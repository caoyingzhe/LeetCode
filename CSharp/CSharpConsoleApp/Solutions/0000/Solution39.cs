using System;
using System.Collections.Generic;

namespace CSharpConsoleApp.Solutions
{
    /*
     * @lc app=leetcode.cn id=39 lang=csharp
     *
     * [39] 组合总和
     *
     * https://leetcode-cn.com/problems/combination-sum/description/
     *
     * algorithms
     * Medium (72.40%)
     * Likes:    1343
     * Dislikes: 0
     * Total Accepted:    257.2K
     * Total Submissions: 355.2K
     * Testcase Example:  '[2,3,6,7]\n7'
     *
     * 给定一个无重复元素的数组 candidates 和一个目标数 target ，找出 candidates 中所有可以使数字和为 target 的组合。
     * 
     * candidates 中的数字可以无限制重复被选取。
     * 
     * 说明：
     * 所有数字（包括 target）都是正整数。
     * 解集不能包含重复的组合。 
     * 
     * 
     * 示例 1：
     * 输入：candidates = [2,3,6,7], target = 7,
     * 所求解集为：
     * [
     * ⁠ [7],
     * ⁠ [2,2,3]
     * ]
     * 
     * 
     * 示例 2：
     * 输入：candidates = [2,3,5], target = 8,
     * 所求解集为：
     * [
     *   [2,2,2,2],
     *   [2,3,3],
     *   [3,5]
     * ]
     * 
     * 
     * 提示：
     * 1 <= candidates.length <= 30
     * 1 <= candidates[i] <= 200
     * candidate 中的每个元素都是独一无二的。
     * 1 <= target <= 500
     * 
     * 
     */
    public class Solution39 : SolutionBase
    {
        /// <summary>
        /// 难易度:
        /// </summary>
        public override Difficulity GetDifficulity() { return Difficulity.Medium; }
        /// <summary>
        /// 关键字:
        /// </summary>
        public override string[] GetKeyWords() { return new string[] { "回溯" }; }
        /// <summary>
        /// 标签： 图
        /// </summary>
        public override Tag[] GetTags() { return new Tag[] { Tag.Backtracking, Tag.Array, }; }

        public override bool Test(System.Diagnostics.Stopwatch sw)
        {
            bool isSuccess = true;
            int[] candidates; int target;
            IList<IList<int>> result;
            int[][] checkResult;

            candidates = new int[] { 2, 3, 6, 7 };
            target = 7;
            result = CombinationSum(candidates, target);
            checkResult = new int[][] {
                new int[] { 2,2,3 },
                new int[] { 7 }
            };

            isSuccess &= IsArray2DSame(result, checkResult);
            Print("isSuccess = {0} result = {1} | checkResult = {2}", isSuccess, GetArray2DStr(result), GetArray2DStr(checkResult));

            return isSuccess;
        }

        private List<IList<int>> res = new List<IList<int>>(); //所有答案
        public IList<IList<int>> CombinationSum(int[] candidates, int target)
        {
            Array.Sort(candidates); //先排序，减少回溯次数。

            List<int> path = new List<int>(); //答案之一
            Backtrack(path, candidates, target, 0, 0); //回溯， 其中最后两个参数0，0  代表当前总和=0， 当前答案的开始位置=0；
            return res;
        }

        /// <summary>
        /// 170/170 cases passed (284 ms)
        /// Your runtime beats 79.87 % of csharp submissions
        /// Your memory usage beats 85.53 % of csharp submissions(31.5 MB)
        /// </summary>
        /// <param name="path"></param>
        /// <param name="candidates"></param>
        /// <param name="target"></param>
        /// <param name="sum"></param>
        /// <param name="begin"></param>
        private void Backtrack(List<int> path, int[] candidates, int target, int sum, int begin)
        {
            if (sum == target)
            {
                res.Add(new List<int>(path)); //添加答案，必须用 new List<int> 复制当前答案。
                return;
            }
            for (int i = begin; i < candidates.Length; i++)     //逐渐测试递增的数字，测试数字是否符合要求。
            {
                int rs = candidates[i] + sum;
                if (rs <= target)
                {
                    path.Add(candidates[i]);                    //临时添加当前数字到答案中，不管答案是否正确。
                    Backtrack(path, candidates, target, rs, i); //回溯， 这里 rs是当前和，i代表刚添加的测试数字，对应的索引。
                    path.RemoveAt(path.Count - 1);                //删除临时答案中的最后一个路径。准备测试下一个数字。
                }
                else
                {
                    break; //当前不正确的情况，不用在测试后面的数字（因为已经排序过，数字会越来越大）
                }
            }
        }
    }
}
