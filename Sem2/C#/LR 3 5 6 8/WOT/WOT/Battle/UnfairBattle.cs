using System;

namespace WOT
{
    class UnfairBattle : IBattle
    {
        private readonly ICalculatePoints calculatePoints = new MaintainingBattle();

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
                Console.WriteLine("\nUnhonestly battle!\n");

                // first tank
                calculatePoints.NumberOfShotsToKillTank(tanks, ref firstTankHp, ref firstTankShots, ref firstChooseTank, ref secondChooseTank);

                // second tank
                calculatePoints.NumberOfShotsToKillTank(tanks, ref secondTankHp, ref secondTankShots, ref firstChooseTank, ref secondChooseTank);

                calculatePoints.CalculateShotsRatio(tanks, ref secondTankShots, ref secondChooseTank, ref shotRatio1, ref shotRatio2, ref firstTankShots,
                    ref firstChooseTank);

                calculatePoints.DeterminingTheWinner(ref shotRatio1, ref shotRatio2);
            }
            else
            {
                Console.WriteLine("A tank can't fight itself");
            }
        }
    }
}
