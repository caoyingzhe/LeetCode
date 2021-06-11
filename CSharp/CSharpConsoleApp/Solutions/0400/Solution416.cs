using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpConsoleApp.Solutions
{
    /*
     * @lc app=leetcode.cn id=416 lang=csharp
     *
     * [416] 分割等和子集
     *
     * https://leetcode-cn.com/problems/partition-equal-subset-sum/description/
     *
     * Category	Difficulty	Likes	Dislikes
     * algorithms	Medium (50.07%)	821	-
     * Tags
     * dynamic-programming
     * 
     * Companies
     * ebay
     * 
     * Total Accepted:    134.4K
     * Total Submissions: 268.2K
     * Testcase Example:  '[1,5,11,5]'
     *
     * 给你一个 只包含正整数 的 非空 数组 nums 。请你判断是否可以将这个数组分割成两个子集，使得两个子集的元素和相等。
     * 
     * 示例 1：
     * 输入：nums = [1,5,11,5]
     * 输出：true
     * 解释：数组可以分割成 [1, 5, 5] 和 [11] 。
     * 
     * 示例 2：
     * 输入：nums = [1,2,3,5]
     * 输出：false
     * 解释：数组不能分割成两个元素和相等的子集。
     * 
     * 
     * 提示：
     * 1 <= nums.length <= 200
     * 1 <= nums[i] <= 100
     */

    /// <summary>
    /// 时间复杂度：O(n * target)O(n∗target)
    /// 空间复杂度：O(target)O(target)
    /// </summary>
    class Solution416 : SolutionBase
    {
        /// <summary>
        /// 难易度:
        /// </summary>
        public override Difficulity GetDifficulity() { return Difficulity.Medium; }
        /// <summary>
        /// 关键字:
        /// </summary>
        public override string[] GetKeyWords() { return new string[] { "自我完成","动态规划之01背包问题" }; }
        /// <summary>
        /// 标签： 图
        /// </summary>
        public override Tag[] GetTags() { return new Tag[] { Tag.DynamicProgramming }; }

        public override bool Test(System.Diagnostics.Stopwatch sw)
        {
            int[] nums = new int[] { 1, 5, 5, 11, 22 };

            bool result = CanPartition(nums);
            System.Diagnostics.Debug.Print("Result = " + result);
            return true;
        }
        public bool CanPartition(int[] nums)
        {
            int len = nums.Length;
            int sum = nums.Sum();
            if (sum % 2 == 1)
                return false;
            else
            {
                int half = sum / 2;

                //dp[j]含义：有没有和为j的子集，有为True，没有为False。
                bool[] dp = new bool[half + 1];
                dp[0] = true;

                for (int i = 0; i < nums.Length; i++)
                {
                    //对每一个数进行dp判定，必须从大到下
                    for (int j = half; j >= nums[i]; j--)
                    {
                        //最重要的处理。
                        dp[j] = dp[j] || dp[j - nums[i]];
                    }
                    //对数组 { 1, 5, 5, 11, 22 } 的处理过程
                    //i=0; dp[1]              = true;
                    //i=1; dp[5],[6]          = true;
                    //i=2; dp[10],[11]        = true;
                    //i=3; dp[]12],[16],[17]  = true;
                }
                return dp[half];
            }
        }
    }
}
