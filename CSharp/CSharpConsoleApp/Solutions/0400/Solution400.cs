using System;
namespace CSharpConsoleApp.Solutions
{
    /*
     * @lc app=leetcode.cn id=400 lang=csharp
     *
     * [400] 第 N 位数字
     *
     * https://leetcode-cn.com/problems/nth-digit/description/
     *
     * Category	Difficulty	Likes	Dislikes
     * algorithms	Medium (40.56%)	158	-
     * Tags
     * math
     * 
     * Companies
     * google
     * 
     * Total Accepted:    15.8K
     * Total Submissions: 38.8K
     * Testcase Example:  '3'
     *
     * 在无限的整数序列 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, ...中找到第 n 位数字。
     * 
     * 注意：n 是正数且在 32 位整数范围内（n < 2^31）。
     * 
     * 示例 1：
     * 输入：3
     * 输出：3
     * 
     * 示例 2：
     * 输入：11
     * 输出：0
     * 解释：第 11 位数字在序列 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, ... 里是 0 ，它是 10 的一部分。
     * 
     */
    public class Solution400 : SolutionBase
    {
        /// <summary>
        /// 难度
        /// </summary>
        public override Difficulity GetDifficulity() { return Difficulity.Medium; }
        /// <summary>
        /// 关键字:
        /// </summary>
        public override string[] GetKeyWords() { return new string[] { }; }
        /// <summary>
        /// 标签：
        /// </summary>
        public override Tag[] GetTags() { return new Tag[] { Tag.Math }; }

        public override bool Test(System.Diagnostics.Stopwatch sw)
        {
            bool isSuccess = true;
            int n;
            int result, checkResult;

            n = 3600;
            checkResult = 2;
            result = FindNthDigit(n);

            isSuccess &= checkResult == result;
            Print("isSuccess = {0} | result = {1} | anticipated = {2}", isSuccess, result, checkResult);

            return isSuccess;
        }

        //版权声明：本文为CSDN博主「学术状态抽奖器」的原创文章，
        //原文链接：https://blog.csdn.net/MebiuW/article/details/52575028

        /**
         * 这里是找第n个数字(这里的数和数字有区别，数字可以理解为将所有数拼合成一个字符串后的第n为对应的数字（0-9)）
         * 这里首先分析一下位数和规律
         * 个位数：1-9，一共9个,共计9个数字 = 1 * 9
         * 2位数：10-99,一共90个，共计180个数字 = 2 * 90
         * 3位数：100-999，一共900个，共计270个数字 =  3 * 900
         * 4位数，1000-9999，一共9000个，共计36000个数字 = 4 * 9000
         * 以此类推，
         * 这样我们就可以首先定位到是哪个数，再找到其对应的数字
         * */

        /// 71/71 cases passed (48 ms)
        /// Your runtime beats 43.75 % of csharp submissions
        /// Your memory usage beats 6.25 % of csharp submissions(15.2 MB)
        public int FindNthDigit(int n)
        {
            //小心溢出
            int digitType = 1;
            long digitNum = 9;
            //定位到是几位数
            while (n > digitNum * digitType)
            {
                n -= (int)digitNum * digitType;
                digitType++;
                digitNum *= 10;
            }
            //定位到是这些几位数里面的第几个的第几位
            int indexInSubRange = (n - 1) / digitType;
            int indexInNum = (n - 1) % digitType;
            //还原数字
            int num = (int)Math.Pow(10, digitType - 1) + indexInSubRange;
            int result = int.Parse(("" + num)[indexInNum] + "");

            //Print("n ={0} | indexInSubRange = {1} | indexInNum = {2} | num = {3} | digitType={4}  | digitNum = {5}",
            //    n, indexInSubRange, indexInNum, num, digitType, digitNum);
            return result;
        }
    }
}
