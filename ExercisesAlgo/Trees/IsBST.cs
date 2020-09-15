using ConsoleDump;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExercisesAlgo.Trees
{
    public class IsBST
    {
        public static void Execute()
        {
            /*    var root = new TreeNode(40)
                {
                    left = new TreeNode(35)
                    {
                        left = new TreeNode(34)
                        {
                          left = new TreeNode(31)
                        },
                        right = new TreeNode(37)
                    }
                    ,
                    right = new TreeNode(41)
                    {
                        right = new TreeNode(46)
                        {
                            right = new TreeNode(47)
                        }
                    }
                };*/

            //         44 
            // 42             45
            // 33    43    - 1   46 
            //- 1 41 - 1 - 1   - 1 - 1
            //   35    40 
            // 34 - 1 39 36 
            //- 1 - 1 38 - 1 - 1 - 1 
            //       37 - 1 
            //    - 1 - 1
            var right = new TreeNode(42)
            {
                left = new TreeNode(33)
                {
                    right = new TreeNode(41)
                    {
                        left = new TreeNode(35)
                        {
                            left = new TreeNode(34)
                        },
                        right = new TreeNode(40)
                        {
                            left = new TreeNode(39),
                            right = new TreeNode(36)
                        }
                    }
                },
                right = new TreeNode(43)
            };
            new IsBST().isValidBST(right).Dump();
        
            var root = new TreeNode(44)
            {
                left = new TreeNode(42)
                {
                    left = new TreeNode(33)
                    {
                        right = new TreeNode(41)
                        {
                            left = new TreeNode(35)
                            {
                                left = new TreeNode(34)
                            },
                            right = new TreeNode(40)
                            {
                                left = new TreeNode(39),
                                right = new TreeNode(36)
                            }
                        }
                    },
                    right = new TreeNode(43)
                }
               ,
                right = new TreeNode(45)
                {
                    right = new TreeNode(46)
                }
            };
            new IsBST().isValidBST(root).Dump();
        }

        public int isValidBST(TreeNode A)
        {
            return isValidBST(A, Int32.MinValue, Int32.MaxValue) ? 1 : 0;
        }

        private bool isValidBST(TreeNode A, int low, int up)
        {
            if (A == null) return true;
            return A.val > low && A.val < up
                && isValidBST(A.left, low, A.val)
                && isValidBST(A.right, A.val, up);
        }

    }
}
