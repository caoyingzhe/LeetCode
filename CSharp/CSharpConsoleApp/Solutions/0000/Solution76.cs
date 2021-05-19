using System;
namespace CSharpConsoleApp.Solutions
{
    /*
     * @lc app=leetcode.cn id=76 lang=csharp
     *
     * [76] 最小覆盖子串
     *
     * https://leetcode-cn.com/problems/minimum-window-substring/description/
     *
     * Category	Difficulty	Likes	Dislikes
     * algorithms	Hard (41.42%)	1158	-
     * Tags
     * hash-table | two-pointers | string | sliding-window
     * 
     * Companies
     * facebook | linkedin | snapchat | uber
     * 
     * Total Accepted:    138K
     * Total Submissions: 333.1K
     * Testcase Example:  '"ADOBECODEBANC"\n"ABC"'
     *
     * 给你一个字符串 s 、一个字符串 t 。返回 s 中涵盖 t 所有字符的最小子串。如果 s 中不存在涵盖 t 所有字符的子串，则返回空字符串 "" 。
     * 
     * 注意：如果 s 中存在这样的子串，我们保证它是唯一的答案。
     * 
     * 示例 1：
     * 输入：s = "ADOBECODEBANC", t = "ABC"
     * 输出："BANC"
     * 
     * 示例 2：
     * 输入：s = "a", t = "a"
     * 输出："a"
     * 
     * 提示：
     * 1 <= s.length, t.length <= 10^5
     * s 和 t 由英文字母组成
     * 
     * 进阶：你能设计一个在 o(n) 时间内解决此问题的算法吗？
     */
    public class Solution76
    {
        /// <summary>
        /// 评论中的代码，效率不错。
        ///
        /// 266/266 cases passed (108 ms)
        /// Your runtime beats 86.67 % of csharp submissions
        /// Your memory usage beats 96.19 % of csharp submissions(25.3 MB)
        /// https://leetcode-cn.com/problems/minimum-window-substring/solution/tong-su-qie-xiang-xi-de-miao-shu-hua-dong-chuang-k/
        /// </summary>
        /// <param name="s"></param>
        /// <param name="t"></param>
        /// <returns></returns>
        public string MinWindow(string s, string t)
        {
            if (s == null || s.Length== 0 || t == null || t.Length== 0)
            {
                return "";
            }

            int[] need = new int[128]; //英文字母大小写一共有 64+64 =128种。对应 t 中包含字母对应的个数
            //记录需要的字符的个数
            for (int i = 0; i < t.Length; i++)
            {
                need[t[i]]++;
            }
            //l是当前左边界，r是当前右边界，size记录窗口大小，count是需求的字符个数，start是最小覆盖串开始的index
            int l = 0, r = 0, count = t.Length;

            //返回结果用的变量
            int start = 0;             //起始字符的位置
            int minLen = int.MaxValue; //匹配全包含字符的字符串最小长度

            //遍历所有字符
            while (r < s.Length) //循环一直等到右侧R变成末尾
            {
                char c = s[r];
                if (need[c] > 0) //在s中发现 t 中包含的字符c
                {
                    count--;
                }
                need[c]--;

                //把右边的字符加入窗口 ？？？
                if (count == 0) //在s中发现所有的 t 中包含的字符c
                {
                    while (l < r && need[s[l]] < 0) //左侧的字符c的出现数量小于0
                    {
                        need[s[l]]++;//释放右边移动出窗口的字符
                        l++;//指针右移
                    }
                    if (r - l + 1 < minLen)  //发现更短的窗口范围，更新 minLen 和左侧的索引 start；
                    {//不能右移时候挑战最小窗口大小，更新最小窗口开始的start
                        minLen = r - l + 1;
                        start = l;//记录下最小值时候的开始位置，最后返回覆盖串时候会用到
                    }
                    //l向右移动后窗口肯定不能满足了 重新开始循环
                    need[s[l]]++;
                    l++;
                    count++;   //等同于count=1； 意思就是左边已经是 t中的字符了，右移后，count重新返回1，（需要再次在右侧找到字符c才行）
                }
                r++;
            }
            return minLen == int.MaxValue ? "" : s.Substring(start, minLen);
        }
    }
}
