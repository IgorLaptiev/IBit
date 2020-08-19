using ConsoleDump;
using System.Collections.Generic;
using System.Text;

namespace ExercisesAlgo.Stacks
{
    public class FirstNRcharacter
    {
        public void Execute()
        {
            solve("jhhjq").Dump();
            solve2("jhhjq").Dump();
            solve("jyhrcwuengcbnuchctluxjgtxqtfvrebveewgasluuwooupcyxwgl").Dump();
            solve2("jyhrcwuengcbnuchctluxjgtxqtfvrebveewgasluuwooupcyxwgl").Dump();
        }

        public string solve(string A)
        {
            var result = new StringBuilder();
            var q = new Queue<char>();
            var counts = new Dictionary<char, int>();
            foreach (var c in A)
            {
                if (!counts.ContainsKey(c))
                {
                    q.Enqueue(c);
                    counts[c] = 1;
                }
                else
                {
                    counts[c]++;
                    while (q.Count > 0 && counts.ContainsKey(q.Peek()) && counts[q.Peek()] > 1)
                    {
                        q.Dequeue();
                    }
                }
                if (q.Count > 0)
                {
                    result.Append(q.Peek());
                }
                else
                {
                    result.Append("#");
                }
            }
            return result.ToString();
        }

        public string solve2(string A)
        {
            var result = new StringBuilder();
            var q = new List<char>();
            var counts = new Dictionary<char, int>();
            foreach (var c in A)
            {
                if (!counts.ContainsKey(c))
                {
                    q.Add(c);
                }
                else
                {
                    q.Remove(c);
                }
                counts[c] = 1;
                if (q.Count > 0)
                {
                    result.Append(q[0]);
                }
                else
                {
                    result.Append("#");
                }
            }
            return result.ToString();
        }
    }
}
