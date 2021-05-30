using System;
namespace CSharpConsoleApp.Solutions
{
    public class Solution892
    {
        /// <summary>
        /// 90/90 cases passed (148 ms)
        /// Your runtime beats 16.67 % of csharp submissions
        /// Your memory usage beats 66.67 % of csharp submissions(25.6 MB)
        /// </summary>
        /// <param name="grid"></param>
        /// <returns></returns>
        public int SurfaceArea(int[][] grid)
        {
            //分别对应位置为         U, R, D, L
            int[] dr = new int[] { 0, 1, 0, -1 }; //行偏移
            int[] dc = new int[] { 1, 0, -1, 0 }; //列偏移

            int N = grid.Length;
            int ans = 0;

            for (int r = 0; r < N; ++r)
            {
                for (int c = 0; c < N; ++c)
                {
                    if (grid[r][c] > 0) //必须大于0才有贡献顶面和底面
                    {
                        ans += 2; //顶面和底面面积=2
                        for (int k = 0; k < 4; ++k)
                        {
                            int nr = r + dr[k]; //行偏移
                            int nc = c + dc[k]; //列偏移
                            int nv = 0; //默认周围高度为0（处于边缘）
                            //求出nv，不在边缘情况的高度。
                            if (0 <= nr && nr < N && 0 <= nc && nc < N)
                            {
                                nv = grid[nr][nc];
                            }
                            //计算侧面值
                            ans += Math.Max(grid[r][c] - nv, 0);
                        }
                    }
                }
            }
            return ans;
        }
    }
}
