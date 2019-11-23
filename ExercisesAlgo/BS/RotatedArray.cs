using System;
using System.Collections.Generic;

using ConsoleDump;

namespace ExercisesAlgo.BS
{
    public class RotatedArray
    {
        public void Execute()
        {
            var searchlist = new List<int>()
                                 {
                                     4,
                                     5,
                                     6,
                                     7,
                                     0,
                                     1,
                                     2
                                 };
            search(new List<int>() { 101, 103, 106, 109, 158, 164, 182, 187, 202, 205, 2, 3, 32, 57, 69, 74, 81, 99, 100 },20 ).Dump();
            search(searchlist, 5).Dump();
            search(searchlist, 4).Dump();
            search(searchlist, 2).Dump();
            search(searchlist, 1).Dump();
            search(new List<int>(){ 180, 181, 182, 183, 184, 187, 188, 189, 191, 192, 193, 194, 195, 196, 201, 202, 203, 204, 3, 4, 5, 6, 7, 8, 9, 10, 14, 16, 17, 18, 19, 23, 26, 27, 28, 29, 32, 33, 36, 37, 38, 39, 41, 42, 43, 45, 48, 51, 52, 53, 54, 56, 62, 63, 64, 67, 69, 72, 73, 75, 77, 78, 79, 83, 85, 87, 90, 91, 92, 93, 96, 98, 99, 101, 102, 104, 105, 106, 107, 108, 109, 111, 113, 115, 116, 118, 119, 120, 122, 123, 124, 126, 127, 129, 130, 135, 137, 138, 139, 143, 144, 145, 147, 149, 152, 155, 156, 160, 162, 163, 164, 166, 168, 169, 170, 171, 172, 173, 174, 175, 176, 177 },
                42).Dump();
        }
        public int findMin(List<int> a)
        {
            var low = 0;
            var high = a.Count - 1;
            while (high >= low)
            {
                var mid = (low + high) / 2;
                if (a[low] <= a[high])
                    return low;
                if (a[mid] < a[(mid - 1) % a.Count] && a[mid] < a[(mid + 1) % a.Count])
                    return mid;
                if (a[mid] >= a[low])
                {
                    low = mid + 1;
                }
                if (a[mid] <= a[high])
                {
                    high = mid - 1;
                }
            }

            return -1;
        }

        public int search(List<int> a, int b)
        {
            int lo = 0;
            int hi = a.Count - 1;
          
            while (lo <=hi)
            {
                int mid = (hi + lo) / 2;

                if (a[mid] == b) return mid;
                if (a[mid] <= a[hi])
                {
                    if (a[mid] < b && b <= a[hi])
                    {
                        lo = mid + 1;
                    }
                    else
                    {
                        hi = mid - 1;
                    }
                }
                else
                {
                    if (a[lo] <= b && b < a[mid])
                    {
                        hi = mid - 1;
                    }
                    else
                    {
                        lo = mid + 1;
                    }
                }
            }

            return -1;
        }
    }
}