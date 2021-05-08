using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpConsoleApp.Solutions
{
    /*
     * @lc app=leetcode.cn id=309 lang=csharp
     *
     * [309] 最佳买卖股票时机含冷冻期
     *
     * https://leetcode-cn.com/problems/best-time-to-buy-and-sell-stock-with-cooldown/description/
     *
     * algorithms
     * Medium (58.63%)
     * Likes:    762
     * Dislikes: 0
     * Total Accepted:    87.3K
     * Total Submissions: 148.8K
     * Testcase Example:  '[1,2,3,0,2]'
     *
     * 给定一个整数数组，其中第 i 个元素代表了第 i 天的股票价格 。​
     * 
     * 设计一个算法计算出最大利润。在满足以下约束条件下，你可以尽可能地完成更多的交易（多次买卖一支股票）:
     * 
     * 你不能同时参与多笔交易（你必须在再次购买前出售掉之前的股票）。
     * 卖出股票后，你无法在第二天买入股票 (即冷冻期为 1 天)。
     * 
     * 示例:
     * 输入: [1,2,3,0,2]
     * 输出: 3 
     * 解释: 对应的交易状态为: [买入, 卖出, 冷冻期, 买入, 卖出]
     * 
     */
    class Solution309 : SolutionBase
    {
        public override bool Test(Stopwatch sw)
        {
            Print("" + MaxProfit(new int[] { 7, 1, 5, 3, 6, 4 }));
            return true;
        }

        /// <summary>
        /// 动态规划
        /// Your runtime beats 91.43 % of csharp submissions
        /// Your memory usage beats 77.14 % of csharp submissions(24.5 MB)
        /// 前言：不要关注冷冻期
        /// https://leetcode-cn.com/problems/best-time-to-buy-and-sell-stock-with-cooldown/solution/fei-zhuang-tai-ji-de-dpjiang-jie-chao-ji-tong-su-y/
        /// </summary>
        /// <param name="prices"></param>
        /// <returns></returns>
        public int MaxProfit(int[] prices)
        {
            int n = prices.Length;
            if (n <= 1) return 0;

            int[,] dp = new int[n,3];
            //对于每一天i，都有可能是三种状态：

            //0.不持股且当天没卖出,定义其最大收益dp[i][0];  Ai
            dp[0,0] = 0;
            //1.持股,定义其最大收益dp[i][1]；               Bi
            dp[0,1] = -1 * prices[0];
            //2.不持股且当天卖出了，定义其最大收益dp[i][2]；Ci
            dp[0,2] = 0;

            for (int i = 1; i < n; i++)
            {
                //0.不持股且当天没卖出利润  A[i] = Max(A[i-1], C[i-1])
                dp[i,0] = Math.Max(dp[i - 1,0], dp[i - 1,2]);

                //1.持股的收益（即成本）    B[i] = Max(B[i-1], A[i-1] - prices[i])
                dp[i,1] = Math.Max(dp[i - 1,1], dp[i - 1,0] - prices[i]); //购买股票，成本极为负。

                //2.不持股且当天卖出的利润  C[i] = B[i-1] + prices[i]
                dp[i,2] = dp[i - 1,1] + prices[i];  //卖出股票 = 持股收益 + 卖出价格；
            }

            //比较不持股两种状态的利润，取最大值。
            return Math.Max(dp[n - 1,0], dp[n - 1,2]);
        }
    }
}
