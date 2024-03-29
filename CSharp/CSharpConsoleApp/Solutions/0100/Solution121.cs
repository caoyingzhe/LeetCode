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
     * @lc app=leetcode.cn id=121 lang=csharp
     *
     * [121] 买卖股票的最佳时机
     *
     * https://leetcode-cn.com/problems/best-time-to-buy-and-sell-stock/description/
     *
     * algorithms
     * Easy (56.66%)
     * Likes:    1604
     * Dislikes: 0
     * Total Accepted:    436.6K
     * Total Submissions: 770.4K
     * Testcase Example:  '[7,1,5,3,6,4]'
     *
     * 给定一个数组 prices ，它的第 i 个元素 prices[i] 表示一支给定股票第 i 天的价格。
     * 你只能选择 某一天 买入这只股票，并选择在 未来的某一个不同的日子 卖出该股票。设计一个算法来计算你所能获取的最大利润。
     * 返回你可以从这笔交易中获取的最大利润。如果你不能获取任何利润，返回 0 。
     * 
     * 示例 1：
     * 输入：[7,1,5,3,6,4]
     * 输出：5
     * 解释：在第 2 天（股票价格 = 1）的时候买入，在第 5 天（股票价格 = 6）的时候卖出，最大利润 = 6-1 = 5 。
     * ⁠    注意利润不能是 7-1 = 6, 因为卖出价格需要大于买入价格；同时，你不能在买入前卖出股票。
     * 
     * 示例 2：
     * 输入：prices = [7,6,4,3,1]
     * 输出：0
     * 解释：在这种情况下, 没有交易完成, 所以最大利润为 0。
     * 
     * 提示：
     * 1 <= prices.length <= 10^5
     * 0 <= prices[i] <= 10^4
     */
    class Solution121 : SolutionBase
    {
        public override bool Test(System.Diagnostics.Stopwatch sw)
        {
            Print("" + MaxProfit(new int[] { 7, 1, 5, 3, 6, 4 }));
            return true;
        }
        
        public int MaxProfit(int[] prices)
        {
            int cost = prices[0];
            int profitMax = 0;
            for (int i = 1; i < prices.Length; i++)
            {
                if (prices[i] > cost) //有利可图卖出。
                {
                    //比较当前了利润和既有利润，取其大者。
                    profitMax = Math.Max(profitMax, prices[i] - cost); //当前利润 profit = prices[i] - cost;
                }
                else if (prices[i] < cost) //买亏了，重买
                {
                    cost = prices[i];
                }
            }
            return profitMax;
        }
    }
}
