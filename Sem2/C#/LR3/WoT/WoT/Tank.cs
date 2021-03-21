namespace WoT
{
    public class Tank
    {
<<<<<<< HEAD
        public int HitPoints { get; }
        public int AverageSpeed { get; }
        public int DamagePerMinute { get; }
        public string Name { get; }
        public string Id { get; }
        //public bool Equipment { get; }
        
        public Tank() {}
        
        public Tank(int hitPoints, int averageSpeed, int damagePerMinute, string name)
        {
            HitPoints = hitPoints;
            AverageSpeed = averageSpeed;
            DamagePerMinute = damagePerMinute;
            Name = name;
            //Equipment = false;
            Id = GenerationId();
        }
        
        private static string GenerationId() => Guid.NewGuid().ToString();
=======
        
>>>>>>> parent of de7fe02 (:anchor:)
    }
}