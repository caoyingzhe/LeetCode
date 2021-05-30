using System;
using System.Collections.Generic;
namespace CSharpConsoleApp.Solutions
{
    /*
     * @lc app=leetcode.cn id=581 lang=csharp
     *
     * [581] 最短无序连续子数组
     *
     * https://leetcode-cn.com/problems/shortest-unsorted-continuous-subarray/description/
     *
     * Category	Difficulty	Likes	Dislikes
     * algorithms	Medium (36.76%)	542	-
     * Tags
     * array
     * 
     * Companies
     * google
     * 
     * Total Accepted:    57.4K
     * Total Submissions: 156.2K
     * Testcase Example:  '[2,6,4,8,10,9,15]'
     *
     * 给你一个整数数组 nums ，你需要找出一个 连续子数组 ，如果对这个子数组进行升序排序，那么整个数组都会变为升序排序。
     * 
     * 请你找出符合题意的 最短 子数组，并输出它的长度。
     * 
     * 示例 1：
     * 输入：nums = [2,6,4,8,10,9,15]
     * 输出：5
     * 解释：你只需要对 [6, 4, 8, 10, 9] 进行升序排序，那么整个表都会变为升序排序。
     * 
     * 
     * 示例 2：
     * 输入：nums = [1,2,3,4]
     * 输出：0
     * 
     * 
     * 示例 3：
     * 输入：nums = [1]
     * 输出：0
     * 
     * 
     * 提示：
     * 1 <= nums.length <= 10^4
     * -10^5 <= nums[i] <= 10^5
     * 
     * 进阶：你可以设计一个时间复杂度为 O(n) 的解决方案吗？
     */
    public class Solution581 : SolutionBase
    {
        /// <summary>
        /// 难度
        /// </summary>
        public override Difficulity GetDifficulity() { return Difficulity.Medium; }
        /// <summary>
        /// 关键字:
        /// </summary>
        public override string[] GetKeyWords() { return new string[] { "自己完成", }; }
        /// <summary>
        /// 标签： 
        /// </summary>
        public override Tag[] GetTags() { return new Tag[] { Tag.Array}; }
        
        public override bool Test(System.Diagnostics.Stopwatch sw)
        {
            bool isSuccess = true;
            int[] nums;
            int result;
            int checkResult;
            
            //nums = new int[] { 2, 6, 4, 8, 10, 9, 15  };
            //checkResult = 5;
            //result = FindUnsortedSubarray(nums);
            //isSuccess &= result == checkResult;
            //Print("isSuccess = {0} | result = {1} | anticipated = {2}", isSuccess, result, checkResult);
            //
            //nums = new int[] { 1, 2, 3, 4 };
            //checkResult = 0;
            //result = FindUnsortedSubarray(nums);
            //isSuccess &= result == checkResult;
            //Print("isSuccess = {0} | result = {1} | anticipated = {2}", isSuccess, result, checkResult);

            nums = new int[] { 1 };
            checkResult = 0;
            result = FindUnsortedSubarray(nums);
            isSuccess &= result == checkResult;
            Print("isSuccess = {0} | result = {1} | anticipated = {2}", isSuccess, result, checkResult);

            return isSuccess;
        }

        /// 307/307 cases passed (204 ms)
        /// Your runtime beats 8.82 % of csharp submissions
        /// Your memory usage beats 50 % of csharp submissions(31.8 MB)
        public int FindUnsortedSubarray(int[] nums)
        {
            List<int> list = new List<int>(nums);
            list.Sort();

            int n = nums.Length;
            int L = 0; int R = n - 1;

            while(L<R)
            {
                if(list[L] != nums[L] && list[R] != nums[R]) break;
                if (list[L] == nums[L]) L++;
                if (list[R] == nums[R]) R--;
            }
            //Print(GetArrayStr(list.ToArray()));
            //Print("{0}|{1}", L, R);
            return (L >= R) ? 0 : R - L + 1;
        }
    }
}
