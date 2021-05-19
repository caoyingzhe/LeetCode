using System;
using System.Collections.Generic;

namespace CSharpConsoleApp.Solutions
{
    /*
     * @lc app=leetcode.cn id=389 lang=csharp
     *
     * [389] 找不同
     *
     * https://leetcode-cn.com/problems/find-the-difference/description/
     *
     * Category	Difficulty	Likes	Dislikes
     * algorithms	Easy (69.42%)	250	-
     * Tags
     * hash-table | bit-manipulation
     * 
     * Companies
     * google
     * 
     * Total Accepted:    89K
     * Total Submissions: 128.1K
     * Testcase Example:  '"abcd"\n"abcde"'
     *
     * 给定两个字符串 s 和 t，它们只包含小写字母。
     * 
     * 字符串 t 由字符串 s 随机重排，然后在随机位置添加一个字母。
     * 
     * 请找出在 t 中被添加的字母。
     * 
     * 
     * 示例 1：
     * 输入：s = "abcd", t = "abcde"
     * 输出："e"
     * 解释：'e' 是那个被添加的字母。
     * 
     * 
     * 示例 2：
     * 输入：s = "", t = "y"
     * 输出："y"
     * 
     * 
     * 示例 3：
     * 输入：s = "a", t = "aa"
     * 输出："a"
     * 
     * 
     * 示例 4：
     * 输入：s = "ae", t = "aea"
     * 输出："a"
     * 
     * 
     * 提示：
     * 0 <= s.length <= 1000
     * t.length == s.length + 1
     * s 和 t 只包含小写字母
     * 
     */

    // @lc code=start
    public class Solution389 : SolutionBase
    {
        /// <summary>
        /// 难度
        /// </summary>
        public override Difficulity GetDifficulity() { return Difficulity.Easy; }
        /// <summary>
        /// 关键字:
        /// </summary>
        public override string[] GetKeyWords() { return new string[] { "无需看第二遍" }; }
        /// <summary>
        /// 标签： 
        /// </summary>
        public override Tag[] GetTags() { return new Tag[] { Tag.HashTable }; }

        public override bool Test(System.Diagnostics.Stopwatch sw)
        {
            bool isSuccess = true;

            char result = FindTheDifference("abcd","abcde");

            return isSuccess;
        }

        /// <summary>
        /// 54/54 cases passed (108 ms)
        /// Your runtime beats 92.42 % of csharp submissions
        /// Your memory usage beats 68.18 % of csharp submissions
        /// </summary>
        /// <param name="s"></param>
        /// <param name="t"></param>
        /// <returns></returns>
        public char FindTheDifference(string s, string t)
        {
            if (string.IsNullOrEmpty(s))
                return t[0];
            if (string.IsNullOrEmpty(t))
                return s[0];

            Dictionary<char, int> tDict = new Dictionary<char, int>();

            foreach (char c in t)
            {
                if (!tDict.ContainsKey(c))
                    tDict.Add(c, 1);
                else
                    tDict[c] += 1;
            }
            foreach (char c in s)
            {
                tDict[c]--;
            }

            foreach (char c in tDict.Keys)
            {
                if (tDict[c] != 0)
                    return c;
            }
            return ' ';
        }
    }
}
