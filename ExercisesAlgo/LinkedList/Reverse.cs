using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ConsoleDump;

using InterviewBit.Strings;

namespace ExercisesAlgo.LinkedList
{
    public class Reverse
    {
        public void Execute()
        {
            var la = new ListNode(1);
            var n = new ListNode(4)
                        {
                            next = new ListNode(5)
                        };
            la.next = new ListNode(2)
                          {
                              next = new ListNode(3)
                                         {
                                             next = n
                                         }
                          };

            var result = reverseBetween(la,2,4);
            while (result != null)
            {
                result.val.Dump();
                result = result.next;
            }
        }

        public ListNode reverseList(ListNode A)
        {
            ListNode newHead = null;

            while (A != null)
            {
                var next = newHead;
                newHead = A;
                var anext = A.next;
                newHead.next = next;
                A = anext;
            }

            return newHead;
        }

        public ListNode reverseBetween(ListNode A, int B, int C)
        {
            var current = 1;
            var head = A;
            if (B == 1)
            {
                return reverse(A, C);
            }

            while (A!=null)
            {
                if (current == B - 1)
                {
                    var next = reverse(A.next, C-B+1);
                    A.next = next;
                    return head;
                }

                A = A.next;
                current++;
            }

            return head;
        }

        public ListNode reverse(ListNode A, int count)
        {
            ListNode newHead = null;
            ListNode tail = A;
            var current = 1;
            while (A != null)
            {
                if (current <= count)
                {
                    var next = newHead;
                    newHead = A;
                    var anext = A.next;
                    newHead.next = next;
                    A = anext;
                 //tail = getTail(newHead);
                }
                else if (current > count)
                {
                    tail.next = A;
                    return newHead;
                }

                current++;
            }

            return newHead;
        }

        private ListNode getTail(ListNode newHead)
        {
            while (newHead.next != null)
            {
                newHead = newHead.next;
            }

            return newHead;
        }
    }
}
