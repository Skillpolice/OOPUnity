using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GeekBrains
{
    public class GoodBonusComparer : IComparer<GoodBonus>
    {
        public int Compare(GoodBonus x, GoodBonus y)
        {
            if (x._point < y._point)
            {
                return 1;
            }

            if (x._point > y._point)
            {
                return -1;
            }

            return 0;
        }
    }
}

