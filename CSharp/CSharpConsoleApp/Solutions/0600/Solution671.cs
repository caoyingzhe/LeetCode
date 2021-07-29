using System;
using System.Collections.Generic;
namespace CSharpConsoleApp.Solutions
{
    /*
 * @lc app=leetcode.cn id=671 lang=csharp
 *
 * [671] 二叉树中第二小的节点
 *
 * https://leetcode-cn.com/problems/second-minimum-node-in-a-binary-tree/description/
 *
 * Category	Difficulty	Likes	Dislikes
 * algorithms	Easy (46.20%)	152	-
 * Tags
 * tree
 * 
 * Companies
 * linkedin
 * Total Accepted:    26.9K
 * Total Submissions: 58.3K
 * Testcase Example:  '[2,2,5,null,null,5,7]'
 *
 * 给定一个非空特殊的二叉树，每个节点都是正数，并且每个节点的子节点数量只能为 2 或
 * 0。如果一个节点有两个子节点的话，那么该节点的值等于两个子节点中较小的一个。
 * 更正式地说，root.val = min(root.left.val, root.right.val) 总成立。
 * 给出这样的一个二叉树，你需要输出所有节点中的第二小的值。如果第二小的值不存在的话，输出 -1 。
 * 
 * 
 * 示例 1：
 * 输入：root = [2,2,5,null,null,5,7]
 * 输出：5
 * 解释：最小的值是 2 ，第二小的值是 5 。
 * 
 * 
 * 示例 2：
 * 输入：root = [2,2,2]
 * 输出：-1
 * 解释：最小的值是 2, 但是不存在第二小的值。
 * 
 * 
 * 提示：
 * 树中节点数目在范围 [1, 25] 内
 * 1 
 * 对于树中每个节点 root.val == min(root.left.val, root.right.val)
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

    public class Solution671 : SolutionBase
    {
        /// <summary>
        /// 难易度:
        /// </summary>
        public override Difficulity GetDifficulity() { return Difficulity.Easy; }
        /// <summary>
        /// 关键字:
        /// </summary>
        public override string[] GetKeyWords() { return new string[] { "通过" }; }
        /// <summary>
        /// 标签：
        /// </summary>
        public override Tag[] GetTags() { return new Tag[] { Tag.Tree }; }

        //TODO
        public override bool Test(System.Diagnostics.Stopwatch sw)
        {
            bool isSuccess = true;
            TreeNode root;
            int result, checkResult;

            root = TreeNode.Create(new int[] { 2, 2, 5, NULL, NULL, 5, 7 }, NULL);
            checkResult = 5;
            result = FindSecondMinimumValue(root);
            isSuccess &= IsSame(result, checkResult);
            PrintResult(isSuccess, result, checkResult);

            root = TreeNode.Create(new int[] { 2, 2, 2 }, NULL);
            checkResult = -1;
            result = FindSecondMinimumValue(root);
            isSuccess &= IsSame(result, checkResult);
            PrintResult(isSuccess, result, checkResult);

            return isSuccess;
        }
        /// <summary>
        /// 39/39 cases passed (84 ms)
        /// Your runtime beats 90 % of csharp submissions
        /// Your memory usage beats 70 % of csharp submissions(24 MB)
        /// </summary>
        long[] min = new long[] { long.MaxValue, long.MaxValue };
        bool isFound = false;
        public int FindSecondMinimumValue(TreeNode root)
        {
            isFound = false;
            min = new long[] { long.MaxValue, long.MaxValue };
            DFS(root);
            if(isFound) return (int) min[1];
            return -1;
        }

        public void DFS(TreeNode root)
        {
            if (root == null)
                return;

            if(root.val == min[0])
            {

            }
            else if (root.val < min[0])
            {
                min[1] = min[0];
                min[0] = root.val;
            }
            else if(root.val < min[1])
            {
                min[1] = root.val;
                isFound = true;
            }
            DFS(root.left);
            DFS(root.right);
        }
    }
    // @lc code=end


}
