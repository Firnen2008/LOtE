using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LOtE
{
    class WoodenShield : ItmeShield
    {
        public WoodenShield(int strength, float physicalarmor, float magicarmor, int blockchance, float blockpower, Texture2D texture, Rectangle rectangle, String name, int number) : base(strength, physicalarmor, magicarmor, blockchance, blockpower, texture, rectangle, name, number)
        {
            ID = 2;
            TextID = "pers" + ID;
        }
    }
}
