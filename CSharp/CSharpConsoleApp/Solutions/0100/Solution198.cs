using System;
namespace CSharpConsoleApp.Solutions
{
    /*
     * @lc app=leetcode.cn id=198 lang=csharp
     *
     * [198] 打家劫舍
     *
     * https://leetcode-cn.com/problems/house-robber/description/
     *
     * Category	Difficulty	Likes	Dislikes
     * algorithms	Medium (49.95%)	1508	-
     * Tags
     * dynamic-programming
     * 
     * Companies
     * airbnb | linkedin
     * 
     * Total Accepted:    314.4K
     * Total Submissions: 629.3K
     * Testcase Example:  '[1,2,3,1]'
     *
     * 你是一个专业的小偷，计划偷窃沿街的房屋。每间房内都藏有一定的现金，影响你偷窃的唯一制约因素就是相邻的房屋装有相互连通的防盗系统，如果两间相邻的房屋在同一晚上被小偷闯入，系统会自动报警。
     * 给定一个代表每个房屋存放金额的非负整数数组，计算你 不触动警报装置的情况下 ，一夜之内能够偷窃到的最高金额。
     *
     * 
     * 示例 1：
     * 输入：[1,2,3,1]
     * 输出：4
     * 解释：偷窃 1 号房屋 (金额 = 1) ，然后偷窃 3 号房屋 (金额 = 3)。
     * 偷窃到的最高金额 = 1 + 3 = 4 。
     * 
     * 示例 2：
     * 输入：[2,7,9,3,1]
     * 输出：12
     * 解释：偷窃 1 号房屋 (金额 = 2), 偷窃 3 号房屋 (金额 = 9)，接着偷窃 5 号房屋 (金额 = 1)。
     * 偷窃到的最高金额 = 2 + 9 + 1 = 12 。
     * 
     * 
     * 提示：
     * 1 <= nums.length <= 100
     * 0 <= nums[i] <= 400
     */

    // @lc code=start
    public class Solution198 : SolutionBase
    {
        /// <summary>
        /// 难度
        /// </summary>
        public override Difficulity GetDifficulity() { return Difficulity.Medium; }
        /// <summary>
        /// 关键字:
        /// </summary>
        public override string[] GetKeyWords() { return new string[] { "" }; }
        /// <summary>
        /// 标签：
        /// </summary>
        public override Tag[] GetTags() { return new Tag[] { Tag.DynamicProgramming, }; }

        public override bool Test(System.Diagnostics.Stopwatch sw)
        {
            bool isSuccess = true;
            int[] nums;
            int result, checkResult;

            nums = new int[] { 2, 7, 9, 3, 1 };
            checkResult = 12;
            result = Rob(nums);

            isSuccess &= IsSame(result, checkResult);
            PrintResult(isSuccess, (result), (checkResult));
            return isSuccess;
        }

        /// <summary>
        /// 68/68 cases passed (96 ms)
        /// Your runtime beats 96.49 % of csharp submissions
        /// Your memory usage beats 55.26 % of csharp submissions(24 MB)
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public int Rob(int[] nums)
        {
            if (nums == null || nums.Length == 0) return 0;

            int n = nums.Length;
            if (n == 1) return nums[0];

            int[] dp = new int[n];

            dp[0] = nums[0];
            dp[1] = Math.Max(nums[0], nums[1]);
            for (int i = 2; i < n; i++)
            {
                dp[i] = Math.Max(dp[i-2] + nums[i], dp[i - 1]);
            }
            return dp[n - 1];
        }
    }
    // @lc code=end


}
