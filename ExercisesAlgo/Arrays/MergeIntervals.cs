using ConsoleDump;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExercisesAlgo.Arrays
{
    public class MergeIntervals
    {
        public static void Execute()
        {
            //            new MergeIntervals().insert(new List<Interval> { new Interval(1, 3), new Interval(4, 6) }, new Interval(2,5)).Dump();
            ConsoleDump.Extensions.RowLimit = 100;
            var list = new List<Interval> { new Interval(137207, 1734370), new Interval(5057723, 5365773), new Interval(6997657, 7282669), new Interval(7992707, 8945780), new Interval(13205169, 13286380), new Interval(13478080, 14361199), new Interval(14648047, 16875188), new Interval(17296166, 19089625), new Interval(20424412, 20617334), new Interval(21947854, 23077086), new Interval(24901000, 26346402), new Interval(26650724, 27196856), new Interval(28896156, 29975691), new Interval(30071726, 31373629), new Interval(32397799, 33159528), new Interval(33305337, 35470848), new Interval(35720431, 37452993), new Interval(39147629, 40818780), new Interval(40930468, 41652526), new Interval(41938404, 44430212), new Interval(48114813, 48611161), new Interval(50335149, 51023917), new Interval(51878891, 52987379), new Interval(53902725, 54359910), new Interval(56661881, 58671175), new Interval(59326619, 61927945), new Interval(63215257, 63817507), new Interval(64968095, 65653303), new Interval(66634969, 67941460), new Interval(69980615, 71436951), new Interval(71564309, 74681566), new Interval(75530199, 76592769), new Interval(76988511, 77454928), new Interval(77665838, 78087358), new Interval(78229841, 79535243), new Interval(81250676, 82624050), new Interval(83142364, 84255671), new Interval(84379892, 84668384), new Interval(84954893, 85392199), new Interval(87804458, 90457067), new Interval(90760520, 91607160), new Interval(92361716, 92692045), new Interval(95399553, 97983139), new Interval(99776803, 99818745) };
            new MergeIntervals().insert(list, new Interval(108785977, 16197462)).Dump();
            //            new MergeIntervals().insert(new List<Interval> { new Interval(1, 3), new Interval(4, 6) }, new Interval(8, 9)).Dump();
        }

        public List<Interval> insert(List<Interval> intervals, Interval newInterval)
        {
            List<Interval> result = new List<Interval>();
            bool fit = false;
            for (int i = 0; i < intervals.Count; i++)
            {
                Interval currInterval = intervals[i];
                if (newInterval.start < currInterval.end
                    && newInterval.start > currInterval.start)
                {
                    fit = true;
                    Interval nInterval = new Interval(currInterval.start, 0);
                    while (currInterval.end <= newInterval.end && i < intervals.Count)
                    {
                        i++;
                        currInterval = intervals[i];
                    }
                    nInterval.end = Math.Max(currInterval.end, newInterval.end);
                    result.Add(nInterval);
                }
                else
                {
                    result.Add(currInterval);
                }
            }
            if (!fit)
            {
                result.Add(newInterval);
            }
            return result;
        }
    }
    public class Interval
    {
       public int start;
       public int end;
       public Interval() { start = 0; end = 0; }
       public Interval(int s, int e) { start = s; end = e; }
  }
}
