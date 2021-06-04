using System;
using System.Collections.Generic;
namespace CSharpConsoleApp.Solutions
{
    /*
     * @lc app=leetcode.cn id=401 lang=csharp
     *
     * [401] 二进制手表
     *
     * https://leetcode-cn.com/problems/binary-watch/description/
     *
     * Category	Difficulty	Likes	Dislikes
     * algorithms	Easy (53.83%)	251	-
     * Tags
     * backtracking | bit-manipulation
     * 
     * Companies
     * google
     * Total Accepted:    27.9K
     * Total Submissions: 51.8K
     * Testcase Example:  '1'
     *
     * 二进制手表顶部有 4 个 LED 代表 小时（0-11），底部的 6 个 LED 代表 分钟（0-59）。每个 LED 代表一个 0 或
     * 1，最低位在右侧。
     * 
     * 例如，下面的二进制手表读取 "3:25" 。
     * （图源：WikiMedia - Binary clock samui moon.jpg ，许可协议：Attribution-ShareAlike 3.0
     * Unported (CC BY-SA 3.0) ）
     * 
     * 给你一个整数 turnedOn ，表示当前亮着的 LED 的数量，返回二进制手表可以表示的所有可能时间。你可以 按任意顺序 返回答案。
     * 
     * 小时不会以零开头：
     * 例如，"01:00" 是无效的时间，正确的写法应该是 "1:00" 。
     * 
     * 分钟必须由两位数组成，可能会以零开头：
     * 例如，"10:2" 是无效的时间，正确的写法应该是 "10:02" 。
     * 
     * 
     * 示例 1：
     * 输入：turnedOn = 1
     * 输出：["0:01","0:02","0:04","0:08","0:16","0:32","1:00","2:00","4:00","8:00"]
     * 
     * 
     * 示例 2：
     * 输入：turnedOn = 9
     * 输出：[]
     * 
     * 解释：
     * 0 <= turnedOn <= 10
     */
    public class Solution401 : SolutionBase
    {
        /// <summary>
        /// 难度
        /// </summary>
        public override Difficulity GetDifficulity() { return Difficulity.Easy; }
        /// <summary>
        /// 关键字:
        /// </summary>
        public override string[] GetKeyWords() { return new string[] { }; }
        /// <summary>
        /// 标签：
        /// </summary>
        public override Tag[] GetTags() { return new Tag[] { Tag.Backtracking, Tag.BitManipulation, }; }

        public override bool Test(System.Diagnostics.Stopwatch sw)
        {
            bool isSuccess = true;
            int nums;
            IList<string> result; string[] checkResult;

            nums = 6;
            checkResult = new string[] { };
            result = ReadBinaryWatch(nums);
            isSuccess &= checkResult == result;
            Print("isSuccess = {0} | result = {1} | anticipated = {2}", isSuccess, GetArrayStr<string>(result), GetArrayStr<string>(checkResult));
            //    
            return isSuccess;
        }
        public IList<string> ReadBinaryWatch_My(int turnedOn)
        {
            List<string> list = new List<string>();
            if (turnedOn == 0)
            {
                list.Add("0:00");
                return list;
            }

            int hCountMax = 4;
            int mCountMax = 6;
            for (int i = 0; i <= mCountMax; i++)
            {
                int mCount = i;
                int hCount = turnedOn - i;

                if (hCount > hCountMax || i > turnedOn)
                    continue;

                for (int h = 0; h <= hCountMax; i++)
                {
                }
            }
            return null;
        }

        /// <summary>
        /// 10/10 cases passed (264 ms)
        /// Your runtime beats 81.82 % of csharp submissions
        /// Your memory usage beats 54.55 % of csharp submissions(31.1 MB)
        /// </summary>
        /// <param name="turnedOn"></param>
        /// <returns></returns>
        public IList<string> ReadBinaryWatch(int turnedOn)
        {
            List<string> list = new List<string>();
            for (int i = 0; i < 12; i++)
            {
                for (int j = 0; j < 60; j++)
                {
                    if (Count1(i) + Count1(j) == turnedOn)
                    {
                        list.Add(string.Format("{0}:{1:D2}", i, j));
                    }
                }
            }
            return list;
        }
        //作者：ljj666
        //链接：https://leetcode-cn.com/problems/binary-watch/solution/cjian-jian-dan-dan-de-ji-xing-dai-ma-jie-jue-wen-t/
        int Count1(int n)
        {
            int res = 0;
            while (n != 0)
            {
                n = n & (n - 1);
                res++;
            }
            return res;
        }

        
    }
}
