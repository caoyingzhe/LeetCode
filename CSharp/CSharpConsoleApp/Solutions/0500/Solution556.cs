using System;
using System.Collections.Generic;
namespace CSharpConsoleApp.Solutions
{
    /*
 * @lc app=leetcode.cn id=556 lang=csharp
 *
 * [556] 下一个更大元素 III
 *
 * https://leetcode-cn.com/problems/next-greater-element-iii/description/
 *
 * Category	Difficulty	Likes	Dislikes
 * algorithms	Medium (32.13%)	149	-
 * Tags
 * string
 * 
 * Companies
 * bloomberg
 * 
 * Total Accepted:    12.5K
 * Total Submissions: 38.8K
 * Testcase Example:  '12'
 *
 * 给你一个正整数 n ，请你找出符合条件的最小整数，其由重新排列 n 中存在的每位数字组成，并且其值大于 n 。如果不存在这样的正整数，则返回 -1 。
 * 注意 ，返回的整数应当是一个 32 位整数 ，如果存在满足题意的答案，但不是 32 位整数 ，同样返回 -1 。
 * 
 * 
 * 示例 1：
 * 输入：n = 12
 * 输出：21
 * 
 * 
 * 示例 2：
 * 输入：n = 21
 * 输出：-1
 * 
 * 
 * 提示：
 * 1 <= n <= 231 - 1
 */

    // @lc code=start
    public class Solution556 : SolutionBase
    {
        /// <summary>
        /// 难度
        /// </summary>
        public override Difficulity GetDifficulity() { return Difficulity.Medium; }
        /// <summary>
        /// 关键字:
        /// </summary>
        public override string[] GetKeyWords() { return new string[] { }; }
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

            int n = 158476531;
            int result, checkResult;

            n = 158476531;
            checkResult = 158513467;
            result = NextGreaterElement(n);
            isSuccess &= IsSame(result, checkResult);
            PrintResult(isSuccess, (result), (checkResult));

            n = 21;
            checkResult = -1;
            result = NextGreaterElement(n);
            isSuccess &= IsSame(result, checkResult);
            PrintResult(isSuccess, (result), (checkResult));


            return isSuccess;
        }

        /// <summary>
        /// 作者：LeetCode
        /// 链接：https://leetcode-cn.com/problems/next-greater-element-iii/solution/xia-yi-ge-geng-da-yuan-su-iii-by-leetcode/
        /// 1. 任意降序的序列，不会有更大的排列出现。
        /// 2. 从末端至最高位顺序，寻找非逐次变大的数，然后同样顺序 寻找最接近该数，交换该数后，翻转区间数字即可。
        /// 例： 158【4】76【5】31
        ///     2.1 从末端至最高位顺序，寻找非逐次变大的数 [4]
        ///     2.2 正向（向个位）寻找最接近该数 [5]
        ///     2.3 交换该数后   158【5】76【4】31
        ///     2.4 翻转区间数字 158【5】13【4】67
        ///
        /// 39/39 cases passed (36 ms)
        /// Your runtime beats 100 % of csharp submissions
        /// Your memory usage beats 85.71 % of csharp submissions(14.9 MB)
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public int NextGreaterElement(int n)
        {
            char[] a = ("" + n).ToCharArray();
            int i = a.Length - 2;

            //2.1 从末端至最高位顺序，寻找非逐次变大的数 A
            while (i >= 0 && a[i + 1] <= a[i])  //a[i + 1] <= a[i] 代表：非逐次变大的数
            {
                i--;
            }
            if (i < 0)
                return -1;

            //2.2 寻找最接近该 A 的数 B
            int j = a.Length - 1;
            while (j >= 0 && a[j] <= a[i]) //a[j] <= a[i] 代表：寻找最接近该数
            {
                j--;
            }
            //交换A，B
            swap(a, i, j);
            //翻转原有 A（已经变为B）之后的位数。
            reverse(a, i + 1);
            try
            {
                return int.Parse(new String(a));
            }
            catch (Exception e)
            {
                return -1;
            }
        }
        private void reverse(char[] a, int start)
        {
            int i = start, j = a.Length - 1;
            while (i < j)
            {
                swap(a, i, j);
                i++;
                j--;
            }
        }

        private void swap(char[] a, int i, int j)
        {
            char temp = a[i];
            a[i] = a[j];
            a[j] = temp;
        }
    }
    // @lc code=end


}
