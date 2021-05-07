namespace WOT
{
    public interface ICalculatePoints
    {
        void NumberOfShotsToKillTank(Tanks tanks, ref int TankHp, ref int TankShots,
            ref int firstChooseTank, ref int secondChooseTank);
        
        void CalculateShotsRatio(Tanks tanks, ref int secondTankShots, ref int secondChooseTank,
            ref double shotRatio1, ref double shotRatio2, ref int firstTankShots, ref int firstChooseTank);

        void DeterminingTheWinner(ref double shotRatio1, ref double shotRatio2);
    }
}