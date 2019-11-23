using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ConsoleDump;

namespace ExercisesAlgo.Mathe
{
    public class PowerOfIntegers
    {
        public void Execute()
        {
            isPower(536870912).Dump();
            isPower(16808).Dump();
        }

        public int isPower(int A)
        {
            if (A == 1) return 1;
            for (int i = 2; i <= Math.Sqrt(A); i++)
            {
                var log = Math.Log(A, i);
                if (Math.Abs(log - Math.Round(log)) < 0.000001)
                {
                    Console.WriteLine($"log {log} i {i}");
                    return 1;
                }
            }

            return 0;
        }
    }
}
