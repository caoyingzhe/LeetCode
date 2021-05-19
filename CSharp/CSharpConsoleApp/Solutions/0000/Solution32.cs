using System;
using System.Collections.Generic;
using System.Linq;
namespace CSharpConsoleApp.Solutions
{
    /*
     * @lc app=leetcode.cn id=32 lang=csharp
     *
     * [32] 最长有效括号
     *
     * https://leetcode-cn.com/problems/longest-valid-parentheses/description/
     *
     * Category	Difficulty	Likes	Dislikes
     * algorithms	Hard (34.88%)	1306	-
     * Tags
     * string | dynamic-programming
     * 
     * Companies
     * Unknown
     * 
     * Total Accepted:    150.1K
     * Total Submissions: 430.2K
     * Testcase Example:  '"(()"'
     *
     * 给你一个只包含 '(' 和 ')' 的字符串，找出最长有效（格式正确且连续）括号子串的长度。
     * 
     * 示例 1：
     * 输入：s = "(()"
     * 输出：2
     * 解释：最长有效括号子串是 "()"
     * 
     * 示例 2：
     * 输入：s = ")()())"
     * 输出：4
     * 解释：最长有效括号子串是 "()()"
     * 
     * 示例 3：
     * 输入：s = ""
     * 输出：0
     * 
     * 提示：
     * 0 <= s.length <= 3 * 10^4
     * s[i] 为 '(' 或 ')'
     * 
     */
    public class Solution32 : SolutionBase
    {
        /// <summary>
        /// 难易度:
        /// </summary>
        public override Difficulity GetDifficulity() { return Difficulity.Hard; }
        /// <summary>
        /// 关键字:
        /// </summary>
        public override string[] GetKeyWords() { return new string[] { "动态编程", "字符串" }; }
        /// <summary>
        /// 标签： 图
        /// </summary>
        public override Tag[] GetTags() { return new Tag[] { Tag.String, Tag.DynamicProgramming }; }

        public override bool Test(System.Diagnostics.Stopwatch sw)
        {
            bool isSuccess = true;
            string s;
            int result, checkResult;

            s = ")()()()(())))";
            checkResult = 10;
            result = LongestValidParentheses(s);
            
            isSuccess &= result == checkResult;
            Print("isSuccess = {0} result = {1} | checkResult = {2}", isSuccess, (result), (checkResult));
            
            s = "(()";
            checkResult = 2;
            result = LongestValidParentheses(s);
            
            isSuccess &= result == checkResult;
            Print("isSuccess = {0} result = {1} | checkResult = {2}", isSuccess, (result), (checkResult));
            
            s = "(()()";
            checkResult = 4;
            result = LongestValidParentheses(s);
            
            isSuccess &= result == checkResult;
            Print("isSuccess = {0} result = {1} | checkResult = {2}", isSuccess, (result), (checkResult));
            
            s = "()(()()(()";
            checkResult = 4;
            result = LongestValidParentheses(s);
            
            isSuccess &= result == checkResult;
            Print("isSuccess = {0} result = {1} | checkResult = {2}", isSuccess, (result), (checkResult));

            s = "()(())";
            checkResult = 6;
            result = LongestValidParentheses(s);

            isSuccess &= result == checkResult;
            Print("isSuccess = {0} result = {1} | checkResult = {2}", isSuccess, (result), (checkResult));

            s = "((()))())";
            checkResult = 8;
            result = LongestValidParentheses(s);

            isSuccess &= result == checkResult;
            Print("isSuccess = {0} result = {1} | checkResult = {2}", isSuccess, (result), (checkResult));

            s = ")(((((()())()()))()(()))(";
            checkResult = 22;
            result = LongestValidParentheses(s);

            isSuccess &= result == checkResult;
            Print("isSuccess = {0} result = {1} | checkResult = {2}", isSuccess, (result), (checkResult));

            return isSuccess;
        }
        public int LongestValidParentheses(string s)
        {
            return LongestValidParentheses_Stack(s);
        }

        /// <summary>
        /// 使用栈
        /// 参考 https://leetcode-cn.com/problems/longest-valid-parentheses/solution/zui-chang-you-xiao-gua-hao-by-leetcode-solution/
        /// 231/231 cases passed (96 ms)
        /// Your runtime beats 33.64 % of csharp submissions
        /// Your memory usage beats 48.18 % of csharp submissions(23.2 MB)
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public int LongestValidParentheses_Stack(string s)
        {
            int maxLen = 0;
            Stack<int> stack = new Stack<int >(); //存储左括号的索引

            stack.Push(-1);
            for (int i = 0; i < s.Length; i++)
            {
                if (s[i] == '(')
                    stack.Push(i);
                else  //TODO 此处else的处理未全弄明白
                {
                    stack.Pop();
                    if (stack.Count == 0)   
                    {
                        stack.Push(i);
                    }
                    else
                    {
                        maxLen = Math.Max(maxLen, i - stack.Peek());
                    }
                }
            }

            return maxLen;
        }
        public int LongestValidParentheses_LTE(string s)
        {
            int n = s.Length;

            int maxLen = 0;
            for (int L = 0; L < n; L++)
            {
                int R = n - 1;

                if (R - L + 1 <= maxLen)
                    break;
                while (L < R)
                {
                    int tmpLen;
                    if (IsAllMatch(s.Substring(L, R - L + 1), out tmpLen))
                    {
                        maxLen = Math.Max(maxLen, (R - L + 1));
                        break;
                        //if (R - L + 1 >= 22) // "((((()())()()))()(()))")
                        //    Print("len =" +(R-L+1) + " | " + s.Substring(L, R - L + 1));
                    }
                    R--;
                }
            }
            return maxLen;
        }

        bool IsAllMatch(string s, out int maxLen)
        {
            maxLen = 0;
            Stack<char> stack = new Stack<char>();

            for(int i=0; i<s.Length; i++)
            {
                if(stack.Count == 0 )
                {
                    if (s[i] == ')')
                        return false;
                    else
                        stack.Push(s[i]);
                }
                else
                {
                    if(stack.Peek() == '(' && s[i] == ')')
                    {
                        stack.Pop();
                        maxLen++;
                    }
                    else if (stack.Peek() == ')' && s[i] == '(')
                    {
                        stack.Pop();
                        maxLen++;
                    }
                    else
                    {
                        if (s[i] == ')')
                            return false;
                        else
                            stack.Push('(');
                    }
                }
            }

            return stack.Count == 0;
        }
    }
}
