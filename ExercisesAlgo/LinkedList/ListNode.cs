using System.Collections.Generic;
using System.Linq;

namespace ExercisesAlgo.LinkedList
{
    public class ListNode
    {
        public int val;
        public ListNode next;
        public ListNode previous;

        public ListNode(int x)
        {
            this.val = x;
            this.next = null;
        }

        public ListNode(params int[] arr)
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