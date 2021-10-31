using ConsoleDump;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExercisesAlgo.Strings
{
    public class Decode
    {
        public static void Execute()
        {
            var str = "(2(3ac>)(5b))";
            Decompose(str).Dump();
        }

        static string Decompose(String str)
        {
            if (String.IsNullOrEmpty(str)) return string.Empty;
            var sb = new StringBuilder();

            for (var i = 0; i < str.Length; i++)
            {
                if (str[i] == '(')
                {
                    var num = getNumber(str, i + 1);
                    i = getCharPos(str, i + 1);
                    var s = getString(str, i);
                    for (var j = 0; j < num; j++)
                    {
                        sb.Append(s);
                    }
                    i = i + s.Length;
                }
                else if (str[i] != ')')
                {
                    sb.Append(str[i]);
                }
            }
            return sb.ToString();

        }

        static string getString(string str, int pos)
        {
            var charArray = new List<char>();
            var count = 1;
            for (var i = pos; i < str.Length; i++)
            {
                if (str[i] == '(')
                {
                    count++;
                }
                if (str[i] == ')')
                {
                    count--;
                }
                if (count == 0)
                {
                    break;
                }

                charArray.Add(str[i]);
            }
            return Decompose(new String(charArray.ToArray()));
        }

        static int getNumber(string str, int pos)
        {
            var res = 0;
            var intArray = new List<int>();
            for (var i = pos; i < str.Length; i++)
            {
                if (str[i] > '9' || str[i] == '(')
                {
                    break;
                }
                res = res * 10 + (str[i] - '0');
            }
            return res;
        }

        static int getCharPos(string str, int pos)
        {
            for (var i = pos; i < str.Length; i++)
            {
                if (str[i] > '9' || str[i] == '(')
                {
                    return i;
                }
            }
            return pos;
        }
    }
}
