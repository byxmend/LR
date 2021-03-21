using System;

namespace WoT
{
    public class Tanks
    {
        private Tank[] _tanksSet;

        public Tanks()
        {
            _tanksSet = new Tank[3];
        }
        
        private Tank this[int index]
        {
            get => _tanksSet[index];
            set => _tanksSet[index] = value;
        }

        private int CheckInt()
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
                
                this[i] = new Tank(hitPoints, averageSpeed, damagePerMinute, name);
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