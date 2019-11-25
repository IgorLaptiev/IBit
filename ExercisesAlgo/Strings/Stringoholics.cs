using ConsoleDump;
using System;
using System.Collections.Generic;
using System.Linq;

namespace InterviewBit.Strings
{
    public class Stringoholics
    {
        public void Execute()
        {
           // KMP("b", "b").Dump();
           // calculateLPS("AABAACAABAA").Dump();
            solve(new List<string>
            {"a","ababa","aba"
            }).Dump();
        }
        int M = (int)1e9 + 7;

        public int solve(List<string> A)
        {
            List<int> lens = new List<int>();

            foreach (var t in A)
            {
                int maxLen = GetMaxSubstringLength(t);
                int n = t.Length;

                if (n % (n - maxLen) == 0)
                {
                    n -= maxLen;
                }

                long sum = 0;
                int i = 1;
                do
                {
                    sum += i;
                    i++;
                } while (sum % ((long)n) != 0L);

                lens.Add(i - 1);
            }
            long lcm = GetLcm(lens) % M;

            return (int)lcm % M;
        }

        private int GetLcm(List<int> lens)
        {
            Dictionary<int, int> lcms = new Dictionary<int, int>();

            foreach (var num in lens)
            {
                updateLcmMap(lcms, num);
            }

            long prod = 1;
            foreach (var entry in lcms)
            {
                long p = pow(entry.Key, entry.Value) % M;
                prod = (prod * p) % M;
            }

            return (int)(prod % M);
        }

        long pow(long a, long p)
        {

            long result = 1;
            while (p > 0)
            {
                if (p % 2L == 1L)
                {
                    result = (result * a) % M;
                }
                a = (a * a) % M;
                p /= 2;
            }

            return result % M;
        }
        void updateLcmMap(Dictionary<int, int> m, int num)
        {

            int i = 2;

            while (i <= num && i > 1)
            {
                int count = 0;

                while (num % i == 0)
                {
                    count++;
                    num /= i;
                }

                if (count == 0)
                {
                    i++;
                    continue;
                }

                if (m.ContainsKey(i))
                {
                    m[i] = Math.Max(m[i],count);
                }
                else
                {
                    m[i] = count;
                }

                i++;
            }
        }
        private int GetMaxSubstringLength(string str)
        {
            return calculateLPS(str).Max();
        }
        

        public int strStr(string A, string B)
        {
            if (string.IsNullOrEmpty(A) || string.IsNullOrEmpty(B)) return -1;
            var results = KMP(A, B);
            if (results.Count == 0) return -1;
            return results[0];

        }
        private List<int> KMP(string txt, string pattern)
        {
            var result = new List<int>();
            var lps = calculateLPS(pattern);
            var i = 0;
            var j = 0;
            while(i < txt.Length)
            {
                if (j == pattern.Length)
                {
                    result.Add(i- j);
                    j = lps[j - 1];
                }
                else
                {
                    if (txt[i] == pattern[j])
                    {
                        i++;
                        j++;
                    }
                    else
                    {
                        if (j != 0)
                        {
                            j = lps[j - 1];
                        }
                        else
                        {
                            i++;
                        }
                    }
                }
            }
            if (j == pattern.Length)
            {
                result.Add(i - j);
            }
            return result;
        }
        
        private int[] calculateLPS(string pattern)
        {
            var result = new int[pattern.Length];
            var i = 1;
            var cnt = 0;
            result[0] = 0;

            while(i< pattern.Length)
            {
                if (pattern[i] == pattern[cnt])
                {
                    cnt++;
                    result[i] = cnt;
                    i++;
                }
                else
                {
                    if(cnt!=0)
                    {
                        cnt = result[cnt - 1];
                    }
                    else
                    {
                        result[i] = 0;
                        i++;
                    }
                }
            }
            return result;
        }
    }
}
