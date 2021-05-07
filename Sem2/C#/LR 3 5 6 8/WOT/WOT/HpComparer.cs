using System.Collections.Generic;

namespace WOT
{
    class HpComparer : IComparer<int>
    {
        public int Compare(int firstTankHp, int secondTankHp)
        {
            if (firstTankHp > secondTankHp)
                return 1;
            else if (firstTankHp == secondTankHp)
                return 0;
            else
                return -1;
        }
    }
}
