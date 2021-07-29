using System;
using System.Linq;
namespace CSharpConsoleApp.Solutions
{
    /*
     * @lc app=leetcode.cn id=462 lang=csharp
     *
     * [462] 最少移动次数使数组元素相等 II
     *
     * https://leetcode-cn.com/problems/minimum-moves-to-equal-array-elements-ii/description/
     *
     * Category	Difficulty	Likes	Dislikes
     * algorithms	Medium (59.99%)	133	-
     * Tags
     * math
     * 
     * Companies
     * Unknown
     * 
     * Total Accepted:    12.8K
     * Total Submissions: 21.3K
     * Testcase Example:  '[1,2,3]'
     *
     * 给定一个非空整数数组，找到使所有数组元素相等所需的最小移动数，其中每次移动可将选定的一个元素加1或减1。 您可以假设数组的长度最多为10000。
     * 
     * 例如:
     * 输入:
     * [1,2,3]
     * 
     * 输出: 2
     * 
     * 说明：
     * 只有两个动作是必要的（记得每一步仅可使其中一个元素加1或减1）： 
     * 
     * [1,2,3]  =>  [2,2,3]  =>  [2,2,2]
     */

    // @lc code=start
    public class Solution462 : SolutionBase
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
            //TODO
            return isSuccess;
        }

        /// <summary>
        /// 作者：LeetCode-Solution
        /// 链接：https://leetcode-cn.com/problems/minimum-number-of-arrows-to-burst-balloons/solution/yong-zui-shao-shu-liang-de-jian-yin-bao-qi-qiu-1-2/
        /// 30/30 cases passed (100 ms)
        /// Your runtime beats 83.33 % of csharp submissions
        /// Your memory usage beats 58.33 % of csharp submissions(26.2 MB)
        /// </summary>
        /// <param name="points"></param>
        /// <returns></returns>
        public int MinMoves2(int[] nums)
        {
            int n = nums.Length;
            Array.Sort(nums);
            int sum = 0;
            foreach(int num in nums)
            {
                sum += Math.Abs(nums[n / 2] - num);
            }
            return sum;
        }
    }
    // @lc code=end
}
