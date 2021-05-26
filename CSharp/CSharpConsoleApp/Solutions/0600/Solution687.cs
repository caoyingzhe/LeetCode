using System;
using System.Collections.Generic;
namespace CSharpConsoleApp.Solutions
{
    /*
     * @lc app=leetcode.cn id=687 lang=csharp
     *
     * [687] 最长同值路径
     *
     * https://leetcode-cn.com/problems/longest-univalue-path/description/
     *
     * algorithms
     * Medium (43.18%)
     * Likes:    463
     * Dislikes: 0
     * Total Accepted:    32.6K
     * Total Submissions: 75.3K
     * Testcase Example:  '[5,4,5,1,1,5]'
     *
     * 给定一个二叉树，找到最长的路径，这个路径中的每个节点具有相同值。 这条路径可以经过也可以不经过根节点。
     * 
     * 注意：两个节点之间的路径长度由它们之间的边数表示。
     * 
     * 示例 1:
     * 输入:
     * ⁠             5
     * ⁠            / \
     * ⁠           4   5
     * ⁠          / \   \
     * ⁠         1   1   5
     * 输出:
     * 2
     * 
     * 示例 2:
     * 输入:
     * ⁠             1
     * ⁠            / \
     * ⁠           4   5
     * ⁠          / \   \
     * ⁠         4   4   5
     * 输出:
     * 2
     * 
     * 
     * 注意: 给定的二叉树不超过10000个结点。 树的高度不超过1000。
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
    public class Solution687 : SolutionBase
    {
        /// <summary>
        /// 难度
        /// </summary>
        public override Difficulity GetDifficulity() { return Difficulity.Hard; }
        /// <summary>
        /// 关键字:
        /// </summary>
        public override string[] GetKeyWords() { return new string[] { "", }; }
        /// <summary>
        /// 标签：
        /// </summary>
        public override Tag[] GetTags() { return new Tag[] { Tag.HashTable, Tag.Stack, Tag.Recursion }; }

        public override bool Test(System.Diagnostics.Stopwatch sw)
        {
            TreeNode node; int depth;
            // node = TreeNode.Create(new string[] { "5", "4", "5", "1", "1", null, "5" });
            // depth = LongestUnivaluePath(node);
            //Print("depth = " + depth);

            //node = TreeNode.Create(new string[] { "5", "5", "5", "5", "1", null, "5" });
            //depth = LongestUnivaluePath(node);
            //Print("depth = " + depth);

            //         1
            //        / \
            //       n   1
            //          / \  
            //        1    1
            //       / \   / 
            //      1   1 1  
            node = TreeNode.Create(new string[] { "1", null, "1", null, null, "1", "1", null, null, null, null, "1", "1", "1" });
            depth = LongestUnivaluePath(node);
            Print("depth = " + depth);

            //[1,4,5,4,4,5]
            //node = TreeNode.Create(new string[] { "1", "4", "5", "4", "4", "5" });
            //depth = LongestUnivaluePath(node);
            //Print("depth = " + depth);
            return true;
        }

        public int LongestUnivaluePath(TreeNode root)
        {
            ans = 0;
            DFS(root);
            return ans;
        }

        int ans;

        /// <summary>
        /// https://leetcode-cn.com/problems/longest-univalue-path/solution/zui-chang-tong-zhi-lu-jing-by-leetcode/
        /// 时间复杂度：O(N) N 是树中节点数
        /// 空间复杂度：O(H) H 是树的高度
        /// 71/71 cases passed (256 ms)
        /// Your runtime beats 10 % of csharp submissions
        /// Your memory usage beats 10 % of csharp submissions(44.6 MB)
        /// </summary>
        /// <param name="node"></param>
        /// <returns></returns>
        public int DFS(TreeNode node)
        {
            if (node == null) return 0;
            int left = DFS(node.left);
            int right = DFS(node.right);

            int arrowLeft = 0, arrowRight = 0;
            if (node.left != null && node.left.val == node.val)
            {
                arrowLeft += left + 1;
            }
            if (node.right != null && node.right.val == node.val)
            {
                arrowRight += right + 1;
            }
            ans = Math.Max(ans, arrowLeft + arrowRight);
            return Math.Max(arrowLeft, arrowRight);
        }

        //作者：LeetCode
        //链接：https://leetcode-cn.com/problems/longest-univalue-path/solution/zui-chang-tong-zhi-lu-jing-by-leetcode/

    }
}
