using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.Diagnostics;
using System.Net;
using System.Management;
using System.IO;
using System.Xml;

namespace CAdminTools
{
    /// <summary>
    /// Main form for the CAdminTools app to hold all and is the main interface of the application
    /// </summary>
    /// This page of the class holds all the private and public methods used on this form
    public partial class Form_MainForm
    {
        /// <summary>
        /// Takes the provided string and safely prints it to the output textbox
        /// </summary>
        /// <param name="output"> The text to print to the output textbox </param>
        private void PrintOutput(string output)
        {
            if (TxtBox_Output.InvokeRequired)
                TxtBox_Output.Invoke(new delvoidstring(PrintOutput), output);
            else
                TxtBox_Output.AppendText(output + Environment.NewLine);
        }

        /// <summary>
        /// Loads ComboBoxes with their values. Attaches delegates to methods. 
        /// Updates the default text for ClearTextBoxes, moves and hides them appropriately.
        /// </summary>
        private void Init()
        {
            _intDocDic = new Dictionary<string, string>();
            _openSiteDic = new Dictionary<string, string>();

            //move and hide the First, Last and Email name text boxes
            CTxtBox_FName.Hide();
            CTxtBox_FName.Location = new Point(CTxtBox_UserName.Location.X, CTxtBox_UserName.Location.Y);

            CTxtBox_LName.Hide();
            CTxtBox_LName.Location = new Point(CTxtBox_UserName.Location.X + CTxtBox_UserName.Width / 2, CTxtBox_UserName.Location.Y);

            CTxtBox_Email.Hide();
            CTxtBox_Email.Location = new Point(CTxtBox_UserName.Location.X, CTxtBox_UserName.Location.Y);

            ComBox_IntDocs.DropDownStyle = ComboBoxStyle.DropDownList;

            //populate the open site and internal document combo boxes
            PopulateComBoxes();

            //attach method to delegates
            DelPassToOutput = PrintOutput;

            //init drop down server list
            foreach (string server in _settings.LANDeskServers)
            {
                ComBox_Server.Items.Add(server);
            }

            ComBox_Server.SelectedItem = _settings.LANDeskServers[0];

            _IAMBrowser = new IAMBrowserForm(this);

            CTxtBox_UserName.DefaultText = _settings.DefaultUserNameTextBoxText;
            CTxtBox_UserName.AutoClear = true;
            CTxtBox_FName.DefaultText = _settings.DefaultFirstNameTextBoxText;
            CTxtBox_FName.AutoClear = false;
            CTxtBox_LName.DefaultText = _settings.DefaultLastNameTextBoxText;
            CTxtBox_LName.AutoClear = false;
            CTxtBox_Email.DefaultText = _settings.DefaultEmailTextBoxText;
            CTxtBox_Email.AutoClear = true;

            //CkBox_IAM.Checked = true;
            //CkBox_ThisPC.Checked = true;

            ComBox_OpenSite.DropDownStyle = ComboBoxStyle.DropDownList;

            RBtn_https.Checked = true;
            RBtn_Select.Checked = true;
            RBtn_ThisPC.Checked = true;

            foreach (RadioButton rb in Pnl_OpenSitePrefix.Controls)
            {
                rb.Enabled = false;
            }
            //check for required folders and files
            CreateLocalFiles(_settings.LocalSettingsSavePath);


            if (System.IO.File.Exists(_settings.LocalSettingsSavePath + @"\LocalNotes.txt"))
            {
                TxtBox_Notes.Text = System.IO.File.ReadAllText(_settings.LocalSettingsSavePath + @"\LocalNotes.txt");
            }

            //load in the visuals
            
        }

        private void SaveLocalFiles(string path)
        {
            if (System.IO.File.Exists(path + @"\LocalNotes.txt"))
            {
                System.IO.File.WriteAllText(path + @"\LocalNotes.txt", TxtBox_Notes.Text);
            }
            else
            {
                //file doesn't exist - at this point, it should
                CreateLocalFiles(path);
                File.WriteAllText(path + @"\LocalNotes.txt", TxtBox_Notes.Text);
            }
        }

        private void CreateLocalFiles(string path)
        {
            if (path == "")
            {
                return;
            }
            if (!Directory.Exists(path))
            {
                DirectoryInfo dI = Directory.CreateDirectory(path);
                dI.Attributes = FileAttributes.Directory | FileAttributes.Hidden;
            }


            if (!System.IO.File.Exists(_settings.LocalSettingsSavePath + @"\LocalNotes.txt"))
            {
                using (System.IO.StreamWriter sw = System.IO.File.CreateText(_settings.LocalSettingsSavePath + @"\LocalNotes.txt"))
                { }
            }
            if (!File.Exists(_settings.LocalSettingsSavePath + @"\LocalSettings.xml"))
            {
                CreateLocalXMLSettings();
            }
        }

        /// <summary>
        /// Populates the ComboBoxes with the files located in their respective folders
        /// </summary>
        private void PopulateComBoxes()
        {
            //Internal Document combo box
            List<string> files = new List<string>(Directory.GetFiles(Environment.CurrentDirectory + @"\OrgFiles"));

            for (int i = 0; i < files.Count; i++)
            {
                string[] tmp = files[i].Split(new char[] { '\\' }, StringSplitOptions.RemoveEmptyEntries);
                ComBox_IntDocs.Items.Add(tmp[tmp.Length - 1]);
                _intDocDic.Add(tmp[tmp.Length - 1], files[i]);
            }

            //Open Site combo box
            List<string> sites = new List<string>(Directory.GetFiles(Environment.CurrentDirectory + @"\Sites"));

            //add the default text
            ComBox_OpenSite.Items.Add("Open Site");
            ComBox_OpenSite.SelectedItem = "Open Site";


            for (int i = 0; i < sites.Count; i++)
            {
                string[] tmp = sites[i].Split(new char[] { '\\' }, StringSplitOptions.RemoveEmptyEntries);
                ComBox_OpenSite.Items.Add(tmp[tmp.Length - 1].Substring(0, tmp[tmp.Length - 1].Length - 4));

                using (TextReader reader = new StreamReader(sites[i]))
                {
                    string line = "";
                    while ((line = reader.ReadLine()) != null)
                    {
                        if (line.StartsWith("URL="))
                        {
                            string[] splitLine = line.Split('=');
                            if (splitLine.Length > 0)
                            {
                                _openSiteDic.Add(tmp[tmp.Length - 1].Substring(0, tmp[tmp.Length - 1].Length - 4), splitLine[1]);
                                break;
                            }
                        }
                    }
                }

            }

            foreach (KeyValuePair<string, string> kvp in _settings.VirtualMachines)
            {
                ComBox_VMs.Items.Add(kvp.Key);
            }

            //////
            ComBox_IntDocs.Items.Add("Open Document");
            ComBox_IntDocs.SelectedItem = "Open Document";
            ComBox_VMs.Items.Add("Virtual Machines");
            ComBox_VMs.SelectedItem = "Virtual Machines";
        }

        /// <summary>
        /// Used to safely update a Label with text
        /// </summary>
        /// <param name="label"> The Label to update </param>
        /// <param name="text"> The text to change the label to </param>
        private void UpdateLabel(Label label, string text)
        {
            if (label.InvokeRequired)
            {
                label.Invoke(new delWriteLabel(UpdateLabel), label, text);
            }
            else
            {
                label.Text = text;
            }
        }

        private void UpdateLabelColour(Label label, Color colour)
        {
            if (label.InvokeRequired)
            {
                label.Invoke(new delColourLabel(UpdateLabelColour), label, colour);
            }
            else
            {
                label.ForeColor = colour;
            }
        }

        /// <summary>
        /// performs Trim() on provided TextBox. Returns true if not blank
        /// </summary>
        /// <param name="textBox"> Textbox to check </param>
        /// <returns> True if there is text, False if there is no text</returns>
        private bool TextBoxCheck(TextBox textBox)
        {
            textBox.Text = textBox.Text.Trim();
            if (textBox.Text == "")
            {
                //textbox is blank
                MessageBox.Show("Please enter a computer name");
                return false;
            }
            return true;
        }

        /// <summary>
        /// Takes the provided list of filePaths and returns a list of those that are available on the local computer
        /// </summary>
        /// <param name="paths"> List of paths to check if they are installed </param>
        /// <returns> List of file paths that are installed </returns>
        private static List<string> GetAvailableBrowsers(List<string> paths)
        {
            List<string> installedlist = new List<string>();
            foreach (string filePath in paths)
            {
                if (File.Exists(filePath))
                {
                    installedlist.Add(filePath);
                }
            }
            return installedlist;
        }

        private void UpdateDefaultBrowser(string browserPath)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(_settings.LocalSettingsSavePath + @"\LocalSettings.xml");
            XmlNode defaultBrowserNode = doc.SelectSingleNode("//LocalSettings/UserSettings/DefaultBrowser");

            defaultBrowserNode.InnerText = browserPath;

            doc.Save(_settings.LocalSettingsSavePath + @"\LocalSettings.xml");
        }

        /// <summary>
        /// Creates the local settings XML file using the UserDefaultBrowser in settings
        /// </summary>
        private void CreateLocalXMLSettings()
        {
            //check if folder exists
            if (!Directory.Exists(_settings.LocalSettingsSavePath))
            {
                Directory.CreateDirectory(_settings.LocalSettingsSavePath);
            }

            XmlDocument xlDoc = new XmlDocument();
            XmlNode rootNode = xlDoc.CreateElement("LocalSettings");
            xlDoc.AppendChild(rootNode);

            XmlNode userSettings = xlDoc.CreateElement("UserSettings");
            rootNode.AppendChild(userSettings);

            XmlNode defaultBrowser = xlDoc.CreateElement("DefaultBrowser");
            defaultBrowser.InnerText = "";
            userSettings.AppendChild(defaultBrowser);

            xlDoc.Save(_settings.LocalSettingsSavePath + @"\LocalSettings.xml");
        }

        /// <summary>
        /// Opens the default web browser to AHS ARS site searching for provided username
        /// </summary>
        /// <param name="userName"> Target username to search for </param>
        private void ARSSearchUser(string userName)
        {
            List<string> tempList = new List<string>
            {
                (userName.Contains("@") ? "Email" : "UserName"),
                userName
            };
            System.Threading.ThreadPool.QueueUserWorkItem(TARSSearchUser, tempList);
        }

        /// <summary>
        /// Starts a thread method to search the AHS ARS site
        /// </summary>
        /// <param name="firstName"> Target first name </param>
        /// <param name="lastName"> Target last name</param>
        private void ARSSearchUser(string firstName, string lastName)
        {
            List<string> tempList = new List<string>
            {
                "FirstLast",
                firstName,
                lastName
            };

            System.Threading.ThreadPool.QueueUserWorkItem(TARSSearchUser, tempList);
        }

        /// <summary>
        /// Opens the default web browser to AHS ARS site searching for provided search criteria
        /// </summary>
        /// <param name="searchInfo"> contains a List<string> with the seach type and search info </string> </param>
        private void TARSSearchUser(object searchInfo)
        {
            //need to test which of the 3 we are using

            //object will be an array

            if (!(searchInfo is List<string>))
                return;

            List<string> searchList = new List<string>((searchInfo as List<string>));

            //first entry is the type of search

            string urlSearch = "";

            switch (searchList[0])
            {
                case "UserName":
                    urlSearch = "Redacted" + searchList[1] + "%2cOU%3dGeneral%2cOU%3dEDM%2cOU%3dUsers%2cOU%3dAccounts%2cDC%3dhealthy%2cDC%3dbewell%2cDC%3dca";
                    break;
                case "Email":
                    string email = searchList[1].Replace("@", "%40");
                    urlSearch = "Redacted" + email;
                    break;
                case "FirstLast":
                    urlSearch = "Redacted" + searchList[1] + "+" + searchList[2];
                    break;
            }

            try
            {
                Process.Start(urlSearch);
            }
            catch (Exception e)
            {
                PrintOutput(e.Message);
            }

        }

        /// <summary>
        /// Returns a list of the active ClearTextBoxes from this form
        /// </summary>
        /// <returns> The active ClearTextBox from this form </returns>
        public List<ClearTextBox> PassActiveClearBoxes()
        {
            List<Panel> userPanel = Controls.OfType<Panel>().Where(o => o.Name.Contains("Pnl_User")).ToList();

            //something is wrong, there can only be one
            if (userPanel.Count != 1)
            {
                return null;
            }

            List<ClearTextBox> CTBList = userPanel[0].Controls.OfType<ClearTextBox>().Where(o => o.Visible).ToList();

            //can either have 1 or 2 visible boxes 
            if (CTBList.Count < 1)
            {
                return null;
            }

            return CTBList;
        }

        /// <summary>
        /// Opens a website on this computer and/or a remote computer
        /// </summary>
        private void OpenSite(bool isRemoteComputer, string compName = "ThisPC")
        {
            string thesite = "";

            //site is not going to be in opensite dictionary
            if (RBtn_Custom.Checked)
            {
                if (_openSiteDic.ContainsKey(ComBox_OpenSite.Text))
                {
                    thesite = _openSiteDic[ComBox_OpenSite.SelectedItem.ToString()];
                }
                else if (RBtn_http.Checked)
                {
                    thesite = @"http:\\" + ComBox_OpenSite.Text;
                }
                else if (RBtn_https.Checked)
                {
                    thesite = @"https:\\" + ComBox_OpenSite.Text;
                }
                else
                {
                    thesite = ComBox_OpenSite.Text;
                }
            }
            else if (RBtn_Select.Checked)
            {
                //going to have what we need in dictionary
                thesite = _openSiteDic[ComBox_OpenSite.SelectedItem.ToString()];
            }
            //if remote
            if (isRemoteComputer)
            {
                if (MessageBox.Show("Are you sure you want to open " + (ComBox_OpenSite.SelectedItem == null ? ComBox_OpenSite.Text : ComBox_OpenSite.SelectedItem.ToString()) + " on " + TxtBox_CompName.Text, "Open Site on Remote PC?", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
                {
                    _pSTools.OpenRemSite(compName, thesite);
                }
            }
            else
            {
                try
                {
                    Process.Start(thesite);
                }
                catch
                {
                    PrintOutput("Error opening site");
                }
            }

        }

        /// <summary>
        /// Opens the item selected in the internal douments combo box
        /// </summary>
        private void OpenInternalDoc()
        {
            try
            {
                Process.Start(_intDocDic[ComBox_IntDocs.SelectedItem.ToString()]);
                PrintOutput("Opening " + ComBox_IntDocs.SelectedItem.ToString());
            }
            catch (Exception e)
            {
                PrintOutput(e.Message);
            }
        }

        /// <summary>
        /// Prompts the user to set their default browser for LANDesk use
        /// Returns true if user sucessfully set their browser
        /// </summary>
        /// <returns> True if the user set thier default browser. False if not </returns>
        private static string PromptToSelectDefaultBrowser(List<string> allBrowsers)
        {
            using (DefaultBrowserDialog DBD = new DefaultBrowserDialog(GetAvailableBrowsers(allBrowsers)))
            {
                if (DBD.ShowDialog() == DialogResult.OK)
                {
                    return DBD.SelectedBrowser;
                }
                else
                {
                    return null;
                }
            }
        }

        /// <summary>
        /// Attempts to ping the provided computer
        /// </summary>
        /// <param name="compName"> Target computer </param>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Code Quality", "IDE0067:Dispose objects before losing scope", Justification = "Ping is disposed in Callback method")]
        private void PingTarget(string compName)
        {
            System.Net.NetworkInformation.Ping pingSender = new System.Net.NetworkInformation.Ping();
            System.Net.NetworkInformation.PingOptions options = new System.Net.NetworkInformation.PingOptions
            {
                DontFragment = true
            };

            int timeout = 120;

            //async
            pingSender.PingCompleted += PingComplete;

            try
            {
                pingSender.SendAsync(compName, timeout, compName);
            }
            catch (Exception e)
            {
                PrintOutput(e.Message);
            }

            //Ping is disposed in Callback method
        }

        /// <summary>
        /// On ping return, updates labels accordingly, and attempts to get user of computer if successful
        /// </summary>
        /// <param name="pinger"></param>
        /// <param name="e"></param>
        private void PingComplete(object pinger, System.Net.NetworkInformation.PingCompletedEventArgs e)
        {
            //System.Net.NetworkInformation.Ping p = (pinger as System.Net.NetworkInformation.Ping);

            if (e.Reply != null && e.Reply.Status == System.Net.NetworkInformation.IPStatus.Success)
            {
                string IP4Address = "";
                string IP6Address = "";

                foreach (IPAddress IPA in Dns.GetHostAddresses(e.UserState.ToString()))
                {
                    if (IPA.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork)
                        IP4Address = IPA.ToString();
                    else if (IPA.AddressFamily == System.Net.Sockets.AddressFamily.InterNetworkV6)
                        IP6Address = IPA.ToString();
                }

                UpdateLabel(Lbl_IP, IP4Address);
                UpdateLabel(Lbl_PingStatus, "Online");
                UpdateLabelColour(Lbl_PingStatus, Color.Green);
                System.Threading.ThreadPool.QueueUserWorkItem(TGetUser);

            }
            else
            {
                if (Lbl_PingStatus.Text != "Online")
                {
                    UpdateLabel(Lbl_PingStatus, "Offline");
                    UpdateLabelColour(Lbl_PingStatus, Color.Red);
                }
            }
            (pinger as System.Net.NetworkInformation.Ping).Dispose();
        }

        /// <summary>
        /// Thread method that will check for the current logged in user of the computer in TxtBox_CompName 
        /// </summary>
        /// <param name="stateInfo"></param>
        private void TGetUser(object stateInfo)
        {
            string user = WindowsFunctions.GetCurrentUser(TxtBox_CompName.Text.Trim());
            UpdateLabel(Lbl_UserName, user);
        }

        private void PSReturn(object sender, EventArgs e)
        {
            PrintOutput((e as PSToolsEventArgs).Message);
        }

        private void PrintReturn(object sender, EventArgs e)
        {
            PrintOutput((e as WinEventArgs).Message);
        }



    }
}
