using System;
namespace CSharpConsoleApp.Solutions
{
    /*
 * @lc app=leetcode.cn id=171 lang=csharp
 *
 * [171] Excel表列序号
 *
 * https://leetcode-cn.com/problems/excel-sheet-column-number/description/
 *
 * algorithms
 * Easy (69.35%)
 * Likes:    227
 * Dislikes: 0
 * Total Accepted:    73.1K
 * Total Submissions: 105.3K
 * Testcase Example:  '"A"'
 *
 * 给定一个Excel表格中的列名称，返回其相应的列序号。
 * 
 * 例如，
 * 
 * ⁠   A -> 1
 * ⁠   B -> 2
 * ⁠   C -> 3
 * ⁠   ...
 * ⁠   Z -> 26
 * ⁠   AA -> 27
 * ⁠   AB -> 28 
 * ⁠   ...
 * 
 * 
 * 示例 1:
 * 
 * 输入: "A"
 * 输出: 1
 * 
 * 
 * 示例 2:
 * 
 * 输入: "AB"
 * 输出: 28
 * 
 * 
 * 示例 3:
 * 
 * 输入: "ZY"
 * 输出: 701
 * 
 * 致谢：
 * 特别感谢 @ts 添加此问题并创建所有测试用例。
 * 
 */

    // @lc code=start
    public class Solution171
    {
        /// <summary>
        /// 1002/1002 cases passed (84 ms)
        /// Your runtime beats 88.16 % of csharp submissions
        /// Your memory usage beats 71.05 % of csharp submissions(24.7 MB)
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public int TitleToNumber(string s)
        {
            int ans = 0;
            for (int i = 0; i < s.Length; i++)
            {
                int num = s[i] - 'A' + 1;
                ans = ans * 26 + num;
            }
            return ans;
        }

        public string ConvertToTitle(int columnNumber)
        {
            int n = columnNumber;
            string chart = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            string s = "";
            while (n > 0)
            {
                int a = (n - 1) % 26; //从1到26对应从0到25，所以我们在取余是要-1；
                char tem = chart[a];
                s = "" + tem + s;
                n = n - 1;              //进位是也是这个问题，我们要到27才能进位，而不是26.
                n = n / 26;
            }
            return s;
        }
    }
    // @lc code=end


}
