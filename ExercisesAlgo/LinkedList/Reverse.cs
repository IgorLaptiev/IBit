using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ConsoleDump;

namespace ExercisesAlgo.LinkedList
{
    public class Reverse
    {
        public void Execute()
        {
            var la = new ListNode(2);
            var n = new ListNode(4);
            la.next = new ListNode(1)
                          {
                              next = new ListNode(2)
                                         {
                                             next = n
                                         }
                          };

            var result = reverseList(la);
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
    }
}
