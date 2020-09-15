using ConsoleDump;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExercisesAlgo.Trees
{

    /*
     * 
     * Given a binary tree and a sum, find all root-to-leaf paths where each path’s sum equals the given sum.

For example:
Given the below binary tree and sum = 22,

              5
             / \
            4   8
           /   / \
          11  13  4
         /  \    / \
        7    2  5   1
return

[
   [5,4,11,2],
   [5,8,4,5]
]
     */

    public class PathsWithSum
    {
        public static void Execute()
        {
        //    var tr = Tree.Build("0 1 2 3 -1 4 5 -1 -1 -1 -1 -1");
        //    BTreePrinter.Print(tr);
            var tree = Tree.Build("543 0 2 0 1 0 2 2 1 0 0 1 2 1 1 2 1 2 1 0 0 2 0 2 2 -1 1 0 1 -1 1 2 2 2 1 1 -1 1 2 1 0 1 1 0 2 2 2 2 2 0 2 0 1 2 -1 -1 0 1 0 2 -1 2 1 0 -1 -1 2 1 0 -1 0 2 -1 -1 1 2 -1 -1 0 2 1 -1 1 0 0 -1 2 -1 -1 1 2 0 -1 -1 2 1 2 -1 1 1 0 2 2 0 -1 1 1 0 1 0 0 1 2 2 0 -1 1 2 0 -1 -1 -1 0 -1 2 2 -1 -1 0 -1 1 0 -1 -1 0 -1 1 -1 0 1 -1 1 0 0 -1 2 1 -1 0 0 0 0 -1 -1 -1 -1 2 1 -1 1 2 -1 0 1 1 2 0 -1 -1 0 -1 0 2 0 -1 1 -1 2 1 -1 0 -1 0 2 -1 0 2 0 1 0 -1 -1 -1 0 -1 -1 -1 -1 -1 2 -1 1 0 -1 1 0 -1 -1 -1 -1 -1 -1 -1 -1 0 -1 1 1 -1 -1 -1 -1 -1 -1 -1 -1 1 0 -1 -1 -1 2 1 1 2 1 -1 -1 -1 1 -1 -1 -1 -1 -1 0 2 2 0 -1 -1 1 0 -1 1 1 1 -1 2 1 0 2 -1 1 2 -1 -1 -1 -1 2 2 1 1 -1 2 0 2 -1 -1 -1 1 2 -1 -1 -1 -1 0 1 1 -1 -1 -1 2 2 -1 -1 2 2 -1 -1 -1 1 0 -1 -1 2 -1 -1 -1 -1 -1 -1 0 -1 -1 1 -1 -1 1 2 -1 1 2 2 -1 -1 -1 2 -1 0 -1 0 2 2 0 2 -1 0 2 1 -1 0 -1 -1 2 -1 -1 -1 -1 -1 2 1 -1 0 2 -1 -1 -1 -1 -1 -1 1 -1 -1 -1 -1 -1 -1 -1 -1 -1 -1 -1 -1 2 -1 -1 -1 0 2 1 0 -1 -1 2 0 -1 -1 -1 1 1 -1 -1 -1 0 1 -1 -1 -1 -1 1 0 -1 0 0 -1 1 1 1 2 -1 -1 -1 1 1 -1 0 -1 -1 -1 2 -1 -1 -1 0 2 0 -1 -1 -1 -1 -1 1 -1 -1 -1 -1 -1 -1 -1 -1 0 0 2 2 -1 -1 -1 -1 -1 -1 -1 0 -1 -1 2 -1 -1 1 -1 -1 1 2 1 0 -1 -1 0 -1 2 -1 -1 -1 -1 -1 -1 -1 2 -1 -1 2 -1 -1 2 -1 1 -1 -1 2 -1 -1 -1 -1 -1 -1 0 -1 -1 -1 1 1 -1 -1 1 -1 -1 -1 -1 -1 -1 -1 0 -1 -1 -1 -1 -1 -1 -1 -1 -1 -1 1 -1 -1 -1 -1 -1 -1 -1 1 0 0 1 1 0 -1 -1 -1 -1 -1 -1 -1 -1");
          //  var tree = Tree.Build("0 1 2 3 -1 4 5 -1 -1 -1 -1 -1");
            new TreePrinter().Draw(tree);
       //     tree.Dump();
            var res = new PathsWithSum().pathSum(tree, 10);
            foreach (var r in res)
            {
                r.Dump();
            }
        }

        public List<List<int>> pathSum(TreeNode A, int B)
        {
            var res = new List<List<int>>();
            pathSum(A, B, 0, res, new List<int>());
            if (!res.Any())
            {
                res.Add(new List<int>());
            }
            return res;
        }

        public void pathSum(TreeNode node, int sum, int currSum, List<List<int>> res, List<int> currList)
        {
            if (node == null) return;
            var cs = node.val + currSum;
            currList.Add(node.val);
            if (node.left == null && node.right == null && cs == sum)
            {
                res.Add(currList.ToList());
            }
            pathSum(node.left, sum, cs, res, currList);
            pathSum(node.right, sum, cs, res, currList);
            currList.RemoveAt(currList.Count - 1);
        }
    }
}
