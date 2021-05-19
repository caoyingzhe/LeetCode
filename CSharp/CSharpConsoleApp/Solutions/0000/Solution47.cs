using System;
using System.Collections.Generic;

namespace CSharpConsoleApp.Solutions
{
    /*
     * @lc app=leetcode.cn id=47 lang=csharp
     *
     * [47] 全排列 II
     *
     * https://leetcode-cn.com/problems/permutations-ii/description/
     *
     * Category	Difficulty	Likes	Dislikes
     * algorithms	Medium (63.20%)	701	-
     * Tags
     * backtracking
     * 
     * Companies
     * linkedin | microsoft
     * 
     * Total Accepted:    167.5K
     * Total Submissions: 265K
     * Testcase Example:  '[1,1,2]'
     *
     * 给定一个可包含重复数字的序列 nums ，按任意顺序 返回所有不重复的全排列。
     * 
     * 示例 1：
     * 输入：nums = [1,1,2]
     * 输出：
     * [[1,1,2],
     * ⁠[1,2,1],
     * ⁠[2,1,1]]
     * 
     * 
     * 示例 2：
     * 输入：nums = [1,2,3]
     * 输出：[[1,2,3],[1,3,2],[2,1,3],[2,3,1],[3,1,2],[3,2,1]]
     * 
     * 
     * 提示：
     * 1 <= nums.length <= 8
     * -10 <= nums[i] <= 10
     * 
     */
    public class Solution47 : SolutionBase
    {
        public override bool Test(System.Diagnostics.Stopwatch sw)
        {
            IList<IList<int>> result = Permute46(new int[] { 1, 1, 2 });
            Print("result = \n{0}", GetArray2DStr(result));

            result = PermuteUnique(new int[] { 1, 1, 2 });
            Print("result = \n{0}", GetArray2DStr(result));

            return true;
        }


        bool[] vis; //保存数字的数组

        /// <summary>
        /// 25/25 cases passed (272 ms)
        /// Your runtime beats 96.82 % of csharp submissions
        /// Your memory usage beats 54.42 % of csharp submissions(31.4 MB)
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public IList<IList<int>> Permute46(int[] nums)
        {
            vis = new bool[nums.Length];
            for (int i = 0; i < nums.Length; i++) vis[i] = false;
            List<IList<int>> res = new List<IList<int>>();

            List<int> output = new List<int>();

            Array.Sort(nums);
            foreach (int num in nums)
            {
                output.Add(num);    //output是一个原序列数组。
            }

            int n = nums.Length;
            Backtrack46(n, output, res, nums, 0);
            return res;
        }
        /// <summary>
        /// 作者：LeetCode-Solution
        /// 链接：https://leetcode-cn.com/problems/permutations/solution/quan-pai-lie-by-leetcode-solution-2/
        ///
        /// backtrack 的调用次数是 O(n!) <3n!
        /// 
        /// 时间复杂度为 O(n×n!)
        /// 空间复杂度：O(n)O(n)
        /// 
        /// [2,5,8,9,10] => [8,9|2,5,10] => [first]=2,[n-1]=10,交换[2]与[10]，=> [8,9,10|2,5]
        /// 注意：该方法生成结果非字典序。
        /// 
        /// </summary>
        /// <param name="n"></param>
        /// <param name="output"></param>
        /// <param name="res"></param>
        /// <param name="first"></param>
        public void Backtrack46(int n, List<int> output, List<IList<int>> res, int[] nums, int first)
        {
            // 所有数都填完了
            if (first == n)
            {
                Print("Add vis ={0} | {1}", GetArrayStr(vis), GetArrayStr(output));
                res.Add(new List<int>(output)); //添加当前结果之一
            }
            //[0, first−1] 是已填过的数的集合，[first, n−1]是待填的数的集合
            for (int i = first; i < n; i++)  //通过不停交换位置，实现所有组合。
            {
                if (vis[i] || (i > 0 && output[i] == output[i - 1] && !vis[i - 1]))
                {
                    Print("first={0} i={1} | vis = {2} | {3}", first,i, GetArrayStr(vis), GetArrayStr(output));
                    continue;
                }

                // 动态维护数组
                CollectionsSwap<int>(output, first, i); //交换元素 first 和 i；//Collections.swap(output, first, i);
                //output.Add(nums[i]);
                vis[i] = true;

                // 继续递归填下一个数
                Backtrack46(n, output, res, nums, first + 1); //下一个
                
                // 撤销操作
                CollectionsSwap<int>(output, first, i); //交换元素 first 和 i；//Collections.swap(output, first, i); 
                vis[i] = false;
                //output.RemoveAt(first + 1);
            }
        }

        void CollectionsSwap<T>(List<T> list, int i1, int i2)
        {
            T tmp = list[i1];
            list[i1] = list[i2];
            list[i2] = tmp;
        }

        /// <summary>
        ///  效率不佳
        ///  33/33 cases passed (300 ms)
        ///  Your runtime beats 28.77 % of csharp submissions
        ///  Your memory usage beats 19.18 % of csharp submissions(33.1 MB)
        ///  作者：LeetCode-Solution
        ///  链接：https://leetcode-cn.com/problems/permutations-ii/solution/quan-pai-lie-ii-by-leetcode-solution/
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public IList<IList<int>> PermuteUnique(int[] nums)
        {
            int n = nums.Length;
            vis = new bool[nums.Length];
            for (int i = 0; i < nums.Length; i++) vis[i] = false;
            List<IList<int>> ans = new List<IList<int>>();

            List<int> perm = new List<int>();
            Array.Sort(nums);

            Backtrack(nums, ans, 0, perm);
            return ans;
        }

        public void Backtrack(int[] nums, List<IList<int>> ans, int idx, List<int> perm)
        {
            if (idx == nums.Length)
            {
                ans.Add(new List<int>(perm));
                return;
            }
            for (int i = 0; i < nums.Length; ++i)
            {
                if (vis[i] || (i > 0 && nums[i] == nums[i - 1] && !vis[i - 1]))
                {
                    Print("first={0} i={1} | vis = {2} | {3}", i, i, GetArrayStr(vis), GetArrayStr(perm));

                    continue;
                }
                perm.Add(nums[i]);
                vis[i] = true;
                Backtrack(nums, ans, idx + 1, perm);
                vis[i] = false;
                perm.RemoveAt(idx);
            }
        }

    }
}
