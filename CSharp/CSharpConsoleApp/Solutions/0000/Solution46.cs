using System;
using System.Collections.Generic;

namespace CSharpConsoleApp.Solutions
{
    /*
     * @lc app=leetcode.cn id=46 lang=csharp
     *
     * [46] 全排列
     *
     * https://leetcode-cn.com/problems/permutations/description/
     *
     * Category	Difficulty	Likes	Dislikes
     * algorithms	Medium (77.89%)	1356	-
     * Tags
     * backtracking
     * 
     * Companies
     * linkedin | microsoft
     * 
     * Total Accepted:    321.7K
     * Total Submissions: 413K
     * Testcase Example:  '[1,2,3]'
     *
     * 给定一个不含重复数字的数组 nums ，返回其 所有可能的全排列 。你可以 按任意顺序 返回答案。
     * 
     * 示例 1：
     * 输入：nums = [1,2,3]
     * 输出：[[1,2,3],[1,3,2],[2,1,3],[2,3,1],[3,1,2],[3,2,1]]
     * 
     * 
     * 示例 2：
     * 输入：nums = [0,1]
     * 输出：[[0,1],[1,0]]
     * 
     * 
     * 示例 3：
     * 输入：nums = [1]
     * 输出：[[1]]
     * 
     * 
     * 提示：
     * 1 <= nums.length <= 6
     * -10 <= nums[i] <= 10
     * nums 中的所有整数 互不相同
     * 
     */
    public class Solution46 : SolutionBase
    {
        public override bool Test(System.Diagnostics.Stopwatch sw)
        {
            IList<IList<int>> result = Permute(new int[] {1,2,3,4});

            Print("result = \n{0}", GetArray2DStr(result));

            return true;
        }

        #region --------------- my answer ---------------
        List<IList<int>> result = new List<IList<int>>();

        /// <summary>
        /// 25/25 cases passed (296 ms)
        /// Your runtime beats 37.1 % of csharp submissions
        /// Your memory usage beats 6.36 % of csharp submissions(32.4 MB)
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public IList<IList<int>> Permute_MY(int[] nums)
        {
            if (nums.Length <= 1)
            {
                result.Add(nums);
                return result;
            }

            for (int i = 0; i < nums.Length; i++)
            {
                result.Add(new List<int>(new int[] { nums[i] }));
            }
            AddNext(1, nums);
            return result;
        }

        void AddNext(int depth, int[] nums)
        {
            int n = nums.Length;

            int m = result.Count;

            //Print("before result count = " + result.Count);

            for (int i= m-1; i >=0; i--)
            {
                for (int j = n-1; j >=0 ; j--)
                {
                    if (!result[i].Contains(nums[j]))
                    {
                        IList<int> clone = new List<int>(result[i]);
                        clone.Add(nums[j]);
                        result.Add(clone);
                    }
                }
                result.RemoveAt(i);
            }

            //Print("after  result count = " + result.Count);

            depth++;
            if(depth < n-1)
                AddNext(depth, nums);
            return;
        }
        #endregion


        /// <summary>
        /// 25/25 cases passed (272 ms)
        /// Your runtime beats 96.82 % of csharp submissions
        /// Your memory usage beats 54.42 % of csharp submissions(31.4 MB)
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public IList<IList<int>> Permute(int[] nums)
        {
            List<IList<int>> res = new List<IList<int>>();

            List<int> output = new List<int>();
            foreach (int num in nums)
            {
                output.Add(num);    //output是一个原序列数组。
            }

            int n = nums.Length;
            Backtrack(n, output, res, 0);
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
        /// [1,2,3,4]
        /// [1,2,4,3]
        /// [1,3,2,4]
        /// [1,3,4,2]
        /// [1,4,3,2]
        /// [1,4,2,3]
        /// [2,1,3,4]
        /// [2,1,4,3]
        /// [2,3,1,4]
        /// [2,3,4,1]
        /// [2,4,3,1]
        /// [2,4,1,3]
        /// [3,2,1,4]
        /// [3,2,4,1]
        /// [3,1,2,4]
        /// [3,1,4,2]
        /// [3,4,1,2]
        /// [3,4,2,1]
        /// [4,2,3,1]
        /// [4,2,1,3]
        /// [4,3,2,1]
        /// [4,3,1,2]
        /// [4,1,3,2]
        /// [4,1,2,3]
        /// 
        /// </summary>
        /// <param name="n"></param>
        /// <param name="output"></param>
        /// <param name="res"></param>
        /// <param name="first"></param>
        public void Backtrack(int n, List<int> output, List<IList<int>> res, int first)
        {
            // 所有数都填完了
            if (first == n)
            {
                res.Add(new List<int>(output)); //添加当前结果之一
            }
            //[0, first−1] 是已填过的数的集合，[first, n−1]是待填的数的集合
            for (int i = first; i < n; i++)  //通过不停交换位置，实现所有组合。
            {
                // 动态维护数组
                CollectionsSwap<int>(output, first, i); //交换元素 first 和 i；//Collections.swap(output, first, i);
                // 继续递归填下一个数
                Backtrack(n, output, res, first + 1); //下一个
                // 撤销操作
                CollectionsSwap<int>(output, first, i); //交换元素 first 和 i；//Collections.swap(output, first, i); 
            }
        }

        void CollectionsSwap<T>(List<T> list, int i1, int i2)
        {
            T tmp = list[i1];
            list[i1] = list[i2];
            list[i2] = tmp;
        }
    }
}
