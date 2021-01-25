using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CAdminTools
{
    /// <summary>
    /// Modified TextBox that has default text that clears when the TextBox gets focus, 
    /// and reappears if the TextBox is empty and loses focus
    /// </summary>
    public class ClearTextBox : System.Windows.Forms.TextBox
    {
        //The default text of the ClearTextBox
        public string DefaultText { get; set; }

        public bool AutoClear { get; set; }

        /// <summary>
        /// When the TextBox gets focus, if it contains the default text, clear it.
        /// </summary>
        /// <param name="e"></param>
        protected override void OnEnter(EventArgs e)
        {
            base.OnEnter(e);
            if (this.Text == DefaultText)
            {
                Text = string.Empty;
            }
        }

        /// <summary>
        /// When the TextBox loses focus, if it contains no text, return the default text
        /// </summary>
        /// <param name="e"></param>
        protected override void OnLeave(EventArgs e)
        {
            base.OnLeave(e);
            if (!AutoClear)
            {
                return;
            }
            if (this.Text.Trim() == string.Empty)
            {
                Text = DefaultText;
            }
        }

        /// <summary>
        /// Set the TextBox back to default text
        /// </summary>
        public void SetDefaultText()
        {
            Text = DefaultText;
        }

    }
}
