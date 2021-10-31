using ConsoleDump;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExercisesAlgo.Greedy
{
    public class MeetingRooms
    {

        public static void Execute()
        {
            new MeetingRooms().solve(new List<List<int>>
            {
              new List<int>{ 7, 10},
              new List<int>{ 4, 19},
              new List<int>{19, 26},
              new List<int>{14, 16},
              new List<int>{13, 18},
              new List<int>{16, 21} 
            }).Dump();
        }

        public int solve(List<List<int>> A)
        {
            
            var flat = A.Select(a => new { time = a[0], cnt = 1 })
                .Concat(A.Select(a => new { time = a[1], cnt = -1 }))
                .GroupBy(a => a.time)
                .Select(g => new { g.Key, cnt = g.Sum(a => a.cnt) })
                .ToList();

            var max = 0;
            var cnt = 0;
            for (var i = 0; i < flat.Count; i++)
            {
                cnt += flat[i].cnt;
                if (cnt > max)
                {
                    max = cnt;
                }
            }
            return max;
        }
    }
}
