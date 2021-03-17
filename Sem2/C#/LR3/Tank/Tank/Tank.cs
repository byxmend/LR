using System;

namespace Tank
{
    public class Tank
    {
        public int AverageSpeed;
        public int Caliber;
        public int HitPoints;
        public int DamagePerMinute;
        public string Name;
        public string Armor;
        //private string ID;

        public Tank()
        {
            AverageSpeed = 30;
            Caliber = 150;
            HitPoints = 2750;
            DamagePerMinute = 2465;
            Name = "E100";
            Armor = "good"; // bad, average, good
        }
        
        public Tank(int averageSpeed = 0, int caliber = 0, int hp = 0, int dpm = 0, string name = "", string armor = "")
        {
            AverageSpeed = averageSpeed;
            Caliber = caliber;
            HitPoints = hp;
            DamagePerMinute = dpm;
            Name = name;
            Armor = armor;
        }
        
        public void AddEquipment()
        {
            AverageSpeed += 5;
            HitPoints += 165;
            DamagePerMinute += 186;
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
    }
}