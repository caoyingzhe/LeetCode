
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpConsoleApp.Solutions
{
    /*
     * @lc app=leetcode.cn id=714 lang=csharp
     *
     * [714] 买卖股票的最佳时机含手续费
     *
     * https://leetcode-cn.com/problems/best-time-to-buy-and-sell-stock-with-transaction-fee/description/
     *
     * algorithms
     * Medium (70.48%)
     * Likes:    467
     * Dislikes: 0
     * Total Accepted:    76.1K
     * Total Submissions: 108K
     * Testcase Example:  '[1,3,2,8,4,9]\n2'
     *
     * 给定一个整数数组 prices，其中第 i 个元素代表了第 i 天的股票价格 ；非负整数 fee 代表了交易股票的手续费用。
     * 
     * 你可以无限次地完成交易，但是你每笔交易都需要付手续费。如果你已经购买了一个股票，在卖出它之前你就不能再继续购买股票了。
     * 
     * 返回获得利润的最大值。
     * 
     * 注意：这里的一笔交易指买入持有并卖出股票的整个过程，每笔交易你只需要为支付一次手续费。
     * 
     * 示例 1:
     * 输入: prices = [1, 3, 2, 8, 4, 9], fee = 2
     * 输出: 8
     * 解释: 能够达到的最大利润:  
     * 在此处买入 prices[0] = 1
     * 在此处卖出 prices[3] = 8
     * 在此处买入 prices[4] = 4
     * 在此处卖出 prices[5] = 9
     * 总利润: ((8 - 1) - 2) + ((9 - 4) - 2) = 8.
     * 
     * 注意:
     * 0 < prices.length <= 50000.
     * 0 < prices[i] < 50000.
     * 0 <= fee < 50000.
     */
    class Solution714 : SolutionBase
    {
        /// <summary>
        /// 难度
        /// </summary>
        public override Difficulity GetDifficulity() { return Difficulity.Medium; }
        /// <summary>
        /// 关键字:
        /// </summary>
        public override string[] GetKeyWords() { return new string[] { "股票" }; }
        /// <summary>
        /// 标签： 
        /// </summary>
        public override Tag[] GetTags() { return new Tag[] { Tag.Array, Tag.DynamicProgramming, Tag.Greedy }; }

        public override bool Test(System.Diagnostics.Stopwatch sw)
        {
            int[] prices;
            int fee;
            int checkResult;
            bool isSuccess = true;

            prices = new int[] { 1, 3, 2, 8, 4, 9 };
            fee = 2;
            checkResult = 8;
            isSuccess &= MaxProfit(prices, fee) == checkResult;

            prices = new int[] { };
            checkResult = 1;
            isSuccess &= MaxProfit(prices, fee) == checkResult;

            return isSuccess;
        }

        /// <summary>
        /// 动态规划法
        /// </summary>
        /// <param name="prices"></param>
        /// <param name="fee"></param>
        /// <returns></returns>
        public int MaxProfit_DP(int[] prices, int fee)
        {
            int n = prices.Length;

            // dp[i][0] 表示第 i 天交易完后，手里没有股票的最大利润
            // dp[i][1] 表示第 i 天交易完后，手里持有股票的最大利润（i 从 0 开始）。
            int[,] dp = new int[n, 2];
            dp[0, 0] = 0;           //第 0 天交易完后，不持有股票的最大利润
            dp[0, 1] = -prices[0];  //第 0 天交易完后，  持有股票的最大利润 （买入股票，利润为买入额的负值)
            for (int i = 1; i < n; ++i)
            {
                //收益最大化的转移方程
                dp[i, 0] = Math.Max(                                               //第 i   天交易完后，不持有股票的最大利润
                    dp[i - 1, 0],                                                  //第 i-1 天交易完后，不持有股票的最大利润
                    dp[i - 1, 1] + prices[i] - fee);                               //第 i-1 天持有股票，第i天卖出的最大利润

                dp[i, 1] = Math.Max(                                               //第 i   天交易完后，  持有股票的最大利润
                    dp[i - 1, 1],                                                  //第 i-1 天交易完后，  持有股票的最大利润
                    dp[i - 1, 0] - prices[i]);                                     //第 i-1 天不持有股票，第i天买入的最大利润
            }
            return dp[n - 1, 0]; //第 n 天交易完后，不持有股票的最大利润
        }

        /// <summary>
        /// 动态规划法优化 （该算法速度和空间使用都不佳）
        /// 
        /// Your runtime beats 9.76 % of csharp submissions
        /// Your memory usage beats 58.54 % of csharp submissions(43.2 MB)
        /// </summary>
        /// <param name="prices"></param>
        /// <param name="fee"></param>
        /// <returns></returns>
        public int MaxProfit_DP_Optimized(int[] prices, int fee)
        {
            int n = prices.Length;
            int sell = 0, buy = -prices[0];
            for (int i = 1; i < n; ++i)
            {
                sell = Math.Max(sell, buy + prices[i] - fee);
                buy = Math.Max(buy, sell - prices[i]);
            }
            return sell;
        }

        /// <summary>
        /// 贪心算法 （该算法速度和空间使用都不佳）
        /// Your runtime beats 24.39 % of csharp submissions
        //  Your memory usage beats 9.76 % of csharp submissions(43.5 MB)
        /// 当我们卖出一支股票时，我们就立即获得了以相同价格并且免除手续费买入一支股票的权利
        /// </summary>
        /// <param name="prices"></param>
        /// <param name="fee"></param>
        /// <returns></returns>
        public int MaxProfit_Greedy(int[] prices, int fee)
        {
            int n = prices.Length;
            int buy = prices[0] + fee; //买入成本 = 买入价格+手续费

            int profit = 0;
            for (int i = 1; i < n; ++i)
            {
                if (prices[i] + fee < buy) //当日买入成本 < 已经买入成本，即买亏了。 
                {
                    buy = prices[i] + fee;  //放弃之前购买，更改买入成本=>当日买入成本
                }
                else if (prices[i] > buy) //当日价格 > 已经买入成本，即可以卖掉了，
                {
                    profit += prices[i] - buy;   //更新利润 += 当日利润
                    buy = prices[i];             //更新买入成本 => 当日价格 （因为利润中已经包含了手续费成本）
                }
            }
            return profit;
        }


        /// <summary>
        /// 大佬算法 (未理解）
        /// </summary>
        /// <param name="prices"></param>
        /// <param name="fee"></param>
        /// <returns></returns>
        public int MaxProfit(int[] prices, int fee)
        {
            int len = prices.Length;
            if (len < 2)
            {
                return 0;
            }
            int res = 0, min = prices[0];
            for (int i = 1; i < len; i++)
            {
                if (prices[i] < min)
                {
                    //未发生买卖时找到第一个最小数，如果发生过买卖则比较当前价格和上次卖出时的价格减去手续费
                    min = prices[i];
                }
                else
                {
                    if (prices[i] - fee > min)
                    {
                        res += prices[i] - min - fee;
                        //当前的价格已经减过手续费，所以min的值应为当前价格减去手续费。
                        min = prices[i] - fee;
                    }
                }
            }
            return res;
        }

    }
}
