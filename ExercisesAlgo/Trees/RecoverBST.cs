using ConsoleDump;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExercisesAlgo.Trees
{
    public class RecoverBST
    {
        public static void Execute()
        {
            var root = new TreeNode(1)
            {
                left = new TreeNode(2),
                right = new TreeNode(3)
            };
            new RecoverBST().recoverTree(root).Dump();

            root = new TreeNode(2)
            {
                left = new TreeNode(3),
                right = new TreeNode(1)
            };
            new RecoverBST().recoverTree(root).Dump();

            root = new TreeNode(2)
            {
                left = new TreeNode(1),
                right = new TreeNode(3)
            };
            new RecoverBST().recoverTree(root).Dump();
        }

        private TreeNode max;
        private TreeNode min;
        private TreeNode prev = new TreeNode(Int32.MinValue);

        public List<int> recoverTree(TreeNode A)
        {
            traverse(A);
            if (min != null)
            {
                return new List<int> { min.val, max.val };
            }
            return new List<int>();
        }

        private void traverse(TreeNode node)
        {
            if (node == null) return;
            traverse(node.left);
            if (node.val < prev.val)
            {
                if (max == null)
                {
                    max = prev;
                }
                min = node;
            }

            prev = node;
            traverse(node.right);
        }
    }
}
