
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpConsoleApp.Solutions
{
    /*
     * @lc app=leetcode.cn id=122 lang=csharp
     *
     * [122] 买卖股票的最佳时机 II
     *
     * https://leetcode-cn.com/problems/best-time-to-buy-and-sell-stock-ii/description/
     *
     * algorithms
     * Easy (67.51%)
     * Likes:    1206
     * Dislikes: 0
     * Total Accepted:    356.9K
     * Total Submissions: 528.6K
     * Testcase Example:  '[7,1,5,3,6,4]'
     *
     * 给定一个数组 prices ，其中 prices[i] 是一支给定股票第 i 天的价格。
     * 
     * 设计一个算法来计算你所能获取的最大利润。你可以尽可能地完成更多的交易（多次买卖一支股票）。
     * 
     * 注意：你不能同时参与多笔交易（你必须在再次购买前出售掉之前的股票）。
     * 
     * 示例 1:
     * 输入: prices = [7,1,5,3,6,4]
     * 输出: 7
     * 解释: 在第 2 天（股票价格 = 1）的时候买入，在第 3 天（股票价格 = 5）的时候卖出, 这笔交易所能获得利润 = 5-1 = 4 。
     * 随后，在第 4 天（股票价格 = 3）的时候买入，在第 5 天（股票价格 = 6）的时候卖出, 这笔交易所能获得利润 = 6-3 = 3 。
     * 
     * 示例 2:
     * 输入: prices = [1,2,3,4,5]
     * 输出: 4
     * 解释: 在第 1 天（股票价格 = 1）的时候买入，在第 5 天 （股票价格 = 5）的时候卖出, 这笔交易所能获得利润 = 5-1 = 4
     * 注意你不能在第 1 天和第 2 天接连购买股票，之后再将它们卖出。因为这样属于同时参与了多笔交易，你必须在再次购买前出售掉之前的股票。
     * 
     * 示例 3:
     * 输入: prices = [7,6,4,3,1]
     * 输出: 0
     * 解释: 在这种情况下, 没有交易完成, 所以最大利润为 0。
     * 
     * 提示：
     * 1 <= prices.length <= 3 * 10^4
     * 0 <= prices[i] <= 10^4
     */

    class Solution122 : SolutionBase
    {
        public override bool Test(System.Diagnostics.Stopwatch sw)
        {
            Print("" + MaxProfit(new int[] { 7, 1, 5, 3, 6, 4 }));
            return true;
        }

        public int MaxProfit(int[] prices)
        {
            int fee = 0; //手续费 = 0

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
    }
}
