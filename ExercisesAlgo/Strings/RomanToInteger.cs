using ConsoleDump;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterviewBit.Strings
{
    public class RomanToInteger
    {
        public void Execute()
        {
            //romanToInt("XIV").Dump();
            //romanToInt("XX").Dump();
            //romanToInt("MCMXII").Dump();
            //romanToInt("MMXIX").Dump();
            intToRoman(49).Dump();
            intToRoman(1000).Dump();
            intToRoman(500).Dump();
            intToRoman(400).Dump();
            intToRoman(450).Dump();
           
        }

        public int romanToInt(string A)
        {
            var digits = new Dictionary<char, int>
            {
                {'I',1 },
                {'V',5 },
                {'X',10 },
                {'L',50 },
                {'C',100 },
                {'D',500 },
                {'M',1000 },
            };

            var number = 0;
            int i = 0;
            for (; i < A.Length-1; i++)
            {
                var current = digits[A[i]];
                var next = digits[A[i+1]];
                if (current < next)
                {
                    number += next - current;
                    i++;
                }
                else
                {
                    number += current;
                }
            }
            if (i < A.Length)
            {
                var current = digits[A[i]];
                number += current;
            }
            return number;
        }

        public string intToRoman(int A)
        {
            var digits = new Dictionary<int, char>
            {{1000, 'M' },
                {500, 'D' },
                {100,'C' },
                {50, 'L'},
                {10, 'X' },
                {5, 'V'},
                {1, 'I'},
               
            };
            var number = A;
            var result = "";
            foreach (var dig in digits)
            {
                if (number == 0) break;
                if (number / dig.Key > 0)
                {
                    var cnt = number / dig.Key;
                    for (int i = 0; i < cnt; i++)
                    {
                        result += dig.Value;
                        number -= dig.Key;
                    }
                }
                if (dig.Key > 100 && (number + 100) / dig.Key > 0)
                {
                    for (int i = 0; i < number / dig.Key; i++)
                    {
                        result += dig.Value;
                        number -= dig.Key;
                    }
                    result += "C";
                    number += 100;
                    result += dig.Value;
                    number -= dig.Key;
                }
                if (dig.Key > 10 && (number + 10) / dig.Key > 0)
                {
                    for (int i = 0; i < number / dig.Key; i++)
                    {
                        result += dig.Value;
                        number -= dig.Key;
                    }
                    result += "X";
                    number += 10;
                    result += dig.Value;
                    number -= dig.Key;
                }
                if (dig.Key > 1 && (number +1) / dig.Key >0)
                {
                    for (int i = 0; i < number / dig.Key; i++)
                    {
                        result += dig.Value;
                        number -= dig.Key;
                    }
                    result += "I";
                    number += 1;
                    result += dig.Value;
                    number -= dig.Key;
                }
               
               
            }
            return result;
        }
    }
}
