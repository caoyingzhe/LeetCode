using System;
using System.Collections.Generic;
namespace CSharpConsoleApp.Solutions
{
    /*
 * @lc app=leetcode.cn id=554 lang=csharp
 *
 * [554] 砖墙
 *
 * https://leetcode-cn.com/problems/brick-wall/description/
 *
 * Category	Difficulty	Likes	Dislikes
 * algorithms	Medium (49.89%)	241	-
 * Tags
 * hash-table
 * 
 * Companies
 * facebook
 * 
 * Total Accepted:    43K
 * Total Submissions: 86.2K
 * Testcase Example:  '[[1,2,2,1],[3,1,2],[1,3,2],[2,4],[3,1,2],[1,3,1,1]]'
 *
 * 你的面前有一堵矩形的、由 n 行砖块组成的砖墙。这些砖块高度相同（也就是一个单位高）但是宽度不同。每一行砖块的宽度之和相等。
 * 
 * 你现在要画一条 自顶向下 的、穿过 最少
 * 砖块的垂线。如果你画的线只是从砖块的边缘经过，就不算穿过这块砖。你不能沿着墙的两个垂直边缘之一画线，这样显然是没有穿过一块砖的。
 * 
 * 给你一个二维数组 wall ，该数组包含这堵墙的相关信息。其中，wall[i] 是一个代表从左至右每块砖的宽度的数组。你需要找出怎样画才能使这条线
 * 穿过的砖块数量最少 ，并且返回 穿过的砖块数量 。
 * 
 * 
 * 示例 1：
 * 输入：wall = [[1,2,2,1],[3,1,2],[1,3,2],[2,4],[3,1,2],[1,3,1,1]]
 * 输出：2
 * 
 * 
 * 示例 2：
 * 输入：wall = [[1],[1],[1]]
 * 输出：3
 * 
 * 
 * 提示：
 * n == wall.length
 * 1 <= n <= 10^4
 * 1 <= wall[i].length <= 10^4
 * 1 <= sum(wall[i].length) <= 2 * 10^4
 * 对于每一行 i ，sum(wall[i]) 是相同的
 * 1 <= wall[i][j] <= 231 - 1
 */

    // @lc code=start
    public class Solution545 : SolutionBase
    {
        /// <summary>
        /// 难度
        /// </summary>
        public override Difficulity GetDifficulity() { return Difficulity.Medium; }
        /// <summary>
        /// 关键字:
        /// </summary>
        public override string[] GetKeyWords() { return new string[] { "待理解好题", }; }
        /// <summary>
        /// 标签：
        /// </summary>
        public override Tag[] GetTags() { return new Tag[] { Tag.HashTable }; }


        public override bool Test(System.Diagnostics.Stopwatch sw)
        {
            bool isSuccess = true;
            isSuccess &= Test(
                new int[][] {
                    new int[] { 1, 2, 2, 1 },
                    new int[] { 3, 1, 2 },
                    new int[] { 1, 3, 2 },
                    new int[] { 2, 4 },
                    new int[] { 3, 1, 2 },
                    new int[] { 1, 3, 1, 1 }
                }, 2
            );
            isSuccess &= Test(
                new int[][] {
                   new int[] {1},
                   new int[] {1},
                   new int[] {1},
                },
                3
            );
            //-2,0,-1
            return isSuccess;
        }
        public bool Test(IList<IList<int>> nums, int checkResult)
        {
            bool isSuccess = true;
            int result = LeastBricks(nums);
            isSuccess = IsSame(result, checkResult);
            PrintResult(isSuccess, result, checkResult);
            return isSuccess;
        }

        /// <summary>
        /// 87/87 cases passed (136 ms)
        /// Your runtime beats 100 % of csharp submissions
        /// Your memory usage beats 78.75 % of csharp submissions(35 MB)
        /// </summary>
        /// <param name="wall"></param>
        /// <returns></returns>
        public int LeastBricks(IList<IList<int>> wall)
        {
            Dictionary<int, int> cnt = new Dictionary<int, int>();
            foreach (IList<int> widths in wall)
            {
                int n = widths.Count;
                int sum = 0;
                for (int i = 0; i < n - 1; i++)
                {
                    sum += widths[i];
                    if (!cnt.ContainsKey(sum))
                    {
                        cnt.Add(sum, 1);
                    }
                    else
                    {
                        cnt[sum]++;
                    }
                }
            }
            int maxCnt = 0;
            foreach (var entry in cnt)
            {
                maxCnt = Math.Max(maxCnt, entry.Value);
            }
            return wall.Count - maxCnt;
        }

        //作者：LeetCode-Solution
        //链接：https://leetcode-cn.com/problems/brick-wall/solution/zhuan-qiang-by-leetcode-solution-2kls/

    }
    // @lc code=end


}
