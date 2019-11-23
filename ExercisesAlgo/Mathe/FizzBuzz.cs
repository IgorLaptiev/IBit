using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ConsoleDump;

namespace ExercisesAlgo.Mathe
{
    public class FizzBuzz
    {
        public void Execute()
        {

            fizzBuzz(15).Dump();
        }

        public List<string> fizzBuzz(int A)
        {
            var result = new List<string>();
            for (int i = 1; i <= A; i++)
            {
                var str = "";
                if (i % 3 == 0)
                {
                    str = "Fizz";
                }
                if (i % 5 == 0)
                {
                    str +="Buzz";
                }

                if (string.IsNullOrEmpty(str))
                {
                    str = i.ToString();
                }
                result.Add(str);
            }

            return result;
        }
    }
}
