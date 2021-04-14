using System;

namespace WOT
{
    public class Battle
    {
        private readonly HeavyTank _heavyTank = new HeavyTank();
        
        private readonly LightTank _lightTank = new LightTank();

        private readonly MediumTank _mediumTank = new MediumTank();
        
        public void BattleBetweenTanks(Tanks tanks, int firstChooseTank, int secondChooseTank)
        {
            Console.WriteLine("\nBattle!\n");
            
            int firstTankShots = 0;
            int secondTankShots = 0;
            int firstTankHp = tanks[firstChooseTank].HitPoints;
            int secondTankHp = tanks[secondChooseTank].HitPoints;
            double shotRatio1 = 0;
            double shotRatio2 = 0;

            if (tanks[firstChooseTank] != tanks[secondChooseTank])
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
                    firstTankShots += _mediumTank.Aiming(); // only for medium tank tank (add aiming)
                }
                else if (firstChooseTank == 3)
                {
                    secondTankShots += _mediumTank.Aiming(); // only for medium tank tank (add aiming)
                }
                
                // counting the number of shots to kill the first tank
                while (firstTankHp > 0)
                {
                    firstTankHp -= tanks[firstChooseTank].DamagePerShoot;
                    firstTankShots++;
                    
                    if (secondChooseTank == 1)
                    {
                        firstTankShots += _heavyTank.Defence(); // only for heavy tank (add defence)
                    }
                }

                // counting the number of shots to kill the second tank
                while (secondTankHp > 0)
                {
                    secondTankHp -= tanks[secondChooseTank].DamagePerShoot;
                    secondTankShots++;

                    if (secondChooseTank == 1)
                    {
                        secondTankShots += _heavyTank.Defence(); // only for heavy tank (add defence)
                    }
                }

                if (secondTankShots > 0 && tanks[secondChooseTank].ShotsPerMinute > 0)
                {
                    shotRatio1 = firstTankShots / (float)(secondTankShots);
                    shotRatio2 = tanks[firstChooseTank].ShotsPerMinute / (float)(tanks[secondChooseTank].ShotsPerMinute);
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