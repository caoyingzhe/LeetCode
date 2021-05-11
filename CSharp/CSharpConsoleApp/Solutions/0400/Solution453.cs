using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpConsoleApp.Solutions._0400
{
    /*
     * @lc app=leetcode.cn id=453 lang=csharp
     *
     * [453] 最小操作次数使数组元素相等
     *
     * https://leetcode-cn.com/problems/minimum-moves-to-equal-array-elements/description/
     *
     * Category	Difficulty	Likes	Dislikes
     * algorithms	Easy (54.67%)	214	-
     * Tags
     * math
     * 
     * Companies
     * indeed
     * 
     * Total Accepted:    22K
     * Total Submissions: 40.3K
     * Testcase Example:  '[1,2,3]'
     *
     * 给定一个长度为 n 的 非空 整数数组，每次操作将会使 n - 1 个元素增加 1。找出让数组所有元素相等的最小操作次数。
     * 
     * 示例：
     * 输入：
     * [1,2,3]
     * 输出：
     * 3
     * 
     * 解释：
     * 只需要3次操作（注意每次操作会增加两个元素的值）：
     * [1,2,3]  =>  [2,3,3]  =>  [3,4,3]  =>  [4,4,4]
     */
    class Solution453 : SolutionBase
    {
        public override Difficulity GetDifficulity() { return Difficulity.Easy; }
        /// <summary>
        /// 关键字:
        /// </summary>
        public override string[] GetKeyWords() { return new string[] { "" }; }
        /// <summary>
        /// 标签：
        /// </summary>
        public override Tag[] GetTags() { return new Tag[] { Tag.Math, }; }
        public override bool Test(System.Diagnostics.Stopwatch sw)
        {
            bool isSuccess = true;
            int[] nums;
            int checkResult;

            nums = new int[] { 1, 2, 3 };
            checkResult = 3;
            isSuccess &= (MinMoves(nums) == checkResult);

            nums = new int[] { 1, 1, 1 };
            checkResult = 0;
            isSuccess &= (MinMoves(nums) == checkResult);

            nums = new int[] { -1, 1 };
            checkResult = 2;
            isSuccess &= (MinMoves(nums) == checkResult);
            return isSuccess;
        }

        public int MinMoves(int[] nums)
        {
            int n = nums.Length;
            Array.Sort(nums);

            int sum = 0;
            for(int i=1; i< n; i++)
            {
                sum += nums[i] - nums[0];
            }
            return sum;
        }

        /// 1,4,6   +5  6,9,6  + 3 9,9,9
    }
}
