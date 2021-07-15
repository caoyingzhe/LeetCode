using System;
using System.Collections.Generic;
namespace CSharpConsoleApp.Solutions
{
    /*
     * @lc app=leetcode.cn id=640 lang=csharp
     *
     * [640] 求解方程
     *
     * https://leetcode-cn.com/problems/solve-the-equation/description/
     *
     * Category	Difficulty	Likes	Dislikes
     * algorithms	Medium (42.13%)	74	-
     * Tags
     * math
     * 
     * Companies
     * amazon
     * Total Accepted:    9.7K
     * Total Submissions: 23K
     * Testcase Example:  '"x+5-3+x=6+x-2"'
     *
     * 求解一个给定的方程，将x以字符串"x=#value"的形式返回。该方程仅包含'+'，' - '操作，变量 x 和其对应系数。
     * 
     * 如果方程没有解，请返回“No solution”。
     * 如果方程有无限解，则返回“Infinite solutions”。
     * 如果方程中只有一个解，要保证返回值 x 是一个整数。
     * 
     * 示例 1：
     * 输入: "x+5-3+x=6+x-2"
     * 输出: "x=2"
     * 
     * 
     * 示例 2:
     * 输入: "x=x"
     * 输出: "Infinite solutions"
     * 
     * 
     * 示例 3:
     * 输入: "2x=x"
     * 输出: "x=0"
     * 
     * 
     * 示例 4:
     * 输入: "2x+3x-6x=x+2"
     * 输出: "x=-1"
     * 
     * 
     * 示例 5:
     * 输入: "x=x+2"
     * 输出: "No solution"
     */

    // @lc code=start
    public class Solution640 : SolutionBase
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
        public override Tag[] GetTags() { return new Tag[] { Tag.Tree }; }

        public const int NULL = int.MinValue;
        /// <summary>
        /// 160/160 cases passed (124 ms)
        /// Your runtime beats 100 % of csharp submissions
        /// Your memory usage beats 88.89 % of csharp submissions(28.2 MB)
        /// </summary>
        /// <param name="sw"></param>
        /// <returns></returns>
        public override bool Test(System.Diagnostics.Stopwatch sw)
        {
            bool isSuccess = true;
            string equation;
            string result, checkResult;

            //equation = "x+5-3+x=6+x-2"; checkResult = "x=2";
            //result = SolveEquation(equation);
            //isSuccess &= IsSame(result, checkResult);
            //PrintResult(isSuccess, result, checkResult);

            //equation = "x=x"; checkResult = "Infinite solutions";
            //result = SolveEquation(equation);
            //isSuccess &= IsSame(result, checkResult);
            //PrintResult(isSuccess, result, checkResult);

            //equation = "2x=x"; checkResult = "x=0";
            //result = SolveEquation(equation);
            //isSuccess &= IsSame(result, checkResult);
            //PrintResult(isSuccess, result, checkResult);

            //equation = "2x+3x-6x=x+2"; checkResult = "x=-1";
            //result = SolveEquation(equation);
            //isSuccess &= IsSame(result, checkResult);
            //PrintResult(isSuccess, result, checkResult);

            //equation = "x=x+2"; checkResult = "No solution";
            //result = SolveEquation(equation);
            //isSuccess &= IsSame(result, checkResult);
            //PrintResult(isSuccess, result, checkResult);

            //-x=-1-x=-1
            equation = "-x=-1"; checkResult = "x=1";
            result = SolveEquation(equation);
            isSuccess &= IsSame(result, checkResult);
            PrintResult(isSuccess, result, checkResult);

            return isSuccess;
        }

        /// <summary>
        /// 59/59 cases passed (116 ms)
        /// Your runtime beats 40 % of csharp submissions
        /// Your memory usage beats 100 % of csharp submissions(22.5 MB)
        /// </summary>
        /// <param name="equation"></param>
        /// <returns></returns>
        public string SolveEquation(string equation)
        {
            string[] LR = equation.Split('=');
            string[] arrL = LR[0].Replace("-", "+-").Split('+');
            string[] arrR = LR[1].Replace("-", "+-").Split('+');
            int xCount = 0;
            int val = 0;

            for (int i = 0; i < arrL.Length; i++)
            {
                if (string.IsNullOrEmpty(arrL[i])) continue; 
                if (arrL[i] == "x")
                    xCount += 1;
                else if (arrL[i] == "-x")
                    xCount += -1;
                else if (arrL[i][arrL[i].Length - 1] == 'x')
                    xCount += int.Parse(arrL[i].Substring(0, arrL[i].Length - 1));
                else
                {
                    val -= int.Parse(arrL[i]);
                }
            }
            for (int i = 0; i < arrR.Length; i++)
            {
                if (string.IsNullOrEmpty(arrR[i])) continue;
                if (arrR[i] == "x")
                    xCount -= 1;
                else if (arrR[i] == "-x")
                    xCount -= -1;
                else if (arrR[i][arrR[i].Length - 1] == 'x')
                    xCount -= int.Parse(arrR[i].Substring(0, arrR[i].Length - 1));
                else
                {
                    val += int.Parse(arrR[i]);
                }
            }
            if (xCount == 0)
            {
                if (val != 0)
                    return "No solution";
                else
                    return "Infinite solutions";
            }
            else
                return "x=" + val / xCount;
        }
    }
    // @lc code=end

}
