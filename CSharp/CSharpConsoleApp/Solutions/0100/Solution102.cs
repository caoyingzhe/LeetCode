using System;
using System.Collections.Generic;
namespace CSharpConsoleApp.Solutions
{
    /*
     * @lc app=leetcode.cn id=102 lang=csharp
     *
     * [102] 二叉树的层序遍历
     *
     * https://leetcode-cn.com/problems/binary-tree-level-order-traversal/description/
     *
     * Category	Difficulty	Likes	Dislikes
     * algorithms	Medium (64.14%)	908	-
     * Tags
     * tree | breadth-first-search
     * 
     * Companies
     * amazon | apple | bloomberg | facebook | linkedin | microsoft
     * 
     * 给你一个二叉树，请你返回其按 层序遍历 得到的节点值。 （即逐层地，从左到右访问所有节点）
     * Total Accepted:    330.3K
     * Total Submissions: 514.9K
     * Testcase Example:  '[3,9,20,null,null,15,7]'
     *
     * 给你一个二叉树，请你返回其按 层序遍历 得到的节点值。 （即逐层地，从左到右访问所有节点）。
     * 
     * 示例：
     * 二叉树：[3,9,20,null,null,15,7],
     * 
     * 
     * ⁠   3
     * ⁠  / \
     * ⁠ 9  20
     * ⁠   /  \
     * ⁠  15   7
     * 
     * 
     * 返回其层序遍历结果：
     * [
     * ⁠ [3],
     * ⁠ [9,20],
     * ⁠ [15,7]
     * ]
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
    public class Solution102 : SolutionBase
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
            result = LevelOrder(root);
            checkResult = new int[][] {
                new int[] { 3 },
                new int[] { 9, 20},
                new int[] { 15, 7},
            };
            isSuccess &= IsArray2DSame(result, checkResult);
            PrintResult(isSuccess, GetArray2DStr(result), GetArray2DStr(checkResult));

            return isSuccess;
        }

        /// <summary>
        /// TODO 内存消耗太高，不太正常，待调查
        /// 34/34 cases passed (272 ms)
        /// Your runtime beats 95.17 % of csharp submissions
        /// Your memory usage beats 13.76 % of csharp submissions(31.1 MB)
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public IList<IList<int>> LevelOrder(TreeNode root)
        {
            IList<IList<int>> result = new List<IList<int>>();
            DFS(result, root, 0);
            return result;
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
            DFS(result, root.left,  depth + 1);
            DFS(result, root.right, depth + 1);
        }
    }
    // @lc code=end


}
