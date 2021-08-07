
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpConsoleApp.Solutions
{
    /*
     * @lc app=leetcode.cn id=279 lang=csharp
     *
     * [279] 完全平方数
     *
     * https://leetcode-cn.com/problems/perfect-squares/description/
     *
     * algorithms
     * Medium (60.25%)
     * Likes:    856
     * Dislikes: 0
     * Total Accepted:    132.5K
     * Total Submissions: 219.9K
     * Testcase Example:  '12'
     *
     * 给定正整数 n，找到若干个完全平方数（比如 1, 4, 9, 16, ...）使得它们的和等于 n。你需要让组成和的完全平方数的个数最少。
     * 
     * 给你一个整数 n ，返回和为 n 的完全平方数的 最少数量 。
     * 
     * 完全平方数 是一个整数，其值等于另一个整数的平方；换句话说，其值等于一个整数自乘的积。例如，1、4、9 和 16 都是完全平方数，而 3 和 11
     * 不是。
     * 
     * 示例 1：
     * 输入：n = 12
     * 输出：3 
     * 解释：12 = 4 + 4 + 4
     * 
     * 示例 2：
     * 输入：n = 13
     * 输出：2
     * 解释：13 = 4 + 9
     * 
     * 提示：1 <= n <= 10^4
     */
    class Solution279 : SolutionBase
    {
        /// <summary>
        /// 难度  官方说是 Medium，实际是题解都看不懂，比Hard更Hard。
        /// 官方有5种方法，最后竟然用数学推导降维打击，忽然感觉智商直接归0重置。
        /// </summary>
        public override Difficulity GetDifficulity() { return Difficulity.Hard; }
        /// <summary>
        /// 关键字:
        /// </summary>
        public override string[] GetKeyWords() { return new string[] { "难度信息错误" }; }
        /// <summary>
        /// 标签： 
        /// </summary>
        public override Tag[] GetTags() { return new Tag[] { Tag.Math, Tag.BreadthFirstSearch, Tag.DynamicProgramming }; }

        public override bool Test(System.Diagnostics.Stopwatch sw)
        {
            bool isSuccess = true;
            //isSuccess &= (NumSquares(12) == 3);

            sw.Start();
            isSuccess &= (NumSquares(10000 - 1) == 3);

            sw.Stop();
            Print("Eclipsed time = {0}", sw.ElapsedMilliseconds);
            return isSuccess;
        }

        /// <summary>
        /// 自己的处理，无法通过测试
        /// 
        /// Wrong Answer  312/588 cases passed(N/A)
        /// Test Case : 12   result = 3;  12 = 4 + 4 + 4
        /// 自己的结果 = 4;   12 = 9 + 1 + 1 + 1
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public int NumSquares_My(int n)
        {
            int count = 0;
            int left = n;

            while (left != 0)
            {
                int maxN = (int)Math.Sqrt(left);
                int pow = (maxN * maxN);
                int add = left / pow;
                left -= add * pow;
                count += add;
            }
            return count;
        }



        /// <summary>
        /// 方法二：动态规划
        /// Your runtime beats 51.46 % of csharp submissions
        /// Your memory usage beats 76.7 % of csharp submissions(16.4 MB)
        /// 
        /// 理解该方法首先需要理解该公式
        /// 一定存在某一k值，使得 dp[n] = dp[n - k] + 1;  k为某一个值的平方。
        /// 
        /// 举例说明 对于 dp[21]， 存在k值（1,4,9,16), 使得 dp[n] = dp[n-k] + 1;
        /// dp[21] 21 = 16 + 4 + 1;  dp[21] = 3;   
        /// dp[12] 12 = 4 + 4 + 4;   dp[12] = 3;   dp[21] !=  dp[12] + 1
        /// dp[17] 17 = 16 + 1;      dp[17] = 2;   dp[21]  =  dp[17] + 1
        /// dp[20] 20 = 16 + 4;      dp[20] = 2;   dp[21]  =  dp[20] + 1
        /// dp[5]  5  =  4 + 1;      dp[5] = 2;    dp[21]  =  dp[5] + 1
        /// 
        /// 参考打印信息（dp[21], dp[99])
        /// i = 21 s = 1| ======== dp[21] = 3 | Min( self, dp[21 - 1]+1 = dp[20]+1 = 2+1) 
        /// i = 21 s = 2| ======== dp[21] = 3 | Min( self, dp[21 - 4]+1 = dp[17]+1 = 2+1) 
        /// i = 21 s = 3| ======== dp[21] = 3 | Min( self, dp[21 - 9]+1 = dp[12]+1 = 3+1) 
        /// i = 21 s = 4| ======== dp[21] = 3 | Min( self, dp[21 - 16]+1 = dp[5]+1 = 2+1) 
        /// 
        /// i = 99 s = 1| ======== dp[99] = 3 | Min( self, dp[99 - 1]+1 = dp[98]+1 = 2+1) 
        /// i = 99 s = 2| ======== dp[99] = 3 | Min( self, dp[99 - 4]+1 = dp[95]+1 = 4+1) 
        /// i = 99 s = 3| ======== dp[99] = 3 | Min( self, dp[99 - 9]+1 = dp[90]+1 = 2+1) 
        /// i = 99 s = 4| ======== dp[99] = 3 | Min( self, dp[99 - 16]+1 = dp[83]+1 = 3+1) 
        /// i = 99 s = 5| ======== dp[99] = 3 | Min( self, dp[99 - 25]+1 = dp[74]+1 = 2+1) 
        /// i = 99 s = 6| ======== dp[99] = 3 | Min( self, dp[99 - 36]+1 = dp[63]+1 = 4+1) 
        /// i = 99 s = 7| ======== dp[99] = 3 | Min( self, dp[99 - 49]+1 = dp[50]+1 = 2+1) 
        /// i = 99 s = 8| ======== dp[99] = 3 | Min( self, dp[99 - 64]+1 = dp[35]+1 = 3+1) 
        /// i = 99 s = 9| ======== dp[99] = 3 | Min( self, dp[99 - 81]+1 = dp[18]+1 = 2+1)  
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public int NumSquares(int n)
        {
            int[] dp = new int[n + 1];
            //ArrayFill(dp, int.MaxValue);
            for (int i = 0; i < dp.Length; i++)
            {
                dp[i] = int.MaxValue;
            }
            // bottom case
            dp[0] = 0;

            // 与计算所有的开方根
            int max_square_index = (int)Math.Sqrt(n) + 1;
            int[] square_nums = new int[max_square_index];
            for (int i = 1; i < max_square_index; ++i)
            {
                square_nums[i] = i * i;
            }

            //动态规划
            for (int i = 1; i <= n; ++i)
            {
                for (int s = 1; s < max_square_index; ++s)
                {
                    if (i < square_nums[s])
                        break;

                    //Print("i = {0} s = {1} | dp[{0}] = {2} | Min(dp[{0}]: {2}, dp[{0} - (pow[{1}]={3})] + 1 ({4})", i, s, dp[i], square_nums[s], dp[i - square_nums[s]] + 1);
                    dp[i] = Math.Min(dp[i], dp[i - square_nums[s]] + 1); //dp[i - square_nums[s]]
                    //Print("i = {0} s = {1} | dp[{0}] = {2}", i, s, dp[i]);
                    //if(i==9999 || i == 99 || i == 21)
                    //    Print("i = {0} s = {1}| ======== dp[{0}] = {3} | Min( self, dp[{0} - {2}]+1 = dp[{4}]+1 = {5}+1) ", i, s, square_nums[s], dp[i], i - square_nums[s], dp[i - square_nums[s]]);

                }
            }
            return dp[n];
        }
    }
}
