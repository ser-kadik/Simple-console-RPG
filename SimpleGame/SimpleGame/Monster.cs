using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleGame
{
    internal class Monster
    {
        public string Name { get; set; }
        public int HP { get; set; }  
        public int Damage { get; set; }

        
        public Monster(string name, int hP, int damage)
        {
            Name = name;
            HP = hP;
            Damage = damage;
        }

        public virtual int Attack() 
        {
            return Damage;
        }

        public virtual void GetDamage(int damage)
        {
            HP -= damage;
        }

        public virtual string GetInfo() 
        {
            return $"Name: {Name}, HP: {HP}, Damage: {Damage}";
        }
    }
}
