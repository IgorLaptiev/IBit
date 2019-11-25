using ConsoleDump;
using System;
using System.Globalization;
using System.Linq;
using System.Threading;

namespace InterviewBit.Strings
{
    public class ValidNumber
    {
        public void Execute()
        {
            isNumber("3.").Dump();
        }
        public int isNumber(string A)
        {
            double dig;
            var str = A.Trim();
            if(str.Length ==0) return 0;
            if (str.Last() == '.') return 0;
            if (str.Contains(".e")) return 0;
            Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US");
            return (Double.TryParse(str, System.Globalization.NumberStyles.Any, 
                Thread.CurrentThread.CurrentCulture, out dig))? 1:0;
        }
    }
}
