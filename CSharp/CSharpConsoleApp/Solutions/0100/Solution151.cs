using System;
namespace CSharpConsoleApp.Solutions
{
    /*
     * @lc app=leetcode.cn id=151 lang=csharp
     *
     * [151] 翻转字符串里的单词
     *
     * https://leetcode-cn.com/problems/reverse-words-in-a-string/description/
     *
     * Category	Difficulty	Likes	Dislikes
     * algorithms	Medium (47.15%)	328	-
     * Tags
     * string
     * 
     * Companies
     * apple | bloomberg | microsoft | snapchat | yelp
     * 
     * Total Accepted:    141.9K
     * Total Submissions: 300.9K
     * Testcase Example:  '"the sky is blue"'
     *
     * 给你一个字符串 s ，逐个翻转字符串中的所有 单词 。
     * 单词 是由非空格字符组成的字符串。s 中使用至少一个空格将字符串中的 单词 分隔开。
     * 请你返回一个翻转 s 中单词顺序并用单个空格相连的字符串。
     * 
     * 说明：
     * 输入字符串 s 可以在前面、后面或者单词间包含多余的空格。
     * 翻转后单词间应当仅用一个空格分隔。
     * 翻转后的字符串中不应包含额外的空格。
     * 
     * 示例 1：
     * 输入：s = "the sky is blue"
     * 输出："blue is sky the"
     * 
     * 示例 2：
     * 输入：s = "  hello world  "
     * 输出："world hello"
     * 解释：输入字符串可以在前面或者后面包含多余的空格，但是翻转后的字符不能包括。
     * 
     * 示例 3：
     * 输入：s = "a good   example"
     * 输出："example good a"
     * 解释：如果两个单词间有多余的空格，将翻转后单词间的空格减少到只含一个。
     * 
     * 示例 4：
     * 输入：s = "  Bob    Loves  Alice   "
     * 输出："Alice Loves Bob"
     * 
     * 示例 5：
     * 输入：s = "Alice does not even like bob"
     * 输出："bob like even not does Alice"
     * 
     * 提示：
     * 1 <= s.length <= 104
     * s 包含英文大小写字母、数字和空格 ' '
     * s 中 至少存在一个 单词
     * 
     * 进阶：
     * 请尝试使用 O(1) 额外空间复杂度的原地解法。
     */
    public class Solution151 : SolutionBase
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
        public override Tag[] GetTags() { return new Tag[] { Tag.Array }; }

        public override bool Test(System.Diagnostics.Stopwatch sw)
        {
            bool isSuccess = true;
            string points, result, checkResult;

            points = "  Bob    Loves  Alice   A";
            checkResult = "A Alice Loves Bob";
            result = ReverseWords(points);
            isSuccess &= result == checkResult;
            Print("isSuccess = {0} | result = {1} | anticipated = {2}", isSuccess, (result), (checkResult));

            points = "Bob    Loves  Alice   A  ";
            checkResult = "A Alice Loves Bob";
            result = ReverseWords(points);
            isSuccess &= result == checkResult;
            Print("isSuccess = {0} | result = {1} | anticipated = {2}", isSuccess, (result), (checkResult));

            return isSuccess;
        }

        /// <summary>
        /// 57/57 cases passed (104 ms)
        /// Your runtime beats 78.52 % of csharp submissions
        /// Your memory usage beats 80.74 % of csharp submissions(24.5 MB)
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public string ReverseWords(string s)
        {
            if (string.IsNullOrEmpty(s))
                return s;

            char c = s[0];
            int start = s[0] == ' ' ? -1 : 0;
            int end = start;
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            for (int i = 1; i < s.Length; i++)
            {
                if (c == ' ')
                {
                    if (s[i] != ' ')
                    {
                        start = i;
                        if (i == s.Length - 1)
                        {
                            end = i;
                            AddWord(sb, s, start, end);
                        }
                    }
                }
                else  //c != ' '
                {
                    if (s[i] == ' ')
                    {
                        end = i - 1;
                        AddWord(sb, s, start, end);
                    }
                    else if (i == s.Length - 1)
                    {
                        end = i;
                        AddWord(sb, s, start, end);
                    }
                }
                c = s[i];
            }
            return sb.ToString();
        }

        void AddWord(System.Text.StringBuilder sb, string s, int start, int end)
        {
            if (start >= 0 || end >= start)
            {
                if (sb.Length > 0)
                    sb.Insert(0, ' ');
                sb.Insert(0, s.Substring(start, end - start + 1));
            }
        }
    }
}
