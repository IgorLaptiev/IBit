using ConsoleDump;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExercisesAlgo.Mathe
{
    public class Steps
    {
        public static void Execute()
        {
            new Steps().solve(2).Dump();
            new Steps().solve(3).Dump();
            new Steps().solve(4).Dump();
            new Steps().solve(5).Dump();
            new Steps().solve(6).Dump();
            new Steps().solve(7).Dump();
            new Steps().solve(8).Dump();
            new Steps().solve(42).Dump();
        }

        public int solve(int A)
        {
            var curr = 0;
            var step = 0;
            A = Math.Abs(A);
            while (curr < A || (curr-A)%2 !=0)
            {
                step++;
                curr += step;
                Console.WriteLine($"step:{step} val:{curr}");
                //if (A - curr >= i)
                //{
                //    curr += i;
                //}
                //else
                //{
                //    curr -= i;
                //}
            }
            return step;
        }
    }
}
