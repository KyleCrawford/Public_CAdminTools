 
/*******************************************************

Program: CAdminTools

Description: A tool designed to be used by the AHS IT Service Desk to bring useful tools, documents and websites to the fingertips
            of an AHS IT support tech.

Author: Kyle Crawford

*******************************************************/
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Diagnostics;
using System.Drawing;
using System.Xml;
using System.Drawing.Imaging;

namespace CAdminTools
{
    // general delegate used to provide other forms to write to the main form's output
    public delegate void delvoidstring(string s);
    // General delegate with no inputs or outputs. Mainly used for safe invoking
    public delegate void delvoidvoid();
    
    /// <summary>
    /// Main form for the CAdminTools app to hold all and is the main interface of the application
    /// </summary>
    /// This page holds all the global variable declarations, properties, Contructors, and events for the main form
    public partial class Form_MainForm : Form
    {
        //delegate to provide safe access to updating a label
        private delegate void delWriteLabel(Label l, string s);

        private delegate void delColourLabel(Label l, Color c);

        //Holds the Internal Documents - Key: Shotcut Name, Value: URL
        private Dictionary<string, string> _intDocDic = null;

        //Holds the list of sites that can be opened - Key: Shotcut Name, Value: URL
        private Dictionary<string, string> _openSiteDic = null;

        //The IAM browser search form. Global to keep reference to just one form.
        private IAMBrowserForm _IAMBrowser;

        /// <summary>
        /// Used to pass arguments to a callback method
        /// isLogOff is true if logging off, false if restarting computer
        /// compName is the computer name to attempt action
        /// </summary>


        private PSToolsCS _pSTools;

        

        //Public delegate to provide access to other forms to write to the main forms output textbox
        public delvoidstring DelPassToOutput;

        // The application settings that holds important information for several functions within the program
        private readonly AppSettings _settings;


        //public gets to provide access to values loaded in from xml file to the other forms
        public string IAMUserNameID
        {
            get => _settings.IAMUserNameID; 
        }

        public string IAMFirstNameID
        {
            get => _settings.IAMFirstNameID; 
        }

        public string IAMLastNameID
        {
            get => _settings.IAMLastNameID; 
        }

        public string IAMEmailID
        {
            get => _settings.IAMEmailID; 
        }

        public string IAMGoButtonID
        {
            get => _settings.IAMGoButtonID; 
        }

        public string IAMLoginSite
        {
            get => _settings.IAMLoginPage; 
        }
        
        public string IAMHomeSite
        {
            get => _settings.IAMHomePage; 
        }

        public string IAMPasswordSite
        {
            get => _settings.IAMPWordResetPage; 
        }

        public string LocalSettingsPath
        {
            get => _settings.LocalSettingsSavePath;
        }

        //CustomiseVisuals cv = new CustomiseVisuals();
        public void ChangeVisuals(CustomiseVisuals cv)
        {
            
        }


        int _formWidth;

        /// <summary>
        /// Initializes main form components and loads in application settings
        /// </summary>
        public Form_MainForm()
        {
            InitializeComponent();

            _settings = new AppSettings();


            ///////////
            ///
            //ComBox_VMs.Items.Add("vdwrkstn0291");

            this.Width = this.Width - TxtBox_Notes.Width - 15;
            _formWidth = this.Width;


            //  Bitmap bmp = new Bitmap(CAdminTools.Properties.Resources.AHSPng_86x80NB);

            // bmp.MakeTransparent(Color.FromKnownColor(KnownColor.Control));

            // PicBox_Main.Image = bmp;
            PicBox_Main.BackColor = Color.Transparent;
            PicBox_Main.Image = CAdminTools.Properties.Resources.AHSPng_86x80NB;

            _pSTools = new PSToolsCS(Environment.CurrentDirectory + @"\PSTools");
            _pSTools.LookupFinished += PSReturn;

            WindowsFunctions.OutputPrinting += PrintReturn;

            
        }

        /// <summary>
        /// When the main form is loaded, attempt to load the application settings, and initialize the main form values.
        /// </summary>
        /// <param name="sender"> this form </param>
        /// <param name="e"></param>
        private void Form_MainForm_Load(object sender, EventArgs e)
        {

            if (_settings.LoadSettings(Environment.CurrentDirectory))
            {
                //Settings loaded successfully
                PrintOutput("Settings Loaded");
            }
            else
            {
                MessageBox.Show("Default settings applied. Some functions may not work properly");
            }
            Init();

            LoadCustomisation();
        }

        private void LoadCustomisation()
        {
            //so... here we need to load all the settings in here.


            //SaveDefaultVisualsProfile();

            CustomiseVisuals visuals = new CustomiseVisuals(this);
            visuals.LoadProfile();

        }



        private void SaveDefaultVisualsProfile()
        {
            XmlDocument xmldoc = new XmlDocument();
            xmldoc.Load(_settings.LocalSettingsSavePath + @"\LocalSettings.xml");
            
            /*
            if (xmldoc.SelectSingleNode("//Customisation") == null)
            {
                //no profile exists, gotta create xml from scratch
                XmlNode settingsRoot = xmldoc.SelectSingleNode("//LocalSettings");

                XmlElement customisation = xmldoc.CreateElement("Customisation");
                settingsRoot.AppendChild(customisation);

                XmlElement visualsProfile = xmldoc.CreateElement("VisualsProfile");
                customisation.AppendChild(visualsProfile);

                XmlElement formColour = xmldoc.CreateElement("FormColour");

            }
            else
            {
                //modify values
            }
            */
            
            
            
            
            
            
            //XmlNode settingsRoot = xmldoc.SelectSingleNode("//LocalSettings");

            //XmlElement customisation = xmldoc.CreateElement("Customisation");
            //settingsRoot.AppendChild(customisation);

            XmlElement defaultProfile = xmldoc.CreateElement("DefaultProfile");
            //customisation.AppendChild(defaultProfile);
            
            XmlElement formColour = xmldoc.CreateElement("FormColour");
            formColour.InnerText = this.BackColor.ToArgb().ToString();


            XmlElement formImage = xmldoc.CreateElement("FormImage");
            formImage.InnerText = "";



            //XmlAttribute opacity = xmldoc.CreateAttribute("Form");


            defaultProfile.AppendChild(formColour);
            defaultProfile.AppendChild(formImage);


            //xmldoc.AppendChild(settingsRoot);

            xmldoc.Save(_settings.LocalSettingsSavePath + @"\LocalSettings.xml");






            /*
            XmlDocument xlDoc = new XmlDocument();
            xlDoc.Load(_settings.LocalSettingsSavePath + @"\LocalSettings.xml");
            //xlDoc.SelectSingleNode("")
            //create the profile xml
            XmlElement rootNode = xlDoc.CreateElement("Customisation");
            xlDoc.AppendChild(rootNode);

            XmlNode defaultProfile = xlDoc.CreateElement("DefaultProfile");
            rootNode.AppendChild(defaultProfile);

            XmlNode formColour = xlDoc.CreateElement("FormColour");
            formColour.InnerText = Color.FromKnownColor(KnownColor.Control).ToArgb().ToString();
            defaultProfile.AppendChild(formColour);

            XmlNode formPic = xlDoc.CreateElement("FormPicture");
            formPic.InnerText = this.BackgroundImage.ToString();
            defaultProfile.AppendChild(formColour);
            */


        }


        /// <summary>
        /// When the textbox is changed, clears the labels and checks if there is text
        /// if there is text, starts a timer. If this timer ticks before another key is pressed in the textbox. Begins pinging.
        /// </summary>
        /// <param name="sender"> Textbox </param>
        /// <param name="e"></param>
        private void TxtBox_CompName_TextChanged(object sender, EventArgs e)
        {
              if (ComBox_VMs.SelectedIndex >= 0 &&
                ComBox_VMs.SelectedItem.ToString() != "Virtual Machines" &&
                _settings.VirtualMachines[ComBox_VMs.SelectedItem.ToString()] != TxtBox_CompName.Text)
            {
                ComBox_VMs.SelectedIndex = -1;
                ComBox_VMs.Items.Add("Virtual Machines");
                ComBox_VMs.SelectedItem = "Virtual Machines";
            }

            if (Lbl_PingStatus.Text != "")
            {
                Lbl_PingStatus.Text = "";
                Lbl_IP.Text = "";
                Lbl_UserName.Text = "";
            }

            //if the textbox is empty, do nothing
            if (TxtBox_CompName.Text.Trim() == "")
                return;

            //start the timer to wait to begin the ping

            //check if it is already running
            if (!WaitToPing.Enabled)
            {
                //not running, start running
                WaitToPing.Enabled = true;
                WaitToPing.Start();
            }
            else
            {
                //is running, reset the timer
                WaitToPing.Stop();
                WaitToPing.Start();
            }
        }

        private void Btn_Ping_Click(object sender, EventArgs e)
        {
            if (TxtBox_CompName.Text.Trim() == "")
            {
                return;
            }
            Lbl_PingStatus.Text = "Pinging...";
            Lbl_PingStatus.ForeColor = Color.Black;
            Lbl_IP.Text = "";
            Lbl_UserName.Text = "";
            PingTarget(TxtBox_CompName.Text.Trim());
        }

        /// <summary>
        /// Attempts to ping with the provided text in the TxtBox_CompName textbox
        /// </summary>
        /// <param name="sender"> timer </param>
        /// <param name="e"></param>
        private void WaitToPing_Tick(object sender, EventArgs e)
        {
            //ping
            Lbl_PingStatus.Text = "Pinging...";
            Lbl_PingStatus.ForeColor = Color.Black;
            PingTarget(TxtBox_CompName.Text.Trim());

            //stop us,
            WaitToPing.Stop();
        }

        /// <summary>
        /// Attempts to launch the local LANDesk to connect to the computer name in TxtBox_CompName
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Btn_LANDesk_Click(object sender, EventArgs e)
        {
            if (TextBoxCheck(TxtBox_CompName))
            {
                PrintOutput("Opening Local LANDesk to remote to " + TxtBox_CompName.Text);
                WindowsFunctions.RunLANDesk(ComBox_Server.SelectedItem.ToString(), TxtBox_CompName.Text);
            }
        }

        /// <summary>
        /// Attempts to launch the web LANDesk to connect to the computer name in TxtBox_CompName
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Btn_LANDeskWeb_Click(object sender, EventArgs e)
        {
            //check if the user has set their web preference
            if (_settings.UserDefaultBrowser == string.Empty)
            {
                //need to set the default browser for the user
                SetDefaultBrowser();

            }

            if (TextBoxCheck(TxtBox_CompName))
            {
                PrintOutput(WindowsFunctions.RunLANDeskWeb(TxtBox_CompName.Text, _settings.UserDefaultBrowser));
            }
        }

        /// <summary>
        /// Prompts to user to select the default browser. If sucessesful, saves the value, and writes the local XML settings file
        /// </summary>
        private void SetDefaultBrowser()
        {
            string selectedBrowser = PromptToSelectDefaultBrowser(_settings.AllBrowsers);

            if (string.IsNullOrEmpty(selectedBrowser))
            {
                return;
            }
            else
            {
                _settings.UserDefaultBrowser = selectedBrowser;
                UpdateDefaultBrowser(selectedBrowser);
            }
        }

        /// <summary>
        /// Attempts to launch Windows RDP to connect to the computer name i TxtBox_CompName
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Btn_WinRDP_Click(object sender, EventArgs e)
        {
            if (TextBoxCheck(TxtBox_CompName))
            {
                PrintOutput("Opening Windows RDP to computer " + TxtBox_CompName.Text);
                WindowsFunctions.RunWinRDP(TxtBox_CompName.Text);
            }
        }

        

        /// <summary>
        /// Attempts to get the current uptime for the computer name in TxtBox_CompName
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Btn_Uptime_Click(object sender, EventArgs e)
        {
            if (TextBoxCheck(TxtBox_CompName))
            {
                PrintOutput("Querying for computer uptime");
                _pSTools.GetUpTime(TxtBox_CompName.Text);
            }
        }



        /// <summary>
        /// Attempts to get the PSTools PSInfo from the computer name in TxtBox_CompName
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Btn_PCInfo_Click(object sender, EventArgs e)
        {
            if (TextBoxCheck(TxtBox_CompName))
            {
                PrintOutput("Querying for computer information");
                _pSTools.GetPCInfo(TxtBox_CompName.Text);
            }
        }

        /// <summary>
        /// Attempts to log any user logged into the computer name in TxtBox_CompName
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Btn_Logoff_Click(object sender, EventArgs e)
        {
            if (!TextBoxCheck(TxtBox_CompName))
            {
                return;
            }

            if (MessageBox.Show("are you sure you want to log all users off " + TxtBox_CompName.Text, "Log Off?", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.No)
            {
                return;
            }

            PrintOutput("Attempting to log users off");
            WindowsFunctions.RemoteLogOfforRestart(true, TxtBox_CompName.Text);
        }

        /// <summary>
        /// Attempts to restart the computer name in TxtBox_CompName
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Btn_Restart_Click(object sender, EventArgs e)
        {
            if (!TextBoxCheck(TxtBox_CompName))
            {
                return;
            }

            if (MessageBox.Show("are you sure you want to restart " + TxtBox_CompName.Text, "Restart?", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.No)
            {
                return;
            }

            PrintOutput("Attempting to restart computer " + TxtBox_CompName.Text);
            WindowsFunctions.RemoteLogOfforRestart(false, TxtBox_CompName.Text);
        }

        /// <summary>
        /// Attempts to open the Windows Computer Management windows for the computer name in TxtBox_CompName
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Btn_PCMange_Click(object sender, EventArgs e)
        {
            if (TextBoxCheck(TxtBox_CompName))
            {
                PrintOutput("Opening Computer Management for " + TxtBox_CompName.Text);
                WindowsFunctions.RunPCManage(TxtBox_CompName.Text);
            }
        }

        /// <summary>
        /// Opens the Processes form to attempt to view the processes running on the computer name in TxtBox_CompName
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Btn_Processes_Click(object sender, EventArgs e)
        {
            ProcessesForm procForm = new ProcessesForm(this, TxtBox_CompName.Text);

            procForm.Show();
        }

        /// <summary>
        /// Attempts to open File Explorer to the computer name in TxtBox_CompName's C: drive
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Btn_RemoteC_Click(object sender, EventArgs e)
        {
            if (TextBoxCheck(TxtBox_CompName))
            {
                PrintOutput("Opening File Explorer for " + TxtBox_CompName.Text);
                WindowsFunctions.OpenRemoteC(TxtBox_CompName.Text);
            }
        }

        /// <summary>
        /// Toggles between the various different ClearTextBoxes for various search criteria
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Btn_ChangeNameType_Click(object sender, EventArgs e)
        {

            if (CTxtBox_UserName.Visible == true)
            {
                CTxtBox_UserName.Hide();
                CTxtBox_UserName.SetDefaultText();
                CTxtBox_FName.Show();
                CTxtBox_LName.Show();
            }

            else if (CTxtBox_FName.Visible == true)
            {
                CTxtBox_FName.Hide();
                CTxtBox_FName.SetDefaultText();
                CTxtBox_LName.Hide();
                CTxtBox_LName.SetDefaultText();
                CTxtBox_Email.Show();
            }

            else if (CTxtBox_Email.Visible == true)
            {
                CTxtBox_Email.Hide();
                CTxtBox_Email.SetDefaultText();
                CTxtBox_UserName.Show();
            }

            else
            {
                //there is an error 
            }

        }

        /// <summary>
        /// Attempts to look up the provided user in one or more of the ClearTextBoxes in IAM and/or ARS
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Btn_UserLookUp_Click(object sender, EventArgs e)
        {
            if (CkBox_ARS.Checked)
            {
                if (CTxtBox_UserName.Visible)
                {
                    ARSSearchUser(CTxtBox_UserName.Text.Trim());
                }
                else if (CTxtBox_Email.Visible)
                {
                    ARSSearchUser(CTxtBox_Email.Text.Trim());
                }
                else
                {
                    ARSSearchUser(CTxtBox_FName.Text, CTxtBox_LName.Text);
                }
                PrintOutput("Searching User in ARS");
            }

            if (CkBox_IAM.Checked)
            {
                if (_IAMBrowser.WindowState == FormWindowState.Minimized)
                {
                    _IAMBrowser.WindowState = FormWindowState.Normal;
                }
                _IAMBrowser.LoadIAM();
                _IAMBrowser.Show();
                //_IAMBrowser.Focus();
            }

        }

        /// <summary>
        /// When the list is opened, if the default value is there, removes in.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ComBox_OpenSite_DropDown(object sender, EventArgs e)
        {
            if (ComBox_OpenSite.Items.Contains("Open Site"))
            {
                ComBox_OpenSite.Items.Remove("Open Site");
            }
        }

        /// <summary>
        /// When the list is closed, if no value is selected, add the default value back and set it as selected
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ComBox_OpenSite_DropDownClosed(object sender, EventArgs e)
        {
            if (ComBox_OpenSite.SelectedIndex < 0)
            {
                ComBox_OpenSite.Items.Add("Open Site");
                ComBox_OpenSite.SelectedItem = "Open Site";
            }
        }

        /// <summary>
        /// Attempts to open the selected website from the OpenSite control on the local and/or remote computer
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Btn_SiteGo_Click(object sender, EventArgs e)
        {
            if (ComBox_OpenSite.Text == "Open Site" || ComBox_OpenSite.Text == "Enter URL")
            {
                MessageBox.Show("Please select or type a website");
                return;
            }
            if (RBtn_RemotePC.Checked)
            {
                if (!TextBoxCheck(TxtBox_CompName))
                {
                    return;
                }
            }

            OpenSite(RBtn_RemotePC.Checked, TxtBox_CompName.Text);
 
        }

        /// <summary>
        /// When the list is opened, if the default value is there, remove it
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ComBox_IntDocs_DropDown(object sender, EventArgs e)
        {
            if (ComBox_IntDocs.Items.Contains("Open Document"))
            {
                ComBox_IntDocs.Items.Remove("Open Document");
            }
        }

        /// <summary>
        /// When the list closes, if no value is selected, add the default value back and set it as selected
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ComBox_IntDocs_DropDownClosed(object sender, EventArgs e)
        {
            if (ComBox_IntDocs.SelectedIndex < 0)
            {
                ComBox_IntDocs.Items.Add("Open Document");
                ComBox_IntDocs.SelectedItem = "Open Document";
            }
        }
        
        /// <summary>
        /// Attempts to open the selected document from the IntDocs controls on the local computer
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Btn_IntDocGo_Click(object sender, EventArgs e)
        {
            OpenInternalDoc();
        }

        /// <summary>
        /// Runs a PowerShell script that removes all network printers from the computer and adds a default printer back
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Btn_CleanPrinters_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to delete all the printers on your computer (adds CNTIS60 back as default)", "Delete Printers?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                return;
            }

            Process p = new Process();
            p.StartInfo.FileName = "powershell.exe";
            p.StartInfo.Arguments = "-file " + Environment.CurrentDirectory + @"\CleanPrinters.ps1";
            p.StartInfo.RedirectStandardOutput = true;
            p.StartInfo.RedirectStandardError = true;
            p.StartInfo.UseShellExecute = false;
            p.StartInfo.CreateNoWindow = true;

            p.Start();
        }

        /// <summary>
        /// Clears the Output Textbox text
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Btn_ClearOutput_Click(object sender, EventArgs e)
        {
            TxtBox_Output.Clear();
        }

        /// <summary>
        /// Prompts the user the select a new default browser
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Btn_ChangeBrowser_Click(object sender, EventArgs e)
        {
            SetDefaultBrowser();
        }

        /// <summary>
        /// Dispose of objects when the form is closing
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form_MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            _IAMBrowser.Dispose();

            if (System.IO.File.Exists(_settings.LocalSettingsSavePath + @"\LocalNotes.txt"))
            {
                SaveLocalFiles(_settings.LocalSettingsSavePath);
            }
            



        }

        ///Beyond here be test code. Ye be warned!

        private void Btn_Printers_Click(object sender, EventArgs e)
        {
            if (TextBoxCheck(TxtBox_CompName))
            {
                AvailablePrinters(TxtBox_CompName.Text);
            }
        }



        //testing the PSExec Class
        private void Btn_RemExec_Click(object sender, EventArgs e)
        {
            PSToolsCS PSTools = new PSToolsCS(Environment.CurrentDirectory + @"\PSTools");

            PSTools.LookupFinished += TakePSOutout;

            PSTools.GetUpTime(TxtBox_CompName.Text);

        }

        void TakePSOutout(object p, EventArgs e)
        {
            PrintOutput((e as PSToolsEventArgs).Message);
        }

        private void Btn_CHFSSearch_Click(object sender, EventArgs e)
        {

            
            //MessageBox.Show("Feature not implemented yet");
            //AppSettings settings = new AppSettings();
            // settings.LoadSettings(Environment.CurrentDirectory);



            //this.BackgroundImage = Image.FromFile(@"C:\users\kylecrawford\desktop\AdminTools Backgrounds\ananas.png");



            //ComBox_VMs.SelectedIndex = -1;

            //var test = settings.LANDeskServers;

            //ShrinkForm();

            //NotepadForm notes = new NotepadForm();


            //notes.Show();
            //notes.Location = new System.Drawing.Point(this.Location.X - notes.Width + 15, this.Location.Y);
        }

        private void Btn_PrinterSearch_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Feature not implemented yet");
            Console.WriteLine(Environment.CurrentDirectory);
        }

        private void Btn_SecondayPC_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Feature not implemented yet");
        }

        private void Btn_ShowNotes_Click(object sender, EventArgs e)
        {
            if (this.Width > _formWidth)
            {
                //return to normal
                this.Width -= TxtBox_Notes.Width + 15;
            }
            else
            {
                //enlarge
                this.Width += TxtBox_Notes.Width + 15;
            }

            if (Btn_ShowNotes.Text == ">")
            {
                Btn_ShowNotes.Text = "<";
            }
            else
            {
                Btn_ShowNotes.Text = ">";
            }
        }

        private void ComBox_VMs_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ComBox_VMs.SelectedIndex != -1 && ComBox_VMs.SelectedItem.ToString() != "Virtual Machines")
            {
                TxtBox_CompName.Text = _settings.VirtualMachines[ComBox_VMs.SelectedItem.ToString()];
            }
        }

        private void ComBox_VMs_DropDown(object sender, EventArgs e)
        {
            if (ComBox_VMs.Items.Contains("Virtual Machines"))
            {
                ComBox_VMs.Items.Remove("Virtual Machines");
            }
        }

        private void ComBox_VMs_DropDownClosed(object sender, EventArgs e)
        {
            if (ComBox_VMs.SelectedIndex < 0)
            {
                ComBox_VMs.Items.Add("Virtual Machines");
                ComBox_VMs.SelectedItem = "Virtual Machines";
            }
        }

        private void Btn_RCViewer_Click(object sender, EventArgs e)
        {
            WindowsFunctions.OpenRCViewer();
        }

        private void Btn_Customize_Click(object sender, EventArgs e)
        {
            CustomizeForm window = new CustomizeForm();
            window.Owner = this;
            window.Setup();
            window.ShowDialog();
        }



        public void UpdateForm()
        {
            foreach (Control c in this.Controls)
            {
                if (c is Panel)
                {
                    foreach (Control co in c.Controls)
                    {
                        if (co is Button)
                        {
                            (co as Button).FlatStyle = FlatStyle.Flat;
                            co.BackColor = Color.FromArgb(150, co.BackColor);
                        }
                        else if (co is Panel)
                        {
                            co.BackColor = Color.FromArgb(100, co.BackColor);
                            foreach (RadioButton rBtn in co.Controls)
                            {
                                rBtn.BackColor = Color.FromArgb(0, rBtn.BackColor);
                            }
                        }
                        else if (co is CheckBox)
                        {
                            co.BackColor = Color.FromArgb(150, co.BackColor);
                        }
                        else if (co is Label)
                        {
                            co.BackColor = Color.FromArgb(150, co.BackColor);
                        }
                    }
                    c.BackColor = Color.FromArgb(0, c.BackColor);
                }

                else if (c is Label)
                {
                    c.BackColor = Color.FromArgb(150, c.BackColor);
                }
                else if (c is Button)
                {
                    (c as Button).FlatStyle = FlatStyle.Flat;
                    c.BackColor = Color.FromArgb(150, c.BackColor);
                }
                else if (c is ComboBox)
                {
                    //c.BackColor = Color.FromArgb(0, c.BackColor);
                }

            }

            OpenFileDialog ofd = new OpenFileDialog();
            ofd.InitialDirectory = Environment.CurrentDirectory + @"\Admintools Backgrounds";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                this.BackgroundImage = Image.FromFile(ofd.FileName);
            }
        
    }

        private void RBtn_Custom_CheckedChanged(object sender, EventArgs e)
        {
            //enable the prefix radio buttons
            if (RBtn_Custom.Checked)
            {
                foreach (RadioButton rb in Pnl_OpenSitePrefix.Controls)
                {
                    rb.Enabled = true;
                }
                //change the drop down style
                ComBox_OpenSite.DropDownStyle = ComboBoxStyle.DropDown;
                ComBox_OpenSite.Text = "Enter URL";
            }
            else
            {
                foreach (RadioButton rb in Pnl_OpenSitePrefix.Controls)
                {
                    rb.Enabled = false;
                }
                ComBox_OpenSite.DropDownStyle = ComboBoxStyle.DropDownList;
            }


            //make sure the default text for the opensite combobox is there
            if (!ComBox_OpenSite.Items.Contains("Open Site"))
            {
                ComBox_OpenSite.Items.Add("Open Site");
            }
            ComBox_OpenSite.SelectedItem = "Open Site";
        }
    }

}

