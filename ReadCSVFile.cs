using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace boxfittingapp
{
    public class ReadInputSizes
    {
        public Dictionary<int, RectangularBox> BoxListReadOnly { get; set; } = new Dictionary<int, RectangularBox>();
        private Dictionary<int, RectangularBox> BoxList { get; set; } = new Dictionary<int, RectangularBox>();
        public bool IsReadFile { get; set; } = true;
        public List<int> listA { get; set; }
        public List<int> listB { get; set; }
        public int BufferWidth { get; private set; }

        public ReadInputSizes()
        {
            listA = new List<int>();
            listB = new List<int>();
            if (IsReadFile)
            {
                using (var reader = new StreamReader(@"C:\Users\hang2\Source\Repos\BoxFit2\Properties\fittingboxsamples2.csv"))
                {
                    while (!reader.EndOfStream)
                    {
                        var line = reader.ReadLine();
                        var values = line.Split(',');
                        int x, y;

                        if (int.TryParse(values[0], out x) && int.TryParse(values[1], out y))
                        {
                            listA.Add(x);
                            listB.Add(y);
                        }
                    }
                }
            }
            AssignBoxlistSizes();
        }

        private void AssignBoxlistSizes()
        {
            BoxList.Clear();
            BoxListReadOnly.Clear();
            for (int i = 0; i < listA.Count; i++)
            {
                BoxList.Add(i, new RectangularBox { Width = listA[i], Height = listB[i],Buffer = BufferWidth });
            }
            BoxListReadOnly = BoxList;
        }

        public void SetSizes(BindingList<RectangularBox> rects)
        {
            listA.Clear();
            listB.Clear();
            foreach (var item in rects)
            {
                listA.Add(item.Width + item.Buffer*2);
                listB.Add(item.Height + item.Buffer*2);
                BufferWidth = item.Buffer;
            }
           
            AssignBoxlistSizes();
            foreach (var item in BoxList)
            {
                item.Value.WidthInterpreter = rects[item.Key].WidthInterpreter; 
                item.Value.HeightInterpreter = rects[item.Key].HeightInterpreter; 
            }
        }
    }
}
