using System;

namespace WoT
{
    public class Tanks : InputOutput
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

        public int CheckInt()
        {
            int a;
            while (!int.TryParse(Console.ReadLine(), out a))
            {
                Console.Write("Invalid data, please try again: ");
            }
            return a;
        }

        public void Menu()
        {
            Console.WriteLine("\nSelect an action:\n1 - Fill tanks set\n2 - Show tanks set\n3 - Add standard equipment\n" +
                              "4 - Remove standard equipment\n5 - Add specific equipment\n6 - Remove specific equipment\n" +
                              "7 - Shoot\n8 - Battle\n9 - Clear console\n10 - Turn off");
        }

        public void MenuEquipment(int[] array)
        {
            Console.WriteLine("\nEnter hitPoints:");
            array[0] = CheckInt();
            Console.WriteLine("Enter hitPoints:");
            array[1] = CheckInt();
            Console.WriteLine("Enter hitPoints:");
            array[2] = CheckInt();
        }
        
        public override void FillTanksSet(int i)
        {
            int hitPoints;
            int shotsPerMinute;
            string name;
            int damagePerShoot;
            int nationInt;
            Nationality nation;

            Console.WriteLine("\nEnter the hit points:");
            hitPoints = CheckInt();
            Console.WriteLine("Enter the number of shots fired per minute:");
            shotsPerMinute = CheckInt();
            Console.WriteLine("Enter the name:");
            name = Console.ReadLine();
            Console.WriteLine("Enter the damage per shoot:");
            damagePerShoot = CheckInt();
            Console.WriteLine("Chose nation:\n1 - Germany\n2 - Russia\n3 - France\nOther - Multinational");
            nationInt = CheckInt();

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
                
            this[i] = new Tank(hitPoints, shotsPerMinute, name, damagePerShoot, nation);
            Console.Clear();
        }

        public override void ShowTanksSet()
        {
            for (int i = 0; i < 3; i++)
            {
                Console.WriteLine($"\nHitPoints: {this[i].HitPoints}\nShotsPerMinute: {this[i].ShotsPerMinute}\n" +
                                  $"Name: {this[i].Name}\nId: {this[i].Id}\nDamagePerShoot: " +
                                  $"{this[i].DamagePerShoot}\nNation: {this[i].Nation}\n");
            }
        }
    }
}