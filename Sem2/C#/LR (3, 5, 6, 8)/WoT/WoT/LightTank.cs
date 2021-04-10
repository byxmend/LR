using System;

namespace WoT
{
    public class LightTank : Tank
    {
        private int DamageAirSupport { get; set; }
        private double AirSupportPerMinute { get; set; }

        private readonly Tanks _tanksSet = new Tanks();

        public override void FillTanksSet(Tanks tanks, int i)
        {
            Console.WriteLine("Light tank:");
            Console.Write("Enter damage from air support: ");
            DamageAirSupport = CheckInt();
            Console.Write("Enter the number of air supports per minute: ");
            AirSupportPerMinute = CheckInt();
            base.FillTanksSet(tanks, i);
        }

        public override void ShowTanksSet(Tanks tanks, int i)
        {
            base.ShowTanksSet(tanks, i);
            Console.WriteLine($"Damage from air support: {DamageAirSupport}");
            Console.WriteLine($"The number of air supports per minute: {AirSupportPerMinute}");
        }

        public double AirSupport()
        {
            double value = DamageAirSupport * AirSupportPerMinute;

            return value;
        }
        
        public override void AddEquip(Tanks tanks, int i)
        {
            if (!tanks[i].Equipment)
            {
                tanks[i].HitPoints += 350;
                tanks[i].ShotsPerMinute += 4;
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
                tanks[i].HitPoints -= 350;
                tanks[i].ShotsPerMinute -= 4;
                tanks[i].Equipment = false;
            }
            else
            {
                Console.WriteLine("There is no equipment on the tank anyway");
            }
        }
    }
}