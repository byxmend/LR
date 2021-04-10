using System;

namespace WoT
{
    public class HeavyTank : Tank
    {
        private int ArmorRatio { get; set; }

        public override void FillTanksSet(Tanks tanks, int i)
        {
            Console.WriteLine("Heavy tank:");
            Console.Write("Enter armor ratio: ");
            ArmorRatio = CheckInt();
            base.FillTanksSet(tanks, i);
        }

        public override void ShowTanksSet(Tanks tanks, int i)
        {
            base.ShowTanksSet(tanks, i);
            Console.WriteLine($"Armor ratio: {ArmorRatio}");
        }
        
        public int Defence()
        {
            Random random = new Random();
            
            int value = random.Next(0, ArmorRatio);
            int counter = 0;

            if (ArmorRatio / 2 > value)
            {
                counter++;
            }

            return counter;
        }
        
        public override void AddEquip(Tanks tanks, int i)
        {
            if (!tanks[i].Equipment)
            {
                tanks[i].HitPoints += 1000;
                tanks[i].ShotsPerMinute += 1;
                tanks[i].Equipment = true;
            }
            else
            {
                Console.WriteLine("You can't install the equipment twice");
            }
        }
        
        public override void RemoveEquip(Tanks tanks, int i)
        {
            if (tanks[i].Equipment)
            {
                tanks[i].HitPoints -= 1000;
                tanks[i].ShotsPerMinute -= 1;
                tanks[i].Equipment = false;
            }
            else
            {
                Console.WriteLine("There is no equipment on the tank anyway");
            }
        }
    }
}