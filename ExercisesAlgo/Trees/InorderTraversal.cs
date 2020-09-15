using ConsoleDump;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExercisesAlgo.Trees
{
    public class InorderTraversal
    {
        public static void Execute()
        {
            var tree = new TreeNode(1)
            {
                left = new TreeNode(2)
                {
                    left = new TreeNode(8),
                    right = new TreeNode(6)
                },
                right = new TreeNode(3)
                {
                    left = new TreeNode(4)
                }
            };

            var result = new InorderTraversal().inorderTraversal(tree);
            foreach (var r in result)
            {
                r.Dump();
            }
        }

        public List<int> inorderTraversal(TreeNode A)
        {
            var result = new List<int>();
            var st = new Stack<TreeNode>();
            st.Push(A);
            while (st.Count > 0)
            {
                var node = st.Pop();
                if (node != null)
                {
                    st.Push(node.right);
                    st.Push(node);
                    st.Push(node.left);
                }
                else if (st.Count > 0)
                {
                    node = st.Pop();
                    if (node != null)
                    {
                        result.Add(node.val);
                    }
                }
            }
            return result;
        }
    }
}
