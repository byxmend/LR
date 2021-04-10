using System;

namespace WoT
{
    public class Tank : Tanks
    {
        public int HitPoints { get; set; }
        public int ShotsPerMinute { get; set; }
        public int DamagePerShoot { get; set; }
        public string Name { get; }
        public string Id { get; }
        protected internal bool Equipment = true;
        public Nationality Nation { get; }

        public Tank() { }

        public Tank(int hitPoints, int shotsPerMinute, string name, int damagePerShoot, Nationality nation)
        {
            HitPoints = hitPoints;
            ShotsPerMinute = shotsPerMinute;
            Name = name;
            Equipment = false;
            DamagePerShoot = damagePerShoot;
            Id = GenerationId();
            Nation = nation;
        }

        private static string GenerationId() => Guid.NewGuid().ToString();

        public virtual void AddEquip()
        {
            if (!Equipment)
            {
                HitPoints += 500;
                ShotsPerMinute += 2;
                Equipment = true;
            }
            else
            {
                Console.WriteLine("You can't install the equipment twice");
            }
        }
        
        public virtual void RemoveEquip()
        {
            if (Equipment)
            {
                HitPoints -= 500;
                ShotsPerMinute -= 2;
                Equipment = false;
            }
            else
            {
                Console.WriteLine("There is no equipment on the tank anyway");
            }
        }
    }
}