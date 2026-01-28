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
    public class ByteArrayArgs : EventArgs
    {
        public ByteArrayArgs(byte[] strArr)
        {
            this.mData = strArr;
        }

        public byte[] Data
        {
            get
            {
                return this.mData;
            }
        }

        private readonly byte[] mData;
    }

    public class Sp
    {
        public SerialPort ComDevice = new SerialPort();
        private static readonly Sp instance = new Sp();
        private int communicatBaudrate = 115200;
        public bool Listening;
        public bool Closing;
        public bool SofReceived;
          

        private Sp()
        {
            ComDevice.PortName = "COM1";
            ComDevice.BaudRate = 9600;
            ComDevice.Parity = Parity.None;
            ComDevice.DataBits = 8;
            ComDevice.StopBits = StopBits.One;
            ComDevice.NewLine = "/r/n";
        }

        public bool Open()
        {
            if (this.ComDevice.IsOpen)
            {
                return true;
            }
            try
            {
                this.ComDevice.Open();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Open Port Fail, " + ex.Message);
                return false;
            }
            Console.WriteLine("Port Opened, ");
            return true;
        }

        public bool IsOpen()
        {
            return ComDevice.IsOpen;
        }

        public bool Close()
        {
            Closing = true;
            if (!ComDevice.IsOpen)
            {
                Closing = false;
                return true;
            }
            try
            {
                while (this.Listening)
                {
                    Application.DoEvents();
                }
                this.ComDevice.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Close Port Fail, " + ex.Message);
                this.Closing = false;
                return false;
            }
            this.Closing = false;
            Console.WriteLine("Closed Port, ");
            return true;
    
        }

        public void Config(string port, int baudrate, Parity p, int databits, StopBits s)
        {
            try
            {
                ComDevice.PortName = port;
                ComDevice.BaudRate = baudrate;
                ComDevice.Parity = p;
                ComDevice.DataBits = 8;
                ComDevice.StopBits = s;
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public int GetCommunicateBaudRate()
        {
            return communicatBaudrate;
        }

        public static Sp GetInstance()
        {
            return Sp.instance;
        }

        public string[] GetPortNames()
        {
            return SerialPort.GetPortNames();
        }

        public int Send(byte[] packet)
        {
            instance.SofReceived = false;

            if (packet.Length <= 0)
            {
                MessageBox.Show("Please Write Send Data!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return 0;
            }
            if (this.ComDevice.IsOpen)
            {
                try
                {
                    ComDevice.Write(packet, 0, packet.Length);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                return packet.Length;
            }
            MessageBox.Show("Please Connect Serial Port!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            return 0;
        }

        public void SetCommunicatBaudRate(int baudrate)
        {
            communicatBaudrate = baudrate;
        }
    }
}
