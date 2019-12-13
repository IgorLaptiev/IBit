using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ConsoleDump;

namespace ExercisesAlgo.LinkedList
{
    public class Intersection
    {

        public void Execute()
        {
            var la = new ListNode(2);
            var lb = new ListNode(3);
            var n = new ListNode(4);
            la.next = new ListNode(1)
              {
                  next = new ListNode(2)
                             {
                                 next = n
                             }
              };
            lb.next = n;
            getIntersectionNode(la, lb).val.Dump();
        }

        public ListNode getIntersectionNode(ListNode a, ListNode b)
        {
            int aL = length(a);
            int bL = length(b);
            if (aL >= bL)
            {
                return getIntersectionNode(a, b, aL, bL);
            }
            else
            {
                return getIntersectionNode(b, a, bL, aL);
            }
        }

        public ListNode getIntersectionNode(ListNode a, ListNode b, int aL, int bL)
        {
            int n = aL - bL;
            while (n != 0)
            {
                a = a.next;
                n--;
            }
            if (a== b) return a;
            while (a.next != null)
            {
                if (a.next == b.next) return a.next;
                a = a.next;
                b = b.next;
            }

            return null;
        }

        private int length(ListNode list)
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
