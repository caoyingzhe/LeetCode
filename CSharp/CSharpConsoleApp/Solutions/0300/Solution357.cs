using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpConsoleApp.Solutions._0300
{
    /*
     * @lc app=leetcode.cn id=357 lang=csharp
     *
     * [357] 计算各个位数不同的数字个数
     *
     * https://leetcode-cn.com/problems/count-numbers-with-unique-digits/description/
     *
     * Category	Difficulty	Likes	Dislikes
     * algorithms	Medium (51.46%)	133	-
     * Tags
     * math | dynamic-programming | backtracking
     * 
     * Companies
     * google
     * Total Accepted:    21.6K
     * Total Submissions: 41.8K
     * Testcase Example:  '2'
     *
     * 给定一个非负整数 n，计算各位数字都不同的数字 x 的个数，其中 0 ≤ x < 10^n 。
     * 
     * 示例:
     * 输入: 2
     * 输出: 91 
     * 解释: 答案应为除去 11,22,33,44,55,66,77,88,99 外，在 [0,100) 区间内的所有数字。
     * 
     * 
     */
    class Solution357 : SolutionBase
    {
        /// <summary>
        /// 难度
        /// </summary>
        public override Difficulity GetDifficulity() { return Difficulity.Medium; }
        /// <summary>
        /// 关键字:
        /// </summary>
        public override string[] GetKeyWords() { return new string[] { "纯粹公式推导问题" }; }
        /// <summary>
        /// 标签：
        /// </summary>
        public override Tag[] GetTags() { return new Tag[] { Tag.Math, Tag.DynamicProgramming, Tag.Backtracking }; }

        public override bool Test(System.Diagnostics.Stopwatch sw)
        {
            return false;
        }

        /// <summary>
        /// 纯粹公式推导问题
        /// 9/9 cases passed (44 ms)
        /// Your runtime beats 100 % of csharp submissions
        /// Your memory usage beats 17.65 % of csharp submissions(15.1 MB)
        /// 
        /// 作者：ffreturn
        /// 链接：https://leetcode-cn.com/problems/count-numbers-with-unique-digits/solution/cchao-100de-dong-tai-gui-hua-by-ffreturn-hbzt/
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public int CountNumbersWithUniqueDigits(int n)
        {
            int[] d = new int[n + 1];
            for (int i = 0; i < n + 1; i++) d[i] = 0;

            for (int i = 2; i < n + 1; ++i)
            {
                d[i] = d[i - 1] * 10 + (9 * (int) (Math.Pow(10, i - 2)) - d[i - 1]) * (i - 1);
            }

            int sum = 0;
            for (int i = 0; i < n + 1; ++i)
            {
                sum += d[i];
            }
            return (int)Math.Pow(10, n) - sum;
        }
    }
}
