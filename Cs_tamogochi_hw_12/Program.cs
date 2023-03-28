using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;
using System.Threading;

namespace Cs_tamogochi_hw_12
{
    class Program
    {
       
        static void Main(string[] args)
        {
            int count1 = 1;
            User u1 = new User();
            Tamagochi t1 = new Tamagochi();
            Write($"Назовите вашего питомца: ");
            string str = ReadLine();
            t1.Name = str;
            WriteLine();
            while (true)
            {
                Clear();
                WriteLine($"{t1}");
                Thread.Sleep(1000);
                Game(ref t1, ref count1);
                count1++;
            }
           
        }
        public static void Game(ref Tamagochi tam, ref int n)
        {
            Random random = new Random();
            User u1 = new User();
            u1.FeedEvent += tam.Feed;
            u1.PlayEvent += tam.Play;
            u1.Take_outEvent += tam.Take_out;
            u1.DeadEvent += tam.Dead;
            u1.HealEvent += tam.Heal;
            if (tam.Count_ > 2)
            {
                u1.Heal();
            }
            else if (tam.Health == 0)
            {
                u1.Dead();
            }
            else
            {
                switch (n)
                {
                    case 1:
                        u1.Feed();
                        break;
                    case 2:
                        u1.Take_out();
                        break;
                    case 3:
                        u1.Play();
                        break;
                }
                if (n == 3) n = 0;
            }

        }
    }
    
}
