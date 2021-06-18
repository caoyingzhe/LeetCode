using System;
using System.Collections.Generic;
namespace CSharpConsoleApp.Solutions
{
    /*
     * @lc app=leetcode.cn id=447 lang=csharp
     *
     * [447] 回旋镖的数量
     *
     * https://leetcode-cn.com/problems/number-of-boomerangs/description/
     *
     * Category	Difficulty	Likes	Dislikes
     * algorithms	Medium (60.01%)	137	-
     * Tags
     * hash-table
     * 
     * Companies
     * google
     * Total Accepted:    20K
     * Total Submissions: 33.3K
     * Testcase Example:  '[[0,0],[1,0],[2,0]]'
     *
     * 给定平面上 n 对 互不相同 的点 points ，其中 points[i] = [xi, yi] 。回旋镖 是由点 (i, j, k) 表示的元组
     * ，其中 i 和 j 之间的距离和 i 和 k 之间的距离相等（需要考虑元组的顺序）。
     * 返回平面上所有回旋镖的数量。
     * 
     * 
     * 示例 1：
     * 输入：points = [[0,0],[1,0],[2,0]]
     * 输出：2
     * 解释：两个回旋镖为 [[1,0],[0,0],[2,0]] 和 [[1,0],[2,0],[0,0]]
     * 
     * 
     * 示例 2：
     * 输入：points = [[1,1],[2,2],[3,3]]
     * 输出：2
     * 
     * 
     * 示例 3：
     * 输入：points = [[1,1]]
     * 输出：0
     * 
     * 提示：
     * n == points.length
     * 1 <= n <= 500
     * points[i].length == 2
     * -10^4 <= xi, yi <= 10^4
     * 所有点都 互不相同
     */
    public class Solution447 : SolutionBase
    {
        /// <summary>
        /// 难易度:
        /// </summary>
        public override Difficulity GetDifficulity() { return Difficulity.Medium; }
        /// <summary>
        /// 关键字:
        /// </summary>
        public override string[] GetKeyWords() { return new string[] { }; }
        /// <summary>
        /// 标签： 图
        /// </summary>
        public override Tag[] GetTags() { return new Tag[] { Tag.HashTable }; }

        public override bool Test(System.Diagnostics.Stopwatch sw)
        {
            bool isSuccess = true;
            return isSuccess;
        }

        /// <summary>
        /// 32/32 cases passed (284 ms)
        /// Your runtime beats 52.94 % of csharp submissions
        /// Your memory usage beats 47.06 % of csharp submissions(45.4 MB)
        /// 1. 对于每个点p1，遍历points所有点，找到与其距离相同的点个数，统计结果放在字典中，
        /// 2. 遍历字典，每一组相同的点，可以两两构成的组合数为
        /// 比如，三个点到p1距离相同，那么其可以构成的两两组合数量为3 * 2 = 6种，因为组合是区分顺序的，无需除以2
        /// </summary>
        /// <param name="points"></param>
        /// <returns></returns>
        public int NumberOfBoomerangs(int[][] points)
        {
            var ans = 0;
            //双循环可优化。（因为AB和BA虽然为2个组合，但是距离一样，对计算个数没有影响，X2即可）
            foreach (var p1 in points)
            {
                //key: 距离平方, value: 相同距离的坐标对儿的个数
                var map = new Dictionary<int, int>();
                foreach (var p2 in points)
                {
                    var dx = p1[0] - p2[0];
                    var dy = p1[1] - p2[1];
                    int dictPow = dx * dx + dy * dy;
                    if (map.ContainsKey(dictPow))
                    {
                        map[dictPow]++;
                    }
                    else
                    {
                        map.Add(dictPow, 1);
                    }
                }
                ///此处可优化。
                foreach (var x in map)
                {
                    ans += x.Value * (x.Value - 1);
                }
            }
            return ans;
        }
    }
}
