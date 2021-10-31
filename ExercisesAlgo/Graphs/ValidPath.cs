using ConsoleDump;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExercisesAlgo.Graphs
{
    public class ValidPath
    {
        public static void Execute()
        {
            new ValidPath().solve(5, 5, 1, 1, new List<int> { 2 }, new List<int> { 3 }).Dump();
        }

        int[,] rect;

        public string solve(int A, int B, int C, int D, List<int> E, List<int> F)
        {
            rect = new int[A+1,B+1];
            for (var i = 0; i <= A; i++)
            {
                for (var j = 0; j <= B; j++)
                {
                    for (var ci = 0; ci < C; ci++)
                    {
                        var dist = Math.Sqrt(Math.Pow(E[ci] - i,2 ) + Math.Pow(F[ci] - j,2));
                        if (dist <= D)
                        {
                            rect[i,j] = -1;
                        }
                    }
                }
            }
            var st = new Stack<Point>();
            rect[0, 0] = 1;
            st.Push(new Point(0, 0));
            while (st.Count() > 0)
            {
                var current = st.Pop();
                if (current.X == A && current.Y == B)
                {
                    return "YES";
                }
                AddPoint(st, current.X - 1, current.Y);
                AddPoint(st, current.X - 1, current.Y - 1);
                AddPoint(st, current.X, current.Y - 1);
                AddPoint(st, current.X + 1, current.Y);
                AddPoint(st, current.X + 1, current.Y + 1);
                AddPoint(st, current.X, current.Y + 1);
                AddPoint(st, current.X + 1, current.Y - 1);
                AddPoint(st, current.X - 1, current.Y + 1);
            }
            return "NO";
        }

        private void AddPoint(Stack<Point> stack, int x, int y)
        {
            var newPoint = new Point(x, y);
            if (newPoint.X >= 0
                && newPoint.Y >= 0
                && newPoint.X < rect.GetLength(0)
                && newPoint.Y < rect.GetLength(1)
                && rect[newPoint.X,newPoint.Y] == 0)
            {
                stack.Push(newPoint);
                rect[newPoint.X, newPoint.Y] = 1;
            }

        }
    }

    public class Point
    {
        public int X { get; set; }
        public int Y { get; set; }

        public Point(int x, int y)
        {
            X = x;
            Y = y;
        }

        public override int GetHashCode()
        {
            return (X * 500 + Y).GetHashCode();
        }

        public override bool Equals(object obj)
        {
            var point = obj as Point;
            return point != null &&
                   X == point.X &&
                   Y == point.Y;
        }
    }

}
