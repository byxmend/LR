using System;

namespace WOT
{
    public class HeavyTank : Tank
    {
        public sealed override int ArmorRatio { get; set; }
        public override int DamageAirSupport { get; set; }
        public override double AirSupportPerMinute { get; set; }
        
        public HeavyTank(int hitPoints, int shotsPerMinute, string name, int damagePerShoot, Nationality nation, 
            int armorRatio) : base(hitPoints, shotsPerMinute, name, damagePerShoot, nation)
        {
            HitPoints = hitPoints;
            ShotsPerMinute = shotsPerMinute;
            Name = name;
            DamagePerShoot = damagePerShoot;
            Nation = nation;
            ArmorRatio = armorRatio;
        }

        public HeavyTank() { }

        public override void AddEquip(Tanks tanks, int index)
        {
            if (!tanks[index].Equipment)
            {
                tanks[index].HitPoints += 1000;
                tanks[index].ShotsPerMinute += 1;
                tanks[index].DamagePerShoot += 100;
                tanks[index].Equipment = true;
            }
            else
            {
                Console.WriteLine("You can't install the equipment on heavy tank twice");
            }
        }
        
        public override void DeleteEquip(Tanks tanks, int index)
        {
            if (tanks[index].Equipment)
            {
                tanks[index].HitPoints -= 1000;
                tanks[index].ShotsPerMinute -= 1;
                tanks[index].DamagePerShoot -= 100;
                tanks[index].Equipment = false;
            }
            else
            {
                Console.WriteLine("There is no equipment on the heavy tank anyway");
            }
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
    }
}