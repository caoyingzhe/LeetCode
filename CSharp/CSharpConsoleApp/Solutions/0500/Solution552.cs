using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpConsoleApp.Solutions._0500
{
    /*
     * @lc app=leetcode.cn id=552 lang=csharp
     *
     * [552] 学生出勤记录 II
     *
     * https://leetcode-cn.com/problems/student-attendance-record-ii/description/
     *
     * Category	Difficulty	Likes	Dislikes
     * algorithms	Hard (43.49%)	136	-
     * Tags
     * dynamic-programming
     * 
     * Companies
     * google
     * 
     * Total Accepted:    4.9K
     * Total Submissions: 11.2K
     * Testcase Example:  '2'
     *
     * 给定一个正整数 n，返回长度为 n 的所有可被视为可奖励的出勤记录的数量。 答案可能非常大，你只需返回结果mod 10^9 + 7的值。
     * 
     * 学生出勤记录是只包含以下三个字符的字符串：
     * 
     * 'A' : Absent，缺勤
     * 'L' : Late，迟到
     * 'P' : Present，到场
     * 
     * 如果记录不包含多于一个'A'（缺勤）或超过两个连续的'L'（迟到），则该记录被视为可奖励的。
     * 
     * 示例 1:
     * 输入: n = 2
     * 输出: 8 
     * 解释：
     * 有8个长度为2的记录将被视为可奖励：
     * "PP" , "AP", "PA", "LP", "PL", "AL", "LA", "LL"
     * 只有"AA"不会被视为可奖励，因为缺勤次数超过一次。
     * 
     * 示例 2:
     * 输入: n = 10101
     * 输出: 183236316
     * 
     * 注意：n 的值不会超过100000。
     * 
     */
    /// <summary>
    /// 中国剰余定理 和 1000000007
    /// https://qiita.com/drken/items/ae02240cd1f8edfc86fd
    /// https://qiita.com/drken/items/3b4fdf0a78e7a138cd9a
    /// https://www.geeksforgeeks.org/modulo-1097-1000000007/
    /// https://www.quora.com/What-is-the-concept-of-taking-modulo-by-1000000007
    /// </summary>
    class Solution552 : SolutionBase
    {
        /// <summary>
        /// 难度
        /// </summary>
        public override Difficulity GetDifficulity() { return Difficulity.Hard; }
        /// <summary>
        /// 关键字:
        /// </summary>
        public override string[] GetKeyWords() { return new string[] { "完全没理解的难题",  "中国剰余定理", "1000000007", "10^9+7" }; }
        /// <summary>
        /// 标签：
        /// </summary>
        public override Tag[] GetTags() { return new Tag[] { Tag.Tree, Tag.DepthFirstSearch }; }

        
        public override bool Test(System.Diagnostics.Stopwatch sw)
        {
            return false;
        }

        #region ------------------------- 常规解法 TLE -------------------------------------
        /// 链接：https://leetcode-cn.com/problems/student-attendance-record-ii/solution/xue-sheng-chu-qin-ji-lu-ii-by-leetcode/

        int M = 1000000007;
        public int CheckRecord_TLE(int n)
        {
            int[] f = new int[n + 1];
            f[0] = 1;
            for (int i = 1; i <= n; i++)
                f[i] = func(i);
            int sum = func(n);
            for (int i = 1; i <= n; i++)
            {
                sum += (f[i - 1] * f[n - i]) % M;
            }
            return sum % M;
        }
        public int func(int n)
        {
            if (n == 0)     
                return 1;
            if (n == 1)     
                return 2;
            if (n == 2)
                return 4;
            if (n == 3)
                return 7;
            return (2 * func(n - 1) - func(n - 4)) % M;
        }

        #endregion

        #region ------------------------- 使用动态规划 [Accepted]  -------------------------------------
        //long M = 1000000007;

        /// <summary>
        /// 59/59 cases passed (136 ms)
        /// Your runtime beats 100 % of csharp submissions
        /// Your memory usage beats 100 % of csharp submissions(29.3 MB)
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public int CheckRecord_DP(int n)
        {
            long[] f = new long[n <= 5 ? 6 : n + 1];
            f[0] = 1;
            f[1] = 2;
            f[2] = 4;
            f[3] = 7;
            for (int i = 4; i <= n; i++)
                f[i] = ((2 * f[i - 1]) % M + (M - f[i - 4])) % M;
            long sum = f[n];
            for (int i = 1; i <= n; i++)
            {
                sum += (f[i - 1] * f[n - i]) % M;
            }
            return (int)(sum % M);
        }
        #endregion

        #region ------------------------- 常数空间的动态规划 [Accepted] ------------------------
        //long M = 1000000007;

        /// <summary>
        /// 可怕的双100%
        /// 59/59 cases passed (88 ms)
        /// Your runtime beats 100 % of csharp submissions
        /// Your memory usage beats 100 % of csharp submissions(14.7 MB)
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public int CheckRecord(int n)
        {
            long a0l0 = 1;
            long a0l1 = 0, a0l2 = 0, a1l0 = 0, a1l1 = 0, a1l2 = 0;
            for (int i = 0; i < n; i++)
            {
                long new_a0l0 = (a0l0 + a0l1 + a0l2) % M;
                long new_a0l1 = a0l0;
                long new_a0l2 = a0l1;
                long new_a1l0 = (a0l0 + a0l1 + a0l2 + a1l0 + a1l1 + a1l2) % M;
                long new_a1l1 = a1l0;
                long new_a1l2 = a1l1;
                a0l0 = new_a0l0;
                a0l1 = new_a0l1;
                a0l2 = new_a0l2;
                a1l0 = new_a1l0;
                a1l1 = new_a1l1;
                a1l2 = new_a1l2;
            }
            return (int)((a0l0 + a0l1 + a0l2 + a1l0 + a1l1 + a1l2) % M);
        }
        #endregion
    }
}
