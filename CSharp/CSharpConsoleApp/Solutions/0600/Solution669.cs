using System;
namespace CSharpConsoleApp.Solutions
{
    /*
     * @lc app=leetcode.cn id=669 lang=csharp
     *
     * [669] 修剪二叉搜索树
     *
     * https://leetcode-cn.com/problems/trim-a-binary-search-tree/description/
     *
     * Category	Difficulty	Likes	Dislikes
     * algorithms	Medium (66.65%)	399	-
     * Tags
     * tree
     * 
     * Companies
     * bloomberg
     * 
     * Total Accepted:    30.9K
     * Total Submissions: 46.4K
     * Testcase Example:  '[1,0,2]\n1\n2'
     *
     * 给你二叉搜索树的根节点 root ，同时给定最小边界low 和最大边界 high。通过修剪二叉搜索树，使得所有节点的值在[low,
     * high]中。修剪树不应该改变保留在树中的元素的相对结构（即，如果没有被移除，原有的父代子代关系都应当保留）。 可以证明，存在唯一的答案。
     * 
     * 所以结果应当返回修剪好的二叉搜索树的新的根节点。注意，根节点可能会根据给定的边界发生改变。
     * 
     * 示例 1：
     * 输入：root = [1,0,2], low = 1, high = 2
     * 输出：[1,null,2]
     * 
     * 示例 2：
     * 输入：root = [3,0,4,null,2,null,null,1], low = 1, high = 3
     * 输出：[3,2,null,1]
     * 
     * 示例 3：
     * 输入：root = [1], low = 1, high = 2
     * 输出：[1]
     * 
     * 示例 4：
     * 输入：root = [1,null,2], low = 1, high = 3
     * 输出：[1,null,2]
     * 
     * 示例 5：
     * 输入：root = [1,null,2], low = 2, high = 4
     * 输出：[2]
     * 
     * 提示：
     * 树中节点数在范围 [1, 10^4] 内
     * 0 <= Node.val <= 104
     * 树中每个节点的值都是唯一的
     * 题目数据保证输入是一棵有效的二叉搜索树
     * 0 <= low <= high <= 104
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
    public class Solution669 : SolutionBase
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
        public override Tag[] GetTags() { return new Tag[] { Tag.Tree }; }


        /// <summary>
        /// </summary>
        /// <param name="sw"></param>
        /// <returns></returns>
        public override bool Test(System.Diagnostics.Stopwatch sw)
        {
            bool isSuccess = true;

            TreeNode root; int low, high;
            TreeNode result, checkResult;

            root = TreeNode.Create(new int[] { 3, 0, 4, NULL, 2, NULL, NULL, 1 }, NULL);
            low = 1; high = 3;
            checkResult = TreeNode.Create(new int[] { 3, 2, NULL, 1 }, NULL);
            result = TrimBST(root, low, high);
            isSuccess &= IsSame(result, checkResult);
            PrintResult(isSuccess, (result).GetNodeString(), (checkResult).GetNodeString());

            return isSuccess;
        }
        /// <summary>
        /// 作者：LeetCode
        /// 链接：https://leetcode-cn.com/problems/trim-a-binary-search-tree/solution/xiu-jian-er-cha-sou-suo-shu-by-leetcode/
        ///
        /// 分析：
        /// 当 node.val > R，那么修剪后的二叉树必定出现在节点的左边。
        /// 当 node.val<L，那么修剪后的二叉树出现在节点的右边。
        /// 否则，我们将会修剪树的两边
        ///
        /// 78/78 cases passed (96 ms)
        /// Your runtime beats 100 % of csharp submissions
        /// Your memory usage beats 52.63 % of csharp submissions(28.2 MB)
        /// </summary>
        /// <param name="root"></param>
        /// <param name="low"></param>
        /// <param name="high"></param>
        /// <returns></returns>
        public TreeNode TrimBST(TreeNode root, int low, int high)
        {
            if (root == null) return root;

            //当 node.val > R，那么修剪后的二叉树必定出现在节点的左边。
            if (root.val > high) return TrimBST(root.left, low, high);
            //当 node.val<L，那么修剪后的二叉树出现在节点的右边
            if (root.val < low) return TrimBST(root.right, low, high);
            //否则，我们将会修剪树的两边
            root.left = TrimBST(root.left, low, high);
            root.right = TrimBST(root.right, low, high);

            return root;
        }
    }
    // @lc code=end


}
