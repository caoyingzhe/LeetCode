using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpConsoleApp.Solutions
{
    /// <summary>
    /// 岛屿数量
    /// </summary>
    class Solution200 : SolutionBase
    {
        /// <summary>
        /// 难度
        /// </summary>
        public override Difficulity GetDifficulity() { return Difficulity.Medium; }
        /// <summary>
        /// 关键字:
        /// </summary>
        public override string[] GetKeyWords() { return new string[] { "DFS","BFS", "阵列包围区域搜索" }; }
        /// <summary>
        /// 标签： depth-first-search | breadth-first-search | union-find
        /// </summary>
        public override Tag[] GetTags() { return new Tag[] { Tag.DepthFirstSearch, Tag.BreadthFirstSearch, Tag.UnionFind }; }

        public override bool Test(System.Diagnostics.Stopwatch sw)
        {
            bool isSuccess = true;
            char[][] grid;
            int result;
            int resultChecked;

            grid = new char[][] {
                new char[] {'1','1','0','0','0'},
                new char[] {'1','1','0','0','0'},
                new char[] {'0','0','1','0','0'},
                new char[] {'0','0','0','1','1'}};

            resultChecked = 3;
            result = NumIslands(grid);
            isSuccess &= result == resultChecked;
            Print("isSuccess = {0} | result= {1} | resultChecked = {2}", isSuccess, result, resultChecked);
            return isSuccess;
        }

        public int NumIslands(char[][] grid)
        {
            return NumIslands_DFS(grid);
            //return NumIslands_BFS(grid);
        }

        #region ------------------ 深度优先搜索--------------------
        /// <summary>
        /// 时间复杂度：O(M * N)
        /// 空间复杂度：O(M * N)
        /// </summary>
        /// <param name="grid"></param>
        /// <returns></returns>
        public int NumIslands_DFS(char[][] grid)
        {
            if (grid == null || grid.Length == 0)
            {
                return 0;
            }

            int nr = grid.Length;
            int nc = grid[0].Length;
            int num_islands = 0;
            for (int r = 0; r < nr; ++r)
            {
                for (int c = 0; c < nc; ++c)
                {
                    if (grid[r][c] == '1')
                    {
                        //最终岛屿的数量就是我们进行深度优先搜索的次数。
                        ++num_islands;
                        DFS(grid, r, c);
                    }
                }
            }

            return num_islands;
        }

        /// <summary>
        /// 深度优先搜索。
        /// 如果一个位置为 1，则以其为起始节点开始进行深度优先搜索。
        /// 在深度优先搜索的过程中，每个搜索到的 1 都会被重新标记为 0。
        /// 为什么要标记为0，因为已经搜索过了，对于上下左右邻接位置的检测处理，设置为0了就不用再重复搜索了。
        /// </summary>
        /// <param name="grid">网格</param>
        /// <param name="r">行索引</param>
        /// <param name="c">列索引</param>
        void DFS(char[][] grid, int r, int c)
        {
            int nr = grid.Length;
            int nc = grid[0].Length;

            if (r < 0 || c < 0 || r >= nr || c >= nc || grid[r][c] == '0')
            {
                return;
            }

            grid[r][c] = '0';
            DFS(grid, r - 1, c);
            DFS(grid, r + 1, c);
            DFS(grid, r, c - 1);
            DFS(grid, r, c + 1);
        }
        #endregion

        #region ------------------ 广度优优先搜索--------------------
        /// <summary>
        /// 时间复杂度：O(MN)
        /// 空间复杂度：O(min(M, N))
        /// </summary>
        /// <param name="grid"></param>
        /// <returns></returns>
        public int NumIslands_BFS(char[][] grid)
        {
            if (grid == null || grid.Length == 0)
            {
                return 0;
            }

            int nr = grid.Length;
            int nc = grid[0].Length;
            int num_islands = 0;

            for (int r = 0; r < nr; ++r)
            {
                for (int c = 0; c < nc; ++c)
                {
                    if (grid[r][c] == '1')
                    {
                        ++num_islands;
                        //为什么要标记为0，因为已经搜索过了，对于上下左右邻接位置的检测处理，设置为0了就不用再重复搜索了。
                        grid[r][c] = '0';
                        LinkedList<int> neighbors = new LinkedList<int>();
                        neighbors.AddLast(r * nc + c);
                        while (neighbors.Count != 0)
                        {
                            //int id = neighbors.remove(); //Java LinkList.remove ：获取并移除此列表的头(第一个元素)。
                            int id = neighbors.First();
                            neighbors.RemoveFirst();

                            int row = id / nc;
                            int col = id % nc;

                            //测试上下左右位置，如果为1，加入邻居中，然后置为0，
                            if (row - 1 >= 0 && grid[row - 1][col] == '1')
                            {
                                neighbors.AddLast((row - 1) * nc + col);
                                grid[row - 1][col] = '0';
                            }
                            if (row + 1 < nr && grid[row + 1][col] == '1')
                            {
                                neighbors.AddLast((row + 1) * nc + col);
                                grid[row + 1][col] = '0';
                            }
                            if (col - 1 >= 0 && grid[row][col - 1] == '1')
                            {
                                neighbors.AddLast(row * nc + col - 1);
                                grid[row][col - 1] = '0';
                            }
                            if (col + 1 < nc && grid[row][col + 1] == '1')
                            {
                                neighbors.AddLast(row * nc + col + 1);
                                grid[row][col + 1] = '0';
                            }
                        }
                    }
                }
            }
            return num_islands;
        }
        #endregion
    }
}
