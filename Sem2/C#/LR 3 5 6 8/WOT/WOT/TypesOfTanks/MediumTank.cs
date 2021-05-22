using System;

namespace WOT
{
    public class MediumTank : Tank
    {
        public sealed override int Disguise { get; set; }
        public override int ArmorRatio { get; set; }
        public override int DamageAirSupport { get; set; }
        public override double AirSupportPerMinute { get; set; }

        public MediumTank(int hitPoints, int shotsPerMinute, string name, int damagePerShoot, 
            Nationality nation, int disguise) : base(hitPoints, shotsPerMinute, name, damagePerShoot, nation)
        {
            HitPoints = hitPoints;
            ShotsPerMinute = shotsPerMinute;
            Name = name;
            DamagePerShoot = damagePerShoot;
            Nation = nation;
            Disguise = disguise;
        }
        
        public MediumTank() { }

        public override void AddEquip(Tanks tanks, int index)
        {
            if (!tanks[index].Equipment)
            {
                tanks[index].DamagePerShoot += 150;
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
                tanks[index].DamagePerShoot -= 150;
                tanks[index].Equipment = false;
            }
            else
            {
                Console.WriteLine("There is no equipment on the light tank anyway");
            }
        }
        
        public int Aiming(Program.CheckNumberInteger checkNumberInteger)
        {
            int value, num = 0;
            
            while (true)
            {
                switch (Disguise)
                {
                    case > 0 and < 6:
                        value = Disguise / 2;
                        return value;
                    case > 5 and < 11:
                        value = Disguise / 3;
                        return value;
                    default:
                        Console.WriteLine("Range: 1 - 10, try again");
                        Disguise = checkNumberInteger(num);
                        break;
                }
            }
        }
    }
}