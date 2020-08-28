using ConsoleDump;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExercisesAlgo.Recursion
{
    public class LetterPhone
    {

        Dictionary<char, List<char>> recode = new Dictionary<char, List<char>>
        {
            {'0', new List<char> {'0'}},
            {'1', new List<char> {'1'}},
            {'2', new List<char> {'a','b','c'}},
            {'3', new List<char> {'d','e','f'}},
            {'4', new List<char> {'g','h','i'}},
            {'5', new List<char> {'j','k','l'}},
            {'6', new List<char> {'m','n','o'}},
            {'7', new List<char> {'p','q','r','s'}},
            {'8', new List<char> {'t','u','v'}},
            {'9', new List<char> {'w','x','y','z'}}
        };

        List<string> result = new List<string>();

        public void Execute()
        {
            var subs = letterCombinations("24");
            subs.ForEach(s => s.Dump());
        }

        public List<string> letterCombinations(string A)
        {
            letterCombinations(A, 0, new List<string>());
            return result;
        }

        private void letterCombinations(string str, int ind, List<string> current)
        {
            if (ind >= str.Length)
            {
                result.Add(string.Join("", current));
                return;
            }
            var recChars = recode[str[ind]];
            foreach (var recChar in recChars)
            {
                current.Add(recChar.ToString());
                letterCombinations(str, ind +1, current);
                current.RemoveAt(current.Count - 1);
            }
        }
    }
}
