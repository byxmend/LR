using System;

namespace WoT
{
    public class HeavyTank : Tank
    {
        private int ArmorRatio { get; set; }

        public override void FillTanksSet(int i)
        {
            Console.WriteLine("Heavy tank:");
            Console.Write("Enter armor ratio: ");
            ArmorRatio = CheckInt();
            base.FillTanksSet(i);
        }

        public override void ShowTanksSet(int i)
        {
            base.ShowTanksSet(i);
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
        
        public override void AddEquip()
        {
            Tanks tanksSet = new Tanks();

            if (!tanksSet[0].Equipment)
            {
                tanksSet[0].HitPoints += 1000;
                tanksSet[0].ShotsPerMinute += 1;
                tanksSet[0].Equipment = true;
            }
            else
            {
                Console.WriteLine("You can't install the equipment twice");
            }
        }
        
        public override void RemoveEquip()
        {
            Tanks tanksSet = new Tanks();
            
            if (tanksSet[0].Equipment)
            {
                tanksSet[0].HitPoints -= 1000;
                tanksSet[0].ShotsPerMinute -= 1;
                tanksSet[0].Equipment = false;
            }
            else
            {
                Console.WriteLine("There is no equipment on the tank anyway");
            }
        }
    }
}