using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomLib
{
    public static class Utils
    {
        public static bool BetweenIE(float min, float max, float val)
        {
            return min <= val && val < max;
        }
    }
}
