using System;
using System.Collections.Generic;
using System.Linq;
namespace CSharpConsoleApp.Solutions
{
    /*
     * @lc app=leetcode.cn id=103 lang=csharp
     *
     * [103] 二叉树的锯齿形层序遍历
     *
     * https://leetcode-cn.com/problems/binary-tree-zigzag-level-order-traversal/description/
     *
     * Category	Difficulty	Likes	Dislikes
     * algorithms	Medium (57.11%)	457	-
     * Tags
     * stack | tree | breadth-first-search
     * 
     * Companies
     * bloomberg | linkedin | microsoft
     * 
     * Total Accepted:    147.6K
     * Total Submissions: 258.5K
     * Testcase Example:  '[3,9,20,null,null,15,7]'
     *
     * 给定一个二叉树，返回其节点值的锯齿形层序遍历。（即先从左往右，再从右往左进行下一层遍历，以此类推，层与层之间交替进行）。
     * 
     * 例如：
     * 给定二叉树 [3,9,20,null,null,15,7],
     * 
     * ⁠   3
     * ⁠  / \
     * ⁠ 9  20
     * ⁠   /  \
     * ⁠  15   7
     * 
     * 返回锯齿形层序遍历如下：
     * [
     * ⁠ [3],
     * ⁠ [20,9],
     * ⁠ [15,7]
     * ]
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
    public class Solution103 : SolutionBase
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

        const int NULL = int.MinValue;
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

            //root = TreeNode.Create(new int[] { 3, 9, 20, -1, -1, 15, 7 }, -1);
            //result = ZigzagLevelOrder(root);
            //checkResult = new int[][] {
            //    new int[] { 3 },
            //    new int[] { 20, 9},
            //    new int[] { 15, 7},
            //};
            //isSuccess &= IsArray2DSame(result, checkResult);
            //PrintResult(isSuccess, GetArray2DStr(result), GetArray2DStr(checkResult));

            //      ⁠     0
            //      ⁠   /   \
            //       2       4
            //      /  \    /  \
            //    1     N   3   -1
            //   / \       / \  / \
            //  5   1     N  6  N  8
            //[0,2,4,1,null,3,-1,5,1,null,6,null,8]
            root = TreeNode.Create(new int[] { 0, 2, 4, 1, NULL, 3, -1, 5, 1, NULL, NULL, NULL, 6, NULL, 8 }, NULL);
            result = ZigzagLevelOrder(root);
            checkResult = new int[][] {
                new int[] { 0 },
                new int[] { 4, 2},
                new int[] { 1, 3, -1},
                new int[] { 8, 6, 1, 5 },
            };
            isSuccess &= IsArray2DSame(result, checkResult);
            PrintResult(isSuccess, GetArray2DStr(result), GetArray2DStr(checkResult));
            return isSuccess;
        }

        ////// <summary>
        ///33/33 cases passed (404 ms)
        ///Your runtime beats 5.66 % of csharp submissions
        ///Your memory usage beats 5.66 % of csharp submissions(30.9 MB)
        /// TODO 速度及其慢，内存消耗太高，不太正常，待调查
        /// 34/34 cases passed (272 ms)
        /// Your runtime beats 95.17 % of csharp submissions
        /// Your memory usage beats 13.76 % of csharp submissions(31.1 MB)
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public IList<IList<int>> ZigzagLevelOrder(TreeNode root)
        {
            IList<IList<int>> result = new List<IList<int>>();
            if (root != null)
            {
                result.Add(new List<int>());
                result[0].Add(root.val);
            }

            DFS(result, root, 1);
            for (int i = 1; i < result.Count; i += 2)
            {
                var arr = result[i].ToArray();
                Array.Reverse(arr);
                result[i] = arr;
            }
            return result;
        }

        public void DFS(IList<IList<int>> result, TreeNode root, int depth)
        {
            if (root == null || (root.left == null && root.right == null))
            {
                return;
            }

            if (depth > result.Count - 1)
                result.Add(new List<int>());

            //if(depth %2 == 0)
            //{
            //    if(root.left != null) result[depth].Add(root.left.val);
            //    if(root.right != null) result[depth].Add(root.right.val);

            //}
            //else 
            //{
            //    if (root.right != null) result[depth].Add(root.right.val);
            //    if (root.left != null) result[depth].Add(root.left.val);
            //}
            if (root.left != null) result[depth].Add(root.left.val);
            if (root.right != null) result[depth].Add(root.right.val);

            DFS(result, root.left, depth + 1);
            DFS(result, root.right, depth + 1);
        }
    }
    // @lc code=end


}
