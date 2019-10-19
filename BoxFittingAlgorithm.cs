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
        public int ContainerWidth { get { return 600; } }
        public int CurrentWidth { get; set; }
        public int CurrentHeight { get; set; }
        public int CurrentBinIndex { get; set; }
        public int CursorX { get; set; }
        public int CursorY { get; set; }
        public int MaxY { get; set; }
        public int MaxX { get; set; }
        public int MinX { get; set; }
        public int MinY { get; set; }
        public RectangularBox CurrentBin { get; set; }
        public RectangularBox PreviuosBin { get; set; }
        public List<int> CurrentPair1 { get; private set; }
        public List<int> CurrentPair2 { get; private set; }
        public RectangularBox Gap { get; set; }
        public List<RectangularBox> Wasted { get; set; }
        public RectangularBox CurrentContainer { get; set; }
        public Dictionary<int, RectangularBox> OptimizedBoxList { get; set; }
        public List<RectangularBox> ResultList { get; set; }
        public List<Point> CursorPoints { get; set; }
        public List<Point> ResultListCoordinates { get; set; }
        public Dictionary<int, RectangularBox> BoxList { get; set; }
        public List<List<int>> PairIndexValueList { get; set; }
        public string MyResult { get; set; }

        public BoxFittingAlgorithm()
        {
            CurrentBin = new RectangularBox();
            Gap = new RectangularBox();
            Wasted = new List<RectangularBox>();
            CurrentContainer = new RectangularBox();
            BoxList = new Dictionary<int, RectangularBox>();
            OptimizedBoxList = new Dictionary<int, RectangularBox>();
            ResultList = new List<RectangularBox>();
            ResultListCoordinates = new List<Point>();
            CursorPoints = new List<Point>();
        }
        public void GetOptimizationListOrder(Dictionary<int, RectangularBox> BoxList)
        {
            this.BoxList = BoxList;

            PerformAlgorithm();
        }

        private void PerformAlgorithm()
        {
            PairIndexValueList = new List<List<int>>();
            GetSortedListForPairIndexValue(PairIndexValueList);
            ResetGap();
            var isFinish = false;
            while (!isFinish)
            {
                var hasBin = SelectBin(PairIndexValueList);
                if (hasBin)
                {
                    var hasNewline = SetNewLine();
                    AddBinToGraph(hasNewline);
                    DefineCursorPoint(hasNewline);
                }
                else
                {
                    CalculateWastedArea();
                }
                if (PairIndexValueList.Count == 0)
                {
                    isFinish = true;
                    MyResult = "";
                    int count = 0;
                    foreach (var item in ResultList)
                    {
                        MyResult += "D: " + item.X + " -" + item.Y + " \n" + " X: " + ResultListCoordinates[count].X + " Y: " + ResultListCoordinates[count].Y +"\n ";
                        count++;
                    }
                }
                else if (!hasBin)
                {
                    ResetGap();
                }
                
            }
            if (isFinish)
            {
                BoxList = new Dictionary<int, RectangularBox>();
                for (int i = 0; i < ResultList.Count; i++)
                {
                    BoxList.Add(i, ResultList[i]);
                }
                OptimizedBoxList = BoxList;
            }

        }

        private void CaculateGap(bool hasNewline)
        {
            if (hasNewline)
            {
                ResetGap();
            }
            else
            {
                Gap = new RectangularBox { X = ContainerWidth - CursorX, Y = CurrentHeight - CursorY };

                if (Gap.X == 0 && Gap.Y == 0)
                {
                    ResetGap();

                }
            }
        }

        private void DefineCursorPoint(bool hasNewline)
        {
            if (MinX + CurrentBin.X <= Gap.X && MinY + CurrentBin.Y <= Gap.Y)
            {
                CursorX = MinX + CurrentBin.X;
                MinX = Math.Min(CursorX, MinX);
                MinY = Math.Min(CursorY, MinY);
                CaculateGap(hasNewline);
                if (CursorX + CurrentBin.X <= Gap.X && CursorY + CurrentBin.Y <= Gap.Y && !hasNewline)
                {
                    CurrentHeight = CurrentHeight;
                    CaculateGap(hasNewline);
                }
            }
            else
            {
                CursorX += CurrentBin.X;
                //CursorY += CurrentBin.Y;
                MinX = CursorX;
                MinY = CursorY;
            }
        }

        private void CalculateWastedArea()
        {
            Wasted.Add(new RectangularBox { X = Gap.X, Y = Gap.Y });
            Gap = new RectangularBox { X = ContainerWidth - MinX, Y = MaxY - CurrentHeight };
        }

        private void ResetGap()
        {
            Gap = new RectangularBox { X = ContainerWidth, Y = int.MaxValue };
            CursorX = 0;
            CursorY = MaxY;
            CurrentHeight = MaxY;
        }

        private void AddBinToGraph(bool hasNewLine)
        {
            RemoveBinFromListThenAddRoResultList();
            CursorPoints.Add(new Point { X = CursorX, Y = CursorY });
        }

        private void RemoveBinFromListThenAddRoResultList()
        {
            PairIndexValueList.Remove(CurrentPair1);
            PairIndexValueList.Remove(CurrentPair2);
            ResultList.Add(CurrentBin);
            ResultListCoordinates.Add(new Point(CursorX, CursorY));
        }

        private bool SetNewLine()
        {
            if (CurrentWidth >= ContainerWidth)
            {
                CursorX = 0;
                CursorY = MaxY;
                CurrentWidth = 0;
                CurrentHeight = MaxY + CurrentBin.Y;
                MaxX = Math.Max(CurrentWidth, MaxX);
                MaxY = Math.Max(CurrentHeight, MaxY);
                MinX = 0;
                MinY = MaxY;
                return true;
            }
            else
            {
                CurrentWidth += CurrentBin.X;
                CurrentHeight += CurrentBin.Y - PreviuosBin.Y;
                MaxY = Math.Max(MaxY, CurrentHeight);
                MaxX = Math.Max(MaxX, CurrentWidth);
                return false;
            }
        }

        private bool SelectBin(List<List<int>> pairIndexValueList)
        {
            int i = 0;
            while (pairIndexValueList.Count > 0 && i < pairIndexValueList.Count)
            {
                var width = pairIndexValueList[i][1];
                var index = pairIndexValueList[i][0];
                var heights = pairIndexValueList.Where(t => t[0] == index && pairIndexValueList.IndexOf(t) != pairIndexValueList.IndexOf(pairIndexValueList[i])).ToList();
                if (heights.Count > 0)
                {
                    var height = heights[0][1];
                    //width = Math.Max(width, height);
                    //height = Math.Min(width, height);
                    if (width <= Gap.X && height <= Gap.Y)
                    {
                        CurrentPair1 = pairIndexValueList[i];
                        index = pairIndexValueList.IndexOf(CurrentPair1);
                        var CurrentPair2s = pairIndexValueList.Where(t => t[0] == CurrentPair1[0] && pairIndexValueList.IndexOf(t) != index).ToList();
                        if (CurrentPair2s.Count > 0)
                        {
                            CurrentPair2 = CurrentPair2s[0];
                        }
                        //width = Math.Max(CurrentPair1[1], CurrentPair2[1]);
                        //height = Math.Min(CurrentPair1[1], CurrentPair2[1]);
                        PreviuosBin = new RectangularBox { X = CurrentBin.X, Y = CurrentBin.Y };
                        CurrentBin = new RectangularBox { X = width, Y = height };

                        return true;
                    }
                    else if (height <= Gap.X && width <= Gap.Y)
                    {
                        CurrentPair1 = pairIndexValueList[i];
                        index = pairIndexValueList.IndexOf(CurrentPair1);
                        var CurrentPair2s = pairIndexValueList.Where(t => t[0] == CurrentPair1[0] && pairIndexValueList.IndexOf(t) != index).ToList();
                        if (CurrentPair2s.Count > 0)
                        {
                            CurrentPair2 = CurrentPair2s[0];
                        }
                        var temp = width;
                        width = height;
                        height = temp;
                        PreviuosBin = new RectangularBox { X = CurrentBin.X, Y = CurrentBin.Y };
                        CurrentBin = new RectangularBox { X = width, Y = height };

                        return true;
                    }
                    i++;
                }
                else return false;
            }
            return false;
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
