using System;
namespace CSharpConsoleApp.Solutions
{
    /*
 * @lc app=leetcode.cn id=540 lang=csharp
 *
 * [540] 有序数组中的单一元素
 *
 * https://leetcode-cn.com/problems/single-element-in-a-sorted-array/description/
 *
 * algorithms
 * Medium (57.98%)
 * Likes:    252
 * Dislikes: 0
 * Total Accepted:    34.1K
 * Total Submissions: 58.8K
 * Testcase Example:  '[1,1,2,3,3,4,4,8,8]'
 *
 * 给定一个只包含整数的有序数组，每个元素都会出现两次，唯有一个数只会出现一次，找出这个数。
 * 
 * 
 * 示例 1:
 * 输入: nums = [1,1,2,3,3,4,4,8,8]
 * 输出: 2
 * 
 * 
 * 示例 2:
 * 输入: nums =  [3,3,7,7,10,11,11]
 * 输出: 10
 * 
 * 
 * 提示:
 * 1 <= nums.length <= 10^5
 * 0 <= nums[i] <= 10^5
 * 
 * 进阶: 采用的方案可以在 O(log n) 时间复杂度和 O(1) 空间复杂度中运行吗？
 */

    // @lc code=start
    public class Solution540 : SolutionBase
    {
        /// <summary>
        /// 难度
        /// </summary>
        public override Difficulity GetDifficulity() { return Difficulity.Medium; }
        /// <summary>
        /// 关键字:
        /// </summary>
        public override string[] GetKeyWords() { return new string[] { "抄作业" }; }
        /// <summary>
        /// 标签：
        /// </summary>
        public override Tag[] GetTags() { return new Tag[] { Tag.Unknown }; }

        /// <summary>
        /// </summary>
        /// <param name="sw"></param>
        /// <returns></returns>
        public override bool Test(System.Diagnostics.Stopwatch sw)
        {
            bool isSuccess = true;
            //TODO
            return isSuccess;
        }

        //作者：LeetCode
        //链接：https://leetcode-cn.com/problems/single-element-in-a-sorted-array/solution/you-xu-shu-zu-zhong-de-dan-yi-yuan-su-by-leetcode/
        /// <summary>
        /// 仅对偶数索引进行二分搜索
        /// 14/14 cases passed (88 ms)
        /// Your runtime beats 96 % of csharp submissions
        /// Your memory usage beats 84 % of csharp submissions(25.7 MB)
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public int SingleNonDuplicate(int[] nums)
        {
            int L = 0;
            int R = nums.Length - 1;
            while (L < R)
            {
                int mid = L + (R - L) / 2;
                //仅对偶数索引进行二分搜索
                if (mid % 2 == 1) mid--;

                if (nums[mid] == nums[mid + 1])
                {
                    L = mid + 2;
                }
                else
                {
                    R = mid;
                }
            }
            return nums[L];
        }
    }
    // @lc code=end


}
