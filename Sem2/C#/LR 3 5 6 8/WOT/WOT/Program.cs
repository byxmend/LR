using System;

namespace WOT
{
    public class Program
    {
        public delegate int CheckNumberInteger(int num);

        public delegate void ClearConsole();

        public delegate void ShowInfoAboutTanksInBattle(Tanks tanks, int index);

        public static event ShowInfoAboutTanksInBattle EventShowInfoAbotTanksInBattle;

        static void Main(string[] args)
        {
            Menu menu = new Menu();
            Tanks tanks = new Tanks();
            
            IBattle battle = new Battle();
            IBattle unfairBattle = new UnfairBattle();

            CheckNumberInteger checkNumberInteger = menu.MenuCheckInteger;
            ClearConsole clearConsole = () => Console.Clear();

            EventShowInfoAbotTanksInBattle += menu.ShowMessage;

            int[] array = new int[3];
            int firstChooseTank, secondChooseTank;
            int index, meaning = 0;

            Console.WriteLine("Fill information about tanks");
            tanks.FillTanksSet(tanks, checkNumberInteger);
            tanks.ShowTanksSet(tanks);
            
            while (true)
            {
                menu.GeneralMenu();

                switch (checkNumberInteger(meaning))
                {
                    case 1:
                        clearConsole();
                        tanks.FillTanksSet(tanks, checkNumberInteger);
                        break;
                    case 2:
                        clearConsole();
                        tanks.ShowTanksSet(tanks);
                        break;
                    case 3:
                        clearConsole();
                        index = tanks.ChooseTank(checkNumberInteger);
                        menu.MenuAddEquip(tanks, index);
                        break;
                    case 4:
                        clearConsole();
                        index = tanks.ChooseTank(checkNumberInteger);
                        menu.MenuDeleteEquip(tanks, index);
                        break;
                    case 5:
                        clearConsole();
                        index = tanks.ChooseTank(checkNumberInteger);
                        menu.MenuAddFeatures(tanks, array, index, checkNumberInteger);
                        break;
                    case 6:
                        clearConsole();
                        firstChooseTank = tanks.ChooseTank(checkNumberInteger);
                        secondChooseTank = tanks.ChooseTank(checkNumberInteger);
                        EventShowInfoAbotTanksInBattle(tanks, firstChooseTank);
                        EventShowInfoAbotTanksInBattle(tanks, secondChooseTank);
                        battle.BattleBetweenTanks(tanks, firstChooseTank, secondChooseTank, checkNumberInteger);
                        break;
                    case 7:
                        clearConsole();
                        firstChooseTank = tanks.ChooseTank(checkNumberInteger);
                        secondChooseTank = tanks.ChooseTank(checkNumberInteger);
                        EventShowInfoAbotTanksInBattle(tanks, firstChooseTank);
                        EventShowInfoAbotTanksInBattle(tanks, secondChooseTank);
                        unfairBattle.BattleBetweenTanks(tanks, firstChooseTank, secondChooseTank, checkNumberInteger);
                        break;
                    case 8:
                        clearConsole();
                        tanks.ShowComparerTanksHp(tanks);
                        break;
                    case 9:
                        clearConsole();
                        break;
                    default:
                        return;
                }
            }
        }
    }
}