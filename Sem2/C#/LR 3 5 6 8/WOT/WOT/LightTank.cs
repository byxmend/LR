using System;

namespace WOT
{
    public class LightTank : Tank
    {
        public sealed override int DamageAirSupport { get; set; }
        public sealed override double AirSupportPerMinute { get; set; }
        public override int ArmorRatio { get; set; }
        
        public LightTank(int hitPoints, int shotsPerMinute, string name, int damagePerShoot, Nationality nation, 
            int damageAirSupport, double airSupportPerMinute) : base(hitPoints, shotsPerMinute, name, damagePerShoot, nation)
        {
            HitPoints = hitPoints;
            ShotsPerMinute = shotsPerMinute;
            Name = name;
            DamagePerShoot = damagePerShoot;
            Nation = nation;
            DamageAirSupport = damageAirSupport;
            AirSupportPerMinute = airSupportPerMinute;
        }
        
        public LightTank() { }

        public override void AddEquip(Tanks tanks, int index)
        {
            if (!tanks[index].Equipment)
            {
                tanks[index].HitPoints += 350;
                tanks[index].ShotsPerMinute += 4;
                tanks[index].Equipment = true;
            }
            else
            {
                Console.WriteLine("You can't install the equipment  on light tank twice");
            }
        }
        
        public override void DeleteEquip(Tanks tanks, int index)
        {
            if (tanks[index].Equipment)
            {
                tanks[index].HitPoints -= 350;
                tanks[index].ShotsPerMinute -= 4;
                tanks[index].Equipment = false;
            }
            else
            {
                Console.WriteLine("There is no equipment on the light tank anyway");
            }
        }
        
        public double AirSupport()
        {
            double value = DamageAirSupport * AirSupportPerMinute;

            return value;
        }
    }
}