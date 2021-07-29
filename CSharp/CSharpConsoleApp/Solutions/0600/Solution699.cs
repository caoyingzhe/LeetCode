using System;
using System.Collections.Generic;
namespace CSharpConsoleApp.Solutions
{
    /*
     * @lc app=leetcode.cn id=699 lang=csharp
     *
     * [699] 掉落的方块
     *
     * https://leetcode-cn.com/problems/falling-squares/description/
     *
     * Category	Difficulty	Likes	Dislikes
     * algorithms	Hard (47.23%)	61	-
     * Tags
     * segment-tree | ordered-map
     * 
     * Companies
     * uber
     * 
     * Total Accepted:    2.5K
     * Total Submissions: 5.2K
     * Testcase Example:  '[[1,2],[2,3],[6,1]]'
     *
     * 在无限长的数轴（即 x 轴）上，我们根据给定的顺序放置对应的正方形方块。
     * 
     * 第 i 个掉落的方块（positions[i] = (left, side_length)）是正方形，其中 left
     * 表示该方块最左边的点位置(positions[i][0])，side_length 表示该方块的边长(positions[i][1])。
     * 
     * 每个方块的底部边缘平行于数轴（即 x 轴），并且从一个比目前所有的落地方块更高的高度掉落而下。在上一个方块结束掉落，并保持静止后，才开始掉落新方块。
     * 
     * 方块的底边具有非常大的粘性，并将保持固定在它们所接触的任何长度表面上（无论是数轴还是其他方块）。邻接掉落的边不会过早地粘合在一起，因为只有底边才具有粘性。
     * 
     * 返回一个堆叠高度列表 ans 。每一个堆叠高度 ans[i] 表示在通过 positions[0], positions[1], ...,
     * positions[i] 表示的方块掉落结束后，目前所有已经落稳的方块堆叠的最高高度。
     * 
     * 
     * 示例 1:
     * 输入: [[1, 2], [2, 3], [6, 1]]
     * 输出: [2, 5, 5]
     * 解释:
     * 
     * 第一个方块 positions[0] = [1, 2] 掉落：
     * _aa
     * _aa
     * -------
     * 方块最大高度为 2 。
     * 
     * 第二个方块 positions[1] = [2, 3] 掉落：
     * __aaa
     * __aaa
     * __aaa
     * _aa__
     * _aa__
     * --------------
     * 方块最大高度为5。
     * 大的方块保持在较小的方块的顶部，不论它的重心在哪里，因为方块的底部边缘有非常大的粘性。
     * 
     * 第三个方块 positions[1] = [6, 1] 掉落：
     * __aaa
     * __aaa
     * __aaa
     * _aa
     * _aa___a
     * -------------- 
     * 方块最大高度为5。
     * 因此，我们返回结果[2, 5, 5]。
     * 
     * 
     * 示例 2:
     * 输入: [[100, 100], [200, 100]]
     * 输出: [100, 100]
     * 解释: 相邻的方块不会过早地卡住，只有它们的底部边缘才能粘在表面上。
     *
     * 
     * 注意:
     * 1 <= n <= 1000.
     * 1 <= positions[i][0] <= 10^8.
     * 1 <= positions[i][1] <= 10^6.
     */

    // @lc code=start
    public class Solution699 : SolutionBase
    {
        /// <summary>
        /// 难易度:
        /// </summary>
        public override Difficulity GetDifficulity() { return Difficulity.Hard; }
        /// <summary>
        /// 关键字:
        /// </summary>
        public override string[] GetKeyWords() { return new string[] { "" }; }
        /// <summary>
        /// 标签： 
        /// </summary>
        public override Tag[] GetTags() { return new Tag[] { Tag.SegmentTree, Tag.OrderedMap }; }

        public override bool Test(System.Diagnostics.Stopwatch sw)
        {
            bool isSuccess = true;
            int[][] points;
            IList<int> result, checkResult;

            points = new int[][]
            {
                new int[] { 1,2},
                new int[] { 2,3},
                new int[] { 6,1},
            };
            checkResult = new int[] { 2,5,5 } ;
            result = FallingSquares(points);
            isSuccess &= IsSame(result, checkResult);
            PrintResult(isSuccess, result, checkResult);

            points = new int[][]
            {
                new int[] { 100,100},
                new int[] { 200,100},
            };
            checkResult = new int[] { 100, 100 };
            result = FallingSquares(points);
            isSuccess &= IsSame(result, checkResult);
            PrintResult(isSuccess, result, checkResult);

            return isSuccess;
        }

        /// <summary>
        /// 方法1 ： 模拟方块掉落
        /// 作者：LeetCode
        /// 链接：https://leetcode-cn.com/problems/falling-squares/solution/diao-luo-de-fang-kuai-by-leetcode/
        /// 44/44 cases passed (260 ms)
        /// Your runtime beats 100 % of csharp submissions
        /// Your memory usage beats 100 % of csharp submissions(33.8 MB)
        /// </summary>
        /// <param name="posArr"></param>
        /// <returns></returns>
        public IList<int> FallingSquares(int[][] posArr)
        {
            int n = posArr.Length;

            //qans[i] 表示 positions[i] 的最大高度。
            int[] qans = new int[n];
            for (int i = 0; i < n; i++)
            {
                int L = posArr[i][0];
                int size = posArr[i][1];
                int R = L + size;

                //方块掉落高度
                qans[i] += size;

                //后续层 模拟方块掉落
                for (int j = i + 1; j < n; j++)
                {
                    int L2 = posArr[j][0];
                    int size2 = posArr[j][1];
                    int R2 = L2 + size2;

                    //方块掉落条件：
                    if (L2 < R && L < R2)
                    { //intersect
                        qans[j] = Math.Max(qans[j], qans[i]);
                    }
                }
            }

            List<int> ans = new List<int>();
            int cur = -1;
            foreach (int x in qans)
            {
                cur = Math.Max(cur, x);
                ans.Add(cur);
            }
            return ans;
        }
    }
    // @lc code=end
}
