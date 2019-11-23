using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExercisesAlgo
{
    //Given a list of non negative integers, arrange them such that they form the largest number.
    //For example:
    //Given[3, 30, 34, 5, 9], the largest formed number is 9534330.
    public class LargestNumber
    {
        public void Execute()
        {
            var A = new List<int>()
                        {
                            0,
                            0,
                            0,
                            0,
                            0,1
                        }; //{ 3, 30, 34, 5, 9,99, 98 };
            Console.WriteLine(largestNumber(A));
        }

        public string largestNumber(List<int> A)
        {
            var str = new StringBuilder();
            A.Sort(
                (a, b) =>
                    {
                        var one = a.ToString() + b.ToString();
                        var two = b.ToString() + a.ToString();
                        if ( Int64.Parse(one)> Int64.Parse(two))
                        {
                            return -1;
                        }
                        else if (Int64.Parse(one) == Int64.Parse(two))
                        {
                            return 0;
                        }

                        return 1;
                    });
            var leadingZero = true;
            foreach (var i in A)
            {
                if (leadingZero)
                {
                    if (i > 0)
                    {
                        leadingZero = false;
                    }
                }

                if (!leadingZero)
                {
                    str.Append(i.ToString());
                }
            }

            if (str.Length == 0)
            {
                str.Append(0);
            }

            return str.ToString();
        }

    }
}
