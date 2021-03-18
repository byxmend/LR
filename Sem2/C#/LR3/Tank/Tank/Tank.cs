using System;

namespace Tank
{
    public class Tank
    {
        private int AverageSpeed { get; set; }
        private int Caliber { get; }
        private int HitPoints { get; set; }
        private int DamagePerMinute { get; set; }
        private string Name { get; }
        private string Armor { get; }
        private string Id { get; }

        public Tank()
        {
            AverageSpeed = 30;
            Caliber = 150;
            HitPoints = 2750;
            DamagePerMinute = 2465;
            Name = "E100";
            Armor = "good";
            Id = GenerationId();
        }

        public void AddEquipment()
        {
            if (AverageSpeed == 35)
            {
                Console.WriteLine("There is equipment on the tank");
            }
            else
            {
                AverageSpeed += 5;
                HitPoints += 165;
                DamagePerMinute += 186;
            }
        }

        public void RemoveEquipment()
        {
            if (AverageSpeed == 30)
            {
                Console.WriteLine("There is no equipment on the tank");
            }
            else
            {
                AverageSpeed -= 5;
                HitPoints -= 165;
                DamagePerMinute -= 186;
            }
        }

        public void Output()
        {
            Console.WriteLine($"\nAverageSpeed: {AverageSpeed}\nCaliber: {Caliber}\nHitPoints: {HitPoints}\n" +
                              $"DamagePerMinute: {DamagePerMinute}\nName: {Name}\nArmor: {Armor}\nId: {Id}");
        }

        private static string GenerationId() => System.Guid.NewGuid().ToString();
    }
}