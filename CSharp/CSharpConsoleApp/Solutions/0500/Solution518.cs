using System;
namespace CSharpConsoleApp.Solutions
{
    /*
     * @lc app=leetcode.cn id=518 lang=csharp
     *
     * [518] 零钱兑换 II
     *
     * https://leetcode-cn.com/problems/coin-change-2/description/
     *
     * Category	Difficulty	Likes	Dislikes
     * algorithms	Medium (64.14%)	567	-
     * Tags
     * Unknown
     * 
     * Companies
     * Unknown
     * 
     * Total Accepted:    92K
     * Total Submissions: 142.8K
     * Testcase Example:  '5\n[1,2,5]'
     *
     * 给你一个整数数组 coins 表示不同面额的硬币，另给一个整数 amount 表示总金额。
     * 请你计算并返回可以凑成总金额的硬币组合数。如果任何硬币组合都无法凑出总金额，返回 0 。
     * 假设每一种面额的硬币有无限个。 
     * 题目数据保证结果符合 32 位带符号整数。
     * 
     * 
     * 示例 1：
     * 输入：amount = 5, coins = [1, 2, 5]
     * 输出：4
     * 解释：有四种方式可以凑成总金额：
     * 5=5
     * 5=2+2+1
     * 5=2+1+1+1
     * 5=1+1+1+1+1
     * 
     * 
     * 示例 2：
     * 输入：amount = 3, coins = [2]
     * 输出：0
     * 解释：只用面额 2 的硬币不能凑成总金额 3 。
     * 
     * 
     * 示例 3：
     * 输入：amount = 10, coins = [10] 
     * 输出：1
     * 
     * 
     * 提示：
     * 1 <= coins.length <= 300
     * 1 <= coins[i] <= 5000
     * coins 中的所有值 互不相同
     * 0 <= amount <= 5000
     */

    // @lc code=start
    public class Solution518 : SolutionBase
    {
        /// <summary>
        /// 难度
        /// </summary>
        public override Difficulity GetDifficulity() { return Difficulity.Medium; }
        /// <summary>
        /// 关键字:
        /// </summary>
        public override string[] GetKeyWords() { return new string[] { "抄作业" }; }
        /// <summary>
        /// 标签：
        /// </summary>
        public override Tag[] GetTags() { return new Tag[] { Tag.DynamicProgramming }; }

        /// <summary>
        /// </summary>
        /// <param name="sw"></param>
        /// <returns></returns>
        public override bool Test(System.Diagnostics.Stopwatch sw)
        {
            bool isSuccess = true;

            int amount; int[] coins;
            int result, checkResult;

            coins = new int[] { 1, 2, 5 }; amount = 5; checkResult = 4;
            result = Change(amount, coins);
            isSuccess &= IsSame(result, checkResult);
            PrintResult(isSuccess, (result), (checkResult));

            return isSuccess;
        }

        //作者：LeetCode - Solution
        //链接：https://leetcode-cn.com/problems/coin-change-2/solution/ling-qian-dui-huan-ii-by-leetcode-soluti-f7uh/

        /// <summary>
        /// 28/28 cases passed (80 ms)
        /// Your runtime beats 100 % of csharp submissions
        /// Your memory usage beats 85.12 % of csharp submissions(23.8 MB)
        /// </summary>
        /// <param name="amount"></param>
        /// <param name="coins"></param>
        /// <returns></returns>
        public int Change(int amount, int[] coins)
        {
            //初始化 dp[0] = 1 最关键
            int[] dp = new int[amount + 1];
            dp[0] = 1;

            foreach (int coin in coins)
            {
                for (int i = coin; i <= amount; i++)
                {
                    dp[i] += dp[i - coin];
                }
            }
            return dp[amount];
        }
    }
    // @lc code=end


}
