using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpConsoleApp.Solutions
{
    /// <summary>
    /// 最短回文串
    /// 
    /// 给定一个字符串 s，你可以通过在字符串前面添加字符将其转换为回文串。找到并返回可以用这种方式转换的最短回文串。
    /// 
    /// 输入：s = "aacecaaa"
    /// 输出："aaacecaaa"
    /// 
    /// 输入：s = "abcd"
    /// 输出："dcbabcd"
    /// 
    /// 提示：
    /// 0 <= s.length <= 5 * 104
    /// s 仅由小写英文字母组成
    /// 
    /// 作者：LeetCode - Solution
    /// 链接：https://leetcode-cn.com/problems/shortest-palindrome/solution/zui-duan-hui-wen-chuan-by-leetcode-solution/
    /// </summary>
    class Solution214 : SolutionBase
    {
        /// <summary>
        /// 难度
        /// </summary>
        public override Difficulity GetDifficulity() { return Difficulity.Hard; }
        /// <summary>
        /// 关键字:
        /// </summary>
        public override string[] GetKeyWords() { return new string[] { "KMP算法" }; }
        /// <summary>
        /// 标签： 
        /// </summary>
        public override Tag[] GetTags() { return new Tag[] { Tag.String }; }

        public override bool Test(System.Diagnostics.Stopwatch sw)
        {
            bool isSuccess = true;
            string input = "aacecaaa";
            string result = ShortestPalindrome(input);
            string checkResult = "aaacecaaa";
            isSuccess &= result.Equals(checkResult);

            return isSuccess;
        }

        public string ShortestPalindrome(string s)
        {
            //return ShortestPalindrome_HashCollision(s);
            return ShortestPalindrome_KMP(s);
        }

        /// <summary>
        ///  Rabin-Karp 字符串哈希算法
        ///  时间复杂度：O(|s|)
        ///  空间复杂度：O(1)
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public string ShortestPalindrome_HashCollision(string s)
        {
            int n = s.Length;

            //我们选取一个大于字符集大小（即字符串中可能出现的字符种类的数目）的质数作为 base，（当前题目只有小写英文字母，大于26即可)
            //再选取一个在字符串长度平方级别左右的质数作为 mod，产生哈希碰撞的概率就会很低。 (当前题目为5万，这里用到了10万*10万）
            int baseNum = 131; int mod = 1000000007;
            int left = 0, right = 0, mul = 1;
            int best = -1;
            for (int i = 0; i < n; ++i)
            {
                left = (int)(((long)left * baseNum + s[i]) % mod);
                right = (int)((right + (long)mul * s[i]) % mod);
                if (left == right)
                {
                    best = i;
                }
                mul = (int)((long)mul * baseNum % mod);
            }
            string add = (best == n - 1 ? "" : s.Substring(best + 1));
            return string.Join("", add.Reverse<char>().ToArray()) + s;
        }

        /// <summary>
        /// KMP算法 专门用来匹配字符串的算法
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public string ShortestPalindrome_KMP(string s)
        {
            int n = s.Length;
            int[] fail = new int[n];
            for (int i = 0; i < n; i++) fail[i] = -1;

            //正向循环
            for (int i = 1; i < n; ++i)
            {
                int j = fail[i - 1];
                while (j != -1 && s[j + 1] != s[i])
                {
                    j = fail[j];
                }
                if (s[j + 1] == s[i])
                {
                    fail[i] = j + 1;
                }
            }
            int best = -1; //代表需要添加的对称字符所对应的索引
            //逆向循环
            for (int i = n - 1; i >= 0; --i)
            {
                while (best != -1 && s[best + 1] != s[i])
                {
                    best = fail[best];
                }
                if (s[best + 1] == s[i])
                {
                    ++best;
                }
            }
            string add = (best == n - 1 ? "" : s.Substring(best + 1));
            return string.Join("", add.Reverse<char>().ToArray()) + s;
        }
    }
}
