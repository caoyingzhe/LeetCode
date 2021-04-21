using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpConsoleApp.Solutions
{
    /// <summary>
    /// 有效的括号
    /// </summary>
    class Solution20 : SolutionBase
    {
        /// <summary>
        /// 难度
        /// </summary>
        public override Difficulity GetDifficulity() { return Difficulity.Easy; }
        /// <summary>
        /// 关键字:
        /// </summary>
        public override string[] GetKeyWords() { return new string[] { "Stack" }; }
        /// <summary>
        /// 标签： 
        /// </summary>
        public override Tag[] GetTags() { return new Tag[] { Tag.Stack }; }

        public override bool Test(System.Diagnostics.Stopwatch sw)
        {
            return false;
        }

        /// <summary>
        /// 该方法速度超慢，超耗内存，不采用。
        /// Your runtime beats 10.29 % of csharp submissions
        /// Your memory usage beats 5.03 % of csharp submissions(41.3 MB)
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public bool IsValid_Slow(string s)
        {
            if (s.Length % 2 != 0)
                return false;
            while (s.Contains("[]") || s.Contains("()") || s.Contains("{}"))
            {
                s = s.Replace("[]", "").Replace("()", "").Replace("{}", "");
            }
            if (s == "")
                return true;
            else
                return false;
        }


        /// <summary>
        /// Your runtime beats 86.51 % of csharp submissions
        /// Your memory usage beats 39.77 % of csharp submissions(22.2 MB)
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public bool IsValid(string s)
        {
            if (string.IsNullOrEmpty(s))
                return true;
            Stack<char> stack = new Stack<char>();
            foreach (char c in s)
            {
                if (c == '(')
                    stack.Push(')');
                else if (c == '{')
                    stack.Push('}');
                else if (c == '[')
                    stack.Push(']');
                else if (stack.Count == 0 || c != stack.Pop())
                    return false;
            }
            if (stack.Count == 0)
                return true;
            return false;
        }

    }
}
