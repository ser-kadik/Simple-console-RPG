using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleGame
{
    internal class SwordMonster : Monster
    {
        static Random rnd = new Random();

        public int DeadProcent {  get; set; }

        public SwordMonster(string name, int hP, int damage, int deadProcent) : base(name, hP, damage)
        {
            DeadProcent = deadProcent;
        }

        public override int Attack()
        {
            if (rnd.Next(0, 100) < DeadProcent) 
            {
                return base.Attack();
            }

            else 
            {
                return 100;
            }
        }

        

        public override string GetInfo()
        {
            return base.GetInfo() + $" Chance of death: {DeadProcent}%";
        }
    }
}
