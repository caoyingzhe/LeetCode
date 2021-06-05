using System;
using System.Collections.Generic;
namespace CSharpConsoleApp.Solutions
{
    /*
     * @lc app=leetcode.cn id=78 lang=csharp
     *
     * [78] 子集
     *
     * https://leetcode-cn.com/problems/subsets/description/
     *
     * Category	Difficulty	Likes	Dislikes
     * algorithms	Medium (79.85%)	1208	-
     * Tags
     * array | backtracking | bit-manipulation
     * 
     * Companies
     * amazon | bloomberg | facebook | uber
     * 
     * Total Accepted:    255.5K
     * Total Submissions: 319.9K
     * Testcase Example:  '[1,2,3]'
     *
     * 给你一个整数数组 nums ，数组中的元素 互不相同 。返回该数组所有可能的子集（幂集）。
     * 解集 不能 包含重复的子集。你可以按 任意顺序 返回解集。
     * 
     * 示例 1：
     * 输入：nums = [1,2,3]
     * 输出：[[],[1],[2],[1,2],[3],[1,3],[2,3],[1,2,3]]
     * 
     * 示例 2：
     * 输入：nums = [0]
     * 输出：[[],[0]]
     *
     * 
     * 提示：
     * 1 <= nums.length <= 10
     * -10 <= nums[i] <= 10
     * nums 中的所有元素 互不相同
     */
    public class Solution78
    {


        /// <summary>
        /// 迭代法，利用了int的位操作充当mask的特点。
        /// 时间复杂度：O(n * 2^n)                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                       
        /// 空间复杂度：O(n)
        /// 10/10 cases passed (288 ms)
        /// Your runtime beats 45.08 % of csharp submissions
        /// Your memory usage beats 54.1 % of csharp submissions(30.4 MB)
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public IList<IList<int>> Subsets_Iterator(int[] nums)
        {
            List<int> t = new List<int>();
            List<IList<int>> ans = new List<IList<int>>();

            int n = nums.Length;
            for (int mask = 0; mask < (1 << n); ++mask) //因为n<=10,可以用int类型处理
            {
                t.Clear();
                for (int i = 0; i < n; ++i)
                {
                    if ((mask & (1 << i)) != 0)
                    {
                        t.Add(nums[i]);
                    }
                }
                ans.Add(new List<int>(t));
            }
            return ans;
        }

        //作者：LeetCode-Solution
        //链接：https://leetcode-cn.com/problems/subsets/solution/zi-ji-by-leetcode-solution/


        List<int> t = new List<int>();
        List<IList<int>> ans = new List<IList<int>>();

        /// <summary>
        /// 回溯法，速度更快。（这里用了DFS）
        /// 时间复杂度：O(n * 2^n)
        /// 空间复杂度：O(n)
        /// 10/10 cases passed (264 ms)
        /// Your runtime beats 97.54 % of csharp submissions
        /// Your memory usage beats 64.34 % of csharp submissions(30.4 MB)
        /// </summary>
        public IList<IList<int>> Subsets(int[] nums)
        {
            DFS(0, nums);
            return ans;
        }

        public void DFS(int cur, int[] nums)
        {
            if (cur == nums.Length)
            {
                ans.Add(new List<int>(t));
                return;
            }
            t.Add(nums[cur]);
            DFS(cur + 1, nums);
            t.RemoveAt(t.Count - 1);
            DFS(cur + 1, nums);
        }
    }
}
