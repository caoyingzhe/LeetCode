using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpConsoleApp.Solutions._0000
{
    /*
     * @lc app=leetcode.cn id=13 lang=csharp
     *
     * [13] 罗马数字转整数
     *
     * https://leetcode-cn.com/problems/roman-to-integer/description/
     *
     * Category	Difficulty	Likes	Dislikes
     * algorithms	Easy (62.41%)	1303	-
     * Tags
     * math | string
     * 
     * Companies
     * bloomberg | facebook | microsoft | uber | yahoo
     * 
     * Total Accepted:    365.5K
     * Total Submissions: 585.7K
     * Testcase Example:  '"III"'
     *
     * 罗马数字包含以下七种字符: I， V， X， L，C，D 和 M。
     * 
     * 
     * 字符          数值
     * I             1
     * V             5
     * X             10
     * L             50
     * C             100
     * D             500
     * M             1000
     * 
     * 例如， 罗马数字 2 写做 II ，即为两个并列的 1。12 写做 XII ，即为 X + II 。 27 写做  XXVII, 即为 XX + V +
     * II 。
     * 
     * 通常情况下，罗马数字中小的数字在大的数字的右边。但也存在特例，例如 4 不写做 IIII，而是 IV。数字 1 在数字 5 的左边，所表示的数等于大数
     * 5 减小数 1 得到的数值 4 。同样地，数字 9 表示为 IX。这个特殊的规则只适用于以下六种情况：
     * 
     * 
     * I 可以放在 V (5) 和 X (10) 的左边，来表示 4 和 9。
     * X 可以放在 L (50) 和 C (100) 的左边，来表示 40 和 90。 
     * C 可以放在 D (500) 和 M (1000) 的左边，来表示 400 和 900。
     * 
     * 
     * 给定一个罗马数字，将其转换成整数。输入确保在 1 到 3999 的范围内。
     * 
     * 
     * 
     * 示例 1:
     * 
     * 
     * 输入: "III"
     * 输出: 3
     * 
     * 示例 2:
     * 
     * 
     * 输入: "IV"
     * 输出: 4
     * 
     * 示例 3:
     * 
     * 
     * 输入: "IX"
     * 输出: 9
     * 
     * 示例 4:
     * 
     * 
     * 输入: "LVIII"
     * 输出: 58
     * 解释: L = 50, V= 5, III = 3.
     * 
     * 
     * 示例 5:
     * 
     * 
     * 输入: "MCMXCIV"
     * 输出: 1994
     * 解释: M = 1000, CM = 900, XC = 90, IV = 4.
     * 
     * 提示：
     * s 仅含字符 ('I', 'V', 'X', 'L', 'C', 'D', 'M')
     * 题目数据保证 s 是一个有效的罗马数字，且表示整数在范围 [1, 3999] 内
     * 题目所给测试用例皆符合罗马数字书写规则，不会出现跨位等情况。
     * IL 和 IM 这样的例子并不符合题目要求，49 应该写作 XLIX，999 应该写作 CMXCIX 。
     * 关于罗马数字的详尽书写规则，可以参考 罗马数字 - Mathematics 。
     * 
     * 
     */
    class Solution13 : SolutionBase
    {
        /// <summary>
        /// 难度
        /// </summary>
        public override Difficulity GetDifficulity() { return Difficulity.Hard; }
        /// <summary>
        /// 关键字:
        /// </summary>
        public override string[] GetKeyWords() { return new string[] { "binary-search | divide-and-conquer | sort | binary-indexed-tree | segment-tree", }; }
        /// <summary>
        /// 标签：
        /// </summary>
        public override Tag[] GetTags() { return new Tag[] { Tag.BinarySearch, Tag.DivideAndConquer, Tag.Sort, Tag.BinaryIndexedTree, Tag.SegmentTree }; }
        public override bool Test(System.Diagnostics.Stopwatch sw)
        {
            bool isSuccess = true;
            string s;

            s = "MCMXCIV";
            isSuccess &= RomanToInt(s) == 1994;

            s = "DCXXI";
            isSuccess &= RomanToInt(s) == 621;
            return isSuccess;
        }

        /// <summary>
        /// 3999/3999 cases passed (204 ms)
        /// Your runtime beats 6.38 % of csharp submissions
        /// Your memory usage beats 5.13 % of csharp submissions(26.6 MB)
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public int RomanToInt_MY(string s)
        {
            //string[] romaArr = new string[] { "I", "V", "X", "L", "C", "D", "M" }; //
            //int[] valArr = new int[]         { 1,   5,   10, 50,  100, 500, 1000 };
            string[] romaExArr = new string[] {
                "I", "II","III",              // Contain/End with I  [1,2,3]
                "V","IV", "VI", "VII", "VIII", // Contain          V  [5,4,6,7,8]
                "X", "IX", "XX", "XXX",        // Contain/End with X  [10,9,20,30]
                "L","XL","LX", "LXX","LXXX",   // Contain          L  [50,40,60,70,80]
                "C","XC","CC","CCC",           // Contain/End with C  [100,90,200,300]
                "D", "CD","DC","DCC", "DCCC",  // Contain          D  [500,400,600,700,800]
                "M","CM", "MM","MMM",          // Contain/End with M  [1000,900,2000,3000]
            };
            int[] valExArr = new int[] { 1,2,3,5, 4, 6,7,8,10, 9, 20,30,50, 40, 60,70,80,100,90,200,300,500, 400, 600,700,800,1000,900,2000,3000};

            Dictionary<string, int> map = new Dictionary<string, int>();
            for(int i=0; i<valExArr.Length; i++)
            {
                map.Add(romaExArr[i], valExArr[i]);
            }
            int result = 0;
            
            int n = s.Length;
            int index = 0;

            while (index <= n-1) //"MCMXCIV";  1994
            {
                string last4Char = index < n-4 ? s.Substring(index, 4) : s.Substring(index, n - index);
                for (int i = romaExArr.Length -1; i>=0; i--)
                {
                    string key = romaExArr[i];
                    if (last4Char.StartsWith(key))
                    {
                        result += map[key];
                        index += key.Length;
                        Print("Find {0} = {1} in {2} index={3}", key, map[key], last4Char, index);
                        break;
                    }
                }
            }
            return result;
        }

        public int RomanToInt_Fast(string s)
        {
            s = s.Replace("IV", "a");
            s = s.Replace("IX", "b");
            s = s.Replace("XL", "c");
            s = s.Replace("XC", "d");
            s = s.Replace("CD", "e");
            s = s.Replace("CM", "f");

            int result = 0;
            for (int i = 0; i < s.Length; i++)
            {
                result += which(s[i]);
            }
            return result;
        }

        public int which(char ch)
        {
            switch (ch)
            {
                case 'I': return 1;
                case 'V': return 5;
                case 'X': return 10;
                case 'L': return 50;
                case 'C': return 100;
                case 'D': return 500;
                case 'M': return 1000;
                case 'a': return 4;
                case 'b': return 9;
                case 'c': return 40;
                case 'd': return 90;
                case 'e': return 400;
                case 'f': return 900;
            }
            return 0;
        }


        //作者：tommying
        //链接：https://leetcode-cn.com/problems/roman-to-integer/solution/ji-lu-yi-xia-by-tommying-3dwc/
        public int RomanToInt(string s)
        {
            int n = 0;
            int i = 0;

            int len = s.Length;
            while (i < s.Length)
            {
                switch (s[i])
                {
                    case 'M':
                        n += 1000; i++; break;
                    case 'D':
                        n += 500; i++; break;
                    case 'C':
                        if (i + 1 == len) {
                            n += 100; i++; break;
                        } if (s[i + 1] == 'M') {
                            n += 900; i += 2; break;
                        } else if (s[i + 1] == 'D') {
                            n += 400; i += 2; break;
                        } else {
                            n += 100; i++; break;
                        }
                    case 'L':
                        n += 50; i++; break;
                    case 'X':
                        if (i + 1 == len) {
                            n += 10; i++; break;
                        } if (s[i + 1] == 'C') {
                            n += 90; i += 2; break;
                        } else if (s[i + 1] == 'L') {
                            n += 40; i += 2; break;
                        } else {
                            n += 10; i++; break;
                        }
                    case 'V':
                        n += 5; i++; break;
                    case 'I':
                        if (i + 1 == len) {
                            n++; i++; break;
                        } else if (s[i + 1] == 'X'){
                            n += 9;i += 2;break;
                        } else if (s[i + 1] == 'V') {
                            n += 4;i += 2;break;
                        } else {
                            n++; i++;break;
                        }
                }
            }
            return n;
        }
    }
}
