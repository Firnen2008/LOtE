using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LOtE
{
    enum States
    {
        // ходьба по прямой
        Left,
        Up,
        Right,
        Down,
        // ходьба по диагонали //правил код CreaHaGame
        LeftUp,
        UpRight,
        RightDown,
        DownLeft,
        // стоп
        Stop
    }
    enum DamageType
    {
        magic,
        physical,
        pure
    }
    enum PersDirection
    {
        Run,
        Atact,
        ShieldDefend,
        Standart
    }
}

