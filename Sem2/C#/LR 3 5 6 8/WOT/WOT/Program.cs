using System;

namespace WOT
{
    class Program
    {
        static void Main(string[] args)
        {
            Menu menu = new Menu();
            Tanks tanks = new Tanks();

            IBattle battle = new Battle();
            IBattle unfairBattle = new UnfairBattle();

            int[] array = new int[3];
            int firstChooseTank, secondChooseTank;
            int index;
            
            tanks.FillTanksSet(tanks);
            tanks.ShowTanksSet(tanks);
            
            while (true)
            {
                menu.GeneralMenu();

                switch (menu.MenuCheckInt())
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
                        firstChooseTank = tanks.ChooseTank();
                        secondChooseTank = tanks.ChooseTank();
                        unfairBattle.BattleBetweenTanks(tanks, firstChooseTank, secondChooseTank);
                        break;
                    case 8:
                        tanks.ShowComparerTanksHp(tanks);
                        break;
                    case 9:
                        Console.Clear();
                        break;
                    default:
                        return;
                }
            }
        }
    }
}