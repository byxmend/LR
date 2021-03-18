using System;

namespace Tank
{
    public class Tank
    {
        public int AverageSpeed { get; set; }
        public int Caliber { get; }
        public int HitPoints { get; set; }
        public int DamagePerMinute { get; set; }
        public string Name { get; }
        public string Armor { get; }
        public string Id { get; }

        public Tank(int averageSpeed, int caliber, int hitPoints, int damagePerMinute, string name, string armor)
        {
            AverageSpeed = averageSpeed;
            Caliber = caliber;
            HitPoints = hitPoints;
            DamagePerMinute = damagePerMinute;
            Name = name;
            Armor = armor;
            Id = GenerationId();
        }

        public void AddEquipment()
        {
            AverageSpeed += 5;
            HitPoints += 165;
            DamagePerMinute += 186;
        }

        public void RemoveEquipment()
        {
            AverageSpeed -= 5;
            HitPoints -= 165;
            DamagePerMinute -= 186;
        }

        private static string GenerationId() => System.Guid.NewGuid().ToString();
    }
}