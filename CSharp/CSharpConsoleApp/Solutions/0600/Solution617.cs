﻿using System;
namespace CSharpConsoleApp.Solutions
{
    /*
     * @lc app=leetcode.cn id=617 lang=csharp
     *
     * [617] 合并二叉树
     *
     * https://leetcode-cn.com/problems/merge-two-binary-trees/description/
     *
     * Category	Difficulty	Likes	Dislikes
     * algorithms	Easy (78.81%)	713	-
     * Tags
     * tree
     * 
     * Companies
     * amazon
     * Total Accepted:    154K
     * Total Submissions: 195.3K
     * Testcase Example:  '[1,3,2,5]\n[2,1,3,null,4,null,7]'
     *
     * 给定两个二叉树，想象当你将它们中的一个覆盖到另一个上时，两个二叉树的一些节点便会重叠。
     * 
     * 你需要将他们合并为一个新的二叉树。合并的规则是如果两个节点重叠，那么将他们的值相加作为节点合并后的新值，否则不为 NULL
     * 的节点将直接作为新二叉树的节点。
     * 
     * 示例 1:
     * 
     * 
     * 输入: 
     * Tree 1                     Tree 2                  
     * ⁠         1                         2                             
     * ⁠        / \                       / \                            
     * ⁠       3   2                     1   3                        
     * ⁠      /                           \   \                      
     * ⁠     5                             4   7                  
     * 输出: 
     * 合并后的树:
     * 3
     * / \
     * 4   5
     * / \   \ 
     * 5   4   7
     * 
     * 
     * 注意: 合并必须从两个树的根节点开始。
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
    public class Solution617 : SolutionBase
    {
        /// <summary>
        /// 难度
        /// </summary>
        public override Difficulity GetDifficulity() { return Difficulity.Easy; }
        /// <summary>
        /// 关键字:
        /// </summary>
        public override string[] GetKeyWords() { return new string[] {}; }
        /// <summary>
        /// 标签：
        /// </summary>
        public override Tag[] GetTags() { return new Tag[] { Tag.Tree }; }

        public const int NULL = int.MinValue;
        /// <summary>
        /// 160/160 cases passed (124 ms)
        /// Your runtime beats 100 % of csharp submissions
        /// Your memory usage beats 88.89 % of csharp submissions(28.2 MB)
        /// </summary>
        /// <param name="sw"></param>
        /// <returns></returns>
        public override bool Test(System.Diagnostics.Stopwatch sw)
        {
            bool isSuccess = true;
            TreeNode root, root2;
            TreeNode result, checkResult;

            root = TreeNode.Create(new int[] { 1, 2, 3, 4 }, NULL);
            root2 = TreeNode.Create(new int[] { 1, 2, 3, NULL, 4 }, NULL);
            checkResult = TreeNode.Create(new int[] { 2, 4, 6, 4, 4 }, NULL);
            result = MergeTrees(root, root2);
            isSuccess &= IsSame(result, checkResult);
            PrintResult(isSuccess, result.GetNodeString(true), checkResult.GetNodeString(true));
            return isSuccess;
        }

        /// <summary>
        /// 182/182 cases passed (136 ms)
        /// Your runtime beats 54.95 % of csharp submissions
        /// Your memory usage beats 48.35 % of csharp submissions(27.8 MB)
        /// </summary>
        /// <param name="t1"></param>
        /// <param name="t2"></param>
        /// <returns></returns>
        public TreeNode MergeTrees(TreeNode t1, TreeNode t2)
        {
            if (t1 == null)
            {
                return t2;
            }
            if (t2 == null)
            {
                return t1;
            }
            TreeNode merged = new TreeNode(t1.val + t2.val);
            merged.left = MergeTrees(t1.left, t2.left);
            merged.right = MergeTrees(t1.right, t2.right);
            return merged;
        }
    }
    // @lc code=end


}
