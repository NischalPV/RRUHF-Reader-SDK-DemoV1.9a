using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.IO;
using System.IO.Ports;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;
using System.Globalization;
using System.Net;
using System.Net.Sockets;
using ZedGraph;


namespace RRUHF_Reader_SDK_Demo
{

    public partial class Form1 : Form
    {
        public bool IsConnected;
        public bool ConnectBySerialPort;
        public bool ConnectByTCP;
        public bool ClientOk;
        public bool IsSingleQuery;
        private bool InvRespOk;
        bool StartedFromOtherTab;
        byte type;
        byte CurrentWorkingMode;
        Thread ListnearThread;
        static Mutex mutex = new Mutex(false, "LocalM1");
        private static readonly object mutexLock1 = new object();
        TcpClient client;
        //TcpClient Myclient;

        TcpListener server;
        List<TcpClient> clients;
        List<DateTime> tagLastDetectedOn;
        bool bListenerEnbled;
        Thread tListener;
        Thread tViewList;
        bool bEnableTextBoxLogging;
        int nAllowedTimeDiff;

        GraphPane myPane;
        PointPairList data_list1 = new PointPairList();
        PointPairList data_list2 = new PointPairList();
        PointPairList data_list3 = new PointPairList();
        int ArrayIndex;

        double FilteredRssi;
        double FilteredRssi2;
        bool IsFirstAcq;
        int RecordCount;

        byte[] ParkingmodePwd    = new byte[16];
        byte[] NewParkingmodePwd = new byte[16];
        byte[] GlobalPassword    = new byte[16];
        byte[] NewGlobalPassword = new byte[16];

        bool ParkModeAuthentOK;
        bool DeviceInfoReceived;
        bool DeviceRFRegionReceived;
        bool DeviceRFModeReceived;
        bool DeviceRfPowerReceived;
        bool ExtAppEnabled;

        bool CommunicationOk = true;
        string fileName;



        public void ControlsEnable(bool Enable)
        {
            grpExtInvRouteOptions.Enabled = Enable;
            tabCtrl.TabPages[3].Enabled = Enable;
            ExtAppEnabled = Enable;
        }
        private void Log(string Command, byte[] ByteFrame)
        {
            string Text = DateTime.Now.ToLongTimeString() +
                          " >> " + Command + ": " +
                          BitConverter.ToString(ByteFrame).Replace("-", " ") +
                          Environment.NewLine;

            rtbLog.AppendText(Text);
            LogToFile(Text);
        }

        public bool ValidateIPv4(string ipString)
        {
            if (String.IsNullOrWhiteSpace(ipString))
            {
                return false;
            }

            string[] splitValues = ipString.Split('.');
            if (splitValues.Length != 4)
            {
                return false;
            }

            byte tempForParsing;

            return splitValues.All(r => byte.TryParse(r, out tempForParsing));
        }

        private void LogToFile(string strLog)
        {
            int retries = 0;
            while (retries <= 100)
            {
                try
                {
                    File.AppendAllText(fileName, strLog);
                }
                catch (IOException)
                {
                    Thread.Sleep(50);
                    retries++;
                    continue;
                }
                break;
            }
        }


        private void Log(string strLog)
        {
            string Text = DateTime.Now.ToLongTimeString()
                + " >> " + strLog
                + Environment.NewLine;

            try
            {
                rtbLog.AppendText(Text);
            }
            catch (Exception ex)
            {
            }

            LogToFile(Text);
        }

        private void ZedGraphCtrlInit()
        {
            myPane = zedGraphControl1.GraphPane;
            myPane.Title.Text = "";
            myPane.XAxis.Title.Text = "Time(mS)";
            myPane.YAxis.Title.Text = "RSSI(cdBm)";

            myPane.AddCurve("RSSI", data_list1, Color.Red, SymbolType.None);
            myPane.AddCurve("Avg.", data_list2, Color.Blue, SymbolType.None);
            myPane.AddCurve("Avg. Avg.", data_list3, Color.Brown, SymbolType.None);
            myPane.AxisChange();
        }


        private void ToolTipSetup()
        {
            toolTip1.SetToolTip(this.chkIDReverse2, "Reverse the order of device serial number");
            toolTip1.SetToolTip(this.tbUIDCont, "Accumulated EPC/TID count");
            toolTip1.SetToolTip(this.radTCPClient, "Computer's TCP client");
            toolTip1.SetToolTip(this.radTCPServer, "Computer's TCP server");
            toolTip1.SetToolTip(this.chkRSSI, "Include RSSI in the response frame");
        }


        private void SetupDefaults()
        {
            DeviceInfoReceived = false;
            DeviceRFRegionReceived = false;
            DeviceRFModeReceived = false;
            DeviceRfPowerReceived = false;

            radSelectCOMPort.Checked = true;
            ConnectBySerialPort = true;
            radSelectTCP.Checked = false;
            grpCOM.Enabled = true;
            grpTCP.Enabled = false;

            IsConnected = false;
            ConnectBySerialPort = true;
            ConnectByTCP = false;
            
            COMPortSetup();
            cbxCOMPortSetup();
            SetupInventoryBox();
            SetupMemoryOperationsBox();
            SetupSetProtectBox();
            UpdateRFRegionCombobox();
            UpdateRFModesComboBox();
            cbxGPIOSetup();
            ZedGraphCtrlInit();

            IsFirstAcq = true;
            bEnableTextBoxLogging = true;

            /*parking mode default*/
            ParkingModeDefaultSetup();

            dgView.Tag = -1;
            DataGridView_StyleChange(0, false, false, false);

            radEPCOnly.Checked = true;
            radExtInvRespRouteToServer.Checked = true;

            radTCPClient.Checked = true;

            ToolTipSetup();

            cbxMuxPort.Items.Clear();
            for (byte i = 0; i < 6; i++)
            {
                cbxMuxPort.Items.Add((i+1).ToString());
            }
            cbxMuxPort.SelectedIndex = 0;

            fileName = $"Log_{DateTime.Now:dd-MM-yyyyTHH-mm-ss-fff}.txt";
            dgView.Columns[11].Visible = false;
        }


        void UpdateRFModesComboBox()
        {
            cbxRFMode.Items.Clear();
            cbxRFMode.Items.Add("1");    //BPSK: False, lf_khz: 640, m: 2  E510, E710, E910
            cbxRFMode.Items.Add("3");    //BPSK: False, lf_khz: 320, m: 2  E310, E510, E710, E910
            cbxRFMode.Items.Add("5");    //BPSK: False, lf_khz: 320, m: 4  E310, E510, E710, E910
            cbxRFMode.Items.Add("7");    //BPSK: False, lf_khz: 250, m: 4  E310, E510, E710, E910
            cbxRFMode.Items.Add("11");   //BPSK: False, lf_khz: 640, m: 1  E710, E910
            cbxRFMode.Items.Add("12");   //BPSK: False, lf_khz: 320, m: 2  E310, E510, E710, E910
            cbxRFMode.Items.Add("13");   //BPSK: False, lf_khz: 160, m: 8  E310, E510, E710, E910
            cbxRFMode.Items.Add("15");   //BPSK: False, lf_khz: 640, m: 4  E510, E710, E910
            cbxRFMode.Items.Add("102");  //BPSK: False, lf_khz: 640, m: 1  E710, E910
            cbxRFMode.Items.Add("123");  //BPSK: False, lf_khz: 320, m: 2  E310, E510, E710, E910
            cbxRFMode.Items.Add("124");  //BPSK: False, lf_khz: 640, m: 2  E510, E710, E910
            cbxRFMode.Items.Add("125");  //BPSK: False, lf_khz: 320, m: 2  E310, E510, E710, E910
            cbxRFMode.Items.Add("141");  //BPSK: False, lf_khz: 320, m: 4  E310, E510, E710, E910
            cbxRFMode.Items.Add("146");  //BPSK: False, lf_khz: 250, m: 4  E310, E510, E710, E910
            cbxRFMode.Items.Add("147");  //BPSK: False, lf_khz: 640, m: 4  E510, E710, E910
            cbxRFMode.Items.Add("148");  //BPSK: False, lf_khz: 640, m: 4  E510, E710, E910
            cbxRFMode.Items.Add("185");  //BPSK: False, lf_khz: 160, m: 8  E310, E510, E710, E910
            cbxRFMode.Items.Add("202");  //BPSK: False, lf_khz: 426, m: 1  E710, E910
            cbxRFMode.Items.Add("222");  //BPSK: False, lf_khz: 320, m: 2  E310, E510, E710, E910
            cbxRFMode.Items.Add("223");  //BPSK: False, lf_khz: 320, m: 2  E310, E510, E710, E910
            cbxRFMode.Items.Add("241");  //BPSK: False, lf_khz: 320, m: 4  E310, E510, E710, E910
            cbxRFMode.Items.Add("244");  //BPSK: False, lf_khz: 250, m: 4  E310, E510, E710, E910
            cbxRFMode.Items.Add("285");  //BPSK: False, lf_khz: 160, m: 8  E310, E510, E710, E910
            cbxRFMode.Items.Add("302");  //BPSK: False, lf_khz: 640, m: 1  E710, E910
            cbxRFMode.Items.Add("323");  //BPSK: False, lf_khz: 640, m: 2  E510, E710, E910
            cbxRFMode.Items.Add("324");  //BPSK: False, lf_khz: 320, m: 2  E310, E510, E710, E910
            cbxRFMode.Items.Add("325");  //BPSK: False, lf_khz: 320, m: 2  E310, E510, E710, E910
            cbxRFMode.Items.Add("342");  //BPSK: False, lf_khz: 320, m: 4  E310, E510, E710, E910
            cbxRFMode.Items.Add("343");  //BPSK: False, lf_khz: 250, m: 4  E310, E510, E710, E910
            cbxRFMode.Items.Add("344");  //BPSK: False, lf_khz: 640, m: 4  E510, E710, E910
            cbxRFMode.Items.Add("103");  //BPSK: False, lf_khz: 640, m: 1  E710, E910
            cbxRFMode.Items.Add("345");  //BPSK: False, lf_khz: 640, m: 4  E510, E710, E910
            cbxRFMode.Items.Add("120");  //BPSK: False, lf_khz: 640, m: 2  E510, E710, E910
            cbxRFMode.Items.Add("382");  //BPSK: False, lf_khz: 160, m: 8  E310, E510, E710, E910

            cbxRFMode.SelectedIndex = 0;

            cbxDeviceWorkingMode.Items.Clear();           
            cbxDeviceWorkingMode.Items.Add("Response mode");
            cbxDeviceWorkingMode.Items.Add("Auto mode");
            cbxDeviceWorkingMode.Items.Add("Bufferd Inventory mode");
            cbxDeviceWorkingMode.Items.Add("Parking mode");
            cbxDeviceWorkingMode.SelectedIndex = 0;
        }

        void UpdateRFRegionCombobox()
        {
            cbxRegion.Items.Add("FCC");
            cbxRegion.Items.Add("HK");
            cbxRegion.Items.Add("TAIWAN");
            cbxRegion.Items.Add("ETSI LOWER");
            cbxRegion.Items.Add("ETSI UPPER");
            cbxRegion.Items.Add("KOREA");
            cbxRegion.Items.Add("MALAYSIA");
            cbxRegion.Items.Add("CHINA");
            cbxRegion.Items.Add("SOUTH AFRICA");
            cbxRegion.Items.Add("BRAZIL");
            cbxRegion.Items.Add("THAILAND");
            cbxRegion.Items.Add("SINGAPORE");
            cbxRegion.Items.Add("AUSTRALIA");
            cbxRegion.Items.Add("INDIA");
            cbxRegion.Items.Add("URUGUAY");
            cbxRegion.Items.Add("VIETNAM");
            cbxRegion.Items.Add("ISRAEL");
            cbxRegion.Items.Add("PHILIPPINES");
            cbxRegion.Items.Add("INDONESIA");
            cbxRegion.Items.Add("NEW ZEALAND");
            cbxRegion.Items.Add("JAPAN2");
            cbxRegion.Items.Add("PERU");
            cbxRegion.Items.Add("RUSSIA");

            cbxRegion.SelectedIndex = 13;

            //string Region = cbxRegion.GetItemText(cbxRegion.SelectedItem); Handled by index changed event
            //FrequencyTableUpdate(Region);
        }

        private void cbxCOMPortSetup()
        {
            string[] ports = Sp.GetInstance().GetPortNames();
            foreach (string port in ports)
            {
                cbxSerPort.Items.Add(port);
            }
            if (cbxSerPort.Items.Count > 0)
            {
                cbxSerPort.SelectedIndex = 0;
                btnConnect.Enabled = true;
            }


            cbxBaudRate.Items.Add("1200");
            cbxBaudRate.Items.Add("2400");
            cbxBaudRate.Items.Add("4800");
            cbxBaudRate.Items.Add("9600");
            cbxBaudRate.Items.Add("19200");
            cbxBaudRate.Items.Add("38400");
            cbxBaudRate.Items.Add("57600");
            cbxBaudRate.Items.Add("115200");
            cbxBaudRate.Items.Add("128000");
            cbxBaudRate.Items.Add("256000");
            cbxBaudRate.Items.Add("921600");

            cbxBaudRate.SelectedIndex = 7;

            cbxUSARTBaudrate.Items.Add("1200");
            cbxUSARTBaudrate.Items.Add("2400");
            cbxUSARTBaudrate.Items.Add("4800");
            cbxUSARTBaudrate.Items.Add("9600");
            cbxUSARTBaudrate.Items.Add("19200");
            cbxUSARTBaudrate.Items.Add("38400");
            cbxUSARTBaudrate.Items.Add("57600");
            cbxUSARTBaudrate.Items.Add("115200");
            cbxUSARTBaudrate.Items.Add("128000");
            cbxUSARTBaudrate.Items.Add("256000");
            cbxUSARTBaudrate.Items.Add("921600");

            cbxUSARTBaudrate.SelectedIndex = 10;
        }


        void cbxGPIOSetup()
        {
            cbxIO1.Items.Add("0");
            cbxIO1.Items.Add("1");
            cbxIO1.Items.Add("2");
            cbxIO1.Items.Add("3");
            cbxIO1.Items.Add("4");


            cbxIO1.SelectedIndex = 0;

            cbxIO1State.Items.Add("Set   (1)");
            cbxIO1State.Items.Add("Reset (0)");

            cbxIO1State.SelectedIndex = 0;

            cbxIO2.Items.Add("0");
            cbxIO2.Items.Add("1");
            cbxIO2.Items.Add("2");
            cbxIO2.Items.Add("3");
            cbxIO2.Items.Add("4");

            cbxIO2.SelectedIndex = 0;

            cbxIO2State.Items.Add("Set   (1)");
            cbxIO2State.Items.Add("Reset (0)");

            cbxIO2State.SelectedIndex = 0;

            cbxIO3State.Items.Add("Set   (1)");
            cbxIO3State.Items.Add("Reset (0)");

            cbxIO3State.SelectedIndex = 0;
        }

        private void SetupMemoryOperationsBox()
        {
            radEPCBank.Checked = true;
            txtWordAddress.Text = "0000";
            txtTotalWords.Text = "01";
            txtAccessPwdOps.Text = "00000000";
        }

        private void SetupSetProtectBox()
        {
            radBankEPC.Checked = true;
            SetProtectUpdateDisplayOption();
        }

        private void SetProtectUpdateDisplayOption()
        {
            cbxSetProtect.Items.Clear();

            if ((radKillPwd.Checked) || (radAdccessPwd.Checked))
            {
                cbxSetProtect.Items.Add("R/W from any state");
                cbxSetProtect.Items.Add("Permanently R/W from any state");
                cbxSetProtect.Items.Add("R/W only from secured state");
                cbxSetProtect.Items.Add("Never R/W from any state");
            }
            else
            {

                cbxSetProtect.Items.Add("Writable from any state");
                cbxSetProtect.Items.Add("Permanently writable form any state");
                cbxSetProtect.Items.Add("Writable only from secured state");
                cbxSetProtect.Items.Add("Non writable from any state");// ("Readonly from any state");
            }

            cbxSetProtect.SelectedIndex = 0;
        }

        private bool IsActiveMode()
        {
            bool mode = true;

            if(cbxDeviceWorkingMode.SelectedIndex == 0) {  mode = false; }
            return (mode);
        }


        private void SetupInventoryBox()
        {
            cbxQValue.Items.Clear();
            for (byte i = 0; i < 16; i++)
            {
                cbxQValue.Items.Add(i.ToString());
            }
            cbxQValue.SelectedIndex = 0;

            for (int i = 4; i < 100; i++)
            {
                cbxInterval.Items.Add((i * 10).ToString() + " mS");
            }
            cbxInterval.SelectedIndex = 0;

            for (int i = 0; i < 4; i++)
            {
                cbxSession.Items.Add(i.ToString());
            }
            cbxSession.SelectedIndex = 0;

            cbxTarget.Items.Clear();
            cbxTarget.Items.Add("A");
            cbxTarget.Items.Add("B");
            cbxTarget.Items.Add("A<->B");       
            cbxTarget.SelectedIndex = 0;
        }

        private void COMPortSetup()
        {
            ReceiveParser rp = new ReceiveParser();
            Sp.GetInstance().ComDevice.DataReceived += rp.DataReceived;
            rp.PacketReceived += PaketReceived;
        }

        private bool OpenCOMPort()
        {
            bool Ok = true;
            try
            {
                Sp.GetInstance().Config(cbxSerPort.SelectedItem.ToString(), Convert.ToInt32(cbxBaudRate.SelectedItem.ToString()), Parity.None, 8, StopBits.One);
            }
            catch (Exception ex)
            {
                Ok = false;
                MessageBox.Show(ex.Message);
            }
            if (Ok)
            {
                Ok = Sp.GetInstance().Open();
            }

            return (Ok);
        }

        private bool CloseCOMPort()
        {
            bool IsError = false;

            IsError = Sp.GetInstance().Close();
            return (IsError);
        }

        public Form1()
        {
            InitializeComponent();
        }


        private void FrequencyTableUpdate(string Region)
        {
            RegionTable R = new RegionTable();
            if (Region == "FCC")
            {
                R.Update(Region, 902750, 500, 50, null, true);
            }
            else if (Region == "HK")
            {
                R.Update(Region, 902750, 50, 10, UsableRfChannels.GetRFChannels(Region), false);
            }
            else if (Region == "TAIWAN")
            {
                R.Update(Region, 902750, 500, 11, UsableRfChannels.GetRFChannels(Region), false);
            }
            else if (Region == "ETSI LOWER")
            {
                R.Update(Region, 865100, 200, 4, UsableRfChannels.GetRFChannels(Region), false);
            }
            else if (Region == "ETSI UPPER")
            {
                R.Update(Region, 915500, 400, 4, UsableRfChannels.GetRFChannels(Region), false);
            }
            else if (Region == "KOREA")
            {
                R.Update(Region, 917300, 600, 6, UsableRfChannels.GetRFChannels(Region), true);
            }
            else if (Region == "MALAYSIA")
            {
                R.Update(Region, 902750, 500, 8, UsableRfChannels.GetRFChannels(Region), true);
            }
            else if (Region == "CHINA")
            {
                R.Update(Region, 920125, 250, 16, UsableRfChannels.GetRFChannels(Region), false);
            }
            else if (Region == "SOUTH AFRICA")
            {
                R.Update(Region, 915600, 200, 17, UsableRfChannels.GetRFChannels(Region), false);
            }
            else if (Region == "BRAZIL")
            {
                R.Update(Region, 902750, 500, 35, UsableRfChannels.GetRFChannels(Region), false);
            }
            else if (Region == "THAILAND")
            {
                R.Update(Region, 902750, 500, 10, UsableRfChannels.GetRFChannels(Region), false);

            }
            else if (Region == "SINGAPORE")
            {
                R.Update(Region, 902750, 500, 10, UsableRfChannels.GetRFChannels(Region), false);
            }
            else if (Region == "AUSTRALIA")
            {
                R.Update(Region, 902750, 500, 10, UsableRfChannels.GetRFChannels(Region), false);
            }
            else if (Region == "INDIA")
            {
                R.Update(Region, 865100, 200, 4, UsableRfChannels.GetRFChannels(Region), false);
            }
            else if (Region == "URUGUAY")
            {
                R.Update(Region, 902750, 500, 23, UsableRfChannels.GetRFChannels(Region), false);
            }
            else if (Region == "VIETNAM")
            {
                R.Update(Region, 902750, 500, 8, UsableRfChannels.GetRFChannels(Region), false);
            }
            else if (Region == "ISRAEL")
            {
                R.Update(Region, 902750, 500, 1, UsableRfChannels.GetRFChannels(Region), false);
            }
            else if (Region == "PHILIPPINES")
            {
                R.Update(Region, 918250, 500, 4, UsableRfChannels.GetRFChannels(Region), true);
            }
            else if (Region == "INDONESIA")
            {
                R.Update(Region, 902750, 500, 4, UsableRfChannels.GetRFChannels(Region), false);
            }
            else if (Region == "NEW ZEALAND")
            {
                R.Update(Region, 902750, 500, 10, UsableRfChannels.GetRFChannels(Region), true);
            }
            else if (Region == "JAPAN2")
            {
                R.Update(Region, 915800, 200, 4, UsableRfChannels.GetRFChannels(Region), false);
            }
            else if (Region == "PERU")
            {
                R.Update(Region, 902750, 500, 23, UsableRfChannels.GetRFChannels(Region), false);
            }
            else if (Region == "RUSSIA")
            {
                R.Update(Region, 916200, 1200, 4, UsableRfChannels.GetRFChannels(Region), false);
            }

            cbxMinFreq.Items.Clear();
            cbxMaxFreq.Items.Clear();
            cbxCurrentFreq.Items.Clear();
            cbxMinFreq.Items.AddRange(R.GetFreqTable());
            cbxMaxFreq.Items.AddRange(R.GetFreqTable());
            cbxCurrentFreq.Items.AddRange(R.GetFreqTable());

            if (cbxMinFreq.Items.Count > 0) { cbxMinFreq.SelectedIndex = 0; }
            if (cbxMaxFreq.Items.Count > 0) { cbxMaxFreq.SelectedIndex = cbxMaxFreq.Items.Count - 1; }
            if (cbxCurrentFreq.Items.Count > 0) { cbxCurrentFreq.SelectedIndex = 0; }
        }

        private void ProcessGetInventoryQResponse(byte[] RxFrame)
        {
            Log("Get inventory Q value response", RxFrame);

            //if ((RxFrame[1] == 0x00) && ((RxFrame[2]) > 0 && (RxFrame[2] < 17)))
            if ((RxFrame[1] == 0x00) && (RxFrame[2] < 16))
            {
                cbxQValue.SelectedIndex = RxFrame[2];
            }
        }

        private void ProcessMuxConfigResponse(byte[] RxFrame)
        {
            Log("Mux config, response frame", RxFrame);
            if ((RxFrame[1] == 0x00) && (RxFrame[2] == 1) && (RxFrame[3] < 6))
            {
                int MuxPort = RxFrame[3] - 1;
                try
                {
                    cbxMuxPort.SelectedIndex = MuxPort;
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void ProcessSetInventoryQResponse(byte[] RxFrame)
        {
            Log("Set inventory Q value response", RxFrame);
            if (RxFrame[1] == 0x00)
            {

            }
        }

        private void ProcessGetInventorySessionResponse(byte[] RxFrame)
        {
            Log("Get inventory session response", RxFrame);

            if ((RxFrame[1] == 0x00) && ((RxFrame[2]) >= 0 && (RxFrame[2] < 4)))
            {
                cbxSession.SelectedIndex = RxFrame[2];
            }
        }

        private void ProcessSetInventoryTargetResponse(byte[] RxFrame)
        {
            Log("Set inventory target response", RxFrame);
        }


        private void ProcessGetInventoryTargetResponse(byte[] RxFrame)
        {
            Log("Get inventory target response", RxFrame);

            if ((RxFrame[1] == 0x00) && ((RxFrame[2]) >= 0 && (RxFrame[2] < 3)))
            {
                cbxTarget.SelectedIndex = RxFrame[2];
            }
            else
            {
                byte[] InvalidVal = new byte[1];
                InvalidVal[0] = RxFrame[2];
                Log("C1G2 target value is :", InvalidVal);
            }
        }

        private void ProcessSetInventorySessionResponse(byte[] RxFrame)
        {
            Log("Set inventory session response", RxFrame);
        }


        private void DataGridView_StyleChange(byte StyleID, bool WithRSSI, bool WithDeviceID, bool WithAntennaID)
        {
            int [] Width = new int[dgView.ColumnCount];

            if(WithRSSI)
            {
                dgView.Columns[8].Visible = true;
            }

            if(WithDeviceID)
            {
                dgView.Columns[1].Visible = true;
                dgView.Columns[1].Width = 60;
            }

            if(WithAntennaID)
            {
                dgView.Columns[11].Visible = true;
                dgView.Columns[11].Width = 20;
            }

            if(dgView.Tag.ToString() == StyleID.ToString()) { return;  }

            switch(StyleID)
            {
                case 0://EPC only inventory
                    dgView.Columns[0].Visible = true;
                    dgView.Columns[0].Width = 40;
                    if (!WithDeviceID) dgView.Columns[1].Visible = false;
                    dgView.Columns[2].Visible = true;
                    dgView.Columns[2].Width = 60;
                    dgView.Columns[3].Visible = false;
                    dgView.Columns[3].Width = 350;
                    dgView.Columns[4].Visible = false;
                    dgView.Columns[5].Visible = true;
                    dgView.Columns[6].Visible = false;
                    dgView.Columns[7].Visible = false;
                    if(!WithRSSI) dgView.Columns[8].Visible = false;
                    dgView.Columns[9].Visible = false;
                    dgView.Columns[10].Visible = false;
                    dgView.Tag = StyleID;
                    
                break;
                case 1://TID only inventory
                    dgView.Columns[0].Visible = true;
                    if (!WithDeviceID) dgView.Columns[1].Visible = false;
                    dgView.Columns[2].Visible = true;
                    dgView.Columns[3].Visible = false;
                    dgView.Columns[4].Visible = false;
                    dgView.Columns[5].Visible = false;
                    dgView.Columns[6].Visible = true;
                    dgView.Columns[7].Visible = false;
                    if (!WithRSSI) dgView.Columns[8].Visible = false;
                    dgView.Columns[9].Visible = false;
                    dgView.Columns[10].Visible = false;
                    dgView.Tag = StyleID;
                break;
                case 2://EPC + TID inventory
                    dgView.Columns[0].Visible = true;
                    if (!WithDeviceID) dgView.Columns[1].Visible = false;
                    dgView.Columns[2].Visible = true;
                    dgView.Columns[3].Visible = false;
                    dgView.Columns[4].Visible = false;
                    dgView.Columns[5].Visible = true;
                    dgView.Columns[6].Visible = true;
                    dgView.Columns[7].Visible = false;
                    if (!WithRSSI) dgView.Columns[8].Visible = false;
                    dgView.Columns[9].Visible = false;
                    dgView.Columns[10].Visible = false;
                    dgView.Tag = StyleID;
                    break;
                case 3://EPC + Data (Extended mode)
                    dgView.Columns[0].Visible = true;
                    if (!WithDeviceID) dgView.Columns[1].Visible = false;
                    dgView.Columns[2].Visible = true;
                    dgView.Columns[3].Visible = false;
                    dgView.Columns[4].Visible = false;
                    dgView.Columns[5].Visible = true;
                    dgView.Columns[6].Visible = false;
                    dgView.Columns[7].Visible = true;
                    if (!WithRSSI) dgView.Columns[8].Visible = false;
                    dgView.Columns[9].Visible = false;
                    dgView.Columns[10].Visible = false;
                    dgView.Tag = StyleID;
                    break;
                case 4://EPC + TID + Data (Extended mode)
                    dgView.Columns[0].Visible = true;
                    if (!WithDeviceID) dgView.Columns[1].Visible = false;
                    dgView.Columns[2].Visible = true;
                    dgView.Columns[3].Visible = false;
                    dgView.Columns[4].Visible = false;
                    dgView.Columns[5].Visible = true;
                    dgView.Columns[6].Visible = true;
                    dgView.Columns[7].Visible = true;
                    if (!WithRSSI) dgView.Columns[8].Visible = false;
                    dgView.Columns[9].Visible = false;
                    dgView.Columns[10].Visible = false;
                    dgView.Tag = StyleID;
                    break;
                case 5://parking mode TID,TimeStamp,Active
                    dgView.Columns[0].Visible = true;
                    dgView.Columns[0].Width = 40;
                    if (!WithDeviceID) dgView.Columns[1].Visible = false;
                    dgView.Columns[2].Visible = true;
                    dgView.Columns[2].Width = 60;
                    dgView.Columns[3].Visible = true;
                    dgView.Columns[3].Width = 100;
                    dgView.Columns[4].Visible = true;
                    dgView.Columns[4].Width = 50;
                    dgView.Columns[5].Visible = false;
                    dgView.Columns[6].Visible = true;
                    dgView.Columns[6].Width = 300;
                    dgView.Columns[7].Visible = false;
                    if (!WithRSSI) dgView.Columns[8].Visible = false;
                    dgView.Columns[9].Visible = false;
                    dgView.Columns[10].Visible = false;
                    dgView.Tag = StyleID;
                    break;
                case 6:
                    dgView.Columns[0].Visible = true;
                    dgView.Columns[1].Visible = true;
                    dgView.Columns[2].Visible = true;
                    dgView.Columns[3].Visible = true;
                    dgView.Columns[4].Visible = true;
                    dgView.Columns[5].Visible = false;
                    dgView.Columns[6].Visible = true;
                    dgView.Columns[7].Visible = false;
                    if (!WithRSSI) dgView.Columns[8].Visible = false;
                    dgView.Columns[9].Visible = false;
                    dgView.Columns[10].Visible = false;
                    dgView.Tag = StyleID;
                    break;
                case 7:
                    dgView.Columns[0].Visible  = true;//Sr.NO
                    dgView.Columns[1].Visible  = false;//DeviceID
                    dgView.Columns[2].Visible  = false;//Count
                    dgView.Columns[3].Visible  = false;//Time stamp(RTC)
                    dgView.Columns[4].Visible  = true;//IsActive
                    dgView.Columns[5].Visible  = false;//EPC
                    dgView.Columns[6].Visible  = true;//TID
                    dgView.Columns[7].Visible  = false;//Data
                    dgView.Columns[8].Visible  = false;//RSSI
                    dgView.Columns[9].Visible  = false;//TIME(Local)
                    dgView.Columns[10].Visible = true;//Category
                    dgView.Tag = StyleID;
               break;
            }


            dgView.Columns[0].Width = 50;
            dgView.Columns[1].Width = 50;
            dgView.Columns[2].Width = 60;
            dgView.Columns[3].Width = 80;
            dgView.Columns[4].Width = 50;
            dgView.Columns[5].Width = 280;
            dgView.Columns[6].Width = 280;
            dgView.Columns[7].Width = 200;
            dgView.Columns[8].Width = 80;
            dgView.Columns[10].Width = 50;

            foreach (DataGridViewColumn column in dgView.Columns)
            {
                column.SortMode = DataGridViewColumnSortMode.NotSortable;
            }

            dgView.Rows.Clear();
            dgView.Refresh();
        }


        private void ProcessParkingmodeTID_EntryFrame(byte[] RxFrame)
        {
            byte FlagGroup0;
            byte FlagGroup1;
            byte Category;
            byte TIDLength;
            byte[] TID = new byte[12];
            string sIsActive = "NO";
            string sCategory = string.Empty;
            string sTID = string.Empty;

            int idx = 3;
            FlagGroup1 = RxFrame[idx++];
            FlagGroup0 = RxFrame[idx++];
            Category   = RxFrame[idx++];
            TIDLength  = RxFrame[idx++];

            TID = new byte[TIDLength];
            Array.Copy(RxFrame, idx, TID, 0, TID.Length);

            if ((FlagGroup0 & 0x06) == 0x04)
            {
                sIsActive = "Blocked";
            }
            else if ((FlagGroup0 & 0x06) == 0x02)
            {
                sIsActive = "Active";
            }
            else
            {
                sIsActive = "Unregistered";
            }

            sCategory = Category.ToString();
            sTID = BitConverter.ToString(TID).Replace("-", "");

            bool NewEntry = true;
            for (int k = 0; k < dgView.Rows.Count; k++)
            {
                if ((dgView.Rows[k].Cells[6].Value != null) && (dgView.Rows[k].Cells[6].Value.ToString() == sTID))
                {
                    NewEntry = false;

                    dgView.Rows[k].Cells[4].Value  = sIsActive;
                    dgView.Rows[k].Cells[6].Value  = sTID;
                    dgView.Rows[k].Cells[9].Value  = DateTime.Now.ToString();
                    dgView.Rows[k].Cells[10].Value = sCategory;    
                    dgView.Rows[k].DefaultCellStyle.BackColor = Color.LightBlue;
                }
            }
            if (NewEntry)
            {
                string[] sArray = new string[11];
                sArray[0] = (dgView.RowCount).ToString();
                sArray[1] = "";
                sArray[2] = "";
                sArray[3] = "";
                sArray[4] = sIsActive;
                sArray[5] = "";
                sArray[6] = sTID;
                sArray[7] = "";
                sArray[8] = "";
                sArray[9] = DateTime.Now.ToString();
                sArray[10] = sCategory;

                dgView.Rows.Insert(dgView.RowCount - 1, sArray);
                dgView.Rows[dgView.RowCount - 2].DefaultCellStyle.BackColor = Color.LightGreen;
            }

            RecordCount++;
            tbUIDCont.Text = RecordCount.ToString();
        }

        private void ProcessParkingmodeTID_Frame(byte[] RxFrame)
        {
            /*
             * Device serial number
             * Time stamp
             * flags (active/Other)
             * TID length
             * TID
             * RSSI (optional)
             */
            Log("Parking mode TID inventory response", RxFrame);

            bool IsWithDeviceID = false;
            bool IsWithRSSI = false;
            byte FlagGroup0;
            byte FlagGroup1;
            byte[] TimeStamp = new byte[6];
            byte[] DeviceID = new byte[4];
            uint SerialNumber32 = 0;
            string sRSSI = "";
            string sDeviceSN = "";
            string sIsActive = "NO";

            int idx = 1;

            FlagGroup0 = RxFrame[idx++];
            FlagGroup1 = RxFrame[idx++];

            if ((FlagGroup0 & 0x06) == 0x04)
            {
                sIsActive = "Blocked";
            }
            else if ((FlagGroup0 & 0x06) == 0x02)
            {
                sIsActive = "Active";
            }
            else
            {
                sIsActive = "Unregistered";
            }

            if ((FlagGroup1 & 0x40) == 0x40) 
            {
                IsWithDeviceID = true;
                Array.Copy(RxFrame, idx, DeviceID, 0, DeviceID.Length);
                idx += 4;

                if(!chkIDReverse2.Checked) { Array.Reverse(DeviceID, 0, DeviceID.Length); }
                SerialNumber32 = BitConverter.ToUInt32(DeviceID, 0);                 
            }


            DataGridView_StyleChange(5, IsWithRSSI, IsWithDeviceID, false);            

            Array.Copy(RxFrame, idx, TimeStamp, 0, TimeStamp.Length);
            idx += TimeStamp.Length;

            byte TIDLength = RxFrame[idx++];
            byte[] TID = new byte[TIDLength]; 
            Array.Copy(RxFrame, idx, TID, 0, TIDLength);
            string sTID = BitConverter.ToString(TID).Replace("-", "");
            string sTimeStamp = Helpers.TimeStampStr(TimeStamp);


            bool NewEntry = true;
            for (int k = 0; k < dgView.Rows.Count; k++)
            {
                if ((dgView.Rows[k].Cells[6].Value != null) && (dgView.Rows[k].Cells[6].Value.ToString() == sTID))
                {
                    NewEntry = false;
                    int count = Convert.ToInt32(dgView.Rows[k].Cells[2].Value.ToString());
                    count = count + 1;
                    dgView.Rows[k].Cells[1].Value = SerialNumber32.ToString();
                    dgView.Rows[k].Cells[2].Value = count;
                    dgView.Rows[k].Cells[3].Value = sTimeStamp;
                    dgView.Rows[k].Cells[4].Value = sIsActive;                    
                    dgView.Rows[k].Cells[8].Value = sRSSI;
                    dgView.Rows[k].Cells[9].Value = DateTime.Now;

                    dgView.Rows[k].DefaultCellStyle.BackColor = Color.LightBlue;
                }
            }
            if (NewEntry)
            {
                string[] sArray = new string[11];
                sArray[0] = (dgView.RowCount).ToString();
                sArray[1] = SerialNumber32.ToString();
                sArray[2] = "1";
                sArray[3] = sTimeStamp;
                sArray[4] = sIsActive;
                sArray[5] = "";
                sArray[6] = sTID;
                sArray[7] = "";
                sArray[8] = sRSSI;
                sArray[9] = DateTime.Now.ToString();
                sArray[10] = "";

                dgView.Rows.Insert(dgView.RowCount - 1, sArray);
                dgView.Rows[dgView.RowCount - 2].DefaultCellStyle.BackColor = Color.LightGreen;
            }

            RecordCount++;
            tbUIDCont.Text = RecordCount.ToString();

            DateTime now = System.DateTime.Now;
            DateTime dt;
            int timeout = (3000);
            for (int i = 0; i < dgView.Rows.Count - 1; i++)
            {
                string time = dgView.Rows[i].Cells[9].Value.ToString();
                if (null != time && !"".Equals(time))
                {
                    if (DateTime.TryParse(time, out dt))
                    {
                        TimeSpan sub = now.Subtract(dt);
                        if (sub.TotalMilliseconds > timeout)
                        {
                            this.dgView.Rows[i].DefaultCellStyle.BackColor = Color.Red;
                        }
                    }
                }
            }
        }

        private void ProcessInventoryResponse(byte[] RxFrame)
        {
            bool IsWithTID = false;
            bool IsWithRSSI = false;
            bool IsWithUserMem = false;
            bool IsWithAntennID = false;
            bool IsWithDeviceID = false;
            bool IsWithUID = false;
            bool IsTID_Only = false;
            bool IsTimeStampPresent = false;
            
            int idx     = 1;
            int uid_offset = 3;

            byte[] DevID = new byte[4];

            byte UIDLength=0;
            byte[] UID;

            byte TIDLength=0;
            byte[] TID = new byte[8];

            byte MemLength=0;
            byte[] MemData;

            byte[] TimeStamp;

            string sDeviceID = String.Empty;
            string sTimeStamp = String.Empty;
            string sUID = String.Empty;
            string sTID = String.Empty;
            string sUserMemData = String.Empty;
            string sRSSI = String.Empty;
            string sAnt = String.Empty;

            Log("Inventory response", RxFrame);
            InvRespOk = true;

            if (RxFrame.Length < 3) { return; }
            if ((RxFrame[idx] & 0x01) == 0x01) { IsWithUID = true; dgView.Columns[5].Visible = true; }
            if ((RxFrame[idx] & 0x02) == 0x02) { IsWithTID = true; dgView.Columns[6].Visible = true; }
            if ((RxFrame[idx] & 0x03) == 0x02) { IsTID_Only = true; }
            if ((RxFrame[idx] & 0x04) == 0x04) { IsWithRSSI = true; dgView.Columns[8].Visible = true; }
            if ((RxFrame[idx] & 0x08) == 0x08) { IsWithUserMem = true; dgView.Columns[7].Visible = true; }
            if ((RxFrame[idx] & 0x10) == 0x10) { IsWithAntennID = true; dgView.Columns[11].Visible = true; }
            if ((RxFrame[idx] & 0x40) == 0x40) { IsWithDeviceID = true; dgView.Columns[1].Visible = true; }
            if ((RxFrame[idx] & 0x80) == 0x80) { IsTimeStampPresent = true; dgView.Columns[3].Visible = true; }

            idx++;
            if (IsWithDeviceID)
            {
                Array.Copy(RxFrame, idx, DevID, 0, DevID.Length);
                idx += DevID.Length;
                if (!chkIDReverse2.Checked) { Array.Reverse(DevID); }
                uint SerialNumber32 = BitConverter.ToUInt32(DevID, 0);
                sDeviceID = SerialNumber32.ToString();//
            }

            if(IsTimeStampPresent)
            {
                TimeStamp = new byte[6];
                Array.Copy(RxFrame, idx, TimeStamp, 0, TimeStamp.Length);
                idx += TimeStamp.Length;
                sTimeStamp = Helpers.TimeStampStr(TimeStamp); 
            }

            if(IsWithAntennID)
            {
                byte AntId = RxFrame[idx++];
                sAnt = AntId.ToString();
            }
            
            if(IsWithUID)
            {
                UIDLength = RxFrame[idx++];
                UID = new byte[UIDLength];
                Array.Copy(RxFrame, idx, UID, 0, UIDLength);
                sUID = BitConverter.ToString(UID).Replace("-", "");//
                idx += UIDLength;
            }

            if(IsWithTID)
            {
                TIDLength = RxFrame[idx++];
                TID = new byte[TIDLength];
                Array.Copy(RxFrame, idx, TID, 0, TID.Length);
                sTID = BitConverter.ToString(TID).Replace("-", "");//
                idx += TIDLength;
            }

            if (IsWithUserMem)
            {
                MemLength = RxFrame[idx++];
                MemData = new byte[MemLength];
                Array.Copy(RxFrame, idx, MemData, 0, MemData.Length);
                sUserMemData = BitConverter.ToString(MemData).Replace("-", "");//
                idx += MemLength;
            }

            if (IsWithRSSI)
            {
                Int16 RSSI = RxFrame[idx++];
                RSSI <<= 8;
                RSSI |= RxFrame[idx++];
                Double fRSSI = Convert.ToDouble(RSSI) / 100.0;
                sRSSI = fRSSI.ToString();//
            }

            RecordCount++;
            tbUIDCont.Text = RecordCount.ToString();


            if (IsWithTID)
            {
                txtParkingmodeEPCtoRegister.Text = sTID;
                txtParkmodeRecordToCheck.Text = sTID;

                if (ParkModeAuthentOK && chkParkmodeAutoRegister.Checked && (cbxDeviceWorkingMode.SelectedIndex == 0))
                {
                    ParkmodeRegisterSingleTID(TID);
                }
            }
            
            if (IsWithUID)
            {
                if (!cbxUIDOps.Items.Contains(sUID))
                {
                    cbxUIDOps.Items.Add(sUID); cbxUIDOps.SelectedIndex = 0;
                }
            }

            int Index;
            string sID = string.Empty;
            if (IsTID_Only) { Index = 6; sID = sTID; }
            else { Index = 5; sID = sUID; }

            bool NewEntry = true;
            for (int k = 0; k < dgView.Rows.Count; k++)
            {
                if ((dgView.Rows[k].Cells[Index].Value != null) && (dgView.Rows[k].Cells[Index].Value.ToString() == sID))
                {
                    bool allok = true;
                    NewEntry = false;
                    int count = 0;
                    try
                    {
                         count = Convert.ToInt32(dgView.Rows[k].Cells[2].Value.ToString());
                    }
                    catch(Exception ex)
                    {
                        allok = false;
                    }
                    if (allok)
                    {
                        count = count + 1;
                        dgView.Rows[k].Cells[2].Value = count;
                        dgView.Rows[k].Cells[3].Value = sTimeStamp;
                        dgView.Rows[k].Cells[8].Value = sRSSI;
                        dgView.Rows[k].Cells[9].Value = DateTime.Now;
                        dgView.Rows[k].DefaultCellStyle.BackColor = Color.LightBlue;
                    }
                }
            }
            if (NewEntry)
            {
                //TotalUIDCount++;//
                //tbUIDCnt.Text = TotalUIDCount.ToString();
                string[] sArray = new string[12];
                sArray[0] = (dgView.RowCount).ToString();
                sArray[1] = sDeviceID;
                sArray[2] = "1";
                sArray[3] = sTimeStamp;
                sArray[5] = sUID;
                sArray[6] = sTID;
                sArray[7] = sUserMemData;
                sArray[8] = sRSSI;
                sArray[9] = DateTime.Now.ToString();
                sArray[11] = sAnt;


                dgView.Rows.Insert(dgView.RowCount - 1, sArray);
                dgView.Rows[dgView.RowCount - 2].DefaultCellStyle.BackColor = Color.LightGreen;
            }

           /* DateTime now = System.DateTime.Now;
            DateTime dt;
            int timeout = 5000;
            for (int i = 0; i < dgView.Rows.Count - 1; i++)
            {
                string time = dgView.Rows[i].Cells[9].Value.ToString();
                if (null != time && !"".Equals(time))
                {
                    if (DateTime.TryParse(time, out dt))
                    {
                        TimeSpan sub = now.Subtract(dt);
                        if (sub.TotalMilliseconds > timeout) { this.dgView.Rows[i].DefaultCellStyle.BackColor = Color.Red; }
                    }
                }
            }*/
        }

        private void ProcessInventoryCompleteResponse(byte[] RxFrame)
        {
            Log("Inventory round finished response", RxFrame);
            if(RxFrame.Length < 3) { Console.WriteLine("Invalid epc len??"); return; } //KINJAL FIX
            switch (RxFrame[1])
            {
                case 0x00: Log("Inventory finished with Success"); break;
                case 0xB1: Log("Inventory finshed with No tag found."); break;
                case 0xF0: Log("Inventory finished with RF error"); break;
            }

            if (RxFrame.Length > 2)
            {
                string sTotalUIDs = "Total Tags singulated = " + RxFrame[2].ToString();
                Log(sTotalUIDs);
            }

        }

        private void ProcessGetDeviceInfoFrame(byte[] RxFrame)
        {
            Log("Get device info response", RxFrame);

            if (RxFrame[1] == 0x00)
            {
                byte[] DeviceFirmwareVersion = new byte[2];
                
                Array.Copy(RxFrame, 2, DeviceFirmwareVersion, 0, 2);

                String sFirmwareVersion = DeviceFirmwareVersion[0].ToString() + ".";
                sFirmwareVersion += DeviceFirmwareVersion[1].ToString();
                txtFirmwareVersion.Text = sFirmwareVersion;

                byte[] DeviceHardwareVersion = new byte[2];
                Array.Copy(RxFrame, 4, DeviceHardwareVersion, 0, 2);

                String sHardwareVersion = DeviceHardwareVersion[0].ToString() + ".";
                sHardwareVersion += DeviceHardwareVersion[1].ToString();
                txtHardwareVersion.Text = sHardwareVersion;

                int InfoLength = RxFrame[6];
                int idx = 6 + InfoLength + 1;
                if ((InfoLength > 0) && (InfoLength < 42))
                {
                    byte[] SerialNumber = new byte[4];
                    Array.Copy(RxFrame, 7, SerialNumber, 0, 4);

                    if (DeviceFirmwareVersion[1] > 9) { Array.Reverse(SerialNumber); }//Firmware bugfix(little endian to bigendian)
                    uint SerialNumber32 = BitConverter.ToUInt32(SerialNumber, 0);
                    string S1 = SerialNumber32.ToString();
                    txtDeviceSerialNum.Text = S1;

                    byte[] FeatureBitList = new byte[4];
                    bool ok = true;
                    try
                    {
                        Array.Copy(RxFrame, idx, FeatureBitList, 0, 4);
                    }
                    catch (Exception ex)
                    {
                       Log(ex.ToString());
                       ok = false;
                    }

                    if(ok)
                    {
                        uint FeatureBitList32 = BitConverter.ToUInt32(FeatureBitList, 0);
                        if (FeatureBitList32 == 0x01010101) { /*Log("NXP DEVICE");*/ ControlsEnable(false);   }
                        if (FeatureBitList32 == 0x02020202) { /*Log("STM32 DEVICE");*/ ControlsEnable(true);  }
                    }

                   

                    DeviceInfoReceived = true;
                }
            }
        }

        private void ProcessGetDeviceWorkingMode(byte[] RxFrame)
        {
            if(RxFrame.Length < 3)
            {
                Log("Get device working mode response : Invalid length!", RxFrame);
                return;
            }

            Log("Get device working mode response", RxFrame);
            int Index = RxFrame[2];
            CurrentWorkingMode = RxFrame[2];

            if ((Index >= 0) && (Index < 4)) { cbxDeviceWorkingMode.SelectedIndex = Index;  }
        }

        private void ProcessGetDeviceCommunicationParameterResponse(byte[] RxFrame)
        {
            int idx = 4;

            Log("Get communication parameters response", RxFrame);

            if (RxFrame[1] == 0x00)
            {
                if (RxFrame[2] == 0x01)//USART
                {
                    Log("Get UART parameters response");
                    if (RxFrame[3] <= 10) { cbxUSARTBaudrate.SelectedIndex = RxFrame[3]; }
                }
                else if (RxFrame[2] == 0x02)//Ethernet
                {
                    Log("Get TCP/IP parameters response");
                    if ((RxFrame[3] & 0x01) == 0x01)
                    {
                        chkDeviceIP.Checked = true;

                        string s = string.Empty;
                        s = RxFrame[idx].ToString();
                        idx++;
                        s += ".";
                        s += RxFrame[idx].ToString();
                        idx++;
                        s += ".";
                        s += RxFrame[idx].ToString();
                        idx++;
                        s += ".";
                        s += RxFrame[idx].ToString();
                        idx++;

                        txtDeviceIP.Text = s;
                    }

                    if ((RxFrame[3] & 0x02) == 0x02)
                    {
                        chkGetWayIP.Checked = true;

                        string s = string.Empty;
                        s = RxFrame[idx].ToString();
                        idx++;
                        s += ".";
                        s += RxFrame[idx].ToString();
                        idx++;
                        s += ".";
                        s += RxFrame[idx].ToString();
                        idx++;
                        s += ".";
                        s += RxFrame[idx].ToString();
                        idx++;

                        txtDeviceGW.Text = s;
                    }

                    if ((RxFrame[3] & 0x04) == 0x04)
                    {
                        chkNetMask.Checked = true;

                        string s = string.Empty;
                        s = RxFrame[idx].ToString();
                        idx++;
                        s += ".";
                        s += RxFrame[idx].ToString();
                        idx++;
                        s += ".";
                        s += RxFrame[idx].ToString();
                        idx++;
                        s += ".";
                        s += RxFrame[idx].ToString();
                        idx++;

                        txtDeviceNetMask.Text = s;
                    }

                    if ((RxFrame[3] & 0x08) == 0x08)
                    {
                        chkServerPort.Checked = true;

                        string s = string.Empty;
                        ushort port;
                        port = RxFrame[idx++];
                        port <<= 8;
                        port |= RxFrame[idx++];

                        s = port.ToString();
                        txtDeviceServerPort.Text = s;

                    }

                    if ((RxFrame[3] & 0x10) == 0x10)
                    {
                        chkClientIP.Checked = true;

                        string s = string.Empty;
                        s = RxFrame[idx].ToString();
                        idx++;
                        s += ".";
                        s += RxFrame[idx].ToString();
                        idx++;
                        s += ".";
                        s += RxFrame[idx].ToString();
                        idx++;
                        s += ".";
                        s += RxFrame[idx].ToString();
                        idx++;

                        txtDeviceClietnIP.Text = s;
                    }

                    if ((RxFrame[3] & 0x20) == 0x20)
                    {
                        chkClientPort.Checked = true;

                        string s = string.Empty;
                        ushort port;
                        port = RxFrame[idx++];
                        port <<= 8;
                        port |= RxFrame[idx++];

                        s = port.ToString();
                        txtDeviceClientPort.Text = s;
                    }

                    if ((RxFrame[3] & 0x40) == 0x40)
                    {
                        //chkMACAddress.Checked = true;
                        byte[] mac_adr = new byte[6];
                        Array.Copy(RxFrame, idx, mac_adr, 0, 6);

                        string sBlockData = BitConverter.ToString(mac_adr).Replace("-", "");
                        txtMACAddress.Text = sBlockData;

                        idx += 6;
                    }

                    if ((RxFrame[3] & 0x80) == 0x80)
                    {
                        chkDHCP.Checked = true;
                        chkDeviceIP.Checked = false;
                        chkGetWayIP.Checked = false;
                        chkNetMask.Checked = false;
                    }
                    else { chkDHCP.Checked = false; }
                }
                else if(RxFrame[2] == 0x08)//rtc
                {
                    string s = string.Empty;
                    if ((RxFrame[3] & 0x01) == 0x01)
                    {                        
                        s += RxFrame[idx++].ToString();
                        s += ":";
                    }
                    if ((RxFrame[3] & 0x02) == 0x02)
                    {
                        s += RxFrame[idx++].ToString();
                        s += ":";
                    }
                    if ((RxFrame[3] & 0x04) == 0x04)
                    {
                        s += RxFrame[idx++].ToString();
                        s += " ";
                    }
                    if ((RxFrame[3] & 0x08) == 0x08)
                    {
                        s += RxFrame[idx++].ToString();
                        s += "/";
                    }
                    if ((RxFrame[3] & 0x10) == 0x10)
                    {
                        s += RxFrame[idx++].ToString();
                        s += "/";
                    }
                    if ((RxFrame[3] & 0x20) == 0x20)
                    {
                        s += RxFrame[idx++].ToString();
                    }

                    txtRTC.Text = s;
                }
                else
                {
                    MessageBox.Show("Invalid communication PHY ID received !");
                }
            }
        }

        private void ProcessSetDeviceCommunicationParameterResponse(byte[] RxFrame)
        {

        }

        private void ProcessHeartbeatResponse(byte[] RxFrame)
        {
            Log("Heartbeat response", RxFrame);
            if(RxFrame.Length >= 6)
            {
                byte[] sn =new byte[4];

                Array.Copy(RxFrame, 2, sn, 0,4);
                Array.Reverse(sn);
                uint SerialNumber32 = BitConverter.ToUInt32(sn, 0);
                string S1 = SerialNumber32.ToString();
                Log("Heartbeat response SN:" + S1);
            }
        }


        private void ProcessDeviceRestartResponse(byte[] RxFrame)
        {
            Log("Device restart response", RxFrame);
        }

        private void ProcessDiagnosisResponse(byte[] RxFrame)
        {
            bool Proceed = false;
            if(RxFrame.Length > 10)
            {
                if ((RxFrame[1] == 0x00) && (RxFrame[2] == 0x00)) { Proceed = true; }
            }

            if(Proceed)
            {
                byte FrameVersion = RxFrame[3];
                lblDiagFrameVersion.Text = FrameVersion.ToString();
                int Idx = 4;

                byte[] Ary = new byte[4];

                Array.Copy(RxFrame, Idx, Ary, 0, 4);
                Idx += 4;
                txtDeviceDuration.Text = BitConverter.ToUInt32(Ary, 0).ToString();//Device run time
                

                Array.Copy(RxFrame, Idx, Ary, 0, 4);
                Idx += 4;
                UInt32 Flags = BitConverter.ToUInt32(Ary, 0);//system flags

                if((Flags & 0x01) == 0x01)
                {
                    chkRFHardFault.Checked = true;
                }
                else
                {
                    chkRFHardFault.Checked = false;
                }

                if ((Flags & 0x02) == 0x02)
                {
                    chkEEPFault.Checked = true;
                }
                else
                {
                    chkEEPFault.Checked = false;
                }

                if ((Flags & 0x04) == 0x04)
                {
                    chkPHYHardFault.Checked = true;
                }
                else
                {
                    chkPHYHardFault.Checked = false;
                }

                txtRFErrorCode.Text = RxFrame[Idx].ToString();//RF error code
                Idx++;

                Array.Copy(RxFrame, Idx, Ary, 0, 4);
                Idx += 4;
                txtRFErrorCount.Text = BitConverter.ToUInt32(Ary, 0).ToString();//RF error count

                txtLastCmdCode.Text = RxFrame[Idx].ToString();//last command code
                Idx++;

                Array.Copy(RxFrame, Idx, Ary, 0, 4);
                Idx += 4;
                txtLastCmdExecDuration.Text = BitConverter.ToUInt32(Ary, 0).ToString();//Command exec duration

                txtLastCmdErrorCode.Text = RxFrame[Idx].ToString();//last command status
                Idx++;

                txtPHYLinkState.Text = RxFrame[Idx].ToString();
                Idx++;

                Array.Copy(RxFrame, Idx, Ary, 0, 4);
                Idx += 4;
                txtPHYLinkStateDuration.Text = BitConverter.ToUInt32(Ary, 0).ToString();//Link state duration

                Array.Copy(RxFrame, Idx, Ary, 0, 4);
                Idx += 4;
                txtPHY_OkPacketCounts.Text = BitConverter.ToUInt32(Ary, 0).ToString();//OK packet count

                Array.Copy(RxFrame, Idx, Ary, 0, 4);
                Idx += 4;
                txtPHY_NokPacketCounts.Text = BitConverter.ToUInt32(Ary, 0).ToString();//NOK packet count

                txtServerState.Text = RxFrame[Idx].ToString(); //TCP server state
                Idx++;

                Array.Copy(RxFrame, Idx, Ary, 0, 4);
                Idx += 4;
                txtServerStateDuration.Text = BitConverter.ToUInt32(Ary, 0).ToString();//State duration

                Array.Copy(RxFrame, Idx, Ary, 0, 4);
                Idx += 4;
                txtServerConnectCount.Text = BitConverter.ToUInt32(Ary, 0).ToString();//Connected count

                Array.Copy(RxFrame, Idx, Ary, 0, 4);
                Idx += 4;
                txtServerClosedCount.Text = BitConverter.ToUInt32(Ary, 0).ToString();//Closed count

                Array.Copy(RxFrame, Idx, Ary, 0, 4);
                Idx += 4;
                txtServerAbortedCount.Text = BitConverter.ToUInt32(Ary, 0).ToString();//Abort count

                Array.Copy(RxFrame, Idx, Ary, 0, 4);
                Idx += 4;
                txtServerTimedoutCount.Text = BitConverter.ToUInt32(Ary, 0).ToString();//Timedout count

                Array.Copy(RxFrame, Idx, Ary, 0, 4);
                Idx += 4;
                txtServerDataRxCount.Text = BitConverter.ToUInt32(Ary, 0).ToString();//RX packet count

                Array.Copy(RxFrame, Idx, Ary, 0, 4);
                Idx += 4;
                txtServerDataTxCount.Text = BitConverter.ToUInt32(Ary, 0).ToString();//TX packet count

                Array.Copy(RxFrame, Idx, Ary, 0, 4);
                Idx += 4;
                txtServerDataACKCount.Text = BitConverter.ToUInt32(Ary, 0).ToString();//ACK packet count

                //**//
                txtClientState.Text = RxFrame[Idx].ToString(); //TCP client state
                Idx++;

                Array.Copy(RxFrame, Idx, Ary, 0, 4);
                Idx += 4;
                txtClientStateDuration.Text = BitConverter.ToUInt32(Ary, 0).ToString();//State duration

                Array.Copy(RxFrame, Idx, Ary, 0, 4);
                Idx += 4;
                txtClientResetEcentCount.Text = BitConverter.ToUInt32(Ary, 0).ToString();//reset count

                Array.Copy(RxFrame, Idx, Ary, 0, 4);
                Idx += 4;
                txtClientConnectCount.Text = BitConverter.ToUInt32(Ary, 0).ToString();//connected count

                Array.Copy(RxFrame, Idx, Ary, 0, 4);
                Idx += 4;
                txtClientClosedCount.Text = BitConverter.ToUInt32(Ary, 0).ToString();//close count

                Array.Copy(RxFrame, Idx, Ary, 0, 4);
                Idx += 4;
                txtClientAbortedCount.Text = BitConverter.ToUInt32(Ary, 0).ToString();//abort count

                Array.Copy(RxFrame, Idx, Ary, 0, 4);
                Idx += 4;
                txtClientTimedoutCount.Text = BitConverter.ToUInt32(Ary, 0).ToString();//timedout count

                Array.Copy(RxFrame, Idx, Ary, 0, 4);
                Idx += 4;
                txtClientDataRxCount.Text = BitConverter.ToUInt32(Ary, 0).ToString();//TX packet count

                Array.Copy(RxFrame, Idx, Ary, 0, 4);
                Idx += 4;
                txtClientDataTxCount.Text = BitConverter.ToUInt32(Ary, 0).ToString();//RX packet count

                Array.Copy(RxFrame, Idx, Ary, 0, 4);
                Idx += 4;
                txtClientDataACKCount.Text = BitConverter.ToUInt32(Ary, 0).ToString();//ACK packet count

                /*Extension*/
                Array.Copy(RxFrame, Idx, Ary, 0, 4);
                Idx += 4;
                txtMemFailEventCounts.Text = BitConverter.ToUInt32(Ary, 0).ToString();//Mem fail packet count

                txtActiveSocketCounts.Text = RxFrame[Idx].ToString(); //TCP active socket count
                Idx++;

                Array.Copy(RxFrame, Idx, Ary, 0, 2);
                Idx += 2;
                txtLPort.Text = BitConverter.ToUInt32(Ary, 0).ToString();//L port

                Array.Copy(RxFrame, Idx, Ary, 0, 2);
                Idx += 2;
                txtSPort.Text = BitConverter.ToUInt32(Ary, 0).ToString();//S port

                Array.Copy(RxFrame, Idx, Ary, 0, 2);
                Idx += 2;
                txtRPort.Text = BitConverter.ToUInt32(Ary, 0).ToString();//R port

                Array.Copy(RxFrame, Idx, Ary, 0, 2);
                Idx += 2;
                txtCPort.Text = BitConverter.ToUInt32(Ary, 0).ToString();//C port

                Array.Copy(RxFrame, Idx, Ary, 0, 4);
                Idx += 4;
                txtServerAppCallCount.Text = BitConverter.ToUInt32(Ary, 0).ToString();//servver appcall count

                Array.Copy(RxFrame, Idx, Ary, 0, 4);
                Idx += 4;
                txtClientAppCallCount.Text = BitConverter.ToUInt32(Ary, 0).ToString();//client appcall count

                Array.Copy(RxFrame, Idx, Ary, 0, 4);
                Idx += 4;
                txtGlobalCallbackCount.Text = BitConverter.ToUInt32(Ary, 0).ToString();//global appcall count

                txtServerUnknownState.Text = RxFrame[Idx].ToString(); //server misc state
                Idx++;

                Array.Copy(RxFrame, Idx, Ary, 0, 4);
                Idx += 4;
                txtServerUStateCount.Text = BitConverter.ToUInt32(Ary, 0).ToString();//server misc state count

                txtClientUnknownState.Text = RxFrame[Idx].ToString(); //client misc state
                Idx++;

                Array.Copy(RxFrame, Idx, Ary, 0, 4);
                Idx += 4;
                txtClientUStateCount.Text = BitConverter.ToUInt32(Ary, 0).ToString();//client misc state count

                if(FrameVersion == 2)
                {
                    Array.Copy(RxFrame, Idx, Ary, 0, 4);
                    Idx += 4;
                    txtTIDScanTimeMsec.Text = BitConverter.ToUInt32(Ary, 0).ToString();//ID scan time delta
                }
            }
        }


        private void ProcessGetRFPowerResponse(byte[] RxFrame)
        {
            Log("Get RF power response", RxFrame);

            if (RxFrame[1] == 0x00)
            {
                ushort RFPower;

                RFPower = RxFrame[2];
                RFPower <<= 8;
                RFPower |= RxFrame[3];

                tbRFPower.Text = RFPower.ToString();

                lblRFInfo2.Text = "RF power = " + tbRFPower.Text;
            }

            DeviceRfPowerReceived = true;
        }

        private void ProcessSetRFPowerResponse(byte[] RxFrame)
        {
            Log("Set RF power response", RxFrame);
            if (RxFrame[1] == 0x00)
            {

            }
        }

        private void ProcessGetRFModeResponse(byte[] RxFrame)
        {
            ushort RFMode;

            Log("Get RF mode response", RxFrame);

            if (RxFrame[1] == 0x00)
            {
                RFMode = RxFrame[2];
                RFMode <<= 8;
                RFMode |= RxFrame[3];

                switch (RFMode)
                {
                    case 1:
                        cbxRFMode.SelectedIndex = 0;
                        break;
                    case 3:
                        cbxRFMode.SelectedIndex = 1;
                        break;
                    case 5:
                        cbxRFMode.SelectedIndex = 2;
                        break;
                    case 7:
                        cbxRFMode.SelectedIndex = 3;
                        break;
                    case 11:
                        cbxRFMode.SelectedIndex = 4;
                        break;
                    case 12:
                        cbxRFMode.SelectedIndex = 5;
                        break;
                    case 13:
                        cbxRFMode.SelectedIndex = 6;
                        break;
                    case 15:
                        cbxRFMode.SelectedIndex = 7;
                        break;
                }

                lblRFInfo3.Text = "RF mode = " + cbxRFMode.GetItemText(cbxRFMode.SelectedItem);

            }

            DeviceRFModeReceived = true;
        }


        private void ProcessSetRFModeResponse(byte[] RxFrame)
        {
            Log("Set RF power response", RxFrame);

            if (RxFrame[1] == 0x00)
            {

            }
        }


        private void ProcessGetRegionResponse(byte[] RxFrame)
        {
            Log("Get RF region response", RxFrame);

            if ((RxFrame[1] == 0x00) && (RxFrame[2] < 23))
            {
                cbxRegion.SelectedIndex = RxFrame[2];

                string Region = cbxRegion.GetItemText(cbxRegion.SelectedItem);
                FrequencyTableUpdate(Region);

                bool Ok = true;
                try
                {
                    if (cbxMinFreq.Items.Count > 0) { cbxMinFreq.SelectedIndex = RxFrame[3]; }
                    if (cbxMaxFreq.Items.Count > 0) { cbxMaxFreq.SelectedIndex = RxFrame[4]; }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    Ok = false;
                }

                lblRFInfo1.Text = "Region: " + Region;
                if(Ok)
                {
                    lblRFInfo1.Text = lblRFInfo1.Text
                                      + ", F(min) :" + cbxMinFreq.GetItemText(cbxMinFreq.SelectedItem) + "Hz"
                                      + ", F(max) :" + cbxMaxFreq.GetItemText(cbxMaxFreq.SelectedItem) + "Hz";
                }

                
            }
            DeviceRFRegionReceived = true;
        }


        private void ProcessSetRegionResponse(byte[] RxFrame)
        {
            Log("Set RF region response", RxFrame);
        }


        private void ProcessBlockReadResponse(byte[] RxFrame)
        {
            Log("EPC C1G2 block read response", RxFrame);

            if (RxFrame[1] == 0)
            {
                int BlockLength = RxFrame.Length - 2;
                byte[] BlockData = new byte[BlockLength];

                Array.Copy(RxFrame, 2, BlockData, 0, BlockData.Length);
                string sBlockData = BitConverter.ToString(BlockData).Replace("-", "");
                txtBlockData.Text = sBlockData;
            }
        }


        private void ProcessBlockWriteResponse(byte[] RxFrame)
        {
            Log("EPC C1G2 block write response", RxFrame);

            if (RxFrame[1] == 0)
            {

            }
        }

        private void ProcessGetExtendedInventoryConfigFrame(byte[] RxFrame)
        {
            int idx = 4;
            Log("Get extended inventory config. response", RxFrame);

            if ((RxFrame[2] & 0x01) == 0x01)//EPC_MASK_PRESENT
            {
                chkEPCMask.Checked = true;
                byte epc_length = RxFrame[idx++];
                byte[] epc_mask = new byte[epc_length];

                Array.Copy(RxFrame, idx, epc_mask, 0, epc_length);
                idx += epc_length;

                txtEPCMask2.Text = BitConverter.ToString(epc_mask).Replace("-", "");
            }
            else { chkEPCMask.Checked = false; }

            if ((RxFrame[2] & 0x02) == 0x02)//ACCESS_PWD_PRESENT
            {
                chkAccessPwd.Checked = true;

                byte[] access_pwd = new byte[4];
                Array.Copy(RxFrame, idx, access_pwd, 0, 4);

                txtAccessPwd2.Text = BitConverter.ToString(access_pwd).Replace("-", "");
                idx += 4;
            }
            else { chkAccessPwd.Checked = false; }

            if ((RxFrame[2] & 0x04) == 0x04)//REPORT_RSSI
            {
                chkReportRSSI.Checked = true;
            }
            else { chkReportRSSI.Checked = false; }


            if ((RxFrame[2] & 0x08) == 0x08)//REPORT_TID
            {
                chkReportTID.Checked = true;
            }
            else { chkReportTID.Checked = false; }

            if ((RxFrame[2] & 0x10) == 0x10)//REPORT_USER_MEM
            {
                chkReportUserMem.Checked = true;

                byte[] mem_address = new byte[2];
                Array.Copy(RxFrame, idx, mem_address, 0, 2);

                txtUserMemBlockAddress.Text = BitConverter.ToString(mem_address).Replace("-", "");
                idx += 2;

                byte total_blocks = RxFrame[idx++];
                txtUserMemBlockCount.Text = total_blocks.ToString();
            }
            else { chkReportUserMem.Checked = false; }

            if ((RxFrame[2] & 0x20) == 0x20)//REPORT_COMPLIANT_ONLY
            {
                chkComplaintTags.Checked = true;
            }
            else { chkComplaintTags.Checked = false; }

            if ((RxFrame[2] & 0x40) == 0x40)//IO_OPS_PASS_EN
            {
                chkIOPassEnable.Checked = true;

                cbxIO1.SelectedIndex = RxFrame[idx];
                idx++;
                if (RxFrame[idx] == 1) { cbxIO1State.SelectedIndex = 0; }
                else { cbxIO1State.SelectedIndex = 1; }
                idx++;

                ushort dwell_time = RxFrame[idx++];
                dwell_time <<= 8;
                dwell_time |= RxFrame[idx++];

                txtIO1_DwellTime.Text = dwell_time.ToString();
            }
            else { chkIOPassEnable.Checked = false; }

            if ((RxFrame[2] & 0x80) == 0x80)//IO_OPS_FAIL_EN
            {
                chkIOFailEnable.Checked = true;

                cbxIO2.SelectedIndex = RxFrame[idx];
                idx++;
                if (RxFrame[idx] == 1) { cbxIO2State.SelectedIndex = 0; }
                else { cbxIO2State.SelectedIndex = 1; }
                idx++;

                ushort dwell_time = RxFrame[idx++];
                dwell_time <<= 8;
                dwell_time |= RxFrame[idx++];

                txtIO2_DwellTime.Text = dwell_time.ToString();
            }
            else { chkIOFailEnable.Checked = false; }

            if ((RxFrame[3] & 0x01) == 0x01)//IO_OPS_TRIGGER_EN
            {
                chkInvTriggerEnable.Checked = true;
                chkIOFailEnable.Checked = true;


                idx++;
                idx++;

                ushort dwell_time = RxFrame[idx++];
                dwell_time <<= 8;
                dwell_time |= RxFrame[idx++];

                txtIO3_DwellTime.Text = dwell_time.ToString();
            }
            else { chkInvTriggerEnable.Checked = false; }

            if ((RxFrame[3] & 0x02) == 0x02)//EPC_PERSISTENCE_EN
            {
                chkEPCPersistance.Checked = true;

                ushort persistence_time = RxFrame[idx++];
                persistence_time <<= 8;
                persistence_time |= RxFrame[idx++];

                txtTagPersistenceTime.Text = persistence_time.ToString();
            }
            else
            {
                chkEPCPersistance.Checked = false;
            }

            if ((RxFrame[3] & 0x04) == 0x04)//include/exclude antenna ID into the response frame
            {
                chkIncludeAntennaID.Checked = true;
            }
            else
            {
                chkIncludeAntennaID.Checked = false;
            }

            if ((RxFrame[3] & 0x08) == 0x08)//Heartbeat enable
            {
                chkHeartbeatEn.Checked = true;
                ushort HeartbeatX100mS;

                HeartbeatX100mS = RxFrame[idx++];
                HeartbeatX100mS <<= 8;
                HeartbeatX100mS |= RxFrame[idx++];

                txtHeartbeat2.Text = HeartbeatX100mS.ToString();
            }
            else { chkHeartbeatEn.Checked = false;  }

            if ((RxFrame[3] & 0x10) == 0x10)//EPC_PERSISTENCE_ARST_EN
            {
                chkPersistanceAutoReset.Checked = true;
            }
            else
            {

              chkPersistanceAutoReset.Checked= false;   
            }

            if ((RxFrame[3] & 0x20)==0x20)
            {
                chkBufferedReadMode.Checked = true;
            }
            else
            {
                chkBufferedReadMode.Checked = false;
            }
            if ((RxFrame[3] & 0x40) == 0x40)//Send device serial ID
            { chkReaderID.Checked = true; }
            else { chkReaderID.Checked = false; }

            if ((RxFrame[3] & 0x80) == 0x80)//AUTO_INVENTORY_ENABLE
            {
                chkInvOpsEnable.Checked = true;
            }
            else { chkInvOpsEnable.Checked = false; }
        }

        private void ProcessEPCVaultOperationResponseFrame(byte[] RxFrame)
        {
            Log("EPC mask storage operation response", RxFrame);
            if (RxFrame[1] == 0x00)
            {
                switch (RxFrame[2])
                {
                    case 0x01://parse write response
                        break;
                    case 0x02://parse read response
                        byte MemoryLocation = RxFrame[3];
                        byte MaskConf0 = RxFrame[4];
                        byte MaskConf1 = RxFrame[5];
                        byte MaskLength = RxFrame[6];

                        if ((MaskLength > 0) && (MaskLength < 13))
                        {
                            byte[] Mask = new byte[MaskLength];
                            Array.Copy(RxFrame, 7, Mask, 0, MaskLength);
                            Log("EPC Mask", Mask);

                            string sMask = BitConverter.ToString(Mask).Replace("-", "");

                            if (MemoryLocation == 0)
                            {
                                txtMask0.Text = sMask;
                                if ((MaskConf0 & 0x01) == 0x01) { chkMask0Enabled.Checked = true; }
                                else { chkMask0Enabled.Checked = false; }
                            }
                            if (MemoryLocation == 1)
                            {
                                txtMask1.Text = sMask;
                                if ((MaskConf0 & 0x01) == 0x01) { chkMask1Enabled.Checked = true; }
                                else { chkMask1Enabled.Checked = false; }
                            }
                            if (MemoryLocation == 2)
                            {
                                txtMask2.Text = sMask;
                                if ((MaskConf0 & 0x01) == 0x01) { chkMask2Enabled.Checked = true; }
                                else { chkMask2Enabled.Checked = false; }
                            }
                            if (MemoryLocation == 3)
                            {
                                txtMask3.Text = sMask;
                                if ((MaskConf0 & 0x01) == 0x01) { chkMask3Enabled.Checked = true; }
                                else { chkMask3Enabled.Checked = false; }
                            }
                            if (MemoryLocation == 4)
                            {
                                txtMask4.Text = sMask;
                                if ((MaskConf0 & 0x01) == 0x01) { chkMask4Enabled.Checked = true; }
                                else { chkMask4Enabled.Checked = false; }
                            }
                            if (MemoryLocation == 5)
                            {
                                txtMask5.Text = sMask;
                                if ((MaskConf0 & 0x01) == 0x01) { chkMask5Enabled.Checked = true; }
                                else { chkMask5Enabled.Checked = false; }
                            }
                            if (MemoryLocation == 6)
                            {
                                txtMask6.Text = sMask;
                                if ((MaskConf0 & 0x01) == 0x01) { chkMask6Enabled.Checked = true; }
                                else { chkMask6Enabled.Checked = false; }
                            }
                            if (MemoryLocation == 7)
                            {
                                txtMask7.Text = sMask;
                                if ((MaskConf0 & 0x01) == 0x01) { chkMask7Enabled.Checked = true; }
                                else { chkMask7Enabled.Checked = false; }
                            }
                            if (MemoryLocation == 8)
                            {
                                txtMask8.Text = sMask;
                                if ((MaskConf0 & 0x01) == 0x01) { chkMask8Enabled.Checked = true; }
                                else { chkMask8Enabled.Checked = false; }
                            }
                            if (MemoryLocation == 9)
                            {
                                txtMask9.Text = sMask;
                                if ((MaskConf0 & 0x01) == 0x01) { chkMask9Enabled.Checked = true; }
                                else { chkMask9Enabled.Checked = false; }
                            }

                        }
                        else
                        {
                            MessageBox.Show("Invalid mask length reported!");
                        }

                        break;
                    case 0x03://parse enable response
                        break;
                    case 0x04://parse erase response
                        byte Location = RxFrame[3];
                        switch (Location)
                        {
                            case 0: txtMask0.Text = ""; break;
                            case 1: txtMask1.Text = ""; break;
                            case 2: txtMask2.Text = ""; break;
                            case 3: txtMask3.Text = ""; break;
                            case 4: txtMask4.Text = ""; break;
                            case 5: txtMask5.Text = ""; break;
                            case 6: txtMask6.Text = ""; break;
                            case 7: txtMask7.Text = ""; break;
                            case 8: txtMask8.Text = ""; break;
                            case 9: txtMask9.Text = ""; break;
                        }
                        break;
                    default:
                        break;
                }
            }

        }

        private void ProcessParkingmodeResponseFrame(byte[] RxFrame)
        {
            byte ResponseCode = RxFrame[1];
            byte SubCmdCode   = RxFrame[2];            

            Log("Parking mode operation response frame", RxFrame);

             switch (SubCmdCode)
            {
                case 0x01:
                    if (ResponseCode == 0) { Log("Parking mode new tag registration : Success"); }
                    if (ResponseCode == 6) { Log("Parking mode new tag registration : Entry already exists!"); }
                    break;
                case 0x02:
                    break;
                case 0x03:
                    break;
                case 0x04://Get parking mode record counters frame response

                    if (ResponseCode != 0) { return; }
                    ushort RecordCount;

                    RecordCount = RxFrame[3];
                    RecordCount <<= 8;
                    RecordCount |= RxFrame[4];

                    txtParkModeWhitelistRecordsCounter.Text = RecordCount.ToString();

                    RecordCount = RxFrame[5];
                    RecordCount <<= 8;
                    RecordCount |= RxFrame[6];

                    txtParkModeBlacklistRecordsCounter.Text = RecordCount.ToString();
                    break;
                case 0x05:
                    if (ResponseCode != 0)
                    {
                        Log("Parking mode get stored TID entry response : Error! (Authfail?/Entry list empty?)");                    
                        ParkingmodeRecordReadStop();
                    }
                    else
                    {
                        ProcessParkingmodeTID_EntryFrame(RxFrame);
                    }
                    break;
                case 0x09://check record response frame
                    if (ResponseCode == 0)
                    {
                        byte Category = RxFrame[3];
                        byte FlagGroup1, FlagGroup0;

                        switch (Category)
                        {
                            case 1: chkCat1.Checked = true; break;
                            case 2: chkCat2.Checked = true; break;
                            case 3: chkCat3.Checked = true; break;
                            case 4: chkCat4.Checked = true; break;
                        }

                        FlagGroup1 = RxFrame[4];
                        FlagGroup0 = RxFrame[5];

                        if ((FlagGroup0 & 0x04) == 0x04) { chkRecordIsBlacklist.Checked = true; }
                        else if ((FlagGroup0 & 0x02) == 0x02) { chkRecordIsWhitelist.Checked = true; }
                    }
                    else
                    {
                        Log("Given record does not exist!");
                    }
                    break;
                case 0x0A:
                    if (ResponseCode == 0) { Log("Parking mode record attribute update : Success"); }
                    else { Log("Parking mode record attribute update : Record not found!"); }
                    break;
                case 0x0B:
                    if (ResponseCode == 0) { Log("Parking mode single record delete operation : Success"); }
                    else { Log("Parking mode single record delete operation: Record not found!"); }
                    break;
                case 0x10:
                    if (ResponseCode == 0)
                    {
                        ushort CatConfig;

                        CatConfig = RxFrame[3];

                        if ((CatConfig & 0x01) == 0x01) { chkCat1R1.Checked = true; }
                        else { chkCat1R1.Checked = false; }
                        if ((CatConfig & 0x02) == 0x02) { chkCat1R2.Checked = true; }
                        else { chkCat1R2.Checked = false; }
                        if ((CatConfig & 0x04) == 0x04) { chkCat1R3.Checked = true; }
                        else { chkCat1R3.Checked = false; }
                        if ((CatConfig & 0x08) == 0x08) { chkCat1R4.Checked = true; }
                        else { chkCat1R4.Checked = false; }

                        CatConfig = RxFrame[4];

                        if ((CatConfig & 0x01) == 0x01) { chkCat2R1.Checked = true; }
                        else { chkCat2R1.Checked = false; }
                        if ((CatConfig & 0x02) == 0x02) { chkCat2R2.Checked = true; }
                        else { chkCat2R2.Checked = false; }
                        if ((CatConfig & 0x04) == 0x04) { chkCat2R3.Checked = true; }
                        else { chkCat2R3.Checked = false; }
                        if ((CatConfig & 0x08) == 0x08) { chkCat2R4.Checked = true; }
                        else { chkCat2R4.Checked = false; }

                        CatConfig = RxFrame[5];

                        if ((CatConfig & 0x01) == 0x01) { chkCat3R1.Checked = true; }
                        else { chkCat3R1.Checked = false; }
                        if ((CatConfig & 0x02) == 0x02) { chkCat3R2.Checked = true; }
                        else { chkCat3R2.Checked = false; }
                        if ((CatConfig & 0x04) == 0x04) { chkCat3R3.Checked = true; }
                        else { chkCat3R3.Checked = false; }
                        if ((CatConfig & 0x08) == 0x08) { chkCat3R4.Checked = true; }
                        else { chkCat3R4.Checked = false; }

                        CatConfig = RxFrame[6];

                        if ((CatConfig & 0x01) == 0x01) { chkCat4R1.Checked = true; }
                        else { chkCat4R1.Checked = false; }
                        if ((CatConfig & 0x02) == 0x02) { chkCat4R2.Checked = true; }
                        else { chkCat4R2.Checked = false; }
                        if ((CatConfig & 0x04) == 0x04) { chkCat4R3.Checked = true; }
                        else { chkCat4R3.Checked = false; }
                        if ((CatConfig & 0x08) == 0x08) { chkCat4R4.Checked = true; }
                        else { chkCat4R4.Checked = false; }
                    }
                    else { Log("Parking mode get Category configuration operation: Invalid parameter!"); }
                    break;
                case 0x11:
                    break;
                case 0x12:
                    if (ResponseCode == 0)
                    {
                        int idx = 3;
                        //int RelayAttribute;
                        int RelayOnTime;

                        /*relay-1*/
                        //RelayAttribute = RxFrame[idx++];
                        RelayOnTime    = RxFrame[idx++];
                        RelayOnTime    = RelayOnTime << 8;
                        RelayOnTime    = RelayOnTime | RxFrame[idx++];
                        txtRelay1OnTime.Text = RelayOnTime.ToString();


                        /*relay-2*/
                        //RelayAttribute = RxFrame[idx++];
                        RelayOnTime = RxFrame[idx++];
                        RelayOnTime = RelayOnTime << 8;
                        RelayOnTime = RelayOnTime | RxFrame[idx++];
                        txtRelay2OnTime.Text = RelayOnTime.ToString();


                        /*relay-3*/
                        //RelayAttribute = RxFrame[idx++];
                        RelayOnTime = RxFrame[idx++];
                        RelayOnTime = RelayOnTime << 8;
                        RelayOnTime = RelayOnTime | RxFrame[idx++];
                        txtRelay3OnTime.Text = RelayOnTime.ToString();
            

                        /*relay-4*/
                        //RelayAttribute = RxFrame[idx++];
                        RelayOnTime = RxFrame[idx++];
                        RelayOnTime = RelayOnTime << 8;
                        RelayOnTime = RelayOnTime | RxFrame[idx++];
                        txtRelay4OnTime.Text = RelayOnTime.ToString();
    
                    }
                break;
                case 0x13:
                break;
                case 0x20:
                    if (ResponseCode == 0)
                    {
                        ushort PersistenceMs100;

                        if (RxFrame[3] > 0)  { chkParkModePersistenceAutoReset.Checked = true; }
                        else { chkParkModePersistenceAutoReset.Checked = false; }

                        PersistenceMs100 = RxFrame[4];
                        PersistenceMs100 <<= 8;
                        PersistenceMs100 |= RxFrame[5];

                        txtParkModePersistence.Text = PersistenceMs100.ToString();

                        Log("Parking mode get persistence operation: OK!");
                    }
                    else
                    {
                        Log("Parking mode get persistence operation: Authentication fail!");
                    }
                break;
                case 0x21:
                    if (ResponseCode == 0) { Log("Parking mode set persistence operation: OK!"); }
                    else                   { Log("Parking mode set persistence operation: Authentication fail!"); }
                break;
                case 0x22:
                    if (ResponseCode == 0) 
                    { 
                        if(RxFrame[3] == 0x02)
                        {
                            radParmodeDataToTCP_Server.Checked = true;
                            radParmodeDataToTCP_Client.Checked = false;
                        }
                        else if(RxFrame[3] == 0x04)
                        {
                            radParmodeDataToTCP_Server.Checked = false;
                            radParmodeDataToTCP_Client.Checked = true;
                        }
                        else
                        {
                            MessageBox.Show("Received TID route config. is not valid!");
                        }
                        Log("Parking mode get TID route operation: OK!"); 
                    }
                    else { Log("Parking mode get TID route operation: Authentication fail!"); }
                break;
                case 0x23:
                    if (ResponseCode == 0) { Log("Parking mode set TID route operation: OK!"); }
                    else                 { Log("Parking mode set TID route operation: Authentication fail!"); }
                break;
                case 0x24:
                    if (ResponseCode == 0)
                    {
                        if (RxFrame[3] == 0x01)
                        {
                            radParkmodeLogWLOnly.Checked = true;
                            radParkModeLogAll.Checked = false;
                        }
                        else if (RxFrame[3] == 0x02)
                        {
                            radParkmodeLogWLOnly.Checked = false;
                            radParkModeLogAll.Checked = true;
                        }
                        else
                        {
                            MessageBox.Show("Received TID log config. is not valid!");
                        }
                        Log("Parking mode set TID log config. operation: OK!"); 
                    }
                    else { Log("Parking mode set TID log config. operation: Authentication fail!"); }
                    break;
                case 0x25:
                    if (ResponseCode == 0) { Log("Parking mode set TID log config. operation: OK!");  }
                    else  { Log("Parking mode set TID log config. operation: Authentication fail!");}
                break;
                case 0x26:
                    if (ResponseCode == 0)
                    {
                        byte[] temp = new byte[4];
                        Array.Copy(RxFrame,3,temp,0,temp.Length);

                        //if (DeviceFirmwareVersion[1] > 9) { A }//Firmware bugfix(little endian to bigendian)
                        Array.Reverse(temp);
                        uint LoggedTIDCount = BitConverter.ToUInt32(temp, 0);
                        string S1 = LoggedTIDCount.ToString();
                        txtParkingmodeLoggedTIDCount.Text = S1;
                    }
                    else { Log("Parking mode get logged TID count operation fail!"); }
                break;
                case 0x27:
                    if (ResponseCode == 0) {  }
                    else { Log("Parking mode log read operation fail!"); ParkingmodeLogReadStop();  }
                break;
                case 0x28:
                    if (RxFrame[3] > 0)
                    {
                        chkParkingmodeIncDeviceSNR.Checked = true;
                    }            
                    else
                    {
                        chkParkingmodeIncDeviceSNR.Checked = false;
                    }
                break;
                case 0x29:
                    if (ResponseCode == 0) { Log("Parking mode set DeviceID in TID config. operation: OK!"); }
                    else { Log("Parking mode set DeviceID in TID config. operation: Fail!"); }
                break;
                case 0xF0://password authenticate response
                    if(ResponseCode == 0)
                    {
                        ParkModeAuthentOK = true;
                        Log("Parking mode password authentication success!");
                    }
                    else
                    {
                        ParkModeAuthentOK = false;
                        Log("Parking mode password authentication fail!");
                    }
                    break;
                case 0xF1://password de-authenticate response
                    if (ResponseCode == 0) { Log("Parking mode password de-authentication success!"); }
                break;
                case 0xF2://password update response
                    if (ResponseCode == 0) 
                    {
                        Array.Copy(NewParkingmodePwd, ParkingmodePwd, ParkingmodePwd.Length);
                        Log("Parking mode password update success!");
                    }
                    else 
                    {
                        Log("Parking mode password update fail!"); 
                        ParkModeAuthentOK = false;
                    }
                break;

            }
        }

        private void ExtendedInventoryConfflagsPublish(byte cfg0, byte cfg1)
        {
            if ((cfg0 & 0x01) == 0x01) { chkEPCMask.Checked = true; }
            else { chkEPCMask.Checked = false;  }

            if ((cfg0 & 0x02) == 0x02) { chkAccessPwd.Checked = true; }
            else { chkAccessPwd.Checked = false; }

            if ((cfg0 & 0x04) == 0x04) { chkReportRSSI.Checked = true; }
            else { chkReportRSSI.Checked = false; }

            if ((cfg0 & 0x08) == 0x08) { chkReportTID.Checked = true; }
            else { chkReportTID.Checked = false; }

            if ((cfg0 & 0x10) == 0x10) { chkReportUserMem.Checked = true; }
            else { chkReportUserMem.Checked = false; }

            if ((cfg0 & 0x20) == 0x20) { chkComplaintTags.Checked = true; }
            else { chkComplaintTags.Checked = false; }

            if ((cfg0 & 0x40) == 0x40) { chkIOPassEnable.Checked = true; }
            else { chkIOPassEnable.Checked = false; }

            if ((cfg0 & 0x80) == 0x80) { chkIOFailEnable.Checked = true; }
            else { chkIOFailEnable.Checked = false; }


            if ((cfg1 & 0x01) == 0x01) { chkInvTriggerEnable.Checked = true; }
            else { chkInvTriggerEnable.Checked = false; }

            if ((cfg1 & 0x02) == 0x02) { chkEPCPersistance.Checked = true; }
            else { chkEPCPersistance.Checked = false; }

            if ((cfg1 & 0x04) == 0x04) { chkIncludeAntennaID.Checked = true; }
            else { chkIncludeAntennaID.Checked = false; }


            if ((cfg1 & 0x08) == 0x08) { chkHeartbeatEn.Checked = true; }
            else { chkHeartbeatEn.Checked = false; }

            if ((cfg1 & 0x10) == 0x10) { chkPersistanceAutoReset.Checked = true; }
            else { chkPersistanceAutoReset.Checked = false; }

            if ((cfg1 & 0x20) == 0x20) { chkBufferedReadMode.Checked = true; }
            else { chkBufferedReadMode.Checked = false; }

            if ((cfg1 & 0x40) == 0x40) { chkReaderID.Checked = true; }
            else { chkReaderID.Checked = false; }

            if ((cfg1 & 0x80) == 0x80) { chkInvOpsEnable.Checked = true; }
            else { chkInvOpsEnable.Checked = false; }
        }

        private void ExtendedInventoryMuxConfigUpdate(byte MuxConfig)
        {
            Log("extended inventory antenna multiplexer config. get response frame");

            if ((MuxConfig & 0x01) == 0x01)
            {
                ChkExtAnt1.Checked = true;
            }
            else
            {
                ChkExtAnt1.Checked = false;
            }

            if ((MuxConfig & 0x01) == 0x01)
            {
                ChkExtAnt1.Checked = true;
            }
            else
            {
                ChkExtAnt1.Checked = false;
            }

            if ((MuxConfig & 0x02) == 0x02)
            {
                ChkExtAnt2.Checked = true;
            }
            else
            {
                ChkExtAnt2.Checked = false;
            }

            if ((MuxConfig & 0x04) == 0x04)
            {
                ChkExtAnt3.Checked = true;
            }
            else
            {
                ChkExtAnt3.Checked = false;
            }

            if ((MuxConfig & 0x08) == 0x08)
            {
                ChkExtAnt4.Checked = true;
            }
            else
            {
                ChkExtAnt4.Checked = false;
            }

            if ((MuxConfig & 0x10) == 0x10)
            {
                ChkExtAnt5.Checked = true;
            }
            else
            {
                ChkExtAnt5.Checked = false;
            }

            if ((MuxConfig & 0x20) == 0x20)
            {
                ChkExtAnt6.Checked = true;
            }
            else
            {
                ChkExtAnt6.Checked = false;
            }
            if(0 == MuxConfig)
            {
                Log("Warning: no antenna selected!");
            }
        }

        private void ProcessExtInvConfResponseFrame(byte[] RxFrame)
        {
            byte ResponseCode = RxFrame[1];
            byte OpCode       = RxFrame[2];

            if (ResponseCode == 0)
            {
                switch(OpCode)
                {
                    case 0x01://get extended inventory config flags
                        ExtendedInventoryConfflagsPublish(RxFrame[3], RxFrame[4]);
                    break;
                    case 0x02://update extended inventory config flags
                        Log("extended inventory config flags update OK!");
                    break;
                    case 0x03://extended inventory soft trigger enable
                       Log("extended inventory soft trigger enable OK!");
                    break;
                    case 0x04://extended inventory soft trigger disable
                        Log("extended inventory soft trigger disable OK!");
                    break;
                    case 0x07:
                        ExtendedInventoryMuxConfigUpdate(RxFrame[3]);
                    break;
                    case 0x08:
                        if(0 == ResponseCode)
                        {
                            Log("extended inventory antenna multiplexer config. save OK!");
                        }
                        else
                        {
                            Log("extended inventory antenna multiplexer config. save ERROR!");
                        }
                    break;
                }
            }
        }

        private void ProcessExtInvRoutRespFrame(byte[]RxFrame)
        {
            byte ResponseCode = RxFrame[1];
            byte OpCode = RxFrame[2];
            
            if (ResponseCode == 0)
            {
                switch (OpCode)
                {
                    case 0x01://get extended inventory rout path
                        byte RoutePath = RxFrame[3];
                        if (RoutePath == 0x02)
                        {
                            radExtInvRespRouteToServer.Checked = true;
                            radExtInvRespRouteToClient.Checked = false;
                            Log("Remote route path: TCP Server!");
                        }
                        else if (RoutePath == 0x04)
                        {
                            radExtInvRespRouteToServer.Checked = false;
                            radExtInvRespRouteToClient.Checked = true;
                            Log("Remote route path: TCP client!");
                        }
                        else
                        {
                            Log("Remote route path is not valid!");
                        }
                    break;
                    case 0x02://update extended inventory route path
                        Log("Remote route change OK!");
                    break;
               }
            }
        }

        private void ProcessBRMRecordOpsResponse(byte[] RxFrame)
        {
            byte ResponseCode = RxFrame[1];
            byte OpCode = RxFrame[2];

            switch (OpCode)
            {
                case 0x01:
                    if(ResponseCode == 0)
                    {

                    }
                    break;
                case 0x02:
                    if(ResponseCode != 0)
                    {
                        //StopBRMLogOps();
                    }
                    break;
                case 0xFE:
                    if(ResponseCode == 0)
                    { }
                    break;
            }            
        }

        private void ProcessRFDiagnosisFrame(byte[] RxFrame)
        {
            Log("RF diagnosis response", RxFrame);

            byte offset = 2;
            if (RxFrame[1] == 0x00)
            {
                Int16 RSSI = RxFrame[offset++];
                RSSI <<= 8;
                RSSI |= RxFrame[offset];
                Double fRSSI = Convert.ToDouble(RSSI) / 100.0;

                if (IsFirstAcq)
                {
                    IsFirstAcq = false;
                    FilteredRssi  = fRSSI;
                    FilteredRssi2 = fRSSI;

                }
                else
                {
                    FilteredRssi = (0.1 * fRSSI) + (0.9 * FilteredRssi);
                    FilteredRssi2 = (0.1 * FilteredRssi) + (0.9 * FilteredRssi2);
                }
                //data_list1.Add(ArrayIndex, fRSSI);
                //data_list2.Add(ArrayIndex, FilteredRssi);
                data_list3.Add(ArrayIndex, FilteredRssi2);
                ArrayIndex++;
                zedGraphControl1.Invalidate();
                zedGraphControl1.AxisChange();

                txtRSSINow.Text = fRSSI.ToString();
                txtRSSIAvg.Text = FilteredRssi.ToString();
            }
        }

        private void PaketReceived(object sender, ByteArrayArgs e)
        {
            byte[] RxFrame = e.Data;
            byte RespCmdCode = RxFrame[0];

            if(RxFrame.Length < 3) 
            {
                Console.WriteLine("Not a good packet!");
                return; 
            }

            this.Invoke((EventHandler)delegate
            {
                switch (RespCmdCode)
                {
                    case 0x01:
                      ProcessGetDeviceInfoFrame(RxFrame);
                    break;
                    case 0x02:
                      ProcessGetDeviceWorkingMode(RxFrame);
                    break;
                    case 0x03:
                    break;
                    case 0x04:
                      ProcessGetDeviceCommunicationParameterResponse(RxFrame);
                    break;
                    case 0x05:
                      ProcessSetDeviceCommunicationParameterResponse(RxFrame);
                    break;
                    case 0x06:
                    break;
                    case 0x0A:
                      ProcessHeartbeatResponse(RxFrame);
                    break;
                    case 0x0C:
                      ProcessDeviceRestartResponse(RxFrame);
                    break;
                    case 0x0E:
                      ProcessDiagnosisResponse(RxFrame);
                    break;
                    case 0x0F:
                       ProcessGlobalPasswordOpsResponse(RxFrame);
                    break;
                    case 0x10:
                      ProcessGetRFPowerResponse(RxFrame);
                    break;
                    case 0x11:
                      ProcessSetRFPowerResponse(RxFrame);
                    break;
                    case 0x12:
                      ProcessGetRFModeResponse(RxFrame);
                    break;
                    case 0x13:
                      ProcessSetRFModeResponse(RxFrame);
                    break;
                    case 0x14:
                      ProcessGetRegionResponse(RxFrame);
                    break;
                    case 0x15:
                      ProcessSetRegionResponse(RxFrame);
                    break;
                    case 0x16:
                      ProcessGetInventoryQResponse(RxFrame);
                    break;
                    case 0x17:
                      ProcessSetInventoryQResponse(RxFrame);
                    break;
                    case 0x18:
                      ProcessGetInventorySessionResponse(RxFrame);
                    break;
                    case 0x19:
                      ProcessSetInventorySessionResponse(RxFrame);
                    break;
                    case 0x1A:
                      ProcessGetInventoryTargetResponse(RxFrame);
                    break;
                    case 0x1B:
                      ProcessSetInventoryTargetResponse(RxFrame);
                    break;
                    case 0x1C:
                        ProcessMuxConfigResponse(RxFrame);
                    break;
                    case 0x20:
                    case 0x21:
                        ProcessInventoryCompleteResponse(RxFrame);                    
                    break;
                    case 0x22:
                      ProcessBlockReadResponse(RxFrame);
                    break;
                    case 0x23:
                      ProcessBlockWriteResponse(RxFrame);
                    break;
                    case 0x24:
                    break;
                    case 0x25:
                    break;
                    case 0x26:
                    break;
                    case 0x27:
                    break;
                    case 0xA0:
                      ProcessParkingmodeResponseFrame(RxFrame);
                    break;
                    case 0xE0:
                      ProcessInventoryResponse(RxFrame);
                    break;
                    case 0xE2:
                        ProcessParkingmodeTID_Frame(RxFrame);
                    break;
                    case 0xD0:
                    break;
                    case 0xD1:
                      ProcessGetExtendedInventoryConfigFrame(RxFrame);
                    break;
                    case 0xD2:
                    break;
                    case 0xD3:
                      ProcessEPCVaultOperationResponseFrame(RxFrame);
                    break;
                    case 0xD4:
                    break;
                    case 0xD5:
                        ProcessExtInvConfResponseFrame(RxFrame);
                    break;
                    case 0xD6:
                        ProcessExtInvRoutRespFrame(RxFrame);
                    break;
                    case 0xD7:
                        ProcessBRMRecordOpsResponse(RxFrame);
                    break;
                    case 0xD8:
                        ProcessExtInvConfResponse(RxFrame);
                    break;
                    case 0xDA:
                      ProcessRFDiagnosisFrame(RxFrame);
                    break;
                    case 0xFF:
                        Log("Error frame received!", RxFrame);
                    break;
                }
            });
        }

        private void ProcessExtInvConfResponse(byte[] rxFrame)
        {
            byte OpCode = rxFrame[2];
            byte ResponseCode = rxFrame[1];

            switch(OpCode)
            {
                case 0x01:
                    if (ResponseCode == 0)
                    {
                        int Cfg = rxFrame[3];
                        if (0x01 == (Cfg & 0x01)) { chkEPCPersistance.Checked = true; }
                        if (0x02 == (Cfg & 0x02)) { chkPersistanceAutoReset.Checked = true; }

                        ushort persistence_time = rxFrame[4];
                        persistence_time <<= 8;
                        persistence_time |= rxFrame[5];

                        txtTagPersistenceTime.Text = persistence_time.ToString();
                    }
                    break;
                case 0x02:
                    if (ResponseCode == 0) { Log("Persistence conf. update OK!"); }
                    else { Log("Persistence conf. update FAIL!"); }
                    break;
                case 0x05:
                    if (ResponseCode == 0)
                    {
                        ushort CycleTime = rxFrame[3];
                        CycleTime <<= 8;
                        CycleTime |= rxFrame[4];

                        txtCycleTime.Text = CycleTime.ToString();
                    }
                    break;
                case 0x06:
                    if (ResponseCode == 0) { Log("Cycle time update OK!"); }
                    else { Log("Cycle time update FAIL!"); }
                    break;
            }

            if (OpCode == 0x01)
            {

            }

            if(OpCode == 0x02)
            {

            }
        }

        private void ProcessGlobalPasswordOpsResponse(byte[] rxFrame)
        {
            byte OpCode       = rxFrame[2];
            byte ResponseCode = rxFrame[1];

            if (OpCode == 0x01)
            {
                if (ResponseCode == 0)
                {
                    Array.Copy(NewGlobalPassword, GlobalPassword, NewGlobalPassword.Length);
                    Log("Global password operation success!");
                }
                else
                {
                    Log("Global password operation fail!");
                }
            }
        }

        private void radSelectCOMPort_CheckedChanged(object sender, EventArgs e)
        {
            if (radSelectCOMPort.Checked)
            {
                grpCOM.Enabled = true;
                grpTCP.Enabled = false;
                ConnectBySerialPort = true;
                ConnectByTCP = false;
            }
        }

        private void radSelectTCP_CheckedChanged(object sender, EventArgs e)
        {
            if (radSelectTCP.Checked)
            {
                grpCOM.Enabled = false;
                grpTCP.Enabled = true;
                ConnectBySerialPort = false;
                ConnectByTCP = true;
            }
        }

        private void ParkingModeDefaultSetup()
        {
            radParkModeCat1.Checked = true;
            chkParkModeTagWhitelistEnable.Checked = true;
            ParkModeAuthentOK = false;
        }

        private void InterfaceSelectionCtrl(bool enable)
        {
            radSelectCOMPort.Enabled = enable;
            radSelectTCP.Enabled = enable;
            grpCOM.Enabled = enable;

            if (!radSelectTCP.Checked) { grpTCP.Enabled = false; }
            else { grpTCP.Enabled = enable; }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            SetupDefaults();
            ControlsEnable(true);
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            if (btnConnect.Tag.ToString() == "0")
            {
                if (ConnectBySerialPort)
                {
                    if (!OpenCOMPort()) { return; }
                    IsConnected = true;
                }
                else
                {
                    if (radTCPServer.Checked)
                    {
                        txtPortTcpServer.Text = txtTCP_Port.Text;
                        TCP_LocalServerStart(int.Parse(txtTCP_Port.Text));
                        IsConnected = true; //Check this
                        ConnectByTCP = true;
                    }
                    else
                    {
                        try
                        {
                            IPAddress address = IPAddress.Parse(txtDevicIP.Text);//open connection to remote server
                            client = new TcpClient(txtDevicIP.Text, int.Parse(txtTCP_Port.Text));
                            IsConnected = true;
                            ConnectByTCP = true;
                        }
                        catch (Exception ex)
                        {
                            IsConnected = false;
                            MessageBox.Show(ex.Message);
                            ConnectByTCP = false;
                            return;
                        }
                    }
                    //open connection to remote client
                }

                if (IsConnected && ConnectByTCP && (!radTCPServer.Checked))
                {
                    tmrTCPClient.Interval = 100;
         
                    ListnearThread = new Thread(new ThreadStart(tcp_server_resp_get));
                    ListnearThread.Start();
                    //tmrTCPClient.Enabled = true;
                }

                if (IsConnected)
                {
                    int retry = 0;
                    //while (!DeviceInfoReceived)
                    {
                        byte[] TxFrame0 = CommandBuilder.BuildGetDeviceInfoFrame();
                        if (ConnectBySerialPort) { Sp.GetInstance().Send(TxFrame0); }
                        if (ConnectByTCP)
                        {
                            TCP_Send(TxFrame0);
                        }
                        Thread.Sleep(30);
                        //while (!DeviceInfoReceived) {; }
                            retry++;
                        //if(retry> 5) { break; }
                    }

                   //while (!DeviceRFRegionReceived)
                    {
                        byte[] TxFrame1 = CommandBuilder.BuildGetRFRegionFrame();
                        if (ConnectBySerialPort) { Sp.GetInstance().Send(TxFrame1); }
                        if (ConnectByTCP)
                        {
                            TCP_Send(TxFrame1);
                        }
                        Thread.Sleep(30);
                    }

                    //while (!DeviceRFModeReceived)
                    {
                        byte[] TxFrame2 = CommandBuilder.BuildGetRFModeFrame();
                        if (ConnectBySerialPort) { Sp.GetInstance().Send(TxFrame2); }
                        if (ConnectByTCP)
                        {
                            TCP_Send(TxFrame2);
                        }
                        Thread.Sleep(30);
                    }

                    //while (!DeviceRfPowerReceived)
                    {
                        byte[] TxFrame3 = CommandBuilder.BuildGetRFPowerFrame();
                        if (ConnectBySerialPort) { Sp.GetInstance().Send(TxFrame3); }
                        if (ConnectByTCP)
                        {
                            TCP_Send(TxFrame3);
                        }
                      Thread.Sleep(30);
                    }

                    byte[] TxFrame4 = CommandBuilder.BuildGetInventoryQFrame();
                    if (ConnectBySerialPort) { Sp.GetInstance().Send(TxFrame4); }
                    if (ConnectByTCP)
                    {
                        TCP_Send(TxFrame4);
                    }
                    Thread.Sleep(20);

                    byte[] TxFrame5 = CommandBuilder.BuildGetInventorySessionFrame();
                    if (ConnectBySerialPort) { Sp.GetInstance().Send(TxFrame5); }
                    if (ConnectByTCP)
                    {
                        TCP_Send(TxFrame5);
                    }
                    Thread.Sleep(20);

                    byte[] TxFrame6 = CommandBuilder.BuildGetInventoryTargetFrame();
                    if (ConnectBySerialPort) { Sp.GetInstance().Send(TxFrame6); }
                    if (ConnectByTCP)
                    {
                        TCP_Send(TxFrame6);
                    }
                    Thread.Sleep(20);

                    byte[] TxFrame7 = CommandBuilder.BuildGetWorkingModeFrame();
                    if (ConnectBySerialPort) { Sp.GetInstance().Send(TxFrame7); }
                    if (ConnectByTCP)
                    {
                        TCP_Send(TxFrame7);
                    }
                    Thread.Sleep(20);
                }

                btnConnect.Tag = 1;
                btnConnect.Text = "Disconnect";
                InterfaceSelectionCtrl(false);
            }
            else
            {
                tmrEPCInventory.Stop();

                if (IsConnected)
                {
                    if (ConnectBySerialPort)
                    {
                        if (!CloseCOMPort())
                        {
                            MessageBox.Show("Serial Port Close Failed", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                    }
                    else
                    {
                        if (radTCPServer.Checked && !StartedFromOtherTab) { TCP_LocalServerStop(); }
                        else
                        {
                            ListnearThread.Abort();
                            client.Close();
                        }
                        //tmrTCPClient.Enabled = false;
                    }
                }
                btnConnect.Tag = 0;
                btnConnect.Text = "Connect";
                ConnectByTCP = false;
                InterfaceSelectionCtrl(true);
            }
        }

        public class ComboboxItem
        {
            public string Text { get; set; }
            //public object Value { get; set; }

            public override string ToString()
            {
                return Text;
            }
        }

        private void btnInventory_Stop()
        {
            tmrEPCInventory.Stop();
            tmrEPCInventory.Enabled = false;
            btnInventory.Tag = 0;
            btnInventory.Text = "Start Inventory";

            radEPCOnly.Enabled = true;
            radTIDOnly.Enabled = true;            
            radEPC_TID.Enabled = true;
            chkRSSI.Enabled = true;

            grpMemOps.Enabled = true;
            grpEPCSetProtect.Enabled = true;
            grpEPCWrite.Enabled = true;
        }

        private void btnInventory_Click(object sender, EventArgs e)
        {
            if (btnInventory.Tag.ToString() == "0")
            {
                if (!IsConnected) { return; }
                if (IsActiveMode())
                {
                    MessageBox.Show("Device is not set in the response mode!");
                    return;
                }

                string TimerInterval = cbxInterval.SelectedItem.ToString().Trim((new Char[] { ' ', 'm', 'S' }));
                //TimerInterval.Trim((new Char[] { ' ', 'm', 'S' }));
                int interval;
                if (!int.TryParse(TimerInterval, out interval)) { interval = 100; }

                tmrEPCInventory.Interval = interval;
                btnInventory.Tag = 1;
                btnInventory.Text = "Stop Inventory";

                if (radEPCOnly.Checked) { DataGridView_StyleChange(0, chkRSSI.Checked, false, false); }
                if (radTIDOnly.Checked) { DataGridView_StyleChange(1, chkRSSI.Checked, false, false); }
                if (radEPC_TID.Checked) { DataGridView_StyleChange(2, chkRSSI.Checked, false, false); }

                radEPCOnly.Enabled = false;
                radEPC_TID.Enabled = false;                
                radTIDOnly.Enabled = false;
                chkRSSI.Enabled = false;

                tmrEPCInventory.Enabled = true;

                grpEPCSetProtect.Enabled = false;
                grpMemOps.Enabled = false;
                grpEPCWrite.Enabled = false;

                InvRespOk = true;

                dgView.Rows.Clear();
                tmrEPCInventory.Start();
            }
            else
            {
                btnInventory_Stop();
            }
        }


        private bool SendInventoryCommand(byte ExtOption)
        {
            byte[] TxFrame;

            CommunicationOk = true;

            if (ExtOption != 0) { TxFrame = CommandBuilder.BuildExtInventoryFrame(ExtOption); }
            else { TxFrame = CommandBuilder.BuildInventoryFrame(); }

            Log("Inventory command:", TxFrame);

            if ((ConnectBySerialPort) && Sp.GetInstance().IsOpen()) { Sp.GetInstance().Send(TxFrame); }
            if (ConnectByTCP)
            {
                TCP_Send(TxFrame);
            }

            return (CommunicationOk);
        }

        private void tmrEPCInventory_Tick(object sender, EventArgs e)
        {
            byte ExtOption = 0;
            bool CommStatus;

            if(radEPC_TID.Checked)     { ExtOption = 0x08;  }
            if(radTIDOnly.Checked)     { ExtOption = 0x80;  }
            if(chkRSSI.Checked)        { ExtOption |= 0x04; }

            tmrEPCInventory.Stop();

            CommStatus = SendInventoryCommand(ExtOption);

            InvRespOk = false;

            if (CommStatus)
            {
                tmrEPCInventory.Start();
            }
            else
            {
                btnInventory_Stop();
            }
        }

        private void button13_Click(object sender, EventArgs e)
        {
            dgView.Rows.Clear();
            RecordCount = 0;
            tbUIDCont.Text = "";
        }

        private void btnQuery_Click(object sender, EventArgs e)
        {
            if (IsActiveMode())
            {
                MessageBox.Show("Device is not set in the response mode!");
                return;
            }

            if (btnInventory.Tag.ToString() == "0")
            {
                IsSingleQuery = true;
                byte ExtOption = 0;

                if (radEPC_TID.Checked) { ExtOption = 0x08; }
                if (radTIDOnly.Checked) { ExtOption = 0x80; }
                if (chkRSSI.Checked)    { ExtOption |= 0x04; }
                SendInventoryCommand(ExtOption);

                //dgView.Rows.Clear();
                cbxUIDOps.Items.Clear();
            }
        }

        private void btnBlockRead_Click(object sender, EventArgs e)
        {
            byte EPCLength;
            byte[] TagEPC;
            byte[] AccessPW;
            byte[] BlockAddress;
            byte BankAddress = 1;

            txtBlockData.Text = "";

            if (IsActiveMode())
            {
                MessageBox.Show("Device is not set in the response mode!");
                return;
            }

            if (radReservedBank.Checked) { BankAddress = 0; }
            else if (radEPCBank.Checked) { BankAddress = 1; }
            else if (radTIDBank.Checked) { BankAddress = 2; }
            else if (radUserBank.Checked) { BankAddress = 3; }

            UInt16 TotalBlocks;
            byte WordCount;
            if (cbxUIDOps.SelectedIndex >= 0)
            {
                string TagID = cbxUIDOps.SelectedItem.ToString();
                TagEPC = Helpers.StringToHexArray(TagID);
                EPCLength = (byte)TagEPC.Length;
                AccessPW = Helpers.StringToHexArray(txtAccessPwdOps.Text);
                BlockAddress = Helpers.StringToHexArray(txtWordAddress.Text);

                if (
                    UInt16.TryParse(txtTotalWords.Text, out TotalBlocks)
                    && (AccessPW != null)
                    && (AccessPW.Length == 4)
                    && (BlockAddress != null)
                    && (BlockAddress.Length == 2)
                   )
                {
                    WordCount = (byte)TotalBlocks;
                    byte[] TxFrame = CommandBuilder.BuildReadBlockFrame(EPCLength, TagEPC, AccessPW, BankAddress, BlockAddress, WordCount);

                    Log("EPC C1G2 Block read", TxFrame);
                    if (ConnectBySerialPort) { Sp.GetInstance().Send(TxFrame); }
                    if (ConnectByTCP)
                    {
                        TCP_Send(TxFrame);
                    }
                }

            }
        }

        private void btnBlockWrite_Click(object sender, EventArgs e)
        {
            byte EPCLength;
            byte[] TagEPC;
            byte[] AccessPW;
            byte[] BlockAddress;
            byte[] Data;
            byte BankAddress = 1;
            UInt16 TotalBlocks;
            byte WordCount;

            if (IsActiveMode())
            {
                MessageBox.Show("Device is not set in the response mode!");
                return;
            }

            if (radReservedBank.Checked) { BankAddress = 0; }
            else if (radEPCBank.Checked) { BankAddress = 1; }
            else if (radTIDBank.Checked) { BankAddress = 2; }
            else if (radUserBank.Checked) { BankAddress = 3; }

            if (cbxUIDOps.SelectedIndex >= 0)
            {
                string TagID = cbxUIDOps.SelectedItem.ToString();
                TagEPC = Helpers.StringToHexArray(TagID);
                EPCLength = (byte)TagEPC.Length;
                AccessPW = Helpers.StringToHexArray(txtAccessPwdOps.Text);
                BlockAddress = Helpers.StringToHexArray(txtWordAddress.Text);
                Data = Helpers.StringToHexArray(txtBlockData.Text);
                if (
                    UInt16.TryParse(txtTotalWords.Text, out TotalBlocks)
                    && (AccessPW != null)
                    && (AccessPW.Length == 4)
                    && (BlockAddress != null)
                    && (BlockAddress.Length == 2)
                    && (Data != null)
                   )
                {
                    WordCount = (byte)TotalBlocks;
                    byte[] TxFrame = CommandBuilder.BuildWriteBlockFrame(EPCLength, TagEPC, AccessPW, BankAddress, BlockAddress, WordCount, Data);

                    Log("EPC C1G2 Block write", TxFrame);
                    if (ConnectBySerialPort) { Sp.GetInstance().Send(TxFrame); }
                    if (ConnectByTCP)
                    {
                        TCP_Send(TxFrame);
                    }
                }

            }
        }

        private void btnBlockErase_Click(object sender, EventArgs e)
        {
            byte EPCLength;
            byte[] TagEPC;
            byte[] AccessPW;
            byte[] BlockAddress;
            byte BankAddress = 1;
            UInt16 TotalBlocks;
            byte WordCount;

            if (IsActiveMode())
            {
                MessageBox.Show("Device is not set in the response mode!");
                return;
            }

            if (radReservedBank.Checked) { BankAddress = 0; }
            else if (radEPCBank.Checked) { BankAddress = 1; }
            else if (radTIDBank.Checked) { BankAddress = 2; }
            else if (radUserBank.Checked) { BankAddress = 3; }

            if (cbxUIDOps.SelectedIndex >= 0)
            {
                string TagID = cbxUIDOps.SelectedItem.ToString();
                TagEPC = Helpers.StringToHexArray(TagID);
                AccessPW = Helpers.StringToHexArray(txtAccessPwdOps.Text);
                BlockAddress = Helpers.StringToHexArray(txtWordAddress.Text);
                if (
                    UInt16.TryParse(txtTotalWords.Text, out TotalBlocks)
                    && (TagEPC != null)
                    && (AccessPW != null)
                    && (AccessPW.Length == 4)
                    && (BlockAddress != null)
                    && (BlockAddress.Length == 2)
                   )
                {
                    EPCLength = (byte)TagEPC.Length;
                    WordCount = (byte)TotalBlocks;
                    byte[] TxFrame = CommandBuilder.BuildEraseBlockFrame(EPCLength, TagEPC, AccessPW, BankAddress, BlockAddress, WordCount);

                    Log("EPC C1G2 Block erase", TxFrame);
                    if (ConnectBySerialPort) { Sp.GetInstance().Send(TxFrame); }
                    if (ConnectByTCP)
                    {
                        TCP_Send(TxFrame);
                    }
                }

            }
        }

        private void btnWriteEPC_Click(object sender, EventArgs e)
        {
            byte[] NewEPC;
            byte EPCLength;
            byte[] AccessPW;
            NewEPC = Helpers.StringToHexArray(txtNewEPC.Text);

            AccessPW = Helpers.StringToHexArray(txtAccessPwEPC.Text);

            if (
                (NewEPC != null)
                && (AccessPW != null)
                && (AccessPW.Length == 4)
              )
            {
                EPCLength = (byte)NewEPC.Length;
                byte[] TxFrame = CommandBuilder.BuildWriteEPCFrame(EPCLength, NewEPC, AccessPW);

                Log("EPC C1G2 Write new EPC ID", TxFrame);
                if (ConnectBySerialPort) { Sp.GetInstance().Send(TxFrame); }
                if (ConnectByTCP)
                {
                    TCP_Send(TxFrame);
                }
            }
        }

        private void btnGetRegion_Click(object sender, EventArgs e)
        {
            byte[] TxFrame = CommandBuilder.BuildGetRFRegionFrame();

            Log("Get RF region", TxFrame);
            if (ConnectBySerialPort) { Sp.GetInstance().Send(TxFrame); }
            if (ConnectByTCP)
            {
                TCP_Send(TxFrame);
            }
        }

        private void btnSetRegion_Click(object sender, EventArgs e)
        {
            if (cbxRegion.SelectedIndex < 0) { return; }

            byte RFRegion;
            RFRegion = (byte)cbxRegion.SelectedIndex;

            if ((cbxMinFreq.SelectedIndex >= 0) && (cbxMaxFreq.SelectedIndex >= 0))
            {
                byte IdxFreqMin = 0;
                byte IdxFreqMax = 0;

                IdxFreqMin = (byte)cbxMinFreq.SelectedIndex;
                IdxFreqMax = (byte)cbxMaxFreq.SelectedIndex;

                if (IdxFreqMax >= IdxFreqMin)
                {
                    byte[] TxFrame = CommandBuilder.BuildSetRFRegionFrame(RFRegion, IdxFreqMin, IdxFreqMax);

                    Log("Set RF region", TxFrame);
                    if (ConnectBySerialPort) { Sp.GetInstance().Send(TxFrame); }
                    if (ConnectByTCP)
                    {
                        TCP_Send(TxFrame);
                    }
                }
                else { MessageBox.Show("Invalid frequency index configuration!"); }
            }

        }

        private void btnGetRfMode_Click(object sender, EventArgs e)
        {
            byte[] TxFrame = CommandBuilder.BuildGetRFModeFrame();

            Log("Get RF mode", TxFrame);
            if (ConnectBySerialPort) { Sp.GetInstance().Send(TxFrame); }
            if (ConnectByTCP)
            {
                TCP_Send(TxFrame);
            }
        }

        ushort GetSelectedRFMode()
        {
            ushort RFMode = 13;

            ushort[] RfMode =   {
                                  1,3,5,7,11,
                                  12,13,15,102,
                                  123,124,125,141,
                                  146,147,148,185,
                                  202,222,223,241,
                                  244,285,302,323,
                                  324,325,342,343,
                                  344,103,345,120,
                                  382
                                };

            if ((cbxRFMode.SelectedIndex >= 0) && (cbxRFMode.SelectedIndex < RfMode.Length))
            {
                RFMode = RfMode[cbxRFMode.SelectedIndex];
            }

            return RFMode;
        }

        private void btnSetRfmode_Click(object sender, EventArgs e)
        {
            ushort RFMode = GetSelectedRFMode();

            byte[] TxFrame = CommandBuilder.BuildSetRFModeFrame(RFMode);

            Log("Set RF mode", TxFrame);
            if (ConnectBySerialPort) { Sp.GetInstance().Send(TxFrame); }
            if (ConnectByTCP)
            {
                TCP_Send(TxFrame);
            }
        }

        private void btnGetRfPower_Click(object sender, EventArgs e)
        {
            byte[] TxFrame = CommandBuilder.BuildGetRFPowerFrame();

            Log("Get RF power", TxFrame);
            if (ConnectBySerialPort) { Sp.GetInstance().Send(TxFrame); }
            if (ConnectByTCP)
            {
                TCP_Send(TxFrame);
            }
        }

        private void btnSetRfPower_Click(object sender, EventArgs e)
        {
            ushort RFPower = 2500;

            if (!ushort.TryParse(tbRFPower.Text, out RFPower))
            {
                MessageBox.Show("Invalid RF power value!");
                return;
            }

            if(RFPower > 3100)
            {
                DialogResult result = MessageBox.Show("Using the RFID reader on higher power for prolonged time may generate too much heat. Do you want to continue?", "RF Power",MessageBoxButtons.YesNoCancel);
                if (result != DialogResult.Yes) { return; }
            }

            byte[] TxFrame = CommandBuilder.BuildSetRFPowerFrame(RFPower);

            Log("Set RF power", TxFrame);
            if (ConnectBySerialPort) { Sp.GetInstance().Send(TxFrame); }
            if (ConnectByTCP)
            {
                TCP_Send(TxFrame);
            }

            //TextBox_Update(tbRFPower);
        }

        private void tbRFPower_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (((e.KeyChar < '0') || (e.KeyChar > '9')) && (e.KeyChar != 0x08))
            { e.Handled = true; }


        }

        private void btnGetQValue_Click(object sender, EventArgs e)
        {
            byte[] TxFrame = CommandBuilder.BuildGetInventoryQFrame();
            if (ConnectBySerialPort) { Sp.GetInstance().Send(TxFrame); }
            if (ConnectByTCP)
            {
                TCP_Send(TxFrame);
            }
        }

        private void btnSetQValue_Click(object sender, EventArgs e)
        {
            if (cbxQValue.SelectedIndex < 0) { return; }

            string InvQ = cbxQValue.SelectedItem.ToString();
            byte QValue = Convert.ToByte(InvQ);

            byte[] TxFrame = CommandBuilder.BuildSetInventoryQFrame(QValue);
            if (ConnectBySerialPort) { Sp.GetInstance().Send(TxFrame); }
            if (ConnectByTCP)
            {
                TCP_Send(TxFrame);
            }
        }

        private void btnGetSession_Click(object sender, EventArgs e)
        {
            byte[] TxFrame = CommandBuilder.BuildGetInventorySessionFrame();
            if (ConnectBySerialPort) { Sp.GetInstance().Send(TxFrame); }
            if (ConnectByTCP)
            {
                TCP_Send(TxFrame);
            }
        }

        private void btnSetSession_Click(object sender, EventArgs e)
        {
            if (cbxSession.SelectedIndex < 0) { return; }

            string InvS = cbxSession.SelectedItem.ToString();
            byte SessionValue = Convert.ToByte(InvS);

            byte[] TxFrame = CommandBuilder.BuildSetInventorySessionFrame(SessionValue);
            if (ConnectBySerialPort) { Sp.GetInstance().Send(TxFrame); }
            if (ConnectByTCP)
            {
                TCP_Send(TxFrame);
            }
        }

        private void radKillPwd_CheckedChanged(object sender, EventArgs e)
        {
            SetProtectUpdateDisplayOption();
        }

        private void radAdccessPwd_CheckedChanged(object sender, EventArgs e)
        {
            SetProtectUpdateDisplayOption();
        }

        private void radBankEPC_CheckedChanged(object sender, EventArgs e)
        {
            SetProtectUpdateDisplayOption();
        }

        private void radBankTID_CheckedChanged(object sender, EventArgs e)
        {
            SetProtectUpdateDisplayOption();
        }

        private void radBankUser_CheckedChanged(object sender, EventArgs e)
        {
            SetProtectUpdateDisplayOption();
        }

        private void btnSetProtect_Click(object sender, EventArgs e)
        {
            byte Target;
            byte Action = 1;
            byte EPCLength;
            byte[] TagEPC;
            byte[] AccessPW;

            if (cbxUIDOps.SelectedIndex < 0) { return; }

            if (IsActiveMode())
            {
                MessageBox.Show("Device is not set in the response mode!");
                return;
            }

            if (radKillPwd.Checked) { Target = 5; }
            else if (radAdccessPwd.Checked) { Target = 4; }
            else if (radBankEPC.Checked) { Target = 3; }
            else if (radBankTID.Checked) { Target = 2; }
            else { Target = 1; }

            string TagID = cbxUIDOps.SelectedItem.ToString();
            TagEPC = Helpers.StringToHexArray(TagID);
            EPCLength = (byte)TagEPC.Length;
            AccessPW = Helpers.StringToHexArray(txtSetProtectPw.Text);


            if ((cbxSetProtect.SelectedIndex >= 0) && (cbxSetProtect.SelectedIndex < 4))
            {
                Action = (byte)(cbxSetProtect.SelectedIndex + 1);
            }

            if ((AccessPW != null) && (AccessPW.Length == 4))
            {
                byte[] TxFrame = CommandBuilder.BuildSetProtectFrame(EPCLength, TagEPC, AccessPW, Target, Action);

                Log("EPC C1G2 Password config.", TxFrame);
                if (ConnectBySerialPort) { Sp.GetInstance().Send(TxFrame); }
                if (ConnectByTCP)
                {
                    TCP_Send(TxFrame);
                }
            }
        }

        private void cbxRegion_SelectedIndexChanged(object sender, EventArgs e)
        {
            string Region = cbxRegion.GetItemText(cbxRegion.SelectedItem);
            FrequencyTableUpdate(Region);
        }

        private void label16_Click(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnGetWorkingMode_Click(object sender, EventArgs e)
        {
            byte[] TxFrame = CommandBuilder.BuildGetWorkingModeFrame();

            Log("Get working mode", TxFrame);
            if (ConnectBySerialPort) { Sp.GetInstance().Send(TxFrame); }
            if (ConnectByTCP)
            {
                TCP_Send(TxFrame);
            }
        }

        private void btnSetWorkingMode_Click(object sender, EventArgs e)
        {
            byte NewWorkingMode;

            if ((cbxDeviceWorkingMode.SelectedIndex >= 0) && (cbxDeviceWorkingMode.SelectedIndex < 4))
            {
                NewWorkingMode = (byte)cbxDeviceWorkingMode.SelectedIndex;
            }
            else
            {
                return;
            }

            byte[] TxFrame = CommandBuilder.BuildSetWorkingModeFrame(NewWorkingMode);

            if((CurrentWorkingMode > 0) && (NewWorkingMode> 0))
            {
                bool Ask = false;

                if((CurrentWorkingMode == 2) && (NewWorkingMode == 3))
                {
                    Ask = true;
                }
                if ((CurrentWorkingMode == 3) && (NewWorkingMode == 2))
                {
                    Ask = true;
                }

                if(Ask)
                {
                    DialogResult dialogResult = MessageBox.Show("Working mode change will erase the previously logged records!", "Sure?", MessageBoxButtons.YesNo);
                    if (dialogResult == DialogResult.No) 
                    {
                        cbxDeviceWorkingMode.SelectedIndex = CurrentWorkingMode;
                        return; 
                    }
                }
            }

            Log("Set working mode", TxFrame);
            if (ConnectBySerialPort) { Sp.GetInstance().Send(TxFrame); }
            if (ConnectByTCP)
            {
                TCP_Send(TxFrame);
            }
        }

        private void tabPage2_Click(object sender, EventArgs e)
        {

        }

        private void btnRtbClear_Click(object sender, EventArgs e)
        {
            rtbLog.Clear();
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }



        private void tabCtrl_Click(object sender, EventArgs e)
        {
            this.Refresh();
        }

  


        private void btnBaudrateSet_Click(object sender, EventArgs e)
        {
            byte BaudrateIndex;

            BaudrateIndex = (byte)cbxUSARTBaudrate.SelectedIndex;
            if (BaudrateIndex > 10) { Log("Baudrate not supported"); return; }
            byte[] TxFrame = CommandBuilder.BuildSetUsartBaudrate(BaudrateIndex);

            Log("Set USART Baudrete", TxFrame);
            if (ConnectBySerialPort) { Sp.GetInstance().Send(TxFrame); }
            if (ConnectByTCP)
            {
                TCP_Send(TxFrame);
            }
        }

        private void btnSetInvCfg_Click(object sender, EventArgs e)
        {
            byte cfg0 = 0;
            byte cfg1 = 0;
            byte length = 2;
            byte[] RawCmdStrem = new byte[length];
            int index = length;

            if (chkEPCMask.Checked)
            {
                cfg0 |= 0x01; //fill the epc mask

                byte[] EPC_Mask;
                EPC_Mask = Helpers.StringToHexArray(txtEPCMask2.Text);//fill actual mask
                if (EPC_Mask.Length > 12) { MessageBox.Show("Mask length exceeds the maximum limit!"); return; }

                length += Convert.ToByte(EPC_Mask.Length + 1);//fill mask length
                Array.Resize(ref RawCmdStrem, length);
                RawCmdStrem[index++] = Convert.ToByte(EPC_Mask.Length);
                Array.Copy(EPC_Mask, 0, RawCmdStrem, index, EPC_Mask.Length);
                index += EPC_Mask.Length;
            }

            if (chkAccessPwd.Checked)
            {
                cfg0 |= 0x02; //

                byte[] AccessPW;
                AccessPW = Helpers.StringToHexArray(txtAccessPwd2.Text);//fill access pwd
                if (AccessPW.Length != 4) { MessageBox.Show("Password setting is invalid!"); return; }
                length += 4;
                Array.Resize(ref RawCmdStrem, length);
                Array.Copy(AccessPW, 0, RawCmdStrem, index, AccessPW.Length);
                index += 4;
            }

            if (chkReportRSSI.Checked) { cfg0 |= 0x04; }
            if (chkReportTID.Checked) { cfg0 |= 0x08; }

            if (chkReportUserMem.Checked)
            {
                cfg0 |= 0x10;

                byte[] BlockAddress;
                byte WordCount = 0;

                BlockAddress = Helpers.StringToHexArray(txtUserMemBlockAddress.Text);//fill block address

                UInt16 TotalBlocks;
                if (UInt16.TryParse(txtUserMemBlockCount.Text, out TotalBlocks)) { WordCount = (byte)TotalBlocks; }
                else { MessageBox.Show("Invalid word count!"); return; }

                if ((WordCount == 0) || (WordCount > 64)) { MessageBox.Show("Invalid word count limit!"); return; }

                length += 3;
                Array.Resize(ref RawCmdStrem, length);
                Array.Copy(BlockAddress, 0, RawCmdStrem, index, BlockAddress.Length);
                index += 2;
                RawCmdStrem[index++] = WordCount;
            }

            if (chkComplaintTags.Checked) { cfg0 |= 0x20; }

            if (chkIOPassEnable.Checked)
            {
                cfg0 |= 0x40;

                byte[] IOCfg = new byte[4];
                UInt16 WaitTime;

                if (!ushort.TryParse(txtIO1_DwellTime.Text, out WaitTime))
                {
                    MessageBox.Show("Invalid dwell value!");
                    WaitTime = 10;
                }

                //IOCfg[0] = (byte)(cbxIO1.SelectedIndex + 1);

                string s = cbxIO1.SelectedItem.ToString();
                IOCfg[0] = Convert.ToByte(s);

                if (cbxIO1State.SelectedIndex == 0) { IOCfg[1] = 1; }
                else { IOCfg[1] = 0; }

                IOCfg[3] = (byte)(WaitTime & 0x00FF);
                IOCfg[2] = (byte)((WaitTime & 0xFF00) >> 8);

                length += 4;
                Array.Resize(ref RawCmdStrem, length);
                Array.Copy(IOCfg, 0, RawCmdStrem, index, IOCfg.Length);
                index += 4;
            }

            if (chkIOFailEnable.Checked)
            {
                cfg0 |= 0x80;

                byte[] IOCfg = new byte[4];
                UInt16 WaitTime;

                if (!ushort.TryParse(txtIO2_DwellTime.Text, out WaitTime))
                {
                    MessageBox.Show("Invalid dwell value!");
                    WaitTime = 10;
                }

                //IOCfg[0] = (byte)(cbxIO2.SelectedIndex + 1);

                string s = cbxIO2.SelectedItem.ToString();
                IOCfg[0] = Convert.ToByte(s);

                if (cbxIO2State.SelectedIndex == 0) { IOCfg[1] = 1; }
                else { IOCfg[1] = 0; }

                IOCfg[3] = (byte)(WaitTime & 0x00FF);
                IOCfg[2] = (byte)((WaitTime & 0xFF00) >> 8);

                length += 4;
                Array.Resize(ref RawCmdStrem, length);
                Array.Copy(IOCfg, 0, RawCmdStrem, index, IOCfg.Length);
                index += 4;
            }

            if (chkInvTriggerEnable.Checked)
            {
                cfg1 |= 0x01;

                byte[] IOCfg = new byte[4];
                UInt16 WaitTime;

                if (!ushort.TryParse(txtIO3_DwellTime.Text, out WaitTime))
                {
                    MessageBox.Show("Invalid dwell value!");
                    WaitTime = 10;
                }

                //IOCfg[0] = (byte)(cbxIO3.SelectedIndex + 1);
                IOCfg[0] = 4;
                if (cbxIO3State.SelectedIndex == 0) { IOCfg[1] = 1; }
                else { IOCfg[1] = 0; }

                IOCfg[3] = (byte)(WaitTime & 0x00FF);
                IOCfg[2] = (byte)((WaitTime & 0xFF00) >> 8);

                length += 4;
                Array.Resize(ref RawCmdStrem, length);
                Array.Copy(IOCfg, 0, RawCmdStrem, index, IOCfg.Length);
                index += 4;
            }

            if (chkEPCPersistance.Checked)
            {
                cfg1 |= 0x02;
                byte[] time = new byte[2];
                //add peristance time interval here
                UInt16 WaitTime;

                if (!ushort.TryParse(txtTagPersistenceTime.Text, out WaitTime))
                {
                    MessageBox.Show("Invalid Persistence value!");
                    WaitTime = 10;
                }

                time[0] = (byte)(WaitTime >> 8);
                time[1] = (byte)(WaitTime);

                length += 2;
                Array.Resize(ref RawCmdStrem, length);
                Array.Copy(time, 0, RawCmdStrem, index, time.Length);
                index += 2;
            }

            if(chkPersistanceAutoReset.Checked)
            {
                cfg1 |= 0x10;
            }

            if (chkIncludeAntennaID.Checked)
            {
                cfg1 |= 0x04;
            }

            if (chkHeartbeatEn.Checked)
            {
                cfg1 |= 0x08;
                ushort duration = 0;
                byte[] bytes = new byte[2];

                if (!ushort.TryParse(txtHeartbeat2.Text, out duration))
                {
                    MessageBox.Show("Invalid beep duration value!");
                    return;
                }

                bytes[0] = (byte)(duration >> 8);
                bytes[1] = (byte)(duration);

                length += 2;
                Array.Resize(ref RawCmdStrem, length);
                Array.Copy(bytes, 0, RawCmdStrem, index, bytes.Length);
                index += 2;
            }
            if(chkBufferedReadMode.Checked) { cfg1 |= 0x20; }
            if (chkReaderID.Checked) { cfg1 |= 0x40; }
            if (chkInvOpsEnable.Checked) { cfg1 |= 0x80; }

            RawCmdStrem[0] = cfg0;
            RawCmdStrem[1] = cfg1;

            byte[] TxFrame = CommandBuilder.BuildExtendedInventoryFrame(RawCmdStrem);

            Log("Setup ans start Parking mode app.", TxFrame);
            if (ConnectBySerialPort) { Sp.GetInstance().Send(TxFrame); }
            if (ConnectByTCP)
            {
                TCP_Send(TxFrame);
            }

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void btnGetTCPConf_Click(object sender, EventArgs e)
        {
            byte flags = 0x7F;

            /*if (chkDeviceIP.Checked)   { flags |= 0x01; }
            if (chkGetWayIP.Checked)   { flags |= 0x02; }
            if (chkNetMask.Checked)    { flags |= 0x04; }
            if (chkServerPort.Checked) { flags |= 0x08; }
            if (chkClientIP.Checked)   { flags |= 0x10; }
            if (chkClientPort.Checked) { flags |= 0x20; }*/

            byte[] TxFrame = CommandBuilder.BuildGetTCPParametersFrame(flags);

            Log("Get TCP/IP parameters", TxFrame);
            if (ConnectBySerialPort) { Sp.GetInstance().Send(TxFrame); }
            if (ConnectByTCP)
            {
                TCP_Send(TxFrame);
            }
        }

        private void ConfigureForTCP()
        {
            byte cfg0 = 0;
            byte length = 2;
            byte[] RawCmdStrem = new byte[length];
            int index = length;


        if (chkDeviceIP.Checked)
        {
            cfg0 |= 0x01;

            if (ValidateIPv4(txtDeviceIP.Text))
            {
                IPAddress address = IPAddress.Parse(txtDeviceIP.Text);
                byte[] ip_address = address.GetAddressBytes();
                length += 4;
                Array.Resize(ref RawCmdStrem, length);
                Array.Copy(ip_address, 0, RawCmdStrem, index, ip_address.Length);
                index += 4;
            }
            else { MessageBox.Show("Invalid device IP address."); return; }
        }

        if (chkGetWayIP.Checked)
        {
            cfg0 |= 0x02;

            if (ValidateIPv4(txtDeviceGW.Text))
            {
                IPAddress address = IPAddress.Parse(txtDeviceGW.Text);
                byte[] ip_address = address.GetAddressBytes();
                length += 4;
                Array.Resize(ref RawCmdStrem, length);
                Array.Copy(ip_address, 0, RawCmdStrem, index, ip_address.Length);
                index += 4;
            }
            else { MessageBox.Show("Invalid device IP address."); return; }

        }

        if (chkNetMask.Checked)
        {
            cfg0 |= 0x04;

            if (ValidateIPv4(txtDeviceNetMask.Text))
            {
                IPAddress address = IPAddress.Parse(txtDeviceNetMask.Text);
                byte[] ip_address = address.GetAddressBytes();
                length += 4;
                Array.Resize(ref RawCmdStrem, length);
                Array.Copy(ip_address, 0, RawCmdStrem, index, ip_address.Length);
                index += 4;
            }
            else { MessageBox.Show("Invalid device IP address."); return; }
        }

        if (chkServerPort.Checked)
        {
            cfg0 |= 0x08;

            ushort port_number = 0;

            if (!ushort.TryParse(txtDeviceServerPort.Text, out port_number))
            {
                MessageBox.Show("Invalid port value!");
                return;
            }

            byte[] bytes = new byte[2];
            bytes[0] = (byte)(port_number >> 8);
            bytes[1] = (byte)(port_number);

            length += 2;
            Array.Resize(ref RawCmdStrem, length);
            Array.Copy(bytes, 0, RawCmdStrem, index, bytes.Length);
            index += 2;

        }

        if (chkClientIP.Checked)
        {
            cfg0 |= 0x10;

            if (ValidateIPv4(txtDeviceClietnIP.Text))
            {
                IPAddress address = IPAddress.Parse(txtDeviceClietnIP.Text);
                byte[] ip_address = address.GetAddressBytes();
                length += 4;
                Array.Resize(ref RawCmdStrem, length);
                Array.Copy(ip_address, 0, RawCmdStrem, index, ip_address.Length);
                index += 4;
            }
            else { MessageBox.Show("Invalid device IP address."); return; }
        }

        if (chkClientPort.Checked)
        {
            cfg0 |= 0x20;

            ushort port_number = 2500;

            if (!ushort.TryParse(txtDeviceClientPort.Text, out port_number))
            {
                MessageBox.Show("Invalid port value!");
                return;
            }

            byte[] bytes = new byte[2];
            bytes[0] = (byte)(port_number >> 8);
            bytes[1] = (byte)(port_number);

            length += 2;
            Array.Resize(ref RawCmdStrem, length);
            Array.Copy(bytes, 0, RawCmdStrem, index, bytes.Length);
            index += 2;
        }

        if (chkMACAddress.Checked)
        {
            cfg0 |= 0x40;
            byte[] mac_address = Helpers.StringToHexArray(txtMACAddress.Text);
            if (mac_address.Length != 6) { MessageBox.Show("MAC address length mismatch"); return; }

            length += 6;
            Array.Resize(ref RawCmdStrem, length);
            Array.Copy(mac_address, 0, RawCmdStrem, index, mac_address.Length);
            index += 6;
        }
            
            

            RawCmdStrem[0] = 0x02; //TCP config
            RawCmdStrem[1] = cfg0;

            byte[] TxFrame = CommandBuilder.BuildSetComunucationParametersFrame(RawCmdStrem);
            Log("Set TCP/IP parameters frame", TxFrame);
            if (ConnectBySerialPort) { Sp.GetInstance().Send(TxFrame); }
            if (ConnectByTCP)
            {
                //byte[] DummyFrame = new byte[512];
                //for(int i= 0; i<DummyFrame.Length; i++) { DummyFrame[i] = (byte)i; }
                TCP_Send(TxFrame);
            }
        }


        private void btnSetTCPConf_Click(object sender, EventArgs e)
        {
           ConfigureForTCP();            
        }

        private void ProcessSinglePacket(byte[] PacketBuff)
        {
            if ((PacketBuff.Length > 0) && (PacketBuff[0] == 0xBB))
            {
                byte length = PacketBuff[1];
                int PacketCRC = 0;
                int PacketCRC2 = 0;

                PacketCRC = PacketBuff[length + 2];
                PacketCRC <<= 8;
                PacketCRC |= PacketBuff[length + 3];

                PacketCRC2 = CRC16.Calc(PacketBuff, 2, length);

                if (PacketCRC2 == PacketCRC)
                {
                    byte[] resp = new byte[length];
                    Array.Copy(PacketBuff, 2, resp, 0, length);
                    PaketReceived(this, new ByteArrayArgs(resp));
                }
                else
                {
                    Console.WriteLine("TCP packet droped due to CRC error!");
                }
            }
        }


        private void TryProcessFullPacket(byte[] PacketBuff)
        {
            int sm_state = 0;
            int idx = 0;
            int ThisPacketLength = 0;

            int StartIndex = 0;
            int PacketCnt = 0;
            int BlockLen = 0;

            int len = PacketBuff.Length;
 
            //Console.WriteLine("Full packet length: " + len.ToString());
            //Console.WriteLine(BitConverter.ToString(PacketBuff).Replace("-", ""));
            while (len > 0)
            {
                if(idx >= len) { break;  }
                switch (sm_state)
                {
                    case 0:
                        if (PacketBuff[idx++] == 0xBB) { StartIndex = idx-1; sm_state++; ThisPacketLength = 0; BlockLen = 0; }
                        //idx++;
                        break;
                    case 1:
                        if ((PacketBuff[idx] > 0) && (PacketBuff[idx] < 253))
                        { sm_state++; ThisPacketLength = PacketBuff[idx]; BlockLen = ThisPacketLength + 3 + idx; }
                        else { sm_state = 0; }
                        idx++;
                        break;
                    case 2:
                        idx++;
                        if (idx == BlockLen)
                        {
                            byte[] RespPacket = new byte[ThisPacketLength + 4];
                            Array.Copy(PacketBuff, StartIndex, RespPacket, 0, RespPacket.Length);
                            PacketCnt++;
                            //Console.WriteLine("Seperated packet: " + PacketCnt.ToString());
                            //Console.WriteLine(BitConverter.ToString(RespPacket).Replace("-", ""));
                            ProcessSinglePacket(RespPacket);
                            sm_state = 0;
                            //Console.WriteLine("idx next = " + BlockLen.ToString());
                        }
                        /*if (idx > (4 + ThisPacketLength)) 
                        {
                            Console.WriteLine("Index phased out");
                        }*/
                        break;
                }   
            }
        }
        
        private void tcp_server_resp_get()
        {
            while (true)
            {
                try
                {
                    
                    //if(threadbusy) { Console.WriteLine("THREAD BUSY OVERLAP"); }
                    if (client.Available > 0)
                    {
                        NetworkStream stream = client.GetStream();
                        byte[] data = new byte[1000];
                        int len = stream.Read(data, 0, 1000);
                        byte[] PacketBuff = new byte[len];
                        Array.Copy(data, 0, PacketBuff, 0, len);
                        
                        TryProcessFullPacket(PacketBuff);
                        //threadbusy = false;
                    }
                }
                catch (Exception ex)
                {
                    //MessageBox.Show(ex.Message);
                }

            Thread.Sleep(10);
            }
        }

        private void tmrTCPClient_Tick(object sender, EventArgs e)
        {
            tmrTCPClient.Enabled = false;



            tmrTCPClient.Enabled = true;
        }

 

        private void btnGetInvCfg_Click(object sender, EventArgs e)
        {
            byte[] TxFrame = CommandBuilder.BuildGetExtendedInventoryParametersFrame();
            Log("Get extended inventory configuration", TxFrame);
            if (ConnectBySerialPort) { Sp.GetInstance().Send(TxFrame); }
            if (ConnectByTCP)
            {
                TCP_Send(TxFrame);
            }
        }

        private void chkIOFailEnable_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void label34_Click(object sender, EventArgs e)
        {

        }

        private void cbxIO3_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void txtIO3_DwellTime_TextChanged(object sender, EventArgs e)
        {

        }

        private void label39_Click(object sender, EventArgs e)
        {

        }

        private void label37_Click(object sender, EventArgs e)
        {

        }

        private void label36_Click(object sender, EventArgs e)
        {

        }

        private void cbxIO2State_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnBaudrateGet_Click(object sender, EventArgs e)
        {
            byte[] TxFrame = CommandBuilder.BuildGetUartParametersFrame();

            Log("Get UART parameters", TxFrame);
            if (ConnectBySerialPort) { Sp.GetInstance().Send(TxFrame); }
            if (ConnectByTCP)
            {
                TCP_Send(TxFrame);
            }
        }

        private void btnBuzzerControl_Click(object sender, EventArgs e)
        {
            byte enable = 0;

            if (chkBuzzerEnable.Checked) { enable = 1; }

            byte[] TxFrame = CommandBuilder.BuildBuzzerEnableFrame(enable);
            Log("Buzzer enable/disable control frame", TxFrame);
            if (ConnectBySerialPort) { Sp.GetInstance().Send(TxFrame); }
            if (ConnectByTCP)
            {
                TCP_Send(TxFrame);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ushort beep_duration = 0;

            if (!ushort.TryParse(txtBuzzerBeepDuration.Text, out beep_duration))
            {
                MessageBox.Show("Invalid beep duration value!");
                return;
            }

            byte[] TxFrame = CommandBuilder.BuildBuzzerBeepFrame(beep_duration);
            Log("Buzzer beep control frame", TxFrame);
            if (ConnectBySerialPort) { Sp.GetInstance().Send(TxFrame); }
            if (ConnectByTCP)
            {
                TCP_Send(TxFrame);
            }
        }

        private void tabCtrl_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label15_Click(object sender, EventArgs e)
        {

        }

        private void txtDeviceSerialNum_TextChanged(object sender, EventArgs e)
        {

        }



        private void btnFastAutoAccess_Click(object sender, EventArgs e)
        {
            byte[] TxFrame = CommandBuilder.BuildAutoAccessAPIType(0x00);
            Log("Fast access mode frame", TxFrame);
            if (ConnectBySerialPort) { Sp.GetInstance().Send(TxFrame); }
            if (ConnectByTCP)
            {
                TCP_Send(TxFrame);
            }
        }

        private void btnRegularAccessMode_Click(object sender, EventArgs e)
        {
            byte[] TxFrame = CommandBuilder.BuildAutoAccessAPIType(0xCC);
            Log("Regular access mode frame", TxFrame);
            if (ConnectBySerialPort) { Sp.GetInstance().Send(TxFrame); }
            if (ConnectByTCP)
            {
                TCP_Send(TxFrame);
            }
        }




        private void btnRFDiagnosisCtrl_Click(object sender, EventArgs e)
        {
            if (btnRFDiagnosisCtrl.Tag.ToString() == "0")
            {
                if (!IsConnected) { return; }
                if (cbxCurrentFreq.Items.Count <= 0) { return; }

                IsFirstAcq = true;
                tmrRFDiagnosis.Interval = 50;
                btnRFDiagnosisCtrl.Tag = 1;
                btnRFDiagnosisCtrl.Text = "Stop";
                tmrRFDiagnosis.Start();
            }
            else
            {
                tmrRFDiagnosis.Stop();
                btnRFDiagnosisCtrl.Tag = 0;
                btnRFDiagnosisCtrl.Text = "Start";
            }
        }

        private void tmrRFDiagnosis_Tick(object sender, EventArgs e)
        {
            bool Status;
            string sFreqKHz = cbxCurrentFreq.GetItemText(cbxCurrentFreq.SelectedItem);
            UInt32 FrequencyKHz = Convert.ToUInt32(sFreqKHz);


            byte[] TxFrame = CommandBuilder.Build_RF_LBT_Diagnosis_Frame(0x02, FrequencyKHz, 0);
            Log("RF diagnosis, check LBT frame", TxFrame);
            if (ConnectBySerialPort) 
            {                 
                if(Sp.GetInstance().Send(TxFrame) <= 0)
                {
                    tmrRFDiagnosis.Stop();
                    btnRFDiagnosisCtrl.Tag = 0;
                    btnRFDiagnosisCtrl.Text = "Start";
                }
            }
            if (ConnectByTCP)
            {
                Status = TCP_Send(TxFrame);
                if(!Status) 
                {
                    tmrRFDiagnosis.Stop();
                    btnRFDiagnosisCtrl.Tag = 0;
                    btnRFDiagnosisCtrl.Text = "Start";
                }
            }
        }

        private void btnHeartbeat_Click(object sender, EventArgs e)
        {
            ushort duration = 0;
            byte Type = 1;

            if (!ushort.TryParse(txtHeartbeat.Text, out duration))
            {
                MessageBox.Show("Invalid beep duration value!");
                return;
            }

            if(chkTCPClientCheck.Checked) { Type = 4; }

            byte[] TxFrame = CommandBuilder.BuildHeartbeatFrame(Type, duration);
            Log("Heartbeat setup frame", TxFrame);
            if (ConnectBySerialPort) { Sp.GetInstance().Send(TxFrame); }
            if (ConnectByTCP)
            {
                TCP_Send(TxFrame);
            }

        }

        private void btnDeviceRestart_Click(object sender, EventArgs e)
        {
            byte[] TxFrame = CommandBuilder.BuildDeviceRestartFrame();
            Log("Device restart frame", TxFrame);
            if (ConnectBySerialPort) { Sp.GetInstance().Send(TxFrame); }
            if (ConnectByTCP)
            {
                TCP_Send(TxFrame);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            byte[] TxFrame = CommandBuilder.BuildGetDeviceInfoFrame();
            if (ConnectBySerialPort) { Sp.GetInstance().Send(TxFrame); }
            if (ConnectByTCP)
            {
                TCP_Send(TxFrame);
            }
        }

        private void btnDeviceSearch_Click(object sender, EventArgs e)
        {
            dgDeviceList.Rows.Clear();

            try
            {
                Socket SockUDP = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
                IPEndPoint ipEndpt = new IPEndPoint(IPAddress.Broadcast, 30303);
                EndPoint Endpt = (EndPoint)ipEndpt;

                SockUDP.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.Broadcast, true);

                byte[] Message = new byte[1];
                Message[0] = 0xBB;

                SockUDP.SendTo(Message, ipEndpt);

                for (int i = 0; i < 255; i++)
                {
                    SockUDP.ReceiveTimeout = 1000;
                    int idx = 1;
                    byte[] RxBuf = new byte[1024];
                    byte[] DeviceSerialNum = new byte[4];
                    byte[] DeviceMac = new byte[6];
                    byte[] DeviceIP = new byte[4];
                    byte[] RemoteIP = new byte[4];
                    byte[] ServerPort = new byte[2];
                    byte[] ClientPort = new byte[2];

                    int RxBytes = SockUDP.ReceiveFrom(RxBuf, ref Endpt);
                    if (RxBytes == 23)
                    {
                        Array.Copy(RxBuf, idx, DeviceSerialNum, 0, 4);
                        if (!chkIDReverse.Checked) { Array.Reverse(DeviceSerialNum); }
                        idx += 4;
                        Array.Copy(RxBuf, idx, DeviceMac, 0, 6);
                        idx += 6;
                        Array.Copy(RxBuf, idx, DeviceIP, 0, 4);
                        idx += 4;
                        Array.Copy(RxBuf, idx, RemoteIP, 0, 4);
                        idx += 4;
                        Array.Copy(RxBuf, idx, ServerPort, 0, 2);
                        Array.Reverse(ServerPort);
                        idx += 2;
                        Array.Copy(RxBuf, idx, ClientPort, 0, 2);
                        Array.Reverse(ClientPort);


                        uint SerialNumber32 = BitConverter.ToUInt32(DeviceSerialNum, 0);
                         

                        string[] sArray = new string[7];
                        sArray[0] = (dgDeviceList.RowCount).ToString();
                        sArray[1] = SerialNumber32.ToString(); //BitConverter.ToString(DeviceSerialNum).Replace("-", "");
                        sArray[2] = BitConverter.ToString(DeviceMac).Replace("-", "");
                        sArray[3] = string.Join(".", DeviceIP.Select(b => b.ToString()));
                        sArray[4] = string.Join(".", RemoteIP.Select(b => b.ToString()));
                        sArray[5] = BitConverter.ToUInt16(ServerPort, 0).ToString();// BitConverter.ToString(ServerPort).Replace("-", "");
                        ushort myy = BitConverter.ToUInt16(ServerPort, 0);
                        sArray[6] = BitConverter.ToUInt16(ClientPort, 0).ToString();//BitConverter.ToString(ClientPort).Replace("-", "");

                        dgDeviceList.Rows.Add(sArray);
                    }
                }

                SockUDP.Close();
            }
            catch (Exception ex) { ex.ToString(); }
        }

        private void btnTagKill_Click(object sender, EventArgs e)
        {
            byte EPCLength;
            byte[] TagEPC;
            byte[] KillPw;

            if (IsActiveMode())
            {
                MessageBox.Show("Device is not set in the response mode!");
                return;
            }

            string TagID = cbxUIDOps.SelectedItem.ToString();
            TagEPC = Helpers.StringToHexArray(TagID);
            KillPw = Helpers.StringToHexArray(txtAccessPwdOps.Text);

            if ((TagEPC != null) && (KillPw != null) && (KillPw.Length == 4))
            {
                EPCLength = (byte)TagEPC.Length;

                byte[] TxFrame = CommandBuilder.BuildTagKillFrame(EPCLength, TagEPC, KillPw);

                Log("EPC C1G2 Tag Kill frame", TxFrame);
                if (ConnectBySerialPort) { Sp.GetInstance().Send(TxFrame); }
                if (ConnectByTCP)
                {
                    TCP_Send(TxFrame);
                }
            }
        }

        private void btnClearList_Click(object sender, EventArgs e)
        {

        }

        private void btnClear_Click(object sender, EventArgs e)
        {

        }

        private void btnStartStop_Click(object sender, EventArgs e)
        {

        }

        private void SetMask0_Click(object sender, EventArgs e)
        {
            byte[] EPC_Mask;
            EPC_Mask = Helpers.StringToHexArray(txtMask0.Text);//fill actual mask
            if ((EPC_Mask.Length == 0) || (EPC_Mask.Length > 12) || (EPC_Mask == null))
            {
                MessageBox.Show("Mask length error!");
                return;
            }

            byte[] TxFrame = CommandBuilder.BuildWriteEPCMaskFrame(0, EPC_Mask);
            Log("Write EPC mask No.0 frame", TxFrame);
            if (ConnectBySerialPort) { Sp.GetInstance().Send(TxFrame); }
            if (ConnectByTCP)
            {
                TCP_Send(TxFrame);
            }
        }

        private void SetMask1_Click(object sender, EventArgs e)
        {
            byte[] EPC_Mask;
            EPC_Mask = Helpers.StringToHexArray(txtMask1.Text);//fill actual mask
            if ((EPC_Mask.Length == 0) || (EPC_Mask.Length > 12) || (EPC_Mask == null))
            {
                MessageBox.Show("Mask length error!");
                return;
            }

            byte[] TxFrame = CommandBuilder.BuildWriteEPCMaskFrame(1, EPC_Mask);
            Log("Write EPC mask No.1 frame", TxFrame);
            if (ConnectBySerialPort) { Sp.GetInstance().Send(TxFrame); }
            if (ConnectByTCP)
            {
                TCP_Send(TxFrame);
            }
        }

        private void SetMask2_Click(object sender, EventArgs e)
        {
            byte[] EPC_Mask;
            EPC_Mask = Helpers.StringToHexArray(txtMask2.Text);//fill actual mask
            if ((EPC_Mask.Length == 0) || (EPC_Mask.Length > 12) || (EPC_Mask == null))
            {
                MessageBox.Show("Mask length error!");
                return;
            }

            byte[] TxFrame = CommandBuilder.BuildWriteEPCMaskFrame(2, EPC_Mask);
            Log("Write EPC mask No.2 frame", TxFrame);
            if (ConnectBySerialPort) { Sp.GetInstance().Send(TxFrame); }
            if (ConnectByTCP)
            {
                TCP_Send(TxFrame);
            }
        }

        private void SetMask3_Click(object sender, EventArgs e)
        {
            byte[] EPC_Mask;
            EPC_Mask = Helpers.StringToHexArray(txtMask3.Text);//fill actual mask
            if ((EPC_Mask.Length == 0) || (EPC_Mask.Length > 12) || (EPC_Mask == null))
            {
                MessageBox.Show("Mask length error!");
                return;
            }

            byte[] TxFrame = CommandBuilder.BuildWriteEPCMaskFrame(3, EPC_Mask);
            Log("Write EPC mask No.3 frame", TxFrame);
            if (ConnectBySerialPort) { Sp.GetInstance().Send(TxFrame); }
            if (ConnectByTCP)
            {
                TCP_Send(TxFrame);
            }
        }

        private void SetMask4_Click(object sender, EventArgs e)
        {
            byte[] EPC_Mask;
            EPC_Mask = Helpers.StringToHexArray(txtMask4.Text);//fill actual mask
            if ((EPC_Mask.Length == 0) || (EPC_Mask.Length > 12) || (EPC_Mask == null))
            {
                MessageBox.Show("Mask length error!");
                return;
            }

            byte[] TxFrame = CommandBuilder.BuildWriteEPCMaskFrame(4, EPC_Mask);
            Log("Write EPC mask No.4 frame", TxFrame);
            if (ConnectBySerialPort) { Sp.GetInstance().Send(TxFrame); }
            if (ConnectByTCP)
            {
                TCP_Send(TxFrame);
            }
        }

        private void SetMask5_Click(object sender, EventArgs e)
        {
            byte[] EPC_Mask;
            EPC_Mask = Helpers.StringToHexArray(txtMask5.Text);//fill actual mask
            if ((EPC_Mask.Length == 0) || (EPC_Mask.Length > 12) || (EPC_Mask == null))
            {
                MessageBox.Show("Mask length error!");
                return;
            }

            byte[] TxFrame = CommandBuilder.BuildWriteEPCMaskFrame(5, EPC_Mask);
            Log("Write EPC mask No.5 frame", TxFrame);
            if (ConnectBySerialPort) { Sp.GetInstance().Send(TxFrame); }
            if (ConnectByTCP)
            {
                TCP_Send(TxFrame);
            }
        }

        private void SetMask6_Click(object sender, EventArgs e)
        {
            byte[] EPC_Mask;
            EPC_Mask = Helpers.StringToHexArray(txtMask6.Text);//fill actual mask
            if ((EPC_Mask.Length == 0) || (EPC_Mask.Length > 12) || (EPC_Mask == null))
            {
                MessageBox.Show("Mask length error!");
                return;
            }

            byte[] TxFrame = CommandBuilder.BuildWriteEPCMaskFrame(6, EPC_Mask);
            Log("Write EPC mask No.6 frame", TxFrame);
            if (ConnectBySerialPort) { Sp.GetInstance().Send(TxFrame); }
            if (ConnectByTCP)
            {
                TCP_Send(TxFrame);
            }
        }

        private void SetMask7_Click(object sender, EventArgs e)
        {
            byte[] EPC_Mask;
            EPC_Mask = Helpers.StringToHexArray(txtMask7.Text);//fill actual mask
            if ((EPC_Mask.Length == 0) || (EPC_Mask.Length > 12) || (EPC_Mask == null))
            {
                MessageBox.Show("Mask length error!");
                return;
            }

            byte[] TxFrame = CommandBuilder.BuildWriteEPCMaskFrame(7, EPC_Mask);
            Log("Write EPC mask No.7 frame", TxFrame);
            if (ConnectBySerialPort) { Sp.GetInstance().Send(TxFrame); }
            if (ConnectByTCP)
            {
                TCP_Send(TxFrame);
            }
        }

        private void SetMask8_Click(object sender, EventArgs e)
        {
            byte[] EPC_Mask;
            EPC_Mask = Helpers.StringToHexArray(txtMask8.Text);//fill actual mask
            if ((EPC_Mask.Length == 0) || (EPC_Mask.Length > 12) || (EPC_Mask == null))
            {
                MessageBox.Show("Mask length error!");
                return;
            }

            byte[] TxFrame = CommandBuilder.BuildWriteEPCMaskFrame(8, EPC_Mask);
            Log("Write EPC mask No.8 frame", TxFrame);
            if (ConnectBySerialPort) { Sp.GetInstance().Send(TxFrame); }
            if (ConnectByTCP)
            {
                TCP_Send(TxFrame);
            }
        }

        private void SetMask9_Click(object sender, EventArgs e)
        {
            byte[] EPC_Mask;
            EPC_Mask = Helpers.StringToHexArray(txtMask9.Text);//fill actual mask
            if ((EPC_Mask.Length == 0) || (EPC_Mask.Length > 12) || (EPC_Mask == null))
            {
                MessageBox.Show("Mask length error!");
                return;
            }

            byte[] TxFrame = CommandBuilder.BuildWriteEPCMaskFrame(9, EPC_Mask);
            Log("Write EPC mask No.9 frame", TxFrame);
            if (ConnectBySerialPort) { Sp.GetInstance().Send(TxFrame); }
            if (ConnectByTCP)
            {
                TCP_Send(TxFrame);
            }
        }

        private void GetMask0_Click(object sender, EventArgs e)
        {
            byte[] TxFrame = CommandBuilder.BuildReadEPCMaskFrame(0);
            Log("Read EPC mask No.0 frame", TxFrame);
            if (ConnectBySerialPort) { Sp.GetInstance().Send(TxFrame); }
            if (ConnectByTCP)
            {
                TCP_Send(TxFrame);
            }
        }

        private void GetMask1_Click(object sender, EventArgs e)
        {
            byte[] TxFrame = CommandBuilder.BuildReadEPCMaskFrame(1);
            Log("Read EPC mask No.1 frame", TxFrame);
            if (ConnectBySerialPort) { Sp.GetInstance().Send(TxFrame); }
            if (ConnectByTCP)
            {
                TCP_Send(TxFrame);
            }
        }

        private void GetMask2_Click(object sender, EventArgs e)
        {
            byte[] TxFrame = CommandBuilder.BuildReadEPCMaskFrame(2);
            Log("Read EPC mask No.2 frame", TxFrame);
            if (ConnectBySerialPort) { Sp.GetInstance().Send(TxFrame); }
            if (ConnectByTCP)
            {
                TCP_Send(TxFrame);
            }
        }

        private void GetMask3_Click(object sender, EventArgs e)
        {
            byte[] TxFrame = CommandBuilder.BuildReadEPCMaskFrame(3);
            Log("Read EPC mask No.3 frame", TxFrame);
            if (ConnectBySerialPort) { Sp.GetInstance().Send(TxFrame); }
            if (ConnectByTCP)
            {
                TCP_Send(TxFrame);
            }
        }

        private void GetMask4_Click(object sender, EventArgs e)
        {
            byte[] TxFrame = CommandBuilder.BuildReadEPCMaskFrame(4);
            Log("Read EPC mask No.4 frame", TxFrame);
            if (ConnectBySerialPort) { Sp.GetInstance().Send(TxFrame); }
            if (ConnectByTCP)
            {
                TCP_Send(TxFrame);
            }
        }

        private void GetMask5_Click(object sender, EventArgs e)
        {
            byte[] TxFrame = CommandBuilder.BuildReadEPCMaskFrame(5);
            Log("Read EPC mask No.5 frame", TxFrame);
            if (ConnectBySerialPort) { Sp.GetInstance().Send(TxFrame); }
            if (ConnectByTCP)
            {
                TCP_Send(TxFrame);
            }
        }

        private void GetMask6_Click(object sender, EventArgs e)
        {
            byte[] TxFrame = CommandBuilder.BuildReadEPCMaskFrame(6);
            Log("Read EPC mask No.6 frame", TxFrame);
            if (ConnectBySerialPort) { Sp.GetInstance().Send(TxFrame); }
            if (ConnectByTCP)
            {
                TCP_Send(TxFrame);
            }
        }

        private void GetMask7_Click(object sender, EventArgs e)
        {
            byte[] TxFrame = CommandBuilder.BuildReadEPCMaskFrame(7);
            Log("Read EPC mask No.7 frame", TxFrame);
            if (ConnectBySerialPort) { Sp.GetInstance().Send(TxFrame); }
            if (ConnectByTCP)
            {
                TCP_Send(TxFrame);
            }
        }

        private void GetMask8_Click(object sender, EventArgs e)
        {
            byte[] TxFrame = CommandBuilder.BuildReadEPCMaskFrame(8);
            Log("Read EPC mask No.8 frame", TxFrame);
            if (ConnectBySerialPort) { Sp.GetInstance().Send(TxFrame); }
            if (ConnectByTCP)
            {
                TCP_Send(TxFrame);
            }
        }

        private void GetMask9_Click(object sender, EventArgs e)
        {
            byte[] TxFrame = CommandBuilder.BuildReadEPCMaskFrame(9);
            Log("Read EPC mask No.9 frame", TxFrame);
            if (ConnectBySerialPort) { Sp.GetInstance().Send(TxFrame); }
            if (ConnectByTCP)
            {
                TCP_Send(TxFrame);
            }
        }

        private void chkMask0_CheckedChanged(object sender, EventArgs e)
        {
            byte Enable = 0;
            if (chkMask0.Checked) { Enable = 1; }

            byte[] TxFrame = CommandBuilder.BuildEnableEPCMaskFrame(0, Enable);
            Log("Enable EPC mask No.0 frame", TxFrame);
            if (ConnectBySerialPort) { Sp.GetInstance().Send(TxFrame); }
            if (ConnectByTCP)
            {
                TCP_Send(TxFrame);
            }
        }

        private void chkMask1_CheckedChanged(object sender, EventArgs e)
        {
            byte Enable = 0;
            if (chkMask1.Checked) { Enable = 1; }

            byte[] TxFrame = CommandBuilder.BuildEnableEPCMaskFrame(1, Enable);
            Log("Enable EPC mask No.1 frame", TxFrame);
            if (ConnectBySerialPort) { Sp.GetInstance().Send(TxFrame); }
            if (ConnectByTCP)
            {
                TCP_Send(TxFrame);
            }
        }

        private void chkMask2_CheckedChanged(object sender, EventArgs e)
        {
            byte Enable = 0;
            if (chkMask2.Checked) { Enable = 1; }

            byte[] TxFrame = CommandBuilder.BuildEnableEPCMaskFrame(2, Enable);
            Log("Enable EPC mask No.2 frame", TxFrame);
            if (ConnectBySerialPort) { Sp.GetInstance().Send(TxFrame); }
            if (ConnectByTCP)
            {
                TCP_Send(TxFrame);
            }
        }

        private void chkMask3_CheckedChanged(object sender, EventArgs e)
        {
            byte Enable = 0;
            if (chkMask3.Checked) { Enable = 1; }

            byte[] TxFrame = CommandBuilder.BuildEnableEPCMaskFrame(3, Enable);
            Log("Enable EPC mask No.3 frame", TxFrame);
            if (ConnectBySerialPort) { Sp.GetInstance().Send(TxFrame); }
            if (ConnectByTCP)
            {
                TCP_Send(TxFrame);
            }
        }

        private void chkMask4_CheckedChanged(object sender, EventArgs e)
        {
            byte Enable = 0;
            if (chkMask4.Checked) { Enable = 1; }

            byte[] TxFrame = CommandBuilder.BuildEnableEPCMaskFrame(4, Enable);
            Log("Enable EPC mask No.4 frame", TxFrame);
            if (ConnectBySerialPort) { Sp.GetInstance().Send(TxFrame); }
            if (ConnectByTCP)
            {
                TCP_Send(TxFrame);
            }
        }

        private void chkMask5_CheckedChanged(object sender, EventArgs e)
        {
            byte Enable = 0;
            if (chkMask5.Checked) { Enable = 1; }

            byte[] TxFrame = CommandBuilder.BuildEnableEPCMaskFrame(5, Enable);
            Log("Enable EPC mask No.5 frame", TxFrame);
            if (ConnectBySerialPort) { Sp.GetInstance().Send(TxFrame); }
            if (ConnectByTCP)
            {
                TCP_Send(TxFrame);
            }
        }

        private void chkMask6_CheckedChanged(object sender, EventArgs e)
        {
            byte Enable = 0;
            if (chkMask6.Checked) { Enable = 1; }

            byte[] TxFrame = CommandBuilder.BuildEnableEPCMaskFrame(6, Enable);
            Log("Enable EPC mask No.6 frame", TxFrame);
            if (ConnectBySerialPort) { Sp.GetInstance().Send(TxFrame); }
            if (ConnectByTCP)
            {
                TCP_Send(TxFrame);
            }
        }

        private void chkMask7_CheckedChanged(object sender, EventArgs e)
        {
            byte Enable = 0;
            if (chkMask7.Checked) { Enable = 1; }

            byte[] TxFrame = CommandBuilder.BuildEnableEPCMaskFrame(7, Enable);
            Log("Enable EPC mask No.7 frame", TxFrame);
            if (ConnectBySerialPort) { Sp.GetInstance().Send(TxFrame); }
            if (ConnectByTCP)
            {
                TCP_Send(TxFrame);
            }
        }

        private void chkMask8_CheckedChanged(object sender, EventArgs e)
        {
            byte Enable = 0;
            if (chkMask8.Checked) { Enable = 1; }

            byte[] TxFrame = CommandBuilder.BuildEnableEPCMaskFrame(8, Enable);
            Log("Enable EPC mask No.8 frame", TxFrame);
            if (ConnectBySerialPort) { Sp.GetInstance().Send(TxFrame); }
            if (ConnectByTCP)
            {
                TCP_Send(TxFrame);
            }
        }

        private void chkMask9_CheckedChanged(object sender, EventArgs e)
        {
            byte Enable = 0;
            if (chkMask9.Checked) { Enable = 1; }

            byte[] TxFrame = CommandBuilder.BuildEnableEPCMaskFrame(9, Enable);
            Log("Enable EPC mask No.9 frame", TxFrame);
            if (ConnectBySerialPort) { Sp.GetInstance().Send(TxFrame); }
            if (ConnectByTCP)
            {
                TCP_Send(TxFrame);
            }
        }

        private void btnMask0Erase_Click(object sender, EventArgs e)
        {
            byte[] TxFrame = CommandBuilder.BuildEraseEPCMaskFrame(0);
            Log("Erase EPC mask No.0 frame", TxFrame);
            txtMask0.Text = "";
            if (ConnectBySerialPort) { Sp.GetInstance().Send(TxFrame); }
            if (ConnectByTCP)
            {
                TCP_Send(TxFrame);
            }
        }

        private void btnMask1Erase_Click(object sender, EventArgs e)
        {
            byte[] TxFrame = CommandBuilder.BuildEraseEPCMaskFrame(1);
            Log("Erase EPC mask No.0 frame", TxFrame);
            txtMask1.Text = "";
            if (ConnectBySerialPort) { Sp.GetInstance().Send(TxFrame); }
            if (ConnectByTCP)
            {
                TCP_Send(TxFrame);
            }
        }

        private void btnMask2Erase_Click(object sender, EventArgs e)
        {
            byte[] TxFrame = CommandBuilder.BuildEraseEPCMaskFrame(2);
            Log("Erase EPC mask No.0 frame", TxFrame);
            txtMask2.Text = "";
            if (ConnectBySerialPort) { Sp.GetInstance().Send(TxFrame); }
            if (ConnectByTCP)
            {
                TCP_Send(TxFrame);
            }
        }

        private void btnMask3Erase_Click(object sender, EventArgs e)
        {
            byte[] TxFrame = CommandBuilder.BuildEraseEPCMaskFrame(3);
            Log("Erase EPC mask No.0 frame", TxFrame);
            txtMask3.Text = "";
            if (ConnectBySerialPort) { Sp.GetInstance().Send(TxFrame); }
            if (ConnectByTCP)
            {
                TCP_Send(TxFrame);
            }
        }

        private void btnMask4Erase_Click(object sender, EventArgs e)
        {
            byte[] TxFrame = CommandBuilder.BuildEraseEPCMaskFrame(4);
            Log("Erase EPC mask No.0 frame", TxFrame);
            txtMask4.Text = "";
            if (ConnectBySerialPort) { Sp.GetInstance().Send(TxFrame); }
            if (ConnectByTCP)
            {
                TCP_Send(TxFrame);
            }
        }

        private void btnMask5Erase_Click(object sender, EventArgs e)
        {
            byte[] TxFrame = CommandBuilder.BuildEraseEPCMaskFrame(5);
            Log("Erase EPC mask No.0 frame", TxFrame);
            txtMask5.Text = "";
            if (ConnectBySerialPort) { Sp.GetInstance().Send(TxFrame); }
            if (ConnectByTCP)
            {
                TCP_Send(TxFrame);
            }
        }

        private void btnMask6Erase_Click(object sender, EventArgs e)
        {
            byte[] TxFrame = CommandBuilder.BuildEraseEPCMaskFrame(6);
            Log("Erase EPC mask No.0 frame", TxFrame);
            txtMask6.Text = "";
            if (ConnectBySerialPort) { Sp.GetInstance().Send(TxFrame); }
            if (ConnectByTCP)
            {
                TCP_Send(TxFrame);
            }
        }

        private void btnMask7Erase_Click(object sender, EventArgs e)
        {
            byte[] TxFrame = CommandBuilder.BuildEraseEPCMaskFrame(7);
            Log("Erase EPC mask No.0 frame", TxFrame);
            txtMask7.Text = "";
            if (ConnectBySerialPort) { Sp.GetInstance().Send(TxFrame); }
            if (ConnectByTCP)
            {
                TCP_Send(TxFrame);
            }
        }

        private void btnMask8Erase_Click(object sender, EventArgs e)
        {
            byte[] TxFrame = CommandBuilder.BuildEraseEPCMaskFrame(8);
            Log("Erase EPC mask No.0 frame", TxFrame);
            txtMask8.Text = "";
            if (ConnectBySerialPort) { Sp.GetInstance().Send(TxFrame); }
            if (ConnectByTCP)
            {
                TCP_Send(TxFrame);
            }
        }

        private void btnMask9Erase_Click(object sender, EventArgs e)
        {
            byte[] TxFrame = CommandBuilder.BuildEraseEPCMaskFrame(9);
            Log("Erase EPC mask No.0 frame", TxFrame);
            txtMask9.Text = "";
            if (ConnectBySerialPort) { Sp.GetInstance().Send(TxFrame); }
            if (ConnectByTCP)
            {
                TCP_Send(TxFrame);
            }
        }


        private void ListenerThread()
        {
           Log("Listener thread started");
            while (bListenerEnbled)
            //while (true)
            {
                try
                {
                    while (server.Pending())
                    {
                        Log("Pending client connection - Trying to accept");
                        TcpClient client = server.AcceptTcpClient();
                        Log("New Client Connected - " + client.Client.RemoteEndPoint.ToString()); // + "\r\nTotal Clients = " + clients.Count);
                        for (int i = 0; i < clients.Count; i++)
                        {
                            if (clients[i].Client.RemoteEndPoint.ToString().Split(new char[] { ':' })[0] == client.Client.RemoteEndPoint.ToString().Split(new char[] { ':' })[0])
                            {
                                clients.RemoveAt(i);
                                i--;
                            }
                        }
                        clients.Add(client);
                        Thread.Sleep(1);
                    }
                }
                catch (SocketException ex)
                {
                    Log("Error in Accepting New Client\r\n" + ex.ToString());
                    if (ex.Message.Contains("A blocking operation was interrupted"))
                        break;
                }
                catch (InvalidOperationException ex)
                {
                    Log("Error in Accepting New Client\r\n" + ex.ToString());
                    if (ex.Message.Contains("Not listening."))
                        break;
                }
                catch (Exception ex)
                {
                    Log("Error in Accepting New Client\r\n" + ex.ToString());
                }
                Thread.Sleep(5);
            }
            Log("Listener thread stopped");
        }

        private void AddLog(string data)
        {
            DateTime dt = DateTime.Now;

            if (bEnableTextBoxLogging)
            {
                if (!txtLog.InvokeRequired)
                {

                    if (txtLog.Text.Length < 15000)
                        txtLog.Text = dt.ToString("dd/MM/yyyy HH:mm:ss.ffffff - ") + data + Environment.NewLine + txtLog.Text;
                    else
                        txtLog.Text = dt.ToString("dd/MM/yyyy HH:mm:ss.ffffff - ") + data + Environment.NewLine + txtLog.Text.Substring(0, 15000);
                }
                else
                {
                    txtLog.Invoke((MethodInvoker)delegate
                    {
                        if (txtLog.Text.Length < 15000)
                            txtLog.Text = dt.ToString("dd/MM/yyyy HH:mm:ss.ffffff - ") + data + Environment.NewLine + txtLog.Text;
                        else
                            txtLog.Text = dt.ToString("dd/MM/yyyy HH:mm:ss.ffffff - ") + data + Environment.NewLine + txtLog.Text.Substring(0, 15000);
                    });
                }
            }

            /*            if (txtLog.Text.Length < 15000)
                            txtLog.Text = dt.ToString("dd/MM/yyyy HH:mm:ss.ffffff - ") + data + Environment.NewLine + "-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------" + Environment.NewLine + txtLog.Text;
                        else
                            txtLog.Text = dt.ToString("dd/MM/yyyy HH:mm:ss.ffffff - ") + data + Environment.NewLine + "-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------" + Environment.NewLine + txtLog.Text.Substring(0, 15000);
             */
            //File.AppendAllText("Log.txt", dt.ToString("dd/MM/yyyy HH:mm:ss.ffffff - ") + data + Environment.NewLine);
        }

        private void btnTcpServerStartStop_Click(object sender, EventArgs e)
        {
            if (btnTcpServerStartStop.Tag.ToString() == "0")
            {
                TCP_LocalServerStart(int.Parse(txtPortTcpServer.Text));
                StartedFromOtherTab = true;

                lvData.Items.Clear();
                txtTagCount.Text = "0";
                tagLastDetectedOn = new List<DateTime>();

                nAllowedTimeDiff = int.Parse(txtTimeDiff.Text);
                txtTimeDiff.ReadOnly = true;

                //listAddItems(sender, e);
                txtPortTcpServer.ReadOnly = true;

                btnTcpServerStartStop.Tag = 1;
                btnTcpServerStartStop.Text = "Stop";
                AddLog("TCP Listener started successfully");
                
            }
            else
            {
                TCP_LocalServerStop();
                StartedFromOtherTab = false;

                txtPortTcpServer.ReadOnly = false;

                txtTimeDiff.ReadOnly = false;

                AddLog("Listener stopped successfully");

                btnTcpServerStartStop.Tag = 0;
                btnTcpServerStartStop.Text = "Start";
            }


        }

        bool TCP_LocalServerStarted;
        private void TCP_LocalServerStart(int port)
        {
            if(TCP_LocalServerStarted) { return; }

            try
            {
                //int port = int.Parse(txtPortTcpServer.Text);
                server = new TcpListener(IPAddress.Any, port);
                server.Start();
                clients = new List<TcpClient>();

                bListenerEnbled = true;
                tListener = new Thread(new ThreadStart(ListenerThread));
                tListener.Start();
                //Myclient = server.AcceptTcpClient();
                TCP_LocalServerStarted = true;
                tmrServerTasks.Enabled = true;

            }
            catch (Exception ex)
            {
                AddLog("Error starting Listener" + ex.ToString());
                TCP_LocalServerStarted = false;
                tmrServerTasks.Enabled = false;
                return;
            }
        }

        private void TCP_LocalServerStop()
        {
            if (!TCP_LocalServerStarted) { return; }

            bListenerEnbled = false;
            tListener.Abort();

            tmrServerTasks.Enabled = false;

            foreach (var client in clients)
                client.Close();
            //Myclient.Close();
            server.Stop();
            clients.Clear();
            clients = null;
            TCP_LocalServerStarted = false;
        }

        private void Process_EPCFrame(byte[] packetBuff)
        {
            byte[] DeviceID = new byte[4];
            ushort uid_len;
            byte[] uid = new byte[4];
            byte[] TimeStamp = new byte[6];
            int Offset = 4;

            if ((packetBuff[3] & 0x40) == 0x40) //Device ID present
            {
                Array.Copy(packetBuff, Offset, DeviceID, 0, 4);
                Offset += 4;
            }

            if ((packetBuff[3] & 0x80) == 0x80)
            {
                Array.Copy(packetBuff, Offset, TimeStamp, 0, TimeStamp.Length);
                Offset += 6;
            }

            uid_len = (ushort)packetBuff[Offset++];
            uid = new byte[uid_len];
            Array.Copy(packetBuff, Offset, uid, 0, uid_len);
            Offset += uid_len;

            listAddItems(DeviceID, uid, uid_len);
        }

        private void Process_ParkingmodeTIDFrame(byte[] PacketBuf)
        {
            byte[] DeviceID = new byte[4];
            byte[] TimeStamp = new byte[6];
            bool IsActive = false;
            ushort IDLength;
            byte[] ID = new byte[4];
            byte FlagGroup0, FlagGroup1;
            int Offset = 5;

            FlagGroup0 = PacketBuf[3];
            FlagGroup1 = PacketBuf[4];

            if ((FlagGroup0 & 0x02) == 0x02) { IsActive = true; }

            if((FlagGroup1 & 0x40) == 0x40)
            {
                Array.Copy(PacketBuf, Offset, DeviceID, 0, DeviceID.Length);
                Offset += 4;
            }

            Array.Copy(PacketBuf, Offset, TimeStamp, 0, TimeStamp.Length);
            Offset += 6;

            IDLength = PacketBuf[Offset];
            Offset++;

            ID = new byte[IDLength];
            Array.Copy(PacketBuf, Offset, ID, 0, IDLength);

            

            List_AddItems(DeviceID, ID, TimeStamp, IsActive);
        }


        private void List_AddItems(byte[] DeviceID, byte[]ID, byte[] TimeStamp, bool IsActive)
        {
 
            string strTID = string.Empty;
            string sIsActive = string.Empty;
            string sTimeStamp = string.Empty;
            string sDeviceID;

            strTID = BitConverter.ToString(ID).Replace("-", "");

            if (!chkDeviceIDReverse1.Checked) { Array.Reverse(DeviceID, 0, DeviceID.Length); }
            uint SerialNumber32 = BitConverter.ToUInt32(DeviceID, 0);
            
            sDeviceID = SerialNumber32.ToString();

              
     
            sTimeStamp = Helpers.TimeStampStr(TimeStamp);
            if(IsActive) { sIsActive = "YES";  }
            else { sIsActive = "NO"; }

            int k = 0;
            for (k = 0; k < lvData.Items.Count; k++)
            {
                if (lvData.Items[k].SubItems[1].Text == strTID)
                    break;
            }

            DateTime dt = DateTime.Now;

            if (k == lvData.Items.Count)
            {
                lvData.Items.Insert(0, new ListViewItem(new string[] { sDeviceID, strTID, "1", dt.ToString("dd/MM/yyyy HH:mm:ss.ffffff"), sTimeStamp, sIsActive }));
                txtTagCount.Text = lvData.Items.Count.ToString();
            }
            else
            {
                lvData.Items[k].SubItems[2].Text = (int.Parse(lvData.Items[k].SubItems[2].Text) + 1).ToString();
                lvData.Items[k].SubItems[3].Text = dt.ToString("dd/MM/yyyy HH:mm:ss.ffffff");
                lvData.Items[k].SubItems[4].Text = sTimeStamp;
                lvData.Items[k].SubItems[5].Text = sIsActive;
            }

        }
        private void TryProcessFullPacket2(byte[] PacketBuff)
        {
            int sm_state = 0;
            int idx = 0;
            int ThisPacketLength = 0;

            int StartIndex = 0;
            int PacketCnt = 0;
            int BlockLen = 0;

            int len = PacketBuff.Length;

            Console.WriteLine("Full packet length: " + len.ToString());
            Console.WriteLine(BitConverter.ToString(PacketBuff).Replace("-", ""));
            while (len > 0)
            {
                if (idx >= len) { break; }
                switch (sm_state)
                {
                    case 0:
                        if (PacketBuff[idx++] == 0xBB) { StartIndex = idx - 1; sm_state++; ThisPacketLength = 0; BlockLen = 0; }
                        //idx++;
                        break;
                    case 1:
                        if ((PacketBuff[idx] > 0) && (PacketBuff[idx] < 253))
                        { sm_state++; ThisPacketLength = PacketBuff[idx]; BlockLen = ThisPacketLength + 3 + idx; }
                        else { sm_state = 0; }
                        idx++;
                        break;
                    case 2:
                        idx++;
                        if (idx == BlockLen)
                        {
                            byte[] RespPacket = new byte[ThisPacketLength + 4];
                            Array.Copy(PacketBuff, StartIndex, RespPacket, 0, RespPacket.Length);
                            PacketCnt++;
                            Console.WriteLine("Seperated packet: " + PacketCnt.ToString());
                            Console.WriteLine(BitConverter.ToString(RespPacket).Replace("-", ""));
                            ProcessSinglePacket(RespPacket);
                            int PacketLength = RespPacket[1];
                            byte[] Packet = new byte[PacketLength];
                            Array.Copy(RespPacket, 2, Packet, 0, PacketLength);
               
                            switch (RespPacket[2])
                            {
                                case 0xE0:
                                    Process_EPCFrame(RespPacket);
                                    //ProcessInventoryResponse(Packet);
                                    break;
                                case 0xE2:
                                    Process_ParkingmodeTIDFrame(RespPacket);
                                    //ProcessParkingmodeTID_Frame(Packet);
                                    break;
                            }
                            sm_state = 0;
                            Console.WriteLine("idx next = " + BlockLen.ToString());
                        }  
                        break;
                }
            }
        }

        private void tmrServerTasks_Tick(object sender, EventArgs e)
        {
            tmrServerTasks.Enabled = false;
            for (int i = 0; i < clients.Count; i++)
            {
                try
                {
                    TcpClient client = clients[i];
                    if (client.Available > 0)
                    {
                        AddLog(client.Client.RemoteEndPoint.ToString() + " - Data available - Trying to read");
                        NetworkStream stream = client.GetStream();
                        byte[] data = new byte[65536];
                        int len = stream.Read(data, 0, 65536);
                        Array.Resize(ref data, len);

                        AddLog(client.Client.RemoteEndPoint.ToString() + " --- " + BitConverter.ToString(data).Replace("-", ""));
                        TryProcessFullPacket2(data); 
                    }
                }
                catch (Exception ex)
                {
                    AddLog("Problem Reading Data\r\n" + ex.ToString());
                    clients.RemoveAt(i);
                    i--;
                }
            }
            tmrServerTasks.Enabled = true;
        }

        //bool ID_Reverse1 = false;
        private void listAddItems(byte[] DeviceID, byte[] data, int len)
        {
            var tagCount = 0;
            string strUid = string.Empty;
            string sDeviceID;
            var index = 0;

            strUid = BitConverter.ToString(data).Replace("-", "");
            if (chkDeviceIDReverse1.Checked)
            {
                Array.Reverse(DeviceID);
            }
            uint SerialNumber32 = BitConverter.ToUInt32(DeviceID, 0);
            
            sDeviceID = SerialNumber32.ToString();

            int k = 0;
            for (k = 0; k < lvData.Items.Count; k++)
            {
                if (lvData.Items[k].SubItems[1].Text == strUid)
                    break;
            }

            DateTime dt = DateTime.Now;

            if (k == lvData.Items.Count)
            {
                lvData.Items.Insert(0, new ListViewItem(new string[] { sDeviceID, strUid, "1", dt.ToString("dd/MM/yyyy HH:mm:ss.ffffff") }));
                txtTagCount.Text = lvData.Items.Count.ToString();
            }
            else
            {
                lvData.Items[k].SubItems[2].Text = (int.Parse(lvData.Items[k].SubItems[2].Text) + 1).ToString();
                lvData.Items[k].SubItems[3].Text = dt.ToString("dd/MM/yyyy HH:mm:ss.ffffff");
            }
            index += 2;
        }

        private void btnTcpServerClearList_Click(object sender, EventArgs e)
        {
            lvData.Items.Clear();
            txtTagCount.Text = "0";
            tagLastDetectedOn = new List<DateTime>();
        }

        private void btnTcpServerLogClear_Click(object sender, EventArgs e)
        {
            txtLog.Text = string.Empty;
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (ListnearThread != null)
            {
                if (ListnearThread.IsAlive)
                {
                    ListnearThread.Abort();
                }
            }

            if (tListener != null)
            {
                if (tListener.IsAlive)
                {
                    tListener.Abort();
                }
            }

            if (Sp.GetInstance().IsOpen())
            {
                Sp.GetInstance().Close();
            }
        }

        private void btnRelay1Trigger_Click(object sender, EventArgs e)
        {
            ushort Timeout100mSec;

            if (!ushort.TryParse(txtIRelay1Timeout.Text, out Timeout100mSec))
            {
                MessageBox.Show("Invalid dwell value!");
                Timeout100mSec = 10;
            }

            byte[] TxFrame = CommandBuilder.BuildIOCtrlFrame(1, Timeout100mSec);
            Log("IO control frame", TxFrame);
            if (ConnectBySerialPort) { Sp.GetInstance().Send(TxFrame); }
            if (ConnectByTCP)
            {
                TCP_Send(TxFrame);
            }
        }

        private void btnRelay2Trigger_Click(object sender, EventArgs e)
        {
            ushort Timeout100mSec;

            if (!ushort.TryParse(txtIRelay2Timeout.Text, out Timeout100mSec))
            {
                MessageBox.Show("Invalid dwell value!");
                Timeout100mSec = 10;
            }

            byte[] TxFrame = CommandBuilder.BuildIOCtrlFrame(2, Timeout100mSec);
            Log("IO control frame", TxFrame);
            if (ConnectBySerialPort) { Sp.GetInstance().Send(TxFrame); }
            if (ConnectByTCP)
            {
                TCP_Send(TxFrame);
            }
        }

        private void btnRelay3Trigger_Click(object sender, EventArgs e)
        {
            ushort Timeout100mSec;

            if (!ushort.TryParse(txtIRelay3Timeout.Text, out Timeout100mSec))
            {
                MessageBox.Show("Invalid dwell value!");
                Timeout100mSec = 10;
            }

            byte[] TxFrame = CommandBuilder.BuildIOCtrlFrame(3, Timeout100mSec);
            Log("IO control frame", TxFrame);
            if (ConnectBySerialPort) { Sp.GetInstance().Send(TxFrame); }
            if (ConnectByTCP)
            {
                TCP_Send(TxFrame);
            }
        }

        private void btnRelay4Trigger_Click(object sender, EventArgs e)
        {
            ushort Timeout100mSec;

            if (!ushort.TryParse(txtIRelay4Timeout.Text, out Timeout100mSec))
            {
                MessageBox.Show("Invalid dwell value!");
                Timeout100mSec = 10;
            }

            byte[] TxFrame = CommandBuilder.BuildIOCtrlFrame(4, Timeout100mSec);
            Log("IO control frame", TxFrame);
            if (ConnectBySerialPort) { Sp.GetInstance().Send(TxFrame); }
            if (ConnectByTCP)
            {
                TCP_Send(TxFrame);
            }
        }

        private void btnRelaysSet_Click(object sender, EventArgs e)
        {
            int IOBits = 0;

            if (chkRelay1.Checked) { IOBits |= 0x01; }
            else { IOBits &= ~0x01; }
            if (chkRelay2.Checked) { IOBits |= 0x02; }
            else { IOBits &= ~0x02; }
            if (chkRelay3.Checked) { IOBits |= 0x04; }
            else { IOBits &= ~0x04; }
            if (chkRelay4.Checked) { IOBits |= 0x08; }
            else { IOBits &= ~0x08; }

            byte[] TxFrame = CommandBuilder.BuildIOCtrlFrame((byte)IOBits);
            Log("IO control frame", TxFrame);
            if (ConnectBySerialPort) { Sp.GetInstance().Send(TxFrame); }
            if (ConnectByTCP)
            {
                TCP_Send(TxFrame);
            }
        }

        private void btnForceBootMode_Click(object sender, EventArgs e)
        {
            byte[] TxFrame = CommandBuilder.BuildForceBootModeFrame();
            Log("Force bootloader mode frame", TxFrame);
            if (ConnectBySerialPort) { Sp.GetInstance().Send(TxFrame); }
            if (ConnectByTCP)
            {
                TCP_Send(TxFrame);
            }
        }


        private void btnRTCTimeGet_Click(object sender, EventArgs e)
        {            
            byte[] TxFrame = CommandBuilder.BuildGetRTC_NowFrame(0x3F);

            Log("Get RTC frame", TxFrame);
            if (ConnectBySerialPort) { Sp.GetInstance().Send(TxFrame); }
            if (ConnectByTCP)
            {
                TCP_Send(TxFrame);
            }
        }

        private void btnRTCSync_Click(object sender, EventArgs e)
        {
            byte[] RawCmdFrame = new byte[7];
            int idx = 0;

            DateTime now = DateTime.Now;
            byte[] copyBytes = BitConverter.GetBytes(now.ToBinary());

            RawCmdFrame[idx++] = 0x3F;//setup config flags
            RawCmdFrame[idx++] = (byte)(now.Hour);//hh
            RawCmdFrame[idx++] = (byte)(now.Minute);//mm
            RawCmdFrame[idx++] = (byte)(now.Second);//ss
            RawCmdFrame[idx++] = (byte)(now.Month);//mm
            RawCmdFrame[idx++] = (byte)(now.Day); //dd
            RawCmdFrame[idx++] = (byte)(now.Year%200);//yy

            byte[] TxFrame = CommandBuilder.BuildSetRTC_NowFrame(RawCmdFrame);

            Log("Synchronize RTC setup frame", TxFrame);
            if (ConnectBySerialPort) { Sp.GetInstance().Send(TxFrame); }
            if (ConnectByTCP)
            {
                TCP_Send(TxFrame);
            }
        }

        private void btnGetBrmRecordCnt_Click(object sender, EventArgs e)
        {
            byte[] TxFrame = CommandBuilder.BuildInventoryGetLogedRecordCountFrame();

            Log("Get logged EPC records count frame", TxFrame);
            if (ConnectBySerialPort) { Sp.GetInstance().Send(TxFrame); }
            if (ConnectByTCP)
            {
                TCP_Send(TxFrame);
            }
        }

        private void btnBrmReadSingleRecord_Click(object sender, EventArgs e)
        {
            byte[] TxFrame;// = CommandBuilder.BuildInventoryLogAutoReadStartFrame();
            //RecordCount = 0;

            TxFrame = CommandBuilder.BuildInventoryLogAutoReadStartFrame();
            Log("Start auto read logged EPC records frame", TxFrame);
            
            if (ConnectBySerialPort) { Sp.GetInstance().Send(TxFrame); }
            if (ConnectByTCP)
            {
                TCP_Send(TxFrame);
            }
        }

        /*private void btnBrmReadAllRecords_Click(object sender, EventArgs e)
        {
            byte[] TxFrame = CommandBuilder.BuildInventoryLogAutoReadResetFrame();

            Log("Reset logged EPC records read count frame", TxFrame);
            if (ConnectBySerialPort) { Sp.GetInstance().Send(TxFrame); }
            if (ConnectByTCP)
            {
                try { client.Client.Send(TxFrame); }
                catch (Exception ex) { MessageBox.Show(ex.Message); }
            }
        }*/

        private void btnBrmEraseAllRecords_Click(object sender, EventArgs e)
        {
            byte[] TxFrame = CommandBuilder.BuildInventoryLogEraseAllFrame();

            Log("Erase all logged EPC records frame", TxFrame);
            if (ConnectBySerialPort) { Sp.GetInstance().Send(TxFrame); }
            if (ConnectByTCP)
            {
                TCP_Send(TxFrame);
            }
        }

        private void btnBRMLogReadStop_Click(object sender, EventArgs e)
        {
            byte[] TxFrame;

            TxFrame = CommandBuilder.BuildInventoryLogAutoReadStopFrame();
            Log("Stop auto read logged EPC records frame", TxFrame);

            if (ConnectBySerialPort) { Sp.GetInstance().Send(TxFrame); }
            if (ConnectByTCP)
            {
                TCP_Send(TxFrame);
            }
        }

        private void btnParkModeEPC_Query_Click(object sender, EventArgs e)
        {
            IsSingleQuery = true;
            SendInventoryCommand(0x80);
            cbxUIDOps.Items.Clear();
        }

        private void btnLoadFromCSV_Click(object sender, EventArgs e)
        {

        }

        private void ParkmodeRegisterSingleTID(byte[] TID)
        {
            byte[] TxFrame;
            
            byte Category = 0;
            byte FlagGroup0, FlagGroup1;

            if (radParkModeCat1.Checked) { Category = 1; }
            else if (radParkModeCat2.Checked) { Category = 2; }
            else if (radParkModeCat3.Checked) { Category = 3; }
            else if (radParkModeCat4.Checked) { Category = 4; }
            else { MessageBox.Show("Please selct a valid Category!"); return; }

            if (txtParkingmodeEPCtoRegister.Text == "")
            { MessageBox.Show("No TID to register!"); return; }

            FlagGroup1 = 0;
            if (chkParkModeTagWhitelistEnable.Checked) { FlagGroup0 = 0x02; }//set active flag
            else { FlagGroup0 = 0x04; }//set blocked flag
            
            if (TID.Length != 12) { MessageBox.Show("TID length is not valid!"); return; }

            TxFrame = CommandBuilder.BuildParkingmodeRegisterSingleID_Frame(Category, FlagGroup1, FlagGroup0, TID);
            Log("Parking mode TID Register frame", TxFrame);

            if (ConnectBySerialPort) { Sp.GetInstance().Send(TxFrame); }
            if (ConnectByTCP)
            {
                TCP_Send(TxFrame);
            }
        }

        private void ParkmodeRegisterSingleTID(string  sTID)
        {
            byte[] TagTID;
            TagTID = Helpers.StringToHexArray(sTID);
            ParkmodeRegisterSingleTID(TagTID);
        }

        private void btnParkModeTagRegister_Click(object sender, EventArgs e)
        {
            ParkmodeRegisterSingleTID(txtParkingmodeEPCtoRegister.Text);
        }

        private void btnParkModeCheckTagEntries_Click(object sender, EventArgs e)
        {
            byte[] TxFrame = CommandBuilder.BuildParkingmodeGetRecordCountersFrame();
            Log("Parking mode get record counters frame", TxFrame);

            if (ConnectBySerialPort) { Sp.GetInstance().Send(TxFrame); }
            if (ConnectByTCP)
            {
                TCP_Send(TxFrame);
            }
        }

        private void btnParkingModeCheckForEntry_Click(object sender, EventArgs e)
        {
            byte[] TagTID;

            TagTID = Helpers.StringToHexArray(txtParkmodeRecordToCheck.Text);
            if (TagTID.Length != 12) { MessageBox.Show("TID length is not valid!"); return; }

            byte[] TxFrame = CommandBuilder.BuildParkingmodeCheckRecordStatusFrame(TagTID);
            Log("Parking mode check single record frame", TxFrame);

            if (ConnectBySerialPort) { Sp.GetInstance().Send(TxFrame); }
            if (ConnectByTCP)
            {
                TCP_Send(TxFrame);
            }
        }

        private void btnParkmodeUpdateExistingRecord_Click(object sender, EventArgs e)
        {
            byte[] TxFrame;
            byte[] TagTID;
            byte Category = 0;
            byte FlagGroup0, FlagGroup1;

            if (chkCat1.Checked)      { Category = 1; }
            else if (chkCat2.Checked) { Category = 2; }
            else if (chkCat3.Checked) { Category = 3; }
            else if (chkCat4.Checked) { Category = 4; }
            else { MessageBox.Show("Please selct a valid Category!"); return; }

            if (txtParkmodeRecordToCheck.Text == "")
            { MessageBox.Show("No TID to register!"); return; }

            FlagGroup1 = 0;
            if (chkRecordIsWhitelist.Checked) { FlagGroup0 = 0x02; }//set active flag
            else { FlagGroup0 = 0x04; }//set blocked flag

            TagTID = Helpers.StringToHexArray(txtParkmodeRecordToCheck.Text);
            if (TagTID.Length != 12) { MessageBox.Show("TID length is not valid!"); return; }

            TxFrame = CommandBuilder.BuildParkingmodeModifyRegisteredID_Frame(Category, FlagGroup1, FlagGroup0, TagTID);
            Log("Parking mode update existing record frame", TxFrame);

            if (ConnectBySerialPort) { Sp.GetInstance().Send(TxFrame); }
            if (ConnectByTCP)
            {
                TCP_Send(TxFrame);
            }
        }

        private void btnParkmodeDeleteExistingRecord_Click(object sender, EventArgs e)
        {
            byte[] TagTID;

            TagTID = Helpers.StringToHexArray(txtParkmodeRecordToCheck.Text);
            if (TagTID.Length != 12) { MessageBox.Show("TID length is not valid!"); return; }

            byte[] TxFrame = CommandBuilder.BuildParkingmodeDeleteSingleRecordFrame(TagTID);
            Log("Parking mode delete single record frame", TxFrame);

            if (ConnectBySerialPort) { Sp.GetInstance().Send(TxFrame); }
            if (ConnectByTCP)
            {
                TCP_Send(TxFrame);
            }
        }

        private void btnParkModeCatConfGet_Click(object sender, EventArgs e)
        {
            byte[] TxFrame = CommandBuilder.BuildParkingmodeGetCatogriesAttribFrame(1, 4);
            Log("Parking mode get Category(s) attribute frame", TxFrame);

            if (ConnectBySerialPort) { Sp.GetInstance().Send(TxFrame); }
            if (ConnectByTCP)
            {
                TCP_Send(TxFrame);
            }
        }

        private void btnParkModeCatConfSet_Click(object sender, EventArgs e)
        {
            byte[] CatAttributes = new byte[4];
            Array.Clear(CatAttributes, 0, 4);

            //Category-1
            if (chkCat1R1.Checked) { CatAttributes[0] += 0x01; }
            if (chkCat1R2.Checked) { CatAttributes[0] += 0x02; }
            if (chkCat1R3.Checked) { CatAttributes[0] += 0x04; }
            if (chkCat1R4.Checked) { CatAttributes[0] += 0x08; }

            //Category-2
            if (chkCat2R1.Checked) { CatAttributes[1] += 0x01; }
            if (chkCat2R2.Checked) { CatAttributes[1] += 0x02; }
            if (chkCat2R3.Checked) { CatAttributes[1] += 0x04; }
            if (chkCat2R4.Checked) { CatAttributes[1] += 0x08; }

            //Category-3
            if (chkCat3R1.Checked) { CatAttributes[2] += 0x01; }
            if (chkCat3R2.Checked) { CatAttributes[2] += 0x02; }
            if (chkCat3R3.Checked) { CatAttributes[2] += 0x04; }
            if (chkCat3R4.Checked) { CatAttributes[2] += 0x08; }

            //Category-4
            if (chkCat4R1.Checked) { CatAttributes[3] += 0x01; }
            if (chkCat4R2.Checked) { CatAttributes[3] += 0x02; }
            if (chkCat4R3.Checked) { CatAttributes[3] += 0x04; }
            if (chkCat4R4.Checked) { CatAttributes[3] += 0x08; }

            byte[] TxFrame = CommandBuilder.BuildParkingmodeSetCatogriesAttribFrame(1, 4, CatAttributes);
            Log("Parking mode set Category(s) attribute frame", TxFrame);

            if (ConnectBySerialPort) { Sp.GetInstance().Send(TxFrame); }
            if (ConnectByTCP)
            {
                TCP_Send(TxFrame);
            }
        }

        private void btnRelayModeGet_Click(object sender, EventArgs e)
        {
            byte[] TxFrame = CommandBuilder.BuildParkingmodeGetRelayAttribFrame();
            Log("Parking mode get relay(s) attribute frame", TxFrame);

            if (ConnectBySerialPort) { Sp.GetInstance().Send(TxFrame); }
            if (ConnectByTCP)
            {
                TCP_Send(TxFrame);
            }
        }

        private void btnRelayModeSet_Click(object sender, EventArgs e)
        {
            int idx = 0;
            byte[] RelayAttributes = new byte[8];
            //byte RelayConfig;
            UInt16 RelayOnTime;

            /*Relay-1*/
            //RelayConfig = 2;
            //if((RelayConfig < 1) || (RelayConfig > 2)) { MessageBox.Show("Relay configurations are not valid!"); return;  }          
            if (!ushort.TryParse(txtRelay1OnTime.Text, out RelayOnTime)) { MessageBox.Show("Invalid On-Time value!"); return; }
            //RelayAttributes[idx++] = RelayConfig;
            RelayAttributes[idx++] = (byte)(RelayOnTime >> 8);
            RelayAttributes[idx++] = (byte)(RelayOnTime);

            /*Relay-2*/
            //RelayConfig = 2;
            //if ((RelayConfig < 1) || (RelayConfig > 2)) { MessageBox.Show("Relay configurations are not valid!"); return; }
            if (!ushort.TryParse(txtRelay2OnTime.Text, out RelayOnTime)) { MessageBox.Show("Invalid On-Time value!"); return; }
            //RelayAttributes[idx++] = RelayConfig;
            RelayAttributes[idx++] = (byte)(RelayOnTime >> 8);
            RelayAttributes[idx++] = (byte)(RelayOnTime);

            /*Relay-3*/
            //RelayConfig = 2;
            //if ((RelayConfig < 1) || (RelayConfig > 2)) { MessageBox.Show("Relay configurations are not valid!"); return; }
            if (!ushort.TryParse(txtRelay3OnTime.Text, out RelayOnTime)) { MessageBox.Show("Invalid On-Time value!"); return; }
            //RelayAttributes[idx++] = RelayConfig;
            RelayAttributes[idx++] = (byte)(RelayOnTime >> 8);
            RelayAttributes[idx++] = (byte)(RelayOnTime);

            /*Relay-4*/
            //RelayConfig = 2;
            //if ((RelayConfig < 1) || (RelayConfig > 2)) { MessageBox.Show("Relay configurations are not valid!"); return; }
            if (!ushort.TryParse(txtRelay4OnTime.Text, out RelayOnTime)) { MessageBox.Show("Invalid On-Time value!"); return; }
            //RelayAttributes[idx++] = RelayConfig;
            RelayAttributes[idx++] = (byte)(RelayOnTime >> 8);
            RelayAttributes[idx++] = (byte)(RelayOnTime);

            byte[] TxFrame = CommandBuilder.BuildParkingmodeSetRelaysAttribFrame(RelayAttributes);
            Log("Parking mode set relay(s) attribute frame", TxFrame);

            if (ConnectBySerialPort) { Sp.GetInstance().Send(TxFrame); }
            if (ConnectByTCP)
            {
                TCP_Send(TxFrame);
            }
        }


        private void btnParkingmodeDataLogReset_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Sure?", "Erase all logged TID frames!", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.No) { return; }

            byte[] TxFrame = CommandBuilder.BuildParkingmodeDataLogEraseAllFrame();
            Log("Parking mode erase all logged data frame", TxFrame);

            if (ConnectBySerialPort) { Sp.GetInstance().Send(TxFrame); }
            if (ConnectByTCP)
            {
                TCP_Send(TxFrame);
            }
        }

        private void btnParkingmodeRecordTableReset_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Sure?", "Erase all  TID entries!", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.No) { return; }

            byte[] TxFrame = CommandBuilder.BuildParkingmodeRecordEraseAllFrame();
            Log("Parking mode erase all stored records frame", TxFrame);

            if (ConnectBySerialPort) { Sp.GetInstance().Send(TxFrame); }
            if (ConnectByTCP)
            {
                TCP_Send(TxFrame);
            }
        }

        private void btnParkModePersistenceGet_Click(object sender, EventArgs e)
        {
            byte[] TxFrame = CommandBuilder.BuildParkingmodeGetPersistenceFrame();
            Log("Parking mode get persistence frame", TxFrame);

            if (ConnectBySerialPort) { Sp.GetInstance().Send(TxFrame); }
            if (ConnectByTCP)
            {
                TCP_Send(TxFrame);
            }
        }

        private void btnParkModePersistenceSet_Click(object sender, EventArgs e)
        {
            UInt16 WaitTime;

            if (!ushort.TryParse(txtParkModePersistence.Text, out WaitTime))
            {
                MessageBox.Show("Invalid Persistence value!");
                return;
            }

            byte AutoResetEnable;

            if (chkParkModePersistenceAutoReset.Checked) { AutoResetEnable = 1; }
            else { AutoResetEnable = 0; }

            byte[] TxFrame = CommandBuilder.BuildParkingmodeSetPersistenceFrame(AutoResetEnable, WaitTime);
            Log("Parking mode set persistence frame", TxFrame);

            if (ConnectBySerialPort) { Sp.GetInstance().Send(TxFrame); }
            if (ConnectByTCP)
            {
                TCP_Send(TxFrame);
            }
        }

        private void btnParkingModeGetDataRouteConf_Click(object sender, EventArgs e)
        {
            byte[] TxFrame = CommandBuilder.BuildParkingmodeGet_TID_RouteFrame();
            Log("Parking mode get TID route frame", TxFrame);

            if (ConnectBySerialPort) { Sp.GetInstance().Send(TxFrame); }
            if (ConnectByTCP)
            {
                TCP_Send(TxFrame);
            }
        }

        private void btnParkingModeSetDataRouteConf_Click(object sender, EventArgs e)
        {
            byte RoutePath = 0;

            if (radParmodeDataToTCP_Server.Checked) { RoutePath = 0x02; }
            if (radParmodeDataToTCP_Client.Checked) { RoutePath = 0x04; }

            if (RoutePath == 0)
            {
                MessageBox.Show("Route path selection is not valid!");
                return;
            }

            byte[] TxFrame = CommandBuilder.BuildParkingmodeSet_TID_RoutFrame(RoutePath);
            Log("Parking mode set TID route frame", TxFrame);

            if (ConnectBySerialPort) { Sp.GetInstance().Send(TxFrame); }
            if (ConnectByTCP)
            {
                TCP_Send(TxFrame);
            }
        }

        private void btnParkingmodeGetOfflineLogCfg_Click(object sender, EventArgs e)
        {
            byte[] TxFrame = CommandBuilder.BuildParkingmodeGet_TID_OfflineLogConfig();
            Log("Parking mode get offline TID log config. frame", TxFrame);

            if (ConnectBySerialPort) { Sp.GetInstance().Send(TxFrame); }
            if (ConnectByTCP)
            {
                TCP_Send(TxFrame);
            }
        }

        private void btnParkingmodeSetOfflineLogCfg_Click(object sender, EventArgs e)
        {
            byte Cfg = 0;

            if (radParkmodeLogWLOnly.Checked) { Cfg = 0x01; }
            if (radParkModeLogAll.Checked)    { Cfg = 0x02; }

            if (Cfg == 0)
            {
                MessageBox.Show("Route path selection is not valid!");
                return;
            }

            byte[] TxFrame = CommandBuilder.BuildParkingmodeSet_TID_OfflineLogConfig(Cfg);
            Log("Parking mode set offline TID config. frame", TxFrame);

            if (ConnectBySerialPort) { Sp.GetInstance().Send(TxFrame); }
            if (ConnectByTCP)
            {
                TCP_Send(TxFrame);
            }
        }

        private void btnParkingmodeGetLoggedTIDCount_Click(object sender, EventArgs e)
        {            
            byte[] TxFrame = CommandBuilder.BuildParkingmodeGetLoggedTIDCountFrame();
            Log("Parking mode get logged TID count frame", TxFrame);

            if (ConnectBySerialPort) { Sp.GetInstance().Send(TxFrame); }
            if (ConnectByTCP)
            {
                TCP_Send(TxFrame);
            }
        }


        private void ParkingmodeLogReadStart()
        {
            if (!IsConnected) { return; }

            if(chkParkingmodeIncDeviceSNR.Checked)
            {
                DataGridView_StyleChange(6, false, false, false);
            }
            else
            {
                DataGridView_StyleChange(5, false, false, false);
            }

            btnParkingmodeLogRead.Text = "Stop Log read";
            btnParkingmodeLogRead.Tag = 1;
            tmrGetLoggedData.Enabled = true;
        }

        private void ParkingmodeLogReadStop()
        {
            btnParkingmodeLogRead.Text = "Start Log read";
            btnParkingmodeLogRead.Tag = 0;
            tmrGetLoggedData.Enabled = false;
        }

        private bool ParkingmodeSendLogReadCommand()
        {
            byte[] TxFrame;
            bool CommunicationOk = true;

              TxFrame = CommandBuilder.BuildParkingmodeReadSingleLoggedRecordFrame(); 

            Log("Parking mode read single logged entry command frame:", TxFrame);

            if ((ConnectBySerialPort) && Sp.GetInstance().IsOpen()) { Sp.GetInstance().Send(TxFrame); }
            if (ConnectByTCP)
            {
                CommunicationOk = TCP_Send(TxFrame);
            }

            return (CommunicationOk);
        }


        private void btnParkingmodeLogRead_Click(object sender, EventArgs e)
        {
            if (btnParkingmodeLogRead.Tag.ToString() == "0")
            {
                ParkingmodeLogReadStart();
                dgView.Rows.Clear();
                RecordCount = 0;
                tbUIDCont.Text = "";
            }
            else
            {
                ParkingmodeLogReadStop();
            }
        }

        private void tmrGetLoggedData_Tick(object sender, EventArgs e)
        {
            bool CommStatus;

            tmrGetLoggedData.Stop();
            CommStatus = ParkingmodeSendLogReadCommand();

            if (CommStatus)
            {
                tmrGetLoggedData.Start();
            }
            else
            {
                ParkingmodeLogReadStop();
            }
        }

        private void ParkingmodeRecordReadStart()
        {
            if (!IsConnected) { return; }

            btnParkModeReadAllrecords.Text = "Stop Record(s) Read";

            btnParkModeReadAllrecords.Tag = 1;
            DataGridView_StyleChange(7, false, false, false);
            tmrGetParkingModeRecords.Enabled = true;
            tmrGetParkingModeRecords.Start();            
        }

        private void ParkingmodeRecordReadStop()
        {
            btnParkModeReadAllrecords.Tag = 0;
            tmrGetParkingModeRecords.Stop();
            tmrGetParkingModeRecords.Enabled = false;
            btnParkModeReadAllrecords.Text = "Start Record(s) Read";
        }


        private void btnParkModeReadAllrecords_Click(object sender, EventArgs e)
        {
            if (btnParkModeReadAllrecords.Tag.ToString() == "0")
            {
                ParkingmodeRecordReadStart();
                dgView.Rows.Clear();
                RecordCount = 0;
                tbUIDCont.Text = "";
            }
            else
            {
                ParkingmodeRecordReadStop();
            }
        }


        private bool ParkingmodeSendGetSingleRecordEntryCmd()
        {
            byte[] TxFrame;
            bool CommunicationOk = true;

            TxFrame = CommandBuilder.BuildParkingmodeGetSingleRecordFrame();

            Log("Parking mode read single TID entry command frame:", TxFrame);

            if ((ConnectBySerialPort) && Sp.GetInstance().IsOpen()) { Sp.GetInstance().Send(TxFrame); }
            if (ConnectByTCP)
            {
                CommunicationOk = TCP_Send(TxFrame);
            }

            return (CommunicationOk);
        }

        private void tmrGetParkingModeRecords_Tick(object sender, EventArgs e)
        {
            bool CommStatus;

            tmrGetParkingModeRecords.Stop();

            CommStatus = ParkingmodeSendGetSingleRecordEntryCmd();

            if (CommStatus)
            {
                tmrGetParkingModeRecords.Start();
            }
            else
            {
                ParkingmodeRecordReadStop();
            }
        }

        private void btnExtInvSoftTrigger_Click(object sender, EventArgs e)
        {
            byte[] TxFrame = CommandBuilder.BuildExtAutoInventorySoftTriggerFrame();
            Log("Extended inventory soft trigger command:", TxFrame);
            if (ConnectBySerialPort) { Sp.GetInstance().Send(TxFrame); }
            if (ConnectByTCP)
            {
                TCP_Send(TxFrame);
            }
        }

        private void btnExtInCfgFlagsGet_Click(object sender, EventArgs e)
        {            
            byte[] TxFrame = CommandBuilder.BuildExtAutoInentoryGetConfigFalgsFrame();
            Log("Extended inventory get config flags command:", TxFrame);
            if (ConnectBySerialPort) { Sp.GetInstance().Send(TxFrame); }
            if (ConnectByTCP)
            {
                TCP_Send(TxFrame);
            }
        }

        private void btnExtInvSoftTrigEnable_Click(object sender, EventArgs e)
        {
            byte[] TxFrame = CommandBuilder.BuildExtIncentorySoftTriggerCtrlFrame(1);
            Log("Extended inventory soft trigger enable command:", TxFrame);
            if (ConnectBySerialPort) { Sp.GetInstance().Send(TxFrame); }
            if (ConnectByTCP)
            {
                TCP_Send(TxFrame);
            }
        }

        private void btnExtAotuInventoryRespRouteSet_Click(object sender, EventArgs e)
        {
            byte RoutePath = 0;

            if (radExtInvRespRouteToServer.Checked) { RoutePath = 0x02; }
            if (radExtInvRespRouteToClient.Checked) { RoutePath = 0x04; }

            if (RoutePath == 0)
            {
                MessageBox.Show("Route path selection is not valid!");
                return;
            }

            byte[] TxFrame = CommandBuilder.BuildExtInventoryRespPathSetFrame(RoutePath);
            Log("Parking mode set Inventory response route frame", TxFrame);

            if (ConnectBySerialPort) { Sp.GetInstance().Send(TxFrame); }
            if (ConnectByTCP)
            {
                TCP_Send(TxFrame);
            }
        }

        private void btnExtAotuInventoryRespRouteGet_Click(object sender, EventArgs e)
        {
            byte[] TxFrame = CommandBuilder.BuildExtInventoryRespPathGetFrame();
            Log("Parking mode get Inventory response route frame", TxFrame);

            if (ConnectBySerialPort) { Sp.GetInstance().Send(TxFrame); }
            if (ConnectByTCP)
            {
                TCP_Send(TxFrame);
            }
        }

        private void StartBRMLogOps()
        {
            if (!IsConnected) { return; }

            btn_BRMLogOps.Text = "Stop BRM log read";
            btn_BRMLogOps.Tag = 1;            
            tmrGetBRMLogs.Enabled = true;
            tmrGetBRMLogs.Start();
        }

        private void StopBRMLogOps()
        {
            btn_BRMLogOps.Text = "Start BRM log read";
            btn_BRMLogOps.Tag = 0;
            tmrGetBRMLogs.Stop();
            tmrGetBRMLogs.Enabled = false;
        }

        private void btn_BRMLogOps_Click(object sender, EventArgs e)
        {
            if (btn_BRMLogOps.Tag.ToString() == "0")
            {
                StartBRMLogOps();
            }
            else
            {
                StopBRMLogOps();
            }
        }

        private bool BRMGetSingleRecordCmd_Transmit()
        {
            byte[] TxFrame;
            bool CommunicationOk = true;

            TxFrame = CommandBuilder.BuildBRMGetSingleRecordFrame();

            Log("Read single BRM entry command frame:", TxFrame);

            if ((ConnectBySerialPort) && Sp.GetInstance().IsOpen()) { Sp.GetInstance().Send(TxFrame); }
            if (ConnectByTCP)
            {
                CommunicationOk = TCP_Send(TxFrame);
            }

            return (CommunicationOk);
        }

        private void tmrGetBRMLogs_Tick(object sender, EventArgs e)
        {
            bool CommStatus;

            tmrGetBRMLogs.Stop();

            CommStatus = BRMGetSingleRecordCmd_Transmit();

            if (CommStatus)
            {
                tmrGetBRMLogs.Start();
            }
            else
            {
                StopBRMLogOps();
            }
        }

        private void btnAuthenticate_Click(object sender, EventArgs e)
        {
            byte[] Password = Encoding.ASCII.GetBytes(txtGlobalPwd.Text);
            if (Password.Length > 16) { MessageBox.Show("Password length limit exedded!"); return; }

            if (Password.Length < 16)
            {
                int NewLength = 16;
                Array.Resize(ref Password, NewLength);
            }

            Array.Copy(Password, GlobalPassword, GlobalPassword.Length);//Local copy

            byte[] TxFrame = CommandBuilder.BuildGlobalPasswordAuthenticateFrame(Password);
            Log("Global password authenticate frame", TxFrame);

            if (ConnectBySerialPort) { Sp.GetInstance().Send(TxFrame); }
            if (ConnectByTCP)
            {
                TCP_Send(TxFrame);
            }
        }

        private void btnDeAuthenticate_Click(object sender, EventArgs e)
        {
            byte[] TxFrame = CommandBuilder.BuildGlobalPasswordDeauthenticateFrame();
            Log("Global password de-authenticate frame", TxFrame);

            if (ConnectBySerialPort) { Sp.GetInstance().Send(TxFrame); }
            if (ConnectByTCP)
            {
                TCP_Send(TxFrame);
            }
        }

        private void btnPasswordUpdate_Click(object sender, EventArgs e)
        {
            byte[] Password = Encoding.ASCII.GetBytes(txtGlobalPwd.Text);
            if (Password.Length > 16) { MessageBox.Show("Password length limit exedded!"); return; }
            //if (Password.Length == 0) { MessageBox.Show("Password length error!"); return; }
            if (Password.Length < 16)
            {
                int NewLength = 16;
                Array.Resize(ref Password, NewLength);
            }

            Array.Copy(Password, NewGlobalPassword, NewGlobalPassword.Length);//Local copy

            byte[] TxFrame = CommandBuilder.BuildGlobalPasswordUpdateFrame(GlobalPassword, Password);
            Log("Global password de-authenticate frame", TxFrame);

            if (ConnectBySerialPort) { Sp.GetInstance().Send(TxFrame); }
            if (ConnectByTCP)
            {
                TCP_Send(TxFrame);
            }
        }

        private void btnPersistenceGet_Click(object sender, EventArgs e)
        {
            byte[] TxFrame = CommandBuilder.BuildGetExtInvPersistanceConfFrame();
            Log("Extended inventory get persistence info. command:", TxFrame);
            if (ConnectBySerialPort) { Sp.GetInstance().Send(TxFrame); }
            if (ConnectByTCP)
            {
                TCP_Send(TxFrame);
            }
        }

        private void btnPersistenceSet_Click(object sender, EventArgs e)
        {
            int Enable = 0;
            if(chkEPCPersistance.Checked)        { Enable |= 0x01; }
            if (chkPersistanceAutoReset.Checked) { Enable |= 0x02; }

            ushort WaitTime;

            if (!ushort.TryParse(txtTagPersistenceTime.Text, out WaitTime))
            {
                MessageBox.Show("Invalid Persistence value!");
                WaitTime = 10;
            }

            byte[] TxFrame = CommandBuilder.BuildSetExtInvPersistanceFrame((byte)Enable, WaitTime);
            Log("Extended inventory set persistence info. command:", TxFrame);
            if (ConnectBySerialPort) { Sp.GetInstance().Send(TxFrame); }
            if (ConnectByTCP)
            {
                TCP_Send(TxFrame);
            }
        }


        ushort SessionCountTCP;
        ushort SessionCountInventory;
        ushort SessionCountInventoryLatch;
        ushort DelayInBetween;
        bool TCP_SM_Enable = false;
        ushort TCP_TestSM_State = 0;
        TcpClient Client1;

        private bool TCPCtrl(bool OpenClose)
        {
            bool Result = false;

            if (OpenClose)
            {
                try
                {
                    IPAddress address = IPAddress.Parse(txtDevicIP.Text);//open connection to remote server
                    Client1 = new TcpClient(txtDevicIP.Text, int.Parse(txtTCP_Port.Text));
                    Console.WriteLine(">>>Port open success!>>>");
                    Result = true;
                }
                catch (SocketException ex)
                {
                    Result = false;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    Result = false;
                }

            }
            else
            {
                Result = true;
                    try
                    {
                     Client1.Close();
                    }
                    catch (NullReferenceException ex)
                    {

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                        Result = false;
                    }
                Console.WriteLine("<<<Port close success!<<<");
            }

            return Result;
        }



        private void txtSessionCount_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (
           ((e.KeyChar < '0') || (e.KeyChar > '9')) && (e.KeyChar != 0x08)
          )
            { e.Handled = true; }
        }

        private void txtSessionDelay_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (
           ((e.KeyChar < '0') || (e.KeyChar > '9')) && (e.KeyChar != 0x08)
          )
            { e.Handled = true; }
        }

        private void txtIncentorySessionCount_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (
           ((e.KeyChar < '0') || (e.KeyChar > '9')) && (e.KeyChar != 0x08)
          )
            { e.Handled = true; }
        }

 


        private bool TCP_ResponseGet()
        {
            bool ExitNow = false;
            try
            {
                if (Client1.Available > 0)
                {
                    NetworkStream stream = Client1.GetStream();
                    byte[] data = new byte[1000];
                    int len = stream.Read(data, 0, 1000);
                    byte[] PacketBuff = new byte[len];
                    Array.Copy(data, 0, PacketBuff, 0, len);

                    TryProcessFullPacket(PacketBuff);
                }
            }
            catch (Exception ex)
            {
                ExitNow = true;
            }

            return(ExitNow);
        }

        private bool TCPTranceiveAsync(byte[] TxFrame, int TimeOut)
        {
            bool ExitNow = false;

            try { Client1.Client.Send(TxFrame); }
            catch (Exception ex) { ExitNow = true; MessageBox.Show(ex.Message); }

            if(false == ExitNow)
            {
                //TimeOut += 50;
                while (TimeOut > 0)
                {
                    //TCP_ResponseGet();
                    TimeOut--;
                    //Thread.Sleep(1);
                }
            }

            return (ExitNow);
        }

        private void btnDiagScan_Click(object sender, EventArgs e)
        {

            if (btnDiagScan.Tag.ToString() == "0")
            {
                ushort ScanIntervalmSec = 50;

                if (!ushort.TryParse(txtScanFrequency.Text, out ScanIntervalmSec))
                {
                    ScanIntervalmSec = 50;
                }


                btnDiagScan.Text = "Stop";
                btnDiagScan.Tag = 1;
                tmrDiagScan.Interval = ScanIntervalmSec;
                tmrDiagScan.Enabled = true;
                tmrDiagScan.Start();
            }
            else
            {
                btnDiagScan.Text = "Start";
                btnDiagScan.Tag = 0;
                tmrDiagScan.Stop();
            }
        }

        private void tmrDiagScan_Tick(object sender, EventArgs e)
        {
            bool Ex = false;
            tmrDiagScan.Stop();
            byte[] TxFrame = CommandBuilder.BuildDeviceStatisticsGetCmd();

            Log("Get Device diagnostic status frame", TxFrame);
            if ((ConnectBySerialPort) && Sp.GetInstance().IsOpen()) { Sp.GetInstance().Send(TxFrame); }
            if (ConnectByTCP)
            {
                bool Status = TCP_Send(TxFrame);
                tmrDiagScan.Start();
                if (!Status)
                {
                    btnDiagScan.Text = "Start";
                    btnDiagScan.Tag = 0;
                    tmrDiagScan.Stop();
                }
            }

            if (ConnectBySerialPort)
            {
                if (!Sp.GetInstance().IsOpen()) { Ex = true; }
            }

            if (Ex) 
            {
                btnDiagScan.Text = "Start";
                btnDiagScan.Tag = 0;
                tmrDiagScan.Stop(); 
            }
        }

        private void btnDiagResetAllCnt_Click(object sender, EventArgs e)
        {
            byte[] TxFrame = CommandBuilder.BuildDeviceStatisticsResetCmd();

            Log("Reset all device diagnostic counters frame", TxFrame);
            if (ConnectBySerialPort) { Sp.GetInstance().Send(TxFrame); }
            if (ConnectByTCP)
            {
                TCP_Send(TxFrame);
            }

        }

        private void tbRFPower_TextChanged(object sender, EventArgs e)
        {
                ushort RFPower = 0;

                if (ushort.TryParse(tbRFPower.Text, out RFPower))
                {
                    if (RFPower > 3100) { tbRFPower.BackColor = Color.Red; }
                    else { { tbRFPower.BackColor = Color.White; } }
                }            
        }

        private void TextBox_Update(TextBox textbox)
        {
            textbox.Text = "1234";
        }

        private void cbxDeviceWorkingMode_SelectedIndexChanged(object sender, EventArgs e)
        {
            //MessageBox.Show(cbxDeviceWorkingMode.SelectedIndex.ToString()); ;
            if (!ExtAppEnabled)
            {
                if(cbxDeviceWorkingMode.SelectedIndex > 1)
                {
                    MessageBox.Show("This working mode is not supported by the connected hardware!");
                    cbxDeviceWorkingMode.SelectedIndex = 0;
                }
            }
        }

        private void btnGetTarget_Click(object sender, EventArgs e)
        {
            byte[] TxFrame = CommandBuilder.BuildGetInventoryTargetFrame();
            if (ConnectBySerialPort) { Sp.GetInstance().Send(TxFrame); }
            if (ConnectByTCP)
            {
                TCP_Send(TxFrame);
            }
        }

        private void btnSetTarget_Click(object sender, EventArgs e)
        {
            if (cbxTarget.SelectedIndex < 0) { return; }

            byte TValue = (byte)cbxTarget.SelectedIndex;

            byte[] TxFrame = CommandBuilder.BuildSetInventoryTargetFrame(TValue);
            if (ConnectBySerialPort) { Sp.GetInstance().Send(TxFrame); }
            if (ConnectByTCP)
            {
                TCP_Send(TxFrame);
            }
        }

        private void cbxInterval_SelectedIndexChanged(object sender, EventArgs e)
        {
            string TimerInterval = cbxInterval.SelectedItem.ToString().Trim((new Char[] { ' ', 'm', 'S' }));
            //TimerInterval.Trim((new Char[] { ' ', 'm', 'S' }));
            int interval;
            if (!int.TryParse(TimerInterval, out interval))
            {
                interval = 100;
            }
            tmrEPCInventory.Interval = interval;
        }

        private void tmrEPC_Timeout_Tick(object sender, EventArgs e)
        {
            DateTime now = System.DateTime.Now;
            DateTime dt;
            int timeout = 5000;
            for (int i = 0; i < dgView.Rows.Count - 1; i++)
            {
                string time = dgView.Rows[i].Cells[9].Value.ToString();
                if (null != time && !"".Equals(time))
                {
                    if (DateTime.TryParse(time, out dt))
                    {
                        TimeSpan sub = now.Subtract(dt);
                        if (sub.TotalMilliseconds > timeout) { this.dgView.Rows[i].DefaultCellStyle.BackColor = Color.Red; }
                    }
                }
            }
        }

        private void chkDHCP_Click(object sender, EventArgs e)
        {
            byte[] DHCP_Config = new byte[2];
            DHCP_Config[0] = 0x03; //Indicate DHCP parameter

            if (chkDHCP.Checked)
            {
                DHCP_Config[1] = 0x01; //dhcl enabled
            }
            else
            {
                DHCP_Config[1] = 0x00; //DHCP disabled
            }

            byte[] TxFrame = CommandBuilder.BuildSetComunucationParametersFrame(DHCP_Config);
            Log("Set TCP/IP DHCP setup frame", TxFrame);
            if (ConnectBySerialPort) { Sp.GetInstance().Send(TxFrame); }
            if (ConnectByTCP)
            {
                TCP_Send(TxFrame);
            }
        }

        private bool TCP_ServerSend(byte[] data)
        {
            bool status = true;
            if (clients.Count == 0) { return false; }

            TcpClient client = clients[0];
            try
            {
                NetworkStream stream = client.GetStream();
                stream.Write(data, 0, data.Length);
            }
            catch(Exception Ex)
            {
                MessageBox.Show(Ex.ToString());
                status = false;
            }
            return status;
        }


        private bool TCP_ClientSend(byte[] data)
        {
            bool status = true;
            try { client.Client.Send(data); }
            catch (Exception ex) 
            {
                MessageBox.Show(ex.Message);
                CommunicationOk = false;
                status = false;
            }
            return status;
        }

        private bool TCP_Send(byte[] data)
        {
            bool Status = false;
            if (radTCPServer.Checked)
            {
                Status = TCP_ServerSend(data);
            }
            else
            {
                Status = TCP_ClientSend(data);
            }

            return Status;
        }

        private void chkIDReverse2_CheckedChanged(object sender, EventArgs e)
        {
            dgView.Rows.Clear();
            RecordCount = 0;
            tbUIDCont.Text = "";
        }

        private void btnMuxConfGet_Click(object sender, EventArgs e)
        {
            byte[] TxFrame = CommandBuilder.BuildGetMuxPortCmdFrame();
            Log("Get Get antenna multiplexer port", TxFrame);
            if (ConnectBySerialPort) { Sp.GetInstance().Send(TxFrame); }
            if (ConnectByTCP)
            {
                TCP_Send(TxFrame);
            }
        }

        private void btnMuxConfSet_Click(object sender, EventArgs e)
        {
            if (cbxMuxPort.SelectedIndex < 0) { return; }

            string sMuxPortVal = cbxMuxPort.SelectedItem.ToString();
            byte MuxPort = Convert.ToByte(sMuxPortVal);

            byte[] TxFrame = CommandBuilder.BuildSetMuxPortCmdFrame(MuxPort);
            Log("Get Set antenna multiplexer port", TxFrame);
            if (ConnectBySerialPort) { Sp.GetInstance().Send(TxFrame); }
            if (ConnectByTCP)
            {
                TCP_Send(TxFrame);
            }
        }

        private void btnExtInventory_Click(object sender, EventArgs e)
        {
            byte MuxConfig = 0;

            if (chkAnt1.Checked) { MuxConfig += 0x01; }
            if (chkAnt2.Checked) { MuxConfig += 0x02; }
            if (chkAnt3.Checked) { MuxConfig += 0x04; }
            if (chkAnt4.Checked) { MuxConfig += 0x08; }
            if (chkAnt5.Checked) { MuxConfig += 0x10; }
            if (chkAnt6.Checked) { MuxConfig += 0x20; }

            byte[] TxFrame = CommandBuilder.BuildExtendedInventoryFrame(MuxConfig);
            Log("Extended inventory request frame:", TxFrame);
            if (ConnectBySerialPort) { Sp.GetInstance().Send(TxFrame); }
            if (ConnectByTCP)
            {
                TCP_Send(TxFrame);
            }
        }

        private void btnGetMuxConfig_Click(object sender, EventArgs e)
        {
            byte[] TxFrame = CommandBuilder.BuildExtInventoryMuxConfigGetFrame();
            Log("Extended inventory get antenna multiplexer config command:", TxFrame);
            if (ConnectBySerialPort) { Sp.GetInstance().Send(TxFrame); }
            if (ConnectByTCP)
            {
                TCP_Send(TxFrame);
            }
        }

        private void btnSetMuxConfig_Click(object sender, EventArgs e)
        {
            byte MuxConfig = 0;

            if (ChkExtAnt1.Checked) { MuxConfig += 0x01; }
            if (ChkExtAnt2.Checked) { MuxConfig += 0x02; }
            if (ChkExtAnt3.Checked) { MuxConfig += 0x04; }
            if (ChkExtAnt4.Checked) { MuxConfig += 0x08; }
            if (ChkExtAnt5.Checked) { MuxConfig += 0x10; }
            if (ChkExtAnt6.Checked) { MuxConfig += 0x20; }

            if(0 == MuxConfig)
            {
                MessageBox.Show("Must have to select atleast one antenna!");
                return;
            }

            byte[] TxFrame = CommandBuilder.BuildExtInventoryMuxConfigSetFrame(MuxConfig);
            Log("Extended inventory set antenna multiplexer config command:", TxFrame);
            if (ConnectBySerialPort) { Sp.GetInstance().Send(TxFrame); }
            if (ConnectByTCP)
            {
                TCP_Send(TxFrame);
            }
        }

        private void radTIDOnly_CheckedChanged(object sender, EventArgs e)
        {
            //0x20 0x01 0x00
            //0x20 0x01 0x06
        }

        private void btnLogDeviceSNConfSet_Click(object sender, EventArgs e)
        {
            byte enable = 0;

            if (chkParkingmodeIncDeviceSNR.Checked) { enable = 0x01; }
            byte[] TxFrame = CommandBuilder.BuildParkingmodeEnableDevID(enable);
            Log("Parking mode set DevicID in TID frame", TxFrame);

            if (ConnectBySerialPort) { Sp.GetInstance().Send(TxFrame); }
            if (ConnectByTCP)
            {
                TCP_Send(TxFrame);
            }
        }

        private void btnLogDeviceSNConfGet_Click(object sender, EventArgs e)
        {
            byte[] TxFrame = CommandBuilder.BuildParkingmodeGetDevIDStatus();
            Log("Parking mode set DevicID in TID frame", TxFrame);

            if (ConnectBySerialPort) { Sp.GetInstance().Send(TxFrame); }
            if (ConnectByTCP)
            {
                TCP_Send(TxFrame);
            }
        }

        private void btnCycleTimeGet_Click(object sender, EventArgs e)
        {
            byte[] TxFrame = CommandBuilder.BuildGetOneShotInventoryCycleTimeFrame();
            Log("Extended inventory get cycle time command:", TxFrame);
            if (ConnectBySerialPort) { Sp.GetInstance().Send(TxFrame); }
            if (ConnectByTCP)
            {
                TCP_Send(TxFrame);
            }
        }

        private void btnCycleTimeSet_Click(object sender, EventArgs e)
        {
            ushort CycleTime;

            if (!ushort.TryParse(txtCycleTime.Text, out CycleTime))
            {
                MessageBox.Show("Invalid Cycle time value!");
                CycleTime = 1000;
            }

            byte[] TxFrame = CommandBuilder.BuildSetOneShotInventoryCycleTimeFrame(CycleTime);
            Log("Extended inventory set cycle time command:", TxFrame);
            if (ConnectBySerialPort) { Sp.GetInstance().Send(TxFrame); }
            if (ConnectByTCP)
            {
                TCP_Send(TxFrame);
            }
        }
    }
}
