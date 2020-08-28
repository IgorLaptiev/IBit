using ConsoleDump;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExercisesAlgo.Hashing
{
    public class SubstringConcatenation
    {

        public static void Execute()
        {
            //var subs = new SubstringConcatenation().findSubstring("barfoothefoobarmanbarfoot", new List<string> {"bar","foo" });
            var subs = new SubstringConcatenation().findSubstring("aaaaaaa", new List<string> { "aaa", "aaa" });
            subs.Dump();
        }

        public List<int> findSubstring(string A, List<string> B)
        {
            var results = new List<int>();
            for(var i = 0; i < B.Count; i++)
            {
                var spos = -1;
                var substr = B[i];
                do
                {
                    spos = A.IndexOf(substr, spos + 1);
                    if (spos != -1)
                    {
                        var tmp = B.ToList();
                        tmp.RemoveAt(i);
                        if (findAll(A.Substring(spos + substr.Length), tmp))
                        {
                            results.Add(spos);
                        }
                    }
                } while (spos != -1);
            }
            return results.Distinct().ToList();
        }

        private bool findAll(string str, List<string> substrings)
        {
            if (substrings.Count == 0) return true;
            for(var i = 0; i < substrings.Count; i++)
            {
                var substr = substrings[i];
                if (str.StartsWith(substr))
                {
                    var tmp = substrings.ToList();
                    tmp.RemoveAt(i);

                    return findAll(str.Substring(substr.Length), tmp);
                }
            }
            return false;
        }
    }
}
