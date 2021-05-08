using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpConsoleApp.Solutions._0300
{
    /*
     * @lc app=leetcode.cn id=312 lang=csharp
     *
     * [312] 戳气球
     *
     * https://leetcode-cn.com/problems/burst-balloons/description/
     *
     * Category	Difficulty	Likes	Dislikes
     * algorithms	Hard (67.71%)	716	-
     * Tags
     * divide-and-conquer | dynamic-programming
     * 
     * Companies
     * google | snapchat
     * Total Accepted:    45.1K
     * Total Submissions: 66.5K
     * Testcase Example:  '[3,1,5,8]'
     *
     * 有 n 个气球，编号为0 到 n - 1，每个气球上都标有一个数字，这些数字存在数组 nums 中。
     * 
     * 现在要求你戳破所有的气球。戳破第 i 个气球，你可以获得 nums[i - 1] * nums[i] * nums[i + 1] 枚硬币。 这里的 i
     * - 1 和 i + 1 代表和 i 相邻的两个气球的序号。如果 i - 1或 i + 1 超出了数组的边界，那么就当它是一个数字为 1 的气球。
     * 
     * 求所能获得硬币的最大数量。
     * 
     * 示例 1：x
     * 输入：nums = [3,1,5,8]
     * 输出：167
     * 解释：
     * nums = [3,1,5,8] --> [3,5,8] --> [3,8] --> [8] --> []
     * coins =  3*1*5    +   3*5*8   +  1*3*8  + 1*8*1 = 167
     * 
     * 示例 2：
     * 输入：nums = [1,5]
     * 输出：10
     * 
     * 提示：
     * n == nums.length
     * 1 <= n <= 500
     * 0 <= nums[i] <= 100
     */
    class Solution312 : SolutionBase
    {
        /// <summary>
        /// 难度
        /// </summary>
        public override Difficulity GetDifficulity() { return Difficulity.Hard; }
        /// <summary>
        /// 关键字:
        /// </summary>
        public override string[] GetKeyWords() { return new string[] { "动态编程", }; }
        /// <summary>
        /// 标签：
        /// </summary>
        public override Tag[] GetTags() { return new Tag[] { Tag.DivideAndConquer, Tag.DynamicProgramming }; }

        public override bool Test(System.Diagnostics.Stopwatch sw)
        {
            bool isSuccess = true;

            isSuccess &= maxCoins(new int[] { 3, 1, 5, 8 }) == 167;
            return isSuccess;
        }

        /// <summary>
        /// 作者：LeetCode-Solution
        /// 链接：https://leetcode-cn.com/problems/burst-balloons/solution/chuo-qi-qiu-by-leetcode-solution/
        /// 
        /// 动态编程过程  一目了然
        /// 输入: [3, 1, 5, 8]
        /// 输出: 
        /// -------- Test Problem[312] Solution312 --------
        /// i=3|j=5|k=4| sum =  40 = | rec[3, 4] (   0) + rec[4, 5] (   0) | + | val[3] * val[4] * val[5] = 5*8*1 =   40| | rec[3, 5] =    0 =>   40
        /// i=2|j=4|k=3| sum =  40 = | rec[2, 3] (   0) + rec[3, 4] (   0) | + | val[2] * val[3] * val[4] = 1*5*8 =   40| | rec[2, 4] =    0 =>   40
        /// i=2|j=5|k=3| sum =  45 = | rec[2, 3] (   0) + rec[3, 5] (  40) | + | val[2] * val[3] * val[5] = 1*5*1 =    5| | rec[2, 5] =    0 =>   45
        /// i=2|j=5|k=4| sum =  48 = | rec[2, 4] (  40) + rec[4, 5] (   0) | + | val[2] * val[4] * val[5] = 1*8*1 =    8| | rec[2, 5] =   45 =>   48
        /// i=1|j=3|k=2| sum =  15 = | rec[1, 2] (   0) + rec[2, 3] (   0) | + | val[1] * val[2] * val[3] = 3*1*5 =   15| | rec[1, 3] =    0 =>   15
        /// i=1|j=4|k=2| sum =  64 = | rec[1, 2] (   0) + rec[2, 4] (  40) | + | val[1] * val[2] * val[4] = 3*1*8 =   24| | rec[1, 4] =    0 =>   64
        /// i=1|j=4|k=3| sum = 135 = | rec[1, 3] (  15) + rec[3, 4] (   0) | + | val[1] * val[3] * val[4] = 3*5*8 =  120| | rec[1, 4] =   64 =>  135
        /// i=1|j=5|k=2| sum =  51 = | rec[1, 2] (   0) + rec[2, 5] (  48) | + | val[1] * val[2] * val[5] = 3*1*1 =    3| | rec[1, 5] =    0 =>   51
        /// i=1|j=5|k=3| sum =  70 = | rec[1, 3] (  15) + rec[3, 5] (  40) | + | val[1] * val[3] * val[5] = 3*5*1 =   15| | rec[1, 5] =   51 =>   70
        /// i=1|j=5|k=4| sum = 159 = | rec[1, 4] ( 135) + rec[4, 5] (   0) | + | val[1] * val[4] * val[5] = 3*8*1 =   24| | rec[1, 5] =   70 =>  159
        /// i=0|j=2|k=1| sum =   3 = | rec[0, 1] (   0) + rec[1, 2] (   0) | + | val[0] * val[1] * val[2] = 1*3*1 =    3| | rec[0, 2] =    0 =>    3
        /// i=0|j=3|k=1| sum =  30 = | rec[0, 1] (   0) + rec[1, 3] (  15) | + | val[0] * val[1] * val[3] = 1*3*5 =   15| | rec[0, 3] =    0 =>   30
        /// i=0|j=3|k=2| sum =   8 = | rec[0, 2] (   3) + rec[2, 3] (   0) | + | val[0] * val[2] * val[3] = 1*1*5 =    5| | rec[0, 3] =   30 =>   30
        /// i=0|j=4|k=1| sum = 159 = | rec[0, 1] (   0) + rec[1, 4] ( 135) | + | val[0] * val[1] * val[4] = 1*3*8 =   24| | rec[0, 4] =    0 =>  159
        /// i=0|j=4|k=2| sum =  51 = | rec[0, 2] (   3) + rec[2, 4] (  40) | + | val[0] * val[2] * val[4] = 1*1*8 =    8| | rec[0, 4] =  159 =>  159
        /// i=0|j=4|k=3| sum =  70 = | rec[0, 3] (  30) + rec[3, 4] (   0) | + | val[0] * val[3] * val[4] = 1*5*8 =   40| | rec[0, 4] =  159 =>  159
        /// i=0|j=5|k=1| sum = 162 = | rec[0, 1] (   0) + rec[1, 5] ( 159) | + | val[0] * val[1] * val[5] = 1*3*1 =    3| | rec[0, 5] =    0 =>  162
        /// i=0|j=5|k=2| sum =  52 = | rec[0, 2] (   3) + rec[2, 5] (  48) | + | val[0] * val[2] * val[5] = 1*1*1 =    1| | rec[0, 5] =  162 =>  162
        /// i=0|j=5|k=3| sum =  75 = | rec[0, 3] (  30) + rec[3, 5] (  40) | + | val[0] * val[3] * val[5] = 1*5*1 =    5| | rec[0, 5] =  162 =>  162
        /// i=0|j=5|k=4| sum = 167 = | rec[0, 4] ( 159) + rec[4, 5] (   0) | + | val[0] * val[4] * val[5] = 1*8*1 =    8| | rec[0, 5] =  162 =>  167
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public int maxCoins(int[] nums)
        {
            int n = nums.Length;
            //n+2的意义： 边缘的数字为1，所以左右两侧各添加一个1，数组长度+2 = n+2;
            int[] val = new int[n + 2];
            val[0] = val[n + 1] = 1;
            for (int i = 1; i <= n; i++)
            {
                val[i] = nums[i - 1];
            }
            //DP数组
            int[,] rec = new int[n + 2, n + 2];

            //倒序 n-1 => 0
            for (int i = n - 1; i >= 0; i--)
            {
                //正序 i+2 => n+1
                for (int j = i + 2; j <= n + 1; j++)
                {
                    //正序 i+1 => j
                    for (int k = i + 1; k < j; k++)
                    {
                        int sum = val[i] * val[k] * val[j];
                        sum += rec[i,k] + rec[k,j];
                        Print("i={0}|j={1}|k={2}| sum ={3} = | rec[{0},{2}]({4}) + rec[{2},{1}]({5}) | + " +
                            "| val[{0}] * val[{2}] * val[{1}] = {8}*{9}*{10} = {11}| " +
                            "| rec[{0},{1}] = {6} => {7}",
                            i, j, k, 
                            sum.ToString().PadLeft(4), 
                            rec[i, k].ToString().PadLeft(4), 
                            rec[k, j].ToString().PadLeft(4), 
                            rec[i, j].ToString().PadLeft(4),
                            Math.Max(rec[i, j], sum).ToString().PadLeft(4),
                            val[i] , val[k] , val[j],
                            (val[i] * val[k] * val[j]).ToString().PadLeft(4));

                        rec[i,j] = Math.Max(rec[i,j], sum);
                    }
                }
            }
            return rec[0,n + 1];
        }
    }
}
