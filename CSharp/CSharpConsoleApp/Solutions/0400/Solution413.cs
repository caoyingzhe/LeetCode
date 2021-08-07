using System;
using System.Collections.Generic;
namespace CSharpConsoleApp.Solutions
{
    /*
     * @lc app=leetcode.cn id=413 lang=csharp
     *
     * [413] 等差数列划分
     *
     * https://leetcode-cn.com/problems/arithmetic-slices/description/
     *
     * Category	Difficulty	Likes	Dislikes
     * algorithms	Medium (65.36%)	242	-
     * Tags
     * math | dynamic-programming
     * 
     * Companies
     * baidu
     * 
     * Total Accepted:    31.9K
     * Total Submissions: 48.8K
     * Testcase Example:  '[1,2,3,4]'
     *
     * 如果一个数列至少有三个元素，并且任意两个相邻元素之差相同，则称该数列为等差数列。
     * 
     * 例如，以下数列为等差数列:
     * 1, 3, 5, 7, 9
     * 7, 7, 7, 7
     * 3, -1, -5, -9
     * 
     * 以下数列不是等差数列。
     * 1, 1, 2, 5, 7
     * 
     * 数组 A 包含 N 个数，且索引从0开始。数组 A 的一个子数组划分为数组 (P, Q)，P 与 Q 是整数且满足 0<=P<Q<N 。
     * 如果满足以下条件，则称子数组(P, Q)为等差数组：
     * 元素 A[P], A[p + 1], ..., A[Q - 1], A[Q] 是等差的。并且 P + 1 < Q 。
     * 函数要返回数组 A 中所有为等差数组的子数组个数。
     * 
     * 示例:
     * A = [1, 2, 3, 4]
     * 返回: 3, A 中有三个子等差数组: [1, 2, 3], [2, 3, 4] 以及自身 [1, 2, 3, 4]。
     */
    public class Solution413 : SolutionBase
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
        public override Tag[] GetTags() { return new Tag[] { Tag.Math, Tag.DynamicProgramming, }; }

        public override bool Test(System.Diagnostics.Stopwatch sw)
        {
            bool isSuccess = true;
            int[] nums;
            int result, checkResult;

            nums = new int[] { 1, 2, 3, 4, 7, 8, 9 };
            checkResult = 4;
            result = NumberOfArithmeticSlices(nums);
            isSuccess &= checkResult == result;
            Print("isSuccess = {0} | result = {1} | anticipated = {2}", isSuccess, (result), (checkResult));

            nums = new int[] { 1, 2, 3 };
            checkResult = 1;
            result = NumberOfArithmeticSlices(nums);
            isSuccess &= checkResult == result;
            Print("isSuccess = {0} | result = {1} | anticipated = {2}", isSuccess, (result), (checkResult));

            return isSuccess;
        }

        /// <summary>
        /// 15/15 cases passed (100 ms)
        /// Your runtime beats 92.11 % of csharp submissions
        /// Your memory usage beats 42.1 % of csharp submissions(24 MB)
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public int NumberOfArithmeticSlices(int[] nums)
        {
            //List<int> list = new List<int>(nums);
            //对一个N（N>3)长的等差数组，有存在 (N^2-3N+2)/2 个组合；
            //所以求出所有N长等差数组即可。
            int n = nums.Length;
            if (n <= 2)
                return 0;
            int count = 0;
            int start = -1;
            int i = 0;
            while (i < n - 2)
            {
                bool isOK = nums[i] + nums[i + 2] == nums[i + 1] * 2;
                if (start == -1)
                {
                    if (isOK)
                    {
                        start = i;
                        if (i == n - 3)
                        {
                            int end = i + 2;
                            int N = end - start + 1;
                            count += (N * N - 3 * N + 2) / 2;
                            //Print(GetArrayStr(list.GetRange(start, N)));
                            break;
                        }
                    }

                }
                else
                {
                    if (!isOK)
                    {
                        int end = i + 1;
                        int N = end - start + 1;
                        count += (N * N - 3 * N + 2) / 2;
                        //Print(GetArrayStr(list.GetRange(start, N)));
                        start = -1;
                    }
                    else if (i == n - 3)
                    {
                        int end = i + 2;
                        int N = end - start + 1;
                        count += (N * N - 3 * N + 2) / 2;
                        //Print(GetArrayStr(list.GetRange(start, N)));
                        break;
                    }
                }
                i++;
            }
            return count;
        }
    }
}
