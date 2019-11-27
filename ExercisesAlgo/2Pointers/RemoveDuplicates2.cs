using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ConsoleDump;

namespace ExercisesAlgo._2Pointers
{
    public class RemoveDuplicates2
    {
        public void Execute()
        {
           // removeDuplicates(new List<int>() { 0, 2 }).Dump();
        //   var list = new List<int>() { 1000, 1000, 1000, 1000, 1001, 1002, 1003, 1003, 1004, 1010 };
           var list = new List<int>() { 0, 1, 2, 2, 6, 2, 2, 3};
           removeElement(list, 2).Dump();
         //   removeDuplicates(list).Dump();
            list.Dump();
        }

        public int removeDuplicates(List<int> a)
        {
            int i = 0;
            int j = i + 1;
            int cnt = 0;
            while (j < a.Count)
            {
                if (a[i] == a[j])
                {
                    j++;
                    cnt++;
                }
                else
                {
                    if (i + 2 >= a.Count)
                    {
                        break;
                    }

                    if (j > i + 2)
                    {
                        a[i + 2] = a[j];
                    }

                    j++;
                    i++;
                }
            }

            return Math.Min(i+2, a.Count);
        }

        public int removeElement(List<int> a, int b)
        {
            int last = 0;
            int i = 0;
            while (i < a.Count)
            {
                if (a[i] != b)
                {
                    if (i >= last)
                    {
                        a[last] = a[i];
                    }

                    last++;
                }

                i++;
            }

            return last;
        }

    }
}
