using System;

namespace WOT
{
    public class Tanks
    {
        private readonly Tank[] _tanksSet;

        private readonly Program _program = new();

        private readonly MediumTank _mediumTank = new();

        private readonly HpComparer _hpComparer = new();

        public Tanks()
        {
            _tanksSet = new Tank[3];
        }

        public Tank this[int index]
        {
            get => _tanksSet[index];
            private set => _tanksSet[index] = value;
        }

        public int ChooseTank()
        {
            Console.WriteLine("\nChoose number of the tank:");

            for (int i = 0; i < 3; i++)
            {
                Console.Write(i + " ");
            }

            Console.WriteLine(": ");

            int a = _program.CheckInt();
            return a;
        }

        public void ShowComparerTanks(Tanks tanks)
		{
            Console.WriteLine("\n");

			if (_hpComparer.Compare(tanks[0], tanks[1]) == 1)
			{
                Console.WriteLine("Heavy tank HitPoints > Medium tank hitPoints");

                if (_hpComparer.Compare(tanks[0], tanks[2]) == 1)
				{
                    Console.WriteLine("Heavy tank HitPoints > Light tank hitPoints");
                }
				else if (_hpComparer.Compare(tanks[0], tanks[2]) == 0)
				{
                    Console.WriteLine("Heavy tank HitPoints = Light tank hitPoints");
                }
				else
				{
                    Console.WriteLine("Heavy tank HitPoints < Light tank hitPoints");
                }
			}
			else if (_hpComparer.Compare(tanks[0], tanks[1]) == 0)
			{
                Console.WriteLine("Heavy tank HitPoints = Medium tank hitPoints");

                if (_hpComparer.Compare(tanks[0], tanks[2]) == 1)
                {
                    Console.WriteLine("Heavy tank HitPoints > Light tank hitPoints");
                }
                else if (_hpComparer.Compare(tanks[0], tanks[2]) == 0)
                {
                    Console.WriteLine("Heavy tank HitPoints = Light tank hitPoints");
                }
                else
				{
                    Console.WriteLine("Heavy and Medium tanks HitPoints < Light tank hitPoints");
                }
            }
			else
			{
                Console.WriteLine("Heavy tank HitPoints < Medium tank hitPoints");

                if (_hpComparer.Compare(tanks[1], tanks[2]) == 1)
                {
                    Console.WriteLine("Medium tank HitPoints > Light tank hitPoints");
                }
                else if (_hpComparer.Compare(tanks[1], tanks[2]) == 0)
                {
                    Console.WriteLine("Medium tank HitPoints = Light tank hitPoints");
                }
                else
                {
                    Console.WriteLine("Heavy and Medium tanks HitPoints < Light tank hitPoints");
                }
            }
		}

        public void FillTanksSet(Tanks tanks)
        {
            for (int i = 0; i < 3; i++)
            {
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
                hitPoints = _program.CheckInt();
                Console.Write("Enter the number of shots fired per minute: ");
                shotsPerMinute = _program.CheckInt();
                Console.Write("Enter the name: ");
                name = Console.ReadLine();
                Console.Write("Enter the damage per shoot: ");
                damagePerShoot = _program.CheckInt();
                Console.WriteLine("Chose nation:\n1 - Germany\n2 - Russia\n3 - France\nOther - Multinational");
                nationInt = _program.CheckInt();

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
                        int armorRatio = _program.CheckInt();
                        tanks[i] = new HeavyTank(hitPoints, shotsPerMinute, name, damagePerShoot, nation, armorRatio);
                        break;
                    }
                    case 1:
                        Console.Write("Enter disguise: ");
                        int disguise = _program.CheckInt();
                        tanks[i] = new MediumTank(hitPoints, shotsPerMinute, name, damagePerShoot, nation, disguise);
                        break;
                    default:
                    {
                        Console.Write("Enter the damage from air support: ");
                        int damageAirSupport = _program.CheckInt();
                        Console.Write("Enter numbers of air support per minute: ");
                        int airSupportPerMinute = _program.CheckInt();

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
    }
}