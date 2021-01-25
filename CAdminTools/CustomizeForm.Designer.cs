namespace CAdminTools
{
    partial class CustomizeForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CustomizeForm));
            this.Btn_Font = new System.Windows.Forms.Button();
            this.Btn_BackgroundColour = new System.Windows.Forms.Button();
            this.Lbl_BackgroundOpacity = new System.Windows.Forms.Label();
            this.Btn_Picture = new System.Windows.Forms.Button();
            this.Btn_FontColour = new System.Windows.Forms.Button();
            this.Btn_BtnAndLblColour = new System.Windows.Forms.Button();
            this.TBar_BackgroundOpacity = new System.Windows.Forms.TrackBar();
            this.Num_BackgroundOpacity = new System.Windows.Forms.NumericUpDown();
            this.Num_BtnOpacity = new System.Windows.Forms.NumericUpDown();
            this.TBar_BtnOpacity = new System.Windows.Forms.TrackBar();
            this.GBox_Font = new System.Windows.Forms.GroupBox();
            this.GBox_BtnAndLbl = new System.Windows.Forms.GroupBox();
            this.Lbl_BtnOpacity = new System.Windows.Forms.Label();
            this.GBox_Background = new System.Windows.Forms.GroupBox();
            this.GBox_Panel = new System.Windows.Forms.GroupBox();
            this.Btn_PanelColour = new System.Windows.Forms.Button();
            this.TBar_PanelOpacity = new System.Windows.Forms.TrackBar();
            this.label1 = new System.Windows.Forms.Label();
            this.Num_PanelOpacity = new System.Windows.Forms.NumericUpDown();
            this.button1 = new System.Windows.Forms.Button();
            this.Btn_Save = new System.Windows.Forms.Button();
            this.Btn_Default = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.TBar_BackgroundOpacity)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Num_BackgroundOpacity)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Num_BtnOpacity)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TBar_BtnOpacity)).BeginInit();
            this.GBox_Font.SuspendLayout();
            this.GBox_BtnAndLbl.SuspendLayout();
            this.GBox_Background.SuspendLayout();
            this.GBox_Panel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TBar_PanelOpacity)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Num_PanelOpacity)).BeginInit();
            this.SuspendLayout();
            // 
            // Btn_Font
            // 
            this.Btn_Font.Location = new System.Drawing.Point(6, 19);
            this.Btn_Font.Name = "Btn_Font";
            this.Btn_Font.Size = new System.Drawing.Size(76, 23);
            this.Btn_Font.TabIndex = 0;
            this.Btn_Font.Text = "Change Font";
            this.Btn_Font.UseVisualStyleBackColor = true;
            this.Btn_Font.Click += new System.EventHandler(this.Btn_ChangeFont_Click);
            // 
            // Btn_BackgroundColour
            // 
            this.Btn_BackgroundColour.Location = new System.Drawing.Point(123, 19);
            this.Btn_BackgroundColour.Name = "Btn_BackgroundColour";
            this.Btn_BackgroundColour.Size = new System.Drawing.Size(100, 23);
            this.Btn_BackgroundColour.TabIndex = 1;
            this.Btn_BackgroundColour.Text = "Background Color";
            this.Btn_BackgroundColour.UseVisualStyleBackColor = true;
            this.Btn_BackgroundColour.Click += new System.EventHandler(this.Btn_BackgroundColour_Click);
            // 
            // Lbl_BackgroundOpacity
            // 
            this.Lbl_BackgroundOpacity.AutoSize = true;
            this.Lbl_BackgroundOpacity.Location = new System.Drawing.Point(628, 91);
            this.Lbl_BackgroundOpacity.Name = "Lbl_BackgroundOpacity";
            this.Lbl_BackgroundOpacity.Size = new System.Drawing.Size(43, 13);
            this.Lbl_BackgroundOpacity.TabIndex = 2;
            this.Lbl_BackgroundOpacity.Text = "Opacity";
            // 
            // Btn_Picture
            // 
            this.Btn_Picture.Location = new System.Drawing.Point(6, 19);
            this.Btn_Picture.Name = "Btn_Picture";
            this.Btn_Picture.Size = new System.Drawing.Size(111, 23);
            this.Btn_Picture.TabIndex = 3;
            this.Btn_Picture.Text = "Background Picture";
            this.Btn_Picture.UseVisualStyleBackColor = true;
            this.Btn_Picture.Click += new System.EventHandler(this.Btn_Picture_Click);
            // 
            // Btn_FontColour
            // 
            this.Btn_FontColour.Location = new System.Drawing.Point(6, 48);
            this.Btn_FontColour.Name = "Btn_FontColour";
            this.Btn_FontColour.Size = new System.Drawing.Size(111, 23);
            this.Btn_FontColour.TabIndex = 4;
            this.Btn_FontColour.Text = "Change Font Colour";
            this.Btn_FontColour.UseVisualStyleBackColor = true;
            this.Btn_FontColour.Click += new System.EventHandler(this.Btn_FontColour_Click);
            // 
            // Btn_BtnAndLblColour
            // 
            this.Btn_BtnAndLblColour.Location = new System.Drawing.Point(6, 19);
            this.Btn_BtnAndLblColour.Name = "Btn_BtnAndLblColour";
            this.Btn_BtnAndLblColour.Size = new System.Drawing.Size(129, 23);
            this.Btn_BtnAndLblColour.TabIndex = 5;
            this.Btn_BtnAndLblColour.Text = "Button and Label Colour";
            this.Btn_BtnAndLblColour.UseVisualStyleBackColor = true;
            this.Btn_BtnAndLblColour.Click += new System.EventHandler(this.Btn_BtnAndLblColour_Click);
            // 
            // TBar_BackgroundOpacity
            // 
            this.TBar_BackgroundOpacity.Location = new System.Drawing.Point(496, 107);
            this.TBar_BackgroundOpacity.Maximum = 255;
            this.TBar_BackgroundOpacity.Name = "TBar_BackgroundOpacity";
            this.TBar_BackgroundOpacity.Size = new System.Drawing.Size(161, 45);
            this.TBar_BackgroundOpacity.TabIndex = 6;
            this.TBar_BackgroundOpacity.Scroll += new System.EventHandler(this.TBar_BackgroundOpacity_Scroll);
            // 
            // Num_BackgroundOpacity
            // 
            this.Num_BackgroundOpacity.Location = new System.Drawing.Point(663, 107);
            this.Num_BackgroundOpacity.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.Num_BackgroundOpacity.Name = "Num_BackgroundOpacity";
            this.Num_BackgroundOpacity.Size = new System.Drawing.Size(46, 20);
            this.Num_BackgroundOpacity.TabIndex = 8;
            this.Num_BackgroundOpacity.Value = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.Num_BackgroundOpacity.ValueChanged += new System.EventHandler(this.Num_BackgroundOpacity_ValueChanged);
            // 
            // Num_BtnOpacity
            // 
            this.Num_BtnOpacity.Location = new System.Drawing.Point(173, 48);
            this.Num_BtnOpacity.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.Num_BtnOpacity.Name = "Num_BtnOpacity";
            this.Num_BtnOpacity.Size = new System.Drawing.Size(46, 20);
            this.Num_BtnOpacity.TabIndex = 10;
            this.Num_BtnOpacity.Value = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.Num_BtnOpacity.ValueChanged += new System.EventHandler(this.Num_BtnOpacity_ValueChanged);
            // 
            // TBar_BtnOpacity
            // 
            this.TBar_BtnOpacity.Location = new System.Drawing.Point(6, 48);
            this.TBar_BtnOpacity.Maximum = 255;
            this.TBar_BtnOpacity.Name = "TBar_BtnOpacity";
            this.TBar_BtnOpacity.Size = new System.Drawing.Size(161, 45);
            this.TBar_BtnOpacity.TabIndex = 9;
            this.TBar_BtnOpacity.Value = 255;
            this.TBar_BtnOpacity.Scroll += new System.EventHandler(this.TBar_BtnOpacity_Scroll);
            // 
            // GBox_Font
            // 
            this.GBox_Font.Controls.Add(this.Btn_Font);
            this.GBox_Font.Controls.Add(this.Btn_FontColour);
            this.GBox_Font.Location = new System.Drawing.Point(11, 308);
            this.GBox_Font.Name = "GBox_Font";
            this.GBox_Font.Size = new System.Drawing.Size(331, 79);
            this.GBox_Font.TabIndex = 12;
            this.GBox_Font.TabStop = false;
            this.GBox_Font.Text = "Font";
            // 
            // GBox_BtnAndLbl
            // 
            this.GBox_BtnAndLbl.Controls.Add(this.Lbl_BtnOpacity);
            this.GBox_BtnAndLbl.Controls.Add(this.Btn_BtnAndLblColour);
            this.GBox_BtnAndLbl.Controls.Add(this.TBar_BtnOpacity);
            this.GBox_BtnAndLbl.Controls.Add(this.Num_BtnOpacity);
            this.GBox_BtnAndLbl.Location = new System.Drawing.Point(12, 196);
            this.GBox_BtnAndLbl.Name = "GBox_BtnAndLbl";
            this.GBox_BtnAndLbl.Size = new System.Drawing.Size(331, 97);
            this.GBox_BtnAndLbl.TabIndex = 13;
            this.GBox_BtnAndLbl.TabStop = false;
            this.GBox_BtnAndLbl.Text = "Button and Label Colour";
            // 
            // Lbl_BtnOpacity
            // 
            this.Lbl_BtnOpacity.AutoSize = true;
            this.Lbl_BtnOpacity.Location = new System.Drawing.Point(141, 32);
            this.Lbl_BtnOpacity.Name = "Lbl_BtnOpacity";
            this.Lbl_BtnOpacity.Size = new System.Drawing.Size(43, 13);
            this.Lbl_BtnOpacity.TabIndex = 7;
            this.Lbl_BtnOpacity.Text = "Opacity";
            // 
            // GBox_Background
            // 
            this.GBox_Background.Controls.Add(this.Btn_BackgroundColour);
            this.GBox_Background.Controls.Add(this.Btn_Picture);
            this.GBox_Background.Location = new System.Drawing.Point(12, 12);
            this.GBox_Background.Name = "GBox_Background";
            this.GBox_Background.Size = new System.Drawing.Size(331, 58);
            this.GBox_Background.TabIndex = 14;
            this.GBox_Background.TabStop = false;
            this.GBox_Background.Text = "Form Background";
            // 
            // GBox_Panel
            // 
            this.GBox_Panel.Controls.Add(this.Btn_PanelColour);
            this.GBox_Panel.Controls.Add(this.TBar_PanelOpacity);
            this.GBox_Panel.Controls.Add(this.label1);
            this.GBox_Panel.Controls.Add(this.Num_PanelOpacity);
            this.GBox_Panel.Location = new System.Drawing.Point(12, 85);
            this.GBox_Panel.Name = "GBox_Panel";
            this.GBox_Panel.Size = new System.Drawing.Size(331, 95);
            this.GBox_Panel.TabIndex = 15;
            this.GBox_Panel.TabStop = false;
            this.GBox_Panel.Text = "Panel Colour";
            // 
            // Btn_PanelColour
            // 
            this.Btn_PanelColour.Location = new System.Drawing.Point(6, 19);
            this.Btn_PanelColour.Name = "Btn_PanelColour";
            this.Btn_PanelColour.Size = new System.Drawing.Size(100, 23);
            this.Btn_PanelColour.TabIndex = 1;
            this.Btn_PanelColour.Text = "Choose Colour";
            this.Btn_PanelColour.UseVisualStyleBackColor = true;
            this.Btn_PanelColour.Click += new System.EventHandler(this.Btn_PanelColour_Click);
            // 
            // TBar_PanelOpacity
            // 
            this.TBar_PanelOpacity.Location = new System.Drawing.Point(6, 48);
            this.TBar_PanelOpacity.Maximum = 255;
            this.TBar_PanelOpacity.Name = "TBar_PanelOpacity";
            this.TBar_PanelOpacity.Size = new System.Drawing.Size(161, 45);
            this.TBar_PanelOpacity.TabIndex = 6;
            this.TBar_PanelOpacity.Value = 255;
            this.TBar_PanelOpacity.Scroll += new System.EventHandler(this.TBar_PanelOpacity_Scroll);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(141, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Opacity";
            // 
            // Num_PanelOpacity
            // 
            this.Num_PanelOpacity.Location = new System.Drawing.Point(173, 48);
            this.Num_PanelOpacity.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.Num_PanelOpacity.Name = "Num_PanelOpacity";
            this.Num_PanelOpacity.Size = new System.Drawing.Size(46, 20);
            this.Num_PanelOpacity.TabIndex = 8;
            this.Num_PanelOpacity.Value = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.Num_PanelOpacity.ValueChanged += new System.EventHandler(this.Num_PanelOpacity_ValueChanged);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(631, 244);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 16;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Btn_Save
            // 
            this.Btn_Save.Location = new System.Drawing.Point(11, 416);
            this.Btn_Save.Name = "Btn_Save";
            this.Btn_Save.Size = new System.Drawing.Size(75, 23);
            this.Btn_Save.TabIndex = 17;
            this.Btn_Save.Text = "Save";
            this.Btn_Save.UseVisualStyleBackColor = true;
            this.Btn_Save.Click += new System.EventHandler(this.Btn_Save_Click);
            // 
            // Btn_Default
            // 
            this.Btn_Default.Location = new System.Drawing.Point(253, 416);
            this.Btn_Default.Name = "Btn_Default";
            this.Btn_Default.Size = new System.Drawing.Size(89, 23);
            this.Btn_Default.TabIndex = 18;
            this.Btn_Default.Text = "Restore Default";
            this.Btn_Default.UseVisualStyleBackColor = true;
            this.Btn_Default.Click += new System.EventHandler(this.Btn_Default_Click);
            // 
            // CustomizeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(359, 607);
            this.Controls.Add(this.Btn_Default);
            this.Controls.Add(this.Btn_Save);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.GBox_Panel);
            this.Controls.Add(this.TBar_BackgroundOpacity);
            this.Controls.Add(this.Lbl_BackgroundOpacity);
            this.Controls.Add(this.GBox_Background);
            this.Controls.Add(this.Num_BackgroundOpacity);
            this.Controls.Add(this.GBox_BtnAndLbl);
            this.Controls.Add(this.GBox_Font);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CustomizeForm";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "CustomizeForm";
            ((System.ComponentModel.ISupportInitialize)(this.TBar_BackgroundOpacity)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Num_BackgroundOpacity)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Num_BtnOpacity)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TBar_BtnOpacity)).EndInit();
            this.GBox_Font.ResumeLayout(false);
            this.GBox_BtnAndLbl.ResumeLayout(false);
            this.GBox_BtnAndLbl.PerformLayout();
            this.GBox_Background.ResumeLayout(false);
            this.GBox_Panel.ResumeLayout(false);
            this.GBox_Panel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TBar_PanelOpacity)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Num_PanelOpacity)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button Btn_Font;
        private System.Windows.Forms.Button Btn_BackgroundColour;
        private System.Windows.Forms.Label Lbl_BackgroundOpacity;
        private System.Windows.Forms.Button Btn_Picture;
        private System.Windows.Forms.Button Btn_FontColour;
        private System.Windows.Forms.Button Btn_BtnAndLblColour;
        private System.Windows.Forms.TrackBar TBar_BackgroundOpacity;
        private System.Windows.Forms.NumericUpDown Num_BackgroundOpacity;
        private System.Windows.Forms.NumericUpDown Num_BtnOpacity;
        private System.Windows.Forms.TrackBar TBar_BtnOpacity;
        private System.Windows.Forms.GroupBox GBox_Font;
        private System.Windows.Forms.GroupBox GBox_BtnAndLbl;
        private System.Windows.Forms.Label Lbl_BtnOpacity;
        private System.Windows.Forms.GroupBox GBox_Background;
        private System.Windows.Forms.GroupBox GBox_Panel;
        private System.Windows.Forms.Button Btn_PanelColour;
        private System.Windows.Forms.TrackBar TBar_PanelOpacity;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown Num_PanelOpacity;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button Btn_Save;
        private System.Windows.Forms.Button Btn_Default;
    }
}