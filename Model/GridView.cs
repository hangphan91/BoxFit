using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace boxfittingapp.Model
{
   public class GridView
    {
        public int RowID { get; set; }
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
        public RectangularBox UserContainer { get; set; }
        public string ContainerWidthAndHeight { get; set; }
        public int UserContainerWidth { get; set; }
        public int UserContainerHeight { get; set; }
        public Dictionary<int, RectangularBox> OptimizedBoxList { get; set; }
        public List<RectangularBox> SuggestionBins { get; set; }
        public string Suggestions { get; set; }
        public List<RectangularBox> BinList { get; set; }
        public String ArrangedBins { get; set; }
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
        public float UsedPercent { get; set; }
        public float WastedPercent { get; set; }
        public bool IsMultipleContainers { get; private set; }
        public int NumberOfMyContainerUsed { get; set; }
        public List<int> ContainerNumbers { get; set; }
        public Bitmap Image { get; set; }
    }
}
