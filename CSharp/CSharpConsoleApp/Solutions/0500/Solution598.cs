using System;
namespace CSharpConsoleApp.Solutions
{
    /*
     * @lc app=leetcode.cn id=598 lang=csharp
     *
     * [598] 范围求和 II
     *
     * https://leetcode-cn.com/problems/range-addition-ii/description/
     *
     * algorithms
     * Easy (51.55%)
     * Likes:    68
     * Dislikes: 0
     * Total Accepted:    14.8K
     * Total Submissions: 28.7K
     * Testcase Example:  '3\n3\n[[2,2],[3,3]]'
     *
     * 给定一个初始元素全部为 0，大小为 m*n 的矩阵 M 以及在 M 上的一系列更新操作。
     * 
     * 操作用二维数组表示，其中的每个操作用一个含有两个正整数 a 和 b 的数组表示，含义是将所有符合 0 <= i < a 以及 0 <= j < b
     * 的元素 M[i][j] 的值都增加 1。
     * 
     * 在执行给定的一系列操作后，你需要返回矩阵中含有最大整数的元素个数。
     * 
     * 示例 1:
     * 输入: 
     * m = 3, n = 3
     * operations = [[2,2],[3,3]]
     * 输出: 4
     * 解释: 
     * 初始状态, M = 
     * [[0, 0, 0],
     * ⁠[0, 0, 0],
     * ⁠[0, 0, 0]]
     * 
     * 执行完操作 [2,2] 后, M = 
     * [[1, 1, 0],
     * ⁠[1, 1, 0],
     * ⁠[0, 0, 0]]
     * 
     * 执行完操作 [3,3] 后, M = 
     * [[2, 2, 1],
     * ⁠[2, 2, 1],
     * ⁠[1, 1, 1]]
     * 
     * M 中最大的整数是 2, 而且 M 中有4个值为2的元素。因此返回 4。
     * 
     * 
     * 注意:
     * m 和 n 的范围是 [1,40000]。
     * a 的范围是 [1,m]，b 的范围是 [1,n]。
     * 操作数目不超过 10000。
     * 
     * 
     */

    // @lc code=start
    public class Solution598 : SolutionBase
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

        /// <summary>
        /// </summary>
        /// <param name="sw"></param>
        /// <returns></returns>
        public override bool Test(System.Diagnostics.Stopwatch sw)
        {
            bool isSuccess = true;
            int m, n; int[][] nums;
            int result, checkResult;

            m = 3; n = 3;
            nums = new int[][] {
                new int[] { 2,2 },
                new int[] { 3,3 }
            };
            checkResult = 4;
            result = MaxCount(m, n, nums);
            isSuccess &= IsSame(result, checkResult);
            PrintResult(isSuccess, result, checkResult);

            return isSuccess;
        }

        //作者：LeetCode
        //链接：https://leetcode-cn.com/problems/range-addition-ii/solution/fan-wei-qiu-he-ii-by-leetcode/
        /// <summary>
        /// 69/69 cases passed (104 ms)
        /// Your runtime beats 94.74 % of csharp submissions
        /// Your memory usage beats 31.58 % of csharp submissions(26.5 MB)
        /// </summary>
        /// <param name="m"></param>
        /// <param name="n"></param>
        /// <param name="ops"></param>
        /// <returns></returns>
        public int MaxCount(int m, int n, int[][] ops)
        {
            foreach(int[] op in ops)
            {
                m = Math.Min(m, op[0]);
                n = Math.Min(n, op[1]);
            }
            return m * n; //解法精妙
        }
    }
    // @lc code=end


}
