using ConsoleDump;

namespace ExercisesAlgo.LinkedList
{
    public class Swap2Nodes
    {
        public void Execute()
        {
            var la = new ListNode(1)
            {
                next = new ListNode(2)
                {
                    next = new ListNode(3)
                    {
                        next = new ListNode(4)
                        {
                            next = new ListNode(5)
                            {
                                next = new ListNode(6)
                                {
                                    next = new ListNode(7)
                                }
                            }
                        }

                    }
                }
            };

            var result = swapPairs(la);
            while (result != null)
            {
                result.val.Dump();
                result = result.next;
            }
        }

        public ListNode swapPairs(ListNode A)
        {
            ListNode head = null;
            ListNode tail = null;

            while (A != null)
            {
                A = swapNext(A);
                if (head == null)
                {
                    head = A;
                    tail = head.next;
                }
                else
                {
                    tail.next = A;
                    tail = tail.next == null? null: tail.next.next;
                }
                
                A = getNext(A);
            }
            return head;
        }

        private ListNode getNext(ListNode a)
        {
            return a.next == null? null: a.next.next;
        }

        private ListNode swapNext(ListNode a)
        {
            var node = a;
            if (a.next !=null)
            {
                node = a.next;
                var next = node.next;
                node.next = a;
                a.next = next;
            }
            return node;
        }
    }
}
