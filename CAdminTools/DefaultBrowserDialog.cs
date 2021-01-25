using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CAdminTools
{
    public partial class DefaultBrowserDialog : Form
    {
        //holds the paths of installed browsers
        Dictionary<string, string> _browserPaths;

        //Provides access to the browser that was selected by users
        public string SelectedBrowser
        {
            get => _browserPaths[ComBox_Browsers.SelectedItem.ToString()];
        }

        /// <summary>
        /// Runs Init method
        /// </summary>
        /// <param name="availableBrowsers"> list of installed browsers file paths to .exe </param>
        public DefaultBrowserDialog(List<string> availableBrowsers)
        {
            InitializeComponent();
            _browserPaths = new Dictionary<string, string>();
            Init(availableBrowsers);
        }

        /// <summary>
        /// When the OK button is clicked, set the Dialog result to OK and close this form
        /// </summary>
        /// <param name="sender"> The sending control </param>
        /// <param name="e"> EventArgs </param>
        private void Btn_OK_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            Close();
        }

        /// <summary>
        /// When the Cancel button is clicked, set the Dialog result to Cancel and close this form
        /// </summary>
        /// <param name="sender"> The sending control </param>
        /// <param name="e"> EventArgs </param>
        private void Btn_Cancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        /// <summary>
        /// When Open button clicked, open an OpenFileDialog to prompt the user to select an appropriate browser .exe
        /// </summary>
        /// <param name="sender"> The sending control </param>
        /// <param name="e"> EventArgs </param>
        private void Btn_Open_Click(object sender, EventArgs e)
        {
            OpenFileDialog OFD = new OpenFileDialog();
            OFD.InitialDirectory = @"c:\";
            OFD.Filter = "exe files (*.exe)|*.exe|All Files (*.*)|*.*";
            if (OFD.ShowDialog() == DialogResult.OK)
            {
                //if the path contains (x86), add that to the display exe name
                List<string> fileSplit = new List<string>();
                fileSplit = OFD.FileName.Split(new char[] { '\\' }, StringSplitOptions.RemoveEmptyEntries).ToList();
                fileSplit[fileSplit.Count - 1] += fileSplit.Contains("(x86)") ? " x86" : string.Empty;
                ComBox_Browsers.Items.Add(fileSplit[fileSplit.Count - 1]);
                ComBox_Browsers.SelectedItem = fileSplit[fileSplit.Count - 1];

                _browserPaths.Add(fileSplit[fileSplit.Count - 1], OFD.FileName);
            }
        }

        static private string GiveExeFromFilePath(string path, string searchPathFor = "")
        {
            List<string> fileSplit = new List<string>();
            fileSplit = path.Split(new char[] { '\\' }, StringSplitOptions.RemoveEmptyEntries).ToList();
            return fileSplit[fileSplit.Count - 1] += fileSplit.Contains(searchPathFor) ? " " + searchPathFor : string.Empty;
        }

        /// <summary>
        /// Takes a list of installed browser paths and adds the file name to the combo box to display
        /// </summary>
        /// <param name="browserPaths"> List of installed browsers </param>
        private void Init(List<string> browserPaths)
        {
            

            foreach (string path in browserPaths)
            {
                if (path == null)
                    continue;

                List<string> splitPath = new List<string>();

                //if the path contains (x86), add that to the display exe name
                splitPath = path.Split(new char[] { '\\' }, StringSplitOptions.RemoveEmptyEntries).ToList();
                splitPath[splitPath.Count - 1] += path.Contains("(x86)") ? " x86" : string.Empty;

                ComBox_Browsers.Items.Add(splitPath[splitPath.Count - 1]);

                _browserPaths.Add(splitPath[splitPath.Count - 1], path);

            }

            if (ComBox_Browsers.Items.Contains(@"iexplore.exe"))
                ComBox_Browsers.SelectedItem = @"iexplore.exe";
        }





    }
}
