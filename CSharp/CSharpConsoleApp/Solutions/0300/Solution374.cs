using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpConsoleApp.Solutions._0300
{
    /*
     * @lc app=leetcode.cn id=374 lang=csharp
     *
     * [374] 猜数字大小
     *
     * https://leetcode-cn.com/problems/guess-number-higher-or-lower/description/
     *
     * algorithms
     * Easy (47.74%)
     * Likes:    117
     * Dislikes: 0
     * Total Accepted:    49.2K
     * Total Submissions: 103.1K
     * Testcase Example:  '10\n6'
     *
     * 猜数字游戏的规则如下：
     * 
     * 
     * 每轮游戏，我都会从 1 到 n 随机选择一个数字。 请你猜选出的是哪个数字。
     * 如果你猜错了，我会告诉你，你猜测的数字比我选出的数字是大了还是小了。
     * 
     * 
     * 你可以通过调用一个预先定义好的接口 int guess(int num) 来获取猜测结果，返回值一共有 3 种可能的情况（-1，1 或
     * 0）：
     * 
     * -1：我选出的数字比你猜的数字小 pick < num
     * 1：我选出的数字比你猜的数字大 pick > num
     * 0：我选出的数字和你猜的数字一样。恭喜！你猜对了！pick == num
     * 
     * 返回我选出的数字。
     * 
     * 示例 1：
     * 输入：n = 10, pick = 6
     * 输出：6
     * 
     * 示例 2：
     * 输入：n = 1, pick = 1
     * 输出：1
     * 
     * 示例 3：
     * 输入：n = 2, pick = 1
     * 输出：1
     * 
     * 示例 4：
     * 输入：n = 2, pick = 2
     * 输出：2
     * 
     * 提示：
     * 1 <= n <= 231 - 1
     * 1 <= pick <= n
     * 
     */

    // @lc code=start
    /** 
     * Forward declaration of guess API.
     * @param  num   your guess
     * @return 	     -1 if num is lower than the guess number
     *			      1 if num is higher than the guess number
     *               otherwise return 0
     * int guess(int num);
     */
    class Solution374 : SolutionBase
    {
        /// <summary>
        /// 难度
        /// </summary>
        public override Difficulity GetDifficulity() { return Difficulity.Easy; }
        /// <summary>
        /// 关键字:
        /// </summary>
        public override string[] GetKeyWords() { return new string[] { "不易写测试用例" }; }
        /// <summary>
        /// 标签：
        /// </summary>
        public override Tag[] GetTags() { return new Tag[] { Tag.BinarySearch }; }

        //TODO
        public override bool Test(System.Diagnostics.Stopwatch sw)
        {
            return false;
        }

        /// <summary>
        /// 不知为何，速度极差，内存倒是极佳，
        /// 25/25 cases passed (56 ms)
        /// Your runtime beats 11.11 % of csharp submissions
        /// Your memory usage beats 95.24 % of csharp submissions(14.6 MB)
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public int GuessNumber(int n)
        {
            int l = 1;
            int r = n;
            while (l <= r)
            {
                int mid = l + (r - l) / 2;
                int gRtn = guess(mid);
                if (gRtn == 1)
                {
                    l = mid + 1;  //千万不能写成 : l = mid - 1;
                }
                else if (gRtn == -1)
                {
                    r = mid - 1;  //千万不能写成 : r = mid + 1;
                }
                else // if(gRtn == 1)
                {
                    return mid;
                }
            }
            return -1;
        }

        int pick = 100;
        public int guess(int num)
        {
            return num == pick ? 0 : (pick > num ? -1 : 1);
        }
    }
    
}
