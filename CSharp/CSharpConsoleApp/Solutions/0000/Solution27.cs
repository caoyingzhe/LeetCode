﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpConsoleApp.Solutions._0000
{
    /*
     * @lc app=leetcode.cn id=27 lang=csharp
     *
     * [27] 移除元素
     *
     * https://leetcode-cn.com/problems/remove-element/description/
     *
     * Category	Difficulty	Likes	Dislikes
     * algorithms	Easy (59.80%)	920	-
     * Tags
     * array | two-pointers
     * 
     * Companies
     * Unknown
     * Total Accepted:    389.8K
     * Total Submissions: 651.6K
     * Testcase Example:  '[3,2,2,3]\n3'
     *
     * 给你一个数组 nums 和一个值 val，你需要 原地 移除所有数值等于 val 的元素，并返回移除后数组的新长度。
     * 
     * 不要使用额外的数组空间，你必须仅使用 O(1) 额外空间并 原地 修改输入数组。
     * 
     * 元素的顺序可以改变。你不需要考虑数组中超出新长度后面的元素。
     * 
     * 
     * 说明:
     * 为什么返回数值是整数，但输出的答案是数组呢?
     * 请注意，输入数组是以「引用」方式传递的，这意味着在函数里修改输入数组对于调用者是可见的。
     * 
     * 你可以想象内部操作如下:
     * // nums 是以“引用”方式传递的。也就是说，不对实参作任何拷贝
     * int len = removeElement(nums, val);
     * 
     * // 在函数里修改输入数组对于调用者是可见的。
     * // 根据你的函数返回的长度, 它会打印出数组中 该长度范围内 的所有元素。
     * for (int i = 0; i < len; i++) {
     * print(nums[i]);
     * }
     * 
     * 
     * 示例 1：
     * 输入：nums = [3,2,2,3], val = 3
     * 输出：2, nums = [2,2]
     * 解释：函数应该返回新的长度 2, 并且 nums 中的前两个元素均为 2。你不需要考虑数组中超出新长度后面的元素。例如，函数返回的新长度为 2 ，而
     * nums = [2,2,3,3] 或 nums = [2,2,0,0]，也会被视作正确答案。
     * 
     * 示例 2：
     * 输入：nums = [0,1,2,2,3,0,4,2], val = 2
     * 输出：5, nums = [0,1,4,0,3]
     * 解释：函数应该返回新的长度 5, 并且 nums 中的前五个元素为 0, 1, 3, 0,
     * 4。注意这五个元素可为任意顺序。你不需要考虑数组中超出新长度后面的元素。
     * 
     * 提示：
     * 0 <= nums.length <= 100
     * 0 <= nums[i] <= 50
     * 0 <= val <= 100
     * 
     */
    class Solution27 : SolutionBase
    {
        public override bool Test(System.Diagnostics.Stopwatch sw)
        {
            int[] nums;
            int k;
            int result;
            int checkResult;
            int[] checkResultArr;
            bool isSuccess = true;
            //[2,2,3]
            //nums = new int[] { 3, 2, 2, 3 };
            //k = 3;
            //checkResult = 2;
            //checkResultArr = new int[] { 2, 2, };
            //result = RemoveElement(nums, k);
            //isSuccess &= result == checkResult;
            //isSuccess &= IsArraySame(nums, checkResultArr);
            //Print("isSuccess = {0} | resultCount = {1} result = {2} | anticipated = {3}", isSuccess, result, GetArrayStr<int>(nums), GetArrayStr<int>(checkResultArr));

            nums = new int[] { 3, 3 };
            k = 3;
            checkResult = 0;
            checkResultArr = new int[] { };
            result = RemoveElement(nums, k);
            isSuccess &= result == checkResult;
            isSuccess &= IsArraySame(nums, checkResultArr);
            Print("isSuccess = {0} | resultCount = {1} result = {2} | anticipated = {3}", isSuccess, result, GetArrayStr<int>(nums), GetArrayStr<int>(checkResultArr));

            //nums = new int[] { 0, 1, 2, 2, 3, 0, 4, 2 };
            //k = 2;
            //checkResult = 3;
            //checkResultArr = new int[] { 0, 1, 4, 0, 3 };
            //result = RemoveElement(nums, k);
            //isSuccess &= result == checkResult;
            //isSuccess &= IsArraySame(nums, checkResultArr);
            //Print("isSuccess = {0} | result = {1} | anticipated = {2}", isSuccess, GetArrayStr<int>(nums), GetArrayStr<int>(checkResultArr));

            return isSuccess;
        }

        public int RemoveElement(int[] nums, int val)
        {
            int n = nums.Length;
            int ri = n - 1;
            int li = 0; int j = n - 1;

            while (li < ri)
            {
                bool isLSame = nums[li] == val;
                bool isRSame = nums[ri] == val;

                int l = nums[li];
                int r = nums[ri];
                if (isLSame && !isRSame)
                {
                    //交换，只更新左侧索引递增，
                    nums[ri] = nums[li];
                    nums[li] = r;
                    li++;
                    ri--;
                }
                else if (!isLSame && isRSame)
                {
                    //不交换，更新左侧索引递增，右侧索引递减
                    li++;
                    ri--;
                }
                else if (isLSame && isRSame)
                {
                    //不交换，只更新右侧索引递减
                    ri--;
                }
                else
                {
                    li++;
                }
                //Print("" + (isLSame + "|" + isRSame) + " | L[{0}] = {1}, R[{2}] = {3}, nums={4}", li, l, ri, r, GetArrayStr(nums));
            }

            int count = 0;
            for (int i = 0; i < n; i++)
            {
                if (nums[i] == val)
                    break;
                count++;
            }
            return count;
        }
    }
}
