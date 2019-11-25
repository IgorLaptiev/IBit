using ConsoleDump;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace InterviewBit.Strings
{
    public class Prefixes
    {
        public void Execute()
        {
            var a = new List<string>
            {
                "abcdefgh", "aefghijk", "abcefgh"
            };
            longestCommonPrefix(a).Dump();
            a = new List<string>
            {
                "abcefgh", "abcefghijk", "abcefg"
            };
            longestCommonPrefix(a).Dump();
        }

        public string longestCommonPrefix(List<string> A)
        {
            var minLength = A.Select(str => str.Length).Min();

            for (int i = 0; i < minLength; i++)
            {
                var currentChar = A[0][i];
                for (int j = 1; j < A.Count; j++)
                {
                    if (A[j][i] != currentChar)
                    {
                        return A[0].Substring(0, i);
                    }
                }
            }
            return A[0].Substring(0, minLength);
        }
    }
}
