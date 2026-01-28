using RRUHFReaderService.Protocol;

namespace RRUHFReaderAPI.Commands;

public static class CommandBuilder
{
    public static byte[] BuildGetDeviceInfoFrame()
    {
        byte[] txFrame = new byte[5];
        txFrame[0] = 0xBB;
        txFrame[1] = 0x01;
        txFrame[2] = 0x01;

        ushort crc = CRC16.Calc(txFrame, 2, 1);
        txFrame[3] = (byte)(crc >> 8);
        txFrame[4] = (byte)(crc);

        return txFrame;
    }

    public static byte[] BuildGetWorkingModeFrame()
    {
        byte[] txFrame = new byte[5];
        txFrame[0] = 0xBB;
        txFrame[1] = 0x01;
        txFrame[2] = 0x02;

        ushort crc = CRC16.Calc(txFrame, 2, 1);
        txFrame[3] = (byte)(crc >> 8);
        txFrame[4] = (byte)(crc);

        return txFrame;
    }

    public static byte[] BuildSetWorkingModeFrame(byte workingMode)
    {
        byte[] txFrame = new byte[6];
        txFrame[0] = 0xBB;
        txFrame[1] = 0x02;
        txFrame[2] = 0x03;
        txFrame[3] = workingMode;

        ushort crc = CRC16.Calc(txFrame, 2, 2);
        txFrame[4] = (byte)(crc >> 8);
        txFrame[5] = (byte)(crc);

        return txFrame;
    }

    public static byte[] BuildInventoryFrame()
    {
        byte[] txFrame = new byte[5];
        txFrame[0] = 0xBB;
        txFrame[1] = 0x01;
        txFrame[2] = 0x20;

        ushort crc = CRC16.Calc(txFrame, 2, 1);
        txFrame[3] = (byte)(crc >> 8);
        txFrame[4] = (byte)(crc);

        return txFrame;
    }

    public static byte[] BuildGetRFPowerFrame()
    {
        byte[] txFrame = new byte[5];
        txFrame[0] = 0xBB;
        txFrame[1] = 0x01;
        txFrame[2] = 0x10;

        ushort crc = CRC16.Calc(txFrame, 2, 1);
        txFrame[3] = (byte)(crc >> 8);
        txFrame[4] = (byte)(crc);

        return txFrame;
    }

    public static byte[] BuildSetRFPowerFrame(byte power)
    {
        byte[] txFrame = new byte[6];
        txFrame[0] = 0xBB;
        txFrame[1] = 0x02;
        txFrame[2] = 0x11;
        txFrame[3] = power;

        ushort crc = CRC16.Calc(txFrame, 2, 2);
        txFrame[4] = (byte)(crc >> 8);
        txFrame[5] = (byte)(crc);

        return txFrame;
    }

    public static byte[] BuildGetRegionFrame()
    {
        byte[] txFrame = new byte[5];
        txFrame[0] = 0xBB;
        txFrame[1] = 0x01;
        txFrame[2] = 0x14;

        ushort crc = CRC16.Calc(txFrame, 2, 1);
        txFrame[3] = (byte)(crc >> 8);
        txFrame[4] = (byte)(crc);

        return txFrame;
    }

    public static byte[] BuildSetRegionFrame(byte region)
    {
        byte[] txFrame = new byte[6];
        txFrame[0] = 0xBB;
        txFrame[1] = 0x02;
        txFrame[2] = 0x15;
        txFrame[3] = region;

        ushort crc = CRC16.Calc(txFrame, 2, 2);
        txFrame[4] = (byte)(crc >> 8);
        txFrame[5] = (byte)(crc);

        return txFrame;
    }

    public static byte[] BuildRestartDeviceFrame()
    {
        byte[] txFrame = new byte[5];
        txFrame[0] = 0xBB;
        txFrame[1] = 0x01;
        txFrame[2] = 0x0C;

        ushort crc = CRC16.Calc(txFrame, 2, 1);
        txFrame[3] = (byte)(crc >> 8);
        txFrame[4] = (byte)(crc);

        return txFrame;
    }
}
