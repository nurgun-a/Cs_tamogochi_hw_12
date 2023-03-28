using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;
using System.Windows.Forms;

namespace Cs_tamogochi_hw_12
{
    public delegate void FeedDelegate();
    public delegate void Take_outDelegate();
    public delegate void DeadDelegate();
    public delegate void HealDelegate();
    public delegate void PlayDelegate();
    class Tamagochi
    {
        public int Health { get; set; } = 100;
        public string Name { get; set; }
        public int Count_ { get; set; } = 0;
        public void Feed()
        {
            if (MessageBox.Show($"Накормить {Name}", $"Ваш питомец хочет кушать",
               MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                if (Health < 100) Health += 20;               
                
            }
            else
            {
                if (Health > 0) Health -= 20;
                Count_++;
            }
           
        }
        public void Take_out()
        {
            if (MessageBox.Show($"Погулять с {Name}", $"Ваш питомец хочет гулять ",
                MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                if (Health < 100) Health += 20;
            }
            else
            {
                if (Health > 0) Health -= 20;
                Count_++;
            }
        }
        public void Play()
        {
            if (MessageBox.Show($"Поиграть с {Name}", $"Ваш питомец хочет поиграть",
               MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                if (Health < 100) Health += 20;

            }
            else
            {
                if (Health > 0) Health -= 20;
                Count_++;
            }

        }
        public void Heal()
        {
            if (MessageBox.Show($"Вылечить {Name}", $"Ваш питомец умирает!!!",
                MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                if (Health < 100) Health =100;
                Count_ = 0;
            }
            else
            {                
                Dead();
            }
        }
        public void Dead()
        {
            Clear();
            Health = 0;
            WriteLine($"{Name} УМИР!!!");
            WriteLine($"{ToString()}");
            Environment.Exit(0);
        }
        public override string ToString()
        {
            if (Health==0)
            {
            return $"Health: {Health}\nName: {Name}" + @"
                 _
              (\   /)
              (=x.x=)
              () _ ()
               \_|_/";
            }
            else return $"Health: {Health}\nName: {Name}"+@"
                 _
              (\   /)
              (='.'=)
              () _ ()
               \_|_/"; 
        }
    }

    class User
    {  
        public event FeedDelegate FeedEvent;
        public event Take_outDelegate Take_outEvent;
        public event HealDelegate HealEvent;
        public event DeadDelegate DeadEvent;
        public event DeadDelegate PlayEvent;
        public void Feed()
        {
            if (FeedEvent != null)
            {
                FeedEvent();
            }
        }
        public void Take_out()
        {
            if (Take_outEvent != null)
            {
                Take_outEvent();
            }
        }
        public void Play()
        {
            if (PlayEvent != null)
            {
                PlayEvent();
            }
        }
        public void Heal()
        {
            if (HealEvent != null)
            {
                HealEvent();
            }
        }
        public void Dead()
        {
            if (DeadEvent != null)
            {
                DeadEvent();
            }
        }
    }
}
