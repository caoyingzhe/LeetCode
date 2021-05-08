﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpConsoleApp.Solutions
{
    /*
    * @lc app=leetcode.cn id=1 lang=csharp
    *
    * [1] 两数之和
    *
    * 
    * Category	Difficulty	Likes	Dislikes
    * algorithms	Easy (50.71%)	10650	-
    * Tags
    * array | hash-table
    * 
    * Companies
    * adobe | airbnb | amazon | apple | bloomberg | dropbox | facebook | linkedin | microsoft | uber | yahoo | yelp
    * 
    * 给定一个整数数组 nums 和一个整数目标值 target，请你在该数组中找出 和为目标值 的那 两个 整数，并返回它们的数组下标。
    * 
    * 你可以假设每种输入只会对应一个答案。但是，数组中同一个元素在答案里不能重复出现。
    * 
    * 你可以按任意顺序返回答案。
    * 
    * 示例 1：
    * 输入：nums = [2,7,11,15], target = 9
    * 输出：[0,1]
    * 解释：因为 nums[0] + nums[1] == 9 ，返回 [0, 1] 。
    * 
    * 示例 2：
    * 输入：nums = [3,2,4], target = 6
    * 输出：[1,2]
    * 
    * 示例 3：
    * 输入：nums = [3,3], target = 6
    * 输出：[0,1]
    * 
    * 提示：
    * 2 <= nums.length <= 10^3
    * -10^9 <= nums[i] <= 10^9
    * -10^9 <= target <= 10^9
    * 只会存在一个有效答案
    */
    class Solution1 : SolutionBase
    {
        #region Test1 : TwoSum Easy
        public override bool Test(System.Diagnostics.Stopwatch sw)
        {
            int[] nums = { 0, 4, 3, 0 };
            int target = 0;

            int[] result = TwoSum(nums, target);

            System.Diagnostics.Debug.Print("Result = " + string.Join(",", result));

            return true;
        }

        /// <summary>
        /// Problem
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        public int[] TwoSum(int[] nums, int target)
        {
            Dictionary<int, int> dict = new Dictionary<int, int>();
            int[] result = new int[2];
            for (int i = 0; i < nums.Length; i++)
            {
                int num = nums[i];
                if (!dict.ContainsKey(num))
                    dict.Add(num, i);

                int diff = target - num;
                {
                    if (dict.ContainsKey(diff))
                    {
                        if (dict[diff] != i)
                        {
                            result[0] = dict[diff];
                            result[1] = i;
                            break;
                        }
                    }
                }

            }
            return result;
        }
        #endregion

    }
}
