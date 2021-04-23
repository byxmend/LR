using System;

namespace WOT
{
    public class Battle : ICalculatePoints, IAbilities
    {
        private readonly HeavyTank _heavyTank = new HeavyTank();

        private readonly LightTank _lightTank = new LightTank();

        private readonly MediumTank _mediumTank = new MediumTank();

        public void BattleAirSupportLightTank(ref int firstChooseTank, ref int secondChooseTank,
            ref int firstTankHp,  ref int secondTankHp)
        {
            if (secondTankHp > 0 && firstChooseTank == 2)
            {
                secondTankHp -= (int) _lightTank.AirSupport();
            }
            else if (firstTankHp > 0 && secondChooseTank == 2)
            {
                firstTankHp -= (int) _lightTank.AirSupport();
            }
        }

        public void BattleAimingMediumTank(ref int firstChooseTank, ref int secondChooseTank,
            ref int firstTankShots, ref int secondTankShots)
        {
            if (secondChooseTank == 3)
            {
                firstTankShots += _mediumTank.Aiming();
            }
            else if (firstChooseTank == 3)
            {
                secondTankShots += _mediumTank.Aiming();
            }
        }

        public void NumberShotsToKillFirstTank(Tanks tanks, ref int firstTankHp, ref int firstTankShots,
            ref int firstChooseTank, ref int secondChooseTank)
        {
            while (firstTankHp > 0)
            {
                firstTankHp -= tanks[firstChooseTank].DamagePerShoot;
                firstTankShots++;

                if (secondChooseTank == 1)
                {
                    firstTankShots += _heavyTank.Defence();
                }
            }
        }

        public void NumberShotsToKillSecondTank(Tanks tanks, ref int secondTankHp, ref int secondTankShots,
            ref int firstChooseTank, ref int secondChooseTank)
        {
            while (secondTankHp > 0)
            {
                secondTankHp -= tanks[secondChooseTank].DamagePerShoot;
                secondTankShots++;

                if (firstChooseTank == 1)
                {
                    secondTankShots += _heavyTank.Defence();
                }
            }
        }

        public void CalculateShotsRatio(Tanks tanks, ref int secondTankShots, ref int secondChooseTank,
            ref double shotRatio1, ref double shotRatio2, ref int firstTankShots, ref int firstChooseTank)
        {
            if (secondTankShots > 0 && tanks[secondChooseTank].ShotsPerMinute > 0)
            {
                shotRatio1 = firstTankShots / (float) (secondTankShots);
                shotRatio2 = tanks[firstChooseTank].ShotsPerMinute /
                             (float) (tanks[secondChooseTank].ShotsPerMinute);
            }
            else
            {
                Console.WriteLine(
                    "The hit points of the second tank is less than zero or the second tank does not fire");
            }
        }

        public void DeterminingTheWinner(ref double shotRatio1, ref double shotRatio2)
        {
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

        public void BattleBetweenTanks(Tanks tanks, int firstChooseTank, int secondChooseTank)
        {
            int firstTankHp = tanks[firstChooseTank].HitPoints;
            int secondTankHp = tanks[secondChooseTank].HitPoints;
            int firstTankShots = 0;
            int secondTankShots = 0;
            
            double shotRatio1 = 0;
            double shotRatio2 = 0;

            if (tanks[firstChooseTank] != tanks[secondChooseTank])
            {
                Console.WriteLine("\nBattle!\n");
                
                BattleAirSupportLightTank(ref firstChooseTank, ref secondChooseTank, ref firstTankHp, ref secondTankHp);
                
                BattleAimingMediumTank(ref firstChooseTank, ref secondChooseTank, ref firstTankShots, ref secondTankShots);

                NumberShotsToKillFirstTank(tanks, ref firstTankHp, ref firstTankShots, ref firstChooseTank, ref secondChooseTank);

                NumberShotsToKillSecondTank(tanks, ref secondTankHp, ref secondTankShots, ref firstChooseTank, ref secondChooseTank);
                
                CalculateShotsRatio(tanks, ref secondTankShots, ref secondChooseTank, ref shotRatio1, ref shotRatio2, ref firstTankShots, 
                    ref firstChooseTank);

                DeterminingTheWinner(ref shotRatio1, ref shotRatio2);
            }
            else
            {
                Console.WriteLine("A tank can't fight itself");
            }
        }
    }
}