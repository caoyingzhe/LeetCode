using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpConsoleApp.Solutions
{
    /*
     * @lc app=leetcode.cn id=665 lang=csharp
     *
     * [665] 非递减数列
     *
     * https://leetcode-cn.com/problems/non-decreasing-array/description/
     *
     * algorithms
     * Easy (26.64%)
     * Likes:    573
     * Dislikes: 0
     * Total Accepted:    66.7K
     * Total Submissions: 250.4K
     * Testcase Example:  '[4,2,3]'
     *
     * 给你一个长度为 n 的整数数组，请你判断在 最多 改变 1 个元素的情况下，该数组能否变成一个非递减数列。
     * 
     * 我们是这样定义一个非递减数列的： 对于数组中任意的 i (0 ，总满足 nums[i] 。
     * 
     * 示例 1:
     * 输入: nums = [4,2,3]
     * 输出: true
     * 解释: 你可以通过把第一个4变成1来使得它成为一个非递减数列。
     * 
     * 
     * 示例 2:
     * 输入: nums = [4,2,1]
     * 输出: false
     * 解释: 你不能在只改变一个元素的情况下将其变为非递减数列。
     * 
     * 提示：
     * 1 <= n <= 10 ^ 4
     * - 10 ^ 5 <= nums[i] <= 10 ^ 5
     */
    class Solution665 : SolutionBase
    {
        /// <summary>
        /// 难度
        /// </summary>
        public override Difficulity GetDifficulity() { return Difficulity.Easy; }
        /// <summary>
        /// 关键字:
        /// </summary>
        public override string[] GetKeyWords() { return new string[] { "" }; }
        /// <summary>
        /// 标签： 
        /// </summary>
        public override Tag[] GetTags() { return new Tag[] { Tag.Array,}; }

        public override bool Test(System.Diagnostics.Stopwatch sw)
        {
            bool isSuccess = true;
            int[] nums;
            bool result;
            bool checkResult;

            //nums = new int[] { 4, 2, 3 };
            //checkResult = true;
            //result = CheckPossibility(nums);
            //isSuccess &= result == checkResult;
            //Print("result = {0} | checkResult = {1}", result, checkResult);
            //
            //nums = new int[] { 4, 2, 1 };
            //checkResult = false;
            //result = CheckPossibility(nums);
            //isSuccess &= result == checkResult;
            //Print("result = {0} | checkResult = {1}", result, checkResult);
            //
            nums = new int[] { 3, 4, 2, 3 };
            checkResult = false;
            result = CheckPossibility(nums);
            isSuccess &= result == checkResult;
            Print("result = {0} | checkResult = {1}", result, checkResult);

            nums = new int[] { 5, 7, 1, 8 };
            checkResult = true;
            result = CheckPossibility(nums);
            isSuccess &= result == checkResult;
            Print("result = {0} | checkResult = {1}", result, checkResult);

            //[1,2,4,5,3]
            nums = new int[] { -1, 4, 2, 3 };
            checkResult = true;
            result = CheckPossibility(nums);
            isSuccess &= result == checkResult;
            Print("result = {0} | checkResult = {1}", result, checkResult);


            nums = new int[] { 1, 2, 4, 5, 3 };
            checkResult = true;
            result = CheckPossibility(nums);
            isSuccess &= result == checkResult;
            Print("result = {0} | checkResult = {1}", result, checkResult);
            return isSuccess;
        }

        public bool CheckPossibility(int[] nums)
        {
            int count = 0;
            int firstIndex = -1;
            int n = nums.Length;
            for(int i=0; i<n-1; i++)
            {
                if(nums[i] > nums[i+1])
                {
                    count++;

                    if (count == 1)
                        firstIndex = i;
                }
            }

            if (count >= 2)
                return false;
            else if (count == 1)
            {
                if (n == 2 || firstIndex == 0)
                {
                    return true;
                }
                else 
                {
                    //开始位置和结束位置发生递减，直接替换首位就能解决问题，直接返回true。
                    if (firstIndex == 0 || firstIndex == n - 2)
                        return true;

                    int from = nums[firstIndex];
                    int to = nums[firstIndex + 1];
                    int l = (firstIndex >= 1) ? nums[firstIndex - 1] : from;
                    int r = (firstIndex + 2 <= n - 1) ? nums[firstIndex + 2] : to;

                    int replaceL = (l + to) / 2;
                    int replaceR = (from + r) / 2;

                    if (replaceL >= l && replaceL <= to)  //左侧替换可以解决
                        return true;
                    else if (replaceR >= from && replaceL <= r) //右侧替换可以解决
                        return true;
                    else
                        return false; //解决不了的  比如 [3, 4, 2]
                }
            }
            else //if (count == 0)
                return true;
            
        }
    }
}
