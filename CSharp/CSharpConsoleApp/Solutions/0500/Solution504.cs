using System;
using System.Collections.Generic;
using System.Text;
namespace CSharpConsoleApp.Solutions
{
    /*
 * @lc app=leetcode.cn id=504 lang=csharp
 *
 * [504] 七进制数
 *
 * https://leetcode-cn.com/problems/base-7/description/
 *
 * algorithms
 * Easy (50.46%)
 * Likes:    91
 * Dislikes: 0
 * Total Accepted:    27.8K
 * Total Submissions: 55K
 * Testcase Example:  '100'
 *
 * 给定一个整数，将其转化为7进制，并以字符串形式输出。
 * 
 * 示例 1:
 * 
 * 
 * 输入: 100
 * 输出: "202"
 * 
 * 
 * 示例 2:
 * 
 * 
 * 输入: -7
 * 输出: "-10"
 * 
 * 
 * 注意: 输入范围是 [-1e7, 1e7] 。
 * 
 */

    // @lc code=start
    public class Solution504 : SolutionBase
    {
        
        /// <summary>
        /// 难度
        /// </summary>
        public override Difficulity GetDifficulity() { return Difficulity.Easy; }
        /// <summary>
        /// 关键字:
        /// </summary>
        public override string[] GetKeyWords() { return new string[] { "" }; }
        /// <summary>
        /// 标签：
        /// </summary>
        public override Tag[] GetTags() { return new Tag[] { Tag.BitManipulation }; }

        public override bool Test(System.Diagnostics.Stopwatch sw)
        {
            bool isSuccess = true;
            string result, checkResult;
            int num;

            num = 8;
            checkResult = "11";
            result = ConvertToBase7(num);
            isSuccess &= IsSame(result, checkResult);
            PrintResult(isSuccess, result, checkResult);

            num = 80;
            checkResult = "143";
            result = ConvertToBase7(num);
            isSuccess &= IsSame(result, checkResult);
            PrintResult(isSuccess, result, checkResult);

            num = -7;
            checkResult = "-10";
            result = ConvertToBase7(num);
            isSuccess &= IsSame(result, checkResult);
            PrintResult(isSuccess, result, checkResult);

            return isSuccess;
        }

        /// <summary>
        /// 241/241 cases passed (80 ms)
        /// Your runtime beats 90.63 % of csharp submissions
        /// Your memory usage beats 40.63 % of csharp submissions(22.9 MB)
        /// </summary>
        /// <param name="num"></param>
        /// <returns></returns>
        public string ConvertToBase7(int num) {
            StringBuilder sb = new StringBuilder();
            bool isMinus = num < 0;
            int left = Math.Abs(num);
            while(left >= 7)
            {
                sb.Insert(0, left % 7);
                left /= 7;
            }
            sb.Insert(0, left);

            if (isMinus)
                sb.Insert(0, '-');
            return sb.ToString();
        }
    }
    // @lc code=end
}
