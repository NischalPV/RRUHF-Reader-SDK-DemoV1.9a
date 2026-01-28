using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.IO.Ports;
using System.Windows.Forms;


namespace RRUHF_Reader_SDK_Demo
{
    public class ReceiveParser
    {
		private static bool frameBeginFlag = false;	
		private static long Idx;
		private static int PacketLength;// = 0;
		private static byte[] PacketBuff;//= new byte[4096];
		public event EventHandler<ByteArrayArgs> PacketReceived;

		public ReceiveParser()
		{
			frameBeginFlag = false;
			Idx = 0;
			PacketLength = 0;
			PacketBuff = new byte[4096];
		}

		public void DataReceived(object sender, SerialDataReceivedEventArgs e)
        {		
			if (Sp.GetInstance().Closing)
			{
				return;
			}
			if (!Sp.GetInstance().IsOpen())
			{
				return;
			}
			
			int bytesToRead = Sp.GetInstance().ComDevice.BytesToRead;
			try
			{
				Sp.GetInstance().Listening = true;
				byte[] array = new byte[bytesToRead];
				Sp.GetInstance().ComDevice.Read(array, 0, bytesToRead);

				if (bytesToRead > 0)
				{
					for (int i = 0; i < bytesToRead; i++)
					{
						if (frameBeginFlag)
						{
							PacketBuff[Idx] = array[i];

							if (Idx == 0) { PacketLength = array[i]; }
							if (Idx == PacketLength + 2)
							{
								int PacketCRC = 0;
								int PacketCRC2 = 0;

								//check and compare the crc
								PacketCRC = PacketBuff[PacketLength + 1];
								PacketCRC <<= 8;
								PacketCRC |= PacketBuff[PacketLength + 2];

								PacketCRC2 = CRC16.Calc(PacketBuff, 1, PacketLength);

								if (PacketCRC2 == PacketCRC)
								{
									byte[] resp = new byte[PacketLength];
									Array.Copy(PacketBuff, 1, resp, 0, PacketLength);
					
									string s = BitConverter.ToString(resp).Replace("-", " ");
									PacketReceived(this, new ByteArrayArgs(resp));
									Console.WriteLine("RX: 0xBB " + s);
								}
								else
                                {
									string s = BitConverter.ToString(PacketBuff).Replace("-", " ");
									Console.WriteLine("Invalid packet received :" + s);
                                }
								frameBeginFlag = false;
							}

							Idx++;
						}
						else
						{//wait for SOF
							if (array[i] == 0xBB)
							{//SOF received
								Idx = 0;
								PacketLength = 0;
								frameBeginFlag = true;
							}
						}
					}
				}
			}
			finally
			{
				Sp.GetInstance().Listening = false;
			}
		}
    }
}
