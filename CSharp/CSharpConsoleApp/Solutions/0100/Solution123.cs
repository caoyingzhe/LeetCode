﻿
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpConsoleApp.Solutions
{
    /*
     * @lc app=leetcode.cn id=123 lang=csharp
     *
     * [123] 买卖股票的最佳时机 III
     *
     * https://leetcode-cn.com/problems/best-time-to-buy-and-sell-stock-iii/description/
     *
     * algorithms
     * Hard (52.03%)
     * Likes:    757
     * Dislikes: 0
     * Total Accepted:    105.7K
     * Total Submissions: 203.1K
     * Testcase Example:  '[3,3,5,0,0,3,1,4]'
     *
     * 给定一个数组，它的第 i 个元素是一支给定的股票在第 i 天的价格。
     * 
     * 设计一个算法来计算你所能获取的最大利润。你最多可以完成 两笔 交易。
     *
     * 注意：你不能同时参与多笔交易（你必须在再次购买前出售掉之前的股票）。
     * 
     * 示例 1:
     * 输入：prices = [3,3,5,0,0,3,1,4]
     * 输出：6
     * 解释：在第 4 天（股票价格 = 0）的时候买入，在第 6 天（股票价格 = 3）的时候卖出，这笔交易所能获得利润 = 3-0 = 3 。
     * 随后，在第 7 天（股票价格 = 1）的时候买入，在第 8 天 （股票价格 = 4）的时候卖出，这笔交易所能获得利润 = 4-1 = 3 。
     * 
     * 示例 2：
     * 输入：prices = [1,2,3,4,5]
     * 输出：4
     * 解释：在第 1 天（股票价格 = 1）的时候买入，在第 5 天 （股票价格 = 5）的时候卖出, 这笔交易所能获得利润 = 5-1 = 4
     * 。   
     * 注意你不能在第 1 天和第 2 天接连购买股票，之后再将它们卖出。   
     * 因为这样属于同时参与了多笔交易，你必须在再次购买前出售掉之前的股票。
     * 
     * 示例 3：
     * 输入：prices = [7,6,4,3,1] 
     * 输出：0 
     * 解释：在这个情况下, 没有交易完成, 所以最大利润为 0。
     * 
     * 示例 4：
     * 输入：prices = [1]
     * 输出：0
     * 
     * 提示：
     * 1 <= prices.length <= 10^5
     * 0 <= prices[i] <= 10^5
     */

    class Solution123 : SolutionBase
    {
        public override bool Test(System.Diagnostics.Stopwatch sw)
        {
            Print("" + (MaxProfit(new int[] { 3, 3, 5, 0, 0, 3, 1, 4 }) == 6));
            Print("" + (MaxProfit(new int[] { 1, 2, 3, 4, 5 }) == 4));
            return true;
        }

        /// <summary>
        /// 官方答案
        /// 
        /// 动态规划
        /// Your runtime beats 93.22 % of csharp submissions
        /// Your memory usage beats 69.49 % of csharp submissions(43.8 MB
        /// 
        /// 另外这个链接有所有股票问题，也是全部简单明了
        /// https://leetcode-cn.com/problems/best-time-to-buy-and-sell-stock-iii/solution/zui-jian-dan-2-ge-bian-liang-jie-jue-suo-71fe/
        /// </summary>
        /// <param name="prices"></param>
        /// <returns></returns>
        public int MaxProfit(int[] prices)
        {
            int n = prices.Length;
            int buy1 = -prices[0], sell1 = 0;
            int buy2 = -prices[0], sell2 = 0;
            for (int i = 1; i < n; ++i)
            {
                /// 神了，循环中的4行代码简单明了.
                buy1 = Math.Max(buy1, -prices[i]);
                sell1 = Math.Max(sell1, buy1 + prices[i]);
                buy2 = Math.Max(buy2, sell1 - prices[i]);
                sell2 = Math.Max(sell2, buy2 + prices[i]);
            }
            return sell2;
        }
    }
}
