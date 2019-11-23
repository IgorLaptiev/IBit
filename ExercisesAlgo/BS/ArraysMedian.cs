using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ConsoleDump;

namespace ExercisesAlgo.BS
{
    public class ArraysMedian
    {
        public void Execute()
        {
            var a = new List<int>
                        {
                            -35, 5, 11, 34, 35
                          // -50, -41, -40, -19, 5, 21, 28 
                            //1, 4, 5
                        };
            var b = new List<int>
                        {
                         //   -2
                           // -50, -21, -10
                            //2, 3
                        };
            findMedianSortedArrays(a, b).Dump();
        }

        static double findMedianSortedArrays(List<int> a, List<int> b)
        {
            if (b.Count < a.Count)
            {
                return findMedianSortedArraysint(b, a);
            }
            else
            {
                return findMedianSortedArraysint(a,b);
            }
        }

        static double findMedianSortedArraysint(List<int> a, List<int> b)
        {
            int n = a.Count;
            int m = b.Count;

            int min_index = 0, max_index = n, i = 0,
            j = 0, median = 0;

            while (min_index <= max_index)
            {
                i = (min_index + max_index) / 2;
                j = Math.Max(((n + m + 1) / 2) - i,0);

               
                if (i < n && j > 0 && b[j - 1] > a[i])
                    min_index = i + 1;

                else if (i > 0 && j < m && b[j] < a[i - 1])
                    max_index = i - 1;

                // we have found the desired halves. 
                else
                {
                 
                    if (i == 0)
                        median = b[j - 1];

                
                    else if (j == 0)
                        median = a[i - 1];
                    else
                        median = Math.Max(a[i - 1], b[j - 1]);
                    break;
                }
            }

            // calculating the median. 
            // If number of elements is odd  
            // there is one middle element. 
            if ((n + m) % 2 == 1)
                return (double)median;

            // Elements from a[] in the second  
            // half is an empty set.  
            if (i == n)
                return (median + b[j]) / 2.0;

            // Elements from b[] in the second  
            // half is an empty set. 
            if (j == m)
                return (median + a[i]) / 2.0;

            return (median + Math.Min(a[i], b[j])) / 2.0;
        }


        public double findMedianSortedArrays2(List<int> a, List<int> b)
        {
            int n = a.Count;
            int m = b.Count;
            int min = int.MaxValue;
            int max = int.MinValue;
            if (n > 0)
            {
                min = a[0];
            }

            if (m > 0)
            {
                min = Math.Min(min, b[0]);
            }

            if (n > 0)
            {
                max = a[n - 1];
            }

            if (m > 0)
            {
                max = Math.Max(max, b[m - 1]);
            }

            bool isEven = (n + m) % 2 == 0;
            int median = isEven ? (n + m ) / 2: (n + m + 1) / 2;

            double med = GetMedian(a, b, min, max, n, m, median);
            if (isEven)
            {
                double next = GetMedian(a, b, min, max, n, m, median+1);
                med = (med + next) / 2;
            }

            return med;
        }

        private static double GetMedian(List<int> a, List<int> b, int min, int max, int n, int m, int median)
        {
            while (min < max)
            {
                var mid = min + (max - min) / 2;
                var place = 0;
                place += FindPlace(a, mid, n);
                place += FindPlace(b, mid, m);

                if (place < median)
                    min = mid + 1;
                else
                    max = mid;
            }

            return min;
        }

        private static int FindPlace(List<int> a, int mid, int n)
        {
            if (n == 0) return 0;
            int found = a.BinarySearch(mid);
            if (found < 0)
            {
                found = Math.Abs(found) - 1;
            }
            else
            {
                while (found < n && a[found] == mid)
                    found += 1;
            }

            return found;
        }
    }
}
