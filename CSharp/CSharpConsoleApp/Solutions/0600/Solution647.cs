using System;
namespace CSharpConsoleApp.Solutions
{
    /*
     * @lc app=leetcode.cn id=647 lang=csharp
     *
     * [647] 回文子串
     *
     * https://leetcode-cn.com/problems/palindromic-substrings/description/
     *
     * Category	Difficulty	Likes	Dislikes
     * algorithms	Medium (65.44%)	639	-
     * Tags
     * string | dynamic-programming
     * 
     * Companies
     * facebook | linkedin
     * Total Accepted:    108.3K
     * Total Submissions: 165.4K
     * Testcase Example:  '"abc"'
     *
     * 给定一个字符串，你的任务是计算这个字符串中有多少个回文子串。
     * 具有不同开始位置或结束位置的子串，即使是由相同的字符组成，也会被视作不同的子串。
     * 
     * 
     * 示例 1：
     * 输入："abc"
     * 输出：3
     * 解释：三个回文子串: "a", "b", "c"
     * 
     * 
     * 示例 2：
     * 输入："aaa"
     * 输出：6
     * 解释：6个回文子串: "a", "a", "a", "aa", "aa", "aaa"
     *
     * 
     * 提示：
     * 输入的字符串长度不会超过 1000 。
     */

    // @lc code=start
    public class Solution647 : SolutionBase
    {
        /// <summary>
        /// 难度
        /// </summary>
        public override Difficulity GetDifficulity() { return Difficulity.Medium; }
        /// <summary>
        /// 关键字:
        /// </summary>
        public override string[] GetKeyWords() { return new string[] { "回文子串", "通过" }; }
        /// <summary>
        /// 标签：
        /// </summary>
        public override Tag[] GetTags() { return new Tag[] { Tag.String, Tag.DynamicProgramming }; }

        
        /// <summary>
        /// </summary>
        /// <param name="sw"></param>
        /// <returns></returns>
        public override bool Test(System.Diagnostics.Stopwatch sw)
        {
            bool isSuccess = true;

            string c;
            int result, checkResult;

            c = "abc";
            checkResult = 3;
            result = CountSubstrings(c);
            isSuccess &= IsSame(result, checkResult);
            PrintResult(isSuccess, result, checkResult);

            c = "aaa";
            checkResult = 6;
            result = CountSubstrings(c);
            isSuccess &= IsSame(result, checkResult);
            PrintResult(isSuccess, result, checkResult);

            return isSuccess;
        }

        /// <summary>
        /// 130/130 cases passed (260 ms)
        /// Your runtime beats 7.32 % of csharp submissions
        /// Your memory usage beats 90.24 % of csharp submissions(21.9 MB)
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public int CountSubstrings(string s)
        {
            if (string.IsNullOrEmpty(s)) return 0;

            int n = s.Length;

            int sum = 0;
            for (int i = 0; i < n; i++)
            {
                for (int j = i; j < n ; j++)
                {
                    if (i == j)
                        sum += 1;
                    else if (IsPalindrome(s, i, j))
                    {
                        sum += 1;
                    }    
                }
            }
            return sum;
        }

        //判断是否是回文。 From Solution 336
        public bool IsPalindrome(String s, int left, int right)
        {
            int len = right - left + 1;
            for (int i = 0; i < len / 2; i++)
            {
                if (s[left + i] != s[right - i])
                {
                    return false;
                }
            }
            return true;
        }
    }
    // @lc code=end


}
