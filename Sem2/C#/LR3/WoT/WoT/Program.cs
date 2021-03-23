namespace WoT
{
    static class Program
    {
        static void Main()
        {
            Tanks tanks = new Tanks();
            Tank tank = new Tank();
            tanks.FillTanksSet();
            tanks.ShowTanksSet();
            //tanks[tank.ChooseTank()].AddEquip();
            //tanks.ShowTanksSet();
            //tanks[tank.ChooseTank()].RemoveEquip();
            //tanks.ShowTanksSet();
            //tank.Shoot(tanks[tank.ChooseTank()]);
            //tanks.ShowTanksSet();
            tank.Battle(tanks[tank.ChooseTank()], tanks[tank.ChooseTank()]);
        }
    }
}