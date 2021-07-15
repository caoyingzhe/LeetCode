using System;
using System.Collections.Generic;
namespace CSharpConsoleApp.Solutions
{
    /*
     * @lc app=leetcode.cn id=498 lang=csharp
     *
     * [498] 对角线遍历
     *
     * https://leetcode-cn.com/problems/diagonal-traverse/description/
     *
     * algorithms
     * Medium (44.55%)
     * Likes:    206
     * Dislikes: 0
     * Total Accepted:    36.3K
     * Total Submissions: 81.5K
     * Testcase Example:  '[[1,2,3],[4,5,6],[7,8,9]]'
     *
     * 给定一个含有 M x N 个元素的矩阵（M 行，N 列），请以对角线遍历的顺序返回这个矩阵中的所有元素，对角线遍历如下图所示。
     * 
     * 示例:
     * 输入:
     * [
     * ⁠[ 1, 2, 3 ],
     * ⁠[ 4, 5, 6 ],
     * ⁠[ 7, 8, 9 ]
     * ]
     * 
     * 输出:  [1,2,4,7,5,3,6,8,9]
     * 
     * 解释:
     * 说明:
     * 给定矩阵中的元素总数不会超过 100000 。
     */

    public class Solution498 : SolutionBase
    {
        /// <summary>
        /// 难度
        /// </summary>
        public override Difficulity GetDifficulity() { return Difficulity.Medium; }
        /// <summary>
        /// 关键字:
        /// </summary>
        public override string[] GetKeyWords() { return new string[] { "" }; }
        /// <summary>
        /// 标签：
        /// </summary>
        public override Tag[] GetTags() { return new Tag[] { Tag.Unknown, }; }

        public override bool Test(System.Diagnostics.Stopwatch sw)
        {
            bool isSuccess = true;
            int[][] nums;
            int[] result, checkResult;

            nums = new int[][]{
                new int[] { 1, 2, 3 },
                new int[] { 4, 5, 6 },
                new int[] { 7, 8, 9 },
            };
            checkResult = new int[] { 1, 2, 4, 7, 5, 3, 6, 8, 9 };
            result = FindDiagonalOrder(nums);

            isSuccess &= IsSame(result, checkResult);
            PrintResult(isSuccess, (result), (checkResult));
            return isSuccess;
        }

        //作者：muzhiyuan
        //    链接：https://leetcode-cn.com/problems/diagonal-traverse/solution/chun-mo-ni-dai-ma-du-lan-de-you-hua-liao-qyin/
        /// <summary>
        /// 32/32 cases passed (304 ms)
        /// Your runtime beats 96.15 % of csharp submissions
        /// Your memory usage beats 57.69 % of csharp submissions(36.9 MB)
        /// </summary>
        /// <param name="mat"></param>
        /// <returns></returns>
        public int[] FindDiagonalOrder(int[][] mat)
        {
            bool flag = true;  //向上
            int m = mat.Length;
            int n = mat[0].Length;
            int[] res = new int[m * n];
            int row = 0, col = 0;
            int index = 0;
            while (index != res.Length)
            {
                if (flag)
                {
                    res[index++] = mat[row][col];
                    row--;
                    col++;
                    if (row < 0 && col > n - 1)
                    {
                        row += 2;
                        col -= 1;
                        flag = false;
                    }
                    else if (col > n - 1)
                    {
                        row += 2;
                        col -= 1;
                        flag = false;
                    }
                    else if (row < 0)
                    {
                        row = 0;
                        flag = false;
                    }
                }
                else
                {
                    res[index++] = mat[row][col];
                    row++;
                    col--;
                    if (row > m - 1 && col < 0)
                    {
                        row -= 1;
                        col += 2;
                        flag = true;
                    }
                    else if (row > m - 1)
                    {
                        row -= 1;
                        col += 2;
                        flag = true;
                    }
                    else if (col < 0)
                    {
                        col = 0;
                        flag = true;
                    }
                }
            }
            return res;
        }
        public int[] FindDiagonalOrder_MY(int[][] mat)
        {
            int[][] dirDiffs = new int[4][] {
                new int[] { 0,1 },
                new int[] { 1,-1 },
                new int[] { 1,0 },
                new int[] { -1,1 }
            };
            int m = mat.Length;
            int n = mat[0].Length;

            if (m == 1)
                return mat[0];
            if (n == 1)
            {
                int[] rtn = new int[m];
                for (int idx = 0; idx < m; idx++)
                    rtn[idx] = mat[idx][0];
                return rtn;
            }

            int max = m * n;
            int count = 0;
            int dir = 0;
            int i = 0; int j = 0;
            List<int> list = new List<int>();
            while (count < max)
            {
                list.Add(mat[i][j]);
                count++;


                int nextDir = dir;
                if (i == 0 && dir == 0)
                {
                    nextDir = 1;
                }
                else if (i == 0 && dir == 1)
                {
                    if (j == 0)
                        nextDir = 2;
                    else if (i == n - 1)
                        nextDir = 0;
                }
                else if (j == 0 && dir == 2)
                {
                    nextDir = 3;
                }
                else if (j == 0 && dir == 3)
                {
                    if (i == 0)
                        nextDir = 0;
                    else if (j == n - 1)
                        nextDir = 2;
                }

                i += dirDiffs[dir][0];
                j += dirDiffs[dir][1];

                Print("i={0} | j={1} | dir={2} nextDir={3}", i, j, dir, nextDir);

                dir = nextDir;
            }
            return list.ToArray();
        }
    }
}
