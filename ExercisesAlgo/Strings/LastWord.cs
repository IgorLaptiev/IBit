using ConsoleDump;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterviewBit.Strings
{
    public class LastWord
    {
        public void Execute()
        {
            lengthOfLastWord("helloworld").Dump();
        }

        public int lengthOfLastWord(string A)
        {
            var length = 0;
            var startWord = false;
            for (int i = A.Length-1; i >= 0; i--)
            {
                if (A[i] == ' ' && startWord)
                {
                    break;
                }
                if (A[i] != ' ')
                {
                    startWord = true;
                    length++;
                }
            }
            return length;
        }
    }
}
