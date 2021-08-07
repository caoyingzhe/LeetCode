using System;
using System.Collections.Generic;
namespace CSharpConsoleApp.Solutions
{
    /*
     * @lc app=leetcode.cn id=436 lang=csharp
     *
     * [436] 寻找右区间
     *
     * https://leetcode-cn.com/problems/find-right-interval/description/
     *
     * algorithms
     * Medium (48.80%)
     * Likes:    75
     * Dislikes: 0
     * Total Accepted:    7.9K
     * Total Submissions: 16.2K
     * Testcase Example:  '[[1,2]]'
     *
     * 给你一个区间数组 intervals ，其中 intervals[i] = [starti, endi] ，且每个 starti 都 不同 。
     * 区间 i 的 右侧区间 可以记作区间 j ，并满足 startj >= endi ，且 startj 最小化 。
     * 返回一个由每个区间 i 的 右侧区间 的最小起始位置组成的数组。如果某个区间 i 不存在对应的 右侧区间 ，则下标 i 处的值设为 -1 。
     * 
     * 
     * 示例 1：
     * 输入：intervals = [[1,2]]
     * 输出：[-1]
     * 解释：集合中只有一个区间，所以输出-1。
     * 
     * 
     * 示例 2：
     * 输入：intervals = [[3,4],[2,3],[1,2]]
     * 输出：[-1, 0, 1]
     * 解释：对于 [3,4] ，没有满足条件的“右侧”区间。
     * 对于 [2,3] ，区间[3,4]具有最小的“右”起点;
     * 对于 [1,2] ，区间[2,3]具有最小的“右”起点。
     * 
     * 
     * 示例 3：
     * 输入：intervals = [[1,4],[2,3],[3,4]]
     * 输出：[-1, 2, -1]
     * 解释：对于区间 [1,4] 和 [3,4] ，没有满足条件的“右侧”区间。
     * 对于 [2,3] ，区间 [3,4] 有最小的“右”起点。
     * 
     * 
     * 提示：
     * 1 <= intervals.length <= 2 * 10^4
     * intervals[i].length == 2
     * -10^6 <= starti <= endi <= 10^6
     */

    // @lc code=start
    public class Solution436 : SolutionBase
    {
        /// <summary>
        /// 难度
        /// </summary>
        public override Difficulity GetDifficulity() { return Difficulity.Easy; }
        /// <summary>
        /// 关键字:
        /// </summary>
        public override string[] GetKeyWords() { return new string[] { "掌握" }; }
        /// <summary>
        /// 标签：
        /// </summary>
        public override Tag[] GetTags() { return new Tag[] { Tag.BinarySearch }; }

        /// <summary>
        /// </summary>
        /// <param name="sw"></param>
        /// <returns></returns>
        public override bool Test(System.Diagnostics.Stopwatch sw)
        {
            bool isSuccess = true;

            int[][] nums;
            int[] result, checkResult;

            nums = new int[][] {
                new int[] { 1,2 }
            };
            checkResult = new int[] { -1};
            result = FindRightInterval(nums);
            isSuccess &= IsArraySame(result, checkResult);
            PrintResult(isSuccess, GetArrayStr(result), GetArrayStr(checkResult));

            nums = new int[][] {
                new int[] { 3,4 },new int[] { 2,3 },new int[] { 1,2 }
            };
            checkResult = new int[] { -1, 0, 1 };
            result = FindRightInterval(nums);
            isSuccess &= IsArraySame(result, checkResult);
            PrintResult(isSuccess, GetArrayStr(result), GetArrayStr(checkResult));

            nums = new int[][] {
                new int[] { 1,4},new int[] { 2,3 },new int[] { 3,4 }
            };
            checkResult = new int[] { -1, 2, -1 };
            result = FindRightInterval(nums);
            isSuccess &= IsArraySame(result, checkResult);
            PrintResult(isSuccess, GetArrayStr(result), GetArrayStr(checkResult));

            //1,1],[3,4
            nums = new int[][] {
                new int[] { 1,1},new int[] { 3,4 }
            };
            checkResult = new int[] { 0, -1 };
            result = FindRightInterval(nums);
            isSuccess &= IsArraySame(result, checkResult);
            PrintResult(isSuccess, GetArrayStr(result), GetArrayStr(checkResult));

            return isSuccess;
        }

        //作者：LeetCode
        //链接：https://leetcode-cn.com/problems/find-right-interval/solution/xun-zhao-you-qu-jian-by-leetcode/
        /// <summary>
        /// 19/19 cases passed (1008 ms)
        /// Your runtime beats 50 % of csharp submissions
        /// Your memory usage beats 16.67 % of csharp submissions(43.9 MB)
        /// </summary>
        /// <param name="intervals"></param>
        /// <returns></returns>
        public int[] FindRightInterval(int[][] intervals)
        {
            int n = intervals.Length;
            int[] res = new int[n];
            //保存排序前的索引到哈希表中
            Dictionary<int[], int> hash = new Dictionary<int[], int>();
            for (int i = 0; i < n; i++)
            {
                hash.Add(intervals[i], i);
            }
            //对原数组排序。
            Array.Sort(intervals, (a, b) => a[0] - b[0]);
            //循环寻找最小的右边缘对应的范围数组的索引（可优化部分）
            for (int i = 0; i < n; i++)
            {
                int min = int.MaxValue;
                int minindex = -1;
                for (int j = i; j < n; j++)
                {
                    if (intervals[j][0] >= intervals[i][1] && intervals[j][0] < min)
                    {
                        min = intervals[j][0];
                        minindex = hash[intervals[j]];
                    }
                }
                res[hash[intervals[i]]] = minindex;
            }
            return res;
        }
    }
    // @lc code=end


}
