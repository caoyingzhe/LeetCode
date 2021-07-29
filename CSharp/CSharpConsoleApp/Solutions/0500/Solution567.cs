using System;
namespace CSharpConsoleApp.Solutions
{
    /*
 * @lc app=leetcode.cn id=567 lang=csharp
 *
 * [567] 字符串的排列
 *
 * https://leetcode-cn.com/problems/permutation-in-string/description/
 *
 * Category	Difficulty	Likes	Dislikes
 * algorithms	Medium (42.42%)	369	-
 * Tags
 * two-pointers | sliding-window
 * 
 * Companies
 * microsoft
 * 
 * Total Accepted:    89.8K
 * Total Submissions: 211.7K
 * Testcase Example:  '"ab"\n"eidbaooo"'
 *
 * 给定两个字符串 s1 和 s2，写一个函数来判断 s2 是否包含 s1 的排列。
 * 换句话说，第一个字符串的排列之一是第二个字符串的 子串 。
 * 
 * 
 * 示例 1：
 * 输入: s1 = "ab" s2 = "eidbaooo"
 * 输出: True
 * 解释: s2 包含 s1 的排列之一 ("ba").
 * 
 * 
 * 示例 2：
 * 输入: s1= "ab" s2 = "eidboaoo"
 * 输出: False
 * 
 * 
 * 提示：
 * 输入的字符串只包含小写字母
 * 两个字符串的长度都在 [1, 10,000] 之间
 */

    // @lc code=start
    public class Solution567 : SolutionBase
    {
        /// <summary>
        /// 难度
        /// </summary>
        public override Difficulity GetDifficulity() { return Difficulity.Medium; }
        /// <summary>
        /// 关键字:
        /// </summary>
        public override string[] GetKeyWords() { return new string[] {"双指针变种" }; }
        /// <summary>
        /// 标签：
        /// </summary>
        public override Tag[] GetTags() { return new Tag[] { Tag.TwoPointers, Tag.SlidingWindow }; }

        public override bool Test(System.Diagnostics.Stopwatch sw)
        {
            bool isSuccess = true;
            string s1, s2;
            bool result, checkResult;

            s1 = "ab";  s2 = "eidbaooo";
            checkResult = true;
            result = CheckInclusion(s1, s2);
            isSuccess &= IsSame(result, checkResult);
            PrintResult(isSuccess, result, checkResult);

            s1 = "ab"; s2 = "eidboaoo";
            checkResult = false;
            result = CheckInclusion(s1, s2);
            isSuccess &= IsSame(result, checkResult);
            PrintResult(isSuccess, result, checkResult);

            return isSuccess;
        }

        /// <summary>
        /// 106/106 cases passed (76 ms)
        /// Your runtime beats 70.59 % of csharp submissions
        /// Your memory usage beats 88.24 % of csharp submissions(23.7 MB)
        /// </summary>
        /// <param name="s1"></param>
        /// <param name="s2"></param>
        /// <returns></returns>
        public bool CheckInclusion(string s1, string s2)
        {
            int n = s1.Length, m = s2.Length;
            if (n > m) return false;

            int[] cnt = new int[26];
            for (int i = 0; i < n; ++i)
            {
                cnt[s1[i] - 'a']--;
            }

            int L = 0;
            int R = 0;
            while (R < m)
            {
                int iR = s2[R] - 'a';
                cnt[iR]++;
                while (cnt[iR] > 0)
                {
                    //int iL = s2[L] - 'a'; cnt[iL]--;
                    cnt[s2[L] - 'a']--;
                    L++;
                }

                //此时 cnt[x] = 0；对应字母全部匹配
                if (R - L + 1 == n) return true;
                R++;
            }
            return false;
        }
    }
    // @lc code=end


}
