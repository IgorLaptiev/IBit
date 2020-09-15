using ConsoleDump;
using ExercisesAlgo.LinkedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExercisesAlgo.HeapsAndMaps
{
    public class NMaxPair
    {

        public static void Execute()
        {
            new NMaxPair().solve(new List<int> { 3, 2, 4, 2 }, new List<int> { 4, 3, 1, 2 }).Dump();
            //new NMaxPair().solve(new List<int> { 3, 1, 3, 1 }, new List<int> { 1, 4, 1, 4 }).Dump();
        }

        List<int> sums = new List<int>();

        ListNode sumList = new ListNode(-1);
        ListNode tail = null;

        private PriorityQueue<int> pq = new PriorityQueue<int>();
        private int N;

        public List<int> solve(List<int> A, List<int> B)
        {
            N = A.Count;
            var listA = A.OrderByDescending(a => a).ToList();
            var listB = B.OrderByDescending(b => b).ToList();
            for (int i = 0; i < listA.Count; i++)
            {
                for (int j = 0; j < listB.Count; j++)
                {
                    var sum = listA[i]+ listB[j];
                    if (i == 0)
                    {
                        pq.Enqueue(sum);
                    }
                    else if (pq.Tail() < sum)
                    {
                        pq.RemoveTail();
                        pq.Enqueue(sum);
                    }
                    else
                    {
                        break;
                    }
                }
            }

            return pq.ToList();
        }

        private void AddToList(int val)
        {
            var curr = sumList;
            while(curr.next != null && val <= curr.next.val)
            {
                curr = curr.next;
            }
            var next = curr.next;
            curr.next = new ListNode(val)
            {
                next = next,
                previous = curr
            };
            if (next == null)
            {
                tail = curr.next;
            }
            else
            {
                next.previous = curr.next;
            }

        }

        private void RemoveLast()
        {
            tail = tail.previous;
            tail.next = null;
        }

        private void Add(int val)
        {
            int i = 0;
            for (; i < sums.Count; i++)
            {
                if (val > sums[i])
                {
                    break;
                }
            }
            sums.Insert(i, val);

            if (sums.Count > N)
            {
                sums.RemoveAt(sums.Count - 1);
            }
        }


    }
}
