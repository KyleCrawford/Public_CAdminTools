using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Imaging;

namespace CAdminTools
{
    public partial class CustomizeForm : Form
    {
        CustomiseVisuals visuals;
        public CustomizeForm()
        {
            InitializeComponent();
            
        }

        public void Setup()
        {
            visuals = new CustomiseVisuals((Form_MainForm)this.Owner);
        }

        private void Btn_ChangeFont_Click(object sender, EventArgs e)
        {
            FontDialog fontPicker = new FontDialog();
            if (fontPicker.ShowDialog() == DialogResult.OK)
            {
                //(Owner as Form_MainForm).UpdateFont(fontPicker.Font);
                visuals.UpdateFont(fontPicker.Font);
            }
        }

        private void ImageImdumb()
        {
            foreach (Control c in this.Controls)
            {
                if (c is Panel)
                {
                    foreach (Control co in c.Controls)
                    {
                        if (co is Button)
                        {
                            (co as Button).FlatStyle = FlatStyle.Flat;
                            co.BackColor = Color.FromArgb(150, co.BackColor);
                        }
                        else if (co is Panel)
                        {
                            co.BackColor = Color.FromArgb(100, co.BackColor);
                            foreach (RadioButton rBtn in co.Controls)
                            {
                                rBtn.BackColor = Color.FromArgb(0, rBtn.BackColor);
                            }
                        }
                        else if (co is CheckBox)
                        {
                            co.BackColor = Color.FromArgb(150, co.BackColor);
                        }
                        else if (co is Label)
                        {
                            co.BackColor = Color.FromArgb(150, co.BackColor);
                        }
                    }
                    c.BackColor = Color.FromArgb(0, c.BackColor);
                }

                else if (c is Label)
                {
                    c.BackColor = Color.FromArgb(150, c.BackColor);
                }
                else if (c is Button)
                {
                    (c as Button).FlatStyle = FlatStyle.Flat;
                    c.BackColor = Color.FromArgb(150, c.BackColor);
                }
                else if (c is ComboBox)
                {
                    //c.BackColor = Color.FromArgb(0, c.BackColor);
                }

            }

            OpenFileDialog ofd = new OpenFileDialog();
            ofd.InitialDirectory = Environment.CurrentDirectory + @"\Admintools Backgrounds";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                this.BackgroundImage = Image.FromFile(ofd.FileName);

            }
        }

        private void Btn_FontColour_Click(object sender, EventArgs e)
        {
            ColorDialog colorPicker = new ColorDialog();
            if (colorPicker.ShowDialog() == DialogResult.OK)
            {
                //(Owner as Form_MainForm).UpdateFontColour(colorPicker.Color);
                visuals.UpdateFontColour(colorPicker.Color);
            }
        }

        private void CaptureMainForm()
        {
            if (Bounds.IntersectsWith(Owner.Bounds))
            {
                //move this form out of the way
                Location = new Point(Owner.Location.X + Owner.Width, Location.Y);
            }

            Rectangle bounds = Owner.Bounds;
            using (Bitmap bitmap = new Bitmap(bounds.Width, bounds.Height))
            {
                using (Graphics g = Graphics.FromImage(bitmap))
                {
                    g.CopyFromScreen(new Point(bounds.Left, bounds.Top), Point.Empty, bounds.Size);
                }
                bitmap.Save(@"C:\users\kylecrawford\desktop\test.jpg", ImageFormat.Jpeg);
            }
        }

        private void TBar_BtnOpacity_Scroll(object sender, EventArgs e)
        {
            Num_BtnOpacity.Value = TBar_BtnOpacity.Value;
        }

        private void Num_BtnOpacity_ValueChanged(object sender, EventArgs e)
        {
            TBar_BtnOpacity.Value = (int)Num_BtnOpacity.Value;
            Color btnColour = Color.FromKnownColor(KnownColor.Control);
            //(Owner as Form_MainForm).DrawBtnAndLbl((int)Num_BtnOpacity.Value);
            foreach (Control con in Owner.Controls)
            {
                if (con is Button)
                {
                    btnColour = con.BackColor;
                    break;
                }
            }
            visuals.DrawBtnAndLbl((int)Num_BtnOpacity.Value, btnColour);
        }

        private void Btn_BtnAndLblColour_Click(object sender, EventArgs e)
        {
            ColorDialog colDia = new ColorDialog();
            if (colDia.ShowDialog() != DialogResult.OK)
            {
                return;
            }
            visuals.DrawBtnAndLbl(((int)Num_BtnOpacity.Value < 255) ? (int)Num_BtnOpacity.Value : 254, colDia.Color);
        }

        private void Btn_Picture_Click(object sender, EventArgs e)
        {
            //(Owner as Form_MainForm).ChangeBackgroundImage();
            visuals.ChangeBackgroundImage();


        }

        private void TBar_BackgroundOpacity_Scroll(object sender, EventArgs e)
        {

        }

        private void Num_BackgroundOpacity_ValueChanged(object sender, EventArgs e)
        {

        }

        private void Btn_BackgroundColour_Click(object sender, EventArgs e)
        {
            ColorDialog colDia = new ColorDialog();
            if (colDia.ShowDialog() != DialogResult.OK)
            {
                return;
            }
            Owner.BackColor = colDia.Color;
        }

        private void TBar_PanelOpacity_Scroll(object sender, EventArgs e)
        {
            Num_PanelOpacity.Value = TBar_PanelOpacity.Value;
        }

        private void Num_PanelOpacity_ValueChanged(object sender, EventArgs e)
        {
            TBar_PanelOpacity.Value = (int)Num_PanelOpacity.Value;

            //(Owner as Form_MainForm).UpdatePanel((int)Num_PanelOpacity.Value);
            Color panelColour = Color.FromKnownColor(KnownColor.Control);
            foreach (Control con in Owner.Controls)
            {
                if (con is Panel)
                {
                    panelColour = con.BackColor;
                    break;
                }
            }
            visuals.UpdatePanel((int)Num_PanelOpacity.Value, panelColour);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //CaptureMainForm();

            
        }

        private void Btn_Save_Click(object sender, EventArgs e)
        {
            visuals.SaveProfile();
        }

        private void Btn_PanelColour_Click(object sender, EventArgs e)
        {
            ColorDialog colDia = new ColorDialog();
            if (colDia.ShowDialog() != DialogResult.OK)
            {
                return;
            }
            visuals.UpdatePanel((int)Num_PanelOpacity.Value, colDia.Color);
        }

        private void Btn_Default_Click(object sender, EventArgs e)
        {
            visuals.SetToDefault();
        }
    }
}
