using System;

namespace WoT
{
    public class Tank : Tanks
    {
        public int HitPoints { get; protected internal set; }
        public int ShotsPerMinute { get; protected internal set; }
        public int DamagePerShoot { get; protected internal set; }
        public string Name { get; }
        public string Id { get; }
        protected internal bool Equipment { get; set; }
        public Nationality Nation { get; }

        public Tank() { }

        private readonly HeavyTank _heavyTank = new HeavyTank();
        private readonly LightTank _lightTank = new LightTank();
        private readonly Imba _imba = new Imba();

        public Tank(int hitPoints, int shotsPerMinute, string name, int damagePerShoot, Nationality nation)
        {
            HitPoints = hitPoints;
            ShotsPerMinute = shotsPerMinute;
            Name = name;
            Equipment = false;
            DamagePerShoot = damagePerShoot;
            Id = GenerationId();
            Nation = nation;
        }

        private static string GenerationId() => Guid.NewGuid().ToString();

        public virtual void AddEquip()
        {
            if (!Equipment)
            {
                HitPoints += 500;
                ShotsPerMinute += 2;
                Equipment = true;
            }
            else
            {
                Console.WriteLine("You can't install the equipment twice");
            }
        }
        
        public virtual void RemoveEquip(int i)
        {
            if (Equipment)
            {
                HitPoints -= 500;
                ShotsPerMinute -= 2;
                Equipment = false;
            }
            else
            {
                Console.WriteLine("There is no equipment on the tank anyway");
            }
        }

        public void Battle(Tank tank1, Tank tank2, int firstChooseTank, int secondChooseTank)
        {
            Console.WriteLine("\nBattle!\n");
            
            int firstTankShots = 0;
            int secondTankShots = 0;
            int firstTankHp = tank1.HitPoints;
            int secondTankHp = tank2.HitPoints;
            double shotRatio1 = 0;
            double shotRatio2 = 0;

            if (tank1 != tank2)
            {
                if (secondTankHp > 0 && firstChooseTank == 2)
                {
                    secondTankHp -= (int)_lightTank.AirSupport(); // only for light tank (add air support)
                }
                else if (firstTankHp > 0 && secondChooseTank == 2)
                {
                    firstTankHp -= (int)_lightTank.AirSupport(); // only for light tank (add air support)
                }
                
                if (secondChooseTank == 3)
                {
                    firstTankShots += _imba.Aiming(); // only for imba tank (add aiming)
                }
                else if (firstChooseTank == 3)
                {
                    secondTankShots += _imba.Aiming(); // only for imba tank (add aiming)
                }
                
                // counting the number of shots to kill the first tank
                while (firstTankHp > 0)
                {
                    firstTankHp -= tank1.DamagePerShoot;
                    firstTankShots++;
                    
                    if (secondChooseTank == 1)
                    {
                        firstTankShots += _heavyTank.Defence(); // only for heavy tank (add defence)
                    }
                }

                // counting the number of shots to kill the second tank
                while (secondTankHp > 0)
                {
                    secondTankHp -= tank2.DamagePerShoot;
                    secondTankShots++;

                    if (secondChooseTank == 1)
                    {
                        secondTankShots += _heavyTank.Defence(); // only for heavy tank (add defence)
                    }
                }

                if (secondTankShots > 0 && tank2.ShotsPerMinute > 0)
                {
                    // ReSharper disable once PossibleLossOfFraction
                    shotRatio1 = firstTankShots / secondTankShots;
                    // ReSharper disable once PossibleLossOfFraction
                    shotRatio2 = tank1.ShotsPerMinute / tank2.ShotsPerMinute;
                }
                else
                {
                    Console.WriteLine("The hit points of the second tank is less than zero or the second tank does not fire");
                }

                if (shotRatio1 < shotRatio2)
                {
                    Console.WriteLine("The first tank won");
                }
                else if (shotRatio1 > shotRatio2)
                {
                    Console.WriteLine("The second tank won");
                }
                else
                {
                    Console.WriteLine("Draw");
                }
            }
            else
            {
                Console.WriteLine("A tank can't fight itself");
            }
        }
    }
}