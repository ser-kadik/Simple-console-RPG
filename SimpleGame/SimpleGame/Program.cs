using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace SimpleGame
{
    internal class Program
    {
        static Random rnd = new Random();
        static List<Monster> monsters = new List<Monster>();
        static int playerDamage;
        static double playerHP = 100;

        static string[] MonstersNames = { "Spectralsoul", "Halothing", "Aurafang", "Vampthing", "Emberjester", "Halofly", "Dawnbeing", "Halopaw", "Wispfang", "Tangleclaw", "Sparkbeing", "Halomirage", "The Dirty Bathtub", "The Stinky Trash Can", "The Sneaky Tree", "Pieloop", "Rotclown", "The Granny Pumpkin", "Bigbilly", "Bigdaffy", "The Violent Slasher", "Morbidtoe", "The Horned Witch", "The Scary Canine", "Demonmera", "Nightsome", "Poisonclot" }; //12 //20

        
        static void Main(string[] args)
        {
            Console.Title = "Simple Console RPG";
            Console.WriteLine("Welcome to the Simple Console RPG! Fight or die ");
            Console.WriteLine("Select game mode: 1.Baby, 2.Teenager, 3. Doomgay");
            int choice = int.Parse(Console.ReadLine());
            int choice1;
            

            switch (choice) 
            {
                case 1:
                    for (int i = 0; i < 2; i++) 
                    {
                        AddMonser();
                    } 
                    break;

                case 2:
                    for (int i = 0; i < 5; i++)
                    {
                        AddMonser();
                    }
                    break;

                case 3:
                    for (int i = 0; i < 12; i++)
                    {
                        AddMonser();
                    }
                    break;

                default:
                    Console.WriteLine("It's the worst choice in your life!");
                    for (int i = 0; i < 30; i++)
                    {
                        AddMonser();
                    }
                    break;
            }
            Console.WriteLine("Press any button...");
            Console.ReadKey();

            while (true) 
            {
                Console.Clear();
                Console.WriteLine("You fight with: \n");
                for(int i = 0;i < monsters.Count; i++) 
                {
                    Console.WriteLine($"{i + 1}. - " + monsters[i].GetInfo());
                }

                Console.WriteLine("Select one monster to hit");
                choice = int.Parse(Console.ReadLine());
                Console.WriteLine("Select attack type: \n 1. Head(damage: 8 - 10, сhance to blunder: 70%), \n 2. Body(damage: 4 - 7, сhance to blunder: 40%), \n 3. Legs(damage: 1 - 3, сhance to blunder: 10%)");
                choice1 = int.Parse(Console.ReadLine());

                Attack(choice, choice1);
                MonsterAttack();
                Console.WriteLine("Press any button...");
                Console.ReadKey();

            }

        }

        private static void MonsterAttack()
        {

            for (int i = 0; i < monsters.Count; i++)
            {
                 playerHP -= monsters[i].Attack();
                Console.WriteLine($"Monster {i + 1} hit you");
            }
            Console.ReadKey();
            if (playerHP <= 0) 
            {
                Console.Clear();
                Console.WriteLine("You lost"); ;
                Console.ReadKey();
                Environment.Exit(0);
            }
            Console.WriteLine($"Your HP = {playerHP}");
            Console.ReadKey();

        }

        private static void Attack(int monster, int attackType)
        {
            int blunderChance = rnd.Next(0,100);

            switch (attackType) 
            {
                case 1:
                    if (blunderChance > 90)
                    {
                        monsters[monster - 1].GetDamage(rnd.Next(8,11));
                        Console.WriteLine($"You hit a monster {monster}");
                    }

                    else
                    {
                        Console.WriteLine("You blundered");
                    }
                    break;

                case 2:
                    if (blunderChance < 90 && blunderChance > 30)
                    {
                        monsters[monster-1].GetDamage(rnd.Next(4,8));
                        Console.WriteLine($"You hit a monster {monster}");
                    }

                    else
                    {
                        Console.WriteLine("You blundered");
                    }
                    break;

                case 3:
                    if (blunderChance > 30)
                    {
                        monsters[monster-1].GetDamage(rnd.Next(1,4));
                        Console.WriteLine($"You hit a monster {monster}");
                    }

                    else
                    {
                        Console.WriteLine("You blundered");
                    }
                    break;

                default:
                    Console.WriteLine("You hit air");
                    Console.ReadKey();
                    break;
            }

            if (monsters[monster-1].HP <= 0)
            {
                monsters.RemoveAt(monster-1);
                Console.WriteLine($"Monster {monster} dead");
               

                if (rnd.Next(0, 100) > 80) 
                {
                    playerHP = playerHP + playerHP*0.2;
                    playerHP = Math.Truncate(playerHP);
                    Console.WriteLine($"You get a prize 20% HP \n Your HP = {playerHP}");
                }
            }

            Console.ReadKey();

            if (monsters.Count == 0) 
            {
                Console.Clear();
                Console.WriteLine("\nYou win!");
                Console.ReadKey();
                Environment.Exit(0);
            }
        }

        private static void AddMonser()
        {
            int monsterChoice = rnd.Next(0, 100);
            if(monsterChoice > 30) 
            {
                monsters.Add(new Monster(MonstersNames[rnd.Next(0,13)], rnd.Next(10,15), rnd.Next(2,6)));
            }

            else if(monsterChoice > 5 && monsterChoice < 30) 
            {
                monsters.Add(new ArmorMonster(MonstersNames[rnd.Next(13, 21)], rnd.Next(10, 15), rnd.Next(2, 6), rnd.Next(5,11)));
            }

            else 
            {
                monsters.Add(new SwordMonster(MonstersNames[rnd.Next(21, 27)], rnd.Next(10, 15), rnd.Next(2, 6), rnd.Next(0,5)));
            }

        }
    }
}
