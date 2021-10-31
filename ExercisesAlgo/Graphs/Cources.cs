using ConsoleDump;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExercisesAlgo.Graphs
{
    /*
     * There are a total of A courses you have to take, labeled from 1 to A.

Some courses may have prerequisites, for example to take course 2 you have to first take course 1, which is expressed as a pair: [1,2].

Given the total number of courses and a list of prerequisite pairs, is it possible for you to finish all courses?

Return 1 if it is possible to finish all the courses, or 0 if it is not possible to finish all the courses.

Input Format:

The first argument of input contains an integer A, representing the number of courses.
The second argument of input contains an integer array, B.
The third argument of input contains an integer array, C.
Output Format:

Return a boolean value:
    1 : If it is possible to complete all the courses.
    0 : If it is not possible to complete all the courses.
Constraints:

1 <= A <= 6e4
1 <= length(B) = length(C) <= 1e5
1 <= B[i], C[i] <= A
Example:

Input 1:
    A = 3
    B = [1, 2]
    C = [2, 3]

Output 1:
    1

Explanation 1:
    It is possible to complete the courses in the following order:
        1 -> 2 -> 3

Input 2:
    A = 2
    B = [1, 2]
    C = [2, 1]

Output 2:
    0

Explanation 2:
    It is not possible to complete all the courses.
     */
    public class Cources
    {

        public static void Execute()
        {
            new Cources().solve(3, new List<int> { 1, 2, 3 }, new List<int> { 2, 3, 1 }).Dump();
            new Cources().solve(3, new List<int> { 1, 1, 2 }, new List<int> { 2, 3, 3 }).Dump();
        }

        public int solve(int A, List<int> B, List<int> C)
        {
            if (B.Count == 0) return 1;
            var dict = new Dictionary<int, List<int>>();
            for (int i = 0; i < B.Count; i++)
            {
                if (!dict.ContainsKey(B[i]))
                {
                    dict[B[i]] = new List<int>();
                }
                dict[B[i]].Add(C[i]);
            }
            var recStack = new bool[A+1];
            var visited = new bool[A+1];
            return HasCycle(dict, recStack, visited, dict.Keys.First())? 0: 1;
        }

        private bool HasCycle(Dictionary<int, List<int>> dict, bool[] recStack, bool[] visited, int v)
        {
            if (!dict.ContainsKey(v)) return false;
            if (recStack[v]) return true;
            recStack[v] = visited[v] = true;
            return dict[v].Any(vert => HasCycle(dict, recStack, visited, vert));
        }
    }
}
