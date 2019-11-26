using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ConsoleDump;

namespace ExercisesAlgo._2Pointers
{
    public class RemoveDublicates
    {
        public void Execute()
        {
            removeDuplicates(new List<int>() { 1,1,2,4,5,5,10,12,12}).Dump();
            //removeDuplicates(new List<int>() { 5000, 5000, 5000 }).Dump();
            
        }
        public int removeDuplicates(List<int> a)
        {
            int i = 0;
            int j = i + 1;
            while (i< a.Count && j <a.Count)
            {
                if (a[i] == a[j])
                {
                    j++;
                }
                else
                {
                    a[i + 1] = a[j];
                    j++;
                    i++;
                }
            }

            return i+1;
        }
    }
}
