using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace CAdminTools
{
    [ComVisibleAttribute(true)]
    public partial class IAMBrowserForm : Form
    {
        // The IAM password reset user lookup page url
        private readonly string _iamPWordReset = "";
        // The IAM login page url
        private readonly string _iamLoginPage = "";
        // The IAM home page url
        private readonly string _iamHomePage = "";

        // The IAM password reset user lookup page textbox IDs, and search button ID
        private readonly string _iamUserNameID = "";
        private readonly string _iamFirstNameID = "";
        private readonly string _iamLastNameID = "";
        private readonly string _iamEmailID = "";
        private readonly string _iamGoButton = "";

        // Reference to the main form control to be able to retrieve the settings values
        private readonly Form_MainForm _mainForm = null;

        // Used to determine if the user is trying to search IAM
        private bool _isUserSearch = false;

        /// <summary>
        /// Loads the settings needed for the IAM Browser form from the main form
        /// </summary>
        /// <param name="mainForm"> The main form containing the settings </param>
        public IAMBrowserForm(Form_MainForm mainForm)
        {
            InitializeComponent();
            _mainForm = mainForm;

            //load browser form settings
            _iamUserNameID = _mainForm.IAMUserNameID;
            _iamFirstNameID = _mainForm.IAMFirstNameID;
            _iamLastNameID = _mainForm.IAMLastNameID;
            _iamEmailID = _mainForm.IAMEmailID;
            _iamGoButton = _mainForm.IAMGoButtonID;

            _iamPWordReset = _mainForm.IAMPasswordSite;
            _iamHomePage = _mainForm.IAMHomeSite;
            _iamLoginPage = _mainForm.IAMLoginSite;

            Btn_NavForward.Enabled = false;
            Btn_NavBack.Enabled = false;
        }

        /// <summary>
        /// Navigate the WebBrowser to the IAM Password reset user lookup page
        /// </summary>
        public void LoadIAM()
        {
            WebBrow_IAM.Navigate(_iamPWordReset);
            _isUserSearch = true;
        }

        /// <summary>
        /// When the document loads, Checks to see if browser can navigate and sets buttons accordingly.
        /// If we are on the login page and it is a user search, enter in the values into the appropriate textbox and search
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void WebBrow_IAM_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            if (WebBrow_IAM.CanGoForward)
            {
                Btn_NavForward.Enabled = true;
            }
            if (WebBrow_IAM.CanGoBack)
            {
                Btn_NavBack.Enabled = true;
            }


            if (WebBrow_IAM.Url.ToString() != _iamPWordReset || !_isUserSearch)
            {
                return;
            }

            _isUserSearch = false;

            List<ClearTextBox> CTBoxList = _mainForm.PassActiveClearBoxes();

            if (CTBoxList == null)
            {
                return;
            }

            if (CTBoxList.Count > 1)
            {
                //we know we are searching by first last

                //cannot guarantee the order of the list.
                List<ClearTextBox> tempBoxList = CTBoxList.Where(o => o.Name == "CTxtBox_FName").ToList();
                if (tempBoxList.Count < 1)
                {
                    return;
                }

                WebBrow_IAM.Document.GetElementById(_iamFirstNameID).SetAttribute("value", tempBoxList[0].Text);

                tempBoxList = CTBoxList.Where(o => o.Name == "CTxtBox_LName").ToList();
                if (tempBoxList.Count < 1)
                {
                    return;
                }

                WebBrow_IAM.Document.GetElementById(_iamLastNameID).SetAttribute("value", tempBoxList[0].Text);
            }
            //either email or username
            else if (CTBoxList[0].Name == "CTxtBox_UserName")
            {
                //search by username
                WebBrow_IAM.Document.GetElementById(_iamUserNameID).SetAttribute("value", CTBoxList[0].Text);
            }
            else
            {
                //email
                WebBrow_IAM.Document.GetElementById(_iamEmailID).SetAttribute("value", CTBoxList[0].Text);
            }
            
             System.Threading.ThreadPool.QueueUserWorkItem(TClickForm, CTBoxList[0].Text);
        }

        /// <summary>
        /// Threaded method to send a click the the browser form
        /// </summary>
        /// <param name="args"></param>
        private void TClickForm(object args)
        {
            if (!(args is string))
                return;
            // Delayed for 200 miliseconds to ensure the button loaded
            System.Threading.Thread.Sleep(200);
            Invoke((Action)(() => {
                WebBrow_IAM.Document.GetElementById(_iamGoButton).InvokeMember("Click");
            }));
        }

        /// <summary>
        /// If the user is trying to close the form, hide it instead.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void IAMBrowserForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            
            if (e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true;
                this.Hide();
            }
        }

        /// <summary>
        /// When the form is loaded attach the form the WebBrowser.ObjectForScripting and navigate to the IAM password reset page
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void IAMBrowserForm_Load(object sender, EventArgs e)
        {
            WebBrow_IAM.ObjectForScripting = this;
            WebBrow_IAM.Navigate(_iamPWordReset);

        }

        /// <summary>
        /// Navigate back the browser back
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Btn_NavBack_Click(object sender, EventArgs e)
        {
            WebBrow_IAM.GoBack();
        }

        /// <summary>
        /// Navigate the browser forward
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Btn_NavForward_Click(object sender, EventArgs e)
        {
            WebBrow_IAM.GoForward();
        }

        /// <summary>
        /// Test button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            WebBrow_IAM.Document.GetElementById(_iamGoButton).InvokeMember("Click");
        }

        private void WebBrow_IAM_Navigated(object sender, WebBrowserNavigatedEventArgs e)
        {
            /*
            if (WebBrow_IAM.Url.ToString() != _iamPWordReset || !_isUserSearch)
                return;

            // System.Threading.Thread.Sleep(1000);
            List<ClearTextBox> CTBoxList = _mainForm.PassActiveClearBoxes();

            WebBrow_IAM.Document.GetElementById(_iamUserNameID).SetAttribute("value", CTBoxList[0].Text);
            WebBrow_IAM.Document.GetElementById(_iamGoButton).InvokeMember("Click");
            */
        }
    }
}
