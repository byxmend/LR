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
            int shotsPerMinute;
            string name;
            int ammunition;
            int damagePerShoot;

            for (int i = 0; i < 3; i++)
            {
                Console.WriteLine("Enter the hit points:");
                hitPoints = CheckInt();
                Console.WriteLine("Enter the number of shots fired per minute:");
                shotsPerMinute = CheckInt();
                Console.WriteLine("Enter the name:");
                name = Console.ReadLine();
                Console.WriteLine("Enter the ammunition size:");
                ammunition = CheckInt();
                Console.WriteLine("Enter the damage per shoot:");
                damagePerShoot = CheckInt();
                
                this[i] = new Tank(hitPoints, shotsPerMinute, name, ammunition, damagePerShoot);
                Console.Clear();
            }
        }

        public void ShowTanksSet()
        {
            for (int i = 0; i < 3; i++)
            {
                Console.WriteLine($"\nHitPoints: {this[i].HitPoints}\nShotsPerMinute: {this[i].ShotsPerMinute}\n" +
                                  $"Name: {this[i].Name}\nId: {this[i].Id}\nAmmunition: {this[i].Ammunition}\n" +
                                  $"DamagePerShoot: {this[i].DamagePerShoot}");
            }
        }
    }
}