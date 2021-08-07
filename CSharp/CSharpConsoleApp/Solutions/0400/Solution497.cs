using System;
using System.Collections.Generic;

namespace CSharpConsoleApp.Solutions
{
    /*
     * @lc app=leetcode.cn id=497 lang=csharp
     *
     * [497] 非重叠矩形中的随机点
     *
     * https://leetcode-cn.com/problems/random-point-in-non-overlapping-rectangles/description/
     *
     * Category	Difficulty	Likes	Dislikes
     * algorithms	Medium (40.30%)	37	-
     * Tags
     * Unknown
     * 
     * Companies
     * Unknown
     * 
     * Total Accepted:    2.7K
     * Total Submissions: 6.6K
     * Testcase Example:  '["Solution","pick","pick","pick","pick","pick"]\n' +
      '[[[[-2,-2,1,1],[2,2,4,6]]],[],[],[],[],[]]'
     *
     * 给定一个非重叠轴对齐矩形的列表 rects，写一个函数 pick 随机均匀地选取矩形覆盖的空间中的整数点。
     * 
     * 提示：
     * 整数点是具有整数坐标的点。
     * 矩形周边上的点包含在矩形覆盖的空间中。
     * 第 i 个矩形 rects [i] = [x1，y1，x2，y2]，其中 [x1，y1] 是左下角的整数坐标，[x2，y2]
     * 是右上角的整数坐标。
     * 每个矩形的长度和宽度不超过 2000。
     * 1 <= rects.length <= 100
     * pick 以整数坐标数组 [p_x, p_y] 的形式返回一个点。
     * pick 最多被调用10000次。
     * 
     * 
     * 示例 1：
     * 输入: 
     * ["Solution","pick","pick","pick"]
     * [[[[1,1,5,5]]],[],[],[]]
     * 输出: 
     * [null,[4,1],[4,1],[3,3]]
     * 
     * 
     * 示例 2：
     * 输入: 
     * ["Solution","pick","pick","pick","pick","pick"]
     * [[[[-2,-2,-1,-1],[1,0,3,0]]],[],[],[],[],[]]
     * 输出: 
     * [null,[-1,-2],[2,0],[-2,-1],[3,0],[-2,-2]]
     * 
     * 
     * 输入语法的说明：
     * 输入是两个列表：调用的子例程及其参数。Solution 的构造函数有一个参数，即矩形数组 rects。pick
     * 没有参数。参数总是用列表包装的，即使没有也是如此。
     */

    // @lc code=start
    public class Solution497 : SolutionBase
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
        //作者：LeetCode
        //链接：https://leetcode-cn.com/problems/random-point-in-non-overlapping-rectangles/solution/fei-zhong-die-ju-xing-zhong-de-sui-ji-dian-by-leet/

        /// <summary>
        /// 35/35 cases passed (320 ms)
        /// Your runtime beats 100 % of csharp submissions
        /// Your memory usage beats 100 % of csharp submissions(46 MB)
        /// </summary>
        public class Solution
        {
            int[][] rects;
            List<int> psum = new List<int>();
            int tot = 0;
            Random rand = new Random();

            public Solution(int[][] rects)
            {
                this.rects = rects;
                foreach (int[] x in rects)
                {
                    tot += (x[2] - x[0] + 1) * (x[3] - x[1] + 1);
                    psum.Add(tot);
                }
            }

            public int[] Pick()
            {
                int targ = rand.Next(tot);

                int lo = 0;
                int hi = rects.Length - 1;
                while (lo != hi)
                {
                    int mid = (lo + hi) / 2;
                    if (targ >= psum[mid]) lo = mid + 1;
                    else hi = mid;
                }

                int[] x = rects[lo];
                int width = x[2] - x[0] + 1;
                int height = x[3] - x[1] + 1;
                int baseN = psum[lo] - width * height;
                return new int[] { x[0] + (targ - baseN) % width, x[1] + (targ - baseN) / width };
            }
        }
    }

    /**
     * Your Solution object will be instantiated and called as such:
     * Solution obj = new Solution(rects);
     * int[] param_1 = obj.Pick();
     */
    // @lc code=end


}
