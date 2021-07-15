using System;
using System.Collections.Generic;
namespace CSharpConsoleApp.Solutions
{
    /*
 * @lc app=leetcode.cn id=107 lang=csharp
 *
 * [107] 二叉树的层序遍历 II
 *
 * https://leetcode-cn.com/problems/binary-tree-level-order-traversal-ii/description/
 *
 * Category	Difficulty	Likes	Dislikes
 * algorithms	Medium (69.15%)	453	-
 * Tags
 * tree | breadth-first-search
 * 
 * Companies
 * Unknown
 * Total Accepted:    148K
 * Total Submissions: 214K
 * Testcase Example:  '[3,9,20,null,null,15,7]'
 *
 * 给定一个二叉树，返回其节点值自底向上的层序遍历。 （即按从叶子节点所在层到根节点所在的层，逐层从左向右遍历）
 * 
 * 例如：
 * 给定二叉树 [3,9,20,null,null,15,7],
 * 
 * 
 * ⁠   3
 * ⁠  / \
 * ⁠ 9  20
 * ⁠   /  \
 * ⁠  15   7
 * 
 * 
 * 返回其自底向上的层序遍历为：
 * 
 * 
 * [
 * ⁠ [15,7],
 * ⁠ [9,20],
 * ⁠ [3]
 * ]
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
    public class Solution107 : SolutionBase
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
            IList<IList<int>> result, checkResult;

            root = TreeNode.Create(new int[] { 3, 9, 20, -1, -1, 15, 7 }, -1);
            result = LevelOrderBottom(root);
            checkResult = new int[][] {
                new int[] { 15, 7},
                new int[] { 9, 20},
                new int[] { 3 },
            };
            isSuccess &= IsArray2DSame(result, checkResult);
            PrintResult(isSuccess, GetArray2DStr(result), GetArray2DStr(checkResult));

            return isSuccess;
        }


        //public IList<IList<int>> LevelOrder(TreeNode root)
        //{
        //    IList<IList<int>> result = new List<IList<int>>();
        //    DFS(result, root, 0);
        //    return result;
        //}

        /// <summary>
        /// 34/34 cases passed (276 ms)
        /// Your runtime beats 90 % of csharp submissions
        /// Your memory usage beats 5.71 % of csharp submissions(31.3 MB)
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public IList<IList<int>> LevelOrderBottom(TreeNode root)
        {
            List<IList<int>> result = new List<IList<int>>();
            DFS(result, root, 0);
            var arr = result.ToArray();
            Array.Reverse(arr);
            return arr;
        }


        public void DFS(IList<IList<int>> result, TreeNode root, int depth)
        {
            if (root == null)
            {
                return;
            }
            if (depth > result.Count - 1)
                result.Add(new List<int>());
            result[depth].Add(root.val);
            DFS(result, root.left, depth + 1);
            DFS(result, root.right, depth + 1);
        }
    }
    // @lc code=end


}
