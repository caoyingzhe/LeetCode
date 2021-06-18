using System;
using System.Collections.Generic;
namespace CSharpConsoleApp.Solutions
{
    /*
 * @lc app=leetcode.cn id=90 lang=csharp
 *
 * [90] 子集 II
 *
 * https://leetcode-cn.com/problems/subsets-ii/description/
 *
 * algorithms
 * Medium (63.40%)
 * Likes:    593
 * Dislikes: 0
 * Total Accepted:    115.6K
 * Total Submissions: 182.3K
 * Testcase Example:  '[1,2,2]'
 *
 * 给你一个整数数组 nums ，其中可能包含重复元素，请你返回该数组所有可能的子集（幂集）。
 * 
 * 解集 不能 包含重复的子集。返回的解集中，子集可以按 任意顺序 排列。
 * 
 * 
 * 
 * 
 * 
 * 示例 1：
 * 
 * 
 * 输入：nums = [1,2,2]
 * 输出：[[],[1],[1,2],[1,2,2],[2],[2,2]]
 * 
 * 
 * 示例 2：
 * 
 * 
 * 输入：nums = [0]
 * 输出：[[],[0]]
 * 
 * 
 * 
 * 
 * 提示：
 * 
 * 
 * 1 
 * -10 
 * 
 * 
 * 
 * 
 */

    // @lc code=start
    public class Solution90 : SolutionBase
    {
        /// <summary>
        /// 难易度:
        /// </summary>
        public override Difficulity GetDifficulity() { return Difficulity.Medium; }
        /// <summary>
        /// 关键字:
        /// </summary>
        public override string[] GetKeyWords() { return new string[] { "" }; }
        /// <summary>
        /// 标签： binary-search | divide-and-conquer | sort | binary-indexed-tree | segment-tree
        /// </summary>
        public override Tag[] GetTags() { return new Tag[] { Tag.Array, Tag.Backtracking }; }

        public override bool Test(System.Diagnostics.Stopwatch sw)
        {
            bool isSuccess = false;
            //TODO
            return isSuccess;
        }

        List<int> t = new List<int>();
        List<IList<int>> ans = new List<IList<int>>();

        /// <summary>
        /// 递归法实现子集枚举
        /// https://leetcode-cn.com/problems/subsets-ii/solution/zi-ji-ii-by-leetcode-solution-7inq/
        /// 19/19 cases passed (276 ms)
        /// Your runtime beats 86.1 % of csharp submissions
        /// Your memory usage beats 72.2 % of csharp submissions(30.9 MB)
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public IList<IList<int>> SubsetsWithDup(int[] nums)
        {
            Array.Sort(nums);
            DFS(false, 0, nums);
            return ans;
        }

        public void DFS(bool choosePre, int cur, int[] nums)
        {
            if (cur == nums.Length)
            {
                ans.Add(new List<int>(t));
                return;
            }
            DFS(false, cur + 1, nums);
            if (!choosePre && cur > 0 && nums[cur - 1] == nums[cur])
            {
                return;
            }
            t.Add(nums[cur]);
            DFS(true, cur + 1, nums);
            t.RemoveAt(t.Count - 1);
        }
    }
    // @lc code=end


}
