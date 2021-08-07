using System;
using System.Collections.Generic;
namespace CSharpConsoleApp.Solutions
{
    /*
 * @lc app=leetcode.cn id=539 lang=csharp
 *
 * [539] 最小时间差
 *
 * https://leetcode-cn.com/problems/minimum-time-difference/description/
 *
 * Category	Difficulty	Likes	Dislikes
 * algorithms	Medium (59.01%)	93	-
 * Tags
 * string
 * 
 * Companies
 * Unknown
 * Total Accepted:    12.8K
 * Total Submissions: 21.6K
 * Testcase Example:  '["23:59","00:00"]'
 *
 * 给定一个 24 小时制（小时:分钟 "HH:MM"）的时间列表，找出列表中任意两个时间的最小时间差并以分钟数表示。
 * 
 * 
 * 示例 1：
 * 输入：timePoints = ["23:59","00:00"]
 * 输出：1
 * 
 * 
 * 示例 2：
 * 输入：timePoints = ["00:00","23:59","00:00"]
 * 输出：0
 * 
 * 
 * 提示：
 * 2 <= timePoints <= 2 * 104
 * timePoints[i] 格式为 "HH:MM"
 */

    // @lc code=start
    public class Solution539 : SolutionBase
    {
        /// <summary>
        /// 难度
        /// </summary>
        public override Difficulity GetDifficulity() { return Difficulity.Easy; }
        /// <summary>
        /// 关键字:
        /// </summary>
        public override string[] GetKeyWords() { return new string[] { "抄作业" }; }
        /// <summary>
        /// 标签：
        /// </summary>
        public override Tag[] GetTags() { return new Tag[] { Tag.String }; }

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

        //作者：ffreturn
        //链接：https://leetcode-cn.com/problems/minimum-time-difference/solution/539-cjian-dan-yi-dong-zhuan-huan-pai-xu-pwuib/
        /// <summary>
        /// 113/113 cases passed (96 ms)
        /// Your runtime beats 100 % of csharp submissions
        /// Your memory usage beats 100 % of csharp submissions(25.7 MB)
        /// </summary>
        /// <param name="timePoints"></param>
        /// <returns></returns>
        public int FindMinDifference(IList<string> timePoints)
        {
            int n = timePoints.Count;
            int[] times = new int[n];
            for (int i = 0; i < n; ++i)
            {
                // times[i] = stoi(timePoints[i].substr(0,2))*60 + stoi(timePoints[i].substr(3,2));
                times[i] = ((timePoints[i][0] - '0') * 10 + (timePoints[i][1] - '0')) * 60 +
                        (timePoints[i][3] - '0') * 10 + (timePoints[i][4] - '0');
            }
            Array.Sort(times); //sort(times, times + n);
            int res = int.MaxValue;
            for (int i = 0; i < n - 1; ++i)
            {
                res = Math.Min(res, times[i + 1] - times[i]);
            }
            // 最后一个还要和第一个比较
            res = Math.Min(res, 24 * 60 + times[0] - times[n - 1]);
            return res;
        }
    }
    // @lc code=end



}
