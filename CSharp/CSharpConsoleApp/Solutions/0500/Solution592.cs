using System;
using System.Collections.Generic;
namespace CSharpConsoleApp.Solutions
{
    /*
     * @lc app=leetcode.cn id=592 lang=csharp
     *
     * [592] 分数加减运算
     *
     * https://leetcode-cn.com/problems/fraction-addition-and-subtraction/description/
     *
     * Category	Difficulty	Likes	Dislikes
     * algorithms	Medium (51.79%)	51	-
     * Tags
     * math
     * 
     * Companies
     * Unknown
     * 
     * Total Accepted:    4.1K
     * Total Submissions: 8K
     * Testcase Example:  '"-1/2+1/2"'
     *
     * 给定一个表示分数加减运算表达式的字符串，你需要返回一个字符串形式的计算结果。 这个结果应该是不可约分的分数，即最简分数。 如果最终结果是一个整数，例如
     * 2，你需要将它转换成分数形式，其分母为 1。所以在上述例子中, 2 应该被转换为 2/1。
     * 
     * 示例 1:
     * 输入:"-1/2+1/2"
     * 输出: "0/1"
     * 
     * 
     * 示例 2:
     * 输入:"-1/2+1/2+1/3"
     * 输出: "1/3"
     * 
     * 
     * 示例 3:
     * 输入:"1/3-1/2"
     * 输出: "-1/6"
     * 
     * 
     * 示例 4:
     * 输入:"5/3+1/3"
     * 输出: "2/1"
     * 
     * 
     * 说明:
     * 输入和输出字符串只包含 '0' 到 '9' 的数字，以及 '/', '+' 和 '-'。 
     * 输入和输出分数格式均为 ±分子/分母。如果输入的第一个分数或者输出的分数是正数，则 '+' 会被省略掉。
     * 输入只包含合法的最简分数，每个分数的分子与分母的范围是  [1,10]。 如果分母是1，意味着这个分数实际上是一个整数。
     * 输入的分数个数范围是 [1,10]。
     * 最终结果的分子与分母保证是 32 位整数范围内的有效整数。
     * 
     * 
     */

    // @lc code=start
    public class Solution592 : SolutionBase
    {
        /// <summary>
        /// 难度
        /// </summary>
        public override Difficulity GetDifficulity() { return Difficulity.Medium; }
        /// <summary>
        /// 关键字:
        /// </summary>
        public override string[] GetKeyWords() { return new string[] { "抄作业" }; }
        /// <summary>
        /// 标签：
        /// </summary>
        public override Tag[] GetTags() { return new Tag[] { Tag.Math }; }

        /// <summary>
        /// </summary>
        /// <param name="sw"></param>
        /// <returns></returns>
        public override bool Test(System.Diagnostics.Stopwatch sw)
        {
            bool isSuccess = true;
            //TODO
            return isSuccess;
        }

        /// <summary>
        /// 105/105 cases passed (80 ms)
        /// Your runtime beats 86.67 % of csharp submissions
        /// Your memory usage beats 40 % of csharp submissions(23.4 MB)
        /// </summary>
        /// <param name="expression"></param>
        /// <returns></returns>
        public string FractionAddition(string expression)
        {
            List<char> sign = new List<char>();
            for (int i = 1; i < expression.Length; i++)
            {
                if (expression[i] == '+' || expression[i] == '-')
                    sign.Add(expression[i]);
            }
            List<int> num = new List<int>();
            List<int> den = new List<int>();
            foreach (String sub in expression.Split('+'))
            {
                foreach (String subsub in sub.Split('-'))
                {
                    if (subsub.Length > 0)
                    {
                        String[] fraction = subsub.Split('/');
                        num.Add(int.Parse(fraction[0]));
                        den.Add(int.Parse(fraction[1]));
                    }
                }
            }
            if (expression[0] == '-')
                num[0] = -num[0];
            int lcm = 1;
            foreach (int x in den)
            {
                lcm = lcm_(lcm, x);
            }

            int res = lcm / den[0] * num[0];
            for (int i = 1; i < num.Count; i++)
            {
                if (sign[i - 1] == '+')
                    res += lcm / den[i] * num[i];
                else
                    res -= lcm / den[i] * num[i];
            }
            int g = GCD(Math.Abs(res), Math.Abs(lcm));
            return (res / g) + "/" + (lcm / g);
        }
        public int lcm_(int a, int b)
        {
            return a * b / GCD(a, b);
        }
        public int GCD(int a, int b)
        {
            while (b != 0)
            {
                int t = b;
                b = a % b;
                a = t;
            }
            return a;
        }

//        作者：LeetCode
//        链接：https://leetcode-cn.com/problems/fraction-addition-and-subtraction/solution/fen-shu-jia-jian-yun-suan-by-leetcode/
//来源：力扣（LeetCode）
//著作权归作者所有。商业转载请联系作者获得授权，非商业转载请注明出处。
    }
    // @lc code=end


}
