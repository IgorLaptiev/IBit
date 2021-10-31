using ConsoleDump;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExercisesAlgo.Arrays
{
    public class MaxSumSquareSubMatrix
    {
        public static void Execute()
        {
            new MaxSumSquareSubMatrix().solve(new List<List<int>> { new List<int> { 2, 2, 3 }, new List<int> { 2, 2, 3 }, new List<int> { 2, 3, 3 } }, 2).Dump();
        }

        public int solve(List<List<int>> A, int B)
        {
            if (B > A.Count)
            {
                B = A.Count;
            }
            var strips = new List<List<int>>();
            for (var i = 0; i < A.Count; i++)
            {
                strips.Add(new List<int>());
                for (var j = 0; j <= A.Count - B; j++)
                {
                    var sum = 0;
                    for (var k = j; k < j + B; k++)
                    {
                        sum += A[i][k];
                    }
                    strips[i].Add(sum);
                }
            }


            var maxSum = getSum(strips, 0, 0, B);
            for (var i = 0; i <= A.Count - B; i++)
            {
                for (var j = 0; j <= A.Count - B; j++)
                {
                    var currSum = getSum(strips, i, j, B);
                    if (currSum > maxSum)
                    {
                        maxSum = currSum;
                    }
                }
            }
            return maxSum;
        }

        private int getSum(List<List<int>> matrix, int x, int y, int size)
        {
            var sum = 0;
            for (var i = x; i < x + size; i++)
            {
                sum += matrix[i][y];
            }
            return sum;
        }
    }
}
