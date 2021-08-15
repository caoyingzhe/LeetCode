using System;
namespace CSharpConsoleApp.Solutions
{
    /*
     * @lc app=leetcode.cn id=495 lang=csharp
     *
     * [495] 提莫攻击
     *
     * https://leetcode-cn.com/problems/teemo-attacking/description/
     *
     * algorithms
     * Easy (53.58%)
     * Likes:    157
     * Dislikes: 0
     * Total Accepted:    25.1K
     * Total Submissions: 46.8K
     * Testcase Example:  '[1,4]\n2'
     *
     * 在《英雄联盟》的世界中，有一个叫 “提莫”
     * 的英雄，他的攻击可以让敌方英雄艾希（编者注：寒冰射手）进入中毒状态。现在，给出提莫对艾希的攻击时间序列和提莫攻击的中毒持续时间，你需要输出艾希的中毒状态总时长。
     * 
     * 你可以认为提莫在给定的时间点进行攻击，并立即使艾希处于中毒状态。
     * 
     * 示例1:
     * 输入: [1,4], 2
     * 输出: 4
     * 原因: 第 1 秒初，提莫开始对艾希进行攻击并使其立即中毒。中毒状态会维持 2 秒钟，直到第 2 秒末结束。
     * 第 4 秒初，提莫再次攻击艾希，使得艾希获得另外 2 秒中毒时间。
     * 所以最终输出 4 秒。
     * 
     * 
     * 示例2:
     * 输入: [1,2], 2
     * 输出: 3
     * 原因: 第 1 秒初，提莫开始对艾希进行攻击并使其立即中毒。中毒状态会维持 2 秒钟，直到第 2 秒末结束。
     * 但是第 2 秒初，提莫再次攻击了已经处于中毒状态的艾希。
     * 由于中毒状态不可叠加，提莫在第 2 秒初的这次攻击会在第 3 秒末结束。
     * 所以最终输出 3 。
     *
     * 提示：
     * 你可以假定时间序列数组的总长度不超过 10000。
     * 你可以假定提莫攻击时间序列中的数字和提莫攻击的中毒持续时间都是非负整数，并且不超过 10,000,000。
     */

    // @lc code=start
    public class Solution495 : SolutionBase
    {
        /// <summary>
        /// 难度
        /// </summary>
        public override Difficulity GetDifficulity() { return Difficulity.Easy; }
        /// <summary>
        /// 关键字:
        /// </summary>
        public override string[] GetKeyWords() { return new string[] { "抄作业" }; }
        /// <summary>
        /// 标签：
        /// </summary>
        public override Tag[] GetTags() { return new Tag[] { Tag.Array }; }

        /// <summary>
        /// </summary>
        /// <param name="sw"></param>
        /// <returns></returns>
        public override bool Test(System.Diagnostics.Stopwatch sw)
        {
            bool isSuccess = true;
            //TODO
            //PrintDatas(PoorPigs(new int[] { 0, 0 }, new int[] { 1, 1 }, new int[] { 1, 0 }, new int[] { 0, 1 }));
            return isSuccess;
        }

        /// <summary>
        /// Your runtime beats 91.23 % of csharp submissions
        /// Your memory usage beats 68.42 % of csharp submissions(35.6 MB)
        /// </summary>
        /// <param name="timeSeries"></param>
        /// <param name="duration"></param>
        /// <returns></returns>
        public int FindPoisonedDuration(int[] timeSeries, int duration)
        {
            int n = timeSeries.Length;
            if (n == 0) return 0;

            int total = 0;
            for (int i = 0; i < n - 1; ++i)
                total += Math.Min(timeSeries[i + 1] - timeSeries[i], duration);
            return total + duration;
        }
    }
    // @lc code=end


}
