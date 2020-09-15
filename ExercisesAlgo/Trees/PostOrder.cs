using ConsoleDump;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExercisesAlgo.Trees
{
    public class PostOrder
    {
        public static void Execute()
        {
            var tree = new TreeNode(1)
            {
                left = new TreeNode(2)
                {
                    left = new TreeNode(4),
                    right = new TreeNode(5)
                },
                right = new TreeNode(3)
                {
                    left = new TreeNode(6),
                    right = new TreeNode(7),
                }
            };

            var result = new PostOrder().postorderTraversal(tree);
            foreach (var r in result)
            {
                r.Dump();
            }
        }

        public List<int> postorderTraversal(TreeNode A)
        {
            var result = new List<int>();
            var st = new Stack<TreeNode>();
            var stRev = new Stack<TreeNode>();
            stRev.Push(A);
            while (stRev.Count > 0)
            {
                var node = stRev.Pop();
                if (node != null)
                {
                    st.Push(node);
                    stRev.Push(node.left);
                    stRev.Push(node.right);
                }
            }
            return st.Select(node => node.val).ToList();
        }
    }
}
