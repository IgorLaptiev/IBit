using ConsoleDump;

namespace ExercisesAlgo.LinkedList
{
    public class EvenReverse
    {
        public void Execute()
        {
            var a = new ListNode(1, 2, 3); //new ListNode(42, 68, 1, 2, 4, 8);
            var result = solve(a);
            while (result != null)
            {
                result.val.Dump();
                result = result.next;
            }
        }

        public ListNode solve(ListNode A)
        {
            var odd = new ListNode(-1);
            var even = new ListNode(-1);
            var current = A;
            var headOdd = odd;
            var headEven = even;
            var i = 1;
            while (current != null)
            {
                if (i % 2 == 0)
                {
                    even.next = current;
                    even = even.next;
                }
                else
                {
                    odd.next = current;
                    odd = odd.next;
                }
                current = current.next;
                i++;
            }
            odd.next = null;
            even.next = null;
            current = headEven.next;
            while(current !=null && current.next != null)
            {
                var move = current.next;
                current.next = move.next;
                move.next = headEven.next;
                headEven.next = move;
            }
            odd = headOdd.next;
            even = headEven.next;
            while (odd != null && even != null)
            {
                var nextodd = odd.next;
                var nexteven = even.next;
                odd.next = even;
                even.next = nextodd;
                odd = nextodd;
                even = nexteven;
            }
            return headOdd.next;
        }
    }
}
