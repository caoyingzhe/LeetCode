using System;
namespace CSharpConsoleApp.Solutions
{
    /*
 * @lc app=leetcode.cn id=474 lang=csharp
 *
 * [474] 一和零
 *
 * https://leetcode-cn.com/problems/ones-and-zeroes/description/
 *
 * Category	Difficulty	Likes	Dislikes
 * algorithms	Medium (60.14%)	508	-
 * Tags
 * dynamic-programming
 * 
 * Companies
 * google
 * 
 * Total Accepted:    63.9K
 * Total Submissions: 106K
 * Testcase Example:  '["10","0001","111001","1","0"]\n5\n3'
 *
 * 给你一个二进制字符串数组 strs 和两个整数 m 和 n 。
 * 
 * 请你找出并返回 strs 的最大子集的大小，该子集中 最多 有 m 个 0 和 n 个 1 。
 * 
 * 如果 x 的所有元素也是 y 的元素，集合 x 是集合 y 的 子集 。
 * 
 * 示例 1：
 * 输入：strs = ["10", "0001", "111001", "1", "0"], m = 5, n = 3
 * 输出：4
 * 解释：最多有 5 个 0 和 3 个 1 的最大子集是 {"10","0001","1","0"} ，因此答案是 4 。
 * 其他满足题意但较小的子集包括 {"0001","1"} 和 {"10","1","0"} 。{"111001"} 不满足题意，因为它含 4 个 1
 * ，大于 n 的值 3 。
 * 
 * 
 * 示例 2：
 * 输入：strs = ["10", "0", "1"], m = 1, n = 1
 * 输出：2
 * 解释：最大的子集是 {"0", "1"} ，所以答案是 2 。
 * 
 * 提示：
 * 1 <= strs.length <= 600
 * 1 <= strs[i].length <= 100
 * strs[i] 仅由 '0' 和 '1' 组成
 * 1 <= m, n <= 100
 */

    public class Solution474 : SolutionBase
    {
        /// <summary>
        /// 难度
        /// </summary>
        public override Difficulity GetDifficulity() { return Difficulity.Hard; }
        /// <summary>
        /// 关键字:
        /// </summary>
        public override string[] GetKeyWords() { return new string[] { "" }; }
        /// <summary>
        /// 标签：
        /// </summary>
        public override Tag[] GetTags() { return new Tag[] { Tag.DynamicProgramming, }; }

        public override bool Test(System.Diagnostics.Stopwatch sw)
        {
            bool isSuccess = true;
            int[][] dungeon;
            int result, checkResult;

            checkResult = 7;
            dungeon = new int[][]
            {
                new int[] { -2, -3, 3},
                new int[] { -5,-10, 1},
                new int[] { 10, 30, -5},
            };
            return isSuccess;
        }

        /// <summary>
        /// 70/70 cases passed (164 ms)
        /// Your runtime beats 98.48 % of csharp submissions
        /// Your memory usage beats 58.58 % of csharp submissions(25.2 MB)
        /// 作者：AC_OIer 宫水三叶
        /// 链接：https://leetcode-cn.com/problems/ones-and-zeroes/solution/gong-shui-san-xie-xiang-jie-ru-he-zhuan-174wv/
        /// </summary>
        /// <param name="strs"></param>
        /// <param name="m"></param>
        /// <param name="n"></param>
        /// <returns></returns>
        public int FindMaxForm(string[] strs, int m, int n)
        {
            int len = strs.Length;
            int[][] cnt = new int[len][];
            for (int r = 0; r < len; r++) cnt[r] = new int[2];

            for (int i = 0; i < len; i++)
            {
                int zero = 0, one = 0;
                foreach (char c in strs[i].ToCharArray())
                {
                    if (c == '0') zero++;
                    else one++;
                }
                cnt[i] = new int[] { zero, one };
            }
            int[][] f = new int[m + 1][];
            for (int r = 0; r < m + 1; r++) f[r] = new int[n + 1];

            for (int k = 0; k < len; k++)
            {
                int zero = cnt[k][0], one = cnt[k][1];
                for (int i = m; i >= zero; i--)
                {
                    for (int j = n; j >= one; j--)
                    {
                        f[i][j] = Math.Max(f[i][j], f[i - zero][j - one] + 1);
                    }
                }
            }
            return f[m][n];
        }
    }
}
