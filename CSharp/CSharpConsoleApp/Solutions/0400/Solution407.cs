using System;
using System.Collections.Generic;
namespace CSharpConsoleApp.Solutions
{
    /*
     * @lc app=leetcode.cn id=407 lang=csharp
     *
     * [407] 接雨水 II
     *
     * https://leetcode-cn.com/problems/trapping-rain-water-ii/description/
     *
     * algorithms
     * Hard (47.44%)
     * Likes:    342
     * Dislikes: 0
     * Total Accepted:    8.4K
     * Total Submissions: 17.7K
     * Testcase Example:  '[[1,4,3,1,3,2],[3,2,1,3,2,4],[2,3,3,2,3,1]]'
     * 给你一个 m x n 的矩阵，其中的值均为非负整数，代表二维高度图每个单元的高度，请计算图中形状最多能接多少体积的雨水。
     * 
     * 示例：
     * 给出如下 3x6 的高度图:
     * [
     * ⁠ [1,4,3,1,3,2],
     * ⁠ [3,2,1,3,2,4],
     * ⁠ [2,3,3,2,3,1]
     * ]
     * 
     * 返回 4 。
     * 
     * 如上图所示，这是下雨前的高度图[[1,4,3,1,3,2],[3,2,1,3,2,4],[2,3,3,2,3,1]] 的状态。
     * 下雨后，雨水将会被存储在这些方块中。总的接雨水量是4。
     * 
     * 
     * 提示：
     * 1 <= m, n <= 110
     * 0 <= heightMap[i][j] <= 20000
     */
    public class Solution407 : SolutionBase
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
        public override Tag[] GetTags() { return new Tag[] { Tag.Heap, Tag.BreadthFirstSearch }; }

        public override bool Test(System.Diagnostics.Stopwatch sw)
        {
            bool isSuccess = true;
            int[][] heights;
            int result, checkResult;
            heights = new int[][]
            {
                new int[] {1, 4, 3, 1, 3, 2},
                new int[] {3, 2, 1, 3, 2, 4},
                new int[] {2, 3, 3, 2, 3, 1 },
            };

            checkResult = 4;
            result = TrapRainWater(heights);
            isSuccess &= result == checkResult;
            Print("isSuccess = {0} | result= {1} | checkResult= {2} | ", isSuccess, (result), (checkResult));

            return isSuccess;
        }

        /// <summary>
        /// 42/42 cases passed (212 ms)
        /// Your runtime beats 50 % of csharp submissions
        /// Your memory usage beats 75 % of csharp submissions(30 MB)
        /// </summary>
        /// <param name="heights"></param>
        /// <returns></returns>
        public int TrapRainWater(int[][] heights)
        {
            int n = heights.Length;
            int m = heights[0].Length;

            if (m <= 2 || n <= 2)
                return 0;

            // 用一个vis数组来标记这个位置有没有被访问过
            bool[][] vis = new bool[n][];
            for (int v = 0; v < n; v++) vis[v] = new bool[m];
            // 优先队列中存放三元组 [x,y,h] 坐标和高度
            PriorityQueue<int[]> pq = new PriorityQueue<int[]> (new ComparerSolution407());

            // 先把最外一圈放进去
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    if (i == 0 || i == n - 1 || j == 0 || j == m - 1)
                    {
                        pq.Push(new int[] { i, j, heights[i][j] });
                        vis[i][j] = true;
                    }
                }
            }
            int res = 0;
            // 方向数组，把dx和dy压缩成一维来做
            int[] dirs = { -1, 0, 1, 0, -1 };
            while (pq.Count != 0)
            {
                int[] poll = pq.Pop();
                // 看一下周围四个方向，没访问过的话能不能往里灌水
                for (int k = 0; k < 4; k++)
                {
                    int nx = poll[0] + dirs[k];
                    int ny = poll[1] + dirs[k + 1];
                    // 如果位置合法且没访问过
                    if (nx >= 0 && nx < n && ny >= 0 && ny < m && !vis[nx][ny])
                    {
                        // 如果外围这一圈中最小的比当前这个还高，那就说明能往里面灌水啊
                        if (poll[2] > heights[nx][ny])
                        {
                            res += poll[2] - heights[nx][ny];
                        }
                        // 如果灌水高度得是你灌水后的高度了，如果没灌水也要取高的
                        pq.Push(new int[] { nx, ny, Math.Max(heights[nx][ny], poll[2]) });
                        vis[nx][ny] = true;
                    }
                }
            }
            return res;
        }
        //作者：jerry_nju
        //链接：https://leetcode-cn.com/problems/trapping-rain-water-ii/solution/you-xian-dui-lie-de-si-lu-jie-jue-jie-yu-shui-ii-b/
    }

    //public class ComparerSolution239 : IComparer<int[]>
    public class ComparerSolution407 : IComparer<int[]>
    {
        public int Compare(int[] pair1, int[] pair2)
        {
            if(pair2[2] != pair1[2])
                return pair2[2] - pair1[2]; //升序
            else if (pair2[0] != pair1[0])
            {
                return pair2[0] - pair1[0]; //升序
            }
            else// (pair2[0] != pair1[0])
            {
                return pair2[1] - pair1[1]; //升序
            }
        }
    }
}
