using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WOT
{
	class HpComparer : IComparer<Tank>
	{
        public int Compare(Tank firstTank, Tank secondTank)
        {
            if (firstTank.HitPoints > secondTank.HitPoints)
            {
                return 1;
            }
            else if (firstTank.HitPoints == secondTank.HitPoints)
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
