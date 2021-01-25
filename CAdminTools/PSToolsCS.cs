using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace CAdminTools
{
    class PSToolsCS
    {
        private string _fileDirectory;

        public event EventHandler LookupFinished;

        public PSToolsCS(string directory)
        {
            _fileDirectory = directory;
        }

        /// <summary>
        /// Gets the current uptime for the provided computername
        /// </summary>
        /// <param name="compName"> Target computer to get current uptime. </param>
        public void GetUpTime(string compName)
        {
            Process p = new Process();
            p.StartInfo.FileName = _fileDirectory + @"\psinfo.exe";
            p.StartInfo.Arguments = @"\\" + compName;
            p.StartInfo.RedirectStandardOutput = true;
            p.StartInfo.RedirectStandardError = true;
            p.StartInfo.UseShellExecute = false;
            p.StartInfo.CreateNoWindow = true;
            p.EnableRaisingEvents = true;
            p.Exited += UpReturn;

            try
            {
                p.Start();
            }
            catch (Exception e)
            {

                OnCompletedLookup(new PSToolsEventArgs(e.Message));
            }

            //process is disposed in return method
        }

        /// <summary>
        /// Return for the GetUpTime method. Filters down the data to only return the uptime of the computer
        /// </summary>
        /// <param name="proc"> The sending process </param>
        /// <param name="s">  </param>
        private void UpReturn(object proc, System.EventArgs s)
        {
            //if we have not been passed a process
            if (!(proc is Process))
            {
                return;

            }
            Process p = (proc as Process);
            string output = p.StandardOutput.ReadToEnd();
            string error = p.StandardError.ReadToEnd();

            //if the output is blank that is the only time to print the error
            if (output == "")
            {
                OnCompletedLookup(new PSToolsEventArgs(error));

            }
            else
            {
                List<string> outputs = new List<string>();
                outputs = output.Split(new char[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries).ToList();
                OnCompletedLookup(new PSToolsEventArgs(outputs[0] + Environment.NewLine + outputs[1]));
            }
            
            p.Dispose();
        }

        /// <summary>
        /// Gets the PC Info (PSINFO.exe) for the provided computer name
        /// </summary>
        /// <param name="compName"> Target computer name </param>
        public void GetPCInfo(string compName)
        {
            Process p = new Process();
            p.StartInfo.FileName = _fileDirectory + @"\psinfo.exe";
            p.StartInfo.Arguments = @"\\" + compName;
            p.StartInfo.RedirectStandardOutput = true;
            p.StartInfo.RedirectStandardError = true;
            p.StartInfo.UseShellExecute = false;
            p.StartInfo.CreateNoWindow = true;
            p.EnableRaisingEvents = true;
            p.Exited += ProcReturn;

            try
            {
                p.Start();
            }
            catch (Exception e)
            {
                OnCompletedLookup(new PSToolsEventArgs(e.Message));
            }

            //process is disposed in return method
        }

        /// <summary>
        /// Return method for PSInfo or PSExec calls to return their output
        /// </summary>
        /// <param name="proc"> Sending Process </param>
        /// <param name="s">  </param>
        private void ProcReturn(object proc, EventArgs e)
        {
            
            //if we have not been passed a process or is null
            if (!(proc is Process))
                return;
            Process p = (proc as Process);
            string error = p.StandardError.ReadToEnd();
            string output = p.StandardOutput.ReadToEnd();

            //only prints if there is text to be printed
            if (error != "")
            {
                OnCompletedLookup(new PSToolsEventArgs(output));
            }
                //ToOutput();
            if (output != "")
            {
                OnCompletedLookup(new PSToolsEventArgs(error));
            }

            p.Dispose();
        }

        /// <summary>
        /// Starts a psexec process to attempt to open provided site on target computer
        /// </summary>
        /// <param name="compName"> Target computer </param>
        /// <param name="site"> Target website </param>
        public void OpenRemSite(string compName, string site)
        {
            Process p = new Process();
            p.StartInfo.FileName = _fileDirectory + @"\psexec.exe";
            p.StartInfo.Arguments = @"\\" + compName + " -i -d -e Explorer " + site;
            p.StartInfo.RedirectStandardOutput = true;
            p.StartInfo.RedirectStandardError = true;
            p.StartInfo.UseShellExecute = false;
            p.StartInfo.CreateNoWindow = true;

            try
            {
                p.Start();
            }
            catch (Exception e)
            {
                OnCompletedLookup(new PSToolsEventArgs(e.Message));
            }
        }

        private void GetWinVer(string compName)
        {
            Process p = new Process();
            p.StartInfo.FileName = Environment.CurrentDirectory + @"\PSTools\psinfo.exe";
            p.StartInfo.Arguments = @"\\" + compName;
            p.StartInfo.RedirectStandardOutput = true;
            p.StartInfo.RedirectStandardError = true;
            p.StartInfo.UseShellExecute = false;
            p.StartInfo.CreateNoWindow = true;
            p.EnableRaisingEvents = true;
            p.Exited += ProcReturn;
            p.Start();



            //string output = p.StandardOutput.ReadToEnd();
            //string error = p.StandardError.ReadToEnd();

            //TxtBox_Output.AppendText(error + Environment.NewLine);
            //TxtBox_Output.AppendText(output);

            //////////test
            string output = p.StandardOutput.ReadToEnd();
            string error = p.StandardError.ReadToEnd();

            List<string> testList = output.Split(new char[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries).Where(o => o.Contains("Kernel version")).ToList();
            if (testList.Count > 0)
            {
                //we have the Windows verseion
                testList = testList[0].Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).ToList();
                foreach (string s in testList)
                {
                    if (Int32.TryParse(s, out int result))
                    {
                        //we have a number
                        if (result == 7)
                        {
                            //windows 7
                        }
                        else if (result == 10)
                        {
                            //windows 10
                        }
                        else
                        {
                            //anything else
                        }


                    }
                }
            }

            //List<string> temp = testList.Where(o => o.Contains("Kernel version")).ToList();

        }


        protected virtual void OnCompletedLookup(PSToolsEventArgs e)
        {
            LookupFinished?.Invoke(this, e);
        }

    }


    class PSToolsEventArgs : EventArgs
    {
        public string Message { get; private set; }

        public PSToolsEventArgs(string message)
        {
            Message = message;
        }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    class EventArgs<T> : EventArgs
    {

        public T Message { get; private set; }

        public EventArgs(T message)
        {
            Message = message;
        }

    }
}
