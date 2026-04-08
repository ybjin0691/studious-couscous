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
    public class LeftBalloonLabel : Control
    {
        public int CornerRadius { get; set; } = 10;
        public Color BalloonColor { get; set; } = Color.White;
        public Color BorderColor { get; set; } = Color.LightGray;
        public int TailSize { get; set; } = 10;
        
        public int MaxWidth { get; set; }

        public LeftBalloonLabel(int maxWidth)
        {
            this.Font = new Font("맑은 고딕", 10);
            this.ForeColor = Color.Black;
            this.DoubleBuffered = true;
            this.AutoSize = true;
            this.Padding = new Padding(15, 5, 10, 5);

            this.SetStyle(ControlStyles.SupportsTransparentBackColor, true);
            this.SetStyle(ControlStyles.UserPaint, true);
            this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            this.BackColor = Color.Transparent;

            this.TextChanged += (s, e) => AutoResize();

            MaxWidth = maxWidth - 110;
        }

        private void AutoResize()
        {
            Size textSize = TextRenderer.MeasureText(this.Text, this.Font, new Size(300, 0), TextFormatFlags.WordBreak);

            int maxWidth = textSize.Width + Padding.Horizontal;
            Console.WriteLine(maxWidth);
            Console.WriteLine(MaxWidth);
            if(maxWidth > MaxWidth) { maxWidth = MaxWidth; }

            this.Size = new Size(maxWidth, textSize.Height + Padding.Vertical + TailSize);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

            var bodyRect = new Rectangle(0, 0, this.Width - 1, this.Height - 1 - TailSize);
            var path = GetBalloonPath(bodyRect);

            using (SolidBrush brush = new SolidBrush(BalloonColor))
            using (Pen pen = new Pen(BorderColor))
            {
                e.Graphics.FillPath(brush, path);
                e.Graphics.DrawPath(pen, path);
            }

            Rectangle textRect = new Rectangle(Padding.Left, Padding.Top, this.Width - Padding.Horizontal, this.Height - Padding.Vertical - TailSize);
            TextRenderer.DrawText(
                e.Graphics, this.Text, this.Font,
                textRect, this.ForeColor,
                TextFormatFlags.WordBreak | TextFormatFlags.Left | TextFormatFlags.Top);
        }

        private GraphicsPath GetBalloonPath(Rectangle rect)
        {
            GraphicsPath path = new GraphicsPath();
            int r = CornerRadius;
            int t = TailSize;
            int tailY = rect.Top + 10;

            Rectangle balloonRect = new Rectangle(rect.X + t, rect.Y, rect.Width - t, rect.Height);

            path.AddArc(balloonRect.X, balloonRect.Y, r, r, 180, 90);
            path.AddArc(balloonRect.Right - r, balloonRect.Y, r, r, 270, 90);
            path.AddArc(balloonRect.Right - r, balloonRect.Bottom - r, r, r, 0, 90);
            path.AddArc(balloonRect.X, balloonRect.Bottom - r, r, r, 90, 90);
            path.CloseFigure();

            Point p1 = new Point(rect.X + t, tailY - 5); // 위
            Point p2 = new Point(rect.X, tailY);         // 가운데 (꼬리 뾰족한 부분)
            Point p3 = new Point(rect.X + t, tailY + 5); // 아래

            path.StartFigure();
            path.AddPolygon(new Point[] { p1, p2, p3 });
            path.CloseFigure();

            return path;
        }
    }
}
