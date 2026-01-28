namespace RRUHFReaderService.Protocol;

public class FrameParser
{
    private const byte SOF = 0xBB;
    private bool _frameBeginFlag;
    private int _idx;
    private int _packetLength;
    private readonly byte[] _packetBuffer = new byte[4096];

    public event EventHandler<byte[]>? PacketReceived;

    public void ProcessData(byte[] data)
    {
        foreach (byte b in data)
        {
            if (_frameBeginFlag)
            {
                _packetBuffer[_idx] = b;

                if (_idx == 0)
                {
                    _packetLength = b;
                    // Validate packet length to prevent buffer overflow
                    if (_packetLength > 4090) // Leave room for header/CRC
                    {
                        _frameBeginFlag = false;
                        continue;
                    }
                }

                if (_idx == _packetLength + 2)
                {
                    // Check CRC
                    int packetCrc = (_packetBuffer[_packetLength + 1] << 8) | _packetBuffer[_packetLength + 2];
                    int calculatedCrc = CRC16.Calc(_packetBuffer, 1, _packetLength);

                    if (packetCrc == calculatedCrc)
                    {
                        byte[] response = new byte[_packetLength];
                        Array.Copy(_packetBuffer, 1, response, 0, _packetLength);
                        PacketReceived?.Invoke(this, response);
                    }

                    _frameBeginFlag = false;
                }

                _idx++;
            }
            else
            {
                // Wait for SOF
                if (b == SOF)
                {
                    _idx = 0;
                    _packetLength = 0;
                    _frameBeginFlag = true;
                }
            }
        }
    }

    public static InventoryResponse? ParseInventoryResponse(byte[] rxFrame)
    {
        if (rxFrame.Length < 3 || rxFrame[0] != 0xE0)
            return null;

        try
        {
            int idx = 1;
            var response = new InventoryResponse { RawData = rxFrame };

            // Parse flags
            byte flags = rxFrame[idx];
            bool isWithUid = (flags & 0x01) == 0x01;
            bool isWithTid = (flags & 0x02) == 0x02;
            // TID-only mode: TID field is present but not UID, so TID should be used as the identifier
            bool isTidOnly = (flags & 0x03) == 0x02;
            bool isWithRssi = (flags & 0x04) == 0x04;
            bool isWithUserMem = (flags & 0x08) == 0x08;
            bool isWithAntennaId = (flags & 0x10) == 0x10;
            bool isWithDeviceId = (flags & 0x40) == 0x40;
            bool isTimeStampPresent = (flags & 0x80) == 0x80;

            idx++;

            // Device ID
            if (isWithDeviceId)
            {
                byte[] devId = new byte[4];
                Array.Copy(rxFrame, idx, devId, 0, 4);
                Array.Reverse(devId);
                response.DeviceId = BitConverter.ToUInt32(devId, 0);
                idx += 4;
            }

            // Timestamp
            if (isTimeStampPresent)
            {
                byte[] timestamp = new byte[6];
                Array.Copy(rxFrame, idx, timestamp, 0, 6);
                response.Timestamp = Helpers.TimeStampStr(timestamp);
                idx += 6;
            }

            // Antenna ID
            if (isWithAntennaId)
            {
                response.AntennaId = rxFrame[idx++];
            }

            // EPC/UID
            if (isWithUid)
            {
                byte uidLength = rxFrame[idx++];
                byte[] uid = new byte[uidLength];
                Array.Copy(rxFrame, idx, uid, 0, uidLength);
                response.Epc = Helpers.ByteArrayToHex(uid);
                idx += uidLength;
            }

            // TID
            if (isWithTid)
            {
                byte tidLength = rxFrame[idx++];
                byte[] tid = new byte[tidLength];
                Array.Copy(rxFrame, idx, tid, 0, tidLength);
                response.Tid = Helpers.ByteArrayToHex(tid);
                idx += tidLength;
            }

            // User Memory
            if (isWithUserMem)
            {
                byte memLength = rxFrame[idx++];
                byte[] memData = new byte[memLength];
                Array.Copy(rxFrame, idx, memData, 0, memLength);
                response.UserMemory = Helpers.ByteArrayToHex(memData);
                idx += memLength;
            }

            // RSSI
            if (isWithRssi)
            {
                short rssi = (short)((rxFrame[idx] << 8) | rxFrame[idx + 1]);
                response.Rssi = rssi / 100.0;
                idx += 2;
            }

            // Use TID as EPC if TID-only mode
            if (isTidOnly && !string.IsNullOrEmpty(response.Tid))
            {
                response.Epc = response.Tid;
            }

            return response;
        }
        catch
        {
            return null;
        }
    }
}
