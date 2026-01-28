using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RRUHF_Reader_SDK_Demo
{
 


    public class CommandBuilder
    {
        public static byte[] BuildGetDeviceInfoFrame()
        {
            byte[] TxFrame = new byte[5];

            TxFrame[0] = 0xBB;
            TxFrame[1] = 0x01;
            TxFrame[2] = 0x01;

            ushort crc = CRC16.Calc(TxFrame, 2, 1);
            TxFrame[3] = (byte)(crc >> 8);
            TxFrame[4] = (byte)(crc);

            return (TxFrame);
        }


        public static byte[] BuildGetWorkingModeFrame()
        {
            byte[] TxFrame = new byte[5];

            TxFrame[0] = 0xBB;
            TxFrame[1] = 0x01;
            TxFrame[2] = 0x02;

            ushort crc = CRC16.Calc(TxFrame, 2, 1);
            TxFrame[3] = (byte)(crc >> 8);
            TxFrame[4] = (byte)(crc);

            return (TxFrame);
        }


        public static byte[] BuildSetWorkingModeFrame(byte WorkingMode)
        {
            byte[] TxFrame = new byte[6];

            TxFrame[0] = 0xBB;
            TxFrame[1] = 0x02;
            TxFrame[2] = 0x03;
            TxFrame[3] = WorkingMode;

            ushort crc = CRC16.Calc(TxFrame, 2, 2);
            TxFrame[4] = (byte)(crc >> 8);
            TxFrame[5] = (byte)(crc);

            return (TxFrame);
        }

        public static byte[] BuildSetUsartBaudrate(byte BaudrateIndex)
        {
            byte[] TxFrame = new byte[7];

            TxFrame[0] = 0xBB;
            TxFrame[1] = 0x03;
            TxFrame[2] = 0x05;
            TxFrame[3] = 0x01; //phyID = USART
            TxFrame[4] = BaudrateIndex;

            ushort crc = CRC16.Calc(TxFrame, 2, 3);
            TxFrame[5] = (byte)(crc >> 8);
            TxFrame[6] = (byte)(crc);

            return (TxFrame);
        }


        public static byte[] BuildDHCPConfSetupFrame(byte DHCP_Enable)
        {
            byte[] TxFrame = new byte[7];

            TxFrame[0] = 0xBB;
            TxFrame[1] = 0x03;
            TxFrame[2] = 0x05;
            TxFrame[3] = 0x03; //phyID = TCP_DHCP
            TxFrame[4] = DHCP_Enable;

            ushort crc = CRC16.Calc(TxFrame, 2, 3);
            TxFrame[5] = (byte)(crc >> 8);
            TxFrame[6] = (byte)(crc);

            return (TxFrame);
        }

        public static byte[] BuildGlobalPasswordAuthenticateFrame(byte[] Password)
        {
            byte[] TxFrame = new byte[22];
            int idx = 0;

            if (Password.Length == 16)
            {
                TxFrame[idx++] = 0xBB;
                TxFrame[idx++] = (byte)(0x02 + Password.Length);
                TxFrame[idx++] = 0x0F;//Main command
                TxFrame[idx++] = 0x01;//Sub command (Authenticate)

                Array.Copy((byte[])Password, 0, TxFrame, idx, Password.Length);
                idx += Password.Length;

                int Length = idx - 2;
                ushort crc = CRC16.Calc(TxFrame, 2, Length);
                TxFrame[idx++] = (byte)(crc >> 8);
                TxFrame[idx++] = (byte)(crc);
            }

            return (TxFrame);
        }

        public static byte[] BuildGlobalPasswordDeauthenticateFrame()
        {
            byte[] TxFrame = new byte[6];
            int idx = 0;

            TxFrame[idx++] = 0xBB;
            TxFrame[idx++] = 0x02;
            TxFrame[idx++] = 0x0F;//Main command
            TxFrame[idx++] = 0x02;//Sub command (De-authenticate)

            ushort crc = CRC16.Calc(TxFrame, 2, 2);
            TxFrame[idx++] = (byte)(crc >> 8);
            TxFrame[idx++] = (byte)(crc);

            return (TxFrame);
        }

        public static byte[] BuildGlobalPasswordUpdateFrame(byte[] OldPassword, byte[] NewPassword)
        {
            byte[] TxFrame = new byte[38];
            int idx = 0;
            int Length;

            if ((OldPassword.Length == 16) && (NewPassword.Length == 16))
            {
                TxFrame[idx++] = 0xBB;
                TxFrame[idx++] = 0x04;
                TxFrame[idx++] = 0x0F;//Main command
                TxFrame[idx++] = 0x03;//Sub command (De-authenticate)

                Array.Copy((byte[])OldPassword, 0, TxFrame, idx, OldPassword.Length);//copy old password
                idx += OldPassword.Length;

                Array.Copy((byte[])NewPassword, 0, TxFrame, idx, NewPassword.Length);//copy new password
                idx += NewPassword.Length;

                Length = idx - 2;
                TxFrame[1] = (byte)Length;
                ushort crc = CRC16.Calc(TxFrame, 2, Length);
                TxFrame[idx++] = (byte)(crc >> 8);
                TxFrame[idx++] = (byte)(crc);
            }

            return (TxFrame);
        }

        public static byte[] BuildInventoryFrame()
        {
            byte[] TxFrame = new byte[5];
            
            TxFrame[0] = 0xBB;
            TxFrame[1] = 0x01;
            TxFrame[2] = 0x20;

            ushort crc = CRC16.Calc(TxFrame, 2, 1);
            TxFrame[3] = (byte)(crc >> 8);
            TxFrame[4] = (byte)(crc);

            return (TxFrame);
        }


        public static byte[] BuildExtendedInventoryFrame(byte MuxConfig)
        {
            byte[] TxFrame = new byte[7];

            TxFrame[0] = 0xBB;
            TxFrame[1] = 0x03;
            TxFrame[2] = 0x20;
            TxFrame[3] = 0x01;
            TxFrame[4] = MuxConfig;

            ushort crc = CRC16.Calc(TxFrame, 2, 3);
            TxFrame[5] = (byte)(crc >> 8);
            TxFrame[6] = (byte)(crc);

            return (TxFrame);
        }

        public static byte[] BuildExtInventoryFrame(byte ExtOptions)
        {
            byte[] TxFrame = new byte[6];

            TxFrame[0] = 0xBB;
            TxFrame[1] = 0x02;
            TxFrame[2] = 0x21;
            TxFrame[3] = ExtOptions;

            ushort crc = CRC16.Calc(TxFrame, 2, 2);
            TxFrame[4] = (byte)(crc >> 8);
            TxFrame[5] = (byte)(crc);

            return (TxFrame);
        }


        public static byte[] BuildGetRFPowerFrame()
        {
            byte[] TxFrame = new byte[5];

            TxFrame[0] = 0xBB;
            TxFrame[1] = 0x01;
            TxFrame[2] = 0x10;

            ushort crc = CRC16.Calc(TxFrame, 2, 1);
            TxFrame[3] = (byte)(crc >> 8);
            TxFrame[4] = (byte)(crc);

            return (TxFrame);
        }


        public static byte[] BuildSetRFPowerFrame(ushort RFPower)
        {
            byte[] TxFrame = new byte[7];

            if (RFPower > 3300) { RFPower = 3300; }
            if (RFPower < 100)  { RFPower = 100; }

            TxFrame[0] = 0xBB;
            TxFrame[1] = 0x03;
            TxFrame[2] = 0x11;
            TxFrame[3] = (byte)(RFPower >> 8);
            TxFrame[4] = (byte)(RFPower);

            ushort crc = CRC16.Calc(TxFrame, 2, 3);
            TxFrame[5] = (byte)(crc >> 8);
            TxFrame[6] = (byte)(crc);

            return (TxFrame);
        }

        public static byte[] BuildGetRFModeFrame()
        {
            byte[] TxFrame = new byte[5];

            TxFrame[0] = 0xBB;
            TxFrame[1] = 0x01;
            TxFrame[2] = 0x12;

            ushort crc = CRC16.Calc(TxFrame, 2, 1);
            TxFrame[3] = (byte)(crc >> 8);
            TxFrame[4] = (byte)(crc);

            return (TxFrame);
        }

        public static byte[] BuildSetRFModeFrame(ushort RFMode)
        {
            byte[] TxFrame = new byte[7];

            TxFrame[0] = 0xBB;
            TxFrame[1] = 0x03;
            TxFrame[2] = 0x13;
            TxFrame[3] = (byte)(RFMode >> 8);
            TxFrame[4] = (byte)(RFMode);

            ushort crc = CRC16.Calc(TxFrame, 2, 3);
            TxFrame[5] = (byte)(crc >> 8);
            TxFrame[6] = (byte)(crc);

            return (TxFrame);
        }

        public static byte[] BuildGetInventoryQFrame()
        {
            byte[] TxFrame = new byte[5];

            TxFrame[0] = 0xBB;
            TxFrame[1] = 0x01;
            TxFrame[2] = 0x16;

            ushort crc = CRC16.Calc(TxFrame, 2, 1);
            TxFrame[3] = (byte)(crc >> 8);
            TxFrame[4] = (byte)(crc);

            return (TxFrame);
        }

        public static byte[] BuildSetInventoryQFrame(byte QValue)
        {
            byte[] TxFrame = new byte[6];

            TxFrame[0] = 0xBB;
            TxFrame[1] = 0x02;
            TxFrame[2] = 0x17;
            TxFrame[3] = QValue;

            ushort crc = CRC16.Calc(TxFrame, 2, 2);
            TxFrame[4] = (byte)(crc >> 8);
            TxFrame[5] = (byte)(crc);

            return (TxFrame);
        }


        public static byte[] BuildGetInventorySessionFrame()
        {
            byte[] TxFrame = new byte[5];

            TxFrame[0] = 0xBB;
            TxFrame[1] = 0x01;
            TxFrame[2] = 0x18;

            ushort crc = CRC16.Calc(TxFrame, 2, 1);
            TxFrame[3] = (byte)(crc >> 8);
            TxFrame[4] = (byte)(crc);

            return (TxFrame);
        }

        public static byte[] BuildSetInventorySessionFrame(byte SValue)
        {
            byte[] TxFrame = new byte[6];

            TxFrame[0] = 0xBB;
            TxFrame[1] = 0x02;
            TxFrame[2] = 0x19;
            TxFrame[3] = SValue;

            ushort crc = CRC16.Calc(TxFrame, 2, 2);
            TxFrame[4] = (byte)(crc >> 8);
            TxFrame[5] = (byte)(crc);

            return (TxFrame);
        }

        public static byte[] BuildGetInventoryTargetFrame()
        {
            byte[] TxFrame = new byte[5];

            TxFrame[0] = 0xBB;
            TxFrame[1] = 0x01;
            TxFrame[2] = 0x1A;

            ushort crc = CRC16.Calc(TxFrame, 2, 1);
            TxFrame[3] = (byte)(crc >> 8);
            TxFrame[4] = (byte)(crc);

            return (TxFrame);
        }

        public static byte[] BuildSetInventoryTargetFrame(byte TValue)
        {
            byte[] TxFrame = new byte[6];

            TxFrame[0] = 0xBB;
            TxFrame[1] = 0x02;
            TxFrame[2] = 0x1B;
            TxFrame[3] = TValue;

            ushort crc = CRC16.Calc(TxFrame, 2, 2);
            TxFrame[4] = (byte)(crc >> 8);
            TxFrame[5] = (byte)(crc);

            return (TxFrame);
        }

        public static byte[] BuildGetRFRegionFrame()
        {
            byte[] TxFrame = new byte[5];

            TxFrame[0] = 0xBB;
            TxFrame[1] = 0x01;
            TxFrame[2] = 0x14;

            ushort crc = CRC16.Calc(TxFrame, 2, 1);
            TxFrame[3] = (byte)(crc >> 8);
            TxFrame[4] = (byte)(crc);

            return (TxFrame);
        }

        public static byte[] BuildSetRFRegionFrame(byte RFRegion, byte IdxFreqMin, byte IdxFreqMax)
        {
            byte[] TxFrame = new byte[8];

            TxFrame[0] = 0xBB;
            TxFrame[1] = 0x04;
            TxFrame[2] = 0x15;
            TxFrame[3] = RFRegion;
            TxFrame[4] = IdxFreqMin;
            TxFrame[5] = IdxFreqMax;

            ushort crc = CRC16.Calc(TxFrame, 2, 4);
            TxFrame[6] = (byte)(crc >> 8);
            TxFrame[7] = (byte)(crc);

            return (TxFrame);
        }

        public static byte[] BuildSetRxConfigFrame(byte pga1_gain, byte pga2_gain, byte pga3_gain, byte mixer_gain)
        {
            byte[] TxFrame = new byte[9];

            TxFrame[0] = 0xBB;
            TxFrame[1] = 0x05;
            TxFrame[2] = 0xFE;
            TxFrame[3] = pga1_gain;
            TxFrame[4] = pga2_gain;
            TxFrame[5] = pga3_gain;
            TxFrame[6] = mixer_gain;

            ushort crc = CRC16.Calc(TxFrame, 2, 5);
            TxFrame[7] = (byte)(crc >> 8);
            TxFrame[8] = (byte)(crc);

            return (TxFrame);
        }

        public static byte[] BuildGetRxConfigFrame()
        {
            byte[] TxFrame = new byte[5];

            TxFrame[0] = 0xBB;
            TxFrame[1] = 0x01;
            TxFrame[2] = 0xFD;

            ushort crc = CRC16.Calc(TxFrame, 2, 1);
            TxFrame[3] = (byte)(crc >> 8);
            TxFrame[4] = (byte)(crc);

            return (TxFrame);
        }


        public static byte[] BuildReadBlockFrame(byte EPCLength, byte[] TagEPC, byte[] AccessPW, byte BankAddress, byte[] BlockAddress, byte TotalBlocks)
        {
            int PacketLength = 1 + 1 + 4 + 1 + 2 + 1+ TagEPC.Length;
            int CompletePacketLength = 4 + PacketLength;
            byte[] TxFrame = new byte[CompletePacketLength];
            

            TxFrame[0] = 0xBB;
            TxFrame[1] = (byte)(PacketLength);
            TxFrame[2] = 0x22;
            TxFrame[3] = EPCLength;

            int offset = 4;
            Array.Copy(TagEPC,0, TxFrame, offset, TagEPC.Length);
            offset +=  TagEPC.Length;
            Array.Copy(AccessPW, 0, TxFrame, offset, AccessPW.Length);
            offset += AccessPW.Length;

            TxFrame[offset++] = BankAddress;
            TxFrame[offset++] = BlockAddress[0];
            TxFrame[offset++] = BlockAddress[1];
            TxFrame[offset++] = TotalBlocks;

            ushort crc = CRC16.Calc(TxFrame, 2, PacketLength);
            TxFrame[offset++] = (byte)(crc >> 8);
            TxFrame[offset++] = (byte)(crc);

            return (TxFrame);
        }


        public static byte[] BuildWriteBlockFrame(byte EPCLength, byte[] TagEPC, byte[]AccessPW, byte BankAddress, byte[] BlockAddress, byte TotalBlocks, byte[] Data)
        {
            int PacketLength = 1 + 1 + 4 + 1 + 2 + 1 + TagEPC.Length + Data.Length;
            int CompletePacketLength = 4 + PacketLength;
            byte[] TxFrame = new byte[CompletePacketLength];

            TxFrame[0] = 0xBB;
            TxFrame[1] = (byte)(PacketLength);
            TxFrame[2] = 0x23;
            TxFrame[3] = EPCLength;

            int offset = 4;
            Array.Copy(TagEPC, 0, TxFrame, offset, TagEPC.Length);
            offset += TagEPC.Length;
            Array.Copy(AccessPW, 0, TxFrame, offset, AccessPW.Length);
            offset += AccessPW.Length;

            TxFrame[offset++] = BankAddress;
            TxFrame[offset++] = BlockAddress[0];
            TxFrame[offset++] = BlockAddress[1];
            TxFrame[offset++] = TotalBlocks;

            Array.Copy(Data, 0, TxFrame, offset, Data.Length);
            offset += Data.Length;

            ushort crc = CRC16.Calc(TxFrame, 2, PacketLength);
            TxFrame[offset++] = (byte)(crc >> 8);
            TxFrame[offset++] = (byte)(crc);

            return (TxFrame);
        }


        public static byte[] BuildEraseBlockFrame(byte EPCLength, byte[] TagEPC, byte[] AccessPW, byte BankAddress, byte[] BlockAddress, byte TotalBlocks)
        {
            int PacketLength = 1+1 + 1 + 4 + 2 + 1 + TagEPC.Length;
            int CompletePacketLength = 4 + PacketLength;
            byte[] TxFrame = new byte[CompletePacketLength];

            TxFrame[0] = 0xBB;
            TxFrame[1] = (byte)(PacketLength);
            TxFrame[2] = 0x24;
            TxFrame[3] = EPCLength;

            int offset = 4;
            Array.Copy(TagEPC, 0, TxFrame, offset, TagEPC.Length);
            offset += TagEPC.Length;
            Array.Copy(AccessPW, 0, TxFrame, offset, AccessPW.Length);
            offset += AccessPW.Length;

            TxFrame[offset++] = BankAddress;
            TxFrame[offset++] = BlockAddress[0];
            TxFrame[offset++] = BlockAddress[1];
            TxFrame[offset++] = TotalBlocks;

            ushort crc = CRC16.Calc(TxFrame, 2, PacketLength);
            TxFrame[offset++] = (byte)(crc >> 8);
            TxFrame[offset++] = (byte)(crc);

            return (TxFrame);
        }
        
        public static byte[] BuildTagKillFrame(byte EPCLength, byte[] TagEPC, byte[] KillPW)
        {
            int PacketLength = 1 + 1 + TagEPC.Length + 4 + 1;
            int CompletePacketLength = 4 + PacketLength;
            byte[] TxFrame = new byte[CompletePacketLength];
            int idx = 0;

            TxFrame[idx++] = 0xBB;
            TxFrame[idx++] = (byte)(PacketLength);
            TxFrame[idx++] = 0x27;
            TxFrame[idx++] = 0x00;// RFU
            TxFrame[idx++] = EPCLength;

            Array.Copy(TagEPC, 0, TxFrame, idx, TagEPC.Length);
            idx += TagEPC.Length;
            Array.Copy(KillPW, 0, TxFrame, idx, KillPW.Length);
            idx += KillPW.Length;            

            ushort crc = CRC16.Calc(TxFrame, 2, PacketLength);
            TxFrame[idx++] = (byte)(crc >> 8);
            TxFrame[idx++] = (byte)(crc);

            return (TxFrame);
        }


        public static byte[] BuildWriteEPCFrame(byte EPCLength, byte[] NewEPC, byte[] AccessPW)
        {
            int PacketLength = 1+ 1 + 4 + NewEPC.Length;
            int CompletePacketLength = 4 + PacketLength;
            byte[] TxFrame = new byte[CompletePacketLength];

            TxFrame[0] = 0xBB;
            TxFrame[1] = (byte)(PacketLength);
            TxFrame[2] = 0x25;
            TxFrame[3] = EPCLength;

            int offset = 4;
            Array.Copy(NewEPC, 0, TxFrame, offset, NewEPC.Length);
            offset += NewEPC.Length;
            Array.Copy(AccessPW, 0, TxFrame, offset, AccessPW.Length);
            offset += AccessPW.Length;

            ushort crc = CRC16.Calc(TxFrame, 2, PacketLength);
            TxFrame[offset++] = (byte)(crc >> 8);
            TxFrame[offset++] = (byte)(crc);

            return (TxFrame);
        }


        public static byte[] BuildSetProtectFrame(byte EPCLength, byte[] TagEPC, byte[] AccessPW, byte Target, byte Action)
        {
            int PacketLength = 1 + 1 + 4 + TagEPC.Length + 1 + 1;
            int CompletePacketLength = 4 + PacketLength;
            byte[] TxFrame = new byte[CompletePacketLength];


            TxFrame[0] = 0xBB;
            TxFrame[1] = (byte)(PacketLength);
            TxFrame[2] = 0x26;
            TxFrame[3] = EPCLength;

            int offset = 4;
            Array.Copy(TagEPC, 0, TxFrame, offset, TagEPC.Length);
            offset += TagEPC.Length;
            Array.Copy(AccessPW, 0, TxFrame, offset, AccessPW.Length);
            offset += AccessPW.Length;

            TxFrame[offset++] = Target;
            TxFrame[offset++] = Action;

            ushort crc = CRC16.Calc(TxFrame, 2, PacketLength);
            TxFrame[offset++] = (byte)(crc >> 8);
            TxFrame[offset++] = (byte)(crc);

            return (TxFrame);
        }


        public static byte[] BuildMaskedInventoryAppFrame(byte Enable, byte EPC_MaskLength, byte[] EPC_Mask, byte IO_Number, byte IO_ActiveState, UInt16 DwellTIme_x100ms)
        {
            if (EPC_MaskLength != EPC_Mask.Length) { }

            int PacketLength = 1 + 1 + 1 + EPC_Mask.Length + 1+ 1 + 2;
            int CompletePacketLength = 4 + PacketLength;
            byte[] TxFrame = new byte[CompletePacketLength];
            ushort DwellTime = DwellTIme_x100ms;

            TxFrame[0] = 0xBB;
            TxFrame[1] = (byte)(PacketLength);
            TxFrame[2] = 0xD0;
            TxFrame[3] = Enable;
            TxFrame[4] = EPC_MaskLength;

            int offset = 5;
            Array.Copy(EPC_Mask, 0, TxFrame, offset, EPC_Mask.Length);
            offset += EPC_Mask.Length;

            TxFrame[offset++] = IO_Number;
            TxFrame[offset++] = IO_ActiveState;
            TxFrame[offset++] = (byte)(DwellTime >> 8);
            TxFrame[offset++] = (byte)(DwellTime);
            

            ushort crc = CRC16.Calc(TxFrame, 2, PacketLength);
            TxFrame[offset++] = (byte)(crc >> 8);
            TxFrame[offset++] = (byte)(crc);

            return (TxFrame);
        }

        public static byte[] BuildExtendedInventoryFrame(byte[] RawCmdFrame)
        {            
            //add crc
            byte[] TxFrame = new byte[RawCmdFrame.Length + 5];
            int idx = 0;

            TxFrame[idx++] = 0xBB; //add SOF
            TxFrame[idx++] = Convert.ToByte(RawCmdFrame.Length + 1); //add length
            TxFrame[idx++] = 0xD2; //add cmd code

            Array.Copy(RawCmdFrame, 0, TxFrame, idx, RawCmdFrame.Length); //copy raw frame
            idx += RawCmdFrame.Length;

            ushort crc = CRC16.Calc(TxFrame, 2, RawCmdFrame.Length + 1);
            TxFrame[idx++] = (byte)(crc >> 8);
            TxFrame[idx++] = (byte)(crc);

            return (TxFrame);
        }

        public static byte[] BuildSetComunucationParametersFrame(byte[] RawCmdFrame)
        {
            byte[] TxFrame = new byte[RawCmdFrame.Length + 5];
            int idx = 0;

            TxFrame[idx++] = 0xBB; //add SOF
            TxFrame[idx++] = Convert.ToByte(RawCmdFrame.Length + 1); //add length
            TxFrame[idx++] = 0x05; //add cmd code

            Array.Copy(RawCmdFrame, 0, TxFrame, idx, RawCmdFrame.Length); //copy raw frame
            idx += RawCmdFrame.Length;

            ushort crc = CRC16.Calc(TxFrame, 2, RawCmdFrame.Length + 1);
            TxFrame[idx++] = (byte)(crc >> 8);
            TxFrame[idx++] = (byte)(crc);

            return (TxFrame);
        }

        public static byte[] BuildGetRTC_NowFrame(byte flags)
        {
            byte[] TxFrame = new byte[7];
            int idx = 0;

            TxFrame[idx++] = 0xBB;
            TxFrame[idx++] = 0x03;
            TxFrame[idx++] = 0x04;//main cmd code
            TxFrame[idx++] = 0x08;//sub cmd code-1 (RTC)
            TxFrame[idx++] = flags;

            ushort crc = CRC16.Calc(TxFrame, 2, idx-2);
            TxFrame[idx++] = (byte)(crc >> 8);
            TxFrame[idx++] = (byte)(crc);

            return (TxFrame);
        }

        public static byte[] BuildSetRTC_NowFrame(byte[] RawCmdFrame)
        {
            //RawCmdFrame <flags><hh mm......yy>
            byte[] TxFrame = new byte[RawCmdFrame.Length + 6];
            int idx = 0;

            TxFrame[idx++] = 0xBB; //add SOF
            TxFrame[idx++] = Convert.ToByte(RawCmdFrame.Length + 2); //add length
            TxFrame[idx++] = 0x05; //add cmd code
            TxFrame[idx++] = 0x08; //add sub cmd code

            Array.Copy(RawCmdFrame, 0, TxFrame, idx, RawCmdFrame.Length); //copy raw frame
            idx += RawCmdFrame.Length;

            ushort crc = CRC16.Calc(TxFrame, 2, idx - 2);
            TxFrame[idx++] = (byte)(crc >> 8);
            TxFrame[idx++] = (byte)(crc);

            return (TxFrame);
        }

        public static byte[] BuildGetTCPParametersFrame(byte flags)
        {
            byte[] TxFrame = new byte[7];
            int idx = 0;

            TxFrame[idx++] = 0xBB; //add SOF
            TxFrame[idx++] = 3;
            TxFrame[idx++] = 0x04; //cmd code
            TxFrame[idx++] = 0x02; //phy ID code
            TxFrame[idx++] = flags; //flags

            ushort crc = CRC16.Calc(TxFrame, 2, 3);
            TxFrame[idx++] = (byte)(crc >> 8);
            TxFrame[idx++] = (byte)(crc);

            return TxFrame;
        }

        public static byte[] BuildGetUartParametersFrame()
        {
            byte[] TxFrame = new byte[6];
            int idx = 0;

            TxFrame[idx++] = 0xBB; //add SOF
            TxFrame[idx++] = 2;
            TxFrame[idx++] = 0x04; //cmd code
            TxFrame[idx++] = 0x01; //phy ID code

            ushort crc = CRC16.Calc(TxFrame, 2, 2);
            TxFrame[idx++] = (byte)(crc >> 8);
            TxFrame[idx++] = (byte)(crc);

            return TxFrame;
        }

        public static byte[] BuildGetExtendedInventoryParametersFrame()
        {
            byte[] TxFrame = new byte[5];
            int idx = 0;

            TxFrame[idx++] = 0xBB; //add SOF
            TxFrame[idx++] = 0x01;
            TxFrame[idx++] = 0xD1; //cmd code

            ushort crc = CRC16.Calc(TxFrame, 2, 1);
            TxFrame[idx++] = (byte)(crc >> 8);
            TxFrame[idx++] = (byte)(crc);

            return TxFrame;
        }

        public static byte[] BuildBuzzerEnableFrame(byte enable)
        {
            byte[] TxFrame = new byte[6];
            int idx = 0;

            TxFrame[idx++] = 0xBB; //add SOF
            TxFrame[idx++] = 0x02;
            TxFrame[idx++] = 0x06;
            TxFrame[idx++] = enable;//enable=1,diable=0

            ushort crc = CRC16.Calc(TxFrame, 2, 2);
            TxFrame[idx++] = (byte)(crc >> 8);
            TxFrame[idx++] = (byte)(crc);

            return TxFrame;
        }

        public static byte[] BuildBuzzerBeepFrame(ushort beep_duration_x100ms)
        {
            byte[] TxFrame = new byte[7];
            int idx = 0;

            TxFrame[idx++] = 0xBB; //add SOF
            TxFrame[idx++] = 0x03;
            TxFrame[idx++] = 0x07;
            TxFrame[idx++] = (byte)((beep_duration_x100ms & 0xFF00) >> 8);
            TxFrame[idx++] = (byte)((beep_duration_x100ms & 0x00FF));

            ushort crc = CRC16.Calc(TxFrame, 2, 3);
            TxFrame[idx++] = (byte)(crc >> 8);
            TxFrame[idx++] = (byte)(crc);

            return TxFrame;
        }


        public static byte[] BuildAutoAccessAPIType(byte type)
        {
            byte[] TxFrame = new byte[6];
            int idx = 0;

            TxFrame[idx++] = 0xBB; //add SOF
            TxFrame[idx++] = 0x02;
            TxFrame[idx++] = 0xEF;
            TxFrame[idx++] = type;

            ushort crc = CRC16.Calc(TxFrame, 2, 2);
            TxFrame[idx++] = (byte)(crc >> 8);
            TxFrame[idx++] = (byte)(crc);

            return (TxFrame);
        }

        public static byte[] BuildIOCtrlFrame(byte IONum, byte SetReset)
        {
            byte[] TxFrame = new byte[7];
            int idx = 0;

            TxFrame[idx++] = 0xBB; //add SOF
            TxFrame[idx++] = 0x03;
            TxFrame[idx++] = 0x08;
            TxFrame[idx++] = IONum;
            TxFrame[idx++] = SetReset;

            ushort crc = CRC16.Calc(TxFrame, 2, 3);
            TxFrame[idx++] = (byte)(crc >> 8);
            TxFrame[idx++] = (byte)(crc);

            return (TxFrame);
        }

        public static byte[] BuildIOCtrlFrame(byte IOBits)
        {
            byte[] TxFrame = new byte[7];
            int idx = 0;

            TxFrame[idx++] = 0xBB; //add SOF
            TxFrame[idx++] = 0x03;
            TxFrame[idx++] = 0x08;
            TxFrame[idx++] = 0xC0;
            TxFrame[idx++] = IOBits;

            ushort crc = CRC16.Calc(TxFrame, 2, 3);
            TxFrame[idx++] = (byte)(crc >> 8);
            TxFrame[idx++] = (byte)(crc);

            return (TxFrame);
        }

        public static byte[] BuildIOCtrlFrame(byte IONum, ushort Timeoutx100mSec)
        {
            byte[] TxFrame = new byte[8];
            int idx = 0;

            TxFrame[idx++] = 0xBB; //add SOF
            TxFrame[idx++] = 0x04;
            TxFrame[idx++] = 0x08;
            TxFrame[idx++] = IONum;
            TxFrame[idx++] = (byte)((Timeoutx100mSec & 0xFF00) >> 8);
            TxFrame[idx++] = (byte)((Timeoutx100mSec & 0x00FF));

            ushort crc = CRC16.Calc(TxFrame, 2, 4);
            TxFrame[idx++] = (byte)(crc >> 8);
            TxFrame[idx++] = (byte)(crc);

            return (TxFrame);
        }

        public static byte[] Build_RF_LBT_Diagnosis_Frame(byte flags, UInt32 FreqKHz, Int16 FreqOffset)
        {
            byte[] TxFrame = new byte[7];
            int length = TxFrame.Length;
            int idx = 0;

            TxFrame[idx++] = 0xBB; //add SOF
            TxFrame[idx++] = 0x03;
            TxFrame[idx++] = 0xDA;
            TxFrame[idx++] = 0x01;
            TxFrame[idx++] = flags;

            if((flags & 0x02) == 0x02)//frequency present
            {
                byte[] bFreq;
                bFreq = BitConverter.GetBytes(FreqKHz);
                length += 4;
                Array.Reverse(bFreq);
                Array.Resize(ref TxFrame, length);
                Array.Copy(bFreq, 0, TxFrame, idx, 4);
                idx += 4;
            }

            if ((flags & 0x04) == 0x04)//frequency offset present
            {
                byte[] bFreqOffset;// = new byte[2];
                bFreqOffset = BitConverter.GetBytes(FreqOffset);
                length += 2;
                Array.Resize(ref TxFrame, length);
                Array.Copy(bFreqOffset, 0, TxFrame, idx, 2);
                idx += 2;
            }

            ushort crc = CRC16.Calc(TxFrame, 2, TxFrame.Length - 4);
            TxFrame[idx++] = (byte)(crc >> 8);
            TxFrame[idx++] = (byte)(crc);

            TxFrame[1] = (byte)(TxFrame.Length - 4);
            return (TxFrame);
        }


        public static byte[] BuildHeartbeatFrame(byte InterfaceType, ushort Duration_x100mS)
        {
            byte[] TxFrame = new byte[8];
            byte[] bytes = BitConverter.GetBytes(Duration_x100mS);
            Array.Reverse(bytes);
            int idx = 0;

            TxFrame[idx++] = 0xBB; //add SOF
            TxFrame[idx++] = 0x04; 
            TxFrame[idx++] = 0x0A;
            TxFrame[idx++] = InterfaceType;
            Array.Copy(bytes, 0, TxFrame, idx, 2);
            idx += 2;

            ushort crc = CRC16.Calc(TxFrame, 2, 4);
            TxFrame[idx++] = (byte)(crc >> 8);
            TxFrame[idx++] = (byte)(crc);

            return (TxFrame);
        }


        public static byte[] BuildDeviceRestartFrame()
        {
            byte[] TxFrame = new byte[5];
            int idx = 0;

            TxFrame[idx++] = 0xBB;
            TxFrame[idx++] = 0x01;
            TxFrame[idx++] = 0x0C;

            ushort crc = CRC16.Calc(TxFrame, 2, 1);
            TxFrame[idx++] = (byte)(crc >> 8);
            TxFrame[idx++] = (byte)(crc);

            return (TxFrame);
        }


        public static byte[] BuildWriteEPCMaskFrame(byte MaskAddress, byte[] Mask)
        {
            byte[] TxFrame = new byte[8];
            int idx = 0;

            if ((Mask.Length>0) && (Mask.Length <= 12))
            {
                TxFrame[idx++] = 0xBB;
                TxFrame[idx++] = 0x04;
                TxFrame[idx++] = 0xD3;
                TxFrame[idx++] = 0x01;
                TxFrame[idx++] = MaskAddress;
                TxFrame[idx++] = (byte)Mask.Length;

                Array.Resize(ref TxFrame, Mask.Length + 8);
                Array.Copy(Mask, 0, TxFrame, idx, Mask.Length);
                idx += Mask.Length;
                TxFrame[1] += (byte)Mask.Length;

                ushort crc = CRC16.Calc(TxFrame, 2, TxFrame[1]);
                TxFrame[idx++] = (byte)(crc >> 8);
                TxFrame[idx++] = (byte)(crc);
            }
            else
            {
                throw new Exception("Invalid mask length");
            }

            return (TxFrame);
        }


        public static byte[] BuildReadEPCMaskFrame(byte MaskAddress)
        {
            byte[] TxFrame = new byte[7];

            TxFrame[0] = 0xBB;
            TxFrame[1] = 0x03;
            TxFrame[2] = 0xD3;
            TxFrame[3] = 0x02;
            TxFrame[4] = MaskAddress;

            ushort crc = CRC16.Calc(TxFrame, 2, 3);
            TxFrame[5] = (byte)(crc >> 8);
            TxFrame[6] = (byte)(crc);

            return (TxFrame);
        }

        public static byte[] BuildEnableEPCMaskFrame(byte MaskAddress, byte Enable)
        {
            byte[] TxFrame = new byte[8];
            int idx = 0;

            TxFrame[idx++] = 0xBB;
            TxFrame[idx++] = 0x04;
            TxFrame[idx++] = 0xD3;
            TxFrame[idx++] = 0x03;
            TxFrame[idx++] = MaskAddress;
            TxFrame[idx++] = Enable;

            ushort crc = CRC16.Calc(TxFrame, 2, TxFrame[1]);
            TxFrame[idx++] = (byte)(crc >> 8);
            TxFrame[idx++] = (byte)(crc);

            return (TxFrame);
        }

        public static byte[] BuildEraseEPCMaskFrame(byte MaskAddress)
        {
            byte[] TxFrame = new byte[7];
            int idx = 0;

            TxFrame[idx++] = 0xBB;
            TxFrame[idx++] = 0x03;
            TxFrame[idx++] = 0xD3;
            TxFrame[idx++] = 0x04;
            TxFrame[idx++] = MaskAddress;

            ushort crc = CRC16.Calc(TxFrame, 2, TxFrame[1]);
            TxFrame[idx++] = (byte)(crc >> 8);
            TxFrame[idx++] = (byte)(crc);

            return (TxFrame);
        }

        public static byte[] BuildForceBootModeFrame()
        {
            byte[] TxFrame = new byte[5];
            int idx = 0;

            TxFrame[idx++] = 0xBB; //add SOF
            TxFrame[idx++] = 0x01;
            TxFrame[idx++] = 0x0D;

            ushort crc = CRC16.Calc(TxFrame, 2, 1);
            TxFrame[idx++] = (byte)(crc >> 8);
            TxFrame[idx++] = (byte)(crc);

            return (TxFrame);
        }

        public static byte[] BuildExtAutoInventorySoftTriggerFrame()
        {
            byte[] TxFrame = new byte[5];
            int idx = 0;

            TxFrame[idx++] = 0xBB;
            TxFrame[idx++] = 0x01;
            TxFrame[idx++] = 0xD4;// 

            ushort crc = CRC16.Calc(TxFrame, 2, 1);
            TxFrame[idx++] = (byte)(crc >> 8);
            TxFrame[idx++] = (byte)(crc);

            return (TxFrame);
        }

        public static byte[] BuildExtAutoInentoryGetConfigFalgsFrame()
        {
            byte[] TxFrame = new byte[6];
            int idx = 0;

            TxFrame[idx++] = 0xBB;
            TxFrame[idx++] = 0x02;
            TxFrame[idx++] = 0xD5;//main command
            TxFrame[idx++] = 0x01;//sub command

            ushort crc = CRC16.Calc(TxFrame, 2, 2);
            TxFrame[idx++] = (byte)(crc >> 8);
            TxFrame[idx++] = (byte)(crc);

            return (TxFrame);
        }

        public static byte[] BuildExtInentorySetConfigFlagsFrame(byte Cfg0, byte Cfg1)
        {
            byte[] TxFrame = new byte[8];
            int idx = 0;

            TxFrame[idx++] = 0xBB;
            TxFrame[idx++] = 0x02;
            TxFrame[idx++] = 0xD5;//main command
            TxFrame[idx++] = 0x02;//sub command
            TxFrame[idx++] = Cfg0;
            TxFrame[idx++] = Cfg1;

            ushort crc = CRC16.Calc(TxFrame, 2, 4);
            TxFrame[idx++] = (byte)(crc >> 8);
            TxFrame[idx++] = (byte)(crc);

            return (TxFrame);
        }

        public static byte[] BuildExtIncentorySoftTriggerCtrlFrame(byte TriggerEnable)
        {
            byte[] TxFrame = new byte[7];
            int idx = 0;

            TxFrame[idx++] = 0xBB;
            TxFrame[idx++] = 0x03;
            TxFrame[idx++] = 0xD5;//main command
            TxFrame[idx++] = 0x03;//sub command
            TxFrame[idx++] = TriggerEnable;
 

            ushort crc = CRC16.Calc(TxFrame, 2, 3);
            TxFrame[idx++] = (byte)(crc >> 8);
            TxFrame[idx++] = (byte)(crc);

            return (TxFrame);
        }

        public static byte[] BuildExtInventoryMuxConfigGetFrame()
        {
            byte[] TxFrame = new byte[6];
            int idx = 0;

            TxFrame[idx++] = 0xBB;
            TxFrame[idx++] = 0x02;
            TxFrame[idx++] = 0xD5;
            TxFrame[idx++] = 0x07;

            ushort crc = CRC16.Calc(TxFrame, 2, 2);
            TxFrame[idx++] = (byte)(crc >> 8);
            TxFrame[idx++] = (byte)(crc);

            return (TxFrame);
        }

        public static byte[] BuildExtInventoryMuxConfigSetFrame(byte MuxConfig)
        {
            byte[] TxFrame = new byte[7];
            int idx = 0;

            TxFrame[idx++] = 0xBB;
            TxFrame[idx++] = 0x03;
            TxFrame[idx++] = 0xD5;
            TxFrame[idx++] = 0x08;
            TxFrame[idx++] = MuxConfig;

            ushort crc = CRC16.Calc(TxFrame, 2, 3);
            TxFrame[idx++] = (byte)(crc >> 8);
            TxFrame[idx++] = (byte)(crc);

            return (TxFrame);
        }

        public static byte[] BuildExtInventoryRespPathGetFrame()
        {
            byte[] TxFrame = new byte[6];
            int idx = 0;

            TxFrame[idx++] = 0xBB;
            TxFrame[idx++] = 0x02;
            TxFrame[idx++] = 0xD6;
            TxFrame[idx++] = 0x01;

            ushort crc = CRC16.Calc(TxFrame, 2, 2);
            TxFrame[idx++] = (byte)(crc >> 8);
            TxFrame[idx++] = (byte)(crc);

            return (TxFrame);
        }

        public static byte[] BuildExtInventoryRespPathSetFrame(byte RespPath)
        {
            byte[] TxFrame = new byte[7];
            int idx = 0;

            TxFrame[idx++] = 0xBB;
            TxFrame[idx++] = 0x03;
            TxFrame[idx++] = 0xD6;
            TxFrame[idx++] = 0x02;
            TxFrame[idx++] = RespPath;

            ushort crc = CRC16.Calc(TxFrame, 2, 3);
            TxFrame[idx++] = (byte)(crc >> 8);
            TxFrame[idx++] = (byte)(crc);

            return (TxFrame);
        }

        public static byte[] BuildBRMGetRecordsCountFrame()
        {
            byte[] TxFrame = new byte[6];
            int idx = 0;

            TxFrame[idx++] = 0xBB;
            TxFrame[idx++] = 0x02;
            TxFrame[idx++] = 0xD7;
            TxFrame[idx++] = 0x01;

            ushort crc = CRC16.Calc(TxFrame, 2, 2);
            TxFrame[idx++] = (byte)(crc >> 8);
            TxFrame[idx++] = (byte)(crc);

            return (TxFrame);
        }

        public static byte[] BuildBRMGetSingleRecordFrame()
        {
            byte[] TxFrame = new byte[6];
            int idx = 0;

            TxFrame[idx++] = 0xBB;
            TxFrame[idx++] = 0x02;
            TxFrame[idx++] = 0xD7;
            TxFrame[idx++] = 0x02;

            ushort crc = CRC16.Calc(TxFrame, 2, 2);
            TxFrame[idx++] = (byte)(crc >> 8);
            TxFrame[idx++] = (byte)(crc);

            return (TxFrame);
        }

        public static byte[] BuildGetExtInvPersistanceConfFrame()
        {
            byte[] TxFrame = new byte[6];
            int idx = 0;

            TxFrame[idx++] = 0xBB;
            TxFrame[idx++] = 0x02;
            TxFrame[idx++] = 0xD8;
            TxFrame[idx++] = 0x01;

            ushort crc = CRC16.Calc(TxFrame, 2, 2);
            TxFrame[idx++] = (byte)(crc >> 8);
            TxFrame[idx++] = (byte)(crc);

            return (TxFrame);
        }


        public static byte[] BuildSetExtInvPersistanceFrame(byte Enable, ushort Persistence_ms100)
        {
            byte[] TxFrame = new byte[9];
            int idx = 0;

            TxFrame[idx++] = 0xBB;
            TxFrame[idx++] = 0x05;
            TxFrame[idx++] = 0xD8;
            TxFrame[idx++] = 0x02;
            TxFrame[idx++] = Enable;
            TxFrame[idx++] = (byte)(Persistence_ms100>>8);
            TxFrame[idx++] = (byte)(Persistence_ms100);

            ushort crc = CRC16.Calc(TxFrame, 2, 5);
            TxFrame[idx++] = (byte)(crc >> 8);
            TxFrame[idx++] = (byte)(crc);

            return (TxFrame);
        }

        public static byte[] BuildGetOneShotInventoryCycleTimeFrame()
        {
            byte[] TxFrame = new byte[6];
            int idx = 0;

            TxFrame[idx++] = 0xBB;
            TxFrame[idx++] = 0x02;
            TxFrame[idx++] = 0xD8;
            TxFrame[idx++] = 0x05;

            ushort crc = CRC16.Calc(TxFrame, 2, 2);
            TxFrame[idx++] = (byte)(crc >> 8);
            TxFrame[idx++] = (byte)(crc);

            return (TxFrame);
        }


        public static byte[] BuildSetOneShotInventoryCycleTimeFrame(ushort CycleTime_msec)
        {
            byte[] TxFrame = new byte[8];
            int idx = 0;

            TxFrame[idx++] = 0xBB;
            TxFrame[idx++] = 0x04;
            TxFrame[idx++] = 0xD8;
            TxFrame[idx++] = 0x06;
            TxFrame[idx++] = (byte)(CycleTime_msec >> 8);
            TxFrame[idx++] = (byte)(CycleTime_msec);

            ushort crc = CRC16.Calc(TxFrame, 2, 4);
            TxFrame[idx++] = (byte)(crc >> 8);
            TxFrame[idx++] = (byte)(crc);

            return (TxFrame);
        }

        public static byte[] BuildInventoryGetLogedRecordCountFrame()
        {
            byte[] TxFrame = new byte[6];
            int idx = 0;

            TxFrame[idx++] = 0xBB;
            TxFrame[idx++] = 0x02;
            TxFrame[idx++] = 0xDE;//main cmd code
            TxFrame[idx++] = 0x01;//sub cmd code

            ushort crc = CRC16.Calc(TxFrame, 2, idx - 2);
            TxFrame[idx++] = (byte)(crc >> 8);
            TxFrame[idx++] = (byte)(crc);

            return (TxFrame);
        }
        public static byte[] BuildInventoryLogAutoReadStartFrame()
        {
            byte[] TxFrame = new byte[6];
            int idx = 0;

            TxFrame[idx++] = 0xBB;
            TxFrame[idx++] = 0x02;
            TxFrame[idx++] = 0xDE;//main cmd code
            TxFrame[idx++] = 0x02;//sub cmd code

            ushort crc = CRC16.Calc(TxFrame, 2, idx - 2);
            TxFrame[idx++] = (byte)(crc >> 8);
            TxFrame[idx++] = (byte)(crc);

            return (TxFrame);
        }

        public static byte[] BuildInventoryLogAutoReadStopFrame()
        {
            byte[] TxFrame = new byte[6];
            int idx = 0;

            TxFrame[idx++] = 0xBB;
            TxFrame[idx++] = 0x02;
            TxFrame[idx++] = 0xDE;//main cmd code
            TxFrame[idx++] = 0x03;//sub cmd code

            ushort crc = CRC16.Calc(TxFrame, 2, idx - 2);
            TxFrame[idx++] = (byte)(crc >> 8);
            TxFrame[idx++] = (byte)(crc);

            return (TxFrame);
        }

        public static byte[] BuildInventoryLogAutoReadResetFrame()
        {
            byte[] TxFrame = new byte[6];
            int idx = 0;

            TxFrame[idx++] = 0xBB;
            TxFrame[idx++] = 0x02;
            TxFrame[idx++] = 0xDE;//main cmd code
            TxFrame[idx++] = 0x04;//sub cmd code

            ushort crc = CRC16.Calc(TxFrame, 2, idx - 2);
            TxFrame[idx++] = (byte)(crc >> 8);
            TxFrame[idx++] = (byte)(crc);

            return (TxFrame);
        }

        public static byte[] BuildInventoryLogEraseAllFrame()
        {
            byte[] TxFrame = new byte[6];
            int idx = 0;

            TxFrame[idx++] = 0xBB;
            TxFrame[idx++] = 0x02;
            TxFrame[idx++] = 0xDE;//main cmd code
            TxFrame[idx++] = 0xFE;//sub cmd code

            ushort crc = CRC16.Calc(TxFrame, 2, idx - 2);
            TxFrame[idx++] = (byte)(crc >> 8);
            TxFrame[idx++] = (byte)(crc);

            return (TxFrame);
        }

        public static byte[] BuildParkingmodeRegisterSingleID_Frame(byte Category, byte FlagGroup1, byte FlagGroup0, byte[] TID)
        {
            byte[] TxFrame = new byte[10];
            int idx = 0;
            int Length;

            TxFrame[idx++] = 0xBB;
            TxFrame[idx++] = 0x05;
            TxFrame[idx++] = 0xA0;//Parking mode main command
            TxFrame[idx++] = 0x01;//Parking mode sub command (Register new tag (TID))
            TxFrame[idx++] = Category;
            TxFrame[idx++] = FlagGroup1;
            TxFrame[idx++] = FlagGroup0;
            TxFrame[idx++] = (byte)TID.Length;

            Array.Resize(ref TxFrame, 10 + TID.Length);
            Array.Copy(TID, 0, TxFrame, idx, TID.Length);
            idx += TID.Length;

            Length = idx - 2;
            TxFrame[1] = (byte)Length;
            ushort crc = CRC16.Calc(TxFrame, 2, Length);
            TxFrame[idx++] = (byte)(crc >> 8);
            TxFrame[idx++] = (byte)(crc);

            return (TxFrame);
        }

        public static byte[] BuildParkingmodeGetRecordCountersFrame()
        {
            byte[] TxFrame = new byte[6];
            int idx = 0;

            TxFrame[idx++] = 0xBB;
            TxFrame[idx++] = 0x02;
            TxFrame[idx++] = 0xA0;//Parking mode main command
            TxFrame[idx++] = 0x04;//Parking mode sub command (Register new tag (TID))

            ushort crc = CRC16.Calc(TxFrame, 2, 2);
            TxFrame[idx++] = (byte)(crc >> 8);
            TxFrame[idx++] = (byte)(crc);

            return (TxFrame);
        }

        public static byte[] BuildParkingmodeGetSingleRecordFrame()
        {
            byte[] TxFrame = new byte[6];
            int idx = 0;

            TxFrame[idx++] = 0xBB;
            TxFrame[idx++] = 0x02;
            TxFrame[idx++] = 0xA0;//Parking mode main command
            TxFrame[idx++] = 0x05;//Parking mode sub command (Register new tag (TID))

            ushort crc = CRC16.Calc(TxFrame, 2, 2);
            TxFrame[idx++] = (byte)(crc >> 8);
            TxFrame[idx++] = (byte)(crc);

            return (TxFrame);
        }

        public static byte[] BuildParkingmodeCheckRecordStatusFrame(byte[] TID)
        {
            byte[] TxFrame = new byte[7];
            int idx = 0;
            int Length;

            TxFrame[idx++] = 0xBB;
            TxFrame[idx++] = 0x05;
            TxFrame[idx++] = 0xA0;//Parking mode main command
            TxFrame[idx++] = 0x09;//Parking mode sub command (Register new tag (TID))
            TxFrame[idx++] = (byte)TID.Length;

            Array.Resize(ref TxFrame, 7 + TID.Length);
            Array.Copy(TID, 0, TxFrame, idx, TID.Length);
            idx += TID.Length;

            Length = idx - 2;
            TxFrame[1] = (byte)Length;
            ushort crc = CRC16.Calc(TxFrame, 2, Length);
            TxFrame[idx++] = (byte)(crc >> 8);
            TxFrame[idx++] = (byte)(crc);

            return (TxFrame);
        }

        public static byte[] BuildParkingmodeModifyRegisteredID_Frame(byte Category, byte FlagGroup1, byte FlagGroup0, byte[] TID)
        {
            byte[] TxFrame = new byte[10];
            int idx = 0;
            int Length;

            TxFrame[idx++] = 0xBB;
            TxFrame[idx++] = 0x05;
            TxFrame[idx++] = 0xA0;//Parking mode main command
            TxFrame[idx++] = 0x0A;//Parking mode sub command (Update registered tag (TID))
            TxFrame[idx++] = Category;
            TxFrame[idx++] = FlagGroup1;
            TxFrame[idx++] = FlagGroup0;
            TxFrame[idx++] = (byte)TID.Length;

            Array.Resize(ref TxFrame, 10 + TID.Length);
            Array.Copy(TID, 0, TxFrame, idx, TID.Length);
            idx += TID.Length;

            Length = idx - 2;
            TxFrame[1] = (byte)Length;
            ushort crc = CRC16.Calc(TxFrame, 2, Length);
            TxFrame[idx++] = (byte)(crc >> 8);
            TxFrame[idx++] = (byte)(crc);

            return (TxFrame);
        }

        public static byte[] BuildParkingmodeDeleteSingleRecordFrame(byte[] TID)
        {
            byte[] TxFrame = new byte[7];
            int idx = 0;
            int Length;

            TxFrame[idx++] = 0xBB;
            TxFrame[idx++] = 0x05;
            TxFrame[idx++] = 0xA0;//Parking mode main command
            TxFrame[idx++] = 0x0B;//Parking mode sub command (delete existing tag (TID))
            TxFrame[idx++] = (byte)TID.Length;

            Array.Resize(ref TxFrame, 7 + TID.Length);
            Array.Copy(TID, 0, TxFrame, idx, TID.Length);
            idx += TID.Length;

            Length = idx - 2;
            TxFrame[1] = (byte)Length;
            ushort crc = CRC16.Calc(TxFrame, 2, Length);
            TxFrame[idx++] = (byte)(crc >> 8);
            TxFrame[idx++] = (byte)(crc);

            return (TxFrame);
        }

        public static byte[] BuildParkingmodeGetCatogriesAttribFrame(byte CatIdxStart, byte CatIdxEnd)
        {
            byte[] TxFrame = new byte[8];
            int idx = 0;
            int Length;

            TxFrame[idx++] = 0xBB;
            TxFrame[idx++] = 0x04;
            TxFrame[idx++] = 0xA0;//Parking mode main command
            TxFrame[idx++] = 0x10;//Parking mode sub command (Get Category(s) attributes)
            TxFrame[idx++] = CatIdxStart;
            TxFrame[idx++] = CatIdxEnd;

            Length = idx - 2;
            ushort crc = CRC16.Calc(TxFrame, 2, Length);
            TxFrame[idx++] = (byte)(crc >> 8);
            TxFrame[idx++] = (byte)(crc);

            return (TxFrame);
        }

        public static byte[] BuildParkingmodeSetCatogriesAttribFrame(byte CatIdxStart, byte CatIdxEnd, byte[] CatAttributes)
        {
            byte[] TxFrame = new byte[8];
            int idx = 0;
            int Length;

            TxFrame[idx++] = 0xBB;
            TxFrame[idx++] = 0x04;
            TxFrame[idx++] = 0xA0;//Parking mode main command
            TxFrame[idx++] = 0x11;//Parking mode sub command (Set Category(s) attributes)
            TxFrame[idx++] = CatIdxStart;
            TxFrame[idx++] = CatIdxEnd;

            Array.Resize(ref TxFrame, 8 + CatAttributes.Length);
            Array.Copy(CatAttributes, 0, TxFrame, idx, CatAttributes.Length);
            idx += CatAttributes.Length;

            Length = idx - 2;
            TxFrame[1] = (byte)Length;
            ushort crc = CRC16.Calc(TxFrame, 2, Length);
            TxFrame[idx++] = (byte)(crc >> 8);
            TxFrame[idx++] = (byte)(crc);

            return (TxFrame);
        }

        public static byte[] BuildParkingmodeGetRelayAttribFrame()
        {
            byte[] TxFrame = new byte[6];
            int idx = 0;
            int Length;

            TxFrame[idx++] = 0xBB;
            TxFrame[idx++] = 0x02;
            TxFrame[idx++] = 0xA0;//Parking mode main command
            TxFrame[idx++] = 0x12;//Parking mode sub command (Get Category(s) attributes)

            Length = idx - 2;
            ushort crc = CRC16.Calc(TxFrame, 2, Length);
            TxFrame[idx++] = (byte)(crc >> 8);
            TxFrame[idx++] = (byte)(crc);

            return (TxFrame);
        }

        public static byte[] BuildParkingmodeSetRelaysAttribFrame(byte[] RelaysAttributes)
        {
            byte[] TxFrame = new byte[6];
            int idx = 0;
            int Length;

            TxFrame[idx++] = 0xBB;
            TxFrame[idx++] = 0x04;
            TxFrame[idx++] = 0xA0;//Parking mode main command
            TxFrame[idx++] = 0x13;//Parking mode sub command (Set Category(s) attributes)

            Array.Resize(ref TxFrame, 6 + RelaysAttributes.Length);
            Array.Copy(RelaysAttributes, 0, TxFrame, idx, RelaysAttributes.Length);
            idx += RelaysAttributes.Length;

            Length = idx - 2;
            TxFrame[1] = (byte)Length;
            ushort crc = CRC16.Calc(TxFrame, 2, Length);
            TxFrame[idx++] = (byte)(crc >> 8);
            TxFrame[idx++] = (byte)(crc);

            return (TxFrame);
        }

        public static byte[] BuildParkingmodeGetPersistenceFrame()
        {
            byte[] TxFrame = new byte[6];
            int idx = 0;

            TxFrame[idx++] = 0xBB;
            TxFrame[idx++] = 0x02;
            TxFrame[idx++] = 0xA0;//Parking mode main command
            TxFrame[idx++] = 0x20;//Parking mode sub command

            ushort crc = CRC16.Calc(TxFrame, 2, 2);
            TxFrame[idx++] = (byte)(crc >> 8);
            TxFrame[idx++] = (byte)(crc);

            return (TxFrame);
        }

        public static byte[] BuildParkingmodeSetPersistenceFrame(byte AutoResetEnable, ushort Delay_ms100)
        {
            byte[] TxFrame = new byte[9];
            int idx = 0;

            TxFrame[idx++] = 0xBB;
            TxFrame[idx++] = 0x05;
            TxFrame[idx++] = 0xA0;//Parking mode main command
            TxFrame[idx++] = 0x21;//Parking mode sub command
            TxFrame[idx++] = AutoResetEnable;
            TxFrame[idx++] = (byte)(Delay_ms100 >> 8);
            TxFrame[idx++] = (byte)(Delay_ms100);

     
            ushort crc = CRC16.Calc(TxFrame, 2, 5);
            TxFrame[idx++] = (byte)(crc >> 8);
            TxFrame[idx++] = (byte)(crc);

            return (TxFrame);
        }

        public static byte[] BuildParkingmodeGet_TID_RouteFrame()
        {
            byte[] TxFrame = new byte[6];
            int idx = 0;

            TxFrame[idx++] = 0xBB;
            TxFrame[idx++] = 0x02;
            TxFrame[idx++] = 0xA0;//Parking mode main command
            TxFrame[idx++] = 0x22;//Parking mode sub command 

            ushort crc = CRC16.Calc(TxFrame, 2, 2);
            TxFrame[idx++] = (byte)(crc >> 8);
            TxFrame[idx++] = (byte)(crc);

            return (TxFrame);
        }


        public static byte[] BuildParkingmodeSet_TID_RoutFrame(byte Type)
        {
            byte[] TxFrame = new byte[7];
            int idx = 0;

            TxFrame[idx++] = 0xBB;
            TxFrame[idx++] = 0x03;
            TxFrame[idx++] = 0xA0;//Parking mode main command
            TxFrame[idx++] = 0x23;//Parking mode sub command 
            TxFrame[idx++] = Type;

            ushort crc = CRC16.Calc(TxFrame, 2, 3);
            TxFrame[idx++] = (byte)(crc >> 8);
            TxFrame[idx++] = (byte)(crc);

            return (TxFrame);
        }

        public static byte[] BuildParkingmodeGet_TID_OfflineLogConfig()
        {
            byte[] TxFrame = new byte[6];
            int idx = 0;

            TxFrame[idx++] = 0xBB;
            TxFrame[idx++] = 0x02;
            TxFrame[idx++] = 0xA0;//Parking mode main command
            TxFrame[idx++] = 0x24;//Parking mode sub command 

            ushort crc = CRC16.Calc(TxFrame, 2, 2);
            TxFrame[idx++] = (byte)(crc >> 8);
            TxFrame[idx++] = (byte)(crc);

            return (TxFrame);
        }

        public static byte[] BuildParkingmodeSet_TID_OfflineLogConfig(byte Cfg)
        {
            byte[] TxFrame = new byte[7];
            int idx = 0;

            TxFrame[idx++] = 0xBB;
            TxFrame[idx++] = 0x03;
            TxFrame[idx++] = 0xA0;//Parking mode main command
            TxFrame[idx++] = 0x25;//Parking mode sub command 
            TxFrame[idx++] = Cfg;

            ushort crc = CRC16.Calc(TxFrame, 2, 3);
            TxFrame[idx++] = (byte)(crc >> 8);
            TxFrame[idx++] = (byte)(crc);

            return (TxFrame);
        }


        public static byte[] BuildParkingmodeAuthenticateFrame(byte[] Password)
        {
            byte[] TxFrame = new byte[22];
            int idx = 0;

            if (Password.Length == 16)
            {
                TxFrame[idx++] = 0xBB;
                TxFrame[idx++] = (byte)(0x02 + Password.Length);
                TxFrame[idx++] = 0xA0;//Parking mode main command
                TxFrame[idx++] = 0xF0;//Parking mode sub command (Authenticate)

                Array.Copy((byte[])Password, 0, TxFrame, idx, Password.Length);
                idx += Password.Length;

                int Length = idx - 2;
                ushort crc = CRC16.Calc(TxFrame, 2, Length);
                TxFrame[idx++] = (byte)(crc >> 8);
                TxFrame[idx++] = (byte)(crc);
            }

            return (TxFrame);
        }

        public static byte[] BuildParkingmodeDeauthenticateFrame()
        {
            byte[] TxFrame = new byte[6];
            int idx = 0;

            TxFrame[idx++] = 0xBB;
            TxFrame[idx++] = 0x02;
            TxFrame[idx++] = 0xA0;//Parking mode main command
            TxFrame[idx++] = 0xF1;//Parking mode sub command (De-authenticate)

            ushort crc = CRC16.Calc(TxFrame, 2, 2);
            TxFrame[idx++] = (byte)(crc >> 8);
            TxFrame[idx++] = (byte)(crc);

            return (TxFrame);
        }

        public static byte[] BuildParkingmodePwdUpdateFrame(byte[] OldPassword, byte[] NewPassword)
        {
            byte[] TxFrame = new byte[38];
            int idx = 0;
            int Length;

            if ((OldPassword.Length == 16) && (NewPassword.Length == 16))
            {
                TxFrame[idx++] = 0xBB;
                TxFrame[idx++] = 0x04;
                TxFrame[idx++] = 0xA0;//Parking mode main command
                TxFrame[idx++] = 0xF2;//Parking mode sub command (De-authenticate)

                Array.Copy((byte[])OldPassword, 0, TxFrame, idx, OldPassword.Length);//copy old password
                idx += OldPassword.Length;

                Array.Copy((byte[])NewPassword, 0, TxFrame, idx, NewPassword.Length);//copy new password
                idx += NewPassword.Length;

                Length = idx - 2;
                TxFrame[1] = (byte)Length;
                ushort crc = CRC16.Calc(TxFrame, 2, Length);
                TxFrame[idx++] = (byte)(crc >> 8);
                TxFrame[idx++] = (byte)(crc);
            }

            return (TxFrame);
        }

        public static byte[] BuildParkingmodeDataLogEraseAllFrame()
        {
            byte[] TxFrame = new byte[6];
            int idx = 0;

            TxFrame[idx++] = 0xBB;
            TxFrame[idx++] = 0x02;
            TxFrame[idx++] = 0xA0;//Parking mode main command
            TxFrame[idx++] = 0xFC;//Parking mode sub command (erase all logged data)

            ushort crc = CRC16.Calc(TxFrame, 2, 2);
            TxFrame[idx++] = (byte)(crc >> 8);
            TxFrame[idx++] = (byte)(crc);

            return (TxFrame);
        }

        public static byte[] BuildParkingmodeRecordEraseAllFrame()
        {
            byte[] TxFrame = new byte[6];
            int idx = 0;

            TxFrame[idx++] = 0xBB;
            TxFrame[idx++] = 0x02;
            TxFrame[idx++] = 0xA0;//Parking mode main command
            TxFrame[idx++] = 0xFD;//Parking mode sub command (erase all stored records)

            ushort crc = CRC16.Calc(TxFrame, 2, 2);
            TxFrame[idx++] = (byte)(crc >> 8);
            TxFrame[idx++] = (byte)(crc);

            return (TxFrame);
        }

        public static byte[] BuildParkingmodeGetLoggedTIDCountFrame()
        {
            byte[] TxFrame = new byte[6];
            int idx = 0;

            TxFrame[idx++] = 0xBB;
            TxFrame[idx++] = 0x02;
            TxFrame[idx++] = 0xA0;//Parking mode main command
            TxFrame[idx++] = 0x26;//Parking mode sub command (erase all stored records)

            ushort crc = CRC16.Calc(TxFrame, 2, 2);
            TxFrame[idx++] = (byte)(crc >> 8);
            TxFrame[idx++] = (byte)(crc);

            return (TxFrame);
        }


        public static byte[] BuildParkingmodeReadSingleLoggedRecordFrame()
        {
            byte[] TxFrame = new byte[6];
            int idx = 0;

            TxFrame[idx++] = 0xBB;
            TxFrame[idx++] = 0x02;
            TxFrame[idx++] = 0xA0;//Parking mode main command
            TxFrame[idx++] = 0x27;//Parking mode sub command (erase all stored records)

            ushort crc = CRC16.Calc(TxFrame, 2, 2);
            TxFrame[idx++] = (byte)(crc >> 8);
            TxFrame[idx++] = (byte)(crc);

            return (TxFrame);
        }

        public static byte[] BuildParkingmodeGetDevIDStatus()
        {
            byte[] TxFrame = new byte[6];
            int idx = 0;

            TxFrame[idx++] = 0xBB;
            TxFrame[idx++] = 0x02;
            TxFrame[idx++] = 0xA0;//Parking mode main command
            TxFrame[idx++] = 0x28;//Parking mode sub command

            ushort crc = CRC16.Calc(TxFrame, 2, 2);
            TxFrame[idx++] = (byte)(crc >> 8);
            TxFrame[idx++] = (byte)(crc);

            return (TxFrame);
        }

        public static byte[] BuildParkingmodeEnableDevID(byte enable)
        {
            byte[] TxFrame = new byte[7];
            int idx = 0;

            if(enable > 0) { enable = 1;  }

            TxFrame[idx++] = 0xBB;
            TxFrame[idx++] = 0x03;
            TxFrame[idx++] = 0xA0;//Parking mode main command
            TxFrame[idx++] = 0x29;//Parking mode sub command
            TxFrame[idx++] = enable;//Parking mode sub command

            ushort crc = CRC16.Calc(TxFrame, 2, 3);
            TxFrame[idx++] = (byte)(crc >> 8);
            TxFrame[idx++] = (byte)(crc);

            return (TxFrame);
        }

        public static byte[] BuildDeviceStatisticsGetCmd()
        {
            byte[] TxFrame = new byte[6];
            int idx = 0;

            TxFrame[idx++] = 0xBB;
            TxFrame[idx++] = 0x02;
            TxFrame[idx++] = 0x0E;//main cmd code
            TxFrame[idx++] = 0x00;//sub cmd code

            ushort crc = CRC16.Calc(TxFrame, 2, idx - 2);
            TxFrame[idx++] = (byte)(crc >> 8);
            TxFrame[idx++] = (byte)(crc);

            return (TxFrame);
        }

        public static byte[] BuildDeviceStatisticsResetCmd()
        {
            byte[] TxFrame = new byte[6];
            int idx = 0;

            TxFrame[idx++] = 0xBB;
            TxFrame[idx++] = 0x02;
            TxFrame[idx++] = 0x0E;//main cmd code
            TxFrame[idx++] = 0x01;//sub cmd code

            ushort crc = CRC16.Calc(TxFrame, 2, idx - 2);
            TxFrame[idx++] = (byte)(crc >> 8);
            TxFrame[idx++] = (byte)(crc);

            return (TxFrame);
        }

        public static byte[] BuildGetMuxPortCmdFrame()
        {
            byte[] TxFrame = new byte[6];
            int idx = 0;

            TxFrame[idx++] = 0xBB;
            TxFrame[idx++] = 0x02;
            TxFrame[idx++] = 0x1C;//main cmd code
            TxFrame[idx++] = 0x01;//sub cmd code

            ushort crc = CRC16.Calc(TxFrame, 2, idx - 2);
            TxFrame[idx++] = (byte)(crc >> 8);
            TxFrame[idx++] = (byte)(crc);

            return (TxFrame);
        }

        public static byte[] BuildSetMuxPortCmdFrame(byte AntennaPort)
        {
            byte[] TxFrame = new byte[7];
            int idx = 0;

            TxFrame[idx++] = 0xBB;
            TxFrame[idx++] = 0x03;
            TxFrame[idx++] = 0x1C;//main cmd code
            TxFrame[idx++] = 0x02;//sub cmd code
            TxFrame[idx++] = AntennaPort;

            ushort crc = CRC16.Calc(TxFrame, 2, idx - 2);
            TxFrame[idx++] = (byte)(crc >> 8);
            TxFrame[idx++] = (byte)(crc);

            return (TxFrame);
        }

    }
}
