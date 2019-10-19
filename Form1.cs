using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace boxfittingapp
{
    public partial class Form1 : Form
    {
        public List<Point> Points { get; set; }
        public List<Point> MaxLine { get; set; }
        public List<Point> CursorPoints { get; set; }
        public int ContainerWidth { get; set; }

        public Form1()
        {
            InitializeComponent();
            Points = new List<Point>();
            MaxLine = new List<Point>();
            ReadCSVFile read = new ReadCSVFile();
            var dictionary = read.BoxListReadOnly;
            var applyAlgorith = new BoxFittingAlgorithm();
            applyAlgorith.GetOptimizationListOrder(dictionary);
            CursorPoints = applyAlgorith.CursorPoints;
            txtMyString.Text = applyAlgorith.MyResult;
            ContainerWidth = applyAlgorith.ContainerWidth;
            var optimization = applyAlgorith.OptimizedBoxList;
            optimization = new Dictionary<int, RectangularBox>();
            for (int i = 0; i < applyAlgorith.ResultList.Count; i++)
            {
                optimization.Add(i, applyAlgorith.ResultList[i]);
            }
            var XCoordinate = 0; var YCoordinate = 0;
            var maxY = 0;
           // DefaultDrawing(applyAlgorith, optimization, ref XCoordinate, ref YCoordinate, ref maxY);
            OptimumDrawing(applyAlgorith, optimization, ref XCoordinate, ref YCoordinate, ref maxY);
            MaxLine.Add(new Point(applyAlgorith.ContainerWidth, maxY));
            MaxLine.Add(new Point(0, maxY));
            this.Refresh();
        }

        private void OptimumDrawing(BoxFittingAlgorithm applyAlgorith, Dictionary<int, RectangularBox> optimization, ref int XCoordinate, ref int YCoordinate, ref int maxY)
        {
            var index = 0;
            foreach (var item in optimization)
            {
                this.box = new System.Windows.Forms.Button();
                this.box.Location = new System.Drawing.Point(applyAlgorith.ResultListCoordinates[index].X, applyAlgorith.ResultListCoordinates[index].Y);
                this.box.Name = "box " + item.Key;
                this.box.Size = new System.Drawing.Size(item.Value.X, item.Value.Y);
                this.box.TabIndex = 0;
                this.box.Text = "box " + item.Key +": "+ item.Value.X + " x " + item.Value.Y + "--CorX: " + applyAlgorith.ResultListCoordinates[index].X
                    + "CorY: " + applyAlgorith.ResultListCoordinates[index].Y;
                this.box.UseVisualStyleBackColor = true;
                this.container.Controls.Add(this.box);
                XCoordinate += item.Value.X;
                maxY = Math.Max(maxY, item.Value.Y + YCoordinate);
                var nextX = GetNextItem(item, optimization);
                if (nextX > 0 && XCoordinate + nextX >= applyAlgorith.ContainerWidth)
                {
                    Points.Add(new Point(applyAlgorith.ContainerWidth, maxY));
                    Points.Add(new Point(0, maxY));
                    XCoordinate = 0;
                    YCoordinate += maxY;
                }
                index++;
            }
            txtHeight.Text = maxY.ToString();
            txtWidth.Text = ContainerWidth.ToString() + " Total bins:" + optimization.Count;

        }

        private void DefaultDrawing(BoxFittingAlgorithm applyAlgorith, Dictionary<int, RectangularBox> optimization, ref int XCoordinate, ref int YCoordinate, ref int maxY)
        {
            foreach (var item in optimization)
            {
                this.box = new System.Windows.Forms.Button();
                this.box.Location = new System.Drawing.Point(XCoordinate, YCoordinate);
                this.box.Name = "box " + item.Key;
                this.box.Size = new System.Drawing.Size(item.Value.X, item.Value.Y);
                this.box.TabIndex = 0;
                this.box.Text = "box " +item.Key + item.Value.X +" x " + item.Value.Y;
                this.box.UseVisualStyleBackColor = true;
                this.container.Controls.Add(this.box);
                XCoordinate += item.Value.X;
                maxY = Math.Max(maxY, item.Value.Y + YCoordinate);
                var nextX = GetNextItem(item, optimization);
                if (nextX > 0 && XCoordinate + nextX >= applyAlgorith.ContainerWidth)
                {
                    Points.Add(new Point(applyAlgorith.ContainerWidth, maxY));
                    Points.Add(new Point(0, maxY));
                    XCoordinate = 0;
                    YCoordinate += maxY;
                }
            }
        }

        private int GetNextItem(KeyValuePair<int, RectangularBox> item, Dictionary<int, RectangularBox> optimization)
        {
            if (optimization.Count > item.Key + 1)
            {
                return optimization[item.Key + 1].X;
            }
            else
            {
                return -1;
            }

        }

        private void Container_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawLines(Pens.Red, Points.ToArray());
            e.Graphics.DrawLines(Pens.Red, new List<Point> { new Point {X =this.ContainerWidth ,Y =0}, new Point { X = this.ContainerWidth, Y = 1000 } }.ToArray());
            //e.Graphics.DrawLines(Pens.Red, MaxLine.ToArray());
            foreach (var item in CursorPoints)
            {
                e.Graphics.DrawEllipse(Pens.Blue, item.X, item.Y, 10, 10);
            }
            
        }
    }

}
