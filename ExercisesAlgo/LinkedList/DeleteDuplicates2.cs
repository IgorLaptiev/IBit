using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ConsoleDump;

namespace ExercisesAlgo.LinkedList
{
    public class DeleteDuplicates2
    {
        public void Execute()
        {
            var la = new ListNode(1)
            {
                next = new ListNode(2)
                {
                    next = new ListNode(2)
                    {
                        next = new ListNode(3)
                        {
                            next = new ListNode(3)
                            {
                                next = new ListNode(4)
                                {
                                    next = new ListNode(4)
                                }
                            }
                        }

                    }
                }
            };

            var result = deleteDuplicates(la);
            while (result != null)
            {
                result.val.Dump();
                result = result.next;
            }
        }

        public ListNode deleteDuplicates(ListNode A)
        {
            if (A == null || A.next == null) return A;
            ListNode prev = null;
            ListNode current = A;
            ListNode next = A.next;
            while (current != null)
            {
                while (next != null && next.val == current.val)
                {
                    next = next.next;
                }
                if (next == current.next)
                {
                    prev = current;
                    current = next;
                }
                else if (prev == null)
                {
                    A = next;
                    current = next;
                }
                else
                {
                    prev.next = next;
                    current = next;

                }

                if (next != null) next = next.next;
            }
            return A;
        }
    }
}
