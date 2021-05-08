using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpConsoleApp.Solutions
{
    /*
    /// @lc app=leetcode.cn id=326 lang=csharp
    /// [326] 3的幂
    /// https://leetcode-cn.com/problems/power-of-three/description/
    /// algorithms
    /// Easy (48.29%)
    /// Likes:    161
    /// Dislikes: 0
    /// Total Accepted:    79.5K
    /// Total Submissions: 164.6K
    /// Testcase Example:  '27'
    /// 
    /// 给定一个整数，写一个函数来判断它是否是 3 的幂次方。如果是，返回 true ；否则，返回 false 。
    /// 
    /// 整数 n 是 3 的幂次方需满足：存在整数 x 使得 n == 3^x
    /// 
    /// 示例 1：
    /// 输入：n = 27
    /// 输出：true
    /// 示例 2：
    /// 输入：n = 0
    /// 输出：false
    /// 示例 3：
    /// 输入：n = 9
    /// 输出：true
    /// 示例 4：
    /// 输入：n = 45
    /// 输出：false
    /// 提示：
    /// -2^31 
    /// 进阶：
    /// 你能不使用循环或者递归来完成本题吗？
    */
    class Solution326 : SolutionBase
    {
        /// <summary>
        /// 难度
        /// </summary>
        public override Difficulity GetDifficulity() { return Difficulity.Easy; }
        /// <summary>
        /// 关键字:
        /// </summary>
        public override string[] GetKeyWords() { return new string[] { "3的幂", }; }
        /// <summary>
        /// 标签：
        /// </summary>
        public override Tag[] GetTags() { return new Tag[] { Tag.Math}; }

        public override bool Test(System.Diagnostics.Stopwatch sw)
        {
            bool isSuccess = true;
            int n;
            bool result;
            bool checkResult;

            n = (int) Math.Pow(3, 10);
            checkResult = true;
            result = IsPowerOfThree(n);
            isSuccess &= (checkResult == result);
            Print("isSuccess ={0} | result = {1} | checkResult = {2}", isSuccess, result, checkResult);
            return isSuccess;
        }

        /// <summary>
        /// 不砸地水平
        /// 21038/21038 cases passed (124 ms)
        /// Your runtime beats 21.21 % of csharp submissions
        /// Your memory usage beats 11.11 % of csharp submissions(17.4 MB)
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public bool IsPowerOfThree(int n)
        {
            if (n <= 0)
                return false;
            if (n == 1)
                return true;
            if (n % 2 == 0)
                return false;

            for(int i=0; i<int.MaxValue; i++)
            {
                double pow = Math.Pow(3, i);

                if (n == pow)
                    return true;

                if (pow > int.MaxValue)
                    return false;
            }
            return false;
        }
    }
}
