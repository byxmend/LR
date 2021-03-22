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
        private int Ammunition { get; set; }
        
        public Tank() {}
        
        public Tank(int hitPoints, int averageSpeed, int damagePerMinute, string name, int ammunition)
        {
            HitPoints = hitPoints;
            AverageSpeed = averageSpeed;
            DamagePerMinute = damagePerMinute;
            Name = name;
            Equipment = false;
            Ammunition = ammunition;
            Id = GenerationId();
        }
        
        private static string GenerationId() => Guid.NewGuid().ToString();

        private readonly Tanks _tanks = new Tanks();

        public int ChooseTank()
        {
            Console.WriteLine("\nChoose number of the tank:");
            
            for (int i = 1; i < 4; i++)
            {
                Console.Write(i + " ");
            }
            Console.WriteLine(": ");
            
            int a = _tanks.CheckInt();
            return (a - 1);
        }
        
        public void AddEquip()
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

        public void RemoveEquip()
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

        public void Shoot(Tank tank)
        {
            if (tank.Ammunition > 0)
            {
                tank.Ammunition--;
                Console.WriteLine("The tank fired!");
            }
            else
            {
                Console.WriteLine("No ammunition");
            }
        }

        public void Battle()
        {
            
        }
    }
}