using System;
using System.Collections.Generic;
namespace CSharpConsoleApp.Solutions
{
    /*
 * @lc app=leetcode.cn id=423 lang=csharp
 *
 * [423] 从英文中重建数字
 *
 * https://leetcode-cn.com/problems/reconstruct-original-digits-from-english/description/
 *
 * Category	Difficulty	Likes	Dislikes
 * algorithms	Medium (56.64%)	65	-
 * Tags
 * math
 * 
 * Companies
 * Unknown
 * 
 * Total Accepted:    7.6K
 * Total Submissions: 13.4K
 * Testcase Example:  '"owoztneoer"'
 *
 * 给定一个非空字符串，其中包含字母顺序打乱的英文单词表示的数字0-9。按升序输出原始的数字。
 * 
 * 注意:
 * 
 * 
 * 输入只包含小写英文字母。
 * 输入保证合法并可以转换为原始的数字，这意味着像 "abc" 或 "zerone" 的输入是不允许的。
 * 输入字符串的长度小于 50,000。
 * 
 * 
 * 示例 1:
 * 
 * 
 * 输入: "owoztneoer"
 * 
 * 输出: "012" (zeroonetwo)
 * 
 * 
 * 示例 2:
 * 
 * 
 * 输入: "fviefuro"
 * 
 * 输出: "45" (fourfive)
 * 
 * 
 */

    // @lc code=start
    public class Solution423 : SolutionBase
    {
        /// <summary>
        /// 难度
        /// </summary>
        public override Difficulity GetDifficulity() { return Difficulity.Medium; }
        /// <summary>
        /// 关键字:
        /// </summary>
        public override string[] GetKeyWords() { return new string[] { }; }
        /// <summary>
        /// 标签：
        /// </summary>
        public override Tag[] GetTags() { return new Tag[] { Tag.Unknown }; }

        public override bool Test(System.Diagnostics.Stopwatch sw)
        {
            bool isSuccess = true;
            //TODO
            return isSuccess;
        }

        string[] numbers = {
            "zero", "one", "two", "three", "four",
            "five",  "six", "seven", "eight", "nine"
        };

        //作者：LeetCode
        //链接：https://leetcode-cn.com/problems/reconstruct-original-digits-from-english/solution/cong-ying-wen-zhong-zhong-jian-shu-zi-by-leetcode/
        /// <summary>
        /// 24/24 cases passed (80 ms)
        /// Your runtime beats 100 % of csharp submissions
        /// Your memory usage beats 45.45 % of csharp submissions(30.3 MB)
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public string OrignialDigits(string s)
        {
            // building hashmap letter -> its frequency
            // 数组范围为  0～ z, 实际使用范围为'a' ~ 'z',
            // 虽然浪费了部分空间，但是省去了字符串转索引的处理。 
            char[] count = new char[26 + (int)'a']; 
            foreach(char letter in s)
            {
                count[letter]++;
            }

            // building hashmap digit -> its frequency
            int[] rtn = new int[10];
            // letter "z" is present only in "zero"
            rtn[0] = count['z'];
            // letter "w" is present only in "two"
            rtn[2] = count['w'];
            // letter "u" is present only in "four"
            rtn[4] = count['u'];
            // letter "x" is present only in "six"
            rtn[6] = count['x'];
            // letter "g" is present only in "eight"
            rtn[8] = count['g'];
            // letter "h" is present only in "three" and "eight"
            rtn[3] = count['h'] - rtn[8];
            // letter "f" is present only in "five" and "four"
            rtn[5] = count['f'] - rtn[4];
            // letter "s" is present only in "seven" and "six"
            rtn[7] = count['s'] - rtn[6];
            // letter "i" is present in "nine", "five", "six", and "eight"
            rtn[9] = count['i'] - rtn[5] - rtn[6] - rtn[8];
            // letter "n" is present in "one", "nine", and "seven"
            rtn[1] = count['n'] - rtn[7] - 2 * rtn[9];

            // building output string
            System.Text.StringBuilder output = new System.Text.StringBuilder();
            for(int i = 0; i< 10; i++)
              for (int j = 0; j< rtn[i]; j++)
                output.Append(i);
            return output.ToString();
        }

        public string OriginalDigits_MY_TODO(string s)
        {
            Dictionary<char, int> dict = new Dictionary<char, int>();
            Dictionary<char, int> dictTarget = new Dictionary<char, int>();
            int[] charsCount = new int[26];
            for(int i=0; i< 9; i++)
            {
                string numStr = numbers[i];
                foreach(char c in numStr)
                {
                    charsCount[c-'a']++;
                }
            }
            string log = "";
            List<char> chars = new List<char>();
            for(int i=0; i<26; i++)
            {
                if (charsCount[i] > 0)
                {
                    char c = (char)('a' + i);
                    chars.Add(c);
                    dict.Add(c, charsCount[i]);
                    log += "" + c  + " : " + charsCount[i] + "\n";
                }
            }
            Print(log);

            
            foreach (char c in s)
            {
                if (!dictTarget.ContainsKey(c))
                {
                    dictTarget[c]=0;
                }
                dictTarget[c]++;
            }
            foreach (char c in dictTarget.Keys)
            {

            }

            return "";
        }
    }
    // @lc code=end


}
