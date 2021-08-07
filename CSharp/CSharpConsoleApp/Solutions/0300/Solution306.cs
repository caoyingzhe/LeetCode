using System;
namespace CSharpConsoleApp.Solutions
{
    /*
     * @lc app=leetcode.cn id=306 lang=csharp
     *
     * [306] 累加数
     *
     * https://leetcode-cn.com/problems/additive-number/description/
     *
     * Category	Difficulty	Likes	Dislikes
     * algorithms	Medium (33.54%)	168	-
     * Tags
     * backtracking
     * 
     * Companies
     * Unknown
     * 
     * Total Accepted:    15.2K
     * Total Submissions: 45.4K
     * Testcase Example:  '"112358"'
     *
     * 累加数是一个字符串，组成它的数字可以形成累加序列。
     * 
     * 一个有效的累加序列必须至少包含 3 个数。除了最开始的两个数以外，字符串中的其他数都等于它之前两个数相加的和。
     * 
     * 给定一个只包含数字 '0'-'9' 的字符串，编写一个算法来判断给定输入是否是累加数。
     * 
     * 说明: 累加序列里的数不会以 0 开头，所以不会出现 1, 2, 03 或者 1, 02, 3 的情况。
     * 
     * 示例 1:
     * 
     * 输入: "112358"
     * 输出: true 
     * 解释: 累加序列为: 1, 1, 2, 3, 5, 8 。1 + 1 = 2, 1 + 2 = 3, 2 + 3 = 5, 3 + 5 = 8
     * 
     * 
     * 示例 2:
     * 
     * 输入: "199100199"
     * 输出: true 
     * 解释: 累加序列为: 1, 99, 100, 199。1 + 99 = 100, 99 + 100 = 199
     * 
     * 进阶:
     * 你如何处理一个溢出的过大的整数输入?
     * 
     */

    // @lc code=start
    public class Solution306 : SolutionBase
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
        public override Tag[] GetTags() { return new Tag[] { Tag.Backtracking }; }


        public override bool Test(System.Diagnostics.Stopwatch sw)
        {
            bool isSuccess = true;
            string urlStr;
            bool result, checkResult;

            urlStr = "112358";
            checkResult = true;
            result = IsAdditiveNumber(urlStr);
            isSuccess &= IsSame(result, checkResult);
            PrintResult(isSuccess, (result).ToString(), (checkResult).ToString());

            urlStr = "199100199";
            checkResult = true;
            result = IsAdditiveNumber(urlStr);
            isSuccess &= IsSame(result, checkResult);
            PrintResult(isSuccess, (result).ToString(), (checkResult).ToString());

            return isSuccess;
        }

        //作者：geguanting
        //链接：https://leetcode-cn.com/problems/additive-number/solution/xian-que-ding-qian-liang-ge-shu-yun-xing-q6qu/
        /// <summary>
        /// 41/41 cases passed (76 ms)
        /// Your runtime beats 88.89 % of csharp submissions
        /// Your memory usage beats 11.11 % of csharp submissions(22.8 MB)
        /// </summary>
        /// <param name="num"></param>
        /// <returns></returns>
        public bool IsAdditiveNumber(string num)
        {
            int n = num.Length;
            char[] chs = num.ToCharArray();
            long v1 = 0;
            for (int i = 0; i < n - 2; i++)
            {
                if (i == 1 && chs[0] == '0')
                {
                    return false;
                }
                v1 = v1 * 10 + (chs[i] - '0');
                long v2 = 0;
                for (int j = i + 1; j < n - 1; j++)
                {
                    v2 = v2 * 10 + chs[j] - '0';
                    if (j > i + 1 && chs[i + 1] == '0')
                    {
                        break;
                    }
                    if (check(num, j + 1, v2, v1 + v2))
                    {
                        return true;
                    }
                }
            }
            return false;
        }
        public bool check(String num, int start, long pre, long cur)
        {
            for (int i = start; i < num.Length;)
            {
                String scur = cur.ToString();
                if (!num.Substring(i).StartsWith(scur))
                {
                    return false;
                }
                i += scur.Length;
                long t = pre + cur;
                pre = cur;
                cur = t;
            }
            return true;
        }


    }
    // @lc code=end


}
