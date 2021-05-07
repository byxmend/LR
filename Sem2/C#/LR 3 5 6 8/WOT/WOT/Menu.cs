using System;

namespace WOT
{
    public class Menu
    {
        private readonly Program _program = new Program();

        private readonly HeavyTank _heavyTank = new HeavyTank();

        private readonly MediumTank _mediumTank = new MediumTank();

        private readonly LightTank _lightTank = new LightTank();

        public void GeneralMenu()
        {
            Console.WriteLine("\nSelect an action:\n1 - Fill tanks set\n2 - Show tanks set\n" +
                              "3 - Add standard equipment\n4 - Remove standard equipment\n5 - Add features\n" +
                              "6 - Battle\n7 - Unfair battle\n8 - Comparer tanks hitpoints\n9 - Clear console\nOther number - Turn off");
        }

        public void MenuAddFeatures(Tanks tanks, int[] array, int index)
        {
            Console.WriteLine("\nEnter hitPoints:");
            array[0] = _program.CheckInt();
            Console.WriteLine("Enter shots per minute:");
            array[1] = _program.CheckInt();
            Console.WriteLine("Enter damage per shot:");
            array[2] = _program.CheckInt();
            
            switch (index)
            {
                case 0:
                    _heavyTank.AddFeatures(tanks, array[0], array[1], array[2], index);
                    break;
                case 1:
                    _mediumTank.AddFeatures(tanks, array[0], array[1], array[2], index);
                    break;
                case 2:
                    _lightTank.AddFeatures(tanks, array[0], array[1], array[2], index);
                    break;
                default:
                    Console.WriteLine("Adding error");
                    break;
            }
        }
        
        public void MenuAddEquip(Tanks tanks, int index)
        {
            switch (index)
            {
                case 0:
                    tanks[index].AddEquip(tanks, index);
                    break;
                case 1:
                    tanks[index].AddEquip(tanks, index);
                    break;
                case 2:
                    tanks[index].AddEquip(tanks, index);
                    break;
                default:
                    Console.WriteLine("Adding error");
                    break;
            }
        }
        
        public void MenuDeleteEquip(Tanks tanks, int index)
        {
            switch (index)
            {
                case 0:
                    tanks[index].DeleteEquip(tanks, index);
                    break;
                case 1:
                    tanks[index].DeleteEquip(tanks, index);
                    break;
                case 2:
                    tanks[index].DeleteEquip(tanks, index);
                    break;
                default:
                    Console.WriteLine("Deletion error");
                    break;
            }
        }
    }
}