using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ConsoleDump;

namespace ExercisesAlgo.Strings
{
    public class JsonFormatter
    {
        public void Execute()
        {
            prettyJSON("{A:\"B\",C:{D:\"E\",F:{G:\"H\",I:\"J\"}}}").Dump();
            //prettyJSON("{\"id\":100,\"firstName\":\"Jack\",\"lastName\":\"Jones\",\"age\":12}").Dump();
        }

        public List<string> prettyJSON(string A)
        {
            var currentIndent = 0;
            var result = new List<string>();
            var openBrackets = new List<char> { '{', '[' };
            var closeBrackets = new List<char> { '}', ']' };
            var lineBreakChars = new List<char>() {','};
            //lineBreakChars.AddRange(openBrackets);
            //lineBreakChars.AddRange(closeBrackets);
            var strb = new StringBuilder();
            foreach (var currentChar in A)
            {
                if (openBrackets.Contains(currentChar))
                {
                    if (strb.Length > 0)
                    {
                        strb.Insert(0, new String('\t', currentIndent));
                        result.Add(strb.ToString());
                        strb.Length =0;
                    }

                    strb.Append(currentChar);
                    strb.Insert(0, new String('\t', currentIndent));
                    result.Add(strb.ToString());
                    strb.Length = 0;
                    currentIndent++;
                }
                else if (closeBrackets.Contains(currentChar))
                {
                    if (strb.Length > 0)
                    {
                        strb.Insert(0, new String('\t', currentIndent));
                        result.Add(strb.ToString());
                        strb.Length = 0;
                    }
                    strb.Append(currentChar);

                    currentIndent--;
                }
                else if (lineBreakChars.Contains(currentChar))
                {
                    strb.Append(currentChar);
                    strb.Insert(0, new String('\t', currentIndent));
                    result.Add(strb.ToString());
                    strb.Length = 0;
                }
                else
                {
                    strb.Append(currentChar);

                }

            }

            if (strb.Length > 0)
            {
                strb.Insert(0, new String('\t', currentIndent));
                result.Add(strb.ToString());
            }

            return result;
        }
    }
}
