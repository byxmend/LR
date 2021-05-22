using System;

namespace WOT
{
    public class Program
    {
        public delegate int CheckNumberInteger(int num);

        static void Main(string[] args)
        {
            Menu menu = new Menu();
            Tanks tanks = new Tanks();
            
            IBattle battle = new Battle();
            IBattle unfairBattle = new UnfairBattle();

            CheckNumberInteger checkNumberInteger = menu.MenuCheckInteger;

            int[] array = new int[3];
            int firstChooseTank, secondChooseTank;
            int index, meaning = 0;
            
            tanks.FillTanksSet(tanks, checkNumberInteger);
            tanks.ShowTanksSet(tanks);
            
            while (true)
            {
                menu.GeneralMenu();

                switch (checkNumberInteger(meaning))
                {
                    case 1:
                        tanks.FillTanksSet(tanks, checkNumberInteger);
                        break;
                    case 2:
                        tanks.ShowTanksSet(tanks);
                        break;
                    case 3:
                        index = tanks.ChooseTank(checkNumberInteger);
                        menu.MenuAddEquip(tanks, index);
                        break;
                    case 4:
                        index = tanks.ChooseTank(checkNumberInteger);
                        menu.MenuDeleteEquip(tanks, index);
                        break;
                    case 5:
                        index = tanks.ChooseTank(checkNumberInteger);
                        menu.MenuAddFeatures(tanks, array, index, checkNumberInteger);
                        break;
                    case 6:
                        firstChooseTank = tanks.ChooseTank(checkNumberInteger);
                        secondChooseTank = tanks.ChooseTank(checkNumberInteger);
                        battle.BattleBetweenTanks(tanks, firstChooseTank, secondChooseTank, checkNumberInteger);
                        break;
                    case 7:
                        firstChooseTank = tanks.ChooseTank(checkNumberInteger);
                        secondChooseTank = tanks.ChooseTank(checkNumberInteger);
                        unfairBattle.BattleBetweenTanks(tanks, firstChooseTank, secondChooseTank, checkNumberInteger);
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