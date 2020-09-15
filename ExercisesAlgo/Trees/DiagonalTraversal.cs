using ConsoleDump;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExercisesAlgo.Trees
{
    public class DiagonalTraversal
    {

        public static void Execute()
        {
            var tree = new TreeNode(1)
            {
                left = new TreeNode(2)
                {
                    right = new TreeNode(5)
                    {
                        left = new TreeNode(6)
                        { right = new TreeNode(8)},
                        right = new TreeNode(7)
                    }
                },
                right = new TreeNode(3)
                {
                    left = new TreeNode(4)
                }
            };
            //tree = new TreeNode(1)
            //{
            //    left = new TreeNode(15),
            //    right = new TreeNode(2)
            //};

            var result = new DiagonalTraversal().solve(tree);
            foreach (var r in result)
            {
                r.Dump();
            }
        }

        class NL
        {
            public TreeNode node { get; set; }
            public int level { get; set; }
        }

        Dictionary<int, List<int>> diags = new Dictionary<int, List<int>>();

        public List<int> solve(TreeNode A)
        {
            Traverse(A,0);
            return diags.SelectMany(k => k.Value).ToList();
        }

        private void Traverse(TreeNode node, int level)
        {
            if (node == null) return;
           // Console.WriteLine(node.val);
            if (!diags.ContainsKey(level))
            {
                diags.Add(level, new List<int>());
            }
            diags[level].Add(node.val);
            Traverse(node.left, level + 1);
            Traverse(node.right, level);
        }


        private void TraverseNR(TreeNode root)
        {
            var q = new Queue<NL>();
            q.Enqueue(new NL { node = root, level = 0 });
            while (q.Count > 0)
            {
                var n = q.Dequeue();
                if (n.node != null)
                {
                    if (!diags.ContainsKey(n.level))
                    {
                        diags.Add(n.level, new List<int>());
                    }
                    diags[n.level].Add(n.node.val);
                    q.Enqueue(new NL { node = n.node.left, level = n.level + 1 });
                    q.Enqueue(new NL { node = n.node.right, level = n.level });
                }
            }
        }
    }
}
