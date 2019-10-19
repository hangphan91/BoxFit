using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace boxfittingapp
{
   public class ReadCSVFile
    {
        public Dictionary<int, RectangularBox> BoxListReadOnly { get; set; } = new Dictionary<int, RectangularBox>();
        private Dictionary<int, RectangularBox> BoxList { get; set; } = new Dictionary<int, RectangularBox>();
        public ReadCSVFile()
        {
            using (var reader = new StreamReader(@"C:\Users\hang2\Desktop\fittingboxsamples2.csv"))
            {
                List<int> listA = new List<int>();
                List<int> listB = new List<int>();
                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    var values = line.Split(',');
                    int x, y;

                    if (int.TryParse(values[0], out x) && int.TryParse(values[1], out y))
                    {
                        listA.Add(x*3);
                        listB.Add(y*3);
                    }
                }
                for (int i = 0; i < listA.Count; i++)
                {
                    BoxList.Add(i, new RectangularBox { X= listA[i], Y= listB[i] });
                }
            }
            BoxListReadOnly = BoxList;
        }
    }
}
