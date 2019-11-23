using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ConsoleDump;

namespace ExercisesAlgo.Strings
{
    public class PowerOf2
    {
        public void Execute()
        {
            mult("5131848155574784703269632922904933776792735241197982102373370", "56675688419586288442134264892419611145485574406534291250836").Dump();

        }

        public int power(string A)
        {
            var strNum = A;
            while (strNum.Length >0)
            {
                strNum = Devide(strNum);
                strNum.Dump();
                if (strNum == "1")
                {
                    return 1;
                }
                if (strNum == "-1")
                {
                    return 0;
                }
            }

            return 1;
        }

        private string Devide(string strNum)
        {
            if ((strNum[strNum.Length - 1] - '0') % 2 != 0) return "-1";

            var res = new StringBuilder();
            var tmp = strNum.ToCharArray();
            int dividend = 0;
            int reminder=0;

            for (int i = 0; i < tmp.Length;)
            {
                dividend = dividend *10+ (tmp[i] - '0');

                if (dividend < 2)
                {
                    res.Append("0");
                }
                else
                {
                    var d = dividend / 2;
                    reminder = dividend % 2;

                    res.Append(d.ToString());
                    dividend = reminder;
                    // tmp[i] = reminder.ToString()[0];
                }

                i++;

                if (reminder > 0 && i == tmp.Length )
                {
                    return "-1";
                }
            }
            return res.ToString().TrimStart('0');
        }

        public string mult(string A, string B)
        {
            int aLength = A.Length;
            int bLength = B.Length;
            var result = new string('0', aLength + bLength).ToCharArray(); 
            for (int i = aLength - 1; i >= 0; i--)
            {
                for (int j = bLength - 1; j >= 0; j--)
                {
                    int p = (A[i] - '0') * (B[j] - '0') + (result[i + j + 1] - '0');
                    result[i + j + 1] = (char)(p % 10 + '0');
                    result[i + j] = (char)(result[i + j] + p / 10);
                }
            }
            for (int i = 0; i < aLength + bLength; i++)
                if (result[i] != '0')
                    return new string(result).Substring(i);
            return "0";
        }

        public string multiply(string A, string B)
        {
            if (A == "0") return "0";
            if (B == "0") return "0";
            if (A == "1") return B;
            if (B == "1") return A;
            var res = "0";
            var strB = new StringBuilder();
            for (int i = B.Length -1; i >=0; i--)
            {
                var mult1 = B[i] - '0';
                string tmpres= "0";
                var strA = new StringBuilder();
                for (int j = A.Length-1; j >=0; j--)
                {
                    var mult2 = A[j] - '0';
                    var mult = (mult1 * mult2).ToString();
                    tmpres = Add(tmpres, String.Concat(mult, strA.ToString()));
                    strA.Append("0");
                }

                res = Add(res, String.Concat(tmpres, strB.ToString()));
                strB.Append("0");
            }

            return res.TrimStart('0');
        }

        private string Add(string num1, string num2)
        {
            if (num1.Length < num2.Length) return Add(num2, num1);
            var result = new Char[num1.Length + 1];
            var rem = false;
            num2 = num2.PadLeft(num1.Length, '0');
            for (int i = num1.Length - 1; i >= 0; i--)
            {
                var dig1 = num1[i] - '0';
                var dig2 = num2[i] - '0';
                var res = dig1 + dig2 + (rem?1:0);
                rem = res >= 10;
                result[i+1] = rem? (res-10).ToString()[0]: res.ToString()[0];
            }

            result[0] = rem?'1':'0';
            return new string(result);
        }
    }
}
