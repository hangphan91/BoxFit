using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace boxfittingapp
{
    public class BoxFittingAlgorithm
    {
        #region Properties
        public int ContainerWidth { get; set; }
        public RectangularBox CurrentBin { get; set; }
        public RectangularBox PreviuosBin { get; set; }
        public List<int> CurrentPair1 { get; private set; }
        public List<int> CurrentPair2 { get; private set; }
        public RectangularBox CurrentGap1 { get; set; }
        public RectangularBox CurrentGap2 { get; set; }
        public List<RectangularBox> Gaps { get; set; }
        public List<RectangularBox> Gaps1 { get; set; }
        public List<RectangularBox> Gaps2 { get; set; }
        public List<RectangularBox> TempBins { get; set; }
        public List<RectangularBox> LayerHeights { get; set; }
        public List<RectangularBox> WastedGaps { get; set; }
        public RectangularBox CurrentContainer { get; set; }
        public RectangularBox PreviousContainer { get; set; }
        public RectangularBox MyContainer { get; set; }
        public Dictionary<int, RectangularBox> OptimizedBoxList { get; set; }
        public List<RectangularBox> BinList { get; set; }
        public List<RectangularBox> Bins { get; set; }
        public List<Point> ResultListCoordinates { get; set; }
        public Dictionary<int, RectangularBox> BoxList { get; set; }
        public List<List<int>> PairIndexValueList { get; set; }
        public List<RectangularBox> FitInBins { get; set; }
        public string MyResult { get; set; }
        public int WastedArea { get; set; }
        public int UsedArea { get; set; }
        public int TotalArea { get; set; }
        public int MaxHeight { get; set; }
        public int MaxWidth { get; set; }
        public bool IsHorizontal { get; set; }
        public string DisplayResult { get; set; }
        public bool HasResult { get; set; }
        public int InputHeight { get; set; }
        public int InputWidth { get; set; }
        public bool IsMultipleContainers { get; private set; }
        public int NumberOfMyContainerUsed { get; set; }
        public List<int> ContainerNumbers { get; set; }
        #endregion
        public BoxFittingAlgorithm()
        {
            CurrentBin = new RectangularBox();
            CurrentGap1 = new RectangularBox();
            CurrentGap2 = new RectangularBox();
            Gaps = new List<RectangularBox>();
            Gaps1 = new List<RectangularBox>();
            Gaps2 = new List<RectangularBox>();
            WastedGaps = new List<RectangularBox>();
            LayerHeights = new List<RectangularBox>();
            CurrentContainer = new RectangularBox { X = 0, Y = 0, Width = 408, Height = int.MaxValue };
            PreviousContainer = new RectangularBox();
            BoxList = new Dictionary<int, RectangularBox>();
            OptimizedBoxList = new Dictionary<int, RectangularBox>();
            BinList = new List<RectangularBox>();
            Bins = new List<RectangularBox>();
            ResultListCoordinates = new List<Point>();
            TempBins = new List<RectangularBox>();
            MyContainer = new RectangularBox();
            FitInBins = new List<RectangularBox>();
            ContainerNumbers = new List<int>();
            HasResult = true;
            IsMultipleContainers = false;
            NumberOfMyContainerUsed = 0;
        }
        public void GetOptimizationListOrder(Dictionary<int, RectangularBox> BoxList)
        {
            try
            {
                this.BoxList = BoxList;
                PairIndexValueList = new List<List<int>>();
                GetSortedListForPairIndexValue();
                MyContainer.Width = PairIndexValueList[0][1];
                MyContainer.Height = PairIndexValueList[1][1];

                if (IsHorizontal)
                {
                    var task = Task.Run(() => PerformHorizontalBoxFittingAlgorithm());
                    task.Wait();
                }
                else
                {
                    var task = Task.Run(() => PerFormVerticalBoxFittingAlgorith());
                    task.Wait();
                }
                MyResult = "";
                int i = 0;
                MaxWidth = 0;
                foreach (var item in BinList)
                {
                    UsedArea += item.Height * item.Width;
                    if (item.X + item.Width > MaxWidth)
                    {
                        MaxWidth = item.X + item.Width;
                    }
                    if (item.Y + item.Height > MaxHeight)
                    {
                        MaxHeight = item.Y + item.Height;
                    }
                }
                if (HasResult)
                {
                    DisplayResults();
                }
            }
            catch (Exception ex)
            {
                HasResult = false;
                PairIndexValueList.Clear();
                MessageBox.Show("SIZE OF YOUR BIN IS TOO SMALL!!!!");

                BinList.Clear();
            }

        }

        public void DisplayResults()
        {
            int i = 1;
            foreach (var item in Bins)
            {
                MyResult += $"Container#: {ContainerNumbers[i-1]} Box {i}@ X: {item.X} - Y: {item.Y} - W: {item.Width} - H: {item.Height} \n";
                i++;
            }
            MyResult += "Used Area: " + UsedArea.ToString();
            TotalArea = MaxWidth * MaxHeight;
            WastedArea = TotalArea - UsedArea;
            MyResult += "\nTotal Area: " + TotalArea.ToString();
            MyResult += "\nWasted Area: " + (WastedArea).ToString();
            MyResult += "\nWasted percent: " + (double)WastedArea * 100 / TotalArea + " %";
            MyResult += "\nUsed percent: " + (double)UsedArea * 100 / TotalArea + " %";
            MyResult += "\nTotal Bins: " + BinList.Count.ToString();
            MyResult += "\nNumber of Containers: " + (NumberOfMyContainerUsed == 0 ? 1 : NumberOfMyContainerUsed);
        }

        internal void SetMultipleContainers(bool @checked)
        {
            this.IsMultipleContainers = @checked;
        }

        internal void SetAlgorithm(bool isHorizontal)
        {
            this.IsHorizontal = isHorizontal;
        }

        internal void SetContainerHeight(int maxheight)
        {
            CurrentContainer.Height = maxheight;
            MaxWidth = CurrentContainer.Width;
            InputHeight = maxheight;
        }

        internal void SetContainerWidth(int maxwidth)
        {
            CurrentContainer.Width = maxwidth;
            MaxWidth = CurrentContainer.Width;
            InputWidth = maxwidth;
        }

        private void PerFormVerticalBoxFittingAlgorith()
        {
            while (PairIndexValueList.Count > 0 && HasResult)
            {
                PreviousContainer = new RectangularBox { X = CurrentContainer.X, Y = CurrentContainer.Y, Width = CurrentContainer.Width, Height = CurrentContainer.Height };
                if (SelectBin())
                {
                    HasResult = true;
                    CurrentGap1 = new RectangularBox { X = CurrentContainer.X + CurrentBin.Width, Y = CurrentContainer.Y, Width = CurrentContainer.Width - CurrentBin.Width, Height = CurrentContainer.Height };
                    CurrentGap2 = new RectangularBox { X = CurrentContainer.X, Y = CurrentContainer.Y + CurrentBin.Height, Width = CurrentBin.Width, Height = CurrentContainer.Height - CurrentBin.Height };
                    Gaps1.Add(CurrentGap1);
                    Gaps2.Add(CurrentGap2);
                    CurrentContainer = CurrentGap1;
                    RemoveBinFromListThenAddtoResultList();
                    BinList.Add(CurrentBin);
                    Gaps.Add(CurrentGap1);
                    Gaps.Add(CurrentGap2);
                    TempBins.Add(CurrentBin);

                }
                else
                {
                    var lastgap2 = new RectangularBox();
                    if (!WastedGaps.Contains(CurrentContainer))
                    {
                        WastedGaps.Add(CurrentContainer);
                        Gaps1.Clear();
                    }
                    Gaps2.Reverse();
                    foreach (var item in Gaps2.ToList())
                    {
                        CurrentContainer = item;
                        Gaps2.Remove(item);
                        PerFormVerticalBoxFittingAlgorith();
                    }
                    Gaps2.Clear();

                    if (Gaps2.Count == 0 && Gaps1.Count == 0 && BinList.Count > 0)
                    {
                        var maxH = 0;
                        foreach (var item in BinList)
                        {
                            if (item.Y + item.Height > maxH)
                            {
                                maxH = item.Y + item.Height;
                            }
                        }

                        if (InputHeight > maxH)
                        {
                            CurrentContainer = new RectangularBox { X = 0, Y = maxH, Height = InputHeight - maxH, Width = MaxWidth };

                            if (Gaps2.Count == 0 && Gaps1.Count == 0 && CurrentContainer.Compare(PreviousContainer))
                            {
                                CurrentContainer = new RectangularBox { X = 0, Y = maxH, Height = 0, Width = 0 };
                                BinList.Clear();
                                PairIndexValueList.Clear();
                                HasResult = false;
                                break;
                            }
                            PerFormVerticalBoxFittingAlgorith();
                        }
                        else if (PairIndexValueList.Count > 0)
                        {
                            BinList.Clear();
                            PairIndexValueList.Clear();
                            HasResult = false;
                            break;
                        }
                    }
                    else
                    {
                        HasResult = true;
                        break;
                    }
                }
            }

        }

        internal void FitMyContainerVertical()
        {
            try
            {
                while (!ShouldStop())
                {
                    if (SelectBin())
                    {
                        CurrentGap1 = new RectangularBox { X = CurrentContainer.X + CurrentBin.Width, Y = CurrentContainer.Y, Width = CurrentContainer.Width - CurrentBin.Width, Height = CurrentContainer.Height };
                        CurrentGap2 = new RectangularBox { X = CurrentContainer.X, Y = CurrentContainer.Y + CurrentBin.Height, Width = CurrentBin.Width, Height = CurrentContainer.Height - CurrentBin.Height };

                        Gaps1.Add(CurrentGap1);
                        Gaps2.Add(CurrentGap2);
                        CurrentContainer = CurrentGap1;
                        RemoveBinFromListThenAddtoResultList();
                        FitInBins.Add(CurrentBin);
                        Gaps.Add(CurrentGap1);
                        Gaps.Add(CurrentGap2);
                    }
                    else
                    {
                        var lastgap2 = new RectangularBox();
                        if (!WastedGaps.Contains(CurrentContainer))
                        {
                            WastedGaps.Add(CurrentContainer);
                            Gaps1.Clear();
                        }
                        Gaps2.Reverse();
                        foreach (var item in Gaps2.ToList())
                        {
                            CurrentContainer = item;
                            Gaps2.Remove(item);
                            FitMyContainerVertical();
                        }
                        Gaps2.Clear();
                    }
                    if (PairIndexValueList.Count == 0 & Gaps1.Count == 0 && Gaps2.Count == 0)
                    {
                        return;
                    }
                }
            }
            catch (Exception EX)
            {
                MessageBox.Show("SIZE OF YOUR BIN IS TOO SMALL!!!!");
            }
        }

        internal void FitMyContainerHorizontal()
        {
            try
            {
                while (!ShouldStop())
                {
                    if (SelectBin())
                    {
                        CurrentGap1 = new RectangularBox { X = CurrentContainer.X + CurrentBin.Width, Y = CurrentContainer.Y, Width = CurrentContainer.Width - CurrentBin.Width, Height = CurrentBin.Height };
                        CurrentGap2 = new RectangularBox { X = CurrentContainer.X, Y = CurrentContainer.Y + CurrentBin.Height, Width = CurrentContainer.Width, Height = CurrentContainer.Height - CurrentBin.Height };
                        Gaps1.Add(CurrentGap1);
                        Gaps2.Add(CurrentGap2);
                        CurrentContainer = CurrentGap1;
                        RemoveBinFromListThenAddtoResultList();
                        FitInBins.Add(CurrentBin);
                        Gaps.Add(CurrentGap1);
                        Gaps.Add(CurrentGap2);
                    }
                    else
                    {
                        var lastgap2 = new RectangularBox();
                        if (!WastedGaps.Contains(CurrentContainer))
                        {
                            WastedGaps.Add(CurrentContainer);
                            Gaps1.Clear();
                        }
                        Gaps2.Sort(new RectangularBoxComparerHorizontal());
                        foreach (var item in Gaps2.ToList())
                        {
                            CurrentContainer = item;
                            Gaps2.Remove(item);
                            FitMyContainerHorizontal();
                        }
                        Gaps2.Clear();
                    }
                    if (PairIndexValueList.Count == 0 & Gaps1.Count == 0 && Gaps2.Count == 0)
                    {
                        return;
                    }
                }
            }
            catch (Exception EX)
            {
                MessageBox.Show("SIZE OF YOUR BIN IS TOO SMALL!!!!");
            }

        }

        public bool ShouldStop()
        {
            bool result = false;
            try
            {
                var MyContainerArea = MyContainer.Width * MyContainer.Height;
                var WastedArea = WastedGaps.Count > 0 ? WastedGaps.Sum(t => t.Height * t.Width) : 0;
                var AllFitInBinArea = FitInBins.Sum(t => t.Width * t.Height);

                if (MyContainerArea == AllFitInBinArea + WastedArea && WastedGaps.Count > 0 && WastedArea != MyContainerArea)
                {
                    NumberOfMyContainerUsed++;
                    WastedGaps.Clear();
                    CurrentContainer = MyContainer;
                    CurrentContainer.Y = CurrentContainer.Height * (NumberOfMyContainerUsed);

                    FitInBins.Clear();
                    while (PairIndexValueList.Count > 0)
                    {
                        if (IsHorizontal)
                        {
                            FitMyContainerHorizontal();
                        }
                        else
                        {
                            FitMyContainerVertical();
                        }
                    }
                    result = true;
                }
                if (AllFitInBinArea == 0 && !SelectBin() && WastedArea == 0)
                {
                    if (PairIndexValueList.Count > 0)
                    {
                        PairIndexValueList.Clear();
                        BinList.Clear();
                        Bins.Clear();
                        MessageBox.Show("SIZE OF YOUR BIN IS TOO SMALL!!!!");
                        return true;
                    }
                }
            }
            catch (Exception EX)
            {
                MessageBox.Show("SIZE OF YOUR BIN IS TOO SMALL!!!!");
            }
            return result;
        }

        private void PerformHorizontalBoxFittingAlgorithm()
        {
            while (PairIndexValueList.Count > 0 && HasResult)
            {
                if (SelectBin())
                {
                    CurrentGap1 = new RectangularBox { X = CurrentContainer.X + CurrentBin.Width, Y = CurrentContainer.Y, Width = CurrentContainer.Width - CurrentBin.Width, Height = CurrentBin.Height };
                    CurrentGap2 = new RectangularBox { X = CurrentContainer.X, Y = CurrentContainer.Y + CurrentBin.Height, Width = CurrentContainer.Width, Height = CurrentContainer.Height - CurrentBin.Height };
                    Gaps1.Add(CurrentGap1);
                    Gaps2.Add(CurrentGap2);
                    CurrentContainer = CurrentGap1;
                    RemoveBinFromListThenAddtoResultList();
                    BinList.Add(CurrentBin);
                    Gaps.Add(CurrentGap1);
                    Gaps.Add(CurrentGap2);
                }
                else
                {
                    if (Gaps2.Count == 0 && Gaps1.Count == 0)
                    {
                        PairIndexValueList.Clear();
                        MessageBox.Show("SIZE OF YOUR BIN IS TOO SMALL!!!!");
                        HasResult = false;
                        BinList.Clear();
                        return;
                    }
                    var lastgap2 = new RectangularBox();
                    if (!WastedGaps.Contains(CurrentContainer))
                    {
                        WastedGaps.Add(CurrentContainer);
                        Gaps1.Clear();
                    }
                    Gaps2.Sort(new RectangularBoxComparerHorizontal());
                    foreach (var item in Gaps2.ToList())
                    {
                        CurrentContainer = item;
                        Gaps2.Remove(item);
                        PerformHorizontalBoxFittingAlgorithm();
                    }
                    Gaps2.Clear();
                }
            }
        }
        private void RemoveBinFromListThenAddtoResultList()
        {
            PairIndexValueList.Remove(CurrentPair1);
            PairIndexValueList.Remove(CurrentPair2);
            Bins.Add(CurrentBin);
            ContainerNumbers.Add(NumberOfMyContainerUsed + 1);
        }

        private bool SelectBin()
        {
            var hasBin = false;
            try
            {
                int numOfPair = PairIndexValueList.Count;
                foreach (var item in PairIndexValueList)
                {
                    numOfPair--;
                    var width = item[1];
                    var matchitem = PairIndexValueList.Find(t => t[0] == item[0] && PairIndexValueList.IndexOf(item) != PairIndexValueList.IndexOf(t));
                    var height = matchitem[1];

                    if (width <= CurrentContainer.Width && height <= CurrentContainer.Height)
                    {
                        CurrentPair1 = item;
                        CurrentPair2 = matchitem;
                        CurrentBin = new RectangularBox { X = CurrentContainer.X, Y = CurrentContainer.Y, Width = width, Height = height };
                        hasBin = true;
                        return hasBin;
                    }
                    else if (height <= CurrentContainer.Width && width <= CurrentContainer.Height)
                    {
                        CurrentPair1 = item;
                        CurrentPair2 = matchitem;
                        CurrentBin = new RectangularBox { X = CurrentContainer.X, Y = CurrentContainer.Y, Width = height, Height = width };
                        hasBin = true;
                        return hasBin;
                    }
                    else
                    {
                        hasBin = false;
                    }
                }
            }
            catch (Exception EX)
            {
                MessageBox.Show("SIZE OF YOUR BIN IS TOO SMALL!!!!");
            }
            return hasBin;
        }

        public void GetSortedListForPairIndexValue()
        {

            OptimizedBoxList = new Dictionary<int, RectangularBox>(BoxList);
            OptimizedBoxList = BoxList;
            foreach (var item in BoxList)
            {
                PairIndexValueList.Add(new List<int> { item.Key, item.Value.X });
                PairIndexValueList.Add(new List<int> { item.Key, item.Value.Y });
            }
            Console.WriteLine("sorted List: ");

            PairIndexValueList.Sort(new PairIndexValueComparer());

            foreach (var item in PairIndexValueList)
            {
                MyResult += item[0] + " " + item[1] + ",";
            }
        }
    }
}
