using System;
using System.Collections.Generic;
namespace CSharpConsoleApp.Solutions
{
    /*
     * @lc app=leetcode.cn id=467 lang=csharp
     *
     * [467] 环绕字符串中唯一的子字符串
     *
     * https://leetcode-cn.com/problems/unique-substrings-in-wraparound-string/description/
     *
     * Category	Difficulty	Likes	Dislikes
     * algorithms	Medium (43.74%)	155	-
     * Tags
     * dynamic-programming
     * 
     * Companies
     * Unknown
     * 
     * Total Accepted:    8K
     * Total Submissions: 18.3K
     * Testcase Example:  '"a"'
     *
     * 把字符串 s 看作是“abcdefghijklmnopqrstuvwxyz”的无限环绕字符串，所以 s
     * 看起来是这样的："...zabcdefghijklmnopqrstuvwxyzabcdefghijklmnopqrstuvwxyzabcd....". 
     * 
     * 现在我们有了另一个字符串 p 。你需要的是找出 s 中有多少个唯一的 p 的非空子串，尤其是当你的输入是字符串 p ，你需要输出字符串 s 中 p
     * 的不同的非空子串的数目。 
     * 
     * 注意: p 仅由小写的英文字母组成，p 的大小可能超过 10000。
     *
     * 
     * 示例 1:
     * 输入: "a"
     * 输出: 1
     * 解释: 字符串 S 中只有一个"a"子字符。
     * 
     * 
     * 示例 2:
     * 输入: "cac"
     * 输出: 2
     * 解释: 字符串 S 中的字符串“cac”只有两个子串“a”、“c”。.
     * 
     * 
     * 示例 3:
     * 输入: "zab"
     * 输出: 6
     * 解释: 在字符串 S 中有六个子串“z”、“a”、“b”、“za”、“ab”、“zab”。.
     */

    // @lc code=start
    public class Solution467 : SolutionBase
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
        public override Tag[] GetTags() { return new Tag[] { Tag.DynamicProgramming, Tag.Minimax }; }

        public override bool Test(System.Diagnostics.Stopwatch sw)
        {
            bool isSuccess = true;
            //TODO
            return isSuccess;
        }

        /// <summary>
        /// 作者：da-li-wang
        /// 链接：https://leetcode-cn.com/problems/unique-substrings-in-wraparound-string/solution/c-yi-ci-bian-li-by-da-li-wang-6/
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        public int FindSubstringInWraproundString(string p)
        {
            int[] dp = new int[26];
            int N = p.Length;
            int k = 0;
            for (int i = 0; i < N; ++i)
            {
                if (i > 0 && IsContinous(p[i - 1], p[i]))
                {
                    ++k;
                }
                else
                {
                    k = 1;
                }
                dp[p[i] - 'a'] = Math.Max(dp[p[i] - 'a'], k);
            }

            // accumulate(dp.begin(), dp.end(), 0);
            int sum = 0;
            foreach(int num in dp)
            {
                sum += num;
            }
            return sum;
        }

        bool IsContinous(char prev, char curr)
        {
            if (prev == 'z') return curr == 'a';
            return prev + 1 == curr;
        }
    }
    // @lc code=end
}
