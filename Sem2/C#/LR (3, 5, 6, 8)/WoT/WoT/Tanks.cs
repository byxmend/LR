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
            set => _tanksSet[index] = value;
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

        public int ChooseTank()
        {
            Console.WriteLine("\nChoose number of the tank:");

            for (int i = 0; i < 3; i++)
            {
                Console.Write(i + " ");
            }

            Console.WriteLine(": ");

            int a = CheckInt();
            return a;
        }

        public void Menu()
        {
            Console.WriteLine("\nSelect an action:\n1 - Fill tanks set\n2 - Show tanks set\n3 - Add standard equipment\n" +
                              "4 - Remove standard equipment\n5 - Add specific equipment\n6 - Battle\n7 - Clear console\n" +
                              "Other - Turn off");
        }

        public void MenuEquipment(Tanks tanks, int[] array)
        {
            Console.WriteLine("\nEnter hitPoints:");
            array[0] = CheckInt();
            Console.WriteLine("Enter shots per minute:");
            array[1] = CheckInt();
            Console.WriteLine("Enter damage per shot:");
            array[2] = CheckInt();
            
            AddFeatures(tanks, array[0], array[1], array[2]);
        }
        
        public override void AddFeatures(Tanks tanks, int hitPoints, int shotsPerMinute, int damagePerShot)
        {
            tanks[2].HitPoints += hitPoints;
            tanks[2].ShotsPerMinute += shotsPerMinute;
            tanks[2].DamagePerShoot += damagePerShot;
        }
        
        public virtual void FillTanksSet(Tanks tanks, int i)
        {
            int hitPoints;
            int shotsPerMinute;
            string name;
            int damagePerShoot;
            int nationInt;
            Nationality nation;

            Console.Write("Enter the hit points: ");
            hitPoints = CheckInt();
            Console.Write("Enter the number of shots fired per minute: ");
            shotsPerMinute = CheckInt();
            Console.Write("Enter the name: ");
            name = Console.ReadLine();
            Console.Write("Enter the damage per shoot: ");
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
                
            tanks[i] = new Tank(hitPoints, shotsPerMinute, name, damagePerShoot, nation);
            Console.Clear();
        }

        public virtual void ShowTanksSet(Tanks tanks, int i)
        {
            Console.WriteLine($"\nHitPoints: {tanks[i].HitPoints}\nShotsPerMinute: {tanks[i].ShotsPerMinute}\n" +
                              $"Name: {tanks[i].Name}\nId: {tanks[i].Id}\nDamagePerShoot: " +
                              $"{tanks[i].DamagePerShoot}\nNation: {tanks[i].Nation}\n");
        }
    }
}