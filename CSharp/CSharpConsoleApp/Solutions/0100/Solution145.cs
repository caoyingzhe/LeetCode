using System;
using System.Collections.Generic;
namespace CSharpConsoleApp.Solutions
{
    /*
     * @lc app=leetcode.cn id=145 lang=csharp
     *
     * [145] 二叉树的后序遍历
     *
     * https://leetcode-cn.com/problems/binary-tree-postorder-traversal/description/
     *
     * algorithms
     * Easy (74.64%)
     * Likes:    615
     * Dislikes: 0
     * Total Accepted:    249.3K
     * Total Submissions: 334K
     * Testcase Example:  '[1,null,2,3]'
     *
     * 给定一个二叉树，返回它的 后序 遍历。
     * 
     * 示例:
     * 
     * 输入: [1,null,2,3]  
     * ⁠  1
     * ⁠   \
     * ⁠    2
     * ⁠   /
     * ⁠  3 
     * 
     * 输出: [3,2,1]
     * 
     * 进阶: 递归算法很简单，你可以通过迭代算法完成吗？
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

    public class Solution145 : SolutionBase
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
            IList<int> result, checkResult;
            TreeNode root;

            root = TreeNode.Create(new int[] { 1, -1, 2, -1, -1, 3 }, -1);
            checkResult = new int[] { 3, 2, 1};
            result = PostorderTraversal(root);
            isSuccess &= IsListSame(result, checkResult);
            PrintResult(isSuccess, GetArrayStr(result), GetArrayStr(checkResult));

            return isSuccess;
        }

        /// <summary>
        /// 68/68 cases passed (304 ms)
        /// Your runtime beats 17.5 % of csharp submissions
        /// Your memory usage beats 52.92 % of csharp submissions(29.8 MB)
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public IList<int> PostorderTraversal(TreeNode root)
        {
            List<int> rtn = new List<int>();
            GetValueList_Postorder(root, rtn);
            return rtn;
        }

        /// <summary>
        /// 获取值列表（后序遍历） Solution145
        /// </summary>
        /// <param name="node"></param>
        /// <param name="nodeList"></param>
        /// <param name="noAddNullNode"></param>
        /// <param name="nullVale"></param>
        public void GetValueList_Postorder(TreeNode node, List<int> nodeList)
        {
            if (node == null)
            {
                return;
            }
            GetValueList_Postorder(node.left, nodeList);
            GetValueList_Postorder(node.right, nodeList);
            nodeList.Add(node.val);
        }
    }
}
