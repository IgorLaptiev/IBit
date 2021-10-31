using ConsoleDump;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExercisesAlgo.Arrays
{
    /*
     * Given an integer array A of size N. You need to count the number of special elements in the given array.

A element is special if removal of that element make the array balanced.

Array will be balanced if sum of even index element equal to sum of odd index element.



Problem Constraints
1 <= N <= 105

1 <= A[i] <= 109



Input Format
First and only argument is an integer array A of size N.



Output Format
Return an integer denoting the count of special elements.



Example Input
Input 1:

 A = [2, 1, 6, 4]
Input 2:

 A = [5, 5, 2, 5, 8]


     */
    public class BalanceArray
    {
        public static void Execute()
        {
            var A = new List<int> { 5, 5, 2, 5, 8 };
            var count = 0;
            var leftOdd = new int[A.Count];
            var leftEven = new int[A.Count];
            for (var i = 0; i < A.Count - 1; i++)
            {
                if (i % 2 == 0)
                {
                    leftOdd[i + 1] = leftOdd[i] + A[i];
                    leftEven[i + 1] = leftEven[i];
                }
                else
                {
                    leftOdd[i + 1] = leftOdd[i];
                    leftEven[i + 1] = leftEven[i] + A[i];
                }
            }

            var rightOdd = new int[A.Count];
            var rightEven = new int[A.Count];
            for (var i = A.Count - 1; i >0; i--)
            {
                if (i % 2 == 0)
                {
                    rightOdd[i - 1] = rightOdd[i] + A[i];
                    rightEven[i - 1] = rightEven[i];
                }
                else
                {
                    rightOdd[i - 1] = rightOdd[i];
                    rightEven[i - 1] = rightEven[i] + A[i];
                }
            }
            for (var i = 0; i < A.Count; i++)
            {
                if (leftOdd[i] + rightEven[i] == leftEven[i] + rightOdd[i])
                {
                    count++;
                }
            }
            count.Dump();
        }
    }
}
