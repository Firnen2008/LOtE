using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;

namespace LOtE
{
    class ItmeSword : Itme
    {
        //Прочность
        public int Strength { get; set; }
        //Урон
        public Line Damage {get; set;} 
        //Вид урона
        public DamageType TypeOfDamage { get;set;}
        public ItmeSword(int strength, Line damage, DamageType typeOfDamage, Texture2D texture, Rectangle rectangle, String name, int number,int persID) : base( texture,  rectangle, name, number, persID)
        {
            Strength = strength;
            Damage = damage;
            TypeOfDamage = typeOfDamage;
            StuckOrNot = false;
        }
    }
}
