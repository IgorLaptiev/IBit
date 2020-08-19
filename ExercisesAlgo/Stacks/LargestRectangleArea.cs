using ConsoleDump;
using System.Collections.Generic;

namespace ExercisesAlgo.Stacks
{
    public class LargestRectangleArea
    {
        public void Execute()
        {
            var result = largestRectangleArea(new List<int> { 2, 1, 5, 6, 2, 3 });
            //var result = largestRectangleArea(new List<int> { 1, 2, 4});
            result.Dump();
        }

        public int largestRectangleArea(List<int> A)
        {
            var lstack = new Stack<int>();
            var max = 0;
            var i = 0;
            while(i < A.Count)
            {
                if (lstack.Count == 0 || A[lstack.Peek()] <= A[i])
                {
                    lstack.Push(i++);
                }
                else
                {
                    var h = A[lstack.Pop()];
                    var l = lstack.Count > 0 ? lstack.Peek() + 1: 0;
                    var area = (i - l) * h;
                    if (area > max)
                    {
                        max = area;
                    }
                }
            }
            while (lstack.Count > 0)
            {
                var h = A[lstack.Pop()];
                var l = lstack.Count > 0 ? lstack.Peek() + 1 : 0;
                var area = (i - l) * h;
                if (area > max)
                {
                    max = area;
                }
            }
            return max;
        }
    }
}
