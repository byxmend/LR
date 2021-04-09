using System;

namespace WoT
{
    public class LightTank : Tank
    {
        private int DamageAirSupport { get; set; }
        private int AirSupportPerMinute { get; set; }

        public override void FillTanksSet(int i)
        {
            Console.WriteLine("Light tank:\n");
            Console.WriteLine("Enter damage from air support:");
            DamageAirSupport = CheckInt();
            Console.WriteLine("Enter the number of air supports per minute:");
            AirSupportPerMinute = CheckInt();
            base.FillTanksSet(1); // 1 - indexer number
        }

        public override void ShowTanksSet()
        {
            base.ShowTanksSet();
            Console.WriteLine($"Damage from air support: {DamageAirSupport}");
            Console.WriteLine($"The number of air supports per minute: {AirSupportPerMinute}");
        }
        
        
        
        public override void AddEquip()
        {
            if (!Equipment)
            {
                HitPoints += 350;
                ShotsPerMinute += 4;
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
                HitPoints -= 350;
                ShotsPerMinute -= 4;
                Equipment = false;
            }
            else
            {
                Console.WriteLine("There is no equipment on the tank anyway");
            }
        }
    }
}