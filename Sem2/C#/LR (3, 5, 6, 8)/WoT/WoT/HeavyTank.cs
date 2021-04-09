using System;

namespace WoT
{
    public class HeavyTank : Tank
    {
        private int ArmorRatio { get; set; }

        public override void FillTanksSet(int i)
        {
            Console.WriteLine("Heavy tank:\n");
            Console.WriteLine("Enter armor ratio (more is worse):");
            ArmorRatio = CheckInt();
            base.FillTanksSet(i); // 0 - indexer number
        }

        public override void ShowTanksSet()
        {
            base.ShowTanksSet();
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
                HitPoints += 1000;
                ShotsPerMinute += 1;
                Equipment = true;
            }
            else
            {
                Console.WriteLine("You can't install the equipment twice");
            }
        }
        
        public override void RemoveEquip()
        {
            if (Equipment)
            {
                HitPoints -= 1000;
                ShotsPerMinute -= 1;
                Equipment = false;
            }
            else
            {
                Console.WriteLine("There is no equipment on the tank anyway");
            }
        }
    }
}