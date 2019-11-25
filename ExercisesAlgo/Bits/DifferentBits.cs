using ConsoleDump;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterviewBit.BitManipulation
{
    public class DifferentBits
    {

        public void Execute()
        {
            cntBits(new List<int> { 1,3,5 }).Dump();
        }

        public int cntBits(List<int> A)
        {
            long sum = 0;
            for (int i = 0; i < 32; i++)
            {
                long count = 0;
                for (int j = 0; j < A.Count; j++)
                {
                    if ((A[j] & (1 << i)) == 0)
                    {
                        count++;
                    }
                }
                sum += (count * (A.Count - count) * 2);
            }
            return (int)(sum % 1000000007);
        }

        private int cntBits(int number)
        {
            int count = 0;
            while (number > 0)
            {
                count += number % 2;
                number = number >> 1;
            }
            return count % 1000000007;
        }
    }
}
