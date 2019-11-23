using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ConsoleDump;

namespace ExercisesAlgo.Strings
{
    public class JustifiedText
    {
        public void Execute()
        {
          //  fullJustify(new List<string>() { "glu", "muskzjyen", "ahxkp", "t", "djmgzzyh", "jzudvh", "raji", "vmipiz", "sg", "rv", "mekoexzfmq", "fsrihvdnt", "yvnppem", "gidia", "fxjlzekp", "uvdaj", "ua", "pzagn", "bjffryz", "nkdd", "osrownxj", "fvluvpdj", "kkrpr", "khp", "eef", "aogrl", "gqfwfnaen", "qhujt", "vabjsmj", "ji", "f", "opihimudj", "awi", "jyjlyfavbg", "tqxupaaknt", "dvqxay", "ny", "ezxsvmqk", "ncsckq", "nzlce", "cxzdirg", "dnmaxql", "bhrgyuyc", "qtqt", "yka", "wkjriv", "xyfoxfcqzb", "fttsfs", "m" }, 144).Dump();
            
        //   fullJustify(new List<string>() { "lkgyyrqh", "qrdqusnh", "zyu", "w", "ukzxyykeh", "zmfqafqle", "e", "ajq", "kagjss", "mihiqla", "qekf", "ipxbpz", "opsndtyu", "x", "ec", "cbd", "zz", "yzgx", "qbzaffgf", "i", "atstkrdph", "jgx", "qiy", "jeythmm", "qgqvyz", "dfagnfpwat", "sigxajhjt", "zx", "hwmcgss" }, 178).Dump();
            fullJustify(new List<string>(){ "This", "is", "an", "example", "of", "text", "justifica." },16 ).Dump();
            fullJustify(new List<string>() { "am", "fasgoprn", "lvqsrjylg", "rzuslwan", "xlaui", "tnzegzuzn", "kuiwdc", "fofjkkkm", "ssqjig", "tcmejefj", "uixgzm", "lyuxeaxsg", "iqiyip", "msv", "uurcazjc", "earsrvrq", "qlq", "lxrtzkjpg", "jkxymjus", "mvornwza", "zty", "q", "nsecqphjy" }, 14).Dump();
        }
        public List<string> fullJustify(List<string> A, int B)
        {
            var result = new List<string>();
            var lines = new List<List<string>>();
            var lineLength = new List<int>();
            var line = new List<string>();
            var currentLineLength = 0;
            foreach (var word in A)
            {
                if (currentLineLength + word.Length + line.Count > B)
                {
                    lineLength.Add(currentLineLength);
                    lines.Add(line);
                    currentLineLength = 0;
                    line = new List<string>();
                }
                currentLineLength += word.Length;
                line.Add(word);
            }

            if (currentLineLength > 0)
            {
                lineLength.Add(currentLineLength);
                lines.Add(line);
            }

            if (lines.Count > 0)
            {
                int i;
                for (i = 0; i < lines.Count - 1; i++)
                {
                    var positions = lines[i].Count - 1;
                    var spaceCount = B - lineLength[i];
                    var spaces = GetSpread(spaceCount, positions);
                    var stringBuilder = new StringBuilder();
                    for (int j = 0; j < lines[i].Count; j++)
                    {
                        stringBuilder.Append(lines[i][j]);
                        if (j < spaces.Count)
                        {
                            stringBuilder.Append(new String(' ', spaces[j]));
                        }
                    }

                    result.Add(stringBuilder.ToString());
                }

                var sb = new StringBuilder();
                for (int j = 0; j < lines[i].Count; j++)
                {
                    sb.Append(lines[i][j]);
                    if (j < lines[i].Count - 1)
                    {
                        sb.Append(" ");
                    }
                }
                sb.Append(new String(' ', B - lineLength[i] - lines[i].Count +1));
                result.Add(sb.ToString());
            }

            return result;
        }

        private List<int> GetSpread(int spaceCount, int positions)
        {
            var result = new List<int>();
            if (positions <= 1) return new List<int>(){spaceCount};
            var leastSpaces = spaceCount / positions;
            result.AddRange(GetSpread(spaceCount-leastSpaces, positions-1));
            result.Add(leastSpaces);
            return result;
        }
    }
}
