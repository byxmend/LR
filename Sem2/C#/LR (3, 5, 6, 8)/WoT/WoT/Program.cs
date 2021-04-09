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
            int firstChooseTank;
            int secondChooseTank;

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
                        tanks[tanks.ChooseTank()].AddEquip();
                        break;
                    case 4:
                        tanks[tanks.ChooseTank()].RemoveEquip();
                        break;
                    case 5:
                        tanks.MenuEquipment(array);
                        tanks[tanks.ChooseTank()].AddEquip(array[0], array[1], array[2]);
                        break;
                    case 6:
                        tanks.MenuEquipment(array);
                        tanks[tanks.ChooseTank()].RemoveEquip(array[0], array[1], array[2]);
                        break;
                    case 7:
                        // tank.Shoot(tanks[tanks.ChooseTank()]); // delete this method
                        break;
                    case 8:
                        firstChooseTank = tanks.ChooseTank();
                        secondChooseTank = tanks.ChooseTank();
                        tank.Battle(tanks[firstChooseTank], tanks[secondChooseTank], firstChooseTank, secondChooseTank);
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