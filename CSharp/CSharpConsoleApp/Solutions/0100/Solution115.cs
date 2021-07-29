using System;
namespace CSharpConsoleApp.Solutions
{

    /*
     * @lc app=leetcode.cn id=115 lang=csharp
     *
     * [115] 不同的子序列
     *
     * https://leetcode-cn.com/problems/distinct-subsequences/description/
     *
     * Category	Difficulty	Likes	Dislikes
     * algorithms	Hard (53.31%)	548	-
     * Tags
     * string | dynamic-programming
     * 
     * Companies
     * Unknown
     * 
     * Total Accepted:    53.8K
     * Total Submissions: 101K
     * Testcase Example:  '"rabbbit"\n"rabbit"'
     *
     * 给定一个字符串 s 和一个字符串 t ，计算在 s 的子序列中 t 出现的个数。
     * 
     * 字符串的一个 子序列 是指，通过删除一些（也可以不删除）字符且不干扰剩余字符相对位置所组成的新字符串。（例如，"ACE" 是 "ABCDE"
     * 的一个子序列，而 "AEC" 不是）
     * 
     * 题目数据保证答案符合 32 位带符号整数范围。
     * 
     * 
     * 示例 1：
     * 输入：s = "rabbbit", t = "rabbit"
     * 输出：3
     * 解释：
     * 如下图所示, 有 3 种可以从 s 中得到 "rabbit" 的方案。
     * (上箭头符号 ^ 表示选取的字母)
     * rabbbit
     * ^^^^ ^^
     * rabbbit
     * ^^ ^^^^
     * rabbbit
     * ^^^ ^^^
     * 
     * 
     * 示例 2：
     * 输入：s = "babgbag", t = "bag"
     * 输出：5
     * 解释：
     * 如下图所示, 有 5 种可以从 s 中得到 "bag" 的方案。 
     * (上箭头符号 ^ 表示选取的字母)
     * babgbag
     * ^^ ^
     * babgbag
     * ^^    ^
     * babgbag
     * ^    ^^
     * babgbag
     * ⁠ ^  ^^
     * babgbag
     * ⁠   ^^^
     * 
     * 提示：
     * 0 <= s.length, t.length <= 1000
     * s 和 t 由英文字母组成
     */

    // @lc code=start
    public class Solution115 : SolutionBase
    {
        /// <summary>
        /// 难度
        /// </summary>
        public override Difficulity GetDifficulity() { return Difficulity.Hard; }
        /// <summary>
        /// 关键字:
        /// </summary>
        public override string[] GetKeyWords() { return new string[] { "" }; }
        /// <summary>
        /// 标签：
        /// </summary>
        public override Tag[] GetTags() { return new Tag[] { Tag.String, Tag.DynamicProgramming }; }

        
        public override bool Test(System.Diagnostics.Stopwatch sw)
        {
            bool isSuccess = true;
            string s, t;
            int result, checkResult;

            s = "rabbbit"; t = "rabbit";
            checkResult = 3;
            result = NumDistinct(s, t);
            isSuccess &= IsSame(result, checkResult);
            PrintResult(isSuccess, result, checkResult);

            s = "babgbag"; t = "bag";
            checkResult = 5;
            result = NumDistinct(s, t);
            isSuccess &= IsSame(result, checkResult);
            PrintResult(isSuccess, result, checkResult);

            return isSuccess;
        }

        /// <summary>
        /// 作者：LeetCode-Solution
        /// 链接：https://leetcode-cn.com/problems/distinct-subsequences/solution/bu-tong-de-zi-xu-lie-by-leetcode-solutio-urw3/
        /// 63/63 cases passed (68 ms)
        /// Your runtime beats 100 % of csharp submissions
        /// Your memory usage beats 63.64 % of csharp submissions(25.7 MB)
        /// </summary>
        /// <param name="s"></param>
        /// <param name="t"></param>
        /// <returns></returns>
        public int NumDistinct(string s, string t)
        {
            int m = s.Length; int n = t.Length;
            if (m < n) return 0;

            //创建二维数组 dp
            //dp[i,j] 表示在 s[i:] 的子序列中 t[j:] 出现的个数
            //字符串 s 和 t 的长度分别为 m 和 n
            int[,] dp = new int[m + 1,n + 1];
            for (int i = 0; i <= m; i++)
            {
                dp[i,n] = 1;
            }

            for (int i = m - 1; i >= 0; i--)
            {
                for (int j = n - 1; j >= 0; j--)
                {
                    //动态方程
                    if (s[i] == t[j])
                    {
                        dp[i,j] = dp[i + 1,j + 1] + dp[i + 1,j];
                    }
                    else
                    {
                        dp[i,j] = dp[i + 1,j];
                    }
                }
            }
            return dp[0,0];
        }
    }
    // @lc code=end


}
