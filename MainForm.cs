﻿using boxfittingapp.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace boxfittingapp
{
    public partial class MainForm : Form
    {
        private int timeleft;
        #region properties
        public Timer Timer { get; set; }
        public int Score { get; set; }
        public List<RectangularBox> Points { get; set; }
        public List<Point> MaxLine { get; set; }
        public List<Point> CursorPoints { get; set; }
        public int ContainerWidth { get; set; }
        public int MaxHeight { get; set; }
        public UserInput UserInput { get; set; }
        public BoxFittingAlgorithm applyAlgorith { get; set; }
        public ReadInputSizes read { get; set; }
        public Dictionary<int, RectangularBox> dictionary { get; set; }
        public RectangularBox MyContainer { get; set; }
        public RectangularBox BiggiestBin { get; set; }
        public bool IsHorizontal { get; set; }
        public List<Task> Tasks { get; set; }
        public GridView CurrentRow { get; set; }
        public BindingList<GridView> Rows { get; set; }
        public Bitmap Bitmap { get; private set; }
        public List<Button> SuggestionButtonList { get; set; }
        public Button CurrentSelection { get; set; }
        public List<int> RandomList { get; private set; }
        public List<Button> ListSuggestionToShow { get; private set; }
        public BindingList<RectangularBox> InputBoxes { get; set; }

        public const int TimeLimit = 120;
        #endregion
        public MainForm()
        {
            InitializeComponent();
            Score = 0;
            InputBoxes = new BindingList<RectangularBox>();
            Points = new List<RectangularBox>();
            MaxLine = new List<Point>();
            read = new ReadInputSizes();
            MyContainer = new RectangularBox();
            BiggiestBin = new RectangularBox();
            Tasks = new List<Task>();
            CurrentRow = new GridView();
            Rows = new BindingList<GridView>();
            dgvInputSizes.DataSource = InputBoxes;
            ListSuggestionToShow = new List<Button>();
            Start();
        }

        private void Start()
        {
            dictionary = read.BoxListReadOnly;
            applyAlgorith = new BoxFittingAlgorithm();
            CurrentSelection = new Button();
            SuggestionButtonList = new List<Button>();
            Timer = new Timer();
            timeleft = TimeLimit;
            PerformBoxFittingAlgorithm(dictionary);
            FitMyContainerHorizontal();
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
                this.box.BackColor = Color.FromArgb(180, (item.Height * 2) % 255, (item.Height * 6) % 255, (item.Width * 2) % 255);
                var toolTip = new System.Windows.Forms.ToolTip();
                toolTip.SetToolTip(box, $"Container# {applyAlgorith.ContainerNumbers[index]} X: { item.X} Y: {item.Y} Width: {item.Width} Height {item.Height}");
                this.container.Controls.Add(this.box);
                index++;
            }
            DrawBorders(applyAlgorith);
            DrawBarrierForEachContainer(applyAlgorith);
            container.Size = new Size(applyAlgorith.MaxWidth, applyAlgorith.MaxHeight);

            //foreach (Control item in container.Controls)
            //{
            //    pnlCopycontainer.Controls.Add(item);
            //}

            this.Refresh();
        }

        private void DrawBorders(BoxFittingAlgorithm applyAlgorith)
        {
            txtWidth.Text = "Width: " + applyAlgorith.MaxWidth.ToString();
            txtHeight.Text = "Height: " + MaxHeight.ToString();
            this.box2 = new System.Windows.Forms.Button();
            this.box2.Location = new System.Drawing.Point(0, MaxHeight);
            this.box2.Size = new System.Drawing.Size(applyAlgorith.MaxWidth, 2);
            this.box2.BackColor = Color.Red;
            this.box2.FlatStyle = FlatStyle.Flat;
            var toolTip1 = new System.Windows.Forms.ToolTip();
            toolTip1.SetToolTip(box2, $"Width: { applyAlgorith.MaxWidth}");
            this.container.Controls.Add(this.box2);

            this.box2 = new System.Windows.Forms.Button();
            this.box2.Location = new System.Drawing.Point(applyAlgorith.MaxWidth, 0);
            this.box2.Size = new System.Drawing.Size(2, MaxHeight);
            this.box2.BackColor = Color.Red;
            this.box2.FlatStyle = FlatStyle.Flat;
            toolTip1 = new System.Windows.Forms.ToolTip();
            toolTip1.SetToolTip(box2, $"Height: { MaxHeight}");
            this.container.Controls.Add(this.box2);

            this.box2 = new System.Windows.Forms.Button();
            this.box2.Location = new System.Drawing.Point(0, 0);
            this.box2.Size = new System.Drawing.Size(2, MaxHeight);
            this.box2.BackColor = Color.Red;
            this.box2.FlatStyle = FlatStyle.Flat;
            this.container.Controls.Add(this.box2);

            this.box2 = new System.Windows.Forms.Button();
            this.box2.Location = new System.Drawing.Point(0, 0);
            this.box2.Size = new System.Drawing.Size(2, MaxHeight);
            this.box2.BackColor = Color.Red;
            this.box2.FlatStyle = FlatStyle.Flat;
            this.container.Controls.Add(this.box2);
        }

        private void DrawBarrierForEachContainer(BoxFittingAlgorithm applyAlgorith)
        {
            for (int i = 0; i < applyAlgorith.NumberOfMyContainerUsed; i++)
            {
                this.box2 = new System.Windows.Forms.Button();
                this.box2.Location = new System.Drawing.Point(0, MyContainer.Height * (i + 1));
                this.box2.Size = new System.Drawing.Size(MyContainer.Width, 2);
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
            if (applyAlgorith.Bins.Count > 0)
            {
                InputBoxes.Clear();
                dgvInputSizes.Columns[3].Visible = true;
                dgvInputSizes.Columns[4].Visible = true;
                dgvInputSizes.Columns[0].Visible = true;
            }
            foreach (var item in applyAlgorith.Bins)
            {
                InputBoxes.Add(item);
            }

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
            applyAlgorith.ContainerNumbers.Clear();
            applyAlgorith.Gaps1.Clear();
            applyAlgorith.Gaps2.Clear();
            applyAlgorith.WastedGaps.Clear();
            applyAlgorith.BinList.Clear();
            applyAlgorith.Bins.Clear();
            applyAlgorith.SuggestionBins.Clear();
            applyAlgorith.MyResult = "";
            applyAlgorith.NumberOfMyContainerUsed = 0;
            MyContainer.Y = 0;
            applyAlgorith.CurrentContainer = MyContainer;
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            if (applyAlgorith.BinList.Count > 0)
            {
                CurrentRow = applyAlgorith.MapToGridView();
                CurrentRow.Image = Bitmap;
                CurrentRow.RowID = Rows.Any(t => t.RowID == Rows.Count + 1) ? Rows.LastOrDefault().RowID + 1 : Rows.Count + 1;
                Rows.Add(CurrentRow);
                SavetoGrid();
            }
            this.tabPage2.Show();
        }

        private void SavetoGrid()
        {
            SaveImage();
            dgvPanel.DataSource = Rows;
            dgvPanel.Refresh();
        }

        private void BtnExport_Click(object sender, EventArgs e)
        {
            copyAlltoClipboard();

            ExportToExcel();
        }

        private void ExportToExcel()
        {
            Microsoft.Office.Interop.Excel.Application xlexcel;
            Microsoft.Office.Interop.Excel.Workbook xlWorkBook;
            Microsoft.Office.Interop.Excel.Worksheet xlWorkSheet;
            object misValue = System.Reflection.Missing.Value;
            xlexcel = new Microsoft.Office.Interop.Excel.Application();
            xlexcel.Visible = true;
            xlWorkBook = xlexcel.Workbooks.Add(misValue);
            xlWorkSheet = (Microsoft.Office.Interop.Excel.Worksheet)xlWorkBook.Worksheets.get_Item(1);
            int j = 0, i = 0;
            int StartCol = 1;
            int StartRow = 1;

            //Write Headers
            for (j = 0; j < dgvPanel.Columns.Count; j++)
            {
                if (dgvPanel.Columns[j].Visible == true)
                {
                    Microsoft.Office.Interop.Excel.Range myRange = (Microsoft.Office.Interop.Excel.Range)xlWorkSheet.Cells[StartRow, StartCol + j];
                    myRange.Value2 = dgvPanel.Columns[j].HeaderText;
                }
            }
            xlWorkSheet.Columns.AutoFit();
            StartRow++;

            //Write datagridview content
            for (i = 0; i < dgvPanel.Rows.Count; i++)
            {
                for (j = 0; j < dgvPanel.Columns.Count; j++)
                {
                    try
                    {
                        if (dgvPanel.Columns[j].Visible == true)
                        {
                            Microsoft.Office.Interop.Excel.Range myRange = (Microsoft.Office.Interop.Excel.Range)xlWorkSheet.Cells[StartRow + i, StartCol + j];
                            myRange.Value2 = dgvPanel[j, i].Value == null ? "" : dgvPanel[j, i].Value;

                        }
                    }
                    catch
                    {
                        ;
                    }
                }
            }
        }

        private void copyAlltoClipboard()
        {
            dgvPanel.SelectAll();
            DataObject dataObj = dgvPanel.GetClipboardContent();
            if (dataObj != null)
                Clipboard.SetDataObject(dataObj);
        }

        private void RemoveColumnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Make every column not sortable.
            for (int i = 0; i < dgvPanel.Columns.Count; i++)
                dgvPanel.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;

            if (dgvPanel.CurrentCell != null && dgvPanel.CurrentCell.ColumnIndex != 0)
            {
                int columnIndex = dgvPanel.CurrentCell.ColumnIndex;
                dgvPanel.Columns.RemoveAt(columnIndex);
                dgvPanel.Columns[columnIndex].Visible = false;
            }
        }

        private void RemoveRowToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dgvPanel.CurrentCell != null)
            {
                int rowIndex = dgvPanel.CurrentCell.RowIndex;
                dgvPanel.Rows.RemoveAt(rowIndex);
            }
        }

        private void DgvPanel_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                contextMenuStrip1.Visible = true;
                contextMenuStrip1.Show(this, e.X, e.Y + contextMenuStrip1.Size.Height);
            }
        }

        private void BtnSaveImage_Click(object sender, EventArgs e)
        {
            SaveImage();
            System.Diagnostics.Process.Start(@"C:\Users\hang2\Source\Repos\BoxFit2\Images" + CurrentRow.RowID + ".bmp");

        }

        private void SaveImage()
        {
            Bitmap = new Bitmap(this.Width, this.Height);
            Graphics graphics = Graphics.FromImage(Bitmap);
            Rectangle rect = container.RectangleToScreen(container.ClientRectangle);
            graphics.CopyFromScreen(rect.Location, new Point(container.Location.X, container.Location.Y), paper.Size);
            Bitmap.Save(@"C:\Users\hang2\Source\Repos\BoxFit2\Images" + CurrentRow.RowID + ".bmp");
        }

        private void BtnSuggestion_Click(object sender, EventArgs e)
        {
            timeleft = TimeLimit;
            Timer.Start();
            Timer.Interval = 1000;
            Timer.Tick += Timer_Tick;
            container.Controls.Clear();
            if (applyAlgorith.SuggestionBins.Count == 0)
            {
                CalculateSuggestionBins();
            }
            OptimumDrawing(applyAlgorith);
            var areaWasteed = 0;
            lblBoxes.Text += $"\nSuggestions Bins to fill gaps:{applyAlgorith.SuggestionBins.Count}\n";
            foreach (var item in applyAlgorith.SuggestionBins)
            {
                lblBoxes.Text += $"X: {item.X} Y: {item.Y} -- W: {item.Width} H:{item.Height}\n";
                areaWasteed += item.Height * item.Width;
            }
            lblBoxes.Text += $"Total wasted area: {areaWasteed}";
            DrawSuggestionBins();
            this.Refresh();
        }

        private void CalculateSuggestionBins()
        {
            if (applyAlgorith.IsHorizontal)
            {
                applyAlgorith.GetSortedListForPairIndexValue();
                applyAlgorith.MyContainer.Width = applyAlgorith.MaxWidth;
                applyAlgorith.MyContainer.Height = applyAlgorith.MaxHeight;
                FitMyContainerHorizontal();
            }
            else
            {
                applyAlgorith.GetSortedListForPairIndexValue();
                applyAlgorith.MyContainer.Width = applyAlgorith.MaxWidth;
                applyAlgorith.MyContainer.Height = applyAlgorith.MaxHeight;
                FitMyContainerVertical();
            }
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            timeleft -= 1;
            lblTime.Text = "TIME: " + timeleft + " seconds";
            if (timeleft <= 0)
            {
                container.AllowDrop = false;
                container.DragEnter -= Container_DragEnter;
                container.DragDrop -= Container_DragDrop;
                tabPage4.AllowDrop = false;
                tabPage4.DragEnter -= TabPage4_DragEnter;
                tabPage4.DragDrop -= TabPage4_DragDrop;
                Timer.Stop();
                MessageBox.Show("Game Over!");
                ListSuggestionToShow.Clear();
                container.AllowDrop = false;
                lblTime.Text = "TIME: 0";
                timeleft = TimeLimit;
            }
            else if (ListSuggestionToShow.Count == 0 && Score != 0)
            {
                container.AllowDrop = false;
                container.DragEnter -= Container_DragEnter;
                container.DragDrop -= Container_DragDrop;
                tabPage4.AllowDrop = false;
                tabPage4.DragEnter -= TabPage4_DragEnter;
                tabPage4.DragDrop -= TabPage4_DragDrop;
                Timer.Stop();
                MessageBox.Show($"Congrat!! You Won!!!\n Your Score: {Score}");
                lblTime.Text = "TIME: 0";
                timeleft = TimeLimit;
            }
        }

        private void DrawSuggestionBins()
        {
            container.AllowDrop = true;
            container.DragEnter += Container_DragEnter;
            container.DragDrop += Container_DragDrop;
            tabPage4.AllowDrop = true;
            tabPage4.DragEnter += TabPage4_DragEnter;
            tabPage4.DragDrop += TabPage4_DragDrop;
            int x = 10;
            int y = 10;
            tabPage4.Controls.Clear();

            RandomList = GetRandomListOfInterger();
            SuggestionListToShow(x, y);
            ShowNextSuggestionBox();
            //if (applyAlgorith.SuggestionBins.Count > 0)
            //{
            //    panel1.Width = this.Width - container.Width - 200;
            //}
            tabControl1.SelectedIndex = 1;
            this.Refresh();
        }

        private void SuggestionListToShow(int x, int y)
        {
            for (int i = 0; i < applyAlgorith.SuggestionBins.Count; i++)
            {
                int index = RandomList[i];
                var item = applyAlgorith.SuggestionBins[index];
                this.box = new System.Windows.Forms.Button();
                this.box.Location = new System.Drawing.Point(x, y);
                this.box.Size = new System.Drawing.Size(item.Width, item.Height);
                this.box.FlatStyle = FlatStyle.Popup;
                this.box.BackColor = Color.FromArgb(180, 0, 0, 0);
                var toolTip = new System.Windows.Forms.ToolTip();
                toolTip.SetToolTip(box, $"Suggestion Box: X: { item.X} Y: {item.Y} Width: {item.Width} Height {item.Height}");
                this.tabPage4.Controls.Add(this.box);
                this.box.MouseDown += Container_MouseDown;
                this.box.Tag = index;
                this.box.Visible = false;
                ListSuggestionToShow.Add(this.box);
            }
        }

        private void ShowNextSuggestionBox()
        {
            if (ListSuggestionToShow != null && ListSuggestionToShow.Count > 0)
            {
                CurrentSelection = ListSuggestionToShow.FirstOrDefault();
                CurrentSelection.Visible = true;
            }
        }

        private List<int> GetRandomListOfInterger()
        {
            var resultList = new List<int>();
            Random rnd = new Random();
            foreach (var item in applyAlgorith.SuggestionBins)
            {
                var randomNumber = rnd.Next(0, applyAlgorith.SuggestionBins.Count);
                while (resultList.Contains(randomNumber))
                {
                    randomNumber = rnd.Next(0, applyAlgorith.SuggestionBins.Count);
                }
                resultList.Add(randomNumber);
            }
            return resultList;
        }

        private void Container_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Move;
            this.Refresh();
        }

        private void Container_DragDrop(object sender, DragEventArgs e)
        {
            DropIntoContainer(sender, e);
        }

        private void DropIntoContainer(object sender, DragEventArgs e)
        {
            var currentBin = new RectangularBox();
            ((Button)e.Data.GetData(typeof(Button))).Parent = (Panel)sender;
            var button = (Button)e.Data.GetData(typeof(Button));
            currentBin = applyAlgorith.SuggestionBins[(int)button.Tag];
            if ((currentBin.X - 30 <= e.X - container.Location.X && e.X - container.Location.X <= currentBin.X + Width + 70)
                && (currentBin.Y - 30 <= e.Y - container.Location.Y && e.Y - container.Location.Y <= currentBin.Y + currentBin.Height + 70))
            {
                button.SetBounds(currentBin.X, currentBin.Y, currentBin.Width, currentBin.Height);
                ListSuggestionToShow.Remove(button);
                ShowNextSuggestionBox();
                Score += 10;
                lblScore.Text = "SCORE: " + Score;
            }
            else
            {
                container.Controls.Remove(button);
                tabPage4.Controls.Add(button);
            }
            this.Refresh();
        }

        private void Container_MouseDown(object sender, MouseEventArgs e)
        {
            if (sender as Button != null)
            {
                CurrentSelection = (Button)sender;
                CurrentSelection.DoDragDrop(CurrentSelection, DragDropEffects.Move);
            }
            this.Refresh();
        }

        private void TabPage4_DragDrop(object sender, DragEventArgs e)
        {
            ((Button)e.Data.GetData(typeof(Button))).Parent = (Panel)sender;
            var button = (Button)e.Data.GetData(typeof(Button));
            this.Refresh();
        }

        private void TabPage4_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Move;
            this.Refresh();
        }

        private void TabPage4_MouseDown(object sender, MouseEventArgs e)
        {
            this.Refresh();
        }

        private void BtnSuggestionResult_Click(object sender, EventArgs e)
        {
            container.AllowDrop = false;
            container.DragEnter -= Container_DragEnter;
            container.DragDrop -= Container_DragDrop;
            tabPage4.AllowDrop = false;
            tabPage4.DragEnter -= TabPage4_DragEnter;
            tabPage4.DragDrop -= TabPage4_DragDrop;
            Timer.Stop();
            SuggestionButtonList = new List<Button>();
            GetSuggestionBins();
            tabPage4.Controls.Clear();
            tabPage3.Show();
        }

        private void GetSuggestionBins()
        {
            if (applyAlgorith.SuggestionBins.Count == 0)
            {
                CalculateSuggestionBins();
            }
            SuggestionButtonList = new List<Button>();
            foreach (var item in applyAlgorith.SuggestionBins)
            {
                this.box = new System.Windows.Forms.Button();
                this.box.Location = new System.Drawing.Point(item.X, item.Y);
                this.box.Size = new System.Drawing.Size(item.Width, item.Height);
                this.box.FlatStyle = FlatStyle.Popup;
                this.box.BackColor = Color.FromArgb(180, 0, 0, 0);
                var toolTip = new System.Windows.Forms.ToolTip();
                toolTip.SetToolTip(box, $"Suggestion Box: X: { item.X} Y: {item.Y} Width: {item.Width} Height {item.Height}");
                this.container.Controls.Add(this.box);
                this.box.MouseDown += Container_MouseDown;
                this.box.BringToFront();
                this.box.Visible = true;

                SuggestionButtonList.Add(this.box);
            }
        }

        private void BtnDrawInputSizes_Click(object sender, EventArgs e)
        {
            if (InputBoxes.Count > 0)
            {
                read.IsReadFile = false;
                read.SetSizes(InputBoxes);
                Start();
            }
            tabPage1.Show();
            this.Refresh();
        }
        private void Container_Click(object sender, EventArgs e)
        {
            // GetSuggestionBins();
            if (applyAlgorith.SuggestionBins.Count > 0)
            {
                foreach (var item in applyAlgorith.SuggestionBins)
                {
                    if (CurrentSelection != null && CurrentSelection.Tag != null)
                    {
                        var currentBin = applyAlgorith.SuggestionBins[(int)CurrentSelection.Tag];
                        var button = new Button();
                        button.BackColor = Color.FromArgb(190, 125, 125, 250);
                        button.FlatStyle = FlatStyle.Popup;
                        button.SetBounds(currentBin.X, currentBin.Y, currentBin.Width, currentBin.Height);
                        //lblScore.Text = $"Cursor: x: {Cursor.Position.X -container.Location.X} y: {Cursor.Position.Y - container.Location.Y -50} " +
                        //$"Item x: {button.Location.X} y: {button.Location.Y}";
                        if (Cursor.Position.X - container.Location.X > button.Location.X
                            && Cursor.Position.X - container.Location.X < button.Location.X + button.Width
                            && Cursor.Position.Y - container.Location.Y - 50 > button.Location.Y
                            && Cursor.Position.Y - container.Location.Y - 50 < button.Location.Y + button.Height)
                        {
                            ListSuggestionToShow.Remove(CurrentSelection);
                            CurrentSelection.Visible = false;
                            container.Controls.Add(button);
                            ShowNextSuggestionBox();
                            Score = Score + 10;
                            lblScore.Text = $"Score: {Score}";
                        }
                    }
                }
            }
        }

        private void TxtNumber_TextChanged(object sender, EventArgs e)
        {
            if (!txtNumber.Text.All(t => Char.IsDigit(t)))
            {
                errorProvider.SetError(txtNumber, "Please Enter Number Only");
            }
            else
            {
                errorProvider.Clear();
            }
        }

        private void TxtNumber_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Return))
            {
                errorProvider.Clear();
                InputBoxes.Clear();
                var number = int.Parse(txtNumber.Text);
                if (number > 1)
                {
                    var rand = new Random();
                    for (int i = 0; i < number; i++)
                    {
                        InputBoxes.Add(new RectangularBox
                        {
                            Width = rand.Next(1, 3) * rand.Next(1, 4) * 20,
                            Height = rand.Next(1, 3) * rand.Next(1, 4) * 20
                        });
                    }
                }
                else
                {
                    errorProvider.SetError(txtNumber, "Please Enter a number greater than 1.");
                }

            }
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            txtNumber.Visible = true;
            lblNumber.Visible = true;
            InputBoxes.Clear();
        }
    }

}
