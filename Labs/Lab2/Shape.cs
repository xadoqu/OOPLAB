using System;
using System.Drawing;

namespace Lab2
{
    public abstract class Shape
    {
        protected int x1, y1, x2, y2;

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

    public class RectangleShape : Shape
    {
        public override void Draw(Graphics g)
        {
            using (Pen pen = new Pen(Color.Black, 1))
            {
                int rx = Math.Abs(x2 - x1);
                int ry = Math.Abs(y2 - y1);

                int left = x1 - rx;
                int top = y1 - ry;
                int width = 2 * rx;
                int height = 2 * ry;

                g.DrawRectangle(pen, left, top, width, height);
            }
        }
    }

    public class EllipseShape : Shape
    {
        public override void Draw(Graphics g)
        {
            int left = Math.Min(x1, x2);
            int top = Math.Min(y1, y2);
            int width = Math.Abs(x2 - x1);
            int height = Math.Abs(y2 - y1);

            using (SolidBrush brush = new SolidBrush(Color.Pink))
            using (Pen pen = new Pen(Color.Black, 1))
            {
                g.FillEllipse(brush, left, top, width, height);
                g.DrawEllipse(pen, left, top, width, height);
            }
        }
    }
}