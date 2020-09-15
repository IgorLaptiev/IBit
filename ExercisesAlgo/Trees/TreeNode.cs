﻿using System;

namespace ExercisesAlgo.Trees
{
    public class TreeNode
    {
      public int val;
      public TreeNode left;
      public TreeNode right;
      public TreeNode(int x) { this.val = x; this.left = this.right = null; }

        public override string ToString()
        {
            return val.ToString();
        }

    }
}
