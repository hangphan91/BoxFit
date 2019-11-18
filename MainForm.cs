using boxfittingapp.Model;
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
        #region properties

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
        public GridView CurrentRow { get; set; }
        public BindingList<GridView> Rows { get; set; }
        public Bitmap Bitmap { get; private set; }
        #endregion
        public MainForm()
        {
            InitializeComponent();
            Points = new List<RectangularBox>();
            MaxLine = new List<Point>();
            read = new ReadCSVFile();
            MyContainer = new RectangularBox();
            BiggiestBin = new RectangularBox();
            Tasks = new List<Task>();
            CurrentRow = new GridView();
            Rows = new BindingList<GridView>();
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
                this.box.BackColor = Color.FromArgb(180, (item.Height * 2) % 255, (item.Height * 6) % 255, (item.Width * 2) % 255);
                var toolTip = new System.Windows.Forms.ToolTip();
                toolTip.SetToolTip(box, $"Container# {applyAlgorith.ContainerNumbers[index]} X: { item.X} Y: {item.Y} Width: {item.Width} Height {item.Height}");
                this.container.Controls.Add(this.box);
                index++;
            }
            DrawBorders(applyAlgorith);
            DrawBarrierForEachContainer(applyAlgorith);
            container.Size = new Size(applyAlgorith.MaxWidth, applyAlgorith.MaxHeight);
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
            applyAlgorith.ContainerNumbers.Clear();
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
        }

        private void SavetoGrid()
        {
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
            Bitmap = new Bitmap(this.Width, this.Height);
            Graphics graphics = Graphics.FromImage(Bitmap);
            Rectangle rect = container.RectangleToScreen(container.ClientRectangle);
            graphics.CopyFromScreen(rect.Location, new Point(container.Location.X, container.Location.Y), paper.Size);
            Bitmap.Save(@"C:\Users\hang2\Source\Repos\BoxFit2\Images\container"+CurrentRow.RowID+".bmp");
            System.Diagnostics.Process.Start(@"C:\Users\hang2\Source\Repos\BoxFit2\Images\container" +CurrentRow.RowID+".bmp");
        }
    }

}
