using System;
using System.Collections.Generic;
namespace CSharpConsoleApp.Solutions
{
    /*
     * @lc app=leetcode.cn id=653 lang=csharp
     *
     * [653] 两数之和 IV - 输入 BST
     *
     * https://leetcode-cn.com/problems/two-sum-iv-input-is-a-bst/description/
     *
     * Category	Difficulty	Likes	Dislikes
     * algorithms	Easy (58.81%)	256	-
     * Tags
     * tree
     * 
     * Companies
     * facebook
     * Total Accepted:    35.2K
     * Total Submissions: 59.6K
     * Testcase Example:  '[5,3,6,2,4,null,7]\n9'
     *
     * 给定一个二叉搜索树 root 和一个目标结果 k，如果 BST 中存在两个元素且它们的和等于给定的目标结果，则返回 true。
     * 
     * 
     * 示例 1：
     * 输入: root = [5,3,6,2,4,null,7], k = 9
     * 输出: true
     * 
     * 
     * 示例 2：
     * 输入: root = [5,3,6,2,4,null,7], k = 28
     * 输出: false
     * 
     * 
     * 示例 3：
     * 输入: root = [2,1,3], k = 4
     * 输出: true
     * 
     * 
     * 示例 4：
     * 输入: root = [2,1,3], k = 1
     * 输出: false
     * 
     * 
     * 示例 5：
     * 输入: root = [2,1,3], k = 3
     * 输出: true
     * 
     * 
     * 提示:
     * 二叉树的节点个数的范围是  [1, 10^4].
     * -10^4 
     * root 为二叉搜索树
     * -10^5 
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
    public class Solution653 : SolutionBase
    {
        /// <summary>
        /// 难度
        /// </summary>
        public override Difficulity GetDifficulity() { return Difficulity.Medium; }
        /// <summary>
        /// 关键字:
        /// </summary>
        public override string[] GetKeyWords() { return new string[] { "通过" }; }
        /// <summary>
        /// 标签：
        /// </summary>
        public override Tag[] GetTags() { return new Tag[] { Tag.Trie, Tag.HashTable }; }

        /// <summary>
        /// </summary>
        /// <param name="sw"></param>
        /// <returns></returns>
        public override bool Test(System.Diagnostics.Stopwatch sw)
        {
            bool isSuccess = true;
            TreeNode root; int k;
            bool result, checkResult;

            root = TreeNode.Create(new int[] { 5, 3, 6, 2, 4, NULL, 7 }, NULL);
            k = 9; checkResult = true;
            result = FindTarget(root, k);
            isSuccess &= IsSame(result, checkResult);
            PrintResult(isSuccess, result, checkResult);

            root = TreeNode.Create(new int[] { 5, 3, 6, 2, 4, NULL, 7 }, NULL);
            k = 28; checkResult = false;
            result = FindTarget(root, k);
            isSuccess &= IsSame(result, checkResult);
            PrintResult(isSuccess, result, checkResult);

            root = TreeNode.Create(new int[] { 2, 1, 3 }, NULL);
            k = 4; checkResult = true;
            result = FindTarget(root, k);
            isSuccess &= IsSame(result, checkResult);
            PrintResult(isSuccess, result, checkResult);

            root = TreeNode.Create(new int[] { 2, 1, 3 }, NULL);
            k = 1; checkResult = false;
            result = FindTarget(root, k);
            isSuccess &= IsSame(result, checkResult);
            PrintResult(isSuccess, result, checkResult);

            root = TreeNode.Create(new int[] { 2, 1, 3 }, NULL);
            k = 3; checkResult = true;
            result = FindTarget(root, k);
            isSuccess &= IsSame(result, checkResult);
            PrintResult(isSuccess, result, checkResult);

            return isSuccess;
        }

        /// <summary>
        /// 422/422 cases passed (124 ms)
        /// Your runtime beats 80.77 % of csharp submissions
        /// Your memory usage beats 92.31 % of csharp submissions(30.4 MB)
        /// </summary>
        HashSet<int> findMap;
        public bool FindTarget(TreeNode root, int k)
        {
            findMap = new HashSet<int>();
            return DFS(root, k);
        }

        public bool DFS(TreeNode root, int k)
        {
            if (root == null)
                return false;

            if (findMap.Contains(root.val))
                return true;

            findMap.Add(k - root.val);

            return DFS(root.left, k) || DFS(root.right, k);
        }
    }
    // @lc code=end


}
