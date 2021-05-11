using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpConsoleApp.Solutions._0300
{
    /*
     * @lc app=leetcode.cn id=345 lang=csharp
     *
     * [345] 反转字符串中的元音字母
     *
     * https://leetcode-cn.com/problems/reverse-vowels-of-a-string/description/
     *
     * Category	Difficulty	Likes	Dislikes
     * algorithms	Easy (51.77%)	149	-
     * Tags
     * two-pointers | string
     * 
     * Companies
     * google
     * 
     * Total Accepted:    69.2K
     * Total Submissions: 133.6K
     * Testcase Example:  '"hello"'
     *
     * 编写一个函数，以字符串作为输入，反转该字符串中的元音字母。
     * 
     * 示例 1：
     * 输入："hello"
     * 输出："holle"
     * 
     * 示例 2：
     * 输入："leetcode"
     * 输出："leotcede"
     * 
     * 提示：
     * 元音字母不包含字母 "y" 。
     * 
     * 
     */

    class Solution345 : SolutionBase
    {

        /// <summary>
        /// 难易度:
        /// </summary>
        public override Difficulity GetDifficulity() { return Difficulity.Easy; }
        /// <summary>
        /// 关键字:
        /// </summary>
        public override string[] GetKeyWords() { return new string[] { "前序序列化", "入度出度" }; }
        /// <summary>
        /// 标签：
        /// </summary>
        public override Tag[] GetTags() { return new Tag[] { Tag.HashTable, Tag.String, Tag.Trie }; }

        //TODO
        public override bool Test(System.Diagnostics.Stopwatch sw)
        {
            bool isSuccess = true;
            string words;
            string result;
            string checkResult;

            words = "leetcode";
            checkResult = "leotcede";
            result = ReverseVowels(words);

            Print("{0}, {1}" , result, checkResult);
            return isSuccess;
        }

        /// <summary>
        /// 双指针方法，速度凑活
        /// 
        /// 480/480 cases passed (112 ms)
        /// Your runtime beats 66.18 % of csharp submissions
        /// Your memory usage beats 57.35 % of csharp submissions(27.3 MB)
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public string ReverseVowels(string s)
        {
            if (string.IsNullOrEmpty(s))
                return s;

            int n = s.Length;
            int li = 0;
            int ri = n - 1;
            char[] charArr = s.ToArray();
            while (true)
            {
                while (li < n && !"AEIOUaeiou".Contains(s[li]))
                {
                    li++;
                }

                while (ri >= 0 && !"AEIOUaeiou".Contains(s[ri]))
                {
                    ri--;
                }
                if (li < ri)
                {
                    char r = charArr[ri];
                    charArr[ri] = charArr[li];
                    charArr[li] = r;
                    li++;
                    ri--;
                }
                else
                {
                    break;
                }
            }
            return new string(charArr);
        }
    }
}
