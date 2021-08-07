using System;
using System.Collections.Generic;
namespace CSharpConsoleApp.Solutions
{
    /*
     * @lc app=leetcode.cn id=437 lang=csharp
     *
     * [437] 路径总和 III
     *
     * https://leetcode-cn.com/problems/path-sum-iii/description/
     *
     * Category	Difficulty	Likes	Dislikes
     * algorithms	Medium (56.69%)	933	-
     * Tags
     * tree
     * 
     * Companies
     * Unknown
     * 
     * Total Accepted:    90.1K
     * Total Submissions: 159K
     * Testcase Example:  '[10,5,-3,3,2,null,11,3,-2,null,1]\n8'
     *
     * 给定一个二叉树的根节点 root ，和一个整数 targetSum ，求该二叉树里节点值之和等于 targetSum 的 路径 的数目。
     * 
     * 路径 不需要从根节点开始，也不需要在叶子节点结束，但是路径方向必须是向下的（只能从父节点到子节点）。
     * 
     * 
     * 
     * 示例 1：
     * 输入：root = [10,5,-3,3,2,null,11,3,-2,null,1], targetSum = 8
     * 输出：3
     * 解释：和等于 8 的路径有 3 条，如图所示。
     * 
     * 
     * 示例 2：
     * 输入：root = [5,4,8,11,null,13,4,7,2,null,null,5,1], targetSum = 22
     * 输出：3
     * 
     * 
     * 提示:
     * 二叉树的节点个数的范围是 [0,1000]
     * -10^9 <= Node.val <= 10^9
     * -1000 <= targetSum <= 1000 
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
    public class Solution437 : SolutionBase
    {
        /// <summary>
        /// 难度
        /// </summary>
        public override Difficulity GetDifficulity() { return Difficulity.Medium; }
        /// <summary>
        /// 关键字:
        /// </summary>
        public override string[] GetKeyWords() { return new string[] { "前缀和", "抄作业" }; }
        /// <summary>
        /// 标签：
        /// </summary>
        public override Tag[] GetTags() { return new Tag[] { Tag.Tree }; }

        /// <summary>
        /// </summary>
        /// <param name="sw"></param>
        /// <returns></returns>
        public override bool Test(System.Diagnostics.Stopwatch sw)
        {
            bool isSuccess = true;

            TreeNode root; int targetSum;
            int result, checkResult;

            root = TreeNode.Create(new int[] { 10, 5, -3, 3, 2, NULL, 11, 3, -2, NULL, 1 }, NULL);
            targetSum = 8; checkResult = 3;
            result = PathSum(root, targetSum);
            isSuccess &= IsSame(result, checkResult);
            PrintResult(isSuccess, (result), (checkResult));

            //       5
            //     4 , 8
            //  11,N   13,4
            //7,2,N,N,5,1
            root = TreeNode.Create(new int[] { 5, 4, 8, 11, NULL, 13, 4, 7, 2, NULL, NULL, 5, 1 }, NULL);
            targetSum = 22; checkResult = 3;
            result = PathSum(root, targetSum);
            isSuccess &= IsSame(result, checkResult);
            PrintResult(isSuccess, (result), (checkResult));

            return isSuccess;
        }

        //作者：fengziluo
        //链接：https://leetcode-cn.com/problems/path-sum-iii/solution/2chong-jie-fa-xiang-jie-xi-jie-wen-ti-by-txip/

        int res = 0;
        Dictionary<int, int> worker = new Dictionary<int, int>();

        /// <summary>
        /// 126/126 cases passed (88 ms)
        /// Your runtime beats 97.5 % of csharp submissions
        /// Your memory usage beats 22.5 % of csharp submissions(26.5 MB)
        /// </summary>
        /// <param name="root"></param>
        /// <param name="targetSum"></param>
        /// <returns></returns>
        public int PathSum(TreeNode root, int targetSum)
        {
            worker = new Dictionary<int, int>();
            //该行处理代表如果节点为0，累计和等于目标值的数量多一个 ???
            worker.Add(0, 1);
            res = 0;
            dfs(root, 0, targetSum);
            return res;  
        }

        void dfs(TreeNode root, int preSum, int target)
        {
            if (root == null) return;
            preSum += root.val;
            if(worker.ContainsKey(preSum - target))
            {
                PrintDatas(res, res+1, preSum, root.val, target);
                res += worker[preSum - target];
            }
            if (!worker.ContainsKey(preSum))
                worker.Add(preSum, 0);
            ++worker[preSum];
            dfs(root.left, preSum, target);
            dfs(root.right, preSum, target);
            --worker[preSum];
        }
    }
    // @lc code=end


}
