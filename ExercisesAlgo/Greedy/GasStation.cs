using ConsoleDump;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExercisesAlgo.Greedy
{
    /*
     * 
Given two integer arrays A and B of size N.
There are N gas stations along a circular route, where the amount of gas at station i is A[i].

You have a car with an unlimited gas tank and it costs B[i] of gas to travel from station i
to its next station (i+1). You begin the journey with an empty tank at one of the gas stations.

Return the minimum starting gas station’s index if you can travel around the circuit once, otherwise return -1.

You can only travel in one direction. i to i+1, i+2, … n-1, 0, 1, 2.. Completing the circuit means starting at i and
ending up at i again.



Input Format

The first argument given is the integer array A.
The second argument given is the integer array B.
Output Format

Return the minimum starting gas station's index if you can travel around the circuit once, otherwise return -1.
For Example

Input 1:
    A =  [1, 2]
    B =  [2, 1]
Output 1:
    1
    Explanation 1:
        If you start from index 0, you can fill in A[0] = 1 amount of gas. Now your tank has 1 unit of gas. But you need B[0] = 2 gas to travel to station 1. 
        If you start from index 1, you can fill in A[1] = 2 amount of gas. Now your tank has 2      
     */

    public class GasStation
    {
        public static void Execute()
        {
            var a = new List<int> { 204, 918, 18, 17, 35, 739, 913, 14, 76, 555, 333, 535, 653, 667, 52, 987, 422, 553, 599, 765, 494, 298, 16, 285, 272, 485, 989, 627, 422, 399, 258, 959, 475, 983, 535, 699, 663, 152, 606, 406, 173, 671, 559, 594, 531, 824, 898, 884, 491, 193, 315, 652, 799, 979, 890, 916, 331, 77, 650, 996, 367, 86, 767, 542, 858, 796, 264, 64, 513, 955, 669, 694, 382, 711, 710, 962, 854, 784, 299, 606, 655, 517, 376, 764, 998, 244, 896, 725, 218, 663, 965, 660, 803, 881, 482, 505, 336, 279 };
            var b = new List<int> { 273, 790, 131, 367, 914, 140, 727, 41, 628, 594, 725, 289, 205, 496, 290, 743, 363, 412, 644, 232, 173, 8, 787, 673, 798, 938, 510, 832, 495, 866, 628, 184, 654, 296, 734, 587, 142, 350, 870, 583, 825, 511, 184, 770, 173, 486, 41, 681, 82, 532, 570, 71, 934, 56, 524, 432, 307, 796, 622, 640, 705, 498, 109, 519, 616, 875, 895, 244, 688, 283, 49, 946, 313, 717, 819, 427, 845, 514, 809, 422, 233, 753, 176, 35, 76, 968, 836, 876, 551, 398, 12, 151, 910, 606, 932, 580, 795, 187 };
            new GasStation().canCompleteCircuit(a, b).Dump();
        }

        public int canCompleteCircuit(List<int> A, List<int> B)
        {
            var diff = new List<int>();
            for (var i = 0; i < A.Count; i++)
            {
                diff.Add(A[i] - B[i]);
            }

            if (diff.Sum() < 0) return -1;

            for (var i = 0; i < A.Count; i++)
            {
                if (diff[i] >= 0)
                {
                    if (Check(diff, i))
                    {
                        return i;
                    }
                }
            }
            return -1;
        }

        private bool Check(List<int> diff, int start)
        {
            var current = start;
            var fuel = 0;
            do
            {
                fuel += diff[current];
                if (current == diff.Count - 1)
                {
                    current = 0;
                }
                else
                {
                    current++;
                }
            }
            while (current != start && fuel >= 0);
            return fuel >= 0;
        }
    }
}
