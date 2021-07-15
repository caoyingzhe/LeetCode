using System;
using System.Collections.Generic;
namespace CSharpConsoleApp.Solutions
{
    /*
 * @lc app=leetcode.cn id=144 lang=csharp
 *
 * [144] 二叉树的前序遍历
 *
 * https://leetcode-cn.com/problems/binary-tree-preorder-traversal/description/
 *
 * Category	Difficulty	Likes	Dislikes
 * algorithms	Easy (69.92%)	592	-
 * Tags
 * stack | tree
 * 
 * Companies
 * Unknown
 * 
 * Total Accepted:    343.9K
 * Total Submissions: 491.8K
 * Testcase Example:  '[1,null,2,3]'
 *
 * 给你二叉树的根节点 root ，返回它节点值的 前序 遍历。
 * 
 * 
 * 示例 1：
 * 输入：root = [1,null,2,3]
 * 输出：[1,2,3]
 * 
 * 
 * 示例 2：
 * 输入：root = []
 * 输出：[]
 * 
 * 
 * 示例 3：
 * 输入：root = [1]
 * 输出：[1]
 * 
 * 
 * 示例 4：
 * 输入：root = [1,2]
 * 输出：[1,2]
 * 
 * 
 * 示例 5：
 * 输入：root = [1,null,2]
 * 输出：[1,2]
 * 
 * 
 * 提示：
 * 树中节点数目在范围 [0, 100] 内
 * -100 <= Node.val <= 100
 *
 * 
 * 进阶：递归算法很简单，你可以通过迭代算法完成吗？
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
    public class Solution144 : SolutionBase
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
        public override Tag[] GetTags() { return new Tag[] { Tag.Tree,  }; }

        public override bool Test(System.Diagnostics.Stopwatch sw)
        {
            bool isSuccess = true;
            IList<int> result, checkResult;
            TreeNode root;

            root = TreeNode.Create(new int[] { 1, -1, 2, -1, -1, 3 }, -1);
            checkResult = new int[] { 1, 2, 3 };
            result = PreorderTraversal(root);
            isSuccess &= IsListSame(result, checkResult);
            PrintResult(isSuccess, GetArrayStr(result), GetArrayStr(checkResult));

            return isSuccess;
        }

        /// <summary>
        /// 69/69 cases passed (284 ms)
        /// Your runtime beats 45.35 % of csharp submissions
        /// Your memory usage beats 30.93 % of csharp submissions(29.9 MB)
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public IList<int> PreorderTraversal(TreeNode root)
        {
            List<int> rtn = new List<int>();
            GetValueList_Preorder(root, rtn);
            return rtn;
        }

        /// <summary>
        /// 获取值列表（前序遍历） Solution144
        /// </summary>
        /// <param name="node"></param>
        /// <param name="nodeList"></param>
        /// <param name="noAddNullNode"></param>
        /// <param name="nullVale"></param>
        public void GetValueList_Preorder(TreeNode node, List<int> nodeList)
        {
            if (node == null)
            {
                return;
            }
            nodeList.Add(node.val);
            GetValueList_Preorder(node.left, nodeList);
            GetValueList_Preorder(node.right, nodeList);
        }
    }
    // @lc code=end


}
