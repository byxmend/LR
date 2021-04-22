using System;

namespace WOT
{
    class Program
    {
        public int CheckInt()
        {
            int a;
            while (!int.TryParse(Console.ReadLine(), out a))
            {
                Console.Write("Invalid data, please try again: ");
            }
            return a;
        }
        
        static void Main(string[] args)
        {
            Program program = new Program();
            Menu menu = new Menu();
            Battle battle = new Battle();
            Tanks tanks = new Tanks();
            HeavyTank heavyTank = new HeavyTank();

            int[] array = new int[3];
            int firstChooseTank;
            int secondChooseTank;
            int index;
            
            tanks.FillTanksSet(tanks);
            tanks.ShowTanksSet(tanks);
            
            while (true)
            {
                menu.GeneralMenu();

                switch (program.CheckInt())
                {
                    case 1:
                        tanks.FillTanksSet(tanks);
                        break;
                    case 2:
                        tanks.ShowTanksSet(tanks);
                        break;
                    case 3:
                        index = tanks.ChooseTank();
                        menu.MenuAddEquip(tanks, index);
                        break;
                    case 4:
                        index = tanks.ChooseTank();
                        menu.MenuDeleteEquip(tanks, index);
                        break;
                    case 5:
                        index = tanks.ChooseTank();
                        menu.MenuAddFeatures(tanks, array, index);
                        break;
                    case 6:
                        firstChooseTank = tanks.ChooseTank();
                        secondChooseTank = tanks.ChooseTank();
                        battle.BattleBetweenTanks(tanks, firstChooseTank, secondChooseTank);
                        break;
                    case 7:
                        Console.Clear();
                        break;
                    default:
                        return;
                }
            }
        }
    }
}