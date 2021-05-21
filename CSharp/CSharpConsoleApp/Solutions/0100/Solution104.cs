using System;
namespace CSharpConsoleApp.Solutions
{
    /*
     * @lc app=leetcode.cn id=104 lang=csharp
     *
     * [104] 二叉树的最大深度
     *
     * https://leetcode-cn.com/problems/maximum-depth-of-binary-tree/description/
     *
     * algorithms
     * Easy (76.18%)
     * Likes:    879
     * Dislikes: 0
     * Total Accepted:    418.8K
     * Total Submissions: 549.8K
     * Testcase Example:  '[3,9,20,null,null,15,7]'
     *
     * 给定一个二叉树，找出其最大深度。
     * 
     * 二叉树的深度为根节点到最远叶子节点的最长路径上的节点数。
     * 
     * 说明: 叶子节点是指没有子节点的节点。
     * 
     * 示例：
     * 给定二叉树 [3,9,20,null,null,15,7]，
     * 
     * ⁠   3
     * ⁠  / \
     * ⁠ 9  20
     * ⁠   /  \
     * ⁠  15   7
     * 
     * 返回它的最大深度 3 。
     * 
     */

    // @lc code=start
    /**
        * Definition for a binary tree node.
        * public class TreeNode {
        *     public int val;
        *     public TreeNode left;
        *     public TreeNode right;
        *     public TreeNode(int val=0, TreeNode left=null, TreeNode right=null) {
        *         this.val = val;
        *         this.left = left;
        *         this.right = right;
        *     }
        * }
        */
    public class Solution104 : SolutionBase
    {
        public override bool Test(System.Diagnostics.Stopwatch sw)
        {
            TreeNode node = TreeNode.Create(new string[] { "7", "1", "5", "3", "6", "4", "3", "3" });
            int result = MaxDepth(node);
            Print("Depth = {0} | anticipated = {1}", result, 4);

            node = TreeNode.Create(new string[] { "7", "1", "5", null, null, "3", "6" });
            result = MaxDepth(node);
            Print("Depth = {0} | anticipated = {1}", result, 3);

            return true;
        }

        /// <summary>
        /// 39/39 cases passed (148 ms)
        /// Your runtime beats 8.29 % of csharp submissions
        /// Your memory usage beats 27.13 % of csharp submissions(25.5 MB)
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public int MaxDepth_My(TreeNode root)
        {
            return MaxDepth(root, 0);
        }

        public int MaxDepth(TreeNode root, int currDepth)
        {
            if (root == null) //|| (root.left == null && root.right == null)
                return currDepth;

            int l = MaxDepth(root.left, currDepth+1);
            int r = MaxDepth(root.right, currDepth + 1);

            //Print("L={0} | R={1} {2}", l, r, currDepth);
            return Math.Max(l, r);
        }

        /// <summary>
        /// 39/39 cases passed (116 ms)
        /// Your runtime beats 46.73 % of csharp submissions
        /// Your memory usage beats 37.69 % of csharp submissions(25.5 MB)
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public int MaxDepth(TreeNode root)
        {
            if (root == null) return 0;
            int l = MaxDepth(root.left);
            int r = MaxDepth(root.right);
            return Math.Max(l, r) + 1;
        }
    }
}
