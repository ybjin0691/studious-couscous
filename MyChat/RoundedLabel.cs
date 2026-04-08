using System;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyClub.MyChat
{
    internal class RoundedLabel : Label
    {
        public int CornerRadius { get; set; } = 10;
        public Color BorderColor { get; set; } = Color.Gray;
        public Color FillColor { get; set; } = Color.Transparent;

        public RoundedLabel()
        {
            this.BackColor = Color.Transparent;
            this.ForeColor = Color.DimGray;
            this.TextAlign = ContentAlignment.MiddleCenter;
            this.Padding = new Padding(10, 5, 10, 5);
            this.AutoSize = true;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

            Rectangle rect = this.ClientRectangle;
            rect.Inflate(-1, -1); // 테두리 안쪽

            using (GraphicsPath path = RoundedRect(rect, CornerRadius))
            using (Pen borderPen = new Pen(BorderColor))
            using (SolidBrush fillBrush = new SolidBrush(FillColor))
            {
                e.Graphics.FillPath(fillBrush, path);
                e.Graphics.DrawPath(borderPen, path);
            }

            TextRenderer.DrawText(e.Graphics, this.Text, this.Font, rect, this.ForeColor, TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter);
        }

        private GraphicsPath RoundedRect(Rectangle bounds, int radius)
        {
            int d = radius * 2;
            GraphicsPath path = new GraphicsPath();
            path.AddArc(bounds.X, bounds.Y, d, d, 180, 90);
            path.AddArc(bounds.Right - d, bounds.Y, d, d, 270, 90);
            path.AddArc(bounds.Right - d, bounds.Bottom - d, d, d, 0, 90);
            path.AddArc(bounds.X, bounds.Bottom - d, d, d, 90, 90);
            path.CloseFigure();
            return path;
        }
    }
}

