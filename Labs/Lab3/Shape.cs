using System;
using System.Drawing;

namespace Lab3
{
    public abstract class Shape
    {
        protected int x1, y1, x2, y2;

        public int X1 { get => x1; set => x1 = value; }
        public int Y1 { get => y1; set => y1 = value; }
        public int X2 { get => x2; set => x2 = value; }
        public int Y2 { get => y2; set => y2 = value; }

        public void SetCoords(int x1, int y1, int x2, int y2)
        {
            this.x1 = x1;
            this.y1 = y1;
            this.x2 = x2;
            this.y2 = y2;
        }

        public abstract void Draw(Graphics g);
    }

    public class PointShape : Shape
    {
        public override void Draw(Graphics g)
        {
            using (SolidBrush brush = new SolidBrush(Color.Black))
            {
                g.FillRectangle(brush, x1, y1, 2, 2);
            }
        }
    }

    public class LineShape : Shape
    {
        public override void Draw(Graphics g)
        {
            using (Pen pen = new Pen(Color.Black, 1))
            {
                g.DrawLine(pen, x1, y1, x2, y2);
            }
        }
    }
    public class RectShape : Shape
    {
        public override void Draw(Graphics g)
        {
            using (Pen pen = new Pen(Color.Black, 1))
            {
                int left = Math.Min(x1, x2);
                int top = Math.Min(y1, y2);
                int width = Math.Abs(x2 - x1);
                int height = Math.Abs(y2 - y1);

                g.DrawRectangle(pen, left, top, width, height);
            }
        }
    }

    public class EllipseShape : Shape
    {
        public override void Draw(Graphics g)
        {
            int rx = Math.Abs(x2 - x1);
            int ry = Math.Abs(y2 - y1);

            int left = x1 - rx;
            int top = y1 - ry;
            int width = 2 * rx;
            int height = 2 * ry;

            using (SolidBrush brush = new SolidBrush(Color.Pink))
            using (Pen pen = new Pen(Color.Black, 1))
            {
                g.FillEllipse(brush, left, top, width, height);
                g.DrawEllipse(pen, left, top, width, height);
            }
        }
    }
}