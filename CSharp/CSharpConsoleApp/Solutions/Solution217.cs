using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpConsoleApp.Solutions
{
    /// <summary>
    /*
    * @lc app=leetcode.cn id=217 lang=csharp
    *
    * [217] 存在重复元素
    *
    * https://leetcode-cn.com/problems/contains-duplicate/description/
    *
    * algorithms
    * Easy (55.69%)
    * Likes:    393
    * Dislikes: 0
    * Total Accepted:    266.7K
    * Total Submissions: 478.9K
    * Testcase Example:  '[1,2,3,1]'
    *
    * 给定一个整数数组，判断是否存在重复元素。
    * 
    * 如果存在一值在数组中出现至少两次，函数返回 true 。如果数组中每个元素都不相同，则返回 false 。
    * 
    * 示例 1:
    * 输入: [1,2,3,1]
    * 输出: true
    * 
    * 示例 2:
    * 输入: [1,2,3,4]
    * 输出: false
    * 
    * 示例 3:
    * 输入: [1,1,1,3,3,4,3,2,4,2]
    * 输出: true
    * 
    */
    /// /// </summary>
    class Solution217 : SolutionBase
    {
        /// <summary>
        /// 难度
        /// </summary>
        public override Difficulity GetDifficulity() { return Difficulity.Easy; }
        /// <summary>
        /// 关键字:
        /// </summary>
        public override string[] GetKeyWords() { return new string[] { "无聊" }; }
        /// <summary>
        /// 标签： 
        /// </summary>
        public override Tag[] GetTags() { return new Tag[] { Tag.HashTable }; }

        public override bool Test(System.Diagnostics.Stopwatch sw)
        {
            int[] nums;
            bool checkResult;
            bool isSuccess = true;

            nums = new int[] { 1, 1, 1, 3, 3, 4, 3, 2, 4, 2 };
            checkResult = true;

            Print("isSuccess = {0} | result= {1} | resultChecked = {2}", isSuccess, string.Join(",", result), string.Join(",", checkResult));

            isSuccess &= ContainsDuplicate(nums) == checkResult;

            return isSuccess;
        }

        public bool ContainsDuplicate(int[] nums)
        {
            HashSet<int> set = new HashSet<int>();
            foreach(int val in nums)
            {
                if (set.Contains(val))
                    return true;
                else
                    set.Add(val);
            }
            return false;
        }
    }
}
