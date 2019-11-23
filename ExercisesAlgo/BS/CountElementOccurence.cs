using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ConsoleDump;

namespace ExercisesAlgo.BS
{
    public class CountElementOccurence
    {
        public void Execute()
        {
            findCount(
                new List<int>()
                    {1
                      //  1, 1, 2, 4, 4, 4, 5, 6, 6, 6, 8, 8, 8, 9, 9, 9, 10, 10, 10, 10
                       // 1, 1, 2, 2, 2, 2, 3, 3, 3, 3, 3, 3, 3, 4, 4, 5, 5, 5, 5, 5, 6, 6, 6, 7, 7, 8, 8, 8, 8, 9, 9, 10, 10, 10
                    },
                1).Dump();
        }

        public int findCount(List<int> A, int B)
        {
            var firstB = findB(A, B);
            if (firstB < 0) return 0;
            int count =0;
            while (firstB < A.Count && A[firstB] == B)
            {
                firstB++;
                count++;
            }

            return count;
        }

        private int findB(List<int> array, int number)
        {
            var low = 0;
            var hight = array.Count- 1;
            var foundPos = -1;
            while (low <=hight )
            {
                var mid = (low + hight) / 2;
                if (array[mid] == number)
                {
                    foundPos = mid;
                    hight = mid - 1;

                }
                else if (array[mid] > number)
                {
                    hight = mid - 1;
                }
                else if (array[mid] < number)
                {
                    low = mid + 1;
                }
            }

            if (foundPos > 0)
            {
                while (foundPos>-1 && array[foundPos] == number)
                {
                    foundPos--;
                }

                foundPos++;
            }

            return foundPos;
        }
    }
}
