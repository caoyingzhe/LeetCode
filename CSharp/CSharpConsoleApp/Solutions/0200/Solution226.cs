using System;
namespace CSharpConsoleApp.Solutions
{
    /*
     * @lc app=leetcode.cn id=226 lang=csharp
     *
     * [226] 翻转二叉树
     *
     * https://leetcode-cn.com/problems/invert-binary-tree/description/
     *
     * algorithms
     * Easy (78.52%)
     * Likes:    901
     * Dislikes: 0
     * Total Accepted:    254.5K
     * Total Submissions: 324.2K
     * Testcase Example:  '[4,2,7,1,3,6,9]'
     *
     * 翻转一棵二叉树。
     * 示例：
     * 输入：
     * 
     * ⁠    4
     * ⁠  /   \
     * ⁠ 2     7
     * ⁠/ \   / \
     * 1   3 6   9
     * 
     * 输出：
     * 
     * ⁠    4
     * ⁠  /   \
     * ⁠ 7     2
     * ⁠/ \   / \
     * 9   6 3   1
     * 
     * 备注:
     * 这个问题是受到 Max Howell 的 原问题 启发的 ：
     * 谷歌：我们90％的工程师使用您编写的软件(Homebrew)，但是您却无法在面试时在白板上写出翻转二叉树这道题，这太糟糕了。
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
    public class Solution226 : SolutionBase
    {
        /// <summary>
        /// 难度
        /// </summary>
        public override Difficulity GetDifficulity() { return Difficulity.Easy; }
        /// <summary>
        /// 关键字:
        /// </summary>
        public override string[] GetKeyWords() { return new string[] { "" }; }
        /// <summary>
        /// 标签：
        /// </summary>
        public override Tag[] GetTags() { return new Tag[] { Tag.Tree, }; }

        public override bool Test(System.Diagnostics.Stopwatch sw)
        {
            bool isSuccess = true;
            TreeNode result, checkResult;
            TreeNode root;

            root = TreeNode.Create(new int[] { 4, 2,7,1,3,6,9 }, -1);
            checkResult = TreeNode.Create(new int[] { 4,7,2,9,6,3,1}, -1);
            result = InvertTree(root);
            isSuccess &= IsSame(result, checkResult);
            PrintResult(isSuccess, (result).GetNodeString(true), (checkResult).GetNodeString(true));

            return isSuccess;
        }

        /// <summary>
        /// 77/77 cases passed (108 ms)
        /// Your runtime beats 72.43 % of csharp submissions
        /// Your memory usage beats 94.05 % of csharp submissions(23.9 MB)
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public TreeNode InvertTree(TreeNode root)
        {
            DFS(root);
            return root;
        }

        void DFS(TreeNode root)
        {
            if(root == null)
            {
                return;
            }
            TreeNode L = root.left;
            TreeNode R = root.right;
            root.right = L;
            root.left = R;
            DFS(root.left);
            DFS(root.right);
        }
    }
    // @lc code=end


}
