using System;
using System.Collections.Generic;

namespace CSharpConsoleApp.Solutions
{
    /*
     * @lc app=leetcode.cn id=85 lang=csharp
     *
     * [85] 最大矩形
     *
     * https://leetcode-cn.com/problems/maximal-rectangle/description/
     *
     * Category	Difficulty	Likes	Dislikes
     * algorithms	Hard (51.68%)	921	-
     * Tags
     * array | hash-table | dynamic-programming | stack
     * 
     * Companies
     * facebook
     * 
     * Total Accepted:    79.7K
     * Total Submissions: 154.2K
     * Testcase Example:  '[["1","0","1","0","0"],["1","0","1","1","1"],["1","1","1","1","1"],["1","0","0","1","0"]]'
     *
     * 给定一个仅包含 0 和 1 、大小为 rows x cols 的二维二进制矩阵，找出只包含 1 的最大矩形，并返回其面积。
     * ---------------------------
     * 示例 1：
     * 输入：matrix =
     * [["1","0","1","0","0"],["1","0","1","1","1"],["1","1","1","1","1"],["1","0","0","1","0"]]
     * 输出：6
     * 解释：最大矩形如上图所示。
     * ---------------------------
     * 示例 2：
     * 输入：matrix = []
     * 输出：0
     * ---------------------------
     * 示例 3：
     * 输入：matrix = [["0"]]
     * 输出：0
     * ---------------------------
     * 示例 4：
     * 输入：matrix = [["1"]]
     * 输出：1
     * ---------------------------
     * 示例 5：
     * 输入：matrix = [["0","0"]]
     * 输出：0
     * ---------------------------
     * 提示：
     * rows == matrix.length
     * cols == matrix[0].length
     * 0 
     * matrix[i][j] 为 '0' 或 '1'
     * 
     */
    public class Solution85 : SolutionBase
    {
        /// <summary>
        /// 难易度:
        /// </summary>
        public override Difficulity GetDifficulity() { return Difficulity.Hard; }
        /// <summary>
        /// 关键字:
        /// </summary>
        public override string[] GetKeyWords() { return new string[] { "单调栈", "Monotone stack", "哨兵" }; }
        /// <summary>
        /// 标签： 图
        /// </summary>
        public override Tag[] GetTags() { return new Tag[] { Tag.Array, Tag.DynamicProgramming, Tag.HashTable, Tag.Stack, }; }
        public override bool Test(System.Diagnostics.Stopwatch sw)
        {
            bool isSuccess = true;
            return isSuccess;
        }

        // Solution84
        public int LargestRectangleArea(int[] heights)
        {
            int m = heights.Length;
            int[] left = new int[m];
            int[] right = new int[m];

            Stack<int> mono_stack = new Stack<int>();
            for (int i = 0; i < m; ++i)
            {
                while (mono_stack.Count != 0 && heights[mono_stack.Peek()] >= heights[i])
                {
                    mono_stack.Pop();
                }
                left[i] = (mono_stack.Count == 0 ? -1 : mono_stack.Peek());
                mono_stack.Push(i);
            }

            mono_stack.Clear();
            for (int i = m - 1; i >= 0; --i)
            {
                while (mono_stack.Count != 0 && heights[mono_stack.Peek()] >= heights[i])
                {
                    mono_stack.Pop();
                }
                right[i] = (mono_stack.Count == 0 ? m : mono_stack.Peek());
                mono_stack.Push(i);
            }

            int ret = 0;
            for (int i = 0; i < m; ++i)
            {
                ret = Math.Max(ret, (right[i] - left[i] - 1) * heights[i]);
            }
            return ret;
        }

        /// <summary>
        /// 下面的代码与此前第 84 题的代码的相似之处
        /// 
        /// 时间复杂度：O(mn)O(mn)，其中 mm 和 nn 分别是矩阵的行数和列数。
        /// 空间复杂度：O(mn)O(mn)
        ///
        /// 71/71 cases passed (184 ms)
        /// Your runtime beats 9.09 % of csharp submissions
        /// Your memory usage beats 90.91 % of csharp submissions(28.6 MB)
        ///
        /// 执行效率好惨，c#的 Stack类的效率问题么 ？？？
        /// </summary>
        /// <param name="matrix"></param>
        /// <returns></returns>
        public int MaximalRectangle(char[][] matrix)
        {
            int m = matrix.Length;
            if (m == 0)
            {
                return 0;
            }
            int n = matrix[0].Length;
            int[][] left = new int[m][];
            for (int mi = 0; mi < m; mi++) left[mi] = new int[n];

            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (matrix[i][j] == '1')
                    {
                        left[i][j] = (j == 0 ? 0 : left[i][j - 1]) + 1;
                    }
                }
            }

            int ret = 0;
            for (int j = 0; j < n; j++)
            {
                // 对于每一列，使用基于柱状图的方法
                int[] up = new int[m];
                int[] down = new int[m];

                Stack<int> stack = new Stack<int>();  //Deque<Integer> stack = new LinkedList<Integer>();
                for (int i = 0; i < m; i++)
                {
                    while (stack.Count != 0 && left[stack.Peek()][j] >= left[i][j])
                    {
                        stack.Pop();
                    }
                    up[i] = stack.Count == 0 ? -1 : stack.Peek();
                    stack.Push(i);
                }
                stack.Clear();
                for (int i = m - 1; i >= 0; i--)
                {
                    while (stack.Count != 0 && left[stack.Peek()][j] >= left[i][j])
                    {
                        stack.Pop();
                    }
                    down[i] = stack.Count == 0 ? m : stack.Peek();
                    stack.Push(i);
                }

                for (int i = 0; i < m; i++)
                {
                    //ret = Math.Max(ret, (right[i] - left[i] - 1) * heights[i]); //Solution84
                    ret = Math.Max(ret,  (down[i] - up[i] - 1) * left[i][j]);  //height = down[i] - up[i] - 1; width = left[i][j];

                }
            }
            return ret;
        }

        //作者：LeetCode-Solution
        //链接：https://leetcode-cn.com/problems/maximal-rectangle/solution/zui-da-ju-xing-by-leetcode-solution-bjlu/
    }
}
