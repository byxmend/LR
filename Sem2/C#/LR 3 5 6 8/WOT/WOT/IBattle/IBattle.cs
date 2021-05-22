namespace WOT
{
    interface IBattle
    {
        public void BattleBetweenTanks(Tanks tanks, int firstChooseTank, int secondChooseTank, Program.CheckNumberInteger checkNumberInteger);
    }
}