using System;
using System.Collections.Generic;
namespace CSharpConsoleApp.Solutions
{
    /*
 * @lc app=leetcode.cn id=113 lang=csharp
 *
 * [113] 路径总和 II
 *
 * https://leetcode-cn.com/problems/path-sum-ii/description/
 *
 * algorithms
 * Medium (62.40%)
 * Likes:    521
 * Dislikes: 0
 * Total Accepted:    150.3K
 * Total Submissions: 240.7K
 * Testcase Example:  '[5,4,8,11,null,13,4,7,2,null,null,5,1]\n22'
 *
 * 给你二叉树的根节点 root 和一个整数目标和 targetSum ，找出所有 从根节点到叶子节点 路径总和等于给定目标和的路径。
 * 
 * 叶子节点 是指没有子节点的节点。
 * 
 * 
 * 
 * 
 * 
 * 示例 1：
 * 
 * 
 * 输入：root = [5,4,8,11,null,13,4,7,2,null,null,5,1], targetSum = 22
 * 输出：[[5,4,11,2],[5,8,4,5]]
 * 
 * 
 * 示例 2：
 * 
 * 
 * 输入：root = [1,2,3], targetSum = 5
 * 输出：[]
 * 
 * 
 * 示例 3：
 * 
 * 
 * 输入：root = [1,2], targetSum = 0
 * 输出：[]
 * 
 * 
 * 
 * 
 * 提示：
 * 
 * 
 * 树中节点总数在范围 [0, 5000] 内
 * -1000 
 * -1000 
 * 
 * 
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
    public class Solution113 : SolutionBase
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
        /// </summary>
        /// <param name="sw"></param>
        /// <returns></returns>
        public override bool Test(System.Diagnostics.Stopwatch sw)
        {
            bool isSuccess = true;

            TreeNode root; int targetSum;
            IList<IList<int>> result, checkResult;

            //      5
            // ⁠   /    \
            // ⁠  4      8
            // ⁠ / \      / \
            // ⁠11   N   13  4
            // / \     / \ / \
            // 7 2     N N 5 1
            root = TreeNode.Create(new int[] { 5, 4, 8, 11, NULL, 13, 4, 7, 2, NULL, NULL, NULL, NULL, 5, 1 }, NULL);
            targetSum = 22;
            result = PathSum(root, targetSum);
            checkResult = new int[][] {
                new int[] { 5,4,11,2 },
                new int[] { 5,8,4,5},
            };
            isSuccess &= IsArray2DSame(result, checkResult);
            PrintResult(isSuccess, GetArray2DStr(result), GetArray2DStr(checkResult));

            //1,2 1
            root = TreeNode.Create(new int[] { 1, 2 }, NULL);
            targetSum = 1;
            result = PathSum(root, targetSum);
            checkResult = new int[][] {
            };
            isSuccess &= IsArray2DSame(result, checkResult);
            PrintResult(isSuccess, GetArray2DStr(result), GetArray2DStr(checkResult));

            root = TreeNode.Create(new int[] { 1 }, NULL);
            targetSum = 1;
            result = PathSum(root, targetSum);
            checkResult = new int[][] {
                 new int[] { 1 },
            };
            isSuccess &= IsArray2DSame(result, checkResult);
            PrintResult(isSuccess, GetArray2DStr(result), GetArray2DStr(checkResult));

            //[-2,null,-3]
            return isSuccess;
        }

        /// <summary>
        /// 115/115 cases passed (304 ms)
        /// Your runtime beats 25.86 % of csharp submissions
        /// Your memory usage beats 53.45 % of csharp submissions(32.5 MB)
        /// </summary>
        /// <param name="root"></param>
        /// <param name="targetSum"></param>
        /// <returns></returns>
        public IList<IList<int>> PathSum(TreeNode root, int targetSum)
        {
            IList<IList<int>> result = new List<IList<int>>();
            List<int> tmp = new List<int>();
            int sum = 0;
            DFS(result, tmp, root, root, sum, targetSum);
            return result;
        }

        public void DFS(IList<IList<int>> result, List<int> tmp, TreeNode rootTop, TreeNode root, int sum, int targetSum)
        {
            if (root == null)
            {
                return;
            }
            sum += root.val;
            tmp.Add(root.val);
            if (root.left == null && root.right == null && sum == targetSum)
                result.Add(tmp.ToArray());

            if (root.left != null)
            { 
                DFS(result, tmp, rootTop, root.left, sum, targetSum);
                tmp.RemoveAt(tmp.Count - 1);
            }
            if (root.right != null)
            { 
                DFS(result, tmp, rootTop, root.right, sum, targetSum);
                tmp.RemoveAt(tmp.Count - 1);
            }
        }
    }
    // @lc code=end


}
