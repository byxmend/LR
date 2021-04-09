using System;

namespace WoT
{
    public class HeavyTank : Tank
    {
        private int ArmorRatio { get; set; }

        private readonly Tanks _tanksSet = new Tanks();

        public override void FillTanksSet(int i)
        {
            Console.WriteLine("Heavy tank:\n");
            Console.WriteLine("Enter armor ratio (more is worse):");
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
            if (!Equipment)
            {
                _tanksSet[0].HitPoints += 1000;
                _tanksSet[0].ShotsPerMinute += 1;
                _tanksSet[0].Equipment = true;
            }
            else
            {
                Console.WriteLine("You can't install the equipment twice");
            }
        }
        
        public override void RemoveEquip(int i)
        {
            if (Equipment)
            {
                _tanksSet[i].HitPoints -= 1000;
                _tanksSet[i].ShotsPerMinute -= 1;
                _tanksSet[i].Equipment = false;
            }
            else
            {
                Console.WriteLine("There is no equipment on the tank anyway");
            }
        }
    }
}