using System;
using System.Collections.Generic;
using System.Linq;
namespace CSharpConsoleApp.Solutions
{
    /*
     * @lc app=leetcode.cn id=219 lang=csharp
     *
     * [219] 存在重复元素 II
     *
     * https://leetcode-cn.com/problems/contains-duplicate-ii/description/
     *
     * Category	Difficulty	Likes	Dislikes
     * algorithms	Easy (42.19%)	278	-
     * Tags
     * array | hash-table
     * 
     * Companies
     * airbnb | palantir
     * 
     * Total Accepted:    95.9K
     * Total Submissions: 227.1K
     * Testcase Example:  '[1,2,3,1]\n3'
     *
     * 给定一个整数数组和一个整数 k，判断数组中是否存在两个不同的索引 i 和 j，使得 nums [i] = nums [j]，
     * 并且 i 和 j 的差的绝对值 至多为 k。
     * 
     * 
     * 示例 1:
     * 输入: nums = [1,2,3,1], k = 3
     * 输出: true
     * 
     * 示例 2:
     * 输入: nums = [1,0,1,1], k = 1
     * 输出: true
     * 
     * 示例 3:
     * 输入: nums = [1,2,3,1,2,3], k = 2
     * 输出: false
     */

    // @lc code=start
    public class Solution219 : SolutionBase
    {
        /// <summary>
        /// 难度
        /// </summary>
        public override Difficulity GetDifficulity() { return Difficulity.Easy; }
        /// <summary>
        /// 关键字:
        /// </summary>
        public override string[] GetKeyWords() { return new string[] { "" }; }
        /// <summary>
        /// 标签：
        /// </summary>
        public override Tag[] GetTags() { return new Tag[] { Tag.Array, Tag.HashTable, }; }

        public override bool Test(System.Diagnostics.Stopwatch sw)
        {
            bool isSuccess = true;

            bool result, checkResult;
            int[] nums = new int[] {1, 0, 1, 1}; int k = 1;
            checkResult = true;
            result = ContainsNearbyDuplicate(nums, k);
            isSuccess &= IsSame(result, checkResult);
            PrintResult(isSuccess, (result), (checkResult));

            return isSuccess;
        }

        /// <summary>
        /// 关键题意 ： i 和 j 的差的绝对值 至多为 k 的意思是索引差至多为 K
        /// 50/50 cases passed (272 ms)
        /// Your runtime beats 6.32 % of csharp submissions
        /// Your memory usage beats 5.27 % of csharp submissions(43.3 MB)
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public bool ContainsNearbyDuplicate1(int[] nums, int k)
        {
            HashSet<int> set = new HashSet<int>();
            for (int i = 0; i < nums.Length; ++i)
            {
                if (set.Contains(nums[i])) return true;
                set.Add(nums[i]);

                if (set.Count > k)
                {
                    //此处保证 i 和 j 的差的绝对值 至多为 k 的意思是索引差至多为 K
                    //因为超出 K 即 毫无意义。删除前K个即可，（隐含前提为：此处还未出现重复元素）
                    set.Remove(nums[i - k]);
                }
            }
            return false;
        }

        /// <summary>
        /// 作者：Echo__wwW
        /// 50/50 cases passed (380 ms)
        /// Your runtime beats 6.32 % of csharp submissions
        /// Your memory usage beats 5.27 % of csharp submissions(47.3 MB)
        /// 链接：https://leetcode-cn.com/problems/contains-duplicate-ii/solution/javajie-fa-ling-pi-xi-jing-er-wei-shu-zu-s94f/
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public bool ContainsNearbyDuplicate(int[] nums, int k)
        {
            int[][] allNums = new int[nums.Length][];
            for (int i = 0; i < nums.Length; i++)
            {
                allNums[i] = new int[2];
                allNums[i][0] = nums[i];
                allNums[i][1] = i;
            }
            Array.Sort(allNums, (a, b) =>
            {
                if (a[0] == b[0]) return a[1] - b[1];
                return a[0] - b[0];
            });
            
            for (int i = 1; i<nums.Length; i++) {
                if (allNums[i][0] == allNums[i - 1][0] && allNums[i][1] - allNums[i - 1][1] <= k) return true;
            }
            return false;
        }
    }
    // @lc code=end


}
