using System;
namespace CSharpConsoleApp.Solutions
{
    /*
     * @lc app=leetcode.cn id=583 lang=csharp
     *
     * [583] 两个字符串的删除操作
     *
     * https://leetcode-cn.com/problems/delete-operation-for-two-strings/description/
     *
     * Category	Difficulty	Likes	Dislikes
     * algorithms	Medium (55.64%)	197	-
     * Tags
     * string
     * 
     * Companies
     * google
     * 
     * Total Accepted:    19.8K
     * Total Submissions: 35.5K
     * Testcase Example:  '"sea"\n"eat"'
     *
     * 给定两个单词 word1 和 word2，找到使得 word1 和 word2 相同所需的最小步数，每步可以删除任意一个字符串中的一个字符。
     * 
     * 
     * 
     * 示例：
     * 
     * 输入: "sea", "eat"
     * 输出: 2
     * 解释: 第一步将"sea"变为"ea"，第二步将"eat"变为"ea"
     * 
     * 
     * 提示：
     * 给定单词的长度不超过500。
     * 给定单词中的字符只含有小写字母。
     * 
     * 
     */
    public class Solution583 : SolutionBase
    {
        /// <summary>
        /// 难易度:
        /// </summary>
        public override Difficulity GetDifficulity() { return Difficulity.Medium; }
        /// <summary>
        /// 关键字:
        /// </summary>
        public override string[] GetKeyWords() { return new string[] { "最长非连续公共子序列", "动态编程" }; }
        /// <summary>
        /// 标签： 
        /// </summary>
        public override Tag[] GetTags() { return new Tag[] { Tag.DynamicProgramming, Tag.String }; }

        public override bool Test(System.Diagnostics.Stopwatch sw)
        {
            return false;
        }

        //作者：user4276
        //链接：https://leetcode-cn.com/problems/delete-operation-for-two-strings/solution/bao-jiao-bao-hui-shuang-bai-jie-fa-ke-mo-z8ps/
        /// <summary>
        /// 1306/1306 cases passed (100 ms)
        /// Your runtime beats 68.42 % of csharp submissions
        /// Your memory usage beats 42.1 % of csharp submissions(27.6 MB)
        /// </summary>
        /// <param name="word1"></param>
        /// <param name="word2"></param>
        /// <returns></returns>
        public int MinDistance(string word1, string word2)
        {
            int m = word1.Length, n = word2.Length;

            //dp[i,j]定义为字符串a第i位和字符串b第j位所匹配的最长非连续子序列长度
            int[,] dp = new int[m + 1,n + 1];

            for (int i = 1; i <= m; ++i) {
                for (int j = 1; j <= n; ++j) {
                    if (word1[i - 1] == word2[j - 1]) {
                        //相等时由dp[i - 1][j - 1]补上当前字符
                        dp[i,j] = dp[i - 1,j - 1] + 1;
                    } else {
                        //不等时舍弃words1[i - 1] 或words2[j - 1]，结果当然时取一个最大值
                        dp[i,j] = Math.Max(dp[i - 1,j], dp[i,j - 1]);
                    }
                }
            }
            return m + n - 2 * dp[m,n];
        }
    }
}
