using ConsoleDump;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExercisesAlgo.Recursion
{
    public class Parentheses
    {
        public void Execute()
        {
            GenerateParenthesis(3).Dump();
        }

        public IList<string> GenerateParenthesis(int n)
        {
            var result = new List<string>();
            AddOpen(result, new List<char>(), n, 0, 0);
            return result;
        }

        private void AddOpen(IList<string> result, List<char> current, int n, int countOpened, int countClosed)
        {
            if (countOpened < n)
            {
                current.Add('(');
                countOpened++;
            }
            if (countOpened < n)
            {
                AddOpen(result, current, n, countOpened, countClosed);
            }
            if (countClosed < countOpened)
            {
                AddClose(result, current, n, countOpened, countClosed);
            }
            current.RemoveAt(current.Count - 1);
        }

        private void AddClose(IList<string> result, List<char> current, int n, int countOpened, int countClosed)
        {
            if (countClosed >= countOpened) return;
            current.Add(')');
            countClosed++;
            if (countClosed == n)
            {
                result.Add(new string(current.ToArray()));
            }

            if (countOpened < n)
            {
                AddOpen(result, current, n, countOpened, countClosed);
            }
            if (countClosed < countOpened)
            {
                AddClose(result, current, n, countOpened, countClosed);
            }
            current.RemoveAt(current.Count - 1);
        }
    }
}
