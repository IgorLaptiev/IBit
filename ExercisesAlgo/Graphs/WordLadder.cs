using ConsoleDump;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExercisesAlgo.Graphs
{
    public class WordLadder
    {
        public static void Execute()
        {
            new WordLadder().solve("hit", "cog", new List<string> { "hot", "dot", "dog", "lot", "log" }).Dump();
            new WordLadder().solve("ymain", "oecij", new List<string> { "ymann", "yycrj", "oecij", "ymcnj", "yzcrj", "yycij", "xecij", "yecij", "ymanj", "yzcnj", "ymain" }).Dump();

                new WordLadder().solve("sgtra", "plvgf", new List<string> { "pjvgf", "pgtra", "pglga", "pgwra", "pgggf", "pglra", "ppggf", "ppvgf", "pggga", "sgtra", "plvgf" }).Dump();
        }

        public int solve(string A, string B, List<string> C)
        {
            var visited = new Dictionary<string,bool>();
            var q = new Queue<string>();
            var cnt = 0;
            q.Enqueue(A);
            q.Enqueue(null);
            while (q.Count > 0)
            {
                var curr = q.Dequeue();
                if (curr == null)
                {
                    cnt++;
                    q.Enqueue(null);
                    continue;
                }
                if (isOneCharDiff(curr, B))
                {
                    cnt++;
                    Console.WriteLine($"{curr} -> {B} ({cnt})");
                    break;
                }
                foreach (var word in C)
                {
                    if (isOneCharDiff(curr, word) && !visited.ContainsKey(word))
                    {
                            q.Enqueue(word);
                            visited[word] = true;
                            Console.WriteLine($"{curr} -> {word} ({cnt})");
                    }
                }

            }
            return cnt +1;
        }

        public int solveDFS(string A, string B, List<string> C)
        {
            var visited = new Dictionary<string, bool>();
            return solve(A, B, C, visited);
        }

        public int solve(string A, string B, List<string> C, Dictionary<string, bool> visited )
        {
            if (isOneCharDiff(A, B))
            {
                Console.WriteLine($"{A} -> {B} ({1})");
                return 1;
            }
            if (visited.ContainsKey(A)) return -1;
            visited[A] = true;
            var minWay = Int32.MaxValue;
            foreach (var word in C)
            {
                if (isOneCharDiff(A, word) && !visited.ContainsKey(word))
                {
                    var curr = solve(word, B, C, visited);
                    if (curr>0 && curr < minWay)
                    {
                        minWay = curr;
                        Console.WriteLine($"{A} -> {word} ({minWay+1})");
                    }
                }
            }
            return minWay + 1;
        }
        private bool isOneCharDiff(string str1, string str2)
        {
            var cnt = 0;
            for (var i = 0; i < str1.Length; i++)
            {
                if (str1[i] != str2[i])
                {
                    cnt++;
                }
                if (cnt > 1)
                {
                    return false;
                }
            }
            return cnt == 1;
        }
    }
}
