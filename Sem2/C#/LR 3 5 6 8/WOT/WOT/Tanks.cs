using System;

namespace WOT
{
    public class Tanks
    {
        private readonly Tank[] _tanksSet;

        public Tanks()
        {
            _tanksSet = new Tank[3];
        }

        public Tank this[int index]
        {
            get => _tanksSet[index];
            private set => _tanksSet[index] = value;
        }

        public int ChooseTank(Program.CheckNumberInteger checkNumberInteger)
        {
            Console.WriteLine("\nChoose number of the tank:");

            for (int i = 0; i < 3; i++)
            {
                Console.Write(i + " ");
            }

            Console.WriteLine(": ");

            int num = 0;
            int returnValue = checkNumberInteger(num);

            return returnValue;
        }

        public void ShowComparerTanksHp(Tanks tanks)
        {
            Array.Sort(tanks._tanksSet, new HpComparer());

            Console.WriteLine("\n");

            for (int i = 0; i < 3; i++)
                Console.WriteLine(tanks[i].HitPoints);
        }

        public void FillTanksSet(Tanks tanks, Program.CheckNumberInteger checkNumberInteger)
        {
            for (int i = 0; i < 3; i++)
            {
                int num = 0;
                int hitPoints;
                int shotsPerMinute;
                string name;
                int damagePerShoot;
                int nationInt;
                Nationality nation;
                
                switch (i)
                {
                    case 0:
                        Console.Write("\nHeavy tank");
                        break;
                    case 1:
                        Console.Write("\nMedium tank");
                        break;
                    default:
                        Console.Write("\nLight tank");
                        break;
                }

                Console.Write("\nEnter the hit points: ");
                hitPoints = checkNumberInteger(num);
                Console.Write("Enter the number of shots fired per minute: ");
                shotsPerMinute = checkNumberInteger(num);
                Console.Write("Enter the name: ");
                name = Console.ReadLine();
                Console.Write("Enter the damage per shoot: ");
                damagePerShoot = checkNumberInteger(num);
                Console.WriteLine("Chose nation:\n1 - Germany\n2 - Russia\n3 - France\nOther - Multinational");
                nationInt = checkNumberInteger(num);

                switch (nationInt)
                {
                    case 1:
                        nation = Nationality.Germany;
                        break;
                    case 2:
                        nation = Nationality.Russia;
                        break;
                    case 3:
                        nation = Nationality.France;
                        break;
                    default:
                        nation = Nationality.Multinational;
                        break;
                }

                switch (i)
                {
                    case 0:
                    {
                        Console.Write("Enter the armor ratio: ");
                        int armorRatio = checkNumberInteger(num);
                        tanks[i] = new HeavyTank(hitPoints, shotsPerMinute, name, damagePerShoot, nation, armorRatio);
                        break;
                    }
                    case 1:
                        Console.Write("Enter disguise: ");
                        int disguise = checkNumberInteger(num);
                        tanks[i] = new MediumTank(hitPoints, shotsPerMinute, name, damagePerShoot, nation, disguise);
                        break;
                    default:
                    {
                        Console.Write("Enter the damage from air support: ");
                        int damageAirSupport = checkNumberInteger(num);
                        Console.Write("Enter numbers of air support per minute: ");
                        int airSupportPerMinute = checkNumberInteger(num);

                        tanks[i] = new LightTank(hitPoints, shotsPerMinute, name, damagePerShoot, nation,
                            damageAirSupport, airSupportPerMinute);
                        break;
                    }
                }
            }

            Console.Clear();
        }
        
        public void ShowTanksSet(Tanks tanks)
        {
            for (int i = 0; i < 3; i++)
            {
                switch (i)
                {
                    case 0:
                        Console.WriteLine($"\nHeavy tank:\n\nHitPoints: {tanks[i].HitPoints}\nShotsPerMinute: {tanks[i].ShotsPerMinute}\n" +
                                          $"Name: {tanks[i].Name}\nDamagePerShoot: {tanks[i].DamagePerShoot}\nNation: " +
                                          $"{tanks[i].Nation}\nArmor ratio: {tanks[i].ArmorRatio}");
                        break;
                    case 1:
                        Console.WriteLine($"\nMedium tank:\n\nHitPoints: {tanks[i].HitPoints}\nShotsPerMinute: {tanks[i].ShotsPerMinute}\n" +
                                          $"Name: {tanks[i].Name}\nDamagePerShoot: {tanks[i].DamagePerShoot}\nNation: " +
                                          $"{tanks[i].Nation}\nDisguise: {tanks[i].Disguise}");
                        break;
                    default:
                        Console.WriteLine($"\nLight tank:\n\nHitPoints: {tanks[i].HitPoints}\nShotsPerMinute: {tanks[i].ShotsPerMinute}\n" +
                                          $"Name: {tanks[i].Name}\nDamagePerShoot: {tanks[i].DamagePerShoot}\nNation: " +
                                          $"{tanks[i].Nation}\nArmor ratio: {tanks[i].ArmorRatio}\nDamage air support: " +
                                          $"{tanks[i].DamageAirSupport}\nNumbers of air support per minute: " +
                                          $"{tanks[i].AirSupportPerMinute}");
                        break;
                }
            }
        }

        public static string ShowInfoAboutTanks(Tanks tanks, int index)
        {
            if (index >= 0 && index < 3)
            {
                string message = ($"\nTank {index}:\n\nHitPoints: {tanks[index].HitPoints}" +
            $"\nShotsPerMinute: {tanks[index].ShotsPerMinute}\nName: {tanks[index].Name}" +
            $"\nDamagePerShoot: {tanks[index].DamagePerShoot}");

                return message;
            }
            else
            {
                string errorMessage = "Error: out of array range";

                return errorMessage;
            }

        }
    }
}