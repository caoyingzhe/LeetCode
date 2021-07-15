using System;
using System.Collections.Generic;
namespace CSharpConsoleApp.Solutions
{
    /*
     * @lc app=leetcode.cn id=97 lang=csharp
     *
     * [97] 交错字符串
     *
     * https://leetcode-cn.com/problems/interleaving-string/description/
     *
     * Category	Difficulty	Likes	Dislikes
     * algorithms	Medium (45.77%)	483	-
     * Tags
     * string | dynamic-programming
     * 
     * Companies
     * Unknown
     * 
     * Total Accepted:    51.9K
     * Total Submissions: 113.4K
     * Testcase Example:  '"aabcc"\n"dbbca"\n"aadbbcbcac"'
     *
     * 给定三个字符串 s1、s2、s3，请你帮忙验证 s3 是否是由 s1 和 s2 交错 组成的。
     * 两个字符串 s 和 t 交错 的定义与过程如下，其中每个字符串都会被分割成若干 非空 子字符串：
     * 
     * s = s1 + s2 + ... + sn
     * t = t1 + t2 + ... + tm
     * |n - m| 
     * 交错 是 s1 + t1 + s2 + t2 + s3 + t3 + ... 或者 t1 + s1 + t2 + s2 + t3 + s3 +
     * ...
     * 
     * 
     * 提示：a + b 意味着字符串 a 和 b 连接。
     * 
     * 
     * 示例 1：
     * 输入：s1 = "aabcc", s2 = "dbbca", s3 = "aadbbcbcac"
     * 输出：true
     * 
     * 
     * 示例 2：
     * 输入：s1 = "aabcc", s2 = "dbbca", s3 = "aadbbbaccc"
     * 输出：false
     * 
     * 
     * 示例 3：
     * 输入：s1 = "", s2 = "", s3 = ""
     * 输出：true
     * 
     * 
     * 提示：
     * 0 
     * 0 
     * s1、s2、和 s3 都由小写英文字母组成
     */

    // @lc code=start
    public class Solution97 : SolutionBase
    {
        /// <summary>
        /// 难易度:
        /// </summary>
        public override Difficulity GetDifficulity() { return Difficulity.Medium; }
        /// <summary>
        /// 关键字:
        /// </summary>
        public override string[] GetKeyWords() { return new string[] {  }; }
        /// <summary>
        /// 标签：
        /// </summary>
        public override Tag[] GetTags() { return new Tag[] { Tag.String, Tag.DynamicProgramming }; }

        /// <summary>
        /// 195/195 cases passed (104 ms)
        /// Your runtime beats 89.9 % of csharp submissions
        /// Your memory usage beats 95.45 % of csharp submissions(24.5 MB)
        /// </summary>
        /// <param name="sw"></param>
        /// <returns></returns>
        public override bool Test(System.Diagnostics.Stopwatch sw)
        {
            bool isSuccess = true;
            string s1, s2, s3;
            bool result, checkResult;

            s1 = "aabcc"; s2= "dbbca"; s3 = "aadbbcbcac";
            checkResult = true;
            result = IsInterleave(s1, s2, s3);
            isSuccess &= IsSame(result, checkResult);
            Print("isSuccess = {0} result = {1} | checkResult = {2}", isSuccess, (result), (checkResult));

            s1 = "aabcc"; s2 = "dbbca"; s3 = "aadbbbaccc";
            checkResult = false;
            result = IsInterleave(s1, s2, s3);
            isSuccess &= IsSame(result, checkResult);
            Print("isSuccess = {0} result = {1} | checkResult = {2}", isSuccess, (result), (checkResult));

            s1 = ""; s2 = ""; s3 = "";
            checkResult = true;
            result = IsInterleave(s1, s2, s3);
            isSuccess &= IsSame(result, checkResult);
            Print("isSuccess = {0} result = {1} | checkResult = {2}", isSuccess, (result), (checkResult));

            return isSuccess;
        }

        /// <summary>
        /// f(i,j) 表示 s1的前 i 个元素和 s2 的前 j 个元素是否能交错组成 s_3 的前 i+j 个元素。
        /// 动态方程
        ///     f(i,j) = [f(i−1,j) && s1(i−1)=s3(p)] or [f(i, j−1) && s2(j−1)= s3(p)]
        /// 边界条件：
        ///     f(0,0)=True。
        ///     
        /// 作者：LeetCode-Solution
        /// 链接：https://leetcode-cn.com/problems/interleaving-string/solution/jiao-cuo-zi-fu-chuan-by-leetcode-solution/
        ///
        /// 106/106 cases passed (80 ms)
        /// Your runtime beats 94.87 % of csharp submissions
        /// Your memory usage beats 41.03 % of csharp submissions(22.7 MB)
        /// </summary>
        /// <param name="s1"></param>
        /// <param name="s2"></param>
        /// <param name="s3"></param>
        /// <returns></returns>
        public bool IsInterleave(string s1, string s2, string s3)
        {
            int n = s1.Length, m = s2.Length, t = s3.Length;

            if (n + m != t)
            {
                return false;
            }

            bool[][] f = new bool[n + 1][];
            for (int i = 0; i <= n; ++i) f[i] = new bool[m + 1];

            f[0][0] = true;
            for (int i = 0; i <= n; ++i)
            {
                for (int j = 0; j <= m; ++j)
                {
                    int p = i + j - 1;
                    if (i > 0)
                    {
                        f[i][j] = f[i][j] || (f[i - 1][j] && s1[i - 1] == s3[p]);
                    }
                    if (j > 0)
                    {
                        f[i][j] = f[i][j] || (f[i][j - 1] && s2[j - 1] == s3[p]);
                    }
                }
            }

            return f[n][m];
        }
    }
    // @lc code=end


}
