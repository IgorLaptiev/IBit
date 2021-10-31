using ConsoleDump;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExercisesAlgo.Graphs
{
    public class KnightMoves
    {
        public static void Execute()
        {
            //new KnightMoves().knight(8, 8, 1, 1, 8, 8).Dump();
            new KnightMoves().knight(2, 20, 1, 18, 1, 5).Dump();
        }

        int minMoves = -1;
        Dictionary<Point, bool> visited = new Dictionary<Point, bool>();
        Point board;

        public int knight(int A, int B, int C, int D, int E, int F)
        {
            board = new Point(A, B);
            var currentStep = 0;
            var target = new Point(E, F);
            var q = new Queue<Point>();
            q.Enqueue(new Point(C, D));
            q.Enqueue(null);
            while(q.Count >0)
            {
                var current = q.Dequeue();
                if (current == null)
                {
                    currentStep++;
                    if (q.Count > 0)
                    {
                        q.Enqueue(null);
                    }
                }
                else
                {
                    Console.WriteLine($"{current.X}x{current.Y} - {currentStep} - {q.Count}");
                    if (current.Equals(target))
                    {
                        return currentStep;
                    }
                    if (!visited.ContainsKey(current))
                    {
                        visited.Add(current, true);
                        foreach (var pos in new Knight(board, current).PossibleMoves())
                        {
                            q.Enqueue(pos);
                        }
                    }
                }
            }


            return -1;
        }
    }

    public class Knight
    {
        public Point Board { get; }
        public Point Position { get; }

        public Knight(Point board, Point position)
        {
            Board = board;
            Position = position;
        }

        public IEnumerable<Point> PossibleMoves()
        {
            var step = new Point(Position.X + 1, Position.Y - 2);
            if (IsOnBoard(step))
            {
                yield return step;
            }
            step = new Point(Position.X + 2, Position.Y - 1);
            if (IsOnBoard(step))
            {
                yield return step;
            }
            step = new Point(Position.X + 2, Position.Y + 1);
            if (IsOnBoard(step))
            {
                yield return step;
            }
            step = new Point(Position.X + 1, Position.Y + 2);
            if (IsOnBoard(step))
            {
                yield return step;
            }
            step = new Point(Position.X -1 , Position.Y + 2);
            if (IsOnBoard(step))
            {
                yield return step;
            }
            step = new Point(Position.X - 2, Position.Y + 1);
            if (IsOnBoard(step))
            {
                yield return step;
            }
            step = new Point(Position.X - 2, Position.Y - 1);
            if (IsOnBoard(step))
            {
                yield return step;
            }
            step = new Point(Position.X - 1, Position.Y - 2 );
            if (IsOnBoard(step))
            {
                yield return step;
            }

        }

        private bool IsOnBoard(Point pos)
        {
            return (pos.X > 0 && pos.Y >0 && pos.X <= Board.X &&  pos.Y <= Board.Y);
        }
    }
}
