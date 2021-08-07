using System;
using System.Collections.Generic;
namespace CSharpConsoleApp.Solutions
{
    /*
     * @lc app=leetcode.cn id=98 lang=csharp
     *
     * [98] 验证二叉搜索树
     *
     * https://leetcode-cn.com/problems/validate-binary-search-tree/description/
     *
     * Category	Difficulty	Likes	Dislikes
     * algorithms	Medium (34.44%)	1104	-
     * Tags
     * tree | depth-first-search
     * 
     * Companies
     * amazon | bloomberg | facebook | microsoft
     * 
     * Total Accepted:    289.5K
     * Total Submissions: 840.4K
     * Testcase Example:  '[2,1,3]'
     *
     * 给定一个二叉树，判断其是否是一个有效的二叉搜索树。
     * 
     * 假设一个二叉搜索树具有如下特征：
     * 
     * 
     * 节点的左子树只包含小于当前节点的数。
     * 节点的右子树只包含大于当前节点的数。
     * 所有左子树和右子树自身必须也是二叉搜索树。
     * 
     * 
     * 示例 1:
     * 
     * 输入:
     * ⁠   2
     * ⁠  / \
     * ⁠ 1   3
     * 输出: true
     * 
     * 
     * 示例 2:
     * 
     * 输入:
     * ⁠   5
     * ⁠  / \
     * ⁠ 1   4
     * / \
     * 3   6
     * 输出: false
     * 解释: 输入为: [5,1,4,null,null,3,6]。
     * 根节点的值为 5 ，但是其右子节点值为 4 。
     * 
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
    public class Solution98 : SolutionBase
    {
        /// <summary>
        /// 难度
        /// </summary>
        public override Difficulity GetDifficulity() { return Difficulity.Medium; }
        /// <summary>
        /// 关键字:
        /// </summary>
        public override string[] GetKeyWords() { return new string[] { }; }
        /// <summary>
        /// 标签：
        /// </summary>
        public override Tag[] GetTags() { return new Tag[] { Tag.Tree, Tag.BreadthFirstSearch }; }

        /// <summary>
        /// 入度：每个课程节点的入度数量等于其先修课程的数量；
        /// 出度：每个课程节点的出度数量等于其指向的后续课程数量；
        /// 所以只有当一个课程节点的入度为零时，其才是一个可以学习的自由课程。
        ///
        /// 拓扑排序即是将一个无环有向图转换为线性排序的过程。
        /// </summary>
        /// <param name="sw"></param>
        /// <returns></returns>
        public override bool Test(System.Diagnostics.Stopwatch sw)
        {
            bool isSuccess = true;

            TreeNode root;
            bool result, checkResult;

            //root = TreeNode.Create(new int[] { 3, 9, 20, -1, -1, 15, 7 }, -1);
            //result = IsValidBST(root);
            //checkResult = false;
            //isSuccess &= IsSame(result, checkResult);
            //PrintResult(isSuccess, (result), (checkResult));

            //root = TreeNode.Create(new int[] {  7, 3, 15, -1, -1, 9,  20 }, -1);
            //result = IsValidBST(root);
            //checkResult = true;
            //isSuccess &= IsSame(result, checkResult);
            //PrintResult(isSuccess, (result), (checkResult));

            //*输入:
            // * ⁠   5
            // * ⁠  / \
            // *  4   6
            // *     / \
            // *    3   70
            root = TreeNode.Create(new int[] { 5, 4, 6, -1, -1, 3, 70 }, -1);
            result = IsValidBST(root);
            checkResult = true;
            isSuccess &= IsSame(result, checkResult);
            PrintResult(isSuccess, (result), (checkResult));
            return isSuccess;
        }

        /// <summary>
        /// 80/80 cases passed (120 ms)
        /// Your runtime beats 46.15 % of csharp submissions
        /// Your memory usage beats 96.15 % of csharp submissions(26 MB)
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public bool IsValidBST(TreeNode root)
        {
            return DFS(root, long.MinValue, long.MaxValue);
        }

        public bool DFS(TreeNode node, long lower, long upper)
        {
            if (node == null)
            {
                return true;
            }
            if (node.val <= lower || node.val >= upper)
            {
                return false;
            }
            return DFS(node.left, lower, node.val) && DFS(node.right, node.val, upper);
        }
    }
    // @lc code=end


}
