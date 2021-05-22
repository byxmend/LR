namespace WOT
{
    public abstract class Tank
    {
        public int HitPoints { get; set; }
        public int ShotsPerMinute { get; set; }
        public int DamagePerShoot { get; set; }
        public string Name { get; protected init; }
        public bool Equipment { get; set; }
        public Nationality Nation { get; protected init; }
        public abstract int ArmorRatio { get; set; }
        public abstract int DamageAirSupport { get; set; }
        public abstract int Disguise { get; set; }
        public abstract double AirSupportPerMinute { get; set; }

        protected Tank(int hitPoints, int shotsPerMinute, string name, int damagePerShoot, Nationality nation)
        {
            HitPoints = hitPoints;
            ShotsPerMinute = shotsPerMinute;
            Name = name;
            Equipment = false;
            DamagePerShoot = damagePerShoot;
            Nation = nation;
        }
        
        protected Tank() { }

        public abstract void AddEquip(Tanks tanks, int index);

        public abstract void DeleteEquip(Tanks tanks, int index);

        public void AddFeatures(Tanks tanks, int hitPoints, int shotsPerMinute, int damagePerShot, int index)
        {
            tanks[index].HitPoints += hitPoints;
            tanks[index].ShotsPerMinute += shotsPerMinute;
            tanks[index].DamagePerShoot += damagePerShot;
        }
    }
}