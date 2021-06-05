using System;
namespace CSharpConsoleApp.Solutions
{
    /*
     * @lc app=leetcode.cn id=65 lang=csharp
     *
     * [65] 有效数字
     *
     * https://leetcode-cn.com/problems/valid-number/description/
     *
     * Category	Difficulty	Likes	Dislikes
     * algorithms	Hard (22.59%)	188	-
     * Tags
     * math | string
     * 
     * Companies
     * linkedin
     * 
     * Total Accepted:    26.4K
     * Total Submissions: 117K
     * Testcase Example:  '"0"'
     *
     * 有效数字（按顺序）可以分成以下几个部分：
     * 一个 小数 或者 整数
     * （可选）一个 'e' 或 'E' ，后面跟着一个 整数
     * 
     * 小数（按顺序）可以分成以下几个部分：
     * （可选）一个符号字符（'+' 或 '-'）
     * 下述格式之一：
     * 至少一位数字，后面跟着一个点 '.'
     * 至少一位数字，后面跟着一个点 '.' ，后面再跟着至少一位数字
     * 一个点 '.' ，后面跟着至少一位数字
     * 
     * 整数（按顺序）可以分成以下几个部分：
     * （可选）一个符号字符（'+' 或 '-'）
     * 至少一位数字
     * 
     * 部分有效数字列举如下：
     * ["2", "0089", "-0.1", "+3.14", "4.", "-.9", "2e10", "-90E3", "3e+7",
     * "+6e-1", "53.5e93", "-123.456e789"]
     * 
     * 部分无效数字列举如下：
     * ["abc", "1a", "1e", "e3", "99e2.5", "--6", "-+3", "95a54e53"]
     * 
     * 给你一个字符串 s ，如果 s 是一个 有效数字 ，请返回 true 。
     * 
     * 示例 1：
     * 输入：s = "0"  输出：true
     * 
     * 示例 2：
     * 输入：s = "e"  输出：false
     * 
     * 示例 3：
     * 输入：s = "."  输出：false
     * 
     * 示例 4：
     * 输入：s = ".1"  输出：true
     * 
     * 提示：
     * 1 <= s.length <= 20
     * s 仅含英文字母（大写和小写），数字（0-9），加号 '+' ，减号 '-' ，或者点 '.' 。
     */
    public class Solution65 : SolutionBase
    {
        /// <summary>
        /// 难度
        /// </summary>
        public override Difficulity GetDifficulity() { return Difficulity.Medium; }
        /// <summary>
        /// 关键字:
        /// </summary>
        public override string[] GetKeyWords() { return new string[] { "有限状态机（DFA）" }; }
        /// <summary>
        /// 标签：
        /// </summary>
        public override Tag[] GetTags() { return new Tag[] { Tag.Math, Tag.String }; }

        public override bool Test(System.Diagnostics.Stopwatch sw)
        {
            bool isSuccess = true;
            string s;
            bool result, checkResult;

            s = "1E9";
            checkResult = true;
            result = IsNumber(s);
            isSuccess &= checkResult == result;
            Print("isSuccess = {0} | result = {1} | anticipated = {2}", isSuccess, (result), (checkResult));

            return isSuccess;
        }


        /// <summary>
        /// 原文章代码中 make()方法有报错，1E9 返回的是false。加了case判断case 'E':return 4;
        /// 1488/1488 cases passed (88 ms)
        /// Your runtime beats 100 % of csharp submissions
        /// Your memory usage beats 22.22 % of csharp submissions(25.7 MB)
        /// 作者：user8973
        /// 链接：https://leetcode-cn.com/problems/valid-number/solution/biao-qu-dong-fa-by-user8973/
        /// </summary>
        /// <param name="c"></param>
        /// <returns></returns>
        public int Make(char c)
        {
            switch (c)
            {
                case ' ': return 0;
                case '+':
                case '-': return 1;
                case '.': return 3;
                case 'e': return 4;
                case 'E': return 4;
                default:
                    if (c >= 48 && c <= 57) return 2;
                    break;
            }
            return -1;
        }

        /// <summary>
        /// 有限状态机
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public bool IsNumber(string s)
        {
            int state = 0;
            int finals = 0b101101000;
            int[][] transfer = new int[][]{
                new int[] { 0, 1, 6, 2,-1},
                new int[] {-1,-1, 6, 2,-1},
                new int[] {-1,-1, 3,-1,-1},
                new int[] { 8,-1, 3,-1, 4},
                new int[] {-1, 7, 5,-1,-1},
                new int[] { 8,-1, 5,-1,-1},
                new int[] { 8,-1, 6, 3, 4},
                new int[] {-1,-1, 5,-1,-1},
                new int[] { 8,-1,-1,-1,-1}};
            char[] ss = s.ToCharArray();
            for (int i = 0; i < ss.Length; ++i)
            {
                int id = Make(ss[i]);
                if (id < 0) return false;
                state = transfer[state][id];
                if (state < 0) return false;
            }
            return (finals & (1 << state)) > 0;
        }
    }
}
