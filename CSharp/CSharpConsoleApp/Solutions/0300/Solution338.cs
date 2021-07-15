using System;
using System.Collections.Generic;
namespace CSharpConsoleApp.Solutions
{
    /*
     * @lc app=leetcode.cn id=338 lang=csharp
     *
     * [338] 比特位计数
     *
     * https://leetcode-cn.com/problems/counting-bits/description/
     *
     * Category	Difficulty	Likes	Dislikes
     * algorithms	Easy (78.81%)	761	-
     * Tags
     * dynamic-programming | bit-manipulation
     * 
     * Companies
     * Unknown
     * 
     * Total Accepted:    140.5K
     * Total Submissions: 178.3K
     * Testcase Example:  '2'
     *
     * 给定一个非负整数 num。对于 0 ≤ i ≤ num 范围中的每个数字 i ，计算其二进制数中的 1 的数目并将它们作为数组返回。
     * 
     * 示例 1:
     * 输入: 2
     * 输出: [0,1,1]
     * 
     * 示例 2:
     * 输入: 5
     * 输出: [0,1,1,2,1,2]
     * 
     * 进阶:
     * 给出时间复杂度为O(n*sizeof(integer))的解答非常容易。但你可以在线性时间O(n)内用一趟扫描做到吗？
     * 要求算法的空间复杂度为O(n)。
     * 你能进一步完善解法吗？要求在C++或任何其他语言中不使用任何内置函数（如 C++ 中的 __builtin_popcount）来执行此操作。
     */

    // @lc code=start
    public class Solution338 : SolutionBase
    {
        /// <summary>
        /// 难度
        /// </summary>
        public override Difficulity GetDifficulity() { return Difficulity.Easy; }
        /// <summary>
        /// 关键字:
        /// </summary>
        public override string[] GetKeyWords() { return new string[] {  }; }
        /// <summary>
        /// 标签：
        /// </summary>
        public override Tag[] GetTags() { return new Tag[] { Tag.DynamicProgramming, Tag.BitManipulation }; }

        public override bool Test(System.Diagnostics.Stopwatch sw)
        {
            bool isSuccess = true;
            int num;
            int[] result, checkResult;

            num = 5;
            checkResult = new int[] { 0, 1, 1, 2, 1, 2 };
            result = CountBits(num);

            isSuccess &= IsArraySame(result, checkResult);
            PrintResult(isSuccess, GetArrayStr(result), GetArrayStr(checkResult));
            return isSuccess;
        }

        /// <summary>
        /// 大于等于0， 不大于n 的 每个数字 i 的二进制中1的数量（数组[n]）
        /// </summary>
        /// <param name="num"></param>
        /// <returns></returns>
        public int[] CountBits(int num)
        {
            int[] result = new int[num + 1]; //vector<int> result(num+1);
            result[0] = 0;
            for (int i = 1; i <= num; i++)
            {
                if (i % 2 == 1)
                {
                    result[i] = result[i - 1] + 1;
                }
                else
                {
                    result[i] = result[i / 2];
                }
            }

            return result;
        }
    }
    // @lc code=end


}
