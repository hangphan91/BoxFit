using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace boxfittingapp.Model
{
    class InputValuesModel
    {
        public RectangularBox Box { get; set; }
        public int Quantity { get; set; }
        public InputValuesModel()
        {
            Box = new RectangularBox();
        }
    }
}
