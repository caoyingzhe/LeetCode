using System;
namespace CSharpConsoleApp.Solutions
{
    /*
     * @lc app=leetcode.cn id=80 lang=csharp
     *
     * [80] 删除有序数组中的重复项 II
     *
     * https://leetcode-cn.com/problems/remove-duplicates-from-sorted-array-ii/description/
     *
     * Category	Difficulty	Likes	Dislikes
     * algorithms	Medium (61.24%)	526	-
     * Tags
     * array | two-pointers
     * 
     * Companies
     * facebook
     * 
     * Total Accepted:    132.4K
     * Total Submissions: 216.1K
     * Testcase Example:  '[1,1,1,2,2,3]'
     *
     * 给你一个有序数组 nums ，请你 原地 删除重复出现的元素，使每个元素 最多出现两次 ，返回删除后数组的新长度。
     * 
     * 不要使用额外的数组空间，你必须在 原地 修改输入数组 并在使用 O(1) 额外空间的条件下完成。
     * 
     * 说明：
     * 为什么返回数值是整数，但输出的答案是数组呢？
     * 请注意，输入数组是以「引用」方式传递的，这意味着在函数里修改输入数组对于调用者是可见的。
     * 你可以想象内部操作如下:
     * 
     * // nums 是以“引用”方式传递的。也就是说，不对实参做任何拷贝
     * int len = removeDuplicates(nums);
     * 
     * // 在函数里修改输入数组对于调用者是可见的。
     * // 根据你的函数返回的长度, 它会打印出数组中 该长度范围内 的所有元素。
     * for (int i = 0; i < len; i++) {
     * print(nums[i]);
     * }
     * 
     * 
     * 示例 1：
     * 输入：nums = [1,1,1,2,2,3]
     * 输出：5, nums = [1,1,2,2,3]
     * 解释：函数应返回新长度 length = 5, 并且原数组的前五个元素被修改为 1, 1, 2, 2, 3 。
     * 不需要考虑数组中超出新长度后面的元素。
     * 
     * 
     * 示例 2：
     * 输入：nums = [0,0,1,1,1,1,2,3,3]
     * 输出：7, nums = [0,0,1,1,2,3,3]
     * 解释：函数应返回新长度 length = 7, 并且原数组的前五个元素被修改为 0, 0, 1, 1, 2, 3, 3 。
     * 不需要考虑数组中超出新长度后面的元素。
     * 
     * 
     * 提示：
     * 1 <= nums.length <= 3 * 10^4
     * -10^4 <= nums[i] <= 10^4
     * nums 已按升序排列
     * 
     * 
     */
    public class Solution80 : SolutionBase
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
        public override Tag[] GetTags() { return new Tag[] { Tag.TwoPointers, Tag.Array }; }

        public override bool Test(System.Diagnostics.Stopwatch sw)
        {
            bool isSuccess = true;
            int[] nums; int result, checkResult;

            nums = new int[] { 1, 1, 1, 2, 2, 2, 2, 3, 3, 4, };
            checkResult = 7;
            result = RemoveDuplicates(nums);
            isSuccess &= result == checkResult;

            Print(GetArrayStr(nums));
            Print("isSuccess = {0} | result = {1} | anticipated = {2}", isSuccess, (result), (checkResult));

            //nums = new int[] { 1, 2 };
            //checkResult = 2;
            //result = RemoveDuplicates(nums);
            //isSuccess &= result == checkResult;

            //Print(GetArrayStr(nums));
            //Print("isSuccess = {0} | result = {1} | anticipated = {2}", isSuccess, (result), (checkResult));

            //nums = new int[] { 1 };
            //checkResult = 1;
            //result = RemoveDuplicates(nums);
            //isSuccess &= result == checkResult;

            //Print(GetArrayStr(nums));
            //Print("isSuccess = {0} | result = {1} | anticipated = {2}", isSuccess, (result), (checkResult));

            nums = new int[] { 1, 1, 1, 2, 2, 3 };
            checkResult = 5;
            result = RemoveDuplicates(nums);
            isSuccess &= result == checkResult;

            Print(GetArrayStr(nums));
            Print("isSuccess = {0} | result = {1} | anticipated = {2}", isSuccess, (result), (checkResult));

            return isSuccess;
        }

        /// <summary>
        /// 164/164 cases passed (292 ms)
        /// Your runtime beats 38.76 % of csharp submissions
        /// Your memory usage beats 5.14 % of csharp submissions(32.4 MB)
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public int RemoveDuplicates(int[] nums)
        {
            int n = nums.Length;
            if (n <= 2)
                return n;
            
            int len = n;
            int l = 1; int r = n - 1;

            int curr = nums[0];
            int currCount = 1;
            while(l<=r)
            {
                if(curr == nums[l])
                {
                    currCount++;
                    //Print("l={0}|r={1}|curr={2} | count = {3}", l, r, curr, currCount);

                    if (currCount >2)
                    {
                        //Print("Before l={0}|r={1}|{2}", l, r, GetArrayStr(nums));
                        for (int i=l; i<r; i++)
                        {
                            nums[i] = nums[i + 1];
                        }
                        nums[r] = curr;
                        //Print("After  l={0}|r={1}|{2}", l, r, GetArrayStr(nums));

                        r--;
                        currCount = 2;
                        len--;
                    }
                    else
                    {
                        l++;
                    }
                }
                else
                {

                    curr = nums[l];
                    currCount = 1;

                    //Print("currChanged l={0}|r={1}|curr={2} | count = {3}", l, r, curr, currCount);

                    l++;
                }
            }
            return len;
        }
    }
}
