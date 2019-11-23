using System.Collections.Generic;

using ConsoleDump;

namespace ExercisesAlgo
{
    class RotateMatrix
    {
        public void Execute()
        {
            var A = new List<List<int>>()
                        {
                            new List<int>{ 1,2,3,4},
                            new List<int>{ 5,6,7,8},
                            new List<int>{ 9,10,11,12},
                            new List<int>{ 13,14,15,16},
                        }; 
            this.rotate(A);
            foreach (var list in A)
            {
                list.Dump();
            }
        }
        public void rotate(List<List<int>> a)
        {
            var n = a.Count;
            for (int x = 0; x < n/2; x++)
            {
                for (int y = x; y < n - x - 1; y++)
                {
                    // store current cell  
                    // in temp variable 
                    int temp = a[x][y];

                    // left to top
                    a[x][y] = a[n - 1 - y][x];

                    // bottom to left 
                    a[n - 1 - y][x] = a[n - 1 - x][n - 1 - y];

                    // right to bottom
                    a[n - 1 - x][n - 1 - y] = a[y][n - 1 - x];

                    // top to right
                    a[y][n - 1 - x] = temp;
                }
            }
        }

        private void Swap(int a, int b)
        {
            

        }
    }
}