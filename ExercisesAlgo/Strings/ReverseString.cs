using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ConsoleDump;

namespace ExercisesAlgo.Strings
{
    public class ReverseString
    {
        public void Execute()
        {
            solve("test").Dump();

        }

        public string solve(string A)
        {
            var result = new List<string>();
            var start = 0;
            for (int i = 0; i < A.Length; i++)
            {
                if (A[i] == ' ')
                {
                    if (i > start)
                    {
                        var word = A.Substring(start, i - start).Trim(' ');
                        if (!String.IsNullOrEmpty(word))
                        {
                            result.Insert(0, word);
                        }

                        start = i;
                    }
                }
            }
            var word2 = A.Substring(start, A.Length - start).Trim(' ');
            if (!String.IsNullOrEmpty(word2))
            {
                result.Insert(0, word2);
            }

            return String.Join(" ", result);
        }
    }
}
