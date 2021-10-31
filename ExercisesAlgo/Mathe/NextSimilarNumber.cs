using ConsoleDump;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExercisesAlgo.Mathe
{
    /*
Given a number A in a form of string.

You have to find the smallest number that has same set of digits as A and is greater than A.

If A is the greatest possible number with its set of digits, then return -1.



Problem Constraints
1 <= A <= 10100000

A doesn't contain leading zeroes.



Input Format
First and only argument is an numeric string denoting the number A.



Output Format
Return a string denoting the smallest number greater than A with same set of digits , if A is the largest possible then return -1.



Example Input
Input 1:

 A = "218765"
Input 2:

 A = "4321"


Example Output
Output 1:

 "251678"
Output 2:

 "-1"


Example Explanation
Explanation 1:

 The smallest number greater then 218765 with same set of digits is 251678.
Explanation 2:

 The given number is the largest possible number with given set of digits so we will return -1.

      
     
     */
    public class NextSimilarNumber
    {
        public static void Execute()
        {
            new NextSimilarNumber().solve("892795").Dump();
        }

        public string solve(string A)
        {
            var i = A.Length - 2;
            var arr = A.ToCharArray();
            for (; i >= 0; i--)
            {
                if (arr[i] < arr[i + 1])
                {
                    var greater = findGreater(arr, arr[i], i + 1);
                    if (greater > -1)
                    {
                        var tmp = arr[i];
                        arr[i] = arr[greater];
                        arr[greater] = tmp;
                        sort(arr, i + 1);
                    }
                    return new string(arr);
                }
            }
            return "-1";
        }

        private int findGreater(char[] A, char search, int start)
        {
            var mi = -1;
            var min = '9' + 1;
            for (var i = start; i < A.Length; i++)
            {
                if (A[i] < min && A[i] > search)
                {
                    min = A[i];
                    mi = i;
                }
            }
            return mi;
        }

        private void sort(char[] A, int start)
        {
            var arr = A.Skip(start).ToArray();
            Array.Sort(arr);
            var j = 0;
            for (var i = start; i < A.Length; i++, j++)
            {
                A[i] = arr[j];
            }
        }

    }
}
