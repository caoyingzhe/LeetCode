using System;
namespace CSharpConsoleApp.Solutions
{
    /*
 * @lc app=leetcode.cn id=516 lang=csharp
 *
 * [516] 最长回文子序列
 *
 * https://leetcode-cn.com/problems/longest-palindromic-subsequence/description/
 *
 * Category	Difficulty	Likes	Dislikes
 * algorithms	Medium (61.82%)	464	-
 * Tags
 * dynamic-programming
 * 
 * Companies
 * amazon | uber
 * 
 * Total Accepted:    52.6K
 * Total Submissions: 85K
 * Testcase Example:  '"bbbab"'
 *
 * 给定一个字符串 s ，找到其中最长的回文子序列，并返回该序列的长度。可以假设 s 的最大长度为 1000 。
 * 
 * 
 * 示例 1:
 * 输入: "bbbab"
 * 输出: 4
 * 
 * 一个可能的最长回文子序列为 "bbbb"。
 * 
 * 示例 2:
 * 输入:"cbbd"
 * 输出:2
 * 
 * 一个可能的最长回文子序列为 "bb"。
 *
 * 
 * 提示：
 * 1 <= s.length <= 1000
 * s 只包含小写英文字母
 */

    // @lc code=start
    public class Solution516 : SolutionBase
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
        public override Tag[] GetTags() { return new Tag[] { Tag.DynamicProgramming}; }

        public const int NULL = int.MinValue;
        /// <summary>
        /// </summary>
        /// <param name="sw"></param>
        /// <returns></returns>
        public override bool Test(System.Diagnostics.Stopwatch sw)
        {
            bool isSuccess = true;
            string root;
            int result, checkResult;

            root = "bbbab";
            checkResult = 4;
            result = LongestPalindromeSubseq(root);
            isSuccess &= IsSame(result, checkResult);
            PrintResult(isSuccess, (result), (checkResult));

            root = "cbbd";
            checkResult = 2;
            result = LongestPalindromeSubseq(root);
            isSuccess &= IsSame(result, checkResult);
            PrintResult(isSuccess, (result), (checkResult));

            return isSuccess;
        }

        //作者：a380922457
        //链接：https://leetcode-cn.com/problems/longest-palindromic-subsequence/solution/dong-tai-gui-hua-si-yao-su-by-a380922457-3/

        /// <summary>
        /// 86/86 cases passed (116 ms)
        /// Your runtime beats 100 % of csharp submissions
        /// Your memory usage beats 13.33 % of csharp submissions(46.7 MB)
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public int LongestPalindromeSubseq(string s)
        {
            int n = s.Length;
            int[][] f = new int[n][];
            for (int i = n - 1; i >= 0; i--)
                f[i] = new int[n];
            for (int i = n - 1; i >= 0; i--)
            {
                f[i][i] = 1;
                for (int j = i + 1; j < n; j++)
                {
                    if (s[i] == s[j])
                    {
                        //如果 s 的第 i 个字符和第 j 个字符相同的话
                        f[i][j] = f[i + 1][j - 1] + 2;
                    }
                    else
                    {
                        //如果 s 的第 i 个字符和第 j 个字符不同的话
                        f[i][j] = Math.Max(f[i + 1][j], f[i][j - 1]);
                    }
                }
            }
            return f[0][n - 1];
        }
    }
    // @lc code=end


}
