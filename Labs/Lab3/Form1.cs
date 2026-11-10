using System;
using System.Drawing;
using System.Windows.Forms;

namespace Lab3
{
    public enum CurrentShapeType
    {
        Point,
        Line,
        Rect,
        Ellipse
    }

    public partial class Form1 : Form
    {
        private Shape[] shapes = new Shape[104];
        private int shapeCount = 0;
        private Shape? currentShape = null;
        private bool isDrawing = false;
        private CurrentShapeType selectedType = CurrentShapeType.Line;

        private ToolStripMenuItem menuObjPoint = null!;
        private ToolStripMenuItem menuObjLine = null!;
        private ToolStripMenuItem menuObjRect = null!;
        private ToolStripMenuItem menuObjEllipse = null!;

        public Form1()
        {
            InitializeComponent();
            this.DoubleBuffered = true;
            BuildInterface();
        }

        private void BuildInterface()
        {
            this.Text = "Графічний редактор Lab3";
            this.Width = 800;
            this.Height = 600;

            MenuStrip mainToolStripMenuItem = new MenuStrip();

            ToolStripMenuItem menuFile = new ToolStripMenuItem("Файл");
            ToolStripMenuItem menuFileExit = new ToolStripMenuItem("Вихід", null, (s, e) => Application.Exit());
            menuFile.DropDownItems.Add(menuFileExit);

            ToolStripMenuItem menuObjects = new ToolStripMenuItem("Об’єкти");

            menuObjPoint = new ToolStripMenuItem("Крапка", null, (s, e) => SetSelectedShape(CurrentShapeType.Point));
            menuObjLine = new ToolStripMenuItem("Лінія", null, (s, e) => SetSelectedShape(CurrentShapeType.Line));
            menuObjRect = new ToolStripMenuItem("Прямокутник", null, (s, e) => SetSelectedShape(CurrentShapeType.Rect));
            menuObjEllipse = new ToolStripMenuItem("Еліпс", null, (s, e) => SetSelectedShape(CurrentShapeType.Ellipse));

            menuObjects.DropDownItems.AddRange(new ToolStripItem[] {
                menuObjPoint, menuObjLine, menuObjRect, menuObjEllipse
            });

            menuObjLine.Checked = true;

            ToolStripMenuItem menuHelp = new ToolStripMenuItem("Довідка");
            ToolStripMenuItem menuHelpAbout = new ToolStripMenuItem("Про програму", null, (s, e) =>
                MessageBox.Show("Лабораторна робота №3", "Про програму"));
            menuHelp.DropDownItems.Add(menuHelpAbout);

            mainToolStripMenuItem.Items.Add(menuFile);
            mainToolStripMenuItem.Items.Add(menuObjects);
            mainToolStripMenuItem.Items.Add(menuHelp);

            this.MainMenuStrip = mainToolStripMenuItem;

            ImageList imageList = new ImageList();
            imageList.ImageSize = new Size(16, 16);

            Bitmap bmpPoint = new Bitmap(16, 16);
            using (Graphics g = Graphics.FromImage(bmpPoint))
            {
                g.Clear(Color.Transparent);
                g.FillRectangle(Brushes.Black, 7, 7, 3, 3);
            }

            Bitmap bmpLine = new Bitmap(16, 16);
            using (Graphics g = Graphics.FromImage(bmpLine))
            {
                g.Clear(Color.Transparent);
                g.DrawLine(Pens.Black, 2, 13, 13, 2);
            }

            Bitmap bmpRect = new Bitmap(16, 16);
            using (Graphics g = Graphics.FromImage(bmpRect))
            {
                g.Clear(Color.Transparent);
                g.DrawRectangle(Pens.Black, 2, 2, 11, 11);
            }

            Bitmap bmpEllipse = new Bitmap(16, 16);
            using (Graphics g = Graphics.FromImage(bmpEllipse))
            {
                g.Clear(Color.Transparent);
                g.FillEllipse(Brushes.Pink, 2, 2, 11, 11);
                g.DrawEllipse(Pens.Black, 2, 2, 11, 11);
            }

            imageList.Images.Add(bmpPoint);
            imageList.Images.Add(bmpLine);
            imageList.Images.Add(bmpRect);
            imageList.Images.Add(bmpEllipse);

            ToolStrip toolStrip = new ToolStrip();
            toolStrip.ImageList = imageList;

            ToolStripButton btnPoint = new ToolStripButton()
            {
                ImageIndex = 0,
                DisplayStyle = ToolStripItemDisplayStyle.Image,
                ToolTipText = "Крапка"
            };
            btnPoint.Click += (s, e) => SetSelectedShape(CurrentShapeType.Point);

            ToolStripButton btnLine = new ToolStripButton()
            {
                ImageIndex = 1,
                DisplayStyle = ToolStripItemDisplayStyle.Image,
                ToolTipText = "Лінія"
            };
            btnLine.Click += (s, e) => SetSelectedShape(CurrentShapeType.Line);

            ToolStripButton btnRect = new ToolStripButton()
            {
                ImageIndex = 2,
                DisplayStyle = ToolStripItemDisplayStyle.Image,
                ToolTipText = "Прямокутник"
            };
            btnRect.Click += (s, e) => SetSelectedShape(CurrentShapeType.Rect);

            ToolStripButton btnEllipse = new ToolStripButton()
            {
                ImageIndex = 3,
                DisplayStyle = ToolStripItemDisplayStyle.Image,
                ToolTipText = "Еліпс"
            };
            btnEllipse.Click += (s, e) => SetSelectedShape(CurrentShapeType.Ellipse);

            toolStrip.Items.AddRange(new ToolStripItem[] {
                btnPoint, btnLine, btnRect, btnEllipse
            });

            this.Controls.Add(toolStrip);
            this.Controls.Add(mainToolStripMenuItem);

            this.MouseDown += Form1_MouseDown;
            this.MouseMove += Form1_MouseMove;
            this.MouseUp += Form1_MouseUp;
        }

        private void SetSelectedShape(CurrentShapeType type)
        {
            selectedType = type;

            menuObjPoint.Checked = (type == CurrentShapeType.Point);
            menuObjLine.Checked = (type == CurrentShapeType.Line);
            menuObjRect.Checked = (type == CurrentShapeType.Rect);
            menuObjEllipse.Checked = (type == CurrentShapeType.Ellipse);
        }

        private void Form1_MouseDown(object? sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if (shapeCount >= 104)
                {
                    MessageBox.Show("Досягнуто ліміт масиву", "Помилка");
                    return;
                }

                isDrawing = true;

                switch (selectedType)
                {
                    case CurrentShapeType.Point:
                        currentShape = new PointShape();
                        break;
                    case CurrentShapeType.Line:
                        currentShape = new LineShape();
                        break;
                    case CurrentShapeType.Rect:
                        currentShape = new RectShape();
                        break;
                    case CurrentShapeType.Ellipse:
                        currentShape = new EllipseShape();
                        break;
                }

                if (currentShape != null)
                {
                    currentShape.SetCoords(e.X, e.Y, e.X, e.Y);
                }
            }
        }

        private void Form1_MouseMove(object? sender, MouseEventArgs e)
        {
            if (isDrawing && currentShape != null)
            {
                currentShape.X2 = e.X;
                currentShape.Y2 = e.Y;
                this.Invalidate();
            }
        }

        private void Form1_MouseUp(object? sender, MouseEventArgs e)
        {
            if (isDrawing && currentShape != null)
            {
                currentShape.X2 = e.X;
                currentShape.Y2 = e.Y;

                if (shapeCount < 104)
                {
                    shapes[shapeCount] = currentShape;
                    shapeCount++;
                }

                currentShape = null;
                isDrawing = false;
                this.Invalidate();
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            for (int i = 0; i < shapeCount; i++)
            {
                shapes[i].Draw(e.Graphics);
            }

            if (isDrawing && currentShape != null)
            {
                currentShape.Draw(e.Graphics);
            }
        }
    }
}