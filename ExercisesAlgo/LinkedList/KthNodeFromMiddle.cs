using ConsoleDump;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExercisesAlgo.LinkedList
{
    public class KthNodeFromMiddle
    {
        public void Execute()
        {
            var a = new ListNode(42, 68,1,2,4,8);
            var result = solve(a, 2);
            result.Dump();
        }

        public int solve(ListNode A, int B)
        {
            var fast = A;
            var slow = A;
            ListNode Bth = null;
            var cnt = 0;
            while (fast != null && fast.next != null)
            {
                cnt++;
                if (cnt == B)
                {
                    Bth = A;
                }
                else if (cnt > B)
                {
                    Bth = Bth.next;
                }
                slow = slow.next;
                fast = fast.next.next;
            }
            return Bth.val;
        }
    }
}
