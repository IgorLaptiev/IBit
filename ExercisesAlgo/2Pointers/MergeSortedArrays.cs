using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ConsoleDump;

namespace ExercisesAlgo._2Pointers
{
    public class MergeSortedArrays
    {
        public void Execute()
        {
            var a = new List<int> { 1, 5, 8 };
            var b = new List<int> { 2, 4, 9 };
            merge(a,b);
            a.Dump();
        }
        public void merge(List<int> a, List<int> b)
        {
            int i = 0;
            int j = 0;
            while (j < b.Count && i < a.Count)
            {
                if (a[i] > b[j])
                {
                    a.Insert(i,b[j]);
                    j++;
                }
                else
                {
                    i++;
                }
            }
            while (j < b.Count)
            {
                a.Add(b[j]);
                j++;
            }

        }
    }
}
