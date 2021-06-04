using System;
namespace CSharpConsoleApp.Solutions
{
    /*
     * @lc app=leetcode.cn id=403 lang=csharp
     *
     * [403] 青蛙过河
     *
     * https://leetcode-cn.com/problems/frog-jump/description/
     *
     * Category	Difficulty	Likes	Dislikes
     * algorithms	Hard (45.55%)	340	-
     * Tags
     * dynamic-programming
     * 
     * Companies
     * snapchat
     * 
     * Total Accepted:    41.8K
     * Total Submissions: 91.8K
     * Testcase Example:  '[0,1,3,5,6,8,12,17]'
     *
     * 一只青蛙想要过河。 假定河流被等分为若干个单元格，并且在每一个单元格内都有可能放有一块石子（也有可能没有）。 青蛙可以跳上石子，但是不可以跳入水中。
     * 
     * 给你石子的位置列表 stones（用单元格序号 升序 表示）， 请判定青蛙能否成功过河（即能否在最后一步跳至最后一块石子上）。
     * 
     * 开始时， 青蛙默认已站在第一块石子上，并可以假定它第一步只能跳跃一个单位（即只能从单元格 1 跳至单元格 2 ）。
     * 
     * 如果青蛙上一步跳跃了 k 个单位，那么它接下来的跳跃距离只能选择为 k - 1、k 或 k + 1 个单位。
     * 另请注意，青蛙只能向前方（终点的方向）跳跃。
     *
     * 
     * 示例 1：
     * 输入：stones = [0,1,3,5,6,8,12,17]
     * 输出：true
     * 解释：青蛙可以成功过河，按照如下方案跳跃：跳 1 个单位到第 2 块石子, 然后跳 2 个单位到第 3 块石子, 接着 跳 2 个单位到第 4 块石子,
     * 然后跳 3 个单位到第 6 块石子, 跳 4 个单位到第 7 块石子, 最后，跳 5 个单位到第 8 个石子（即最后一块石子）。
     * 
     * 示例 2：
     * 输入：stones = [0,1,2,3,4,8,9,11]
     * 输出：false
     * 解释：这是因为第 5 和第 6 个石子之间的间距太大，没有可选的方案供青蛙跳跃过去。
     * 
     * 提示：
     * 2 <= stones.length <= 2000
     * 0 <= stones[i] <= 231 - 1
     * stones[0] == 0
     */
    public class Solution403 : SolutionBase
    {
        /// <summary>
        /// 难度
        /// </summary>
        public override Difficulity GetDifficulity() { return Difficulity.Hard; }
        /// <summary>
        /// 关键字:
        /// </summary>
        public override string[] GetKeyWords() { return new string[] { }; }
        /// <summary>
        /// 标签：
        /// </summary>
        public override Tag[] GetTags() { return new Tag[] { Tag.DynamicProgramming }; }

        public override bool Test(System.Diagnostics.Stopwatch sw)
        {
            return true;
        }
        /// <summary>
        /// 50/50 cases passed (144 ms)
        /// Your runtime beats 90.45 % of csharp submissions
        /// Your memory usage beats 48.31 % of csharp submissions(41.1 MB)
        /// </summary>
        /// <param name="stones"></param>
        /// <returns></returns>
        public bool CanCross(int[] stones)
        {
            int n = stones.Length;
            bool[,] dp = new bool[n, n];

            dp[0, 0] = true;
            //dp[1] = dp[0] && (stones[1] - stones[0] <= 2 && stones[1] - stones[0] >=0);
            //dp[2] = dp[0] && (stones[2] - stones[0] <= 3 && stones[2] - stones[0] >= 1)
            //    || dp[1] && (stones[2] - stones[1] <= 3 && stones[2] - stones[1] >= 1);

            for (int i = 1; i < stones.Length; i++)
            {
                for (int j = i - 1; j >= 0; j--)
                {
                    int k = stones[i] - stones[j];
                    if (k > j + 1)
                        break;
                    //dp[i] = dp[i - 1] && (stones[i] - stones[i - 1] <= i + 1 && stones[i] - stones[i - 1] >= i - 1);
                    dp[i, k] = dp[j, k - 1] || dp[j, k] || dp[j, k + 1];
                    // 到了数组最末尾的时候，进行一个判断
                    if (i == n - 1 && dp[i,k])
                        return true;
                }
            }
            return false;
        }
    }
}
