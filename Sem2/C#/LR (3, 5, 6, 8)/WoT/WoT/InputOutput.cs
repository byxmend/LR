namespace WoT
{
    public abstract class InputOutput
    {
        private readonly Tank _tank = new Tank();
        
        public abstract void FillTanksSet(int i);
        
        public abstract void ShowTanksSet();
        
        public void AddFeatures(int hitPoints, int shotsPerMinute, int damagePerShot)
        {
            _tank.HitPoints += hitPoints;
            _tank.ShotsPerMinute += shotsPerMinute;
            _tank.DamagePerShoot += damagePerShot;
        }
    }
}