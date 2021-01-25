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

namespace CAdminTools
{
    /// <summary>
    /// Used to hold all the running processes on a given computer. Able to sort by any field. 
    /// Able to attempt to end processes on the computer
    /// </summary>
    public partial class ProcessesForm : Form
    {
        //used to safely add information to a ListView control
        private delegate void UpdateListView(List<ListViewItem> lviList);

        //the computer name to get the processes from
        private readonly string _compName;

        //2D array to hold the processes
        private string[,] _procArray;

        //Reference to the main form
        private readonly Form_MainForm _mainForm;

        /// <summary>
        /// Initialize _mainForm, and _compName
        /// </summary>
        /// <param name="mainForm"> Main Form reference </param>
        /// <param name="compName"> Computer name to get processes from </param>
        public ProcessesForm(Form_MainForm mainForm, string compName)
        {
            InitializeComponent();

            _mainForm = mainForm;

            LView_Processes.FullRowSelect = true;

            _compName = compName;
        }

        /// <summary>
        /// Load in the processes and load in the Listview Control
        /// </summary>
        /// <param name="sender"> ProcessForm </param>
        /// <param name="e"> EventArgs </param>
        private void ProcessesForm_Load(object sender, EventArgs e)
        {
            List<string> procList = GetProcesses(_compName);

            LoadHeaders(procList);

            LoadListView(procList);
        }

        /// <summary>
        /// When button is clicked. End all processes that are selected in the Listview
        /// Or, if "close all with same name" checkbox is checked, closes all with the same name.
        /// </summary>
        /// <param name="sender"> Button </param>
        /// <param name="e"> EventArgs </param>
        private void Btn_EndProc_Click(object sender, EventArgs e)
        {
            List<string> selected = GetSelectedProcesses();

            foreach (string process in selected)
            {
                //do we create a process for each of them?
                Process p = new Process();
                p.StartInfo.FileName = Environment.CurrentDirectory + @"\PSTools\pskill.exe";
                p.StartInfo.Arguments = @"\\" + _compName + " " + process;
                p.StartInfo.RedirectStandardOutput = true;
                p.StartInfo.RedirectStandardError = true;
                p.StartInfo.UseShellExecute = false;
                p.StartInfo.CreateNoWindow = true;
                p.EnableRaisingEvents = true;

                if (process == selected[selected.Count - 1])
                {
                    p.Exited += new EventHandler(KillReturn);
                }

                try
                {
                    p.Start();
                }
                catch (Exception ex)
                {
                    _mainForm.DelPassToOutput.Invoke(ex.Message);
                }
            }

        }

        /// <summary>
        /// Gets and returns a List<string> containing the processes selected in the ListView control </string>
        /// </summary>
        /// <returns> List<string> containing the processes selected in the ListView control </returns>
        private List<string> GetSelectedProcesses()
        {
            List<string> selected = new List<string>();

            foreach (ListViewItem lvi in LView_Processes.SelectedItems)
            {
                if (CkBox_AllName.Checked)
                {
                    //we want to close all with the same name, and may have multiple of the same name selected
                    if (!selected.Contains(lvi.Text))
                    {
                        selected.Add(lvi.Text);
                    }
                }
                else
                {
                    //we want to only close the specific process(es)
                    selected.Add(lvi.SubItems[1].Text);
                }
            }
            return selected;
        }

        /// <summary>
        /// Callback method after all end processes has been sent. Loads ListView with processes that are remaining on computer
        /// </summary>
        /// <param name="sender"> Process </param>
        /// <param name="e"> System.EventArgs </param>
        private void KillReturn(object sender, System.EventArgs e)
        {
            //Process p = (sender as Process);

            LoadListView(GetProcesses(_compName));
        }

        /// <summary>
        /// Gets and returns a list of all the running processes on the target computer name
        /// </summary>
        /// <param name="compName"> Target computer </param>
        /// <returns> List<string> of all the processes running on the target computer </string></returns>
        private static List<string> GetProcesses(string compName)
        {
            Process p = new Process();
            p.StartInfo.FileName = Environment.CurrentDirectory + @"\PSTools\pslist.exe";
            p.StartInfo.Arguments = @"\\" + compName;
            p.StartInfo.RedirectStandardOutput = true;
            p.StartInfo.UseShellExecute = false;
            p.StartInfo.RedirectStandardError = true;
            p.StartInfo.CreateNoWindow = true;
            p.EnableRaisingEvents = true;
            p.Start();

            string output = p.StandardOutput.ReadToEnd();
            //string error = p.StandardError.ReadToEnd();
            p.Dispose();
            return output.Split(new char[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries).ToList();
        }

        /// <summary>
        /// Loads the header information for the processes ListView control
        /// </summary>
        /// <param name="procList"> List of processes retrieved from computer </param>
        private void LoadHeaders(List<string> procList)
        {
            //[1] is header info, parse specially
            List<string> headers = procList[1].Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).ToList();

            headers[6] += " " + headers[7];
            headers[8] += " " + headers[9];
            headers.RemoveAt(7);
            //remove 8 instead of 9 as the list has shrunk in size by 1
            headers.RemoveAt(8);

            LView_Processes.Columns.Add(headers[0], 150);

            for (int i = 1; i < 6; i++)
                LView_Processes.Columns.Add(headers[i], 50);

            for (int i = 6; i < 8; i++)
                LView_Processes.Columns.Add(headers[i], 100);
        }

        /// <summary>
        /// Loads the ListView control with the provided list of processes retrieved from pslist.exe
        /// </summary>
        /// <param name="procList"></param>
        private void LoadListView(List<string> procList)
        {

            if (procList.Count < 0 || procList[0].Contains("Failed to take process snapshot on"))
            {
                return;
            }

            SafeClearListView();

            //first we have to get the processes from the computer again
            _procArray = new string[procList.Count - 2, 8];


            for (int i = 0; i < procList.Count - 2; i++)
            {
                //parse each string into its segments
                //name may contain spaces, but we know it should have 8 entries
                //List<string> tempList = new List<string>();
                //skip [0] and [1]
                List<string> tempList = procList[i + 2].Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).ToList();

                while (tempList.Count > 8)
                {
                    //we split a process name, combine [1] with [0]
                    tempList[0] += " " + tempList[1];
                    tempList.RemoveAt(1);
                }

                //we now have the entire proc info in the tempList, add it to list View
                for (int o = 0; o < 8; o++)
                {
                    if (o == 1)
                        while (tempList[o].Length < 6)
                            tempList[o] = "0" + tempList[o];

                    if (o == 2 || o == 3)
                        while (tempList[o].Length < 3)
                            tempList[o] = "0" + tempList[o];

                    if (o == 4)
                        while (tempList[o].Length < 5)
                            tempList[o] = "0" + tempList[o];

                    if (o == 5)
                        while (tempList[o].Length < 6)
                            tempList[o] = "0" + tempList[o];

                    _procArray[i, o] = tempList[o];
                }

            }

            AddToListView(_procArray);
        }

        /// <summary>
        /// Safely clears the ListView control (Thread safe)
        /// </summary>
        private void SafeClearListView()
        {
            if (LView_Processes.InvokeRequired)
                LView_Processes.Invoke(new delvoidvoid(SafeClearListView));
            else
                LView_Processes.Items.Clear();
        }

        /// <summary>
        /// Adds the provided 2D array to the ListView Control
        /// </summary>
        /// <param name="processArray"></param>
        private void AddToListView(string[,] processArray)
        {
            List<string> tempList = new List<string>();
            List<ListViewItem> lviList = new List<ListViewItem>();
            for (int i = 0; i < processArray.GetUpperBound(0); i++)
            {
                for (int o = 0; o < 8; o++)
                    tempList.Add(processArray[i, o]);

                lviList.Add(new ListViewItem(tempList.ToArray()));
                tempList.Clear();
            }

            SafeAddListView(lviList);
        }

        /// <summary>
        /// Safely adds the provided List<ListViewItem> to the main ListView control
        /// </summary>
        /// <param name="lviList"> List of ListView items to be added to the ListView control </param>
        private void SafeAddListView(List<ListViewItem> lviList)
        {
            if (LView_Processes.InvokeRequired)
                LView_Processes.Invoke(new UpdateListView(SafeAddListView), lviList);
            else
                LView_Processes.Items.AddRange(lviList.ToArray());
        }

        /// <summary>
        /// When a column is clicked, sorts the entire ListView contects by that field
        /// </summary>
        /// <param name="sender"> ListView </param>
        /// <param name="e"></param>
        private void LView_Processes_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            _procArray = _procArray.OrderBy(x => x[e.Column]);

            string[] testArr = new string[8];

            LView_Processes.Items.Clear();

            for (int i = 0; i < _procArray.GetLength(0); i++)
            {
                for (int x = 0; x < 8; x++)
                {
                    testArr[x] = _procArray[i, x];
                }
                ListViewItem lvi = new ListViewItem(testArr);
                LView_Processes.Items.Add(lvi);
            }

        }

        /// <summary>
        /// Refreshes the ListView control with the processes on the target computer
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Btn_Refresh_Click(object sender, EventArgs e)
        {
            LoadListView(GetProcesses(_compName));
        }
    }


    //https://www.codeproject.com/Tips/166236/Sorting-a-Two-Dimensional-Array-in-Csharp
    public static class MultiDimensionalArrayExtensions
    {
        /// <summary>
        ///   Orders the two dimensional array by the provided key in the key selector.
        /// </summary>
        /// <typeparam name="T">The type of the source two-dimensional array.</typeparam>
        /// <param name="source">The source two-dimensional array.</param>
        /// <param name="keySelector">The selector to retrieve the column to sort on.</param>
        /// <returns>A new two dimensional array sorted on the key.</returns>
        public static T[,] OrderBy<T>(this T[,] source, Func<T[], T> keySelector)
        {
            //return source.ConvertToSingleDimension().OrderBy(keySelector).ConvertToMultiDimensional();

            var test = source.ConvertToSingleDimension();
            var test2 = test.OrderBy(keySelector);
            var test3 = test2.ConvertToMultiDimensional();

            return test3;

        }
        /// <summary>
        ///   Orders the two dimensional array by the provided key in the key selector in descending order.
        /// </summary>
        /// <typeparam name="T">The type of the source two-dimensional array.</typeparam>
        /// <param name="source">The source two-dimensional array.</param>
        /// <param name="keySelector">The selector to retrieve the column to sort on.</param>
        /// <returns>A new two dimensional array sorted on the key.</returns>
        public static T[,] OrderByDescending<T>(this T[,] source, Func<T[], T> keySelector)
        {
            return source.ConvertToSingleDimension().
                OrderByDescending(keySelector).ConvertToMultiDimensional();
        }
        /// <summary>
        ///   Converts a two dimensional array to single dimensional array.
        /// </summary>
        /// <typeparam name="T">The type of the two dimensional array.</typeparam>
        /// <param name="source">The source two dimensional array.</param>
        /// <returns>The repackaged two dimensional array as a single dimension based on rows.</returns>
        private static IEnumerable<T[]> ConvertToSingleDimension<T>(this T[,] source)
        {
            T[] arRow;

            for (int row = 0; row < source.GetLength(0); ++row)
            {
                arRow = new T[source.GetLength(1)];

                for (int col = 0; col < source.GetLength(1); ++col)
                    arRow[col] = source[row, col];

                yield return arRow;
            }
        }
        /// <summary>
        ///   Converts a collection of rows from a two dimensional array back into a two dimensional array.
        /// </summary>
        /// <typeparam name="T">The type of the two dimensional array.</typeparam>
        /// <param name="source">The source collection of rows to convert.</param>
        /// <returns>The two dimensional array.</returns>
        private static T[,] ConvertToMultiDimensional<T>(this IEnumerable<T[]> source)
        {
            T[,] twoDimensional;
            T[][] arrayOfArray;
            int numberofColumns;

            arrayOfArray = source.ToArray();
            numberofColumns = (arrayOfArray.Length > 0) ? arrayOfArray[0].Length : 0;
            twoDimensional = new T[arrayOfArray.Length, numberofColumns];

            for (int row = 0; row < arrayOfArray.GetLength(0); ++row)
                for (int col = 0; col < numberofColumns; ++col)
                    twoDimensional[row, col] = arrayOfArray[row][col];

            return twoDimensional;
        }
    }
}
