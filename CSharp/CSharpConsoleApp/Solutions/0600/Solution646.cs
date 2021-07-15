using System;
using System.Collections.Generic;
namespace CSharpConsoleApp.Solutions
{
    /*
     * @lc app=leetcode.cn id=646 lang=csharp
     *
     * [646] 最长数对链
     *
     * https://leetcode-cn.com/problems/maximum-length-of-pair-chain/description/
     *
     * Category	Difficulty	Likes	Dislikes
     * algorithms	Medium (57.31%)	167	-
     * Tags
     * dynamic-programming
     * 
     * Companies
     * amazon
     * Total Accepted:    19.1K
     * Total Submissions: 33.3K
     * Testcase Example:  '[[1,2],[2,3],[3,4]]'
     *
     * 给出 n 个数对。 在每一个数对中，第一个数字总是比第二个数字小。
     * 
     * 现在，我们定义一种跟随关系，当且仅当 b < c 时，数对(c, d) 才可以跟在 (a, b) 后面。我们用这种形式来构造一个数对链。
     * 
     * 给定一个数对集合，找出能够形成的最长数对链的长度。你不需要用到所有的数对，你可以以任何顺序选择其中的一些数对来构造。
     * 
     * 
     * 
     * 示例：
     * 输入：[[1,2], [2,3], [3,4]]
     * 输出：2
     * 解释：最长的数对链是 [1,2] -> [3,4]
     * 
     * 
     * 
     * 提示：
     * 给出数对的个数在 [1, 1000] 范围内。
     */

    // @lc code=start
    public class Solution646 : SolutionBase
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
        public override Tag[] GetTags() { return new Tag[] { Tag.Tree }; }

        public const int N = int.MinValue;
        /// <summary>
        /// TODO  没理解
        /// 160/160 cases passed (124 ms)
        /// Your runtime beats 100 % of csharp submissions
        /// Your memory usage beats 88.89 % of csharp submissions(28.2 MB)
        /// </summary>
        /// <param name="sw"></param>
        /// <returns></returns>
        public override bool Test(System.Diagnostics.Stopwatch sw)
        {
            bool isSuccess = true;
            int[][] pairs;
            int result, checkResult;

            checkResult = 2;
            pairs = new int[][]
            {
                new int[] {1,2},
                new int[] {3,4},
                new int[] {2,4},
                new int[] {3,5},
                new int[] {2,3},
            };

            result = FindLongestChain(pairs);
            isSuccess &= IsSame(result, checkResult);
            PrintResult(isSuccess, result, checkResult);
            return isSuccess;
        }

        //作者：LeetCode
        //链接：https://leetcode-cn.com/problems/maximum-length-of-pair-chain/solution/zui-chang-shu-dui-lian-by-leetcode/
        ///205/205 cases passed(312 ms)
        ///Your runtime beats 10 % of csharp
        ///Your memory usage beats 20 % of csharp submissions(30.4 MB)
        public int FindLongestChain(int[][] pairs)
        {
            //Arrays.sort(pairs, (a, b)->a[0] - b[0]);
            List<int[]> list = new List<int[]>(pairs);
            list.Sort((a, b) =>a[0] - b[0]);
            
            int N = list.Count;
            int[] dp = new int[N];
            for (int m = 0; m < N; ++m) dp[m] = 1;

            for (int j = 1; j < N; ++j)
            {
                for (int i = 0; i < j; ++i)
                {
                    if (list[i][1] < list[j][0])
                        dp[j] = Math.Max(dp[j], dp[i] + 1);
                }
            }

            int ans = 0;
            foreach (int x in dp) if (x > ans) ans = x;
            return ans;
        }
    }
    // @lc code=end


}
