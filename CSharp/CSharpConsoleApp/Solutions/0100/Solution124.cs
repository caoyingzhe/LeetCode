using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpConsoleApp.Solutions
{
    /*
     * @lc app=leetcode.cn id=124 lang=csharp
     *
     * [124] 二叉树中的最大路径和
     *
     * https://leetcode-cn.com/problems/binary-tree-maximum-path-sum/description/
     *
     * algorithms
     * Hard (43.50%)
     * Likes:    972
     * Dislikes: 0
     * Total Accepted:    109.2K
     * Total Submissions: 250.9K
     * Testcase Example:  '[1,2,3]'
     *
     * 路径 被定义为一条从树中任意节点出发，沿父节点-子节点连接，达到任意节点的序列。
     * 同一个节点在一条路径序列中 至多出现一次 。该路径 至少包含一个
     * 节点，且不一定经过根节点。
     * 路径和 是路径中各节点值的总和。
     * 给你一个二叉树的根节点 root ，返回其 最大路径和 。
     * 
     * 示例 1：
     * 输入：root = [1,2,3]
     * 输出：6
     * 解释：最优路径是 2 -> 1 -> 3 ，路径和为 2 + 1 + 3 = 6
     * 
     * 示例 2：
     * 输入：root = [-10,9,20,null,null,15,7]
     * 输出：42
     * 解释：最优路径是 15 -> 20 -> 7 ，路径和为 15 + 20 + 7 = 42
     * 
     * 提示：
     * 树中节点数目范围是 [1, 3 * 10^4]
     * -1000 <= Node.val <= 1000
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
    class Solution124 : SolutionBase
    {
        /// <summary>
        /// 难度
        /// </summary>
        public override Difficulity GetDifficulity() { return Difficulity.Hard; }
        /// <summary>
        /// 关键字:
        /// </summary>
        public override string[] GetKeyWords() { return new string[] { "二叉树中的最大路径和", }; }
        /// <summary>
        /// 标签：
        /// </summary>
        public override Tag[] GetTags() { return new Tag[] { Tag.Tree, Tag.DepthFirstSearch }; }

        public override bool Test(System.Diagnostics.Stopwatch sw)
        {
            bool isSuccess = true;
            TreeNode root;
            int result;
            int checkResult;

            //root = TreeNode.Create(new string[] { "-3", "-2", "-6" });
            //checkResult = -2;
            //result = MaxPathSum(root);
            //isSuccess &= (checkResult == result);
            //Print("isSuccess ={0} | result = {1} | checkResult = {2}", isSuccess, result, checkResult);

            //root = TreeNode.Create(new string[] { "1", "2", "3" });
            //checkResult = 6;
            //result = MaxPathSum(root);
            //isSuccess &= (checkResult == result);
            //Print("isSuccess ={0} | result = {1} | checkResult = {2}", isSuccess, result, checkResult);
            //
            root = TreeNode.Create(new string[] { "-10", "9", "20", "null", "null", "15", "7" });
            checkResult = 42;
            result = MaxPathSum(root);
            isSuccess &= (checkResult == result);
            Print("isSuccess ={0} | result = {1} | checkResult = {2}", isSuccess, result, checkResult);
            
            return isSuccess;
        }


        int maxSum = int.MinValue;

        /// <summary>
        /// 分析： 
        /// 1. 空节点的最大贡献值等于 0。
        /// 2. 非空节点的最大贡献值等于节点值与其子节点中的最大贡献值之和（对于叶节点而言，最大贡献值等于节点值）。
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public int MaxPathSum(TreeNode root)
        {
            MaxGain(root);
            return maxSum;
        }

        /// <summary>
        /// 如果节点全部为负数，结果就是节点中最大的负数（绝对值最小的负数）。
        /// </summary>
        /// <param name="node"></param>
        /// <returns></returns>
        public int MaxGain(TreeNode node, string info = "")
        {
            //1. 空节点的最大贡献值等于 0。
            if (node == null)
            {
                return 0;
            }

            Print(">>>>>> Node ={0} Start", node.val + info);
            // 递归计算左右子节点的最大贡献值
            // 只有在最大贡献值大于 0 时，才会选取对应子节点。(该处理是递归）
            int leftGain = Math.Max(MaxGain(node.left, " [" + node.val + "]->L"), 0);
            int rightGain = Math.Max(MaxGain(node.right, " [" + node.val + "]->R"), 0);

            
            // 节点的最大路径和取决于该节点的值与该节点的左右子节点的最大贡献值
            int priceNewpath = node.val + leftGain + rightGain;
            Print("<<< Node ={0} End, | L={1}, R= {2} | price ={3} | maxSum = {4} => {5} | nodeSum= {6}", node.val, leftGain, rightGain, priceNewpath, maxSum, Math.Max(maxSum, priceNewpath), node.val + Math.Max(leftGain, rightGain));
            // 更新答案
            maxSum = Math.Max(maxSum, priceNewpath);

            
            // 返回节点的最大贡献值 = 自己 + 左右贡献大的值。(该处理是递归）
            return node.val + Math.Max(leftGain, rightGain);
        }
    }
}
