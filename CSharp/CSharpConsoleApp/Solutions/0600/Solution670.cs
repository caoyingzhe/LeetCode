using System;
using System.Collections.Generic;
namespace CSharpConsoleApp.Solutions
{
    /*
 * @lc app=leetcode.cn id=670 lang=csharp
 *
 * [670] 最大交换
 *
 * https://leetcode-cn.com/problems/maximum-swap/description/
 *
 * Category	Difficulty	Likes	Dislikes
 * algorithms	Medium (44.39%)	182	-
 * Tags
 * array | math
 * 
 * Companies
 * facebook
 * 
 * Total Accepted:    16.2K
 * Total Submissions: 36.4K
 * Testcase Example:  '2736'
 *
 * 给定一个非负整数，你至多可以交换一次数字中的任意两位。返回你能得到的最大值。
 * 
 * 示例 1 :
 * 输入: 2736
 * 输出: 7236
 * 解释: 交换数字2和数字7。
 * 
 * 
 * 示例 2 :
 * 输入: 9973
 * 输出: 9973
 * 解释: 不需要交换。
 * 
 * 
 * 注意:
 * 给定数字的范围是 [0, 10^8]
 */

    // @lc code=start
    public class Solution670 : SolutionBase
    {
        /// <summary>
        /// 难度
        /// </summary>
        public override Difficulity GetDifficulity() { return Difficulity.Medium; }
        /// <summary>
        /// 关键字:
        /// </summary>
        public override string[] GetKeyWords() { return new string[] {  }; }
        /// <summary>
        /// 标签：
        /// </summary>
        public override Tag[] GetTags() { return new Tag[] { Tag.Array, Tag.Math }; }

        public override bool Test(System.Diagnostics.Stopwatch sw)
        {
            bool isSuccess = true;
            int num;
            int result, checkResult;

            num = 2736;
            checkResult = 7236;
            result = MaximumSwap(num);
            isSuccess &= IsSame(result, checkResult);
            PrintResult(isSuccess, result, checkResult);

            num = 9973;
            checkResult = 9973;
            result = MaximumSwap(num);
            isSuccess &= IsSame(result, checkResult);
            PrintResult(isSuccess, result, checkResult);

            num = 2;
            checkResult = 2;
            result = MaximumSwap(num);
            isSuccess &= IsSame(result, checkResult);
            PrintResult(isSuccess, result, checkResult);

            //special
            num = 1993;
            checkResult = 9913;
            result = MaximumSwap(num);
            isSuccess &= IsSame(result, checkResult);
            PrintResult(isSuccess, result, checkResult);

            num = 29;
            checkResult = 92;
            result = MaximumSwap(num);
            isSuccess &= IsSame(result, checkResult);
            PrintResult(isSuccess, result, checkResult);

            num = 20;
            checkResult = 20;
            result = MaximumSwap(num);
            isSuccess &= IsSame(result, checkResult);
            PrintResult(isSuccess, result, checkResult);

            num = 10909091;  // 96/111 cases passed (N/A) Answer : 90909011 /  NG: 90901091
            checkResult = 90909011;
            result = MaximumSwap(num);
            isSuccess &= IsSame(result, checkResult);
            PrintResult(isSuccess, result, checkResult);

            return isSuccess;
        }

        /// <summary>
        /// TODO
        /// Wrong Answer
        /// 96/111 cases passed (N/A) Answer : 90909011 /  NG: 90901091
        /// </summary>
        /// <param name="num"></param>
        /// <returns></returns>
        public int MaximumSwap_NG(int num)
        {
            char[] arr = num.ToString().ToCharArray();

            List<char> list = new List<char>(arr);
            list.Sort((a, b) => b - a);

            int n = list.Count;
            for(int i=0; i< n; i++)
            {
                if (list[i] == arr[i]) continue;

                for(int j=i+1; j< n; j++)
                {
                    if(arr[j] > list[j] &&  arr[j] == list[i])
                    {
                        arr[j] = arr[i];
                        arr[i] = list[i];
                        return int.Parse(string.Join("", arr));
                    }
                }
            }
            return num;
        }

        //作者：LeetCode
        //链接：https://leetcode-cn.com/problems/maximum-swap/solution/zui-da-jiao-huan-by-leetcode/

        /// <summary>
        /// 111/111 cases passed (32 ms)
        /// Your runtime beats 100 % of csharp submissions
        /// Your memory usage beats 71.43 % of csharp submissions(14.8 MB)
        /// </summary>
        /// <param name="num"></param>
        /// <returns></returns>
        public int MaximumSwap(int num)
        {
            String s = num.ToString();
            int len = s.Length;
            char[] charArray = s.ToCharArray();

            // 记录每个数字出现的最后一次出现的下标
            int[] last = new int[10];
            for (int i = 0; i < len; i++)
            {
                last[charArray[i] - '0'] = i;
            }

            // 从左向右扫描，找到当前位置右边的最大的数字并交换
            for (int i = 0; i < len - 1; i++)
            {
                // 找最大，所以倒着找
                for (int d = 9; d > charArray[i] - '0'; d--)
                {
                    if (last[d] > i)
                    {
                        Swap(charArray, i, last[d]);
                        // 只允许交换一次，因此直接返回
                        return int.Parse(new String(charArray));
                    }
                }
            }
            return num;
        }

        private void Swap(char[] charArray, int index1, int index2)
        {
            char temp = charArray[index1];
            charArray[index1] = charArray[index2];
            charArray[index2] = temp;
        }
    }
    // @lc code=end


}
