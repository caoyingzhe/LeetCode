using System;
using System.Collections.Generic;
using System.Text;
namespace CSharpConsoleApp.Solutions
{
    /*
     * @lc app=leetcode.cn id=726 lang=csharp
     *
     * [726] 原子的数量
     *
     * https://leetcode-cn.com/problems/number-of-atoms/description/
     *
     * Category	Difficulty	Likes	Dislikes
     * algorithms	Hard (45.94%)	121	-
     * Tags
     * hash-table | stack | recursion
     * 
     * Companies
     * google
     * 
     * Total Accepted:    6.1K
     * Total Submissions: 13.3K
     * Testcase Example:  '"H2O"'
     *
     * 给定一个化学式formula（作为字符串），返回每种原子的数量。
     * 
     * 原子总是以一个大写字母开始，接着跟随0个或任意个小写字母，表示原子的名字。
     * 
     * 如果数量大于 1，原子后会跟着数字表示原子的数量。如果数量等于 1 则不会跟数字。例如，H2O 和 H2O2 是可行的，但 H1O2
     * 这个表达是不可行的。
     * 
     * 两个化学式连在一起是新的化学式。例如 H2O2He3Mg4 也是化学式。
     * 
     * 一个括号中的化学式和数字（可选择性添加）也是化学式。例如 (H2O2) 和 (H2O2)3 是化学式。
     * 
     * 给定一个化学式，输出所有原子的数量。格式为：第一个（按字典序）原子的名子，跟着它的数量（如果数量大于
     * 1），然后是第二个原子的名字（按字典序），跟着它的数量（如果数量大于 1），以此类推。
     * 
     * 示例 1:
     * 输入: 
     * formula = "H2O"
     * 输出: "H2O"
     * 解释: 
     * 原子的数量是 {'H': 2, 'O': 1}。
     * 
     * 
     * 示例 2:
     * 输入: 
     * formula = "Mg(OH)2"
     * 输出: "H2MgO2"
     * 解释: 
     * 原子的数量是 {'H': 2, 'Mg': 1, 'O': 2}。
     * 
     * 
     * 示例 3:
     * 输入: 
     * formula = "K4(ON(SO3)2)2"
     * 输出: "K4N2O14S4"
     * 解释: 
     * 原子的数量是 {'K': 4, 'N': 2, 'O': 14, 'S': 4}。
     * 
     * 
     * 注意:
     * 所有原子的第一个字母为大写，剩余字母都是小写。
     * formula的长度在[1, 1000]之间。
     * formula只包含字母、数字和圆括号，并且题目中给定的是合法的化学式。
     */

    public class Solution726 : SolutionBase
    {
        /// <summary>
        /// 难度
        /// </summary>
        public override Difficulity GetDifficulity() { return Difficulity.Hard; }
        /// <summary>
        /// 关键字:
        /// </summary>
        public override string[] GetKeyWords() { return new string[] { "", }; }
        /// <summary>
        /// 标签：
        /// </summary>
        public override Tag[] GetTags() { return new Tag[] { Tag.HashTable, Tag.Stack, Tag.Recursion }; }

        public override bool Test(System.Diagnostics.Stopwatch sw)
        {
            bool isSuccess = true;
            string checkResult;
            string result;
            string s;

            s = "K4(ON(SO3)2)2";
            checkResult = "K4N2O14S4";
            result = CountOfAtoms(s);
            isSuccess &= checkResult == result;
            Print("isSuccess = {0} | result = {1} | anticipated = {2}", isSuccess, (result), (checkResult));

            s = "Mg(OH)2";
            checkResult = "H2MgO2";
            result = CountOfAtoms(s);
            isSuccess &= checkResult == result;
            Print("isSuccess = {0} | result = {1} | anticipated = {2}", isSuccess, (result), (checkResult));

            
            return isSuccess;
        }
        public String CountOfAtoms(String formula)
        {
            int N = formula.Length;
            Stack<Dictionary<String, int>> stack = new Stack<Dictionary<String, int>>();
            stack.Push(new Dictionary<String, int>());  //stack.Push(new TreeMap());

            for (int i = 0; i < N;)
            {
                if (formula[i] == '(')
                {
                    stack.Push(new Dictionary<String, int>()); ////stack.Push(new TreeMap());
                    i++;
                }
                else if (formula[i] == ')')
                {
                    Dictionary<String, int> top = stack.Pop();
                    int iStart = ++i, multiplicity = 1;
                    while (i < N && char.IsNumber(formula[i])) i++;
                    if (i > iStart) multiplicity = int.Parse(formula.Substring(iStart, i-iStart));
                    foreach (String c in top.Keys)
                    {
                        int v = top[c];
                        //stack.Peek().put(c, stack.Peek().getOrDefault(c, 0) + v * multiplicity);
                        stack.Peek()[c] = (stack.Peek().ContainsKey(c) ? stack.Peek()[c] :  0) + v * multiplicity;
                    }
                }
                else
                {
                    int iStart = i++;
                    while (i < N && char.IsLower(formula[i])) i++;
                    String name = formula.Substring(iStart, i- iStart);
                    iStart = i;
                    while (i < N && char.IsNumber(formula[i])) i++;
                    int multiplicity = i > iStart ? int.Parse(formula.Substring(iStart, i- iStart)) : 1;
                    //stack.Peek().put(name, stack.Peek().getOrDefault(name, 0) + multiplicity);
                    stack.Peek()[name] =  (stack.Peek().ContainsKey(name) ? stack.Peek()[name] :  0) + multiplicity;
                }
            }

            StringBuilder ans = new StringBuilder();

            List<string> names = new List<string>();
            
            foreach (String name in stack.Peek().Keys)
            {
                names.Add(name);
            }
            names.Sort();

            for (int i=0; i<names.Count; i++)
            {
                string name = names[i];
                int multiplicity = stack.Peek()[name];
                ans.Append(name);
                if (multiplicity > 1)
                    ans.Append("" + multiplicity);
                
            }
            return ans.ToString();
        }

        //作者：LeetCode
        //链接：https://leetcode-cn.com/problems/number-of-atoms/solution/yuan-zi-de-shu-liang-by-leetcode/

    }
}
