using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpConsoleApp.Solutions._0500
{
    /*
     * @lc app=leetcode.cn id=566 lang=csharp
     *
     * [566] 重塑矩阵
     *
     * https://leetcode-cn.com/problems/reshape-the-matrix/description/
     *
     * Category	Difficulty	Likes	Dislikes
     * algorithms	Easy (70.61%)	202	-
     * Tags
     * array
     * 
     * Companies
     * mathworks
     * 
     * Total Accepted:    51.5K
     * Total Submissions: 73K
     * Testcase Example:  '[[1,2],[3,4]]\n1\n4'
     *
     * 在MATLAB中，有一个非常有用的函数 reshape，它可以将一个矩阵重塑为另一个大小不同的新矩阵，但保留其原始数据。
     * 
     * 给出一个由二维数组表示的矩阵，以及两个正整数r和c，分别表示想要的重构的矩阵的行数和列数。
     * 
     * 重构后的矩阵需要将原始矩阵的所有元素以相同的行遍历顺序填充。
     * 
     * 如果具有给定参数的reshape操作是可行且合理的，则输出新的重塑矩阵；否则，输出原始矩阵。
     * 
     * 示例 1:
     * 输入:  nums = [[1,2], ⁠[3,4]]  r = 1, c = 4
     * 输出:  [[1,2,3,4]]
     * 解释:
     * 行遍历nums的结果是 [1,2,3,4]。新的矩阵是 1 * 4 矩阵, 用之前的元素值一行一行填充新矩阵。
     * 
     * 
     * 示例 2:
     * 输入:  nums =  [[1,2],⁠[3,4]]  r = 2, c = 4
     * 输出:  [[1,2], [3,4]]
     * 解释:
     * 没有办法将 2 * 2 矩阵转化为 2 * 4 矩阵。 所以输出原矩阵。
     * 
     * 注意：
     * 给定矩阵的宽和高范围在 [1, 100]。
     * 给定的 r 和 c 都是正数。
     * 
     */

    class Solution566 : SolutionBase
    {
        public override Difficulity GetDifficulity() { return Difficulity.Easy; }
        /// <summary>
        /// 关键字:
        /// </summary>
        public override string[] GetKeyWords() { return new string[] { "不用看第二次" }; }
        /// <summary>
        /// 标签：
        /// </summary>
        public override Tag[] GetTags() { return new Tag[] { Tag.Array, }; }
        public override bool Test(System.Diagnostics.Stopwatch sw)
        {
            bool isSuccess = true;
            int[][] nums;
            int r, c;
            int[][] result;
            int[][] checkResult;

            r = 1; c = 4;
            nums = new int[][] {
                new int[] { 1,2 },
                new int[] { 3,4 }
            };
            checkResult = new int[][] {
                new int[] { 1,2,3,4 }
            };
            result = MatrixReshape(nums,r ,c);
            isSuccess &= IsArraySame(result, checkResult);

            return isSuccess;
        }


        public int[][] MatrixReshape(int[][] nums, int r, int c)
        {
            if (nums == null)
                return nums;

            int m = nums.Length;
            int n = nums[0].Length;
            if (m * n != r * c)
                return nums;

            int[][] result = new int[r][];
            for(int i=0; i<r;i++)
            {
                int[] rowData = new int[c];

                for(int j=0; j<c; j++)
                {
                    int index = i * c + j;
                    int row = index / n;
                    int col = index % n;

                    rowData[j] = nums[row][col];

                }
                result[i] = rowData;
            }
            return result;
        }
    }
}
