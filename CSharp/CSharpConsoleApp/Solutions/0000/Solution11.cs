using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpConsoleApp.Solutions._0000
{
    /*
     * @lc app=leetcode.cn id=11 lang=csharp
     *
     * [11] 盛最多水的容器
     *
     * https://leetcode-cn.com/problems/container-with-most-water/description/
     *
     * Category	Difficulty	Likes	Dislikes
     * algorithms	Medium (64.54%)	2317	-
     * Tags
     * array | two-pointers
     * 
     * Companies
     * bloomberg
     * Total Accepted:    402.5K
     * Total Submissions: 623.9K
     * Testcase Example:  '[1,8,6,2,5,4,8,3,7]'
     *
     * 给你 n 个非负整数 a1，a2，...，an，每个数代表坐标中的一个点 (i, ai) 。在坐标内画 n 条垂直线，垂直线 i 的两个端点分别为
     * (i, ai) 和 (i, 0) 。找出其中的两条线，使得它们与 x 轴共同构成的容器可以容纳最多的水。
     * 
     * 说明：你不能倾斜容器。
     * 
     * 
     * 
     * 示例 1：
     * 输入：[1,8,6,2,5,4,8,3,7]
     * 输出：49 
     * 解释：图中垂直线代表输入数组 [1,8,6,2,5,4,8,3,7]。在此情况下，容器能够容纳水（表示为蓝色部分）的最大值为 49。
     * 
     * 示例 2：
     * 输入：height = [1,1]
     * 输出：1
     * 
     * 
     * 示例 3：
     * 输入：height = [4,3,2,1,4]
     * 输出：16
     * 
     * 
     * 示例 4：
     * 输入：height = [1,2,1]
     * 输出：2
     * 
     * 提示：
     * n = height.length
     * 2 <= n <= 3 * 10^4
     * 0 <= height[i] <= 3 * 10^4
     */
    class Solution11 : SolutionBase
    {
        /// <summary>
        /// 难度
        /// </summary>
        public override Difficulity GetDifficulity() { return Difficulity.Hard; }
        /// <summary>
        /// 关键字:
        /// </summary>
        public override string[] GetKeyWords() { return new string[] { "双指针", "容器边界问题" }; }
        /// <summary>
        /// 标签：
        /// </summary>
        public override Tag[] GetTags() { return new Tag[] { Tag.TwoPointers }; }
        public override bool Test(System.Diagnostics.Stopwatch sw)
        {
            bool isSuccess = true;
            int[] nums;
            int result;
            int checkResult;

            nums = new int[] { 1, 8, 6, 2, 5, 4, 8, 3, 7 };
            checkResult = 49;
            result = MaxArea(nums);
            isSuccess &= result == checkResult;
            Print("isSuccess = {0} | result = {1} | anticipated = {2}", isSuccess, result, checkResult);

            return isSuccess;
        }

        /// <summary>
        /// Time Limit Exceeded
        /// </summary>
        /// <param name="height"></param>
        /// <returns></returns>
        public int MaxArea_TLE(int[] height)
        {
            int max = 0;
            int n = height.Length;

            if (n <= 1)
                return 0;
            if (n == 2)
                return Math.Min(height[0], height[1]);

            //List<int[]> sortHeight = new List<int[]>();
            //for (int i = 0; i < n; i++)
            //{
            //    sortHeight.Add(new int[] { i, height[i] });
            //}
            //sortHeight.Sort((a,b) => { return a[1] - b[1]; }); //降序
            //Dictionary<int, int[]> heightIndexDict = new Dictionary<int, int[]>();

            for (int i = 0; i < n; i++)
            {
                int vol = (n - 1 - i) * Math.Min(height[i], height[n - 1]);

                max = Math.Max(vol, max);
                for (int j = n - 2; j > i; j--)
                {
                    if (height[j] < height[j + 1])
                    {
                        continue;
                    }
                    else
                    {
                        vol = (j - i) * Math.Min(height[i], height[j]);
                        max = Math.Max(vol, max);
                    }
                }
            }
            return max;
        }

        /// <summary>
        /// 官方解答 双指针
        /// 作者：LeetCode-Solution
        /// 链接：https://leetcode-cn.com/problems/container-with-most-water/solution/sheng-zui-duo-shui-de-rong-qi-by-leetcode-solution/
        /// </summary>
        /// <param name="height"></param>
        /// <returns></returns>
        public int MaxArea(int[] height)
        {
            int l = 0, r = height.Length - 1;
            int ans = 0;
            while (l < r)
            {
                int area = Math.Min(height[l], height[r]) * (r - l);
                ans = Math.Max(ans, area);
                if (height[l] <= height[r])
                {
                    ++l;
                }
                else
                {
                    --r;
                }
            }
            return ans;
        }
    }
}
