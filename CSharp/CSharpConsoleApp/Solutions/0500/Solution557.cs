using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpConsoleApp.Solutions._0500
{
    /*
     * @lc app=leetcode.cn id=557 lang=csharp
     *
     * [557] 反转字符串中的单词 III
     *
     * https://leetcode-cn.com/problems/reverse-words-in-a-string-iii/description/
     *x
     * Category	Difficulty	Likes	Dislikes
     * algorithms	Easy (74.03%)	291	-
     * Tags
     * string
     * 
     * Companies
     * zappos
     * 
     * Total Accepted:    120.5K
     * Total Submissions: 162.8K
     * Testcase Example:  `"Let's take LeetCode contest"`
     *
     * 给定一个字符串，你需要反转字符串中每个单词的字符顺序，同时仍保留空格和单词的初始顺序。
     * 
     * 
     * 
     * 示例：
     * 
     * 输入："Let's take LeetCode contest"
     * 输出："s'teL ekat edoCteeL tsetnoc"
     * 
     * 
     * 
     * 
     * 提示：
     * 
     * 
     * 在字符串中，每个单词由单个空格分隔，并且字符串中不会有任何额外的空格。
     * 
     * 
     */

    class Solution557 : SolutionBase
    {
        public override Difficulity GetDifficulity() { return Difficulity.Easy; }
        /// <summary>
        /// 关键字:
        /// </summary>
        public override string[] GetKeyWords() { return new string[] { "一定要使用 StringBuilder 替代 List<char>|string", "使用栈翻转字符串" }; }
        /// <summary>
        /// 标签：
        /// </summary>
        public override Tag[] GetTags() { return new Tag[] { Tag.String, }; }
        public override bool Test(System.Diagnostics.Stopwatch sw)
        {
            bool isSuccess = true;
            return isSuccess;
        }

        /// 结果很惨
        /// 29/29 cases passed (116 ms)
        /// Your runtime beats 6.61 % of csharp submissions
        /// Your memory usage beats 16.53 % of csharp submissions(37.3 MB)
        public string ReverseWords_My(string s)
        {
            string[] words = s.Split(' ');

            List<char> result = new List<char>();
            for (int i = 0; i < words.Length; i++)
            {
                result.AddRange(words[i].Reverse());
                if (i != words.Length - 1)
                    result.Add(' ');
            }
            return string.Join("", result);
        }

        /// 改为stringbuilder，性能提高显著，但也只是一般稍好。
        /// 29/29 cases passed (116 ms)
        /// Your runtime beats 61.98 % of csharp submissions
        /// Your memory usage beats 39.67 % of csharp submissions(34.4 MB)
        public string ReverseWords_My2(string s)
        {
            string[] words = s.Split(' ');

            //List<char> result = new List<char>();
            StringBuilder result = new StringBuilder();
            for (int i = 0; i < words.Length; i++)
            {
                result.Append(words[i].Reverse().ToArray());
                if (i != words.Length - 1)
                    result.Append(' ');
            }
            return result.ToString();
        }

        /// 该方法实际效率一般,内存较优。
        /// 29/29 cases passed (136 ms)
        /// Your runtime beats 36.36 % of csharp submissions
        /// Your memory usage beats 68.6 % of csharp submissions(31.3 MB)
        /// 使用栈翻转
        /// 作者：LeetCode-Solution
        /// 链接：https://leetcode-cn.com/problems/reverse-words-in-a-string-iii/solution/fan-zhuan-zi-fu-chuan-zhong-de-dan-ci-iii-by-lee-2/
        public String ReverseWords(String s)
        {
            StringBuilder ret = new StringBuilder();
            int length = s.Length;
            int i = 0;
            while (i < length)
            {
                int start = i;
                while (i < length && s[i] != ' ')
                {
                    i++;
                }
                for (int p = start; p < i; p++)
                {
                    ret.Append(s[start + i - 1 - p]);
                }
                while (i < length && s[i] == ' ')
                {
                    i++;
                    ret.Append(' ');
                }
            }
            return ret.ToString();
        }
    }
}
