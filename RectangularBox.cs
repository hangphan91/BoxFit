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
        public int X { get; set; }
        public int Y { get; set; }
        public RectangularBox()
        {
            X = 0;
            Y = 0;
        }
    }
    public class PairIndexValueComparer : IComparer<List<int>>
    {
        public int Compare(List<int> x, List<int> y)
        {
            return y[1].CompareTo(x[1]);
        }
    }
}

