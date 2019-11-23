using System;
using System.CodeDom;
using System.Collections.Generic;

using ConsoleDump;

namespace ExercisesAlgo
{
    public class ArrayPermutation
    {
        public void Execute()
        {
            var A = new List<int>()
                        {
                            1,2,3,4 
                        };
            this.nextPermutation(A).Dump();
            
            this.nextPermutation(A).Dump();
            this.nextPermutation(A).Dump();
            this.nextPermutation(A).Dump();
            this.nextPermutation(A).Dump();
            this.nextPermutation(A).Dump();
            this.nextPermutation(A).Dump();
            this.nextPermutation(A).Dump();
            this.nextPermutation(A).Dump();

        }

        public List<int> nextPermutation(List<int> a)
        {
            var exist = false;
            for (int i = a.Count-2; i >=0 ; i--)
            {
                var next = FindNext(a, i);
                if (next > 0)
                {
                    var tmp = a[i];
                    a[i] = a[next];
                    a[next] = tmp;
                    SortTail(a, i + 1);
                    exist = true;
                    break;
                }
            }

            if (!exist)
            {
                SortTail(a,0);
            }
            return a;
        }

        private void SortTail(List<int> a, int i)
        {
            for (int j = i; j < a.Count; j++)
            {
                var min = a[j];
                var ind = -1;
                for (int k = j + 1; k < a.Count; k++)
                {
                    if (a[k] < min)
                    {
                        min = a[k];
                        ind = k;
                    }
                }
                if (ind > 0)
                {
                    var tmp = a[j];
                    a[j] = a[ind];
                    a[ind] = tmp;
                }
            }
        }

        private int FindNext(List<int> a, int i)
        {
            var next = int.MaxValue;
            var ind = -1;
            for (int j = i+1; j < a.Count; j++)
            {
                if (a[j] > a[i] && a[j] < next)
                {
                    next = a[j];
                    ind = j;
                }
            }

            return ind;
        }
    }
}