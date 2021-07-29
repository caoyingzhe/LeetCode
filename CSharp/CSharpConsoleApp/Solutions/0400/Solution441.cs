using System;
using System.Collections.Generic;
namespace CSharpConsoleApp.Solutions
{
    /*
     * @lc app=leetcode.cn id=441 lang=csharp
     *
     * [441] 排列硬币
     *
     * https://leetcode-cn.com/problems/arranging-coins/description/
     *
     * Category	Difficulty	Likes	Dislikes
     * algorithms	Easy (42.42%)	109	-
     * Tags
     * math | binary-search
     * 
     * Companies
     * Unknown
     * 
     * Total Accepted:    43K
     * Total Submissions: 101.2K
     * Testcase Example:  '5'
     *
     * 你总共有 n 枚硬币，你需要将它们摆成一个阶梯形状，第 k 行就必须正好有 k 枚硬币。
     * 
     * 给定一个数字 n，找出可形成完整阶梯行的总行数。
     * 
     * n 是一个非负整数，并且在32位有符号整型的范围内。
     * 
     * 示例 1:
     * n = 5
     * 硬币可排列成以下几行:
     * ¤
     * ¤ ¤
     * ¤ ¤
     * 
     * 因为第三行不完整，所以返回2.
     * 
     * 
     * 示例 2:
     * n = 8
     * 硬币可排列成以下几行:
     * ¤
     * ¤ ¤
     * ¤ ¤ ¤
     * ¤ ¤
     * 
     * 因为第四行不完整，所以返回3.
     */

    // @lc code=start
    public class Solution441 : SolutionBase
    {
        /// <summary>
        /// 难度
        /// </summary>
        public override Difficulity GetDifficulity() { return Difficulity.Medium; }
        /// <summary>
        /// 关键字:
        /// </summary>
        public override string[] GetKeyWords() { return new string[] { "回文串" }; }
        /// <summary>
        /// 标签：
        /// </summary>
        public override Tag[] GetTags() { return new Tag[] { Tag.Math, Tag.BinarySearch }; }

        
        /// <summary>
        /// </summary>
        /// <param name="sw"></param>
        /// <returns></returns>
        public override bool Test(System.Diagnostics.Stopwatch sw)
        {
            bool isSuccess = true;

            int s;
            int result, checkResult;

            s = 4;
            result = ArrangeCoins(s);
            checkResult = 2;
            isSuccess &= IsSame(result, checkResult);
            PrintResult(isSuccess, (result), (checkResult));

            s = 8;
            result = ArrangeCoins(s);
            checkResult = 3;
            isSuccess &= IsSame(result, checkResult);
            PrintResult(isSuccess, (result), (checkResult));

            s = 28;
            result = ArrangeCoins(s);
            checkResult = 7;
            isSuccess &= IsSame(result, checkResult);
            PrintResult(isSuccess, (result), (checkResult));


            return isSuccess;
        }

        /// <summary>
        /// 作者：zhi - shou - xiang - yi
        /// 链接：https://leetcode-cn.com/problems/arranging-coins/solution/shu-xue-fang-fa-su-du-86-kong-jian-83-by-s1rp/
        /// 1335/1335 cases passed (48 ms)
        /// Your runtime beats 87.69 % of csharp submissions
        /// Your memory usage beats 10.77 % of csharp submissions(15.1 MB)
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>

        /// 超关键处理： int类型可能会超出范围我们手动改为long类型
        // public int ArrangeCoins(int n)
        public int ArrangeCoins(long n)
        {
            //利用数学方法计算
            if (n == 0)
            {
                return 0;
            }
            double number = (Math.Sqrt(1 + 8 * n) - 1) / 2;
            return (int)(Math.Floor(number));
        }
    }
    // @lc code=end


}
