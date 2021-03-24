using System;

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
            
            int[] array = new int[3];

            while (true)
            {
                tanks.Menu();
                
                switch (tanks.CheckInt())
                {
                    case 1:
                        tanks.FillTanksSet();
                        break;
                    case 2:
                        tanks.ShowTanksSet();
                        break;
                    case 3:
                        tanks[tank.ChooseTank()].AddEquip();
                        break;
                    case 4:
                        tanks[tank.ChooseTank()].RemoveEquip();
                        break;
                    case 5:
                        tanks.MenuEquipment(array);
                        tanks[tank.ChooseTank()].AddEquip(array[0], array[1], array[2]); // Check
                        break;
                    case 6:`
                        tanks.MenuEquipment(array);
                        tanks[tank.ChooseTank()].RemoveEquip(array[0], array[1], array[2]); // Check
                        break;
                    case 7:
                        tank.Shoot(tanks[tank.ChooseTank()]);
                        break;
                    case 8:
                        tank.Battle(tanks[tank.ChooseTank()], tanks[tank.ChooseTank()]);
                        break;
                    case 9:
                        Console.Clear();
                        break;
                    case 10:
                        return;
                }
            }
        }
    }
}