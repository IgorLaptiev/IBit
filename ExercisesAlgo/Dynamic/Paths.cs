using ConsoleDump;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExercisesAlgo.Dynamic
{
    public class Paths
    {
        public static void Execute()
        {
            new Paths().uniquePathsWithObstacles(new List<List<int>>() {
                new List<int> { 0, 0 ,0 },
                new List<int> { 0, 1, 0 },
                new List<int> { 0, 0, 0 }}).Dump();
        }

        public int uniquePathsWithObstacles(List<List<int>> A)
        {
            var start = A[0][0];
            var i = 0;
            var j = 0;
            int paths = 0;
            if (A[i][j] == 1) return paths;
            if (A.Count == 1 && A[0].Count == 1) return 1;
            paths += tryToPath(A, i + 1, j);
            paths += tryToPath(A, i, j + 1);
            return paths;
        }

        private int tryToPath(List<List<int>> A, int i, int j)
        {
            int paths = 0;
            if (i == A.Count - 1 && j == A[i].Count - 1) return 1;
            if (i >= A.Count) return paths;
            if (j >= A[i].Count) return paths;
            if (A[i][j] == 1) return paths;
            paths += tryToPath(A, i + 1, j);
            paths += tryToPath(A, i, j + 1);
            return paths;
        }
    }
}
