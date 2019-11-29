using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace boxfittingapp
{
    public class RectangularBox
    {
        public int TagID { get; set; }
        public int X { get; set; }
        public int Y { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public int Quantity { get; set; }
        public int ContainerNumber { get; set; }
        public int XWithinContainer { get; set; }
        public int YWithinContainer { get; set; }
        public int Buffer { get; set; }

        public RectangularBox()
        {
            X = 0;
            Y = 0;
            Width = 0;
            Height = 0;
            Buffer = 0;
        }

        internal bool Compare(RectangularBox C)
        {
            return this.X == C.X && this.Y == C.Y && this.Width == C.Width && this.Height == C.Height;
        }
    }
    public class PairIndexValueComparer : IComparer<List<int>>
    {
        public int Compare(List<int> x, List<int> y)
        {
            return y[1].CompareTo(x[1]);
        }
    }
    public class AreaComparer : IComparer<RectangularBox>
    {
        public int Compare(RectangularBox x, RectangularBox y)
        {
            return (y.Width * y.Height).CompareTo(x.Width * x.Height);
        }
    }
    public class MaxSideComparer : IComparer<RectangularBox>
    {
        public int Compare(RectangularBox x, RectangularBox y)
        {
            return (Math.Max(y.Width , y.Height).CompareTo(Math.Max(x.Width , x.Height)));
        }
    }
    public class PerimeterComparer : IComparer<RectangularBox>
    {
        public int Compare(RectangularBox x, RectangularBox y)
        {
            return (y.Width + y.Height).CompareTo(x.Width + x.Height);
        }
    }
    public class PairIndexValueComparerByKey : IComparer<List<int>>
    {
        public int Compare(List<int> x, List<int> y)
        {
            return y[0].CompareTo(x[0]);
        }
    }
    public class RectangularBoxComparerHorizontal : IComparer<RectangularBox>
    {
        public int Compare(RectangularBox x, RectangularBox y)
        {
            return y.X.CompareTo(x.X);
        }
    }
    public class RectangularBoxComparerVertical : IComparer<RectangularBox>
    {
        public int Compare(RectangularBox x, RectangularBox y)
        {
            return y.Y.CompareTo(x.Y);
        }
    }
    public class RectangularBoxHeightComparer : IComparer<RectangularBox>
    {
        public int Compare(RectangularBox x, RectangularBox y)
        {
            return (x.Y + x.Height).CompareTo(y.Y + y.Height);
        }
    }
}

