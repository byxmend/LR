using System;

namespace WoT
{
    public class MediumTank : Tank
    {
        public override void AddEquip()
        {
            if (!Equipment)
            {
                HitPoints += 600;
                ShotsPerMinute += 7;
                Equipment = true;
                DamagePerShoot += 50;
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
                HitPoints -= 600;
                ShotsPerMinute -= 7;
                Equipment = false;
                DamagePerShoot -= 50;
            }
            else
            {
                Console.WriteLine("There is no equipment on the tank anyway");
            }
        }
    }
}