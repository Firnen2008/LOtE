﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LOtE
{
    class WoodenSword : ItmeSword
    {
        public WoodenSword(int strength, Line damage, DamageType typeOfDamage, Texture2D texture, Rectangle rectangle, string name, int number) : base(strength, damage, typeOfDamage, texture, rectangle, name, number)
        {
            ID = 1;
            TextID = "pers" + ID;
        }
    }
}
