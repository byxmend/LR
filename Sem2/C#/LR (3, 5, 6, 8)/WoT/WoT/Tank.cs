using System;

namespace WoT
{
    public class Tank
    {
        public int HitPoints { get; protected set; }
        public int ShotsPerMinute { get; protected set; }
        public string Name { get; }
        public string Id { get; }
        protected bool Equipment { get; set; }
        public int Ammunition { get; private set; }
        public int DamagePerShoot { get; protected set; }
        public Nationality Nation { get; }

        public Tank() { }

        public Tank(int hitPoints, int shotsPerMinute, string name, int ammunition, int damagePerShoot, Nationality nation)
        {
            HitPoints = hitPoints;
            ShotsPerMinute = shotsPerMinute;
            Name = name;
            Equipment = false;
            Ammunition = ammunition;
            DamagePerShoot = damagePerShoot;
            Id = GenerationId();
            Nation = nation;
        }

        private static string GenerationId() => Guid.NewGuid().ToString();

        private readonly Tanks _tanks = new Tanks();

        public int ChooseTank()
        {
            Console.WriteLine("\nChoose number of the tank:");

            for (int i = 1; i < 4; i++)
            {
                Console.Write(i + " ");
            }

            Console.WriteLine(": ");

            int a = _tanks.CheckInt();
            return (a - 1);
        }

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

        public void AddEquip(int hitPoints, int shotsPerMinute, int damagePerShot)
        {
            if (!Equipment)
            {
                HitPoints += hitPoints;
                ShotsPerMinute += shotsPerMinute;
                DamagePerShoot += damagePerShot;
                Equipment = true;
            }
            else
            {
                Console.WriteLine("You can't install the equipment twice");
            }
        }

        public virtual void RemoveEquip()
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
        
        public void RemoveEquip(int hitPoints, int shotsPerMinute, int damagePerShot)
        {
            if (!Equipment)
            {
                HitPoints -= hitPoints;
                ShotsPerMinute -= shotsPerMinute;
                DamagePerShoot -= damagePerShot;
                Equipment = false;
            }
            else
            {
                Console.WriteLine("You can't install the equipment twice");
            }
        }

        public void Shoot(Tank tank)
        {
            if (tank.Ammunition > 0)
            {
                tank.Ammunition--;
                Console.WriteLine("The tank fired!");
            }
            else
            {
                Console.WriteLine("No ammunition");
            }
        }

        public void Battle(Tank tank1, Tank tank2)
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
                while (firstTankHp > 0)
                {
                    firstTankHp -= tank1.DamagePerShoot;
                    firstTankShots++;
                }

                while (secondTankHp > 0)
                {
                    secondTankHp -= tank2.DamagePerShoot;
                    secondTankShots++;
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
                    Console.WriteLine(
                        "The hit points of the second tank is less than zero or the second tank does not fire");
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