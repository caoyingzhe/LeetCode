using System;
namespace CSharpConsoleApp.Solutions
{
    /*
     * @lc app=leetcode.cn id=73 lang=csharp
     *
     * [73] 矩阵置零
     *
     * https://leetcode-cn.com/problems/set-matrix-zeroes/description/
     *
     * Category	Difficulty	Likes	Dislikes
     * algorithms	Medium (59.35%)	495	-
     * Tags
     * array
     * 
     * Companies
     * amazon | microsoft
     * 
     * Total Accepted:    109.6K
     * Total Submissions: 184.7K
     * Testcase Example:  '[[1,1,1],[1,0,1],[1,1,1]]'
     *
     * 给定一个 m x n 的矩阵，如果一个元素为 0 ，则将其所在行和列的所有元素都设为 0 。请使用 原地 算法。
     * 
     * 进阶：
     * 一个直观的解决方案是使用  O(mn) 的额外空间，但这并不是一个好的解决方案。
     * 一个简单的改进方案是使用 O(m + n) 的额外空间，但这仍然不是最好的解决方案。
     * 你能想出一个仅使用常量空间的解决方案吗？
     * 
     * 示例 1：
     * 输入：matrix = [[1,1,1],[1,0,1],[1,1,1]]
     * 输出：[[1,0,1],[0,0,0],[1,0,1]]
     * 
     * 示例 2：
     * 输入：matrix = [[0,1,2,0],[3,4,5,2],[1,3,1,5]]
     * 输出：[[0,0,0,0],[0,4,5,0],[0,3,1,0]]
     * 
     * 提示：
     * m == matrix.length
     * n == matrix[0].length
     * 1 <= m, n <= 200
     * -2^31 <= matrix[i][j] <= 2^31 - 1
     */
    public class Solution73 : SolutionBase
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
            int[][] matrix;
            int[][] checkResult;

            //matrix = new int[][] {
            //    new int[] { 1,1,1},
            //    new int[] { 1,0,1},
            //    new int[] { 1,1,1}
            //};
            //checkResult = new int[][] {
            //    new int[] { 1,0,1},
            //    new int[] { 0,0,0},
            //    new int[] { 1,0,1}
            //};
            //SetZeroes(matrix);
            //isSuccess &= IsArray2DSame(checkResult, matrix);
            //Print("isSuccess = {0}  \nresult = \n{1} anticipated = \n{2}", isSuccess, GetArray2DStr(matrix), GetArray2DStr(checkResult));
            matrix = new int[][] {
                new int[] { 0, 1, 2, 0},
                new int[] { 3, 4, 5, 2},
                new int[] { 1, 3, 1, 5},
            };
            checkResult = new int[][] {
                new int[] { 0, 0, 0, 0 },
                new int[] { 0, 4, 5, 0 },
                new int[] { 0, 3, 1, 0 }
            };
            SetZeroes(matrix);
            isSuccess &= IsArray2DSame(checkResult, matrix);
            Print("isSuccess = {0}  \nresult = \n{1} anticipated = \n{2}", isSuccess, GetArray2DStr(matrix), GetArray2DStr(checkResult));

            matrix = new int[][] {
                new int[] { 0,1,0,1},
                new int[] { 1,0,1,1},
                new int[] { 0,1,1,1},
                new int[] { 0,1,1,1}
            };
            checkResult = new int[][] {
                new int[] { 0,0,0,0},
                new int[] { 0,0,0,0},
                new int[] { 0,0,0,0},
                new int[] { 0,0,0,0}
            };
            SetZeroes(matrix);
            isSuccess &= IsArray2DSame(checkResult, matrix);
            Print("isSuccess = {0}  \nresult = \n{1} anticipated = \n{2}", isSuccess, GetArray2DStr(matrix), GetArray2DStr(checkResult));


            return isSuccess;
        }

        /// <summary>
        /// 164/164 cases passed (316 ms)
        /// Your runtime beats 38.91 % of csharp submissions
        /// Your memory usage beats 20 % of csharp submissions(33.4 MB)
        /// </summary>
        /// <param name="matrix"></param>
        public void SetZeroes(int[][] matrix)
        {
            int m = matrix.Length;
            int n = matrix[0].Length;
            int[] row = new int[m]; int[] col = new int[n];
            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (matrix[i][j] == 0)
                    {
                        row[i] = col[j] = 1;
                    }
                }
            }
            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (row[i] != 0 || col[j] != 0)
                    {
                        matrix[i][j] = 0;
                    }
                }
            }
        }

        /// <summary>
        /// 164/164 cases passed (308 ms)
        /// Your runtime beats 62.18 % of csharp submissions
        /// Your memory usage beats 8.73 % of csharp submissions(33.5 MB)
        /// 作者：LeetCode-Solution
        /// 链接：https://leetcode-cn.com/problems/set-matrix-zeroes/solution/ju-zhen-zhi-ling-by-leetcode-solution-9ll7/
        /// </summary>
        /// <param name="matrix"></param>
        public void SetZeroes_Fast(int[][] matrix)
        {
            int m = matrix.Length;
            int n = matrix[0].Length;

            //他把记录第一列的第一个数是否为0的责任交给了 num[0][0]
            //所以遍历时要从第0行开始（要记录第一列第一个数嘛）

            //所以记录第一行的第一个数是否为0的责任交给了 flag
            //所以遍历时从第1列开始,因为他没有责任咯！
            bool flag = false;

            for (int i = 0; i < m; i++) //从0开始
            {
                if (matrix[i][0] == 0)
                {
                    flag = true;
                }
                for (int j = 1; j < n; j++) //从1开始（列更新）
                {
                    if (matrix[i][j] == 0)
                    {
                        matrix[i][0] = matrix[0][j] = 0;
                    }
                }
            }

            //Print("Step1 = \n" + GetArray2DStr(matrix));
            for (int i = m - 1; i >= 0; i--)
            {
                for (int j = 1; j < n; j++)
                {
                    if (matrix[i][0] == 0 || matrix[0][j] == 0)
                    {
                        matrix[i][j] = 0;
                    }
                }
                //Print("Step2_{0} first= \n{1} ", i, GetArray2DStr(matrix));
                if (flag)
                {
                    matrix[i][0] = 0;
                }
                //Print("Step2_{0}  last= \n{1} ", i, GetArray2DStr(matrix));
            }
        }
    }
}
