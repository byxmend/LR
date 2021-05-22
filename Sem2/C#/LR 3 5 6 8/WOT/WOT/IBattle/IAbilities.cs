namespace WOT
{
    public interface IAbilities
    {
        void BattleAirSupportLightTank(ref int firstChooseTank, ref int secondChooseTank,
            ref int firstTankHp,  ref int secondTankHp);

        void BattleAimingMediumTank(ref int firstChooseTank, ref int secondChooseTank,
            ref int firstTankShots, ref int secondTankShots, Program.CheckNumberInteger checkNumberInteger);
    }
}