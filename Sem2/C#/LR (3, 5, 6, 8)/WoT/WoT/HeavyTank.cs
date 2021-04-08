using System;

namespace WoT
{
    public class HeavyTank : Tank
    {
        public override void AddEquip()
        {
            if (!Equipment)
            {
                HitPoints += 1000;
                ShotsPerMinute += 1;
                Equipment = true;
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
                HitPoints -= 1000;
                ShotsPerMinute -= 1;
                Equipment = false;
            }
            else
            {
                Console.WriteLine("There is no equipment on the tank anyway");
            }
        }
    }
}