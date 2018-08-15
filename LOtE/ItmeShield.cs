using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LOtE
{
    class ItmeShield : Itme
    {
        //Прочность
        public int Strength { get; set; }
        //Количество прибовляемой  физической брони
        public float PhysicalArmor { get; set; }
        //Количество прибовляемой  магической брони
        public float MagicArmor { get; set; }
        //шанс блока
        public int BlockChance { get; set; }
        //сила блока
        public float BlockPower { get; set; }
        public ItmeShield(int strength, float physicalarmor, float magicarmor, int blockchance, float blockpower, Texture2D texture, Rectangle rectangle, String name, int number, int persID) : base(texture,  rectangle, name, number, persID)
        {
            PhysicalArmor = physicalarmor;
            MagicArmor = magicarmor;
            BlockChance = blockchance;
            BlockPower = blockpower;
            StuckOrNot = false;
        }
    }
}
