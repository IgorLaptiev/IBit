using ConsoleDump;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExercisesAlgo.Stacks
{
    public class NearestSmallerElement
    {
        public void Execute()
        {
            //var result = prevSmaller(new List<int>{ 4, 5, 2, 10, 8 });
            var result = prevSmaller(new List<int> { 39, 27, 11, 4, 24, 32, 32, 1 });
            result.Dump();
        }

        public List<int> prevSmaller(List<int> A)
        {
            var minStack = new Stack<int>();
            var result = new List<int>();
            foreach (var item in A)
            {
                while (minStack.Count > 0 && minStack.Peek() >= item)
                {
                    minStack.Pop();
                }
                if (minStack.Count > 0)
                {
                    result.Add(minStack.Peek());
                }
                else
                {
                    result.Add(-1);
                }
                minStack.Push(item);
            }
            return result;
        }
    }
}
