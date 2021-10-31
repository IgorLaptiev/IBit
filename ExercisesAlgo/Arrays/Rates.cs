using ConsoleDump;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExercisesAlgo.Arrays
{
    public class Rates
    {
        public static void Execute()
        {
           // new Rates().RankTeams(new string[] { "ABC", "ACB", "ABC", "ACB", "ACB" }).Dump();
            new Rates().RankTeams(new string[] { "BCA", "CAB", "CBA", "ABC", "ACB", "BAC" }).Dump();
        }

        public string RankTeams(string[] votes)
        {
            var rates = new Dictionary<char, int[]>();
            foreach (var vote in votes)
            {
                for (var i = 0; i < vote.Length; i++)
                {
                    if (!rates.ContainsKey(vote[i]))
                    {
                        rates.Add(vote[i], new int[vote.Length]);
                    }
                    rates[vote[i]][i]++;
                }
            }
            var ratesOrdered = rates.OrderBy((keyValue) => 1);
            for (var i = 0; i< votes[0].Length; i++)
            {
                var ind = i;
                ratesOrdered = ratesOrdered.ThenByDescending((keyValue) => keyValue.Value[ind]);
            }
            ratesOrdered = ratesOrdered.ThenBy((keyValue) => keyValue.Key);
            var strBuilder = new StringBuilder();
            foreach(var rate in ratesOrdered.ToList())
            {
                strBuilder.Append(rate.Key);
            }
            return strBuilder.ToString();
        }
    }
}
