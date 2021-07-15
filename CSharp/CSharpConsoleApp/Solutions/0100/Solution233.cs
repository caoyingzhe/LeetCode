using System;
namespace CSharpConsoleApp.Solutions
{
    /*
     * @lc app=leetcode.cn id=233 lang=csharp
     *
     * [233] 数字 1 的个数
     *
     * https://leetcode-cn.com/problems/number-of-digit-one/description/
     *
     * Category	Difficulty	Likes	Dislikes
     * algorithms	Hard (40.63%)	228	-
     * Tags
     * math
     * 
     * Companies
     * Unknown
     * 
     * Total Accepted:    16.8K
     * Total Submissions: 41.4K
     * Testcase Example:  '13'
     *
     * 给定一个整数 n，计算所有小于等于 n 的非负整数中数字 1 出现的个数。
     *
     * 
     * 示例 1：
     * 输入：n = 13
     * 输出：6
     * 
     * 
     * 示例 2：
     * 输入：n = 0
     * 输出：0
     * 
     * 
     * 提示：
     * 0 <= n <= 2 * 109
     */

    // @lc code=start
    public class Solution233 : SolutionBase
    {
        /// <summary>
        /// 难度
        /// </summary>
        public override Difficulity GetDifficulity() { return Difficulity.Hard; }
        /// <summary>
        /// 关键字:
        /// </summary>
        public override string[] GetKeyWords() { return new string[] { "", }; }
        /// <summary>
        /// 标签：
        /// </summary>
        public override Tag[] GetTags() { return new Tag[] { Tag.Math }; }

        public int NULL = -1;
        public override bool Test(System.Diagnostics.Stopwatch sw)
        {
            bool isSuccess = true;
            int s;
            int result, checkResult;

            s = 13;
            checkResult = 6;
            result = CountDigitOne(s);
            isSuccess &= IsSame(result, checkResult);
            PrintResult(isSuccess, result, checkResult);

            s = 2;
            checkResult = 0;
            result = CountDigitOne(s);
            isSuccess &= IsSame(result, checkResult);
            PrintResult(isSuccess, result, checkResult);

            return isSuccess;
        }

        /// <summary>
        /// 作者：LeetCode
        /// 链接：https://leetcode-cn.com/problems/number-of-digit-one/solution/shu-zi-1-de-ge-shu-by-leetcode/
        /// 38/38 cases passed (32 ms)
        /// Your runtime beats 100 % of csharp submissions
        /// Your memory usage beats 85.71 % of csharp submissions(14.7 MB)
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public int CountDigitOne(int n)
        {
            long countr = 0;
            for (long i = 1; i <= n; i *= 10)
            {
                long divider = i * 10;
                countr += (n / divider) * i + Math.Min(Math.Max(n % divider - i + 1, 0L), i);
            }
            return (int) countr;
        }
    }
    // @lc code=end


}
