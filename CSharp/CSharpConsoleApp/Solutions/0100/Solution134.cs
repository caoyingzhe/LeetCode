using System;
namespace CSharpConsoleApp.Solutions
{
    /*
     * @lc app=leetcode.cn id=134 lang=csharp
     *
     * [134] 加油站
     *
     * https://leetcode-cn.com/problems/gas-station/description/
     *
     * Category	Difficulty	Likes	Dislikes
     * algorithms	Medium (57.28%)	678	-
     * Tags
     * greedy
     * 
     * Companies
     * Unknown
     * 
     * Total Accepted:    110.2K
     * Total Submissions: 192.4K
     * Testcase Example:  '[1,2,3,4,5]\n[3,4,5,1,2]'
     *
     * 在一条环路上有 N 个加油站，其中第 i 个加油站有汽油 gas[i] 升。
     * 
     * 你有一辆油箱容量无限的的汽车，从第 i 个加油站开往第 i+1 个加油站需要消耗汽油 cost[i] 升。你从其中的一个加油站出发，开始时油箱为空。
     * 
     * 如果你可以绕环路行驶一周，则返回出发时加油站的编号，否则返回 -1。
     * 
     * 说明: 
     * 
     * 
     * 如果题目有解，该答案即为唯一答案。
     * 输入数组均为非空数组，且长度相同。
     * 输入数组中的元素均为非负数。
     * 
     * 
     * 示例 1:
     * 
     * 输入: 
     * gas  = [1,2,3,4,5]
     * cost = [3,4,5,1,2]
     * 
     * 输出: 3
     * 
     * 解释:
     * 从 3 号加油站(索引为 3 处)出发，可获得 4 升汽油。此时油箱有 = 0 + 4 = 4 升汽油
     * 开往 4 号加油站，此时油箱有 4 - 1 + 5 = 8 升汽油
     * 开往 0 号加油站，此时油箱有 8 - 2 + 1 = 7 升汽油
     * 开往 1 号加油站，此时油箱有 7 - 3 + 2 = 6 升汽油
     * 开往 2 号加油站，此时油箱有 6 - 4 + 3 = 5 升汽油
     * 开往 3 号加油站，你需要消耗 5 升汽油，正好足够你返回到 3 号加油站。
     * 因此，3 可为起始索引。
     * 
     * 示例 2:
     * 
     * 输入: 
     * gas  = [2,3,4]
     * cost = [3,4,3]
     * 
     * 输出: -1
     * 
     * 解释:
     * 你不能从 0 号或 1 号加油站出发，因为没有足够的汽油可以让你行驶到下一个加油站。
     * 我们从 2 号加油站出发，可以获得 4 升汽油。 此时油箱有 = 0 + 4 = 4 升汽油
     * 开往 0 号加油站，此时油箱有 4 - 3 + 2 = 3 升汽油
     * 开往 1 号加油站，此时油箱有 3 - 3 + 3 = 3 升汽油
     * 你无法返回 2 号加油站，因为返程需要消耗 4 升汽油，但是你的油箱只有 3 升汽油。
     * 因此，无论怎样，你都不可能绕环路行驶一周。
     * 
     */

    // @lc code=start
    public class Solution134 : SolutionBase
    {
        /// <summary>
        /// 难度
        /// </summary>
        public override Difficulity GetDifficulity() { return Difficulity.Medium; }
        /// <summary>
        /// 关键字:
        /// </summary>
        public override string[] GetKeyWords() { return new string[] { "" }; }
        /// <summary>
        /// 标签：
        /// </summary>
        public override Tag[] GetTags() { return new Tag[] { Tag.Greedy }; }

        
        public override bool Test(System.Diagnostics.Stopwatch sw)
        {
            bool isSuccess = true;
            isSuccess &= CanCompleteCircuit(new int[] { 1, 2, 3, 4, 5 }, new int[] { 3, 4, 5, 1, 2 }) == 3;
            return isSuccess;
        }

        /// <summary>
        /// 作者：cyaycz
        /// 链接：https://leetcode-cn.com/problems/gas-station/solution/shi-yong-tu-de-si-xiang-fen-xi-gai-wen-ti-by-cyayc/
        /// 32/32 cases passed (100 ms)
        /// Your runtime beats 98.53 % of csharp submissions
        /// Your memory usage beats 100 % of csharp submissions(24.4 MB)
        /// </summary>
        /// <param name="gas"></param>
        /// <param name="cost"></param>
        /// <returns></returns>
        public int CanCompleteCircuit(int[] gas, int[] cost)
        {
            int len = gas.Length;
            int spare = 0;
            int minSpare = int.MaxValue;
            int minIndex = 0;

            for (int i = 0; i < len; i++)
            {
                spare += gas[i] - cost[i];
                if (spare < minSpare)
                {
                    minSpare = spare;
                    minIndex = i;
                }
            }
            return spare < 0 ? -1 : (minIndex + 1) % len;
        }
    }
    // @lc code=end


}
