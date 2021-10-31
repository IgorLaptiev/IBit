using ConsoleDump;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExercisesAlgo.Arrays
{
    public class MaxTriplet
    {
        public static void Execute()
        {
            //var arr = new SortedList<int, int>() { { 1, 1}, { 2,2}, {4, 4 }, { 5,5} };
            //BinarySearch(arr, 1).Dump();
            //BinarySearch(arr, 2).Dump();
            //BinarySearch(arr, 3).Dump();
            //BinarySearch(arr, 4).Dump();
            //BinarySearch(arr, 5).Dump();
            //BinarySearch(arr, 6).Dump();

            //var list = new List<int>() { 2, 5, 3, 1, 4, 9 };
            //            var list = new List<int>() { 32592, 18763, 1656, 17411, 6360, 27625, 20538, 21549, 6484, 27596 };
            var list = new List<int>() { 14310, 7617, 18936, 17452, 20601, 5250, 16520, 31557, 22799, 30304, 6225, 11009, 5845, 32610 };
            new MaxTriplet().solve(list).Dump();
        }

        public int solvesl(List<int> A)
        {
            var list = A.Select((e, ind) => new { val = e, index = ind })
                .OrderByDescending(el => el.val)
                .ToList();
            var maxSum = 0;
            for (var j = 0; j < list.Count; j++)
            {
                var triplet = 0;
                var tripletIndexes = -1;
                var sum = 0;
                var cnt = 0;

                for (int i = j; i < list.Count; i++)
                {
                    var l = list[i];
                    if (tripletIndexes == -1)
                    {
                        triplet = l.val;
                        tripletIndexes = l.index;
                        sum += l.val;
                        cnt++;
                    }
                    else if (triplet > l.val && tripletIndexes > l.index)
                    {
                        triplet = l.val;
                        tripletIndexes = l.index;
                        sum += l.val;
                        cnt++;
                    }
                    if (cnt == 3)
                    {
                        maxSum = Math.Max(sum, maxSum);
                    }

                }
            }
            return maxSum;
        }

        public int solve(List<int> A)
        {
            var rightMax = new int[A.Count];
            rightMax[A.Count - 1] = A[A.Count - 1];
            for (var i = A.Count - 2; i >= 0; i--)
            {
                rightMax[i] = Math.Max(rightMax[i + 1], A[i]); 
            }
            SortedList<int, int> left = new SortedList<int, int>(new DuplicateKeyComparer<int>());
            left.Add(A[0], A[0]);
            var maxSum = 0;
            for (var j = 1; j < A.Count - 1; j++)
            {
                var ai = BinarySearch(left, A[j]);
                var ak = rightMax[j + 1];
                if (ai > 0 && ai < A[j] && ak > A[j])
                {
                    var sum = ai + A[j] + ak;
                    if (sum > maxSum)
                    {
                        maxSum = sum;
                    }
                }
                left.Add(A[j], A[j]);
            }
            return maxSum;
        }


        private static int BinarySearch(SortedList<int,int> arr, int val)
        {
            var start = 0;
            var end = arr.Count - 1;
            while (start <= end)
            {
                var middle = (end + start) / 2;
                if (arr.Keys[middle] >= val)
                {
                    end = middle - 1;
                }
                else
                {
                    start = middle + 1;
                }
            }
            if (end < 0) return -1;
            if (end > arr.Count) return -1;
            return arr.Keys[end];
        }
    }

    public class DuplicateKeyComparer<TKey> : IComparer<TKey> where TKey : IComparable
    {
        #region IComparer<TKey> Members

        public int Compare(TKey x, TKey y)
        {
            int result = x.CompareTo(y);

            if (result == 0)
                return 1;   // Handle equality as beeing greater
            else
                return result;
        }

        #endregion
    }

}
