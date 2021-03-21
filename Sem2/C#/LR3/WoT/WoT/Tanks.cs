using System;

namespace WoT
{
    public class Tanks
    {
        private int HitPoints { get; set; }
        private int AverageSpeed { get; set; }
        private int DamagePerMinute { get; set; }
        private string Name { get; }
        private string Id { get; }
        private bool Equipment { get; set; }

        public Tanks() {}
        
        private Tanks(int hitPoints, int averageSpeed, int damagePerMinute, string name)
        {
            HitPoints = hitPoints;
            AverageSpeed = averageSpeed;
            DamagePerMinute = damagePerMinute;
            Name = name;
            Equipment = false;
            Id = GenerationId();
        }
        
        private static string GenerationId() => Guid.NewGuid().ToString();
        
        private Tanks[] _tanksSet = new Tanks[3];

        public Tanks this[int index]
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

                _tanksSet[i] = new Tanks(hitPoints, averageSpeed, damagePerMinute, name);
                Console.Clear();
            }
        }

        public void L()
        {
            Console.WriteLine(_tanksSet.Length);
        }

        public void ShowTanksSet()
        {
            for (int i = 0; i < 3; i++)
            {
                Console.WriteLine($"\nHitPoints: {_tanksSet[i].HitPoints}\nAverageSpeed: {_tanksSet[i].AverageSpeed}\n" +
                                  $"DamagePerMinute: {_tanksSet[i].DamagePerMinute}\nName: {_tanksSet[i].Name}\nId: {_tanksSet[i].Id}");
            }
        }
        
        public void Equip()
        {
            if (!Equipment)
            {
                AverageSpeed += 10;
                HitPoints += 500;
                DamagePerMinute += 500;
                Equipment = true;
            }
            else
            {
                Console.WriteLine("You can't install the equipment twice");
            }
        }

        public void UnEquip()
        {
            if (Equipment)
            {
                AverageSpeed -= 10;
                HitPoints -= 500;
                DamagePerMinute -= 500;
                Equipment = false;
            }
            else
            {
                Console.WriteLine("There is no equipment on the tank anyway");
            }
        }
    }
}