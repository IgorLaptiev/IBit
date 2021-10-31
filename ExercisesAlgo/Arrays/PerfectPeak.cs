using ConsoleDump;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExercisesAlgo.Arrays
{
    /*
     * Given an integer array A of size N.

You need to check that whether there exist a element which is strictly greater than all the elements on left of it and strictly smaller than all the elements on right of it.

If it exists return 1 else return 0.

NOTE:

Do not consider the corner elements i.e A[0] and A[N-1] as the answer.


Problem Constraints
3 <= N <= 105

1 <= A[i] <= 109



Input Format
First and only argument is an integer array A containing N integers.



Output Format
Return 1 if there exist a element that is strictly greater than all the elements on left of it and strictly smaller than all the elements on right of it else return 0.



Example Input
Input 1:

 A = [5, 1, 4, 3, 6, 8, 10, 7, 9]
Input 2:

 A = [5, 1, 4, 4]


Example Output
Output 1:

 1
Output 2:

 0


Example Explanation
Explanation 1:

 A[4] = 6 is the element we are looking for.
 All elements on left of A[4] are smaller than it and all elements on right are greater.
Explanation 2:

 No such element exits.

     */
    public class PerfectPeak
    {

        public static void Execute()
        {
            new PerfectPeak().perfectPeak(new List<int> { 9895, 30334, 17674, 23812, 20038, 25668, 6869, 1870, 4665, 27645, 7712, 17036, 31323, 8724, 28254, 28704, 26300, 25548, 15142, 12860, 19913, 32663, 32758 }).Dump();
        }

        public int perfectPeak(List<int> A)
        {
            var rightMins = new int[A.Count];
            rightMins[A.Count - 1] = A[A.Count - 1];
            for (var i = A.Count - 2; i >= 0; i--)
            {
                rightMins[i] = Math.Min(rightMins[i+1], A[i]);
            }

            var leftMax = A[0];
            for (var i = 1; i < A.Count - 1; i++)
            {
                if (A[i] > leftMax && A[i] < rightMins[i + 1])
                {
                    return 1;
                }
                leftMax = Math.Max(leftMax, A[i]);
            }
            return 0;
        }
    }
}
