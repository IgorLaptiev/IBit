using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExercisesAlgo.Trees
{
    public class TreePrinter
    {
        Dictionary<int, List<NodeCoord>> Matrix { get; set; } = new Dictionary<int, List<NodeCoord>>();

        public void Draw(TreeNode root)
        {
            var rootNC = BuildLevels(null, root, 0, 0);
            var leftPost = GetLeft();
            ShiftRight(rootNC, Math.Abs(leftPost));
            Rebalance();
            Print();
        }

        private void Print()
        {
            foreach (var level in Matrix)
            {
                foreach (var node in level.Value)
                {
                    Console.SetCursorPosition(node.Position, node.Level);
                    Console.Write(node.Node.val);
                }
            }
            Console.WriteLine();
        }

        private void RangePositions()
        {
            var widestLevel = GetMaxWidthLevel();
            var position = 0;
            for (int i = 0; i < widestLevel.Value.Count - 1; i++)
            {
                widestLevel.Value[i].Position = position;
                if (widestLevel.Value[i].Parent == widestLevel.Value[i + 1].Parent)
                {
                    position += 5;
                }
                else
                {
                    position += 7;
                }
            }
            widestLevel.Value[widestLevel.Value.Count - 1].Position = position;

            widestLevel.Value.ForEach(node => SetChildrenPositions(node, node.Position));
        }

        private void SetChildrenPositions(NodeCoord node, int position)
        {
            if (node == null) return;
            node.Position = position;
            //SetChildrenPositions(node.left, position - 2);
            //SetChildrenPositions(node.right, position + 2);
        }

        private void Rebalance()
        {
            foreach (var level in Matrix)
            {
                if (level.Value.Count > 1)
                {
                    for (int i = 0; i < level.Value.Count -1; i++)
                    {
                        if (level.Value[i].Position == level.Value[i+1].Position)
                        {
                            var commonRoot = GetCommonRoot(level.Value[i],level.Value[i + 1]);
                            if (commonRoot != null)
                            {
                                commonRoot.Position += 1;
                                ShiftRight(commonRoot.Right, 2);
                            }
                        }
                    }
                }
            }
        }

        private NodeCoord GetCommonRoot(NodeCoord left, NodeCoord right)
        {
            if (left == right) return right;
            var currLeft = left;
            var currRight = right;
            while(currLeft != null && currRight != null && currLeft != currRight)
            {
                currLeft = currLeft.Parent;
                currRight = currRight.Parent;
            }
            return currRight;
        }

        private NodeCoord BuildLevels(NodeCoord parent, TreeNode node, int level, int position)
        {
            if (node == null) return null;

            if (!Matrix.ContainsKey(level))
            {
                Matrix[level] = new List<NodeCoord>();
            }
            var nd = new NodeCoord(node, parent);
            nd.Position = position;
            nd.Level = level;
            Matrix[level].Add(nd);
            nd.Left = BuildLevels(nd, node.left, level + 1, position - 1 );
            nd.Right = BuildLevels(nd, node.right, level + 1, position + 1);
            return nd;
        }

        private KeyValuePair<int, List<NodeCoord>> GetMaxWidthLevel()
        {
            return Matrix.Where(v => v.Value.Count == Matrix.Max(kv => kv.Value.Count)).LastOrDefault();
        }

        private void ShiftRight(NodeCoord node, int shift)
        {
            if (node == null) return;
            node.Position += shift;
            ShiftRight(node.Left, shift);
            ShiftRight(node.Right, shift);
        }

        private int GetLeft()
        {
            return Matrix.Min(l => l.Value.First().Position);
        }
        internal static int CountLeft(TreeNode node)
        {
            if (node == null) return 0;
            return node.left.CountLeft() + 1;
        }

        class NodeCoord
        {
            public NodeCoord(TreeNode node, NodeCoord parent)
            {
                Node = node;
                Parent = parent;
            }

            public TreeNode Node { get; }

            public NodeCoord Parent { get; }

            public int Level { get; set; }
            public int Position { get; set; }
            public NodeCoord Left { get; internal set; }
            public NodeCoord Right { get; internal set; }
        }
    }
}
