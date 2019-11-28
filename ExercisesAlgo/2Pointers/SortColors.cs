using System.Collections.Generic;
using System.Runtime.CompilerServices;
using ConsoleDump;

namespace ExercisesAlgo._2Pointers
{
    public class SortColors
    {
        public void Execute()
        {
            var list = //new List<int> {0, 1, 2, 0, 1, 2};
            new List<int> {0,0, 1,2,2, 1, 2, 0, 1, 2};
            sortColors(list);
            list.Dump();
        }
        
        public void sortColors2(List<int> a)
        {
            int ri = 0;
            int wi = 0;
            int bi = 0;
            int lastSorted = 0;
            int current = 0;
            int cnt = a.Count;
            while (lastSorted < cnt)
            {
                if (a[current] == 0)
                {
                    if (current != ri)
                    {
                        a.Insert(ri, a[current]);
                        current++;
                    }

                    ri++;
                    wi++;
                    bi++;
                    lastSorted++;
                }
                else if (a[current] == 1)
                {
                    if (current != wi)
                    {
                        a.Insert(wi, a[current]);
                        current++;
                    }
                    wi++;
                    bi++;
                    
                    lastSorted++;
                }
                else if (a[current] == 2)
                {
                    if (current != bi)
                    {
                        a.Insert(bi, a[current]);
                        current++;
                    }
                    bi++;
                    lastSorted++;
                }

                current++;
            }
            a.RemoveRange(lastSorted, a.Count - lastSorted);
        }
        
        public void sortColors(List<int> a)
        {
            var sorted = new List<List<int>>()
            {
                new List<int>(),
                new List<int>(),
                new List<int>()
            };

            foreach (var element in a)
            {
                sorted[element].Add(element);
            }
            a.Clear();
            a.AddRange(sorted[0]);
            a.AddRange(sorted[1]);
            a.AddRange(sorted[2]);
        }
    }
}