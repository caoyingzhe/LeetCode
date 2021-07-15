using System;
namespace CSharpConsoleApp.Solutions
{
    /*
     * @lc app=leetcode.cn id=661 lang=csharp
     *
     * [661] 图片平滑器
     *
     * https://leetcode-cn.com/problems/image-smoother/description/
     *
     * algorithms
     * Easy (55.86%)
     * Likes:    79
     * Dislikes: 0
     * Total Accepted:    15.1K
     * Total Submissions: 27K
     * Testcase Example:  '[[1,1,1],[1,0,1],[1,1,1]]'
     *
     * 包含整数的二维矩阵 M 表示一个图片的灰度。你需要设计一个平滑器来让每一个单元的灰度成为平均灰度 (向下舍入)
     * ，平均灰度的计算是周围的8个单元和它本身的值求平均，如果周围的单元格不足八个，则尽可能多的利用它们。
     * 
     * 示例 1:
     * 输入:
     * [[1,1,1],
     * ⁠[1,0,1],
     * ⁠[1,1,1]]
     * 输出:
     * [[0, 0, 0],
     * ⁠[0, 0, 0],
     * ⁠[0, 0, 0]]
     * 解释:
     * 对于点 (0,0), (0,2), (2,0), (2,2): 平均(3/4) = 平均(0.75) = 0
     * 对于点 (0,1), (1,0), (1,2), (2,1): 平均(5/6) = 平均(0.83333333) = 0
     * 对于点 (1,1): 平均(8/9) = 平均(0.88888889) = 0
     * 
     * 
     * 注意:
     * 给定矩阵中的整数范围为 [0, 255]。
     * 矩阵的长和宽的范围均为 [1, 150]。Length
     */
    public class Solution661
    {
        /// <summary>
        /// 203/203 cases passed (368 ms)
        /// Your runtime beats 65 % of csharp submissions
        /// Your memory usage beats 95 % of csharp submissions(34.3 MB)
        /// </summary>
        /// <param name="M"></param>
        /// <returns></returns>
        public int[][] ImageSmoother(int[][] M)
        {
            int R = M.Length, C = M[0].Length;
            int[][] ans = new int[R][];
            for (int m = 0; m < R; ++m) ans[m] = new int[C];

            for (int r = 0; r < R; ++r)
                for (int c = 0; c < C; ++c)
                {
                    int count = 0;
                    for (int nr = r - 1; nr <= r + 1; ++nr)
                        for (int nc = c - 1; nc <= c + 1; ++nc)
                        {
                            if (0 <= nr && nr < R && 0 <= nc && nc < C)
                            {
                                ans[r][c] += M[nr][nc];
                                count++;
                            }
                        }
                    ans[r][c] /= count;
                }
            return ans;
        }
    }
}
