using ConsoleDump;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExercisesAlgo.Trees
{
    public class VerticalOrderTraversal
    {
        public static void Execute()
        {
            var tree = new TreeNode(6)
            {
                left = new TreeNode(3)
                {  left = new TreeNode(2),
                   right = new TreeNode(5)
                },
                right = new TreeNode(7)
                {
                    right = new TreeNode(9)
                }
            };
             tree = new TreeNode(460)
            {
                left = new TreeNode(3871)
                {
                    left = new TreeNode(8399)
                    {
                        right = new TreeNode(4167)
                        { left = new TreeNode(2667),
                        right = new TreeNode(5661)}
                    },
                    right = new TreeNode(504)
                    { left = new TreeNode(5721)
                    {
                        left = new TreeNode(1969),
                        right = new TreeNode(7815)
                    } }
                },
                right = new TreeNode(4698)
                {
                    left = new TreeNode(4421),
                    right = new TreeNode(7515)
                }
            };
            var result = new VerticalOrderTraversal().verticalOrderTraversal(tree);
            foreach(var r in result)
            {
                r.Dump();
            }
        }

        Dictionary<int,List<int>> verticals = new Dictionary<int,List<int>>();
        public List<List<int>> verticalOrderTraversal(TreeNode A)
        {
            TraverseNR(A);
            return verticals.OrderBy(v=>v.Key).Select(v=>v.Value).ToList();
        }

        private void Traverse(TreeNode node, int level)
        {
            if (node == null) return;
            Console.WriteLine(node.val);
            if (!verticals.ContainsKey(level))
            {
                verticals.Add(level, new List<int>());
            }
            verticals[level].Add(node.val);
            Traverse(node.left, level - 1);
            Traverse(node.right, level + 1);
        }

        class NL
        {
            public TreeNode node { get; set; }
            public int level { get; set; }
        }

        private void TraverseNR(TreeNode node)
        {
            if (node == null) return;
            var q = new Queue<NL>();
            var level = 0;
            q.Enqueue(new NL { node = node, level = level });
            while(q.Count >0)
            {
                var n = q.Dequeue();
                if (n.node != null)
                {
                    if (!verticals.ContainsKey(n.level))
                    {
                        verticals.Add(n.level, new List<int>());
                    }
                    verticals[n.level].Add(n.node.val);
                    q.Enqueue(new NL { node = n.node.left, level = n.level - 1 });
                    q.Enqueue(new NL { node = n.node.right, level = n.level + 1 });
                }
            }
        }
    }
}
