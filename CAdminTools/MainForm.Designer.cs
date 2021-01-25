namespace CAdminTools
{
    partial class Form_MainForm
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
            this.Lbl_CompName = new System.Windows.Forms.Label();
            this.TxtBox_CompName = new System.Windows.Forms.TextBox();
            this.Btn_WinRDP = new System.Windows.Forms.Button();
            this.Btn_Logoff = new System.Windows.Forms.Button();
            this.Btn_Uptime = new System.Windows.Forms.Button();
            this.Btn_PCMange = new System.Windows.Forms.Button();
            this.Btn_RemoteC = new System.Windows.Forms.Button();
            this.Btn_Processes = new System.Windows.Forms.Button();
            this.Btn_Printers = new System.Windows.Forms.Button();
            this.Btn_PCInfo = new System.Windows.Forms.Button();
            this.Btn_Restart = new System.Windows.Forms.Button();
            this.Lbl_UserName = new System.Windows.Forms.Label();
            this.Lbl_PingStatus = new System.Windows.Forms.Label();
            this.Lbl_IP = new System.Windows.Forms.Label();
            this.Lbl_ManageUser = new System.Windows.Forms.Label();
            this.CkBox_IAM = new System.Windows.Forms.CheckBox();
            this.CkBox_ARS = new System.Windows.Forms.CheckBox();
            this.Btn_ChangeNameType = new System.Windows.Forms.Button();
            this.Pnl_CompMang = new System.Windows.Forms.Panel();
            this.Pnl_User = new System.Windows.Forms.Panel();
            this.Btn_UserLookUp = new System.Windows.Forms.Button();
            this.ComBox_OpenSite = new System.Windows.Forms.ComboBox();
            this.Pnl_OpenSite = new System.Windows.Forms.Panel();
            this.Pnl_OpenSitePrefix = new System.Windows.Forms.Panel();
            this.RBtn_Manual = new System.Windows.Forms.RadioButton();
            this.RBtn_https = new System.Windows.Forms.RadioButton();
            this.RBtn_http = new System.Windows.Forms.RadioButton();
            this.Pnl_WhichPC = new System.Windows.Forms.Panel();
            this.RBtn_RemotePC = new System.Windows.Forms.RadioButton();
            this.RBtn_ThisPC = new System.Windows.Forms.RadioButton();
            this.Pnl_OpenSiteType = new System.Windows.Forms.Panel();
            this.RBtn_Custom = new System.Windows.Forms.RadioButton();
            this.RBtn_Select = new System.Windows.Forms.RadioButton();
            this.Btn_SiteGo = new System.Windows.Forms.Button();
            this.Pnl_IntDocs = new System.Windows.Forms.Panel();
            this.Btn_IntDocGo = new System.Windows.Forms.Button();
            this.ComBox_IntDocs = new System.Windows.Forms.ComboBox();
            this.ComBox_Server = new System.Windows.Forms.ComboBox();
            this.Btn_CHFSSearch = new System.Windows.Forms.Button();
            this.Btn_SecondayPC = new System.Windows.Forms.Button();
            this.Btn_RemExec = new System.Windows.Forms.Button();
            this.Btn_PrinterSearch = new System.Windows.Forms.Button();
            this.TxtBox_Output = new System.Windows.Forms.TextBox();
            this.Btn_LANDeskWeb = new System.Windows.Forms.Button();
            this.WaitToPing = new System.Windows.Forms.Timer(this.components);
            this.Btn_CleanPrinters = new System.Windows.Forms.Button();
            this.Btn_ClearOutput = new System.Windows.Forms.Button();
            this.Btn_ChangeBrowser = new System.Windows.Forms.Button();
            this.ComBox_VMs = new System.Windows.Forms.ComboBox();
            this.TxtBox_Notes = new System.Windows.Forms.TextBox();
            this.PicBox_Main = new System.Windows.Forms.PictureBox();
            this.Btn_ShowNotes = new System.Windows.Forms.Button();
            this.Btn_Ping = new System.Windows.Forms.Button();
            this.Btn_RCViewer = new System.Windows.Forms.Button();
            this.Btn_Customize = new System.Windows.Forms.Button();
            this.Btn_LANDesk = new System.Windows.Forms.Button();
            this.CTxtBox_LName = new CAdminTools.ClearTextBox();
            this.CTxtBox_Email = new CAdminTools.ClearTextBox();
            this.CTxtBox_FName = new CAdminTools.ClearTextBox();
            this.CTxtBox_UserName = new CAdminTools.ClearTextBox();
            this.Pnl_CompMang.SuspendLayout();
            this.Pnl_User.SuspendLayout();
            this.Pnl_OpenSite.SuspendLayout();
            this.Pnl_OpenSitePrefix.SuspendLayout();
            this.Pnl_WhichPC.SuspendLayout();
            this.Pnl_OpenSiteType.SuspendLayout();
            this.Pnl_IntDocs.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PicBox_Main)).BeginInit();
            this.SuspendLayout();
            // 
            // Lbl_CompName
            // 
            this.Lbl_CompName.AutoSize = true;
            this.Lbl_CompName.Location = new System.Drawing.Point(21, 15);
            this.Lbl_CompName.Name = "Lbl_CompName";
            this.Lbl_CompName.Size = new System.Drawing.Size(104, 13);
            this.Lbl_CompName.TabIndex = 1;
            this.Lbl_CompName.Text = "Computer Name / IP";
            // 
            // TxtBox_CompName
            // 
            this.TxtBox_CompName.Location = new System.Drawing.Point(17, 35);
            this.TxtBox_CompName.Name = "TxtBox_CompName";
            this.TxtBox_CompName.Size = new System.Drawing.Size(120, 20);
            this.TxtBox_CompName.TabIndex = 0;
            this.TxtBox_CompName.TextChanged += new System.EventHandler(this.TxtBox_CompName_TextChanged);
            // 
            // Btn_WinRDP
            // 
            this.Btn_WinRDP.Location = new System.Drawing.Point(139, 127);
            this.Btn_WinRDP.Name = "Btn_WinRDP";
            this.Btn_WinRDP.Size = new System.Drawing.Size(71, 23);
            this.Btn_WinRDP.TabIndex = 4;
            this.Btn_WinRDP.Text = "Win RDP";
            this.Btn_WinRDP.UseVisualStyleBackColor = true;
            this.Btn_WinRDP.Click += new System.EventHandler(this.Btn_WinRDP_Click);
            // 
            // Btn_Logoff
            // 
            this.Btn_Logoff.Location = new System.Drawing.Point(6, 35);
            this.Btn_Logoff.Name = "Btn_Logoff";
            this.Btn_Logoff.Size = new System.Drawing.Size(94, 23);
            this.Btn_Logoff.TabIndex = 2;
            this.Btn_Logoff.Text = "Log Off";
            this.Btn_Logoff.UseVisualStyleBackColor = true;
            this.Btn_Logoff.Click += new System.EventHandler(this.Btn_Logoff_Click);
            // 
            // Btn_Uptime
            // 
            this.Btn_Uptime.Location = new System.Drawing.Point(6, 6);
            this.Btn_Uptime.Name = "Btn_Uptime";
            this.Btn_Uptime.Size = new System.Drawing.Size(94, 23);
            this.Btn_Uptime.TabIndex = 0;
            this.Btn_Uptime.Text = "Uptime";
            this.Btn_Uptime.UseVisualStyleBackColor = true;
            this.Btn_Uptime.Click += new System.EventHandler(this.Btn_Uptime_Click);
            // 
            // Btn_PCMange
            // 
            this.Btn_PCMange.Location = new System.Drawing.Point(6, 64);
            this.Btn_PCMange.Name = "Btn_PCMange";
            this.Btn_PCMange.Size = new System.Drawing.Size(94, 23);
            this.Btn_PCMange.TabIndex = 4;
            this.Btn_PCMange.Text = "PC Management";
            this.Btn_PCMange.UseVisualStyleBackColor = true;
            this.Btn_PCMange.Click += new System.EventHandler(this.Btn_PCMange_Click);
            // 
            // Btn_RemoteC
            // 
            this.Btn_RemoteC.Location = new System.Drawing.Point(6, 93);
            this.Btn_RemoteC.Name = "Btn_RemoteC";
            this.Btn_RemoteC.Size = new System.Drawing.Size(94, 23);
            this.Btn_RemoteC.TabIndex = 6;
            this.Btn_RemoteC.Text = "Remote c$";
            this.Btn_RemoteC.UseVisualStyleBackColor = true;
            this.Btn_RemoteC.Click += new System.EventHandler(this.Btn_RemoteC_Click);
            // 
            // Btn_Processes
            // 
            this.Btn_Processes.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Btn_Processes.Location = new System.Drawing.Point(106, 64);
            this.Btn_Processes.Name = "Btn_Processes";
            this.Btn_Processes.Size = new System.Drawing.Size(94, 23);
            this.Btn_Processes.TabIndex = 5;
            this.Btn_Processes.Text = "View Processes";
            this.Btn_Processes.UseVisualStyleBackColor = true;
            this.Btn_Processes.Click += new System.EventHandler(this.Btn_Processes_Click);
            // 
            // Btn_Printers
            // 
            this.Btn_Printers.Location = new System.Drawing.Point(105, 116);
            this.Btn_Printers.Name = "Btn_Printers";
            this.Btn_Printers.Size = new System.Drawing.Size(94, 23);
            this.Btn_Printers.TabIndex = 7;
            this.Btn_Printers.Text = "Printers";
            this.Btn_Printers.UseVisualStyleBackColor = true;
            this.Btn_Printers.Visible = false;
            this.Btn_Printers.Click += new System.EventHandler(this.Btn_Printers_Click);
            // 
            // Btn_PCInfo
            // 
            this.Btn_PCInfo.Location = new System.Drawing.Point(106, 6);
            this.Btn_PCInfo.Name = "Btn_PCInfo";
            this.Btn_PCInfo.Size = new System.Drawing.Size(94, 23);
            this.Btn_PCInfo.TabIndex = 1;
            this.Btn_PCInfo.Text = "PC Info";
            this.Btn_PCInfo.UseVisualStyleBackColor = true;
            this.Btn_PCInfo.Click += new System.EventHandler(this.Btn_PCInfo_Click);
            // 
            // Btn_Restart
            // 
            this.Btn_Restart.Location = new System.Drawing.Point(106, 35);
            this.Btn_Restart.Name = "Btn_Restart";
            this.Btn_Restart.Size = new System.Drawing.Size(94, 23);
            this.Btn_Restart.TabIndex = 3;
            this.Btn_Restart.Text = "Restart";
            this.Btn_Restart.UseVisualStyleBackColor = true;
            this.Btn_Restart.Click += new System.EventHandler(this.Btn_Restart_Click);
            // 
            // Lbl_UserName
            // 
            this.Lbl_UserName.AutoSize = true;
            this.Lbl_UserName.Location = new System.Drawing.Point(153, 50);
            this.Lbl_UserName.Name = "Lbl_UserName";
            this.Lbl_UserName.Size = new System.Drawing.Size(0, 13);
            this.Lbl_UserName.TabIndex = 12;
            // 
            // Lbl_PingStatus
            // 
            this.Lbl_PingStatus.AutoSize = true;
            this.Lbl_PingStatus.Location = new System.Drawing.Point(153, 66);
            this.Lbl_PingStatus.Name = "Lbl_PingStatus";
            this.Lbl_PingStatus.Size = new System.Drawing.Size(0, 13);
            this.Lbl_PingStatus.TabIndex = 13;
            // 
            // Lbl_IP
            // 
            this.Lbl_IP.AutoSize = true;
            this.Lbl_IP.Location = new System.Drawing.Point(153, 35);
            this.Lbl_IP.Name = "Lbl_IP";
            this.Lbl_IP.Size = new System.Drawing.Size(0, 13);
            this.Lbl_IP.TabIndex = 14;
            // 
            // Lbl_ManageUser
            // 
            this.Lbl_ManageUser.AutoSize = true;
            this.Lbl_ManageUser.Location = new System.Drawing.Point(15, 15);
            this.Lbl_ManageUser.Name = "Lbl_ManageUser";
            this.Lbl_ManageUser.Size = new System.Drawing.Size(71, 13);
            this.Lbl_ManageUser.TabIndex = 15;
            this.Lbl_ManageUser.Text = "Manage User";
            // 
            // CkBox_IAM
            // 
            this.CkBox_IAM.AutoSize = true;
            this.CkBox_IAM.Location = new System.Drawing.Point(103, 14);
            this.CkBox_IAM.Name = "CkBox_IAM";
            this.CkBox_IAM.Size = new System.Drawing.Size(45, 17);
            this.CkBox_IAM.TabIndex = 3;
            this.CkBox_IAM.Text = "IAM";
            this.CkBox_IAM.UseVisualStyleBackColor = true;
            // 
            // CkBox_ARS
            // 
            this.CkBox_ARS.AutoSize = true;
            this.CkBox_ARS.Checked = true;
            this.CkBox_ARS.CheckState = System.Windows.Forms.CheckState.Checked;
            this.CkBox_ARS.Location = new System.Drawing.Point(154, 14);
            this.CkBox_ARS.Name = "CkBox_ARS";
            this.CkBox_ARS.Size = new System.Drawing.Size(48, 17);
            this.CkBox_ARS.TabIndex = 4;
            this.CkBox_ARS.Text = "ARS";
            this.CkBox_ARS.UseVisualStyleBackColor = true;
            // 
            // Btn_ChangeNameType
            // 
            this.Btn_ChangeNameType.Location = new System.Drawing.Point(5, 37);
            this.Btn_ChangeNameType.Name = "Btn_ChangeNameType";
            this.Btn_ChangeNameType.Size = new System.Drawing.Size(16, 23);
            this.Btn_ChangeNameType.TabIndex = 0;
            this.Btn_ChangeNameType.Text = "I";
            this.Btn_ChangeNameType.UseVisualStyleBackColor = true;
            this.Btn_ChangeNameType.Click += new System.EventHandler(this.Btn_ChangeNameType_Click);
            // 
            // Pnl_CompMang
            // 
            this.Pnl_CompMang.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Pnl_CompMang.Controls.Add(this.Btn_Logoff);
            this.Pnl_CompMang.Controls.Add(this.Btn_Uptime);
            this.Pnl_CompMang.Controls.Add(this.Btn_RemoteC);
            this.Pnl_CompMang.Controls.Add(this.Btn_PCMange);
            this.Pnl_CompMang.Controls.Add(this.Btn_Restart);
            this.Pnl_CompMang.Controls.Add(this.Btn_PCInfo);
            this.Pnl_CompMang.Controls.Add(this.Btn_Printers);
            this.Pnl_CompMang.Controls.Add(this.Btn_Processes);
            this.Pnl_CompMang.Location = new System.Drawing.Point(10, 159);
            this.Pnl_CompMang.Name = "Pnl_CompMang";
            this.Pnl_CompMang.Size = new System.Drawing.Size(210, 150);
            this.Pnl_CompMang.TabIndex = 11;
            // 
            // Pnl_User
            // 
            this.Pnl_User.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Pnl_User.Controls.Add(this.CTxtBox_LName);
            this.Pnl_User.Controls.Add(this.CTxtBox_Email);
            this.Pnl_User.Controls.Add(this.CTxtBox_FName);
            this.Pnl_User.Controls.Add(this.CTxtBox_UserName);
            this.Pnl_User.Controls.Add(this.Btn_UserLookUp);
            this.Pnl_User.Controls.Add(this.Lbl_ManageUser);
            this.Pnl_User.Controls.Add(this.CkBox_IAM);
            this.Pnl_User.Controls.Add(this.Btn_ChangeNameType);
            this.Pnl_User.Controls.Add(this.CkBox_ARS);
            this.Pnl_User.Location = new System.Drawing.Point(232, 127);
            this.Pnl_User.Name = "Pnl_User";
            this.Pnl_User.Size = new System.Drawing.Size(210, 91);
            this.Pnl_User.TabIndex = 10;
            // 
            // Btn_UserLookUp
            // 
            this.Btn_UserLookUp.Location = new System.Drawing.Point(3, 65);
            this.Btn_UserLookUp.Name = "Btn_UserLookUp";
            this.Btn_UserLookUp.Size = new System.Drawing.Size(91, 23);
            this.Btn_UserLookUp.TabIndex = 5;
            this.Btn_UserLookUp.Text = "Lookup";
            this.Btn_UserLookUp.UseVisualStyleBackColor = true;
            this.Btn_UserLookUp.Click += new System.EventHandler(this.Btn_UserLookUp_Click);
            // 
            // ComBox_OpenSite
            // 
            this.ComBox_OpenSite.FormattingEnabled = true;
            this.ComBox_OpenSite.Location = new System.Drawing.Point(38, 3);
            this.ComBox_OpenSite.Name = "ComBox_OpenSite";
            this.ComBox_OpenSite.Size = new System.Drawing.Size(169, 21);
            this.ComBox_OpenSite.TabIndex = 0;
            this.ComBox_OpenSite.DropDown += new System.EventHandler(this.ComBox_OpenSite_DropDown);
            this.ComBox_OpenSite.DropDownClosed += new System.EventHandler(this.ComBox_OpenSite_DropDownClosed);
            // 
            // Pnl_OpenSite
            // 
            this.Pnl_OpenSite.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Pnl_OpenSite.Controls.Add(this.Pnl_OpenSitePrefix);
            this.Pnl_OpenSite.Controls.Add(this.Pnl_WhichPC);
            this.Pnl_OpenSite.Controls.Add(this.Pnl_OpenSiteType);
            this.Pnl_OpenSite.Controls.Add(this.Btn_SiteGo);
            this.Pnl_OpenSite.Controls.Add(this.ComBox_OpenSite);
            this.Pnl_OpenSite.Location = new System.Drawing.Point(232, 258);
            this.Pnl_OpenSite.Name = "Pnl_OpenSite";
            this.Pnl_OpenSite.Size = new System.Drawing.Size(210, 108);
            this.Pnl_OpenSite.TabIndex = 12;
            // 
            // Pnl_OpenSitePrefix
            // 
            this.Pnl_OpenSitePrefix.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Pnl_OpenSitePrefix.Controls.Add(this.RBtn_Manual);
            this.Pnl_OpenSitePrefix.Controls.Add(this.RBtn_https);
            this.Pnl_OpenSitePrefix.Controls.Add(this.RBtn_http);
            this.Pnl_OpenSitePrefix.Location = new System.Drawing.Point(6, 78);
            this.Pnl_OpenSitePrefix.Name = "Pnl_OpenSitePrefix";
            this.Pnl_OpenSitePrefix.Size = new System.Drawing.Size(196, 24);
            this.Pnl_OpenSitePrefix.TabIndex = 5;
            // 
            // RBtn_Manual
            // 
            this.RBtn_Manual.AutoSize = true;
            this.RBtn_Manual.Location = new System.Drawing.Point(124, 3);
            this.RBtn_Manual.Name = "RBtn_Manual";
            this.RBtn_Manual.Size = new System.Drawing.Size(68, 17);
            this.RBtn_Manual.TabIndex = 2;
            this.RBtn_Manual.Text = "No Prefix";
            this.RBtn_Manual.UseVisualStyleBackColor = true;
            // 
            // RBtn_https
            // 
            this.RBtn_https.AutoSize = true;
            this.RBtn_https.Checked = true;
            this.RBtn_https.Location = new System.Drawing.Point(57, 4);
            this.RBtn_https.Name = "RBtn_https";
            this.RBtn_https.Size = new System.Drawing.Size(61, 17);
            this.RBtn_https.TabIndex = 1;
            this.RBtn_https.TabStop = true;
            this.RBtn_https.Text = "HTTPS";
            this.RBtn_https.UseVisualStyleBackColor = true;
            // 
            // RBtn_http
            // 
            this.RBtn_http.AutoSize = true;
            this.RBtn_http.Location = new System.Drawing.Point(4, 4);
            this.RBtn_http.Name = "RBtn_http";
            this.RBtn_http.Size = new System.Drawing.Size(54, 17);
            this.RBtn_http.TabIndex = 0;
            this.RBtn_http.Text = "HTTP";
            this.RBtn_http.UseVisualStyleBackColor = true;
            // 
            // Pnl_WhichPC
            // 
            this.Pnl_WhichPC.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Pnl_WhichPC.Controls.Add(this.RBtn_RemotePC);
            this.Pnl_WhichPC.Controls.Add(this.RBtn_ThisPC);
            this.Pnl_WhichPC.Location = new System.Drawing.Point(107, 32);
            this.Pnl_WhichPC.Name = "Pnl_WhichPC";
            this.Pnl_WhichPC.Size = new System.Drawing.Size(95, 45);
            this.Pnl_WhichPC.TabIndex = 5;
            // 
            // RBtn_RemotePC
            // 
            this.RBtn_RemotePC.AutoSize = true;
            this.RBtn_RemotePC.Location = new System.Drawing.Point(6, 23);
            this.RBtn_RemotePC.Name = "RBtn_RemotePC";
            this.RBtn_RemotePC.Size = new System.Drawing.Size(79, 17);
            this.RBtn_RemotePC.TabIndex = 3;
            this.RBtn_RemotePC.Text = "Remote PC";
            this.RBtn_RemotePC.UseVisualStyleBackColor = true;
            // 
            // RBtn_ThisPC
            // 
            this.RBtn_ThisPC.AutoSize = true;
            this.RBtn_ThisPC.Checked = true;
            this.RBtn_ThisPC.Location = new System.Drawing.Point(6, 4);
            this.RBtn_ThisPC.Name = "RBtn_ThisPC";
            this.RBtn_ThisPC.Size = new System.Drawing.Size(62, 17);
            this.RBtn_ThisPC.TabIndex = 2;
            this.RBtn_ThisPC.TabStop = true;
            this.RBtn_ThisPC.Text = "This PC";
            this.RBtn_ThisPC.UseVisualStyleBackColor = true;
            // 
            // Pnl_OpenSiteType
            // 
            this.Pnl_OpenSiteType.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Pnl_OpenSiteType.Controls.Add(this.RBtn_Custom);
            this.Pnl_OpenSiteType.Controls.Add(this.RBtn_Select);
            this.Pnl_OpenSiteType.Location = new System.Drawing.Point(6, 32);
            this.Pnl_OpenSiteType.Name = "Pnl_OpenSiteType";
            this.Pnl_OpenSiteType.Size = new System.Drawing.Size(95, 45);
            this.Pnl_OpenSiteType.TabIndex = 4;
            // 
            // RBtn_Custom
            // 
            this.RBtn_Custom.AutoSize = true;
            this.RBtn_Custom.Location = new System.Drawing.Point(4, 23);
            this.RBtn_Custom.Name = "RBtn_Custom";
            this.RBtn_Custom.Size = new System.Drawing.Size(85, 17);
            this.RBtn_Custom.TabIndex = 1;
            this.RBtn_Custom.Text = "Custom URL";
            this.RBtn_Custom.UseVisualStyleBackColor = true;
            this.RBtn_Custom.CheckedChanged += new System.EventHandler(this.RBtn_Custom_CheckedChanged);
            // 
            // RBtn_Select
            // 
            this.RBtn_Select.AutoSize = true;
            this.RBtn_Select.Checked = true;
            this.RBtn_Select.Location = new System.Drawing.Point(3, 4);
            this.RBtn_Select.Name = "RBtn_Select";
            this.RBtn_Select.Size = new System.Drawing.Size(55, 17);
            this.RBtn_Select.TabIndex = 0;
            this.RBtn_Select.TabStop = true;
            this.RBtn_Select.Text = "Select";
            this.RBtn_Select.UseVisualStyleBackColor = true;
            // 
            // Btn_SiteGo
            // 
            this.Btn_SiteGo.Location = new System.Drawing.Point(5, 3);
            this.Btn_SiteGo.Name = "Btn_SiteGo";
            this.Btn_SiteGo.Size = new System.Drawing.Size(32, 23);
            this.Btn_SiteGo.TabIndex = 3;
            this.Btn_SiteGo.Text = "Go";
            this.Btn_SiteGo.UseVisualStyleBackColor = true;
            this.Btn_SiteGo.Click += new System.EventHandler(this.Btn_SiteGo_Click);
            // 
            // Pnl_IntDocs
            // 
            this.Pnl_IntDocs.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Pnl_IntDocs.Controls.Add(this.Btn_IntDocGo);
            this.Pnl_IntDocs.Controls.Add(this.ComBox_IntDocs);
            this.Pnl_IntDocs.Location = new System.Drawing.Point(232, 222);
            this.Pnl_IntDocs.Name = "Pnl_IntDocs";
            this.Pnl_IntDocs.Size = new System.Drawing.Size(210, 30);
            this.Pnl_IntDocs.TabIndex = 13;
            // 
            // Btn_IntDocGo
            // 
            this.Btn_IntDocGo.Location = new System.Drawing.Point(5, 3);
            this.Btn_IntDocGo.Name = "Btn_IntDocGo";
            this.Btn_IntDocGo.Size = new System.Drawing.Size(32, 23);
            this.Btn_IntDocGo.TabIndex = 1;
            this.Btn_IntDocGo.Text = "Go";
            this.Btn_IntDocGo.UseVisualStyleBackColor = true;
            this.Btn_IntDocGo.Click += new System.EventHandler(this.Btn_IntDocGo_Click);
            // 
            // ComBox_IntDocs
            // 
            this.ComBox_IntDocs.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ComBox_IntDocs.FormattingEnabled = true;
            this.ComBox_IntDocs.Location = new System.Drawing.Point(38, 3);
            this.ComBox_IntDocs.Name = "ComBox_IntDocs";
            this.ComBox_IntDocs.Size = new System.Drawing.Size(169, 21);
            this.ComBox_IntDocs.TabIndex = 0;
            this.ComBox_IntDocs.DropDown += new System.EventHandler(this.ComBox_IntDocs_DropDown);
            this.ComBox_IntDocs.DropDownClosed += new System.EventHandler(this.ComBox_IntDocs_DropDownClosed);
            // 
            // ComBox_Server
            // 
            this.ComBox_Server.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ComBox_Server.FormattingEnabled = true;
            this.ComBox_Server.Location = new System.Drawing.Point(17, 58);
            this.ComBox_Server.Name = "ComBox_Server";
            this.ComBox_Server.Size = new System.Drawing.Size(130, 21);
            this.ComBox_Server.TabIndex = 1;
            // 
            // Btn_CHFSSearch
            // 
            this.Btn_CHFSSearch.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.Btn_CHFSSearch.Location = new System.Drawing.Point(458, 531);
            this.Btn_CHFSSearch.Name = "Btn_CHFSSearch";
            this.Btn_CHFSSearch.Size = new System.Drawing.Size(91, 23);
            this.Btn_CHFSSearch.TabIndex = 20;
            this.Btn_CHFSSearch.Text = "CHFS Search";
            this.Btn_CHFSSearch.UseVisualStyleBackColor = true;
            this.Btn_CHFSSearch.Visible = false;
            this.Btn_CHFSSearch.Click += new System.EventHandler(this.Btn_CHFSSearch_Click);
            // 
            // Btn_SecondayPC
            // 
            this.Btn_SecondayPC.Location = new System.Drawing.Point(21, 314);
            this.Btn_SecondayPC.Name = "Btn_SecondayPC";
            this.Btn_SecondayPC.Size = new System.Drawing.Size(91, 23);
            this.Btn_SecondayPC.TabIndex = 22;
            this.Btn_SecondayPC.Text = "MDT / iRequest";
            this.Btn_SecondayPC.UseVisualStyleBackColor = true;
            this.Btn_SecondayPC.Visible = false;
            this.Btn_SecondayPC.Click += new System.EventHandler(this.Btn_SecondayPC_Click);
            // 
            // Btn_RemExec
            // 
            this.Btn_RemExec.Location = new System.Drawing.Point(126, 315);
            this.Btn_RemExec.Name = "Btn_RemExec";
            this.Btn_RemExec.Size = new System.Drawing.Size(91, 23);
            this.Btn_RemExec.TabIndex = 26;
            this.Btn_RemExec.Text = "Remote Exec";
            this.Btn_RemExec.UseVisualStyleBackColor = true;
            this.Btn_RemExec.Visible = false;
            this.Btn_RemExec.Click += new System.EventHandler(this.Btn_RemExec_Click);
            // 
            // Btn_PrinterSearch
            // 
            this.Btn_PrinterSearch.Location = new System.Drawing.Point(555, 532);
            this.Btn_PrinterSearch.Name = "Btn_PrinterSearch";
            this.Btn_PrinterSearch.Size = new System.Drawing.Size(91, 23);
            this.Btn_PrinterSearch.TabIndex = 27;
            this.Btn_PrinterSearch.Text = "Printer Search";
            this.Btn_PrinterSearch.UseVisualStyleBackColor = true;
            this.Btn_PrinterSearch.Visible = false;
            this.Btn_PrinterSearch.Click += new System.EventHandler(this.Btn_PrinterSearch_Click);
            // 
            // TxtBox_Output
            // 
            this.TxtBox_Output.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.TxtBox_Output.Location = new System.Drawing.Point(12, 379);
            this.TxtBox_Output.Multiline = true;
            this.TxtBox_Output.Name = "TxtBox_Output";
            this.TxtBox_Output.ReadOnly = true;
            this.TxtBox_Output.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.TxtBox_Output.Size = new System.Drawing.Size(427, 146);
            this.TxtBox_Output.TabIndex = 22;
            // 
            // Btn_LANDeskWeb
            // 
            this.Btn_LANDeskWeb.Location = new System.Drawing.Point(116, 98);
            this.Btn_LANDeskWeb.Name = "Btn_LANDeskWeb";
            this.Btn_LANDeskWeb.Size = new System.Drawing.Size(94, 23);
            this.Btn_LANDeskWeb.TabIndex = 3;
            this.Btn_LANDeskWeb.Text = "LANDesk Web";
            this.Btn_LANDeskWeb.UseVisualStyleBackColor = true;
            this.Btn_LANDeskWeb.Click += new System.EventHandler(this.Btn_LANDeskWeb_Click);
            // 
            // WaitToPing
            // 
            this.WaitToPing.Interval = 1000;
            this.WaitToPing.Tick += new System.EventHandler(this.WaitToPing_Tick);
            // 
            // Btn_CleanPrinters
            // 
            this.Btn_CleanPrinters.Location = new System.Drawing.Point(24, 343);
            this.Btn_CleanPrinters.Name = "Btn_CleanPrinters";
            this.Btn_CleanPrinters.Size = new System.Drawing.Size(94, 23);
            this.Btn_CleanPrinters.TabIndex = 21;
            this.Btn_CleanPrinters.Text = "Clean Printers";
            this.Btn_CleanPrinters.UseVisualStyleBackColor = true;
            this.Btn_CleanPrinters.Click += new System.EventHandler(this.Btn_CleanPrinters_Click);
            // 
            // Btn_ClearOutput
            // 
            this.Btn_ClearOutput.Location = new System.Drawing.Point(12, 531);
            this.Btn_ClearOutput.Name = "Btn_ClearOutput";
            this.Btn_ClearOutput.Size = new System.Drawing.Size(78, 23);
            this.Btn_ClearOutput.TabIndex = 23;
            this.Btn_ClearOutput.Text = "Clear Output";
            this.Btn_ClearOutput.UseVisualStyleBackColor = true;
            this.Btn_ClearOutput.Click += new System.EventHandler(this.Btn_ClearOutput_Click);
            // 
            // Btn_ChangeBrowser
            // 
            this.Btn_ChangeBrowser.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Btn_ChangeBrowser.Location = new System.Drawing.Point(123, 343);
            this.Btn_ChangeBrowser.Name = "Btn_ChangeBrowser";
            this.Btn_ChangeBrowser.Size = new System.Drawing.Size(97, 23);
            this.Btn_ChangeBrowser.TabIndex = 28;
            this.Btn_ChangeBrowser.Text = "Change Browser";
            this.Btn_ChangeBrowser.UseVisualStyleBackColor = true;
            this.Btn_ChangeBrowser.Click += new System.EventHandler(this.Btn_ChangeBrowser_Click);
            // 
            // ComBox_VMs
            // 
            this.ComBox_VMs.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ComBox_VMs.FormattingEnabled = true;
            this.ComBox_VMs.Location = new System.Drawing.Point(17, 128);
            this.ComBox_VMs.Name = "ComBox_VMs";
            this.ComBox_VMs.Size = new System.Drawing.Size(116, 21);
            this.ComBox_VMs.TabIndex = 29;
            this.ComBox_VMs.DropDown += new System.EventHandler(this.ComBox_VMs_DropDown);
            this.ComBox_VMs.SelectedIndexChanged += new System.EventHandler(this.ComBox_VMs_SelectedIndexChanged);
            this.ComBox_VMs.DropDownClosed += new System.EventHandler(this.ComBox_VMs_DropDownClosed);
            // 
            // TxtBox_Notes
            // 
            this.TxtBox_Notes.Location = new System.Drawing.Point(458, 12);
            this.TxtBox_Notes.Multiline = true;
            this.TxtBox_Notes.Name = "TxtBox_Notes";
            this.TxtBox_Notes.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.TxtBox_Notes.Size = new System.Drawing.Size(338, 513);
            this.TxtBox_Notes.TabIndex = 30;
            // 
            // PicBox_Main
            // 
            this.PicBox_Main.Location = new System.Drawing.Point(356, 6);
            this.PicBox_Main.Name = "PicBox_Main";
            this.PicBox_Main.Size = new System.Drawing.Size(84, 80);
            this.PicBox_Main.TabIndex = 31;
            this.PicBox_Main.TabStop = false;
            // 
            // Btn_ShowNotes
            // 
            this.Btn_ShowNotes.Location = new System.Drawing.Point(419, 93);
            this.Btn_ShowNotes.Name = "Btn_ShowNotes";
            this.Btn_ShowNotes.Size = new System.Drawing.Size(21, 23);
            this.Btn_ShowNotes.TabIndex = 32;
            this.Btn_ShowNotes.Text = ">";
            this.Btn_ShowNotes.UseVisualStyleBackColor = true;
            this.Btn_ShowNotes.Click += new System.EventHandler(this.Btn_ShowNotes_Click);
            // 
            // Btn_Ping
            // 
            this.Btn_Ping.Location = new System.Drawing.Point(137, 34);
            this.Btn_Ping.Name = "Btn_Ping";
            this.Btn_Ping.Size = new System.Drawing.Size(10, 22);
            this.Btn_Ping.TabIndex = 33;
            this.Btn_Ping.UseVisualStyleBackColor = true;
            this.Btn_Ping.Click += new System.EventHandler(this.Btn_Ping_Click);
            // 
            // Btn_RCViewer
            // 
            this.Btn_RCViewer.Location = new System.Drawing.Point(232, 99);
            this.Btn_RCViewer.Name = "Btn_RCViewer";
            this.Btn_RCViewer.Size = new System.Drawing.Size(94, 23);
            this.Btn_RCViewer.TabIndex = 34;
            this.Btn_RCViewer.Text = "RCViewer";
            this.Btn_RCViewer.UseVisualStyleBackColor = true;
            this.Btn_RCViewer.Click += new System.EventHandler(this.Btn_RCViewer_Click);
            // 
            // Btn_Customize
            // 
            this.Btn_Customize.Location = new System.Drawing.Point(346, 531);
            this.Btn_Customize.Name = "Btn_Customize";
            this.Btn_Customize.Size = new System.Drawing.Size(94, 23);
            this.Btn_Customize.TabIndex = 35;
            this.Btn_Customize.Text = "Customize";
            this.Btn_Customize.UseVisualStyleBackColor = true;
            this.Btn_Customize.Click += new System.EventHandler(this.Btn_Customize_Click);
            // 
            // Btn_LANDesk
            // 
            this.Btn_LANDesk.Location = new System.Drawing.Point(17, 98);
            this.Btn_LANDesk.Name = "Btn_LANDesk";
            this.Btn_LANDesk.Size = new System.Drawing.Size(94, 23);
            this.Btn_LANDesk.TabIndex = 36;
            this.Btn_LANDesk.Text = "LANDesk";
            this.Btn_LANDesk.UseVisualStyleBackColor = true;
            this.Btn_LANDesk.Click += new System.EventHandler(this.Btn_LANDesk_Click);
            // 
            // CTxtBox_LName
            // 
            this.CTxtBox_LName.AutoClear = false;
            this.CTxtBox_LName.DefaultText = null;
            this.CTxtBox_LName.Location = new System.Drawing.Point(117, 0);
            this.CTxtBox_LName.Name = "CTxtBox_LName";
            this.CTxtBox_LName.Size = new System.Drawing.Size(85, 20);
            this.CTxtBox_LName.TabIndex = 2;
            this.CTxtBox_LName.Text = "Last Name";
            // 
            // CTxtBox_Email
            // 
            this.CTxtBox_Email.AutoClear = false;
            this.CTxtBox_Email.DefaultText = null;
            this.CTxtBox_Email.Location = new System.Drawing.Point(22, 55);
            this.CTxtBox_Email.Name = "CTxtBox_Email";
            this.CTxtBox_Email.Size = new System.Drawing.Size(180, 20);
            this.CTxtBox_Email.TabIndex = 1;
            this.CTxtBox_Email.Text = "Email Address";
            // 
            // CTxtBox_FName
            // 
            this.CTxtBox_FName.AutoClear = false;
            this.CTxtBox_FName.DefaultText = null;
            this.CTxtBox_FName.Location = new System.Drawing.Point(22, 0);
            this.CTxtBox_FName.Name = "CTxtBox_FName";
            this.CTxtBox_FName.Size = new System.Drawing.Size(85, 20);
            this.CTxtBox_FName.TabIndex = 1;
            this.CTxtBox_FName.Text = "First Name";
            // 
            // CTxtBox_UserName
            // 
            this.CTxtBox_UserName.AutoClear = false;
            this.CTxtBox_UserName.DefaultText = null;
            this.CTxtBox_UserName.Location = new System.Drawing.Point(22, 39);
            this.CTxtBox_UserName.Name = "CTxtBox_UserName";
            this.CTxtBox_UserName.Size = new System.Drawing.Size(180, 20);
            this.CTxtBox_UserName.TabIndex = 1;
            this.CTxtBox_UserName.Text = "UserName";
            // 
            // Form_MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(805, 567);
            this.Controls.Add(this.Btn_LANDesk);
            this.Controls.Add(this.Btn_Customize);
            this.Controls.Add(this.Btn_RCViewer);
            this.Controls.Add(this.Btn_Ping);
            this.Controls.Add(this.Btn_ShowNotes);
            this.Controls.Add(this.PicBox_Main);
            this.Controls.Add(this.TxtBox_Notes);
            this.Controls.Add(this.ComBox_VMs);
            this.Controls.Add(this.Btn_ChangeBrowser);
            this.Controls.Add(this.Btn_ClearOutput);
            this.Controls.Add(this.Btn_CleanPrinters);
            this.Controls.Add(this.Btn_LANDeskWeb);
            this.Controls.Add(this.TxtBox_Output);
            this.Controls.Add(this.Btn_RemExec);
            this.Controls.Add(this.Btn_PrinterSearch);
            this.Controls.Add(this.ComBox_Server);
            this.Controls.Add(this.Pnl_IntDocs);
            this.Controls.Add(this.Pnl_OpenSite);
            this.Controls.Add(this.Btn_CHFSSearch);
            this.Controls.Add(this.Pnl_User);
            this.Controls.Add(this.Btn_SecondayPC);
            this.Controls.Add(this.Pnl_CompMang);
            this.Controls.Add(this.Btn_WinRDP);
            this.Controls.Add(this.Lbl_IP);
            this.Controls.Add(this.Lbl_PingStatus);
            this.Controls.Add(this.Lbl_UserName);
            this.Controls.Add(this.TxtBox_CompName);
            this.Controls.Add(this.Lbl_CompName);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "Form_MainForm";
            this.Text = "CAdminTools";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form_MainForm_FormClosing);
            this.Load += new System.EventHandler(this.Form_MainForm_Load);
            this.Pnl_CompMang.ResumeLayout(false);
            this.Pnl_User.ResumeLayout(false);
            this.Pnl_User.PerformLayout();
            this.Pnl_OpenSite.ResumeLayout(false);
            this.Pnl_OpenSitePrefix.ResumeLayout(false);
            this.Pnl_OpenSitePrefix.PerformLayout();
            this.Pnl_WhichPC.ResumeLayout(false);
            this.Pnl_WhichPC.PerformLayout();
            this.Pnl_OpenSiteType.ResumeLayout(false);
            this.Pnl_OpenSiteType.PerformLayout();
            this.Pnl_IntDocs.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.PicBox_Main)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label Lbl_CompName;
        private System.Windows.Forms.TextBox TxtBox_CompName;
        private System.Windows.Forms.Button Btn_WinRDP;
        private System.Windows.Forms.Button Btn_Logoff;
        private System.Windows.Forms.Button Btn_Uptime;
        private System.Windows.Forms.Button Btn_PCMange;
        private System.Windows.Forms.Button Btn_RemoteC;
        private System.Windows.Forms.Button Btn_Processes;
        private System.Windows.Forms.Button Btn_Printers;
        private System.Windows.Forms.Button Btn_PCInfo;
        private System.Windows.Forms.Button Btn_Restart;
        private System.Windows.Forms.Label Lbl_UserName;
        private System.Windows.Forms.Label Lbl_PingStatus;
        private System.Windows.Forms.Label Lbl_IP;
        private System.Windows.Forms.Label Lbl_ManageUser;
        private System.Windows.Forms.CheckBox CkBox_IAM;
        private System.Windows.Forms.CheckBox CkBox_ARS;
        private System.Windows.Forms.Button Btn_ChangeNameType;
        private System.Windows.Forms.Panel Pnl_CompMang;
        private System.Windows.Forms.Panel Pnl_User;
        private System.Windows.Forms.Button Btn_UserLookUp;
        private System.Windows.Forms.ComboBox ComBox_OpenSite;
        private System.Windows.Forms.Panel Pnl_OpenSite;
        private System.Windows.Forms.Button Btn_SiteGo;
        private System.Windows.Forms.Panel Pnl_IntDocs;
        private System.Windows.Forms.Button Btn_IntDocGo;
        private System.Windows.Forms.ComboBox ComBox_IntDocs;
        private System.Windows.Forms.ComboBox ComBox_Server;
        private System.Windows.Forms.Button Btn_CHFSSearch;
        private System.Windows.Forms.Button Btn_SecondayPC;
        private System.Windows.Forms.Button Btn_RemExec;
        private System.Windows.Forms.Button Btn_PrinterSearch;
        private System.Windows.Forms.TextBox TxtBox_Output;
        private System.Windows.Forms.Button Btn_LANDeskWeb;
        private System.Windows.Forms.Timer WaitToPing;
        private System.Windows.Forms.Button Btn_CleanPrinters;
        private System.Windows.Forms.Button Btn_ClearOutput;
        private ClearTextBox CTxtBox_UserName;
        private ClearTextBox CTxtBox_LName;
        private ClearTextBox CTxtBox_Email;
        private ClearTextBox CTxtBox_FName;
        private System.Windows.Forms.Button Btn_ChangeBrowser;
        private System.Windows.Forms.ComboBox ComBox_VMs;
        private System.Windows.Forms.TextBox TxtBox_Notes;
        private System.Windows.Forms.PictureBox PicBox_Main;
        private System.Windows.Forms.Button Btn_ShowNotes;
        private System.Windows.Forms.Button Btn_Ping;
        private System.Windows.Forms.Button Btn_RCViewer;
        private System.Windows.Forms.Button Btn_Customize;
        private System.Windows.Forms.Panel Pnl_OpenSitePrefix;
        private System.Windows.Forms.RadioButton RBtn_Manual;
        private System.Windows.Forms.RadioButton RBtn_https;
        private System.Windows.Forms.RadioButton RBtn_http;
        private System.Windows.Forms.Panel Pnl_WhichPC;
        private System.Windows.Forms.RadioButton RBtn_RemotePC;
        private System.Windows.Forms.RadioButton RBtn_ThisPC;
        private System.Windows.Forms.Panel Pnl_OpenSiteType;
        private System.Windows.Forms.RadioButton RBtn_Custom;
        private System.Windows.Forms.RadioButton RBtn_Select;
        private System.Windows.Forms.Button Btn_LANDesk;
    }
}

