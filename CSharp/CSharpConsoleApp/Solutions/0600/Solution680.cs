using System;
using System.Collections.Generic;
namespace CSharpConsoleApp.Solutions
{
    /*
     * @lc app=leetcode.cn id=680 lang=csharp
     *
     * [680] 验证回文字符串 Ⅱ
     *
     * https://leetcode-cn.com/problems/valid-palindrome-ii/description/
     *
     * Category	Difficulty	Likes	Dislikes
     * algorithms	Easy (40.15%)	381	-
     * Tags
     * string
     * 
     * Companies
     * facebook
     * 
     * Total Accepted:    82.2K
     * Total Submissions: 204.6K
     * Testcase Example:  '"aba"'
     *
     * 给定一个非空字符串 s，最多删除一个字符。判断是否能成为回文字符串。
     *
     * 
     * 示例 1:
     * 输入: s = "aba"
     * 输出: true
     *
     * 
     * 示例 2:
     * 输入: s = "abca"
     * 输出: true
     * 解释: 你可以删除c字符。
     * 
     * 
     * 示例 3:
     * 输入: s = "abc"
     * 输出: false
     *
     * 
     * 提示:
     * 1 <= s.length <= 10^5
     * s 由小写英文字母组成
     */
    public class Solution680 : SolutionBase
    {
        /// <summary>
        /// 难度
        /// </summary>
        public override Difficulity GetDifficulity() { return Difficulity.Easy; }
        /// <summary>
        /// 关键字:
        /// </summary>
        public override string[] GetKeyWords() { return new string[] { "抄作业", "回文字串"}; }
        /// <summary>
        /// 标签：
        /// </summary>
        public override Tag[] GetTags() { return new Tag[] { Tag.TwoPointers }; }

        /// <summary>
        /// </summary>
        /// <param name="sw"></param>
        /// <returns></returns>
        public override bool Test(System.Diagnostics.Stopwatch sw)
        {
            bool isSuccess = true;
            //TODO
            //PrintDatas(PoorPigs(new int[] { 0, 0 }, new int[] { 1, 1 }, new int[] { 1, 0 }, new int[] { 0, 1 }));
            return isSuccess;
        }

        public bool ValidPalindrome(String s)
        {
            int front = 0;
            int end = s.Length - 1;
            // < 符号，中间一个字符不影响回文与否
            while (front < end)
            {
                if (s[front] != s[end])
                {
                    return IsPalindrome(s, front + 1, end) || IsPalindrome(s, front, end - 1);
                }
                front++;
                end--;
            }
            return true;
        }

        public bool IsPalindrome(String s, int front, int end)
        {
            while (front < end)
            {
                if (s[front] != s[end])
                {
                    return false;
                }
                front++;
                end--;
            }
            return true;
        }
    }
}
