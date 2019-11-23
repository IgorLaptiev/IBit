using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ConsoleDump;

namespace ExercisesAlgo.BS
{
    public class InsertedPosition
    {

        public void Execute()
        {
            searchInsert(new List<int>() { 1, 3, 5, 6 }, 5).Dump();
            searchInsert(new List<int>() { 1, 3, 5, 6 }, 2).Dump();
            searchInsert(new List<int>() { 1, 3, 5, 6 }, 7).Dump();
            searchInsert(new List<int>() { 1, 3, 5, 6 }, 0).Dump();
        }

        public int searchInsert(List<int> a, int b)
        {
            int lo = 0;
            int hi = a.Count - 1;

            while (lo <= hi)
            {
                var mid = lo + (hi - lo) / 2;
                if (a[mid] == b) return mid;
                if (a[mid] > b)
                {
                    hi = mid - 1;
                }
                else
                {
                    lo = mid + 1;
                }
            }

            return lo;
        }
    }
}
