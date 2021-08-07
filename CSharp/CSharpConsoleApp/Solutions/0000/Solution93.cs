using System;
using System.Collections.Generic;
namespace CSharpConsoleApp.Solutions
{
    /*
     * @lc app=leetcode.cn id=93 lang=csharp
     *
     * [93] 复原 IP 地址
     *
     * https://leetcode-cn.com/problems/restore-ip-addresses/description/
     *
     * Category	Difficulty	Likes	Dislikes
     * algorithms	Medium (53.15%)	607	-
     * Tags
     * string | backtracking
     * 
     * Companies
     * Unknown
     * 
     * Total Accepted:    127.6K
     * Total Submissions: 240K
     * Testcase Example:  '"25525511135"'
     *
     * 给定一个只包含数字的字符串，用以表示一个 IP 地址，返回所有可能从 s 获得的 有效 IP 地址 。你可以按任何顺序返回答案。
     * 
     * 有效 IP 地址 正好由四个整数（每个整数位于 0 到 255 之间组成，且不能含有前导 0），整数之间用 '.' 分隔。
     * 
     * 例如："0.1.2.201" 和 "192.168.1.1" 是 有效 IP 地址，但是 "0.011.255.245"、"192.168.1.312"
     * 和 "192.168@1.1" 是 无效 IP 地址。
     *
     * 
     * 示例 1：
     * 输入：s = "25525511135"
     * 输出：["255.255.11.135","255.255.111.35"]
     * 
     * 
     * 示例 2：
     * 输入：s = "0000"
     * 输出：["0.0.0.0"]
     * 
     * 
     * 示例 3：
     * 输入：s = "1111"
     * 输出：["1.1.1.1"]
     * 
     * 
     * 示例 4：
     * 输入：s = "010010"
     * 输出：["0.10.0.10","0.100.1.0"]
     * 
     * 
     * 示例 5：
     * 输入：s = "101023"
     * 输出：["1.0.10.23","1.0.102.3","10.1.0.23","10.10.2.3","101.0.2.3"]
     * 
     * 
     * 提示：
     * 0 <= s.length <= 3000
     * s 仅由数字组成
     */

    // @lc code=start
    public class Solution93 : SolutionBase
    {
        /// <summary>
        /// 难易度:
        /// </summary>
        public override Difficulity GetDifficulity() { return Difficulity.Medium; }
        /// <summary>
        /// 关键字:
        /// </summary>
        public override string[] GetKeyWords() { return new string[] { "回溯模型", "IP地址" }; }
        /// <summary>
        /// 标签：
        /// </summary>
        public override Tag[] GetTags() { return new Tag[] { Tag.String, Tag.Backtracking }; }

        /// <summary>
        /// 195/195 cases passed (104 ms)
        /// Your runtime beats 89.9 % of csharp submissions
        /// Your memory usage beats 95.45 % of csharp submissions(24.5 MB)
        /// </summary>
        /// <param name="sw"></param>
        /// <returns></returns>
        public override bool Test(System.Diagnostics.Stopwatch sw)
        {
            bool isSuccess = true;
            string s;
            IList<string> result, checkResult;

            //s = "19216801";
            //checkResult = new string[] { "192.168.0.1" };
            //result = RestoreIpAddresses(s);
            //isSuccess &= IsListSame(result, checkResult);
            //Print("isSuccess = {0} result = {1} | checkResult = {2}", isSuccess, GetArrayStr(result), GetArrayStr(checkResult));

            s = "25525511135";
            checkResult = new string[] { "255.255.11.135", "255.255.111.35" };
            result = RestoreIpAddresses(s);
            isSuccess &= IsListSame(result, checkResult);
            Print("isSuccess = {0} result = {1} | checkResult = {2}", isSuccess, GetArrayStr(result), GetArrayStr(checkResult));

            s = "101023";
            checkResult = new string[] { "1.0.10.23", "1.0.102.3", "10.1.0.23", "10.10.2.3", "101.0.2.3" };
            result = RestoreIpAddresses(s);
            isSuccess &= IsListSame(result, checkResult);
            Print("isSuccess = {0} result = {1} | checkResult = {2}", isSuccess, GetArrayStr(result), GetArrayStr(checkResult));

            return isSuccess;
        }

        /// <summary>
        /// TODO 有待优化
        /// 147/147 cases passed (304 ms)
        /// 1Your runtime beats 30.16 % of csharp submissions
        /// 1Your memory usage beats 5.55 % of csharp submissions(32.5 MB)
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public IList<string> RestoreIpAddresses(string s)
        {
            result = new List<string>();
            if (string.IsNullOrEmpty(s) || s.Length > 12) return result;

            backtracking(s, s.Length, 0, new List<string>());
            return result;
        }

        List<string> result;
        void backtracking(string s, int sLength, int start, List<string> nums)
        {
            if (start == sLength)
            {
                if (nums.Count == 4)
                {
                    result.Add(string.Join(".", nums.ToArray()));
                }
                //存放结果;
                return;
            }

            //for (选择：本层集合中元素（树中节点孩子的数量就是集合的大小）)
            for (int len = 1; len <= 3; len++)
            {
                if (start + len > sLength) break;

                //处理节点;

                string num = s.Substring(start, len);
                if (IsBit10X3(num))
                {
                    nums.Add(num);

                    backtracking(s, sLength, start + len, nums);
                    //backtracking(路径，选择列表); // 递归

                    //回溯，撤销处理结果
                    nums.RemoveAt(nums.Count - 1);
                }
            }
        }

        //void backtracking(参数)
        //{
        //    if (终止条件)
        //    {
        //        存放结果;
        //        return;
        //    }

        //    for (选择：本层集合中元素（树中节点孩子的数量就是集合的大小）)
        //    {
        //        处理节点;
        //        backtracking(路径，选择列表); // 递归
        //        回溯，撤销处理结果
        //    }
        //}

        //是否为IP4的有效数字
        public bool IsBit10X3(string s, int maxVal = 255)
        {
            if (s == null) return false;
            int n = s.Length;
            if (n > 3 || n == 0) return false;
            if (s.StartsWith("0") && n > 1) return false;

            int val = 0;
            for (int i = 0; i < n; i++)
            {
                if ((s[i] - '0' >= 0 && s[i] - '0' <= 9))
                {
                    val = val * 10 + s[i] - '0';
                    if (i == n - 1 && val <= maxVal)
                        return true;
                }
                else
                    break;
            }
            return false;
        }
    }
    // @lc code=end


}
