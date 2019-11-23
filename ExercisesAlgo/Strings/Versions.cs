using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ConsoleDump;

namespace ExercisesAlgo.Strings
{
    public class Versions
    {
        public void Execute()
        {
            compareVersion("1.0", "1").Dump();

        }

        public int compareVersion(string A, string B)
        {
            var versionA = A.Split('.').ToList();
            var versionB = B.Split('.').ToList();
            if (versionB.Count == 0) return 1;
            if (versionA.Count == 0) return -1;
            while (versionA.Count < versionB.Count)
            {
                versionA.Add("0");
            }
            while (versionB.Count < versionA.Count)
            {
                versionB.Add("0");
            }

            var i = 0;
            while (i < versionA.Count)
            {
                var subA = versionA[i];
                var subB = versionB[i];

                var subRes = subA.TrimStart('0').Length.CompareTo(subB.TrimStart('0').Length);
                if (subRes != 0)
                {
                    return subRes;
                }
                subRes = Decimal.Parse(versionA[i]).CompareTo(Decimal.Parse(versionB[i]));
                if (subRes != 0)
                {
                    return subRes;
                }

                i++;
            }
            return 0;
        }
    }
}
