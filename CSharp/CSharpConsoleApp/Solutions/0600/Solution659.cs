using System;
using System.Collections.Generic;
namespace CSharpConsoleApp.Solutions
{
    /*
     * @lc app=leetcode.cn id=659 lang=csharp
     *
     * [659] 分割数组为连续子序列
     *
     * https://leetcode-cn.com/problems/split-array-into-consecutive-subsequences/description/
     *
     * Category	Difficulty	Likes	Dislikes
     * algorithms	Medium (54.33%)	305	-
     * Tags
     * heap | greedy
     * 
     * Companies
     * google
     * 
     * Total Accepted:    26.6K
     * Total Submissions: 48.9K
     * Testcase Example:  '[1,2,3,3,4,5]'
     *
     * 给你一个按升序排序的整数数组 num（可能包含重复数字），请你将它们分割成一个或多个长度至少为 3 的子序列，其中每个子序列都由连续整数组成。
     * 如果可以完成上述分割，则返回 true ；否则，返回 false 。
     * 
     * 示例 1：
     * 输入: [1,2,3,3,4,5]
     * 输出: True
     * 解释:
     * 你可以分割出这样两个连续子序列 : 
     * 1, 2, 3
     * 3, 4, 5
     * 
     * 示例 2：
     * 输入: [1,2,3,3,4,4,5,5]
     * 输出: True
     * 解释:
     * 你可以分割出这样两个连续子序列 : 
     * 1, 2, 3, 4, 5
     * 3, 4, 5
     * 
     * 
     * 示例 3：
     * 输入: [1,2,3,4,4,5]
     * 输出: False
     *
     * 
     * 提示：
     * 1 <= nums.length <= 10000
     */
    public class Solution659 : SolutionBase
    {
        /// <summary>

        /// </summary>
        /// <param name="sw"></param>
        /// <returns></returns>
        public override bool Test(System.Diagnostics.Stopwatch sw)
        {
            bool isSuccess = true;
            int[] nums;
            bool result;
            bool checkResult;

            nums = new int[] { 1,2,3,3,4,5};
            checkResult = true;
            result = IsPossible(nums);
            isSuccess &= result == checkResult;
            Print("isSuccess = {0} | result = {1} | anticipated = {2}", isSuccess, (result), (checkResult));

            return isSuccess;
        }

        /// <summary>
        /// 方法二：贪心
        /// 
        /// 186/186 cases passed (272 ms)
        /// Your runtime beats 100 % of csharp submissions
        /// Your memory usage beats 25 % of csharp submissions(43.3 MB)
        /// 
        /// 作者：LeetCode - Solution
        /// 链接：https://leetcode-cn.com/problems/split-array-into-consecutive-subsequences/solution/fen-ge-shu-zu-wei-lian-xu-zi-xu-lie-by-l-lbs5/
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public bool IsPossible(int[] nums)
        {
            //第一个哈希表存储数组中的每个数字的剩余次数
            Dictionary<int, int> countDict = new Dictionary<int, int>();
            //第二个哈希表存储数组中的每个数字作为结尾的子序列的数量
            Dictionary<int, int> endDict = new Dictionary<int, int>();

            //初始化第一个哈希表之后
            foreach (int x in nums)
            {
                if (!countDict.ContainsKey(x))
                    countDict.Add(x, 0);
                countDict[x] += 1;
            }

            //遍历数组，更新两个哈希表。
            foreach (int x in nums)
            {
                int count = GetOrDefault(countDict,x, 0);
                if (count > 0)
                {
                    int prevEndCount = GetOrDefault(endDict, x - 1, 0);
                    if (prevEndCount > 0) //存在x-1
                    {
                        countDict[x]= count - 1;                                 //x  数量-1
                        endDict[x - 1] = prevEndCount - 1;                       //x-1的尾部数量-1           
                        endDict[x] = GetOrDefault(endDict, x, 0) + 1;            //x  的尾部数量+1 
                    }
                    else
                    {
                        int count1 = GetOrDefault(countDict,x + 1, 0);           //x+1 数量
                        int count2 = GetOrDefault(countDict,x + 2, 0);           //x+2 数量
                        if (count1 > 0 && count2 > 0)                            //x+1/x+2 都存在，处理
                        {
                            countDict[x] = count - 1;                            //x    数量-1
                            countDict[x + 1] = count1 - 1;                       //x+1  数量-1 
                            countDict[x + 2] = count2 - 1;                       //x+2  数量-1
                            endDict[x + 2] = GetOrDefault(endDict, x + 2, 0) + 1;//x+2 的尾部数量+1 
                        }
                        else                                          //x+1/x+2 有不存在的，直接返回false
                        {
                            return false;
                        }
                    }
                }
            }
            return true;

        }

        int GetOrDefault(Dictionary<int,int> dict, int x, int defaultVal = 0)
        {
            if (dict.ContainsKey(x))
                return dict[x];
            else
            {
                dict.Add(x, defaultVal);
                return defaultVal;
            }
                
        }
    }
}
