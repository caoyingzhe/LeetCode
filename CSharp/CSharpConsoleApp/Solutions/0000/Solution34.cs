using System;
namespace CSharpConsoleApp.Solutions
{
    /*
     * @lc app=leetcode.cn id=34 lang=csharp
     *
     * [34] 在排序数组中查找元素的第一个和最后一个位置
     *
     * https://leetcode-cn.com/problems/find-first-and-last-position-of-element-in-sorted-array/description/
     *
     * algorithms
     * Medium (42.44%)
     * Likes:    1006
     * Dislikes: 0
     * Total Accepted:    253.4K
     * Total Submissions: 597K
     * Testcase Example:  '[5,7,7,8,8,10]\n8'
     *
     * 给定一个按照升序排列的整数数组 nums，和一个目标值 target。找出给定目标值在数组中的开始位置和结束位置。
     * 
     * 如果数组中不存在目标值 target，返回 [-1, -1]。
     * 
     * 进阶：
     * 
     * 
     * 你可以设计并实现时间复杂度为 O(log n) 的算法解决此问题吗？
     * 
     * 示例 1：
     * 输入：nums = [5,7,7,8,8,10], target = 8
     * 输出：[3,4]
     * 
     * 示例 2：
     * 输入：nums = [5,7,7,8,8,10], target = 6
     * 输出：[-1,-1]
     * 
     * 示例 3：
     * 输入：nums = [], target = 0
     * 输出：[-1,-1]
     * 
     * 提示：
     * 0 
     * -10^9 
     * nums 是一个非递减数组
     * -10^9 
     * 
     * 
     */
    public class Solution34 : SolutionBase
    {
        /// <summary>
        /// 难易度:
        /// </summary>
        public override Difficulity GetDifficulity() { return Difficulity.Medium; }
        /// <summary>
        /// 关键字:
        /// </summary>
        public override string[] GetKeyWords() { return new string[] { "BinarySearch"}; }
        /// <summary>
        /// 标签： 图
        /// </summary>
        public override Tag[] GetTags() { return new Tag[] { Tag.BinarySearch}; }
        public override bool Test(System.Diagnostics.Stopwatch sw)
        {
            bool isSuccess = true;

            int[] result;

            result = SearchRange(new int[] { 5, 7, 7, 8, 8, 10 }, 8);
            Print(GetArrayStr(result));

            result = SearchRange(new int[] { 5, 7, 7, 8, 8, 10 }, 6);
            Print(GetArrayStr(result));

            result = SearchRange(new int[] { 0, 1, 2, 3, 4, 4, 4 }, 2);
            Print(GetArrayStr(result));

            result = SearchRange(new int[] { 1 }, 1);
            Print(GetArrayStr(result));

            result = SearchRange(new int[] { 1, 4 }, 4);
            Print(GetArrayStr(result));

            result = SearchRange(new int[] { 1, 4 }, 1);
            Print(GetArrayStr(result));

            result = SearchRange(new int[] { 1, 2, 3 }, 1);
            Print(GetArrayStr(result));

            result = SearchRange(new int[] { 1, 2, 3 }, 3);
            Print(GetArrayStr(result));

            result = SearchRange(new int[] { 2, 2 }, 2);
            Print(GetArrayStr(result));

            result = SearchRange(new int[] { 5, 7, 7, 8, 8, 10 }, 6);
            Print(GetArrayStr(result));

            return isSuccess;
        }
        public int[] SearchRange(int[] nums, int target)
        {
            int leftIdx = BinarySearch(nums, target, true);
            int rightIdx = BinarySearch(nums, target, false);
            return new int[] { leftIdx, rightIdx };
        }


        /// <summary>
        /// 88/88 cases passed (364 ms)
        /// Your runtime beats 5.8 % of csharp submissions
        /// Your memory usage beats 95.65 % of csharp submissions(31.6 MB)
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="target"></param>
        /// <param name="lower"></param>
        /// <returns></returns>
        public int BinarySearch_Slow(int[] nums, int target, bool lower)
        {
            int n = nums.Length;
            int L = 0;
            int R = n - 1;
            int mid = (L + R) / 2;
            int i = mid;

            while(L<=R)
            {
                if (nums[i] == target)
                {
                    int iNext = lower ? i - 1 : i + 1;
                    while(iNext >= 0 && iNext < n && nums[iNext] == target)
                    {
                        iNext += lower ? -1 : 1;
                    }
                    return lower ? iNext + 1 : iNext - 1;
                }
                else if(nums[i] > target) //左移
                {
                    R = i;
                    i = (L + R) / 2;
                    if (i == L)
                        return nums[i] == target ? i : -1;
                }
                else //if (nums[i] < target) //右移
                {
                    L = i;
                    i = (L + R+1) / 2;
                    if (i == R)
                        return nums[i] == target ? i : -1;
                }
            }
            
            return -1;
        }

        /// <summary>
        /// 88/88 cases passed (300 ms)
        /// Your runtime beats 37.32 % of csharp submissions
        /// Your memory usage beats 40.94 % of csharp submissions(31.9 MB)
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="target"></param>
        /// <param name="lower"></param>
        /// <returns></returns>
        public int BinarySearch2(int[] nums, int target, bool lower)
        {
            int n = nums.Length;
            int L = 0;
            int R = n - 1;
            int i = (L + R) / 2;
            int increment = lower ? -1 : 1;

            while (L <= R)
            {
                if (nums[i] == target)
                {
                    while (i >= 0 && i < n && nums[i] == target)
                    {
                        i += increment;
                    }
                    return i - increment;
                }
                else if (nums[i] > target) //左移
                {
                    R = i;
                    i = (L + R) / 2;
                    if (i == L)
                        return nums[i] == target ? i : -1;
                }
                else //if (nums[i] < target) //右移
                {
                    L = i;
                    i = (L + R + 1) / 2;
                    if (i == R)
                        return nums[i] == target ? i : -1;
                }
            }
            return -1;
        }

        /// <summary>
        /// 还是这个二分法最快
        /// 
        /// 88/88 cases passed (288 ms)
        /// Your runtime beats 74.64 % of csharp submissions
        /// Your memory usage beats 58.7 % of csharp submissions(31.9 MB)
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="target"></param>
        /// <param name="lower"></param>
        /// <returns></returns>
        public int BinarySearch(int[] nums, int target, bool lower)
        {
            int n = nums.Length;
            int L = 0;
            int R = n - 1;

            while (L <= R)
            {
                int mid = (L + R) / 2;
                //左移
                if ((lower && nums[mid] >= target)             
                           || nums[mid] >  target) 
                {
                    R = mid - 1;
                    n = mid;
                }
                //右移
                else
                {
                    L = mid + 1;
                }
            }
            n = lower ? n : n -1;  // 为什么要n-1是因为 lower = false时，n最后是第一个大于target的索引。
            return (n >= 0 && n < nums.Length && nums[n] == target) ? n : -1;
        }
    }
}
