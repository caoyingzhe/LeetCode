using System;
namespace CSharpConsoleApp.Solutions
{
     /*
     * @lc app=leetcode.cn id=87 lang=csharp
     *
     * [87] 扰乱字符串
     *
     * https://leetcode-cn.com/problems/scramble-string/description/
     *
     * Category	Difficulty	Likes	Dislikes
     * algorithms	Hard (49.18%)	381	-
     * Tags
     * string | dynamic-programming
     * 
     * Companies
     * Unknown
     * 
     * Total Accepted:    38.9K
     * Total Submissions: 79.1K
     * Testcase Example:  '"great"\n"rgeat"'
     *
     * 使用下面描述的算法可以扰乱字符串 s 得到字符串 t ：
     * 
     * 如果字符串的长度为 1 ，算法停止
     * 如果字符串的长度 > 1 ，执行下述步骤：
     * 
     * 在一个随机下标处将字符串分割成两个非空的子字符串。即，如果已知字符串 s ，则可以将其分成两个子字符串 x 和 y ，且满足 s = x + y。
     * 随机 决定是要「交换两个子字符串」还是要「保持这两个子字符串的顺序不变」。即，在执行这一步骤之后，s 可能是 s = x + y 或者 s = y + x 。
     * 在 x 和 y 这两个子字符串上继续从步骤 1 开始递归执行此算法。
     * 给你两个 长度相等 的字符串 s1 和 s2，判断 s2 是否是 s1 的扰乱字符串。如果是，返回 true ；否则，返回 false 。
     * 
     * 示例 1：
     * 输入：s1 = "great", s2 = "rgeat"
     * 输出：true
     * 解释：s1 上可能发生的一种情形是：
     * "great" --> "gr/eat" // 在一个随机下标处分割得到两个子字符串
     * "gr/eat" --> "gr/eat" // 随机决定：「保持这两个子字符串的顺序不变」
     * "gr/eat" --> "g/r / e/at" // 在子字符串上递归执行此算法。两个子字符串分别在随机下标处进行一轮分割
     * "g/r / e/at" --> "r/g / e/at" // 随机决定：第一组「交换两个子字符串」，第二组「保持这两个子字符串的顺序不变」
     * "r/g / e/at" --> "r/g / e/ a/t" // 继续递归执行此算法，将 "at" 分割得到 "a/t"
     * "r/g / e/ a/t" --> "r/g / e/ a/t" // 随机决定：「保持这两个子字符串的顺序不变」
     * 算法终止，结果字符串和 s2 相同，都是 "rgeat"
     * 这是一种能够扰乱 s1 得到 s2 的情形，可以认为 s2 是 s1 的扰乱字符串，返回 true
     * 
     * 示例 2：
     * 输入：s1 = "abcde", s2 = "caebd"
     * 输出：false
     * 
     * 示例 3：
     * 输入：s1 = "a", s2 = "a"
     * 输出：true
     *
     * 提示：
     * s1.length == s2.length
     * 1 <= s1.length <= 30
     * s1 和 s2 由小写英文字母组成
     */

    // @lc code=start
    public class Solution87 : SolutionBase
    {
        /// <summary>
        /// 难度
        /// </summary>
        public override Difficulity GetDifficulity() { return Difficulity.Hard; }
        /// <summary>
        /// 关键字:
        /// </summary>
        public override string[] GetKeyWords() { return new string[] { "扰乱字符串", "时间复杂度 O(n^4)" }; }
        /// <summary>
        /// 标签：
        /// </summary>
        public override Tag[] GetTags() { return new Tag[] { Tag.String, Tag.DynamicProgramming }; }

        public int NULL = -1;
        public override bool Test(System.Diagnostics.Stopwatch sw)
        {
            bool isSuccess = true;
            string s, t;
            bool result, checkResult;

            s = "great"; t = "rgeat";
            checkResult = true;
            result = IsScramble(s, t);
            isSuccess &= IsSame(result, checkResult);
            PrintResult(isSuccess, result, checkResult);

            s = "abcde"; t = "caebd";
            checkResult = false;
            result = IsScramble(s, t);
            isSuccess &= IsSame(result, checkResult);
            PrintResult(isSuccess, result, checkResult);

            return isSuccess;
        }

        /// <summary>
        /// TODO
        /// 官方解答
        /// 时间复杂度：O(n^4)，
        ///     其中 n 是给定的原始字符串的长度。动态规划中的状态 f(i1, i 2, length) 有 3 个维度，
        ///     对于每一个状态，我们需要 O(n) 枚举分割位置，因此总时间复杂度为 O(n^4)。
        /// 空间复杂度：O(n^3)，即为存储所有动态规划状态需要的空间
        ///
        /// 作者：kang-kang-49
        /// 链接：https://leetcode-cn.com/problems/scramble-string/solution/qu-jian-dp-by-kang-kang-49-n2t3/
        /// 288/288 cases passed (116 ms)
        /// Your runtime beats 59.79 % of csharp submissions
        /// Your memory usage beats 52.58 % of csharp submissions(24.1 MB)
        /// </summary>
        /// <param name="s1"></param>
        /// <param name="s2"></param>
        /// <returns></returns>
        public bool IsScramble(string s1, string s2)
        {
            if (s1.Length != s2.Length) return false;

            int n = s1.Length;
            bool[,,] dp = new bool[n, n, n];//[s1子串起点下标，s2子串起点下标，字串长度（0表示长度1）]

            //初始化DP
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    dp[i, j, 0] = s1[i] == s2[j];
                }
            }

            //DP处理 四重奏 (l < n, i < n - l, j < n - l, w < l + 1)
            //分别代表左右两侧的索引
            for (int l = 1; l < n; l++)
            {
                for (int i = 0; i < n - l; i++)
                {
                    for (int j = 0; j < n - l; j++)
                    {
                        for (int w = 1; w < l + 1; w++)
                        {
                            //使用 |= 运算符
                            dp[i, j, l] |= dp[i, j, w - 1] && dp[i + w, j + w, l - w];
                            dp[i, j, l] |= dp[i, j + l - w + 1, w - 1] && dp[i + w, j, l - w];

                            if (dp[i, j, l]) break;
                        }
                    }
                }
            }
            return dp[0, 0, n - 1];
        }
    }
    // @lc code=end


}
