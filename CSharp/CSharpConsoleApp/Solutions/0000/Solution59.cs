using System;
using System.Collections.Generic;
namespace CSharpConsoleApp.Solutions
{
    /*
     * @lc app=leetcode.cn id=59 lang=csharp
     *
     * [59] 螺旋矩阵 II
     *
     * https://leetcode-cn.com/problems/spiral-matrix-ii/description/
     *
     * Category	Difficulty	Likes	Dislikes
     * algorithms	Medium (79.83%)	421	-
     * Tags
     * array
     * 
     * Companies
     * Unknown
     * 
     * Total Accepted:    102.5K
     * Total Submissions: 128.4K
     * Testcase Example:  '3'
     *
     * 给你一个正整数 n ，生成一个包含 1 到 n^2 所有元素，且元素按顺时针顺序螺旋排列的 n x n 正方形矩阵 matrix 。
     * 
     * 
     * 示例 1：
     * 输入：n = 3
     * 输出：[[1,2,3],[8,9,4],[7,6,5]]
     * 
     * 
     * 示例 2：
     * 输入：n = 1
     * 输出：[[1]]
     * 
     * 
     * 提示：
     * 1 <= n <= 20
     */
    public class Solution59 : SolutionBase
    {
        /// <summary>
        /// 难度
        /// </summary>
        public override Difficulity GetDifficulity() { return Difficulity.Medium; }
        /// <summary>
        /// 关键字:
        /// </summary>
        public override string[] GetKeyWords() { return new string[] { }; }
        /// <summary>
        /// 标签：
        /// </summary>
        public override Tag[] GetTags() { return new Tag[] { Tag.Array }; }

        public override bool Test(System.Diagnostics.Stopwatch sw)
        {
            bool isSuccess = true;

            int n; int[][] result;
            //n = 2;
            //result = GenerateMatrix(n);
            //Print(GetArray2DStr(result));

            n = 3;
            result = GenerateMatrix(n);
            Print(GetArray2DStr(result));

            n = 4;
            result = GenerateMatrix(n);
            Print(GetArray2DStr(result));

            return isSuccess;
        }
        const int right = 0;
        const int down = 1;
        const int left = 2;
        const int up = 3;

        /// <summary>
        /// 20/20 cases passed (232 ms)
        /// Your runtime beats 96.88 % of csharp submissions
        /// Your memory usage beats 68.75 % of csharp submissions(25.9 MB)
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public int[][] GenerateMatrix(int n)
        {
            List<int[]> list = new List<int[]>();
            for(int i=0; i<n; i++)
            {
                list.Add(new int[n]);
            }

            int row = 0, col = 0;

            int val = 1;
            int nPower = n * n;
            int dir = right;
            while(val <= nPower)
            {
                list[row][col] = val;
                val++;

                switch(dir)
                {
                    case right:
                        if (col + 1 < n && list[row][col + 1] == 0)
                            col++;
                        else
                        { 
                            dir = down;
                            row++;
                        }
                        break;
                    case down:
                        if (row + 1 < n && list[row+1][col] == 0)
                            row++;
                        else
                        {
                            dir = left;
                            col--;
                        }
                        break;
                    case left:
                        if (col - 1 >= 0 && list[row][col - 1] == 0)
                            col--;
                        else
                        {
                            dir = up;
                            row--;
                        }
                        break;
                    case up:
                        if (row - 1 >= 0 && list[row - 1][col] == 0)
                            row--;
                        else
                        {
                            dir = right;
                            col++;
                        }
                        break;
                }
            }

            return list.ToArray();
        }
    }
}
