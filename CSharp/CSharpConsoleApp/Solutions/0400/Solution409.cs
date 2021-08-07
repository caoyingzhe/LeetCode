using System;
using System.Collections.Generic;
namespace CSharpConsoleApp.Solutions
{
    /*
     * @lc app=leetcode.cn id=409 lang=csharp
     *
     * [409] 最长回文串
     *
     * https://leetcode-cn.com/problems/longest-palindrome/description/
     *
     * Category	Difficulty	Likes	Dislikes
     * algorithms	Easy (55.46%)	298	-
     * Tags
     * hash-table
     * 
     * Companies
     * google
     * 
     * Total Accepted:    79.4K
     * Total Submissions: 143.2K
     * Testcase Example:  '"abccccdd"'
     *
     * 给定一个包含大写字母和小写字母的字符串，找到通过这些字母构造成的最长的回文串。
     * 
     * 在构造过程中，请注意区分大小写。比如 "Aa" 不能当做一个回文字符串。
     * 
     * 注意:
     * 假设字符串的长度不会超过 1010。
     * 
     * 示例 1: 
     * 输入:
     * "abccccdd"
     * 输出:
     * 7
     * 
     * 解释:
     * 我们可以构造的最长的回文串是"dccaccd", 它的长度是 7。
     */
    public class Solution409 : SolutionBase
    {
        /// <summary>
        /// 难度
        /// </summary>
        public override Difficulity GetDifficulity() { return Difficulity.Easy; }
        /// <summary>
        /// 关键字:
        /// </summary>
        public override string[] GetKeyWords() { return new string[] { }; }
        /// <summary>
        /// 标签：
        /// </summary>
        public override Tag[] GetTags() { return new Tag[] { Tag.HashTable, }; }

        public override bool Test(System.Diagnostics.Stopwatch sw)
        {
            bool isSuccess = true;
            string s;
            int result, checkResult;

            s = "abccccdd";
            checkResult = 7;
            result = LongestPalindrome(s);
            isSuccess &= result == checkResult;
            Print("isSuccess = {0} | result = {1} | anticipated = {2}", isSuccess, (result), (checkResult));

            s = "abccccddeee";
            checkResult = 9;
            result = LongestPalindrome(s);
            isSuccess &= result == checkResult;
            Print("isSuccess = {0} | result = {1} | anticipated = {2}", isSuccess, (result), (checkResult));

            s = "abccccddeeefffff";
            checkResult = 13;
            result = LongestPalindrome(s);
            isSuccess &= result == checkResult;
            Print("isSuccess = {0} | result = {1} | anticipated = {2}", isSuccess, (result), (checkResult));

            s = "";
            checkResult = 0;
            result = LongestPalindrome(s);
            isSuccess &= result == checkResult;
            Print("isSuccess = {0} | result = {1} | anticipated = {2}", isSuccess, (result), (checkResult));

            s = "A";
            checkResult = 1;
            result = LongestPalindrome(s);
            isSuccess &= result == checkResult;
            Print("isSuccess = {0} | result = {1} | anticipated = {2}", isSuccess, (result), (checkResult));

            s = "BB";
            checkResult = 2;
            result = LongestPalindrome(s);
            isSuccess &= result == checkResult;
            Print("isSuccess = {0} | result = {1} | anticipated = {2}", isSuccess, (result), (checkResult));

            return isSuccess;
        }

        /// <summary>
        /// 95/95 cases passed (80 ms)
        /// Your runtime beats 91.89 % of csharp submissions
        /// Your memory usage beats 81.08 % of csharp submissions(22.2 MB)
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public int LongestPalindrome(string s)
        {
            if (s == "")
                return 0;

            int[] counts = new int[52];
            foreach (char c in s)
            {
                if (c >= 'a' && c <= 'z')
                    counts[c - 'a']++;
                else
                    counts[c - 'A' + 26]++;
            }

            int len = 0;
            int oddCount = 0;
            for (int i = 0; i < 52; i++)
            {
                bool isOdd = counts[i] % 2 == 1;

                if (counts[i] >= 2)
                {
                    if (isOdd)
                        len += counts[i] - 1;
                    else
                        len += counts[i];
                }
                if (isOdd)
                    oddCount++;
            }
            return len + (oddCount > 0 ? 1 : 0);
        }
    }
}
