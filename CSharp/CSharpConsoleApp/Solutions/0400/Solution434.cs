using System;
namespace CSharpConsoleApp.Solutions
{
    /*
     * @lc app=leetcode.cn id=434 lang=csharp
     *
     * [434] 字符串中的单词数
     *
     * https://leetcode-cn.com/problems/number-of-segments-in-a-string/description/
     *
     * Category	Difficulty	Likes	Dislikes
     * algorithms	Easy (37.27%)	90	-
     * Tags
     * string
     * 
     * Companies
     * Unknown
     * 
     * Total Accepted:    35.5K
     * Total Submissions: 95.3K
     * Testcase Example:  '"Hello, my name is John"'
     *
     * 统计字符串中的单词个数，这里的单词指的是连续的不是空格的字符。
     * 
     * 请注意，你可以假定字符串里不包括任何不可打印的字符。
     * 
     * 示例:
     * 
     * 输入: "Hello, my name is John"
     * 输出: 5
     * 解释: 这里的单词是指连续的不是空格的字符，所以 "Hello," 算作 1 个单词。
     */

    // @lc code=start
    public class Solution434
    {
        /// <summary>
        /// 27/27 cases passed (68 ms)
        /// Your runtime beats 100 % of csharp submissions
        /// Your memory usage beats 55.36 % of csharp submissions(21.8 MB)
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public int CountSegments(string s)
        {
            if (s == null) return 0;

            s = s.TrimEnd();
            if (string.IsNullOrEmpty(s)) return 0;

            int count = 1;
            for (int i = 0; i < s.Length - 1; i++)
            {
                if (s[i] != ' ' && s[i + 1] == ' ')
                {
                    count++;
                }
            }
            return count;
        }
    }
    // @lc code=end


}
