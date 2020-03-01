using System.Collections.Generic;
using System.Linq;

namespace ExercisesAlgo.LinkedList
{
    public class ListNode
    {
        public int val;
        public ListNode next;

        public ListNode(int x)
        {
            this.val = x;
            this.next = null;
        }

        public ListNode(int[] arr)
        {
            val = arr[0];
            var nexts = arr.Skip(1).ToArray();
            if (nexts.Length != 0)
            {
                next = new ListNode(nexts);
            }
        }
    }
}