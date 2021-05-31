using System;
using System.Collections.Generic;
namespace CSharpConsoleApp.Solutions
{
    /*
     * @lc app=leetcode.cn id=535 lang=csharp
     *
     * [535] TinyURL 的加密与解密
     *
     * https://leetcode-cn.com/problems/encode-and-decode-tinyurl/description/
     *
     * Category	Difficulty	Likes	Dislikes
     * algorithms	Medium (83.99%)	119	-
     * Tags
     * hash-table | math
     * 
     * Companies
     * amazon | facebook | google | uber
     * Total Accepted:    14.1K
     * Total Submissions: 16.8K
     * Testcase Example:  '"https://leetcode.com/problems/design-tinyurl"'
     *
     * TinyURL是一种URL简化服务， 比如：当你输入一个URL https://leetcode.com/problems/design-tinyurl
     * 时，它将返回一个简化的URL http://tinyurl.com/4e9iAk.
     * 
     * 要求：设计一个 TinyURL 的加密 encode 和解密 decode
     * 的方法。你的加密和解密算法如何设计和运作是没有限制的，你只需要保证一个URL可以被加密成一个TinyURL，并且这个TinyURL可以用解密方法恢复成原本的URL。
     * 
     */
    public class Solution535 : SolutionBase
    {
        /// <summary>
        /// 难易度:
        /// </summary>
        public override Difficulity GetDifficulity() { return Difficulity.Medium; }
        /// <summary>
        /// 关键字:
        /// </summary>
        public override string[] GetKeyWords() { return new string[] { "TinyURL"  }; }
        /// <summary>
        /// 标签： 
        /// </summary>
        public override Tag[] GetTags() { return new Tag[] { Tag.HashTable, Tag.Math, Tag.Design }; }

        public override bool Test(System.Diagnostics.Stopwatch sw)
        {
            return true;
        }
    }

    /// <summary>
    /// 作者：LeetCode
    /// 链接：https://leetcode-cn.com/problems/encode-and-decode-tinyurl/solution/tinyurlde-jia-mi-yu-jie-mi-by-leetcod
    /// 739/739 cases passed (108 ms)
    /// Your runtime beats 50 % of csharp submissions
    /// our memory usage beats 10.71 % of csharp submissions(26.9 MB)
    /// </summary>
    public class Codec
    {
        
        String alphabet = "0123456789abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ";
        Dictionary<string, String> map = new Dictionary<string, String>();
        Random rand = new Random();
        String key = "";

        public String GetRand() {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            for (int i = 0; i < 6; i++) {
                sb.Append(alphabet[rand.Next(62)]);
            }
            return sb.ToString();
        }

        public String encode(String longUrl) {
            if (string.IsNullOrEmpty(key))
                key = GetRand();

            while (map.ContainsKey(key)) {
                key = GetRand();
            }
            map.Add(key, longUrl);
            return "http://tinyurl.com/" + key;
        }

        public String decode(String shortUrl) {
            return map[shortUrl.Replace("http://tinyurl.com/", "")];
        }
    }
}
