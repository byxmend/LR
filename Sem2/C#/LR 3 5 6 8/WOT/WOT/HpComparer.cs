using System.Collections.Generic;

namespace WOT
{
    class HpComparer : IComparer<Tank>
    {
        public int Compare(Tank firstTank, Tank secondTank)
        {
            if (secondTank != null && firstTank != null && firstTank.HitPoints > secondTank.HitPoints)
            {
                return 1;
            }
            else if (secondTank != null && firstTank != null && firstTank.HitPoints == secondTank.HitPoints)
            {
                return 0;
            }
            else
            {
                return -1;
            }
        }
    }
}
