using System;
using System.Collections.Generic;
namespace CSharpConsoleApp.Solutions
{
    /*
     * @lc app=leetcode.cn id=84 lang=csharp
     *
     * [84] 柱状图中最大的矩形
     *
     * https://leetcode-cn.com/problems/largest-rectangle-in-histogram/description/
     *
     * Category	Difficulty	Likes	Dislikes
     * algorithms	Hard (42.93%)	1362	-
     * Tags
     * array | stack
     * 
     * Companies
     * Unknown
     * 
     * Total Accepted:    148.9K
     * Total Submissions: 346.9K
     * Testcase Example:  '[2,1,5,6,2,3]'
     *
     * 给定 n 个非负整数，用来表示柱状图中各个柱子的高度。每个柱子彼此相邻，且宽度为 1 。
     * 
     * 求在该柱状图中，能够勾勒出来的矩形的最大面积。
     * 
     * 以上是柱状图的示例，其中每个柱子的宽度为 1，给定的高度为 [2,1,5,6,2,3]。
     * 
     * 图中阴影部分为所能勾勒出的最大矩形面积，其面积为 10 个单位。
     * 
     * 示例:
     * 输入: [2,1,5,6,2,3]
     * 输出: 10
     * 
     */
    public class Solution84 : SolutionBase
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
        public override Tag[] GetTags() { return new Tag[] { Tag.Stack, Tag.Array, }; }
        public override bool Test(System.Diagnostics.Stopwatch sw)
        {
            bool isSuccess = true;
            return isSuccess;
        }

        /// <summary>
        /// 单调栈解法 (视频中的精简代码版本）
        /// 执行效率有点惨，为啥？？？
        /// 96/96 cases passed (308 ms)
        /// Your runtime beats 18.68 % of csharp submissions
        /// Your memory usage beats 5.49 % of csharp submissions(44 MB)
        /// </summary>
        /// <param name="heights"></param>
        /// <returns></returns>
        public int LargestRectangleArea_InVideo(int[] heights)
        {
            int n = heights.Length;
            if (n == 0) return 0;
            if (n == 1) return heights[0];

            int area = 0;

            //添加左右高度为0的哨兵，方便循环；
            List<int> hList = new List<int>(heights);
            hList.Insert(0, 0);
            hList.Add(0);
            n += 2;

            //用栈保存重要的高度信息。
            Stack<int> stack = new Stack<int>();
            stack.Push(0);

            for (int i = 1; i < n; i++) //因为加入了哨兵，所以从1开始
            {
                while (hList[stack.Peek()] > hList[i]) //栈中的最后高度大于当前高度时，计算面积。并比较最大面积。
                {
                    int height = hList[stack.Pop()];  //计算面积时，高度= 栈顶元素对应高度
                    int width = i - stack.Peek() - 1; //计算面积时，宽度=（i - 栈顶元素对应索引）
                    area = Math.Max(area, height * width);
                }
                stack.Push(i);//押入当前元素索引入栈。
            }
            return area;
        }

        /// <summary>
        /// 单调栈解法 (原始代码版）
        /// 96/96 cases passed (292 ms)
        /// Your runtime beats 24.18 % of csharp submissions
        /// Your memory usage beats 16.48 % of csharp submissions(43.6 MB)
        /// 作者：LeetCode-Solution
        /// 链接：https://leetcode-cn.com/problems/largest-rectangle-in-histogram/solution/zhu-zhuang-tu-zhong-zui-da-de-ju-xing-by-leetcode-/
        /// </summary>
        /// <param name="heights"></param>
        /// <returns></returns>
        public int LargestRectangleArea(int[] heights)
        {
            int n = heights.Length;
            int[] left = new int[n];
            int[] right = new int[n];

            Stack<int> mono_stack = new Stack<int>();
            for (int i = 0; i < n; ++i)
            {
                while (mono_stack.Count != 0 && heights[mono_stack.Peek()] >= heights[i])
                {
                    mono_stack.Pop();
                }
                left[i] = (mono_stack.Count == 0 ? -1 : mono_stack.Peek());
                mono_stack.Push(i);
            }

            mono_stack.Clear();
            for (int i = n - 1; i >= 0; --i)
            {
                while (mono_stack.Count != 0 && heights[mono_stack.Peek()] >= heights[i])
                {
                    mono_stack.Pop();
                }
                right[i] = (mono_stack.Count == 0 ? n : mono_stack.Peek());
                mono_stack.Push(i);
            }

            int ans = 0;
            for (int i = 0; i < n; ++i)
            {
                ans = Math.Max(ans, (right[i] - left[i] - 1) * heights[i]);
            }
            return ans;
        }
    }
}
