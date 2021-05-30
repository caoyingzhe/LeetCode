using System;
using System.Collections.Generic;
namespace CSharpConsoleApp.Solutions
{
    /*
     * @lc app=leetcode.cn id=560 lang=csharp
     *
     * [560] 和为K的子数组
     *
     * https://leetcode-cn.com/problems/subarray-sum-equals-k/description/
     *
     * Category	Difficulty	Likes	Dislikes
     * algorithms	Medium (44.45%)	909	-
     * Tags
     * array | hash-table
     * 
     * Companies
     * google
     * 
     * Total Accepted:    111.7K
     * Total Submissions: 251.4K
     * Testcase Example:  '[1,1,1]\n2'
     *
     * 给定一个整数数组和一个整数 k，你需要找到该数组中和为 k 的连续的子数组的个数。
     * 
     * 示例 1 :
     * 输入:nums = [1,1,1], k = 2
     * 输出: 2 , [1,1] 与 [1,1] 为两种不同的情况。
     * 
     * 
     * 说明 :
     * 数组的长度为 [1, 20,000]。
     * 数组中元素的范围是 [-1000, 1000] ，且整数 k 的范围是 [-1e^7, 1e^7]。
     */
    public class Solution560 : SolutionBase
    {
        /// <summary>
        /// 难度
        /// </summary>
        public override Difficulity GetDifficulity() { return Difficulity.Medium; }
        /// <summary>
        /// 关键字:
        /// </summary>
        public override string[] GetKeyWords() { return new string[] { "前缀和", "矩阵" }; }
        /// <summary>
        /// 标签： 
        /// </summary>
        public override Tag[] GetTags() { return new Tag[] { Tag.Array, Tag.HashTable }; }

        public override bool Test(System.Diagnostics.Stopwatch sw)
        {
            int result = SubarraySum(new int[] { 1,1,1}, 2);
            Print("result = {0} | {1} ", result, 2);
            return true;
        }


        //作者：hh20001231
        //链接：https://leetcode-cn.com/problems/subarray-sum-equals-k/solution/he-wei-kde-zi-shu-zu-tong-guo-ha-xi-biao-fkt0/

        /// <summary>
        /// 89/89 cases passed (296 ms)
        /// Your runtime beats 5.75 % of csharp submissions
        /// Your memory usage beats 100 % of csharp submissions(35.5 MB)
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public int SubarraySum(int[] nums, int k)
        {
            int ans = 0, sum = 0;
            SortedList<int, int> mp = new SortedList<int, int>();
            mp.Add(0, 1);

            for (int i = 0; i < nums.Length; ++i)
            {
                sum += nums[i];
                if (mp.ContainsKey(sum-k))  //if (mp.find(sum - k) != mp.end())
                {
                    ans += mp[sum - k];
                }
                if (!mp.ContainsKey(sum))
                    mp.Add(sum, 0);
                ++mp[sum];
            }
            return ans;
        }

        //1、暴力法（超时）
        public int SubarraySum_Violence(int[] nums, int k)
        {
            int count = 0;
            int n = nums.Length;

            for (int i = 0; i< n; i++)
            {
		        for (int j= i; j<n; j++)
                {
                    int sum = 0;
			        for (int q = i; q <= j; q++)
                    {
                        sum += nums[q];
                    }
			        if (sum == k) {
                        count++;
			        }
		        }
	        }
            return count;
        }
        //去除重复计算
        public int SubarraySum_Violence_Opt(int[] nums, int k)
        {
            int count = 0;
            int n = nums.Length;

            for (int i = 0; i < n; i++)
            {
                int sum = 0; //Added:
                for (int j = i; j < n; j++)
                {
                    //Removed:
                    //int sum = 0;
                    //for (int q = i; q <= j; q++)
                    //{
                    //    sum += nums[q];
                    //}
                    sum += nums[j]; //Added:
                    if (sum == k)
                    {
                        count++;
                    }
                }
            }
            return count;
        }
    }
}
