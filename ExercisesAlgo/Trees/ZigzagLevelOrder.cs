using ConsoleDump;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExercisesAlgo.Trees
{
    public class ZigzagLevelOrder
    {

        public static void Execute()
        {
            var tree = new TreeNode(1)
            {
                left = new TreeNode(2)
                {
                    left = new TreeNode(4)
                    { left = new TreeNode(8),
                       right = new TreeNode(9)
                    },
                    right = new TreeNode(5)
                    {
                        left = new TreeNode(10)
                    },
                },
                right = new TreeNode(3)
                {
                    left = new TreeNode(6)
                    {
                        left = new TreeNode(11),
                        right = new TreeNode(12)
                    },
                    right = new TreeNode(7),
                }
            };
            // 129 97 98 93 106 27 61 -1 173 40 78 22 152 99 114 
            tree = new TreeNode(129)
            {
                left = new TreeNode(97)
                {
                    left = new TreeNode(93)
                    {
                        right = new TreeNode(173)
                    },
                    right = new TreeNode(106)
                    {
                        left = new TreeNode(40),
                        right = new TreeNode(78)
                    },
                },
                right = new TreeNode(98)
                {
                    left = new TreeNode(27)
                    {
                        left = new TreeNode(22),
                        right = new TreeNode(152)
                    },
                    right = new TreeNode(61)
                    {
                        left = new TreeNode(99),
                        right = new TreeNode(114)
                    },
                }
            };
            var result = new ZigzagLevelOrder().zigzagLevelOrder(tree);
            foreach (var r in result)
            {
                r.Dump();
            }
        }

        public List<List<int>> zigzagLevelOrder(TreeNode A)
        {
            var currentLevel = new Stack<TreeNode>();
            var nextLevel = new Stack<TreeNode>();
            var res = new List<List<int>>();
            var direction = -1;
            var levList = new List<int>();
            currentLevel.Push(A);
            while (currentLevel.Count > 0)
            {
                var node = currentLevel.Pop();
                if (node != null)
                {
                    levList.Add(node.val);
                    if (direction > 0)
                    {
                        nextLevel.Push(node.right);
                        nextLevel.Push(node.left);
                    }
                    else
                    {
                        nextLevel.Push(node.left);
                        nextLevel.Push(node.right);
                    }
                }
                    if (currentLevel.Count == 0)
                    {
                        direction = -direction;
                        var tmp = currentLevel;
                        currentLevel = nextLevel;
                        nextLevel = tmp;
                        res.Add(levList.ToList());
                        levList.Clear();
                        
                    }
                
            }

            return res;

        }
    }
}
