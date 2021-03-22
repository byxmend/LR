using System;

namespace WoT
{
    static class Program
    {
        static void Main(string[] args)
        {
            Tanks tanks = new Tanks();
            Tank tank = new Tank();
            tanks.FillTanksSet();
            tanks.ShowTanksSet();
            tanks[tank.ChooseTank()].AddEquip();
            tanks.ShowTanksSet();
            tanks[tank.ChooseTank()].RemoveEquip();
            tanks.ShowTanksSet();
            tank.Shoot(tanks[tank.ChooseTank()]);
            tanks.ShowTanksSet();
        }
    }
}