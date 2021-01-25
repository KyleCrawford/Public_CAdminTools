namespace CAdminTools
{
    partial class ProcessesForm
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
            this.LBox_Processes = new System.Windows.Forms.ListBox();
            this.LView_Processes = new System.Windows.Forms.ListView();
            this.Btn_EndProc = new System.Windows.Forms.Button();
            this.CkBox_AllName = new System.Windows.Forms.CheckBox();
            this.Btn_Refresh = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // LBox_Processes
            // 
            this.LBox_Processes.FormattingEnabled = true;
            this.LBox_Processes.Location = new System.Drawing.Point(866, 33);
            this.LBox_Processes.Name = "LBox_Processes";
            this.LBox_Processes.Size = new System.Drawing.Size(331, 420);
            this.LBox_Processes.TabIndex = 0;
            // 
            // LView_Processes
            // 
            this.LView_Processes.HideSelection = false;
            this.LView_Processes.Location = new System.Drawing.Point(12, 12);
            this.LView_Processes.Name = "LView_Processes";
            this.LView_Processes.Size = new System.Drawing.Size(412, 469);
            this.LView_Processes.TabIndex = 0;
            this.LView_Processes.UseCompatibleStateImageBehavior = false;
            this.LView_Processes.View = System.Windows.Forms.View.Details;
            this.LView_Processes.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.LView_Processes_ColumnClick);
            // 
            // Btn_EndProc
            // 
            this.Btn_EndProc.Location = new System.Drawing.Point(431, 13);
            this.Btn_EndProc.Name = "Btn_EndProc";
            this.Btn_EndProc.Size = new System.Drawing.Size(75, 23);
            this.Btn_EndProc.TabIndex = 2;
            this.Btn_EndProc.Text = "End Process";
            this.Btn_EndProc.UseVisualStyleBackColor = true;
            this.Btn_EndProc.Click += new System.EventHandler(this.Btn_EndProc_Click);
            // 
            // CkBox_AllName
            // 
            this.CkBox_AllName.AutoSize = true;
            this.CkBox_AllName.Location = new System.Drawing.Point(431, 42);
            this.CkBox_AllName.Name = "CkBox_AllName";
            this.CkBox_AllName.Size = new System.Drawing.Size(137, 17);
            this.CkBox_AllName.TabIndex = 1;
            this.CkBox_AllName.Text = "End all with same name";
            this.CkBox_AllName.UseVisualStyleBackColor = true;
            // 
            // Btn_Refresh
            // 
            this.Btn_Refresh.Location = new System.Drawing.Point(431, 123);
            this.Btn_Refresh.Name = "Btn_Refresh";
            this.Btn_Refresh.Size = new System.Drawing.Size(75, 23);
            this.Btn_Refresh.TabIndex = 4;
            this.Btn_Refresh.Text = "Refresh";
            this.Btn_Refresh.UseVisualStyleBackColor = true;
            this.Btn_Refresh.Click += new System.EventHandler(this.Btn_Refresh_Click);
            // 
            // ProcessesForm
            // 
            this.AcceptButton = this.Btn_EndProc;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(587, 494);
            this.Controls.Add(this.Btn_Refresh);
            this.Controls.Add(this.CkBox_AllName);
            this.Controls.Add(this.Btn_EndProc);
            this.Controls.Add(this.LView_Processes);
            this.Controls.Add(this.LBox_Processes);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "ProcessesForm";
            this.Text = "View Processes";
            this.Load += new System.EventHandler(this.ProcessesForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox LBox_Processes;
        private System.Windows.Forms.ListView LView_Processes;
        private System.Windows.Forms.Button Btn_EndProc;
        private System.Windows.Forms.CheckBox CkBox_AllName;
        private System.Windows.Forms.Button Btn_Refresh;
    }
}