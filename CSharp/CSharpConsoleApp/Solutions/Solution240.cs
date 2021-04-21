using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace CSharpConsoleApp.Solutions
{
    class Solution240 : SolutionBase
    {
        /// <summary>
        /// 难度
        /// </summary>
        public override Difficulity GetDifficulity() { return Difficulity.Hard; }
        /// <summary>
        /// 关键字:
        ///     DFS => 广度优先搜索（算法导论 第六部分 图算法 22.1章节）
        ///     五大常用算法之四：回溯法（试错思想法）
        /// </summary>
        public override string[] GetKeyWords() { return new string[] { "DFS", "Back_Tracing" }; }
        /// <summary>
        /// 标签： 
        /// </summary>
        public override Tag[] GetTags() { return new Tag[] { Tag.DivideAndConquer, Tag.Heap, Tag.BinaryIndexedTree, Tag.SegmentTree, Tag.LineSweep }; }
        public override bool Test(Stopwatch sw)
        {
            int target = 12;
            int[][] matrix = new int[][] {
                new int[] {1, 4, 7, 11, 15},
                new int[] {2, 5, 8, 12, 19},
                new int[] {3, 6, 9, 16, 22},
                new int[] {10,13,14,17,24},
                new int[] {18,21,23,26,30 }
            };
            bool isSuccess = SearchMatrix(matrix, target);
            return isSuccess;
        }

        public bool SearchMatrix(int[][] matrix, int target)
        {
            int row = matrix.Length - 1;
            int col = 0;
            while (row >= 0 && col < matrix[0].Length)
            {
                int value = matrix[row][col];
                if(value > target)
                {
                    row--;
                }
                else if (value < target)
                {
                    col++;
                }
                else
                {
                    //Print("{0} is at [{1}][{2}]", target, row, col);
                    return true;
                }
            }

            return false;
        }
    }
}
