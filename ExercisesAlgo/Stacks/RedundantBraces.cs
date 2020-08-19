using ConsoleDump;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExercisesAlgo.Stacks
{
    public class RedundantBraces
    {
        public void Execute()
        {
            var result = braces("((a+b))");
            result.Dump();
            result = braces("(a+(b)/c)");
            result.Dump();
            result = braces("(a+b*(c-d))");
            result.Dump();
        }

        public int braces(string A)
        {
            var brStack = new Stack<char>();
            foreach (var a in A)
            {
                if ((new[] { '/', '+', '*', '-', '(' }).Contains(a))
                {
                    brStack.Push(a);
                }
                else if (a == ')')
                {
                    while (brStack.Count > 0)
                    {
                        var ch = brStack.Pop();
                        if (ch == '(')
                        {
                            return 1;
                        }
                        else
                        {
                            while (brStack.Count > 0 && brStack.Pop() != '(')
                            {
                            }
                            break;
                        }
                    }
                }
            }
            return 0;
        }
    }
}
