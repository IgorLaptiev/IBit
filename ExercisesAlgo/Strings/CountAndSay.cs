using ConsoleDump;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterviewBit.Strings
{
    public class CountAndSay
    {
        public void Execute()
        {
            countAndSay(5).Dump();
        }
        public string countAndSay(int A)
        {
            var seq = "1";
            for (int i = 1; i < A; i++)
            {
                seq = generateSeq(seq);
            }
            return seq;
        }

        public string generateSeq(string strA)
        {
            var outStr = new System.Text.StringBuilder();
            var cnt = 1;
            var currentChar = strA[0];
            for (int i = 1; i < strA.Length; i++)
            {
                if (strA[i] == currentChar)
                {
                    cnt++;
                }
                else
                {
                    outStr.Append(cnt);
                    outStr.Append(currentChar);
                    cnt = 1;
                    currentChar = strA[i];
                }
            }
            outStr.Append(cnt);
            outStr.Append(currentChar);
            return outStr.ToString();
        }
    }
}
