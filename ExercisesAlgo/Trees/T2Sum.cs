using ConsoleDump;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExercisesAlgo.Trees
{
    public class T2Sum
    {
        public static void Execute()
        {
          
            var root = new TreeNode(10)
            {
                left = new TreeNode(9),
                right = new TreeNode(20)
            };
            new T2Sum().t2Sum(root, 40).Dump();
        }
        Dictionary<int, TreeNode> sumDict = new Dictionary<int, TreeNode>();

        public int t2Sum(TreeNode A, int B)
        {
            CalcDict(A, B);
            return FindDiff(A) ? 1 : 0;
        }

        private void CalcDict(TreeNode node, int sum)
        {
            if (node == null) return;
            var diff = sum - node.val;
            if (!sumDict.ContainsKey(diff))
            {
                sumDict.Add(diff, node);
            }
            CalcDict(node.left, sum);
            CalcDict(node.right, sum);
        }

        private bool FindDiff(TreeNode node)
        {
            if (node == null) return false;
            if (sumDict.ContainsKey(node.val) && sumDict[node.val] != node) return true;
            return FindDiff(node.left) || FindDiff(node.right);
        }
    }
}
