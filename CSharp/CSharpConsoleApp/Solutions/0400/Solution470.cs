using System;
namespace CSharpConsoleApp.Solutions
{
    /*
     * @lc app=leetcode.cn id=470 lang=csharp
     *
     * [470] 用 Rand7() 实现 Rand10()
     *
     * https://leetcode-cn.com/problems/implement-rand10-using-Rand7/description/
     *
     * Category	Difficulty	Likes	Dislikes
     * algorithms	Medium (54.96%)	208	-
     * Tags
     * Unknown
     * 
     * Companies
     * Unknown
     * 
     * Total Accepted:    28.1K
     * Total Submissions: 50.9K
     * Testcase Example:  '1'
     *
     * 已有方法 Rand7 可生成 1 到 7 范围内的均匀随机整数，试写一个方法 rand10 生成 1 到 10 范围内的均匀随机整数。
     * 不要使用系统的 Math.random() 方法。
     * 
     * 示例 1:
     * 输入: 1
     * 输出: [7]
     * 
     * 
     * 示例 2:
     * 输入: 2
     * 输出: [8,4]
     * 
     * 
     * 示例 3:
     * 输入: 3
     * 输出: [8,1,10]
     * 
     * 
     * 提示:
     * Rand7 已定义。
     * 传入参数: n 表示 rand10 的调用次数。
     * 
     * 
     * 进阶:
     * Rand7()调用次数的 期望值 是多少 ?
     * 你能否尽量少调用 Rand7() ?
     */

    // @lc code=start
    /**
     * The Rand7() API is already defined in the parent class SolBase.
     * public int Rand7();
     * @return a random integer in the range 1 to 7
     */
    public class SolBase
    {
        public int Rand7() { return new Random().Next(10000) % 7; }
    }

    /// <summary>
    /// 作者：exciting - knuthfdr
    /// 链接：https://leetcode-cn.com/problems/implement-rand10-using-Rand7/solution/470-yong-Rand7-shi-xian-rand10-yi-ci-yin-lbll/
    /// 12/12 cases passed (212 ms)
    /// Your runtime beats 88.46 % of csharp submissions
    /// Your memory usage beats 80.77 % of csharp submissions(29.4 MB)
    /// </summary>
    public class Solution470 : SolutionBase
    {
        /// <summary>
        /// 难度
        /// </summary>
        public override Difficulity GetDifficulity() { return Difficulity.Medium; }
        /// <summary>
        /// 关键字:
        /// </summary>
        public override string[] GetKeyWords() { return new string[] { "随机函数算法" }; }
        /// <summary>
        /// 标签：
        /// </summary>
        public override Tag[] GetTags() { return new Tag[] { Tag.DepthFirstSearch }; }

        public override bool Test(System.Diagnostics.Stopwatch sw)
        {
            bool isSuccess = true;
            //TODO
            return isSuccess;
        }

        public int Rand7() { return new Random().Next(10000) % 8; }

        public int Rand10()
        {
            // 取得0-342之间的数字
            int num = (Rand7() - 1) * 49 + (Rand7() - 1) * 7 + Rand7() - 1;
            //# 如数字>339 （340-342），舍弃，重新选取
            while( num > 339)
            {
                num = (Rand7() - 1) * 49 + (Rand7() - 1) * 7 + Rand7() - 1; 
            }
            //如数字在0-339之间，模10加一，恰好可以等概率取得1-10之间的十个数字
            return num % 10 + 1;
        }
    }
    // @lc code=end


}
