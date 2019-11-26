using ConsoleDump;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterviewBit.Strings
{
    public class AddBinaryStrings
    {
        public void Execute()
        {
            addBinary("1", "10").Dump();
        }

        public string addBinary(string A, string B)
        {
            if (A.Length < B.Length) return addBinary(B, A);
            var result = new Char[A.Length+1];
            var rest = false;
            B = B.PadLeft(A.Length, '0');
          
            for (int i = 0; i < A.Length; i++)
            {
                var aind = A.Length - i - 1;
                char curr;
                var first = A[aind];
                var second = B[aind];

                if (rest)
                {
                    if (first == '1' && second == '1')
                    {
                        rest = true;
                        curr = '1';
                    }
                    else if (first == '0' && second == '0')
                    {
                        rest = false;
                        curr = '1';
                    }
                    else
                    {
                        curr = '0';
                        rest = true;
                    }
                }
                else
                {
                    if (first== '1' && second == '1')
                    {
                        rest = true;
                        curr = '0';
                    }
                    else if (first == '0' && second == '0')
                    {
                        rest = false;
                        curr = '0';
                    }
                    else
                    {
                        rest = false;
                        curr = '1';
                    }
                }
              
                result[aind+1] = curr;
            }
            if (rest)
            {
                result[0] = '1'; 
            }
            return new string(result).Trim('\0');
        }
    }
}
