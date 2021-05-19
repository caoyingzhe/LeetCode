
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpConsoleApp.Solutions
{
    /*
     * @lc app=leetcode.cn id=188 lang=csharp
     *
     * [188] 买卖股票的最佳时机 IV
     *
     * https://leetcode-cn.com/problems/best-time-to-buy-and-sell-stock-iv/description/
     *
     * algorithms
     * Hard (37.35%)
     * Likes:    495
     * Dislikes: 0
     * Total Accepted:    69.8K
     * Total Submissions: 186.9K
     * Testcase Example:  '2\n[2,4,1]'
     *
     * 给定一个整数数组 prices ，它的第 i 个元素 prices[i] 是一支给定的股票在第 i 天的价格。
     * 
     * 设计一个算法来计算你所能获取的最大利润。你最多可以完成 k 笔交易。
     * 
     * 注意：你不能同时参与多笔交易（你必须在再次购买前出售掉之前的股票）。
     * 
     * 示例 1：
     * 输入：k = 2, prices = [2,4,1]
     * 输出：2
     * 解释：在第 1 天 (股票价格 = 2) 的时候买入，在第 2 天 (股票价格 = 4) 的时候卖出，这笔交易所能获得利润 = 4-2 = 2 。
     * 
     * 示例 2：
     * 输入：k = 2, prices = [3,2,6,5,0,3]
     * 输出：7
     * 
     * 解释：在第 2 天 (股票价格 = 2) 的时候买入，在第 3 天 (股票价格 = 6) 的时候卖出, 这笔交易所能获得利润 = 6-2 = 4 。
     * 随后，在第 5 天 (股票价格 = 0) 的时候买入，在第 6 天 (股票价格 = 3) 的时候卖出, 这笔交易所能获得利润 = 3-0 = 3 。
     * 
     * 提示：
     * 0 <= k <= 100
     * 0 <= prices.length <= 1000
     * 0 <= prices[i] <= 1000
     */

    class Solution188 : SolutionBase
    {
        public override bool Test(System.Diagnostics.Stopwatch sw)
        {
            Print("" + (MaxProfit(2, new int[] { 2, 4, 1 }) == 2));
            return true;
        }

        /// <summary>
        /// 动态规划
        /// 
        /// Solution123的简单扩展
        /// 
        /// 另外这个链接有所有股票问题，也是全部简单明了
        /// https://leetcode-cn.com/problems/best-time-to-buy-and-sell-stock-iii/solution/zui-jian-dan-2-ge-bian-liang-jie-jue-suo-71fe/
        /// </summary>
        /// <param name="k"></param>
        /// <param name="prices"></param>
        /// <returns></returns>
        public int MaxProfit(int k, int[] prices)
        {
            int n = prices.Length;

            List<int> buys = new List<int>();
            List<int> sells = new List<int>();
            for (int j = 0; j <= k; j++)
            {
                buys.Add(int.MinValue);
                sells.Add(0);
            }
            for(int m =0; m< n; m++)
            {
                int p = prices[m];
                for (int i = 1; i <= k; ++i)
                {
                    buys[i] = Math.Max(buys[i], sells[i - 1] - p);  // 卖了买
                    sells[i] = Math.Max(sells[i], buys[i] + p);     // 买了卖
                }
            }
            return sells[k];
        }
    }
}
