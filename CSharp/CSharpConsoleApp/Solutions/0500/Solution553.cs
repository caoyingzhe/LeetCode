using System;
namespace CSharpConsoleApp.Solutions
{
    /*
 * @lc app=leetcode.cn id=553 lang=csharp
 *
 * [553] 最优除法
 *
 * https://leetcode-cn.com/problems/optimal-division/description/
 *
 * algorithms
 * Medium (60.15%)
 * Likes:    66
 * Dislikes: 0
 * Total Accepted:    5.3K
 * Total Submissions: 8.8K
 * Testcase Example:  '[1000,100,10,2]'
 *
 * 给定一组正整数，相邻的整数之间将会进行浮点除法操作。例如， [2,3,4] -> 2 / 3 / 4 。
 * 
 * 
 * 但是，你可以在任意位置添加任意数目的括号，来改变算数的优先级。你需要找出怎么添加括号，才能得到最大的结果，并且返回相应的字符串格式的表达式。你的表达式不应该含有冗余的括号。
 * 
 * 示例：
 * 
 * 
 * 输入: [1000,100,10,2]
 * 输出: "1000/(100/10/2)"
 * 解释:
 * 1000/(100/10/2) = 1000/((100/10)/2) = 200
 * 但是，以下加粗的括号 "1000/((100/10)/2)" 是冗余的，
 * 因为他们并不影响操作的优先级，所以你需要返回 "1000/(100/10/2)"。
 * 
 * 其他用例:
 * 1000/(100/10)/2 = 50
 * 1000/(100/(10/2)) = 50
 * 1000/100/10/2 = 0.5
 * 1000/100/(10/2) = 2
 * 
 * 
 * 说明:
 * 
 * 
 * 输入数组的长度在 [1, 10] 之间。
 * 数组中每个元素的大小都在 [2, 1000] 之间。
 * 每个测试用例只有一个最优除法解。
 * 
 * 
 */

    // @lc code=start
    public class Solution553
    {
        //为了最大化 a/b/c/da/b/c/d 我们首先需要最小化 b/c/d
        //2 种可能的表达式组合方法，分别是 b/(c/d) 和 (b/c)/d。
        //对于 d>1d>1 我们有 d/c > 1/(d*c)d/c>1/(d∗c)。
        //我们可以发现只要数字大于 11，第二种组合肯定比第一种组合要小。
        //所以答案是 a/(b/c/d)a/(b/c/d)

        /// <summary>
        /// 93/93 cases passed (116 ms)
        /// Your runtime beats 66.67 % of csharp submissions
        /// Your memory usage beats 66.67 % of csharp submissions(24.6 MB)
        /// 作者：LeetCode
        /// 链接：https://leetcode-cn.com/problems/optimal-division/solution/zui-you-chu-fa-by-leetcode/
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public string OptimalDivision(int[] nums)
        {
            if (nums.Length == 1)
                return nums[0] + "";
            if (nums.Length == 2)
                return nums[0] + "/" + nums[1];
            System.Text.StringBuilder res = new System.Text.StringBuilder(nums[0] + "/(" + nums[1]);
            for (int i = 2; i < nums.Length; i++)
            {
                res.Append("/" + nums[i]);
            }
            res.Append(")");
            return res.ToString();
        }
    }
    // @lc code=end


}
