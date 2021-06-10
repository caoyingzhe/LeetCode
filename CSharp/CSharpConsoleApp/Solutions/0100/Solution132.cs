using System;
namespace CSharpConsoleApp.Solutions
{
    /*
     * @lc app=leetcode.cn id=132 lang=csharp
     *
     * [132] 分割回文串 II
     *
     * https://leetcode-cn.com/problems/palindrome-partitioning-ii/description/
     *
     * Category	Difficulty	Likes	Dislikes
     * algorithms	Hard (49.24%)	433	-
     * Tags
     * dynamic-programming
     * 
     * Companies
     * Unknown
     * 
     * Total Accepted:    45K
     * Total Submissions: 91.3K
     * Testcase Example:  '"aab"'
     *
     * 给你一个字符串 s，请你将 s 分割成一些子串，使每个子串都是回文。
     * 返回符合要求的 最少分割次数 。
     * 
     * 示例 1：
     * 输入：s = "aab"
     * 输出：1
     * 解释：只需一次分割就可将 s 分割成 ["aa","b"] 这样两个回文子串。
     * 
     * 
     * 示例 2：
     * 输入：s = "a"
     * 输出：0
     * 
     * 
     * 示例 3：
     * 输入：s = "ab"
     * 输出：1
     * 
     * 
     * 提示：
     * 1 <= s.length <= 2000
     * s 仅由小写英文字母组成
     */
    public class Solution132 : SolutionBase
    {
        /// <summary>
        /// 难度
        /// </summary>
        public override Difficulity GetDifficulity() { return Difficulity.Hard; }
        /// <summary>
        /// 关键字:
        /// </summary>
        public override string[] GetKeyWords() { return new string[] { "回文串" }; }
        /// <summary>
        /// 标签：
        /// </summary>
        public override Tag[] GetTags() { return new Tag[] { Tag.DynamicProgramming, }; }

        public override bool Test(System.Diagnostics.Stopwatch sw)
        {
            bool isSuccess = true;
            return isSuccess;
        }

        /// <summary>
        /// 33/33 cases passed (104 ms)
        /// Your runtime beats 63.43 % of csharp submissions
        /// Your memory usage beats 6.71 % of csharp submissions(29.3 MB)
        /// 作者：LeetCode - Solution
        /// 链接：https://leetcode-cn.com/problems/palindrome-partitioning-ii/solution/fen-ge-hui-wen-chuan-ii-by-leetcode-solu-norx/
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public int MinCut(string s)
        {
            int n = s.Length;

            //g[i][j]表示s[i..j]是否是绘文字串；
            bool[][] g = new bool[n][];
            for (int i = 0; i < n; ++i)
            {
                g[i] = new bool[n];
                for (int j = 0; j < n; ++j)
                    g[i][j] = true;
            }

            for (int i = n - 1; i >= 0; --i)
            {
                for (int j = i + 1; j < n; ++j)
                {
                    g[i][j] = s[i] == s[j] && g[i + 1][j - 1]; //s[i..j]是否为回文字串的动态规划方程；
                }
            }

            //f[i]表示字符串的前缀 s[0..i] 的最少分割次数
            int[] f = new int[n];
            for (int i = 0; i < n; ++i)
                f[i] = int.MaxValue;

            for (int i = 0; i < n; ++i)
            {
                if (g[0][i])
                {
                    f[i] = 0;
                }
                else
                {
                    for (int j = 0; j < i; ++j)
                    {
                        if (g[j + 1][i]) //s[j+1,i]是回文字串
                        {
                            //因为s[0,i] = s[0,j] + s[j+1,i]
                            //所以f[i]   = f[j]   + 1
                            //其中 +1代表 s[j+1,i]是回文字串，从s[0,i]中只需分离1次，无需在分割。
                            f[i] = Math.Min(f[i], f[j] + 1);
                        }
                    }
                }
            }
            return f[n - 1];
        }
    }
}
