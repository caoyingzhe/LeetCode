using System;
using System.Collections.Generic;
namespace CSharpConsoleApp.Solutions
{
    /*
     * @lc app=leetcode.cn id=424 lang=csharp
     *
     * [424] 替换后的最长重复字符
     *
     * https://leetcode-cn.com/problems/longest-repeating-character-replacement/description/
     *
     * Category	Difficulty	Likes	Dislikes
     * algorithms	Medium (52.81%)	454	-
     * Tags
     * two-pointers | sliding-window
     * 
     * Companies
     * pocketgems
     * 
     * Total Accepted:    46.4K
     * Total Submissions: 87.8K
     * Testcase Example:  '"ABAB"\n2'
     *
     * 给你一个仅由大写英文字母组成的字符串，你可以将任意位置上的字符替换成另外的字符，总共可最多替换 k
     * 次。在执行上述操作后，找到包含重复字母的最长子串的长度。
     * 
     * 注意：字符串长度 和 k 不会超过 10^4。
     *
     * 
     * 示例 1：
     * 输入：s = "ABAB", k = 2
     * 输出：4
     * 解释：用两个'A'替换为两个'B',反之亦然。
     * 
     * 
     * 示例 2：
     * 输入：s = "AABABBA", k = 1
     * 输出：4
     * 解释：
     * 将中间的一个'A'替换为'B',字符串变为 "AABBBBA"。
     * 子串 "BBBB" 有最长重复字母, 答案为 4。
     */

    // @lc code=start
    public class Solution424 : SolutionBase
    {
        /// <summary>
        /// 难度
        /// </summary>
        public override Difficulity GetDifficulity() { return Difficulity.Medium; }
        /// <summary>
        /// 关键字:
        /// </summary>
        public override string[] GetKeyWords() { return new string[] { "" }; }
        /// <summary>
        /// 标签：
        /// </summary>
        public override Tag[] GetTags() { return new Tag[] { Tag.TwoPointers, Tag.SlidingWindow }; }

        public override bool Test(System.Diagnostics.Stopwatch sw)
        {
            bool isSuccess = true;
            string s; int k;

            int result, checkResult;

            s = "AABABBA"; k = 1;
            checkResult = 4;
            result = CharacterReplacement(s, k);
            isSuccess &= IsSame(result, checkResult);
            PrintResult(isSuccess, (result), (checkResult));

            return isSuccess;
        }


        /// <summary>
        /// 关键题意： 交换是可以将任意位置上的字符替换成另外的字符，字符串也任意。
        /// 时间复杂度：O(n)，其中 nn 是字符串的长度。
        /// 空间复杂度：O(∣Σ∣)，其中 ∣Σ∣ 是字符集的大小。
        ///
        /// 35/35 cases passed (80 ms)
        /// Your runtime beats 100 % of csharp submissions
        /// Your memory usage beats 70 % of csharp submissions(23.5 MB)
        /// </summary>
        /// <param name="s"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public int CharacterReplacement(string s, int k)
        {
            int[] num = new int[26];
            int n = s.Length;
            int maxn = 0;
            int left = 0, right = 0;
            while (right < n)
            {
                num[s[right] - 'A']++;
                maxn = Math.Max(maxn, num[s[right] - 'A']);

                //滑动窗口为K
                if (right - left + 1 - maxn > k)
                {
                    num[s[left] - 'A']--;
                    left++;
                }
                right++;
            }
            return right - left;

            // 作者：LeetCode-Solution
            // 链接：https://leetcode-cn.com/problems/longest-repeating-character-replacement/solution/ti-huan-hou-de-zui-chang-zhong-fu-zi-fu-n6aza/
        }
    }
    // @lc code=end


}
