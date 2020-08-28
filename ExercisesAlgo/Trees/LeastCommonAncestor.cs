using ConsoleDump;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExercisesAlgo.Trees
{
    public class LeastCommonAncestor
    {
        public static void Execute()
        {
            var root = new TreeNode(1)
            {
                left = new TreeNode(2),
                right = new TreeNode(3)
                {
                    left = new TreeNode(4)
                    {
                        right = new TreeNode(5)
                    }
                }
            };
            new LeastCommonAncestor().lca(root, 27, 5).Dump();
        }

            public int lca(TreeNode A, int B, int C)
            {
                if (A == null) return -1;

                var findLeft = findValue(A.left, B, C);
                var findRight = findValue(A.right, B, C);
                if (findLeft && findRight)
                {
                    return A.val;
                }
                if (findLeft)
                {
                    if (A.val == B || A.val == C)
                    {
                        return A.val;
                    }

                    return lca(A.left, B, C);
                }
                if (findRight)
                {
                    if (A.val == B || A.val == C)
                    {
                        return A.val;
                    }

                    return lca(A.right, B, C);
                }
                return -1;
            }

            private bool findValue(TreeNode A, int B, int C)
            {
                if (A == null) return false;
                if (A.val == B || A.val == C)
                {
                    return true;
                }
                var findLeft = findValue(A.left, B, C);
                var findRight = findValue(A.right, B, C);
                return findLeft || findRight;
            }
        }
}
