using System;
namespace CSharpConsoleApp.Solutions
{
    /*
     * @lc app=leetcode.cn id=48 lang=csharp
     *
     * [48] 旋转图像
     *
     * https://leetcode-cn.com/problems/rotate-image/description/
     *
     * algorithms
     * Medium (72.80%)
     * Likes:    877
     * Dislikes: 0
     * Total Accepted:    171.9K
     * Total Submissions: 236.1K
     * Testcase Example:  '[[1,2,3],[4,5,6],[7,8,9]]'
     *
     * 给定一个 n × n 的二维矩阵 matrix 表示一个图像。请你将图像顺时针旋转 90 度。
     * 
     * 你必须在 原地 旋转图像，这意味着你需要直接修改输入的二维矩阵。请不要 使用另一个矩阵来旋转图像。
     * 
     * 
     * 示例 1：
     * 输入：matrix = [[1,2,3],[4,5,6],[7,8,9]]
     * 输出：[[7,4,1],[8,5,2],[9,6,3]]
     * 
     * 示例 2：
     * 输入：matrix = [[5,1,9,11],[2,4,8,10],[13,3,6,7],[15,14,12,16]]
     * 输出：[[15,13,2,5],[14,3,4,1],[12,6,8,9],[16,7,10,11]]
     * 
     * 示例 3：
     * 输入：matrix = [[1]]
     * 输出：[[1]]
     * 
     * 示例 4：
     * 输入：matrix = [[1,2],[3,4]]
     * 输出：[[3,1],[4,2]]
     * 
     * 提示：
     * matrix.length == n
     * matrix[i].length == n
     * 1 <= n <= 20
     * -1000 <= matrix[i][j] <= 1000
     */

    public class Solution48 : SolutionBase
    {
        public override bool Test(System.Diagnostics.Stopwatch sw)
        {
            int[][] matrix = new int[][] {
                 new int[] {11, 15, 10, 12},
                 new int[] {40, 22, 33, 16},
                 new int[] {18, 55, 44, 20},
                 new int[] {14, 30, 17, 13},
            };

            Print("before = \n{0}", GetArray2DStr(matrix));
            Rotate(matrix);
            Print("result = \n{0}", GetArray2DStr(matrix));

            matrix = new int[][] {
                 new int[] {11,12,13,14,15},
                 new int[] {16,17,18,19,20},
                 new int[] {21,22,23,24,25},
                 new int[] {26,27,28,29,30},
                 new int[] {31,32,33,34,35},
            };

            Print("before = \n{0}", GetArray2DStr(matrix));
            Rotate(matrix);
            Print("result = \n{0}", GetArray2DStr(matrix));
            return true;
        }

        /// <summary>
        /// 21/21 cases passed (284 ms)
        /// Your runtime beats 67.05 % of csharp submissions
        /// Your memory usage beats 18.01 % of csharp submissions(30.4 MB)
        /// </summary>
        /// <param name="matrix"></param>
        public void Rotate(int[][] matrix)
        {
            int n = matrix.Length;
            int L = 0;
            int R = n - 1;
            int ni = n - 1;
            int row = 0;
            while(L<R)
            {
                //Print("L={0} R={1} | ni={2} | row={3}",L,R,ni,row);
                for(int i=L; i<R;i++)
                {
                    bool isClockOrder = true;

                    if (row == 1)
                        row = 1;
                    int LU = matrix[row][i];
                    int RU = matrix[i][ni - row];
                    int RD = matrix[ni - row][ni - i];
                    int LD = matrix[ni - i][row];

                    //Print("Before LU={0} | RU={1} | RD={2} | LD={3}", LU, RU, RD, LD);

                    if (isClockOrder)
                    {
                        //顺时针 LU => LD, RU => LU; RD => RU; LD=>RD;
                        matrix[row][i]           = LD;
                        matrix[i][ni-row]        = LU;
                        matrix[ni - row][ni - i] = RU;
                        matrix[ni - i][row]      = RD;
                    }
                    else
                    {
                        //逆时针 LU => RU, RU => RD; RD => LD; LD=>LU;
                        matrix[row][i] = RU;
                        matrix[i][ni - row] = RD;
                        matrix[ni - row][ni - i] = LD;
                        matrix[ni - i][row] = LU;
                    }
                    //Print("After {0}\n", GetArray2DStr(matrix));
                }
                L++;
                R--;
                row++;
            }
        }
    }
}
