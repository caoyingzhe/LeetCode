using System;
using System.Collections.Generic;
namespace CSharpConsoleApp.Solutions
{
    /*
     * @lc app=leetcode.cn id=519 lang=csharp
     *
     * [519] 随机翻转矩阵
     *
     * https://leetcode-cn.com/problems/random-flip-matrix/description/
     *
     * algorithms
     * Medium (39.40%)
     * Likes:    36
     * Dislikes: 0
     * Total Accepted:    2.4K
     * Total Submissions: 6.2K
     * Testcase Example:  '["Solution","flip","flip","flip","reset","flip"]\n[[3,1],[],[],[],[],[]]'
     *
     * 题中给出一个 n_rows 行 n_cols 列的二维矩阵，且所有值被初始化为 0。要求编写一个 flip 函数，均匀随机的将矩阵中的 0 变为
     * 1，并返回该值的位置下标 [row_id,col_id]；同样编写一个 reset 函数，将所有的值都重新置为 0。尽量最少调用随机函数
     * Math.random()，并且优化时间和空间复杂度。
     * 
     * 注意:
     * 1 <= n_rows, n_cols <= 10000
     * 0 <= row.id < n_rows 并且 0 <= col.id < n_cols
     * 当矩阵中没有值为 0 时，不可以调用 flip 函数
     * 调用 flip 和 reset 函数的次数加起来不会超过 1000 次
     * 
     * 
     * 示例 1：
     * 输入: 
     * ["Solution","flip","flip","flip","flip"]
     * [[2,3],[],[],[],[]]
     * 输出: [null,[0,1],[1,2],[1,0],[1,1]]
     * 
     * 
     * 示例 2：
     * 输入: 
     * ["Solution","flip","flip","reset","flip"]
     * [[1,2],[],[],[],[]]
     * 输出: [null,[0,0],[0,1],null,[0,0]]
     * 
     * 输入语法解释：
     * 输入包含两个列表：被调用的子程序和他们的参数。Solution 的构造函数有两个参数，分别为 n_rows 和 n_cols。flip 和 reset
     * 没有参数，参数总会以列表形式给出，哪怕该列表为空
     */

    // @lc code=start
    public class Solution519 : SolutionBase
    {
        /// <summary>
        /// 难度
        /// </summary>
        public override Difficulity GetDifficulity() { return Difficulity.Medium; }
        /// <summary>
        /// 关键字:
        /// </summary>
        public override string[] GetKeyWords() { return new string[] { "随机函数", "抄作业" }; }
        /// <summary>
        /// 标签：
        /// </summary>
        public override Tag[] GetTags() { return new Tag[] { Tag.Unknown }; }

        /// <summary>
        /// </summary>
        /// <param name="sw"></param>
        /// <returns></returns>
        public override bool Test(System.Diagnostics.Stopwatch sw)
        {
            bool isSuccess = true;
            //TODO
            return isSuccess;
        }

        //作者：LeetCode
        //链接：https://leetcode-cn.com/problems/random-flip-matrix/solution/sui-ji-fan-zhuan-ju-zhen-by-leetcode/

        /// <summary>
        /// 20/20 cases passed (244 ms)
        ///Your runtime beats 100 % of csharp submissions
        ///Your memory usage beats 100 % of csharp submissions(34 MB)
        /// </summary>
        public class Solution {

            Dictionary<int,int > V = new Dictionary<int, int>();
            int nr, nc, rem;
            Random rand = new Random();

            public Solution(int n_rows, int n_cols)
            {
                nr = n_rows;
                nc = n_cols;
                rem = nr * nc;
            }

            public int[] flip()
            {
                int r = rand.Next(rem--);

                //int x = V.getOrDefault(r, r);
                int x = GetOrDefault(V, r, r);

                //V.put(r, V.getOrDefault(rem, rem));
                int y = GetOrDefault(V, rem, rem);

                if (V.ContainsKey(r))
                    V[r] = y;
                else
                    V.Add(r, y);
                return new int[] { x / nc, x % nc };
            }

            public void reset()
            {
                V.Clear();
                rem = nr * nc;
            }

            public int GetOrDefault<T>(Dictionary<T, int> dict, T x, int defaultVal = 0)
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

    /**
     * Your Solution object will be instantiated and called as such:
     * Solution obj = new Solution(m, n);
     * int[] param_1 = obj.Flip();
     * obj.Reset();
     */
    // @lc code=end


}
