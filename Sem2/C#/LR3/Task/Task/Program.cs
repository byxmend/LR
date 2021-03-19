using System;

namespace Task
{
    class Program
    {
        static void FillTanksSet(ref Tank[] array)
        {
            int AverageSpeed;
            int Caliber;
            int HitPoints;
            int DamagePerMinute;
            string Name;
            string Armor;

            for (int i = 0; i < array.Length; i++)
            {
                Console.WriteLine("Enter the average speed:");
                AverageSpeed = CheckInt();
                Console.WriteLine("Enter the caliber:");
                Caliber = CheckInt();
                Console.WriteLine("Enter the hit points:");
                HitPoints = CheckInt();
                Console.WriteLine("Enter the damage per minute:");
                DamagePerMinute = CheckInt();
                Console.WriteLine("Enter the name:");
                Name = Console.ReadLine();
                Console.WriteLine("Enter the armor:");
                Armor = Console.ReadLine();

                array[i] = new Tank(AverageSpeed, Caliber, HitPoints, DamagePerMinute, Name, Armor);
                Console.Clear();
            }
        }

        private static void Menu()
        {
            Console.WriteLine("\n1 - Add equipment\n2 - Remove equipment\n3 - Output all tanks\n4 - Turn off\n");
        }

        static int CheckInt()
        {
            int a;
            while (!int.TryParse(Console.ReadLine(), out a))
            {
                Console.Write("Invalid data, please try again: ");
            }
            return a;
        }

        static void ShowTanksSet(Tank[] array)
        {
            foreach (var t in array)
            {
                Console.WriteLine($"\nAverageSpeed: {t.AverageSpeed}\nCaliber: {t.Caliber}\n" +
                                  $"HitPoints: {t.HitPoints}\nDamagePerMinute: {t.DamagePerMinute}\n" +
                                  $"Name: {t.Name}\nArmor: {t.Armor}\nId: {t.Id}");
            }
        }

        static int ChooseTanks(Tank[] array)
        {
            Console.WriteLine("Choose number of the tank: ");
            for (int i = 0; i < array.Length; i++)
            {
                Console.Write((i + 1) + " ");
            }
            Console.WriteLine(":");

            int a = CheckInt();
            return (a - 1);
        }

        static void Main(string[] args)
        {
            Console.WriteLine("How many tanks?");
            int n = CheckInt();

            Tank[] tanksSet = new Tank[n];
            FillTanksSet(ref tanksSet);
            ShowTanksSet(tanksSet);

            while (true)
            {
                Menu();
                int a = CheckInt();

                switch (a)
                {
                    case 1:
                        tanksSet[ChooseTanks(tanksSet)].AddEquipment();
                        break;
                    case 2:
                        tanksSet[ChooseTanks(tanksSet)].RemoveEquipment();
                        break;
                    case 3:
                        ShowTanksSet(tanksSet);
                        break;
                    case 4:
                        return;
                    default:
                        Console.WriteLine("You entered an invalid value, you can try again");
                        break;
                }
            }
        }
    }
}