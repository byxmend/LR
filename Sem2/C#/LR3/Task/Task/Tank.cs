using System;

namespace Task
{
    public class Tank
    {
        public int AverageSpeed { get; private set; }
        public int Caliber { get; }
        public int HitPoints { get; private set; }
        public int DamagePerMinute { get; private set; }
        public string Name { get; }
        public string Armor { get; }
        public string Id { get; }
        private bool Equipment { get; set; }

        public Tank(int averageSpeed, int caliber, int hitPoints, int damagePerMinute, string name, string armor)
        {
            AverageSpeed = averageSpeed;
            Caliber = caliber;
            HitPoints = hitPoints;
            DamagePerMinute = damagePerMinute;
            Name = name;
            Armor = armor;
            Equipment = false;
            Id = GenerationId();
        }

        public void AddEquipment()
        {
            if (!Equipment)
            {
                AverageSpeed += 10;
                HitPoints += 300;
                DamagePerMinute += 300;
                Equipment = true;
            }
            else
            {
                Console.WriteLine("You can't install the equipment twice");
            }
        }

        public void RemoveEquipment()
        {
            if (Equipment)
            {
                AverageSpeed -= 10;
                HitPoints -= 300;
                DamagePerMinute -= 300;
                Equipment = false;
            }
            else
            {
                Console.WriteLine("There is no equipment on the tank anyway");
            }
        }

        //private static string GenerationId() => System.Guid.NewGuid().ToString();
    }
}