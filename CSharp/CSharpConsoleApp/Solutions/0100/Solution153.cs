using System;
namespace CSharpConsoleApp.Solutions
{
    /*
  * @lc app=leetcode.cn id=153 lang=csharp
  *
  * [153] 寻找旋转排序数组中的最小值
  *
  * https://leetcode-cn.com/problems/find-minimum-in-rotated-sorted-array/description/
  *
  * Category	Difficulty	Likes	Dislikes
  * algorithms	Medium (56.19%)	502	-
  * Tags
  * array | binary-search
  * 
  * Companies
  * microsoft
  * 
  * Total Accepted:    179.6K
  * Total Submissions: 319.7K
  * Testcase Example:  '[3,4,5,1,2]'
  *
  * 已知一个长度为 n 的数组，预先按照升序排列，经由 1 到 n 次 旋转 后，得到输入数组。例如，原数组 nums = [0,1,2,4,5,6,7]
  * 在变化后可能得到：
  * 
  * 若旋转 4 次，则可以得到 [4,5,6,7,0,1,2]
  * 若旋转 7 次，则可以得到 [0,1,2,4,5,6,7]
  *
  * 注意，数组 [a[0], a[1], a[2], ..., a[n-1]] 旋转一次 的结果为数组 [a[n-1], a[0], a[1], a[2],
  * ..., a[n-2]] 。
  * 给你一个元素值 互不相同 的数组 nums ，它原来是一个升序排列的数组，并按上述情形进行了多次旋转。请你找出并返回数组中的 最小元素 。
  *
  * 
  * 示例 1：
  * 输入：nums = [3,4,5,1,2]
  * 输出：1
  * 解释：原数组为 [1,2,3,4,5] ，旋转 3 次得到输入数组。
  * 
  * 
  * 示例 2：
  * 输入：nums = [4,5,6,7,0,1,2]
  * 输出：0
  * 解释：原数组为 [0,1,2,4,5,6,7] ，旋转 4 次得到输入数组。
  * 
  * 
  * 示例 3：
  * 输入：nums = [11,13,15,17]
  * 输出：11
  * 解释：原数组为 [11,13,15,17] ，旋转 4 次得到输入数组。
  * 
  * 
  * 提示：
  * n == nums.length
  * 1 <= n <= 5000
  * -5000 <= nums[i] <= 5000
  * nums 中的所有整数 互不相同
  * nums 原来是一个升序排序的数组，并进行了 1 至 n 次旋转
  */

    // @lc code=start
    public class Solution153 : SolutionBase
    {
        /// <summary>
        /// 难度
        /// </summary>
        public override Difficulity GetDifficulity() { return Difficulity.Medium; }
        /// <summary>
        /// 关键字:
        /// </summary>
        public override string[] GetKeyWords() { return new string[] { "" }; }
        /// <summary>
        /// 标签：
        /// </summary>
        public override Tag[] GetTags() { return new Tag[] { Tag.Tree }; }

        public const int N = int.MinValue;
        /// <summary>
        /// TODO  没理解
        /// 160/160 cases passed (124 ms)
        /// Your runtime beats 100 % of csharp submissions
        /// Your memory usage beats 88.89 % of csharp submissions(28.2 MB)
        /// </summary>
        /// <param name="sw"></param>
        /// <returns></returns>
        public override bool Test(System.Diagnostics.Stopwatch sw)
        {
            bool isSuccess = true;
            int[] pairs;
            int result, checkResult;

            checkResult = 2;
            pairs = new int[] { 1, 2 };

            result = FindMin(pairs);
            isSuccess &= IsSame(result, checkResult);
            PrintResult(isSuccess, result, checkResult);
            return isSuccess;
        }

        //作者：LeetCode-Solution
        //链接：https://leetcode-cn.com/problems/find-minimum-in-rotated-sorted-array/solution/xun-zhao-xuan-zhuan-pai-xu-shu-zu-zhong-5irwp/
        /// <summary>
        /// 150/150 cases passed (96 ms)
        /// Your runtime beats 99.02 % of csharp submissions
        /// Your memory usage beats 5.29 % of csharp submissions(24.9 MB)
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public int FindMin(int[] nums)
        {
            int low = 0;
            int high = nums.Length - 1;
            while (low < high)
            {
                int pivot = low + (high - low) / 2;
                if (nums[pivot] < nums[high])
                {
                    high = pivot;
                }
                else
                {
                    low = pivot + 1;
                }
            }
            return nums[low];
        }
    }
    // @lc code=end


}
