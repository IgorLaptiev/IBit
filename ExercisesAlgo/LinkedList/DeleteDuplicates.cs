using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ConsoleDump;

namespace ExercisesAlgo.LinkedList
{
    public class DeleteDuplicates
    {
        public void Execute()
        {
            var la = new ListNode(1)
            {
                next = new ListNode(2)
                {
                    next = new ListNode(2)
                    {
                        next = new ListNode(4)
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
            ListNode head = A;
            while (A != null)
            {
                while (A.next != null && A.val == A.next.val)
                {
                    A.next = A.next.next;
                }

                A = A.next;
            }

            return head;
        }
    }
}
