using System;
using System.Collections.Generic;

using ConsoleDump;

namespace ExercisesAlgo.Mathe
{
    public class CityTour
    {
        public void Execute()
        {
            solve(48, new List<int> { 5, 12, 48, 34, 21, 29, 25, 11, 37, 26, 14, 15, 35, 41, 24, 39, 10, 17, 23, 16, 8, 44, 13, 31 }).Dump();
        }

        private Dictionary<int,long> factorials = new Dictionary<int, long>();
        public int solve(int A, List<int> B)
        {
            B.Sort();
            var nonvisitedCount = BetweenVisitedCount(B);
            long result = Fact(A - B.Count) / this.BeforeVisitedCount(A,B) % 1000000007;
            result *= nonvisitedCount % 1000000007;
            return (int)result % 1000000007;
        }

        private int BetweenVisitedCount(List<int> visited)
        {
            long count = 1;

            for (int i = 0; i < visited.Count - 1; i++)
            {
                if (visited[i + 1] - visited[i] - 1 != 0)
                {
                    count *= (long)Math.Pow(2, visited[i + 1] - visited[i] - 2) % 1000000007;
                }
            }

            return (int)count % 1000000007;
        }

        private int BeforeVisitedCount(int all, List<int> visited)
        {
            long count = 1;
            count *= this.Fact(visited[0] - 1);
            count *= this.Fact(all - visited[visited.Count - 1]);
            for (int i = 0; i < visited.Count -1 ; i++)
            {
                count *= Fact(visited[i + 1] - visited[i]-1);
            }
            return (int)(count % 1000000007);
        }

        private long Fact(int number)
        {
            if (number == 0) return 1;
            if (factorials.ContainsKey(number))
            {
                return (int) factorials[number];
            }

            long result = ((long)number * Fact(number-1)) % 1000000007;
            this.factorials[number] = result;
            return result;
        }
    }
}