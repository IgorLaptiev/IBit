using ConsoleDump;
using ExercisesAlgo.LinkedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExercisesAlgo.Recursion
{
    public class ReverseListRec
    {
        ListNode head = null;
        public void Execute()
        {
            var result = reverseList(new ListNode(4, 3,2,1));
            while (result != null)
            {
                result.val.Dump();
                result = result.next;
            }
        }

        public ListNode reverseList(ListNode A)
        {
            if (A == null) return null;
            if (A.next == null) return A;

            var head = reverseList(A.next);
            var next = A.next;
            next.next = A;
            A.next = null;
            return head;
        }
    }
}
