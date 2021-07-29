using System;
using System.Collections.Generic;
namespace CSharpConsoleApp.Solutions
{
    /*
 * @lc app=leetcode.cn id=216 lang=csharp
 *
 * [216] 组合总和 III
 *
 * https://leetcode-cn.com/problems/combination-sum-iii/description/
 *
 * Category	Difficulty	Likes	Dislikes
 * algorithms	Medium (74.01%)	321	-
 * Tags
 * array | backtracking
 * 
 * Companies
 * Unknown
 * 
 * Total Accepted:    85.6K
 * Total Submissions: 115.7K
 * Testcase Example:  '3\n7'
 *
 * 找出所有相加之和为 n 的 k 个数的组合。组合中只允许含有 1 - 9 的正整数，并且每种组合中不存在重复的数字。
 * 
 * 说明：
 * 所有数字都是正整数。
 * 解集不能包含重复的组合。 
 * 
 * 
 * 示例 1:
 * 输入: k = 3, n = 7
 * 输出: [[1,2,4]]
 * 
 * 
 * 示例 2:
 * 输入: k = 3, n = 9
 * 输出: [[1,2,6], [1,3,5], [2,3,4]]
 */

    // @lc code=start
    public class Solution216 : SolutionBase
    {
        /// <summary>
        /// 难度
        /// </summary>
        public override Difficulity GetDifficulity() { return Difficulity.Medium; }
        /// <summary>
        /// 关键字:
        /// </summary>
        public override string[] GetKeyWords() { return new string[] { "", }; }
        /// <summary>
        /// 标签：
        /// </summary>
        public override Tag[] GetTags() { return new Tag[] { Tag.Array, Tag.Backtracking }; }

        
        public override bool Test(System.Diagnostics.Stopwatch sw)
        {
            bool isSuccess = true;
            int k, n;
            IList<IList<int>> result, checkResult;

            k = 3; n = 7;
            checkResult = new int[][]
            {
                new int[] { 1, 2, 4 }
            };
            result = CombinationSum3(k, n);
            isSuccess &= IsArray2DSame(result, checkResult, true);
            PrintResult(isSuccess, GetArray2DStr(result), GetArray2DStr(checkResult));

            k = 3; n = 9;
            checkResult = new int[][]
            {
                new int[] { 1, 2, 6 },
                new int[] { 1, 3, 5 },
                new int[] { 2, 3, 4 }
            };
            result = CombinationSum3(k, n);
            isSuccess &= IsArray2DSame(result, checkResult, true);
            PrintResult(isSuccess, GetArray2DStr(result), GetArray2DStr(checkResult));

            return isSuccess;
        }

        //作者：LeetCode-Solution
        //链接：https://leetcode-cn.com/problems/combination-sum-iii/solution/zu-he-zong-he-iii-by-leetcode-solution/
        
        List<int> temp = new List<int>();
        IList<IList<int>> ans = new List<IList<int>>();

        /// <summary>
        /// 18/18 cases passed (196 ms)
        /// Your runtime beats 100 % of csharp submissions
        /// Your memory usage beats 89.58 % of csharp submissions(25.6 MB)
        /// </summary>
        public IList<IList<int>> CombinationSum3(int k, int n)
        {
            ans.Clear();
            for (int mask = 0; mask < (1 << 9); ++mask)
            {
                if (Check(mask, k, n))
                {
                    ans.Add(new List<int>(temp));
                }
            }
            return ans;
        }

        public bool Check(int mask, int k, int n)
        {
            temp.Clear();
            for (int i = 0; i < 9; ++i)
            {
                if (((1 << i) & mask) != 0)
                {
                    temp.Add(i + 1);
                }
            }
            if (temp.Count != k)
            {
                return false;
            }
            int sum = 0;
            foreach (int num in temp) sum += num;
            return sum == n;
        }
    }
    // @lc code=end


}
