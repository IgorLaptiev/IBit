using System;
using System.Collections.Generic;
using System.Linq;

using ConsoleDump;

namespace ExercisesAlgo.BS
{
    public class Books
    {
        public void Execute()
        {
            this.books(new List<int>()
                                  {
                                      73, 58, 30, 72, 44, 78, 23, 9 
                                    //  97, 26, 12, 67, 10, 33, 79, 49, 79, 21, 67, 72, 93, 36, 85, 45, 28, 91, 94, 57, 1, 53, 8, 44, 68, 90, 24 
                                    //  31, 14, 19, 75
                                   //12, 34, 67, 90
                                  },5).Dump();
        }
        public int books(List<int> A, int B)
        {
            if (A.Count < B)
                return -1;

            long hi = A.Sum();
            long lo = A.Max();
            int students =0;
            var res = int.MaxValue;
            while (lo <= hi)
            {
                var mid = lo + (hi - lo) / 2;
                students = this.getStudents(A, mid);
                if (IsPossible(A, mid, B))
                {
                    hi = mid -1;
                    res = (int)Math.Min(mid, res);
                }
                else
                {
                    lo = (mid + 1);
                }
            }
            return (int)res;
        }

        public bool IsPossible(List<int> books, long mid, int nos)
        {
            int students = 1;
            int pages = 0;

            foreach (var book in books)
            {

                if (book > mid)
                {
                    return false;
                }
                if (book + pages <= mid)
                {
                    pages += book;
                }
                else
                {
                    students++;
                    pages = book;
                    if (students > nos)
                    {
                        return false;
                    }
                }

            }
            return true;
        }

        private int getStudents(List<int> books, long mid)
        {
            var total = 0;
            var students = 1;
            foreach (var book in books)
            {
                if (book > mid) return 0;
                total += book;
                if (total > mid)
                {
                    students++;
                    total = book;
                }
            }

            return students;
        }

        private int getMax(List<int> books, long mid)
        {
            var total = 0;
            var max = 0;
            foreach (var book in books)
            {
                total += book;
                if (total > mid)
                {
                    if (total > max)
                    {
                        max = total - book;
                    }
                    total = book;
                }
            }

            return max;
        }
    }
}