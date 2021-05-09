using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpConsoleApp.Solutions._0000
{
    /*
     * @lc app=leetcode.cn id=14 lang=csharp
     *
     * [14] 最长公共前缀
     *
     * https://leetcode-cn.com/problems/longest-common-prefix/description/
     *
     * Category	Difficulty	Likes	Dislikes
     * algorithms	Easy (39.50%)	1592	-
     * Tags
     * string
     * 
     * Companies
     * yelp
     * 
     * Total Accepted:    513.4K
     * Total Submissions: 1.3M
     * Testcase Example:  '["flower","flow","flight"]'
     *
     * 编写一个函数来查找字符串数组中的最长公共前缀。
     * 
     * 如果不存在公共前缀，返回空字符串 ""。
     * 
     * 示例 1：
     * 输入：strs = ["flower","flow","flight"]
     * 输出："fl"
     * 
     * 示例 2：
     * 输入：strs = ["dog","racecar","car"]
     * 输出：""
     * 解释：输入不存在公共前缀。
     * 
     * 提示：
     * 0 <= strs.Length <= 200
     * 0 <= strs[i].Length <= 200
     * strs[i] 仅由小写英文字母组成
     * 
     */
    class Solution14
    {
        public String LongestCommonPrefix(String[] strs)
        {
            //纵向扫描  横向扫描 效率是一样的。
            return LongestCommonPrefix_HScan(strs);
            //return LongestCommonPrefix_VScan(strs);

            //还可以使用分治法，

            //不管什么方法，对于通用场景效率不会差很多。
        }
        /// <summary>
        /// 纵向扫描
        /// 
        /// 作者：LeetCode-Solution
        /// 链接：https://leetcode-cn.com/problems/longest-common-prefix/solution/zui-chang-gong-gong-qian-zhui-by-leetcode-solution/
        /// </summary>
        /// <param name="strs"></param>
        /// <returns></returns>
        public String LongestCommonPrefix_VScan(String[] strs)
        {
            if (strs == null || strs.Length == 0)
            {
                return "";
            }
            int length = strs[0].Length;
            int count = strs.Length;
            for (int i = 0; i < length; i++)
            {
                char c = strs[0][i];
                for (int j = 1; j < count; j++)
                {
                    if (i == strs[j].Length || strs[j][i] != c)
                    {
                        return strs[0].Substring(0, i);
                    }
                }
            }
            return strs[0];
        }

        /// <summary>
        /// 横向扫描
        /// </summary>
        /// <param name="strs"></param>
        /// <returns></returns>
        public String LongestCommonPrefix_HScan(String[] strs)
        {
            if (strs == null || strs.Length == 0)
            {
                return "";
            }
            String prefix = strs[0];
            int count = strs.Length;
            for (int i = 1; i < count; i++)
            {
                prefix = LongestCommonPrefix(prefix, strs[i]);
                if (prefix.Length == 0)
                {
                    break;
                }
            }
            return prefix;
        }

        public String LongestCommonPrefix(String str1, String str2)
        {
            int length = Math.Min(str1.Length, str2.Length);
            int index = 0;
            while (index < length && str1[index] == str2[index])
            {
                index++;
            }
            return str1.Substring(0, index);
        }
    }
}
