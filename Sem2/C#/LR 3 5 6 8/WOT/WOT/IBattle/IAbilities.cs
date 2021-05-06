namespace WOT
{
    public interface IAbilities
    {
        // AirSupport for light tank
        void BattleAirSupportLightTank(ref int firstChooseTank, ref int secondChooseTank,
            ref int firstTankHp,  ref int secondTankHp);

        // Aiming for the medium tank
        void BattleAimingMediumTank(ref int firstChooseTank, ref int secondChooseTank,
            ref int firstTankShots, ref int secondTankShots);
    }
}