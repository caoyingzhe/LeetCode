using System;
using System.Collections.Generic;
namespace CSharpConsoleApp.Solutions
{
    /*
 * @lc app=leetcode.cn id=697 lang=csharp
 *
 * [697] 数组的度
 *
 * https://leetcode-cn.com/problems/degree-of-an-array/description/
 *
 * algorithms
 * Easy (60.60%)
 * Likes:    360
 * Dislikes: 0
 * Total Accepted:    65K
 * Total Submissions: 107.2K
 * Testcase Example:  '[1,2,2,3,1]'
 *
 * 给定一个非空且只包含非负数的整数数组 nums，数组的度的定义是指数组里任一元素出现频数的最大值。
 * 
 * 你的任务是在 nums 中找到与 nums 拥有相同大小的度的最短连续子数组，返回其长度。
 * 
 * 
 * 
 * 示例 1：
 * 
 * 
 * 输入：[1, 2, 2, 3, 1]
 * 输出：2
 * 解释：
 * 输入数组的度是2，因为元素1和2的出现频数最大，均为2.
 * 连续子数组里面拥有相同度的有如下所示:
 * [1, 2, 2, 3, 1], [1, 2, 2, 3], [2, 2, 3, 1], [1, 2, 2], [2, 2, 3], [2, 2]
 * 最短连续子数组[2, 2]的长度为2，所以返回2.
 * 
 * 
 * 示例 2：
 * 
 * 
 * 输入：[1,2,2,3,1,4,2]
 * 输出：6
 * 
 * 
 * 
 * 
 * 提示：
 * 
 * 
 * nums.length 在1到 50,000 区间范围内。
 * nums[i] 是一个在 0 到 49,999 范围内的整数。
 * 
 * 
 */

    // @lc code=start
    public class Solution697 : SolutionBase
    {
        /// <summary>
        /// 难度
        /// </summary>
        public override Difficulity GetDifficulity() { return Difficulity.Easy; }
        /// <summary>
        /// 关键字:
        /// </summary>
        public override string[] GetKeyWords() { return new string[] { "抄作业", "数组的度" }; }
        /// <summary>
        /// 标签：
        /// </summary>
        public override Tag[] GetTags() { return new Tag[] { Tag.Array }; }

        /// <summary>
        /// </summary>
        /// <param name="sw"></param>
        /// <returns></returns>
        public override bool Test(System.Diagnostics.Stopwatch sw)
        {
            bool isSuccess = true;
            //TODO
            //PrintDatas(PoorPigs(new int[] { 0, 0 }, new int[] { 1, 1 }, new int[] { 1, 0 }, new int[] { 0, 1 }));
            return isSuccess;
        }


        /// <summary>
        /// 89/89 cases passed (116 ms)
        /// Your runtime beats 100 % of csharp submissions
        /// Your memory usage beats 100 % of csharp submissions(31.8 MB)
        /// 作者：LeetCode - Solution
        /// 链接：https://leetcode-cn.com/problems/degree-of-an-array/solution/shu-zu-de-du-by-leetcode-solution-ig97/
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public int FindShortestSubArray(int[] nums)
        {
            //值 : 1,i,i  出现次数（度）, 第一次出现的索引,最后一次出现的索引
            Dictionary<int, int[]> dict = new Dictionary<int, int[]>();
            int n = nums.Length;
            for (int i = 0; i < n; i++)
            {
                if (dict.ContainsKey(nums[i]))
                {
                    //出现次数++
                    dict[nums[i]][0]++;
                    //索引 = i;
                    dict[nums[i]][2] = i;
                }
                else
                {
                    dict.Add(nums[i], new int[] { 1, i, i });
                }
            }

            int maxNum = 0, minLen = 0;
            foreach (int key in dict.Keys)
            {
                int[] arr = dict[key];

                //找到最大的度
                if (maxNum < arr[0])
                {
                    maxNum = arr[0];
                    minLen = arr[2] - arr[1] + 1;
                }
                else if (maxNum == arr[0])
                {
                    //arr[2]-arr[1]代表：相同大小的度的最短连续子数组 的 长度
                    if (minLen > arr[2] - arr[1] + 1)
                    {
                        minLen = arr[2] - arr[1] + 1;
                    }
                }
            }
            return minLen;
        }
    }
    // @lc code=end


}
