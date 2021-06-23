using System;

namespace WOT
{
    public class Battle : IBattle
    {
        private readonly ICalculatePoints calculatePoints = new MaintainingBattle();

        private readonly IAbilities abilities = new MaintainingBattle();

        public void BattleBetweenTanks(Tanks tanks, int firstChooseTank, int secondChooseTank, Program.CheckNumberInteger checkNumberInteger)
        {
            try
            {
                int firstTankHp = tanks[firstChooseTank].HitPoints;
                int secondTankHp = tanks[secondChooseTank].HitPoints;
                int firstTankShots = 0, secondTankShots = 0;
                double shotRatio1 = 0, shotRatio2 = 0;

                if (tanks[firstChooseTank] != tanks[secondChooseTank])
                {
                    Console.WriteLine("\nBattle!\n");

                    abilities.BattleAirSupportLightTank(ref firstChooseTank, ref secondChooseTank, ref firstTankHp, ref secondTankHp);

                    abilities.BattleAimingMediumTank(ref firstChooseTank, ref secondChooseTank, ref firstTankShots, ref secondTankShots, checkNumberInteger);

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
            catch
            {
                Console.WriteLine("Error battle!");
            }
        }
    }
}