using ConsoleDump;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExercisesAlgo.Graphs
{
    public class WordSearchBoard
    {
        public static void Execute()
        {
              new WordSearchBoard().exist(new List<string>
              {
                  "BCBGDBCADF",
                  "BFGFFGCEFC",
                  "CABBAABCEA",
                  "ACGCGBGCEC",
                  "CFECDBFFGG",
                  "EEDBEFEGCD",
                  "FCFECACEBC"
              }, "CFFCF").Dump();
             new WordSearchBoard().exist(new List<string>
              {
              "FCDFFD", "DEGEBA", "FEDCGD", "DFCECC", "EEAFCF", "EEBGAE", "AAGCAE", "BGCBFC"
              }, "CDCDEDD").Dump();
              new WordSearchBoard().exist(new List<string>
              {
                   "BGGAGBGE",
                   "EFFAGBEG",
                   "FGGCBBFF",
                   "BEEBDEDC",
                   "FACABDCD",
                   "ECGEFFED",
                   "GDBEGACG",
                   "GCECFBBD"
              },
              "CABBFFEAC"
              ).Dump();
              
            new WordSearchBoard().exist(new List<string>
            {
                "AB",
                "CD",
            }, "ABDBA").Dump();
            new WordSearchBoard().exist(new List<string>
            {
                "FEDCBECD",
                "FABBGACG",
                "CDEDGAEC",
                "BFFEGGBA",
                "FCEEAFDA",
                "AGFADEAC",
                "ADGDCBAA",
                "EAABDDFF"
            }, "BCDCB").Dump();
        }


        public int exist(List<string> A, string B)
        {
            for (var i = 0; i < A.Count; i++)
            {
                for (var j = 0; j < A[i].Length; j++)
                {
                    if (A[i][j] == B[0])
                    {
                        if (findWord(A, B, i, j))
                        {
                            return 1;
                        }
                    }
                }
            }
            return 0;
        }
        private bool findWord(List<string> A, string B, int i, int j)
        {
            if (string.IsNullOrEmpty(B)) return true;

            if (A[i][j] == B[0])
            {
             //   Console.WriteLine($"{B[0]} {i} {j}");
                if (B.Length == 1)
                    return true;
                if (i > 0)
                {
                    if (findWord(A, B.Substring(1), i - 1, j)) return true;
                }
                if (j > 0)
                {
                    if (findWord(A, B.Substring(1), i, j - 1)) return true;
                }
                if (i < A.Count - 1)
                {
                    if (findWord(A, B.Substring(1), i + 1, j)) {
                        return true;
                    };
                }
                if (j < A[i].Length - 1)
                {
                    if (findWord(A, B.Substring(1), i, j + 1)) return true;
                }
            }
            return false;
        }
    }
}
