using System;
using System.Collections.Generic;

using ConsoleDump;

namespace ExercisesAlgo.Mathe
{
    public class PrettyPrint
    {
        public void Execute()
        {
            foreach (var row in this.prettyPrint(6))
            {
                foreach (var cell in row)
                {
                    Console.Write(cell + " ");
                }
                Console.WriteLine();
            }
        }

        public List<List<int>> prettyPrint(int A)
        {
            var matix = new List<List<int>>();
            for (int i = 0; i < A ; i++)
            {
                var row = new List<int>();
              
                for (int j = 0; j < A; j++)
                {
                    row.Add( A -Math.Min(i,j));
                }
                for (int j = A-2; j >=0; j--)
                {
                    row.Add(A - Math.Min(i, j));
                }
                matix.Add(row);
            }
            for (int i = A-2; i >=0; i--)
            {
                var row = new List<int>();

                for (int j = 0; j < A; j++)
                {
                    row.Add(A - Math.Min(i, j));
                }
                for (int j = A - 2; j >= 0; j--)
                {
                    row.Add(A - Math.Min(i, j));
                }
                matix.Add(row);
            }
            return matix;
        }

    }
}