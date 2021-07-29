using System;
namespace CSharpConsoleApp.Solutions
{
    /*
     * @lc app=leetcode.cn id=476 lang=csharp
     *
     * [476] 数字的补数
     *
     * https://leetcode-cn.com/problems/number-complement/description/
     *
     * Category	Difficulty	Likes	Dislikes
     * algorithms	Easy (69.95%)	215	-
     * Tags
     * bit-manipulation
     * 
     * Companies
     * Unknown
     * 
     * Total Accepted:    35.6K
     * Total Submissions: 50.9K
     * Testcase Example:  '5'
     *
     * 给你一个 正 整数 num ，输出它的补数。补数是对该数的二进制表示取反。
     * 
     * 
     * 示例 1：
     * 输入：num = 5
     * 输出：2
     * 解释：5 的二进制表示为 101（没有前导零位），其补数为 010。所以你需要输出 2 。
     * 
     * 
     * 示例 2：
     * 输入：num = 1
     * 输出：0
     * 解释：1 的二进制表示为 1（没有前导零位），其补数为 0。所以你需要输出 0 。
     * 
     * 
     * 提示：
     * 给定的整数 num 保证在 32 位带符号整数的范围内。
     * num >= 1
     * 你可以假定二进制数不包含前导零位。
     * 本题与 1009 https://leetcode-cn.com/problems/complement-of-base-10-integer/ 相同
     */

    // @lc code=start
    public class Solution476 : SolutionBase
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
        public override Tag[] GetTags() { return new Tag[] { Tag.BitManipulation }; }

        
        public override bool Test(System.Diagnostics.Stopwatch sw)
        {
            bool isSuccess = true;
            int a;
            int result, checkResult;

            a = 5;
            checkResult = 2;
            result = FindComplement(a);
            isSuccess &= IsSame(result, checkResult);
            PrintResult(isSuccess, (result).ToString(), (checkResult).ToString());

            a = 7; //111
            checkResult = 0; //
            result = FindComplement(a);
            isSuccess &= IsSame(result, checkResult);
            PrintResult(isSuccess, (result).ToString(), (checkResult).ToString());

            a = 8; //1000
            checkResult = 7; //
            result = FindComplement(a);
            isSuccess &= IsSame(result, checkResult);
            PrintResult(isSuccess, (result).ToString(), (checkResult).ToString());

            a = 2;
            checkResult = 1;
            result = FindComplement(a);
            isSuccess &= IsSame(result, checkResult);
            PrintResult(isSuccess, (result).ToString(), (checkResult).ToString());

            return isSuccess;
        }

        /// <summary>
        /// 149/149 cases passed (32 ms)
        /// Your runtime beats 97.3 % of csharp submissions
        /// Your memory usage beats 18.92 % of csharp submissions(15.1 MB)
        /// </summary>
        /// <param name="num"></param>
        /// <returns></returns>
        public int FindComplement(int num)
        {
            return num ^ (int)Math.Pow(2, Convert.ToString(num, 2).Length) - 1;
        }
    }
    // @lc code=end


}
