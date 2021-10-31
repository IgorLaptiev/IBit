using ConsoleDump;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExercisesAlgo.Arrays
{
    /*
     
     Реализовать (без использования LINQ) метод, возвращающий массив без дубликатов сохраняющий порядок элементов.

int[] Distinct(int[] src)
//[1,2,5,3,3,2] → [1,2,5,3] 

     
         */

    class Test
    {
        public void Execute()
        {
            this.Distinct(new int[0] { }).Dump();
            this.Distinct(new[] {1, 2, 5, 3, 3, 2}).Dump();
        }

        public int[] Distinct(int[] src)
        {
            var result = new List<int>();
            var hash = new HashSet<int>();
            for (int i = 0; i < src.Length; i++)
            {
                if (!hash.Contains(src[i]))
                {
                    result.Add(src[i]);
                    hash.Add(src[i]);
                }
            }
            return result.ToArray();
        }

        public IEnumerable<T> FilterLast<T>(IEnumerable<T> source, Int32 n)
        {
            var buff = new Queue<T>(n);
            var resCount = 0;
            var i = 0;
            foreach (var item in source)
            {
                buff.Enqueue(item);
                i++;
                if (buff.Count > n)
                {
                    resCount++;
                    yield return buff.Dequeue();
                }
            }
            //while(resCount < i - n)
            //{
            //    yield return buff.Dequeue();
            //}
        }
    }
}

