using System;

namespace WOT
{
    public class Menu
    {
        private readonly HeavyTank heavyTank = new HeavyTank();

        private readonly MediumTank mediumTank = new MediumTank();

        private readonly LightTank lightTank = new LightTank();

        public void GeneralMenu()
        {
            Console.WriteLine("\nSelect an action:\n" +
                "1 - Fill tanks set\n" +
                "2 - Show tanks set\n" +
                "3 - Add standard equipment\n" +
                "4 - Remove standard equipment\n" +
                "5 - Add features\n" +
                "6 - Battle\n" +
                "7 - Unfair battle\n" +
                "8 - Comparer tanks hit points\n" +
                "9 - Clear console\n" +
                "Other number - Turn off");
        }

        public void MenuAddFeatures(Tanks tanks, int[] array, int index, Program.CheckNumberInteger checkNumberInteger)
        {
            int num = 0;
            Console.WriteLine("\nEnter hitPoints:");
            array[0] = checkNumberInteger(num);
            Console.WriteLine("Enter shots per minute:");
            array[1] = checkNumberInteger(num);
            Console.WriteLine("Enter damage per shot:");
            array[2] = checkNumberInteger(num);

            switch (index)
            {
                case 0:
                    heavyTank.AddFeatures(tanks, array[0], array[1], array[2], index);
                    break;
                case 1:
                    mediumTank.AddFeatures(tanks, array[0], array[1], array[2], index);
                    break;
                case 2:
                    lightTank.AddFeatures(tanks, array[0], array[1], array[2], index);
                    break;
                default:
                    Console.WriteLine("Adding error");
                    break;
            }
        }
        
        public void MenuAddEquip(Tanks tanks, int index)
        {
            try
            {
                tanks[index].AddEquip(tanks, index);
            }
            catch
            {
                Console.WriteLine("Out of range!");
            }
        }
        
        public void MenuDeleteEquip(Tanks tanks, int index)
        {
            try
            {
                tanks[index].DeleteEquip(tanks, index);
            }
            catch
            {
                Console.WriteLine("Out of range!");
            }
        }

        public int MenuCheckInteger(int num)
        {
            while (!int.TryParse(Console.ReadLine(), out num))
            {
                Console.Write("Invalid data, please try again: ");
            }
            return num;
        }

        public void ShowMessage(Tanks tanks, int index)
        {
            Console.WriteLine(Tanks.ShowInfoAboutTanks(tanks, index));
        }
    }
}