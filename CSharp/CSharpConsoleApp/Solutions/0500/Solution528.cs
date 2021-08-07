using System;
using System.Collections.Generic;
namespace CSharpConsoleApp.Solutions
{
    /*
     * @lc app=leetcode.cn id=528 lang=csharp
     *
     * [528] 按权重随机选择
     *
     * https://leetcode-cn.com/problems/random-pick-with-weight/description/
     *
     * algorithms
     * Medium (46.69%)
     * Likes:    104
     * Dislikes: 0
     * Total Accepted:    8.8K
     * Total Submissions: 18.8K
     * Testcase Example:  '["Solution","pickIndex"]\r\n[[[1]],[]]\r'
     *
     * 给定一个正整数数组 w ，其中 w[i] 代表下标 i 的权重（下标从 0 开始），请写一个函数 pickIndex ，它可以随机地获取下标
     * i，选取下标 i 的概率与 w[i] 成正比。
     * 
     * 
     * 
     * 
     * 例如，对于 w = [1, 3]，挑选下标 0 的概率为 1 / (1 + 3) = 0.25 （即，25%），而选取下标 1 的概率为 3 / (1
     * + 3) = 0.75（即，75%）。
     * 
     * 也就是说，选取下标 i 的概率为 w[i] / sum(w) 。
     * 
     * 
     * 
     * 示例 1：
     * 
     * 输入：
     * ["Solution","pickIndex"]
     * [[[1]],[]]
     * 输出：
     * [null,0]
     * 解释：
     * Solution solution = new Solution([1]);
     * solution.pickIndex(); // 返回 0，因为数组中只有一个元素，所以唯一的选择是返回下标 0。
     * 
     * 示例 2：
     * 
     * 输入：
     * ["Solution","pickIndex","pickIndex","pickIndex","pickIndex","pickIndex"]
     * [[[1,3]],[],[],[],[],[]]
     * 输出：
     * [null,1,1,1,1,0]
     * 解释：
     * Solution solution = new Solution([1, 3]);
     * solution.pickIndex(); // 返回 1，返回下标 1，返回该下标概率为 3/4 。
     * solution.pickIndex(); // 返回 1
     * solution.pickIndex(); // 返回 1
     * solution.pickIndex(); // 返回 1
     * solution.pickIndex(); // 返回 0，返回下标 0，返回该下标概率为 1/4 。
     * 
     * 由于这是一个随机问题，允许多个答案，因此下列输出都可以被认为是正确的:
     * [null,1,1,1,1,0]
     * [null,1,1,1,1,1]
     * [null,1,1,1,0,0]
     * [null,1,1,1,0,1]
     * [null,1,0,1,0,0]
     * ......
     * 诸若此类。
     * 
     * 
     * 
     * 
     * 提示：
     * 
     * 
     * 1 <= w.length <= 10000
     * 1 <= w[i] <= 10^5
     * pickIndex 将被调用不超过 10000 次
     * 
     * 
     */

    // @lc code=start
    public class Solution528 : SolutionBase
    {
        /// <summary>
        /// 难度
        /// </summary>
        public override Difficulity GetDifficulity() { return Difficulity.Medium; }
        /// <summary>
        /// 关键字:
        /// </summary>
        public override string[] GetKeyWords() { return new string[] { "随机函数", "权重", "抄作业" }; }
        /// <summary>
        /// 标签：
        /// </summary>
        public override Tag[] GetTags() { return new Tag[] { Tag.Design }; }

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

        /// <summary>
        /// 57/57 cases passed (200 ms)
        /// Your runtime beats 100 % of csharp submissions
        /// Your memory usage beats 75 % of csharp submissions(46.7 MB)
        /// </summary>
        public class Solution
        {
            List<int> psum = new List<int>();
            int tot = 0;
            Random rand = new Random();

            public Solution(int[] w)
            {
                //预处理前缀和
                foreach (int x in w)
                {
                    tot += x;
                    psum.Add(tot);
                }
            }

            public int PickIndex()
            {
                int targ = rand.Next(tot);

                //二分法查找小于随机数的最小前缀和索引
                int lo = 0;
                int hi = psum.Count - 1;
                while (lo != hi)
                {
                    int mid = (lo + hi) / 2;
                    if (targ >= psum[mid]) lo = mid + 1;
                    else hi = mid;
                }
                return lo;
            }

            //作者：LeetCode
            //链接：https://leetcode-cn.com/problems/random-pick-with-weight/solution/an-quan-zhong-sui-ji-xuan-ze-by-leetcode/

        }
    }

    /**
     * Your Solution object will be instantiated and called as such:
     * Solution obj = new Solution(w);
     * int param_1 = obj.PickIndex();
     */
    // @lc code=end


}
