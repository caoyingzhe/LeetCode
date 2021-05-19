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
        public override Tag[] GetTags() { return new Tag[] { Tag.BinarySearch, Tag.DynamicProgramming, Tag.Queue}; }

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

            int[] dp = new int[n+1];
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
        public int MaxSumSubmatrix(int[][] matrix, int k)
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
    }
}
