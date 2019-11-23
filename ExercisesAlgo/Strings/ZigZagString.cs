using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ConsoleDump;

namespace ExercisesAlgo.Strings
{
    public class ZigZagString
    {
        public void Execute()
        {
            convert("PAYPALISHIRING", 2).Dump();
        }
        public string convert(string A, int B)
        {
            if (B == 0) return string.Empty;
            if (B == 1) return A;
            var tempstr = new List<StringBuilder>();
            for (int i = 0; i < B; i++)
            {
                tempstr.Add(new StringBuilder());
            }

            var currentLine = 0;
            var direction = 1;
            for (int i = 0; i < A.Length; i++)
            {
                if (currentLine == 0)
                {
                    direction = 1;
                }

                if (currentLine == B-1)
                {
                    direction = -1;
                }

                tempstr[currentLine].Append(A[i]);
                currentLine = currentLine + 1 * direction;
            }
            var strB = new StringBuilder();
            foreach (var str in tempstr)
            {
                strB.Append(str.ToString());
            }

            return strB.ToString();
        }
    }
}
