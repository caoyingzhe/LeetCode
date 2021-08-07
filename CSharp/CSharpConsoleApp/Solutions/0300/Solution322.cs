using System;
namespace CSharpConsoleApp.Solutions
{
    /*
     * @lc app=leetcode.cn id=322 lang=csharp
     *
     * [322] 零钱兑换
     *
     * https://leetcode-cn.com/problems/coin-change/description/
     *
     * Category	Difficulty	Likes	Dislikes
     * algorithms	Medium (43.88%)	1373	-
     * Tags
     * dynamic-programming
     * 
     * Companies
     * Unknown
     * 
     * Total Accepted:    259.8K
     * Total Submissions: 592.1K
     * Testcase Example:  '[1,2,5]\n11'
     *
     * 给你一个整数数组 coins ，表示不同面额的硬币；以及一个整数 amount ，表示总金额。
     * 计算并返回可以凑成总金额所需的 最少的硬币个数 。如果没有任何一种硬币组合能组成总金额，返回 -1 。
     * 你可以认为每种硬币的数量是无限的。
     * 
     * 
     * 示例 1：
     * 输入：coins = [1, 2, 5], amount = 11
     * 输出：3 
     * 解释：11 = 5 + 5 + 1
     *
     * 
     * 示例 2：
     * 输入：coins = [2], amount = 3
     * 输出：-1
     *
     * 
     * 示例 3：
     * 输入：coins = [1], amount = 0
     * 输出：0
     * 
     * 
     * 示例 4：
     * 输入：coins = [1], amount = 1
     * 输出：1
     * 
     * 
     * 示例 5：
     * 输入：coins = [1], amount = 2
     * 输出：2
     * 
     * 提示：
     * 1 <= coins.length <= 12
     * 1 <= coins[i] <= 231 - 1
     * 0 <= amount <= 104
     */

    // @lc code=start
    public class Solution322 : SolutionBase
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
        public override Tag[] GetTags() { return new Tag[] { Tag.Math, Tag.Brainteaser }; }


        public override bool Test(System.Diagnostics.Stopwatch sw)
        {
            bool isSuccess = true;

            int[] coins; int amount;
            int result, checkResult;

            coins = new int[] { 1, 2, 5 }; amount = 11;
            checkResult = 3;
            result = CoinChange(coins, amount);
            isSuccess &= IsSame(result, checkResult);
            PrintResult(isSuccess, (result), (checkResult));

            coins = new int[] { 2 }; amount = 3;
            checkResult = -1;
            result = CoinChange(coins, amount);
            isSuccess &= IsSame(result, checkResult);
            PrintResult(isSuccess, (result), (checkResult));

            coins = new int[] { 1 }; amount = 0;
            checkResult = 0;
            result = CoinChange(coins, amount);
            isSuccess &= IsSame(result, checkResult);
            PrintResult(isSuccess, (result), (checkResult));

            coins = new int[] { 1 }; amount = 1;
            checkResult = 1;
            result = CoinChange(coins, amount);
            isSuccess &= IsSame(result, checkResult);
            PrintResult(isSuccess, (result), (checkResult));

            coins = new int[] { 1 }; amount = 2;
            checkResult = 2;
            result = CoinChange(coins, amount);
            isSuccess &= IsSame(result, checkResult);
            PrintResult(isSuccess, (result), (checkResult));

            return isSuccess;
        }

        //https://leetcode-cn.com/problems/coin-change/solution/322-ling-qian-dui-huan-by-leetcode-solution/
        /// <summary>
        /// 188/188 cases passed (108 ms)
        /// Your runtime beats 99.41 % of csharp submissions
        /// Your memory usage beats 78.24 % of csharp submissions(27.4 MB)
        /// </summary>
        /// <param name="coins"></param>
        /// <param name="amount"></param>
        /// <returns></returns>
        public int CoinChange(int[] coins, int amount)
        {
            int max = amount + 1;
            int[] dp = new int[amount + 1];
            for (int i = 1; i <= amount; i++) dp[i] = max;

            dp[0] = 0;
            for (int i = 1; i <= amount; i++)
            {
                for (int j = 0; j < coins.Length; j++)
                {
                    if (coins[j] <= i) //TODO 此处意义不明白
                    {
                        dp[i] = Math.Min(dp[i], dp[i - coins[j]] + 1);
                    }
                }
            }
            return dp[amount] > amount ? -1 : dp[amount];
        }
    }
    // @lc code=end


}
