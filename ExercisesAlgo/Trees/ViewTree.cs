using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExercisesAlgo.Trees
{
    public static class Tree
    {
        public static TreeNode Build(string treeStr)
        {
            var values = treeStr.Split(' ').Skip(1).Select(v => Int32.Parse(v)).ToList();

            TreeNode root = new TreeNode(values[0]);
            List<TreeNode> parentLevel = new List<TreeNode>();
            List<TreeNode> currentLevel = new List<TreeNode>();
            parentLevel.Add(root);
            for (int i = 1; i < values.Count;)
            {
                foreach (var node in parentLevel)
                {
                    if (node.left == null)
                    {
                        if (values[i] != -1)
                        {
                            node.left = new TreeNode(values[i]);
                            currentLevel.Add(node.left);
                        }
                        i++;
                    }
                    if (node.right == null)
                    {
                        if (values[i] != -1)
                        {
                            node.right = new TreeNode(values[i]);
                            currentLevel.Add(node.right);
                        }
                        i++;
                    }
                }
                parentLevel = currentLevel;
                currentLevel = new List<TreeNode>();
            }
            return root;
        }

        public static void Dump2(this TreeNode node)
        {
            var matrix = new Dictionary<int, List<NodeCoord>>();
            BuildLevels(node, 0, node.CountLeft() + 1, matrix);
            foreach(var level in matrix)
            {
                var currPos = 0;
                foreach (var n in level.Value)
                {

//                    Console.Write(new String(' ', Math.Max(n.Position  - currPos,0)));
                    WriteAt(n.Node.val.ToString(), n.Position * 4, n.Level );
                }
                //Console.WriteLine();
            }
        }

        public static void Dump(this TreeNode node)
        {
            new TreePrinter().Draw(node);
        }

        private static void Draw(TreeNode node, int position, int level, int step, int margin =1)
        {
            if (node == null) return;
            WriteAt(node.val.ToString(), position, level);
            Draw(node.left, position - step - margin, level+1, Convert.ToInt32(step - level), margin);
            Draw(node.right, position + step + margin, level+1, Convert.ToInt32(step - level), margin);
        }

        static void WriteAt(string s, int x, int y)
        {
            try
            {
                Console.SetCursorPosition(x, y);
                Console.Write(s);
            }
            catch (ArgumentOutOfRangeException e)
            {
                Console.Clear();
                Console.WriteLine(e.Message);
            }
        }

        private static void BuildLevels(TreeNode node, int level, int position, Dictionary<int, List<NodeCoord>> matrix)
        {
            if (node == null) return;

            if (!matrix.ContainsKey(level))
            {
                matrix[level] = new List<NodeCoord>();
            }
            matrix[level].Add(new NodeCoord(node, level, position));
            BuildLevels(node.left, level + 1, position - 1, matrix);
            BuildLevels(node.right, level + 1, position + 1, matrix);
        }

        internal static int CountLeft(this TreeNode node)
        {
            if (node == null) return 0;
            return node.left.CountLeft() + 1;
        }

        class NodeCoord
        {
            public NodeCoord(TreeNode node, int level, int pos)
            {
                Node = node;
                Level = level;
                Position = pos;
            }

            public TreeNode Node { get; }
            public int Level { get; }
            public int Position { get; }
        }
    }
}
