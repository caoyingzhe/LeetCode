﻿using System;
namespace CSharpConsoleApp.Solutions
{
    /*
     * @lc app=leetcode.cn id=443 lang=csharp
     *
     * [443] 压缩字符串
     *
     * https://leetcode-cn.com/problems/string-compression/description/
     *
     * Category	Difficulty	Likes	Dislikes
     * algorithms	Medium (42.40%)	188	-
     * Tags
     * string
     * 
     * Companies
     * bloomberg | microsoft | snapchat | yelp
     * 
     * Total Accepted:    30.2K
     * Total Submissions: 71.2K
     * Testcase Example:  '["a","a","b","b","c","c","c"]'
     *
     * 给定一组字符，使用原地算法将其压缩。
     * 压缩后的长度必须始终小于或等于原数组长度。
     * 数组的每个元素应该是长度为1 的字符（不是 int 整数类型）。
     * 在完成原地修改输入数组后，返回数组的新长度。
     * 
     * 进阶：
     * 你能否仅使用O(1) 空间解决问题？
     * 
     * 示例 1：
     * 输入： ["a","a","b","b","c","c","c"]
     * 
     * 输出：
     * 返回 6 ，输入数组的前 6 个字符应该是：["a","2","b","2","c","3"]
     * 
     * 说明：
     * "aa" 被 "a2" 替代。"bb" 被 "b2" 替代。"ccc" 被 "c3" 替代。
     * 示例 2：
     * 
     * 输入： ["a"]
     * 
     * 输出：
     * 返回 1 ，输入数组的前 1 个字符应该是：["a"]
     * 
     * 解释： 没有任何字符串被替代。
     * 
     * 
     * 示例 3：
     * 输入：["a","b","b","b","b","b","b","b","b","b","b","b","b"]
     * 输出：
     * 返回 4 ，输入数组的前4个字符应该是：["a","b","1","2"]。
     * 
     * 解释：
     * 由于字符 "a" 不重复，所以不会被压缩。"bbbbbbbbbbbb" 被 “b12” 替代。
     * 注意每个数字在数组中都有它自己的位置。
     * 
     * 提示：
     * 所有字符都有一个ASCII值在[35, 126]区间内。
     * 1 <= len(chars) <= 1000。
     */

    // @lc code=start
    public class Solution443
    {
        /// <summary>
        /// 三指针法
        /// </summary>
        /// <param name="chars"></param>
        /// <returns></returns>
        public int Compress(char[] chars)
        {
            //两个指针 read 和 write 分别标记读和写的位置
            //指针 anchor，指向当前读到连续字符串的起始位置。
            int anchor = 0, write = 0;
            for (int read = 0; read < chars.Length; read++)
            {
                if (read + 1 == chars.Length || chars[read + 1] != chars[read])
                {
                    chars[write++] = chars[anchor];
                    if (read > anchor)
                    {
                        foreach (char c in ("" + (read - anchor + 1)).ToCharArray())
                        {
                            chars[write++] = c;
                        }
                    }
                    anchor = read + 1;
                }
            }
            return write;
        }
    }
    // @lc code=end


}
