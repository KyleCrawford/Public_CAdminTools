using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using Microsoft.VisualBasic;
using System.IO;
using Microsoft.Management;
using Microsoft.Management.Infrastructure;
using System.Management;
using System.Runtime.InteropServices;
using System.Xml;

namespace CAdminTools
{
    partial class Form_MainForm
    {
        ////////////////////////////// Test Code //////////////////////////////
        /// <summary>
        ///         //logs off or restarts the provided computer name
        private void OldRemoteLogOfforRestart(bool isLogOff, string compName)
        {


            //true : false
            //logoff : Restart
            int flag = isLogOff ? 0 : 6;

            ConnectionOptions connOptions = new ConnectionOptions();
            connOptions.Impersonation = ImpersonationLevel.Impersonate;
            connOptions.EnablePrivileges = true;

            SelectQuery query = new SelectQuery("select * from Win32_OperatingSystem");
            ManagementScope manScope = new ManagementScope(@"\\" + compName + @"\root\cimv2", connOptions);

            try
            {
                manScope.Connect();
            }
            catch (Exception e)
            {
                TxtBox_Output.AppendText(e.Message);
                return;
            }
            ManagementObjectSearcher mOS = new ManagementObjectSearcher(manScope, query);


            foreach (ManagementObject mO in mOS.Get())
            {
                ManagementBaseObject inParams = mO.GetMethodParameters("Win32Shutdown");
                inParams["Flags"] = flag;
                ManagementBaseObject outParams = mO.InvokeMethod("Win32Shutdown", inParams, null);
            }
        }
        /// </summary>
        /// <param name="compName"></param>
        /// <returns></returns>
        private string GetUserName(string compName)
        {
            //Clipboard.GetText()
            try
            {
                Process.GetProcessesByName("explorer", compName);
            }
            catch (Exception)
            {

            }
            string user = "";
            foreach (var p in Process.GetProcessesByName("explorer", compName))
            {
                user = GetProcessOwner(p.Id, compName);
            }
            return user;
        }

        public static string GetProcessOwner(int processId, string compName)
        {
            //var query = "Select * From Win32_Process Where ProcessID = " + processId;
            
            
            SelectQuery query = new SelectQuery("Select * From Win32_Process Where ProcessID = " + processId);
            ManagementScope manScope = new ManagementScope(@"\\"+ compName + @"\root\cimv2");


            ManagementObjectCollection processList;

            using (var searcher = new ManagementObjectSearcher(manScope, query))
            {
                processList = searcher.Get();
            }

            foreach (var mo in processList.OfType<ManagementObject>())
            {
                object[] argList = { string.Empty, string.Empty };
                var returnVal = Convert.ToInt32(mo.InvokeMethod("GetOwner", argList));

                if (returnVal == 0)
                {
                    // return DOMAIN\user
                    return argList[1] + "\\" + argList[0];
                }
            }

            return "No User";
        }



        /// <summary>
        /// ////////////////////
        /// </summary>
        /// <param name="compName"></param>
        /// <returns></returns>
        private string GetUserNameOld(string compName)
        {
            //Clipboard.GetText()
            try
            {
                Process.GetProcessesByName("explorer", compName);
            }
            catch (Exception)
            {
                Console.WriteLine("cannot get user");
            }
            string user = "";
            foreach (var p in Process.GetProcessesByName("explorer", compName))
            {
                user = GetProcessOwner(p.Id, compName);
            }
            return user;
        }

        private string GetProcessOwnerNew(int processId)
        {
            //var query = "Select * From Win32_Process Where ProcessID = " + processId;
            SelectQuery query = new SelectQuery("Select * From Win32_Process Where ProcessID = " + processId);
            ManagementObjectCollection processList;

            ManagementScope manScope = new ManagementScope(@"\\M513667\root\cimv2");

            manScope.Connect();

            ManagementObjectSearcher mOS = new ManagementObjectSearcher(manScope, query);


            using (var searcher = new ManagementObjectSearcher(manScope, query))
            {
                processList = searcher.Get();
            }

            foreach (var mo in processList.OfType<ManagementObject>())
            {
                object[] argList = { string.Empty, string.Empty };
                var returnVal = Convert.ToInt32(mo.InvokeMethod("GetOwner", argList));

                if (returnVal == 0)
                {
                    // return DOMAIN\user
                    return argList[1] + "\\" + argList[0];
                }
            }

            return "No User";
        }
        /// <summary>
        /// ///////////////////
        /// </summary>
        private void WMITest()
        {
            SelectQuery query = new SelectQuery("Win32_computersystem");
            ManagementScope manScope = new ManagementScope(@"\\megalapxx\root\cimv2");
            manScope.Connect();

            ManagementObjectSearcher mOS = new ManagementObjectSearcher(manScope, query);

            string s = "";

            foreach (var da in mOS.Get())
            {
                s = da.GetPropertyValue("username").ToString();
            }
            string test = s;
        }

        private void CMDTest()
        {
            //myProcess.Exited += new EventHandler(myProcess_Exited);

            System.Diagnostics.Process cmd = new System.Diagnostics.Process();
            cmd.StartInfo.FileName = "cmd.exe";
            cmd.StartInfo.RedirectStandardInput = true;
            cmd.StartInfo.RedirectStandardOutput = true;
            cmd.StartInfo.CreateNoWindow = false;
            cmd.StartInfo.UseShellExecute = false;

            cmd.Exited += new EventHandler(MyHandle);

            string script = "/c ipconfig /all";
            cmd.StartInfo.Arguments = script;
            cmd.Start();
            //cmd.StandardInput.WriteLine("/c pause");
            //cmd.StandardInput.WriteLine("/c cd users\\kylec\\downloads\\scripting\\PS Tools");

            //extra
            //cmd.StandardInput.WriteLine("echo Oscar");
            cmd.StandardInput.Flush();
            cmd.StandardInput.Close();
            cmd.WaitForExit();
            Console.WriteLine(cmd.StandardOutput.ReadToEnd());
            cmd.Close();

        }

        void MyHandle(object o, System.EventArgs ea)
        {
            string s = (o as Process).StandardOutput.ReadToEnd();

        }

        private void RestartTest(string compName)
        {
            Process p = new Process();
            p.StartInfo.UseShellExecute = false;
            p.StartInfo.RedirectStandardOutput = true;
            p.StartInfo.RedirectStandardError = true;
            p.StartInfo.RedirectStandardInput = true;
            p.StartInfo.CreateNoWindow = true;
            p.StartInfo.FileName = Environment.CurrentDirectory + @"\PSTools\psexec.exe";             //@"E:\Private\Tool\PsTools\PsExec.exe";
            p.StartInfo.Arguments = @"\\lappy5000 shutdown /r /t 0";                                                               //@"\\remotemachine cmd.exe ipconfig /all";
            p.Start();

            string output = p.StandardOutput.ReadToEnd();
            string errormessage = p.StandardError.ReadToEnd();
            Console.WriteLine(output);
            TxtBox_Output.AppendText(errormessage);

            p.WaitForExit();
        }

        private void NewTest()
        {
            Process p = new Process();
            p.StartInfo.UseShellExecute = false;
            p.StartInfo.RedirectStandardOutput = true;
            p.StartInfo.RedirectStandardError = true;
            p.StartInfo.RedirectStandardInput = true;
            p.StartInfo.FileName = "c:\\users\\kylec\\downloads\\scripting\\PS Tools\\psinfo.exe";             //@"E:\Private\Tool\PsTools\PsExec.exe";
            p.StartInfo.Arguments = @"\\megalapxx";                                                               //@"\\remotemachine cmd.exe ipconfig /all";
            p.Start();

            string output = p.StandardOutput.ReadToEnd();
            string errormessage = p.StandardError.ReadToEnd();
            Console.WriteLine(output);
            TxtBox_Output.AppendText(output);
            p.WaitForExit();
        }

        private void RealTest()
        {
            System.Diagnostics.Process cmd = new System.Diagnostics.Process();
            cmd.StartInfo.FileName = "cmd.exe";
            cmd.StartInfo.RedirectStandardInput = true;
            cmd.StartInfo.RedirectStandardOutput = true;
            cmd.StartInfo.CreateNoWindow = true;
            cmd.StartInfo.UseShellExecute = false;

            //string script = "/c ipconfig /all";
            //cmd.StartInfo.Arguments = script;
            cmd.Start();


            cmd.StandardInput.WriteLine("C:");
            cmd.StandardInput.WriteLine("cd users\\kylec\\downloads\\scripting\\PS Tools");
            cmd.StandardInput.WriteLine("psinfo");


            //cmd.WaitForExit();
            Console.WriteLine(cmd.StandardOutput.ReadToEnd());

            cmd.StandardInput.Flush();
            cmd.StandardInput.Close();

        }

        private void XMLShiz()
        {
            XmlWriterSettings xmlSettings = new XmlWriterSettings();
            var r = xmlSettings.NewLineHandling;
            xmlSettings.Indent = true;
            xmlSettings.IndentChars = "\t";
            xmlSettings.NewLineOnAttributes = true;

            /*
            using (XmlWriter writer = XmlWriter.Create(localSettingsSavePath + @"\localSettings.xml", xmlSettings))
            {
                writer.WriteStartElement("settings");
                writer.WriteElementString("DefaultBrowser", selectedDefaultBrowser);
                writer.WriteEndElement();

                //writer.WriteAttributeString("Bar", "Some & value");
                writer.Flush();
            }
            
            //hide a file     File.SetAttributes(path, File.GetAttributes(path) | FileAttributes.Hidden);

            using (System.IO.StreamWriter file = new System.IO.StreamWriter(@"C:\Users\" + Environment.UserName + @"\TestSettings.xml", false))
            {
                file.WriteLine("Fourth line");
            }
             
             */
        }

        private void restTest(string compName)
        {
            Process p = new Process();
            p.StartInfo.FileName = "cmd.exe";
            p.StartInfo.Arguments = @"shutdown /l /f /m \\" + compName;
            p.StartInfo.UseShellExecute = false;
            p.StartInfo.RedirectStandardError = true;
            p.StartInfo.RedirectStandardOutput = true;
            p.StartInfo.CreateNoWindow = true;
            p.Start();

            TxtBox_Output.AppendText(p.StandardError.ReadToEnd());
            TxtBox_Output.AppendText(p.StandardOutput.ReadToEnd());

        }
        private void testing(string HostName)
        {
            //object o = Microsoft.VisualBasic. Interaction.GetObject(@":\\" + HostName & @"\root\CIMV2");
            try
            {
                ConnectionOptions connOptions = new ConnectionOptions();
                connOptions.Impersonation = ImpersonationLevel.Impersonate;
                connOptions.EnablePrivileges = true;
                ManagementScope manScope = new ManagementScope(String.Format(@"\\{0}\ROOT\CIMV2", HostName), connOptions);
                manScope.Connect();
                ObjectQuery oQuery = new ObjectQuery("select Username from Win32_ComputerSystem");
                ManagementObjectSearcher oSearcher = new ManagementObjectSearcher(manScope, oQuery);
                ManagementObjectCollection oReturn = oSearcher.Get();

                foreach (ManagementObject o in oReturn)
                {
                    Console.WriteLine(o.Properties);
                }
            }
            catch
            {

            }
        }

        public void LogOffFromMachine(string MachineName)
        {
            try
            {
                ConnectionOptions connOptions = new ConnectionOptions();
                connOptions.Impersonation = ImpersonationLevel.Impersonate;
                connOptions.EnablePrivileges = true;
                ManagementScope manScope = new ManagementScope(String.Format(@"\\{0}\ROOT\CIMV2", MachineName), connOptions);
                manScope.Connect();
                ObjectQuery oQuery = new ObjectQuery("select * from Win32_OperatingSystem");
                ManagementObjectSearcher oSearcher = new ManagementObjectSearcher(manScope, oQuery);
                ManagementObjectCollection oReturn = oSearcher.Get();
                foreach (ManagementObject mo in oReturn)
                {
                    ManagementBaseObject inParams = mo.GetMethodParameters("Win32Shutdown");
                    inParams["Flags"] = 0;
                    ManagementBaseObject outParams = mo.InvokeMethod("Win32Shutdown", inParams, null);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        private void TestThis()
        {
            string nameSpace = @"root\cimv2";
            string query = "SELECT * FROM Win32_OperatingSystem";
            CimSession mySession = CimSession.Create(@"\\megalapxx");
            IEnumerable<CimInstance> queryInstance = mySession.QueryInstances(nameSpace, "WQL", query);


            // ManagementScope scope = new ManagementScope("\\\\Computer_B\\root\\cimv2");
            // scope.Connect();
            // ObjectQuery query = new ObjectQuery("SELECT * FROM Win32_OperatingSystem");
            // ManagementObjectSearcher searcher = new ManagementObjectSearcher(scope, query);

            //Process.Start(files[1]);


            //object o = Marshal.GetActiveObject(@"winmgmts:{(Debug,RemoteShutdown)}\\" + "megalapxx" + @"\root\CIMV2");
            object o = Microsoft.VisualBasic.Interaction.GetObject(@"winmgmts:{(Debug,RemoteShutdown)}\\" + "MegaLapxx" + @"\root\CIMV2");
            //OpSysSet = o.ExecQuery("Select * From Win32_OperatingSystem");
            SelectQuery q = new SelectQuery("Select * From Win32_OperatingSystem");


            try
            {
                ManagementObjectSearcher searcher =
                    new ManagementObjectSearcher("root\\CIMV2",
                    "SELECT * FROM Win32_OperatingSystem");

                foreach (ManagementObject queryObj in searcher.Get())
                {
                    ManagementBaseObject inParams = queryObj.GetMethodParameters("Win32Shutdown");
                    inParams["Flags"] = 4;
                    ManagementBaseObject outParams = queryObj.InvokeMethod("Win32Shutdown", inParams, null);
                    Console.WriteLine("-----------------------------------");
                    Console.WriteLine("Win32_OperatingSystem instance");
                    Console.WriteLine("-----------------------------------");
                    //queryObj.
                }
            }
            catch (ManagementException e)
            {
                MessageBox.Show("An error occurred while querying for WMI data: " + e.Message);
            }
        }

        private void AddPrinter()
        {
            try
            {
                ManagementClass classInstance =
                    new ManagementClass("root\\CIMV2",
                    "Win32_Printer", null);

                // Obtain in-parameters for the method
                ManagementBaseObject inParams = classInstance.GetMethodParameters("AddPrinterConnection");

                // Add the input parameters.
                inParams["Name"] = "\\\\PrintServer\\PrinterName";

                // Execute the method and obtain the return values.
                ManagementBaseObject outParams = classInstance.InvokeMethod("AddPrinterConnection", inParams, null);

                // List outParams
                Console.WriteLine("Out parameters:");
                Console.WriteLine("ReturnValue: " + outParams["ReturnValue"]);
            }
            catch (ManagementException err)
            {
                MessageBox.Show("An error occurred while trying to execute the WMI method: " + err.Message);
            }


        }

        private void UnmapPrinter()
        {
            ConnectionOptions options = new ConnectionOptions();
            options.EnablePrivileges = true;
            ManagementScope scope = new ManagementScope(ManagementPath.DefaultPath, options);
            scope.Connect();
            ManagementClass win32Printer = new ManagementClass("Win32_Printer");
            ManagementObjectCollection printers = win32Printer.GetInstances();
            foreach (ManagementObject printer in printers)
            {
                printer.Delete();
            }

            ///////// or

            using (var printer = new ManagementObject($"Win32_Printer.DeviceID='{"\\\\printerName"}'"))
                printer.Delete();

            win32Printer.Dispose();
            printers.Dispose();
        }

        private void OldIAM()
        {
            if (CkBox_IAM.Checked)
            {
                try
                {
                    //Process.Start("https://iam-old.albertahealthservices.ca/admin/changeUserPassword.jsp?newView=true&id=" + firstName + lastName + "&lang=en&cntry=US");
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
            if (CkBox_IAM.Checked)
            {
                try
                {
                    //Process.Start("https://iam-old.albertahealthservices.ca/account/view.jsp?id=" + user + "&lang=en&cntry=US");
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }

        private void OldARS()
        {
            ///////// old ///////////
            string userName = "";
            //if we are using first and last name
            if (userName is string)//Array)
            {
                string[] tempArr = new string[10];
                //do the search for the first + last name
                string firstName = tempArr[0];
                string lastName = tempArr[1];

                if (CkBox_ARS.Checked)
                {
                    try
                    {
                        Process.Start("https://ars.healthy.bewell.ca/ARServerAdmin/SearchResult.aspx?TaskId=QuickSearch&SearchID=19&TM=0.882410500143846&Anr=" + firstName + "+" + lastName);
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
                    }
                }


            }

            //
            else if ((userName as string).Contains("."))
            {
                //we are using the email address
                //https://ars.healthy.bewell.ca/ARServerAdmin/SearchResult.aspx?TaskId=QuickSearch&SearchID=19&TM=0.163324797602056&Anr=kyle.crawford%40albertahealthservices.ca
            }


            //we are using the username
            else
            {
                //do the search for the username
                string user = (string)userName;
                if (CkBox_ARS.Checked)
                {
                    try
                    {
                        Process.Start("https://ars.healthy.bewell.ca/ARServerAdmin/GenerateForm.aspx?TaskId=UserProperties&TargetClass=user&DN=CN%3d" + user + "%2cOU%3dGeneral%2cOU%3dEDM%2cOU%3dUsers%2cOU%3dAccounts%2cDC%3dhealthy%2cDC%3dbewell%2cDC%3dca");
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
                    }
                }

                if (CkBox_ARS.Checked && CkBox_IAM.Checked)
                    System.Threading.Thread.Sleep(2500);


            }
        }

        private void ViewProcesses(string compName)
        {
            Process p = new Process();
            p.StartInfo.FileName = Environment.CurrentDirectory + @"\PSTools\pslist.exe";
            p.StartInfo.Arguments = @"\\" + compName;
            p.StartInfo.RedirectStandardOutput = true;
            p.StartInfo.UseShellExecute = false;
            p.StartInfo.RedirectStandardError = true;
            p.StartInfo.CreateNoWindow = true;
            p.EnableRaisingEvents = true;
            p.Exited += ViewProcReturn;
            p.Start();

            string output = p.StandardOutput.ReadToEnd();
            string error = p.StandardError.ReadToEnd();

            //List<string> processes = output.Split(new char[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries).ToList();
            //processes.Sort();


        }

        private void ViewProcReturn(object proc, System.EventArgs s)
        {

            //if we have not been passed a process
            if (!(proc is Process))
                return;
            Process p = (proc as Process);
            //string output = p.StandardOutput.ReadToEnd();
            //string error = p.StandardError.ReadToEnd();

            //if the output is blank that is the only time to print the error

            ProcessesForm procForm = new ProcessesForm(this, TxtBox_CompName.Text);

            procForm.Show();

            p.Dispose();
        }
        /*
         * #remove-printer -name "\\wsprint07\CNTIS60"



add-printer -connectionname "\\WSprint07\CNTIS60"

#set as default
$wshNet = New-Object -ComObject WScript.Network
$wshNet.SetDefaultPrinter("\\wsprint07\CNTIS60")


//Get-WMIObject Win32_Printer -ComputerName $env:COMPUTERNAME | select-object name | where-object {$_.name -like "\\*"}

#get-printer \\m461636

//Get-WmiObject Win32_Printer | select -property Name, Default | where-object {$_.Name -like "\\*"} | export-csv -Path ($path + "\printers.csv")

        foreach ($item in $csv)
        {
            (new-Object -ComObject WScript.Network).AddWindowsPrinterConnection($item.name)

            #if the printer was the default printer before, set it as default again.
            if ($item.Default)
            {
                (new-Object -ComObject WScript.Network).SetDefaultPrinter($item.Name)
            }
        }


*/




        private void CreateDefaultVisuals()
        {

            List<string> stuffToSave = new List<string>();

            stuffToSave.Add(this.BackColor.ToArgb().ToString());
            //stuffToSave.Add("path to the background picture - if any");
            stuffToSave.Add(Color.FromKnownColor(KnownColor.Control).ToArgb().ToString());
            stuffToSave.Add("255");
            stuffToSave.Add(Color.FromKnownColor(KnownColor.Control).ToArgb().ToString());
            stuffToSave.Add("255");
            stuffToSave.Add(this.Font.Name);
            stuffToSave.Add(Font.SizeInPoints.ToString());
            stuffToSave.Add(Font.Bold.ToString());
            stuffToSave.Add(Font.Italic.ToString());
            stuffToSave.Add(Font.Underline.ToString());

            Color defaultColour = Color.FromKnownColor(KnownColor.Control);
            int Opacity = 255;

            string fontName = "Microsoft Sans Serif";

            float fontSize = 8.25f;

            bool bold = false;
            bool italics = false;
            bool underline = false;

            //save profile

        }



        /// ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        //Test Code From here it be.

        public void StopWarningMessages()
        {
            StartProcess("test");
            ViewProcesses("test");
            //GetWinVer("test");
        }

        private void StartProcess(string processName)
        {
            try
            {
                Process.Start(processName);
                PrintOutput("Opening " + processName);
            }
            catch (Exception e)
            {
                PrintOutput(e.Message);
            }
        }



        //Computer\HKEY_Users\SID\Printers\Connections\(this is where the name of the printers live)                                                -- Connections
        //Computer\HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows NT\CurrentVersion\ProfileList\S-1-5-21-38857442-2693285798-3636612711-15565138   -- ProfileImagePath
        //Computer\HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows NT\CurrentVersion\ProfileList                                                      --find the users SID if they are not logged in
        //need a function to get the current user of the computer
        //GetCurrentUser(TxtBox_CompName.Text);
        // GetUserNameOfRemoteMachine();

        //Microsoft.Win32.Registry.GetValue()
        //PrintTest(TxtBox_CompName.Text.Trim());

        public void AvailablePrinters(string compName)
        {
            ConnectionOptions connOptions = new ConnectionOptions
            {
                Impersonation = ImpersonationLevel.Impersonate,
                EnablePrivileges = true
            };

            //SelectQuery query = new SelectQuery("select * from Win32_OperatingSystem");
            ManagementScope oManagementScope = new ManagementScope(@"\\" + compName + @"\root\cimv2", connOptions);

            try
            {
                oManagementScope.Connect();
            }
            catch (Exception e)
            {
                TxtBox_Output.AppendText(e.Message);
            }

            SelectQuery oSelectQuery = new SelectQuery
            {
                QueryString = @"SELECT Name FROM Win32_Printer"
            };

            ManagementObjectSearcher oObjectSearcher = new ManagementObjectSearcher(oManagementScope, @oSelectQuery);
            ManagementObjectCollection oObjectCollection = oObjectSearcher.Get();

            foreach (ManagementObject oItem in oObjectCollection)
            {

                Console.WriteLine("Name : " + oItem["Name"].ToString() + Environment.NewLine);
            }

            oObjectSearcher.Dispose();
        }


        private void PrintTest(string compName)
        {

            //We need to collect the printers of a remote computer

            //wmi cannot do this directly, time to query the target computer's registry

            Process p = new Process();
            p.StartInfo.FileName = Environment.CurrentDirectory + @"\PSTools\PsGetsid.exe";
            //p.StartInfo.Arguments = @"\\" + compName + " " + GetCurrentUser(compName);
            p.StartInfo.RedirectStandardOutput = true;
            p.StartInfo.RedirectStandardError = true;
            p.StartInfo.UseShellExecute = false;
            p.StartInfo.CreateNoWindow = true;
            p.Start();

            //string error = p.StandardError.ReadToEnd();
            string output = p.StandardOutput.ReadToEnd();

            string[] testAr = output.Split(new char[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);
            //get all the processes of a remote computer and get the username who owns 
            //if successful, [1] will have the SID
            string SID = testAr[1];

            Microsoft.Win32.RegistryKey environmentKey = Microsoft.Win32.RegistryKey.OpenRemoteBaseKey(Microsoft.Win32.RegistryHive.Users, compName).OpenSubKey(SID + @"\Printers\Connections");

            List<string> printerList = new List<string>();

            foreach (string s in environmentKey.GetSubKeyNames())
            {
                printerList.Add(s);
                //Console.WriteLine(s);
            }

            //we have the printers. Now, display them

            environmentKey.Dispose();
            p.Dispose();
        }

        private void PrinterTest()
        {
            // PingTest(TxtBox_CompName.Text);


            //Print Test 
            //Copying file to target computer - then running said script (Maybe with PSExec?)

            string filePath = Environment.CurrentDirectory + @"\PSUtils\AddPrinter.ps1";

            if (!File.Exists(@"\\m513667\c$\users\kylecrawford\AddPrinter.ps1"))
                File.Copy(filePath, @"\\m513667\c$\users\kylecrawford\AddPrinter.ps1");


            Process p = new Process();
            p.StartInfo.FileName = Environment.CurrentDirectory + @"\PSTools\psexec.exe";
            p.StartInfo.Arguments = @"\\" + "m513667" + " " + @"start c:\users\kylecrawford\AddPrinter.ps1";
            p.StartInfo.RedirectStandardOutput = true;
            p.StartInfo.RedirectStandardError = true;
            p.StartInfo.UseShellExecute = false;
            p.StartInfo.CreateNoWindow = true;
            p.Exited += AddPrinterExit;

            try
            {
                p.Start();
            }
            catch (Exception ex)
            {
                TxtBox_Output.AppendText(ex.Message);
            }

            //Process is disposed in callback
        }

        private void AddPrinterExit(object proc, EventArgs e)
        {
            (proc as Process).Dispose();
        }

        public static string GetInternetShortcut(string filePath)
        {
            string url = "";

            using (TextReader reader = new StreamReader(filePath))
            {
                string line = "";
                while ((line = reader.ReadLine()) != null)
                {
                    if (line.StartsWith("URL="))
                    {
                        string[] splitLine = line.Split('=');
                        if (splitLine.Length > 0)
                        {
                            url = splitLine[1];
                            break;
                        }
                    }
                }
            }

            return url;
        }

    }
}
