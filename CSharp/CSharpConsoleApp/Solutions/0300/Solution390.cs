using System;
namespace CSharpConsoleApp.Solutions
{
    /*
     * @lc app=leetcode.cn id=390 lang=csharp
     *
     * [390] 消除游戏
     *
     * https://leetcode-cn.com/problems/elimination-game/description/
     *
     * Category	Difficulty	Likes	Dislikes
     * algorithms	Medium (46.49%)	119	-
     * Tags
     * Unknown
     * 
     * Companies
     * Unknown
     * 
     * Total Accepted:    6.5K
     * Total Submissions: 13.9K
     * Testcase Example:  '9'
     *
     * 给定一个从1 到 n 排序的整数列表。
     * 首先，从左到右，从第一个数字开始，每隔一个数字进行删除，直到列表的末尾。
     * 第二步，在剩下的数字中，从右到左，从倒数第一个数字开始，每隔一个数字进行删除，直到列表开头。
     * 我们不断重复这两步，从左到右和从右到左交替进行，直到只剩下一个数字。
     * 返回长度为 n 的列表中，最后剩下的数字。
     * 
     * 示例：
     * 输入:
     * n = 9,
     * 1 2 3 4 5 6 7 8 9
     * 2 4 6 8
     * 2 6
     * 6
     * 
     * 输出: 10
     *
     * 示例：
     * 输入:
     * n = 11,
     * 1 2 3 4 5 6 7 8 9 10 11
     * 2 4 6 8 10
     * 4 8
     * 8
     * 
     * 输出: 8
     *
     * 示例：
     * 输入:
     * n = 11,
     * 1 2 3 4 5 6 7 8 9 10 11 12 13 14
     * 2 4 6 8 10 12 14
     * 4 8 12
     * 8 12
     * 8
     * 输出: 8
     *
     * 示例：
     * 输入:
     * n = 16, 17,
     * 1 2 3 4 5 6 7 8 9 10 11 12 13 14 15 16 17
     * 2 4 6 8 10 12 14 16
     * 2 6 10 14
     * 6 14
     * 6
     * 输出: 6
     */

    // @lc code=start
    public class Solution390 : SolutionBase
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

            int a;
            int result, checkResult;

            a = 9; 
            checkResult = 6;
            result = LastRemaining(a);
            isSuccess &= IsSame(result, checkResult);
            PrintResult(isSuccess, (result).ToString(), (checkResult).ToString());

            a = 10;
            checkResult = 8;
            result = LastRemaining(a);
            isSuccess &= IsSame(result, checkResult);
            PrintResult(isSuccess, (result).ToString(), (checkResult).ToString());

            a = 14;
            checkResult = 8;
            result = LastRemaining(a);
            isSuccess &= IsSame(result, checkResult);
            PrintResult(isSuccess, (result).ToString(), (checkResult).ToString());

            a = 16;
            checkResult = 6;
            result = LastRemaining(a);
            isSuccess &= IsSame(result, checkResult);
            PrintResult(isSuccess, (result).ToString(), (checkResult).ToString());

            a = 17;
            checkResult = 6;
            result = LastRemaining(a);
            isSuccess &= IsSame(result, checkResult);
            PrintResult(isSuccess, (result).ToString(), (checkResult).ToString());

            return isSuccess;
        }

        /// <summary>
        /// 递归解法
        ///
        /// 3377/3377 cases passed (36 ms)
        /// Your runtime beats 100 % of csharp submissions
        /// Your memory usage beats 85.71 % of csharp submissions(15.1 MB)
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public int LastRemaining(int n)
        {
            if (n == 1) return 1;
            return 2 * (n / 2 + 1 - LastRemaining(n / 2));
        }
    }
    // @lc code=end


}
