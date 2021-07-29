using System;
using System.Collections.Generic;
namespace CSharpConsoleApp.Solutions
{
    /*
     * @lc app=leetcode.cn id=264 lang=csharp
     *
     * [264] 丑数 II
     * https://leetcode-cn.com/problems/ugly-number-ii/description/
     *
     * Category	Difficulty	Likes	Dislikes
     * algorithms	Medium (57.26%)	689	-
     * Tags
     * math | dynamic-programming | heap
     * 
     * Companies
     * Unknown
     * 
     * Total Accepted:    87.7K
     * Total Submissions: 153K
     * Testcase Example:  '10'
     *
     * 给你一个整数 n ，请你找出并返回第 n 个 丑数 。
     * 丑数 就是只包含质因数 2、3 和/或 5 的正整数。
     * 
     * 
     * 示例 1：
     * 输入：n = 10
     * 输出：12
     * 解释：[1, 2, 3, 4, 5, 6, 8, 9, 10, 12] 是由前 10 个丑数组成的序列。
     * 
     * 
     * 示例 2：
     * 输入：n = 1
     * 输出：1
     * 解释：1 通常被视为丑数。
     * 
     * 
     * 提示：
     * 1 <= n <= 1690
     */

    // @lc code=start
    public class Solution264 : SolutionBase
    {
        /// <summary>
        /// 难度
        /// </summary>
        public override Difficulity GetDifficulity() { return Difficulity.Medium; }
        /// <summary>
        /// 关键字:
        /// </summary>
        public override string[] GetKeyWords() { return new string[] { "丑数", }; }
        /// <summary>
        /// 标签：
        /// </summary>
        public override Tag[] GetTags() { return new Tag[] { Tag.DivideAndConquer }; }

        
        public override bool Test(System.Diagnostics.Stopwatch sw)
        {
            bool isSuccess = true;
            int n;
            int result, checkResult;

            n = 10;
            checkResult = 12;
            result = NthUglyNumber(n);
            isSuccess &= IsSame(result, checkResult);
            PrintResult(isSuccess, (result), (checkResult));

            return isSuccess;
        }

        //作者：LeetCode - Solution
        //链接：https://leetcode-cn.com/problems/ugly-number-ii/solution/chou-shu-ii-by-leetcode-solution-uoqd/

        /// <summary>
        /// 596/596 cases passed (32 ms)
        /// Your runtime beats 100 % of csharp submissions
        /// Your memory usage beats 66.67 % of csharp submissions(15.8 MB)
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public int NthUglyNumber(int n)
        {
            int[] dp = new int[n + 1];
            dp[1] = 1;

            int p2 = 1, p3 = 1, p5 = 1;
            for (int i = 2; i <= n; i++)
            {
                int num2 = dp[p2] * 2, num3 = dp[p3] * 3, num5 = dp[p5] * 5;
                dp[i] = Math.Min(Math.Min(num2, num3), num5);
                if (dp[i] == num2)
                {
                    p2++;
                }
                if (dp[i] == num3)
                {
                    p3++;
                }
                if (dp[i] == num5)
                {
                    p5++;
                }
            }
            return dp[n];
        }
    }
    // @lc code=end


}
