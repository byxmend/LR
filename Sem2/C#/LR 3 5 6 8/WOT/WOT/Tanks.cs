using System;

namespace WOT
{
    public class Tanks
    {
        private readonly Tank[] tanksSet;

        public Tanks()
        {
            tanksSet = new Tank[3];
        }

        public Tank this[int index]
        {
            get => tanksSet[index];
            private set => tanksSet[index] = value;
        }

        public int ChooseTank(Program.CheckNumberInteger checkNumberInteger)
        {
            int numberThatUsedForCheckedOnInt = 0;

            Console.WriteLine("\nChoose number of the tank:");

            for (int i = 0; i < 3; i++)
            {
                Console.Write(i + " ");
            }

            Console.WriteLine(": ");

            return checkNumberInteger(numberThatUsedForCheckedOnInt);
        }

        public void ShowComparerTanksHp(Tanks tanks)
        {
            Array.Sort(tanks.tanksSet, new HpComparer());

            Console.WriteLine("\n");

            for (int i = 0; i < 3; i++)
            {
                Console.WriteLine(tanks[i].HitPoints);
            }
        }

        public void FillTanksSet(Tanks tanks, Program.CheckNumberInteger checkNumberInteger)
        {
            for (int i = 0; i < 3; i++)
            {
                int numberThatUsedForCheckedOnInt = 0, hitPoints, shotsPerMinute, damagePerShoot, nationInt;
                string name;
                Nationality nation;

                if (i == 0)
                {
                    Console.Write("\nHeavy tank");
                }
                else if (i == 1)
                {
                    Console.Write("\nMedium tank");
                }
                else
                {
                    Console.Write("\nLight tank");
                }

                Console.Write("\nEnter the hit points: ");
                hitPoints = checkNumberInteger(numberThatUsedForCheckedOnInt);
                Console.Write("Enter the number of shots fired per minute: ");
                shotsPerMinute = checkNumberInteger(numberThatUsedForCheckedOnInt);
                Console.Write("Enter the name: ");
                name = Console.ReadLine();
                Console.Write("Enter the damage per shoot: ");
                damagePerShoot = checkNumberInteger(numberThatUsedForCheckedOnInt);
                Console.WriteLine("Chose nation:\n1 - Germany\n2 - Russia\n3 - France\nOther - Multinational");
                nationInt = checkNumberInteger(numberThatUsedForCheckedOnInt);

                if (nationInt == 1)
                {
                    nation = Nationality.Germany;
                }
                else if (nationInt == 2)
                {
                    nation = Nationality.Russia;
                }
                else if (nationInt == 3)
                {
                    nation = Nationality.France;
                }
                else
                {
                    nation = Nationality.Multinational;
                }

                // Initialization fields of the tank
                if (i == 0)
                {
                    Console.Write("Enter the armor ratio: ");
                    int armorRatio = checkNumberInteger(numberThatUsedForCheckedOnInt);

                    tanks[i] = new HeavyTank(hitPoints, shotsPerMinute, name, damagePerShoot, nation, armorRatio);
                }
                else if (i == 1)
                {
                    Console.Write("Enter disguise: ");
                    int disguise = checkNumberInteger(numberThatUsedForCheckedOnInt);

                    tanks[i] = new MediumTank(hitPoints, shotsPerMinute, name, damagePerShoot, nation, disguise);
                }
                else
                {
                    Console.Write("Enter the damage from air support: ");
                    int damageAirSupport = checkNumberInteger(numberThatUsedForCheckedOnInt);
                    Console.Write("Enter numbers of air support per minute: ");
                    int airSupportPerMinute = checkNumberInteger(numberThatUsedForCheckedOnInt);

                    tanks[i] = new LightTank(hitPoints, shotsPerMinute, name, damagePerShoot, nation,
                        damageAirSupport, airSupportPerMinute);
                }
            }

            Console.Clear();
        }
        
        public void ShowTanksSet(Tanks tanks)
        {
            for (int i = 0; i < 3; i++)
            {
                if (i == 0)
                {
                    Console.WriteLine($"\nHeavy tank:\n\n" +
                        $"HitPoints: {tanks[i].HitPoints}\n" +
                        $"ShotsPerMinute: {tanks[i].ShotsPerMinute}\n" +
                        $"Name: {tanks[i].Name}\n" +
                        $"DamagePerShoot: {tanks[i].DamagePerShoot}\n" +
                        $"Nation: {tanks[i].Nation}\n" +
                        $"Armor ratio: {tanks[i].ArmorRatio}");
                }
                else if (i == 1)
                {
                    Console.WriteLine($"\nMedium tank:\n\n" +
                        $"HitPoints: {tanks[i].HitPoints}\n" +
                        $"ShotsPerMinute: {tanks[i].ShotsPerMinute}\n" +
                        $"Name: {tanks[i].Name}\n" +
                        $"DamagePerShoot: {tanks[i].DamagePerShoot}\n" +
                        $"Nation: {tanks[i].Nation}\n" +
                        $"Disguise: {tanks[i].Disguise}");
                }
                else
                {
                    Console.WriteLine($"\nLight tank:\n\n" +
                        $"HitPoints: {tanks[i].HitPoints}\n" +
                        $"ShotsPerMinute: {tanks[i].ShotsPerMinute}\n" +
                        $"Name: {tanks[i].Name}\n" +
                        $"DamagePerShoot: {tanks[i].DamagePerShoot}\n" +
                        $"Nation: {tanks[i].Nation}\n" +
                        $"Armor ratio: {tanks[i].ArmorRatio}\n" +
                        $"Damage air support: {tanks[i].DamageAirSupport}\n" +
                        $"Numbers of air support per minute: {tanks[i].AirSupportPerMinute}");
                }
            }
        }

        public static string ShowInfoAboutTanks(Tanks tanks, int index)
        {
            try
            {
                return ($"\nTank {index}:\n\n" +
                    $"HitPoints: {tanks[index].HitPoints}\n" +
                    $"ShotsPerMinute: {tanks[index].ShotsPerMinute}\n" +
                    $"Name: {tanks[index].Name}\n" +
                    $"DamagePerShoot: {tanks[index].DamagePerShoot}");
            }
            catch (Exception)
            {
                return "Error: out of array range";
            }
        }
    }
}