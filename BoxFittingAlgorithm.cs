using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace boxfittingapp
{
    public class BoxFittingAlgorithm
    {
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
        public Dictionary<int, RectangularBox> OptimizedBoxList { get; set; }
        public List<RectangularBox> BinList { get; set; }
        public List<RectangularBox> Bins { get; set; }
        public List<Point> ResultListCoordinates { get; set; }
        public Dictionary<int, RectangularBox> BoxList { get; set; }
        public List<List<int>> PairIndexValueList { get; set; }
        public string MyResult { get; set; }
        public int WastedArea { get; set; }
        public int UsedArea { get; set; }
        public int TotalArea { get; set; }
        public int MaxHeight { get; set; }

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
            CurrentContainer = new RectangularBox { X = 0, Y = 0, Width =408, Height = int.MaxValue };
            ContainerWidth = CurrentContainer.Width;
            BoxList = new Dictionary<int, RectangularBox>();
            OptimizedBoxList = new Dictionary<int, RectangularBox>();
            BinList = new List<RectangularBox>();
            Bins = new List<RectangularBox>();
            ResultListCoordinates = new List<Point>();
            TempBins = new List<RectangularBox>();
        }
        public void GetOptimizationListOrder(Dictionary<int, RectangularBox> BoxList)
        {
            this.BoxList = BoxList;
            PairIndexValueList = new List<List<int>>();
            GetSortedListForPairIndexValue(PairIndexValueList);
            PerformHorizontalBoxFittingAlgorithm();
           // PerFormVerticalBoxFittingAlgorith();
            BinList.Sort(new RectangularBoxHeightComparer());
            MyResult = "";
            int i = 0;
            foreach (var item in BinList)
            {
                MyResult += $"{i} X:{item.X} Y: {item.Y} W: {item.Width} H: {item.Height}\n";
                i++;
                UsedArea += item.Height * item.Width;
            }
            
            MyResult += "Used Area: " + UsedArea.ToString();
            MaxHeight = BinList.LastOrDefault().Y + BinList.LastOrDefault().Height;
            TotalArea = ContainerWidth * MaxHeight;
            WastedArea = TotalArea - UsedArea;
            MyResult += "\nTotal Area: " + TotalArea.ToString();
            MyResult += "\nWasted Area: " + (WastedArea).ToString();
            MyResult += "\nWasted percent: " +  (double)WastedArea*100/TotalArea + " %";
            MyResult += "\nUsed percent: " + (double)UsedArea*100/TotalArea + " %";


        }

        private void PerFormVerticalBoxFittingAlgorith()
        {

            while (PairIndexValueList.Count > 0 || WastedGaps.Count == BoxList.Count * 2)
            {
                if (SelectBin())
                {
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
                        if (TempBins.Count>0)
                        {
                            if (TempBins.All(t=>t.Y == MaxHeight))
                            {
                                MaxHeight += TempBins[0].Height;
                            }
                        }
                        CurrentContainer.Height = MaxHeight;
                        Gaps1.Clear();
                    }
                    Gaps2.Sort(new RectangularBoxComparerHorizontal());
                    foreach (var item in Gaps2.ToList())
                    {
                        CurrentContainer = item;
                        Gaps2.Remove(item);
                        PerFormVerticalBoxFittingAlgorith();
                    }
                    Gaps2.Clear();

                    TempBins.Clear();
                }
            }

        }

        private void PerformHorizontalBoxFittingAlgorithm()
        {
            while (PairIndexValueList.Count>0|| WastedGaps.Count == BoxList.Count*2)
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
        }

        private bool SelectBin()
        {
            var hasBin = false;
            foreach (var item in PairIndexValueList)
            {
                var width = item[1];
                var matchitem = PairIndexValueList.Find(t => t[0] == item[0] && PairIndexValueList.IndexOf(item)!= PairIndexValueList.IndexOf(t));
                var height = matchitem[1];

                if (width <= CurrentContainer.Width && height <= CurrentContainer.Height)
                {
                    CurrentPair1 = item;
                    CurrentPair2 = matchitem;
                    //PreviuosBin = new RectangularBox {X = CurrentBin.X, Y = CurrentBin.Y, Width = CurrentBin.Width, Height = CurrentBin.Height};
                    CurrentBin = new RectangularBox { X = CurrentContainer.X, Y = CurrentContainer.Y, Width = width, Height = height };
                    hasBin = true;
                    return hasBin;
                }
                else if (height <= CurrentContainer.Width && width <= CurrentContainer.Height)
                {
                    CurrentPair1 = item;
                    CurrentPair2 = matchitem;
                   // PreviuosBin = new RectangularBox { X = CurrentBin.X, Y = CurrentBin.Y, Width = CurrentBin.Width, Height = CurrentBin.Height };
                    CurrentBin = new RectangularBox { X = CurrentContainer.X, Y = CurrentContainer.Y, Width = height, Height = width };
                    hasBin = true;
                    return hasBin;
                }
                else
                {
                    hasBin = false;
                }
            }
            return hasBin;
        }

        private void GetSortedListForPairIndexValue(List<List<int>> PairIndexValueList)
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
