using System;
using System.Collections.Generic;
using System.Linq;
namespace CSharpConsoleApp.Solutions
{
    /*
     * @lc app=leetcode.cn id=40 lang=csharp
     *
     * [40] 组合总和 II
     *
     * https://leetcode-cn.com/problems/combination-sum-ii/description/
     *
     * Category	Difficulty	Likes	Dislikes
     * algorithms	Medium (63.63%)	578	-
     * Tags
     * array | backtracking
     * 
     * Companies
     * snapchat
     * 
     * Total Accepted:    157.8K
     * Total Submissions: 247.9K
     * Testcase Example:  '[10,1,2,7,6,1,5]\n8'
     *
     * 给定一个数组 candidates 和一个目标数 target ，找出 candidates 中所有可以使数字和为 target 的组合。
     * 
     * candidates 中的每个数字在每个组合中只能使用一次。
     * 
     * 说明：
     * 所有数字（包括目标数）都是正整数。
     * 解集不能包含重复的组合。 
     * 
     * 
     * 示例 1:
     * 输入: candidates = [10,1,2,7,6,1,5], target = 8,
     * 所求解集为:
     * [
     * ⁠ [1, 7],
     * ⁠ [1, 2, 5],
     * ⁠ [2, 6],
     * ⁠ [1, 1, 6]
     * ]
     * 
     * 
     * 示例 2:
     * 输入: candidates = [2,5,2,1,2], target = 5,
     * 所求解集为:
     * [
     * [1,2,2],
     * [5]
     * ]
     * 
     */
    public class Solution40 : SolutionBase
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

            //candidates = new int[] { 2, 3, 6, 7 };
            //target = 7;
            //result = CombinationSum2_TLE(candidates, target);
            //checkResult = new int[][] {
            //    new int[] { 7 }
            //};

            //isSuccess &= IsArraySame(result, checkResult);
            //Print("isSuccess = {0} result = {1} | checkResult = {2}", isSuccess, GetArray2DStr(result), GetArray2DStr(checkResult));


            candidates = new int[] { 10, 1, 2, 7, 6, 1, 5 };
            target = 8;
            result = CombinationSum2(candidates, target);
            checkResult = new int[][] {
                new int[] {1,1,6 },
                new int[] {1,2,5 },
                new int[] {1,7 },
                new int[] {2,6 }
            };
            
            isSuccess &= IsArray2DSame(result, checkResult, true);
            Print("isSuccess = {0} result = {1} | checkResult = {2}", isSuccess, GetArray2DStr(result), GetArray2DStr(checkResult));

            //此用例用 39的方法绝对超时。LTE
            candidates = new int[] { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 };
            target = 27;
            result = CombinationSum2(candidates, target);
            checkResult = new int[][] {
            };
            //checkResult = new int[][] {
            //    new int[] {1,1,1,1,1,1,1,1,1,1,1,1,1,1,1},
            //};

            isSuccess &= IsArray2DSame(result, checkResult, true);
            Print("isSuccess = {0} result = {1} | checkResult = {2}", isSuccess, GetArray2DStr(result), GetArray2DStr(checkResult));

            return isSuccess;
        }

        #region ---------------------- 递归 + 回溯算法 LTE -------------------------------
        //private HashSet<string> listSet = new HashSet<string>();
        //private List<IList<int>> res = new List<IList<int>>(); //所有答案

        ///// <summary>
        ///// 本算法就是一个标准的递归 + 回溯算法，但是它并不适用于本题。这是因为题目描述中规定了解集不能包含重复的组合，而上述的算法中并没有去除重复的组合。
        ///// </summary>
        ///// <param name="candidates"></param>
        ///// <param name="target"></param>
        ///// <returns></returns>
        //public IList<IList<int>> CombinationSum2_TLE(int[] candidates, int target)
        //{
        //    res.Clear();
        //    listSet.Clear();
        //    Array.Sort(candidates); //先排序，减少回溯次数。

        //    SortedList<int, int> path = new SortedList<int, int>(); //答案之一
        //    string pathStr = "";
        //    Backtrack(path, pathStr, candidates, target, 0, 0); //回溯， 其中最后两个参数0，0  代表当前总和=0， 当前答案的开始位置=0；
        //    return res;
        //}

        ///// <summary>
        ///// 170/170 cases passed (284 ms)
        ///// Your runtime beats 79.87 % of csharp submissions
        ///// Your memory usage beats 85.53 % of csharp submissions(31.5 MB)
        ///// </summary>
        ///// <param name="path"></param>
        ///// <param name="candidates"></param>
        ///// <param name="target"></param>
        ///// <param name="sum"></param>
        ///// <param name="begin"></param>
        //private void Backtrack(SortedList<int, int> path, string pathStr, int[] candidates, int target, int sum, int begin)
        //{
        //    if (sum == target)
        //    {
        //        //List<int> addPath = path.Values.ToList<int>();
        //        //string name = string.Join(",", addPath.ToArray());
        //        if(!listSet.Contains(pathStr))
        //        { 
        //            listSet.Add(pathStr);
        //            res.Add(path.Values.ToList()); //添加答案，必须用 new List<int> 复制当前答案。
        //        }
        //        else
        //        {
        //            //Print("Duplicate : " + pathStr);
        //        }
        //        return;
        //    }
        //    for (int i = begin; i < candidates.Length; i++)     //逐渐测试递增的数字，测试数字是否符合要求。
        //    {
        //        //if (i > 0 && candidates[i] == candidates[i - 1])
        //        //    continue;
        //        if (path.ContainsKey(i))
        //            continue;

        //        int rs = candidates[i] + sum;
        //        if (rs <= target)
        //        {
        //            path.Add(i, candidates[i]);                 //临时添加当前数字到答案中，不管答案是否正确。

        //            string pathStrPre = pathStr;
        //            pathStr += candidates[i];

        //            if (begin == 0)
        //            {
        //                begin = 0;
        //            }
        //            Backtrack(path, pathStr, candidates, target, rs, i+1); //回溯， 这里 rs是当前和，i代表刚添加的测试数字，对应的索引。
        //            path.Remove(i);                             //删除临时答案中的最后一个路径。准备测试下一个数字。
        //            pathStr = pathStrPre;
        //        }
        //        else
        //        {
        //            break; //当前不正确的情况，不用在测试后面的数字（因为已经排序过，数字会越来越大）
        //        }
        //    }
        //}
        #endregion

        #region  ------------------ 官方答案  Dfs+剪枝 ---------------------------

        List<int[]> freq = new List<int[]>();
        List<IList<int>> ans = new List<IList<int>>();
        List<int> sequence = new List<int>();

        /// <summary>
        /// 174/174 cases passed (280 ms)
        /// Your runtime beats 92.05 % of csharp submissions
        /// Your memory usage beats 70.45 % of csharp submissions(31 MB)
        /// 作者：LeetCode-Solution
        /// 链接：https://leetcode-cn.com/problems/combination-sum-ii/solution/zu-he-zong-he-ii-by-leetcode-solution/
        /// </summary>
        /// <param name="candidates"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        public IList<IList<int>> CombinationSum2(int[] candidates, int target)
        {
            freq.Clear();
            ans.Clear();
            sequence.Clear();

            Array.Sort(candidates);                                  //先排序
            foreach (int num in candidates)                          //统计相同数字的数量，保存到字典
            {
                int size = freq.Count;
                if (freq.Count == 0 || num != freq[size - 1][0])
                {
                    freq.Add(new int[] { num, 1 });  
                }
                else
                {
                    ++freq[size - 1][1];
                }
            }
            DFS(0, target);                                          //深度搜索
            return ans;
        }

        public void DFS(int pos, int rest)
        {
            if (rest == 0)
            {
                ans.Add(new List<int>(sequence));
                return;
            }
            if (pos == freq.Count || rest < freq[pos][0])
            {
                return;
            }

            DFS(pos + 1, rest);                                     //深度搜索 下一个位置，从第0个开始

            int most = Math.Min(rest / freq[pos][0], freq[pos][1]); //取出相同数字的数量n
            for (int i = 1; i <= most; ++i)
            {
                sequence.Add(freq[pos][0]);
                DFS(pos + 1, rest - i * freq[pos][0]);              //深度搜索 下一个位置 从第i个开始 i=[1～n-1]
            }
            for (int i = 1; i <= most; ++i)
            {
                sequence.RemoveAt(sequence.Count - 1);              //回溯
            }
        }
        #endregion
    }
}