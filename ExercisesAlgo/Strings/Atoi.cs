using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ConsoleDump;

namespace ExercisesAlgo.Strings
{
    public class Atoi
    {
        public void Execute()
        {
            atoi("-2147483645").Dump();

        }

        public int atoi(string A)
        {
            var validDigits = new char[] {'0', '1', '2','3','4','5','6','7','8','9','-','+'};
            var a = A.TrimStart(' ');
            int i = 0;
            double numberStr = 0;
            var sign = 1;
            if (a[i] == '-')
            {
                sign = -1;
                i++;
            }

            if (a[i] == '+')
            {
                i++;
            }
            while (i < a.Length && validDigits.Contains(a[i]))
            {
                numberStr = numberStr * 10 + sign*(a[i] - '0');
                i++;
            }

            if (numberStr > 0 && numberStr > Int32.MaxValue)
            {
                return Int32.MaxValue;
            }
            if (numberStr < 0 && numberStr < Int32.MinValue)
            {
                return Int32.MinValue;
            }

            return (int)numberStr;
        }
    }
}
