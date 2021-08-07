using System;
using System.Collections.Generic;
namespace CSharpConsoleApp.Solutions
{
    /*
 * @lc app=leetcode.cn id=594 lang=csharp
 *
 * [594] 最长和谐子序列
 *
 * https://leetcode-cn.com/problems/longest-harmonious-subsequence/description/
 *
 * Category	Difficulty	Likes	Dislikes
 * algorithms	Easy (51.35%)	180	-
 * Tags
 * hash-table
 * 
 * Companies
 * Unknown
 * 
 * Total Accepted:    26.4K
 * Total Submissions: 51.3K
 * Testcase Example:  '[1,3,2,2,5,2,3,7]'
 *
 * 和谐数组是指一个数组里元素的最大值和最小值之间的差别 正好是 1 。
 * 现在，给你一个整数数组 nums ，请你在所有可能的子序列中找到最长的和谐子序列的长度。
 * 数组的子序列是一个由数组派生出来的序列，它可以通过删除一些元素或不删除元素、且不改变其余元素的顺序而得到。
 * 
 * 
 * 示例 1：
 * 输入：nums = [1,3,2,2,5,2,3,7]
 * 输出：5
 * 解释：最长的和谐子序列是 [3,2,2,2,3]
 * 
 * 
 * 示例 2：
 * 输入：nums = [1,2,3,4]
 * 输出：2
 * 
 * 
 * 示例 3：
 * 输入：nums = [1,1,1,1]
 * 输出：0
 * 
 * 
 * 提示：
 * 1 <= nums.length <= 2 * 10^4
 * -10^9 <= nums[i] <= 10^9
 */

    // @lc code=start
    public class Solution594 : SolutionBase
    {
        /// <summary>
        /// 难度
        /// </summary>
        public override Difficulity GetDifficulity() { return Difficulity.Easy; }
        /// <summary>
        /// 关键字:
        /// </summary>
        public override string[] GetKeyWords() { return new string[] { }; }
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

            int[] nums;
            int result, checkResult;

            nums = new int[] { 1, 3, 2, 2, 5, 2, 3, 7 };
            checkResult = 5;
            result = FindLHS(nums);
            isSuccess &= IsSame(result, checkResult);
            PrintResult(isSuccess, result, checkResult);

            nums = new int[] { 1, 2, 3, 4 };
            checkResult = 2;
            result = FindLHS(nums);
            isSuccess &= IsSame(result, checkResult);
            PrintResult(isSuccess, result, checkResult);

            nums = new int[] { 1, 1, 1, 1 };
            checkResult = 0;
            result = FindLHS(nums);
            isSuccess &= IsSame(result, checkResult);
            PrintResult(isSuccess, result, checkResult);

            return isSuccess;
        }

        /// <summary>
        /// 作者：tao - x6
        /// 链接：https://leetcode-cn.com/problems/longest-harmonious-subsequence/solution/gao-xiao-jie-fa-ha-xi-biao-cun-chu-18ms-09a73/
        /// 206/206 cases passed (148 ms)
        /// Your runtime beats 100 % of csharp submissions
        /// Your memory usage beats 61.11 % of csharp submissions(41.6 MB)
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public int FindLHS(int[] nums)
        {
            if (nums.Length <= 1) return 0;

            int maxlength = 0;
            Dictionary<int, int> map = new Dictionary<int,int>();
            foreach (int num in nums)
            {
                if (!map.ContainsKey(num))
                    map.Add(num, 1);
                else
                    map[num] += 1;
            }

            if (map.Count == 1) return 0;

            foreach (int num in map.Keys)
            { 
                if (map.ContainsKey(num + 1))
                {
                    int length = map[num] + map[num + 1];
                    maxlength = Math.Max(length, maxlength);
                }
            }
            return maxlength;
        }
    }
    // @lc code=end


}
