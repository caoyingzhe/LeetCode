 
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpConsoleApp.Solutions
{
    /*
    * @lc app=leetcode.cn id=224 lang=csharp
    *
    * [224] 基本计算器
    * https://leetcode-cn.com/problems/basic-calculator/description/
    *
    * algorithms
    * Hard (41.68%)
    * Likes:    550
    * Dislikes: 0
    * Total Accepted:    57.3K
    * Total Submissions: 137.6K
    * Testcase Example:  '"1 + 1"'
    *
    * 给你一个字符串表达式 s ，请你实现一个基本计算器来计算并返回它的值。
    * 
    * 示例 1：
    * 输入：s = "1 + 1"
    * 输出：2
    * 
    * 示例 2：
    * 输入：s = " 2-1 + 2 "
    * 输出：3
    * 
    * 示例 3：
    * 输入：s = "(1+(4+5+2)-3)+(6+8)"
    * 输出：23
    * 
    * 提示：
    * 1 
    * s 由数字、'+'、'-'、'('、')'、和 ' ' 组成
    * s 表示一个有效的表达式
    */
    class Solution224 : SolutionBase
    {
        /// <summary>
        /// 难度
        /// </summary>
        public override Difficulity GetDifficulity() { return Difficulity.Hard; }
        /// <summary>
        /// 关键字:
        /// </summary>
        public override string[] GetKeyWords() { return new string[] { "Stack", }; }
        /// <summary>
        /// 标签： 
        /// </summary>
        public override Tag[] GetTags() { return new Tag[] { Tag.Math, Tag.Stack }; }
        public override bool Test(System.Diagnostics.Stopwatch sw)
        {
            bool isSuccess = true;

            string s;
            int checkResult;

            s = "6 + 4";
            checkResult = 10;
            System.Diagnostics.Debug.Assert(Calculate(s) == checkResult);

            s = " 2-1 + 2 ";
            checkResult = 3;
            System.Diagnostics.Debug.Assert(Calculate(s) == checkResult);

            s = "(1+ (4+5+2)-3 + (5+5))+(6+8)";
            checkResult = 33;
            System.Diagnostics.Debug.Assert(Calculate(s) == checkResult);

            return isSuccess;
        }

        //思路： 利用栈保存每个数的符号对应的正负号，直接一遍就计算出来了
        public int Calculate(string s)
        {
            int sign = 1;
            Stack<int> ops = new Stack<int>();
            ops.Push(1);

            int i = 0;  int n = s.Length;
            int sum = 0;
            while(i< n)
            {
                char c = s[i];
                if (s[i] == ' ')
                {
                    i++;
                }
                else if (c == '+')
                {
                    sign = ops.First(); //Java代码: ops.peek();  C++代码： ops.top();
                    i++;
                }
                else if(c == '-')
                {
                    sign = -ops.First();
                    i++;
                }
                else if(c == '(')
                {
                    ops.Push(sign);
                    i++;
                }
                else if(c == ')')
                {
                    ops.Pop();
                    i++;
                }
                else
                {
                    int num = 0;
                    while (i< n && s[i] >= '0' && s[i] <= '9')
                    {
                        num = num * 10 + s[i] - '0';
                        i++;
                    }
                    sum += sign * num;
                }
            }
            return sum;
        }
    }
}
