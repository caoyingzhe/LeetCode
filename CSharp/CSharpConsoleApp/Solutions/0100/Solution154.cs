using System;
namespace CSharpConsoleApp.Solutions
{
    /*
     * @lc app=leetcode.cn id=154 lang=csharp
     *
     * [154] 寻找旋转排序数组中的最小值 II
     *
     * https://leetcode-cn.com/problems/find-minimum-in-rotated-sorted-array-ii/description/
     *
     * Category	Difficulty	Likes	Dislikes
     * algorithms	Hard (53.15%)	377	-
     * Tags
     * array | binary-search
     * 
     * Companies
     * Unknown
     * 
     * Total Accepted:    101.6K
     * Total Submissions: 191.2K
     * Testcase Example:  '[1,3,5]'
     *
     * 已知一个长度为 n 的数组，预先按照升序排列，经由 1 到 n 次 旋转 后，得到输入数组。
     * 例如，原数组 nums = [0,1,4,4,5,6,7] 在变化后可能得到：
     * 
     * 若旋转 4 次，则可以得到 [4,5,6,7,0,1,4]
     * 若旋转 7 次，则可以得到 [0,1,4,4,5,6,7]
     * 
     * 注意，数组 [a[0], a[1], a[2], ..., a[n-1]] 旋转一次 的结果为数组 [a[n-1], a[0], a[1], a[2],
     * ..., a[n-2]] 。
     * 
     * 给你一个可能存在 重复 元素值的数组 nums ，它原来是一个升序排列的数组，并按上述情形进行了多次旋转。请你找出并返回数组中的 最小元素 。
     * 
     * 
     * 示例 1：
     * 输入：nums = [1,3,5]
     * 输出：1
     * 
     * 
     * 示例 2：
     * 输入：nums = [2,2,2,0,1]
     * 输出：0
     * 
     * 
     * 提示：
     * n == nums.length
     * 1 <= n <= 5000
     * -5000 <= nums[i] <= 5000
     * nums 原来是一个升序排序的数组，并进行了 1 至 n 次旋转
     * 
     * 
     * 进阶：
     * 这道题是 寻找旋转排序数组中的最小值 的延伸题目。
     * 允许重复会影响算法的时间复杂度吗？会如何影响，为什么？
     */

    // @lc code=start
    public class Solution154 : SolutionBase
    {
        /// <summary>
        /// 难度
        /// </summary>
        public override Difficulity GetDifficulity() { return Difficulity.Hard; }
        /// <summary>
        /// 关键字:
        /// </summary>
        public override string[] GetKeyWords() { return new string[] { }; }
        /// <summary>
        /// 标签：
        /// </summary>
        public override Tag[] GetTags() { return new Tag[] { Tag.Array, Tag.BinarySearch }; }

        public int NULL = -1;
        public override bool Test(System.Diagnostics.Stopwatch sw)
        {
            bool isSuccess = true;
            int[] s;
            int result, checkResult;

            s = new int[] { 1, 0, 2 };
            checkResult = 5;
            result = FindMin(s);
            isSuccess &= IsSame(result, checkResult);
            PrintResult(isSuccess, result, checkResult);

            s = new int[] { 1, 2, 2 };
            checkResult = 4;
            result = FindMin(s);
            isSuccess &= IsSame(result, checkResult);
            PrintResult(isSuccess, result, checkResult);

            return isSuccess;
        }

        //作者：LeetCode - Solution
        //链接：https://leetcode-cn.com/problems/find-minimum-in-rotated-sorted-array-ii/solution/xun-zhao-xuan-zhuan-pai-xu-shu-zu-zhong-de-zui--16/ 
        /// <summary>
        /// 192/192 cases passed (96 ms)
        /// Your runtime beats 99.13 % of csharp submissions
        /// Your memory usage beats 32.56 % of csharp submissions(25.1 MB)
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public int FindMin(int[] nums)
        {
            int L = 0;
            int R = nums.Length - 1;

            while (L < R)
            {
                int mid = L + (R - L) / 2;
                if (nums[mid] < nums[R])
                {
                    R = mid;
                }
                else if (nums[mid] > nums[R])
                {
                    L = mid + 1;
                }
                else
                {
                    R -= 1;
                }
            }
            return nums[L];
        }
    }
    // @lc code=end


}
