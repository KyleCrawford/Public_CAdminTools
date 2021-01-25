using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Net;
using System.Management;
using System.IO;
using System.Xml;

namespace CAdminTools
{
    class WindowsFunctions
    {
        /// <summary>
        /// Attempts to get the username of the current user of the target computer
        /// </summary>
        /// <param name="compName"> Target computer </param>
        /// <returns> Name of the current user, blank if failure, or error message </returns>
        public static string GetCurrentUser(string compName)
        {
            string computer = compName;
            if (computer == "")
            {
                return "";
            }
            ConnectionOptions connOptions = new ConnectionOptions
            {
                Impersonation = ImpersonationLevel.Impersonate,
                EnablePrivileges = true
            };

            SelectQuery query = new SelectQuery("select UserName from Win32_ComputerSystem");
            ManagementScope manScope = new ManagementScope(@"\\" + computer + @"\root\cimv2", connOptions);
            try
            {
                manScope.Connect();
            }
            catch (Exception e)
            {
                if (e.Message != "Access is denied. (Exception from HRESULT: 0x80070005 (E_ACCESSDENIED))")
                {
                    //PrintOutput(e.Message);
                    OnOutputPrint(new WinEventArgs(e.Message));
                }
                return "";
            }
            using (ManagementObjectSearcher mOS = new ManagementObjectSearcher(manScope, query))
            {
                foreach (ManagementObject mO in mOS.Get())
                {
                    if (mO["username"] != null)
                    {
                        mOS.Dispose();
                        return mO["username"].ToString();
                    }
                }
            }

            return "";

        }



        /// <summary>
        /// Opens the local installation of LANDesk to the provided server and computer name
        /// </summary>
        /// <param name="server"> Server name for LANDesk </param>
        /// <param name="compName"> Target computer name </param>
        public static void RunLANDesk(string server, string compName)
        {
            Process p = new Process();
            p.StartInfo.FileName = @"C:\Program Files (x86)\LANDesk\ServerManager\RCViewer\isscntr.exe";
            p.StartInfo.Arguments = "/s" + server + " /a" + compName + " /c" + "\"Remote Control\"";                         //"/s" & My.Settings.LANDeskCore & " /a" & txtComputer.Text.Trim & " /c" & Chr(34) & "Remote Control" & Chr(34)
            p.StartInfo.CreateNoWindow = true;
            p.StartInfo.UseShellExecute = false;
            p.StartInfo.RedirectStandardOutput = false;

            try
            {
                p.Start();
            }
            catch (Exception e)
            {
                //PrintOutput(e.Message);
                OnOutputPrint(new WinEventArgs(e.Message));
            }
        }

        /// <summary>
        /// Opens the provided browser to connect to the target computer for a LANDesk web assistance session
        /// </summary>
        /// <param name="compName"> Target computer </param>
        /// <param name="browser"> Browser to be opened </param>
        /// <returns></returns>
        public static string RunLANDeskWeb(string compName, string browser)
        {
            Process p = new Process();
            p.StartInfo.FileName = browser;
            p.StartInfo.Arguments = "https://" + compName + ":4343";
            p.StartInfo.CreateNoWindow = true;
            p.StartInfo.UseShellExecute = false;

            try
            {
                p.Start();
            }
            catch (Exception e)
            {
                p.Dispose();
                return e.Message;
            }

            List<string> splitPath = browser.Split(new char[] { '\\' }, StringSplitOptions.RemoveEmptyEntries).ToList();
            string browserName = splitPath[splitPath.Count - 1];
            p.Dispose();
            return "Opening Web LANDesk using " + browserName + " to connect to " + compName;
        }

        public static void OpenRCViewer()
        {
            Process p = new Process();
            p.StartInfo.FileName = Environment.CurrentDirectory + @"\RCViewer.exe";
            //p.StartInfo.Arguments = "/s" + server + " /a" + compName + " /c" + "\"Remote Control\"";                         //"/s" & My.Settings.LANDeskCore & " /a" & txtComputer.Text.Trim & " /c" & Chr(34) & "Remote Control" & Chr(34)
            p.StartInfo.CreateNoWindow = true;
            p.StartInfo.UseShellExecute = false;
            p.StartInfo.RedirectStandardOutput = false;

            try
            {
                p.Start();
            }
            catch (Exception ex)
            {
                //PrintOutput(ex.Message);
                OnOutputPrint(new WinEventArgs(ex.Message));
            }
        }

        /// <summary>
        /// Starts a Windows RDP session with the provided computer name
        /// </summary>
        /// <param name="compName"> Target computer name to remote to. </param>
        public static void RunWinRDP(string compName)
        {
            try
            {
                Process.Start("mstsc.exe", "/v " + compName);
            }
            catch (Exception e)
            {
                //PrintOutput(e.Message);
                OnOutputPrint(new WinEventArgs(e.Message));
            }
        }

        private struct ShutDownArgs
        {
            public bool isLogOff;
            public string compName;
        }

        /// <summary>
        /// Calls a ThreadPool method to remotely log off or restart a computer
        /// </summary>
        /// <param name="isLogOff"> True if logging off, false if restarting </param>
        /// <param name="compName"> Target computer name </param>
        public static void RemoteLogOfforRestart(bool isLogOff, string compName)
        {
            ShutDownArgs argPass;
            argPass.compName = compName;
            argPass.isLogOff = isLogOff;

            System.Threading.ThreadPool.QueueUserWorkItem(TLogOfforRestart, argPass);
        }

        /// <summary>
        /// Thread method to remotely restart to log off computer.
        /// </summary>
        /// <param name="args"> ShutDownArgs == isLogOff, compName </param>
        private static void TLogOfforRestart(object args)
        {
            ShutDownArgs info = (ShutDownArgs)args;
            //  true : false
            //logoff : Restart
            int flag = info.isLogOff ? 0 : 6;

            ConnectionOptions connOptions = new ConnectionOptions
            {
                Impersonation = ImpersonationLevel.Impersonate,
                EnablePrivileges = true,
            };

            SelectQuery query = new SelectQuery("select * from Win32_OperatingSystem");
            ManagementScope manScope = new ManagementScope(@"\\" + info.compName + @"\root\cimv2", connOptions);

            try
            {
                manScope.Connect();
            }
            catch (Exception e)
            {
                //TxtBox_Output.AppendText(e.Message);
                //PrintOutput(e.Message);
                OnOutputPrint(new WinEventArgs(e.Message));
                return;
            }
            ManagementObjectSearcher mOS = new ManagementObjectSearcher(manScope, query);

            foreach (ManagementObject mO in mOS.Get())
            {
                ManagementBaseObject inParams = mO.GetMethodParameters("Win32Shutdown");
                inParams["Flags"] = flag;
                ManagementBaseObject outParams = mO.InvokeMethod("Win32Shutdown", inParams, null);
            }
            mOS.Dispose();
        }

        /// <summary>
        /// Opens the Computer Manager for the provided computer name
        /// </summary>
        /// <param name="compName"> Target computer name </param>
        public static void RunPCManage(string compName)
        {
            ProcessStartInfo psi = new ProcessStartInfo
            {
                FileName = "compmgmt.msc",
                Arguments = "/computer=" + compName
            };
            try
            {
                Process.Start(psi);
            }
            catch (Exception e)
            {
                //PrintOutput(e.Message);
                OnOutputPrint(new WinEventArgs(e.Message));
            }


        }

        /// <summary>
        /// Opens file explorer to the provided computer name's C drive
        /// </summary>
        /// <param name="compName"> Target computer name </param>
        public static void OpenRemoteC(string compName)
        {
            Process p = new Process();
            p.StartInfo.FileName = "explorer.exe";
            p.StartInfo.Arguments = @"\\" + compName + @"\c$";
            try
            {
                p.Start();
            }
            catch (Exception e)
            {
                //PrintOutput(e.Message);
                OnOutputPrint(new WinEventArgs(e.Message));
            }

            p.Dispose();
        }

        public static event EventHandler OutputPrinting;
            

        protected static void OnOutputPrint(WinEventArgs e)
        {
            OutputPrinting?.Invoke(null, e);
        }
    }

    class WinEventArgs : EventArgs
    {
        public string Message { get; private set; }

        public WinEventArgs(string message)
        {
            Message = message;
        }
    }
}
