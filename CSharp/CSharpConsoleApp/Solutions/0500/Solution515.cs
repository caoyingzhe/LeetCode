using System;
using System.Collections.Generic;
namespace CSharpConsoleApp.Solutions
{
    /*
     * @lc app=leetcode.cn id=515 lang=csharp
     *
     * [515] 在每个树行中找最大值
     *
     * https://leetcode-cn.com/problems/find-largest-value-in-each-tree-row/description/
     *
     * Category	Difficulty	Likes	Dislikes
     * algorithms	Medium (63.99%)	137	-
     * Tags
     * tree | depth-first-search | breadth-first-search
     * 
     * Companies
     * linkedin
     * 
     * Total Accepted:    33.2K
     * Total Submissions: 51.9K
     * Testcase Example:  '[1,3,2,5,3,null,9]'
     *
     * 给定一棵二叉树的根节点 root ，请找出该二叉树中每一层的最大值。
     *
     * 
     * 示例1：
     * 输入: root = [1,3,2,5,3,null,9]
     * 输出: [1,3,9]
     * 解释:
     * ⁠         1
     * ⁠        / \
     * ⁠       3   2
     * ⁠      / \   \  
     * ⁠     5   3   9 
     * 
     * 
     * 示例2：
     * 
     * 
     * 输入: root = [1,2,3]
     * 输出: [1,3]
     * 解释:
     * ⁠         1
     * ⁠        / \
     * ⁠       2   3
     * 
     * 
     * 示例3：
     * 输入: root = [1]
     * 输出: [1]
     * 
     * 
     * 示例4：
     * 输入: root = [1,null,2]
     * 输出: [1,2]
     * 解释:      
     * 1 
     * \
     * 2     
     * 
     * 
     * 示例5：
     * 输入: root = []
     * 输出: []
     * 
     * 
     * 提示：
     * 二叉树的节点个数的范围是 [0,10^4]
     * -2^31 <= Node.val <= 2^31 - 1
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
    public class Solution515 : SolutionBase
    {
        /// <summary>
        /// 难度
        /// </summary>
        public override Difficulity GetDifficulity() { return Difficulity.Medium; }
        /// <summary>
        /// 关键字:
        /// </summary>
        public override string[] GetKeyWords() { return new string[] { "掌握" }; }
        /// <summary>
        /// 标签：
        /// </summary>
        public override Tag[] GetTags() { return new Tag[] { Tag.Tree, Tag.DepthFirstSearch, Tag.BreadthFirstSearch }; }

        
        /// <summary>
        /// </summary>
        /// <param name="sw"></param>
        /// <returns></returns>
        public override bool Test(System.Diagnostics.Stopwatch sw)
        {
            bool isSuccess = true;

            TreeNode root;
            IList<int> result, checkResult;

            root = TreeNode.Create(new int[] { 1, 3, 2, 5, 3, NULL, 9 }, NULL);
            checkResult = new int[] { 1, 3, 9 };
            result = LargestValues(root);
            isSuccess &= IsListSame(result, checkResult, true);
            PrintResult(isSuccess, result, checkResult);

            root = TreeNode.Create(new int[] { 1, 2, 3 }, NULL);
            checkResult = new int[] { 1,3 };
            result = LargestValues(root);
            isSuccess &= IsListSame(result, checkResult, true);
            PrintResult(isSuccess, result, checkResult);

            root = TreeNode.Create(new int[] { 1 }, NULL);
            checkResult = new int[] { 1 };
            result = LargestValues(root);
            isSuccess &= IsListSame(result, checkResult, true);
            PrintResult(isSuccess, result, checkResult);

            root = TreeNode.Create(new int[] { 1, NULL, 2 }, NULL);
            checkResult = new int[] { 1, 2 };
            result = LargestValues(root);
            isSuccess &= IsListSame(result, checkResult, true);
            PrintResult(isSuccess, result, checkResult);

            //root = TreeNode.Create(new int[] {  }, NULL);
            //checkResult = new int[] { };
            //result = LargestValues(root);
            //isSuccess &= IsListSame(result, checkResult, true);
            //PrintResult(isSuccess, result, checkResult);

            return isSuccess;
        }

        /// <summary>
        /// 78/78 cases passed (236 ms)
        /// Your runtime beats 100 % of csharp submissions
        /// Your memory usage beats 46.15 % of csharp submissions(32.4 MB)
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public IList<int> LargestValues(TreeNode root)
        {
            List<int> result = new List<int>();
            DFS(root, 0, result);//层级从0开始，result不需要考虑加1、减1的情况
            return result;
        }

        public void DFS(TreeNode root, int level, List<int> result)
        {
            //递归DFS总结条件
            if (root == null)
            {
                return;
            }
            if (result.Count == level)
            {
                result.Add(root.val);
            }
            result[level] = Math.Max(result[level], root.val);

            DFS(root.left, level + 1, result);
            DFS(root.right, level + 1, result);
        }
    }
    // @lc code=end
}
