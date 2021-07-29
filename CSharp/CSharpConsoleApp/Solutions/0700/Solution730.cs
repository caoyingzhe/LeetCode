using System;
namespace CSharpConsoleApp.Solutions
{
    /*
     * @lc app=leetcode.cn id=730 lang=csharp
     *
     * [730] 统计不同回文子序列
     *
     * https://leetcode-cn.com/problems/count-different-palindromic-subsequences/description/
     *
     * Category	Difficulty	Likes	Dislikes
     * algorithms	Hard (48.48%)	132	-
     * Tags
     * string | dynamic-programming
     * 
     * Companies
     * linkedin
     * 
     * Total Accepted:    3.6K
     * Total Submissions: 7.5K
     * Testcase Example:  '"bccb"'
     *
     * 给定一个字符串 S，找出 S 中不同的非空回文子序列个数，并返回该数字与 10^9 + 7 的模。
     * 通过从 S 中删除 0 个或多个字符来获得子序列。
     * 如果一个字符序列与它反转后的字符序列一致，那么它是回文字符序列。
     * 如果对于某个  i，A_i != B_i，那么 A_1, A_2, ... 和 B_1, B_2, ... 这两个字符序列是不同的。
     * 
     * 
     * 示例 1：
     * 输入：
     * S = 'bccb'
     * 输出：6
     * 解释：
     * 6 个不同的非空回文子字符序列分别为：'b', 'c', 'bb', 'cc', 'bcb', 'bccb'。
     * 注意：'bcb' 虽然出现两次但仅计数一次。
     * 
     * 
     * 示例 2：
     * 输入：
     * S = 'abcdabcdabcdabcdabcdabcdabcdabcddcbadcbadcbadcbadcbadcbadcbadcba'
     * 输出：104860361
     * 解释：
     * 共有 3104860382 个不同的非空回文子序列，对 10^9 + 7 取模为 104860361。
     * 
     * 
     * 提示：
     * 字符串 S 的长度将在[1, 1000]范围内。
     * 每个字符 S[i] 将会是集合 {'a', 'b', 'c', 'd'} 中的某一个。
     */

    // @lc code=start
    public class Solution730 : SolutionBase
    {
        /// <summary>
        /// 难度
        /// </summary>
        public override Difficulity GetDifficulity() { return Difficulity.Medium; }
        /// <summary>
        /// 关键字:
        /// </summary>
        public override string[] GetKeyWords() { return new string[] { "复杂度N^2", "三维动态方程" }; }
        /// <summary>
        /// 标签：
        /// </summary>
        public override Tag[] GetTags() { return new Tag[] { Tag.DepthFirstSearch }; }

        public override bool Test(System.Diagnostics.Stopwatch sw)
        {
            bool isSuccess = true;
            string matchsticks;
            int result, checkResult;

            matchsticks = "bccb";
            checkResult = 6;
            result = CountPalindromicSubsequences(matchsticks);
            isSuccess &= IsSame(result, checkResult);
            PrintResult(isSuccess, result, checkResult);

            matchsticks = "abcdabcdabcdabcdabcdabcdabcdabcddcbadcbadcbadcbadcbadcbadcbadcba";
            checkResult = 104860361;
            result = CountPalindromicSubsequences(matchsticks);
            isSuccess &= IsSame(result, checkResult);
            PrintResult(isSuccess, result, checkResult);

            return isSuccess;
        }

        int[][] memo, prv, nxt;
        byte[] A;
        int MOD = 1_000_000_007;

        /// <summary>
        /// 367/367 cases passed (104 ms)
        /// Your runtime beats 100 % of csharp submissions
        /// Your memory usage beats 100 % of csharp submissions(46.9 MB)
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public int CountPalindromicSubsequences(string s)
        {
            int n = s.Length;
            prv = new int[n][];
            nxt = new int[n][];
            memo = new int[n][];
            for (int i = 0; i < n; i++)
            {
                prv[i] = new int[] { -1, -1, -1, -1 };
                nxt[i] = new int[] { -1, -1, -1, -1 };
                memo[i] = new int[n];
            }

            A = new byte[n];
            int ix = 0;
            foreach (char c in s.ToCharArray())
            {
                A[ix++] = (byte)(c - 'a');
            }

            int[] last = new int[4] { -1, -1, -1, -1 };
            for (int i = 0; i < n; ++i)
            {
                last[A[i]] = i;
                for (int k = 0; k < 4; ++k)
                    prv[i][k] = last[k];
            }

            last = new int[4] { -1, -1, -1, -1 };
            for (int i = n - 1; i >= 0; --i)
            {
                last[A[i]] = i;
                for (int k = 0; k < 4; ++k)
                    nxt[i][k] = last[k];
            }

            return dp(0, n - 1) - 1;
        }

        //作者：LeetCode
        //链接：https://leetcode-cn.com/problems/count-different-palindromic-subsequences/solution/tong-ji-bu-tong-hui-wen-zi-zi-fu-chuan-by-leetcode/
        public int dp(int i, int j)
        {
            if (memo[i][j] > 0) return memo[i][j];
            int ans = 1;
            if (i <= j)
            {
                for (int k = 0; k < 4; ++k)
                {
                    int i0 = nxt[i][k];
                    int j0 = prv[j][k];
                    if (i <= i0 && i0 <= j) ans++;
                    if (-1 < i0 && i0 < j0) ans += dp(i0 + 1, j0 - 1);
                    if (ans >= MOD) ans -= MOD;
                }
            }
            memo[i][j] = ans;
            return ans;
        }
    }
    // @lc code=end


}
