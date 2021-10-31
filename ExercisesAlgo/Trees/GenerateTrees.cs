using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExercisesAlgo.Trees
{
    public class GenerateTrees
    {
        public static void Execute()
        {
            var res = new GenerateTrees().generateTrees(3);

        }

        public List<TreeNode> generateTrees(int a)
        {
            return generateTrees(1, a);
        }

        public List<TreeNode> generateTrees(int from, int to)
        {
            List<TreeNode> trees = new List<TreeNode>();
            if (from > to) return trees;
            for (var i = from; i <= to; i++)
            {
                List<TreeNode> left = new List<TreeNode>() { null};
                List<TreeNode> right = new List<TreeNode>() { null};
                if (i > from)
                {
                    left = generateTrees(from, i - 1);
                }
                if (i < to)
                {
                    right = generateTrees(i + 1, to);
                }
                for (var li = 0; li < left.Count; li++)
                {
                    for (var ri = 0; ri < right.Count; ri++)
                    {
                        TreeNode root = new TreeNode(i);
                        root.left = left[li];
                        root.right = right[ri];
                        trees.Add(root);
                    }
                }
            }
            return trees;
        }

    }


}
