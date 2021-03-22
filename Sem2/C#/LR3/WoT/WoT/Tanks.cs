using System;

namespace WoT
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

        public int CheckInt()
        {
            int a;
            while (!int.TryParse(Console.ReadLine(), out a))
            {
                Console.Write("Invalid data, please try again: ");
            }
            return a;
        }
        
        public void FillTanksSet()
        {
            int hitPoints;
            int averageSpeed;
            int damagePerMinute;
            string name;
            int ammunition;

            for (int i = 0; i < 3; i++)
            {
                Console.WriteLine("Enter the hit points:");
                hitPoints = CheckInt();
                Console.WriteLine("Enter the average speed:");
                averageSpeed = CheckInt();
                Console.WriteLine("Enter the damage per minute:");
                damagePerMinute = CheckInt();
                Console.WriteLine("Enter the name:");
                name = Console.ReadLine();
                Console.WriteLine("Enter the ammunition size:");
                ammunition = CheckInt();
                
                this[i] = new Tank(hitPoints, averageSpeed, damagePerMinute, name, ammunition);
                Console.Clear();
            }
        }

        public void ShowTanksSet()
        {
            for (int i = 0; i < 3; i++)
            {
                Console.WriteLine($"\nHitPoints: {this[i].HitPoints}\nAverageSpeed: {this[i].AverageSpeed}\n" +
                                  $"DamagePerMinute: {this[i].DamagePerMinute}\nName: {this[i].Name}\nId: {this[i].Id}");
            }
        }
    }
}