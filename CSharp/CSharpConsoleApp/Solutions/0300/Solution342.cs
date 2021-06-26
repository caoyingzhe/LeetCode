using System;
namespace CSharpConsoleApp.Solutions
{
    /*
     * @lc app=leetcode.cn id=342 lang=csharp
     *
     * [342] 4的幂
     *
     * https://leetcode-cn.com/problems/power-of-four/description/
     *
     * Category	Difficulty	Likes	Dislikes
     * algorithms	Easy (51.33%)	259	-
     * Tags
     * bit-manipulation
     * 
     * Companies
     * twosigma
     * 
     * Total Accepted:    80.4K
     * Total Submissions: 156.6K
     * Testcase Example:  '16'
     *
     * 给定一个整数，写一个函数来判断它是否是 4 的幂次方。如果是，返回 true ；否则，返回 false 。
     * 整数 n 是 4 的幂次方需满足：存在整数 x 使得 n == 4^x
     * 
     * 
     * 示例 1：
     * 输入：n = 16
     * 输出：true
     * 
     * 
     * 示例 2：
     * 输入：n = 5
     * 输出：false
     * 
     * 
     * 示例 3：
     * 输入：n = 1
     * 输出：true
     * 
     * 
     * 提示：
     * -231 <= n <= 231 - 1
     *
     * 进阶：
     * 你能不使用循环或者递归来完成本题吗？
     */

    // @lc code=start
    public class Solution342 : SolutionBase
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
        public override Tag[] GetTags() { return new Tag[] { Tag.Math }; }

        public override bool Test(System.Diagnostics.Stopwatch sw)
        {
            bool isSuccess = true;
            //TODO
            return isSuccess;
        }

        //https://leetcode-cn.com/problems/power-of-four/solution/4de-mi-by-leetcode-solution-b3ya/
        public bool IsPowerOfFour(int n)
        {
            //1061/1061 cases passed (44 ms)
            // Your runtime beats 92.08 % of csharp submissions
            // Your memory usage beats 39.62 % of csharp submissions (15 MB)
            return n > 0 && (n & (n - 1)) == 0 && n % 3 == 1;
            // 1061/1061 cases passed (48 ms)
            // Your runtime beats 77.05 % of csharp submissions
            // Your memory usage beats 73.5 % of csharp submissions (14.9 MB)
            //return n > 0 && (n & (n - 1)) == 0 && (n & 0xaaaaaaaa) == 0;
        }
    }
    // @lc code=end
}
