using System;

namespace WOT
{
    class MaintainingBattle : ICalculatePoints, IAbilities
    {
        private readonly HeavyTank _heavyTank = new HeavyTank();

        private readonly LightTank _lightTank = new LightTank();

        private readonly MediumTank _mediumTank = new MediumTank();

        public void BattleAirSupportLightTank(ref int firstChooseTank, ref int secondChooseTank,
            ref int firstTankHp, ref int secondTankHp)
        {
            if (secondTankHp > 0 && firstChooseTank == 2)
            {
                secondTankHp -= (int)_lightTank.AirSupport();
            }
            else if (firstTankHp > 0 && secondChooseTank == 2)
            {
                firstTankHp -= (int)_lightTank.AirSupport();
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

        public void NumberOfShotsToKillTank(Tanks tanks, ref int TankHp, ref int TankShots,
            ref int firstChooseTank, ref int secondChooseTank)
        {
            while (TankHp > 0)
            {
                TankHp -= tanks[firstChooseTank].DamagePerShoot;
                TankShots++;

                if (secondChooseTank == 1)
                {
                    TankShots += _heavyTank.Defence();
                }
            }
        }

        public void CalculateShotsRatio(Tanks tanks, ref int secondTankShots, ref int secondChooseTank,
            ref double shotRatio1, ref double shotRatio2, ref int firstTankShots, ref int firstChooseTank)
        {
            if (secondTankShots > 0 && tanks[secondChooseTank].ShotsPerMinute > 0)
            {
                shotRatio1 = firstTankShots / (float)(secondTankShots);
                shotRatio2 = tanks[firstChooseTank].ShotsPerMinute /
                             (float)(tanks[secondChooseTank].ShotsPerMinute);
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
    }
}
