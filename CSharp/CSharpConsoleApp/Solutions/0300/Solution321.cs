using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpConsoleApp.Solutions._0300
{
    /*
     * @lc app=leetcode.cn id=321 lang=csharp
     *
     * [321] 拼接最大数
     *
     * https://leetcode-cn.com/problems/create-maximum-number/description/
     *
     * Category	Difficulty	Likes	Dislikes
     * algorithms	Hard (42.69%)	377	-
     * Tags
     * dynamic-programming | greedy
     * 
     * Companies
     * google
     * 
     * 给定长度分
     * Total Accepted:    23.9K
     * Total Submissions: 56K
     * Testcase Example:  '[3,4,6,5]\n[9,1,2,5,8,3]\n5'
     *
     * 给定长度分别为 m 和 n 的两个数组，其元素由 0-9 构成，表示两个自然数各位上的数字。现在从这两个数组中选出 k (k <= m + n)
     * 个数字拼接成一个新的数，要求从同一个数组中取出的数字保持其在原数组中的相对顺序。
     * 
     * 求满足该条件的最大数。结果返回一个表示该最大数的长度为 k 的数组。
     * 
     * 说明: 请尽可能地优化你算法的时间和空间复杂度。
     * 
     * 示例 1:
     * 
     * 输入:
     * nums1 = [3, 4, 6, 5]
     * nums2 = [9, 1, 2, 5, 8, 3]
     * k = 5
     * 输出:
     * [9, 8, 6, 5, 3]
     * 
     * 示例 2:
     * 
     * 输入:
     * nums1 = [6, 7]
     * nums2 = [6, 0, 4]
     * k = 5
     * 输出:
     * [6, 7, 6, 0, 4]
     * 
     * 示例 3:
     * 
     * 输入:
     * nums1 = [3, 9]
     * nums2 = [8, 9]
     * k = 3
     * 输出:
     * [9, 8, 9]
     * 
     */

    class Solution321 : SolutionBase
    {
        /// <summary>
        /// 难度
        /// </summary>
        public override Difficulity GetDifficulity() { return Difficulity.Hard; }
        /// <summary>
        /// 关键字:
        /// </summary>
        public override string[] GetKeyWords() { return new string[] { "优先队列（堆）", }; }
        /// <summary>
        /// 标签：
        /// </summary>
        public override Tag[] GetTags() { return new Tag[] { Tag.DynamicProgramming, Tag.Greedy }; }
        public override bool Test(System.Diagnostics.Stopwatch sw)
        {
            bool isSuccess = true;

            int[] nums1 = new int[] { };
            int[] nums2 = new int[] { };
            int k;
            int[] result;
            int[] checkResult;

            nums1 = new int[] { 3, 4, 6, 5 };
            nums2 = new int[] { 9, 1, 2, 5, 8, 3 };
            k = 5;
            checkResult = new int[] { 9, 8, 6, 5, 3 };
            result = MaxNumber(nums1, nums2, k);
            isSuccess &= IsArraySame(result.ToArray(), checkResult);
            Print("isSuccess = {0} | result = {1} | anticipated = {2}", isSuccess, GetArrayStr<int>(result), GetArrayStr<int>(checkResult));
            
            return isSuccess;
        }
        /// <summary>
        /// 作者：LeetCode-Solution
        /// 链接：https://leetcode-cn.com/problems/create-maximum-number/solution/pin-jie-zui-da-shu-by-leetcode-solution/
        /// 
        /// 链接：https://leetcode-cn.com/problems/remove-duplicate-letters/solution/yi-zhao-chi-bian-li-kou-si-dao-ti-ma-ma-zai-ye-b-4/
        /// </summary>
        /// <param name="nums1"></param>
        /// <param name="nums2"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public int[] MaxNumber(int[] nums1, int[] nums2, int k)
        {
            int m = nums1.Length, n = nums2.Length;
            int[] maxSubsequence = new int[k];
            int start = Math.Max(0, k - n), end = Math.Min(k, m);
            for (int i = start; i <= end; i++)
            {
                int[] subsequence1 = MaxSubsequence(nums1, i);
                int[] subsequence2 = MaxSubsequence(nums2, k - i);
                int[] curMaxSubsequence = Merge(subsequence1, subsequence2);
                if (Compare(curMaxSubsequence, 0, maxSubsequence, 0) > 0)
                {
                    //System.arraycopy(curMaxSubsequence, 0, maxSubsequence, 0, k); 
                    //Java System.arraycopy(src, srcPos, dest, destPos, length);
                    Array.Copy(curMaxSubsequence, maxSubsequence, k);
                }
            }
            return maxSubsequence;
        }

        public int[] MaxSubsequence(int[] nums, int k)
        {
            int length = nums.Length;
            int[] stack = new int[k];
            int top = -1;
            int remain = length - k;
            for (int i = 0; i < length; i++)
            {
                int num = nums[i];
                while (top >= 0 && stack[top] < num && remain > 0)
                {
                    top--;
                    remain--;
                }
                if (top < k - 1)
                {
                    stack[++top] = num;
                }
                else
                {
                    remain--;
                }
            }
            return stack;
        }

        public int[] Merge(int[] subsequence1, int[] subsequence2)
        {
            int x = subsequence1.Length, y = subsequence2.Length;
            if (x == 0)
            {
                return subsequence2;
            }
            if (y == 0)
            {
                return subsequence1;
            }
            int mergeLength = x + y;
            int[] merged = new int[mergeLength];
            int index1 = 0, index2 = 0;
            for (int i = 0; i < mergeLength; i++)
            {
                if (Compare(subsequence1, index1, subsequence2, index2) > 0)
                {
                    merged[i] = subsequence1[index1++];
                }
                else
                {
                    merged[i] = subsequence2[index2++];
                }
            }
            return merged;
        }

        public int Compare(int[] subsequence1, int index1, int[] subsequence2, int index2)
        {
            int x = subsequence1.Length, y = subsequence2.Length;
            while (index1 < x && index2 < y)
            {
                int difference = subsequence1[index1] - subsequence2[index2];
                if (difference != 0)
                {
                    return difference;
                }
                index1++;
                index2++;
            }
            return (x - index1) - (y - index2);
        }
    }
}
