using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleDump;

namespace ExercisesAlgo.LinkedList
{
    public class Removenth
    {
        public void Execute()
        {
            var l = new ListNode(1)
            {
                next = new ListNode(2)
                {
                    next = new ListNode(3)
                    {
                        next = new ListNode(4)
                    }
                }
            };
            var result = removeNthFromEnd(l, 4);
            while (result != null)
            {
                result.val.Dump();
                result = result.next;
            }

        }

        public ListNode removeNthFromEnd(ListNode A, int B)
        {
            var head = A;
            var length = Length(A);
            if (B >= length)
            {
                return A.next;
            }

            for (int i = 1; i < length - B; i++)
            {
                A = A.next;
            }

            A.next = A.next.next;
            return head;
        }

        public int Length(ListNode A)
        {
            var cnt = 0;
            while (A != null)
            {
                cnt++;
                A = A.next;
            }

            return cnt;
        }
    }
}
