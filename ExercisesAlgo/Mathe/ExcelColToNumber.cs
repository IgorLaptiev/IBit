using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ConsoleDump;

namespace ExercisesAlgo.Mathe
{
    public class ExcelColToNumber
    {
        public void Execute()
        {
            titleToNumber("BCSUS").Dump();
            convertToTitle(980089).Dump();
            (convertToTitle(titleToNumber("ABC")) == "ABC").Dump();
        //    titleToNumber("AB").Dump();
        //    titleToNumber("AAA").Dump();
        }
        public int titleToNumber(string A)
        {
            var baseEx = 'Z' - 'A' +1;
            var result = 0;
            for (int i = 0; i < A.Length; i++)
            {
                var val = A[i] - 'A' + 1;
                var range = (int)Math.Ceiling(Math.Pow(baseEx,(A.Length - i - 1)));
                result += val * range;
            }

            return result;
        }

        public string convertToTitle(int A)
        {
            var baseEx = 'Z' - 'A' + 1;
            var current = A;
            var titleBuilder = new StringBuilder();
            while (current != 0)
            {
                var element = (current -1)% baseEx;
                titleBuilder.Insert(0,Convert.ToChar('A' + element));
                current = (current-1) / baseEx;
            }

            return titleBuilder.ToString();
        }
    }
}
