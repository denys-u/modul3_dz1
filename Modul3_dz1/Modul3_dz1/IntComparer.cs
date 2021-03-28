namespace Modul3_dz1
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class IntComparer : IComparer<int>
    {
        public int Compare(int x, int y)
        {
            if (x < y)
            {
                return -1;
            }

            if (x > y)
            {
                return 1;
            }

            return 0;
        }
    }
}
