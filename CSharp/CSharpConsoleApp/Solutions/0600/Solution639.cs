using System;
using System.Collections.Generic;

namespace CSharpConsoleApp.Solutions
{

    /*
     * @lc app=leetcode.cn id=639 lang=csharp
     *
     * [639] 解码方法 II
     *
     * https://leetcode-cn.com/problems/decode-ways-ii/description/
     *
     * Category	Difficulty	Likes	Dislikes
     * algorithms	Hard (30.76%)	87	-
     * Tags
     * dynamic-programming
     * 
     * Companies
     * facebook
     * 
     * Total Accepted:    4K
     * Total Submissions: 12.8K
     * Testcase Example:  '"*"'
     *
     * 一条包含字母 A-Z 的消息通过以下的方式进行了编码：
     * 'A' -> 1
     * 'B' -> 2
     * ...
     * 'Z' -> 26
     * 
     * 
     * 除了上述的条件以外，现在加密字符串可以包含字符 '*'了，字符'*'可以被当做1到9当中的任意一个数字。
     * 给定一条包含数字和字符'*'的加密信息，请确定解码方法的总数。
     * 同时，由于结果值可能会相当的大，所以你应当对10^9 + 7取模。（翻译者标注：此处取模主要是为了防止溢出）
     * 
     * 示例 1 :
     * 输入: "*"
     * 输出: 9
     * 解释: 加密的信息可以被解密为: "A", "B", "C", "D", "E", "F", "G", "H", "I".
     * 
     * 
     * 示例 2 :
     * 输入: "1*"
     * 输出: 9 + 9 = 18（翻译者标注：这里1*可以分解为1,* 或者当做1*来处理，所以结果是9+9=18）
     * 
     * 说明 :
     * 输入的字符串长度范围是 [1, 10^5]。
     * 输入的字符串只会包含字符 '*' 和 数字'0' - '9'。
     */

    /*
    Original Description : 
    A message containing letters from A-Z can be encoded into numbers using the following mapping:

    'A' -> "1"
    'B' -> "2"
    ...
    'Z' -> "26"
    To decode an encoded message, all the digits must be grouped then mapped back into letters
    using the reverse of the mapping above (there may be multiple ways).

    For example, "11106" can be mapped into:
    "AAJF" with the grouping (1 1 10 6)
    "KJF" with the grouping (11 10 6)

    Note that the grouping (1 11 06) is invalid because "06" cannot be mapped into 'F'
    since "6" is different from "06".
    In addition to the mapping above, an encoded message may contain the '*' character,
    which can represent any digit from '1' to '9' ('0' is excluded).
    For example, the encoded message "1*" may represent any of the encoded messages
    "11", "12", "13", "14", "15", "16", "17", "18", or "19".
    Decoding "1*" is equivalent to decoding any of the encoded messages it can represent.

    Given a string s consisting of digits and '*' characters, return the number of ways to decode it.
    Since the answer may be very large, return it modulo 109 + 7.

    Example 1:

    Input: s = "*"
    Output: 9
    Explanation: The encoded message can represent any of the encoded messages "1", "2", "3", "4", "5", "6", "7", "8", or "9".
    Each of these can be decoded to the strings "A", "B", "C", "D", "E", "F", "G", "H", and "I" respectively.
    Hence, there are a total of 9 ways to decode "*".
    Example 2:

    Input: s = "1*"
    Output: 18
    Explanation: The encoded message can represent any of the encoded messages "11", "12", "13", "14", "15", "16", "17", "18", or "19".
    Each of these encoded messages have 2 ways to be decoded (e.g. "11" can be decoded to "AA" or "K").
    Hence, there are a total of 9 * 2 = 18 ways to decode "1*".
    Example 3:

    Input: s = "2*"
    Output: 15
    Explanation: The encoded message can represent any of the encoded messages "21", "22", "23", "24", "25", "26", "27", "28", or "29".
    "21", "22", "23", "24", "25", and "26" have 2 ways of being decoded, but "27", "28", and "29" only have 1 way.
    Hence, there are a total of (6 * 2) + (3 * 1) = 12 + 3 = 15 ways to decode "2*".
    
    Constraints:

    1 <= s.length <= 105
    s[i] is a digit or '*'.
    */
    // @lc code=start
    public class Solution639 : SolutionBase
    {
        /// <summary>
        /// 难度
        /// </summary>
        public override Difficulity GetDifficulity() { return Difficulity.Medium; }
        /// <summary>
        /// 关键字:
        /// </summary>
        public override string[] GetKeyWords() { return new string[] { "待理解好题", "解码游戏", "Solution91"}; }
        /// <summary>
        /// 标签：
        /// </summary>
        public override Tag[] GetTags() { return new Tag[] { Tag.DynamicProgramming }; }

        /// <summary>
        /// </summary>
        /// <param name="sw"></param>
        /// <returns></returns>
        public override bool Test(System.Diagnostics.Stopwatch sw)
        {
            bool isSuccess = true;

            string root;
            int result, checkResult;

            root = "*";
            checkResult = 9;
            result = NumDecodings(root);
            isSuccess &= IsSame(result, checkResult);
            PrintResult(isSuccess, (result), (checkResult));

            root = "1*";
            checkResult = 18;
            result = NumDecodings(root);
            isSuccess &= IsSame(result, checkResult);
            PrintResult(isSuccess, (result), (checkResult));

            return isSuccess;
        }

        //作者：go - cavs
        //链接：https://leetcode-cn.com/problems/decode-ways-ii/solution/jue-dui-shi-zui-jian-dan-de-fang-fa-zhe-ti-bu-yong/

        static int M = 1000000007;

        /// <summary>
        /// 217/217 cases passed (80 ms)
        /// Your runtime beats 83.33 % of csharp submissions
        /// Your memory usage beats 66.67 % of csharp submissions(35 MB)
        /// </summary>
        public int NumDecodings(string s)
        {
            int n = s.Length;
            if (s[0] == '0') return 0;
            //vector<vector<int>> dp(len,vector<int>(11,0));
            long a = 1, b, c = 0;

            if (s[0] != '*')
                b = 1;
            else
                b = 9;

            for (int i = 1; i < n; ++i)
            {
                if (s[i] != '*')
                {
                    c = 0;
                    if (s[i] != '0') c = b;
                    if (s[i - 1] == '1' || s[i - 1] == '*') c += a;
                    if (s[i] >= '0' && s[i] <= '6' && (s[i - 1] == '2' || s[i - 1] == '*')) c += a;
                }
                else //if(s[i] == '*')
                {
                    c = b * 9;                                          //前一字母为[3~9],即数字 3*~9* => 对应 [3~9]1~[3~9]9 合计 b*9种
                    if (s[i - 1] == '1' || s[i - 1] == '*') c += a * 9; //前一字母为 = 1
                    if (s[i - 1] == '2' || s[i - 1] == '*') c += a * 6; //前一字母为 = 2
                }
                c %= M;
                a = b;
                b = c;
            }
            if (n == 1)
                return (int) b;
            return (int) c;
        }
    }
    // @lc code=end


}
