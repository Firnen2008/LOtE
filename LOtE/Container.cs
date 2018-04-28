using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LOtE
{
    class Container
    {
        private int x;
        private int y;

        public Line Width { get; set; }
        public Line Height { get; set; }

        public int X
        {
            get
            {
                return x;
            }
            set
            {
                Width.X1 = Width.X1 + value;
                Width.X2 = Width.X2 + value;
                x = value;
            }
        }
        public int Y
        {
            get
            {
                return y;
            }
            set
            {
                Height.X1 = Height.X1 + value;
                Height.X2 = Height.X2 + value;
                y = value;
            }
        }

        public Container(Line width, Line height, int x, int y)
        {
            Width = width;
            Height = height;
            X = x;
            Y = y;
        }
    }
}
