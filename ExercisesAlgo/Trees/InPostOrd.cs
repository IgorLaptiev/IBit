using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExercisesAlgo.Trees
{
    public class InPostOrd
    {

        public static void Execute()
        {
            var tree = new InPostOrd().buildTree(new List<int> { 4,2,5,1,8,3,6}, new List<int> { 4, 5, 2, 8, 6, 3, 1 });
            BTreePrinter.Print(tree);
        }

        public TreeNode buildTree(List<int> A, List<int> B)
        {
            if (A.Count == 0) return null;

            TreeNode root = new TreeNode(B.Last());
            B.RemoveAt(B.Count - 1);
            root.right = buildTree(GetRight(A, root.val).ToList(), B);
            root.left = buildTree(GetLeft(A, root.val).ToList(), B);
            return root;
        }

        private IEnumerable<int> GetRight(List<int> inorder, int val)
        {
            var found = false;
            for (int i = 0; i < inorder.Count; i++)
            {
                if (inorder[i] == val)
                {
                    found = true;
                }
                else if (found)
                {
                    yield return inorder[i]; 
                }
            }
        }

        private IEnumerable<int> GetLeft(List<int> inorder, int val)
        {
            var found = false;
            for (int i = 0; i < inorder.Count; i++)
            {
                if (inorder[i] == val)
                {
                    found = true;
                    break;
                }
                else if (!found)
                {
                    yield return inorder[i];
                }
            }
        }

    }
}
