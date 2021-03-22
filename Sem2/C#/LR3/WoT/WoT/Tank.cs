using System;

namespace WoT
{
    public class Tank
    {
        public int HitPoints { get; private set; }
        public int AverageSpeed { get; private set; }
        public int DamagePerMinute { get; private set; }
        public string Name { get; }
        public string Id { get; }
        private bool Equipment { get; set; }
        
        public Tank() {}
        
        public Tank(int hitPoints, int averageSpeed, int damagePerMinute, string name)
        {
            HitPoints = hitPoints;
            AverageSpeed = averageSpeed;
            DamagePerMinute = damagePerMinute;
            Name = name;
            Equipment = false;
            Id = GenerationId();
        }
        
        public int ChooseTank()
        {
            Tanks tanks = new Tanks();
            Console.WriteLine("Choose number of the tank:");
            
            for (int i = 1; i < 4; i++)
            {
                Console.Write(i + " ");
            }
            Console.WriteLine(": ");
            
            int a = tanks.CheckInt();
            return (a - 1);
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
        
        private static string GenerationId() => Guid.NewGuid().ToString();
    }
}