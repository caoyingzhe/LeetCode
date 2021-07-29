using System;
namespace CSharpConsoleApp.Solutions
{
    /*
     * @lc app=leetcode.cn id=334 lang=csharp
     *
     * [334] 递增的三元子序列
     *
     * https://leetcode-cn.com/problems/increasing-triplet-subsequence/description/
     *
     * Category	Difficulty	Likes	Dislikes
     * algorithms	Medium (41.46%)	323	-
     * Tags
     * Unknown
     * 
     * Companies
     * facebook
     * 
     * Total Accepted:    39.2K
     * Total Submissions: 94.5K
     * Testcase Example:  '[1,2,3,4,5]'
     *
     * 给你一个整数数组 nums ，判断这个数组中是否存在长度为 3 的递增子序列。
     * 
     * 如果存在这样的三元组下标 (i, j, k) 且满足 i < j < k ，使得 nums[i] < nums[j] < nums[k] ，返回
     * true ；否则，返回 false 。
     * 
     * 
     * 示例 1：
     * 输入：nums = [1,2,3,4,5]
     * 输出：true
     * 解释：任何 i < j < k 的三元组都满足题意
     * 
     * 
     * 示例 2：
     * 输入：nums = [5,4,3,2,1]
     * 输出：false
     * 解释：不存在满足题意的三元组
     * 
     * 示例 3：
     * 输入：nums = [2,1,5,0,4,6]
     * 输出：true
     * 解释：三元组 (3, 4, 5) 满足题意，因为 nums[3] == 0 < nums[4] == 4 < nums[5] == 6
     *
     * 
     * 提示：
     * 1 <= nums.length <= 105
     * -2^31 <= nums[i] <= 2^31 - 1
     * 
     * 进阶：你能实现时间复杂度为 O(n) ，空间复杂度为 O(1) 的解决方案吗？
     */

    // @lc code=start
    public class Solution334 : SolutionBase
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
        public override Tag[] GetTags() { return new Tag[] { Tag.Unknown }; }

        
        public override bool Test(System.Diagnostics.Stopwatch sw)
        {
            bool isSuccess = true;

            int[] nums;
            bool result, checkResult;

            nums = new int[] { 1, 2, 5 };
            checkResult = false;
            result = IncreasingTriplet(nums);
            isSuccess &= IsSame(result, checkResult);
            PrintResult(isSuccess, (result).ToString(), (checkResult).ToString());

            return isSuccess;
        }

        int first = int.MinValue;
        int second = int.MinValue;
        /// <summary>
        /// 作者：slience-o
        /// 链接：https://leetcode-cn.com/problems/increasing-triplet-subsequence/solution/on-o1de-jie-fa-shuang-bai-jie-fa-by-slie-trgo/
        ///
        /// 76/76 cases passed (164 ms)
        /// Your runtime beats 50 % of csharp submissions
        /// Your memory usage beats 13.16 % of csharp submissions(37.7 MB)
        /// 本质上是 从后往前遍历 记录最大的俩个值（次大值一定在下标上比最大值小）
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public bool IncreasingTriplet(int[] nums)
        {
            if (nums.Length < 3)
            {
                return false;
            }
            for (int i = nums.Length - 1; i >= 0; i--)
            {
                //tips  =号是防止相等的情况
                if (nums[i] >= first)
                {
                    first = nums[i];
                }
                else if (nums[i] >= second)
                {
                    second = nums[i];
                }
                else
                {
                    return true;
                }
            }
            return false;
        }

        
    }
    // @lc code=end


}
