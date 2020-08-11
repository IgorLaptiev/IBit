using ConsoleDump;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExercisesAlgo.LinkedList
{
    public class ReverseAlternative
    {
        public void Execute()
        {
            var a = new ListNode(42, 68, 35, 1, 8, 12);
            var result = solve(a, 3);
            while (result != null)
            {
                result.val.Dump();
                result = result.next;
            }
        }

        public ListNode solve(ListNode A, int B)
        {
            var head = new ListNode(0);
            head.next = A;
            var current = head;
            var round = 0;
            while (current != null)
            {
                if (round % 2 == 0)
                {
                    current = flipNext(current, B);
                }
                else
                {
                    current = skipNext(current, B);
                }
                round++;
            }
            return head.next;
        }

        private ListNode flipNext(ListNode start, int steps)
        {
            var head = start;
            var current = head.next;
            for (var i = 1; i < steps && current != null && current.next != null; i++)
            {
                var move = current.next;
                current.next = move.next;
                move.next = head.next;
                head.next = move;
            }
            return current;
        }
        private ListNode skipNext(ListNode start, int steps)
        {
            var current = start.next;
            for (var i = 1; i < steps && current != null; i++)
            {
                current = current.next;
            }
            return current;
        }
    }
}
