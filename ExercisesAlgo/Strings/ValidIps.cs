using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

using ConsoleDump;

namespace ExercisesAlgo.Strings
{
    public class ValidIps
    {
        public void Execute()
        {
            restoreIpAddresses("0100100").Dump();

        }

        public List<string> restoreIpAddresses(string A)
        {
            var result = new List<string>();
            if (A.Length < 3) return result;
            if (A.Length > 12) return result;

            for (int i = 1; i < 4; i++)
            {
                for (int j = i+1; j < i+4 && j <= A.Length; j++)
                {
                    for (var k = j + 1; k < j + 4 && k <= A.Length; k++)
                    {
                        for (var l = k + 1; l < k + 4 && l <= A.Length; l++)
                        {
                          
                            if (A.Length == l)
                            {
                                var segment1 = A.Substring(0, i);
                                var segment2 = A.Substring(i, j - i);
                                var segment3 = A.Substring(j, k - j);
                                var segment4 = A.Substring(k, l - k);

                                if (checkValidSegment(segment1)
                                    && checkValidSegment(segment2)
                                    && checkValidSegment(segment3)
                                    && checkValidSegment(segment4))
                                {
                                    var ip = String.Format("{0}.{1}.{2}.{3}", segment1, segment2, segment3, segment4);
                                    result.Add(ip);
                                }
                            }
                        }
                    }
                }
            }

            return result;
        }

        private bool checkValidSegment(string segment)
        {
            if (segment.Length == 0) return false;
            if (segment.Length == 1) return true;
            if (segment[0] == '0') return false;
            if (Int32.Parse(segment) > 255) return false;
            return true;
        }
    } 
}
