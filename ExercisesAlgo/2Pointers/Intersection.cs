using ConsoleDump;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterviewBit._2Pointers
{
    public class Intersection
    {
        public void Execute()
        {
            intersect(new List<int> { 1, 2, 3, 3, 4, 5, 6, }, new List<int> { 3, 3, 5 }).Dump();
        }

        public List<int> intersect(List<int> A, List<int> B)
        {
            var result = new List<int>();

            var i = 0;
            var j = 0;

            while(i < A.Count && j < B.Count)
            {
                if (A[i] < B[j])
                {
                    i++;
                }
                else if (A[i] > B[j])
                {
                    j++;
                }
                else
                {
                    result.Add(A[i]);
                    i++;
                    j++;
                }
            }
            return result;
        }
    }
}
