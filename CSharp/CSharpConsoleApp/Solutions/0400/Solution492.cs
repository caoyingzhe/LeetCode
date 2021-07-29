using System;
namespace CSharpConsoleApp.Solutions
{
    /*
 * @lc app=leetcode.cn id=492 lang=csharp
 *
 * [492] 构造矩形
 *
 * https://leetcode-cn.com/problems/construct-the-rectangle/description/
 *
 * algorithms
 * Easy (54.75%)
 * Likes:    56
 * Dislikes: 0
 * Total Accepted:    18.1K
 * Total Submissions: 33K
 * Testcase Example:  '4'
 *
 * 作为一位web开发者， 懂得怎样去规划一个页面的尺寸是很重要的。 现给定一个具体的矩形页面面积，你的任务是设计一个长度为 L 和宽度为 W
 * 且满足以下要求的矩形的页面。要求：
 * 
 * 
 * 1. 你设计的矩形页面必须等于给定的目标面积。
 * 
 * 2. 宽度 W 不应大于长度 L，换言之，要求 L >= W 。
 * 
 * 3. 长度 L 和宽度 W 之间的差距应当尽可能小。
 * 
 * 
 * 你需要按顺序输出你设计的页面的长度 L 和宽度 W。
 * 
 * 示例：
 * 
 * 
 * 输入: 4
 * 输出: [2, 2]
 * 解释: 目标面积是 4， 所有可能的构造方案有 [1,4], [2,2], [4,1]。
 * 但是根据要求2，[1,4] 不符合要求; 根据要求3，[2,2] 比 [4,1] 更能符合要求. 所以输出长度 L 为 2， 宽度 W 为 2。
 * 
 * 
 * 说明:
 * 
 * 
 * 给定的面积不大于 10,000,000 且为正整数。
 * 你设计的页面的长度和宽度必须都是正整数。
 * 
 * 
 */

    // @lc code=start
    public class Solution492 : SolutionBase
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
        public override Tag[] GetTags() { return new Tag[] { Tag.Unknown }; }

        
        public override bool Test(System.Diagnostics.Stopwatch sw)
        {
            bool isSuccess = true;
            int a;
            int[] result, checkResult;

            a = 4;
            checkResult = new int[] { 2, 2 };
            result = ConstructRectangle(a);
            isSuccess &= IsSame(result, checkResult);
            PrintResult(isSuccess, (result).ToString(), (checkResult).ToString());
            return isSuccess;
        }

        /// <summary>
        /// 52/52 cases passed (236 ms)
        /// Your runtime beats 83.33 % of csharp submissions
        /// Your memory usage beats 100 % of csharp submissions(25.2 MB)
        /// </summary>
        /// <param name="area"></param>
        /// <returns></returns>
        public int[] ConstructRectangle(int area)
        {
            int sqrt = (int)Math.Sqrt(area);
            if (sqrt * sqrt == area)
            {
                return new int[] { sqrt, sqrt };
            }
            for (int i = sqrt; i >= 1; i--)
            {
                if (area % i == 0)
                {
                    return new int[] { area / i, i };
                }
            }
            return null;
        }
    }
    // @lc code=end


}
