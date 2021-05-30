using System;
using System.Collections.Generic;
namespace CSharpConsoleApp.Solutions
{
    /*
     * @lc app=leetcode.cn id=542 lang=csharp
     *
     * [542] 01 矩阵
     *
     * https://leetcode-cn.com/problems/01-matrix/description/
     *
     * Category	Difficulty	Likes	Dislikes
     * algorithms	Medium (45.59%)	428	-
     * Tags
     * depth-first-search | breadth-first-search
     * 
     * Companies
     * google
     * 
     * Total Accepted:    52.5K
     * Total Submissions: 115.1K
     * Testcase Example:  '[[0,0,0],[0,1,0],[0,0,0]]'
     *
     * 给定一个由 0 和 1 组成的矩阵，找出每个元素到最近的 0 的距离。
     * 
     * 两个相邻元素间的距离为 1 。
     * 
     * 示例 1：
     * 输入：
     * [[0,0,0],
     * ⁠[0,1,0],
     * ⁠[0,0,0]]
     * 
     * 输出：
     * [[0,0,0],
     * [0,1,0],
     * [0,0,0]]
     * 
     * 
     * 示例 2：
     * 输入：
     * [[0,0,0],
     * ⁠[0,1,0],
     * ⁠[1,1,1]]
     * 
     * 输出：
     * [[0,0,0],
     * ⁠[0,1,0],
     * ⁠[1,2,1]]
     * 
     * 
     * 提示：
     * 给定矩阵的元素个数不超过 10000。
     * 给定矩阵中至少有一个元素是 0。
     * 矩阵中的元素只在四个方向上相邻: 上、下、左、右。
     */
    public class Solution542 : SolutionBase
    {
        /// <summary>
        /// 难度
        /// </summary>
        public override Difficulity GetDifficulity() { return Difficulity.Medium; }
        /// <summary>
        /// 关键字:
        /// </summary>
        public override string[] GetKeyWords() { return new string[] { "矩阵" }; }
        /// <summary>
        /// 标签： 
        /// </summary>
        public override Tag[] GetTags() { return new Tag[] { Tag.DepthFirstSearch, Tag.BreadthFirstSearch }; }

        public override bool Test(System.Diagnostics.Stopwatch sw)
        {
            return true;
        }
            #region ---------------- BFS -----------------------
            //作者：LeetCode-Solution
            //链接：https://leetcode-cn.com/problems/01-matrix/solution/01ju-zhen-by-leetcode-solution/

            //上下左右索引偏移列表
            static int[][] dirs = new int[][] {
            new int[]{ -1, 0 },  //Left
            new int[]{ 1, 0 },   //Right
            new int[]{ 0, -1 },  //Up
            new int[]{ 0, 1 }    //Down
        };

        /// <summary>
        /// 方法一：广度优先搜索
        /// 时间复杂度：O(rc)，其中 r 为矩阵行数，c 为矩阵列数，
        /// 空间复杂度：O(rc)
        /// </summary>
        public int[][] UpdateMatrix(int[][] matrix)
        {
            int m = matrix.Length, n = matrix[0].Length;
            int[][] dist = new int[m][];    //处理结果
            bool[][] seen = new bool[m][];  //是否处理过的2维表
            for (int i = 0; i < m; i++)
            {
                dist[i] = new int[n];
                seen[i] = new bool[n];
            }
            
            LinkedList<int[]> queue = new LinkedList<int[]>();
            // 将所有的 0 添加进初始队列中
            for (int i = 0; i < m; ++i)
            {
                for (int j = 0; j < n; ++j)
                {
                    if (matrix[i][j] == 0)
                    {
                        queue.AddLast(new int[] { i, j });
                        seen[i][j] = true;
                    }
                }
            }

            // 广度优先搜索
            while (queue.Count != 0)
            {
                //取出处理每次扩展的节点（节点中保存着xy的索引）
                int[] cell = queue.First.Value; //queue.poll()
                int i = cell[0], j = cell[1];
                queue.RemoveFirst();

                //对上下左右扫描（dirs保存者上下左右xy偏移）
                for (int d = 0; d < 4; ++d)
                {
                    int ni = i + dirs[d][0]; //x偏移
                    int nj = j + dirs[d][1]; //y偏移

                    //如果xy未超边界，并且未处理（数据保存于seen二维表中)
                    if (ni >= 0 && ni < m && nj >= 0 && nj < n && !seen[ni][nj])
                    {
                        dist[ni][nj] = dist[i][j] + 1;
                        queue.AddLast(new int[] { ni, nj });
                        seen[ni][nj] = true;
                    }
                }
            }
            return dist;
        }
        #endregion
        #region ---------------- DFS -----------------------
        #endregion
    }
}
