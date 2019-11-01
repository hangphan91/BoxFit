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
    public partial class MainForm : Form
    {
        public List<RectangularBox> Points { get; set; }
        public List<Point> MaxLine { get; set; }
        public List<Point> CursorPoints { get; set; }
        public int ContainerWidth { get; set; }
        public int MaxHeight { get; set; }
        public UserInput UserInput { get; set; }
        public BoxFittingAlgorithm applyAlgorith { get; set; }
        public ReadCSVFile read { get; set; }
        public Dictionary<int, RectangularBox> dictionary { get; set; }

        public MainForm()
        {
            InitializeComponent();
            Points = new List<RectangularBox>();
            MaxLine = new List<Point>();
            read = new ReadCSVFile();
            dictionary = read.BoxListReadOnly;
            applyAlgorith = new BoxFittingAlgorithm();
            UserInput = new UserInput(this, applyAlgorith.InputWidth, applyAlgorith.InputHeight);
            UserInput.ShowDialog();
            PerformBoxFittingAlgorithm(dictionary);
            this.Refresh();
        }

        private void PerformBoxFittingAlgorithm(Dictionary<int, RectangularBox> dictionary)
        {
            ContainerWidth = applyAlgorith.CurrentContainer.Width;
            applyAlgorith.GetOptimizationListOrder(dictionary);
            Points = applyAlgorith.Gaps;
            MaxHeight = applyAlgorith.MaxHeight;
            lblBoxes.Text = applyAlgorith.MyResult;
            lblResult.Text = applyAlgorith.DisplayResult;
            var optimization = applyAlgorith.OptimizedBoxList;
            optimization = new Dictionary<int, RectangularBox>();

            for (int i = 0; i < applyAlgorith.BinList.Count; i++)
            {
                optimization.Add(i, applyAlgorith.BinList[i]);
            }
            var maxY = 0;
            OptimumDrawing(applyAlgorith);
            MaxLine.Add(new Point(applyAlgorith.ContainerWidth, maxY));
            MaxLine.Add(new Point(0, maxY));
            this.paper.Controls.Add(this.container);
            this.Refresh();
        }

        private void OptimumDrawing(BoxFittingAlgorithm applyAlgorith)
        {
            var index = 0;
            foreach (var item in applyAlgorith.BinList)
            {
                this.box = new System.Windows.Forms.Button();
                this.box.Location = new System.Drawing.Point(item.X, item.Y);
                this.box.Name = "box " + index;
                this.box.Size = new System.Drawing.Size(item.Width, item.Height);
                this.box.TabIndex = 0;
                this.box.Text = "box " + index;
                   // + ": " + item.X + " x " + item.Y + "--W: " + item.Width
                  //  + "H: " + item.Height;
                this.box.UseVisualStyleBackColor = true;
                var toolTip = new System.Windows.Forms.ToolTip();
                toolTip.SetToolTip(box, $"X: { item.X} Y: {item.Y} Width: {item.Width} Height {item.Height}");
                this.container.Controls.Add(this.box);
                index++;
            }
            txtWidth.Text = "Width: " + applyAlgorith.MaxWidth.ToString();
            txtHeight.Text = "Height: " + MaxHeight.ToString();
            this.box2 = new System.Windows.Forms.Button();
            this.box2.Location = new System.Drawing.Point(0, MaxHeight);
            this.box2.Size = new System.Drawing.Size(applyAlgorith.MaxWidth, 10);
            this.box2.BackColor = Color.Red;
            var toolTip1 = new System.Windows.Forms.ToolTip();
            toolTip1.SetToolTip(box2, $"Width: { applyAlgorith.MaxWidth}");
            this.container.Controls.Add(this.box2);
            this.box2 = new System.Windows.Forms.Button();
            this.box2.Location = new System.Drawing.Point(applyAlgorith.MaxWidth, 0);
            this.box2.Size = new System.Drawing.Size(10, MaxHeight);
            this.box2.BackColor = Color.Red;
            toolTip1 = new System.Windows.Forms.ToolTip();
            toolTip1.SetToolTip(box2, $"Height: { MaxHeight}");
            this.container.Controls.Add(this.box2);
        }

        internal void SetMultipleContainers(bool @checked)
        {
            applyAlgorith.SetMultipleContainers(@checked);
        }

        internal void SetAlgorithmType(bool isHorizontal)
        {
            applyAlgorith.SetAlgorithm(isHorizontal);
        }

        internal void SetMaxWidth(int maxwidth)
        {
            applyAlgorith.SetContainerWidth(maxwidth);
        }

        internal void SetMaxHeight(int maxheight)
        {
            applyAlgorith.SetContainerHeight(maxheight);
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
                this.box.Text = "box " + item.Key + item.Value.X + " x " + item.Value.Y;
                this.box.UseVisualStyleBackColor = true;
               
                this.container.Controls.Add(this.box);
                XCoordinate += item.Value.X;
                maxY = Math.Max(maxY, item.Value.Y + YCoordinate);
                var nextX = GetNextItem(item, optimization);
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
            //e.Graphics.DrawLines(Pens.Red, new List<Point> { new Point { X = this.ContainerWidth, Y = 0 }, new Point { X = this.ContainerWidth, Y = MaxHeight }, new Point { X = 0, Y = MaxHeight } }.ToArray());
            // e.Graphics.DrawLines(Pens.Red, new List<Point> { new Point { X = 0, Y = MaxHeight }, new Point { X = this.ContainerWidth, Y = MaxHeight } }.ToArray());
        }

        private void btnUserInput_Click(object sender, EventArgs e)
        {
            container.Controls.Clear();
            Points = new List<RectangularBox>();
            MaxLine = new List<Point>();
            read = new ReadCSVFile();
            dictionary = read.BoxListReadOnly;
            var inputWidth = applyAlgorith.InputWidth;
            var inputHeight = applyAlgorith.InputHeight;
            applyAlgorith = new BoxFittingAlgorithm();
            UserInput = new UserInput(this, inputWidth, inputHeight);
            UserInput.ShowDialog();
            PerformBoxFittingAlgorithm(dictionary);
            this.Refresh();
        }
    }

}
