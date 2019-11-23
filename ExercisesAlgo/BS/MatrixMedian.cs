using System;
using System.Collections.Generic;

using ConsoleDump;

namespace ExercisesAlgo.BS
{
    public class MatrixMedian
    {
        public void Execute()
        {
            var matrix = new List<List<int>>
                             {
                                 new List<int>() { 1, 3, 5 },
                                 new List<int>() {2, 6, 9},
                                 new List<int>() {3, 6, 9 },
                             };

            findMedian(matrix).Dump();
        }
        public int findMedian(List<List<int>> A)
        {
            // median = M*N/2 +1;

            int max = int.MinValue;
            int min = int.MaxValue;

            foreach (var row in A)
            {
                // Finding the minimum element 
                if (row[0] < min)
                    min = row[0];

                // Finding the maximum element 
                if (row[row.Count - 1] > max)
                    max = row[row.Count - 1];
            }

            int median = (A.Count * A[0].Count + 1)/2;
            while (max> min)
            {
                var mid = min + (max - min) / 2;
                var found = 0;
                var place = 0;
                for (int i = 0; i < A.Count; i++)
                {
                    found = A[i].BinarySearch(mid);
                    if (found <0)
                    {
                        found = Math.Abs(found) - 1;
                    }
                    else
                    {
                        while (found < A[i].Count && A[i][found] == mid)
                            found += 1;
                    }

                    place = place + found;
                }
                if (place < median)
                    min = mid + 1;
                else
                    max = mid;
            }

            return min;
        }
    }
}