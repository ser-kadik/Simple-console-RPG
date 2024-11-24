using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleGame
{
    internal class ArmorMonster : Monster
    {
        public int Armor {  get; set; }

        public ArmorMonster(string name, int hP, int damage, int armor) : base(name, hP, damage)
        {
            Armor = armor;
        }

        public override void GetDamage(int damage)
        {
            int cp;

            if (Armor >= damage)
            {
                Armor -= damage;
            }

            else 
            {
                cp = Armor - damage;
                Armor = 0;
                HP += cp;
            }  
        }

        public override string GetInfo()
        {
            return base.GetInfo() + $" Armor: {Armor}";
        }
    }
}
