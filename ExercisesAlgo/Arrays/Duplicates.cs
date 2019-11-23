using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;

using ConsoleDump;

namespace ExercisesAlgo
{
    public class Duplicates
    {
        public void Execute()
        {
            var A = new List<int>()
                        {
                            1, 3, 2, 4, 2, 5
                        };

            this.repeatedNumber(A).Dump();
        }
        public int repeatedNumber(List<int> A)
        {
            var d = new Dictionary<int,bool>();
            foreach (var i in A)
            {
                if (d.ContainsKey(i))
                {
                    return i;
                }
                else
                {
                    d[i] = true;
                }
            }

            return -1;
        }
    }
}