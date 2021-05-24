using System;

namespace WOT
{
    public class Battle : IBattle
    {
        private readonly ICalculatePoints _calculatePoints = new MaintainingBattle();

        private readonly IAbilities _abilities = new MaintainingBattle();

        public void BattleBetweenTanks(Tanks tanks, int firstChooseTank, int secondChooseTank, Program.CheckNumberInteger checkNumberInteger)
        {
            try
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

                    _abilities.BattleAirSupportLightTank(ref firstChooseTank, ref secondChooseTank, ref firstTankHp, ref secondTankHp);

                    _abilities.BattleAimingMediumTank(ref firstChooseTank, ref secondChooseTank, ref firstTankShots, ref secondTankShots, checkNumberInteger);

                    // first tank
                    _calculatePoints.NumberOfShotsToKillTank(tanks, ref firstTankHp, ref firstTankShots, ref firstChooseTank, ref secondChooseTank);

                    // second tank
                    _calculatePoints.NumberOfShotsToKillTank(tanks, ref secondTankHp, ref secondTankShots, ref firstChooseTank, ref secondChooseTank);

                    _calculatePoints.CalculateShotsRatio(tanks, ref secondTankShots, ref secondChooseTank, ref shotRatio1, ref shotRatio2, ref firstTankShots,
                        ref firstChooseTank);

                    _calculatePoints.DeterminingTheWinner(ref shotRatio1, ref shotRatio2);
                }
                else
                {
                    Console.WriteLine("A tank can't fight itself");
                }
            }
            catch
            {
                Console.WriteLine("Error battle!");
            }
        }
    }
}