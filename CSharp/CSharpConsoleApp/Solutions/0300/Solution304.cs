using System;
namespace CSharpConsoleApp.Solutions
{
    public class Solution304 : SolutionBase
    {
        /// <summary>
        /// 难度
        /// </summary>
        public override Difficulity GetDifficulity() { return Difficulity.Medium; }
        /// <summary>
        /// 关键字:
        /// </summary>
        public override string[] GetKeyWords() { return new string[] { "前缀和", }; }
        /// <summary>
        /// 标签：
        /// </summary>
        public override Tag[] GetTags() { return new Tag[] { Tag.DynamicProgramming }; }


        public override bool Test(System.Diagnostics.Stopwatch sw)
        {
            bool isSuccess = true;
            NumMatrix matrix;
            int row1, col1, row2, col4;
            int[][] maxtrixArray2D;
            int result, checkResult;

            maxtrixArray2D = new int[][] { };
            checkResult = 1000;
            row1 = 1; row2 = 2; col1 = 3; col4 = 4;
            matrix = new NumMatrix(maxtrixArray2D);
            result = matrix.SumRegion(row1, col1, row2, col1);

            isSuccess &= IsSame(result, checkResult);
            PrintResult(isSuccess, (result).ToString(), (checkResult).ToString());

            return isSuccess;
        }


        /*
         * @lc app=leetcode.cn id=304 lang=csharp
         *
         * [304] 二维区域和检索 - 矩阵不可变
         *
         * https://leetcode-cn.com/problems/range-sum-query-2d-immutable/description/
         *
         * Category	Difficulty	Likes	Dislikes
         * algorithms	Medium (53.45%)	280	-
         * Tags
         * dynamic-programming
         * 
         * Companies
         * Unknown
         * 
         * Total Accepted:    56.7K
         * Total Submissions: 106.1K
         * Testcase Example:  '["NumMatrix","sumRegion","sumRegion","sumRegion"]\n' +
          '[[[[3,0,1,4,2],[5,6,3,2,1],[1,2,0,1,5],[4,1,0,1,7],[1,0,3,0,5]]],[2,1,4,3],[1,1,2,2],[1,2,2,4]]'
         *
         * 给定一个二维矩阵 matrix，以下类型的多个请求：
         * 计算其子矩形范围内元素的总和，该子矩阵的左上角为 (row1, col1) ，右下角为 (row2, col2) 。
         * 
         * 实现 NumMatrix 类：
         * NumMatrix(int[][] matrix) 给定整数矩阵 matrix 进行初始化
         * int sumRegion(int row1, int col1, int row2, int col2) 返回左上角 (row1, col1)
         * 、右下角 (row2, col2) 的子矩阵的元素总和。
         * 
         * 
         * 示例 1：
         * 输入: 
         * ["NumMatrix","sumRegion","sumRegion","sumRegion"]
         * 
         * [[[[3,0,1,4,2],[5,6,3,2,1],[1,2,0,1,5],[4,1,0,1,7],[1,0,3,0,5]]],[2,1,4,3],[1,1,2,2],[1,2,2,4]]
         * 输出: 
         * [null, 8, 11, 12]
         * 
         * 解释:
         * NumMatrix numMatrix = new
         * NumMatrix([[3,0,1,4,2],[5,6,3,2,1],[1,2,0,1,5],[4,1,0,1,7],[1,0,3,0,5]]]);
         * numMatrix.sumRegion(2, 1, 4, 3); // return 8 (红色矩形框的元素总和)
         * numMatrix.sumRegion(1, 1, 2, 2); // return 11 (绿色矩形框的元素总和)
         * numMatrix.sumRegion(1, 2, 2, 4); // return 12 (蓝色矩形框的元素总和)
         * 
         * 
         * 提示：
         * m == matrix.length
         * n == matrix[i].length
         * 1 <= m, n <= 200
         * -10^5   <= matrix[i][j] <= 10^5 
         * 0 <= row1 <= row2 < m
         * 0 <= col1 <= col2 < n
         * 最多调用 10^4 次 sumRegion 方法
         */

        /// <summary>
        /// //作者：LeetCode - Solution
        /// //链接：https://leetcode-cn.com/problems/range-sum-query-2d-immutable/solution/er-wei-qu-yu-he-jian-suo-ju-zhen-bu-ke-b-2z5n/
        /// 16/16 cases passed (456 ms)
        /// Your runtime beats 30 % of csharp submissions
        /// Your memory usage beats 60 % of csharp submissions(55.5 MB)
        /// </summary>
        // @lc code=start
        public class NumMatrix
        {

            int[][] sums;

            public NumMatrix(int[][] matrix)
            {
                int m = matrix.Length;
                if (m > 0)
                {
                    int n = matrix[0].Length;
                    sums = new int[m + 1][];
                    for (int i = 0; i <= m; i++) sums[i] = new int[n + 1];

                    for (int i = 0; i < m; i++)
                    {
                        for (int j = 0; j < n; j++)
                        {
                            sums[i + 1][j + 1] = sums[i][j + 1] + sums[i + 1][j] - sums[i][j] + matrix[i][j];
                        }
                    }
                }
            }

            public int SumRegion(int R1, int C1, int R2, int C2)
            {
                return sums[R2 + 1][C2 + 1] - sums[R1][C2 + 1] - sums[R2 + 1][C1] + sums[R1][C1];
            }
        }

        /**
         * Your NumMatrix object will be instantiated and called as such:
         * NumMatrix obj = new NumMatrix(matrix);
         * int param_1 = obj.SumRegion(row1,col1,row2,col2);
         */
        // @lc code=end


    }
}
