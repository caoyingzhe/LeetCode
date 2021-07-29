using System;
using System.Collections.Generic;

namespace CSharpConsoleApp.Solutions
{
    /*
     * @lc app=leetcode.cn id=507 lang=csharp
     *
     * [507] 完美数
     *
     * https://leetcode-cn.com/problems/perfect-number/description/
     *

     * Category	Difficulty	Likes	Dislikes
     * algorithms	Easy (40.45%)	90	-
     * Tags
     * math
     * 
     * Companies
     * Unknown
     * Total Accepted:    26.9K
     * Total Submissions: 66.5K
     * Testcase Example:  '28'
     *
     * 对于一个 正整数，如果它和除了它自身以外的所有 正因子 之和相等，我们称它为 「完美数」。
     * 
     * 给定一个 整数 n， 如果是完美数，返回 true，否则返回 false
     * 
     * 
     * 
     * 示例 1：
     * 
     * 输入：28
     * 输出：True
     * 解释：28 = 1 + 2 + 4 + 7 + 14
     * 1, 2, 4, 7, 和 14 是 28 的所有正因子。
     * 
     * 示例 2：
     * 输入：num = 6
     * 输出：true
     * 
     * 
     * 示例 3：
     * 输入：num = 496
     * 输出：true
     * 
     * 
     * 示例 4：
     * 输入：num = 8128
     * 输出：true
     * 
     * 
     * 示例 5：
     * 输入：num = 2
     * 输出：false
     * 
     * 
     * 提示：
     * 1 <= num <= 10^8
     */

    // @lc code=start
    public class Solution507 : SolutionBase
    {
        /// <summary>
        /// 难度
        /// </summary>
        public override Difficulity GetDifficulity() { return Difficulity.Easy; }
        /// <summary>
        /// 关键字:
        /// </summary>
        public override string[] GetKeyWords() { return new string[] { "完美数 : 2^(p−1)*(2^p−1)", "欧几里得-欧拉定理", "", }; }
        /// <summary>
        /// 标签：
        /// </summary>
        public override Tag[] GetTags() { return new Tag[] { Tag.Math }; }


        public override bool Test(System.Diagnostics.Stopwatch sw)
        {
            bool isSuccess = true;
            int s;
            bool result, checkResult;

            s = 28;
            checkResult = true;
            result = CheckPerfectNumber(s);
            isSuccess &= IsSame(result, checkResult);
            PrintResult(isSuccess, result, checkResult);


            s = 6;
            checkResult = true;
            result = CheckPerfectNumber(s);
            isSuccess &= IsSame(result, checkResult);
            PrintResult(isSuccess, result, checkResult);

            s = 496;
            checkResult = true;
            result = CheckPerfectNumber(s);
            isSuccess &= IsSame(result, checkResult);
            PrintResult(isSuccess, result, checkResult);

            //179/187 cases passed (N/A)
            //[2,-1,1,1]  asnwer = 2;

            s = 8128;
            checkResult = true;
            result = CheckPerfectNumber(s);
            isSuccess &= IsSame(result, checkResult);
            PrintResult(isSuccess, result, checkResult);

            s = 2;
            checkResult = false;
            result = CheckPerfectNumber(s);
            isSuccess &= IsSame(result, checkResult);
            PrintResult(isSuccess, result, checkResult);

            s = 1;
            checkResult = false;
            result = CheckPerfectNumber(s);
            isSuccess &= IsSame(result, checkResult);
            PrintResult(isSuccess, result, checkResult);

            //-2,0,-1
            return isSuccess;
        }

        public bool CheckPerfectNumber_TLE(int num)
        {
            if (num == 1) return false;

            List<int> factors = new List<int>();
            if (IsPrime2(num, factors))
                return false;
            else
            {
                int sum = 0;
                foreach (int factor in factors)
                    sum += factor;

                Print("sum ={0} | num ={1}", sum + 1, num);
                return sum + 1 == num;
            }
        }

        /// <summary>
        /// 98/98 cases passed (44 ms)
        /// Your runtime beats 79.41 % of csharp submissions
        /// Your memory usage beats 91.18 % of csharp submissions(14.8 MB)
        /// </summary>
        /// <param name="num"></param>
        /// <returns></returns>
        public bool CheckPerfectNumber1(int num)
        {
            if (num == 1) return false;

            int sum = 1;
            //避免TLE的关键 ：
            //1. 使用 i * i <= num 循环结束条件
            //2. 一次找到两个因数，找到一个因数后，通过除法计算同时找到另一个因数。
            for (int i = 2; i * i <= num; i++) //关键1. i * i <= num
            {
                if (num % i == 0)
                {
                    sum += i;
                    if (i * i != num)
                    {
                        sum += num / i; //关键2. sum += num / i;
                    }
                }
            }
            return sum == num;
        }

        /// <summary>
        /// Test1:
        ///     case 6:
        ///     case 28:
        ///     case 496:
        ///     case 8128:
        ///     case 33550336:
        /// 98/98 cases passed (40 ms)
        /// Your runtime beats 91.18 % of csharp submissions
        /// Your memory usage beats 38.23 % of csharp submissions(14.9 MB)
        ///
        /// Test2:
        ///     case 33550336:
        ///     case 8128:
        ///     case 496:
        ///     case 28:
        ///     case 6:
        /// 98/98 cases passed (48 ms)
        /// Your runtime beats 61.76 % of csharp submissions
        /// Your memory usage beats 97.06 % of csharp submissions(14.7 MB)
        /// </summary>
        /// <param name="num"></param>
        /// <returns></returns>
        public bool CheckPerfectNumber(int num)
        {
            switch(num)
            {
                case 33550336:
                case 8128:
                case 496:
                case 28:
                case 6:
                    return true;
                default:
                    return false;
            }
        }
    }
    // @lc code=end


}
