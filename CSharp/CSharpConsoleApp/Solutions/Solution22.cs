using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpConsoleApp.Solutions
{
    /// <summary>
    /// 括号生成
    /// </summary>
    class Solution22 : SolutionBase
    {
        /// <summary>
        /// 难度
        /// </summary>
        public override Difficulity GetDifficulity() { return Difficulity.Medium; }
        /// <summary>
        /// 关键字:
        /// </summary>
        public override string[] GetKeyWords() { return new string[] { "Backtracking" }; }
        /// <summary>
        /// 标签： 
        /// </summary>
        public override Tag[] GetTags() { return new Tag[] { Tag.Backtracking }; }

        public override bool Test(System.Diagnostics.Stopwatch sw)
        {
            int n = 3;
            GenerateParenthesis(n);
            return false;
        }
        #region 

        /// <summary>
        /// 回溯法
        /// 时间复杂度：4n / sqrt(n)
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public List<String> GenerateParenthesis(int n)
        {
            List<String> ans = new List<String>();
            backtrack(ans, new StringBuilder(), 0, 0, n);
            return ans;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ans">计算结果列表</param>
        /// <param name="cur">当前处理中字符串</param>
        /// <param name="open">左括号数量</param>
        /// <param name="close">右括号数量</param>
        /// <param name="max"></param>
        public void backtrack(List<String> ans, StringBuilder cur, int open, int close, int max)
        {
            if (cur.Length == max * 2)
            {
                ans.Add(cur.ToString());
                Print(">>> Add To List : " + cur);
                return;
            }

            //只在序列仍然保持有效时才添加 '(' or ')'
            if (open < max)
            {
                //如果左括号数量不大于 max，我们可以放一个左括号
                cur.Append('(');
                Print("Add ( Step1. cur =" + cur);
                backtrack(ans, cur, open + 1, close, max);
                //移除最后以为的目的是为了，只删除这一次添加的字符, 继续使用前面有效的字串
                Print("Add ( Step2. cur =" + cur);
                cur.Remove(cur.Length - 1,1);
                Print("--- ( Remove cur =" + cur);
            }
            if (close < open)
            {
                //如果右括号数量小于左括号的数量，我们可以放一个右括号。
                cur.Append(')');
                Print("Add ) Step1. cur =" + cur);
                backtrack(ans, cur, open, close + 1, max);
                Print("Add ) Step2. cur =" + cur);
                //移除最后以为的目的是为了，只删除这一次添加的字符, 继续使用前面有效的字串
                cur.Remove(cur.Length - 1,1);
                Print("--- ) Remove cur =" + cur);
            }
        }
        #endregion

        #region 暴力法
        /// <summary>
        /// 暴力法  指定固定长度字符串，尝试填充括号字符串，包含所有可能的组合，测试通过后添加到List中。
        /// 时间复杂度：Power(2,2n)
        /// 
        /// 作者：LeetCode-Solution
        /// 链接：https://leetcode-cn.com/problems/generate-parentheses/solution/gua-hao-sheng-cheng-by-leetcode-solution/
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public IList<string> GenerateParenthesis_Slow(int n)
        {
            List<String> combinations = new List<String>();
            generateAll(new char[2 * n], 0, combinations);
            return combinations;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="current"></param>
        /// <param name="pos"></param>
        /// <param name="result"></param>
        public void generateAll(char[] current, int pos, List<String> result)
        {
            //超出字符串长度，不在增加，开始验证current的有效性。
            if (pos == current.Length)
            {
                if (valid(current))
                {
                    result.Add(new String(current));
                }
            }
            else
            {
                current[pos] = '(';
                generateAll(current, pos + 1, result);
                current[pos] = ')';
                generateAll(current, pos + 1, result);
            }
        }

        public bool valid(char[] current)
        {
            //balance 表示左括号的数量减去右括号的数量
            int balance = 0;
            foreach(char c in current)
            {
                if (c == '(')
                {
                    ++balance;
                }
                else
                {
                    --balance;
                }
                //balance 的值小于零，判定current无效
                if (balance < 0)
                {
                    return false;
                }
            }
            //balance 的值等于零，判定current无效
            return balance == 0;
        }
        #endregion

    }
}
