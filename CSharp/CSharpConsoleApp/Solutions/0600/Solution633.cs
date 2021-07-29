using System;
namespace CSharpConsoleApp.Solutions
{
    /*
     * @lc app=leetcode.cn id=633 lang=csharp
     *
     * [633] 平方数之和
     *
     * https://leetcode-cn.com/problems/sum-of-square-numbers/description/
     *
     * Category	Difficulty	Likes	Dislikes
     * algorithms	Medium (39.98%)	294	-
     * Tags
     * math
     * 
     * Companies
     * linkedin
     * 
     * Total Accepted:    88.9K
     * Total Submissions: 222.3K
     * Testcase Example:  '5'
     *
     * 给定一个非负整数 c ，你要判断是否存在两个整数 a 和 b，使得 a^2 + b^2 = c 。
     * 
     * 示例 1： 输入：c = 5 输出：true  解释：1 * 1 + 2 * 2 = 5
     * 示例 2： 输入：c = 3 输出：false
     * 示例 3： 输入：c = 4 输出：true
     * 示例 4： 输入：c = 2 输出：true
     * 示例 5： 输入：c = 1 输出：true
     * 
     * 提示：
     * 0 <= c <= 2^31 - 1
     */

    // @lc code=start
    public class Solution633 : SolutionBase
    {
        /// <summary>
        /// 难度
        /// </summary>
        public override Difficulity GetDifficulity() { return Difficulity.Medium; }
        /// <summary>
        /// 关键字:
        /// </summary>
        public override string[] GetKeyWords() { return new string[] { "掌握" }; }
        /// <summary>
        /// 标签：
        /// </summary>
        public override Tag[] GetTags() { return new Tag[] { Tag.Math }; }

        
        /// <summary>
        /// </summary>
        /// <param name="sw"></param>
        /// <returns></returns>
        public override bool Test(System.Diagnostics.Stopwatch sw)
        {
            bool isSuccess = true;

            int c;
            bool result, checkResult;

            c = 10;
            checkResult = true;
            result = JudgeSquareSum(c);
            isSuccess &= IsSame(result, checkResult);
            PrintResult(isSuccess, result, checkResult);

            return isSuccess;
        }

        /// <summary>
        /// 124/124 cases passed (40 ms)
        /// Your runtime beats 98.91 % of csharp submissions
        /// Your memory usage beats 17.98 % of csharp submissions(15 MB)
        /// </summary>
        /// <param name="c"></param>
        /// <returns></returns>
        public bool JudgeSquareSum(int c)
        {
            //a = sqrt(c - b^2);
            int max = (int)Math.Sqrt(c);
            for (int a = 0; a <= max; a++)
            {
                int b = (int)Math.Sqrt(c - a * a);
                if (a * a + b * b == c) return true;
            }
            return false;
        }
    }
    // @lc code=end


}
