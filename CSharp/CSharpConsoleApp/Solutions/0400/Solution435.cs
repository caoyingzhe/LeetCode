using System;
using System.Collections.Generic;
namespace CSharpConsoleApp.Solutions
{
    /*
 * @lc app=leetcode.cn id=435 lang=csharp
 *
 * [435] 无重叠区间
 *
 * https://leetcode-cn.com/problems/non-overlapping-intervals/description/
 *
 * Category	Difficulty	Likes	Dislikes
 * algorithms	Medium (50.86%)	458	-
 * Tags
 * greedy
 * 
 * Companies
 * Unknown
 * 
 * Total Accepted:    80.9K
 * Total Submissions: 158.5K
 * Testcase Example:  '[[1,2],[2,3],[3,4],[1,3]]'
 *
 * 给定一个区间的集合，找到需要移除区间的最小数量，使剩余区间互不重叠。
 * 
 * 注意:
 * 
 * 
 * 可以认为区间的终点总是大于它的起点。
 * 区间 [1,2] 和 [2,3] 的边界相互“接触”，但没有相互重叠。
 * 
 * 示例 1:
 * 输入: [ [1,2], [2,3], [3,4], [1,3] ]
 * 
 * 输出: 1
 * 解释: 移除 [1,3] 后，剩下的区间没有重叠。
 * 
 * 示例 2:
 * 输入: [ [1,2], [1,2], [1,2] ]
 * 
 * 输出: 2
 * 解释: 你需要移除两个 [1,2] 来使剩下的区间没有重叠。
 * 
 * 示例 3:
 * 输入: [ [1,2], [2,3] ]
 * 
 * 输出: 0
 * 解释: 你不需要移除任何区间，因为它们已经是无重叠的了。
 */

    // @lc code=start
    public class Solution435 : SolutionBase
    {
        /// <summary>
        /// 难易度:
        /// </summary>
        public override Difficulity GetDifficulity() { return Difficulity.Medium; }
        /// <summary>
        /// 关键字:
        /// </summary>
        public override string[] GetKeyWords() { return new string[] { "" }; }
        /// <summary>
        /// 标签： 
        /// </summary>
        public override Tag[] GetTags() { return new Tag[] { Tag.Design }; }

        public override bool Test(System.Diagnostics.Stopwatch sw)
        {
            bool isSuccess = false;
            int[][] intervals;
            int result, checkResult;

            intervals = new int[][] {
                new int[] { 1,2},
                new int[] { 2,3},
                new int[] { 3,4},
                new int[] { 1,3}
            };
            checkResult = 1;
            result = EraseOverlapIntervals(intervals);
            isSuccess &= IsSame(result, checkResult);
            PrintResult(isSuccess, result, checkResult);

            intervals = new int[][] {
                new int[] { 1,2},
                new int[] { 1,2},
                new int[] { 1,2},
            };
            checkResult = 2;
            result = EraseOverlapIntervals(intervals);
            isSuccess &= IsSame(result, checkResult);
            PrintResult(isSuccess, result, checkResult);

            intervals = new int[][] {
                new int[] { 1,2},
                new int[] { 2,3},
            };
            checkResult = 0;
            result = EraseOverlapIntervals(intervals);
            isSuccess &= IsSame(result, checkResult);
            PrintResult(isSuccess, result, checkResult);

            return isSuccess;
        }
        /// <summary>
        /// 作者：LeetCode-Solution
        /// 链接：https://leetcode-cn.com/problems/non-overlapping-intervals/solution/wu-zhong-die-qu-jian-by-leetcode-solutio-cpsb/
        /// 17/17 cases passed (96 ms)
        /// Your runtime beats 97.73 % of csharp submissions
        /// Your memory usage beats 88.64 % of csharp submissions(26.3 MB)
        /// </summary>
        /// <param name="intervals"></param>
        /// <returns></returns>
        public int EraseOverlapIntervals(int[][] intervalsOrg)
        {
            if (intervalsOrg.Length == 0)
            {
                return 0;
            }

            List<int[]> intervals = new List<int[]>(intervalsOrg);
            //intervals.Sort((int[] interval1, int[] interval2) => 
            //{
            //    return interval1[1] - interval2[1];
            //});
            intervals.Sort((a, b) => { return a[1] != b[1] ? a[1] - b[1] : a[0] - b[0]; });

            int n = intervals.Count;
            int right = intervals[0][1];
            int ans = 1;
            for (int i = 1; i<n; ++i)
            {
                if (intervals[i][0] >= right) {
                    ++ans;
                    right = intervals[i][1];
                }
            }
            return n - ans;
        }
    }
    // @lc code=end
}
