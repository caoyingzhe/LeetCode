using System;
using System.Collections.Generic;
using System.Text;
namespace CSharpConsoleApp.Solutions
{
    /*
     * @lc app=leetcode.cn id=394 lang=csharp
     *
     * [394] 字符串解码
     *
     * https://leetcode-cn.com/problems/decode-string/description/
     *
     * Category	Difficulty	Likes	Dislikes
     * algorithms	Medium (54.56%)	759	-
     * Tags
     * stack | depth-first-search
     * 
     * Companies
     * google | yelp
     * 
     * Total Accepted:    96.5K
     * Total Submissions: 176.8K
     * Testcase Example:  '"3[a]2[bc]"'
     *
     * 给定一个经过编码的字符串，返回它解码后的字符串。
     * 
     * 编码规则为: k[encoded_string]，表示其中方括号内部的 encoded_string 正好重复 k 次。注意 k 保证为正整数。
     * 
     * 你可以认为输入字符串总是有效的；输入字符串中没有额外的空格，且输入的方括号总是符合格式要求的。
     * 
     * 此外，你可以认为原始数据不包含数字，所有的数字只表示重复的次数 k ，例如不会出现像 3a 或 2[4] 的输入。
     * 
     * 示例 1：
     * 输入：s = "3[a]2[bc]"
     * 输出："aaabcbc"
     * 
     * 示例 2：
     * 输入：s = "3[a2[c]]"
     * 输出："accaccacc"
     * 
     * 示例 3：
     * 输入：s = "2[abc]3[cd]ef"
     * 输出："abcabccdcdcdef"
     * 
     * 示例 4：
     * 输入：s = "abc3[cd]xyz"
     * 输出："abccdcdcdxyz"
     */
    public class Solution394 : SolutionBase
    {
        /// <summary>
        /// 难易度:
        /// </summary>
        public override Difficulity GetDifficulity() { return Difficulity.Medium; }
        /// <summary>
        /// 关键字:
        /// </summary>
        public override string[] GetKeyWords() { return new string[] { "字符串" }; }
        /// <summary>
        /// 标签： 图
        /// </summary>
        public override Tag[] GetTags() { return new Tag[] { Tag.Math, Tag.String }; }

        public override bool Test(System.Diagnostics.Stopwatch sw)
        {
            bool isSuccess = true;
            string s;
            string result; string checkResult;

            s = "3[a]2[bc]";
            checkResult = "aaabcbc";
            result = DecodeString(s);
            isSuccess = (checkResult == result);
            Print("isSuccess = {0} result = {1} | checkResult = {2}", isSuccess, (result), (checkResult));

            s = "3[a2[c]]";
            checkResult = "accaccacc";
            result = DecodeString(s);
            isSuccess = (checkResult == result);
            Print("isSuccess = {0} result = {1} | checkResult = {2}", isSuccess, (result), (checkResult));

            s = "2[abc]3[cd]ef";
            checkResult = "abcabccdcdcdef";
            result = DecodeString(s);
            isSuccess = (checkResult == result);
            Print("isSuccess = {0} result = {1} | checkResult = {2}", isSuccess, (result), (checkResult));

            s = "abc3[cd]xyz";
            checkResult = "abccdcdcdxyz";
            result = DecodeString(s);
            isSuccess = (checkResult == result);
            Print("isSuccess = {0} result = {1} | checkResult = {2}", isSuccess, (result), (checkResult));

            return isSuccess;
        }
        /*
        int ptr;
        
        public string DecodeString(string s)
        {
            LinkedList<String> stk = new LinkedList<String>();
            ptr = 0;

            while (ptr < s.Length)
            {
                char cur = s[ptr];
                if (char.IsNumber(cur))
                {
                    // 获取一个数字并进栈
                    String digits = GetDigits(s); //获取数字 参数：s, ptr
                    stk.AddLast(digits);
                }
                else if (char.IsLetter(cur) || cur == '[')
                {
                    // 获取一个字母并进栈
                    stk.AddLast(String.valueOf(s[ptr++]));
                }
                else
                {
                    ++ptr;
                    LinkedList<String> sub = new LinkedList<String>();
                    while ((stk.Last.Value != "["))
                    {
                        sub.AddLast(stk.Last.Value);
                        stk.RemoveLast();
                    }
                    Collections.reverse(sub);
                    // 左括号出栈
                    stk.RemoveLast();
                    // 此时栈顶为当前 sub 对应的字符串应该出现的次数
                    int repTime = int.Parse(stk.Last.Value);
                    stk.RemoveLast();

                    StringBuilder t = new StringBuilder();
                    String o = GetString(sub);
                    // 构造字符串
                    while (repTime-- > 0)
                    {
                        t.Append(o);
                    }
                    // 将构造好的字符串入栈
                    stk.AddLast(t.ToString());
                }
            }

            return GetString(stk);
        }

        public String GetDigits(String s)
        {
            StringBuilder ret = new StringBuilder();
            while (charis(s[ptr]))
            {
                ret.Append(s[ptr++]);
            }
            return ret.ToString();
        }

        public String GetString(LinkedList<String> v)
        {
            StringBuilder ret = new StringBuilder();
            foreach (String s in v)
            {
                ret.Append(s);
            }
            return ret.ToString();
        }

        //作者：LeetCode-Solution
        //链接：https://leetcode-cn.com/problems/decode-string/solution/zi-fu-chuan-jie-ma-by-leetcode-solution/

        */

        /*
        var decodeString = function(s) {
         const reg = /(\d+)\[([a-z]+)\]/g
         while (s.includes('[')) s = s.replace(reg, ($, $1, $2) => $2.repeat($1))
         return s
        };
          */


        /// <summary>
        /// 34/34 cases passed (100 ms)
        /// Your runtime beats 57.89 % of csharp submissions
        /// Your memory usage beats 5.26 % of csharp submissions(26.5 MB)
        /// 栈可以不用塞string，塞下标更省空间
        /// https://leetcode-cn.com/problems/decode-string/solution/zi-fu-chuan-jie-ma-by-leetcode-solution/
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public string DecodeString_NoStringBuffer(string s)
        {
            Stack<int[]> stk = new Stack<int[]>();
            string ans = "";

            for (int i = 0; i < s.Length;)
            {
                while (i < s.Length && char.IsLetter(s[i]))
                    ans += s[i++];

                if (i == s.Length) break;

                //first: 开始位置 second: 重复次数
                if (s[i] == ']')
                {
                    int[] it = stk.Peek();
                    stk.Pop();
                    int End = ans.Length;

                    for (int t = 0; t < it[1] - 1; t++)
                        for (int j = it[0]; j < End; j++)
                            ans += ans[j];

                    i++;
                    continue;
                }

                //first: 开始位置 second: 重复次数
                int cnt = 0;
                while (char.IsNumber(s[i])) cnt = cnt * 10 + s[i++] - '0';
                i++;   //过掉'['

                stk.Push(new int[] { ans.Length, cnt });
            }

            return ans;
        }

        /// <summary>
        /// 34/34 cases passed (132 ms)
        /// Your runtime beats 5.26 % of csharp submissions
        /// Your memory usage beats 38.16 % of csharp submissions(23 MB)
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public string DecodeString_StringBuffer(string s)
        {
            Stack<int[]> stk = new Stack<int[]>();
            StringBuilder ans = new StringBuilder();

            for (int i = 0; i < s.Length;)
            {
                while (i < s.Length && char.IsLetter(s[i]))
                    ans.Append(s[i++]);

                if (i == s.Length) break;

                //first: 开始位置 second: 重复次数
                if (s[i] == ']')
                {
                    int[] it = stk.Peek();
                    stk.Pop();
                    int End = ans.Length;

                    for (int t = 0; t < it[1] - 1; t++)
                        for (int j = it[0]; j < End; j++)
                            ans.Append(ans[j]);

                    i++;
                    continue;
                }

                //first: 开始位置 second: 重复次数
                int cnt = 0;
                while (char.IsNumber(s[i])) cnt = cnt * 10 + s[i++] - '0';
                i++;   //过掉'['

                stk.Push(new int[] { ans.Length, cnt });
            }

            return ans.ToString();
        }

        //js 正则，三行，时间 98%，空间 98%
        public string DecodeString(string s)
        {
            System.Text.RegularExpressions.Regex reg = new System.Text.RegularExpressions.Regex("/ (\\d+)\\[([a-z]+)\\]/g");
            while (s.Contains("["))
            {
                //reg.Replace(reg, 
                //s = s.Replace(reg, ($, $1, $2) => $2.repeat($1));
            }
            return s;
        }
        public string DecodeString_Wrong(string s)
        {
            int n = s.Length;
            Stack<int[]> stack = new Stack<int[]>();

            //Stack<int[]> stack = new Stack<int[]>();

            int bracletCount = 0;

            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            Dictionary<int, List<int[]>> dict = new Dictionary<int, List<int[]>>();
            List<int[]> brackletInfos = new List<int[]>();
            int depth = 0;
            int depthMax = 0;
            for (int i = 0; i < n; i++)
            {
                if (char.IsNumber(s[i]))
                {
                    int start = i;
                    while (i + 1 < n && char.IsNumber(s[i + 1]))
                    {
                        i++;
                    }
                    int number = int.Parse(s.Substring(start, i - start + 1));
                    stack.Push(new int[] { i + 1, number }); //s[i+1] == '['
                    depth++;
                    depthMax = Math.Max(depthMax, depth);
                }
                else if (s[i] == ']')
                {
                    var preInfo = stack.Pop();
                    int charStart = preInfo[0];
                    int number = preInfo[1];
                    int charEnd = i - 1;
                    AddInfo(depth, charStart, charEnd, number, dict);
                    depth--;
                }
            }

            for (int i = 0; i < depthMax; i++)
            {

                //Print(GetString());
            }
            return "";
        }
        void AddInfo(int depth, int charStart, int charEnd, int number, Dictionary<int, List<int[]>> dict)
        {
            if (!dict.ContainsKey(depth))
            {
                dict.Add(depth, new List<int[]>());
            }
            dict[depth].Add(new int[] { number, charStart, charEnd });
        }

        string GetString(string s, int charStart, int charEnd, int number)
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            string word = s.Substring(charStart, charEnd - charStart + 1);
            for (int m = 0; m < number; m++)
            {
                sb.Append(word);
            }
            return sb.ToString();
        }
    }

}
