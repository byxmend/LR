using System;

namespace WoT
{
    public class LightTank : Tank
    {
        public override void AddEquip()
        {
            if (!Equipment)
            {
                HitPoints += 300;
                ShotsPerMinute += 5;
                Equipment = true;
                DamagePerShoot += 100;
            }
            else
            {
                Console.WriteLine("You can't install the equipment twice");
            }
        }
        
        public override void RemoveEquip()
        {
            if (Equipment)
            {
                HitPoints -= 300;
                ShotsPerMinute -= 5;
                Equipment = false;
                DamagePerShoot -= 100;
            }
            else
            {
                Console.WriteLine("There is no equipment on the tank anyway");
            }
        }
    }
}