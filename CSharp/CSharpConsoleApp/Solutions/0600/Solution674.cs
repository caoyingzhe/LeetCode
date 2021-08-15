using System;
namespace CSharpConsoleApp.Solutions
{
    /*
 * @lc app=leetcode.cn id=674 lang=csharp
 *
 * [674] 最长连续递增序列
 *
 * https://leetcode-cn.com/problems/longest-continuous-increasing-subsequence/description/
 *
 * Category	Difficulty	Likes	Dislikes
 * algorithms	Easy (48.77%)	202	-
 * Tags
 * array
 * 
 * Companies
 * facebook
 * 
 * Total Accepted:    85.2K
 * Total Submissions: 174.7K
 * Testcase Example:  '[1,3,5,4,7]'
 *
 * 给定一个未经排序的整数数组，找到最长且 连续递增的子序列，并返回该序列的长度。
 * 
 * 连续递增的子序列 可以由两个下标 l 和 r（l < r）确定，如果对于每个 l ，都有 nums[i] < nums[i + 1] ，那么子序列
 * [nums[l], nums[l + 1], ..., nums[r - 1], nums[r]] 就是连续递增子序列。
 * 
 * 
 * 示例 1：
 * 输入：nums = [1,3,5,4,7]
 * 输出：3
 * 解释：最长连续递增序列是 [1,3,5], 长度为3。
 * 尽管 [1,3,5,7] 也是升序的子序列, 但它不是连续的，因为 5 和 7 在原数组里被 4 隔开。 
 * 
 * 
 * 示例 2：
 * 输入：nums = [2,2,2,2,2]
 * 输出：1
 * 解释：最长连续递增序列是 [2], 长度为1。
 * 
 * 
 * 提示：
 * 1 <= nums.length <= 10^4
 * -10^9 <= nums[i] <= 10^9
 */

    // @lc code=start
    public class Solution674 : SolutionBase
    {
        /// <summary>
        /// 难度
        /// </summary>
        public override Difficulity GetDifficulity() { return Difficulity.Easy; }
        /// <summary>
        /// 关键字:
        /// </summary>
        public override string[] GetKeyWords() { return new string[] { "抄作业" }; }
        /// <summary>
        /// 标签：
        /// </summary>
        public override Tag[] GetTags() { return new Tag[] { Tag.Array }; }

        /// <summary>
        /// </summary>
        /// <param name="sw"></param>
        /// <returns></returns>
        public override bool Test(System.Diagnostics.Stopwatch sw)
        {
            bool isSuccess = true;
            //TODO
            //PrintDatas(PoorPigs(new int[] { 0, 0 }, new int[] { 1, 1 }, new int[] { 1, 0 }, new int[] { 0, 1 }));
            return isSuccess;
        }
        //

        //作者：LeetCode - Solution
        //链接：https://leetcode-cn.com/problems/longest-continuous-increasing-subsequence/solution/zui-chang-lian-xu-di-zeng-xu-lie-by-leet-dmb8/
        /// <summary>
        /// 35/35 cases passed (92 ms)
        /// Your runtime beats 91.18 % of csharp submissions
        /// Your memory usage beats 32.35 % of csharp submissions(26.3 MB)
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public int FindLengthOfLCIS(int[] nums)
        {
            int ans = 0;
            int n = nums.Length;
            int start = 0;
            for (int i = 0; i < n; i++)
            {
                if (i > 0 && nums[i] <= nums[i - 1])
                {
                    start = i;
                }
                ans = Math.Max(ans, i - start + 1);
            }
            return ans;
        }
    }
    // @lc code=end


}
