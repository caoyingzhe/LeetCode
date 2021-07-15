using System;
namespace CSharpConsoleApp.Solutions
{
    /*
     * @lc app=leetcode.cn id=461 lang=csharp
     *
     * [461] 汉明距离
     *
     * https://leetcode-cn.com/problems/hamming-distance/description/
     *
     * Category	Difficulty	Likes	Dislikes
     * algorithms	Easy (81.01%)	496	-
     * Tags
     * bit-manipulation
     * 
     * Companies
     * facebook
     * 
     * Total Accepted:    155.4K
     * Total Submissions: 191.8K
     * Testcase Example:  '1\n4'
     *
     * 两个整数之间的 汉明距离 指的是这两个数字对应二进制位不同的位置的数目。
     * 给你两个整数 x 和 y，计算并返回它们之间的汉明距离。
     * 
     * 
     * 示例 1：
     * 输入：x = 1, y = 4
     * 输出：2
     * 解释：
     * 1   (0 0 0 1)
     * 4   (0 1 0 0)
     * ⁠      ↑   ↑
     * 上面的箭头指出了对应二进制位不同的位置。
     * 
     * 
     * 示例 2：
     * 输入：x = 3, y = 1
     * 输出：1
     *
     * 
     * 提示：
     * 0 <= x, y <= 231 - 1
     */

    // @lc code=start
    public class Solution461 : SolutionBase
    {
        /// <summary>
        /// 难度
        /// </summary>
        public override Difficulity GetDifficulity() { return Difficulity.Easy; }
        /// <summary>
        /// 关键字:
        /// </summary>
        public override string[] GetKeyWords() { return new string[] { "" }; }
        /// <summary>
        /// 标签：
        /// </summary>
        public override Tag[] GetTags() { return new Tag[] { Tag.BitManipulation }; }

        public int NULL = -1;
        public override bool Test(System.Diagnostics.Stopwatch sw)
        {
            bool isSuccess = true;
            isSuccess &= HammingDistance(1, 4) == 2;
            return isSuccess;
        }

        /// <summary>
        /// 149/149 cases passed (40 ms)
        /// Your runtime beats 97.7 % of csharp submissions
        /// Your memory usage beats 29.95 % of csharp submissions(15 MB)
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public int HammingDistance(int x, int y)
        {
            //Print(Convert.ToString(x, 2));
            //Print(Convert.ToString(y, 2));
            //Print(Convert.ToString(x ^ y, 2));
            return Convert.ToString(x ^ y, 2).Replace("0", "").Length;
        }
    }
    // @lc code=end


}
