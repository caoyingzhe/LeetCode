using System;
namespace CSharpConsoleApp.Solutions
{
    /*
     * @lc app=leetcode.cn id=455 lang=csharp
     *
     * [455] 分发饼干
     *
     * https://leetcode-cn.com/problems/assign-cookies/description/
     *
     * Category	Difficulty	Likes	Dislikes
     * algorithms	Easy (57.77%)	346	-
     * Tags
     * greedy
     * 
     * Companies
     * Unknown
     * 
     * Total Accepted:    133.4K
     * Total Submissions: 230.8K
     * Testcase Example:  '[1,2,3]\n[1,1]'
     *
     * 假设你是一位很棒的家长，想要给你的孩子们一些小饼干。但是，每个孩子最多只能给一块饼干。
     * 对每个孩子 i，都有一个胃口值 g[i]，这是能让孩子们满足胃口的饼干的最小尺寸；并且每块饼干 j，都有一个尺寸 s[j] 。如果 s[j] >=
     * g[i]，我们可以将这个饼干 j 分配给孩子 i ，这个孩子会得到满足。你的目标是尽可能满足越多数量的孩子，并输出这个最大数值。
     * 
     * 
     * 示例 1:
     * 输入: g = [1,2,3], s = [1,1]
     * 输出: 1
     * 解释: 
     * 你有三个孩子和两块小饼干，3个孩子的胃口值分别是：1,2,3。
     * 虽然你有两块小饼干，由于他们的尺寸都是1，你只能让胃口值是1的孩子满足。
     * 所以你应该输出1。
     * 
     * 
     * 示例 2:
     * 输入: g = [1,2], s = [1,2,3]
     * 输出: 2
     * 解释: 
     * 你有两个孩子和三块小饼干，2个孩子的胃口值分别是1,2。
     * 你拥有的饼干数量和尺寸都足以让所有孩子满足。
     * 所以你应该输出2.
     * 
     * 
     * 提示：
     * 1 <= g.length <= 3 * 10^4
     * 0 <= s.length <= 3 * 10^4
     * 1 <= g[i], s[j] <= 2^31 - 1
     */

    // @lc code=start
    public class Solution455 : SolutionBase
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
        public override Tag[] GetTags() { return new Tag[] { Tag.Greedy }; }

        public int NULL = -1;
        public override bool Test(System.Diagnostics.Stopwatch sw)
        {
            bool isSuccess = true;
            isSuccess &= FindContentChildren(new int[] { 1, 2 }, new int[] { 1, 2, 3 }) == 2;
            return isSuccess;
        }
        /// <summary>
        /// 21/21 cases passed (128 ms)
        /// Your runtime beats 99.09 % of csharp submissions
        /// Your memory usage beats 46.36 % of csharp submissions(30.2 MB)
        /// </summary>
        /// <param name="g"></param>
        /// <param name="s"></param>
        /// <returns></returns>
        public int FindContentChildren(int[] g, int[] s)
        {
            Array.Sort(g);
            Array.Sort(s);
            int childCount = g.Length, cookieCount = s.Length;
            int count = 0;
            for (int i = 0, j = 0; i < childCount && j < cookieCount; i++, j++)
            {
                //当前饼干大小不能满足当前孩子需求时，饼干索引递增
                while (j < cookieCount && g[i] > s[j])
                {
                    j++;
                }
                //只要不超出饼干数量，即满足了当前孩子的需求，满足人数加1。
                if (j < cookieCount) count++;
            }
            return count;
        }
    }
    // @lc code=end


}
