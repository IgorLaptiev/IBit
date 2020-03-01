using ConsoleDump;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExercisesAlgo.LinkedList
{
    public class PartitionList
    {
        public void Execute()
        {
            var la = new ListNode(new int[] {

                // 384 , 183 , 463 , 31
                18, 595, 253, 7, 18,984, 914, 903, 992, 522, 784, 55, 910, 123, 133, 936, 38, 774, 868, 204, 727, 927, 981, 766, 619, 848, 398, 782, 460, 444, 805, 62, 154, 35, 261, 202, 622, 472, 151, 590, 270, 115, 773, 332, 928, 298, 597, 150, 704, 229, 205, 501, 284, 497, 305, 864, 368, 995, 731, 255, 712, 614, 179, 756, 432, 415, 734, 449, 85, 817, 686, 829, 12, 564, 427, 711, 275, 109, 641, 344, 934, 760, 551, 958, 540, 446 
            });

            var result = partition(la,18);
            while (result != null)
            {
                result.val.Dump();
                result = result.next;
            }
        }

        public ListNode partition(ListNode A, int B)
        {
            ListNode less = null;
            ListNode lesstail = null;
            ListNode more = null;
            ListNode moretail = null;
            while (A != null)
            {
                if (A.val < B)
                {
                    lesstail = Add(lesstail, A);
                    if (less == null)
                    {
                        less = lesstail;
                    }
                }
                else
                {
                    moretail = Add(moretail, A);
                    if (more == null)
                    {
                        more = moretail;
                    }
                }
                A = A.next;
            }
            ListNode res = less ?? more;
            if (lesstail != null)
            {
                lesstail.next = more;
            }
            if (moretail != null) moretail.next = null;
            return res;
        }

        private bool checkExist(ListNode A, int B)
        {
            while (A != null)
            {
                if (A.val < B) return true;
                    A = A.next;
            }
            return false;
        }

        private ListNode Add(ListNode tail, ListNode a)
        {
            if (tail == null)
            {
                tail = a;
            }
            else
            {
                tail.next = a;
                tail = tail.next;
            }
            return tail;
        }
    }
}
