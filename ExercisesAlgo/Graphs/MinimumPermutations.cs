using ConsoleDump;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExercisesAlgo.Graphs
{
    // Node class to store a combined set of values 
    public class Node
    {
        public int[] str;
        public int steps;

        public Node(int[] str, int steps)
        {
            this.str = str.ToArray();
            this.steps = steps;
        }
    }

    public class MinimumPermutations
    {
        public static void Execute()
        {
            int[] a = // new int[] { 3, 1, 2 }; // 
            new int[] { 1, 2, 5, 4, 3 }; // { 1, 2, 4, 3 };
            minimumPrefixReversals(a).Dump();
        }

        // function to find minimum prefix reversal through BFS 
        public static int minimumPrefixReversals(int[] a)
        {
            // size of array  
            int n = a.Length;

            var start = a;
            var destination = a.OrderBy(_ => _).ToArray();
            int[] original;
            int[] modified;

            Node temp = null;

            Queue<Node> q = new Queue<Node>();

            q.Enqueue(new Node(a, 0));

            if (isEqual(a, destination))
            {
                return 0;
            }

            // loop until the size of queue is empty  
            while (q.Count != 0)
            {
                // put front node of queue in temporary variable 
                temp = q.Dequeue();

                // store the original string at this step 
                original = temp.str;
                temp.Dump();
                for (int j = 2; j <= n; j++)
                {
                    modified = original.ToArray();
                    modified = reverse(modified, j);
                    modified.Dump();
                    if (isEqual(modified,destination))
                    {
                        return temp.steps + 1;
                    }
                    q.Enqueue(new Node(modified, temp.steps + 1));
                }
                for (int j = n-3; j >= 0; j--)
                {
                    modified = original.ToArray();
                    modified = reverseEnd(modified, j);
                    if (isEqual(modified, destination))
                    {
                        return temp.steps + 1;
                    }
                    q.Enqueue(new Node(modified, temp.steps + 1));
                }
            }

            // if no case match then default value 
            return int.MaxValue;
        }

        // function to reverse the string upto an index  
        public static int[] reverse(int[] s, int index)
        {
            int i = 0;
            while (i < index)
            {
                var c = s[i];
                s[i] = s[index - 1];
                s[index - 1] = c;
                i++; index--;
            }
            return s;
        }
        public static int[] reverseEnd(int[] s, int index)
        {
            int i = s.Length-1;
            while (i > index)
            {
                var c = s[i];
                s[i] = s[index + 1];
                s[index + 1] = c;
                i--; index++;
            }
            return s;
        }
        public static Boolean isEqual(int[] a, int[] b)
        {
            if (a.Length != b.Length) return false;
            for(var i = 0; i < a.Length; i++)
            {
                if (a[i] != b[i]) return false;
            }
            return true;
        }
    }
}
