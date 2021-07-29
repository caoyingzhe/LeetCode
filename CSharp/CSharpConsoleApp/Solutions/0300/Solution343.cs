using System;
namespace CSharpConsoleApp.Solutions
{
    /*
     * @lc app=leetcode.cn id=343 lang=csharp
     *
     * [343] 整数拆分
     *
     * https://leetcode-cn.com/problems/integer-break/description/
     *
     * Category	Difficulty	Likes	Dislikes
     * algorithms	Medium (60.08%)	557	-
     * Tags
     * math | dynamic-programming
     * 
     * Companies
     * Unknown
     * 
     * Total Accepted:    94.8K
     * Total Submissions: 157.8K
     * Testcase Example:  '2'
     *
     * 给定一个正整数 n，将其拆分为至少两个正整数的和，并使这些整数的乘积最大化。 返回你可以获得的最大乘积。
     * 
     * 示例 1:
     * 输入: 2
     * 输出: 1
     * 解释: 2 = 1 + 1, 1 × 1 = 1。
     * 
     * 示例 2:
     * 输入: 10
     * 输出: 36
     * 解释: 10 = 3 + 3 + 4, 3 × 3 × 4 = 36。
     * 
     * 说明: 你可以假设 n 不小于 2 且不大于 58。
     * 
     */

    // @lc code=start
    public class Solution343 : SolutionBase
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
        public override Tag[] GetTags() { return new Tag[] { Tag.DynamicProgramming }; }

        
        public override bool Test(System.Diagnostics.Stopwatch sw)
        {
            bool isSuccess = true;

            int n;
            int result, checkResult;

            n = 10;
            checkResult = 36;
            result = IntegerBreak(n);
            isSuccess &= IsSame(result, checkResult);
            PrintResult(isSuccess, (result).ToString(), (checkResult).ToString());

            n = 2;
            checkResult = 1;
            result = IntegerBreak(n);
            isSuccess &= IsSame(result, checkResult);
            PrintResult(isSuccess, (result).ToString(), (checkResult).ToString());


            return isSuccess;
        }

        /// <summary>
        /// 50/50 cases passed (32 ms)
        ///Your runtime beats 100 % of csharp submissions
        ///Your memory usage beats 57.14 % of csharp submissions(14.8 MB)
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public int IntegerBreak(int n)
        {
            int[] dp = new int[n + 1];
            for (int i = 2; i <= n; i++) dp[i] = i;

            for(int i=2; i<=n; i++)
            {
                int curMax = 0;
                for (int j = 1; j < i; j++)
                {
                    //j * (i - j) 也需要比较，此处最为关键
                    curMax = Math.Max(curMax, Math.Max(j * (i - j), dp[i-j] * j));
                }
                dp[i] = curMax;
            }

            return dp[n];
        }
    }
    // @lc code=end


}
