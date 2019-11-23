using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ConsoleDump;

namespace ExercisesAlgo.BS
{
    public class MatrixSearch
    {
        public void Execute()
        {
            var matrix= new List<List<int>>
                            {
                                new List<int> { 1, 3, 5, 7 },
                                new List<int> { 10, 11, 16, 20 },
                                new List<int> { 23, 30, 34, 50},
                            };
            searchMatrix(matrix, 2).Dump();
        }

        public int searchMatrix(List<List<int>> a, int b)
        {
            int rows = a.Count;
            int columns = a[0].Count;
            int lo = 0;
            int hi = rows*columns-1;

            while (lo <= hi)
            {
                int midpos = lo + (hi - lo) / 2;
                int midel = a[midpos / columns][midpos % columns ];
                if (midel == b) return 1;
                if (midel > b)
                {
                    hi = midpos - 1;
                }
                else
                {
                    lo = midpos + 1;
                }
            }

            return 0;
        }
    }
}
