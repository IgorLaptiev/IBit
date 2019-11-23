using System.Collections.Generic;

using ConsoleDump;

namespace ExercisesAlgo.Mathe
{
    public class RearrangeArray
    {
        public void Execute()
        {
            arrange(new List<int>() { 1,0}).Dump();
        }

        public List<int> arrange(List<int> a)
        {
            var max = a.Count;
            for (int i = 0; i < a.Count; i++)
            {
                a[i] += (a[a[i]] % max) * max;
            }

            for (int i = 0; i < a.Count; i++)
            {
                a[i] /= max;
            }

            return a;
        }

    }
}