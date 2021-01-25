using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace CAdminTools
{
    class ImageTextBox : TextBox
    {
        public ImageTextBox()
        {
            //this.SetStyle(ControlStyles.SupportsTransparentBackColor, true);
           // this.BackColor = Color.Transparent;

            SetStyle(ControlStyles.SupportsTransparentBackColor |
                 ControlStyles.OptimizedDoubleBuffer |
                 ControlStyles.AllPaintingInWmPaint |
                 ControlStyles.ResizeRedraw |
                 ControlStyles.UserPaint, true);
            //BackColor = Color.FromArgb(125, BackColor);
            TextChanged += ImageTextBox_OnTextChanged;
        }

        public void ImageTextBox_OnTextChanged(object sender, EventArgs e)
        {
            Invalidate();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            var backgroundBrush = new SolidBrush(Color.Transparent);
            Graphics g = e.Graphics;
            g.FillRectangle(backgroundBrush, 0, 0, this.Width, this.Height);
            g.DrawString(Text, Font, new SolidBrush(ForeColor), new PointF(0, 0), StringFormat.GenericDefault);
        }
    }
}
