using System;
using System.Collections.Generic;
using System.Linq;

namespace CSharpConsoleApp.Solutions
{
    /*
     * @lc app=leetcode.cn id=363 lang=csharp
     *
     * [363] 矩形区域不超过 K 的最大数值和
     *
     * https://leetcode-cn.com/problems/max-sum-of-rectangle-no-larger-than-k/description/
     *
     * Category	Difficulty	Likes	Dislikes
     * algorithms	Hard (49.10%)	326	-
     * Tags
     * binary-search | dynamic-programming | queue
     * 
     * Companies
     * google
     * Total Accepted:    29.3K
     * Total Submissions: 59.7K
     * Testcase Example:  '[[1,0,1],[0,-2,3]]\n2'
     *
     * 给你一个 m x n 的矩阵 matrix 和一个整数 k ，找出并返回矩阵内部矩形区域的不超过 k 的最大数值和。
     * 
     * 题目数据保证总会存在一个数值和不超过 k 的矩形区域。
     * 
     * 示例 1：
     * 输入：matrix = [[1,0,1],[0,-2,3]], k = 2
     * 输出：2
     * 解释：蓝色边框圈出来的矩形区域 [[0, 1], [-2, 3]] 的数值和是 2，且 2 是不超过 k 的最大数字（k = 2）。
     * 
     * 示例 2：
     * 输入：matrix = [[2,2,-1]], k = 3
     * 输出：3
     * 
     * 提示：
     * m == matrix.length
     * n == matrix[i].length
     * 1 <= m, n <= 100
     * -100 <= matrix[i][j] <= 100
     * -105 <= k <= 105
     * 
     * 
     * 进阶：如果行数远大于列数，该如何设计解决方案？
     * 
     */
    public class Solution363 : SolutionBase
    {
        /// <summary>
        /// 难度
        /// </summary>
        public override Difficulity GetDifficulity() { return Difficulity.Hard; }
        /// <summary>
        /// 关键字:
        /// </summary>
        public override string[] GetKeyWords() { return new string[] { "SortHashMap" }; }
        /// <summary>
        /// 标签： 
        /// </summary>
        public override Tag[] GetTags() { return new Tag[] { Tag.BinarySearch, Tag.DynamicProgramming, Tag.Queue }; }

        public override bool Test(System.Diagnostics.Stopwatch sw)
        {
            bool isSuccess = true;

            int[][] matrix;
            int k, result, checkResult;

            //matrix = new int[][]{
            //    new int[] { 1,0,1 },
            //    new int[] { 0,-2,3 }
            //};
            //k = 2; checkResult = 2;
            //result = MaxSumSubmatrix(matrix, k);
            //isSuccess &= result == checkResult;
            //Print("isSuccess = {0} | result={1} | checkResult={2}", isSuccess, result, checkResult);
            //
            //k = 3; checkResult = 3;
            //result = MaxSumSubmatrix(matrix, k);
            //isSuccess &= result == checkResult;
            //Print("isSuccess = {0} | result={1} | checkResult={2}", isSuccess, result, checkResult);

            matrix = new int[][]{
                new int[] { 5,-4,-3,4 },
                new int[] { 3, -4, 4, 5 },
                new int[] { 5, 1, 5, -4 }
            };
            k = 10; checkResult = 10;
            result = MaxSumSubmatrix(matrix, k);
            isSuccess &= result == checkResult;
            Print("isSuccess = {0} | result={1} | checkResult={2}", isSuccess, result, checkResult);

            return isSuccess;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="matrix"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public int MaxSumSubmatrix_My(int[][] matrix, int k)
        {
            //DP(n) = DP(n-1)

            int n = matrix.Length;

            int[] dp = new int[n + 1];
            //动态方程

            return dp[n];
        }

        /// <summary>
        /// 方法一：有序集合
        /// 
        /// 作者：LeetCode-Solution
        /// 链接：https://leetcode-cn.com/problems/max-sum-of-rectangle-no-larger-than-k/solution/ju-xing-qu-yu-bu-chao-guo-k-de-zui-da-sh-70q2/
        /// 
        /// </summary>
        /// <param name="matrix"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public int MaxSumSubmatrix_Error(int[][] matrix, int k)
        {
            int ans = int.MinValue;
            int m = matrix.Length, n = matrix[0].Length;
            for (int i = 0; i < m; ++i)
            { // 枚举上边界
                int[] sum = new int[n];
                for (int j = i; j < m; ++j)
                { // 枚举下边界
                    for (int c = 0; c < n; ++c)
                    {
                        sum[c] += matrix[j][c]; // 更新每列的元素和

                        Print("sum[{0}] = {1}, matrix{2}][{0}] = {3}", c, sum[c], j, matrix[j][c]);
                    }

                    //SortedSet<int> sumSet = new SortedSet<int>();//TreeSet<int> sumSet = new TreeSet<int>();
                    List<int> sumSet = new List<int>();
                    sumSet.Add(0);//sumSet.Add(0);
                    int s = 0;
                    foreach (int v in sum)
                    {
                        s += v;
                        //int ceil = sumSet.ceiling(s - k); //Java TreeSet.ceiling 返回Set中大于/等于e的最小元素

                        int sk = s - k;
                        if (sk >= sumSet.Min() && sk <= sumSet.Max())
                        {
                            int ceil = sumSet.Where<int>(a => a >= (s - k)).First();
                            ans = Math.Max(ans, s - ceil);
                        }
                        sumSet.Add(s); //sumSet.Add(s);
                    }
                }
                Print("i={0} sum={1}", i, GetArrayStr(sum));
            }
            return ans;
        }

        //25/27 cases passed (N/A)
        public int MaxSumSubmatrix_TLE(int[][] matrix, int k)
        {
            int ans = int.MinValue;
            int m = matrix.Length, n = matrix[0].Length;
            for (int i = 0; i < m; ++i)
            { // 枚举上边界
                int[] sum = new int[n];
                for (int j = i; j < m; ++j)
                { // 枚举下边界
                    for (int c = 0; c < n; ++c)
                    {
                        sum[c] += matrix[j][c]; // 更新每列的元素和
                    }
                    SortedSet<int> sumSet = new SortedSet<int>(); //TreeSet<int> sumSet = new TreeSet<int>();
                    sumSet.Add(0);
                    int s = 0;
                    foreach (int v in sum)
                    {
                        s += v;

                        var list = sumSet.Where<int>(a => a >= (s - k));  //int ceil = sumSet.ceiling(s - k); //int ceil = sumSet.ceiling(s - k);
                        if (list != null && list.Count() != 0)
                        {
                            ans = Math.Max(ans, s - list.First());
                        }
                        sumSet.Add(s);
                    }
                }
            }
            return ans;
        }

        //作者：LeetCode-Solution
        //链接：https://leetcode-cn.com/problems/max-sum-of-rectangle-no-larger-than-k/solution/ju-xing-qu-yu-bu-chao-guo-k-de-zui-da-sh-70q2/

        #region

        #region ------------ 思路 Step1 ： 暴力法 四重循环 ----------------
        /// <summary>
        /// 暴力法 四重循环
        /// 
        /// 时间复杂度 O(m^2n^2))，
        /// 空间复杂度 O(m^2n^2)
        ///
        /// 状态方程：     ：  dp(i1,j1,i2,j2)   = dp(i1,j1,i2 - 1,j2)   + dp(i1,j1,i2,j2 - 1) - dp(i1,j1,i2 - 1,j2 - 1) + matrix[i2 - 1][j2 - 1];
        /// 状态方程（白话）：  dp最大矩阵和(长，宽) = dp(同长-1，同宽) + dp(同长，同宽-1) -| dp(同长-1,同宽-1) | + 最右下角值 matrix[长-1，宽-1]
        ///                                                                        | 该dp代笔重复区域   |
        /// </summary>
        /// <param name="matrix"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public int maxSumSubmatrix_Step1(int[][] matrix, int k)
        {
            int rows = matrix.Length, cols = matrix[0].Length, max = int.MinValue;
            int[,,,] dp = new int[rows + 1, cols + 1, rows + 1, cols + 1]; // from (i1,j1) to (i2,j2)

            for (int i1 = 1; i1 <= rows; i1++)
            {
                for (int j1 = 1; j1 <= cols; j1++)
                {
                    dp[i1, j1, i1, j1] = matrix[i1 - 1][j1 - 1];
                    for (int i2 = i1; i2 <= rows; i2++)
                    {
                        for (int j2 = j1; j2 <= cols; j2++)
                        {
                            dp[i1, j1, i2, j2] = dp[i1, j1, i2 - 1, j2] + dp[i1, j1, i2, j2 - 1] - dp[i1, j1, i2 - 1, j2 - 1] + matrix[i2 - 1][j2 - 1];
                            if (dp[i1, j1, i2, j2] <= k && dp[i1, j1, i2, j2] > max)
                                max = dp[i1, j1, i2, j2];
                        }
                    }
                }
            }
            return max;
        }
        #endregion

        #region ------------ 思路 Step2 ： 暴力 + 动态规划 + 状态压缩  四重循环 ----------------
        // <summary>
        /// 暴力 + 动态规划 + 状态压缩 四重循环
        /// 
        /// 时间复杂度 O(m^2n^2))，
        /// 空间复杂度 O(mn)
        ///
        /// 相比Step1，代码优化部分为： 四重dp 改为2重dp，dp写入了第二层循环中。
        /// 因为每次更换左上角 (i, j) 之后，之前记录的值都没用过了，
        /// 
        /// </summary>
        /// <param name="matrix"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public int maxSumSubmatrix_Step2(int[][] matrix, int k)
        {
            int rows = matrix.Length, cols = matrix[0].Length, max = int.MinValue;
            for (int i1 = 1; i1 <= rows; i1++)
            {
                for (int j1 = 1; j1 <= cols; j1++)
                {
                    int[,] dp = new int[rows + 1, cols + 1]; // renew  // from (i1,j1) to (i2,j2)
                    dp[i1, j1] = matrix[i1 - 1][j1 - 1];
                    for (int i2 = i1; i2 <= rows; i2++)
                    {
                        for (int j2 = j1; j2 <= cols; j2++)
                        {
                            dp[i2, j2] = dp[i2 - 1, j2] + dp[i2, j2 - 1] - dp[i2 - 1, j2 - 1] + matrix[i2 - 1][j2 - 1];
                            if (dp[i2, j2] <= k && dp[i2, j2] > max) max = dp[i2, j2];
                        }
                    }
                }
            }
            return max;
        }
        #endregion

        #region ------------ 思路 Step2 ： 数组滚动 （固定左右边界）----------------
        public int MaxSumSubmatrix_Step3(int[][] matrix, int k)
        {
            int rows = matrix.Length, cols = matrix[0].Length, max = int.MinValue;
            // O(cols ^ 2 * rows)
            //for (int i1 = 1; i1 <= rows; i1++) 减少了第一层循环。
            {
                for (int l = 0; l < cols; l++)
                { // 枚举左边界
                    int[] rowSum = new int[rows]; // 左边界改变才算区域的重新开始 rowSum代表最左边到左边界的和，这样就减少了第一层循环。
                    for (int r = l; r < cols; r++)
                    { // 枚举右边界
                        for (int i = 0; i < rows; i++)
                        { // 按每一行累计到 dp
                            rowSum[i] += matrix[i][r];
                        }

                        // 求 rowSum 连续子数组 的 和
                        // 和 尽量大，但不大于 k
                        max = Math.Max(max, Dpmax_ToDo(rowSum, k));
                    }
                }
            }
            return max;
        }

        // 在数组 arr 中，求不超过 k 的最大值
        private int Dpmax_ToDo(int[] arr, int k)
        {
            int max = int.MinValue;
            for (int l = 0; l < arr.Length; l++)
            {
                int sum = 0;
                for (int r = l; r < arr.Length; r++)
                {
                    sum += arr[r];
                    if (sum > max && sum <= k) max = sum;
                }
            }
            return max;
        }
        #endregion

        #region ------------ 思路 Step4：最终优化----------------
        /// <summary>
        /// 该算法不但没有超时，而且效率非常优秀
        /// 27/27 cases passed (188 ms)
        /// Your runtime beats 94.06 % of csharp submissions
        /// Your memory usage beats 32.67 % of csharp submissions(25.7 MB)
        /// 
        /// 作者：lzhlyle
        /// 链接：https://leetcode-cn.com/problems/max-sum-of-rectangle-no-larger-than-k/solution/javacong-bao-li-kai-shi-you-hua-pei-tu-pei-zhu-shi/
        /// </summary>
        /// <param name="matrix"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public int MaxSumSubmatrix(int[][] matrix, int k)
        {
            int rows = matrix.Length, cols = matrix[0].Length, max = int.MinValue;
            // O(cols ^ 2 * rows)
            for (int l = 0; l < cols; l++)
            { // 枚举左边界
                int[] rowSum = new int[rows]; // 左边界改变才算区域的重新开始
                for (int r = l; r < cols; r++)
                { // 枚举右边界
                    for (int i = 0; i < rows; i++)
                    { // 按每一行累计到 dp
                        rowSum[i] += matrix[i][r];
                    }
                    max = Math.Max(max, Dpmax(rowSum, k));
                    if (max == k) return k; // 尽量提前
                }
            }
            return max;
        }
        // 在数组 arr 中，求不超过 k 的最大值
        private int Dpmax(int[] arr, int k)
        {
            int rollSum = arr[0], rollMax = rollSum;
            // O(rows)
            for (int i = 1; i < arr.Length; i++)
            {
                if (rollSum > 0) rollSum += arr[i];
                else rollSum = arr[i];
                if (rollSum > rollMax) rollMax = rollSum;
            }
            if (rollMax <= k) return rollMax;
            // O(rows ^ 2)
            int max = int.MinValue;
            for (int l = 0; l < arr.Length; l++)
            {
                int sum = 0;
                for (int r = l; r < arr.Length; r++)
                {
                    sum += arr[r];
                    if (sum > max && sum <= k) max = sum;
                    if (max == k) return k; // 尽量提前
                }
            }
            return max;
        }
        #endregion
        #endregion
    }
}
