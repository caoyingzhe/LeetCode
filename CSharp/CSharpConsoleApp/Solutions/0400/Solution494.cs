using System;
namespace CSharpConsoleApp.Solutions
{
    /*
     * @lc app=leetcode.cn id=494 lang=csharp
     *
     * [494] 目标和
     *
     * https://leetcode-cn.com/problems/target-sum/description/
     *
     * algorithms
     * Medium (49.59%)
     * Likes:    809
     * Dislikes: 0
     * Total Accepted:    121K
     * Total Submissions: 243.9K
     * Testcase Example:  '[1,1,1,1,1]\n3'
     *
     * 给你一个整数数组 nums 和一个整数 target 。
     * 
     * 向数组中的每个整数前添加 '+' 或 '-' ，然后串联起所有整数，可以构造一个 表达式 ：
     * 
     * 
     * 例如，nums = [2, 1] ，可以在 2 之前添加 '+' ，在 1 之前添加 '-' ，然后串联起来得到表达式 "+2-1" 。
     * 
     * 
     * 返回可以通过上述方法构造的、运算结果等于 target 的不同 表达式 的数目。
     * 
     * 
     * 
     * 示例 1：
     * 
     * 
     * 输入：nums = [1,1,1,1,1], target = 3
     * 输出：5
     * 解释：一共有 5 种方法让最终目标和为 3 。
     * -1 + 1 + 1 + 1 + 1 = 3
     * +1 - 1 + 1 + 1 + 1 = 3
     * +1 + 1 - 1 + 1 + 1 = 3
     * +1 + 1 + 1 - 1 + 1 = 3
     * +1 + 1 + 1 + 1 - 1 = 3
     * 
     * 
     * 示例 2：
     * 
     * 
     * 输入：nums = [1], target = 1
     * 输出：1
     * 
     * 
     * 
     * 
     * 提示：
     * 
     * 
     * 1 
     * 0 
     * 0 
     * -1000 
     * 
     * 
     */

    // @lc code=start
    public class Solution494
    {
        /// <summary>
        /// 动态规划
        /// dp[i][j] 表示在数组 nums 的前 i 个数中选取元素，使得这些元素之和等于 j 的方案数。
        ///  
        /// 138/138 cases passed (112 ms)
        /// Your runtime beats 84.79 % of csharp submissions
        /// Your memory usage beats 26.19 % of csharp submissions(25.9 MB)
        /// 作者：LeetCode-Solution
        /// 链接：https://leetcode-cn.com/problems/target-sum/solution/mu-biao-he-by-leetcode-solution-o0cp/
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        public int FindTargetSumWays(int[] nums, int target)
        {
            int sum = 0;
            foreach (int num in nums)
            {
                sum += num;
            }
            int diff = sum - target;
            if (diff < 0 || diff % 2 != 0)
            {
                return 0;
            }
            int n = nums.Length, neg = diff / 2;
            int[,] dp = new int[n + 1, neg + 1];
            dp[0, 0] = 1;
            for (int i = 1; i <= n; i++)
            {
                int num = nums[i - 1];
                for (int j = 0; j <= neg; j++)
                {
                    dp[i, j] = dp[i - 1, j];
                    if (j >= num)
                    {
                        dp[i, j] += dp[i - 1, j - num];
                    }
                }
            }
            return dp[n, neg];
        }

        
    }
    // @lc code=end


}
