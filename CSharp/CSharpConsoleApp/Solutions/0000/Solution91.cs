using System;
namespace CSharpConsoleApp.Solutions
{
    /*
     * @lc app=leetcode.cn id=91 lang=csharp
     *
     * [91] 解码方法
     *
     * https://leetcode-cn.com/problems/decode-ways/description/
     *
     * Category	Difficulty	Likes	Dislikes
     * algorithms	Medium (29.71%)	871	-
     * Tags
     * string | dynamic-programming
     * 
     * Companies
     * facebook | microsoft | uber
     * 
     * Total Accepted:    139.5K
     * Total Submissions: 468.7K
     * Testcase Example:  '"12"'
     *
     * 一条包含字母 A-Z 的消息通过以下映射进行了 编码 ：
     * 'A' -> 1
     * 'B' -> 2
     * ...
     * 'Z' -> 26
     * 
     * 要 解码 已编码的消息，所有数字必须基于上述映射的方法，反向映射回字母（可能有多种方法）。例如，"11106" 可以映射为：
     * "AAJF" ，将消息分组为 (1 1 10 6)
     * "KJF" ，将消息分组为 (11 10 6)
     * 
     * 注意，消息不能分组为  (1 11 06) ，因为 "06" 不能映射为 "F" ，这是由于 "6" 和 "06" 在映射中并不等价。
     * 给你一个只含数字的 非空 字符串 s ，请计算并返回 解码 方法的 总数 。
     * 题目数据保证答案肯定是一个 32 位 的整数。
     *
     *
     * 示例 1：
     * 输入：s = "12"
     * 输出：2
     * 解释：它可以解码为 "AB"（1 2）或者 "L"（12）。
     * 
     * 
     * 示例 2：
     * 输入：s = "226"
     * 输出：3
     * 解释：它可以解码为 "BZ" (2 26), "VF" (22 6), 或者 "BBF" (2 2 6) 。
     * 
     * 
     * 示例 3：
     * 输入：s = "0"
     * 输出：0
     * 解释：没有字符映射到以 0 开头的数字。
     * 含有 0 的有效映射是 'J' -> "10" 和 'T'-> "20" 。
     * 由于没有字符，因此没有有效的方法对此进行解码，因为所有数字都需要映射。
     *
     * 
     * 示例 4：
     * 输入：s = "06"
     * 输出：0
     * 解释："06" 不能映射到 "F" ，因为字符串含有前导 0（"6" 和 "06" 在映射中并不等价）。
     *
     * 
     * 提示：
     * 1 <= s.length <= 100
     * s 只包含数字，并且可能包含前导零。
     */

    // @lc code=start
    public class Solution91 : SolutionBase
    {
        /// <summary>
        /// 难度
        /// </summary>
        public override Difficulity GetDifficulity() { return Difficulity.Medium; }
        /// <summary>
        /// 关键字:
        /// </summary>
        public override string[] GetKeyWords() { return new string[] { "摩尔投票法" }; }
        /// <summary>
        /// 标签：
        /// </summary>
        public override Tag[] GetTags() { return new Tag[] { Tag.Array }; }

        /// <summary>
        /// 入度：每个课程节点的入度数量等于其先修课程的数量；
        /// 出度：每个课程节点的出度数量等于其指向的后续课程数量；
        /// 所以只有当一个课程节点的入度为零时，其才是一个可以学习的自由课程。
        ///
        /// 拓扑排序即是将一个无环有向图转换为线性排序的过程。
        /// </summary>
        /// <param name="sw"></param>
        /// <returns></returns>
        public override bool Test(System.Diagnostics.Stopwatch sw)
        {
            bool isSuccess = true;
            string nums;
            int result, checkResult;

            nums = "226";
            checkResult = 3;
            result = NumDecodings(nums);
            isSuccess &= IsSame(result, checkResult);
            Print("isSuccess = {0} | result= {1} | checkResult= {2} | ", isSuccess, (result), (checkResult));

            nums = "06";
            checkResult = 0;
            result = NumDecodings(nums);
            isSuccess &= IsSame(result, checkResult);
            Print("isSuccess = {0} | result= {1} | checkResult= {2} | ", isSuccess, (result), (checkResult));

            nums = "128";
            checkResult = 2;
            result = NumDecodings(nums);
            isSuccess &= IsSame(result, checkResult);
            Print("isSuccess = {0} | result= {1} | checkResult= {2} | ", isSuccess, (result), (checkResult));

            //Case4: dp[i] = dp[i-1]  s[i] = 8
            nums = "1281";
            checkResult = 2;
            result = NumDecodings(nums);
            isSuccess &= IsSame(result, checkResult);
            Print("isSuccess = {0} | result= {1} | checkResult= {2} | ", isSuccess, (result), (checkResult));

            //Case2: (s[i-1] = 1) dp[i] = dp[i-2] + dp[i-1] 
            nums = "12813";
            checkResult = 2;
            result = NumDecodings(nums);
            isSuccess &= IsSame(result, checkResult);
            Print("isSuccess = {0} | result= {1} | checkResult= {2} | ", isSuccess, (result), (checkResult));

            //Case4: dp[i] = dp[i-1]  s[i] = 8
            nums = "1282";
            checkResult = 2;
            result = NumDecodings(nums);
            isSuccess &= IsSame(result, checkResult);
            Print("isSuccess = {0} | result= {1} | checkResult= {2} | ", isSuccess, (result), (checkResult));

            //Case3 : (s[i-1] = 2 && s[i] = 1～6)  dp[i] = dp[i-2] + dp[i-1]
            nums = "12823";
            checkResult = 4;
            result = NumDecodings(nums);
            isSuccess &= IsSame(result, checkResult);
            Print("isSuccess = {0} | result= {1} | checkResult= {2} | ", isSuccess, (result), (checkResult));


            return isSuccess;
        }

        /// <summary>
        /// 空字符串可以有 11 种解码方法，解码出一个空字符串。
        ///
        /// //作者：pris_bupt
        /// //链接：https://leetcode-cn.com/problems/decode-ways/solution/c-wo-ren-wei-hen-jian-dan-zhi-guan-de-jie-fa-by-pr/
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public int NumDecodings(string s)
        {
            if (string.IsNullOrEmpty(s) || s.Length == 0)
            {
                return 0;
            }
            if (s[0] == '0') return 0;
            int n = s.Length;

            int pre = 1, curr = 1; //dp[-1] = dp[0] = 1
            for (int i = 1; i < n; i++)
            {
                int tmp = curr;

                //Case1 : s[i] ==0 的情况 && s[i-1]= 1 or 2, dp[i] = dp[i-2]; 否则 return 0
                if (s[i] == '0')
                { 
                    if (s[i - 1] == '1' || s[i - 1] == '2')
                        curr = pre;
                    else
                        return 0;
                }
                //Case2 : s[i] ==1 的情况 dp[i] = dp[i-1] + dp[i-2];
                else if (s[i - 1] == '1')
                    curr = curr + pre;
                //Case3 : s[i] ==2 的情况 && s[i-1]= 1~6, dp[i] = dp[i-1] + dp[i-2];
                //                       && s[i-1]= 0,   dp[i] = dp[i-1];
                else if (s[i - 1] == '2' && s[i] >= '1' && s[i] <= '6')
                    curr = curr + pre;

                //Case4 
                //else dp[i] = dp[i];

                pre = tmp; //dp[i-1] = dp[i]
            }
            return curr;
        }
    }
    // @lc code=end


}
