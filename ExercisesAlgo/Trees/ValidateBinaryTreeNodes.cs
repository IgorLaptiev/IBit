using ConsoleDump;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExercisesAlgo.Trees
{
    public class ValidateBinaryTree
    {

        public static void Execute()
        {
            new ValidateBinaryTree().ValidateBinaryTreeNodes(1, new int[] { -1 }, new int[] { -1 }).Dump();
            new ValidateBinaryTree().ValidateBinaryTreeNodes(4, new int[] { 1, 2, 0, -1 }, new int[] { -1, -1, -1, -1 }).Dump();

            new ValidateBinaryTree().ValidateBinaryTreeNodes(4, new int[] { 1, -1, 3, -1 }, new int[] { 2, -1, -1, -1 }).Dump();
            //n = 4, leftChild = [1, -1, 3, -1], rightChild = [2, 3, -1, -1]
            new ValidateBinaryTree().ValidateBinaryTreeNodes(4, new int[] { 1, -1, 3, -1 }, new int[] { 2, 3, -1, -1 }).Dump();
            new ValidateBinaryTree().ValidateBinaryTreeNodes(2, new int[] { 1, 0 }, new int[] { -1, -1 }).Dump();
            //n = 6, leftChild = [1,-1,-1,4,-1,-1], rightChild = [2,-1,-1,5,-1,-1]
            new ValidateBinaryTree().ValidateBinaryTreeNodes(6, new int[] { 1, -1, -1, 4, -1, -1 }, new int[] { 2, -1, -1, 5, -1, -1 }).Dump();
            new ValidateBinaryTree().ValidateBinaryTreeNodes(4, new int[] { 1, 0, 3, -1 }, new int[] { -1, -1, -1, -1 }).Dump();
        }

        public bool ValidateBinaryTreeNodes(int n, int[] leftChild, int[] rightChild)
        {
            if (n == 0) return true;
            if (n == 1) return true;

            var parents = new int[n];
            for(var i = 0;i <n;i++)
            {
                parents[i] = -1;
            }

            for (var i = 0; i < n; i++)
            {
                if (leftChild[i] != -1)
                {
                    if (parents[leftChild[i]] != -1 && parents[leftChild[i]] != i) return false;
                    if(leftChild[i] == parents[i]) return false;
                    parents[leftChild[i]] = i;
                }
                if (rightChild[i] != -1)
                {
                    if (parents[rightChild[i]] != -1 && parents[rightChild[i]] != i) return false;
                    if (rightChild[i] == parents[i]) return false;
                    parents[rightChild[i]] = i;
                }
            }
            var rootInd = -1;
            for (var i = 0; i < n; i++)
            {
                if (parents[i] == -1)
                {
                    if (rootInd != -1) return false;
                    rootInd = i;
                }
            }
            var rootChildren = parents.Count(p => p == rootInd);
            return parents.Count(p => p == -1) == 1 && rootChildren >= 1 && rootChildren <=2;
        }

    }
}
