using System;
namespace CSharpConsoleApp.Solutions
{
    /*
 * @lc app=leetcode.cn id=365 lang=csharp
 *
 * [365] 水壶问题
 *
 * https://leetcode-cn.com/problems/water-and-jug-problem/description/
 *
 * Category	Difficulty	Likes	Dislikes
 * algorithms	Medium (35.84%)	299	-
 * Tags
 * math
 * 
 * Companies
 * microsoft
 * 
 * Total Accepted:    31.2K
 * Total Submissions: 86.9K
 * Testcase Example:  '3\n5\n4'
 *
 * 有两个容量分别为 x升 和 y升 的水壶以及无限多的水。请判断能否通过使用这两个水壶，从而可以得到恰好 z升 的水？
 * 
 * 如果可以，最后请用以上水壶中的一或两个来盛放取得的 z升 水。
 * 
 * 你允许：
 * 
 * 
 * 装满任意一个水壶
 * 清空任意一个水壶
 * 从一个水壶向另外一个水壶倒水，直到装满或者倒空
 * 
 * 
 * 示例 1: (From the famous "Die Hard" example)
 * 
 * 输入: x = 3, y = 5, z = 4
 * 输出: True
 * 
 * 
 * 示例 2:
 * 
 * 输入: x = 2, y = 6, z = 5
 * 输出: False
 * 
 * 
 */

    // @lc code=start
    public class Solution365 : SolutionBase
    {
        /// <summary>
        /// 难度
        /// </summary>
        public override Difficulity GetDifficulity() { return Difficulity.Medium; }
        /// <summary>
        /// 关键字:
        /// </summary>
        public override string[] GetKeyWords() { return new string[] { "贝祖定理", "水壶问题" }; }
        /// <summary>
        /// 标签：
        /// </summary>
        public override Tag[] GetTags() { return new Tag[] { Tag.Math, }; }

        public override bool Test(System.Diagnostics.Stopwatch sw)
        {
            bool isSuccess = true;
            int jug1Capacity, jug2Capacity, targetCapacity;
            bool result, checkResult;

            jug1Capacity = 3; jug2Capacity = 5; targetCapacity = 4;
            checkResult = true;
            result = CanMeasureWater(jug1Capacity, jug2Capacity, targetCapacity);
            isSuccess &= IsSame(result, checkResult);
            PrintResult(isSuccess, (result), (checkResult));

            jug1Capacity = 2; jug2Capacity = 6; targetCapacity = 5;
            checkResult = false;
            result = CanMeasureWater(jug1Capacity, jug2Capacity, targetCapacity);
            isSuccess &= IsSame(result, checkResult);
            PrintResult(isSuccess, (result), (checkResult));

            return isSuccess;
        }

        /// <summary>
        /// 作者：LeetCode-Solution
        /// 链接：https://leetcode-cn.com/problems/water-and-jug-problem/solution/shui-hu-wen-ti-by-leetcode-solution/
        /// 我们可以认为每次操作只会给水的总量带来 x 或者 y 的变化量。
        /// 因此我们的目标可以改写成：
        ///     找到一对整数 a, b，使得 ax+by=z
        ///     而只要满足 z ≤ x+y，且这样的 a, b 存在，那么我们的目标就是可以达成的。
        /// 贝祖定理告诉我们，ax+by=zax+by=z 有解当且仅当 zz 是 x, yx,y 的最大公约数的倍数。
        ///
        /// 28/28 cases passed (40 ms)
        /// Your runtime beats 100 % of csharp submissions
        /// Your memory usage beats 75 % of csharp submissions(14.8 MB)
        /// </summary>
        /// <param name="jug1Capacity"></param>
        /// <param name="jug2Capacity"></param>
        /// <param name="targetCapacity"></param>
        /// <returns></returns>
        public bool CanMeasureWater(int x, int y, int z)
        {
            if (x + y < z)
            {
                return false;
            }
            if (x == 0 || y == 0)
            {
                return z == 0 || x + y == z;
            }
            return z % gcd(x, y) == 0;
        }

        public int gcd(int x, int y)
        {
            int remainder = x % y;
            while (remainder != 0)
            {
                x = y;
                y = remainder;
                remainder = x % y;
            }
            return y;
        }
    }
    // @lc code=end


}
