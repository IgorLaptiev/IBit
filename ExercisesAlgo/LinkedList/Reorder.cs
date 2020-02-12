using ConsoleDump;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExercisesAlgo.LinkedList
{
    public class Reorder
    {
        public void Execute()
        {
            var la = new ListNode(1)
            {
                //next = new ListNode(2)
                //{
                //    next = new ListNode(3)
                //    {
                //        next = new ListNode(4)
                //        {
                //            next = new ListNode(5)
                //            {
                //                next = new ListNode(6)
                //                {
                //                    next = new ListNode(7)
                //                }
                //            }
                //        }

                //    }
                //}
            };
            var result = reorderList(la);
            while (result != null)
            {
                result.val.Dump();
                result = result.next;
            }
        }

        public ListNode reorderList(ListNode A)
        {
            var length = Length(A);
            var i = 1;
            var current = A;
            while(i < length/2)
            {
                current = current.next;
                i++;
            }
            var half = reverse(current.next);
            current.next = null;
            current = A;
            while (current != null)
            {
                var next = current.next;
                var hnext = half.next;
                current.next = half;
                if (next != null)
                {
                    half.next = next;
                }
                current = next;
                half = hnext;
            }
            return A;
        }

        public ListNode reverse(ListNode head)
        {
            var current = head;
            while (current.next != null)
            {
                var newhead = current.next;
                current.next = newhead.next;
                newhead.next = head;
                head = newhead;
            }
            return head;
        }

        public ListNode reorderList2(ListNode A)
        {
            var length = Length(A);
            reorderInnerList(A, length);
            return A;
        }

        private ListNode reorderInnerList(ListNode A, int length)
        {
            if (length == 1) return A;
            if (length == 2) return A.next;
            var head = A;
            var tail = reorderInnerList(head.next, length -2);
            var headnext = head.next;
            head.next = tail.next;
            if (tail.next != null)
            {
                var newtail = tail.next.next;
                head.next.next = headnext;
                tail.next = newtail;
            }
            return tail;
        }

        private int Length(ListNode list)
        {
            int length = 1;
            while (list.next != null)
            {
                length++;
                list = list.next;
            }

            return length;
        }

    }
}
