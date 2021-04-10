using System;

namespace WoT
{
    public class LightTank : Tank
    {
        private int DamageAirSupport { get; set; }
        private double AirSupportPerMinute { get; set; }

        private readonly Tanks _tanksSet = new Tanks();

        public override void FillTanksSet(int i)
        {
            Console.WriteLine("Light tank:");
            Console.Write("Enter damage from air support: ");
            DamageAirSupport = CheckInt();
            Console.Write("Enter the number of air supports per minute: ");
            AirSupportPerMinute = CheckInt();
            base.FillTanksSet(i);
        }

        public override void ShowTanksSet(int i)
        {
            base.ShowTanksSet(i);
            Console.WriteLine($"Damage from air support: {DamageAirSupport}");
            Console.WriteLine($"The number of air supports per minute: {AirSupportPerMinute}");
        }

        public double AirSupport()
        {
            double value = DamageAirSupport * AirSupportPerMinute;

            return value;
        }
        
        public override void AddEquip()
        {
            if (!_tanksSet[1].Equipment)
            {
                _tanksSet[1].HitPoints += 350;
                _tanksSet[1].ShotsPerMinute += 4;
                _tanksSet[1].Equipment = true;
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
                _tanksSet[1].HitPoints -= 350;
                _tanksSet[1].ShotsPerMinute -= 4;
                _tanksSet[1].Equipment = false;
            }
            else
            {
                Console.WriteLine("There is no equipment on the tank anyway");
            }
        }
    }
}