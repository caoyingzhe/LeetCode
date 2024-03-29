﻿using System;
namespace CSharpConsoleApp.Solutions
{
    /*
 * @lc app=leetcode.cn id=299 lang=csharp
 *
 * [299] 猜数字游戏
 *
 * https://leetcode-cn.com/problems/bulls-and-cows/description/
 *
 * Category	Difficulty	Likes	Dislikes
 * algorithms	Medium (50.16%)	135	-
 * Tags
 * hash-table
 * 
 * Companies
 * Unknown
 * 
 * Total Accepted:    27.2K
 * Total Submissions: 54.2K
 * Testcase Example:  '"1807"\n"7810"'
 *
 * 你在和朋友一起玩 猜数字（Bulls and Cows）游戏，该游戏规则如下：
 * 
 * 
 * 你写出一个秘密数字，并请朋友猜这个数字是多少。
 * 朋友每猜测一次，你就会给他一个提示，告诉他的猜测数字中有多少位属于数字和确切位置都猜对了（称为“Bulls”,
 * 公牛），有多少位属于数字猜对了但是位置不对（称为“Cows”, 奶牛）。
 * 朋友根据提示继续猜，直到猜出秘密数字。
 * 
 * 
 * 请写出一个根据秘密数字和朋友的猜测数返回提示的函数，返回字符串的格式为 xAyB ，x 和 y 都是数字，A 表示公牛，用 B 表示奶牛。
 * 
 * xA 表示有 x 位数字出现在秘密数字中，且位置都与秘密数字一致。
 * yB 表示有 y 位数字出现在秘密数字中，但位置与秘密数字不一致。
 * 
 * 请注意秘密数字和朋友的猜测数都可能含有重复数字，每位数字只能统计一次。
 * 
 * 
 * 示例 1:
 * 输入: secret = "1807", guess = "7810"
 * 输出: "1A3B"
 * 解释: 1 公牛和 3 奶牛。公牛是 8，奶牛是 0, 1 和 7。
 * 
 * 示例 2:
 * 输入: secret = "1123", guess = "0111"
 * 输出: "1A1B"
 * 解释: 朋友猜测数中的第一个 1 是公牛，第二个或第三个 1 可被视为奶牛。
 * 
 * 说明: 你可以假设秘密数字和朋友的猜测数都只包含数字，并且它们的长度永远相等。
 */

    // @lc code=start
    public class Solution299 : SolutionBase
    {
        /// <summary>
        /// 难度
        /// </summary>
        public override Difficulity GetDifficulity() { return Difficulity.Medium; }
        /// <summary>
        /// 关键字:
        /// </summary>
        public override string[] GetKeyWords() { return new string[] { "", }; }
        /// <summary>
        /// 标签：
        /// </summary>
        public override Tag[] GetTags() { return new Tag[] { Tag.HashTable }; }

        
        public override bool Test(System.Diagnostics.Stopwatch sw)
        {
            bool isSuccess = true;
            string secret, guess;
            string result, checkResult;

            secret = "1807"; guess = "7801";
            checkResult = "1A3B";
            result = GetHint(secret, guess);
            isSuccess &= IsSame(result, checkResult);
            PrintResult(isSuccess, (result).ToString(), (checkResult).ToString());

            return isSuccess;
        }

        //作者：yixingzhang
        //链接：https://leetcode-cn.com/problems/bulls-and-cows/solution/yi-ci-bian-li-1-ms-10000-by-zyxwmj-d5sa/
        /// <summary>
        /// 152/152 cases passed (68 ms)
        /// Your runtime beats 100 % of csharp submissions
        /// Your memory usage beats 100 % of csharp submissions(23.8 MB)
        /// </summary>
        /// <param name="secret"></param>
        /// <param name="guess"></param>
        /// <returns></returns>
        public string GetHint(string secret, string guess)
        {
            int[] array = new int[10]; //存储10个数字的出现次数
            int A = 0, B = 0;
            for (int i = 0; i < secret.Length; i++)
            {
                if (secret[i] == guess[i])
                {
                    A++;
                }
                else
                {
                    // 判断 guess 在 i 之前是否该数字
                    if (array[secret[i] - '0']++ < 0)
                    {
                        B++;
                    }
                    // 判断 secret 在 i 之前是否该数字
                    if (array[guess[i] - '0']-- > 0)
                    {
                        B++;
                    }
                }
            }
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            return sb.Append(A).Append('A').Append(B).Append('B').ToString();
        }
    }
    // @lc code=end
}
