using System;

namespace WOT
{
    public class MediumTank : Tank
    {
        public override int ArmorRatio { get; set; }
        public override int DamageAirSupport { get; set; }
        public override double AirSupportPerMinute { get; set; }

        public MediumTank(int hitPoints, int shotsPerMinute, string name, int damagePerShoot, 
            Nationality nation) : base(hitPoints, shotsPerMinute, name, damagePerShoot, nation)
        {
            HitPoints = hitPoints;
            ShotsPerMinute = shotsPerMinute;
            Name = name;
            DamagePerShoot = damagePerShoot;
            Nation = nation;
        }
        
        public MediumTank() { }
        
        private readonly Program _program = new Program();
        
        private Camo _camo;
        
        public void FillCamo()
        {
            Console.Write("Fill camo:\nColor: ");
            string color = Console.ReadLine();
            Console.Write("Season: ");
            string season = Console.ReadLine();
            Console.Write("Disguise (1 - 10): ");
            int disguise = _program.CheckInt();

            _camo = new Camo(color, season, disguise);
        }

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
        
        public int Aiming()
        {
            int value;
            
            while (true)
            {
                if (_camo.Disguise > 0 && _camo.Disguise < 6)
                {
                    value = _camo.Disguise / 2;
                    return value;
                }
                
                if (_camo.Disguise > 5 && _camo.Disguise < 11)
                {
                    value = _camo.Disguise / 3;
                    return value;
                }

                Console.WriteLine("Range: 1 - 10, try again");
                _camo.Disguise = _program.CheckInt();
            }
        }
    }
}