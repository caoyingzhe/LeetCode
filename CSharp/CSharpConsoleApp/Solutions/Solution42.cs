using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpConsoleApp.Solutions
{
    /// <summary>
    /// 接雨水
    /// 
    /// 给定 n 个非负整数表示每个宽度为 1 的柱子的高度图，计算按此排列的柱子，下雨之后能接多少雨水。
    /// 
    /// 输入：height = [0,1,0,2,1,0,1,3,2,1,2,1]
    /// 输出：6
    /// 解释：上面是由数组[0, 1, 0, 2, 1, 0, 1, 3, 2, 1, 2, 1] 表示的高度图，在这种情况下，可以接 6 个单位的雨水（蓝色部分表示雨水）。     
    /// 
    /// 输入：height = [4,2,0,3,2,5]
    /// 输出：9
    /// </summary>
    class Solution42 : SolutionBase
    {
        /// <summary>
        /// 难度 
        /// </summary>
        public override Difficulity GetDifficulity() { return Difficulity.Hard; }
        /// <summary>
        /// 关键字:
        /// </summary>
        public override string[] GetKeyWords() { return new string[] { "TwoPointers", "Stack" }; }
        /// <summary>
        /// 标签： 
        /// </summary>
        public override Tag[] GetTags() { return new Tag[] { Tag.Array, Tag.Stack, Tag.TwoPointers }; }
        public override bool Test(System.Diagnostics.Stopwatch sw)
        {
            bool isSuccess = true;
            int[] heights;
            int checkResult;
            int result;

            //heights = new int[] { 0, 1, 0, 2, 1, 0, 1, 3, 2, 1, 2, 1 };
            //Print("--- nums = " + string.Join(",", heights));
            //
            //checkResult = 6;
            //result = Trap(heights);
            //isSuccess &= result == checkResult;
            //Print(string.Format("isSuccss ={0}, result={1} checkResult={2}", isSuccess, result, checkResult));


            heights = new int[] { 4, 2, 0, 3, 2, 5 }; //-2,-2,3,-1,3  //-1,-3,3,-1,1 
            Print("--- heights = " + string.Join(",", heights));

            checkResult = 9;
            result = Trap(heights);
            isSuccess &= result == checkResult;
            Print(string.Format("isSuccss ={0}, result={1} checkResult={2}", isSuccess, result, checkResult));


            return isSuccess;
        }

        /// <summary>
        /// 动态编程法
        /// 
        /// 时间复杂度：O(n)O(n)。
        ///     存储最大高度数组，需要两次遍历，每次 O(n) 。
        ///     最终使用存储的数据更新\text{ans}ans ，O(n)。
        ///     
        /// 空间复杂度：O(n)O(n) 额外空间。
        ///     和方法 1 相比使用了额外的 O(n) 空间用来放置 left_max 和 right_max 数组。
        /// 作者：LeetCode
        /// 链接：https://leetcode-cn.com/problems/trapping-rain-water/solution/jie-yu-shui-by-leetcode/
        /// </summary>
        /// <param name="height"></param>
        /// <returns></returns>
        public int Trap(int[] height)
        {
            if (height == null || height.Length == 0)
                return 0;
            int ans = 0;
            int size = height.Length;
            int[] left_max = new int[size];
            int[] right_max = new int[size];

            //左边最高点，从左往右扫描
            left_max[0] = height[0];
            for (int i = 1; i < size; i++)
            {
                left_max[i] = Math.Max(height[i], left_max[i - 1]);
            }

            //右边最高点，从右往左扫描
            right_max[size - 1] = height[size - 1];
            for (int i = size - 2; i >= 0; i--)
            {
                right_max[i] = Math.Max(height[i], right_max[i + 1]);
            }

            for (int i = 1; i < size - 1; i++)
            {
                //比较左侧高点, 比较 右侧的高度差，取较小的值（该算法为核心算法）
                ans += Math.Min(left_max[i], right_max[i]) - height[i];
            }
            return ans;
        }

        /// <summary>
        /// 直接按问题描述进行。对于数组中的每个元素，我们找出下雨后水能达到的最高位置，等于两边最大高度的较小值减去当前高度的值。
        /// 时间复杂度： O(n^2)
        /// 空间复杂度： O(1)
        /// </summary>
        /// <param name="height"></param>
        /// <returns></returns>
        public int Trap_Slow(int[] height)
        {
            int ans = 0;
            int size = height.Length;
            for (int i = 1; i < size - 1; i++)
            {
                int max_left = 0, max_right = 0;
                for (int j = i; j >= 0; j--)
                { //Search the left part for max bar size
                    max_left = Math.Max(max_left, height[j]);
                }
                for (int j = i; j < size; j++)
                { //Search the right part for max bar size
                    max_right = Math.Max(max_right, height[j]);
                }
                ans += Math.Min(max_left, max_right) - height[i];
            }
            return ans;
        }
    }
}
