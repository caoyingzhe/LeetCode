using System;
using System.Collections.Generic;
namespace CSharpConsoleApp.Solutions
{
    /*
     * @lc app=leetcode.cn id=119 lang=csharp
     *
     * [119] 杨辉三角 II
     *
     * https://leetcode-cn.com/problems/pascals-triangle-ii/description/
     *
     * Category	Difficulty	Likes	Dislikes
     * algorithms	Easy (65.38%)	293	-
     * Tags
     * array
     * 
     * Companies
     * amazon
     * 
     * Total Accepted:    117.8K
     * Total Submissions: 180.1K
     * Testcase Example:  '3'
     *
     * 给定一个非负索引 k，其中 k ≤ 33，返回杨辉三角的第 k 行。
     * 在杨辉三角中，每个数是它左上方和右上方的数的和。
     * 
     * 示例:
     * 输入: 3
     * 输出: [1,3,3,1]
     * 
     * 进阶：
     * 你可以优化你的算法到 O(k) 空间复杂度吗？
     * 
     */
    public class Solution119 : SolutionBase
    {
        /// <summary>
        /// 难度
        /// </summary>
        public override Difficulity GetDifficulity() { return Difficulity.Easy; }
        /// <summary>
        /// 关键字:
        /// </summary>
        public override string[] GetKeyWords() { return new string[] { }; }
        /// <summary>
        /// 标签：
        /// </summary>
        public override Tag[] GetTags() { return new Tag[] { Tag.Array }; }

        public override bool Test(System.Diagnostics.Stopwatch sw)
        {
            bool isSuccess = true;
            int n; IList<int> result, checkResult;

            n = 3;
            checkResult = new int[] { 1,3,3,1};
            result = GetRow(n);
            isSuccess &= IsListSame(result, checkResult);

            n = 5;
            checkResult = new int[] { 1, 5, 10, 10, 5, 1 };
            result = GetRow(n);
            isSuccess &= IsListSame(result, checkResult);
            Print("isSuccess = {0} | result = {1} | anticipated = {2}", isSuccess, GetArrayStr(result), GetArrayStr(checkResult));

            return isSuccess;
        }

        /// <summary>
        /// 34/34 cases passed (240 ms)
        /// Your runtime beats 52.33 % of csharp submissions
        /// Your memory usage beats 67.44 % of csharp submissions(25.6 MB)
        /// </summary>
        /// <param name="rowIndex"></param>
        /// <returns></returns>
        public IList<int> GetRow(int rowIndex)
        {
            return GenerateRow(rowIndex + 1);
        }
        public List<int> GenerateRow(int numRows)
        {
            if (numRows == 1)
                return new List<int>(new int[] { 1 });

            List<int> listPre = GenerateRow(numRows - 1);
            List<int> list = new List<int>();
            for (int j = 0; j <= numRows - 1; j++)
            {
                if (j == 0 || j == numRows - 1)
                    list.Add(1);
                else if (numRows > 1)
                    list.Add(listPre[j - 1] + listPre[j]);
            }
            return list;
        }
    }
}
