using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LOtE
{
    class Position
    {
        public int X { get; set; }
        public int Y { get; set; }

        static Random r = new Random();

        public Position(int x, int y)
        {
            X = x;
            Y = y;
        }
        ///<summary>
        ///Статический метод для генерации случайных координат
        ///</summary>
        public static Position ComputePosition(Container container)
        {
            return new Position(r.Next(container.Width.X1, container.Width.X2),
                r.Next(container.Height.X1, container.Height.X2));
        }
    }
}
