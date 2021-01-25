namespace CAdminTools
{
    partial class PrinterManageForm
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
            this.LBox_Printers = new System.Windows.Forms.ListBox();
            this.Btn_RemovePrinter = new System.Windows.Forms.Button();
            this.Btn_AddPrinter = new System.Windows.Forms.Button();
            this.Btn_Refresh = new System.Windows.Forms.Button();
            this.CkBox_Driver = new System.Windows.Forms.CheckBox();
            this.TxtBox_PrinterName = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // LBox_Printers
            // 
            this.LBox_Printers.FormattingEnabled = true;
            this.LBox_Printers.Location = new System.Drawing.Point(13, 13);
            this.LBox_Printers.Name = "LBox_Printers";
            this.LBox_Printers.Size = new System.Drawing.Size(300, 420);
            this.LBox_Printers.TabIndex = 0;
            // 
            // Btn_RemovePrinter
            // 
            this.Btn_RemovePrinter.Location = new System.Drawing.Point(319, 23);
            this.Btn_RemovePrinter.Name = "Btn_RemovePrinter";
            this.Btn_RemovePrinter.Size = new System.Drawing.Size(75, 23);
            this.Btn_RemovePrinter.TabIndex = 1;
            this.Btn_RemovePrinter.Text = "Remove Printer";
            this.Btn_RemovePrinter.UseVisualStyleBackColor = true;
            // 
            // Btn_AddPrinter
            // 
            this.Btn_AddPrinter.Location = new System.Drawing.Point(319, 67);
            this.Btn_AddPrinter.Name = "Btn_AddPrinter";
            this.Btn_AddPrinter.Size = new System.Drawing.Size(75, 23);
            this.Btn_AddPrinter.TabIndex = 2;
            this.Btn_AddPrinter.Text = "Add Printer";
            this.Btn_AddPrinter.UseVisualStyleBackColor = true;
            // 
            // Btn_Refresh
            // 
            this.Btn_Refresh.Location = new System.Drawing.Point(319, 115);
            this.Btn_Refresh.Name = "Btn_Refresh";
            this.Btn_Refresh.Size = new System.Drawing.Size(75, 23);
            this.Btn_Refresh.TabIndex = 3;
            this.Btn_Refresh.Text = "Refresh";
            this.Btn_Refresh.UseVisualStyleBackColor = true;
            // 
            // CkBox_Driver
            // 
            this.CkBox_Driver.AutoSize = true;
            this.CkBox_Driver.Location = new System.Drawing.Point(419, 28);
            this.CkBox_Driver.Name = "CkBox_Driver";
            this.CkBox_Driver.Size = new System.Drawing.Size(97, 17);
            this.CkBox_Driver.TabIndex = 4;
            this.CkBox_Driver.Text = "Remove Driver";
            this.CkBox_Driver.UseVisualStyleBackColor = true;
            // 
            // TxtBox_PrinterName
            // 
            this.TxtBox_PrinterName.Location = new System.Drawing.Point(400, 69);
            this.TxtBox_PrinterName.Name = "TxtBox_PrinterName";
            this.TxtBox_PrinterName.Size = new System.Drawing.Size(198, 20);
            this.TxtBox_PrinterName.TabIndex = 5;
            // 
            // PrinterManageForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(612, 450);
            this.Controls.Add(this.TxtBox_PrinterName);
            this.Controls.Add(this.CkBox_Driver);
            this.Controls.Add(this.Btn_Refresh);
            this.Controls.Add(this.Btn_AddPrinter);
            this.Controls.Add(this.Btn_RemovePrinter);
            this.Controls.Add(this.LBox_Printers);
            this.Name = "PrinterManageForm";
            this.Text = "PrinterManageForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox LBox_Printers;
        private System.Windows.Forms.Button Btn_RemovePrinter;
        private System.Windows.Forms.Button Btn_AddPrinter;
        private System.Windows.Forms.Button Btn_Refresh;
        private System.Windows.Forms.CheckBox CkBox_Driver;
        private System.Windows.Forms.TextBox TxtBox_PrinterName;
    }
}