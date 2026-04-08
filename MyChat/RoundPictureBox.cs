using System.Drawing.Drawing2D;
using System.Drawing;
using System.Windows.Forms;

namespace MyClub.MyChat
{
    public class RoundPictureBox : PictureBox
    {
        public int CornerRadius { get; set; } = 20;

        protected override void OnPaint(PaintEventArgs pe)
        {
            Graphics g = pe.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;

            using (GraphicsPath path = GetRoundRectangle(this.ClientRectangle, CornerRadius))
            using (Pen pen = new Pen(this.BackColor, 1))
            {
                this.Region = new Region(path);
                g.DrawPath(pen, path);
            }

            base.OnPaint(pe);
        }

        private GraphicsPath GetRoundRectangle(Rectangle rect, int radius)
        {
            GraphicsPath path = new GraphicsPath();
            int d = radius * 2;

            path.StartFigure();
            path.AddArc(rect.X, rect.Y, d, d, 180, 90);
            path.AddArc(rect.Right - d, rect.Y, d, d, 270, 90);
            path.AddArc(rect.Right - d, rect.Bottom - d, d, d, 0, 90);
            path.AddArc(rect.X, rect.Bottom - d, d, d, 90, 90);
            path.CloseFigure();

            return path;
        }
    }

}
