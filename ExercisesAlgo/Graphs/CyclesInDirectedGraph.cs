using ConsoleDump;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExercisesAlgo.Graphs
{
    public class CyclesInDirectedGraph
    {
        public static void Execute()
        {
            new CyclesInDirectedGraph().solve(5, new List<List<int>>
            {
                new List<int> { 1, 2 },
              //  new List<int> { 4, 5 },
                new List<int> { 2, 4 },
                new List<int> { 3, 4 },
                new List<int> { 5, 2 },
                new List<int> { 1, 3 }
            }).Dump();
        }

        public int solve(int A, List<List<int>> B)
        {
            var graph = new List<List<int>>();
            for (var i = 0; i <= A; i++)
            {
                graph.Add(new List<int>());
            }
            for (var i = 0; i< B.Count; i++)
            {
                graph[B[i][0]].Add(B[i][1]);
            }
            var visited = new bool[A+1];
            var recStack = new bool[A + 1];
            for (var i = 1; i <= A; i++)
            {
                if (checkCycle(graph, i, visited, recStack))
                {
                    return 1;
                }
            }
            return 0;
        }

        private bool checkCycle(List<List<int>> graph, int ver, bool[] visited, bool[] recStack)
        {
            if (recStack[ver]) return true;
            if (visited[ver]) return false;
            visited[ver] = true;
            recStack[ver] = true;

            foreach (var next in graph[ver])
            {
                if (checkCycle(graph, next, visited, recStack)) return true;
            }
            recStack[ver] = false;
            return false;
        }
    }
}
