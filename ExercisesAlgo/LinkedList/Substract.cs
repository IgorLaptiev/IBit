using ConsoleDump;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExercisesAlgo.LinkedList
{
    public class Substract
    {
        public void Execute()
        {
            var a = new ListNode(42, 68, 1, 2, 4, 8);
            var result = subtract(a);
            while (result != null)
            {
                result.val.Dump();
                result = result.next;
            }
        }

        public ListNode subtract(ListNode A)
        {
            var currnode = A;
            var count = 0;
            while (currnode != null)
            {
                count++;
                currnode = currnode.next;
            }
            var half = (int)(Math.Floor((double)(count / 2)));
            var reverse = new ListNode(0);
            currnode = A;
            while (currnode != null)
            { 
                var next = reverse.next;
                reverse.next = new ListNode(currnode.val);
                reverse.next.next = next;
                currnode = currnode.next;
            }
            currnode = A;
            var currev = reverse.next;
            var i = 0;
            while (i < half)
            {
                i++;
                currnode.val = currev.val - currnode.val;
                currnode = currnode.next;
                currev = currev.next;
            }
            return A;
        }
    }
}
