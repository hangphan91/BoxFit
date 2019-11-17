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
        public RectangularBox MyContainer { get; set; }
        public RectangularBox BiggiestBin { get; set; }
        public bool IsHorizontal { get; set; }
        public List<Task> Tasks { get; set; }

        public MainForm()
        {
            InitializeComponent();
            Points = new List<RectangularBox>();
            MaxLine = new List<Point>();
            read = new ReadCSVFile();
            MyContainer = new RectangularBox();
            BiggiestBin = new RectangularBox();
            Tasks = new List<Task>();
            dictionary = read.BoxListReadOnly;
            applyAlgorith = new BoxFittingAlgorithm();
            PerformBoxFittingAlgorithm(dictionary);
            this.Refresh();
        }

        private void PerformBoxFittingAlgorithm(Dictionary<int, RectangularBox> dictionary)
        {
            ContainerWidth = applyAlgorith.CurrentContainer.Width;
            var task2 = Task.Run(() => applyAlgorith.GetOptimizationListOrder(dictionary));

            Tasks.Add(task2);
            Task.WaitAll(Tasks.ToArray());
            MyContainer = applyAlgorith.MyContainer;
            Points = applyAlgorith.Gaps;
            MaxHeight = applyAlgorith.MaxHeight;
            lblBoxes.Text = applyAlgorith.MyResult;
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

        internal void SetContainerSizes(int width, int height)
        {
            MyContainer.Width = width;
            MyContainer.Height = height;
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
                this.box.FlatStyle = FlatStyle.Popup;
                this.box.BackColor = Color.FromArgb(180, (item.Height*2)%255, (item.Height *6 )%255, (item.Width*2)%255);
                var toolTip = new System.Windows.Forms.ToolTip();
                toolTip.SetToolTip(box, $"X: { item.X} Y: {item.Y} Width: {item.Width} Height {item.Height}");
                this.container.Controls.Add(this.box);
                index++;
            }
            txtWidth.Text = "Width: " + applyAlgorith.MaxWidth.ToString();
            txtHeight.Text = "Height: " + MaxHeight.ToString();
            this.box2 = new System.Windows.Forms.Button();
            this.box2.Location = new System.Drawing.Point(0, MaxHeight);
            this.box2.Size = new System.Drawing.Size(applyAlgorith.MaxWidth, 5);
            this.box2.BackColor = Color.Red;
            this.box2.FlatStyle = FlatStyle.Flat;

            var toolTip1 = new System.Windows.Forms.ToolTip();
            toolTip1.SetToolTip(box2, $"Width: { applyAlgorith.MaxWidth}");
            this.container.Controls.Add(this.box2);
            this.box2 = new System.Windows.Forms.Button();
            this.box2.Location = new System.Drawing.Point(applyAlgorith.MaxWidth, 0);
            this.box2.Size = new System.Drawing.Size(5, MaxHeight);
            this.box2.BackColor = Color.Red;
            this.box2.FlatStyle = FlatStyle.Flat;

            toolTip1 = new System.Windows.Forms.ToolTip();
            toolTip1.SetToolTip(box2, $"Height: { MaxHeight}");
            this.container.Controls.Add(this.box2);
            for (int i = 0; i < applyAlgorith.NumberOfMyContainerUsed; i++)
            {
                this.box2 = new System.Windows.Forms.Button();
                this.box2.Location = new System.Drawing.Point(0, MyContainer.Height*(i+1));
                this.box2.Size = new System.Drawing.Size(MyContainer.Width, 5);
                this.box2.BackColor = Color.Red;
                this.box2.FlatStyle = FlatStyle.Flat;
                this.container.Controls.Add(this.box2);
            }
        }

        internal void SetMultipleContainers(bool @checked)
        {
            applyAlgorith.SetMultipleContainers(@checked);
        }

        internal void SetAlgorithmType(bool isHorizontal)
        {
            applyAlgorith.SetAlgorithm(isHorizontal);
            IsHorizontal = isHorizontal;
        }

        internal void SetMaxWidth(int maxwidth)
        {
            applyAlgorith.SetContainerWidth(maxwidth);
        }

        internal void SetMaxHeight(int maxheight)
        {
            applyAlgorith.SetContainerHeight(maxheight);
        }


        private void Container_Paint(object sender, PaintEventArgs e)
        {
            for (int i = 0; i < applyAlgorith.NumberOfMyContainerUsed; i++)
            {
                e.Graphics.DrawLines(Pens.Red, new List<Point> { new Point { X = 0, Y = MyContainer.Height * (i + 1) }, new Point { X = MyContainer.Width, Y = MyContainer.Height * (i + 1) } }.ToArray());

            }
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

            this.Show();
            this.Refresh();
        }

        private void BtnMyContainer_Click(object sender, EventArgs e)
        {
            var myContainerInput = new FixSizeContainer(this);
            myContainerInput.ShowDialog();
            FittingBinsIntoMyContainer();

            this.Show();
        }

        private void FittingBinsIntoMyContainer()
        {
            applyAlgorith.GetSortedListForPairIndexValue();
            if (IsHorizontal)
            {
                FitMyContainerHorizontal();
            }
            else
            {
                FitMyContainerVertical();
            }
        }

        private void FitMyContainerVertical()
        {
            ResetContainers();
            var task1 = Task.Run(() => applyAlgorith.FitMyContainerVertical());
            Tasks.Add(task1);
            Task.WaitAll(Tasks.ToArray());
            ShowAndDisplayResults();
        }

        private void FitMyContainerHorizontal()
        {
            ResetContainers();
            var task1 = Task.Run(() => applyAlgorith.FitMyContainerHorizontal());
            Tasks.Add(task1);
            Task.WaitAll(Tasks.ToArray());
            ShowAndDisplayResults();
        }

        private void ShowAndDisplayResults()
        {
            applyAlgorith.BinList = applyAlgorith.Bins;
            MaxHeight = MyContainer.Height * (applyAlgorith.NumberOfMyContainerUsed);
            applyAlgorith.MaxWidth = MyContainer.Width;
            applyAlgorith.MaxHeight = MaxHeight;
            applyAlgorith.UsedArea = applyAlgorith.BinList.Sum(t => t.Height * t.Width);
            applyAlgorith.DisplayResults();
            lblBoxes.Text = applyAlgorith.MyResult;
            OptimumDrawing(applyAlgorith);
            this.paper.Controls.Add(this.container);
            this.Show();
            this.Refresh();
        }

        private void ResetContainers()
        {
            container.Controls.Clear();
            Points = new List<RectangularBox>();
            MaxLine = new List<Point>();
            applyAlgorith.Gaps1.Clear();
            applyAlgorith.Gaps2.Clear();
            applyAlgorith.WastedGaps.Clear();
            applyAlgorith.BinList.Clear();
            applyAlgorith.Bins.Clear();
            applyAlgorith.MyResult = "";
            applyAlgorith.NumberOfMyContainerUsed = 0;
            MyContainer.Y = 0;
            applyAlgorith.CurrentContainer = MyContainer;
        }
    }

}
