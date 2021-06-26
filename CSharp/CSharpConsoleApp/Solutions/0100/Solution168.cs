using System;
namespace CSharpConsoleApp.Solutions
{
    /*
 * @lc app=leetcode.cn id=168 lang=csharp
 *
 * [168] Excel表列名称
 *
 * https://leetcode-cn.com/problems/excel-sheet-column-title/description/
 *
 * Category	Difficulty	Likes	Dislikes
 * algorithms	Easy (39.39%)	355	-
 * Tags
 * math
 * 
 * Companies
 * facebook | microsoft | zenefits
 * 
 * Total Accepted:    52.6K
 * Total Submissions: 133.5K
 * Testcase Example:  '1'
 *
 * 给定一个正整数，返回它在 Excel 表中相对应的列名称。
 * 
 * 例如，
 * ⁠   1 -> A
 * ⁠   2 -> B
 * ⁠   3 -> C
 * ⁠   ...
 * ⁠   26 -> Z
 * ⁠   27 -> AA
 * ⁠   28 -> AB 
 * ⁠   ...
 * 
 * 示例 1:
 * 输入: 1
 * 输出: "A"
 * 
 * 
 * 示例 2:
 * 输入: 28
 * 输出: "AB"
 * 
 * 
 * 示例 3:
 * 输入: 701
 * 输出: "ZY"
 */

    // @lc code=start
    public class Solution168
    {
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
