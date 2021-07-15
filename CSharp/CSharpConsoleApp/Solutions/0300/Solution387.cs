using System;
using System.Collections.Generic;
namespace CSharpConsoleApp.Solutions
{
    /*
 * @lc app=leetcode.cn id=387 lang=csharp
 *
 * [387] 字符串中的第一个唯一字符
 *
 * https://leetcode-cn.com/problems/first-unique-character-in-a-string/description/
 *
 * algorithms
 * Easy (52.32%)
 * Likes:    410
 * Dislikes: 0
 * Total Accepted:    189.7K
 * Total Submissions: 362.4K
 * Testcase Example:  '"leetcode"'
 *
 * 给定一个字符串，找到它的第一个不重复的字符，并返回它的索引。如果不存在，则返回 -1。
 * 
 * 
 * 
 * 示例：
 * 
 * s = "leetcode"
 * 返回 0
 * 
 * s = "loveleetcode"
 * 返回 2
 * 
 * 
 * 
 * 
 * 提示：你可以假定该字符串只包含小写字母。
 * 
 */

    // @lc code=start
    public class Solution387
    {
        public int FirstUniqChar(string s)
        {
            Dictionary<char, int> frequency = new Dictionary<char, int>();
            for (int i = 0; i < s.Length; ++i)
            {
                char ch = s[i];
                if (!frequency.ContainsKey(ch))
                    frequency.Add(ch, 0);
                frequency[ch] += 1;
            }
            for (int i = 0; i < s.Length; ++i)
            {
                if (frequency[s[i]] == 1)
                {
                    return i;
                }
            }
            return -1;
        }
    }
    // @lc code=end


}
