namespace RRUHF_Reader_SDK_Demo
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.grpCommSetup = new System.Windows.Forms.GroupBox();
            this.btnConnect = new System.Windows.Forms.Button();
            this.radSelectTCP = new System.Windows.Forms.RadioButton();
            this.radSelectCOMPort = new System.Windows.Forms.RadioButton();
            this.grpTCP = new System.Windows.Forms.GroupBox();
            this.radTCPClient = new System.Windows.Forms.RadioButton();
            this.radTCPServer = new System.Windows.Forms.RadioButton();
            this.label4 = new System.Windows.Forms.Label();
            this.txtDevicIP = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtTCP_Port = new System.Windows.Forms.TextBox();
            this.grpCOM = new System.Windows.Forms.GroupBox();
            this.cbxBaudRate = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cbxSerPort = new System.Windows.Forms.ComboBox();
            this.tabCtrl = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.groupBox21 = new System.Windows.Forms.GroupBox();
            this.label22 = new System.Windows.Forms.Label();
            this.btnMuxConfSet = new System.Windows.Forms.Button();
            this.btnMuxConfGet = new System.Windows.Forms.Button();
            this.cbxMuxPort = new System.Windows.Forms.ComboBox();
            this.groupBox12 = new System.Windows.Forms.GroupBox();
            this.chkRelay4 = new System.Windows.Forms.CheckBox();
            this.chkRelay3 = new System.Windows.Forms.CheckBox();
            this.btnRelaysSet = new System.Windows.Forms.Button();
            this.chkRelay2 = new System.Windows.Forms.CheckBox();
            this.chkRelay1 = new System.Windows.Forms.CheckBox();
            this.groupBox11 = new System.Windows.Forms.GroupBox();
            this.btnRelay4Trigger = new System.Windows.Forms.Button();
            this.btnRelay3Trigger = new System.Windows.Forms.Button();
            this.label19 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.txtIRelay4Timeout = new System.Windows.Forms.TextBox();
            this.txtIRelay3Timeout = new System.Windows.Forms.TextBox();
            this.btnRelay2Trigger = new System.Windows.Forms.Button();
            this.btnRelay1Trigger = new System.Windows.Forms.Button();
            this.label54 = new System.Windows.Forms.Label();
            this.label53 = new System.Windows.Forms.Label();
            this.txtIRelay2Timeout = new System.Windows.Forms.TextBox();
            this.txtIRelay1Timeout = new System.Windows.Forms.TextBox();
            this.label52 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnBaudrateGet = new System.Windows.Forms.Button();
            this.btnBaudrateSet = new System.Windows.Forms.Button();
            this.label24 = new System.Windows.Forms.Label();
            this.cbxUSARTBaudrate = new System.Windows.Forms.ComboBox();
            this.groupBox8 = new System.Windows.Forms.GroupBox();
            this.chkDHCP = new System.Windows.Forms.CheckBox();
            this.label49 = new System.Windows.Forms.Label();
            this.chkMACAddress = new System.Windows.Forms.CheckBox();
            this.chkClientIP = new System.Windows.Forms.CheckBox();
            this.txtMACAddress = new System.Windows.Forms.TextBox();
            this.label47 = new System.Windows.Forms.Label();
            this.txtDeviceClietnIP = new System.Windows.Forms.TextBox();
            this.chkClientPort = new System.Windows.Forms.CheckBox();
            this.chkServerPort = new System.Windows.Forms.CheckBox();
            this.chkNetMask = new System.Windows.Forms.CheckBox();
            this.chkGetWayIP = new System.Windows.Forms.CheckBox();
            this.chkDeviceIP = new System.Windows.Forms.CheckBox();
            this.btnSetTCPConf = new System.Windows.Forms.Button();
            this.btnGetTCPConf = new System.Windows.Forms.Button();
            this.label45 = new System.Windows.Forms.Label();
            this.label44 = new System.Windows.Forms.Label();
            this.txtDeviceClientPort = new System.Windows.Forms.TextBox();
            this.txtDeviceNetMask = new System.Windows.Forms.TextBox();
            this.label46 = new System.Windows.Forms.Label();
            this.txtDeviceServerPort = new System.Windows.Forms.TextBox();
            this.label43 = new System.Windows.Forms.Label();
            this.txtDeviceGW = new System.Windows.Forms.TextBox();
            this.label42 = new System.Windows.Forms.Label();
            this.txtDeviceIP = new System.Windows.Forms.TextBox();
            this.groupBox10 = new System.Windows.Forms.GroupBox();
            this.cbxMaxFreq = new System.Windows.Forms.ComboBox();
            this.lblRFPower = new System.Windows.Forms.Label();
            this.btnSetRfmode = new System.Windows.Forms.Button();
            this.lblRegion = new System.Windows.Forms.Label();
            this.btnGetRfMode = new System.Windows.Forms.Button();
            this.cbxRegion = new System.Windows.Forms.ComboBox();
            this.btnGetRfPower = new System.Windows.Forms.Button();
            this.btnGetRegion = new System.Windows.Forms.Button();
            this.lblRFMode = new System.Windows.Forms.Label();
            this.btnSetRegion = new System.Windows.Forms.Button();
            this.btnSetRfPower = new System.Windows.Forms.Button();
            this.cbxMinFreq = new System.Windows.Forms.ComboBox();
            this.cbxRFMode = new System.Windows.Forms.ComboBox();
            this.tbRFPower = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.gbRFSetup = new System.Windows.Forms.GroupBox();
            this.groupBox36 = new System.Windows.Forms.GroupBox();
            this.lblRFInfo3 = new System.Windows.Forms.Label();
            this.lblRFInfo2 = new System.Windows.Forms.Label();
            this.lblRFInfo1 = new System.Windows.Forms.Label();
            this.groupBox35 = new System.Windows.Forms.GroupBox();
            this.btnRTCSync = new System.Windows.Forms.Button();
            this.txtRTC = new System.Windows.Forms.TextBox();
            this.label88 = new System.Windows.Forms.Label();
            this.btnRTCTimeGet = new System.Windows.Forms.Button();
            this.groupBox34 = new System.Windows.Forms.GroupBox();
            this.chkTCPClientCheck = new System.Windows.Forms.CheckBox();
            this.btnHeartbeat = new System.Windows.Forms.Button();
            this.label55 = new System.Windows.Forms.Label();
            this.txtHeartbeat = new System.Windows.Forms.TextBox();
            this.groupBox32 = new System.Windows.Forms.GroupBox();
            this.groupBox33 = new System.Windows.Forms.GroupBox();
            this.button1 = new System.Windows.Forms.Button();
            this.txtBuzzerBeepDuration = new System.Windows.Forms.TextBox();
            this.btnBuzzerControl = new System.Windows.Forms.Button();
            this.chkBuzzerEnable = new System.Windows.Forms.CheckBox();
            this.groupBox31 = new System.Windows.Forms.GroupBox();
            this.btnForceBootMode = new System.Windows.Forms.Button();
            this.btnDeviceRestart = new System.Windows.Forms.Button();
            this.groupBox30 = new System.Windows.Forms.GroupBox();
            this.label18 = new System.Windows.Forms.Label();
            this.cbxDeviceWorkingMode = new System.Windows.Forms.ComboBox();
            this.btnGetWorkingMode = new System.Windows.Forms.Button();
            this.btnSetWorkingMode = new System.Windows.Forms.Button();
            this.groupBox29 = new System.Windows.Forms.GroupBox();
            this.txtHardwareVersion = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.txtDeviceSerialNum = new System.Windows.Forms.TextBox();
            this.txtFirmwareVersion = new System.Windows.Forms.TextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.button3 = new System.Windows.Forms.Button();
            this.groupBox28 = new System.Windows.Forms.GroupBox();
            this.btnDeAuthenticate = new System.Windows.Forms.Button();
            this.btnAuthenticate = new System.Windows.Forms.Button();
            this.txtGlobalPwd = new System.Windows.Forms.TextBox();
            this.btnPasswordUpdate = new System.Windows.Forms.Button();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.grpEPCWrite = new System.Windows.Forms.GroupBox();
            this.label26 = new System.Windows.Forms.Label();
            this.btnWriteEPC = new System.Windows.Forms.Button();
            this.txtAccessPwEPC = new System.Windows.Forms.TextBox();
            this.txtNewEPC = new System.Windows.Forms.TextBox();
            this.label27 = new System.Windows.Forms.Label();
            this.button13 = new System.Windows.Forms.Button();
            this.dgView = new System.Windows.Forms.DataGridView();
            this.C0 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.C1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.C2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.C3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.C4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.C5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.C6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.C7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.C8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.C9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.C10 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.C11 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.grpEPCSetProtect = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.radAdccessPwd = new System.Windows.Forms.RadioButton();
            this.radBankTID = new System.Windows.Forms.RadioButton();
            this.radBankUser = new System.Windows.Forms.RadioButton();
            this.radKillPwd = new System.Windows.Forms.RadioButton();
            this.radBankEPC = new System.Windows.Forms.RadioButton();
            this.label25 = new System.Windows.Forms.Label();
            this.cbxSetProtect = new System.Windows.Forms.ComboBox();
            this.label23 = new System.Windows.Forms.Label();
            this.btnSetProtect = new System.Windows.Forms.Button();
            this.txtSetProtectPw = new System.Windows.Forms.TextBox();
            this.grpMemOps = new System.Windows.Forms.GroupBox();
            this.btnTagKill = new System.Windows.Forms.Button();
            this.btnQuery = new System.Windows.Forms.Button();
            this.btnBlockErase = new System.Windows.Forms.Button();
            this.btnBlockWrite = new System.Windows.Forms.Button();
            this.btnBlockRead = new System.Windows.Forms.Button();
            this.txtBlockData = new System.Windows.Forms.TextBox();
            this.txtAccessPwdOps = new System.Windows.Forms.TextBox();
            this.txtTotalWords = new System.Windows.Forms.TextBox();
            this.txtWordAddress = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.radUserBank = new System.Windows.Forms.RadioButton();
            this.radTIDBank = new System.Windows.Forms.RadioButton();
            this.radReservedBank = new System.Windows.Forms.RadioButton();
            this.radEPCBank = new System.Windows.Forms.RadioButton();
            this.cbxUIDOps = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.grpInventorySetup = new System.Windows.Forms.GroupBox();
            this.groupBox26 = new System.Windows.Forms.GroupBox();
            this.label89 = new System.Windows.Forms.Label();
            this.btnExtInventory = new System.Windows.Forms.Button();
            this.chkAnt6 = new System.Windows.Forms.CheckBox();
            this.chkAnt5 = new System.Windows.Forms.CheckBox();
            this.chkAnt4 = new System.Windows.Forms.CheckBox();
            this.chkAnt3 = new System.Windows.Forms.CheckBox();
            this.chkAnt2 = new System.Windows.Forms.CheckBox();
            this.chkAnt1 = new System.Windows.Forms.CheckBox();
            this.label21 = new System.Windows.Forms.Label();
            this.tbUIDCont = new System.Windows.Forms.TextBox();
            this.chkIDReverse2 = new System.Windows.Forms.CheckBox();
            this.btn_BRMLogOps = new System.Windows.Forms.Button();
            this.radEPCOnly = new System.Windows.Forms.RadioButton();
            this.radTIDOnly = new System.Windows.Forms.RadioButton();
            this.radEPC_TID = new System.Windows.Forms.RadioButton();
            this.chkRSSI = new System.Windows.Forms.CheckBox();
            this.btnInventory = new System.Windows.Forms.Button();
            this.btnSetTarget = new System.Windows.Forms.Button();
            this.btnSetSession = new System.Windows.Forms.Button();
            this.btnSetQValue = new System.Windows.Forms.Button();
            this.btnGetTarget = new System.Windows.Forms.Button();
            this.btnGetSession = new System.Windows.Forms.Button();
            this.btnGetQValue = new System.Windows.Forms.Button();
            this.cbxInterval = new System.Windows.Forms.ComboBox();
            this.cbxQValue = new System.Windows.Forms.ComboBox();
            this.cbxTarget = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.cbxSession = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.grpExtInventory = new System.Windows.Forms.GroupBox();
            this.groupBox46 = new System.Windows.Forms.GroupBox();
            this.label90 = new System.Windows.Forms.Label();
            this.txtCycleTime = new System.Windows.Forms.TextBox();
            this.btnCycleTimeSet = new System.Windows.Forms.Button();
            this.btnCycleTimeGet = new System.Windows.Forms.Button();
            this.groupBox37 = new System.Windows.Forms.GroupBox();
            this.btnSetMuxConfig = new System.Windows.Forms.Button();
            this.btnGetMuxConfig = new System.Windows.Forms.Button();
            this.ChkExtAnt6 = new System.Windows.Forms.CheckBox();
            this.ChkExtAnt5 = new System.Windows.Forms.CheckBox();
            this.ChkExtAnt4 = new System.Windows.Forms.CheckBox();
            this.ChkExtAnt3 = new System.Windows.Forms.CheckBox();
            this.ChkExtAnt2 = new System.Windows.Forms.CheckBox();
            this.ChkExtAnt1 = new System.Windows.Forms.CheckBox();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.label40 = new System.Windows.Forms.Label();
            this.label39 = new System.Windows.Forms.Label();
            this.txtIO3_DwellTime = new System.Windows.Forms.TextBox();
            this.cbxIO3State = new System.Windows.Forms.ComboBox();
            this.btnExtInCfgFlagsGet = new System.Windows.Forms.Button();
            this.chkIncludeAntennaID = new System.Windows.Forms.CheckBox();
            this.chkBufferedReadMode = new System.Windows.Forms.CheckBox();
            this.chkReaderID = new System.Windows.Forms.CheckBox();
            this.txtHeartbeat2 = new System.Windows.Forms.TextBox();
            this.label56 = new System.Windows.Forms.Label();
            this.chkHeartbeatEn = new System.Windows.Forms.CheckBox();
            this.groupBox9 = new System.Windows.Forms.GroupBox();
            this.chkPersistanceAutoReset = new System.Windows.Forms.CheckBox();
            this.btnPersistenceSet = new System.Windows.Forms.Button();
            this.btnPersistenceGet = new System.Windows.Forms.Button();
            this.label48 = new System.Windows.Forms.Label();
            this.txtTagPersistenceTime = new System.Windows.Forms.TextBox();
            this.chkEPCPersistance = new System.Windows.Forms.CheckBox();
            this.btnGetInvCfg = new System.Windows.Forms.Button();
            this.btnSetInvCfg = new System.Windows.Forms.Button();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.label31 = new System.Windows.Forms.Label();
            this.txtUserMemBlockCount = new System.Windows.Forms.TextBox();
            this.label30 = new System.Windows.Forms.Label();
            this.txtEPCMask2 = new System.Windows.Forms.TextBox();
            this.txtAccessPwd2 = new System.Windows.Forms.TextBox();
            this.label28 = new System.Windows.Forms.Label();
            this.label29 = new System.Windows.Forms.Label();
            this.txtUserMemBlockAddress = new System.Windows.Forms.TextBox();
            this.chkInvOpsEnable = new System.Windows.Forms.CheckBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.label38 = new System.Windows.Forms.Label();
            this.label36 = new System.Windows.Forms.Label();
            this.label33 = new System.Windows.Forms.Label();
            this.txtIO2_DwellTime = new System.Windows.Forms.TextBox();
            this.cbxIO2State = new System.Windows.Forms.ComboBox();
            this.cbxIO2 = new System.Windows.Forms.ComboBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.label37 = new System.Windows.Forms.Label();
            this.label35 = new System.Windows.Forms.Label();
            this.label32 = new System.Windows.Forms.Label();
            this.txtIO1_DwellTime = new System.Windows.Forms.TextBox();
            this.cbxIO1State = new System.Windows.Forms.ComboBox();
            this.cbxIO1 = new System.Windows.Forms.ComboBox();
            this.chkReportTID = new System.Windows.Forms.CheckBox();
            this.chkIOPassEnable = new System.Windows.Forms.CheckBox();
            this.chkReportRSSI = new System.Windows.Forms.CheckBox();
            this.chkInvTriggerEnable = new System.Windows.Forms.CheckBox();
            this.chkIOFailEnable = new System.Windows.Forms.CheckBox();
            this.chkComplaintTags = new System.Windows.Forms.CheckBox();
            this.chkReportUserMem = new System.Windows.Forms.CheckBox();
            this.chkAccessPwd = new System.Windows.Forms.CheckBox();
            this.chkEPCMask = new System.Windows.Forms.CheckBox();
            this.grpExtInvRouteOptions = new System.Windows.Forms.GroupBox();
            this.radExtInvRespRouteToClient = new System.Windows.Forms.RadioButton();
            this.radExtInvRespRouteToServer = new System.Windows.Forms.RadioButton();
            this.btnExtAotuInventoryRespRouteSet = new System.Windows.Forms.Button();
            this.btnExtAotuInventoryRespRouteGet = new System.Windows.Forms.Button();
            this.chkMask9Enabled = new System.Windows.Forms.CheckBox();
            this.chkMask8Enabled = new System.Windows.Forms.CheckBox();
            this.chkMask7Enabled = new System.Windows.Forms.CheckBox();
            this.chkMask6Enabled = new System.Windows.Forms.CheckBox();
            this.chkMask5Enabled = new System.Windows.Forms.CheckBox();
            this.chkMask4Enabled = new System.Windows.Forms.CheckBox();
            this.chkMask3Enabled = new System.Windows.Forms.CheckBox();
            this.chkMask2Enabled = new System.Windows.Forms.CheckBox();
            this.chkMask1Enabled = new System.Windows.Forms.CheckBox();
            this.chkMask0Enabled = new System.Windows.Forms.CheckBox();
            this.btnMask9Erase = new System.Windows.Forms.Button();
            this.btnMask8Erase = new System.Windows.Forms.Button();
            this.btnMask7Erase = new System.Windows.Forms.Button();
            this.btnMask6Erase = new System.Windows.Forms.Button();
            this.btnMask5Erase = new System.Windows.Forms.Button();
            this.btnMask4Erase = new System.Windows.Forms.Button();
            this.btnMask3Erase = new System.Windows.Forms.Button();
            this.btnMask2Erase = new System.Windows.Forms.Button();
            this.btnMask1Erase = new System.Windows.Forms.Button();
            this.btnMask0Erase = new System.Windows.Forms.Button();
            this.label69 = new System.Windows.Forms.Label();
            this.label68 = new System.Windows.Forms.Label();
            this.label67 = new System.Windows.Forms.Label();
            this.label66 = new System.Windows.Forms.Label();
            this.label65 = new System.Windows.Forms.Label();
            this.label64 = new System.Windows.Forms.Label();
            this.label63 = new System.Windows.Forms.Label();
            this.label62 = new System.Windows.Forms.Label();
            this.label61 = new System.Windows.Forms.Label();
            this.label60 = new System.Windows.Forms.Label();
            this.chkMask9 = new System.Windows.Forms.CheckBox();
            this.SetMask9 = new System.Windows.Forms.Button();
            this.GetMask9 = new System.Windows.Forms.Button();
            this.txtMask9 = new System.Windows.Forms.TextBox();
            this.chkMask8 = new System.Windows.Forms.CheckBox();
            this.SetMask8 = new System.Windows.Forms.Button();
            this.GetMask8 = new System.Windows.Forms.Button();
            this.txtMask8 = new System.Windows.Forms.TextBox();
            this.chkMask7 = new System.Windows.Forms.CheckBox();
            this.SetMask7 = new System.Windows.Forms.Button();
            this.GetMask7 = new System.Windows.Forms.Button();
            this.txtMask7 = new System.Windows.Forms.TextBox();
            this.chkMask6 = new System.Windows.Forms.CheckBox();
            this.SetMask6 = new System.Windows.Forms.Button();
            this.GetMask6 = new System.Windows.Forms.Button();
            this.txtMask6 = new System.Windows.Forms.TextBox();
            this.chkMask5 = new System.Windows.Forms.CheckBox();
            this.SetMask5 = new System.Windows.Forms.Button();
            this.GetMask5 = new System.Windows.Forms.Button();
            this.txtMask5 = new System.Windows.Forms.TextBox();
            this.chkMask4 = new System.Windows.Forms.CheckBox();
            this.SetMask4 = new System.Windows.Forms.Button();
            this.GetMask4 = new System.Windows.Forms.Button();
            this.txtMask4 = new System.Windows.Forms.TextBox();
            this.chkMask3 = new System.Windows.Forms.CheckBox();
            this.SetMask3 = new System.Windows.Forms.Button();
            this.GetMask3 = new System.Windows.Forms.Button();
            this.txtMask3 = new System.Windows.Forms.TextBox();
            this.chkMask2 = new System.Windows.Forms.CheckBox();
            this.SetMask2 = new System.Windows.Forms.Button();
            this.GetMask2 = new System.Windows.Forms.Button();
            this.txtMask2 = new System.Windows.Forms.TextBox();
            this.chkMask1 = new System.Windows.Forms.CheckBox();
            this.SetMask1 = new System.Windows.Forms.Button();
            this.GetMask1 = new System.Windows.Forms.Button();
            this.txtMask1 = new System.Windows.Forms.TextBox();
            this.chkMask0 = new System.Windows.Forms.CheckBox();
            this.SetMask0 = new System.Windows.Forms.Button();
            this.GetMask0 = new System.Windows.Forms.Button();
            this.txtMask0 = new System.Windows.Forms.TextBox();
            this.groupBox13 = new System.Windows.Forms.GroupBox();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.groupBox45 = new System.Windows.Forms.GroupBox();
            this.btnLogDeviceSNConfSet = new System.Windows.Forms.Button();
            this.chkParkingmodeIncDeviceSNR = new System.Windows.Forms.CheckBox();
            this.btnLogDeviceSNConfGet = new System.Windows.Forms.Button();
            this.groupBox44 = new System.Windows.Forms.GroupBox();
            this.txtParkingmodeLoggedTIDCount = new System.Windows.Forms.TextBox();
            this.btnParkingmodeLogRead = new System.Windows.Forms.Button();
            this.btnParkingmodeGetLoggedTIDCount = new System.Windows.Forms.Button();
            this.groupBox27 = new System.Windows.Forms.GroupBox();
            this.radParmodeDataToTCP_Client = new System.Windows.Forms.RadioButton();
            this.radParmodeDataToTCP_Server = new System.Windows.Forms.RadioButton();
            this.btnParkingModeSetDataRouteConf = new System.Windows.Forms.Button();
            this.btnParkingModeGetDataRouteConf = new System.Windows.Forms.Button();
            this.groupBox25 = new System.Windows.Forms.GroupBox();
            this.chkParkModePersistenceAutoReset = new System.Windows.Forms.CheckBox();
            this.btnParkModePersistenceSet = new System.Windows.Forms.Button();
            this.btnParkModePersistenceGet = new System.Windows.Forms.Button();
            this.label51 = new System.Windows.Forms.Label();
            this.txtParkModePersistence = new System.Windows.Forms.TextBox();
            this.groupBox20 = new System.Windows.Forms.GroupBox();
            this.groupBox23 = new System.Windows.Forms.GroupBox();
            this.btnParkingmodeRecordTableReset = new System.Windows.Forms.Button();
            this.btnParkingmodeDataLogReset = new System.Windows.Forms.Button();
            this.groupBox22 = new System.Windows.Forms.GroupBox();
            this.radParkModeLogAll = new System.Windows.Forms.RadioButton();
            this.radParkmodeLogWLOnly = new System.Windows.Forms.RadioButton();
            this.btnParkingmodeSetOfflineLogCfg = new System.Windows.Forms.Button();
            this.btnParkingmodeGetOfflineLogCfg = new System.Windows.Forms.Button();
            this.groupBox19 = new System.Windows.Forms.GroupBox();
            this.btnRelayModeSet = new System.Windows.Forms.Button();
            this.btnRelayModeGet = new System.Windows.Forms.Button();
            this.label86 = new System.Windows.Forms.Label();
            this.label84 = new System.Windows.Forms.Label();
            this.label82 = new System.Windows.Forms.Label();
            this.txtRelay4OnTime = new System.Windows.Forms.TextBox();
            this.label80 = new System.Windows.Forms.Label();
            this.label85 = new System.Windows.Forms.Label();
            this.txtRelay3OnTime = new System.Windows.Forms.TextBox();
            this.txtRelay2OnTime = new System.Windows.Forms.TextBox();
            this.label83 = new System.Windows.Forms.Label();
            this.label81 = new System.Windows.Forms.Label();
            this.label79 = new System.Windows.Forms.Label();
            this.txtRelay1OnTime = new System.Windows.Forms.TextBox();
            this.label78 = new System.Windows.Forms.Label();
            this.groupBox18 = new System.Windows.Forms.GroupBox();
            this.btnParkModeCatConfSet = new System.Windows.Forms.Button();
            this.btnParkModeCatConfGet = new System.Windows.Forms.Button();
            this.chkCat4R4 = new System.Windows.Forms.CheckBox();
            this.chkCat3R4 = new System.Windows.Forms.CheckBox();
            this.chkCat4R3 = new System.Windows.Forms.CheckBox();
            this.chkCat4R2 = new System.Windows.Forms.CheckBox();
            this.chkCat2R4 = new System.Windows.Forms.CheckBox();
            this.chkCat4R1 = new System.Windows.Forms.CheckBox();
            this.chkCat3R3 = new System.Windows.Forms.CheckBox();
            this.chkCat2R3 = new System.Windows.Forms.CheckBox();
            this.chkCat3R2 = new System.Windows.Forms.CheckBox();
            this.chkCat3R1 = new System.Windows.Forms.CheckBox();
            this.chkCat2R2 = new System.Windows.Forms.CheckBox();
            this.chkCat2R1 = new System.Windows.Forms.CheckBox();
            this.chkCat1R4 = new System.Windows.Forms.CheckBox();
            this.chkCat1R3 = new System.Windows.Forms.CheckBox();
            this.chkCat1R2 = new System.Windows.Forms.CheckBox();
            this.chkCat1R1 = new System.Windows.Forms.CheckBox();
            this.label77 = new System.Windows.Forms.Label();
            this.label76 = new System.Windows.Forms.Label();
            this.label75 = new System.Windows.Forms.Label();
            this.label74 = new System.Windows.Forms.Label();
            this.groupBox16 = new System.Windows.Forms.GroupBox();
            this.btnParkmodeDeleteExistingRecord = new System.Windows.Forms.Button();
            this.btnParkmodeUpdateExistingRecord = new System.Windows.Forms.Button();
            this.groupBox17 = new System.Windows.Forms.GroupBox();
            this.chkRecordIsWhitelist = new System.Windows.Forms.RadioButton();
            this.chkRecordIsBlacklist = new System.Windows.Forms.RadioButton();
            this.chkCat4 = new System.Windows.Forms.RadioButton();
            this.chkCat3 = new System.Windows.Forms.RadioButton();
            this.label73 = new System.Windows.Forms.Label();
            this.chkCat2 = new System.Windows.Forms.RadioButton();
            this.btnParkingModeCheckForEntry = new System.Windows.Forms.Button();
            this.chkCat1 = new System.Windows.Forms.RadioButton();
            this.label72 = new System.Windows.Forms.Label();
            this.txtParkmodeRecordToCheck = new System.Windows.Forms.TextBox();
            this.groupBox15 = new System.Windows.Forms.GroupBox();
            this.btnParkModeReadAllrecords = new System.Windows.Forms.Button();
            this.btnParkModeCheckTagEntries = new System.Windows.Forms.Button();
            this.label71 = new System.Windows.Forms.Label();
            this.txtParkModeBlacklistRecordsCounter = new System.Windows.Forms.TextBox();
            this.txtParkModeWhitelistRecordsCounter = new System.Windows.Forms.TextBox();
            this.label70 = new System.Windows.Forms.Label();
            this.groupBox14 = new System.Windows.Forms.GroupBox();
            this.chkParkmodeAutoRegister = new System.Windows.Forms.CheckBox();
            this.btnLoadFromCSV = new System.Windows.Forms.Button();
            this.btnParkModeEPC_Query = new System.Windows.Forms.Button();
            this.chkParkModeTagWhitelistEnable = new System.Windows.Forms.CheckBox();
            this.radParkModeCat4 = new System.Windows.Forms.RadioButton();
            this.radParkModeCat3 = new System.Windows.Forms.RadioButton();
            this.radParkModeCat2 = new System.Windows.Forms.RadioButton();
            this.radParkModeCat1 = new System.Windows.Forms.RadioButton();
            this.label50 = new System.Windows.Forms.Label();
            this.btnParkModeTagRegister = new System.Windows.Forms.Button();
            this.label34 = new System.Windows.Forms.Label();
            this.txtParkingmodeEPCtoRegister = new System.Windows.Forms.TextBox();
            this.tabPage5 = new System.Windows.Forms.TabPage();
            this.txtRSSIAvg = new System.Windows.Forms.TextBox();
            this.txtRSSINow = new System.Windows.Forms.TextBox();
            this.cbxCurrentFreq = new System.Windows.Forms.ComboBox();
            this.btnRFDiagnosisCtrl = new System.Windows.Forms.Button();
            this.zedGraphControl1 = new ZedGraph.ZedGraphControl();
            this.tabPage6 = new System.Windows.Forms.TabPage();
            this.chkIDReverse = new System.Windows.Forms.CheckBox();
            this.btnDeviceSearch = new System.Windows.Forms.Button();
            this.dgDeviceList = new System.Windows.Forms.DataGridView();
            this.col_1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabPage7 = new System.Windows.Forms.TabPage();
            this.chkDeviceIDReverse1 = new System.Windows.Forms.CheckBox();
            this.txtTimeDiff = new System.Windows.Forms.TextBox();
            this.label57 = new System.Windows.Forms.Label();
            this.txtTagCount = new System.Windows.Forms.TextBox();
            this.label58 = new System.Windows.Forms.Label();
            this.btnTcpServerClearList = new System.Windows.Forms.Button();
            this.lvData = new System.Windows.Forms.ListView();
            this.DevID = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.EPC = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ReadCnt = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.TimeStamp = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.TimeStampLogged = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.IsActiveID = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnTcpServerLogClear = new System.Windows.Forms.Button();
            this.txtLog = new System.Windows.Forms.TextBox();
            this.btnTcpServerStartStop = new System.Windows.Forms.Button();
            this.label59 = new System.Windows.Forms.Label();
            this.txtPortTcpServer = new System.Windows.Forms.TextBox();
            this.tabPage9 = new System.Windows.Forms.TabPage();
            this.groupBox24 = new System.Windows.Forms.GroupBox();
            this.lblDiagFrameVersion = new System.Windows.Forms.Label();
            this.label87 = new System.Windows.Forms.Label();
            this.groupBox43 = new System.Windows.Forms.GroupBox();
            this.btnDiagResetAllCnt = new System.Windows.Forms.Button();
            this.btnDiagScan = new System.Windows.Forms.Button();
            this.label119 = new System.Windows.Forms.Label();
            this.txtScanFrequency = new System.Windows.Forms.TextBox();
            this.groupBox42 = new System.Windows.Forms.GroupBox();
            this.label133 = new System.Windows.Forms.Label();
            this.txtGlobalCallbackCount = new System.Windows.Forms.TextBox();
            this.label122 = new System.Windows.Forms.Label();
            this.label117 = new System.Windows.Forms.Label();
            this.txtActiveSocketCounts = new System.Windows.Forms.TextBox();
            this.label118 = new System.Windows.Forms.Label();
            this.txtPHY_NokPacketCounts = new System.Windows.Forms.TextBox();
            this.txtPHY_OkPacketCounts = new System.Windows.Forms.TextBox();
            this.txtPHYLinkStateDuration = new System.Windows.Forms.TextBox();
            this.label116 = new System.Windows.Forms.Label();
            this.txtPHYLinkState = new System.Windows.Forms.TextBox();
            this.label115 = new System.Windows.Forms.Label();
            this.groupBox40 = new System.Windows.Forms.GroupBox();
            this.label41 = new System.Windows.Forms.Label();
            this.txtTIDScanTimeMsec = new System.Windows.Forms.TextBox();
            this.groupBox41 = new System.Windows.Forms.GroupBox();
            this.chkPHYHardFault = new System.Windows.Forms.CheckBox();
            this.chkEEPFault = new System.Windows.Forms.CheckBox();
            this.chkRFHardFault = new System.Windows.Forms.CheckBox();
            this.label114 = new System.Windows.Forms.Label();
            this.label113 = new System.Windows.Forms.Label();
            this.txtRFErrorCount = new System.Windows.Forms.TextBox();
            this.txtRFErrorCode = new System.Windows.Forms.TextBox();
            this.label112 = new System.Windows.Forms.Label();
            this.label111 = new System.Windows.Forms.Label();
            this.label110 = new System.Windows.Forms.Label();
            this.txtLastCmdExecDuration = new System.Windows.Forms.TextBox();
            this.txtLastCmdErrorCode = new System.Windows.Forms.TextBox();
            this.txtLastCmdCode = new System.Windows.Forms.TextBox();
            this.label109 = new System.Windows.Forms.Label();
            this.txtDeviceDuration = new System.Windows.Forms.TextBox();
            this.groupBox39 = new System.Windows.Forms.GroupBox();
            this.label132 = new System.Windows.Forms.Label();
            this.label130 = new System.Windows.Forms.Label();
            this.txtClientAppCallCount = new System.Windows.Forms.TextBox();
            this.txtClientUStateCount = new System.Windows.Forms.TextBox();
            this.label129 = new System.Windows.Forms.Label();
            this.txtClientUnknownState = new System.Windows.Forms.TextBox();
            this.label125 = new System.Windows.Forms.Label();
            this.txtCPort = new System.Windows.Forms.TextBox();
            this.label126 = new System.Windows.Forms.Label();
            this.txtRPort = new System.Windows.Forms.TextBox();
            this.label121 = new System.Windows.Forms.Label();
            this.txtMemFailEventCounts = new System.Windows.Forms.TextBox();
            this.label120 = new System.Windows.Forms.Label();
            this.label100 = new System.Windows.Forms.Label();
            this.txtClientResetEcentCount = new System.Windows.Forms.TextBox();
            this.label101 = new System.Windows.Forms.Label();
            this.label102 = new System.Windows.Forms.Label();
            this.label103 = new System.Windows.Forms.Label();
            this.label104 = new System.Windows.Forms.Label();
            this.label105 = new System.Windows.Forms.Label();
            this.label106 = new System.Windows.Forms.Label();
            this.txtClientTimedoutCount = new System.Windows.Forms.TextBox();
            this.txtClientStateDuration = new System.Windows.Forms.TextBox();
            this.txtClientClosedCount = new System.Windows.Forms.TextBox();
            this.label107 = new System.Windows.Forms.Label();
            this.txtClientAbortedCount = new System.Windows.Forms.TextBox();
            this.txtClientDataACKCount = new System.Windows.Forms.TextBox();
            this.txtClientState = new System.Windows.Forms.TextBox();
            this.txtClientDataTxCount = new System.Windows.Forms.TextBox();
            this.label108 = new System.Windows.Forms.Label();
            this.txtClientDataRxCount = new System.Windows.Forms.TextBox();
            this.txtClientConnectCount = new System.Windows.Forms.TextBox();
            this.groupBox38 = new System.Windows.Forms.GroupBox();
            this.label131 = new System.Windows.Forms.Label();
            this.txtServerAppCallCount = new System.Windows.Forms.TextBox();
            this.label128 = new System.Windows.Forms.Label();
            this.txtServerUStateCount = new System.Windows.Forms.TextBox();
            this.label127 = new System.Windows.Forms.Label();
            this.txtServerUnknownState = new System.Windows.Forms.TextBox();
            this.label123 = new System.Windows.Forms.Label();
            this.label124 = new System.Windows.Forms.Label();
            this.txtSPort = new System.Windows.Forms.TextBox();
            this.txtLPort = new System.Windows.Forms.TextBox();
            this.label99 = new System.Windows.Forms.Label();
            this.label98 = new System.Windows.Forms.Label();
            this.label97 = new System.Windows.Forms.Label();
            this.label96 = new System.Windows.Forms.Label();
            this.label95 = new System.Windows.Forms.Label();
            this.label94 = new System.Windows.Forms.Label();
            this.label93 = new System.Windows.Forms.Label();
            this.txtServerTimedoutCount = new System.Windows.Forms.TextBox();
            this.txtServerStateDuration = new System.Windows.Forms.TextBox();
            this.txtServerClosedCount = new System.Windows.Forms.TextBox();
            this.label92 = new System.Windows.Forms.Label();
            this.txtServerAbortedCount = new System.Windows.Forms.TextBox();
            this.txtServerDataACKCount = new System.Windows.Forms.TextBox();
            this.txtServerState = new System.Windows.Forms.TextBox();
            this.txtServerDataTxCount = new System.Windows.Forms.TextBox();
            this.label91 = new System.Windows.Forms.Label();
            this.txtServerDataRxCount = new System.Windows.Forms.TextBox();
            this.txtServerConnectCount = new System.Windows.Forms.TextBox();
            this.btnRtbClear = new System.Windows.Forms.Button();
            this.rtbLog = new System.Windows.Forms.RichTextBox();
            this.tmrEPCInventory = new System.Windows.Forms.Timer(this.components);
            this.tmrTCPClient = new System.Windows.Forms.Timer(this.components);
            this.tmrRFDiagnosis = new System.Windows.Forms.Timer(this.components);
            this.tmrServerTasks = new System.Windows.Forms.Timer(this.components);
            this.tmrGetLoggedData = new System.Windows.Forms.Timer(this.components);
            this.tmrGetParkingModeRecords = new System.Windows.Forms.Timer(this.components);
            this.tmrGetBRMLogs = new System.Windows.Forms.Timer(this.components);
            this.tmrDiagScan = new System.Windows.Forms.Timer(this.components);
            this.tmrEPC_Timeout = new System.Windows.Forms.Timer(this.components);
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.grpCommSetup.SuspendLayout();
            this.grpTCP.SuspendLayout();
            this.grpCOM.SuspendLayout();
            this.tabCtrl.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.groupBox21.SuspendLayout();
            this.groupBox12.SuspendLayout();
            this.groupBox11.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox8.SuspendLayout();
            this.groupBox10.SuspendLayout();
            this.gbRFSetup.SuspendLayout();
            this.groupBox36.SuspendLayout();
            this.groupBox35.SuspendLayout();
            this.groupBox34.SuspendLayout();
            this.groupBox32.SuspendLayout();
            this.groupBox33.SuspendLayout();
            this.groupBox31.SuspendLayout();
            this.groupBox30.SuspendLayout();
            this.groupBox29.SuspendLayout();
            this.groupBox28.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.grpEPCWrite.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgView)).BeginInit();
            this.grpEPCSetProtect.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.grpMemOps.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.grpInventorySetup.SuspendLayout();
            this.groupBox26.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.grpExtInventory.SuspendLayout();
            this.groupBox46.SuspendLayout();
            this.groupBox37.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.groupBox9.SuspendLayout();
            this.groupBox7.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.grpExtInvRouteOptions.SuspendLayout();
            this.tabPage4.SuspendLayout();
            this.groupBox45.SuspendLayout();
            this.groupBox44.SuspendLayout();
            this.groupBox27.SuspendLayout();
            this.groupBox25.SuspendLayout();
            this.groupBox20.SuspendLayout();
            this.groupBox23.SuspendLayout();
            this.groupBox22.SuspendLayout();
            this.groupBox19.SuspendLayout();
            this.groupBox18.SuspendLayout();
            this.groupBox16.SuspendLayout();
            this.groupBox17.SuspendLayout();
            this.groupBox15.SuspendLayout();
            this.groupBox14.SuspendLayout();
            this.tabPage5.SuspendLayout();
            this.tabPage6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgDeviceList)).BeginInit();
            this.tabPage7.SuspendLayout();
            this.tabPage9.SuspendLayout();
            this.groupBox24.SuspendLayout();
            this.groupBox43.SuspendLayout();
            this.groupBox42.SuspendLayout();
            this.groupBox40.SuspendLayout();
            this.groupBox41.SuspendLayout();
            this.groupBox39.SuspendLayout();
            this.groupBox38.SuspendLayout();
            this.SuspendLayout();
            // 
            // grpCommSetup
            // 
            this.grpCommSetup.Controls.Add(this.btnConnect);
            this.grpCommSetup.Controls.Add(this.radSelectTCP);
            this.grpCommSetup.Controls.Add(this.radSelectCOMPort);
            this.grpCommSetup.Controls.Add(this.grpTCP);
            this.grpCommSetup.Controls.Add(this.grpCOM);
            this.grpCommSetup.Location = new System.Drawing.Point(6, 6);
            this.grpCommSetup.Name = "grpCommSetup";
            this.grpCommSetup.Size = new System.Drawing.Size(213, 282);
            this.grpCommSetup.TabIndex = 0;
            this.grpCommSetup.TabStop = false;
            this.grpCommSetup.Text = "Communication setup";
            // 
            // btnConnect
            // 
            this.btnConnect.Location = new System.Drawing.Point(6, 254);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(200, 23);
            this.btnConnect.TabIndex = 10;
            this.btnConnect.Tag = "0";
            this.btnConnect.Text = "Connect";
            this.btnConnect.UseVisualStyleBackColor = true;
            this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
            // 
            // radSelectTCP
            // 
            this.radSelectTCP.AutoSize = true;
            this.radSelectTCP.Location = new System.Drawing.Point(139, 19);
            this.radSelectTCP.Name = "radSelectTCP";
            this.radSelectTCP.Size = new System.Drawing.Size(61, 17);
            this.radSelectTCP.TabIndex = 1;
            this.radSelectTCP.TabStop = true;
            this.radSelectTCP.Text = "TCP/IP";
            this.radSelectTCP.UseVisualStyleBackColor = true;
            this.radSelectTCP.CheckedChanged += new System.EventHandler(this.radSelectTCP_CheckedChanged);
            // 
            // radSelectCOMPort
            // 
            this.radSelectCOMPort.AutoSize = true;
            this.radSelectCOMPort.Location = new System.Drawing.Point(6, 19);
            this.radSelectCOMPort.Name = "radSelectCOMPort";
            this.radSelectCOMPort.Size = new System.Drawing.Size(71, 17);
            this.radSelectCOMPort.TabIndex = 1;
            this.radSelectCOMPort.TabStop = true;
            this.radSelectCOMPort.Text = "COM Port";
            this.radSelectCOMPort.UseVisualStyleBackColor = true;
            this.radSelectCOMPort.CheckedChanged += new System.EventHandler(this.radSelectCOMPort_CheckedChanged);
            // 
            // grpTCP
            // 
            this.grpTCP.Controls.Add(this.radTCPClient);
            this.grpTCP.Controls.Add(this.radTCPServer);
            this.grpTCP.Controls.Add(this.label4);
            this.grpTCP.Controls.Add(this.txtDevicIP);
            this.grpTCP.Controls.Add(this.label3);
            this.grpTCP.Controls.Add(this.txtTCP_Port);
            this.grpTCP.Location = new System.Drawing.Point(6, 148);
            this.grpTCP.Name = "grpTCP";
            this.grpTCP.Size = new System.Drawing.Size(200, 100);
            this.grpTCP.TabIndex = 0;
            this.grpTCP.TabStop = false;
            this.grpTCP.Text = "TCP/IP";
            // 
            // radTCPClient
            // 
            this.radTCPClient.AutoSize = true;
            this.radTCPClient.Location = new System.Drawing.Point(119, 74);
            this.radTCPClient.Name = "radTCPClient";
            this.radTCPClient.Size = new System.Drawing.Size(75, 17);
            this.radTCPClient.TabIndex = 10;
            this.radTCPClient.TabStop = true;
            this.radTCPClient.Text = "TCP Client";
            this.radTCPClient.UseVisualStyleBackColor = true;
            // 
            // radTCPServer
            // 
            this.radTCPServer.AutoSize = true;
            this.radTCPServer.Location = new System.Drawing.Point(6, 74);
            this.radTCPServer.Name = "radTCPServer";
            this.radTCPServer.Size = new System.Drawing.Size(80, 17);
            this.radTCPServer.TabIndex = 9;
            this.radTCPServer.TabStop = true;
            this.radTCPServer.Text = "TCP Server";
            this.radTCPServer.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(15, 51);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "TCP Port:";
            // 
            // txtDevicIP
            // 
            this.txtDevicIP.Location = new System.Drawing.Point(73, 19);
            this.txtDevicIP.Name = "txtDevicIP";
            this.txtDevicIP.Size = new System.Drawing.Size(121, 20);
            this.txtDevicIP.TabIndex = 5;
            this.txtDevicIP.Text = "192.168.1.32";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 22);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(57, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Device IP:";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // txtTCP_Port
            // 
            this.txtTCP_Port.Location = new System.Drawing.Point(73, 48);
            this.txtTCP_Port.Name = "txtTCP_Port";
            this.txtTCP_Port.Size = new System.Drawing.Size(121, 20);
            this.txtTCP_Port.TabIndex = 6;
            this.txtTCP_Port.Text = "6000";
            // 
            // grpCOM
            // 
            this.grpCOM.Controls.Add(this.cbxBaudRate);
            this.grpCOM.Controls.Add(this.label2);
            this.grpCOM.Controls.Add(this.label1);
            this.grpCOM.Controls.Add(this.cbxSerPort);
            this.grpCOM.Location = new System.Drawing.Point(6, 42);
            this.grpCOM.Name = "grpCOM";
            this.grpCOM.Size = new System.Drawing.Size(200, 100);
            this.grpCOM.TabIndex = 9;
            this.grpCOM.TabStop = false;
            this.grpCOM.Text = "COM port";
            // 
            // cbxBaudRate
            // 
            this.cbxBaudRate.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxBaudRate.FormattingEnabled = true;
            this.cbxBaudRate.Location = new System.Drawing.Point(73, 62);
            this.cbxBaudRate.Name = "cbxBaudRate";
            this.cbxBaudRate.Size = new System.Drawing.Size(121, 21);
            this.cbxBaudRate.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 70);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Baudrate:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "COM Port:";
            // 
            // cbxSerPort
            // 
            this.cbxSerPort.AllowDrop = true;
            this.cbxSerPort.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxSerPort.FormattingEnabled = true;
            this.cbxSerPort.Location = new System.Drawing.Point(73, 19);
            this.cbxSerPort.Name = "cbxSerPort";
            this.cbxSerPort.Size = new System.Drawing.Size(121, 21);
            this.cbxSerPort.TabIndex = 1;
            // 
            // tabCtrl
            // 
            this.tabCtrl.Controls.Add(this.tabPage1);
            this.tabCtrl.Controls.Add(this.tabPage2);
            this.tabCtrl.Controls.Add(this.tabPage3);
            this.tabCtrl.Controls.Add(this.tabPage4);
            this.tabCtrl.Controls.Add(this.tabPage5);
            this.tabCtrl.Controls.Add(this.tabPage6);
            this.tabCtrl.Controls.Add(this.tabPage7);
            this.tabCtrl.Controls.Add(this.tabPage9);
            this.tabCtrl.Location = new System.Drawing.Point(12, 12);
            this.tabCtrl.Name = "tabCtrl";
            this.tabCtrl.SelectedIndex = 0;
            this.tabCtrl.Size = new System.Drawing.Size(993, 647);
            this.tabCtrl.TabIndex = 1;
            this.tabCtrl.SelectedIndexChanged += new System.EventHandler(this.tabCtrl_SelectedIndexChanged);
            this.tabCtrl.Click += new System.EventHandler(this.tabCtrl_Click);
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.groupBox21);
            this.tabPage1.Controls.Add(this.groupBox12);
            this.tabPage1.Controls.Add(this.groupBox11);
            this.tabPage1.Controls.Add(this.groupBox1);
            this.tabPage1.Controls.Add(this.groupBox8);
            this.tabPage1.Controls.Add(this.groupBox10);
            this.tabPage1.Controls.Add(this.gbRFSetup);
            this.tabPage1.Controls.Add(this.grpCommSetup);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(985, 621);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Reader Config.";
            this.tabPage1.UseVisualStyleBackColor = true;
            this.tabPage1.Click += new System.EventHandler(this.tabPage1_Click);
            // 
            // groupBox21
            // 
            this.groupBox21.Controls.Add(this.label22);
            this.groupBox21.Controls.Add(this.btnMuxConfSet);
            this.groupBox21.Controls.Add(this.btnMuxConfGet);
            this.groupBox21.Controls.Add(this.cbxMuxPort);
            this.groupBox21.Location = new System.Drawing.Point(328, 445);
            this.groupBox21.Name = "groupBox21";
            this.groupBox21.Size = new System.Drawing.Size(130, 144);
            this.groupBox21.TabIndex = 125;
            this.groupBox21.TabStop = false;
            this.groupBox21.Text = "Mux. Antenna Port";
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(14, 36);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(78, 13);
            this.label22.TabIndex = 127;
            this.label22.Text = "Multiplexer port";
            // 
            // btnMuxConfSet
            // 
            this.btnMuxConfSet.Location = new System.Drawing.Point(70, 101);
            this.btnMuxConfSet.Name = "btnMuxConfSet";
            this.btnMuxConfSet.Size = new System.Drawing.Size(54, 23);
            this.btnMuxConfSet.TabIndex = 126;
            this.btnMuxConfSet.Text = "Set";
            this.btnMuxConfSet.UseVisualStyleBackColor = true;
            this.btnMuxConfSet.Click += new System.EventHandler(this.btnMuxConfSet_Click);
            // 
            // btnMuxConfGet
            // 
            this.btnMuxConfGet.Location = new System.Drawing.Point(9, 101);
            this.btnMuxConfGet.Name = "btnMuxConfGet";
            this.btnMuxConfGet.Size = new System.Drawing.Size(54, 23);
            this.btnMuxConfGet.TabIndex = 126;
            this.btnMuxConfGet.Text = "Get";
            this.btnMuxConfGet.UseVisualStyleBackColor = true;
            this.btnMuxConfGet.Click += new System.EventHandler(this.btnMuxConfGet_Click);
            // 
            // cbxMuxPort
            // 
            this.cbxMuxPort.FormattingEnabled = true;
            this.cbxMuxPort.Location = new System.Drawing.Point(9, 57);
            this.cbxMuxPort.Name = "cbxMuxPort";
            this.cbxMuxPort.Size = new System.Drawing.Size(115, 21);
            this.cbxMuxPort.TabIndex = 0;
            // 
            // groupBox12
            // 
            this.groupBox12.Controls.Add(this.chkRelay4);
            this.groupBox12.Controls.Add(this.chkRelay3);
            this.groupBox12.Controls.Add(this.btnRelaysSet);
            this.groupBox12.Controls.Add(this.chkRelay2);
            this.groupBox12.Controls.Add(this.chkRelay1);
            this.groupBox12.Location = new System.Drawing.Point(169, 445);
            this.groupBox12.Name = "groupBox12";
            this.groupBox12.Size = new System.Drawing.Size(153, 144);
            this.groupBox12.TabIndex = 124;
            this.groupBox12.TabStop = false;
            this.groupBox12.Text = "Relay Control(Fixed)";
            // 
            // chkRelay4
            // 
            this.chkRelay4.AutoSize = true;
            this.chkRelay4.Location = new System.Drawing.Point(6, 101);
            this.chkRelay4.Name = "chkRelay4";
            this.chkRelay4.Size = new System.Drawing.Size(62, 17);
            this.chkRelay4.TabIndex = 126;
            this.chkRelay4.Text = "Relay-4";
            this.chkRelay4.UseVisualStyleBackColor = true;
            // 
            // chkRelay3
            // 
            this.chkRelay3.AutoSize = true;
            this.chkRelay3.Location = new System.Drawing.Point(6, 78);
            this.chkRelay3.Name = "chkRelay3";
            this.chkRelay3.Size = new System.Drawing.Size(62, 17);
            this.chkRelay3.TabIndex = 125;
            this.chkRelay3.Text = "Relay-3";
            this.chkRelay3.UseVisualStyleBackColor = true;
            // 
            // btnRelaysSet
            // 
            this.btnRelaysSet.Location = new System.Drawing.Point(80, 34);
            this.btnRelaysSet.Name = "btnRelaysSet";
            this.btnRelaysSet.Size = new System.Drawing.Size(60, 82);
            this.btnRelaysSet.TabIndex = 123;
            this.btnRelaysSet.Text = "Set";
            this.btnRelaysSet.UseVisualStyleBackColor = true;
            this.btnRelaysSet.Click += new System.EventHandler(this.btnRelaysSet_Click);
            // 
            // chkRelay2
            // 
            this.chkRelay2.AutoSize = true;
            this.chkRelay2.Location = new System.Drawing.Point(6, 57);
            this.chkRelay2.Name = "chkRelay2";
            this.chkRelay2.Size = new System.Drawing.Size(62, 17);
            this.chkRelay2.TabIndex = 124;
            this.chkRelay2.Text = "Relay-2";
            this.chkRelay2.UseVisualStyleBackColor = true;
            // 
            // chkRelay1
            // 
            this.chkRelay1.AutoSize = true;
            this.chkRelay1.Location = new System.Drawing.Point(6, 34);
            this.chkRelay1.Name = "chkRelay1";
            this.chkRelay1.Size = new System.Drawing.Size(62, 17);
            this.chkRelay1.TabIndex = 123;
            this.chkRelay1.Text = "Relay-1";
            this.chkRelay1.UseVisualStyleBackColor = true;
            // 
            // groupBox11
            // 
            this.groupBox11.Controls.Add(this.btnRelay4Trigger);
            this.groupBox11.Controls.Add(this.btnRelay3Trigger);
            this.groupBox11.Controls.Add(this.label19);
            this.groupBox11.Controls.Add(this.label20);
            this.groupBox11.Controls.Add(this.txtIRelay4Timeout);
            this.groupBox11.Controls.Add(this.txtIRelay3Timeout);
            this.groupBox11.Controls.Add(this.btnRelay2Trigger);
            this.groupBox11.Controls.Add(this.btnRelay1Trigger);
            this.groupBox11.Controls.Add(this.label54);
            this.groupBox11.Controls.Add(this.label53);
            this.groupBox11.Controls.Add(this.txtIRelay2Timeout);
            this.groupBox11.Controls.Add(this.txtIRelay1Timeout);
            this.groupBox11.Controls.Add(this.label52);
            this.groupBox11.Location = new System.Drawing.Point(6, 445);
            this.groupBox11.Name = "groupBox11";
            this.groupBox11.Size = new System.Drawing.Size(157, 144);
            this.groupBox11.TabIndex = 123;
            this.groupBox11.TabStop = false;
            this.groupBox11.Text = "Relay Control (Oneshot)";
            // 
            // btnRelay4Trigger
            // 
            this.btnRelay4Trigger.Location = new System.Drawing.Point(100, 113);
            this.btnRelay4Trigger.Name = "btnRelay4Trigger";
            this.btnRelay4Trigger.Size = new System.Drawing.Size(38, 22);
            this.btnRelay4Trigger.TabIndex = 131;
            this.btnRelay4Trigger.Text = "Set";
            this.btnRelay4Trigger.UseVisualStyleBackColor = true;
            this.btnRelay4Trigger.Click += new System.EventHandler(this.btnRelay4Trigger_Click);
            // 
            // btnRelay3Trigger
            // 
            this.btnRelay3Trigger.Location = new System.Drawing.Point(100, 86);
            this.btnRelay3Trigger.Name = "btnRelay3Trigger";
            this.btnRelay3Trigger.Size = new System.Drawing.Size(38, 22);
            this.btnRelay3Trigger.TabIndex = 128;
            this.btnRelay3Trigger.Text = "Set";
            this.btnRelay3Trigger.UseVisualStyleBackColor = true;
            this.btnRelay3Trigger.Click += new System.EventHandler(this.btnRelay3Trigger_Click);
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(6, 114);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(43, 13);
            this.label19.TabIndex = 130;
            this.label19.Text = "Relay-4";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(7, 91);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(43, 13);
            this.label20.TabIndex = 129;
            this.label20.Text = "Relay-3";
            // 
            // txtIRelay4Timeout
            // 
            this.txtIRelay4Timeout.Location = new System.Drawing.Point(56, 114);
            this.txtIRelay4Timeout.MaxLength = 8;
            this.txtIRelay4Timeout.Name = "txtIRelay4Timeout";
            this.txtIRelay4Timeout.Size = new System.Drawing.Size(38, 20);
            this.txtIRelay4Timeout.TabIndex = 127;
            this.txtIRelay4Timeout.Text = "10";
            // 
            // txtIRelay3Timeout
            // 
            this.txtIRelay3Timeout.Location = new System.Drawing.Point(56, 88);
            this.txtIRelay3Timeout.MaxLength = 8;
            this.txtIRelay3Timeout.Name = "txtIRelay3Timeout";
            this.txtIRelay3Timeout.Size = new System.Drawing.Size(38, 20);
            this.txtIRelay3Timeout.TabIndex = 126;
            this.txtIRelay3Timeout.Text = "10";
            // 
            // btnRelay2Trigger
            // 
            this.btnRelay2Trigger.Location = new System.Drawing.Point(100, 61);
            this.btnRelay2Trigger.Name = "btnRelay2Trigger";
            this.btnRelay2Trigger.Size = new System.Drawing.Size(38, 22);
            this.btnRelay2Trigger.TabIndex = 125;
            this.btnRelay2Trigger.Text = "Set";
            this.btnRelay2Trigger.UseVisualStyleBackColor = true;
            this.btnRelay2Trigger.Click += new System.EventHandler(this.btnRelay2Trigger_Click);
            // 
            // btnRelay1Trigger
            // 
            this.btnRelay1Trigger.Location = new System.Drawing.Point(100, 34);
            this.btnRelay1Trigger.Name = "btnRelay1Trigger";
            this.btnRelay1Trigger.Size = new System.Drawing.Size(38, 22);
            this.btnRelay1Trigger.TabIndex = 122;
            this.btnRelay1Trigger.Text = "Set";
            this.btnRelay1Trigger.UseVisualStyleBackColor = true;
            this.btnRelay1Trigger.Click += new System.EventHandler(this.btnRelay1Trigger_Click);
            // 
            // label54
            // 
            this.label54.AutoSize = true;
            this.label54.Location = new System.Drawing.Point(6, 65);
            this.label54.Name = "label54";
            this.label54.Size = new System.Drawing.Size(43, 13);
            this.label54.TabIndex = 123;
            this.label54.Text = "Relay-2";
            // 
            // label53
            // 
            this.label53.AutoSize = true;
            this.label53.Location = new System.Drawing.Point(6, 39);
            this.label53.Name = "label53";
            this.label53.Size = new System.Drawing.Size(43, 13);
            this.label53.TabIndex = 122;
            this.label53.Text = "Relay-1";
            // 
            // txtIRelay2Timeout
            // 
            this.txtIRelay2Timeout.Location = new System.Drawing.Point(56, 62);
            this.txtIRelay2Timeout.MaxLength = 8;
            this.txtIRelay2Timeout.Name = "txtIRelay2Timeout";
            this.txtIRelay2Timeout.Size = new System.Drawing.Size(38, 20);
            this.txtIRelay2Timeout.TabIndex = 28;
            this.txtIRelay2Timeout.Text = "10";
            // 
            // txtIRelay1Timeout
            // 
            this.txtIRelay1Timeout.Location = new System.Drawing.Point(56, 36);
            this.txtIRelay1Timeout.MaxLength = 8;
            this.txtIRelay1Timeout.Name = "txtIRelay1Timeout";
            this.txtIRelay1Timeout.Size = new System.Drawing.Size(38, 20);
            this.txtIRelay1Timeout.TabIndex = 27;
            this.txtIRelay1Timeout.Text = "10";
            // 
            // label52
            // 
            this.label52.AutoSize = true;
            this.label52.Location = new System.Drawing.Point(53, 18);
            this.label52.Name = "label52";
            this.label52.Size = new System.Drawing.Size(49, 13);
            this.label52.TabIndex = 26;
            this.label52.Text = "(x100ms)";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnBaudrateGet);
            this.groupBox1.Controls.Add(this.btnBaudrateSet);
            this.groupBox1.Controls.Add(this.label24);
            this.groupBox1.Controls.Add(this.cbxUSARTBaudrate);
            this.groupBox1.Location = new System.Drawing.Point(537, 426);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(442, 56);
            this.groupBox1.TabIndex = 56;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Device UART setup";
            // 
            // btnBaudrateGet
            // 
            this.btnBaudrateGet.Location = new System.Drawing.Point(252, 19);
            this.btnBaudrateGet.Name = "btnBaudrateGet";
            this.btnBaudrateGet.Size = new System.Drawing.Size(70, 23);
            this.btnBaudrateGet.TabIndex = 54;
            this.btnBaudrateGet.Text = "Get";
            this.btnBaudrateGet.UseVisualStyleBackColor = true;
            this.btnBaudrateGet.Click += new System.EventHandler(this.btnBaudrateGet_Click);
            // 
            // btnBaudrateSet
            // 
            this.btnBaudrateSet.Location = new System.Drawing.Point(352, 19);
            this.btnBaudrateSet.Name = "btnBaudrateSet";
            this.btnBaudrateSet.Size = new System.Drawing.Size(67, 23);
            this.btnBaudrateSet.TabIndex = 55;
            this.btnBaudrateSet.Text = "Set";
            this.btnBaudrateSet.UseVisualStyleBackColor = true;
            this.btnBaudrateSet.Click += new System.EventHandler(this.btnBaudrateSet_Click);
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Location = new System.Drawing.Point(8, 24);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(90, 13);
            this.label24.TabIndex = 52;
            this.label24.Text = "Device Baudrate:";
            // 
            // cbxUSARTBaudrate
            // 
            this.cbxUSARTBaudrate.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxUSARTBaudrate.FormattingEnabled = true;
            this.cbxUSARTBaudrate.Location = new System.Drawing.Point(119, 21);
            this.cbxUSARTBaudrate.Name = "cbxUSARTBaudrate";
            this.cbxUSARTBaudrate.Size = new System.Drawing.Size(100, 21);
            this.cbxUSARTBaudrate.TabIndex = 53;
            // 
            // groupBox8
            // 
            this.groupBox8.Controls.Add(this.chkDHCP);
            this.groupBox8.Controls.Add(this.label49);
            this.groupBox8.Controls.Add(this.chkMACAddress);
            this.groupBox8.Controls.Add(this.chkClientIP);
            this.groupBox8.Controls.Add(this.txtMACAddress);
            this.groupBox8.Controls.Add(this.label47);
            this.groupBox8.Controls.Add(this.txtDeviceClietnIP);
            this.groupBox8.Controls.Add(this.chkClientPort);
            this.groupBox8.Controls.Add(this.chkServerPort);
            this.groupBox8.Controls.Add(this.chkNetMask);
            this.groupBox8.Controls.Add(this.chkGetWayIP);
            this.groupBox8.Controls.Add(this.chkDeviceIP);
            this.groupBox8.Controls.Add(this.btnSetTCPConf);
            this.groupBox8.Controls.Add(this.btnGetTCPConf);
            this.groupBox8.Controls.Add(this.label45);
            this.groupBox8.Controls.Add(this.label44);
            this.groupBox8.Controls.Add(this.txtDeviceClientPort);
            this.groupBox8.Controls.Add(this.txtDeviceNetMask);
            this.groupBox8.Controls.Add(this.label46);
            this.groupBox8.Controls.Add(this.txtDeviceServerPort);
            this.groupBox8.Controls.Add(this.label43);
            this.groupBox8.Controls.Add(this.txtDeviceGW);
            this.groupBox8.Controls.Add(this.label42);
            this.groupBox8.Controls.Add(this.txtDeviceIP);
            this.groupBox8.Location = new System.Drawing.Point(537, 300);
            this.groupBox8.Name = "groupBox8";
            this.groupBox8.Size = new System.Drawing.Size(442, 120);
            this.groupBox8.TabIndex = 48;
            this.groupBox8.TabStop = false;
            this.groupBox8.Text = "TCP/IP configuration";
            // 
            // chkDHCP
            // 
            this.chkDHCP.AutoSize = true;
            this.chkDHCP.Location = new System.Drawing.Point(231, 97);
            this.chkDHCP.Name = "chkDHCP";
            this.chkDHCP.Size = new System.Drawing.Size(56, 17);
            this.chkDHCP.TabIndex = 44;
            this.chkDHCP.Text = "DHCP";
            this.chkDHCP.UseVisualStyleBackColor = true;
            this.chkDHCP.Click += new System.EventHandler(this.chkDHCP_Click);
            // 
            // label49
            // 
            this.label49.AutoSize = true;
            this.label49.Location = new System.Drawing.Point(8, 98);
            this.label49.Name = "label49";
            this.label49.Size = new System.Drawing.Size(33, 13);
            this.label49.TabIndex = 43;
            this.label49.Text = "MAC:";
            // 
            // chkMACAddress
            // 
            this.chkMACAddress.AutoSize = true;
            this.chkMACAddress.Location = new System.Drawing.Point(196, 98);
            this.chkMACAddress.Name = "chkMACAddress";
            this.chkMACAddress.Size = new System.Drawing.Size(15, 14);
            this.chkMACAddress.TabIndex = 39;
            this.chkMACAddress.UseVisualStyleBackColor = true;
            // 
            // chkClientIP
            // 
            this.chkClientIP.AutoSize = true;
            this.chkClientIP.Location = new System.Drawing.Point(423, 72);
            this.chkClientIP.Name = "chkClientIP";
            this.chkClientIP.Size = new System.Drawing.Size(15, 14);
            this.chkClientIP.TabIndex = 42;
            this.chkClientIP.UseVisualStyleBackColor = true;
            // 
            // txtMACAddress
            // 
            this.txtMACAddress.Location = new System.Drawing.Point(69, 94);
            this.txtMACAddress.Name = "txtMACAddress";
            this.txtMACAddress.Size = new System.Drawing.Size(121, 20);
            this.txtMACAddress.TabIndex = 38;
            // 
            // label47
            // 
            this.label47.AutoSize = true;
            this.label47.Location = new System.Drawing.Point(229, 71);
            this.label47.Name = "label47";
            this.label47.Size = new System.Drawing.Size(45, 13);
            this.label47.TabIndex = 41;
            this.label47.Text = "Host IP:";
            // 
            // txtDeviceClietnIP
            // 
            this.txtDeviceClietnIP.Location = new System.Drawing.Point(298, 68);
            this.txtDeviceClietnIP.Name = "txtDeviceClietnIP";
            this.txtDeviceClietnIP.Size = new System.Drawing.Size(121, 20);
            this.txtDeviceClietnIP.TabIndex = 40;
            // 
            // chkClientPort
            // 
            this.chkClientPort.AutoSize = true;
            this.chkClientPort.Location = new System.Drawing.Point(423, 46);
            this.chkClientPort.Name = "chkClientPort";
            this.chkClientPort.Size = new System.Drawing.Size(15, 14);
            this.chkClientPort.TabIndex = 39;
            this.chkClientPort.UseVisualStyleBackColor = true;
            // 
            // chkServerPort
            // 
            this.chkServerPort.AutoSize = true;
            this.chkServerPort.Location = new System.Drawing.Point(423, 17);
            this.chkServerPort.Name = "chkServerPort";
            this.chkServerPort.Size = new System.Drawing.Size(15, 14);
            this.chkServerPort.TabIndex = 38;
            this.chkServerPort.UseVisualStyleBackColor = true;
            // 
            // chkNetMask
            // 
            this.chkNetMask.AutoSize = true;
            this.chkNetMask.Location = new System.Drawing.Point(196, 72);
            this.chkNetMask.Name = "chkNetMask";
            this.chkNetMask.Size = new System.Drawing.Size(15, 14);
            this.chkNetMask.TabIndex = 37;
            this.chkNetMask.UseVisualStyleBackColor = true;
            // 
            // chkGetWayIP
            // 
            this.chkGetWayIP.AutoSize = true;
            this.chkGetWayIP.Location = new System.Drawing.Point(196, 44);
            this.chkGetWayIP.Name = "chkGetWayIP";
            this.chkGetWayIP.Size = new System.Drawing.Size(15, 14);
            this.chkGetWayIP.TabIndex = 36;
            this.chkGetWayIP.UseVisualStyleBackColor = true;
            // 
            // chkDeviceIP
            // 
            this.chkDeviceIP.AutoSize = true;
            this.chkDeviceIP.Location = new System.Drawing.Point(196, 19);
            this.chkDeviceIP.Name = "chkDeviceIP";
            this.chkDeviceIP.Size = new System.Drawing.Size(15, 14);
            this.chkDeviceIP.TabIndex = 35;
            this.chkDeviceIP.UseVisualStyleBackColor = true;
            // 
            // btnSetTCPConf
            // 
            this.btnSetTCPConf.Location = new System.Drawing.Point(365, 94);
            this.btnSetTCPConf.Name = "btnSetTCPConf";
            this.btnSetTCPConf.Size = new System.Drawing.Size(54, 23);
            this.btnSetTCPConf.TabIndex = 31;
            this.btnSetTCPConf.Text = "Set";
            this.btnSetTCPConf.UseVisualStyleBackColor = true;
            this.btnSetTCPConf.Click += new System.EventHandler(this.btnSetTCPConf_Click);
            // 
            // btnGetTCPConf
            // 
            this.btnGetTCPConf.Location = new System.Drawing.Point(298, 94);
            this.btnGetTCPConf.Name = "btnGetTCPConf";
            this.btnGetTCPConf.Size = new System.Drawing.Size(54, 23);
            this.btnGetTCPConf.TabIndex = 32;
            this.btnGetTCPConf.Text = "Get";
            this.btnGetTCPConf.UseVisualStyleBackColor = true;
            this.btnGetTCPConf.Click += new System.EventHandler(this.btnGetTCPConf_Click);
            // 
            // label45
            // 
            this.label45.AutoSize = true;
            this.label45.Location = new System.Drawing.Point(229, 46);
            this.label45.Name = "label45";
            this.label45.Size = new System.Drawing.Size(54, 13);
            this.label45.TabIndex = 33;
            this.label45.Text = "Host Port:";
            // 
            // label44
            // 
            this.label44.AutoSize = true;
            this.label44.Location = new System.Drawing.Point(6, 72);
            this.label44.Name = "label44";
            this.label44.Size = new System.Drawing.Size(55, 13);
            this.label44.TabIndex = 12;
            this.label44.Text = "Net mask:";
            // 
            // txtDeviceClientPort
            // 
            this.txtDeviceClientPort.Location = new System.Drawing.Point(298, 43);
            this.txtDeviceClientPort.Name = "txtDeviceClientPort";
            this.txtDeviceClientPort.Size = new System.Drawing.Size(121, 20);
            this.txtDeviceClientPort.TabIndex = 34;
            // 
            // txtDeviceNetMask
            // 
            this.txtDeviceNetMask.Location = new System.Drawing.Point(69, 68);
            this.txtDeviceNetMask.Name = "txtDeviceNetMask";
            this.txtDeviceNetMask.Size = new System.Drawing.Size(121, 20);
            this.txtDeviceNetMask.TabIndex = 11;
            // 
            // label46
            // 
            this.label46.AutoSize = true;
            this.label46.Location = new System.Drawing.Point(229, 20);
            this.label46.Name = "label46";
            this.label46.Size = new System.Drawing.Size(66, 13);
            this.label46.TabIndex = 32;
            this.label46.Text = "Device Port:";
            // 
            // txtDeviceServerPort
            // 
            this.txtDeviceServerPort.Location = new System.Drawing.Point(298, 17);
            this.txtDeviceServerPort.Name = "txtDeviceServerPort";
            this.txtDeviceServerPort.Size = new System.Drawing.Size(121, 20);
            this.txtDeviceServerPort.TabIndex = 31;
            // 
            // label43
            // 
            this.label43.AutoSize = true;
            this.label43.Location = new System.Drawing.Point(6, 45);
            this.label43.Name = "label43";
            this.label43.Size = new System.Drawing.Size(52, 13);
            this.label43.TabIndex = 10;
            this.label43.Text = "Gateway:";
            // 
            // txtDeviceGW
            // 
            this.txtDeviceGW.Location = new System.Drawing.Point(69, 42);
            this.txtDeviceGW.Name = "txtDeviceGW";
            this.txtDeviceGW.Size = new System.Drawing.Size(121, 20);
            this.txtDeviceGW.TabIndex = 9;
            // 
            // label42
            // 
            this.label42.AutoSize = true;
            this.label42.Location = new System.Drawing.Point(6, 20);
            this.label42.Name = "label42";
            this.label42.Size = new System.Drawing.Size(57, 13);
            this.label42.TabIndex = 8;
            this.label42.Text = "Device IP:";
            // 
            // txtDeviceIP
            // 
            this.txtDeviceIP.Location = new System.Drawing.Point(69, 17);
            this.txtDeviceIP.Name = "txtDeviceIP";
            this.txtDeviceIP.Size = new System.Drawing.Size(121, 20);
            this.txtDeviceIP.TabIndex = 6;
            // 
            // groupBox10
            // 
            this.groupBox10.Controls.Add(this.cbxMaxFreq);
            this.groupBox10.Controls.Add(this.lblRFPower);
            this.groupBox10.Controls.Add(this.btnSetRfmode);
            this.groupBox10.Controls.Add(this.lblRegion);
            this.groupBox10.Controls.Add(this.btnGetRfMode);
            this.groupBox10.Controls.Add(this.cbxRegion);
            this.groupBox10.Controls.Add(this.btnGetRfPower);
            this.groupBox10.Controls.Add(this.btnGetRegion);
            this.groupBox10.Controls.Add(this.lblRFMode);
            this.groupBox10.Controls.Add(this.btnSetRegion);
            this.groupBox10.Controls.Add(this.btnSetRfPower);
            this.groupBox10.Controls.Add(this.cbxMinFreq);
            this.groupBox10.Controls.Add(this.cbxRFMode);
            this.groupBox10.Controls.Add(this.tbRFPower);
            this.groupBox10.Controls.Add(this.label13);
            this.groupBox10.Controls.Add(this.label14);
            this.groupBox10.Location = new System.Drawing.Point(6, 300);
            this.groupBox10.Name = "groupBox10";
            this.groupBox10.Size = new System.Drawing.Size(452, 133);
            this.groupBox10.TabIndex = 47;
            this.groupBox10.TabStop = false;
            this.groupBox10.Text = "RF Configuration";
            // 
            // cbxMaxFreq
            // 
            this.cbxMaxFreq.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxMaxFreq.FormattingEnabled = true;
            this.cbxMaxFreq.Location = new System.Drawing.Point(98, 73);
            this.cbxMaxFreq.Name = "cbxMaxFreq";
            this.cbxMaxFreq.Size = new System.Drawing.Size(135, 21);
            this.cbxMaxFreq.TabIndex = 13;
            // 
            // lblRFPower
            // 
            this.lblRFPower.AutoSize = true;
            this.lblRFPower.Location = new System.Drawing.Point(242, 79);
            this.lblRFPower.Name = "lblRFPower";
            this.lblRFPower.Size = new System.Drawing.Size(57, 13);
            this.lblRFPower.TabIndex = 11;
            this.lblRFPower.Text = "RF Power:";
            // 
            // btnSetRfmode
            // 
            this.btnSetRfmode.Location = new System.Drawing.Point(386, 46);
            this.btnSetRfmode.Name = "btnSetRfmode";
            this.btnSetRfmode.Size = new System.Drawing.Size(54, 23);
            this.btnSetRfmode.TabIndex = 9;
            this.btnSetRfmode.Text = "Set";
            this.btnSetRfmode.UseVisualStyleBackColor = true;
            this.btnSetRfmode.Click += new System.EventHandler(this.btnSetRfmode_Click);
            // 
            // lblRegion
            // 
            this.lblRegion.AutoSize = true;
            this.lblRegion.Location = new System.Drawing.Point(48, 27);
            this.lblRegion.Name = "lblRegion";
            this.lblRegion.Size = new System.Drawing.Size(44, 13);
            this.lblRegion.TabIndex = 8;
            this.lblRegion.Text = "Region:";
            // 
            // btnGetRfMode
            // 
            this.btnGetRfMode.Location = new System.Drawing.Point(305, 46);
            this.btnGetRfMode.Name = "btnGetRfMode";
            this.btnGetRfMode.Size = new System.Drawing.Size(54, 23);
            this.btnGetRfMode.TabIndex = 8;
            this.btnGetRfMode.Text = "Get";
            this.btnGetRfMode.UseVisualStyleBackColor = true;
            this.btnGetRfMode.Click += new System.EventHandler(this.btnGetRfMode_Click);
            // 
            // cbxRegion
            // 
            this.cbxRegion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxRegion.FormattingEnabled = true;
            this.cbxRegion.Location = new System.Drawing.Point(98, 19);
            this.cbxRegion.Name = "cbxRegion";
            this.cbxRegion.Size = new System.Drawing.Size(135, 21);
            this.cbxRegion.TabIndex = 8;
            // 
            // btnGetRfPower
            // 
            this.btnGetRfPower.Location = new System.Drawing.Point(305, 100);
            this.btnGetRfPower.Name = "btnGetRfPower";
            this.btnGetRfPower.Size = new System.Drawing.Size(54, 23);
            this.btnGetRfPower.TabIndex = 9;
            this.btnGetRfPower.Text = "Get";
            this.btnGetRfPower.UseVisualStyleBackColor = true;
            this.btnGetRfPower.Click += new System.EventHandler(this.btnGetRfPower_Click);
            // 
            // btnGetRegion
            // 
            this.btnGetRegion.Location = new System.Drawing.Point(98, 100);
            this.btnGetRegion.Name = "btnGetRegion";
            this.btnGetRegion.Size = new System.Drawing.Size(54, 23);
            this.btnGetRegion.TabIndex = 10;
            this.btnGetRegion.Text = "Get";
            this.btnGetRegion.UseVisualStyleBackColor = true;
            this.btnGetRegion.Click += new System.EventHandler(this.btnGetRegion_Click);
            // 
            // lblRFMode
            // 
            this.lblRFMode.AutoSize = true;
            this.lblRFMode.Location = new System.Drawing.Point(239, 23);
            this.lblRFMode.Name = "lblRFMode";
            this.lblRFMode.Size = new System.Drawing.Size(60, 13);
            this.lblRFMode.TabIndex = 9;
            this.lblRFMode.Text = "Link Mode:";
            // 
            // btnSetRegion
            // 
            this.btnSetRegion.Location = new System.Drawing.Point(179, 100);
            this.btnSetRegion.Name = "btnSetRegion";
            this.btnSetRegion.Size = new System.Drawing.Size(54, 23);
            this.btnSetRegion.TabIndex = 8;
            this.btnSetRegion.Text = "Set";
            this.btnSetRegion.UseVisualStyleBackColor = true;
            this.btnSetRegion.Click += new System.EventHandler(this.btnSetRegion_Click);
            // 
            // btnSetRfPower
            // 
            this.btnSetRfPower.Location = new System.Drawing.Point(386, 100);
            this.btnSetRfPower.Name = "btnSetRfPower";
            this.btnSetRfPower.Size = new System.Drawing.Size(54, 23);
            this.btnSetRfPower.TabIndex = 10;
            this.btnSetRfPower.Text = "Set";
            this.btnSetRfPower.UseVisualStyleBackColor = true;
            this.btnSetRfPower.Click += new System.EventHandler(this.btnSetRfPower_Click);
            // 
            // cbxMinFreq
            // 
            this.cbxMinFreq.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxMinFreq.FormattingEnabled = true;
            this.cbxMinFreq.Location = new System.Drawing.Point(98, 46);
            this.cbxMinFreq.Name = "cbxMinFreq";
            this.cbxMinFreq.Size = new System.Drawing.Size(135, 21);
            this.cbxMinFreq.TabIndex = 12;
            // 
            // cbxRFMode
            // 
            this.cbxRFMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxRFMode.FormattingEnabled = true;
            this.cbxRFMode.Location = new System.Drawing.Point(305, 19);
            this.cbxRFMode.Name = "cbxRFMode";
            this.cbxRFMode.Size = new System.Drawing.Size(135, 21);
            this.cbxRFMode.TabIndex = 8;
            // 
            // tbRFPower
            // 
            this.tbRFPower.Location = new System.Drawing.Point(305, 74);
            this.tbRFPower.Name = "tbRFPower";
            this.tbRFPower.Size = new System.Drawing.Size(135, 20);
            this.tbRFPower.TabIndex = 9;
            this.tbRFPower.TextChanged += new System.EventHandler(this.tbRFPower_TextChanged);
            this.tbRFPower.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbRFPower_KeyPress);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(9, 54);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(83, 13);
            this.label13.TabIndex = 14;
            this.label13.Text = "Min. Frequency:";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(6, 81);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(86, 13);
            this.label14.TabIndex = 15;
            this.label14.Text = "Max. Frequency:";
            // 
            // gbRFSetup
            // 
            this.gbRFSetup.Controls.Add(this.groupBox36);
            this.gbRFSetup.Controls.Add(this.groupBox35);
            this.gbRFSetup.Controls.Add(this.groupBox34);
            this.gbRFSetup.Controls.Add(this.groupBox32);
            this.gbRFSetup.Controls.Add(this.groupBox31);
            this.gbRFSetup.Controls.Add(this.groupBox30);
            this.gbRFSetup.Controls.Add(this.groupBox29);
            this.gbRFSetup.Controls.Add(this.groupBox28);
            this.gbRFSetup.Location = new System.Drawing.Point(225, 9);
            this.gbRFSetup.Name = "gbRFSetup";
            this.gbRFSetup.Size = new System.Drawing.Size(754, 282);
            this.gbRFSetup.TabIndex = 7;
            this.gbRFSetup.TabStop = false;
            this.gbRFSetup.Text = "Device information and basic configurations";
            // 
            // groupBox36
            // 
            this.groupBox36.Controls.Add(this.lblRFInfo3);
            this.groupBox36.Controls.Add(this.lblRFInfo2);
            this.groupBox36.Controls.Add(this.lblRFInfo1);
            this.groupBox36.Location = new System.Drawing.Point(9, 210);
            this.groupBox36.Name = "groupBox36";
            this.groupBox36.Size = new System.Drawing.Size(311, 64);
            this.groupBox36.TabIndex = 63;
            this.groupBox36.TabStop = false;
            this.groupBox36.Text = "RF info.";
            // 
            // lblRFInfo3
            // 
            this.lblRFInfo3.AutoSize = true;
            this.lblRFInfo3.Location = new System.Drawing.Point(156, 41);
            this.lblRFInfo3.Name = "lblRFInfo3";
            this.lblRFInfo3.Size = new System.Drawing.Size(10, 13);
            this.lblRFInfo3.TabIndex = 2;
            this.lblRFInfo3.Text = " ";
            // 
            // lblRFInfo2
            // 
            this.lblRFInfo2.AutoSize = true;
            this.lblRFInfo2.Location = new System.Drawing.Point(6, 41);
            this.lblRFInfo2.Name = "lblRFInfo2";
            this.lblRFInfo2.Size = new System.Drawing.Size(10, 13);
            this.lblRFInfo2.TabIndex = 1;
            this.lblRFInfo2.Text = " ";
            // 
            // lblRFInfo1
            // 
            this.lblRFInfo1.AutoSize = true;
            this.lblRFInfo1.Location = new System.Drawing.Point(6, 21);
            this.lblRFInfo1.Name = "lblRFInfo1";
            this.lblRFInfo1.Size = new System.Drawing.Size(10, 13);
            this.lblRFInfo1.TabIndex = 0;
            this.lblRFInfo1.Text = " ";
            // 
            // groupBox35
            // 
            this.groupBox35.Controls.Add(this.btnRTCSync);
            this.groupBox35.Controls.Add(this.txtRTC);
            this.groupBox35.Controls.Add(this.label88);
            this.groupBox35.Controls.Add(this.btnRTCTimeGet);
            this.groupBox35.Location = new System.Drawing.Point(326, 185);
            this.groupBox35.Name = "groupBox35";
            this.groupBox35.Size = new System.Drawing.Size(259, 89);
            this.groupBox35.TabIndex = 62;
            this.groupBox35.TabStop = false;
            this.groupBox35.Text = "Device RTC setup";
            // 
            // btnRTCSync
            // 
            this.btnRTCSync.Location = new System.Drawing.Point(149, 62);
            this.btnRTCSync.Name = "btnRTCSync";
            this.btnRTCSync.Size = new System.Drawing.Size(104, 23);
            this.btnRTCSync.TabIndex = 55;
            this.btnRTCSync.Text = "Synchronize";
            this.btnRTCSync.UseVisualStyleBackColor = true;
            this.btnRTCSync.Click += new System.EventHandler(this.btnRTCSync_Click);
            // 
            // txtRTC
            // 
            this.txtRTC.Location = new System.Drawing.Point(101, 32);
            this.txtRTC.Name = "txtRTC";
            this.txtRTC.Size = new System.Drawing.Size(152, 20);
            this.txtRTC.TabIndex = 52;
            // 
            // label88
            // 
            this.label88.AutoSize = true;
            this.label88.Location = new System.Drawing.Point(6, 35);
            this.label88.Name = "label88";
            this.label88.Size = new System.Drawing.Size(92, 13);
            this.label88.TabIndex = 53;
            this.label88.Text = "Internal RTC time:";
            // 
            // btnRTCTimeGet
            // 
            this.btnRTCTimeGet.Location = new System.Drawing.Point(8, 62);
            this.btnRTCTimeGet.Name = "btnRTCTimeGet";
            this.btnRTCTimeGet.Size = new System.Drawing.Size(104, 23);
            this.btnRTCTimeGet.TabIndex = 54;
            this.btnRTCTimeGet.Text = "Get";
            this.btnRTCTimeGet.UseVisualStyleBackColor = true;
            this.btnRTCTimeGet.Click += new System.EventHandler(this.btnRTCTimeGet_Click);
            // 
            // groupBox34
            // 
            this.groupBox34.Controls.Add(this.chkTCPClientCheck);
            this.groupBox34.Controls.Add(this.btnHeartbeat);
            this.groupBox34.Controls.Add(this.label55);
            this.groupBox34.Controls.Add(this.txtHeartbeat);
            this.groupBox34.Location = new System.Drawing.Point(326, 110);
            this.groupBox34.Name = "groupBox34";
            this.groupBox34.Size = new System.Drawing.Size(259, 69);
            this.groupBox34.TabIndex = 61;
            this.groupBox34.TabStop = false;
            this.groupBox34.Text = "Heartbeat Setup";
            // 
            // chkTCPClientCheck
            // 
            this.chkTCPClientCheck.AutoSize = true;
            this.chkTCPClientCheck.Location = new System.Drawing.Point(9, 45);
            this.chkTCPClientCheck.Name = "chkTCPClientCheck";
            this.chkTCPClientCheck.Size = new System.Drawing.Size(109, 17);
            this.chkTCPClientCheck.TabIndex = 50;
            this.chkTCPClientCheck.Text = "TCP Client check";
            this.chkTCPClientCheck.UseVisualStyleBackColor = true;
            // 
            // btnHeartbeat
            // 
            this.btnHeartbeat.Location = new System.Drawing.Point(175, 17);
            this.btnHeartbeat.Name = "btnHeartbeat";
            this.btnHeartbeat.Size = new System.Drawing.Size(78, 22);
            this.btnHeartbeat.TabIndex = 49;
            this.btnHeartbeat.Text = "Setup";
            this.btnHeartbeat.UseVisualStyleBackColor = true;
            this.btnHeartbeat.Click += new System.EventHandler(this.btnHeartbeat_Click);
            // 
            // label55
            // 
            this.label55.AutoSize = true;
            this.label55.Location = new System.Drawing.Point(6, 22);
            this.label55.Name = "label55";
            this.label55.Size = new System.Drawing.Size(57, 13);
            this.label55.TabIndex = 47;
            this.label55.Text = " (x100mS):";
            // 
            // txtHeartbeat
            // 
            this.txtHeartbeat.Location = new System.Drawing.Point(69, 19);
            this.txtHeartbeat.Name = "txtHeartbeat";
            this.txtHeartbeat.Size = new System.Drawing.Size(100, 20);
            this.txtHeartbeat.TabIndex = 48;
            // 
            // groupBox32
            // 
            this.groupBox32.Controls.Add(this.groupBox33);
            this.groupBox32.Controls.Add(this.btnBuzzerControl);
            this.groupBox32.Controls.Add(this.chkBuzzerEnable);
            this.groupBox32.Location = new System.Drawing.Point(591, 110);
            this.groupBox32.Name = "groupBox32";
            this.groupBox32.Size = new System.Drawing.Size(157, 164);
            this.groupBox32.TabIndex = 60;
            this.groupBox32.TabStop = false;
            this.groupBox32.Text = "Buzzer control";
            // 
            // groupBox33
            // 
            this.groupBox33.Controls.Add(this.button1);
            this.groupBox33.Controls.Add(this.txtBuzzerBeepDuration);
            this.groupBox33.Location = new System.Drawing.Point(0, 75);
            this.groupBox33.Name = "groupBox33";
            this.groupBox33.Size = new System.Drawing.Size(157, 89);
            this.groupBox33.TabIndex = 61;
            this.groupBox33.TabStop = false;
            this.groupBox33.Text = "Buzzer Beep";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(6, 58);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(145, 23);
            this.button1.TabIndex = 43;
            this.button1.Text = "Buzzer beep (x100mS)";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // txtBuzzerBeepDuration
            // 
            this.txtBuzzerBeepDuration.Location = new System.Drawing.Point(7, 22);
            this.txtBuzzerBeepDuration.Name = "txtBuzzerBeepDuration";
            this.txtBuzzerBeepDuration.Size = new System.Drawing.Size(145, 20);
            this.txtBuzzerBeepDuration.TabIndex = 44;
            // 
            // btnBuzzerControl
            // 
            this.btnBuzzerControl.Location = new System.Drawing.Point(6, 46);
            this.btnBuzzerControl.Name = "btnBuzzerControl";
            this.btnBuzzerControl.Size = new System.Drawing.Size(145, 23);
            this.btnBuzzerControl.TabIndex = 42;
            this.btnBuzzerControl.Text = "Buzzer setup";
            this.btnBuzzerControl.UseVisualStyleBackColor = true;
            this.btnBuzzerControl.Click += new System.EventHandler(this.btnBuzzerControl_Click);
            // 
            // chkBuzzerEnable
            // 
            this.chkBuzzerEnable.AutoSize = true;
            this.chkBuzzerEnable.Location = new System.Drawing.Point(7, 23);
            this.chkBuzzerEnable.Name = "chkBuzzerEnable";
            this.chkBuzzerEnable.Size = new System.Drawing.Size(93, 17);
            this.chkBuzzerEnable.TabIndex = 40;
            this.chkBuzzerEnable.Text = "Buzzer enable";
            this.chkBuzzerEnable.UseVisualStyleBackColor = true;
            // 
            // groupBox31
            // 
            this.groupBox31.Controls.Add(this.btnForceBootMode);
            this.groupBox31.Controls.Add(this.btnDeviceRestart);
            this.groupBox31.Location = new System.Drawing.Point(591, 23);
            this.groupBox31.Name = "groupBox31";
            this.groupBox31.Size = new System.Drawing.Size(157, 81);
            this.groupBox31.TabIndex = 59;
            this.groupBox31.TabStop = false;
            this.groupBox31.Text = "Device restart and control";
            // 
            // btnForceBootMode
            // 
            this.btnForceBootMode.Location = new System.Drawing.Point(6, 48);
            this.btnForceBootMode.Name = "btnForceBootMode";
            this.btnForceBootMode.Size = new System.Drawing.Size(145, 23);
            this.btnForceBootMode.TabIndex = 51;
            this.btnForceBootMode.Text = "Force Boot mode";
            this.btnForceBootMode.UseVisualStyleBackColor = true;
            this.btnForceBootMode.Click += new System.EventHandler(this.btnForceBootMode_Click);
            // 
            // btnDeviceRestart
            // 
            this.btnDeviceRestart.Location = new System.Drawing.Point(6, 19);
            this.btnDeviceRestart.Name = "btnDeviceRestart";
            this.btnDeviceRestart.Size = new System.Drawing.Size(145, 23);
            this.btnDeviceRestart.TabIndex = 50;
            this.btnDeviceRestart.Text = "Device restart";
            this.btnDeviceRestart.UseVisualStyleBackColor = true;
            this.btnDeviceRestart.Click += new System.EventHandler(this.btnDeviceRestart_Click);
            // 
            // groupBox30
            // 
            this.groupBox30.Controls.Add(this.label18);
            this.groupBox30.Controls.Add(this.cbxDeviceWorkingMode);
            this.groupBox30.Controls.Add(this.btnGetWorkingMode);
            this.groupBox30.Controls.Add(this.btnSetWorkingMode);
            this.groupBox30.Location = new System.Drawing.Point(9, 110);
            this.groupBox30.Name = "groupBox30";
            this.groupBox30.Size = new System.Drawing.Size(311, 94);
            this.groupBox30.TabIndex = 58;
            this.groupBox30.TabStop = false;
            this.groupBox30.Text = "Device operating mode setup";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(6, 27);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(113, 13);
            this.label18.TabIndex = 22;
            this.label18.Text = "Device working mode:";
            // 
            // cbxDeviceWorkingMode
            // 
            this.cbxDeviceWorkingMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxDeviceWorkingMode.FormattingEnabled = true;
            this.cbxDeviceWorkingMode.Location = new System.Drawing.Point(149, 24);
            this.cbxDeviceWorkingMode.Name = "cbxDeviceWorkingMode";
            this.cbxDeviceWorkingMode.Size = new System.Drawing.Size(156, 21);
            this.cbxDeviceWorkingMode.TabIndex = 23;
            this.cbxDeviceWorkingMode.SelectedIndexChanged += new System.EventHandler(this.cbxDeviceWorkingMode_SelectedIndexChanged);
            // 
            // btnGetWorkingMode
            // 
            this.btnGetWorkingMode.Location = new System.Drawing.Point(149, 56);
            this.btnGetWorkingMode.Name = "btnGetWorkingMode";
            this.btnGetWorkingMode.Size = new System.Drawing.Size(75, 23);
            this.btnGetWorkingMode.TabIndex = 24;
            this.btnGetWorkingMode.Text = "Get";
            this.btnGetWorkingMode.UseVisualStyleBackColor = true;
            this.btnGetWorkingMode.Click += new System.EventHandler(this.btnGetWorkingMode_Click);
            // 
            // btnSetWorkingMode
            // 
            this.btnSetWorkingMode.Location = new System.Drawing.Point(230, 56);
            this.btnSetWorkingMode.Name = "btnSetWorkingMode";
            this.btnSetWorkingMode.Size = new System.Drawing.Size(75, 23);
            this.btnSetWorkingMode.TabIndex = 25;
            this.btnSetWorkingMode.Text = "Set";
            this.btnSetWorkingMode.UseVisualStyleBackColor = true;
            this.btnSetWorkingMode.Click += new System.EventHandler(this.btnSetWorkingMode_Click);
            // 
            // groupBox29
            // 
            this.groupBox29.Controls.Add(this.txtHardwareVersion);
            this.groupBox29.Controls.Add(this.label15);
            this.groupBox29.Controls.Add(this.label16);
            this.groupBox29.Controls.Add(this.txtDeviceSerialNum);
            this.groupBox29.Controls.Add(this.txtFirmwareVersion);
            this.groupBox29.Controls.Add(this.label17);
            this.groupBox29.Controls.Add(this.button3);
            this.groupBox29.Location = new System.Drawing.Point(9, 19);
            this.groupBox29.Name = "groupBox29";
            this.groupBox29.Size = new System.Drawing.Size(311, 85);
            this.groupBox29.TabIndex = 57;
            this.groupBox29.TabStop = false;
            this.groupBox29.Text = "Device information";
            // 
            // txtHardwareVersion
            // 
            this.txtHardwareVersion.Location = new System.Drawing.Point(178, 41);
            this.txtHardwareVersion.Name = "txtHardwareVersion";
            this.txtHardwareVersion.ReadOnly = true;
            this.txtHardwareVersion.Size = new System.Drawing.Size(61, 20);
            this.txtHardwareVersion.TabIndex = 19;
            this.txtHardwareVersion.TextChanged += new System.EventHandler(this.textBox4_TextChanged);
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(4, 25);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(59, 13);
            this.label15.TabIndex = 16;
            this.label15.Text = "Device SN";
            this.label15.Click += new System.EventHandler(this.label15_Click);
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(175, 25);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(64, 13);
            this.label16.TabIndex = 17;
            this.label16.Text = "HW Version";
            this.label16.Click += new System.EventHandler(this.label16_Click);
            // 
            // txtDeviceSerialNum
            // 
            this.txtDeviceSerialNum.Location = new System.Drawing.Point(7, 41);
            this.txtDeviceSerialNum.Name = "txtDeviceSerialNum";
            this.txtDeviceSerialNum.ReadOnly = true;
            this.txtDeviceSerialNum.Size = new System.Drawing.Size(100, 20);
            this.txtDeviceSerialNum.TabIndex = 18;
            this.txtDeviceSerialNum.TextChanged += new System.EventHandler(this.txtDeviceSerialNum_TextChanged);
            // 
            // txtFirmwareVersion
            // 
            this.txtFirmwareVersion.Location = new System.Drawing.Point(113, 41);
            this.txtFirmwareVersion.Name = "txtFirmwareVersion";
            this.txtFirmwareVersion.ReadOnly = true;
            this.txtFirmwareVersion.Size = new System.Drawing.Size(59, 20);
            this.txtFirmwareVersion.TabIndex = 20;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(110, 25);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(62, 13);
            this.label17.TabIndex = 21;
            this.label17.Text = "FW Version";
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(249, 40);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(59, 21);
            this.button3.TabIndex = 46;
            this.button3.Text = "Get";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // groupBox28
            // 
            this.groupBox28.Controls.Add(this.btnDeAuthenticate);
            this.groupBox28.Controls.Add(this.btnAuthenticate);
            this.groupBox28.Controls.Add(this.txtGlobalPwd);
            this.groupBox28.Controls.Add(this.btnPasswordUpdate);
            this.groupBox28.Location = new System.Drawing.Point(326, 19);
            this.groupBox28.Name = "groupBox28";
            this.groupBox28.Size = new System.Drawing.Size(259, 85);
            this.groupBox28.TabIndex = 56;
            this.groupBox28.TabStop = false;
            this.groupBox28.Text = "Global Password";
            // 
            // btnDeAuthenticate
            // 
            this.btnDeAuthenticate.Location = new System.Drawing.Point(87, 56);
            this.btnDeAuthenticate.Name = "btnDeAuthenticate";
            this.btnDeAuthenticate.Size = new System.Drawing.Size(95, 23);
            this.btnDeAuthenticate.TabIndex = 6;
            this.btnDeAuthenticate.Text = "DeAuthenticate";
            this.btnDeAuthenticate.UseVisualStyleBackColor = true;
            this.btnDeAuthenticate.Click += new System.EventHandler(this.btnDeAuthenticate_Click);
            // 
            // btnAuthenticate
            // 
            this.btnAuthenticate.Location = new System.Drawing.Point(6, 56);
            this.btnAuthenticate.Name = "btnAuthenticate";
            this.btnAuthenticate.Size = new System.Drawing.Size(75, 23);
            this.btnAuthenticate.TabIndex = 6;
            this.btnAuthenticate.Text = "Authenticate";
            this.btnAuthenticate.UseVisualStyleBackColor = true;
            this.btnAuthenticate.Click += new System.EventHandler(this.btnAuthenticate_Click);
            // 
            // txtGlobalPwd
            // 
            this.txtGlobalPwd.Location = new System.Drawing.Point(8, 22);
            this.txtGlobalPwd.Name = "txtGlobalPwd";
            this.txtGlobalPwd.Size = new System.Drawing.Size(245, 20);
            this.txtGlobalPwd.TabIndex = 6;
            this.txtGlobalPwd.UseSystemPasswordChar = true;
            // 
            // btnPasswordUpdate
            // 
            this.btnPasswordUpdate.Location = new System.Drawing.Point(188, 56);
            this.btnPasswordUpdate.Name = "btnPasswordUpdate";
            this.btnPasswordUpdate.Size = new System.Drawing.Size(65, 22);
            this.btnPasswordUpdate.TabIndex = 7;
            this.btnPasswordUpdate.Text = "Update";
            this.btnPasswordUpdate.UseVisualStyleBackColor = true;
            this.btnPasswordUpdate.Click += new System.EventHandler(this.btnPasswordUpdate_Click);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.grpEPCWrite);
            this.tabPage2.Controls.Add(this.button13);
            this.tabPage2.Controls.Add(this.dgView);
            this.tabPage2.Controls.Add(this.grpEPCSetProtect);
            this.tabPage2.Controls.Add(this.grpMemOps);
            this.tabPage2.Controls.Add(this.grpInventorySetup);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(985, 621);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "EPC C1G2 Operations";
            this.tabPage2.UseVisualStyleBackColor = true;
            this.tabPage2.Click += new System.EventHandler(this.tabPage2_Click);
            // 
            // grpEPCWrite
            // 
            this.grpEPCWrite.Controls.Add(this.label26);
            this.grpEPCWrite.Controls.Add(this.btnWriteEPC);
            this.grpEPCWrite.Controls.Add(this.txtAccessPwEPC);
            this.grpEPCWrite.Controls.Add(this.txtNewEPC);
            this.grpEPCWrite.Controls.Add(this.label27);
            this.grpEPCWrite.Location = new System.Drawing.Point(6, 557);
            this.grpEPCWrite.Name = "grpEPCWrite";
            this.grpEPCWrite.Size = new System.Drawing.Size(322, 64);
            this.grpEPCWrite.TabIndex = 17;
            this.grpEPCWrite.TabStop = false;
            this.grpEPCWrite.Text = "Write Single Tag EPC";
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.Location = new System.Drawing.Point(6, 41);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(94, 13);
            this.label26.TabIndex = 19;
            this.label26.Text = "Access PW (Hex):";
            // 
            // btnWriteEPC
            // 
            this.btnWriteEPC.Location = new System.Drawing.Point(217, 37);
            this.btnWriteEPC.Name = "btnWriteEPC";
            this.btnWriteEPC.Size = new System.Drawing.Size(99, 21);
            this.btnWriteEPC.TabIndex = 4;
            this.btnWriteEPC.Text = "Write EPC";
            this.btnWriteEPC.UseVisualStyleBackColor = true;
            this.btnWriteEPC.Click += new System.EventHandler(this.btnWriteEPC_Click);
            // 
            // txtAccessPwEPC
            // 
            this.txtAccessPwEPC.Location = new System.Drawing.Point(100, 38);
            this.txtAccessPwEPC.MaxLength = 8;
            this.txtAccessPwEPC.Name = "txtAccessPwEPC";
            this.txtAccessPwEPC.Size = new System.Drawing.Size(81, 20);
            this.txtAccessPwEPC.TabIndex = 3;
            this.txtAccessPwEPC.Text = "00000000";
            // 
            // txtNewEPC
            // 
            this.txtNewEPC.Location = new System.Drawing.Point(37, 15);
            this.txtNewEPC.MaxLength = 60;
            this.txtNewEPC.Multiline = true;
            this.txtNewEPC.Name = "txtNewEPC";
            this.txtNewEPC.Size = new System.Drawing.Size(279, 17);
            this.txtNewEPC.TabIndex = 1;
            this.txtNewEPC.Text = "0000";
            // 
            // label27
            // 
            this.label27.AutoSize = true;
            this.label27.Location = new System.Drawing.Point(1, 19);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(37, 13);
            this.label27.TabIndex = 0;
            this.label27.Text = "EPC : ";
            // 
            // button13
            // 
            this.button13.Location = new System.Drawing.Point(948, 6);
            this.button13.Name = "button13";
            this.button13.Size = new System.Drawing.Size(31, 21);
            this.button13.TabIndex = 16;
            this.button13.Text = "Clr";
            this.button13.UseVisualStyleBackColor = true;
            this.button13.Click += new System.EventHandler(this.button13_Click);
            // 
            // dgView
            // 
            this.dgView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.C0,
            this.C1,
            this.C2,
            this.C3,
            this.C4,
            this.C5,
            this.C6,
            this.C7,
            this.C8,
            this.C9,
            this.C10,
            this.C11});
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgView.DefaultCellStyle = dataGridViewCellStyle1;
            this.dgView.Location = new System.Drawing.Point(334, 6);
            this.dgView.Name = "dgView";
            this.dgView.ReadOnly = true;
            this.dgView.RowHeadersVisible = false;
            this.dgView.Size = new System.Drawing.Size(645, 609);
            this.dgView.TabIndex = 15;
            // 
            // C0
            // 
            this.C0.HeaderText = "Sr.No";
            this.C0.Name = "C0";
            this.C0.ReadOnly = true;
            // 
            // C1
            // 
            this.C1.HeaderText = "Device ID";
            this.C1.Name = "C1";
            this.C1.ReadOnly = true;
            // 
            // C2
            // 
            this.C2.HeaderText = "Count";
            this.C2.Name = "C2";
            this.C2.ReadOnly = true;
            // 
            // C3
            // 
            this.C3.HeaderText = "Stamp(RTC)";
            this.C3.Name = "C3";
            this.C3.ReadOnly = true;
            // 
            // C4
            // 
            this.C4.HeaderText = "Status";
            this.C4.Name = "C4";
            this.C4.ReadOnly = true;
            // 
            // C5
            // 
            this.C5.HeaderText = "EPC";
            this.C5.Name = "C5";
            this.C5.ReadOnly = true;
            // 
            // C6
            // 
            this.C6.HeaderText = "TID";
            this.C6.Name = "C6";
            this.C6.ReadOnly = true;
            // 
            // C7
            // 
            this.C7.HeaderText = "Data";
            this.C7.Name = "C7";
            this.C7.ReadOnly = true;
            // 
            // C8
            // 
            this.C8.HeaderText = "RSSI";
            this.C8.Name = "C8";
            this.C8.ReadOnly = true;
            // 
            // C9
            // 
            this.C9.HeaderText = "Time";
            this.C9.Name = "C9";
            this.C9.ReadOnly = true;
            // 
            // C10
            // 
            this.C10.HeaderText = "Category";
            this.C10.Name = "C10";
            this.C10.ReadOnly = true;
            // 
            // C11
            // 
            this.C11.HeaderText = "Antenna";
            this.C11.Name = "C11";
            this.C11.ReadOnly = true;
            // 
            // grpEPCSetProtect
            // 
            this.grpEPCSetProtect.Controls.Add(this.groupBox3);
            this.grpEPCSetProtect.Controls.Add(this.label25);
            this.grpEPCSetProtect.Controls.Add(this.cbxSetProtect);
            this.grpEPCSetProtect.Controls.Add(this.label23);
            this.grpEPCSetProtect.Controls.Add(this.btnSetProtect);
            this.grpEPCSetProtect.Controls.Add(this.txtSetProtectPw);
            this.grpEPCSetProtect.Location = new System.Drawing.Point(6, 431);
            this.grpEPCSetProtect.Name = "grpEPCSetProtect";
            this.grpEPCSetProtect.Size = new System.Drawing.Size(322, 124);
            this.grpEPCSetProtect.TabIndex = 14;
            this.grpEPCSetProtect.TabStop = false;
            this.grpEPCSetProtect.Text = "Set Protect";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.radAdccessPwd);
            this.groupBox3.Controls.Add(this.radBankTID);
            this.groupBox3.Controls.Add(this.radBankUser);
            this.groupBox3.Controls.Add(this.radKillPwd);
            this.groupBox3.Controls.Add(this.radBankEPC);
            this.groupBox3.Location = new System.Drawing.Point(6, 16);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(310, 46);
            this.groupBox3.TabIndex = 7;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Memory bank selection";
            // 
            // radAdccessPwd
            // 
            this.radAdccessPwd.AutoSize = true;
            this.radAdccessPwd.Location = new System.Drawing.Point(69, 20);
            this.radAdccessPwd.Name = "radAdccessPwd";
            this.radAdccessPwd.Size = new System.Drawing.Size(84, 17);
            this.radAdccessPwd.TabIndex = 7;
            this.radAdccessPwd.TabStop = true;
            this.radAdccessPwd.Text = "Access Pwd";
            this.radAdccessPwd.UseVisualStyleBackColor = true;
            this.radAdccessPwd.CheckedChanged += new System.EventHandler(this.radAdccessPwd_CheckedChanged);
            // 
            // radBankTID
            // 
            this.radBankTID.AutoSize = true;
            this.radBankTID.Location = new System.Drawing.Point(211, 20);
            this.radBankTID.Name = "radBankTID";
            this.radBankTID.Size = new System.Drawing.Size(43, 17);
            this.radBankTID.TabIndex = 5;
            this.radBankTID.TabStop = true;
            this.radBankTID.Text = "TID";
            this.radBankTID.UseVisualStyleBackColor = true;
            this.radBankTID.CheckedChanged += new System.EventHandler(this.radBankTID_CheckedChanged);
            // 
            // radBankUser
            // 
            this.radBankUser.AutoSize = true;
            this.radBankUser.Location = new System.Drawing.Point(260, 20);
            this.radBankUser.Name = "radBankUser";
            this.radBankUser.Size = new System.Drawing.Size(47, 17);
            this.radBankUser.TabIndex = 6;
            this.radBankUser.TabStop = true;
            this.radBankUser.Text = "User";
            this.radBankUser.UseVisualStyleBackColor = true;
            this.radBankUser.CheckedChanged += new System.EventHandler(this.radBankUser_CheckedChanged);
            // 
            // radKillPwd
            // 
            this.radKillPwd.AutoSize = true;
            this.radKillPwd.Location = new System.Drawing.Point(6, 20);
            this.radKillPwd.Name = "radKillPwd";
            this.radKillPwd.Size = new System.Drawing.Size(62, 17);
            this.radKillPwd.TabIndex = 4;
            this.radKillPwd.TabStop = true;
            this.radKillPwd.Text = "Kill Pwd";
            this.radKillPwd.UseVisualStyleBackColor = true;
            this.radKillPwd.CheckedChanged += new System.EventHandler(this.radKillPwd_CheckedChanged);
            // 
            // radBankEPC
            // 
            this.radBankEPC.AutoSize = true;
            this.radBankEPC.Location = new System.Drawing.Point(159, 20);
            this.radBankEPC.Name = "radBankEPC";
            this.radBankEPC.Size = new System.Drawing.Size(46, 17);
            this.radBankEPC.TabIndex = 3;
            this.radBankEPC.TabStop = true;
            this.radBankEPC.Text = "EPC";
            this.radBankEPC.UseVisualStyleBackColor = true;
            this.radBankEPC.CheckedChanged += new System.EventHandler(this.radBankEPC_CheckedChanged);
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Location = new System.Drawing.Point(6, 76);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(63, 13);
            this.label25.TabIndex = 21;
            this.label25.Text = "Set Protect:";
            // 
            // cbxSetProtect
            // 
            this.cbxSetProtect.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxSetProtect.FormattingEnabled = true;
            this.cbxSetProtect.Location = new System.Drawing.Point(75, 68);
            this.cbxSetProtect.Name = "cbxSetProtect";
            this.cbxSetProtect.Size = new System.Drawing.Size(241, 21);
            this.cbxSetProtect.TabIndex = 20;
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Location = new System.Drawing.Point(3, 100);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(94, 13);
            this.label23.TabIndex = 19;
            this.label23.Text = "Access PW (Hex):";
            // 
            // btnSetProtect
            // 
            this.btnSetProtect.Location = new System.Drawing.Point(171, 95);
            this.btnSetProtect.Name = "btnSetProtect";
            this.btnSetProtect.Size = new System.Drawing.Size(145, 23);
            this.btnSetProtect.TabIndex = 6;
            this.btnSetProtect.Text = "Set";
            this.btnSetProtect.UseVisualStyleBackColor = true;
            this.btnSetProtect.Click += new System.EventHandler(this.btnSetProtect_Click);
            // 
            // txtSetProtectPw
            // 
            this.txtSetProtectPw.Location = new System.Drawing.Point(103, 95);
            this.txtSetProtectPw.MaxLength = 8;
            this.txtSetProtectPw.Multiline = true;
            this.txtSetProtectPw.Name = "txtSetProtectPw";
            this.txtSetProtectPw.Size = new System.Drawing.Size(62, 21);
            this.txtSetProtectPw.TabIndex = 5;
            this.txtSetProtectPw.Text = "00000000";
            // 
            // grpMemOps
            // 
            this.grpMemOps.Controls.Add(this.btnTagKill);
            this.grpMemOps.Controls.Add(this.btnQuery);
            this.grpMemOps.Controls.Add(this.btnBlockErase);
            this.grpMemOps.Controls.Add(this.btnBlockWrite);
            this.grpMemOps.Controls.Add(this.btnBlockRead);
            this.grpMemOps.Controls.Add(this.txtBlockData);
            this.grpMemOps.Controls.Add(this.txtAccessPwdOps);
            this.grpMemOps.Controls.Add(this.txtTotalWords);
            this.grpMemOps.Controls.Add(this.txtWordAddress);
            this.grpMemOps.Controls.Add(this.groupBox2);
            this.grpMemOps.Controls.Add(this.cbxUIDOps);
            this.grpMemOps.Controls.Add(this.label9);
            this.grpMemOps.Controls.Add(this.label10);
            this.grpMemOps.Controls.Add(this.label11);
            this.grpMemOps.Controls.Add(this.label12);
            this.grpMemOps.Location = new System.Drawing.Point(6, 194);
            this.grpMemOps.Name = "grpMemOps";
            this.grpMemOps.Size = new System.Drawing.Size(322, 231);
            this.grpMemOps.TabIndex = 2;
            this.grpMemOps.TabStop = false;
            this.grpMemOps.Text = "Memory operations";
            // 
            // btnTagKill
            // 
            this.btnTagKill.Location = new System.Drawing.Point(257, 202);
            this.btnTagKill.Name = "btnTagKill";
            this.btnTagKill.Size = new System.Drawing.Size(59, 23);
            this.btnTagKill.TabIndex = 19;
            this.btnTagKill.Text = "Kill";
            this.btnTagKill.UseVisualStyleBackColor = true;
            this.btnTagKill.Click += new System.EventHandler(this.btnTagKill_Click);
            // 
            // btnQuery
            // 
            this.btnQuery.Location = new System.Drawing.Point(6, 202);
            this.btnQuery.Name = "btnQuery";
            this.btnQuery.Size = new System.Drawing.Size(51, 23);
            this.btnQuery.TabIndex = 17;
            this.btnQuery.Text = "Query";
            this.btnQuery.UseVisualStyleBackColor = true;
            this.btnQuery.Click += new System.EventHandler(this.btnQuery_Click);
            // 
            // btnBlockErase
            // 
            this.btnBlockErase.Location = new System.Drawing.Point(196, 202);
            this.btnBlockErase.Name = "btnBlockErase";
            this.btnBlockErase.Size = new System.Drawing.Size(51, 23);
            this.btnBlockErase.TabIndex = 18;
            this.btnBlockErase.Text = "Erase";
            this.btnBlockErase.UseVisualStyleBackColor = true;
            this.btnBlockErase.Click += new System.EventHandler(this.btnBlockErase_Click);
            // 
            // btnBlockWrite
            // 
            this.btnBlockWrite.Location = new System.Drawing.Point(130, 202);
            this.btnBlockWrite.Name = "btnBlockWrite";
            this.btnBlockWrite.Size = new System.Drawing.Size(51, 23);
            this.btnBlockWrite.TabIndex = 17;
            this.btnBlockWrite.Text = "Write";
            this.btnBlockWrite.UseVisualStyleBackColor = true;
            this.btnBlockWrite.Click += new System.EventHandler(this.btnBlockWrite_Click);
            // 
            // btnBlockRead
            // 
            this.btnBlockRead.Location = new System.Drawing.Point(68, 202);
            this.btnBlockRead.Name = "btnBlockRead";
            this.btnBlockRead.Size = new System.Drawing.Size(51, 23);
            this.btnBlockRead.TabIndex = 14;
            this.btnBlockRead.Text = "Read";
            this.btnBlockRead.UseVisualStyleBackColor = true;
            this.btnBlockRead.Click += new System.EventHandler(this.btnBlockRead_Click);
            // 
            // txtBlockData
            // 
            this.txtBlockData.Location = new System.Drawing.Point(124, 176);
            this.txtBlockData.Name = "txtBlockData";
            this.txtBlockData.Size = new System.Drawing.Size(192, 20);
            this.txtBlockData.TabIndex = 15;
            // 
            // txtAccessPwdOps
            // 
            this.txtAccessPwdOps.Location = new System.Drawing.Point(124, 150);
            this.txtAccessPwdOps.Name = "txtAccessPwdOps";
            this.txtAccessPwdOps.Size = new System.Drawing.Size(192, 20);
            this.txtAccessPwdOps.TabIndex = 16;
            // 
            // txtTotalWords
            // 
            this.txtTotalWords.Location = new System.Drawing.Point(124, 124);
            this.txtTotalWords.Name = "txtTotalWords";
            this.txtTotalWords.Size = new System.Drawing.Size(192, 20);
            this.txtTotalWords.TabIndex = 15;
            // 
            // txtWordAddress
            // 
            this.txtWordAddress.Location = new System.Drawing.Point(124, 98);
            this.txtWordAddress.Name = "txtWordAddress";
            this.txtWordAddress.Size = new System.Drawing.Size(192, 20);
            this.txtWordAddress.TabIndex = 14;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.radUserBank);
            this.groupBox2.Controls.Add(this.radTIDBank);
            this.groupBox2.Controls.Add(this.radReservedBank);
            this.groupBox2.Controls.Add(this.radEPCBank);
            this.groupBox2.Location = new System.Drawing.Point(6, 46);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(310, 46);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Memory bank selection";
            // 
            // radUserBank
            // 
            this.radUserBank.AutoSize = true;
            this.radUserBank.Location = new System.Drawing.Point(257, 20);
            this.radUserBank.Name = "radUserBank";
            this.radUserBank.Size = new System.Drawing.Size(47, 17);
            this.radUserBank.TabIndex = 5;
            this.radUserBank.TabStop = true;
            this.radUserBank.Text = "User";
            this.radUserBank.UseVisualStyleBackColor = true;
            // 
            // radTIDBank
            // 
            this.radTIDBank.AutoSize = true;
            this.radTIDBank.Location = new System.Drawing.Point(178, 20);
            this.radTIDBank.Name = "radTIDBank";
            this.radTIDBank.Size = new System.Drawing.Size(43, 17);
            this.radTIDBank.TabIndex = 6;
            this.radTIDBank.TabStop = true;
            this.radTIDBank.Text = "TID";
            this.radTIDBank.UseVisualStyleBackColor = true;
            // 
            // radReservedBank
            // 
            this.radReservedBank.AutoSize = true;
            this.radReservedBank.Location = new System.Drawing.Point(6, 20);
            this.radReservedBank.Name = "radReservedBank";
            this.radReservedBank.Size = new System.Drawing.Size(71, 17);
            this.radReservedBank.TabIndex = 4;
            this.radReservedBank.TabStop = true;
            this.radReservedBank.Text = "Reserved";
            this.radReservedBank.UseVisualStyleBackColor = true;
            // 
            // radEPCBank
            // 
            this.radEPCBank.AutoSize = true;
            this.radEPCBank.Location = new System.Drawing.Point(102, 20);
            this.radEPCBank.Name = "radEPCBank";
            this.radEPCBank.Size = new System.Drawing.Size(46, 17);
            this.radEPCBank.TabIndex = 3;
            this.radEPCBank.TabStop = true;
            this.radEPCBank.Text = "EPC";
            this.radEPCBank.UseVisualStyleBackColor = true;
            // 
            // cbxUIDOps
            // 
            this.cbxUIDOps.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxUIDOps.FormattingEnabled = true;
            this.cbxUIDOps.Location = new System.Drawing.Point(6, 19);
            this.cbxUIDOps.Name = "cbxUIDOps";
            this.cbxUIDOps.Size = new System.Drawing.Size(310, 21);
            this.cbxUIDOps.TabIndex = 3;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(3, 105);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(112, 13);
            this.label9.TabIndex = 3;
            this.label9.Text = "Starting Address(Hex):";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(3, 131);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(105, 13);
            this.label10.TabIndex = 4;
            this.label10.Text = "Block Length(Word):";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(3, 157);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(81, 13);
            this.label11.TabIndex = 5;
            this.label11.Text = "Password(Hex):";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(3, 183);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(58, 13);
            this.label12.TabIndex = 6;
            this.label12.Text = "Data(Hex):";
            // 
            // grpInventorySetup
            // 
            this.grpInventorySetup.Controls.Add(this.groupBox26);
            this.grpInventorySetup.Controls.Add(this.label21);
            this.grpInventorySetup.Controls.Add(this.tbUIDCont);
            this.grpInventorySetup.Controls.Add(this.chkIDReverse2);
            this.grpInventorySetup.Controls.Add(this.btn_BRMLogOps);
            this.grpInventorySetup.Controls.Add(this.radEPCOnly);
            this.grpInventorySetup.Controls.Add(this.radTIDOnly);
            this.grpInventorySetup.Controls.Add(this.radEPC_TID);
            this.grpInventorySetup.Controls.Add(this.chkRSSI);
            this.grpInventorySetup.Controls.Add(this.btnInventory);
            this.grpInventorySetup.Controls.Add(this.btnSetTarget);
            this.grpInventorySetup.Controls.Add(this.btnSetSession);
            this.grpInventorySetup.Controls.Add(this.btnSetQValue);
            this.grpInventorySetup.Controls.Add(this.btnGetTarget);
            this.grpInventorySetup.Controls.Add(this.btnGetSession);
            this.grpInventorySetup.Controls.Add(this.btnGetQValue);
            this.grpInventorySetup.Controls.Add(this.cbxInterval);
            this.grpInventorySetup.Controls.Add(this.cbxQValue);
            this.grpInventorySetup.Controls.Add(this.cbxTarget);
            this.grpInventorySetup.Controls.Add(this.label8);
            this.grpInventorySetup.Controls.Add(this.cbxSession);
            this.grpInventorySetup.Controls.Add(this.label7);
            this.grpInventorySetup.Controls.Add(this.label6);
            this.grpInventorySetup.Controls.Add(this.label5);
            this.grpInventorySetup.Location = new System.Drawing.Point(3, 6);
            this.grpInventorySetup.Name = "grpInventorySetup";
            this.grpInventorySetup.Size = new System.Drawing.Size(325, 184);
            this.grpInventorySetup.TabIndex = 0;
            this.grpInventorySetup.TabStop = false;
            this.grpInventorySetup.Text = "Inventory setup";
            // 
            // groupBox26
            // 
            this.groupBox26.Controls.Add(this.label89);
            this.groupBox26.Controls.Add(this.btnExtInventory);
            this.groupBox26.Controls.Add(this.chkAnt6);
            this.groupBox26.Controls.Add(this.chkAnt5);
            this.groupBox26.Controls.Add(this.chkAnt4);
            this.groupBox26.Controls.Add(this.chkAnt3);
            this.groupBox26.Controls.Add(this.chkAnt2);
            this.groupBox26.Controls.Add(this.chkAnt1);
            this.groupBox26.Location = new System.Drawing.Point(215, 44);
            this.groupBox26.Name = "groupBox26";
            this.groupBox26.Size = new System.Drawing.Size(110, 134);
            this.groupBox26.TabIndex = 23;
            this.groupBox26.TabStop = false;
            this.groupBox26.Text = "Ext. Inv.";
            // 
            // label89
            // 
            this.label89.AutoSize = true;
            this.label89.Location = new System.Drawing.Point(20, 19);
            this.label89.Name = "label89";
            this.label89.Size = new System.Drawing.Size(68, 13);
            this.label89.TabIndex = 25;
            this.label89.Text = "Antenna Sel.";
            // 
            // btnExtInventory
            // 
            this.btnExtInventory.Location = new System.Drawing.Point(8, 83);
            this.btnExtInventory.Name = "btnExtInventory";
            this.btnExtInventory.Size = new System.Drawing.Size(96, 45);
            this.btnExtInventory.TabIndex = 24;
            this.btnExtInventory.Text = "Extended Inventory";
            this.btnExtInventory.UseVisualStyleBackColor = true;
            this.btnExtInventory.Click += new System.EventHandler(this.btnExtInventory_Click);
            // 
            // chkAnt6
            // 
            this.chkAnt6.AutoSize = true;
            this.chkAnt6.Location = new System.Drawing.Point(78, 60);
            this.chkAnt6.Name = "chkAnt6";
            this.chkAnt6.Size = new System.Drawing.Size(32, 17);
            this.chkAnt6.TabIndex = 5;
            this.chkAnt6.Text = "6";
            this.chkAnt6.UseVisualStyleBackColor = true;
            // 
            // chkAnt5
            // 
            this.chkAnt5.AutoSize = true;
            this.chkAnt5.Location = new System.Drawing.Point(41, 60);
            this.chkAnt5.Name = "chkAnt5";
            this.chkAnt5.Size = new System.Drawing.Size(32, 17);
            this.chkAnt5.TabIndex = 4;
            this.chkAnt5.Text = "5";
            this.chkAnt5.UseVisualStyleBackColor = true;
            // 
            // chkAnt4
            // 
            this.chkAnt4.AutoSize = true;
            this.chkAnt4.Location = new System.Drawing.Point(6, 60);
            this.chkAnt4.Name = "chkAnt4";
            this.chkAnt4.Size = new System.Drawing.Size(32, 17);
            this.chkAnt4.TabIndex = 3;
            this.chkAnt4.Text = "4";
            this.chkAnt4.UseVisualStyleBackColor = true;
            // 
            // chkAnt3
            // 
            this.chkAnt3.AutoSize = true;
            this.chkAnt3.Location = new System.Drawing.Point(78, 37);
            this.chkAnt3.Name = "chkAnt3";
            this.chkAnt3.Size = new System.Drawing.Size(32, 17);
            this.chkAnt3.TabIndex = 2;
            this.chkAnt3.Text = "3";
            this.chkAnt3.UseVisualStyleBackColor = true;
            // 
            // chkAnt2
            // 
            this.chkAnt2.AutoSize = true;
            this.chkAnt2.Location = new System.Drawing.Point(41, 37);
            this.chkAnt2.Name = "chkAnt2";
            this.chkAnt2.Size = new System.Drawing.Size(32, 17);
            this.chkAnt2.TabIndex = 1;
            this.chkAnt2.Text = "2";
            this.chkAnt2.UseVisualStyleBackColor = true;
            // 
            // chkAnt1
            // 
            this.chkAnt1.AutoSize = true;
            this.chkAnt1.Location = new System.Drawing.Point(6, 37);
            this.chkAnt1.Name = "chkAnt1";
            this.chkAnt1.Size = new System.Drawing.Size(32, 17);
            this.chkAnt1.TabIndex = 0;
            this.chkAnt1.Text = "1";
            this.chkAnt1.UseVisualStyleBackColor = true;
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(217, 22);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(38, 13);
            this.label21.TabIndex = 18;
            this.label21.Text = "Count:";
            // 
            // tbUIDCont
            // 
            this.tbUIDCont.Location = new System.Drawing.Point(259, 18);
            this.tbUIDCont.Name = "tbUIDCont";
            this.tbUIDCont.Size = new System.Drawing.Size(60, 20);
            this.tbUIDCont.TabIndex = 22;
            // 
            // chkIDReverse2
            // 
            this.chkIDReverse2.AutoSize = true;
            this.chkIDReverse2.Location = new System.Drawing.Point(6, 13);
            this.chkIDReverse2.Name = "chkIDReverse2";
            this.chkIDReverse2.Size = new System.Drawing.Size(15, 14);
            this.chkIDReverse2.TabIndex = 2;
            this.chkIDReverse2.UseVisualStyleBackColor = true;
            this.chkIDReverse2.CheckedChanged += new System.EventHandler(this.chkIDReverse2_CheckedChanged);
            // 
            // btn_BRMLogOps
            // 
            this.btn_BRMLogOps.Location = new System.Drawing.Point(100, 155);
            this.btn_BRMLogOps.Name = "btn_BRMLogOps";
            this.btn_BRMLogOps.Size = new System.Drawing.Size(109, 23);
            this.btn_BRMLogOps.TabIndex = 21;
            this.btn_BRMLogOps.Tag = "0";
            this.btn_BRMLogOps.Text = "Start BRM log read";
            this.btn_BRMLogOps.UseVisualStyleBackColor = true;
            this.btn_BRMLogOps.Click += new System.EventHandler(this.btn_BRMLogOps_Click);
            // 
            // radEPCOnly
            // 
            this.radEPCOnly.AutoSize = true;
            this.radEPCOnly.Location = new System.Drawing.Point(9, 133);
            this.radEPCOnly.Name = "radEPCOnly";
            this.radEPCOnly.Size = new System.Drawing.Size(46, 17);
            this.radEPCOnly.TabIndex = 17;
            this.radEPCOnly.TabStop = true;
            this.radEPCOnly.Text = "EPC";
            this.radEPCOnly.UseVisualStyleBackColor = true;
            // 
            // radTIDOnly
            // 
            this.radTIDOnly.AutoSize = true;
            this.radTIDOnly.Location = new System.Drawing.Point(61, 133);
            this.radTIDOnly.Name = "radTIDOnly";
            this.radTIDOnly.Size = new System.Drawing.Size(43, 17);
            this.radTIDOnly.TabIndex = 20;
            this.radTIDOnly.TabStop = true;
            this.radTIDOnly.Text = "TID";
            this.radTIDOnly.UseVisualStyleBackColor = true;
            this.radTIDOnly.CheckedChanged += new System.EventHandler(this.radTIDOnly_CheckedChanged);
            // 
            // radEPC_TID
            // 
            this.radEPC_TID.AutoSize = true;
            this.radEPC_TID.Location = new System.Drawing.Point(110, 133);
            this.radEPC_TID.Name = "radEPC_TID";
            this.radEPC_TID.Size = new System.Drawing.Size(70, 17);
            this.radEPC_TID.TabIndex = 2;
            this.radEPC_TID.TabStop = true;
            this.radEPC_TID.Text = "EPC+TID";
            this.radEPC_TID.UseVisualStyleBackColor = true;
            // 
            // chkRSSI
            // 
            this.chkRSSI.AutoSize = true;
            this.chkRSSI.Location = new System.Drawing.Point(142, 108);
            this.chkRSSI.Name = "chkRSSI";
            this.chkRSSI.Size = new System.Drawing.Size(51, 17);
            this.chkRSSI.TabIndex = 11;
            this.chkRSSI.Text = "RSSI";
            this.chkRSSI.UseVisualStyleBackColor = true;
            // 
            // btnInventory
            // 
            this.btnInventory.Location = new System.Drawing.Point(6, 155);
            this.btnInventory.Name = "btnInventory";
            this.btnInventory.Size = new System.Drawing.Size(91, 23);
            this.btnInventory.TabIndex = 1;
            this.btnInventory.Tag = "0";
            this.btnInventory.Text = "Start Inventory";
            this.btnInventory.UseVisualStyleBackColor = true;
            this.btnInventory.Click += new System.EventHandler(this.btnInventory_Click);
            // 
            // btnSetTarget
            // 
            this.btnSetTarget.Location = new System.Drawing.Point(169, 79);
            this.btnSetTarget.Name = "btnSetTarget";
            this.btnSetTarget.Size = new System.Drawing.Size(40, 20);
            this.btnSetTarget.TabIndex = 9;
            this.btnSetTarget.Text = "Set";
            this.btnSetTarget.UseVisualStyleBackColor = true;
            this.btnSetTarget.Click += new System.EventHandler(this.btnSetTarget_Click);
            // 
            // btnSetSession
            // 
            this.btnSetSession.Location = new System.Drawing.Point(169, 50);
            this.btnSetSession.Name = "btnSetSession";
            this.btnSetSession.Size = new System.Drawing.Size(40, 20);
            this.btnSetSession.TabIndex = 8;
            this.btnSetSession.Text = "Set";
            this.btnSetSession.UseVisualStyleBackColor = true;
            this.btnSetSession.Click += new System.EventHandler(this.btnSetSession_Click);
            // 
            // btnSetQValue
            // 
            this.btnSetQValue.Location = new System.Drawing.Point(169, 21);
            this.btnSetQValue.Name = "btnSetQValue";
            this.btnSetQValue.Size = new System.Drawing.Size(40, 20);
            this.btnSetQValue.TabIndex = 7;
            this.btnSetQValue.Text = "Set";
            this.btnSetQValue.UseVisualStyleBackColor = true;
            this.btnSetQValue.Click += new System.EventHandler(this.btnSetQValue_Click);
            // 
            // btnGetTarget
            // 
            this.btnGetTarget.Location = new System.Drawing.Point(123, 79);
            this.btnGetTarget.Name = "btnGetTarget";
            this.btnGetTarget.Size = new System.Drawing.Size(40, 20);
            this.btnGetTarget.TabIndex = 6;
            this.btnGetTarget.Text = "Get";
            this.btnGetTarget.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnGetTarget.UseVisualStyleBackColor = true;
            this.btnGetTarget.Click += new System.EventHandler(this.btnGetTarget_Click);
            // 
            // btnGetSession
            // 
            this.btnGetSession.Location = new System.Drawing.Point(123, 50);
            this.btnGetSession.Name = "btnGetSession";
            this.btnGetSession.Size = new System.Drawing.Size(40, 20);
            this.btnGetSession.TabIndex = 5;
            this.btnGetSession.Text = "Get";
            this.btnGetSession.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnGetSession.UseVisualStyleBackColor = true;
            this.btnGetSession.Click += new System.EventHandler(this.btnGetSession_Click);
            // 
            // btnGetQValue
            // 
            this.btnGetQValue.Location = new System.Drawing.Point(123, 22);
            this.btnGetQValue.Name = "btnGetQValue";
            this.btnGetQValue.Size = new System.Drawing.Size(40, 20);
            this.btnGetQValue.TabIndex = 4;
            this.btnGetQValue.Text = "Get";
            this.btnGetQValue.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnGetQValue.UseVisualStyleBackColor = true;
            this.btnGetQValue.Click += new System.EventHandler(this.btnGetQValue_Click);
            // 
            // cbxInterval
            // 
            this.cbxInterval.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxInterval.FormattingEnabled = true;
            this.cbxInterval.Location = new System.Drawing.Point(60, 106);
            this.cbxInterval.Name = "cbxInterval";
            this.cbxInterval.Size = new System.Drawing.Size(58, 21);
            this.cbxInterval.TabIndex = 3;
            this.cbxInterval.SelectedIndexChanged += new System.EventHandler(this.cbxInterval_SelectedIndexChanged);
            // 
            // cbxQValue
            // 
            this.cbxQValue.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxQValue.FormattingEnabled = true;
            this.cbxQValue.Location = new System.Drawing.Point(60, 22);
            this.cbxQValue.Name = "cbxQValue";
            this.cbxQValue.Size = new System.Drawing.Size(58, 21);
            this.cbxQValue.TabIndex = 1;
            // 
            // cbxTarget
            // 
            this.cbxTarget.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxTarget.FormattingEnabled = true;
            this.cbxTarget.Location = new System.Drawing.Point(60, 79);
            this.cbxTarget.Name = "cbxTarget";
            this.cbxTarget.Size = new System.Drawing.Size(58, 21);
            this.cbxTarget.TabIndex = 2;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(6, 114);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(45, 13);
            this.label8.TabIndex = 3;
            this.label8.Text = "Interval:";
            // 
            // cbxSession
            // 
            this.cbxSession.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxSession.FormattingEnabled = true;
            this.cbxSession.Location = new System.Drawing.Point(60, 50);
            this.cbxSession.Name = "cbxSession";
            this.cbxSession.Size = new System.Drawing.Size(58, 21);
            this.cbxSession.TabIndex = 1;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 87);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(41, 13);
            this.label7.TabIndex = 1;
            this.label7.Text = "Target:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 58);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(47, 13);
            this.label6.TabIndex = 2;
            this.label6.Text = "Session:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 30);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(48, 13);
            this.label5.TabIndex = 1;
            this.label5.Text = "Q Value:";
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.grpExtInventory);
            this.tabPage3.Controls.Add(this.grpExtInvRouteOptions);
            this.tabPage3.Controls.Add(this.chkMask9Enabled);
            this.tabPage3.Controls.Add(this.chkMask8Enabled);
            this.tabPage3.Controls.Add(this.chkMask7Enabled);
            this.tabPage3.Controls.Add(this.chkMask6Enabled);
            this.tabPage3.Controls.Add(this.chkMask5Enabled);
            this.tabPage3.Controls.Add(this.chkMask4Enabled);
            this.tabPage3.Controls.Add(this.chkMask3Enabled);
            this.tabPage3.Controls.Add(this.chkMask2Enabled);
            this.tabPage3.Controls.Add(this.chkMask1Enabled);
            this.tabPage3.Controls.Add(this.chkMask0Enabled);
            this.tabPage3.Controls.Add(this.btnMask9Erase);
            this.tabPage3.Controls.Add(this.btnMask8Erase);
            this.tabPage3.Controls.Add(this.btnMask7Erase);
            this.tabPage3.Controls.Add(this.btnMask6Erase);
            this.tabPage3.Controls.Add(this.btnMask5Erase);
            this.tabPage3.Controls.Add(this.btnMask4Erase);
            this.tabPage3.Controls.Add(this.btnMask3Erase);
            this.tabPage3.Controls.Add(this.btnMask2Erase);
            this.tabPage3.Controls.Add(this.btnMask1Erase);
            this.tabPage3.Controls.Add(this.btnMask0Erase);
            this.tabPage3.Controls.Add(this.label69);
            this.tabPage3.Controls.Add(this.label68);
            this.tabPage3.Controls.Add(this.label67);
            this.tabPage3.Controls.Add(this.label66);
            this.tabPage3.Controls.Add(this.label65);
            this.tabPage3.Controls.Add(this.label64);
            this.tabPage3.Controls.Add(this.label63);
            this.tabPage3.Controls.Add(this.label62);
            this.tabPage3.Controls.Add(this.label61);
            this.tabPage3.Controls.Add(this.label60);
            this.tabPage3.Controls.Add(this.chkMask9);
            this.tabPage3.Controls.Add(this.SetMask9);
            this.tabPage3.Controls.Add(this.GetMask9);
            this.tabPage3.Controls.Add(this.txtMask9);
            this.tabPage3.Controls.Add(this.chkMask8);
            this.tabPage3.Controls.Add(this.SetMask8);
            this.tabPage3.Controls.Add(this.GetMask8);
            this.tabPage3.Controls.Add(this.txtMask8);
            this.tabPage3.Controls.Add(this.chkMask7);
            this.tabPage3.Controls.Add(this.SetMask7);
            this.tabPage3.Controls.Add(this.GetMask7);
            this.tabPage3.Controls.Add(this.txtMask7);
            this.tabPage3.Controls.Add(this.chkMask6);
            this.tabPage3.Controls.Add(this.SetMask6);
            this.tabPage3.Controls.Add(this.GetMask6);
            this.tabPage3.Controls.Add(this.txtMask6);
            this.tabPage3.Controls.Add(this.chkMask5);
            this.tabPage3.Controls.Add(this.SetMask5);
            this.tabPage3.Controls.Add(this.GetMask5);
            this.tabPage3.Controls.Add(this.txtMask5);
            this.tabPage3.Controls.Add(this.chkMask4);
            this.tabPage3.Controls.Add(this.SetMask4);
            this.tabPage3.Controls.Add(this.GetMask4);
            this.tabPage3.Controls.Add(this.txtMask4);
            this.tabPage3.Controls.Add(this.chkMask3);
            this.tabPage3.Controls.Add(this.SetMask3);
            this.tabPage3.Controls.Add(this.GetMask3);
            this.tabPage3.Controls.Add(this.txtMask3);
            this.tabPage3.Controls.Add(this.chkMask2);
            this.tabPage3.Controls.Add(this.SetMask2);
            this.tabPage3.Controls.Add(this.GetMask2);
            this.tabPage3.Controls.Add(this.txtMask2);
            this.tabPage3.Controls.Add(this.chkMask1);
            this.tabPage3.Controls.Add(this.SetMask1);
            this.tabPage3.Controls.Add(this.GetMask1);
            this.tabPage3.Controls.Add(this.txtMask1);
            this.tabPage3.Controls.Add(this.chkMask0);
            this.tabPage3.Controls.Add(this.SetMask0);
            this.tabPage3.Controls.Add(this.GetMask0);
            this.tabPage3.Controls.Add(this.txtMask0);
            this.tabPage3.Controls.Add(this.groupBox13);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(985, 621);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Extended Inventory Config";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // grpExtInventory
            // 
            this.grpExtInventory.Controls.Add(this.groupBox46);
            this.grpExtInventory.Controls.Add(this.groupBox37);
            this.grpExtInventory.Controls.Add(this.btnExtInCfgFlagsGet);
            this.grpExtInventory.Controls.Add(this.chkIncludeAntennaID);
            this.grpExtInventory.Controls.Add(this.chkBufferedReadMode);
            this.grpExtInventory.Controls.Add(this.chkReaderID);
            this.grpExtInventory.Controls.Add(this.txtHeartbeat2);
            this.grpExtInventory.Controls.Add(this.label56);
            this.grpExtInventory.Controls.Add(this.chkHeartbeatEn);
            this.grpExtInventory.Controls.Add(this.groupBox9);
            this.grpExtInventory.Controls.Add(this.btnGetInvCfg);
            this.grpExtInventory.Controls.Add(this.btnSetInvCfg);
            this.grpExtInventory.Controls.Add(this.groupBox7);
            this.grpExtInventory.Controls.Add(this.chkInvOpsEnable);
            this.grpExtInventory.Controls.Add(this.groupBox5);
            this.grpExtInventory.Controls.Add(this.groupBox4);
            this.grpExtInventory.Controls.Add(this.chkReportTID);
            this.grpExtInventory.Controls.Add(this.chkIOPassEnable);
            this.grpExtInventory.Controls.Add(this.chkReportRSSI);
            this.grpExtInventory.Controls.Add(this.chkInvTriggerEnable);
            this.grpExtInventory.Controls.Add(this.chkIOFailEnable);
            this.grpExtInventory.Controls.Add(this.chkComplaintTags);
            this.grpExtInventory.Controls.Add(this.chkReportUserMem);
            this.grpExtInventory.Controls.Add(this.chkAccessPwd);
            this.grpExtInventory.Controls.Add(this.chkEPCMask);
            this.grpExtInventory.Location = new System.Drawing.Point(6, 6);
            this.grpExtInventory.Name = "grpExtInventory";
            this.grpExtInventory.Size = new System.Drawing.Size(973, 277);
            this.grpExtInventory.TabIndex = 13;
            this.grpExtInventory.TabStop = false;
            this.grpExtInventory.Text = "Extended auto inventory setup";
            // 
            // groupBox46
            // 
            this.groupBox46.Controls.Add(this.label90);
            this.groupBox46.Controls.Add(this.txtCycleTime);
            this.groupBox46.Controls.Add(this.btnCycleTimeSet);
            this.groupBox46.Controls.Add(this.btnCycleTimeGet);
            this.groupBox46.Location = new System.Drawing.Point(555, 143);
            this.groupBox46.Name = "groupBox46";
            this.groupBox46.Size = new System.Drawing.Size(231, 70);
            this.groupBox46.TabIndex = 58;
            this.groupBox46.TabStop = false;
            this.groupBox46.Text = "Ex Inv Data Send Interval";
            // 
            // label90
            // 
            this.label90.AutoSize = true;
            this.label90.Location = new System.Drawing.Point(10, 23);
            this.label90.Name = "label90";
            this.label90.Size = new System.Drawing.Size(78, 13);
            this.label90.TabIndex = 130;
            this.label90.Text = "Interval (mSec)";
            // 
            // txtCycleTime
            // 
            this.txtCycleTime.Location = new System.Drawing.Point(6, 41);
            this.txtCycleTime.Name = "txtCycleTime";
            this.txtCycleTime.Size = new System.Drawing.Size(100, 20);
            this.txtCycleTime.TabIndex = 129;
            // 
            // btnCycleTimeSet
            // 
            this.btnCycleTimeSet.Location = new System.Drawing.Point(182, 41);
            this.btnCycleTimeSet.Name = "btnCycleTimeSet";
            this.btnCycleTimeSet.Size = new System.Drawing.Size(43, 23);
            this.btnCycleTimeSet.TabIndex = 128;
            this.btnCycleTimeSet.Text = "Set";
            this.btnCycleTimeSet.UseVisualStyleBackColor = true;
            this.btnCycleTimeSet.Click += new System.EventHandler(this.btnCycleTimeSet_Click);
            // 
            // btnCycleTimeGet
            // 
            this.btnCycleTimeGet.Location = new System.Drawing.Point(131, 41);
            this.btnCycleTimeGet.Name = "btnCycleTimeGet";
            this.btnCycleTimeGet.Size = new System.Drawing.Size(43, 23);
            this.btnCycleTimeGet.TabIndex = 127;
            this.btnCycleTimeGet.Text = "Get";
            this.btnCycleTimeGet.UseVisualStyleBackColor = true;
            this.btnCycleTimeGet.Click += new System.EventHandler(this.btnCycleTimeGet_Click);
            // 
            // groupBox37
            // 
            this.groupBox37.Controls.Add(this.btnSetMuxConfig);
            this.groupBox37.Controls.Add(this.btnGetMuxConfig);
            this.groupBox37.Controls.Add(this.ChkExtAnt6);
            this.groupBox37.Controls.Add(this.ChkExtAnt5);
            this.groupBox37.Controls.Add(this.ChkExtAnt4);
            this.groupBox37.Controls.Add(this.ChkExtAnt3);
            this.groupBox37.Controls.Add(this.ChkExtAnt2);
            this.groupBox37.Controls.Add(this.ChkExtAnt1);
            this.groupBox37.Controls.Add(this.groupBox6);
            this.groupBox37.Location = new System.Drawing.Point(555, 68);
            this.groupBox37.Name = "groupBox37";
            this.groupBox37.Size = new System.Drawing.Size(231, 73);
            this.groupBox37.TabIndex = 57;
            this.groupBox37.TabStop = false;
            this.groupBox37.Text = "Mux. antenna selection";
            // 
            // btnSetMuxConfig
            // 
            this.btnSetMuxConfig.Location = new System.Drawing.Point(182, 43);
            this.btnSetMuxConfig.Name = "btnSetMuxConfig";
            this.btnSetMuxConfig.Size = new System.Drawing.Size(43, 23);
            this.btnSetMuxConfig.TabIndex = 128;
            this.btnSetMuxConfig.Text = "Set";
            this.btnSetMuxConfig.UseVisualStyleBackColor = true;
            this.btnSetMuxConfig.Click += new System.EventHandler(this.btnSetMuxConfig_Click);
            // 
            // btnGetMuxConfig
            // 
            this.btnGetMuxConfig.Location = new System.Drawing.Point(133, 43);
            this.btnGetMuxConfig.Name = "btnGetMuxConfig";
            this.btnGetMuxConfig.Size = new System.Drawing.Size(43, 23);
            this.btnGetMuxConfig.TabIndex = 127;
            this.btnGetMuxConfig.Text = "Get";
            this.btnGetMuxConfig.UseVisualStyleBackColor = true;
            this.btnGetMuxConfig.Click += new System.EventHandler(this.btnGetMuxConfig_Click);
            // 
            // ChkExtAnt6
            // 
            this.ChkExtAnt6.AutoSize = true;
            this.ChkExtAnt6.Location = new System.Drawing.Point(196, 21);
            this.ChkExtAnt6.Name = "ChkExtAnt6";
            this.ChkExtAnt6.Size = new System.Drawing.Size(32, 17);
            this.ChkExtAnt6.TabIndex = 5;
            this.ChkExtAnt6.Text = "6";
            this.ChkExtAnt6.UseVisualStyleBackColor = true;
            // 
            // ChkExtAnt5
            // 
            this.ChkExtAnt5.AutoSize = true;
            this.ChkExtAnt5.Location = new System.Drawing.Point(158, 21);
            this.ChkExtAnt5.Name = "ChkExtAnt5";
            this.ChkExtAnt5.Size = new System.Drawing.Size(32, 17);
            this.ChkExtAnt5.TabIndex = 4;
            this.ChkExtAnt5.Text = "5";
            this.ChkExtAnt5.UseVisualStyleBackColor = true;
            // 
            // ChkExtAnt4
            // 
            this.ChkExtAnt4.AutoSize = true;
            this.ChkExtAnt4.Location = new System.Drawing.Point(120, 21);
            this.ChkExtAnt4.Name = "ChkExtAnt4";
            this.ChkExtAnt4.Size = new System.Drawing.Size(32, 17);
            this.ChkExtAnt4.TabIndex = 3;
            this.ChkExtAnt4.Text = "4";
            this.ChkExtAnt4.UseVisualStyleBackColor = true;
            // 
            // ChkExtAnt3
            // 
            this.ChkExtAnt3.AutoSize = true;
            this.ChkExtAnt3.Location = new System.Drawing.Point(82, 21);
            this.ChkExtAnt3.Name = "ChkExtAnt3";
            this.ChkExtAnt3.Size = new System.Drawing.Size(32, 17);
            this.ChkExtAnt3.TabIndex = 2;
            this.ChkExtAnt3.Text = "3";
            this.ChkExtAnt3.UseVisualStyleBackColor = true;
            // 
            // ChkExtAnt2
            // 
            this.ChkExtAnt2.AutoSize = true;
            this.ChkExtAnt2.Location = new System.Drawing.Point(44, 21);
            this.ChkExtAnt2.Name = "ChkExtAnt2";
            this.ChkExtAnt2.Size = new System.Drawing.Size(32, 17);
            this.ChkExtAnt2.TabIndex = 1;
            this.ChkExtAnt2.Text = "2";
            this.ChkExtAnt2.UseVisualStyleBackColor = true;
            // 
            // ChkExtAnt1
            // 
            this.ChkExtAnt1.AutoSize = true;
            this.ChkExtAnt1.Location = new System.Drawing.Point(6, 21);
            this.ChkExtAnt1.Name = "ChkExtAnt1";
            this.ChkExtAnt1.Size = new System.Drawing.Size(32, 17);
            this.ChkExtAnt1.TabIndex = 0;
            this.ChkExtAnt1.Text = "1";
            this.ChkExtAnt1.UseVisualStyleBackColor = true;
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.label40);
            this.groupBox6.Controls.Add(this.label39);
            this.groupBox6.Controls.Add(this.txtIO3_DwellTime);
            this.groupBox6.Controls.Add(this.cbxIO3State);
            this.groupBox6.Location = new System.Drawing.Point(136, 72);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(136, 103);
            this.groupBox6.TabIndex = 25;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Trigger input setup";
            this.groupBox6.Visible = false;
            // 
            // label40
            // 
            this.label40.AutoSize = true;
            this.label40.Location = new System.Drawing.Point(6, 49);
            this.label40.Name = "label40";
            this.label40.Size = new System.Drawing.Size(68, 13);
            this.label40.TabIndex = 20;
            this.label40.Text = "Active State:";
            // 
            // label39
            // 
            this.label39.AutoSize = true;
            this.label39.Location = new System.Drawing.Point(6, 79);
            this.label39.Name = "label39";
            this.label39.Size = new System.Drawing.Size(78, 13);
            this.label39.TabIndex = 19;
            this.label39.Text = "Time (x100ms):";
            this.label39.Click += new System.EventHandler(this.label39_Click);
            // 
            // txtIO3_DwellTime
            // 
            this.txtIO3_DwellTime.Location = new System.Drawing.Point(92, 72);
            this.txtIO3_DwellTime.MaxLength = 8;
            this.txtIO3_DwellTime.Name = "txtIO3_DwellTime";
            this.txtIO3_DwellTime.Size = new System.Drawing.Size(38, 20);
            this.txtIO3_DwellTime.TabIndex = 18;
            this.txtIO3_DwellTime.Text = "10";
            this.txtIO3_DwellTime.TextChanged += new System.EventHandler(this.txtIO3_DwellTime_TextChanged);
            // 
            // cbxIO3State
            // 
            this.cbxIO3State.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxIO3State.FormattingEnabled = true;
            this.cbxIO3State.Location = new System.Drawing.Point(76, 46);
            this.cbxIO3State.Name = "cbxIO3State";
            this.cbxIO3State.Size = new System.Drawing.Size(54, 21);
            this.cbxIO3State.TabIndex = 15;
            // 
            // btnExtInCfgFlagsGet
            // 
            this.btnExtInCfgFlagsGet.Location = new System.Drawing.Point(6, 248);
            this.btnExtInCfgFlagsGet.Name = "btnExtInCfgFlagsGet";
            this.btnExtInCfgFlagsGet.Size = new System.Drawing.Size(123, 23);
            this.btnExtInCfgFlagsGet.TabIndex = 55;
            this.btnExtInCfgFlagsGet.Text = "Get config. flags";
            this.btnExtInCfgFlagsGet.UseVisualStyleBackColor = true;
            this.btnExtInCfgFlagsGet.Click += new System.EventHandler(this.btnExtInCfgFlagsGet_Click);
            // 
            // chkIncludeAntennaID
            // 
            this.chkIncludeAntennaID.AutoSize = true;
            this.chkIncludeAntennaID.Location = new System.Drawing.Point(703, 45);
            this.chkIncludeAntennaID.Name = "chkIncludeAntennaID";
            this.chkIncludeAntennaID.Size = new System.Drawing.Size(117, 17);
            this.chkIncludeAntennaID.TabIndex = 54;
            this.chkIncludeAntennaID.Text = "Include antenna ID";
            this.chkIncludeAntennaID.UseVisualStyleBackColor = true;
            // 
            // chkBufferedReadMode
            // 
            this.chkBufferedReadMode.AutoSize = true;
            this.chkBufferedReadMode.Location = new System.Drawing.Point(703, 22);
            this.chkBufferedReadMode.Name = "chkBufferedReadMode";
            this.chkBufferedReadMode.Size = new System.Drawing.Size(119, 17);
            this.chkBufferedReadMode.TabIndex = 52;
            this.chkBufferedReadMode.Text = "Buffered read mode";
            this.chkBufferedReadMode.UseVisualStyleBackColor = true;
            // 
            // chkReaderID
            // 
            this.chkReaderID.AutoSize = true;
            this.chkReaderID.Location = new System.Drawing.Point(828, 22);
            this.chkReaderID.Name = "chkReaderID";
            this.chkReaderID.Size = new System.Drawing.Size(110, 17);
            this.chkReaderID.TabIndex = 51;
            this.chkReaderID.Text = "Report Reader ID";
            this.chkReaderID.UseVisualStyleBackColor = true;
            // 
            // txtHeartbeat2
            // 
            this.txtHeartbeat2.Location = new System.Drawing.Point(118, 182);
            this.txtHeartbeat2.Name = "txtHeartbeat2";
            this.txtHeartbeat2.Size = new System.Drawing.Size(100, 20);
            this.txtHeartbeat2.TabIndex = 50;
            // 
            // label56
            // 
            this.label56.AutoSize = true;
            this.label56.Location = new System.Drawing.Point(8, 185);
            this.label56.Name = "label56";
            this.label56.Size = new System.Drawing.Size(104, 13);
            this.label56.TabIndex = 49;
            this.label56.Text = "Heartbeat (x100mS):";
            // 
            // chkHeartbeatEn
            // 
            this.chkHeartbeatEn.AutoSize = true;
            this.chkHeartbeatEn.Location = new System.Drawing.Point(589, 45);
            this.chkHeartbeatEn.Name = "chkHeartbeatEn";
            this.chkHeartbeatEn.Size = new System.Drawing.Size(108, 17);
            this.chkHeartbeatEn.TabIndex = 36;
            this.chkHeartbeatEn.Text = "Heartbeat enable";
            this.chkHeartbeatEn.UseVisualStyleBackColor = true;
            // 
            // groupBox9
            // 
            this.groupBox9.Controls.Add(this.chkPersistanceAutoReset);
            this.groupBox9.Controls.Add(this.btnPersistenceSet);
            this.groupBox9.Controls.Add(this.btnPersistenceGet);
            this.groupBox9.Controls.Add(this.label48);
            this.groupBox9.Controls.Add(this.txtTagPersistenceTime);
            this.groupBox9.Controls.Add(this.chkEPCPersistance);
            this.groupBox9.Location = new System.Drawing.Point(792, 68);
            this.groupBox9.Name = "groupBox9";
            this.groupBox9.Size = new System.Drawing.Size(136, 100);
            this.groupBox9.TabIndex = 33;
            this.groupBox9.TabStop = false;
            this.groupBox9.Text = "Tag Persistence setup";
            // 
            // chkPersistanceAutoReset
            // 
            this.chkPersistanceAutoReset.AutoSize = true;
            this.chkPersistanceAutoReset.Location = new System.Drawing.Point(9, 35);
            this.chkPersistanceAutoReset.Name = "chkPersistanceAutoReset";
            this.chkPersistanceAutoReset.Size = new System.Drawing.Size(74, 17);
            this.chkPersistanceAutoReset.TabIndex = 57;
            this.chkPersistanceAutoReset.Text = "Auto reset";
            this.chkPersistanceAutoReset.UseVisualStyleBackColor = true;
            // 
            // btnPersistenceSet
            // 
            this.btnPersistenceSet.Location = new System.Drawing.Point(87, 74);
            this.btnPersistenceSet.Name = "btnPersistenceSet";
            this.btnPersistenceSet.Size = new System.Drawing.Size(43, 23);
            this.btnPersistenceSet.TabIndex = 126;
            this.btnPersistenceSet.Text = "Set";
            this.btnPersistenceSet.UseVisualStyleBackColor = true;
            this.btnPersistenceSet.Click += new System.EventHandler(this.btnPersistenceSet_Click);
            // 
            // btnPersistenceGet
            // 
            this.btnPersistenceGet.Location = new System.Drawing.Point(6, 74);
            this.btnPersistenceGet.Name = "btnPersistenceGet";
            this.btnPersistenceGet.Size = new System.Drawing.Size(43, 23);
            this.btnPersistenceGet.TabIndex = 125;
            this.btnPersistenceGet.Text = "Get";
            this.btnPersistenceGet.UseVisualStyleBackColor = true;
            this.btnPersistenceGet.Click += new System.EventHandler(this.btnPersistenceGet_Click);
            // 
            // label48
            // 
            this.label48.AutoSize = true;
            this.label48.Location = new System.Drawing.Point(6, 55);
            this.label48.Name = "label48";
            this.label48.Size = new System.Drawing.Size(78, 13);
            this.label48.TabIndex = 35;
            this.label48.Text = "Time (x100ms):";
            // 
            // txtTagPersistenceTime
            // 
            this.txtTagPersistenceTime.Location = new System.Drawing.Point(87, 52);
            this.txtTagPersistenceTime.MaxLength = 8;
            this.txtTagPersistenceTime.Name = "txtTagPersistenceTime";
            this.txtTagPersistenceTime.Size = new System.Drawing.Size(43, 20);
            this.txtTagPersistenceTime.TabIndex = 34;
            this.txtTagPersistenceTime.Text = "10";
            // 
            // chkEPCPersistance
            // 
            this.chkEPCPersistance.AutoSize = true;
            this.chkEPCPersistance.Location = new System.Drawing.Point(9, 17);
            this.chkEPCPersistance.Name = "chkEPCPersistance";
            this.chkEPCPersistance.Size = new System.Drawing.Size(81, 17);
            this.chkEPCPersistance.TabIndex = 20;
            this.chkEPCPersistance.Text = "Persistence";
            this.chkEPCPersistance.UseVisualStyleBackColor = true;
            // 
            // btnGetInvCfg
            // 
            this.btnGetInvCfg.Location = new System.Drawing.Point(844, 248);
            this.btnGetInvCfg.Name = "btnGetInvCfg";
            this.btnGetInvCfg.Size = new System.Drawing.Size(123, 23);
            this.btnGetInvCfg.TabIndex = 32;
            this.btnGetInvCfg.Text = "Get config.";
            this.btnGetInvCfg.UseVisualStyleBackColor = true;
            this.btnGetInvCfg.Click += new System.EventHandler(this.btnGetInvCfg_Click);
            // 
            // btnSetInvCfg
            // 
            this.btnSetInvCfg.Location = new System.Drawing.Point(715, 248);
            this.btnSetInvCfg.Name = "btnSetInvCfg";
            this.btnSetInvCfg.Size = new System.Drawing.Size(123, 23);
            this.btnSetInvCfg.TabIndex = 31;
            this.btnSetInvCfg.Text = "Set config.";
            this.btnSetInvCfg.UseVisualStyleBackColor = true;
            this.btnSetInvCfg.Click += new System.EventHandler(this.btnSetInvCfg_Click);
            // 
            // groupBox7
            // 
            this.groupBox7.Controls.Add(this.label31);
            this.groupBox7.Controls.Add(this.txtUserMemBlockCount);
            this.groupBox7.Controls.Add(this.label30);
            this.groupBox7.Controls.Add(this.txtEPCMask2);
            this.groupBox7.Controls.Add(this.txtAccessPwd2);
            this.groupBox7.Controls.Add(this.label28);
            this.groupBox7.Controls.Add(this.label29);
            this.groupBox7.Controls.Add(this.txtUserMemBlockAddress);
            this.groupBox7.Location = new System.Drawing.Point(291, 68);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Size = new System.Drawing.Size(258, 145);
            this.groupBox7.TabIndex = 30;
            this.groupBox7.TabStop = false;
            this.groupBox7.Text = "EPC mask setup";
            // 
            // label31
            // 
            this.label31.AutoSize = true;
            this.label31.Location = new System.Drawing.Point(7, 126);
            this.label31.Name = "label31";
            this.label31.Size = new System.Drawing.Size(67, 13);
            this.label31.TabIndex = 29;
            this.label31.Text = "Block count:";
            // 
            // txtUserMemBlockCount
            // 
            this.txtUserMemBlockCount.Location = new System.Drawing.Point(112, 116);
            this.txtUserMemBlockCount.MaxLength = 60;
            this.txtUserMemBlockCount.Multiline = true;
            this.txtUserMemBlockCount.Name = "txtUserMemBlockCount";
            this.txtUserMemBlockCount.Size = new System.Drawing.Size(46, 23);
            this.txtUserMemBlockCount.TabIndex = 28;
            this.txtUserMemBlockCount.Text = "0000";
            // 
            // label30
            // 
            this.label30.AutoSize = true;
            this.label30.Location = new System.Drawing.Point(7, 92);
            this.label30.Name = "label30";
            this.label30.Size = new System.Drawing.Size(77, 13);
            this.label30.TabIndex = 19;
            this.label30.Text = "Block address:";
            // 
            // txtEPCMask2
            // 
            this.txtEPCMask2.Location = new System.Drawing.Point(112, 19);
            this.txtEPCMask2.MaxLength = 60;
            this.txtEPCMask2.Multiline = true;
            this.txtEPCMask2.Name = "txtEPCMask2";
            this.txtEPCMask2.Size = new System.Drawing.Size(124, 23);
            this.txtEPCMask2.TabIndex = 19;
            this.txtEPCMask2.Text = "0000000000000000";
            // 
            // txtAccessPwd2
            // 
            this.txtAccessPwd2.Location = new System.Drawing.Point(112, 53);
            this.txtAccessPwd2.MaxLength = 8;
            this.txtAccessPwd2.Name = "txtAccessPwd2";
            this.txtAccessPwd2.Size = new System.Drawing.Size(70, 20);
            this.txtAccessPwd2.TabIndex = 26;
            this.txtAccessPwd2.Text = "00000000";
            // 
            // label28
            // 
            this.label28.AutoSize = true;
            this.label28.Location = new System.Drawing.Point(7, 29);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(65, 13);
            this.label28.TabIndex = 18;
            this.label28.Text = "EPC (Hex) : ";
            // 
            // label29
            // 
            this.label29.AutoSize = true;
            this.label29.Location = new System.Drawing.Point(7, 60);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(99, 13);
            this.label29.TabIndex = 27;
            this.label29.Text = "Access pwd. (Hex):";
            // 
            // txtUserMemBlockAddress
            // 
            this.txtUserMemBlockAddress.Location = new System.Drawing.Point(112, 82);
            this.txtUserMemBlockAddress.MaxLength = 60;
            this.txtUserMemBlockAddress.Multiline = true;
            this.txtUserMemBlockAddress.Name = "txtUserMemBlockAddress";
            this.txtUserMemBlockAddress.Size = new System.Drawing.Size(46, 23);
            this.txtUserMemBlockAddress.TabIndex = 20;
            this.txtUserMemBlockAddress.Text = "0000";
            // 
            // chkInvOpsEnable
            // 
            this.chkInvOpsEnable.AutoSize = true;
            this.chkInvOpsEnable.Location = new System.Drawing.Point(828, 45);
            this.chkInvOpsEnable.Name = "chkInvOpsEnable";
            this.chkInvOpsEnable.Size = new System.Drawing.Size(105, 17);
            this.chkInvOpsEnable.TabIndex = 25;
            this.chkInvOpsEnable.Text = "Inventory enable";
            this.chkInvOpsEnable.UseVisualStyleBackColor = true;
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.label38);
            this.groupBox5.Controls.Add(this.label36);
            this.groupBox5.Controls.Add(this.label33);
            this.groupBox5.Controls.Add(this.txtIO2_DwellTime);
            this.groupBox5.Controls.Add(this.cbxIO2State);
            this.groupBox5.Controls.Add(this.cbxIO2);
            this.groupBox5.Location = new System.Drawing.Point(148, 68);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(136, 102);
            this.groupBox5.TabIndex = 24;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Fail state output setup";
            // 
            // label38
            // 
            this.label38.AutoSize = true;
            this.label38.Location = new System.Drawing.Point(6, 75);
            this.label38.Name = "label38";
            this.label38.Size = new System.Drawing.Size(78, 13);
            this.label38.TabIndex = 19;
            this.label38.Text = "Time (x100ms):";
            // 
            // label36
            // 
            this.label36.AutoSize = true;
            this.label36.Location = new System.Drawing.Point(6, 48);
            this.label36.Name = "label36";
            this.label36.Size = new System.Drawing.Size(68, 13);
            this.label36.TabIndex = 19;
            this.label36.Text = "Active State:";
            this.label36.Click += new System.EventHandler(this.label36_Click);
            // 
            // label33
            // 
            this.label33.AutoSize = true;
            this.label33.Location = new System.Drawing.Point(6, 21);
            this.label33.Name = "label33";
            this.label33.Size = new System.Drawing.Size(37, 13);
            this.label33.TabIndex = 19;
            this.label33.Text = "Relay:";
            // 
            // txtIO2_DwellTime
            // 
            this.txtIO2_DwellTime.Location = new System.Drawing.Point(92, 72);
            this.txtIO2_DwellTime.MaxLength = 8;
            this.txtIO2_DwellTime.Name = "txtIO2_DwellTime";
            this.txtIO2_DwellTime.Size = new System.Drawing.Size(38, 20);
            this.txtIO2_DwellTime.TabIndex = 18;
            this.txtIO2_DwellTime.Text = "10";
            // 
            // cbxIO2State
            // 
            this.cbxIO2State.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxIO2State.FormattingEnabled = true;
            this.cbxIO2State.Location = new System.Drawing.Point(80, 45);
            this.cbxIO2State.Name = "cbxIO2State";
            this.cbxIO2State.Size = new System.Drawing.Size(50, 21);
            this.cbxIO2State.TabIndex = 15;
            this.cbxIO2State.SelectedIndexChanged += new System.EventHandler(this.cbxIO2State_SelectedIndexChanged);
            // 
            // cbxIO2
            // 
            this.cbxIO2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxIO2.FormattingEnabled = true;
            this.cbxIO2.Location = new System.Drawing.Point(49, 18);
            this.cbxIO2.Name = "cbxIO2";
            this.cbxIO2.Size = new System.Drawing.Size(81, 21);
            this.cbxIO2.TabIndex = 15;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.label37);
            this.groupBox4.Controls.Add(this.label35);
            this.groupBox4.Controls.Add(this.label32);
            this.groupBox4.Controls.Add(this.txtIO1_DwellTime);
            this.groupBox4.Controls.Add(this.cbxIO1State);
            this.groupBox4.Controls.Add(this.cbxIO1);
            this.groupBox4.Location = new System.Drawing.Point(6, 65);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(136, 105);
            this.groupBox4.TabIndex = 23;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Pass state output setup";
            // 
            // label37
            // 
            this.label37.AutoSize = true;
            this.label37.Location = new System.Drawing.Point(6, 78);
            this.label37.Name = "label37";
            this.label37.Size = new System.Drawing.Size(78, 13);
            this.label37.TabIndex = 18;
            this.label37.Text = "Time (x100ms):";
            this.label37.Click += new System.EventHandler(this.label37_Click);
            // 
            // label35
            // 
            this.label35.AutoSize = true;
            this.label35.Location = new System.Drawing.Point(6, 49);
            this.label35.Name = "label35";
            this.label35.Size = new System.Drawing.Size(68, 13);
            this.label35.TabIndex = 18;
            this.label35.Text = "Active State:";
            // 
            // label32
            // 
            this.label32.AutoSize = true;
            this.label32.Location = new System.Drawing.Point(6, 24);
            this.label32.Name = "label32";
            this.label32.Size = new System.Drawing.Size(43, 13);
            this.label32.TabIndex = 18;
            this.label32.Text = "Relay : ";
            // 
            // txtIO1_DwellTime
            // 
            this.txtIO1_DwellTime.Location = new System.Drawing.Point(90, 75);
            this.txtIO1_DwellTime.MaxLength = 8;
            this.txtIO1_DwellTime.Name = "txtIO1_DwellTime";
            this.txtIO1_DwellTime.Size = new System.Drawing.Size(40, 20);
            this.txtIO1_DwellTime.TabIndex = 17;
            this.txtIO1_DwellTime.Text = "10";
            // 
            // cbxIO1State
            // 
            this.cbxIO1State.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxIO1State.FormattingEnabled = true;
            this.cbxIO1State.Location = new System.Drawing.Point(80, 46);
            this.cbxIO1State.Name = "cbxIO1State";
            this.cbxIO1State.Size = new System.Drawing.Size(50, 21);
            this.cbxIO1State.TabIndex = 15;
            // 
            // cbxIO1
            // 
            this.cbxIO1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxIO1.FormattingEnabled = true;
            this.cbxIO1.Location = new System.Drawing.Point(54, 19);
            this.cbxIO1.Name = "cbxIO1";
            this.cbxIO1.Size = new System.Drawing.Size(76, 21);
            this.cbxIO1.TabIndex = 14;
            // 
            // chkReportTID
            // 
            this.chkReportTID.AutoSize = true;
            this.chkReportTID.Location = new System.Drawing.Point(452, 22);
            this.chkReportTID.Name = "chkReportTID";
            this.chkReportTID.Size = new System.Drawing.Size(79, 17);
            this.chkReportTID.TabIndex = 22;
            this.chkReportTID.Text = "Report TID";
            this.chkReportTID.UseVisualStyleBackColor = true;
            // 
            // chkIOPassEnable
            // 
            this.chkIOPassEnable.AutoSize = true;
            this.chkIOPassEnable.Location = new System.Drawing.Point(304, 45);
            this.chkIOPassEnable.Name = "chkIOPassEnable";
            this.chkIOPassEnable.Size = new System.Drawing.Size(145, 17);
            this.chkIOPassEnable.TabIndex = 21;
            this.chkIOPassEnable.Text = "Pass result output enable";
            this.chkIOPassEnable.UseVisualStyleBackColor = true;
            // 
            // chkReportRSSI
            // 
            this.chkReportRSSI.AutoSize = true;
            this.chkReportRSSI.Location = new System.Drawing.Point(588, 22);
            this.chkReportRSSI.Name = "chkReportRSSI";
            this.chkReportRSSI.Size = new System.Drawing.Size(109, 17);
            this.chkReportRSSI.TabIndex = 20;
            this.chkReportRSSI.Text = "Report RSSI info.";
            this.chkReportRSSI.UseVisualStyleBackColor = true;
            // 
            // chkInvTriggerEnable
            // 
            this.chkInvTriggerEnable.AutoSize = true;
            this.chkInvTriggerEnable.Location = new System.Drawing.Point(305, 22);
            this.chkInvTriggerEnable.Name = "chkInvTriggerEnable";
            this.chkInvTriggerEnable.Size = new System.Drawing.Size(117, 17);
            this.chkInvTriggerEnable.TabIndex = 19;
            this.chkInvTriggerEnable.Text = "Input trigger enable";
            this.chkInvTriggerEnable.UseVisualStyleBackColor = true;
            // 
            // chkIOFailEnable
            // 
            this.chkIOFailEnable.AutoSize = true;
            this.chkIOFailEnable.Location = new System.Drawing.Point(452, 45);
            this.chkIOFailEnable.Name = "chkIOFailEnable";
            this.chkIOFailEnable.Size = new System.Drawing.Size(138, 17);
            this.chkIOFailEnable.TabIndex = 18;
            this.chkIOFailEnable.Text = "Fail result output enable";
            this.chkIOFailEnable.UseVisualStyleBackColor = true;
            this.chkIOFailEnable.CheckedChanged += new System.EventHandler(this.chkIOFailEnable_CheckedChanged);
            // 
            // chkComplaintTags
            // 
            this.chkComplaintTags.AutoSize = true;
            this.chkComplaintTags.Location = new System.Drawing.Point(151, 45);
            this.chkComplaintTags.Name = "chkComplaintTags";
            this.chkComplaintTags.Size = new System.Drawing.Size(151, 17);
            this.chkComplaintTags.TabIndex = 17;
            this.chkComplaintTags.Text = "Report compliant tags only";
            this.chkComplaintTags.UseVisualStyleBackColor = true;
            // 
            // chkReportUserMem
            // 
            this.chkReportUserMem.AutoSize = true;
            this.chkReportUserMem.Location = new System.Drawing.Point(151, 24);
            this.chkReportUserMem.Name = "chkReportUserMem";
            this.chkReportUserMem.Size = new System.Drawing.Size(122, 17);
            this.chkReportUserMem.TabIndex = 16;
            this.chkReportUserMem.Text = "Report User memory";
            this.chkReportUserMem.UseVisualStyleBackColor = true;
            // 
            // chkAccessPwd
            // 
            this.chkAccessPwd.AutoSize = true;
            this.chkAccessPwd.Location = new System.Drawing.Point(6, 47);
            this.chkAccessPwd.Name = "chkAccessPwd";
            this.chkAccessPwd.Size = new System.Drawing.Size(144, 17);
            this.chkAccessPwd.TabIndex = 15;
            this.chkAccessPwd.Text = "Access password enable";
            this.chkAccessPwd.UseVisualStyleBackColor = true;
            // 
            // chkEPCMask
            // 
            this.chkEPCMask.AutoSize = true;
            this.chkEPCMask.Location = new System.Drawing.Point(6, 24);
            this.chkEPCMask.Name = "chkEPCMask";
            this.chkEPCMask.Size = new System.Drawing.Size(110, 17);
            this.chkEPCMask.TabIndex = 14;
            this.chkEPCMask.Text = "EPC mask enable";
            this.chkEPCMask.UseVisualStyleBackColor = true;
            // 
            // grpExtInvRouteOptions
            // 
            this.grpExtInvRouteOptions.Controls.Add(this.radExtInvRespRouteToClient);
            this.grpExtInvRouteOptions.Controls.Add(this.radExtInvRespRouteToServer);
            this.grpExtInvRouteOptions.Controls.Add(this.btnExtAotuInventoryRespRouteSet);
            this.grpExtInvRouteOptions.Controls.Add(this.btnExtAotuInventoryRespRouteGet);
            this.grpExtInvRouteOptions.Location = new System.Drawing.Point(6, 289);
            this.grpExtInvRouteOptions.Name = "grpExtInvRouteOptions";
            this.grpExtInvRouteOptions.Size = new System.Drawing.Size(218, 74);
            this.grpExtInvRouteOptions.TabIndex = 124;
            this.grpExtInvRouteOptions.TabStop = false;
            this.grpExtInvRouteOptions.Text = "Extended auto inventory response routing";
            // 
            // radExtInvRespRouteToClient
            // 
            this.radExtInvRespRouteToClient.AutoSize = true;
            this.radExtInvRespRouteToClient.Location = new System.Drawing.Point(118, 19);
            this.radExtInvRespRouteToClient.Name = "radExtInvRespRouteToClient";
            this.radExtInvRespRouteToClient.Size = new System.Drawing.Size(75, 17);
            this.radExtInvRespRouteToClient.TabIndex = 9;
            this.radExtInvRespRouteToClient.TabStop = true;
            this.radExtInvRespRouteToClient.Text = "TCP Client";
            this.radExtInvRespRouteToClient.UseVisualStyleBackColor = true;
            // 
            // radExtInvRespRouteToServer
            // 
            this.radExtInvRespRouteToServer.AutoSize = true;
            this.radExtInvRespRouteToServer.Location = new System.Drawing.Point(6, 19);
            this.radExtInvRespRouteToServer.Name = "radExtInvRespRouteToServer";
            this.radExtInvRespRouteToServer.Size = new System.Drawing.Size(80, 17);
            this.radExtInvRespRouteToServer.TabIndex = 41;
            this.radExtInvRespRouteToServer.TabStop = true;
            this.radExtInvRespRouteToServer.Text = "TCP Server";
            this.radExtInvRespRouteToServer.UseVisualStyleBackColor = true;
            // 
            // btnExtAotuInventoryRespRouteSet
            // 
            this.btnExtAotuInventoryRespRouteSet.Location = new System.Drawing.Point(118, 46);
            this.btnExtAotuInventoryRespRouteSet.Name = "btnExtAotuInventoryRespRouteSet";
            this.btnExtAotuInventoryRespRouteSet.Size = new System.Drawing.Size(94, 23);
            this.btnExtAotuInventoryRespRouteSet.TabIndex = 39;
            this.btnExtAotuInventoryRespRouteSet.Text = "Set";
            this.btnExtAotuInventoryRespRouteSet.UseVisualStyleBackColor = true;
            this.btnExtAotuInventoryRespRouteSet.Click += new System.EventHandler(this.btnExtAotuInventoryRespRouteSet_Click);
            // 
            // btnExtAotuInventoryRespRouteGet
            // 
            this.btnExtAotuInventoryRespRouteGet.Location = new System.Drawing.Point(6, 46);
            this.btnExtAotuInventoryRespRouteGet.Name = "btnExtAotuInventoryRespRouteGet";
            this.btnExtAotuInventoryRespRouteGet.Size = new System.Drawing.Size(94, 23);
            this.btnExtAotuInventoryRespRouteGet.TabIndex = 40;
            this.btnExtAotuInventoryRespRouteGet.Text = "Get";
            this.btnExtAotuInventoryRespRouteGet.UseVisualStyleBackColor = true;
            this.btnExtAotuInventoryRespRouteGet.Click += new System.EventHandler(this.btnExtAotuInventoryRespRouteGet_Click);
            // 
            // chkMask9Enabled
            // 
            this.chkMask9Enabled.AutoSize = true;
            this.chkMask9Enabled.Enabled = false;
            this.chkMask9Enabled.Location = new System.Drawing.Point(492, 561);
            this.chkMask9Enabled.Name = "chkMask9Enabled";
            this.chkMask9Enabled.Size = new System.Drawing.Size(15, 14);
            this.chkMask9Enabled.TabIndex = 102;
            this.chkMask9Enabled.UseVisualStyleBackColor = true;
            // 
            // chkMask8Enabled
            // 
            this.chkMask8Enabled.AutoSize = true;
            this.chkMask8Enabled.Enabled = false;
            this.chkMask8Enabled.Location = new System.Drawing.Point(492, 535);
            this.chkMask8Enabled.Name = "chkMask8Enabled";
            this.chkMask8Enabled.Size = new System.Drawing.Size(15, 14);
            this.chkMask8Enabled.TabIndex = 101;
            this.chkMask8Enabled.UseVisualStyleBackColor = true;
            // 
            // chkMask7Enabled
            // 
            this.chkMask7Enabled.AutoSize = true;
            this.chkMask7Enabled.Enabled = false;
            this.chkMask7Enabled.Location = new System.Drawing.Point(492, 508);
            this.chkMask7Enabled.Name = "chkMask7Enabled";
            this.chkMask7Enabled.Size = new System.Drawing.Size(15, 14);
            this.chkMask7Enabled.TabIndex = 100;
            this.chkMask7Enabled.UseVisualStyleBackColor = true;
            // 
            // chkMask6Enabled
            // 
            this.chkMask6Enabled.AutoSize = true;
            this.chkMask6Enabled.Enabled = false;
            this.chkMask6Enabled.Location = new System.Drawing.Point(492, 478);
            this.chkMask6Enabled.Name = "chkMask6Enabled";
            this.chkMask6Enabled.Size = new System.Drawing.Size(15, 14);
            this.chkMask6Enabled.TabIndex = 99;
            this.chkMask6Enabled.UseVisualStyleBackColor = true;
            // 
            // chkMask5Enabled
            // 
            this.chkMask5Enabled.AutoSize = true;
            this.chkMask5Enabled.Enabled = false;
            this.chkMask5Enabled.Location = new System.Drawing.Point(492, 449);
            this.chkMask5Enabled.Name = "chkMask5Enabled";
            this.chkMask5Enabled.Size = new System.Drawing.Size(15, 14);
            this.chkMask5Enabled.TabIndex = 98;
            this.chkMask5Enabled.UseVisualStyleBackColor = true;
            // 
            // chkMask4Enabled
            // 
            this.chkMask4Enabled.AutoSize = true;
            this.chkMask4Enabled.Enabled = false;
            this.chkMask4Enabled.Location = new System.Drawing.Point(492, 418);
            this.chkMask4Enabled.Name = "chkMask4Enabled";
            this.chkMask4Enabled.Size = new System.Drawing.Size(15, 14);
            this.chkMask4Enabled.TabIndex = 97;
            this.chkMask4Enabled.UseVisualStyleBackColor = true;
            // 
            // chkMask3Enabled
            // 
            this.chkMask3Enabled.AutoSize = true;
            this.chkMask3Enabled.Enabled = false;
            this.chkMask3Enabled.Location = new System.Drawing.Point(492, 392);
            this.chkMask3Enabled.Name = "chkMask3Enabled";
            this.chkMask3Enabled.Size = new System.Drawing.Size(15, 14);
            this.chkMask3Enabled.TabIndex = 96;
            this.chkMask3Enabled.UseVisualStyleBackColor = true;
            // 
            // chkMask2Enabled
            // 
            this.chkMask2Enabled.AutoSize = true;
            this.chkMask2Enabled.Enabled = false;
            this.chkMask2Enabled.Location = new System.Drawing.Point(492, 362);
            this.chkMask2Enabled.Name = "chkMask2Enabled";
            this.chkMask2Enabled.Size = new System.Drawing.Size(15, 14);
            this.chkMask2Enabled.TabIndex = 95;
            this.chkMask2Enabled.UseVisualStyleBackColor = true;
            // 
            // chkMask1Enabled
            // 
            this.chkMask1Enabled.AutoSize = true;
            this.chkMask1Enabled.Enabled = false;
            this.chkMask1Enabled.Location = new System.Drawing.Point(492, 334);
            this.chkMask1Enabled.Name = "chkMask1Enabled";
            this.chkMask1Enabled.Size = new System.Drawing.Size(15, 14);
            this.chkMask1Enabled.TabIndex = 94;
            this.chkMask1Enabled.UseVisualStyleBackColor = true;
            // 
            // chkMask0Enabled
            // 
            this.chkMask0Enabled.AutoSize = true;
            this.chkMask0Enabled.Enabled = false;
            this.chkMask0Enabled.Location = new System.Drawing.Point(492, 304);
            this.chkMask0Enabled.Name = "chkMask0Enabled";
            this.chkMask0Enabled.Size = new System.Drawing.Size(15, 14);
            this.chkMask0Enabled.TabIndex = 93;
            this.chkMask0Enabled.UseVisualStyleBackColor = true;
            // 
            // btnMask9Erase
            // 
            this.btnMask9Erase.Location = new System.Drawing.Point(912, 561);
            this.btnMask9Erase.Name = "btnMask9Erase";
            this.btnMask9Erase.Size = new System.Drawing.Size(63, 21);
            this.btnMask9Erase.TabIndex = 92;
            this.btnMask9Erase.Text = "Erase";
            this.btnMask9Erase.UseVisualStyleBackColor = true;
            this.btnMask9Erase.Click += new System.EventHandler(this.btnMask9Erase_Click);
            // 
            // btnMask8Erase
            // 
            this.btnMask8Erase.Location = new System.Drawing.Point(912, 532);
            this.btnMask8Erase.Name = "btnMask8Erase";
            this.btnMask8Erase.Size = new System.Drawing.Size(63, 21);
            this.btnMask8Erase.TabIndex = 91;
            this.btnMask8Erase.Text = "Erase";
            this.btnMask8Erase.UseVisualStyleBackColor = true;
            this.btnMask8Erase.Click += new System.EventHandler(this.btnMask8Erase_Click);
            // 
            // btnMask7Erase
            // 
            this.btnMask7Erase.Location = new System.Drawing.Point(912, 504);
            this.btnMask7Erase.Name = "btnMask7Erase";
            this.btnMask7Erase.Size = new System.Drawing.Size(63, 21);
            this.btnMask7Erase.TabIndex = 90;
            this.btnMask7Erase.Text = "Erase";
            this.btnMask7Erase.UseVisualStyleBackColor = true;
            this.btnMask7Erase.Click += new System.EventHandler(this.btnMask7Erase_Click);
            // 
            // btnMask6Erase
            // 
            this.btnMask6Erase.Location = new System.Drawing.Point(912, 475);
            this.btnMask6Erase.Name = "btnMask6Erase";
            this.btnMask6Erase.Size = new System.Drawing.Size(63, 21);
            this.btnMask6Erase.TabIndex = 89;
            this.btnMask6Erase.Text = "Erase";
            this.btnMask6Erase.UseVisualStyleBackColor = true;
            this.btnMask6Erase.Click += new System.EventHandler(this.btnMask6Erase_Click);
            // 
            // btnMask5Erase
            // 
            this.btnMask5Erase.Location = new System.Drawing.Point(912, 446);
            this.btnMask5Erase.Name = "btnMask5Erase";
            this.btnMask5Erase.Size = new System.Drawing.Size(63, 21);
            this.btnMask5Erase.TabIndex = 88;
            this.btnMask5Erase.Text = "Erase";
            this.btnMask5Erase.UseVisualStyleBackColor = true;
            this.btnMask5Erase.Click += new System.EventHandler(this.btnMask5Erase_Click);
            // 
            // btnMask4Erase
            // 
            this.btnMask4Erase.Location = new System.Drawing.Point(912, 417);
            this.btnMask4Erase.Name = "btnMask4Erase";
            this.btnMask4Erase.Size = new System.Drawing.Size(63, 21);
            this.btnMask4Erase.TabIndex = 87;
            this.btnMask4Erase.Text = "Erase";
            this.btnMask4Erase.UseVisualStyleBackColor = true;
            this.btnMask4Erase.Click += new System.EventHandler(this.btnMask4Erase_Click);
            // 
            // btnMask3Erase
            // 
            this.btnMask3Erase.Location = new System.Drawing.Point(912, 388);
            this.btnMask3Erase.Name = "btnMask3Erase";
            this.btnMask3Erase.Size = new System.Drawing.Size(63, 21);
            this.btnMask3Erase.TabIndex = 86;
            this.btnMask3Erase.Text = "Erase";
            this.btnMask3Erase.UseVisualStyleBackColor = true;
            this.btnMask3Erase.Click += new System.EventHandler(this.btnMask3Erase_Click);
            // 
            // btnMask2Erase
            // 
            this.btnMask2Erase.Location = new System.Drawing.Point(912, 357);
            this.btnMask2Erase.Name = "btnMask2Erase";
            this.btnMask2Erase.Size = new System.Drawing.Size(63, 21);
            this.btnMask2Erase.TabIndex = 85;
            this.btnMask2Erase.Text = "Erase";
            this.btnMask2Erase.UseVisualStyleBackColor = true;
            this.btnMask2Erase.Click += new System.EventHandler(this.btnMask2Erase_Click);
            // 
            // btnMask1Erase
            // 
            this.btnMask1Erase.Location = new System.Drawing.Point(912, 330);
            this.btnMask1Erase.Name = "btnMask1Erase";
            this.btnMask1Erase.Size = new System.Drawing.Size(63, 21);
            this.btnMask1Erase.TabIndex = 84;
            this.btnMask1Erase.Text = "Erase";
            this.btnMask1Erase.UseVisualStyleBackColor = true;
            this.btnMask1Erase.Click += new System.EventHandler(this.btnMask1Erase_Click);
            // 
            // btnMask0Erase
            // 
            this.btnMask0Erase.Location = new System.Drawing.Point(912, 301);
            this.btnMask0Erase.Name = "btnMask0Erase";
            this.btnMask0Erase.Size = new System.Drawing.Size(63, 21);
            this.btnMask0Erase.TabIndex = 83;
            this.btnMask0Erase.Text = "Erase";
            this.btnMask0Erase.UseVisualStyleBackColor = true;
            this.btnMask0Erase.Click += new System.EventHandler(this.btnMask0Erase_Click);
            // 
            // label69
            // 
            this.label69.AutoSize = true;
            this.label69.Location = new System.Drawing.Point(513, 562);
            this.label69.Name = "label69";
            this.label69.Size = new System.Drawing.Size(109, 13);
            this.label69.TabIndex = 82;
            this.label69.Text = "EPC [Mask 9] (Hex) : ";
            // 
            // label68
            // 
            this.label68.AutoSize = true;
            this.label68.Location = new System.Drawing.Point(513, 536);
            this.label68.Name = "label68";
            this.label68.Size = new System.Drawing.Size(109, 13);
            this.label68.TabIndex = 81;
            this.label68.Text = "EPC [Mask 8] (Hex) : ";
            // 
            // label67
            // 
            this.label67.AutoSize = true;
            this.label67.Location = new System.Drawing.Point(513, 508);
            this.label67.Name = "label67";
            this.label67.Size = new System.Drawing.Size(109, 13);
            this.label67.TabIndex = 80;
            this.label67.Text = "EPC [Mask 7] (Hex) : ";
            // 
            // label66
            // 
            this.label66.AutoSize = true;
            this.label66.Location = new System.Drawing.Point(513, 479);
            this.label66.Name = "label66";
            this.label66.Size = new System.Drawing.Size(109, 13);
            this.label66.TabIndex = 79;
            this.label66.Text = "EPC [Mask 6] (Hex) : ";
            // 
            // label65
            // 
            this.label65.AutoSize = true;
            this.label65.Location = new System.Drawing.Point(513, 450);
            this.label65.Name = "label65";
            this.label65.Size = new System.Drawing.Size(109, 13);
            this.label65.TabIndex = 78;
            this.label65.Text = "EPC [Mask 5] (Hex) : ";
            // 
            // label64
            // 
            this.label64.AutoSize = true;
            this.label64.Location = new System.Drawing.Point(513, 421);
            this.label64.Name = "label64";
            this.label64.Size = new System.Drawing.Size(109, 13);
            this.label64.TabIndex = 77;
            this.label64.Text = "EPC [Mask 4] (Hex) : ";
            // 
            // label63
            // 
            this.label63.AutoSize = true;
            this.label63.Location = new System.Drawing.Point(513, 392);
            this.label63.Name = "label63";
            this.label63.Size = new System.Drawing.Size(109, 13);
            this.label63.TabIndex = 76;
            this.label63.Text = "EPC [Mask 3] (Hex) : ";
            // 
            // label62
            // 
            this.label62.AutoSize = true;
            this.label62.Location = new System.Drawing.Point(513, 363);
            this.label62.Name = "label62";
            this.label62.Size = new System.Drawing.Size(109, 13);
            this.label62.TabIndex = 75;
            this.label62.Text = "EPC [Mask 2] (Hex) : ";
            // 
            // label61
            // 
            this.label61.AutoSize = true;
            this.label61.Location = new System.Drawing.Point(513, 334);
            this.label61.Name = "label61";
            this.label61.Size = new System.Drawing.Size(109, 13);
            this.label61.TabIndex = 74;
            this.label61.Text = "EPC [Mask 1] (Hex) : ";
            // 
            // label60
            // 
            this.label60.AutoSize = true;
            this.label60.Location = new System.Drawing.Point(513, 305);
            this.label60.Name = "label60";
            this.label60.Size = new System.Drawing.Size(109, 13);
            this.label60.TabIndex = 73;
            this.label60.Text = "EPC [Mask 0] (Hex) : ";
            // 
            // chkMask9
            // 
            this.chkMask9.AutoSize = true;
            this.chkMask9.Location = new System.Drawing.Point(753, 559);
            this.chkMask9.Name = "chkMask9";
            this.chkMask9.Size = new System.Drawing.Size(15, 14);
            this.chkMask9.TabIndex = 72;
            this.chkMask9.UseVisualStyleBackColor = true;
            this.chkMask9.CheckedChanged += new System.EventHandler(this.chkMask9_CheckedChanged);
            // 
            // SetMask9
            // 
            this.SetMask9.Location = new System.Drawing.Point(843, 561);
            this.SetMask9.Name = "SetMask9";
            this.SetMask9.Size = new System.Drawing.Size(63, 21);
            this.SetMask9.TabIndex = 71;
            this.SetMask9.Text = "Set";
            this.SetMask9.UseVisualStyleBackColor = true;
            this.SetMask9.Click += new System.EventHandler(this.SetMask9_Click);
            // 
            // GetMask9
            // 
            this.GetMask9.Location = new System.Drawing.Point(774, 561);
            this.GetMask9.Name = "GetMask9";
            this.GetMask9.Size = new System.Drawing.Size(63, 21);
            this.GetMask9.TabIndex = 70;
            this.GetMask9.Text = "Get";
            this.GetMask9.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.GetMask9.UseVisualStyleBackColor = true;
            this.GetMask9.Click += new System.EventHandler(this.GetMask9_Click);
            // 
            // txtMask9
            // 
            this.txtMask9.Location = new System.Drawing.Point(628, 559);
            this.txtMask9.MaxLength = 60;
            this.txtMask9.Multiline = true;
            this.txtMask9.Name = "txtMask9";
            this.txtMask9.Size = new System.Drawing.Size(124, 23);
            this.txtMask9.TabIndex = 69;
            // 
            // chkMask8
            // 
            this.chkMask8.AutoSize = true;
            this.chkMask8.Location = new System.Drawing.Point(753, 530);
            this.chkMask8.Name = "chkMask8";
            this.chkMask8.Size = new System.Drawing.Size(15, 14);
            this.chkMask8.TabIndex = 68;
            this.chkMask8.UseVisualStyleBackColor = true;
            this.chkMask8.CheckedChanged += new System.EventHandler(this.chkMask8_CheckedChanged);
            // 
            // SetMask8
            // 
            this.SetMask8.Location = new System.Drawing.Point(843, 532);
            this.SetMask8.Name = "SetMask8";
            this.SetMask8.Size = new System.Drawing.Size(63, 21);
            this.SetMask8.TabIndex = 67;
            this.SetMask8.Text = "Set";
            this.SetMask8.UseVisualStyleBackColor = true;
            this.SetMask8.Click += new System.EventHandler(this.SetMask8_Click);
            // 
            // GetMask8
            // 
            this.GetMask8.Location = new System.Drawing.Point(774, 532);
            this.GetMask8.Name = "GetMask8";
            this.GetMask8.Size = new System.Drawing.Size(63, 21);
            this.GetMask8.TabIndex = 66;
            this.GetMask8.Text = "Get";
            this.GetMask8.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.GetMask8.UseVisualStyleBackColor = true;
            this.GetMask8.Click += new System.EventHandler(this.GetMask8_Click);
            // 
            // txtMask8
            // 
            this.txtMask8.Location = new System.Drawing.Point(628, 530);
            this.txtMask8.MaxLength = 60;
            this.txtMask8.Multiline = true;
            this.txtMask8.Name = "txtMask8";
            this.txtMask8.Size = new System.Drawing.Size(124, 23);
            this.txtMask8.TabIndex = 65;
            // 
            // chkMask7
            // 
            this.chkMask7.AutoSize = true;
            this.chkMask7.Location = new System.Drawing.Point(753, 502);
            this.chkMask7.Name = "chkMask7";
            this.chkMask7.Size = new System.Drawing.Size(15, 14);
            this.chkMask7.TabIndex = 64;
            this.chkMask7.UseVisualStyleBackColor = true;
            this.chkMask7.CheckedChanged += new System.EventHandler(this.chkMask7_CheckedChanged);
            // 
            // SetMask7
            // 
            this.SetMask7.Location = new System.Drawing.Point(843, 504);
            this.SetMask7.Name = "SetMask7";
            this.SetMask7.Size = new System.Drawing.Size(63, 21);
            this.SetMask7.TabIndex = 63;
            this.SetMask7.Text = "Set";
            this.SetMask7.UseVisualStyleBackColor = true;
            this.SetMask7.Click += new System.EventHandler(this.SetMask7_Click);
            // 
            // GetMask7
            // 
            this.GetMask7.Location = new System.Drawing.Point(774, 504);
            this.GetMask7.Name = "GetMask7";
            this.GetMask7.Size = new System.Drawing.Size(63, 21);
            this.GetMask7.TabIndex = 62;
            this.GetMask7.Text = "Get";
            this.GetMask7.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.GetMask7.UseVisualStyleBackColor = true;
            this.GetMask7.Click += new System.EventHandler(this.GetMask7_Click);
            // 
            // txtMask7
            // 
            this.txtMask7.Location = new System.Drawing.Point(628, 502);
            this.txtMask7.MaxLength = 60;
            this.txtMask7.Multiline = true;
            this.txtMask7.Name = "txtMask7";
            this.txtMask7.Size = new System.Drawing.Size(124, 23);
            this.txtMask7.TabIndex = 61;
            // 
            // chkMask6
            // 
            this.chkMask6.AutoSize = true;
            this.chkMask6.Location = new System.Drawing.Point(753, 473);
            this.chkMask6.Name = "chkMask6";
            this.chkMask6.Size = new System.Drawing.Size(15, 14);
            this.chkMask6.TabIndex = 60;
            this.chkMask6.UseVisualStyleBackColor = true;
            this.chkMask6.CheckedChanged += new System.EventHandler(this.chkMask6_CheckedChanged);
            // 
            // SetMask6
            // 
            this.SetMask6.Location = new System.Drawing.Point(843, 475);
            this.SetMask6.Name = "SetMask6";
            this.SetMask6.Size = new System.Drawing.Size(63, 21);
            this.SetMask6.TabIndex = 59;
            this.SetMask6.Text = "Set";
            this.SetMask6.UseVisualStyleBackColor = true;
            this.SetMask6.Click += new System.EventHandler(this.SetMask6_Click);
            // 
            // GetMask6
            // 
            this.GetMask6.Location = new System.Drawing.Point(774, 475);
            this.GetMask6.Name = "GetMask6";
            this.GetMask6.Size = new System.Drawing.Size(63, 21);
            this.GetMask6.TabIndex = 58;
            this.GetMask6.Text = "Get";
            this.GetMask6.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.GetMask6.UseVisualStyleBackColor = true;
            this.GetMask6.Click += new System.EventHandler(this.GetMask6_Click);
            // 
            // txtMask6
            // 
            this.txtMask6.Location = new System.Drawing.Point(628, 473);
            this.txtMask6.MaxLength = 60;
            this.txtMask6.Multiline = true;
            this.txtMask6.Name = "txtMask6";
            this.txtMask6.Size = new System.Drawing.Size(124, 23);
            this.txtMask6.TabIndex = 57;
            // 
            // chkMask5
            // 
            this.chkMask5.AutoSize = true;
            this.chkMask5.Location = new System.Drawing.Point(753, 444);
            this.chkMask5.Name = "chkMask5";
            this.chkMask5.Size = new System.Drawing.Size(15, 14);
            this.chkMask5.TabIndex = 56;
            this.chkMask5.UseVisualStyleBackColor = true;
            this.chkMask5.CheckedChanged += new System.EventHandler(this.chkMask5_CheckedChanged);
            // 
            // SetMask5
            // 
            this.SetMask5.Location = new System.Drawing.Point(843, 446);
            this.SetMask5.Name = "SetMask5";
            this.SetMask5.Size = new System.Drawing.Size(63, 21);
            this.SetMask5.TabIndex = 55;
            this.SetMask5.Text = "Set";
            this.SetMask5.UseVisualStyleBackColor = true;
            this.SetMask5.Click += new System.EventHandler(this.SetMask5_Click);
            // 
            // GetMask5
            // 
            this.GetMask5.Location = new System.Drawing.Point(774, 446);
            this.GetMask5.Name = "GetMask5";
            this.GetMask5.Size = new System.Drawing.Size(63, 21);
            this.GetMask5.TabIndex = 54;
            this.GetMask5.Text = "Get";
            this.GetMask5.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.GetMask5.UseVisualStyleBackColor = true;
            this.GetMask5.Click += new System.EventHandler(this.GetMask5_Click);
            // 
            // txtMask5
            // 
            this.txtMask5.Location = new System.Drawing.Point(628, 444);
            this.txtMask5.MaxLength = 60;
            this.txtMask5.Multiline = true;
            this.txtMask5.Name = "txtMask5";
            this.txtMask5.Size = new System.Drawing.Size(124, 23);
            this.txtMask5.TabIndex = 53;
            // 
            // chkMask4
            // 
            this.chkMask4.AutoSize = true;
            this.chkMask4.Location = new System.Drawing.Point(753, 415);
            this.chkMask4.Name = "chkMask4";
            this.chkMask4.Size = new System.Drawing.Size(15, 14);
            this.chkMask4.TabIndex = 52;
            this.chkMask4.UseVisualStyleBackColor = true;
            this.chkMask4.CheckedChanged += new System.EventHandler(this.chkMask4_CheckedChanged);
            // 
            // SetMask4
            // 
            this.SetMask4.Location = new System.Drawing.Point(843, 417);
            this.SetMask4.Name = "SetMask4";
            this.SetMask4.Size = new System.Drawing.Size(63, 21);
            this.SetMask4.TabIndex = 51;
            this.SetMask4.Text = "Set";
            this.SetMask4.UseVisualStyleBackColor = true;
            this.SetMask4.Click += new System.EventHandler(this.SetMask4_Click);
            // 
            // GetMask4
            // 
            this.GetMask4.Location = new System.Drawing.Point(774, 417);
            this.GetMask4.Name = "GetMask4";
            this.GetMask4.Size = new System.Drawing.Size(63, 21);
            this.GetMask4.TabIndex = 50;
            this.GetMask4.Text = "Get";
            this.GetMask4.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.GetMask4.UseVisualStyleBackColor = true;
            this.GetMask4.Click += new System.EventHandler(this.GetMask4_Click);
            // 
            // txtMask4
            // 
            this.txtMask4.Location = new System.Drawing.Point(628, 415);
            this.txtMask4.MaxLength = 60;
            this.txtMask4.Multiline = true;
            this.txtMask4.Name = "txtMask4";
            this.txtMask4.Size = new System.Drawing.Size(124, 23);
            this.txtMask4.TabIndex = 49;
            // 
            // chkMask3
            // 
            this.chkMask3.AutoSize = true;
            this.chkMask3.Location = new System.Drawing.Point(753, 386);
            this.chkMask3.Name = "chkMask3";
            this.chkMask3.Size = new System.Drawing.Size(15, 14);
            this.chkMask3.TabIndex = 48;
            this.chkMask3.UseVisualStyleBackColor = true;
            this.chkMask3.CheckedChanged += new System.EventHandler(this.chkMask3_CheckedChanged);
            // 
            // SetMask3
            // 
            this.SetMask3.Location = new System.Drawing.Point(843, 388);
            this.SetMask3.Name = "SetMask3";
            this.SetMask3.Size = new System.Drawing.Size(63, 21);
            this.SetMask3.TabIndex = 47;
            this.SetMask3.Text = "Set";
            this.SetMask3.UseVisualStyleBackColor = true;
            this.SetMask3.Click += new System.EventHandler(this.SetMask3_Click);
            // 
            // GetMask3
            // 
            this.GetMask3.Location = new System.Drawing.Point(774, 388);
            this.GetMask3.Name = "GetMask3";
            this.GetMask3.Size = new System.Drawing.Size(63, 21);
            this.GetMask3.TabIndex = 46;
            this.GetMask3.Text = "Get";
            this.GetMask3.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.GetMask3.UseVisualStyleBackColor = true;
            this.GetMask3.Click += new System.EventHandler(this.GetMask3_Click);
            // 
            // txtMask3
            // 
            this.txtMask3.Location = new System.Drawing.Point(628, 386);
            this.txtMask3.MaxLength = 60;
            this.txtMask3.Multiline = true;
            this.txtMask3.Name = "txtMask3";
            this.txtMask3.Size = new System.Drawing.Size(124, 23);
            this.txtMask3.TabIndex = 45;
            // 
            // chkMask2
            // 
            this.chkMask2.AutoSize = true;
            this.chkMask2.Location = new System.Drawing.Point(753, 357);
            this.chkMask2.Name = "chkMask2";
            this.chkMask2.Size = new System.Drawing.Size(15, 14);
            this.chkMask2.TabIndex = 44;
            this.chkMask2.UseVisualStyleBackColor = true;
            this.chkMask2.CheckedChanged += new System.EventHandler(this.chkMask2_CheckedChanged);
            // 
            // SetMask2
            // 
            this.SetMask2.Location = new System.Drawing.Point(843, 359);
            this.SetMask2.Name = "SetMask2";
            this.SetMask2.Size = new System.Drawing.Size(63, 21);
            this.SetMask2.TabIndex = 43;
            this.SetMask2.Text = "Set";
            this.SetMask2.UseVisualStyleBackColor = true;
            this.SetMask2.Click += new System.EventHandler(this.SetMask2_Click);
            // 
            // GetMask2
            // 
            this.GetMask2.Location = new System.Drawing.Point(774, 359);
            this.GetMask2.Name = "GetMask2";
            this.GetMask2.Size = new System.Drawing.Size(63, 21);
            this.GetMask2.TabIndex = 42;
            this.GetMask2.Text = "Get";
            this.GetMask2.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.GetMask2.UseVisualStyleBackColor = true;
            this.GetMask2.Click += new System.EventHandler(this.GetMask2_Click);
            // 
            // txtMask2
            // 
            this.txtMask2.Location = new System.Drawing.Point(628, 357);
            this.txtMask2.MaxLength = 60;
            this.txtMask2.Multiline = true;
            this.txtMask2.Name = "txtMask2";
            this.txtMask2.Size = new System.Drawing.Size(124, 23);
            this.txtMask2.TabIndex = 41;
            // 
            // chkMask1
            // 
            this.chkMask1.AutoSize = true;
            this.chkMask1.Location = new System.Drawing.Point(753, 328);
            this.chkMask1.Name = "chkMask1";
            this.chkMask1.Size = new System.Drawing.Size(15, 14);
            this.chkMask1.TabIndex = 40;
            this.chkMask1.UseVisualStyleBackColor = true;
            this.chkMask1.CheckedChanged += new System.EventHandler(this.chkMask1_CheckedChanged);
            // 
            // SetMask1
            // 
            this.SetMask1.Location = new System.Drawing.Point(843, 330);
            this.SetMask1.Name = "SetMask1";
            this.SetMask1.Size = new System.Drawing.Size(63, 21);
            this.SetMask1.TabIndex = 39;
            this.SetMask1.Text = "Set";
            this.SetMask1.UseVisualStyleBackColor = true;
            this.SetMask1.Click += new System.EventHandler(this.SetMask1_Click);
            // 
            // GetMask1
            // 
            this.GetMask1.Location = new System.Drawing.Point(774, 330);
            this.GetMask1.Name = "GetMask1";
            this.GetMask1.Size = new System.Drawing.Size(63, 21);
            this.GetMask1.TabIndex = 38;
            this.GetMask1.Text = "Get";
            this.GetMask1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.GetMask1.UseVisualStyleBackColor = true;
            this.GetMask1.Click += new System.EventHandler(this.GetMask1_Click);
            // 
            // txtMask1
            // 
            this.txtMask1.Location = new System.Drawing.Point(628, 328);
            this.txtMask1.MaxLength = 60;
            this.txtMask1.Multiline = true;
            this.txtMask1.Name = "txtMask1";
            this.txtMask1.Size = new System.Drawing.Size(124, 23);
            this.txtMask1.TabIndex = 37;
            // 
            // chkMask0
            // 
            this.chkMask0.AutoSize = true;
            this.chkMask0.Location = new System.Drawing.Point(753, 299);
            this.chkMask0.Name = "chkMask0";
            this.chkMask0.Size = new System.Drawing.Size(15, 14);
            this.chkMask0.TabIndex = 36;
            this.chkMask0.UseVisualStyleBackColor = true;
            this.chkMask0.CheckedChanged += new System.EventHandler(this.chkMask0_CheckedChanged);
            // 
            // SetMask0
            // 
            this.SetMask0.Location = new System.Drawing.Point(843, 301);
            this.SetMask0.Name = "SetMask0";
            this.SetMask0.Size = new System.Drawing.Size(63, 21);
            this.SetMask0.TabIndex = 23;
            this.SetMask0.Text = "Set";
            this.SetMask0.UseVisualStyleBackColor = true;
            this.SetMask0.Click += new System.EventHandler(this.SetMask0_Click);
            // 
            // GetMask0
            // 
            this.GetMask0.Location = new System.Drawing.Point(774, 301);
            this.GetMask0.Name = "GetMask0";
            this.GetMask0.Size = new System.Drawing.Size(63, 21);
            this.GetMask0.TabIndex = 21;
            this.GetMask0.Text = "Get";
            this.GetMask0.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.GetMask0.UseVisualStyleBackColor = true;
            this.GetMask0.Click += new System.EventHandler(this.GetMask0_Click);
            // 
            // txtMask0
            // 
            this.txtMask0.Location = new System.Drawing.Point(628, 299);
            this.txtMask0.MaxLength = 60;
            this.txtMask0.Multiline = true;
            this.txtMask0.Name = "txtMask0";
            this.txtMask0.Size = new System.Drawing.Size(124, 23);
            this.txtMask0.TabIndex = 20;
            // 
            // groupBox13
            // 
            this.groupBox13.Location = new System.Drawing.Point(470, 289);
            this.groupBox13.Name = "groupBox13";
            this.groupBox13.Size = new System.Drawing.Size(509, 303);
            this.groupBox13.TabIndex = 123;
            this.groupBox13.TabStop = false;
            this.groupBox13.Text = "EPC Mask Bank Setup";
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.groupBox45);
            this.tabPage4.Controls.Add(this.groupBox44);
            this.tabPage4.Controls.Add(this.groupBox27);
            this.tabPage4.Controls.Add(this.groupBox25);
            this.tabPage4.Controls.Add(this.groupBox20);
            this.tabPage4.Controls.Add(this.groupBox19);
            this.tabPage4.Controls.Add(this.groupBox18);
            this.tabPage4.Controls.Add(this.groupBox16);
            this.tabPage4.Controls.Add(this.groupBox15);
            this.tabPage4.Controls.Add(this.groupBox14);
            this.tabPage4.Location = new System.Drawing.Point(4, 22);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage4.Size = new System.Drawing.Size(985, 621);
            this.tabPage4.TabIndex = 7;
            this.tabPage4.Text = "Parking mode";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // groupBox45
            // 
            this.groupBox45.Controls.Add(this.btnLogDeviceSNConfSet);
            this.groupBox45.Controls.Add(this.chkParkingmodeIncDeviceSNR);
            this.groupBox45.Controls.Add(this.btnLogDeviceSNConfGet);
            this.groupBox45.Location = new System.Drawing.Point(400, 265);
            this.groupBox45.Name = "groupBox45";
            this.groupBox45.Size = new System.Drawing.Size(191, 113);
            this.groupBox45.TabIndex = 14;
            this.groupBox45.TabStop = false;
            this.groupBox45.Text = "Log device SN";
            // 
            // btnLogDeviceSNConfSet
            // 
            this.btnLogDeviceSNConfSet.Location = new System.Drawing.Point(110, 84);
            this.btnLogDeviceSNConfSet.Name = "btnLogDeviceSNConfSet";
            this.btnLogDeviceSNConfSet.Size = new System.Drawing.Size(75, 23);
            this.btnLogDeviceSNConfSet.TabIndex = 41;
            this.btnLogDeviceSNConfSet.Text = "Set";
            this.btnLogDeviceSNConfSet.UseVisualStyleBackColor = true;
            this.btnLogDeviceSNConfSet.Click += new System.EventHandler(this.btnLogDeviceSNConfSet_Click);
            // 
            // chkParkingmodeIncDeviceSNR
            // 
            this.chkParkingmodeIncDeviceSNR.AutoSize = true;
            this.chkParkingmodeIncDeviceSNR.Location = new System.Drawing.Point(7, 50);
            this.chkParkingmodeIncDeviceSNR.Name = "chkParkingmodeIncDeviceSNR";
            this.chkParkingmodeIncDeviceSNR.Size = new System.Drawing.Size(97, 17);
            this.chkParkingmodeIncDeviceSNR.TabIndex = 9;
            this.chkParkingmodeIncDeviceSNR.Text = "Log device SN";
            this.chkParkingmodeIncDeviceSNR.UseVisualStyleBackColor = true;
            // 
            // btnLogDeviceSNConfGet
            // 
            this.btnLogDeviceSNConfGet.Location = new System.Drawing.Point(6, 84);
            this.btnLogDeviceSNConfGet.Name = "btnLogDeviceSNConfGet";
            this.btnLogDeviceSNConfGet.Size = new System.Drawing.Size(75, 23);
            this.btnLogDeviceSNConfGet.TabIndex = 42;
            this.btnLogDeviceSNConfGet.Text = "Get";
            this.btnLogDeviceSNConfGet.UseVisualStyleBackColor = true;
            this.btnLogDeviceSNConfGet.Click += new System.EventHandler(this.btnLogDeviceSNConfGet_Click);
            // 
            // groupBox44
            // 
            this.groupBox44.Controls.Add(this.txtParkingmodeLoggedTIDCount);
            this.groupBox44.Controls.Add(this.btnParkingmodeLogRead);
            this.groupBox44.Controls.Add(this.btnParkingmodeGetLoggedTIDCount);
            this.groupBox44.Location = new System.Drawing.Point(203, 173);
            this.groupBox44.Name = "groupBox44";
            this.groupBox44.Size = new System.Drawing.Size(191, 114);
            this.groupBox44.TabIndex = 13;
            this.groupBox44.TabStop = false;
            this.groupBox44.Text = "Datalog";
            // 
            // txtParkingmodeLoggedTIDCount
            // 
            this.txtParkingmodeLoggedTIDCount.Location = new System.Drawing.Point(10, 23);
            this.txtParkingmodeLoggedTIDCount.Name = "txtParkingmodeLoggedTIDCount";
            this.txtParkingmodeLoggedTIDCount.Size = new System.Drawing.Size(172, 20);
            this.txtParkingmodeLoggedTIDCount.TabIndex = 11;
            // 
            // btnParkingmodeLogRead
            // 
            this.btnParkingmodeLogRead.Location = new System.Drawing.Point(10, 85);
            this.btnParkingmodeLogRead.Name = "btnParkingmodeLogRead";
            this.btnParkingmodeLogRead.Size = new System.Drawing.Size(172, 23);
            this.btnParkingmodeLogRead.TabIndex = 12;
            this.btnParkingmodeLogRead.Tag = "0";
            this.btnParkingmodeLogRead.Text = "Start Log Read";
            this.btnParkingmodeLogRead.UseVisualStyleBackColor = true;
            this.btnParkingmodeLogRead.Click += new System.EventHandler(this.btnParkingmodeLogRead_Click);
            // 
            // btnParkingmodeGetLoggedTIDCount
            // 
            this.btnParkingmodeGetLoggedTIDCount.Location = new System.Drawing.Point(10, 53);
            this.btnParkingmodeGetLoggedTIDCount.Name = "btnParkingmodeGetLoggedTIDCount";
            this.btnParkingmodeGetLoggedTIDCount.Size = new System.Drawing.Size(172, 23);
            this.btnParkingmodeGetLoggedTIDCount.TabIndex = 10;
            this.btnParkingmodeGetLoggedTIDCount.Text = "Get Logged TID count";
            this.btnParkingmodeGetLoggedTIDCount.UseVisualStyleBackColor = true;
            this.btnParkingmodeGetLoggedTIDCount.Click += new System.EventHandler(this.btnParkingmodeGetLoggedTIDCount_Click);
            // 
            // groupBox27
            // 
            this.groupBox27.Controls.Add(this.radParmodeDataToTCP_Client);
            this.groupBox27.Controls.Add(this.radParmodeDataToTCP_Server);
            this.groupBox27.Controls.Add(this.btnParkingModeSetDataRouteConf);
            this.groupBox27.Controls.Add(this.btnParkingModeGetDataRouteConf);
            this.groupBox27.Location = new System.Drawing.Point(203, 296);
            this.groupBox27.Name = "groupBox27";
            this.groupBox27.Size = new System.Drawing.Size(191, 82);
            this.groupBox27.TabIndex = 8;
            this.groupBox27.TabStop = false;
            this.groupBox27.Text = "Log data routing";
            // 
            // radParmodeDataToTCP_Client
            // 
            this.radParmodeDataToTCP_Client.AutoSize = true;
            this.radParmodeDataToTCP_Client.Location = new System.Drawing.Point(93, 19);
            this.radParmodeDataToTCP_Client.Name = "radParmodeDataToTCP_Client";
            this.radParmodeDataToTCP_Client.Size = new System.Drawing.Size(75, 17);
            this.radParmodeDataToTCP_Client.TabIndex = 9;
            this.radParmodeDataToTCP_Client.TabStop = true;
            this.radParmodeDataToTCP_Client.Text = "TCP Client";
            this.radParmodeDataToTCP_Client.UseVisualStyleBackColor = true;
            // 
            // radParmodeDataToTCP_Server
            // 
            this.radParmodeDataToTCP_Server.AutoSize = true;
            this.radParmodeDataToTCP_Server.Location = new System.Drawing.Point(7, 19);
            this.radParmodeDataToTCP_Server.Name = "radParmodeDataToTCP_Server";
            this.radParmodeDataToTCP_Server.Size = new System.Drawing.Size(80, 17);
            this.radParmodeDataToTCP_Server.TabIndex = 41;
            this.radParmodeDataToTCP_Server.TabStop = true;
            this.radParmodeDataToTCP_Server.Text = "TCP Server";
            this.radParmodeDataToTCP_Server.UseVisualStyleBackColor = true;
            // 
            // btnParkingModeSetDataRouteConf
            // 
            this.btnParkingModeSetDataRouteConf.Location = new System.Drawing.Point(104, 53);
            this.btnParkingModeSetDataRouteConf.Name = "btnParkingModeSetDataRouteConf";
            this.btnParkingModeSetDataRouteConf.Size = new System.Drawing.Size(75, 23);
            this.btnParkingModeSetDataRouteConf.TabIndex = 39;
            this.btnParkingModeSetDataRouteConf.Text = "Set";
            this.btnParkingModeSetDataRouteConf.UseVisualStyleBackColor = true;
            this.btnParkingModeSetDataRouteConf.Click += new System.EventHandler(this.btnParkingModeSetDataRouteConf_Click);
            // 
            // btnParkingModeGetDataRouteConf
            // 
            this.btnParkingModeGetDataRouteConf.Location = new System.Drawing.Point(7, 53);
            this.btnParkingModeGetDataRouteConf.Name = "btnParkingModeGetDataRouteConf";
            this.btnParkingModeGetDataRouteConf.Size = new System.Drawing.Size(75, 23);
            this.btnParkingModeGetDataRouteConf.TabIndex = 40;
            this.btnParkingModeGetDataRouteConf.Text = "Get";
            this.btnParkingModeGetDataRouteConf.UseVisualStyleBackColor = true;
            this.btnParkingModeGetDataRouteConf.Click += new System.EventHandler(this.btnParkingModeGetDataRouteConf_Click);
            // 
            // groupBox25
            // 
            this.groupBox25.Controls.Add(this.chkParkModePersistenceAutoReset);
            this.groupBox25.Controls.Add(this.btnParkModePersistenceSet);
            this.groupBox25.Controls.Add(this.btnParkModePersistenceGet);
            this.groupBox25.Controls.Add(this.label51);
            this.groupBox25.Controls.Add(this.txtParkModePersistence);
            this.groupBox25.Location = new System.Drawing.Point(400, 173);
            this.groupBox25.Name = "groupBox25";
            this.groupBox25.Size = new System.Drawing.Size(191, 84);
            this.groupBox25.TabIndex = 6;
            this.groupBox25.TabStop = false;
            this.groupBox25.Text = "TID Persistence";
            // 
            // chkParkModePersistenceAutoReset
            // 
            this.chkParkModePersistenceAutoReset.AutoSize = true;
            this.chkParkModePersistenceAutoReset.Location = new System.Drawing.Point(7, 37);
            this.chkParkModePersistenceAutoReset.Name = "chkParkModePersistenceAutoReset";
            this.chkParkModePersistenceAutoReset.Size = new System.Drawing.Size(74, 17);
            this.chkParkModePersistenceAutoReset.TabIndex = 9;
            this.chkParkModePersistenceAutoReset.Text = "Auto reset";
            this.chkParkModePersistenceAutoReset.UseVisualStyleBackColor = true;
            // 
            // btnParkModePersistenceSet
            // 
            this.btnParkModePersistenceSet.Location = new System.Drawing.Point(104, 57);
            this.btnParkModePersistenceSet.Name = "btnParkModePersistenceSet";
            this.btnParkModePersistenceSet.Size = new System.Drawing.Size(75, 23);
            this.btnParkModePersistenceSet.TabIndex = 38;
            this.btnParkModePersistenceSet.Text = "Set";
            this.btnParkModePersistenceSet.UseVisualStyleBackColor = true;
            this.btnParkModePersistenceSet.Click += new System.EventHandler(this.btnParkModePersistenceSet_Click);
            // 
            // btnParkModePersistenceGet
            // 
            this.btnParkModePersistenceGet.Location = new System.Drawing.Point(6, 57);
            this.btnParkModePersistenceGet.Name = "btnParkModePersistenceGet";
            this.btnParkModePersistenceGet.Size = new System.Drawing.Size(75, 23);
            this.btnParkModePersistenceGet.TabIndex = 39;
            this.btnParkModePersistenceGet.Text = "Get";
            this.btnParkModePersistenceGet.UseVisualStyleBackColor = true;
            this.btnParkModePersistenceGet.Click += new System.EventHandler(this.btnParkModePersistenceGet_Click);
            // 
            // label51
            // 
            this.label51.AutoSize = true;
            this.label51.Location = new System.Drawing.Point(4, 21);
            this.label51.Name = "label51";
            this.label51.Size = new System.Drawing.Size(78, 13);
            this.label51.TabIndex = 37;
            this.label51.Text = "Time (x100ms):";
            // 
            // txtParkModePersistence
            // 
            this.txtParkModePersistence.Location = new System.Drawing.Point(104, 18);
            this.txtParkModePersistence.MaxLength = 8;
            this.txtParkModePersistence.Name = "txtParkModePersistence";
            this.txtParkModePersistence.Size = new System.Drawing.Size(75, 20);
            this.txtParkModePersistence.TabIndex = 36;
            this.txtParkModePersistence.Text = "10";
            // 
            // groupBox20
            // 
            this.groupBox20.Controls.Add(this.groupBox23);
            this.groupBox20.Controls.Add(this.groupBox22);
            this.groupBox20.Location = new System.Drawing.Point(726, 173);
            this.groupBox20.Name = "groupBox20";
            this.groupBox20.Size = new System.Drawing.Size(253, 182);
            this.groupBox20.TabIndex = 5;
            this.groupBox20.TabStop = false;
            this.groupBox20.Text = "Administrative configuration(s)";
            // 
            // groupBox23
            // 
            this.groupBox23.Controls.Add(this.btnParkingmodeRecordTableReset);
            this.groupBox23.Controls.Add(this.btnParkingmodeDataLogReset);
            this.groupBox23.Location = new System.Drawing.Point(0, 101);
            this.groupBox23.Name = "groupBox23";
            this.groupBox23.Size = new System.Drawing.Size(253, 81);
            this.groupBox23.TabIndex = 6;
            this.groupBox23.TabStop = false;
            this.groupBox23.Text = "Storage configuration";
            // 
            // btnParkingmodeRecordTableReset
            // 
            this.btnParkingmodeRecordTableReset.Location = new System.Drawing.Point(6, 48);
            this.btnParkingmodeRecordTableReset.Name = "btnParkingmodeRecordTableReset";
            this.btnParkingmodeRecordTableReset.Size = new System.Drawing.Size(241, 23);
            this.btnParkingmodeRecordTableReset.TabIndex = 7;
            this.btnParkingmodeRecordTableReset.Text = "Erase all";
            this.btnParkingmodeRecordTableReset.UseVisualStyleBackColor = true;
            this.btnParkingmodeRecordTableReset.Click += new System.EventHandler(this.btnParkingmodeRecordTableReset_Click);
            // 
            // btnParkingmodeDataLogReset
            // 
            this.btnParkingmodeDataLogReset.Location = new System.Drawing.Point(6, 19);
            this.btnParkingmodeDataLogReset.Name = "btnParkingmodeDataLogReset";
            this.btnParkingmodeDataLogReset.Size = new System.Drawing.Size(241, 23);
            this.btnParkingmodeDataLogReset.TabIndex = 7;
            this.btnParkingmodeDataLogReset.Text = "Log erase";
            this.btnParkingmodeDataLogReset.UseVisualStyleBackColor = true;
            this.btnParkingmodeDataLogReset.Click += new System.EventHandler(this.btnParkingmodeDataLogReset_Click);
            // 
            // groupBox22
            // 
            this.groupBox22.Controls.Add(this.radParkModeLogAll);
            this.groupBox22.Controls.Add(this.radParkmodeLogWLOnly);
            this.groupBox22.Controls.Add(this.btnParkingmodeSetOfflineLogCfg);
            this.groupBox22.Controls.Add(this.btnParkingmodeGetOfflineLogCfg);
            this.groupBox22.Location = new System.Drawing.Point(0, 25);
            this.groupBox22.Name = "groupBox22";
            this.groupBox22.Size = new System.Drawing.Size(253, 68);
            this.groupBox22.TabIndex = 6;
            this.groupBox22.TabStop = false;
            this.groupBox22.Text = "Offline TID logging";
            // 
            // radParkModeLogAll
            // 
            this.radParkModeLogAll.AutoSize = true;
            this.radParkModeLogAll.Location = new System.Drawing.Point(124, 19);
            this.radParkModeLogAll.Name = "radParkModeLogAll";
            this.radParkModeLogAll.Size = new System.Drawing.Size(56, 17);
            this.radParkModeLogAll.TabIndex = 12;
            this.radParkModeLogAll.TabStop = true;
            this.radParkModeLogAll.Text = "Log all";
            this.radParkModeLogAll.UseVisualStyleBackColor = true;
            // 
            // radParkmodeLogWLOnly
            // 
            this.radParkmodeLogWLOnly.AutoSize = true;
            this.radParkmodeLogWLOnly.Location = new System.Drawing.Point(10, 19);
            this.radParkmodeLogWLOnly.Name = "radParkmodeLogWLOnly";
            this.radParkmodeLogWLOnly.Size = new System.Drawing.Size(108, 17);
            this.radParkmodeLogWLOnly.TabIndex = 6;
            this.radParkmodeLogWLOnly.TabStop = true;
            this.radParkmodeLogWLOnly.Text = "Log registred only";
            this.radParkmodeLogWLOnly.UseVisualStyleBackColor = true;
            // 
            // btnParkingmodeSetOfflineLogCfg
            // 
            this.btnParkingmodeSetOfflineLogCfg.Location = new System.Drawing.Point(123, 39);
            this.btnParkingmodeSetOfflineLogCfg.Name = "btnParkingmodeSetOfflineLogCfg";
            this.btnParkingmodeSetOfflineLogCfg.Size = new System.Drawing.Size(49, 23);
            this.btnParkingmodeSetOfflineLogCfg.TabIndex = 11;
            this.btnParkingmodeSetOfflineLogCfg.Text = "Set";
            this.btnParkingmodeSetOfflineLogCfg.UseVisualStyleBackColor = true;
            this.btnParkingmodeSetOfflineLogCfg.Click += new System.EventHandler(this.btnParkingmodeSetOfflineLogCfg_Click);
            // 
            // btnParkingmodeGetOfflineLogCfg
            // 
            this.btnParkingmodeGetOfflineLogCfg.Location = new System.Drawing.Point(6, 39);
            this.btnParkingmodeGetOfflineLogCfg.Name = "btnParkingmodeGetOfflineLogCfg";
            this.btnParkingmodeGetOfflineLogCfg.Size = new System.Drawing.Size(49, 23);
            this.btnParkingmodeGetOfflineLogCfg.TabIndex = 10;
            this.btnParkingmodeGetOfflineLogCfg.Text = "Get";
            this.btnParkingmodeGetOfflineLogCfg.UseVisualStyleBackColor = true;
            this.btnParkingmodeGetOfflineLogCfg.Click += new System.EventHandler(this.btnParkingmodeGetOfflineLogCfg_Click);
            // 
            // groupBox19
            // 
            this.groupBox19.Controls.Add(this.btnRelayModeSet);
            this.groupBox19.Controls.Add(this.btnRelayModeGet);
            this.groupBox19.Controls.Add(this.label86);
            this.groupBox19.Controls.Add(this.label84);
            this.groupBox19.Controls.Add(this.label82);
            this.groupBox19.Controls.Add(this.txtRelay4OnTime);
            this.groupBox19.Controls.Add(this.label80);
            this.groupBox19.Controls.Add(this.label85);
            this.groupBox19.Controls.Add(this.txtRelay3OnTime);
            this.groupBox19.Controls.Add(this.txtRelay2OnTime);
            this.groupBox19.Controls.Add(this.label83);
            this.groupBox19.Controls.Add(this.label81);
            this.groupBox19.Controls.Add(this.label79);
            this.groupBox19.Controls.Add(this.txtRelay1OnTime);
            this.groupBox19.Controls.Add(this.label78);
            this.groupBox19.Location = new System.Drawing.Point(6, 173);
            this.groupBox19.Name = "groupBox19";
            this.groupBox19.Size = new System.Drawing.Size(191, 171);
            this.groupBox19.TabIndex = 4;
            this.groupBox19.TabStop = false;
            this.groupBox19.Text = "Relay(s) Configuration";
            // 
            // btnRelayModeSet
            // 
            this.btnRelayModeSet.Location = new System.Drawing.Point(104, 142);
            this.btnRelayModeSet.Name = "btnRelayModeSet";
            this.btnRelayModeSet.Size = new System.Drawing.Size(75, 23);
            this.btnRelayModeSet.TabIndex = 5;
            this.btnRelayModeSet.Text = "Set";
            this.btnRelayModeSet.UseVisualStyleBackColor = true;
            this.btnRelayModeSet.Click += new System.EventHandler(this.btnRelayModeSet_Click);
            // 
            // btnRelayModeGet
            // 
            this.btnRelayModeGet.Location = new System.Drawing.Point(7, 142);
            this.btnRelayModeGet.Name = "btnRelayModeGet";
            this.btnRelayModeGet.Size = new System.Drawing.Size(75, 23);
            this.btnRelayModeGet.TabIndex = 5;
            this.btnRelayModeGet.Text = "Get";
            this.btnRelayModeGet.UseVisualStyleBackColor = true;
            this.btnRelayModeGet.Click += new System.EventHandler(this.btnRelayModeGet_Click);
            // 
            // label86
            // 
            this.label86.AutoSize = true;
            this.label86.Location = new System.Drawing.Point(77, 20);
            this.label86.Name = "label86";
            this.label86.Size = new System.Drawing.Size(47, 13);
            this.label86.TabIndex = 5;
            this.label86.Text = "On Time";
            // 
            // label84
            // 
            this.label84.AutoSize = true;
            this.label84.Location = new System.Drawing.Point(131, 118);
            this.label84.Name = "label84";
            this.label84.Size = new System.Drawing.Size(48, 13);
            this.label84.TabIndex = 6;
            this.label84.Text = "x 100mS";
            // 
            // label82
            // 
            this.label82.AutoSize = true;
            this.label82.Location = new System.Drawing.Point(131, 92);
            this.label82.Name = "label82";
            this.label82.Size = new System.Drawing.Size(48, 13);
            this.label82.TabIndex = 6;
            this.label82.Text = "x 100mS";
            // 
            // txtRelay4OnTime
            // 
            this.txtRelay4OnTime.Location = new System.Drawing.Point(62, 115);
            this.txtRelay4OnTime.Name = "txtRelay4OnTime";
            this.txtRelay4OnTime.Size = new System.Drawing.Size(66, 20);
            this.txtRelay4OnTime.TabIndex = 7;
            // 
            // label80
            // 
            this.label80.AutoSize = true;
            this.label80.Location = new System.Drawing.Point(131, 66);
            this.label80.Name = "label80";
            this.label80.Size = new System.Drawing.Size(48, 13);
            this.label80.TabIndex = 6;
            this.label80.Text = "x 100mS";
            // 
            // label85
            // 
            this.label85.AutoSize = true;
            this.label85.Location = new System.Drawing.Point(7, 118);
            this.label85.Name = "label85";
            this.label85.Size = new System.Drawing.Size(46, 13);
            this.label85.TabIndex = 9;
            this.label85.Text = "Relay 4:";
            // 
            // txtRelay3OnTime
            // 
            this.txtRelay3OnTime.Location = new System.Drawing.Point(62, 89);
            this.txtRelay3OnTime.Name = "txtRelay3OnTime";
            this.txtRelay3OnTime.Size = new System.Drawing.Size(66, 20);
            this.txtRelay3OnTime.TabIndex = 7;
            // 
            // txtRelay2OnTime
            // 
            this.txtRelay2OnTime.Location = new System.Drawing.Point(62, 63);
            this.txtRelay2OnTime.Name = "txtRelay2OnTime";
            this.txtRelay2OnTime.Size = new System.Drawing.Size(66, 20);
            this.txtRelay2OnTime.TabIndex = 7;
            // 
            // label83
            // 
            this.label83.AutoSize = true;
            this.label83.Location = new System.Drawing.Point(7, 92);
            this.label83.Name = "label83";
            this.label83.Size = new System.Drawing.Size(46, 13);
            this.label83.TabIndex = 9;
            this.label83.Text = "Relay 3:";
            // 
            // label81
            // 
            this.label81.AutoSize = true;
            this.label81.Location = new System.Drawing.Point(7, 66);
            this.label81.Name = "label81";
            this.label81.Size = new System.Drawing.Size(46, 13);
            this.label81.TabIndex = 9;
            this.label81.Text = "Relay 2:";
            // 
            // label79
            // 
            this.label79.AutoSize = true;
            this.label79.Location = new System.Drawing.Point(131, 39);
            this.label79.Name = "label79";
            this.label79.Size = new System.Drawing.Size(48, 13);
            this.label79.TabIndex = 5;
            this.label79.Text = "x 100mS";
            // 
            // txtRelay1OnTime
            // 
            this.txtRelay1OnTime.Location = new System.Drawing.Point(62, 36);
            this.txtRelay1OnTime.Name = "txtRelay1OnTime";
            this.txtRelay1OnTime.Size = new System.Drawing.Size(66, 20);
            this.txtRelay1OnTime.TabIndex = 5;
            // 
            // label78
            // 
            this.label78.AutoSize = true;
            this.label78.Location = new System.Drawing.Point(7, 39);
            this.label78.Name = "label78";
            this.label78.Size = new System.Drawing.Size(46, 13);
            this.label78.TabIndex = 5;
            this.label78.Text = "Relay 1:";
            // 
            // groupBox18
            // 
            this.groupBox18.Controls.Add(this.btnParkModeCatConfSet);
            this.groupBox18.Controls.Add(this.btnParkModeCatConfGet);
            this.groupBox18.Controls.Add(this.chkCat4R4);
            this.groupBox18.Controls.Add(this.chkCat3R4);
            this.groupBox18.Controls.Add(this.chkCat4R3);
            this.groupBox18.Controls.Add(this.chkCat4R2);
            this.groupBox18.Controls.Add(this.chkCat2R4);
            this.groupBox18.Controls.Add(this.chkCat4R1);
            this.groupBox18.Controls.Add(this.chkCat3R3);
            this.groupBox18.Controls.Add(this.chkCat2R3);
            this.groupBox18.Controls.Add(this.chkCat3R2);
            this.groupBox18.Controls.Add(this.chkCat3R1);
            this.groupBox18.Controls.Add(this.chkCat2R2);
            this.groupBox18.Controls.Add(this.chkCat2R1);
            this.groupBox18.Controls.Add(this.chkCat1R4);
            this.groupBox18.Controls.Add(this.chkCat1R3);
            this.groupBox18.Controls.Add(this.chkCat1R2);
            this.groupBox18.Controls.Add(this.chkCat1R1);
            this.groupBox18.Controls.Add(this.label77);
            this.groupBox18.Controls.Add(this.label76);
            this.groupBox18.Controls.Add(this.label75);
            this.groupBox18.Controls.Add(this.label74);
            this.groupBox18.Location = new System.Drawing.Point(726, 6);
            this.groupBox18.Name = "groupBox18";
            this.groupBox18.Size = new System.Drawing.Size(253, 161);
            this.groupBox18.TabIndex = 3;
            this.groupBox18.TabStop = false;
            this.groupBox18.Text = "Category-Relay(s) selection";
            // 
            // btnParkModeCatConfSet
            // 
            this.btnParkModeCatConfSet.Location = new System.Drawing.Point(172, 132);
            this.btnParkModeCatConfSet.Name = "btnParkModeCatConfSet";
            this.btnParkModeCatConfSet.Size = new System.Drawing.Size(75, 23);
            this.btnParkModeCatConfSet.TabIndex = 5;
            this.btnParkModeCatConfSet.Text = "Set";
            this.btnParkModeCatConfSet.UseVisualStyleBackColor = true;
            this.btnParkModeCatConfSet.Click += new System.EventHandler(this.btnParkModeCatConfSet_Click);
            // 
            // btnParkModeCatConfGet
            // 
            this.btnParkModeCatConfGet.Location = new System.Drawing.Point(91, 132);
            this.btnParkModeCatConfGet.Name = "btnParkModeCatConfGet";
            this.btnParkModeCatConfGet.Size = new System.Drawing.Size(75, 23);
            this.btnParkModeCatConfGet.TabIndex = 13;
            this.btnParkModeCatConfGet.Text = "Get";
            this.btnParkModeCatConfGet.UseVisualStyleBackColor = true;
            this.btnParkModeCatConfGet.Click += new System.EventHandler(this.btnParkModeCatConfGet_Click);
            // 
            // chkCat4R4
            // 
            this.chkCat4R4.AutoSize = true;
            this.chkCat4R4.Location = new System.Drawing.Point(207, 98);
            this.chkCat4R4.Name = "chkCat4R4";
            this.chkCat4R4.Size = new System.Drawing.Size(40, 17);
            this.chkCat4R4.TabIndex = 12;
            this.chkCat4R4.Text = "R4";
            this.chkCat4R4.UseVisualStyleBackColor = true;
            // 
            // chkCat3R4
            // 
            this.chkCat3R4.AutoSize = true;
            this.chkCat3R4.Location = new System.Drawing.Point(207, 75);
            this.chkCat3R4.Name = "chkCat3R4";
            this.chkCat3R4.Size = new System.Drawing.Size(40, 17);
            this.chkCat3R4.TabIndex = 12;
            this.chkCat3R4.Text = "R4";
            this.chkCat3R4.UseVisualStyleBackColor = true;
            // 
            // chkCat4R3
            // 
            this.chkCat4R3.AutoSize = true;
            this.chkCat4R3.Location = new System.Drawing.Point(162, 98);
            this.chkCat4R3.Name = "chkCat4R3";
            this.chkCat4R3.Size = new System.Drawing.Size(40, 17);
            this.chkCat4R3.TabIndex = 11;
            this.chkCat4R3.Text = "R3";
            this.chkCat4R3.UseVisualStyleBackColor = true;
            // 
            // chkCat4R2
            // 
            this.chkCat4R2.AutoSize = true;
            this.chkCat4R2.Location = new System.Drawing.Point(116, 98);
            this.chkCat4R2.Name = "chkCat4R2";
            this.chkCat4R2.Size = new System.Drawing.Size(40, 17);
            this.chkCat4R2.TabIndex = 10;
            this.chkCat4R2.Text = "R2";
            this.chkCat4R2.UseVisualStyleBackColor = true;
            // 
            // chkCat2R4
            // 
            this.chkCat2R4.AutoSize = true;
            this.chkCat2R4.Location = new System.Drawing.Point(207, 52);
            this.chkCat2R4.Name = "chkCat2R4";
            this.chkCat2R4.Size = new System.Drawing.Size(40, 17);
            this.chkCat2R4.TabIndex = 12;
            this.chkCat2R4.Text = "R4";
            this.chkCat2R4.UseVisualStyleBackColor = true;
            // 
            // chkCat4R1
            // 
            this.chkCat4R1.AutoSize = true;
            this.chkCat4R1.Location = new System.Drawing.Point(70, 98);
            this.chkCat4R1.Name = "chkCat4R1";
            this.chkCat4R1.Size = new System.Drawing.Size(40, 17);
            this.chkCat4R1.TabIndex = 9;
            this.chkCat4R1.Text = "R1";
            this.chkCat4R1.UseVisualStyleBackColor = true;
            // 
            // chkCat3R3
            // 
            this.chkCat3R3.AutoSize = true;
            this.chkCat3R3.Location = new System.Drawing.Point(162, 75);
            this.chkCat3R3.Name = "chkCat3R3";
            this.chkCat3R3.Size = new System.Drawing.Size(40, 17);
            this.chkCat3R3.TabIndex = 11;
            this.chkCat3R3.Text = "R3";
            this.chkCat3R3.UseVisualStyleBackColor = true;
            // 
            // chkCat2R3
            // 
            this.chkCat2R3.AutoSize = true;
            this.chkCat2R3.Location = new System.Drawing.Point(162, 52);
            this.chkCat2R3.Name = "chkCat2R3";
            this.chkCat2R3.Size = new System.Drawing.Size(40, 17);
            this.chkCat2R3.TabIndex = 11;
            this.chkCat2R3.Text = "R3";
            this.chkCat2R3.UseVisualStyleBackColor = true;
            // 
            // chkCat3R2
            // 
            this.chkCat3R2.AutoSize = true;
            this.chkCat3R2.Location = new System.Drawing.Point(116, 75);
            this.chkCat3R2.Name = "chkCat3R2";
            this.chkCat3R2.Size = new System.Drawing.Size(40, 17);
            this.chkCat3R2.TabIndex = 10;
            this.chkCat3R2.Text = "R2";
            this.chkCat3R2.UseVisualStyleBackColor = true;
            // 
            // chkCat3R1
            // 
            this.chkCat3R1.AutoSize = true;
            this.chkCat3R1.Location = new System.Drawing.Point(70, 75);
            this.chkCat3R1.Name = "chkCat3R1";
            this.chkCat3R1.Size = new System.Drawing.Size(40, 17);
            this.chkCat3R1.TabIndex = 9;
            this.chkCat3R1.Text = "R1";
            this.chkCat3R1.UseVisualStyleBackColor = true;
            // 
            // chkCat2R2
            // 
            this.chkCat2R2.AutoSize = true;
            this.chkCat2R2.Location = new System.Drawing.Point(116, 52);
            this.chkCat2R2.Name = "chkCat2R2";
            this.chkCat2R2.Size = new System.Drawing.Size(40, 17);
            this.chkCat2R2.TabIndex = 10;
            this.chkCat2R2.Text = "R2";
            this.chkCat2R2.UseVisualStyleBackColor = true;
            // 
            // chkCat2R1
            // 
            this.chkCat2R1.AutoSize = true;
            this.chkCat2R1.Location = new System.Drawing.Point(70, 52);
            this.chkCat2R1.Name = "chkCat2R1";
            this.chkCat2R1.Size = new System.Drawing.Size(40, 17);
            this.chkCat2R1.TabIndex = 9;
            this.chkCat2R1.Text = "R1";
            this.chkCat2R1.UseVisualStyleBackColor = true;
            // 
            // chkCat1R4
            // 
            this.chkCat1R4.AutoSize = true;
            this.chkCat1R4.Location = new System.Drawing.Point(207, 27);
            this.chkCat1R4.Name = "chkCat1R4";
            this.chkCat1R4.Size = new System.Drawing.Size(40, 17);
            this.chkCat1R4.TabIndex = 8;
            this.chkCat1R4.Text = "R4";
            this.chkCat1R4.UseVisualStyleBackColor = true;
            // 
            // chkCat1R3
            // 
            this.chkCat1R3.AutoSize = true;
            this.chkCat1R3.Location = new System.Drawing.Point(162, 27);
            this.chkCat1R3.Name = "chkCat1R3";
            this.chkCat1R3.Size = new System.Drawing.Size(40, 17);
            this.chkCat1R3.TabIndex = 7;
            this.chkCat1R3.Text = "R3";
            this.chkCat1R3.UseVisualStyleBackColor = true;
            // 
            // chkCat1R2
            // 
            this.chkCat1R2.AutoSize = true;
            this.chkCat1R2.Location = new System.Drawing.Point(116, 27);
            this.chkCat1R2.Name = "chkCat1R2";
            this.chkCat1R2.Size = new System.Drawing.Size(40, 17);
            this.chkCat1R2.TabIndex = 6;
            this.chkCat1R2.Text = "R2";
            this.chkCat1R2.UseVisualStyleBackColor = true;
            // 
            // chkCat1R1
            // 
            this.chkCat1R1.AutoSize = true;
            this.chkCat1R1.Location = new System.Drawing.Point(70, 27);
            this.chkCat1R1.Name = "chkCat1R1";
            this.chkCat1R1.Size = new System.Drawing.Size(40, 17);
            this.chkCat1R1.TabIndex = 5;
            this.chkCat1R1.Text = "R1";
            this.chkCat1R1.UseVisualStyleBackColor = true;
            // 
            // label77
            // 
            this.label77.AutoSize = true;
            this.label77.Location = new System.Drawing.Point(6, 99);
            this.label77.Name = "label77";
            this.label77.Size = new System.Drawing.Size(58, 13);
            this.label77.TabIndex = 4;
            this.label77.Text = "Category-4";
            // 
            // label76
            // 
            this.label76.AutoSize = true;
            this.label76.Location = new System.Drawing.Point(6, 75);
            this.label76.Name = "label76";
            this.label76.Size = new System.Drawing.Size(58, 13);
            this.label76.TabIndex = 2;
            this.label76.Text = "Category-3";
            // 
            // label75
            // 
            this.label75.AutoSize = true;
            this.label75.Location = new System.Drawing.Point(6, 53);
            this.label75.Name = "label75";
            this.label75.Size = new System.Drawing.Size(58, 13);
            this.label75.TabIndex = 1;
            this.label75.Text = "Category-2";
            // 
            // label74
            // 
            this.label74.AutoSize = true;
            this.label74.Location = new System.Drawing.Point(6, 31);
            this.label74.Name = "label74";
            this.label74.Size = new System.Drawing.Size(58, 13);
            this.label74.TabIndex = 0;
            this.label74.Text = "Category-1";
            // 
            // groupBox16
            // 
            this.groupBox16.Controls.Add(this.btnParkmodeDeleteExistingRecord);
            this.groupBox16.Controls.Add(this.btnParkmodeUpdateExistingRecord);
            this.groupBox16.Controls.Add(this.groupBox17);
            this.groupBox16.Controls.Add(this.chkCat4);
            this.groupBox16.Controls.Add(this.chkCat3);
            this.groupBox16.Controls.Add(this.label73);
            this.groupBox16.Controls.Add(this.chkCat2);
            this.groupBox16.Controls.Add(this.btnParkingModeCheckForEntry);
            this.groupBox16.Controls.Add(this.chkCat1);
            this.groupBox16.Controls.Add(this.label72);
            this.groupBox16.Controls.Add(this.txtParkmodeRecordToCheck);
            this.groupBox16.Location = new System.Drawing.Point(465, 6);
            this.groupBox16.Name = "groupBox16";
            this.groupBox16.Size = new System.Drawing.Size(255, 161);
            this.groupBox16.TabIndex = 2;
            this.groupBox16.TabStop = false;
            this.groupBox16.Text = "Tag entry modification";
            // 
            // btnParkmodeDeleteExistingRecord
            // 
            this.btnParkmodeDeleteExistingRecord.Location = new System.Drawing.Point(171, 131);
            this.btnParkmodeDeleteExistingRecord.Name = "btnParkmodeDeleteExistingRecord";
            this.btnParkmodeDeleteExistingRecord.Size = new System.Drawing.Size(75, 23);
            this.btnParkmodeDeleteExistingRecord.TabIndex = 13;
            this.btnParkmodeDeleteExistingRecord.Text = "Delete";
            this.btnParkmodeDeleteExistingRecord.UseVisualStyleBackColor = true;
            this.btnParkmodeDeleteExistingRecord.Click += new System.EventHandler(this.btnParkmodeDeleteExistingRecord_Click);
            // 
            // btnParkmodeUpdateExistingRecord
            // 
            this.btnParkmodeUpdateExistingRecord.Location = new System.Drawing.Point(90, 131);
            this.btnParkmodeUpdateExistingRecord.Name = "btnParkmodeUpdateExistingRecord";
            this.btnParkmodeUpdateExistingRecord.Size = new System.Drawing.Size(75, 23);
            this.btnParkmodeUpdateExistingRecord.TabIndex = 12;
            this.btnParkmodeUpdateExistingRecord.Text = "Update";
            this.btnParkmodeUpdateExistingRecord.UseVisualStyleBackColor = true;
            this.btnParkmodeUpdateExistingRecord.Click += new System.EventHandler(this.btnParkmodeUpdateExistingRecord_Click);
            // 
            // groupBox17
            // 
            this.groupBox17.Controls.Add(this.chkRecordIsWhitelist);
            this.groupBox17.Controls.Add(this.chkRecordIsBlacklist);
            this.groupBox17.Location = new System.Drawing.Point(9, 80);
            this.groupBox17.Name = "groupBox17";
            this.groupBox17.Size = new System.Drawing.Size(169, 41);
            this.groupBox17.TabIndex = 11;
            this.groupBox17.TabStop = false;
            this.groupBox17.Text = "Status";
            // 
            // chkRecordIsWhitelist
            // 
            this.chkRecordIsWhitelist.AutoSize = true;
            this.chkRecordIsWhitelist.Location = new System.Drawing.Point(6, 18);
            this.chkRecordIsWhitelist.Name = "chkRecordIsWhitelist";
            this.chkRecordIsWhitelist.Size = new System.Drawing.Size(65, 17);
            this.chkRecordIsWhitelist.TabIndex = 9;
            this.chkRecordIsWhitelist.TabStop = true;
            this.chkRecordIsWhitelist.Text = "Whitelist";
            this.chkRecordIsWhitelist.UseVisualStyleBackColor = true;
            // 
            // chkRecordIsBlacklist
            // 
            this.chkRecordIsBlacklist.AutoSize = true;
            this.chkRecordIsBlacklist.Location = new System.Drawing.Point(77, 18);
            this.chkRecordIsBlacklist.Name = "chkRecordIsBlacklist";
            this.chkRecordIsBlacklist.Size = new System.Drawing.Size(64, 17);
            this.chkRecordIsBlacklist.TabIndex = 10;
            this.chkRecordIsBlacklist.TabStop = true;
            this.chkRecordIsBlacklist.Text = "Blacklist";
            this.chkRecordIsBlacklist.UseVisualStyleBackColor = true;
            // 
            // chkCat4
            // 
            this.chkCat4.AutoSize = true;
            this.chkCat4.Location = new System.Drawing.Point(215, 57);
            this.chkCat4.Name = "chkCat4";
            this.chkCat4.Size = new System.Drawing.Size(31, 17);
            this.chkCat4.TabIndex = 5;
            this.chkCat4.TabStop = true;
            this.chkCat4.Text = "4";
            this.chkCat4.UseVisualStyleBackColor = true;
            // 
            // chkCat3
            // 
            this.chkCat3.AutoSize = true;
            this.chkCat3.Location = new System.Drawing.Point(168, 57);
            this.chkCat3.Name = "chkCat3";
            this.chkCat3.Size = new System.Drawing.Size(31, 17);
            this.chkCat3.TabIndex = 7;
            this.chkCat3.TabStop = true;
            this.chkCat3.Text = "3";
            this.chkCat3.UseVisualStyleBackColor = true;
            // 
            // label73
            // 
            this.label73.AutoSize = true;
            this.label73.Location = new System.Drawing.Point(6, 59);
            this.label73.Name = "label73";
            this.label73.Size = new System.Drawing.Size(52, 13);
            this.label73.TabIndex = 4;
            this.label73.Text = "Category:";
            // 
            // chkCat2
            // 
            this.chkCat2.AutoSize = true;
            this.chkCat2.Location = new System.Drawing.Point(116, 57);
            this.chkCat2.Name = "chkCat2";
            this.chkCat2.Size = new System.Drawing.Size(31, 17);
            this.chkCat2.TabIndex = 6;
            this.chkCat2.TabStop = true;
            this.chkCat2.Text = "2";
            this.chkCat2.UseVisualStyleBackColor = true;
            // 
            // btnParkingModeCheckForEntry
            // 
            this.btnParkingModeCheckForEntry.Location = new System.Drawing.Point(9, 131);
            this.btnParkingModeCheckForEntry.Name = "btnParkingModeCheckForEntry";
            this.btnParkingModeCheckForEntry.Size = new System.Drawing.Size(75, 23);
            this.btnParkingModeCheckForEntry.TabIndex = 5;
            this.btnParkingModeCheckForEntry.Text = "Check";
            this.btnParkingModeCheckForEntry.UseVisualStyleBackColor = true;
            this.btnParkingModeCheckForEntry.Click += new System.EventHandler(this.btnParkingModeCheckForEntry_Click);
            // 
            // chkCat1
            // 
            this.chkCat1.AutoSize = true;
            this.chkCat1.Location = new System.Drawing.Point(64, 57);
            this.chkCat1.Name = "chkCat1";
            this.chkCat1.Size = new System.Drawing.Size(31, 17);
            this.chkCat1.TabIndex = 4;
            this.chkCat1.TabStop = true;
            this.chkCat1.Text = "1";
            this.chkCat1.UseVisualStyleBackColor = true;
            // 
            // label72
            // 
            this.label72.AutoSize = true;
            this.label72.Location = new System.Drawing.Point(5, 31);
            this.label72.Name = "label72";
            this.label72.Size = new System.Drawing.Size(28, 13);
            this.label72.TabIndex = 3;
            this.label72.Text = "TID:";
            // 
            // txtParkmodeRecordToCheck
            // 
            this.txtParkmodeRecordToCheck.Location = new System.Drawing.Point(39, 28);
            this.txtParkmodeRecordToCheck.Name = "txtParkmodeRecordToCheck";
            this.txtParkmodeRecordToCheck.Size = new System.Drawing.Size(207, 20);
            this.txtParkmodeRecordToCheck.TabIndex = 4;
            // 
            // groupBox15
            // 
            this.groupBox15.Controls.Add(this.btnParkModeReadAllrecords);
            this.groupBox15.Controls.Add(this.btnParkModeCheckTagEntries);
            this.groupBox15.Controls.Add(this.label71);
            this.groupBox15.Controls.Add(this.txtParkModeBlacklistRecordsCounter);
            this.groupBox15.Controls.Add(this.txtParkModeWhitelistRecordsCounter);
            this.groupBox15.Controls.Add(this.label70);
            this.groupBox15.Location = new System.Drawing.Point(242, 6);
            this.groupBox15.Name = "groupBox15";
            this.groupBox15.Size = new System.Drawing.Size(217, 161);
            this.groupBox15.TabIndex = 1;
            this.groupBox15.TabStop = false;
            this.groupBox15.Text = "General statistics";
            // 
            // btnParkModeReadAllrecords
            // 
            this.btnParkModeReadAllrecords.Location = new System.Drawing.Point(9, 104);
            this.btnParkModeReadAllrecords.Name = "btnParkModeReadAllrecords";
            this.btnParkModeReadAllrecords.Size = new System.Drawing.Size(199, 23);
            this.btnParkModeReadAllrecords.TabIndex = 7;
            this.btnParkModeReadAllrecords.Tag = "0";
            this.btnParkModeReadAllrecords.Text = "Start Record(s) Read";
            this.btnParkModeReadAllrecords.UseVisualStyleBackColor = true;
            this.btnParkModeReadAllrecords.Click += new System.EventHandler(this.btnParkModeReadAllrecords_Click);
            // 
            // btnParkModeCheckTagEntries
            // 
            this.btnParkModeCheckTagEntries.Location = new System.Drawing.Point(9, 77);
            this.btnParkModeCheckTagEntries.Name = "btnParkModeCheckTagEntries";
            this.btnParkModeCheckTagEntries.Size = new System.Drawing.Size(199, 23);
            this.btnParkModeCheckTagEntries.TabIndex = 6;
            this.btnParkModeCheckTagEntries.Text = "Check tag entries";
            this.btnParkModeCheckTagEntries.UseVisualStyleBackColor = true;
            this.btnParkModeCheckTagEntries.Click += new System.EventHandler(this.btnParkModeCheckTagEntries_Click);
            // 
            // label71
            // 
            this.label71.AutoSize = true;
            this.label71.Location = new System.Drawing.Point(6, 51);
            this.label71.Name = "label71";
            this.label71.Size = new System.Drawing.Size(95, 13);
            this.label71.TabIndex = 5;
            this.label71.Text = "Blacklisted entries:";
            // 
            // txtParkModeBlacklistRecordsCounter
            // 
            this.txtParkModeBlacklistRecordsCounter.Location = new System.Drawing.Point(108, 48);
            this.txtParkModeBlacklistRecordsCounter.Name = "txtParkModeBlacklistRecordsCounter";
            this.txtParkModeBlacklistRecordsCounter.Size = new System.Drawing.Size(100, 20);
            this.txtParkModeBlacklistRecordsCounter.TabIndex = 4;
            // 
            // txtParkModeWhitelistRecordsCounter
            // 
            this.txtParkModeWhitelistRecordsCounter.Location = new System.Drawing.Point(108, 20);
            this.txtParkModeWhitelistRecordsCounter.Name = "txtParkModeWhitelistRecordsCounter";
            this.txtParkModeWhitelistRecordsCounter.Size = new System.Drawing.Size(100, 20);
            this.txtParkModeWhitelistRecordsCounter.TabIndex = 3;
            // 
            // label70
            // 
            this.label70.AutoSize = true;
            this.label70.Location = new System.Drawing.Point(6, 24);
            this.label70.Name = "label70";
            this.label70.Size = new System.Drawing.Size(96, 13);
            this.label70.TabIndex = 2;
            this.label70.Text = "Whitelisted entries:";
            // 
            // groupBox14
            // 
            this.groupBox14.Controls.Add(this.chkParkmodeAutoRegister);
            this.groupBox14.Controls.Add(this.btnLoadFromCSV);
            this.groupBox14.Controls.Add(this.btnParkModeEPC_Query);
            this.groupBox14.Controls.Add(this.chkParkModeTagWhitelistEnable);
            this.groupBox14.Controls.Add(this.radParkModeCat4);
            this.groupBox14.Controls.Add(this.radParkModeCat3);
            this.groupBox14.Controls.Add(this.radParkModeCat2);
            this.groupBox14.Controls.Add(this.radParkModeCat1);
            this.groupBox14.Controls.Add(this.label50);
            this.groupBox14.Controls.Add(this.btnParkModeTagRegister);
            this.groupBox14.Controls.Add(this.label34);
            this.groupBox14.Controls.Add(this.txtParkingmodeEPCtoRegister);
            this.groupBox14.Location = new System.Drawing.Point(6, 6);
            this.groupBox14.Name = "groupBox14";
            this.groupBox14.Size = new System.Drawing.Size(230, 161);
            this.groupBox14.TabIndex = 0;
            this.groupBox14.TabStop = false;
            this.groupBox14.Text = "Tag registration";
            // 
            // chkParkmodeAutoRegister
            // 
            this.chkParkmodeAutoRegister.AutoSize = true;
            this.chkParkmodeAutoRegister.Location = new System.Drawing.Point(7, 111);
            this.chkParkmodeAutoRegister.Name = "chkParkmodeAutoRegister";
            this.chkParkmodeAutoRegister.Size = new System.Drawing.Size(112, 17);
            this.chkParkmodeAutoRegister.TabIndex = 6;
            this.chkParkmodeAutoRegister.Text = "Allow auto register";
            this.chkParkmodeAutoRegister.UseVisualStyleBackColor = true;
            this.chkParkmodeAutoRegister.Visible = false;
            // 
            // btnLoadFromCSV
            // 
            this.btnLoadFromCSV.Location = new System.Drawing.Point(122, 104);
            this.btnLoadFromCSV.Name = "btnLoadFromCSV";
            this.btnLoadFromCSV.Size = new System.Drawing.Size(102, 23);
            this.btnLoadFromCSV.TabIndex = 6;
            this.btnLoadFromCSV.Text = "Load from CSV";
            this.btnLoadFromCSV.UseVisualStyleBackColor = true;
            this.btnLoadFromCSV.Visible = false;
            this.btnLoadFromCSV.Click += new System.EventHandler(this.btnLoadFromCSV_Click);
            // 
            // btnParkModeEPC_Query
            // 
            this.btnParkModeEPC_Query.Location = new System.Drawing.Point(6, 132);
            this.btnParkModeEPC_Query.Name = "btnParkModeEPC_Query";
            this.btnParkModeEPC_Query.Size = new System.Drawing.Size(107, 23);
            this.btnParkModeEPC_Query.TabIndex = 1;
            this.btnParkModeEPC_Query.Text = "Query";
            this.btnParkModeEPC_Query.UseVisualStyleBackColor = true;
            this.btnParkModeEPC_Query.Click += new System.EventHandler(this.btnParkModeEPC_Query_Click);
            // 
            // chkParkModeTagWhitelistEnable
            // 
            this.chkParkModeTagWhitelistEnable.AutoSize = true;
            this.chkParkModeTagWhitelistEnable.Location = new System.Drawing.Point(6, 88);
            this.chkParkModeTagWhitelistEnable.Name = "chkParkModeTagWhitelistEnable";
            this.chkParkModeTagWhitelistEnable.Size = new System.Drawing.Size(102, 17);
            this.chkParkModeTagWhitelistEnable.TabIndex = 1;
            this.chkParkModeTagWhitelistEnable.Text = "Whitelist Enable";
            this.chkParkModeTagWhitelistEnable.UseVisualStyleBackColor = true;
            // 
            // radParkModeCat4
            // 
            this.radParkModeCat4.AutoSize = true;
            this.radParkModeCat4.Location = new System.Drawing.Point(193, 65);
            this.radParkModeCat4.Name = "radParkModeCat4";
            this.radParkModeCat4.Size = new System.Drawing.Size(31, 17);
            this.radParkModeCat4.TabIndex = 2;
            this.radParkModeCat4.TabStop = true;
            this.radParkModeCat4.Text = "4";
            this.radParkModeCat4.UseVisualStyleBackColor = true;
            // 
            // radParkModeCat3
            // 
            this.radParkModeCat3.AutoSize = true;
            this.radParkModeCat3.Location = new System.Drawing.Point(149, 65);
            this.radParkModeCat3.Name = "radParkModeCat3";
            this.radParkModeCat3.Size = new System.Drawing.Size(31, 17);
            this.radParkModeCat3.TabIndex = 3;
            this.radParkModeCat3.TabStop = true;
            this.radParkModeCat3.Text = "3";
            this.radParkModeCat3.UseVisualStyleBackColor = true;
            // 
            // radParkModeCat2
            // 
            this.radParkModeCat2.AutoSize = true;
            this.radParkModeCat2.Location = new System.Drawing.Point(105, 65);
            this.radParkModeCat2.Name = "radParkModeCat2";
            this.radParkModeCat2.Size = new System.Drawing.Size(31, 17);
            this.radParkModeCat2.TabIndex = 2;
            this.radParkModeCat2.TabStop = true;
            this.radParkModeCat2.Text = "2";
            this.radParkModeCat2.UseVisualStyleBackColor = true;
            // 
            // radParkModeCat1
            // 
            this.radParkModeCat1.AutoSize = true;
            this.radParkModeCat1.Location = new System.Drawing.Point(65, 65);
            this.radParkModeCat1.Name = "radParkModeCat1";
            this.radParkModeCat1.Size = new System.Drawing.Size(31, 17);
            this.radParkModeCat1.TabIndex = 1;
            this.radParkModeCat1.TabStop = true;
            this.radParkModeCat1.Text = "1";
            this.radParkModeCat1.UseVisualStyleBackColor = true;
            // 
            // label50
            // 
            this.label50.AutoSize = true;
            this.label50.Location = new System.Drawing.Point(7, 65);
            this.label50.Name = "label50";
            this.label50.Size = new System.Drawing.Size(52, 13);
            this.label50.TabIndex = 1;
            this.label50.Text = "Category:";
            // 
            // btnParkModeTagRegister
            // 
            this.btnParkModeTagRegister.Location = new System.Drawing.Point(119, 132);
            this.btnParkModeTagRegister.Name = "btnParkModeTagRegister";
            this.btnParkModeTagRegister.Size = new System.Drawing.Size(105, 23);
            this.btnParkModeTagRegister.TabIndex = 1;
            this.btnParkModeTagRegister.Text = "Register";
            this.btnParkModeTagRegister.UseVisualStyleBackColor = true;
            this.btnParkModeTagRegister.Click += new System.EventHandler(this.btnParkModeTagRegister_Click);
            // 
            // label34
            // 
            this.label34.AutoSize = true;
            this.label34.Location = new System.Drawing.Point(7, 31);
            this.label34.Name = "label34";
            this.label34.Size = new System.Drawing.Size(28, 13);
            this.label34.TabIndex = 1;
            this.label34.Text = "TID:";
            // 
            // txtParkingmodeEPCtoRegister
            // 
            this.txtParkingmodeEPCtoRegister.Location = new System.Drawing.Point(41, 28);
            this.txtParkingmodeEPCtoRegister.Name = "txtParkingmodeEPCtoRegister";
            this.txtParkingmodeEPCtoRegister.Size = new System.Drawing.Size(183, 20);
            this.txtParkingmodeEPCtoRegister.TabIndex = 1;
            // 
            // tabPage5
            // 
            this.tabPage5.Controls.Add(this.txtRSSIAvg);
            this.tabPage5.Controls.Add(this.txtRSSINow);
            this.tabPage5.Controls.Add(this.cbxCurrentFreq);
            this.tabPage5.Controls.Add(this.btnRFDiagnosisCtrl);
            this.tabPage5.Controls.Add(this.zedGraphControl1);
            this.tabPage5.Location = new System.Drawing.Point(4, 22);
            this.tabPage5.Name = "tabPage5";
            this.tabPage5.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage5.Size = new System.Drawing.Size(985, 621);
            this.tabPage5.TabIndex = 4;
            this.tabPage5.Text = "RF diagnosis";
            this.tabPage5.UseVisualStyleBackColor = true;
            // 
            // txtRSSIAvg
            // 
            this.txtRSSIAvg.Location = new System.Drawing.Point(250, 580);
            this.txtRSSIAvg.Name = "txtRSSIAvg";
            this.txtRSSIAvg.Size = new System.Drawing.Size(100, 20);
            this.txtRSSIAvg.TabIndex = 5;
            // 
            // txtRSSINow
            // 
            this.txtRSSINow.Location = new System.Drawing.Point(144, 580);
            this.txtRSSINow.Name = "txtRSSINow";
            this.txtRSSINow.Size = new System.Drawing.Size(100, 20);
            this.txtRSSINow.TabIndex = 4;
            // 
            // cbxCurrentFreq
            // 
            this.cbxCurrentFreq.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxCurrentFreq.FormattingEnabled = true;
            this.cbxCurrentFreq.Location = new System.Drawing.Point(6, 579);
            this.cbxCurrentFreq.Name = "cbxCurrentFreq";
            this.cbxCurrentFreq.Size = new System.Drawing.Size(121, 21);
            this.cbxCurrentFreq.TabIndex = 3;
            // 
            // btnRFDiagnosisCtrl
            // 
            this.btnRFDiagnosisCtrl.Location = new System.Drawing.Point(904, 592);
            this.btnRFDiagnosisCtrl.Name = "btnRFDiagnosisCtrl";
            this.btnRFDiagnosisCtrl.Size = new System.Drawing.Size(75, 23);
            this.btnRFDiagnosisCtrl.TabIndex = 1;
            this.btnRFDiagnosisCtrl.Tag = "0";
            this.btnRFDiagnosisCtrl.Text = "Start";
            this.btnRFDiagnosisCtrl.UseVisualStyleBackColor = true;
            this.btnRFDiagnosisCtrl.Click += new System.EventHandler(this.btnRFDiagnosisCtrl_Click);
            // 
            // zedGraphControl1
            // 
            this.zedGraphControl1.Location = new System.Drawing.Point(6, 6);
            this.zedGraphControl1.Name = "zedGraphControl1";
            this.zedGraphControl1.ScrollGrace = 0D;
            this.zedGraphControl1.ScrollMaxX = 0D;
            this.zedGraphControl1.ScrollMaxY = 0D;
            this.zedGraphControl1.ScrollMaxY2 = 0D;
            this.zedGraphControl1.ScrollMinX = 0D;
            this.zedGraphControl1.ScrollMinY = 0D;
            this.zedGraphControl1.ScrollMinY2 = 0D;
            this.zedGraphControl1.Size = new System.Drawing.Size(973, 552);
            this.zedGraphControl1.TabIndex = 0;
            // 
            // tabPage6
            // 
            this.tabPage6.Controls.Add(this.chkIDReverse);
            this.tabPage6.Controls.Add(this.btnDeviceSearch);
            this.tabPage6.Controls.Add(this.dgDeviceList);
            this.tabPage6.Location = new System.Drawing.Point(4, 22);
            this.tabPage6.Name = "tabPage6";
            this.tabPage6.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage6.Size = new System.Drawing.Size(985, 621);
            this.tabPage6.TabIndex = 5;
            this.tabPage6.Text = "TCP device search";
            this.tabPage6.UseVisualStyleBackColor = true;
            // 
            // chkIDReverse
            // 
            this.chkIDReverse.AutoSize = true;
            this.chkIDReverse.Location = new System.Drawing.Point(856, 11);
            this.chkIDReverse.Name = "chkIDReverse";
            this.chkIDReverse.Size = new System.Drawing.Size(15, 14);
            this.chkIDReverse.TabIndex = 2;
            this.chkIDReverse.UseVisualStyleBackColor = true;
            // 
            // btnDeviceSearch
            // 
            this.btnDeviceSearch.Location = new System.Drawing.Point(887, 6);
            this.btnDeviceSearch.Name = "btnDeviceSearch";
            this.btnDeviceSearch.Size = new System.Drawing.Size(75, 23);
            this.btnDeviceSearch.TabIndex = 1;
            this.btnDeviceSearch.Text = "Search";
            this.btnDeviceSearch.UseVisualStyleBackColor = true;
            this.btnDeviceSearch.Click += new System.EventHandler(this.btnDeviceSearch_Click);
            // 
            // dgDeviceList
            // 
            this.dgDeviceList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgDeviceList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.col_1,
            this.col_2,
            this.col_3,
            this.col_4,
            this.col_5,
            this.col_6,
            this.col_7});
            this.dgDeviceList.Location = new System.Drawing.Point(6, 6);
            this.dgDeviceList.Name = "dgDeviceList";
            this.dgDeviceList.ReadOnly = true;
            this.dgDeviceList.RowHeadersVisible = false;
            this.dgDeviceList.Size = new System.Drawing.Size(844, 609);
            this.dgDeviceList.TabIndex = 0;
            // 
            // col_1
            // 
            this.col_1.HeaderText = "Sr. No.";
            this.col_1.Name = "col_1";
            this.col_1.ReadOnly = true;
            this.col_1.Width = 65;
            // 
            // col_2
            // 
            this.col_2.HeaderText = "Serial number";
            this.col_2.Name = "col_2";
            this.col_2.ReadOnly = true;
            this.col_2.Width = 130;
            // 
            // col_3
            // 
            this.col_3.HeaderText = "MAC Address";
            this.col_3.Name = "col_3";
            this.col_3.ReadOnly = true;
            this.col_3.Width = 130;
            // 
            // col_4
            // 
            this.col_4.HeaderText = "Device IP";
            this.col_4.Name = "col_4";
            this.col_4.ReadOnly = true;
            this.col_4.Width = 130;
            // 
            // col_5
            // 
            this.col_5.HeaderText = "Host IP";
            this.col_5.Name = "col_5";
            this.col_5.ReadOnly = true;
            this.col_5.Width = 130;
            // 
            // col_6
            // 
            this.col_6.HeaderText = "Device port";
            this.col_6.Name = "col_6";
            this.col_6.ReadOnly = true;
            this.col_6.Width = 130;
            // 
            // col_7
            // 
            this.col_7.HeaderText = "Host port";
            this.col_7.Name = "col_7";
            this.col_7.ReadOnly = true;
            this.col_7.Width = 130;
            // 
            // tabPage7
            // 
            this.tabPage7.Controls.Add(this.chkDeviceIDReverse1);
            this.tabPage7.Controls.Add(this.txtTimeDiff);
            this.tabPage7.Controls.Add(this.label57);
            this.tabPage7.Controls.Add(this.txtTagCount);
            this.tabPage7.Controls.Add(this.label58);
            this.tabPage7.Controls.Add(this.btnTcpServerClearList);
            this.tabPage7.Controls.Add(this.lvData);
            this.tabPage7.Controls.Add(this.btnTcpServerLogClear);
            this.tabPage7.Controls.Add(this.txtLog);
            this.tabPage7.Controls.Add(this.btnTcpServerStartStop);
            this.tabPage7.Controls.Add(this.label59);
            this.tabPage7.Controls.Add(this.txtPortTcpServer);
            this.tabPage7.Location = new System.Drawing.Point(4, 22);
            this.tabPage7.Name = "tabPage7";
            this.tabPage7.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage7.Size = new System.Drawing.Size(985, 621);
            this.tabPage7.TabIndex = 6;
            this.tabPage7.Text = "TCP Server";
            this.tabPage7.UseVisualStyleBackColor = true;
            // 
            // chkDeviceIDReverse1
            // 
            this.chkDeviceIDReverse1.AutoSize = true;
            this.chkDeviceIDReverse1.Location = new System.Drawing.Point(786, 192);
            this.chkDeviceIDReverse1.Name = "chkDeviceIDReverse1";
            this.chkDeviceIDReverse1.Size = new System.Drawing.Size(112, 17);
            this.chkDeviceIDReverse1.TabIndex = 2;
            this.chkDeviceIDReverse1.Text = "Device ID reverse";
            this.chkDeviceIDReverse1.UseVisualStyleBackColor = true;
            // 
            // txtTimeDiff
            // 
            this.txtTimeDiff.Location = new System.Drawing.Point(553, 190);
            this.txtTimeDiff.Name = "txtTimeDiff";
            this.txtTimeDiff.Size = new System.Drawing.Size(61, 20);
            this.txtTimeDiff.TabIndex = 20;
            this.txtTimeDiff.Text = "1000";
            // 
            // label57
            // 
            this.label57.AutoSize = true;
            this.label57.Location = new System.Drawing.Point(297, 193);
            this.label57.Name = "label57";
            this.label57.Size = new System.Drawing.Size(250, 13);
            this.label57.TabIndex = 19;
            this.label57.Text = "Allowed time difference between consecutive reads";
            // 
            // txtTagCount
            // 
            this.txtTagCount.Location = new System.Drawing.Point(117, 188);
            this.txtTagCount.Name = "txtTagCount";
            this.txtTagCount.ReadOnly = true;
            this.txtTagCount.Size = new System.Drawing.Size(61, 20);
            this.txtTagCount.TabIndex = 18;
            this.txtTagCount.Text = "0";
            // 
            // label58
            // 
            this.label58.AutoSize = true;
            this.label58.Location = new System.Drawing.Point(6, 193);
            this.label58.Name = "label58";
            this.label58.Size = new System.Drawing.Size(105, 13);
            this.label58.TabIndex = 17;
            this.label58.Text = "Total Tags Detected";
            // 
            // btnTcpServerClearList
            // 
            this.btnTcpServerClearList.Location = new System.Drawing.Point(904, 188);
            this.btnTcpServerClearList.Name = "btnTcpServerClearList";
            this.btnTcpServerClearList.Size = new System.Drawing.Size(75, 23);
            this.btnTcpServerClearList.TabIndex = 16;
            this.btnTcpServerClearList.Text = "Clear";
            this.btnTcpServerClearList.UseVisualStyleBackColor = true;
            this.btnTcpServerClearList.Click += new System.EventHandler(this.btnTcpServerClearList_Click);
            // 
            // lvData
            // 
            this.lvData.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.lvData.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.DevID,
            this.EPC,
            this.ReadCnt,
            this.TimeStamp,
            this.TimeStampLogged,
            this.IsActiveID});
            this.lvData.ForeColor = System.Drawing.SystemColors.WindowText;
            this.lvData.FullRowSelect = true;
            this.lvData.GridLines = true;
            this.lvData.HideSelection = false;
            this.lvData.Location = new System.Drawing.Point(6, 217);
            this.lvData.Name = "lvData";
            this.lvData.Size = new System.Drawing.Size(973, 398);
            this.lvData.TabIndex = 15;
            this.lvData.UseCompatibleStateImageBehavior = false;
            this.lvData.View = System.Windows.Forms.View.Details;
            // 
            // DevID
            // 
            this.DevID.Text = "Device ID";
            this.DevID.Width = 70;
            // 
            // EPC
            // 
            this.EPC.Text = "EPC";
            this.EPC.Width = 250;
            // 
            // ReadCnt
            // 
            this.ReadCnt.Text = "Read count";
            this.ReadCnt.Width = 100;
            // 
            // TimeStamp
            // 
            this.TimeStamp.Text = "Time stamp";
            this.TimeStamp.Width = 90;
            // 
            // TimeStampLogged
            // 
            this.TimeStampLogged.Text = "Time stamp (Logged)";
            this.TimeStampLogged.Width = 115;
            // 
            // IsActiveID
            // 
            this.IsActiveID.Text = "ID Type";
            // 
            // btnTcpServerLogClear
            // 
            this.btnTcpServerLogClear.Location = new System.Drawing.Point(904, 6);
            this.btnTcpServerLogClear.Name = "btnTcpServerLogClear";
            this.btnTcpServerLogClear.Size = new System.Drawing.Size(75, 23);
            this.btnTcpServerLogClear.TabIndex = 14;
            this.btnTcpServerLogClear.Text = "Clear";
            this.btnTcpServerLogClear.UseVisualStyleBackColor = true;
            this.btnTcpServerLogClear.Click += new System.EventHandler(this.btnTcpServerLogClear_Click);
            // 
            // txtLog
            // 
            this.txtLog.Location = new System.Drawing.Point(6, 40);
            this.txtLog.Multiline = true;
            this.txtLog.Name = "txtLog";
            this.txtLog.ReadOnly = true;
            this.txtLog.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtLog.Size = new System.Drawing.Size(973, 141);
            this.txtLog.TabIndex = 10;
            this.txtLog.WordWrap = false;
            // 
            // btnTcpServerStartStop
            // 
            this.btnTcpServerStartStop.Location = new System.Drawing.Point(129, 7);
            this.btnTcpServerStartStop.Name = "btnTcpServerStartStop";
            this.btnTcpServerStartStop.Size = new System.Drawing.Size(75, 23);
            this.btnTcpServerStartStop.TabIndex = 13;
            this.btnTcpServerStartStop.Tag = "0";
            this.btnTcpServerStartStop.Text = "Start";
            this.btnTcpServerStartStop.UseVisualStyleBackColor = true;
            this.btnTcpServerStartStop.Click += new System.EventHandler(this.btnTcpServerStartStop_Click);
            // 
            // label59
            // 
            this.label59.AutoSize = true;
            this.label59.Location = new System.Drawing.Point(6, 12);
            this.label59.Name = "label59";
            this.label59.Size = new System.Drawing.Size(57, 13);
            this.label59.TabIndex = 12;
            this.label59.Text = "Listen Port";
            // 
            // txtPortTcpServer
            // 
            this.txtPortTcpServer.Location = new System.Drawing.Point(69, 9);
            this.txtPortTcpServer.Name = "txtPortTcpServer";
            this.txtPortTcpServer.Size = new System.Drawing.Size(54, 20);
            this.txtPortTcpServer.TabIndex = 11;
            this.txtPortTcpServer.Text = "9000";
            // 
            // tabPage9
            // 
            this.tabPage9.Controls.Add(this.groupBox24);
            this.tabPage9.Controls.Add(this.groupBox43);
            this.tabPage9.Controls.Add(this.groupBox42);
            this.tabPage9.Controls.Add(this.groupBox40);
            this.tabPage9.Controls.Add(this.groupBox39);
            this.tabPage9.Controls.Add(this.groupBox38);
            this.tabPage9.Location = new System.Drawing.Point(4, 22);
            this.tabPage9.Name = "tabPage9";
            this.tabPage9.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage9.Size = new System.Drawing.Size(985, 621);
            this.tabPage9.TabIndex = 9;
            this.tabPage9.Text = "Fault Diagnosis";
            this.tabPage9.UseVisualStyleBackColor = true;
            // 
            // groupBox24
            // 
            this.groupBox24.Controls.Add(this.lblDiagFrameVersion);
            this.groupBox24.Controls.Add(this.label87);
            this.groupBox24.Location = new System.Drawing.Point(6, 6);
            this.groupBox24.Name = "groupBox24";
            this.groupBox24.Size = new System.Drawing.Size(200, 42);
            this.groupBox24.TabIndex = 5;
            this.groupBox24.TabStop = false;
            // 
            // lblDiagFrameVersion
            // 
            this.lblDiagFrameVersion.AutoSize = true;
            this.lblDiagFrameVersion.Location = new System.Drawing.Point(134, 18);
            this.lblDiagFrameVersion.Name = "lblDiagFrameVersion";
            this.lblDiagFrameVersion.Size = new System.Drawing.Size(0, 13);
            this.lblDiagFrameVersion.TabIndex = 6;
            // 
            // label87
            // 
            this.label87.AutoSize = true;
            this.label87.Location = new System.Drawing.Point(6, 16);
            this.label87.Name = "label87";
            this.label87.Size = new System.Drawing.Size(122, 13);
            this.label87.TabIndex = 6;
            this.label87.Text = "Diagnosis frame version:";
            // 
            // groupBox43
            // 
            this.groupBox43.Controls.Add(this.btnDiagResetAllCnt);
            this.groupBox43.Controls.Add(this.btnDiagScan);
            this.groupBox43.Controls.Add(this.label119);
            this.groupBox43.Controls.Add(this.txtScanFrequency);
            this.groupBox43.Location = new System.Drawing.Point(6, 54);
            this.groupBox43.Name = "groupBox43";
            this.groupBox43.Size = new System.Drawing.Size(200, 111);
            this.groupBox43.TabIndex = 4;
            this.groupBox43.TabStop = false;
            this.groupBox43.Text = "Control";
            // 
            // btnDiagResetAllCnt
            // 
            this.btnDiagResetAllCnt.Location = new System.Drawing.Point(9, 76);
            this.btnDiagResetAllCnt.Name = "btnDiagResetAllCnt";
            this.btnDiagResetAllCnt.Size = new System.Drawing.Size(185, 23);
            this.btnDiagResetAllCnt.TabIndex = 5;
            this.btnDiagResetAllCnt.Text = "Reset event counters";
            this.btnDiagResetAllCnt.UseVisualStyleBackColor = true;
            this.btnDiagResetAllCnt.Click += new System.EventHandler(this.btnDiagResetAllCnt_Click);
            // 
            // btnDiagScan
            // 
            this.btnDiagScan.Location = new System.Drawing.Point(9, 47);
            this.btnDiagScan.Name = "btnDiagScan";
            this.btnDiagScan.Size = new System.Drawing.Size(185, 23);
            this.btnDiagScan.TabIndex = 5;
            this.btnDiagScan.Tag = "0";
            this.btnDiagScan.Text = "Start";
            this.btnDiagScan.UseVisualStyleBackColor = true;
            this.btnDiagScan.Click += new System.EventHandler(this.btnDiagScan_Click);
            // 
            // label119
            // 
            this.label119.AutoSize = true;
            this.label119.Location = new System.Drawing.Point(6, 20);
            this.label119.Name = "label119";
            this.label119.Size = new System.Drawing.Size(78, 13);
            this.label119.TabIndex = 5;
            this.label119.Text = "Scan rate (ms):";
            // 
            // txtScanFrequency
            // 
            this.txtScanFrequency.Location = new System.Drawing.Point(94, 18);
            this.txtScanFrequency.Name = "txtScanFrequency";
            this.txtScanFrequency.Size = new System.Drawing.Size(100, 20);
            this.txtScanFrequency.TabIndex = 5;
            this.txtScanFrequency.Text = "1000";
            // 
            // groupBox42
            // 
            this.groupBox42.Controls.Add(this.label133);
            this.groupBox42.Controls.Add(this.txtGlobalCallbackCount);
            this.groupBox42.Controls.Add(this.label122);
            this.groupBox42.Controls.Add(this.label117);
            this.groupBox42.Controls.Add(this.txtActiveSocketCounts);
            this.groupBox42.Controls.Add(this.label118);
            this.groupBox42.Controls.Add(this.txtPHY_NokPacketCounts);
            this.groupBox42.Controls.Add(this.txtPHY_OkPacketCounts);
            this.groupBox42.Controls.Add(this.txtPHYLinkStateDuration);
            this.groupBox42.Controls.Add(this.label116);
            this.groupBox42.Controls.Add(this.txtPHYLinkState);
            this.groupBox42.Controls.Add(this.label115);
            this.groupBox42.Location = new System.Drawing.Point(6, 171);
            this.groupBox42.Name = "groupBox42";
            this.groupBox42.Size = new System.Drawing.Size(200, 186);
            this.groupBox42.TabIndex = 3;
            this.groupBox42.TabStop = false;
            this.groupBox42.Text = "Ethernet PHY Status";
            // 
            // label133
            // 
            this.label133.AutoSize = true;
            this.label133.Location = new System.Drawing.Point(6, 160);
            this.label133.Name = "label133";
            this.label133.Size = new System.Drawing.Size(86, 13);
            this.label133.TabIndex = 26;
            this.label133.Text = "Callback counts:";
            // 
            // txtGlobalCallbackCount
            // 
            this.txtGlobalCallbackCount.Location = new System.Drawing.Point(94, 157);
            this.txtGlobalCallbackCount.Name = "txtGlobalCallbackCount";
            this.txtGlobalCallbackCount.ReadOnly = true;
            this.txtGlobalCallbackCount.Size = new System.Drawing.Size(100, 20);
            this.txtGlobalCallbackCount.TabIndex = 25;
            // 
            // label122
            // 
            this.label122.AutoSize = true;
            this.label122.Location = new System.Drawing.Point(6, 134);
            this.label122.Name = "label122";
            this.label122.Size = new System.Drawing.Size(79, 13);
            this.label122.TabIndex = 24;
            this.label122.Text = "Socket counts:";
            // 
            // label117
            // 
            this.label117.AutoSize = true;
            this.label117.Location = new System.Drawing.Point(6, 108);
            this.label117.Name = "label117";
            this.label117.Size = new System.Drawing.Size(68, 13);
            this.label117.TabIndex = 22;
            this.label117.Text = "NOK counts:";
            // 
            // txtActiveSocketCounts
            // 
            this.txtActiveSocketCounts.Location = new System.Drawing.Point(94, 131);
            this.txtActiveSocketCounts.Name = "txtActiveSocketCounts";
            this.txtActiveSocketCounts.ReadOnly = true;
            this.txtActiveSocketCounts.Size = new System.Drawing.Size(100, 20);
            this.txtActiveSocketCounts.TabIndex = 23;
            // 
            // label118
            // 
            this.label118.AutoSize = true;
            this.label118.Location = new System.Drawing.Point(6, 82);
            this.label118.Name = "label118";
            this.label118.Size = new System.Drawing.Size(60, 13);
            this.label118.TabIndex = 21;
            this.label118.Text = "OK counts:";
            // 
            // txtPHY_NokPacketCounts
            // 
            this.txtPHY_NokPacketCounts.Location = new System.Drawing.Point(94, 105);
            this.txtPHY_NokPacketCounts.Name = "txtPHY_NokPacketCounts";
            this.txtPHY_NokPacketCounts.ReadOnly = true;
            this.txtPHY_NokPacketCounts.Size = new System.Drawing.Size(100, 20);
            this.txtPHY_NokPacketCounts.TabIndex = 20;
            // 
            // txtPHY_OkPacketCounts
            // 
            this.txtPHY_OkPacketCounts.Location = new System.Drawing.Point(94, 79);
            this.txtPHY_OkPacketCounts.Name = "txtPHY_OkPacketCounts";
            this.txtPHY_OkPacketCounts.ReadOnly = true;
            this.txtPHY_OkPacketCounts.Size = new System.Drawing.Size(100, 20);
            this.txtPHY_OkPacketCounts.TabIndex = 19;
            // 
            // txtPHYLinkStateDuration
            // 
            this.txtPHYLinkStateDuration.Location = new System.Drawing.Point(94, 51);
            this.txtPHYLinkStateDuration.Name = "txtPHYLinkStateDuration";
            this.txtPHYLinkStateDuration.ReadOnly = true;
            this.txtPHYLinkStateDuration.Size = new System.Drawing.Size(100, 20);
            this.txtPHYLinkStateDuration.TabIndex = 17;
            // 
            // label116
            // 
            this.label116.AutoSize = true;
            this.label116.Location = new System.Drawing.Point(6, 54);
            this.label116.Name = "label116";
            this.label116.Size = new System.Drawing.Size(72, 13);
            this.label116.TabIndex = 18;
            this.label116.Text = "Duration (ms):";
            // 
            // txtPHYLinkState
            // 
            this.txtPHYLinkState.Location = new System.Drawing.Point(94, 25);
            this.txtPHYLinkState.Name = "txtPHYLinkState";
            this.txtPHYLinkState.ReadOnly = true;
            this.txtPHYLinkState.Size = new System.Drawing.Size(100, 20);
            this.txtPHYLinkState.TabIndex = 16;
            // 
            // label115
            // 
            this.label115.AutoSize = true;
            this.label115.Location = new System.Drawing.Point(6, 28);
            this.label115.Name = "label115";
            this.label115.Size = new System.Drawing.Size(58, 13);
            this.label115.TabIndex = 16;
            this.label115.Text = "Link State:";
            // 
            // groupBox40
            // 
            this.groupBox40.Controls.Add(this.label41);
            this.groupBox40.Controls.Add(this.txtTIDScanTimeMsec);
            this.groupBox40.Controls.Add(this.groupBox41);
            this.groupBox40.Controls.Add(this.label114);
            this.groupBox40.Controls.Add(this.label113);
            this.groupBox40.Controls.Add(this.txtRFErrorCount);
            this.groupBox40.Controls.Add(this.txtRFErrorCode);
            this.groupBox40.Controls.Add(this.label112);
            this.groupBox40.Controls.Add(this.label111);
            this.groupBox40.Controls.Add(this.label110);
            this.groupBox40.Controls.Add(this.txtLastCmdExecDuration);
            this.groupBox40.Controls.Add(this.txtLastCmdErrorCode);
            this.groupBox40.Controls.Add(this.txtLastCmdCode);
            this.groupBox40.Controls.Add(this.label109);
            this.groupBox40.Controls.Add(this.txtDeviceDuration);
            this.groupBox40.Location = new System.Drawing.Point(724, 6);
            this.groupBox40.Name = "groupBox40";
            this.groupBox40.Size = new System.Drawing.Size(252, 272);
            this.groupBox40.TabIndex = 2;
            this.groupBox40.TabStop = false;
            this.groupBox40.Text = "Miscellaneous";
            // 
            // label41
            // 
            this.label41.AutoSize = true;
            this.label41.Location = new System.Drawing.Point(6, 176);
            this.label41.Name = "label41";
            this.label41.Size = new System.Drawing.Size(100, 13);
            this.label41.TabIndex = 46;
            this.label41.Text = "TID Scan time (ms):";
            // 
            // txtTIDScanTimeMsec
            // 
            this.txtTIDScanTimeMsec.Location = new System.Drawing.Point(146, 173);
            this.txtTIDScanTimeMsec.Name = "txtTIDScanTimeMsec";
            this.txtTIDScanTimeMsec.ReadOnly = true;
            this.txtTIDScanTimeMsec.Size = new System.Drawing.Size(100, 20);
            this.txtTIDScanTimeMsec.TabIndex = 45;
            // 
            // groupBox41
            // 
            this.groupBox41.Controls.Add(this.chkPHYHardFault);
            this.groupBox41.Controls.Add(this.chkEEPFault);
            this.groupBox41.Controls.Add(this.chkRFHardFault);
            this.groupBox41.Location = new System.Drawing.Point(0, 199);
            this.groupBox41.Name = "groupBox41";
            this.groupBox41.Size = new System.Drawing.Size(252, 74);
            this.groupBox41.TabIndex = 3;
            this.groupBox41.TabStop = false;
            this.groupBox41.Text = "Fault flags";
            // 
            // chkPHYHardFault
            // 
            this.chkPHYHardFault.AutoSize = true;
            this.chkPHYHardFault.Enabled = false;
            this.chkPHYHardFault.Location = new System.Drawing.Point(9, 52);
            this.chkPHYHardFault.Name = "chkPHYHardFault";
            this.chkPHYHardFault.Size = new System.Drawing.Size(97, 17);
            this.chkPHYHardFault.TabIndex = 2;
            this.chkPHYHardFault.Text = "PHY Hard fault";
            this.chkPHYHardFault.UseVisualStyleBackColor = true;
            // 
            // chkEEPFault
            // 
            this.chkEEPFault.AutoSize = true;
            this.chkEEPFault.Enabled = false;
            this.chkEEPFault.Location = new System.Drawing.Point(104, 26);
            this.chkEEPFault.Name = "chkEEPFault";
            this.chkEEPFault.Size = new System.Drawing.Size(73, 17);
            this.chkEEPFault.TabIndex = 1;
            this.chkEEPFault.Text = "EEP Fault";
            this.chkEEPFault.UseVisualStyleBackColor = true;
            // 
            // chkRFHardFault
            // 
            this.chkRFHardFault.AutoSize = true;
            this.chkRFHardFault.Enabled = false;
            this.chkRFHardFault.Location = new System.Drawing.Point(9, 26);
            this.chkRFHardFault.Name = "chkRFHardFault";
            this.chkRFHardFault.Size = new System.Drawing.Size(89, 17);
            this.chkRFHardFault.TabIndex = 0;
            this.chkRFHardFault.Text = "RF Hard fault";
            this.chkRFHardFault.UseVisualStyleBackColor = true;
            // 
            // label114
            // 
            this.label114.AutoSize = true;
            this.label114.Location = new System.Drawing.Point(6, 150);
            this.label114.Name = "label114";
            this.label114.Size = new System.Drawing.Size(101, 13);
            this.label114.TabIndex = 44;
            this.label114.Text = "Last RF error count:";
            // 
            // label113
            // 
            this.label113.AutoSize = true;
            this.label113.Location = new System.Drawing.Point(6, 124);
            this.label113.Name = "label113";
            this.label113.Size = new System.Drawing.Size(98, 13);
            this.label113.TabIndex = 43;
            this.label113.Text = "Last RF error code:";
            // 
            // txtRFErrorCount
            // 
            this.txtRFErrorCount.Location = new System.Drawing.Point(146, 147);
            this.txtRFErrorCount.Name = "txtRFErrorCount";
            this.txtRFErrorCount.ReadOnly = true;
            this.txtRFErrorCount.Size = new System.Drawing.Size(100, 20);
            this.txtRFErrorCount.TabIndex = 42;
            // 
            // txtRFErrorCode
            // 
            this.txtRFErrorCode.Location = new System.Drawing.Point(146, 121);
            this.txtRFErrorCode.Name = "txtRFErrorCode";
            this.txtRFErrorCode.ReadOnly = true;
            this.txtRFErrorCode.Size = new System.Drawing.Size(100, 20);
            this.txtRFErrorCode.TabIndex = 41;
            // 
            // label112
            // 
            this.label112.AutoSize = true;
            this.label112.Location = new System.Drawing.Point(6, 98);
            this.label112.Name = "label112";
            this.label112.Size = new System.Drawing.Size(130, 13);
            this.label112.TabIndex = 40;
            this.label112.Text = "Last CMD exec. time (ms):";
            // 
            // label111
            // 
            this.label111.AutoSize = true;
            this.label111.Location = new System.Drawing.Point(6, 72);
            this.label111.Name = "label111";
            this.label111.Size = new System.Drawing.Size(110, 13);
            this.label111.TabIndex = 39;
            this.label111.Text = "Last command status:";
            // 
            // label110
            // 
            this.label110.AutoSize = true;
            this.label110.Location = new System.Drawing.Point(6, 46);
            this.label110.Name = "label110";
            this.label110.Size = new System.Drawing.Size(106, 13);
            this.label110.TabIndex = 38;
            this.label110.Text = "Last command code:";
            // 
            // txtLastCmdExecDuration
            // 
            this.txtLastCmdExecDuration.Location = new System.Drawing.Point(146, 95);
            this.txtLastCmdExecDuration.Name = "txtLastCmdExecDuration";
            this.txtLastCmdExecDuration.ReadOnly = true;
            this.txtLastCmdExecDuration.Size = new System.Drawing.Size(100, 20);
            this.txtLastCmdExecDuration.TabIndex = 37;
            // 
            // txtLastCmdErrorCode
            // 
            this.txtLastCmdErrorCode.Location = new System.Drawing.Point(146, 69);
            this.txtLastCmdErrorCode.Name = "txtLastCmdErrorCode";
            this.txtLastCmdErrorCode.ReadOnly = true;
            this.txtLastCmdErrorCode.Size = new System.Drawing.Size(100, 20);
            this.txtLastCmdErrorCode.TabIndex = 36;
            // 
            // txtLastCmdCode
            // 
            this.txtLastCmdCode.Location = new System.Drawing.Point(146, 43);
            this.txtLastCmdCode.Name = "txtLastCmdCode";
            this.txtLastCmdCode.ReadOnly = true;
            this.txtLastCmdCode.Size = new System.Drawing.Size(100, 20);
            this.txtLastCmdCode.TabIndex = 35;
            // 
            // label109
            // 
            this.label109.AutoSize = true;
            this.label109.Location = new System.Drawing.Point(6, 20);
            this.label109.Name = "label109";
            this.label109.Size = new System.Drawing.Size(125, 13);
            this.label109.TabIndex = 34;
            this.label109.Text = "Device run duration (ms):";
            // 
            // txtDeviceDuration
            // 
            this.txtDeviceDuration.Location = new System.Drawing.Point(146, 17);
            this.txtDeviceDuration.Name = "txtDeviceDuration";
            this.txtDeviceDuration.ReadOnly = true;
            this.txtDeviceDuration.Size = new System.Drawing.Size(100, 20);
            this.txtDeviceDuration.TabIndex = 0;
            // 
            // groupBox39
            // 
            this.groupBox39.Controls.Add(this.label132);
            this.groupBox39.Controls.Add(this.label130);
            this.groupBox39.Controls.Add(this.txtClientAppCallCount);
            this.groupBox39.Controls.Add(this.txtClientUStateCount);
            this.groupBox39.Controls.Add(this.label129);
            this.groupBox39.Controls.Add(this.txtClientUnknownState);
            this.groupBox39.Controls.Add(this.label125);
            this.groupBox39.Controls.Add(this.txtCPort);
            this.groupBox39.Controls.Add(this.label126);
            this.groupBox39.Controls.Add(this.txtRPort);
            this.groupBox39.Controls.Add(this.label121);
            this.groupBox39.Controls.Add(this.txtMemFailEventCounts);
            this.groupBox39.Controls.Add(this.label120);
            this.groupBox39.Controls.Add(this.label100);
            this.groupBox39.Controls.Add(this.txtClientResetEcentCount);
            this.groupBox39.Controls.Add(this.label101);
            this.groupBox39.Controls.Add(this.label102);
            this.groupBox39.Controls.Add(this.label103);
            this.groupBox39.Controls.Add(this.label104);
            this.groupBox39.Controls.Add(this.label105);
            this.groupBox39.Controls.Add(this.label106);
            this.groupBox39.Controls.Add(this.txtClientTimedoutCount);
            this.groupBox39.Controls.Add(this.txtClientStateDuration);
            this.groupBox39.Controls.Add(this.txtClientClosedCount);
            this.groupBox39.Controls.Add(this.label107);
            this.groupBox39.Controls.Add(this.txtClientAbortedCount);
            this.groupBox39.Controls.Add(this.txtClientDataACKCount);
            this.groupBox39.Controls.Add(this.txtClientState);
            this.groupBox39.Controls.Add(this.txtClientDataTxCount);
            this.groupBox39.Controls.Add(this.label108);
            this.groupBox39.Controls.Add(this.txtClientDataRxCount);
            this.groupBox39.Controls.Add(this.txtClientConnectCount);
            this.groupBox39.Location = new System.Drawing.Point(466, 6);
            this.groupBox39.Name = "groupBox39";
            this.groupBox39.Size = new System.Drawing.Size(252, 437);
            this.groupBox39.TabIndex = 1;
            this.groupBox39.TabStop = false;
            this.groupBox39.Text = "Internal TCP client stastics";
            // 
            // label132
            // 
            this.label132.AutoSize = true;
            this.label132.Location = new System.Drawing.Point(5, 411);
            this.label132.Name = "label132";
            this.label132.Size = new System.Drawing.Size(86, 13);
            this.label132.TabIndex = 47;
            this.label132.Text = "Callback counts:";
            // 
            // label130
            // 
            this.label130.AutoSize = true;
            this.label130.Location = new System.Drawing.Point(5, 385);
            this.label130.Name = "label130";
            this.label130.Size = new System.Drawing.Size(126, 13);
            this.label130.TabIndex = 45;
            this.label130.Text = "Misc. state event counts:";
            // 
            // txtClientAppCallCount
            // 
            this.txtClientAppCallCount.Location = new System.Drawing.Point(146, 408);
            this.txtClientAppCallCount.Name = "txtClientAppCallCount";
            this.txtClientAppCallCount.ReadOnly = true;
            this.txtClientAppCallCount.Size = new System.Drawing.Size(100, 20);
            this.txtClientAppCallCount.TabIndex = 46;
            // 
            // txtClientUStateCount
            // 
            this.txtClientUStateCount.Location = new System.Drawing.Point(146, 382);
            this.txtClientUStateCount.Name = "txtClientUStateCount";
            this.txtClientUStateCount.ReadOnly = true;
            this.txtClientUStateCount.Size = new System.Drawing.Size(100, 20);
            this.txtClientUStateCount.TabIndex = 44;
            // 
            // label129
            // 
            this.label129.AutoSize = true;
            this.label129.Location = new System.Drawing.Point(5, 359);
            this.label129.Name = "label129";
            this.label129.Size = new System.Drawing.Size(77, 13);
            this.label129.TabIndex = 43;
            this.label129.Text = "Misc. State ID:";
            // 
            // txtClientUnknownState
            // 
            this.txtClientUnknownState.Location = new System.Drawing.Point(146, 356);
            this.txtClientUnknownState.Name = "txtClientUnknownState";
            this.txtClientUnknownState.ReadOnly = true;
            this.txtClientUnknownState.Size = new System.Drawing.Size(100, 20);
            this.txtClientUnknownState.TabIndex = 42;
            // 
            // label125
            // 
            this.label125.AutoSize = true;
            this.label125.Location = new System.Drawing.Point(6, 333);
            this.label125.Name = "label125";
            this.label125.Size = new System.Drawing.Size(53, 13);
            this.label125.TabIndex = 41;
            this.label125.Text = "Host port:";
            // 
            // txtCPort
            // 
            this.txtCPort.Location = new System.Drawing.Point(147, 330);
            this.txtCPort.Name = "txtCPort";
            this.txtCPort.ReadOnly = true;
            this.txtCPort.Size = new System.Drawing.Size(100, 20);
            this.txtCPort.TabIndex = 40;
            // 
            // label126
            // 
            this.label126.AutoSize = true;
            this.label126.Location = new System.Drawing.Point(5, 307);
            this.label126.Name = "label126";
            this.label126.Size = new System.Drawing.Size(65, 13);
            this.label126.TabIndex = 39;
            this.label126.Text = "Device port:";
            // 
            // txtRPort
            // 
            this.txtRPort.Location = new System.Drawing.Point(147, 304);
            this.txtRPort.Name = "txtRPort";
            this.txtRPort.ReadOnly = true;
            this.txtRPort.Size = new System.Drawing.Size(100, 20);
            this.txtRPort.TabIndex = 38;
            // 
            // label121
            // 
            this.label121.AutoSize = true;
            this.label121.Location = new System.Drawing.Point(6, 281);
            this.label121.Name = "label121";
            this.label121.Size = new System.Drawing.Size(117, 13);
            this.label121.TabIndex = 37;
            this.label121.Text = "Mem. fail event counts:";
            // 
            // txtMemFailEventCounts
            // 
            this.txtMemFailEventCounts.Location = new System.Drawing.Point(147, 278);
            this.txtMemFailEventCounts.Name = "txtMemFailEventCounts";
            this.txtMemFailEventCounts.ReadOnly = true;
            this.txtMemFailEventCounts.Size = new System.Drawing.Size(100, 20);
            this.txtMemFailEventCounts.TabIndex = 36;
            // 
            // label120
            // 
            this.label120.AutoSize = true;
            this.label120.Location = new System.Drawing.Point(5, 255);
            this.label120.Name = "label120";
            this.label120.Size = new System.Drawing.Size(129, 13);
            this.label120.TabIndex = 35;
            this.label120.Text = "Conn. reset event counts:";
            // 
            // label100
            // 
            this.label100.AutoSize = true;
            this.label100.Location = new System.Drawing.Point(6, 229);
            this.label100.Name = "label100";
            this.label100.Size = new System.Drawing.Size(140, 13);
            this.label100.TabIndex = 33;
            this.label100.Text = "Conn. timeout event counts:";
            // 
            // txtClientResetEcentCount
            // 
            this.txtClientResetEcentCount.Location = new System.Drawing.Point(147, 252);
            this.txtClientResetEcentCount.Name = "txtClientResetEcentCount";
            this.txtClientResetEcentCount.ReadOnly = true;
            this.txtClientResetEcentCount.Size = new System.Drawing.Size(100, 20);
            this.txtClientResetEcentCount.TabIndex = 34;
            // 
            // label101
            // 
            this.label101.AutoSize = true;
            this.label101.Location = new System.Drawing.Point(6, 203);
            this.label101.Name = "label101";
            this.label101.Size = new System.Drawing.Size(137, 13);
            this.label101.TabIndex = 32;
            this.label101.Text = "Conn. closed event counts:";
            // 
            // label102
            // 
            this.label102.AutoSize = true;
            this.label102.Location = new System.Drawing.Point(6, 177);
            this.label102.Name = "label102";
            this.label102.Size = new System.Drawing.Size(130, 13);
            this.label102.TabIndex = 31;
            this.label102.Text = "Conn. abort event counts:";
            // 
            // label103
            // 
            this.label103.AutoSize = true;
            this.label103.Location = new System.Drawing.Point(6, 151);
            this.label103.Name = "label103";
            this.label103.Size = new System.Drawing.Size(119, 13);
            this.label103.TabIndex = 30;
            this.label103.Text = "Data ack event counts:";
            // 
            // label104
            // 
            this.label104.AutoSize = true;
            this.label104.Location = new System.Drawing.Point(6, 125);
            this.label104.Name = "label104";
            this.label104.Size = new System.Drawing.Size(137, 13);
            this.label104.TabIndex = 29;
            this.label104.Text = "Data transmit event counts:";
            // 
            // label105
            // 
            this.label105.AutoSize = true;
            this.label105.Location = new System.Drawing.Point(6, 99);
            this.label105.Name = "label105";
            this.label105.Size = new System.Drawing.Size(136, 13);
            this.label105.TabIndex = 28;
            this.label105.Text = "Data receive event counts:";
            // 
            // label106
            // 
            this.label106.AutoSize = true;
            this.label106.Location = new System.Drawing.Point(6, 73);
            this.label106.Name = "label106";
            this.label106.Size = new System.Drawing.Size(127, 13);
            this.label106.TabIndex = 27;
            this.label106.Text = "Connected event counts:";
            // 
            // txtClientTimedoutCount
            // 
            this.txtClientTimedoutCount.Location = new System.Drawing.Point(147, 226);
            this.txtClientTimedoutCount.Name = "txtClientTimedoutCount";
            this.txtClientTimedoutCount.ReadOnly = true;
            this.txtClientTimedoutCount.Size = new System.Drawing.Size(100, 20);
            this.txtClientTimedoutCount.TabIndex = 26;
            // 
            // txtClientStateDuration
            // 
            this.txtClientStateDuration.Location = new System.Drawing.Point(147, 44);
            this.txtClientStateDuration.Name = "txtClientStateDuration";
            this.txtClientStateDuration.ReadOnly = true;
            this.txtClientStateDuration.Size = new System.Drawing.Size(100, 20);
            this.txtClientStateDuration.TabIndex = 16;
            // 
            // txtClientClosedCount
            // 
            this.txtClientClosedCount.Location = new System.Drawing.Point(147, 200);
            this.txtClientClosedCount.Name = "txtClientClosedCount";
            this.txtClientClosedCount.ReadOnly = true;
            this.txtClientClosedCount.Size = new System.Drawing.Size(100, 20);
            this.txtClientClosedCount.TabIndex = 25;
            // 
            // label107
            // 
            this.label107.AutoSize = true;
            this.label107.Location = new System.Drawing.Point(6, 47);
            this.label107.Name = "label107";
            this.label107.Size = new System.Drawing.Size(72, 13);
            this.label107.TabIndex = 19;
            this.label107.Text = "Duration (ms):";
            // 
            // txtClientAbortedCount
            // 
            this.txtClientAbortedCount.Location = new System.Drawing.Point(147, 174);
            this.txtClientAbortedCount.Name = "txtClientAbortedCount";
            this.txtClientAbortedCount.ReadOnly = true;
            this.txtClientAbortedCount.Size = new System.Drawing.Size(100, 20);
            this.txtClientAbortedCount.TabIndex = 24;
            // 
            // txtClientDataACKCount
            // 
            this.txtClientDataACKCount.Location = new System.Drawing.Point(147, 148);
            this.txtClientDataACKCount.Name = "txtClientDataACKCount";
            this.txtClientDataACKCount.ReadOnly = true;
            this.txtClientDataACKCount.Size = new System.Drawing.Size(100, 20);
            this.txtClientDataACKCount.TabIndex = 23;
            // 
            // txtClientState
            // 
            this.txtClientState.Location = new System.Drawing.Point(147, 18);
            this.txtClientState.Name = "txtClientState";
            this.txtClientState.ReadOnly = true;
            this.txtClientState.Size = new System.Drawing.Size(100, 20);
            this.txtClientState.TabIndex = 18;
            // 
            // txtClientDataTxCount
            // 
            this.txtClientDataTxCount.Location = new System.Drawing.Point(147, 122);
            this.txtClientDataTxCount.Name = "txtClientDataTxCount";
            this.txtClientDataTxCount.ReadOnly = true;
            this.txtClientDataTxCount.Size = new System.Drawing.Size(100, 20);
            this.txtClientDataTxCount.TabIndex = 22;
            // 
            // label108
            // 
            this.label108.AutoSize = true;
            this.label108.Location = new System.Drawing.Point(6, 21);
            this.label108.Name = "label108";
            this.label108.Size = new System.Drawing.Size(54, 13);
            this.label108.TabIndex = 17;
            this.label108.Text = "SM State:";
            // 
            // txtClientDataRxCount
            // 
            this.txtClientDataRxCount.Location = new System.Drawing.Point(147, 96);
            this.txtClientDataRxCount.Name = "txtClientDataRxCount";
            this.txtClientDataRxCount.ReadOnly = true;
            this.txtClientDataRxCount.Size = new System.Drawing.Size(100, 20);
            this.txtClientDataRxCount.TabIndex = 21;
            // 
            // txtClientConnectCount
            // 
            this.txtClientConnectCount.Location = new System.Drawing.Point(147, 70);
            this.txtClientConnectCount.Name = "txtClientConnectCount";
            this.txtClientConnectCount.ReadOnly = true;
            this.txtClientConnectCount.Size = new System.Drawing.Size(100, 20);
            this.txtClientConnectCount.TabIndex = 20;
            // 
            // groupBox38
            // 
            this.groupBox38.Controls.Add(this.label131);
            this.groupBox38.Controls.Add(this.txtServerAppCallCount);
            this.groupBox38.Controls.Add(this.label128);
            this.groupBox38.Controls.Add(this.txtServerUStateCount);
            this.groupBox38.Controls.Add(this.label127);
            this.groupBox38.Controls.Add(this.txtServerUnknownState);
            this.groupBox38.Controls.Add(this.label123);
            this.groupBox38.Controls.Add(this.label124);
            this.groupBox38.Controls.Add(this.txtSPort);
            this.groupBox38.Controls.Add(this.txtLPort);
            this.groupBox38.Controls.Add(this.label99);
            this.groupBox38.Controls.Add(this.label98);
            this.groupBox38.Controls.Add(this.label97);
            this.groupBox38.Controls.Add(this.label96);
            this.groupBox38.Controls.Add(this.label95);
            this.groupBox38.Controls.Add(this.label94);
            this.groupBox38.Controls.Add(this.label93);
            this.groupBox38.Controls.Add(this.txtServerTimedoutCount);
            this.groupBox38.Controls.Add(this.txtServerStateDuration);
            this.groupBox38.Controls.Add(this.txtServerClosedCount);
            this.groupBox38.Controls.Add(this.label92);
            this.groupBox38.Controls.Add(this.txtServerAbortedCount);
            this.groupBox38.Controls.Add(this.txtServerDataACKCount);
            this.groupBox38.Controls.Add(this.txtServerState);
            this.groupBox38.Controls.Add(this.txtServerDataTxCount);
            this.groupBox38.Controls.Add(this.label91);
            this.groupBox38.Controls.Add(this.txtServerDataRxCount);
            this.groupBox38.Controls.Add(this.txtServerConnectCount);
            this.groupBox38.Location = new System.Drawing.Point(208, 6);
            this.groupBox38.Name = "groupBox38";
            this.groupBox38.Size = new System.Drawing.Size(252, 384);
            this.groupBox38.TabIndex = 0;
            this.groupBox38.TabStop = false;
            this.groupBox38.Text = "Internal TCP server statistics";
            // 
            // label131
            // 
            this.label131.AutoSize = true;
            this.label131.Location = new System.Drawing.Point(5, 359);
            this.label131.Name = "label131";
            this.label131.Size = new System.Drawing.Size(86, 13);
            this.label131.TabIndex = 25;
            this.label131.Text = "Callback counts:";
            // 
            // txtServerAppCallCount
            // 
            this.txtServerAppCallCount.Location = new System.Drawing.Point(146, 356);
            this.txtServerAppCallCount.Name = "txtServerAppCallCount";
            this.txtServerAppCallCount.ReadOnly = true;
            this.txtServerAppCallCount.Size = new System.Drawing.Size(100, 20);
            this.txtServerAppCallCount.TabIndex = 24;
            // 
            // label128
            // 
            this.label128.AutoSize = true;
            this.label128.Location = new System.Drawing.Point(5, 333);
            this.label128.Name = "label128";
            this.label128.Size = new System.Drawing.Size(126, 13);
            this.label128.TabIndex = 23;
            this.label128.Text = "Misc. state event counts:";
            // 
            // txtServerUStateCount
            // 
            this.txtServerUStateCount.Location = new System.Drawing.Point(146, 330);
            this.txtServerUStateCount.Name = "txtServerUStateCount";
            this.txtServerUStateCount.ReadOnly = true;
            this.txtServerUStateCount.Size = new System.Drawing.Size(100, 20);
            this.txtServerUStateCount.TabIndex = 22;
            // 
            // label127
            // 
            this.label127.AutoSize = true;
            this.label127.Location = new System.Drawing.Point(5, 307);
            this.label127.Name = "label127";
            this.label127.Size = new System.Drawing.Size(77, 13);
            this.label127.TabIndex = 21;
            this.label127.Text = "Misc. State ID:";
            // 
            // txtServerUnknownState
            // 
            this.txtServerUnknownState.Location = new System.Drawing.Point(146, 304);
            this.txtServerUnknownState.Name = "txtServerUnknownState";
            this.txtServerUnknownState.ReadOnly = true;
            this.txtServerUnknownState.Size = new System.Drawing.Size(100, 20);
            this.txtServerUnknownState.TabIndex = 20;
            // 
            // label123
            // 
            this.label123.AutoSize = true;
            this.label123.Location = new System.Drawing.Point(5, 281);
            this.label123.Name = "label123";
            this.label123.Size = new System.Drawing.Size(65, 13);
            this.label123.TabIndex = 19;
            this.label123.Text = "Device port:";
            // 
            // label124
            // 
            this.label124.AutoSize = true;
            this.label124.Location = new System.Drawing.Point(5, 255);
            this.label124.Name = "label124";
            this.label124.Size = new System.Drawing.Size(53, 13);
            this.label124.TabIndex = 18;
            this.label124.Text = "Host port:";
            // 
            // txtSPort
            // 
            this.txtSPort.Location = new System.Drawing.Point(146, 278);
            this.txtSPort.Name = "txtSPort";
            this.txtSPort.ReadOnly = true;
            this.txtSPort.Size = new System.Drawing.Size(100, 20);
            this.txtSPort.TabIndex = 17;
            // 
            // txtLPort
            // 
            this.txtLPort.Location = new System.Drawing.Point(146, 252);
            this.txtLPort.Name = "txtLPort";
            this.txtLPort.ReadOnly = true;
            this.txtLPort.Size = new System.Drawing.Size(100, 20);
            this.txtLPort.TabIndex = 16;
            // 
            // label99
            // 
            this.label99.AutoSize = true;
            this.label99.Location = new System.Drawing.Point(6, 228);
            this.label99.Name = "label99";
            this.label99.Size = new System.Drawing.Size(140, 13);
            this.label99.TabIndex = 15;
            this.label99.Text = "Conn. timeout event counts:";
            // 
            // label98
            // 
            this.label98.AutoSize = true;
            this.label98.Location = new System.Drawing.Point(6, 202);
            this.label98.Name = "label98";
            this.label98.Size = new System.Drawing.Size(137, 13);
            this.label98.TabIndex = 14;
            this.label98.Text = "Conn. closed event counts:";
            // 
            // label97
            // 
            this.label97.AutoSize = true;
            this.label97.Location = new System.Drawing.Point(6, 176);
            this.label97.Name = "label97";
            this.label97.Size = new System.Drawing.Size(130, 13);
            this.label97.TabIndex = 13;
            this.label97.Text = "Conn. abort event counts:";
            // 
            // label96
            // 
            this.label96.AutoSize = true;
            this.label96.Location = new System.Drawing.Point(6, 150);
            this.label96.Name = "label96";
            this.label96.Size = new System.Drawing.Size(119, 13);
            this.label96.TabIndex = 12;
            this.label96.Text = "Data ack event counts:";
            // 
            // label95
            // 
            this.label95.AutoSize = true;
            this.label95.Location = new System.Drawing.Point(6, 124);
            this.label95.Name = "label95";
            this.label95.Size = new System.Drawing.Size(137, 13);
            this.label95.TabIndex = 11;
            this.label95.Text = "Data transmit event counts:";
            // 
            // label94
            // 
            this.label94.AutoSize = true;
            this.label94.Location = new System.Drawing.Point(6, 98);
            this.label94.Name = "label94";
            this.label94.Size = new System.Drawing.Size(136, 13);
            this.label94.TabIndex = 10;
            this.label94.Text = "Data receive event counts:";
            // 
            // label93
            // 
            this.label93.AutoSize = true;
            this.label93.Location = new System.Drawing.Point(6, 72);
            this.label93.Name = "label93";
            this.label93.Size = new System.Drawing.Size(129, 13);
            this.label93.TabIndex = 9;
            this.label93.Text = "Connection event counts:";
            // 
            // txtServerTimedoutCount
            // 
            this.txtServerTimedoutCount.Location = new System.Drawing.Point(147, 225);
            this.txtServerTimedoutCount.Name = "txtServerTimedoutCount";
            this.txtServerTimedoutCount.ReadOnly = true;
            this.txtServerTimedoutCount.Size = new System.Drawing.Size(100, 20);
            this.txtServerTimedoutCount.TabIndex = 8;
            // 
            // txtServerStateDuration
            // 
            this.txtServerStateDuration.Location = new System.Drawing.Point(147, 43);
            this.txtServerStateDuration.Name = "txtServerStateDuration";
            this.txtServerStateDuration.ReadOnly = true;
            this.txtServerStateDuration.Size = new System.Drawing.Size(100, 20);
            this.txtServerStateDuration.TabIndex = 2;
            // 
            // txtServerClosedCount
            // 
            this.txtServerClosedCount.Location = new System.Drawing.Point(147, 199);
            this.txtServerClosedCount.Name = "txtServerClosedCount";
            this.txtServerClosedCount.ReadOnly = true;
            this.txtServerClosedCount.Size = new System.Drawing.Size(100, 20);
            this.txtServerClosedCount.TabIndex = 7;
            // 
            // label92
            // 
            this.label92.AutoSize = true;
            this.label92.Location = new System.Drawing.Point(6, 46);
            this.label92.Name = "label92";
            this.label92.Size = new System.Drawing.Size(72, 13);
            this.label92.TabIndex = 2;
            this.label92.Text = "Duration (ms):";
            // 
            // txtServerAbortedCount
            // 
            this.txtServerAbortedCount.Location = new System.Drawing.Point(147, 173);
            this.txtServerAbortedCount.Name = "txtServerAbortedCount";
            this.txtServerAbortedCount.ReadOnly = true;
            this.txtServerAbortedCount.Size = new System.Drawing.Size(100, 20);
            this.txtServerAbortedCount.TabIndex = 6;
            // 
            // txtServerDataACKCount
            // 
            this.txtServerDataACKCount.Location = new System.Drawing.Point(147, 147);
            this.txtServerDataACKCount.Name = "txtServerDataACKCount";
            this.txtServerDataACKCount.ReadOnly = true;
            this.txtServerDataACKCount.Size = new System.Drawing.Size(100, 20);
            this.txtServerDataACKCount.TabIndex = 5;
            // 
            // txtServerState
            // 
            this.txtServerState.Location = new System.Drawing.Point(147, 17);
            this.txtServerState.Name = "txtServerState";
            this.txtServerState.ReadOnly = true;
            this.txtServerState.Size = new System.Drawing.Size(100, 20);
            this.txtServerState.TabIndex = 2;
            // 
            // txtServerDataTxCount
            // 
            this.txtServerDataTxCount.Location = new System.Drawing.Point(147, 121);
            this.txtServerDataTxCount.Name = "txtServerDataTxCount";
            this.txtServerDataTxCount.ReadOnly = true;
            this.txtServerDataTxCount.Size = new System.Drawing.Size(100, 20);
            this.txtServerDataTxCount.TabIndex = 4;
            // 
            // label91
            // 
            this.label91.AutoSize = true;
            this.label91.Location = new System.Drawing.Point(6, 20);
            this.label91.Name = "label91";
            this.label91.Size = new System.Drawing.Size(54, 13);
            this.label91.TabIndex = 2;
            this.label91.Text = "SM State:";
            // 
            // txtServerDataRxCount
            // 
            this.txtServerDataRxCount.Location = new System.Drawing.Point(147, 95);
            this.txtServerDataRxCount.Name = "txtServerDataRxCount";
            this.txtServerDataRxCount.ReadOnly = true;
            this.txtServerDataRxCount.Size = new System.Drawing.Size(100, 20);
            this.txtServerDataRxCount.TabIndex = 3;
            // 
            // txtServerConnectCount
            // 
            this.txtServerConnectCount.Location = new System.Drawing.Point(147, 69);
            this.txtServerConnectCount.Name = "txtServerConnectCount";
            this.txtServerConnectCount.ReadOnly = true;
            this.txtServerConnectCount.Size = new System.Drawing.Size(100, 20);
            this.txtServerConnectCount.TabIndex = 2;
            // 
            // btnRtbClear
            // 
            this.btnRtbClear.Location = new System.Drawing.Point(980, 666);
            this.btnRtbClear.Name = "btnRtbClear";
            this.btnRtbClear.Size = new System.Drawing.Size(25, 20);
            this.btnRtbClear.TabIndex = 9;
            this.btnRtbClear.UseVisualStyleBackColor = true;
            this.btnRtbClear.Click += new System.EventHandler(this.btnRtbClear_Click);
            // 
            // rtbLog
            // 
            this.rtbLog.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rtbLog.HideSelection = false;
            this.rtbLog.Location = new System.Drawing.Point(10, 666);
            this.rtbLog.Name = "rtbLog";
            this.rtbLog.ReadOnly = true;
            this.rtbLog.Size = new System.Drawing.Size(991, 180);
            this.rtbLog.TabIndex = 8;
            this.rtbLog.Text = "";
            // 
            // tmrEPCInventory
            // 
            this.tmrEPCInventory.Tick += new System.EventHandler(this.tmrEPCInventory_Tick);
            // 
            // tmrTCPClient
            // 
            this.tmrTCPClient.Interval = 5;
            this.tmrTCPClient.Tick += new System.EventHandler(this.tmrTCPClient_Tick);
            // 
            // tmrRFDiagnosis
            // 
            this.tmrRFDiagnosis.Tick += new System.EventHandler(this.tmrRFDiagnosis_Tick);
            // 
            // tmrServerTasks
            // 
            this.tmrServerTasks.Interval = 10;
            this.tmrServerTasks.Tick += new System.EventHandler(this.tmrServerTasks_Tick);
            // 
            // tmrGetLoggedData
            // 
            this.tmrGetLoggedData.Tick += new System.EventHandler(this.tmrGetLoggedData_Tick);
            // 
            // tmrGetParkingModeRecords
            // 
            this.tmrGetParkingModeRecords.Interval = 250;
            this.tmrGetParkingModeRecords.Tick += new System.EventHandler(this.tmrGetParkingModeRecords_Tick);
            // 
            // tmrGetBRMLogs
            // 
            this.tmrGetBRMLogs.Interval = 50;
            this.tmrGetBRMLogs.Tick += new System.EventHandler(this.tmrGetBRMLogs_Tick);
            // 
            // tmrDiagScan
            // 
            this.tmrDiagScan.Interval = 250;
            this.tmrDiagScan.Tick += new System.EventHandler(this.tmrDiagScan_Tick);
            // 
            // tmrEPC_Timeout
            // 
            this.tmrEPC_Timeout.Enabled = true;
            this.tmrEPC_Timeout.Interval = 2000;
            this.tmrEPC_Timeout.Tick += new System.EventHandler(this.tmrEPC_Timeout_Tick);
            // 
            // toolTip1
            // 
            this.toolTip1.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1008, 856);
            this.Controls.Add(this.btnRtbClear);
            this.Controls.Add(this.tabCtrl);
            this.Controls.Add(this.rtbLog);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "RRUHFOEM07 Test App. v1.9a";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.grpCommSetup.ResumeLayout(false);
            this.grpCommSetup.PerformLayout();
            this.grpTCP.ResumeLayout(false);
            this.grpTCP.PerformLayout();
            this.grpCOM.ResumeLayout(false);
            this.grpCOM.PerformLayout();
            this.tabCtrl.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.groupBox21.ResumeLayout(false);
            this.groupBox21.PerformLayout();
            this.groupBox12.ResumeLayout(false);
            this.groupBox12.PerformLayout();
            this.groupBox11.ResumeLayout(false);
            this.groupBox11.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox8.ResumeLayout(false);
            this.groupBox8.PerformLayout();
            this.groupBox10.ResumeLayout(false);
            this.groupBox10.PerformLayout();
            this.gbRFSetup.ResumeLayout(false);
            this.groupBox36.ResumeLayout(false);
            this.groupBox36.PerformLayout();
            this.groupBox35.ResumeLayout(false);
            this.groupBox35.PerformLayout();
            this.groupBox34.ResumeLayout(false);
            this.groupBox34.PerformLayout();
            this.groupBox32.ResumeLayout(false);
            this.groupBox32.PerformLayout();
            this.groupBox33.ResumeLayout(false);
            this.groupBox33.PerformLayout();
            this.groupBox31.ResumeLayout(false);
            this.groupBox30.ResumeLayout(false);
            this.groupBox30.PerformLayout();
            this.groupBox29.ResumeLayout(false);
            this.groupBox29.PerformLayout();
            this.groupBox28.ResumeLayout(false);
            this.groupBox28.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.grpEPCWrite.ResumeLayout(false);
            this.grpEPCWrite.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgView)).EndInit();
            this.grpEPCSetProtect.ResumeLayout(false);
            this.grpEPCSetProtect.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.grpMemOps.ResumeLayout(false);
            this.grpMemOps.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.grpInventorySetup.ResumeLayout(false);
            this.grpInventorySetup.PerformLayout();
            this.groupBox26.ResumeLayout(false);
            this.groupBox26.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            this.grpExtInventory.ResumeLayout(false);
            this.grpExtInventory.PerformLayout();
            this.groupBox46.ResumeLayout(false);
            this.groupBox46.PerformLayout();
            this.groupBox37.ResumeLayout(false);
            this.groupBox37.PerformLayout();
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.groupBox9.ResumeLayout(false);
            this.groupBox9.PerformLayout();
            this.groupBox7.ResumeLayout(false);
            this.groupBox7.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.grpExtInvRouteOptions.ResumeLayout(false);
            this.grpExtInvRouteOptions.PerformLayout();
            this.tabPage4.ResumeLayout(false);
            this.groupBox45.ResumeLayout(false);
            this.groupBox45.PerformLayout();
            this.groupBox44.ResumeLayout(false);
            this.groupBox44.PerformLayout();
            this.groupBox27.ResumeLayout(false);
            this.groupBox27.PerformLayout();
            this.groupBox25.ResumeLayout(false);
            this.groupBox25.PerformLayout();
            this.groupBox20.ResumeLayout(false);
            this.groupBox23.ResumeLayout(false);
            this.groupBox22.ResumeLayout(false);
            this.groupBox22.PerformLayout();
            this.groupBox19.ResumeLayout(false);
            this.groupBox19.PerformLayout();
            this.groupBox18.ResumeLayout(false);
            this.groupBox18.PerformLayout();
            this.groupBox16.ResumeLayout(false);
            this.groupBox16.PerformLayout();
            this.groupBox17.ResumeLayout(false);
            this.groupBox17.PerformLayout();
            this.groupBox15.ResumeLayout(false);
            this.groupBox15.PerformLayout();
            this.groupBox14.ResumeLayout(false);
            this.groupBox14.PerformLayout();
            this.tabPage5.ResumeLayout(false);
            this.tabPage5.PerformLayout();
            this.tabPage6.ResumeLayout(false);
            this.tabPage6.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgDeviceList)).EndInit();
            this.tabPage7.ResumeLayout(false);
            this.tabPage7.PerformLayout();
            this.tabPage9.ResumeLayout(false);
            this.groupBox24.ResumeLayout(false);
            this.groupBox24.PerformLayout();
            this.groupBox43.ResumeLayout(false);
            this.groupBox43.PerformLayout();
            this.groupBox42.ResumeLayout(false);
            this.groupBox42.PerformLayout();
            this.groupBox40.ResumeLayout(false);
            this.groupBox40.PerformLayout();
            this.groupBox41.ResumeLayout(false);
            this.groupBox41.PerformLayout();
            this.groupBox39.ResumeLayout(false);
            this.groupBox39.PerformLayout();
            this.groupBox38.ResumeLayout(false);
            this.groupBox38.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grpCommSetup;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtTCP_Port;
        private System.Windows.Forms.TextBox txtDevicIP;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbxBaudRate;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbxSerPort;
        private System.Windows.Forms.GroupBox grpTCP;
        private System.Windows.Forms.GroupBox grpCOM;
        private System.Windows.Forms.RadioButton radSelectTCP;
        private System.Windows.Forms.RadioButton radSelectCOMPort;
        private System.Windows.Forms.TabControl tabCtrl;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Button btnConnect;
        private System.Windows.Forms.GroupBox grpMemOps;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton radUserBank;
        private System.Windows.Forms.RadioButton radTIDBank;
        private System.Windows.Forms.RadioButton radReservedBank;
        private System.Windows.Forms.RadioButton radEPCBank;
        private System.Windows.Forms.ComboBox cbxUIDOps;
        private System.Windows.Forms.GroupBox grpInventorySetup;
        private System.Windows.Forms.Button btnInventory;
        private System.Windows.Forms.Button btnSetTarget;
        private System.Windows.Forms.Button btnSetSession;
        private System.Windows.Forms.Button btnSetQValue;
        private System.Windows.Forms.Button btnGetTarget;
        private System.Windows.Forms.Button btnGetSession;
        private System.Windows.Forms.Button btnGetQValue;
        private System.Windows.Forms.ComboBox cbxInterval;
        private System.Windows.Forms.ComboBox cbxQValue;
        private System.Windows.Forms.ComboBox cbxTarget;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox cbxSession;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button btnBlockErase;
        private System.Windows.Forms.Button btnBlockWrite;
        private System.Windows.Forms.Button btnBlockRead;
        private System.Windows.Forms.TextBox txtBlockData;
        private System.Windows.Forms.TextBox txtAccessPwdOps;
        private System.Windows.Forms.TextBox txtTotalWords;
        private System.Windows.Forms.TextBox txtWordAddress;
        private System.Windows.Forms.GroupBox grpEPCSetProtect;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.RadioButton radBankTID;
        private System.Windows.Forms.RadioButton radBankUser;
        private System.Windows.Forms.RadioButton radKillPwd;
        private System.Windows.Forms.RadioButton radBankEPC;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.ComboBox cbxSetProtect;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.Button btnSetProtect;
        private System.Windows.Forms.TextBox txtSetProtectPw;
        private System.Windows.Forms.Button button13;
        private System.Windows.Forms.DataGridView dgView;
        private System.Windows.Forms.CheckBox chkRSSI;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.Timer tmrEPCInventory;
        private System.Windows.Forms.Button btnQuery;
        private System.Windows.Forms.GroupBox gbRFSetup;
        private System.Windows.Forms.RadioButton radAdccessPwd;
        private System.Windows.Forms.TextBox txtHardwareVersion;
        private System.Windows.Forms.TextBox txtDeviceSerialNum;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.TextBox txtFirmwareVersion;
        private System.Windows.Forms.Button btnSetWorkingMode;
        private System.Windows.Forms.Button btnGetWorkingMode;
        private System.Windows.Forms.ComboBox cbxDeviceWorkingMode;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.RichTextBox rtbLog;
        private System.Windows.Forms.Button btnRtbClear;
        private System.Windows.Forms.GroupBox grpExtInventory;
        private System.Windows.Forms.CheckBox chkComplaintTags;
        private System.Windows.Forms.CheckBox chkReportUserMem;
        private System.Windows.Forms.CheckBox chkAccessPwd;
        private System.Windows.Forms.CheckBox chkEPCMask;
        private System.Windows.Forms.CheckBox chkReportTID;
        private System.Windows.Forms.CheckBox chkIOPassEnable;
        private System.Windows.Forms.CheckBox chkReportRSSI;
        private System.Windows.Forms.CheckBox chkInvTriggerEnable;
        private System.Windows.Forms.CheckBox chkIOFailEnable;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.CheckBox chkInvOpsEnable;
        private System.Windows.Forms.TextBox txtEPCMask2;
        private System.Windows.Forms.Label label28;
        private System.Windows.Forms.Label label29;
        private System.Windows.Forms.TextBox txtAccessPwd2;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.TextBox txtUserMemBlockCount;
        private System.Windows.Forms.TextBox txtUserMemBlockAddress;
        private System.Windows.Forms.Label label31;
        private System.Windows.Forms.Label label30;
        private System.Windows.Forms.GroupBox groupBox7;
        private System.Windows.Forms.Button btnGetInvCfg;
        private System.Windows.Forms.Button btnSetInvCfg;
        private System.Windows.Forms.TextBox txtIO3_DwellTime;
        private System.Windows.Forms.ComboBox cbxIO3State;
        private System.Windows.Forms.Label label36;
        private System.Windows.Forms.Label label33;
        private System.Windows.Forms.TextBox txtIO2_DwellTime;
        private System.Windows.Forms.ComboBox cbxIO2State;
        private System.Windows.Forms.ComboBox cbxIO2;
        private System.Windows.Forms.Label label35;
        private System.Windows.Forms.Label label32;
        private System.Windows.Forms.TextBox txtIO1_DwellTime;
        private System.Windows.Forms.ComboBox cbxIO1State;
        private System.Windows.Forms.ComboBox cbxIO1;
        private System.Windows.Forms.Label label39;
        private System.Windows.Forms.Label label38;
        private System.Windows.Forms.Label label37;
        private System.Windows.Forms.Label label40;
        private System.Windows.Forms.Timer tmrTCPClient;
        private System.Windows.Forms.CheckBox chkEPCPersistance;
        private System.Windows.Forms.GroupBox groupBox9;
        private System.Windows.Forms.Label label48;
        private System.Windows.Forms.TextBox txtTagPersistenceTime;
        private System.Windows.Forms.Button btnBuzzerControl;
        private System.Windows.Forms.CheckBox chkBuzzerEnable;
        private System.Windows.Forms.TextBox txtBuzzerBeepDuration;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TabPage tabPage5;
        private ZedGraph.ZedGraphControl zedGraphControl1;
        private System.Windows.Forms.Button btnRFDiagnosisCtrl;
        private System.Windows.Forms.Timer tmrRFDiagnosis;
        private System.Windows.Forms.ComboBox cbxCurrentFreq;
        private System.Windows.Forms.TextBox txtRSSIAvg;
        private System.Windows.Forms.TextBox txtRSSINow;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button btnHeartbeat;
        private System.Windows.Forms.TextBox txtHeartbeat;
        private System.Windows.Forms.Label label55;
        private System.Windows.Forms.Button btnDeviceRestart;
        private System.Windows.Forms.TabPage tabPage6;
        private System.Windows.Forms.DataGridView dgDeviceList;
        private System.Windows.Forms.Button btnDeviceSearch;
        private System.Windows.Forms.Button btnTagKill;
        private System.Windows.Forms.CheckBox chkHeartbeatEn;
        private System.Windows.Forms.TextBox txtHeartbeat2;
        private System.Windows.Forms.Label label56;
        private System.Windows.Forms.CheckBox chkReaderID;
        private System.Windows.Forms.TabPage tabPage7;
        private System.Windows.Forms.TextBox txtTimeDiff;
        private System.Windows.Forms.Label label57;
        private System.Windows.Forms.TextBox txtTagCount;
        private System.Windows.Forms.Label label58;
        private System.Windows.Forms.Button btnTcpServerClearList;
        private System.Windows.Forms.ListView lvData;
        private System.Windows.Forms.ColumnHeader DevID;
        private System.Windows.Forms.ColumnHeader EPC;
        private System.Windows.Forms.ColumnHeader ReadCnt;
        private System.Windows.Forms.ColumnHeader TimeStamp;
        private System.Windows.Forms.Button btnTcpServerLogClear;
        private System.Windows.Forms.TextBox txtLog;
        private System.Windows.Forms.Button btnTcpServerStartStop;
        private System.Windows.Forms.Label label59;
        private System.Windows.Forms.TextBox txtPortTcpServer;
        private System.Windows.Forms.Button SetMask0;
        private System.Windows.Forms.Button GetMask0;
        private System.Windows.Forms.TextBox txtMask0;
        private System.Windows.Forms.Label label60;
        private System.Windows.Forms.CheckBox chkMask9;
        private System.Windows.Forms.Button SetMask9;
        private System.Windows.Forms.Button GetMask9;
        private System.Windows.Forms.TextBox txtMask9;
        private System.Windows.Forms.CheckBox chkMask8;
        private System.Windows.Forms.Button SetMask8;
        private System.Windows.Forms.Button GetMask8;
        private System.Windows.Forms.TextBox txtMask8;
        private System.Windows.Forms.CheckBox chkMask7;
        private System.Windows.Forms.Button SetMask7;
        private System.Windows.Forms.Button GetMask7;
        private System.Windows.Forms.TextBox txtMask7;
        private System.Windows.Forms.CheckBox chkMask6;
        private System.Windows.Forms.Button SetMask6;
        private System.Windows.Forms.Button GetMask6;
        private System.Windows.Forms.TextBox txtMask6;
        private System.Windows.Forms.CheckBox chkMask5;
        private System.Windows.Forms.Button SetMask5;
        private System.Windows.Forms.Button GetMask5;
        private System.Windows.Forms.TextBox txtMask5;
        private System.Windows.Forms.CheckBox chkMask4;
        private System.Windows.Forms.Button SetMask4;
        private System.Windows.Forms.Button GetMask4;
        private System.Windows.Forms.TextBox txtMask4;
        private System.Windows.Forms.CheckBox chkMask3;
        private System.Windows.Forms.Button SetMask3;
        private System.Windows.Forms.Button GetMask3;
        private System.Windows.Forms.TextBox txtMask3;
        private System.Windows.Forms.CheckBox chkMask2;
        private System.Windows.Forms.Button SetMask2;
        private System.Windows.Forms.Button GetMask2;
        private System.Windows.Forms.TextBox txtMask2;
        private System.Windows.Forms.CheckBox chkMask1;
        private System.Windows.Forms.Button SetMask1;
        private System.Windows.Forms.Button GetMask1;
        private System.Windows.Forms.TextBox txtMask1;
        private System.Windows.Forms.CheckBox chkMask0;
        private System.Windows.Forms.Label label62;
        private System.Windows.Forms.Label label61;
        private System.Windows.Forms.Label label64;
        private System.Windows.Forms.Label label63;
        private System.Windows.Forms.Label label65;
        private System.Windows.Forms.Label label66;
        private System.Windows.Forms.Label label67;
        private System.Windows.Forms.Label label69;
        private System.Windows.Forms.Label label68;
        private System.Windows.Forms.Button btnMask9Erase;
        private System.Windows.Forms.Button btnMask8Erase;
        private System.Windows.Forms.Button btnMask7Erase;
        private System.Windows.Forms.Button btnMask6Erase;
        private System.Windows.Forms.Button btnMask5Erase;
        private System.Windows.Forms.Button btnMask4Erase;
        private System.Windows.Forms.Button btnMask3Erase;
        private System.Windows.Forms.Button btnMask2Erase;
        private System.Windows.Forms.Button btnMask1Erase;
        private System.Windows.Forms.Button btnMask0Erase;
        private System.Windows.Forms.CheckBox chkMask9Enabled;
        private System.Windows.Forms.CheckBox chkMask8Enabled;
        private System.Windows.Forms.CheckBox chkMask7Enabled;
        private System.Windows.Forms.CheckBox chkMask6Enabled;
        private System.Windows.Forms.CheckBox chkMask5Enabled;
        private System.Windows.Forms.CheckBox chkMask4Enabled;
        private System.Windows.Forms.CheckBox chkMask3Enabled;
        private System.Windows.Forms.CheckBox chkMask2Enabled;
        private System.Windows.Forms.CheckBox chkMask1Enabled;
        private System.Windows.Forms.CheckBox chkMask0Enabled;
        private System.Windows.Forms.Timer tmrServerTasks;
        private System.Windows.Forms.GroupBox groupBox13;
        private System.Windows.Forms.Button btnForceBootMode;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.GroupBox groupBox14;
        private System.Windows.Forms.TextBox txtParkingmodeEPCtoRegister;
        private System.Windows.Forms.Button btnParkModeEPC_Query;
        private System.Windows.Forms.CheckBox chkParkModeTagWhitelistEnable;
        private System.Windows.Forms.RadioButton radParkModeCat4;
        private System.Windows.Forms.RadioButton radParkModeCat3;
        private System.Windows.Forms.RadioButton radParkModeCat2;
        private System.Windows.Forms.RadioButton radParkModeCat1;
        private System.Windows.Forms.Label label50;
        private System.Windows.Forms.Button btnParkModeTagRegister;
        private System.Windows.Forms.Label label34;
        private System.Windows.Forms.GroupBox groupBox15;
        private System.Windows.Forms.TextBox txtParkModeWhitelistRecordsCounter;
        private System.Windows.Forms.Label label70;
        private System.Windows.Forms.Label label71;
        private System.Windows.Forms.TextBox txtParkModeBlacklistRecordsCounter;
        private System.Windows.Forms.Button btnParkModeCheckTagEntries;
        private System.Windows.Forms.GroupBox groupBox16;
        private System.Windows.Forms.Button btnParkingModeCheckForEntry;
        private System.Windows.Forms.Label label72;
        private System.Windows.Forms.TextBox txtParkmodeRecordToCheck;
        private System.Windows.Forms.Label label73;
        private System.Windows.Forms.RadioButton chkCat4;
        private System.Windows.Forms.RadioButton chkCat3;
        private System.Windows.Forms.RadioButton chkCat2;
        private System.Windows.Forms.RadioButton chkCat1;
        private System.Windows.Forms.GroupBox groupBox17;
        private System.Windows.Forms.RadioButton chkRecordIsWhitelist;
        private System.Windows.Forms.RadioButton chkRecordIsBlacklist;
        private System.Windows.Forms.Button btnParkmodeDeleteExistingRecord;
        private System.Windows.Forms.Button btnParkmodeUpdateExistingRecord;
        private System.Windows.Forms.GroupBox groupBox18;
        private System.Windows.Forms.CheckBox chkCat1R1;
        private System.Windows.Forms.Label label77;
        private System.Windows.Forms.Label label76;
        private System.Windows.Forms.Label label75;
        private System.Windows.Forms.Label label74;
        private System.Windows.Forms.CheckBox chkCat4R4;
        private System.Windows.Forms.CheckBox chkCat3R4;
        private System.Windows.Forms.CheckBox chkCat4R3;
        private System.Windows.Forms.CheckBox chkCat4R2;
        private System.Windows.Forms.CheckBox chkCat2R4;
        private System.Windows.Forms.CheckBox chkCat4R1;
        private System.Windows.Forms.CheckBox chkCat3R3;
        private System.Windows.Forms.CheckBox chkCat2R3;
        private System.Windows.Forms.CheckBox chkCat3R2;
        private System.Windows.Forms.CheckBox chkCat3R1;
        private System.Windows.Forms.CheckBox chkCat2R2;
        private System.Windows.Forms.CheckBox chkCat2R1;
        private System.Windows.Forms.CheckBox chkCat1R4;
        private System.Windows.Forms.CheckBox chkCat1R3;
        private System.Windows.Forms.CheckBox chkCat1R2;
        private System.Windows.Forms.GroupBox groupBox19;
        private System.Windows.Forms.Label label79;
        private System.Windows.Forms.TextBox txtRelay1OnTime;
        private System.Windows.Forms.Label label78;
        private System.Windows.Forms.Label label84;
        private System.Windows.Forms.Label label82;
        private System.Windows.Forms.TextBox txtRelay4OnTime;
        private System.Windows.Forms.Label label80;
        private System.Windows.Forms.Label label85;
        private System.Windows.Forms.TextBox txtRelay3OnTime;
        private System.Windows.Forms.TextBox txtRelay2OnTime;
        private System.Windows.Forms.Label label83;
        private System.Windows.Forms.Label label81;
        private System.Windows.Forms.Label label86;
        private System.Windows.Forms.Button btnRelayModeSet;
        private System.Windows.Forms.Button btnRelayModeGet;
        private System.Windows.Forms.Button btnParkModeCatConfSet;
        private System.Windows.Forms.Button btnParkModeCatConfGet;
        private System.Windows.Forms.Button btnParkModeReadAllrecords;
        private System.Windows.Forms.GroupBox groupBox20;
        private System.Windows.Forms.GroupBox groupBox22;
        private System.Windows.Forms.GroupBox groupBox23;
        private System.Windows.Forms.Button btnParkingmodeDataLogReset;
        private System.Windows.Forms.Button btnParkingmodeRecordTableReset;
        private System.Windows.Forms.Button btnParkingmodeSetOfflineLogCfg;
        private System.Windows.Forms.Button btnParkingmodeGetOfflineLogCfg;
        private System.Windows.Forms.CheckBox chkBufferedReadMode;
        private System.Windows.Forms.Button btnRTCTimeGet;
        private System.Windows.Forms.Label label88;
        private System.Windows.Forms.TextBox txtRTC;
        private System.Windows.Forms.Button btnRTCSync;
        private System.Windows.Forms.Button btnLoadFromCSV;
        private System.Windows.Forms.CheckBox chkParkmodeAutoRegister;
        private System.Windows.Forms.RadioButton radParkModeLogAll;
        private System.Windows.Forms.RadioButton radParkmodeLogWLOnly;
        private System.Windows.Forms.GroupBox groupBox25;
        private System.Windows.Forms.Label label51;
        private System.Windows.Forms.TextBox txtParkModePersistence;
        private System.Windows.Forms.Button btnParkModePersistenceSet;
        private System.Windows.Forms.Button btnParkModePersistenceGet;
        private System.Windows.Forms.GroupBox groupBox27;
        private System.Windows.Forms.Button btnParkingModeSetDataRouteConf;
        private System.Windows.Forms.Button btnParkingModeGetDataRouteConf;
        private System.Windows.Forms.RadioButton radParmodeDataToTCP_Client;
        private System.Windows.Forms.RadioButton radParmodeDataToTCP_Server;
        private System.Windows.Forms.CheckBox chkParkModePersistenceAutoReset;
        private System.Windows.Forms.CheckBox chkParkingmodeIncDeviceSNR;
        private System.Windows.Forms.ColumnHeader TimeStampLogged;
        private System.Windows.Forms.ColumnHeader IsActiveID;
        private System.Windows.Forms.TextBox txtParkingmodeLoggedTIDCount;
        private System.Windows.Forms.Button btnParkingmodeGetLoggedTIDCount;
        private System.Windows.Forms.Button btnParkingmodeLogRead;
        private System.Windows.Forms.Timer tmrGetLoggedData;
        private System.Windows.Forms.RadioButton radTIDOnly;
        private System.Windows.Forms.RadioButton radEPC_TID;
        private System.Windows.Forms.RadioButton radEPCOnly;
        private System.Windows.Forms.Timer tmrGetParkingModeRecords;
        private System.Windows.Forms.GroupBox grpExtInvRouteOptions;
        private System.Windows.Forms.RadioButton radExtInvRespRouteToClient;
        private System.Windows.Forms.RadioButton radExtInvRespRouteToServer;
        private System.Windows.Forms.Button btnExtAotuInventoryRespRouteSet;
        private System.Windows.Forms.Button btnExtAotuInventoryRespRouteGet;
        private System.Windows.Forms.CheckBox chkIncludeAntennaID;
        private System.Windows.Forms.Button btnExtInCfgFlagsGet;
        private System.Windows.Forms.Button btn_BRMLogOps;
        private System.Windows.Forms.Timer tmrGetBRMLogs;
        private System.Windows.Forms.GroupBox groupBox28;
        private System.Windows.Forms.Button btnDeAuthenticate;
        private System.Windows.Forms.Button btnAuthenticate;
        private System.Windows.Forms.TextBox txtGlobalPwd;
        private System.Windows.Forms.Button btnPasswordUpdate;
        private System.Windows.Forms.GroupBox groupBox29;
        private System.Windows.Forms.GroupBox groupBox30;
        private System.Windows.Forms.GroupBox groupBox31;
        private System.Windows.Forms.GroupBox groupBox32;
        private System.Windows.Forms.GroupBox groupBox34;
        private System.Windows.Forms.GroupBox groupBox33;
        private System.Windows.Forms.GroupBox groupBox35;
        private System.Windows.Forms.GroupBox groupBox36;
        private System.Windows.Forms.Button btnPersistenceSet;
        private System.Windows.Forms.Button btnPersistenceGet;
        private System.Windows.Forms.TabPage tabPage9;
        private System.Windows.Forms.GroupBox groupBox39;
        private System.Windows.Forms.GroupBox groupBox38;
        private System.Windows.Forms.TextBox txtServerStateDuration;
        private System.Windows.Forms.Label label92;
        private System.Windows.Forms.TextBox txtServerState;
        private System.Windows.Forms.Label label91;
        private System.Windows.Forms.TextBox txtServerDataACKCount;
        private System.Windows.Forms.TextBox txtServerDataTxCount;
        private System.Windows.Forms.TextBox txtServerDataRxCount;
        private System.Windows.Forms.TextBox txtServerConnectCount;
        private System.Windows.Forms.TextBox txtServerAbortedCount;
        private System.Windows.Forms.TextBox txtServerTimedoutCount;
        private System.Windows.Forms.TextBox txtServerClosedCount;
        private System.Windows.Forms.Label label95;
        private System.Windows.Forms.Label label94;
        private System.Windows.Forms.Label label93;
        private System.Windows.Forms.Label label99;
        private System.Windows.Forms.Label label98;
        private System.Windows.Forms.Label label97;
        private System.Windows.Forms.Label label96;
        private System.Windows.Forms.Label label100;
        private System.Windows.Forms.Label label101;
        private System.Windows.Forms.Label label102;
        private System.Windows.Forms.Label label103;
        private System.Windows.Forms.Label label104;
        private System.Windows.Forms.Label label105;
        private System.Windows.Forms.Label label106;
        private System.Windows.Forms.TextBox txtClientTimedoutCount;
        private System.Windows.Forms.TextBox txtClientStateDuration;
        private System.Windows.Forms.TextBox txtClientClosedCount;
        private System.Windows.Forms.Label label107;
        private System.Windows.Forms.TextBox txtClientAbortedCount;
        private System.Windows.Forms.TextBox txtClientDataACKCount;
        private System.Windows.Forms.TextBox txtClientState;
        private System.Windows.Forms.TextBox txtClientDataTxCount;
        private System.Windows.Forms.Label label108;
        private System.Windows.Forms.TextBox txtClientDataRxCount;
        private System.Windows.Forms.TextBox txtClientConnectCount;
        private System.Windows.Forms.GroupBox groupBox40;
        private System.Windows.Forms.TextBox txtLastCmdExecDuration;
        private System.Windows.Forms.TextBox txtLastCmdErrorCode;
        private System.Windows.Forms.TextBox txtLastCmdCode;
        private System.Windows.Forms.Label label109;
        private System.Windows.Forms.TextBox txtDeviceDuration;
        private System.Windows.Forms.Label label112;
        private System.Windows.Forms.Label label111;
        private System.Windows.Forms.Label label110;
        private System.Windows.Forms.Label label114;
        private System.Windows.Forms.Label label113;
        private System.Windows.Forms.TextBox txtRFErrorCount;
        private System.Windows.Forms.TextBox txtRFErrorCode;
        private System.Windows.Forms.GroupBox groupBox41;
        private System.Windows.Forms.CheckBox chkPHYHardFault;
        private System.Windows.Forms.CheckBox chkEEPFault;
        private System.Windows.Forms.CheckBox chkRFHardFault;
        private System.Windows.Forms.GroupBox groupBox42;
        private System.Windows.Forms.TextBox txtPHYLinkStateDuration;
        private System.Windows.Forms.Label label116;
        private System.Windows.Forms.TextBox txtPHYLinkState;
        private System.Windows.Forms.Label label115;
        private System.Windows.Forms.Label label117;
        private System.Windows.Forms.Label label118;
        private System.Windows.Forms.TextBox txtPHY_NokPacketCounts;
        private System.Windows.Forms.TextBox txtPHY_OkPacketCounts;
        private System.Windows.Forms.GroupBox groupBox43;
        private System.Windows.Forms.Button btnDiagResetAllCnt;
        private System.Windows.Forms.Button btnDiagScan;
        private System.Windows.Forms.Label label119;
        private System.Windows.Forms.TextBox txtScanFrequency;
        private System.Windows.Forms.Timer tmrDiagScan;
        private System.Windows.Forms.Label label120;
        private System.Windows.Forms.TextBox txtClientResetEcentCount;
        private System.Windows.Forms.Label label121;
        private System.Windows.Forms.TextBox txtMemFailEventCounts;
        private System.Windows.Forms.Label label122;
        private System.Windows.Forms.TextBox txtActiveSocketCounts;
        private System.Windows.Forms.Label label125;
        private System.Windows.Forms.TextBox txtCPort;
        private System.Windows.Forms.Label label126;
        private System.Windows.Forms.TextBox txtRPort;
        private System.Windows.Forms.Label label123;
        private System.Windows.Forms.Label label124;
        private System.Windows.Forms.TextBox txtSPort;
        private System.Windows.Forms.TextBox txtLPort;
        private System.Windows.Forms.Label label130;
        private System.Windows.Forms.TextBox txtClientUStateCount;
        private System.Windows.Forms.Label label129;
        private System.Windows.Forms.TextBox txtClientUnknownState;
        private System.Windows.Forms.Label label128;
        private System.Windows.Forms.TextBox txtServerUStateCount;
        private System.Windows.Forms.Label label127;
        private System.Windows.Forms.TextBox txtServerUnknownState;
        private System.Windows.Forms.Label label131;
        private System.Windows.Forms.TextBox txtServerAppCallCount;
        private System.Windows.Forms.Label label132;
        private System.Windows.Forms.TextBox txtClientAppCallCount;
        private System.Windows.Forms.Label label133;
        private System.Windows.Forms.TextBox txtGlobalCallbackCount;
        private System.Windows.Forms.Label lblRFInfo1;
        private System.Windows.Forms.Label lblRFInfo2;
        private System.Windows.Forms.Label lblRFInfo3;
        private System.Windows.Forms.CheckBox chkDeviceIDReverse1;
        private System.Windows.Forms.CheckBox chkIDReverse2;
        private System.Windows.Forms.CheckBox chkIDReverse;
        private System.Windows.Forms.Button btnBaudrateSet;
        private System.Windows.Forms.Button btnBaudrateGet;
        private System.Windows.Forms.ComboBox cbxUSARTBaudrate;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.GroupBox groupBox8;
        private System.Windows.Forms.CheckBox chkDHCP;
        private System.Windows.Forms.Label label49;
        private System.Windows.Forms.CheckBox chkMACAddress;
        private System.Windows.Forms.CheckBox chkClientIP;
        private System.Windows.Forms.TextBox txtMACAddress;
        private System.Windows.Forms.Label label47;
        private System.Windows.Forms.TextBox txtDeviceClietnIP;
        private System.Windows.Forms.CheckBox chkClientPort;
        private System.Windows.Forms.CheckBox chkServerPort;
        private System.Windows.Forms.CheckBox chkNetMask;
        private System.Windows.Forms.CheckBox chkGetWayIP;
        private System.Windows.Forms.CheckBox chkDeviceIP;
        private System.Windows.Forms.Button btnSetTCPConf;
        private System.Windows.Forms.Button btnGetTCPConf;
        private System.Windows.Forms.Label label45;
        private System.Windows.Forms.Label label44;
        private System.Windows.Forms.TextBox txtDeviceClientPort;
        private System.Windows.Forms.TextBox txtDeviceNetMask;
        private System.Windows.Forms.Label label46;
        private System.Windows.Forms.TextBox txtDeviceServerPort;
        private System.Windows.Forms.Label label43;
        private System.Windows.Forms.TextBox txtDeviceGW;
        private System.Windows.Forms.Label label42;
        private System.Windows.Forms.TextBox txtDeviceIP;
        private System.Windows.Forms.GroupBox groupBox10;
        private System.Windows.Forms.ComboBox cbxMaxFreq;
        private System.Windows.Forms.Label lblRFPower;
        private System.Windows.Forms.Button btnSetRfmode;
        private System.Windows.Forms.Label lblRegion;
        private System.Windows.Forms.Button btnGetRfMode;
        private System.Windows.Forms.ComboBox cbxRegion;
        private System.Windows.Forms.Button btnGetRfPower;
        private System.Windows.Forms.Button btnGetRegion;
        private System.Windows.Forms.Label lblRFMode;
        private System.Windows.Forms.Button btnSetRegion;
        private System.Windows.Forms.Button btnSetRfPower;
        private System.Windows.Forms.ComboBox cbxMinFreq;
        private System.Windows.Forms.ComboBox cbxRFMode;
        private System.Windows.Forms.TextBox tbRFPower;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox grpEPCWrite;
        private System.Windows.Forms.Label label26;
        private System.Windows.Forms.Button btnWriteEPC;
        private System.Windows.Forms.TextBox txtAccessPwEPC;
        private System.Windows.Forms.TextBox txtNewEPC;
        private System.Windows.Forms.Label label27;
        private System.Windows.Forms.GroupBox groupBox12;
        private System.Windows.Forms.Button btnRelaysSet;
        private System.Windows.Forms.CheckBox chkRelay2;
        private System.Windows.Forms.CheckBox chkRelay1;
        private System.Windows.Forms.GroupBox groupBox11;
        private System.Windows.Forms.Button btnRelay2Trigger;
        private System.Windows.Forms.Button btnRelay1Trigger;
        private System.Windows.Forms.Label label54;
        private System.Windows.Forms.Label label53;
        private System.Windows.Forms.TextBox txtIRelay2Timeout;
        private System.Windows.Forms.TextBox txtIRelay1Timeout;
        private System.Windows.Forms.Label label52;
        private System.Windows.Forms.CheckBox chkRelay4;
        private System.Windows.Forms.CheckBox chkRelay3;
        private System.Windows.Forms.Button btnRelay4Trigger;
        private System.Windows.Forms.Button btnRelay3Trigger;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.TextBox txtIRelay4Timeout;
        private System.Windows.Forms.TextBox txtIRelay3Timeout;
        private System.Windows.Forms.CheckBox chkPersistanceAutoReset;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.TextBox tbUIDCont;
        private System.Windows.Forms.Timer tmrEPC_Timeout;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.RadioButton radTCPClient;
        private System.Windows.Forms.RadioButton radTCPServer;
        private System.Windows.Forms.CheckBox chkTCPClientCheck;
        private System.Windows.Forms.GroupBox groupBox21;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Button btnMuxConfSet;
        private System.Windows.Forms.Button btnMuxConfGet;
        private System.Windows.Forms.ComboBox cbxMuxPort;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_1;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_2;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_3;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_4;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_5;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_6;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_7;
        private System.Windows.Forms.Label label41;
        private System.Windows.Forms.TextBox txtTIDScanTimeMsec;
        private System.Windows.Forms.GroupBox groupBox24;
        private System.Windows.Forms.Label lblDiagFrameVersion;
        private System.Windows.Forms.Label label87;
        private System.Windows.Forms.GroupBox groupBox26;
        private System.Windows.Forms.CheckBox chkAnt1;
        private System.Windows.Forms.Button btnExtInventory;
        private System.Windows.Forms.CheckBox chkAnt6;
        private System.Windows.Forms.CheckBox chkAnt5;
        private System.Windows.Forms.CheckBox chkAnt4;
        private System.Windows.Forms.CheckBox chkAnt3;
        private System.Windows.Forms.CheckBox chkAnt2;
        private System.Windows.Forms.GroupBox groupBox37;
        private System.Windows.Forms.CheckBox ChkExtAnt6;
        private System.Windows.Forms.CheckBox ChkExtAnt5;
        private System.Windows.Forms.CheckBox ChkExtAnt4;
        private System.Windows.Forms.CheckBox ChkExtAnt3;
        private System.Windows.Forms.CheckBox ChkExtAnt2;
        private System.Windows.Forms.CheckBox ChkExtAnt1;
        private System.Windows.Forms.Button btnSetMuxConfig;
        private System.Windows.Forms.Button btnGetMuxConfig;
        private System.Windows.Forms.Label label89;
        private System.Windows.Forms.GroupBox groupBox45;
        private System.Windows.Forms.Button btnLogDeviceSNConfSet;
        private System.Windows.Forms.Button btnLogDeviceSNConfGet;
        private System.Windows.Forms.GroupBox groupBox44;
        private System.Windows.Forms.DataGridViewTextBoxColumn C0;
        private System.Windows.Forms.DataGridViewTextBoxColumn C1;
        private System.Windows.Forms.DataGridViewTextBoxColumn C2;
        private System.Windows.Forms.DataGridViewTextBoxColumn C3;
        private System.Windows.Forms.DataGridViewTextBoxColumn C4;
        private System.Windows.Forms.DataGridViewTextBoxColumn C5;
        private System.Windows.Forms.DataGridViewTextBoxColumn C6;
        private System.Windows.Forms.DataGridViewTextBoxColumn C7;
        private System.Windows.Forms.DataGridViewTextBoxColumn C8;
        private System.Windows.Forms.DataGridViewTextBoxColumn C9;
        private System.Windows.Forms.DataGridViewTextBoxColumn C10;
        private System.Windows.Forms.DataGridViewTextBoxColumn C11;
        private System.Windows.Forms.GroupBox groupBox46;
        private System.Windows.Forms.Label label90;
        private System.Windows.Forms.TextBox txtCycleTime;
        private System.Windows.Forms.Button btnCycleTimeSet;
        private System.Windows.Forms.Button btnCycleTimeGet;
    }
}

