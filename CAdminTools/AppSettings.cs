using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml;
using System.Windows.Forms;

namespace CAdminTools
{
    /// <summary>
    /// Provides one places to store all the settings loaded in from an XML settings file.
    /// The settings allow the users to change the values without having to edit the code.
    /// </summary>
    class AppSettings
    {
        // The IAM password reset user lookup page
        private string _iamPWordResetPage = "";
        // The IAM login page
        private string _iamLoginPage = "";
        // The IAM home page
        private string _iamHomePage = "";

        // The default text to have in the various ClearTextBoxes
        private string _defaultUserNameTextBoxText = "";
        private string _defaultFirstNameTextBoxText = "";
        private string _defaultLastNameTextBoxText = "";
        private string _defaultEmailTextBoxText = "";

        // The IAM password reset user lookup textbox field ID names
        private string _iamUserNameID = "";
        private string _iamFirstNameID = "";
        private string _iamLastNameID = "";
        private string _iamEmailID = "";
        private string _iamGoButtonID = "";

        // Virtual Machines
        private Dictionary<string, string> _vmDict;

        // The location the save the local settings XML file
        private string _localSettingsSavePath = "";

        // The file path to the users selected default browser
        private string _userDefaultBrowser = "";

        // List of all the browser paths used to check if they are installed
        private List<string> _allBrowserList = null;

        // List of all the LANDesk server connections
        private List<string> _lanDeskServers = null;

        // The folder path of the application settings file
        //private string _folderPath = "";

        // Public get properties to provide access to the various settings
        public Dictionary<string, string> VirtualMachines
        {
            get => _vmDict;
            set => _vmDict = value;
        }

        public string IAMPWordResetPage
        {
            get => _iamPWordResetPage;
            set => _iamPWordResetPage = value;
        }

        public string IAMLoginPage 
        { 
            get => _iamLoginPage; 
            set => _iamLoginPage = value; 
        }

        public string IAMHomePage
        {
            get => _iamHomePage;
            set => _iamHomePage = value;
        }

        public string DefaultUserNameTextBoxText
        {
            get => _defaultUserNameTextBoxText;
            set => _defaultUserNameTextBoxText = value;
        }
        public string DefaultFirstNameTextBoxText
        {
            get => _defaultFirstNameTextBoxText;
            set => _defaultFirstNameTextBoxText = value;
        }
        public string DefaultLastNameTextBoxText
        {
            get => _defaultLastNameTextBoxText;
            set => _defaultLastNameTextBoxText = value;
        }
        public string DefaultEmailTextBoxText
        {
            get => _defaultEmailTextBoxText;
            set => _defaultEmailTextBoxText = value;
        }

        public string IAMUserNameID
        {
            get => _iamUserNameID;
            set => _iamUserNameID = value;
        }

        public string IAMFirstNameID
        {
            get => _iamFirstNameID;
            set => _iamFirstNameID = value;
        }
        public string IAMLastNameID
        {
            get => _iamLastNameID;
            set => _iamLastNameID = value;
        }
        public string IAMEmailID
        {
            get => _iamEmailID;
            set => _iamEmailID = value;
        }
        public string IAMGoButtonID
        {
            get => _iamGoButtonID;
            set => _iamGoButtonID = value;
        }

        public string LocalSettingsSavePath
        {
            get => _localSettingsSavePath;
            set => _localSettingsSavePath = value;
        }

        public string UserDefaultBrowser
        {
            get => _userDefaultBrowser;
            set => _userDefaultBrowser = value;
        }

        public List<string> AllBrowsers
        {
            get => _allBrowserList;
            set => _allBrowserList = value;
        }

        public List<string> LANDeskServers
        {
            get => _lanDeskServers;
            set => _lanDeskServers = value;
        }

        /// <summary>
        /// Initializes the global list variables
        /// </summary>
        public AppSettings()
        {
            _allBrowserList = new List<string>();
            _lanDeskServers = new List<string>();
            _vmDict = new Dictionary<string, string>();

            _localSettingsSavePath = @"C:\users\" + Environment.UserName + @"\CAdminTools";
        }

        /// <summary>
        /// Loads the settings file from the provided filepath
        /// </summary>
        /// <param name="folderPath"> folderpath containing the XML settings file </param>
        /// <returns> True if successful, False if failure </returns>
        public bool LoadSettings(string folderPath)
        {
            bool loadSuccess = false;
            //check if settings file exists
            if (!File.Exists(folderPath + @"\AppSettings.xml"))
            {
                //file not found. Create one as default
                SetDefaultSettings();
                CreateAppSettings(folderPath);  
            }
            else
            {
                loadSuccess = ReadXMLSettings(folderPath);
            }

            //if the local settings file does not exist, just return. It is handled later
            if (!File.Exists(_localSettingsSavePath + @"\LocalSettings.xml"))
            {
                return loadSuccess;
            }

            //if it does exist, we are getting the user's default browser
            using (XmlReader reader = XmlReader.Create(_localSettingsSavePath + @"\LocalSettings.xml"))
            {
                while (reader.Read())
                {
                    if (!reader.IsStartElement())
                    {
                        continue;
                    }

                    if (reader.Name.ToString() == "DefaultBrowser")
                    {
                        _userDefaultBrowser = reader.ReadInnerXml();
                    }
                }
            }
            return loadSuccess;
        }
        /// <summary>
        /// Sets the global variables used as settings for the application with hard coded default values. (All defaults can be set here)
        /// </summary>
        private void SetDefaultSettings()
        {
            //setting these strings as default values in case the settings file is unable to be opened
            _iamPWordResetPage = @"Redacted";
            _iamLoginPage = @"Redacted";
            _iamHomePage = @"Redacted";

            _defaultUserNameTextBoxText = "UserName";
            _defaultFirstNameTextBoxText = "First Name";
            _defaultLastNameTextBoxText = "Last Name";
            _defaultEmailTextBoxText = "Email Address";

            _iamUserNameID = "searchModel.searchCriterias3.searchValue";
            _iamFirstNameID = "searchModel.searchCriterias1.searchValue";
            _iamLastNameID = "searchModel.searchCriterias0.searchValue";
            _iamEmailID = "searchModel.searchCriterias2.searchValue";
            _iamGoButtonID = "search-advanced-btn-Request-ExistingUserSearch-0-ExistingUser";

            //_localSettingsSavePath = @"C:\users\" + Environment.UserName + @"\CAdminTools";

            _userDefaultBrowser = @"C:\Program Files\internet explorer\iexplore.exe";

            _allBrowserList.AddRange(new string[]
            {
                @"C:\Program Files\Mozilla Firefox\firefox.exe",
                @"C:\Program Files\internet explorer\iexplore.exe",
                @"C:\Program Files (x86)\Internet Explorer\iexplore.exe",
                @"C:\Program Files (x86)\Google\Chrome\Application\Chrome.exe",
                @"C:\Windows\SystemApps\Microsoft.MicrosoftEdge_8wekyb3d8bbwe\MicrosoftEdge.exe"
            });

            _lanDeskServers.AddRange(new string[]
            {
                "RemovedCORE01",
                "RemovedCORE02",
                "RemovedCORE03"
            });

        }

        /// <summary>
        /// Create the AppSettings.xml with hard coded values 
        /// </summary>
        private void CreateAppSettings(string folderPath)
        {
            //create a new default one. Hard coded

            XmlWriterSettings xmlSettings = new XmlWriterSettings();
            var r = xmlSettings.NewLineHandling;
            xmlSettings.Indent = true;
            xmlSettings.IndentChars = "\t";
            //xmlSettings.NewLineOnAttributes = true;

            using (XmlWriter writer = XmlWriter.Create(folderPath + @"\AppSettings.xml", xmlSettings))
            {
                //AppSettings
                writer.WriteStartElement("AppSettings");

                //LocalFiles
                //writer.WriteStartElement("LocalFiles");
                //writer.WriteElementString("LocalFiles", @"C:\users\" + Environment.UserName + @"\CAdminTools");
                //writer.WriteEndElement();

                //  Browsers
                writer.WriteStartElement("Browsers");
                for (int i = 0; i < _allBrowserList.Count; i++)
                {
                    List<string> splitPath = _allBrowserList[i].Split(new char[] { '\\' }, StringSplitOptions.RemoveEmptyEntries).ToList();
                    string browserName = splitPath[splitPath.Count - 1].Substring(0, splitPath[splitPath.Count - 1].Length - 4);
                    writer.WriteElementString(browserName + (splitPath.Where(o => o.Contains("(x86)")).ToList().Count > 0 ? "x86" : string.Empty), _allBrowserList[i]);
                }
                writer.WriteEndElement();

                //  Websites
                writer.WriteStartElement("Websites");
                writer.WriteElementString("IAMPasswordReset", _iamPWordResetPage);
                writer.WriteElementString("IAMHomePage", _iamHomePage);
                writer.WriteElementString("IAMLoginPage", _iamLoginPage);
                writer.WriteEndElement();

                //  DefaultText
                writer.WriteStartElement("DefaultText");
                writer.WriteElementString("UserName", _defaultUserNameTextBoxText);
                writer.WriteElementString("FirstName", _defaultFirstNameTextBoxText);
                writer.WriteElementString("LastName", _defaultLastNameTextBoxText);
                writer.WriteElementString("Email", _defaultEmailTextBoxText);
                writer.WriteEndElement();

                //LANDeskServers
                writer.WriteStartElement("LANDeskServers");
                writer.WriteElementString("Edmonton", _lanDeskServers[0]);
                writer.WriteElementString("RedDeer", _lanDeskServers[1]);
                writer.WriteElementString("Calgary", _lanDeskServers[2]);
                writer.WriteEndElement();

                //IAMIDs
                writer.WriteStartElement("IAMIDs");
                writer.WriteElementString("UserNameID", _iamUserNameID);
                writer.WriteElementString("FirstNameID", _iamFirstNameID);
                writer.WriteElementString("LastNameID", _iamLastNameID);
                writer.WriteElementString("EmailID", _iamEmailID);
                writer.WriteElementString("GoButtonID", _iamGoButtonID);
                writer.WriteEndElement();

                //Virtual Machines
                writer.WriteStartElement("VirtualMachines");
                writer.WriteElementString("EMSiUserVM1", "vdwrkstn0290");
                writer.WriteElementString("EMSiUserVM2", "vdwrkstn0291");
                writer.WriteElementString("EMSiUserVM3", "vdwrkstn0292");
                writer.WriteElementString("EMSiUserVM4", "vdwrkstn0293");
                writer.WriteElementString("EMSiUserVM5", "vdwrkstn0294");
                writer.WriteElementString("FileRecovery", "wsnsrclient03");
                writer.WriteElementString("CallBoard", "vdwrkstn0122");
                writer.WriteElementString("CernerMillenniumApplicationVM", "vdwrkstn0121");
                writer.WriteEndElement();

                //close AppSettings
                writer.WriteEndElement();

                //writer.WriteAttributeString("Bar", "Some & value");
                writer.Flush();
            }
        }

        /// <summary>
        /// loads the global variables with the values from the AppSettings.xml from the provided folder path
        /// </summary>
        /// <returns> True if sucessful, false if fails </returns>
        private bool ReadXMLSettings(string folderPath)
        {
            XmlDocument xmlDoc = TryLoadXML(folderPath + @"\AppSettings.xml");
            if (xmlDoc == null)
            {
                //call method to set defaults hard coded
                //SetDefaultSettings();
                return false;
            }

            //XmlNodeList localFiles = xmlDoc.GetElementsByTagName("LocalFiles");
            //localFiles = localFiles.Count > 0 ? localFiles[0].ChildNodes : localFiles;
            //_localSettingsSavePath = localFiles[0].InnerText;

            XmlNodeList websites = xmlDoc.GetElementsByTagName("Websites");

            if (websites.Count > 0)
            {
                websites = websites[0].ChildNodes;
            }

            foreach (XmlNode xn in websites)
            {
                switch (xn.Name)
                {
                    case "IAMPasswordReset":
                        _iamPWordResetPage = xn.InnerText;
                        break;
                    case "IAMHomePage":
                        _iamHomePage = xn.InnerText;
                        break;
                    case "IAMLoginPage":
                        _iamLoginPage = xn.InnerText;
                        break;
                }
            }

            XmlNodeList browsers = xmlDoc.GetElementsByTagName("Browsers");

            browsers = browsers.Count > 0 ? browsers[0].ChildNodes : browsers;

            foreach (XmlNode xN in browsers)
                _allBrowserList.Add(xN.InnerText);

            //default text
            XmlNodeList defaultText = xmlDoc.GetElementsByTagName("DefaultText");

            defaultText = defaultText.Count > 0 ? defaultText[0].ChildNodes : defaultText;

            foreach (XmlNode xN in defaultText)
            {
                switch (xN.Name)
                {
                    case "UserName":
                        _defaultUserNameTextBoxText = xN.InnerText;
                        break;
                    case "FirstName":
                        _defaultFirstNameTextBoxText = xN.InnerText;
                        break;
                    case "LastName":
                        _defaultLastNameTextBoxText = xN.InnerText;
                        break;
                    case "Email":
                        _defaultEmailTextBoxText = xN.InnerText;
                        break;
                }
            }

            XmlNodeList lanDeskServers = xmlDoc.GetElementsByTagName("LANDeskServers");

            lanDeskServers = lanDeskServers.Count > 0 ? lanDeskServers[0].ChildNodes : lanDeskServers;

            foreach (XmlNode xN in lanDeskServers)
                _lanDeskServers.Add(xN.InnerText);

            //IAMIDs-
            XmlNodeList iamIDs = xmlDoc.GetElementsByTagName("IAMIDs");

            iamIDs = iamIDs.Count > 0 ? iamIDs[0].ChildNodes : iamIDs;

            foreach (XmlNode xN in iamIDs)
            {
                switch (xN.Name)
                {
                    case "UserNameID":
                        _iamUserNameID = xN.InnerText;
                        break;
                    case "FirstNameID":
                        _iamFirstNameID = xN.InnerText;
                        break;
                    case "LastNameID":
                        _iamLastNameID = xN.InnerText;
                        break;
                    case "EmailID":
                        _iamEmailID = xN.InnerText;
                        break;
                    case "GoButtonID":
                        _iamGoButtonID = xN.InnerText;
                        break;
                }
            }

            //Virtual Machines
            XmlNodeList virtualMachineXML = xmlDoc.GetElementsByTagName("VirtualMachines");

            virtualMachineXML = virtualMachineXML.Count > 0 ? virtualMachineXML[0].ChildNodes : virtualMachineXML;

            foreach (XmlNode xN in virtualMachineXML)
            {
                _vmDict.Add(xN.Name, xN.InnerText);
            }

            return true;
        }

        /// <summary>
        /// Attempts to load the XML document located at the provided path. 
        /// </summary>
        /// <param name="path">File path to the XML document to be loaded</param>
        /// <returns>The XML document at the target location as XmlDocument, or null if the user chooses not to load</returns>
        private XmlDocument TryLoadXML(string path)
        {
            XmlDocument xmlDoc = new XmlDocument();
            try
            {
                xmlDoc.Load(path);
            }
            catch (IOException)
            {
                if (MessageBox.Show("Unable to load app settings. Try Again?", "Error", MessageBoxButtons.YesNo, MessageBoxIcon.Error) == DialogResult.Yes)
                {
                    return TryLoadXML(path);
                }
                else
                {
                    //disable features and load some default settings
                    return null;
                }
            }
            catch (System.Xml.XmlException)
            {
                if (MessageBox.Show("AppSettings.xml is either blank or corrupted. Press 'OK' to allow the file to be deleted and remade with defaults", "XML File Error", MessageBoxButtons.OKCancel, MessageBoxIcon.Error) == DialogResult.OK)
                {
                    File.Delete(path);

                    //load the defaults
                    SetDefaultSettings();
                    CreateAppSettings(System.Environment.CurrentDirectory);
                    //try again
                    TryLoadXML(path);
                }
            }
            return xmlDoc;
        }


    }
}
