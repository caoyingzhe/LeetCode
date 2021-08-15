using System;
namespace CSharpConsoleApp.Solutions
{
    /*
 * @lc app=leetcode.cn id=458 lang=csharp
 *
 * [458] 可怜的小猪
 *
 * https://leetcode-cn.com/problems/poor-pigs/description/
 *
 * algorithms
 * Hard (60.11%)
 * Likes:    178
 * Dislikes: 0
 * Total Accepted:    6.4K
 * Total Submissions: 10.5K
 * Testcase Example:  '1000\n15\n60'
 *
 * 有 buckets 桶液体，其中 正好
 * 有一桶含有毒药，其余装的都是水。它们从外观看起来都一样。为了弄清楚哪只水桶含有毒药，你可以喂一些猪喝，通过观察猪是否会死进行判断。不幸的是，你只有
 * minutesToTest 分钟时间来确定哪桶液体是有毒的。
 * 
 * 喂猪的规则如下：
 * 
 * 
 * 选择若干活猪进行喂养
 * 可以允许小猪同时饮用任意数量的桶中的水，并且该过程不需要时间。
 * 小猪喝完水后，必须有 minutesToDie 分钟的冷却时间。在这段时间里，你只能观察，而不允许继续喂猪。
 * 过了 minutesToDie 分钟后，所有喝到毒药的猪都会死去，其他所有猪都会活下来。
 * 重复这一过程，直到时间用完。
 * 
 * 
 * 给你桶的数目 buckets ，minutesToDie 和 minutesToTest ，返回在规定时间内判断哪个桶有毒所需的 最小 猪数。
 * 
 * 
 * 
 * 示例 1：
 * 
 * 
 * 输入：buckets = 1000, minutesToDie = 15, minutesToTest = 60
 * 输出：5
 * 
 * 
 * 示例 2：
 * 
 * 
 * 输入：buckets = 4, minutesToDie = 15, minutesToTest = 15
 * 输出：2
 * 
 * 
 * 示例 3：
 * 
 * 
 * 输入：buckets = 4, minutesToDie = 15, minutesToTest = 30
 * 输出：2
 * 
 * 
 * 
 * 
 * 提示：
 * 
 * 
 * 1 
 * 1 
 * 
 * 
 */

    // @lc code=start
    public class Solution458 : SolutionBase
    {
        /// <summary>
        /// 难度
        /// </summary>
        public override Difficulity GetDifficulity() { return Difficulity.Hard; }
        /// <summary>
        /// 关键字:
        /// </summary>
        public override string[] GetKeyWords() { return new string[] { "抄作业" }; }
        /// <summary>
        /// 标签：
        /// </summary>
        public override Tag[] GetTags() { return new Tag[] { Tag.Math }; }

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
        /// 作者：LeetCode
        /// 链接：https://leetcode-cn.com/problems/poor-pigs/solution/ke-lian-de-xiao-zhu-by-leetcode/
        ///
        /// 每一只小猪 的「状态」数量为 states = minutesToTest / minutesToDie + 1，
        /// 这里「状态」的意思是：在可以测试的次数的范围内，一只小猪可能测试出现的状态。
        /// 
        /// 1. 分析 x 有 2 种状态的猪, x 只猪可以测试 2^x个水桶。
        /// 2. x 只 s 状态的猪（只能测试 s−1 次的情况下）最多可以测试多少个水桶。 答案是 s^x
        /// 其中 states = minutesToTest / minutesToDie + 1, 表示每只猪的状态数
        /// 因此答案为 x > log({states}, {buckets})
        /// 
        /// 因此我们需要找到最小的 x，使得 {states}^x ≥ buckets，
        /// </summary>
        /// <param name="buckets"></param>
        /// <param name="minutesToDie"></param>
        /// <param name="minutesToTest"></param>
        /// <returns></returns>
        public int PoorPigs(int buckets, int minutesToDie, int minutesToTest)
        {
            int states = minutesToTest / minutesToDie + 1;
            return (int)Math.Ceiling(Math.Log(buckets) / Math.Log(states));
        }
    }
    // @lc code=end


}
