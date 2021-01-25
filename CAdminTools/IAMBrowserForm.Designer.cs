namespace CAdminTools
{
    partial class IAMBrowserForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.WebBrow_IAM = new System.Windows.Forms.WebBrowser();
            this.Btn_NavBack = new System.Windows.Forms.Button();
            this.Btn_NavForward = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // WebBrow_IAM
            // 
            this.WebBrow_IAM.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.WebBrow_IAM.Location = new System.Drawing.Point(0, 20);
            this.WebBrow_IAM.MinimumSize = new System.Drawing.Size(20, 20);
            this.WebBrow_IAM.Name = "WebBrow_IAM";
            this.WebBrow_IAM.Size = new System.Drawing.Size(1584, 848);
            this.WebBrow_IAM.TabIndex = 0;
            this.WebBrow_IAM.DocumentCompleted += new System.Windows.Forms.WebBrowserDocumentCompletedEventHandler(this.WebBrow_IAM_DocumentCompleted);
            this.WebBrow_IAM.Navigated += new System.Windows.Forms.WebBrowserNavigatedEventHandler(this.WebBrow_IAM_Navigated);
            // 
            // Btn_NavBack
            // 
            this.Btn_NavBack.Location = new System.Drawing.Point(0, 0);
            this.Btn_NavBack.Name = "Btn_NavBack";
            this.Btn_NavBack.Size = new System.Drawing.Size(23, 20);
            this.Btn_NavBack.TabIndex = 1;
            this.Btn_NavBack.Text = "<";
            this.Btn_NavBack.UseVisualStyleBackColor = true;
            this.Btn_NavBack.Click += new System.EventHandler(this.Btn_NavBack_Click);
            // 
            // Btn_NavForward
            // 
            this.Btn_NavForward.Location = new System.Drawing.Point(29, 0);
            this.Btn_NavForward.Name = "Btn_NavForward";
            this.Btn_NavForward.Size = new System.Drawing.Size(23, 20);
            this.Btn_NavForward.TabIndex = 2;
            this.Btn_NavForward.Text = ">";
            this.Btn_NavForward.UseVisualStyleBackColor = true;
            this.Btn_NavForward.Click += new System.EventHandler(this.Btn_NavForward_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(610, 0);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 20);
            this.button1.TabIndex = 3;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Visible = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // IAMBrowserForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1584, 861);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.Btn_NavForward);
            this.Controls.Add(this.Btn_NavBack);
            this.Controls.Add(this.WebBrow_IAM);
            this.Name = "IAMBrowserForm";
            this.Text = "IAMBrowserForm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.IAMBrowserForm_FormClosing);
            this.Load += new System.EventHandler(this.IAMBrowserForm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.WebBrowser WebBrow_IAM;
        private System.Windows.Forms.Button Btn_NavBack;
        private System.Windows.Forms.Button Btn_NavForward;
        private System.Windows.Forms.Button button1;
    }
}