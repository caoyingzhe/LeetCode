using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpConsoleApp.Solutions
{
    class Solution54 : SolutionBase
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
            int[] checkresult;
            IList<int> result;

            matrix = new int[][]
            {
                new int[] { 1,2,3 },
                new int[] { 4,5,6 },
                new int[] { 7,8,9 }
            };
            checkresult = new int[] { 1, 2, 3, 6, 9, 8, 7, 4, 5 };
            result = SpiralOrder(matrix);
            isSuccess &= string.Join(",", checkresult) == string.Join(",", result.ToArray());
            Print("isSuccess = " + isSuccess + " | Anticipated = " + string.Join(",", checkresult) + " | Result = " + string.Join(",", result.ToArray()));

            matrix = new int[][]
            {
                new int[] { 1,2,3,4},
                new int[] { 5,6,7,8 },
                new int[] { 9, 10, 11, 12 },
                new int[] { 13, 14, 15, 16 }
            };
            checkresult = new int[] { 1, 2, 3, 4, 8, 12, 16, 15, 14, 13, 9, 5, 6, 7, 11, 10 };
            result = SpiralOrder(matrix);
            isSuccess &= string.Join(",", checkresult) == string.Join(",", result.ToArray());
            Print("isSuccess = " + isSuccess + " | Anticipated = " + string.Join(",", checkresult) + " | Result = " + string.Join(",", result.ToArray()));

            //[[1,2,3,4],[5,6,7,8],[9,10,11,12],[13,14,15,16]]
            return isSuccess;
        }
        public IList<int> SpiralOrder(int[][] matrix)
        {
            int row = 0, col = 0;
            int m = matrix.Length;
            int n = matrix[0].Length;

            //移动方向常量（横向向右，纵向向下，横向向左，纵向向上）
            int[] directions = { 1, 1, -1, -1 };
            //当前移动方向
            int directionIndex = 0;

            int[] copy = new int[m * n];
            int[] result = new int[m * n];
            for (int i=0; i< result.Length; i++)
            {
                copy[row*n + col] = matrix[row][col];
                result[i] = matrix[row][col];
                if (directionIndex%2 == 0)  //行操作
                {
                    int nextCol = col + directions[directionIndex % 4];
                    if (nextCol == n || nextCol < 0 || copy[row * n + nextCol] != 0)
                    {
                        directionIndex++;
                        row += directions[directionIndex % 4];
                    }
                    else
                    {
                        col = nextCol;
                    }
                }
                else// 列操作
                {
                    int nextRow = row + directions[directionIndex % 4];
                    if (nextRow == m || nextRow < 0 || copy[nextRow * n + col] != 0)
                    {
                        directionIndex++;
                        col += directions[directionIndex % 4];
                    }
                    else
                    {
                        row = nextRow;
                    }
                }
            }
            return result;
        }
    }
}
