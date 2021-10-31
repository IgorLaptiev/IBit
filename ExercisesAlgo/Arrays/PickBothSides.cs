using ConsoleDump;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
 * Given an integer array A of size N.

You can pick B elements from either left or right end of the array A to get maximum sum.

Find and return this maximum possible sum.

NOTE: Suppose B = 4 and array A contains 10 elements then:

You can pick first four elements or can pick last four elements or can pick 1 from front and 3 from back etc . you need to return the maximum possible sum of elements you can pick.


Problem Constraints
1 <= N <= 105

1 <= B <= N

-103 <= A[i] <= 103



Input Format
First argument is an integer array A.

Second argument is an integer B.



Output Format
Return an integer denoting the maximum possible sum of elements you picked.



Example Input
Input 1:

 A = [5, -2, 3 , 1, 2]
 B = 3
Input 2:

 A = [1, 2]
 B = 1


Example Output
Output 1:

 8
Output 2:

 2


Example Explanation
Explanation 1:

 Pick element 5 from front and element (1, 2) from back so we get 5 + 1 + 2 = 8
Explanation 2:

 Pick element 2 from end as this is the maximum we can get
 */
namespace ExercisesAlgo.Arrays
{
    public class PickBothSides
    {
        public static void Execute()
        {
            var l = new List<int> { -533, -666, -500, 169, 724, 478, 358, -38, -536, 705, -855, 281, -173, 961, -509, -5, 942, -173, 436, -609, -396, 902, -847, -708, -618, 421, -284, 718, 895, 447, 726, -229, 538, 869, 912, 667, -701, 35, 894, -297, 811, 322, -667, 673, -336, 141, 711, -747, -132, 547, 644, -338, -243, -963, -141, -277, 741, 529, -222, -684, 35 };
             new PickBothSides().solve(l, 48).Dump();
            new PickBothSides().solve(new List<int> { 5, -2, 3, 1, 2 }, 3).Dump();
        }

        public int solve(List<int> A, int B)
        {
            var lleft = new int[B+1];
            var lright = new int[B+1];
            for (var i = 0; i < B; i++)
            {
                lleft[i + 1] = lleft[i] + A[i];
                lright[B - i - 1] = lright[B - i] + A[A.Count - i - 1];
            }
            var maxSum = Int32.MinValue;
            for (var i = 0; i <= B; i++)
            {
                if (lleft[i] + lright[i] > maxSum)
                {
                    maxSum = lleft[i] + lright[i];
                }
            }
            return maxSum;
        }
    }
}
