using System;
using System.Collections.Generic;
namespace CSharpConsoleApp.Solutions
{
    /*
 * @lc app=leetcode.cn id=491 lang=csharp
 *
 * [491] 递增子序列
 *
 * https://leetcode-cn.com/problems/increasing-subsequences/description/
 *
 * Category	Difficulty	Likes	Dislikes
 * algorithms	Medium (55.06%)	297	-
 * Tags
 * depth-first-search
 * 
 * Companies
 * yahoo
 * 
 * Total Accepted:    39.4K
 * Total Submissions: 71.5K
 * Testcase Example:  '[4,6,7,7]'
 *
 * 给定一个整型数组, 你的任务是找到所有该数组的递增子序列，递增子序列的长度至少是 2 。
 * 
 * 
 * 示例：
 * 输入：[4, 6, 7, 7]
 * 输出：[[4, 6], [4, 7], [4, 6, 7], [4, 6, 7, 7], [6, 7], [6, 7, 7], [7,7],
 * [4,7,7]]
 * 
 * 
 * 提示：
 * 给定数组的长度不会超过15。
 * 数组中的整数范围是 [-100,100]。
 * 给定数组中可能包含重复数字，相等的数字应该被视为递增的一种情况。
 */

    // @lc code=start
    public class Solution491 : SolutionBase
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
        public override Tag[] GetTags() { return new Tag[] { Tag.DepthFirstSearch }; }

        public override bool Test(System.Diagnostics.Stopwatch sw)
        {
            bool isSuccess = true;
            int[] nums;
            IList<IList<int>> result, checkResult;

            checkResult = new int[][] {
                new int[] { 4, 6},
                new int[] { 4, 6, 7},
                new int[] { 4, 6, 7, 7 },
                new int[] { 4, 7 },
                new int[] { 4, 7, 7},
                new int[] { 6, 7 },
                new int[] { 6, 7, 7},
                new int[] { 7, 7 }
            };
            nums = new int[] { 4, 6, 7, 7 };
            result = FindSubsequences(nums);
            isSuccess &= IsArray2DSame(result, checkResult, true);
            Print("isSuccess = {0} | result = {1} | anticipated = {2}", isSuccess, GetArray2DStr(result), GetArray2DStr(checkResult));

            checkResult = new int[][] {
                new int[] { 4, 4}
            };
            nums = new int[] { 4, 4, 3, 2, 1};
            result = FindSubsequences(nums);
            isSuccess &= IsArray2DSame(result, checkResult, true);
            Print("isSuccess = {0} | result = {1} | anticipated = {2}", isSuccess, GetArray2DStr(result), GetArray2DStr(checkResult));


            return isSuccess;
        }



        //https://leetcode-cn.com/problems/increasing-subsequences/solution/java-ji-hu-shuang-bai-jie-jue-di-zeng-zi-xu-lie-we/

        List<IList<int>> res;
        List<int> data;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public IList<IList<int>> FindSubsequences(int[] nums)
        {
            if (nums == null)
            {
                return null;
            }

            res = new List<IList<int>>();
            data = new List<int>();

            //不可以改变数组顺序。
            //Array.Sort(nums);
            DFS(nums,  int.MinValue, 0);

            return res;
        }

        public void DFS(int[] nums, int preValue, int curIndex)
        {
            if (curIndex >= nums.Length)
            {
                if (data.Count >= 2)
                {                                            
                    res.Add(new List<int>(data.ToArray()));
                }
                return;
            }
            if (nums[curIndex] >= preValue)
            {   // 将当前元素加入，并向后遍历
                data.Add(nums[curIndex]);
                DFS(nums, nums[curIndex], curIndex + 1);
                data.RemoveAt(data.Count - 1);
            }
            if (nums[curIndex] != preValue)
            {   // 不遍历 重复元素
                DFS(nums, preValue, curIndex + 1);
                //dfs(curIndex + 1, preValue, nums);  // 将下一个元素加入，并向后遍历
            }
        }
    }
    // @lc code=end


}
