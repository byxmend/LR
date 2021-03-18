using System;

namespace Tank
{
    class Program
    {
        static void TanksFill(ref Tank[] array)
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
        
        private static void Meny()
        {
            Console.WriteLine("\n1 - add equipment\n2 - remove equipment\n3 - output all tanks\n4 - turn off");
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
            for (int i = 0; i < array.Length; i++)
            {
                Console.WriteLine($"\nAverageSpeed: {array[i].AverageSpeed}\nCaliber: {array[i].Caliber}\n" +
                                  $"HitPoints: {array[i].HitPoints}\nDamagePerMinute: {array[i].DamagePerMinute}\n" +
                                  $"Name: {array[i].Name}\nArmor: {array[i].Armor}\nId: {array[i].Id}");
            }
        }

        static int ChooseTanks(Tank[] array)
        {
            int a;
            Console.WriteLine("Choose number of the tank: ");
            for (int i = 0; i < array.Length; i++)
            {
                Console.Write((i + 1) + " ");
            }

            a = CheckInt();
            return (a - 1);
        }

        static void Main(string[] args)
        {
            int a, n;
            Console.WriteLine("How many tanks?");
            n = CheckInt();

            Tank[] tanksSet = new Tank[n];
            TanksFill(ref tanksSet);
            ShowTanksSet(tanksSet);
            
            while (true)
            {
                Console.Clear();
                Meny();
                a = CheckInt();

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