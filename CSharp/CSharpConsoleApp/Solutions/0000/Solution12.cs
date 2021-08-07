using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace CSharpConsoleApp.Solutions
{
    /*
    * @lc app=leetcode.cn id=3 lang=csharp
    * 
    * [12]. 整数转罗马数字  >>> Integer to Roman  [Medium]
    * 
    * Category	Difficulty	Likes	Dislikes
    * algorithms	Medium (64.93%)	529	-
    * Tags
    * math | string
    * 
    * Companies
    * twitter
    * 
    * 罗马数字包含以下七种字符： I， V， X， L，C，D 和 M。
    * >>> Roman numerals are represented by seven different symbols: I, V, X, L, C, D and M.
    * 
    * Symbol Value
    * I             1
    * V             5
    * X             10
    * L             50
    * C             100
    * D             500
    * M             1000
    * 例如， >>> For example, 
    *     罗马数字 2 写做 II ，即为两个并列的 1。
    *     >>> 2 is written as II in Roman numeral, just two one's added together. 
    *     
    *     12 写做 XII ，即为 X + II 。
    *     >>> 12 is written as XII, which is simply X + II. 
    *     
    *     27 写做  XXVII, 即为 XX + V + II 。
    *     >>> The number 27 is written as XXVII, which is XX + V + II.
    * 
    * 通常情况下，罗马数字中小的数字在大的数字的右边。
    * 但也存在特例，例如 4 不写做 IIII，而是 IV。数字 1 在数字 5 的左边，
    * 所表示的数等于大数 5 减小数 1 得到的数值 4 。
    * 同样地，数字 9 表示为 IX。
    * 这个特殊的规则只适用于以下六种情况：
    * 
    * >>> Roman numerals are usually written largest to smallest from left to right.
    * >>> However, the numeral for four is not IIII. Instead, the number four is written as IV.
    * >>> Because the one is before the five we subtract it making four. 
    * >>> The same principle applies to the number nine, which is written as IX.
    * >>> There are six instances where subtraction is used:
    * 
    * I 可以放在 V (5) 和 X (10) 的左边，来表示 4 和 9。
    * >>> I can be placed before V (5) and X(10) to make 4 and 9. 
    * 
    * X 可以放在 L (50) 和 C (100) 的左边，来表示 40 和 90。 
    * >>> X can be placed before L(50) and C(100) to make 40 and 90. 
    * 
    * C 可以放在 D (500) 和 M (1000) 的左边，来表示 400 和 900。
    * >>> C can be placed before D(500) and M(1000) to make 400 and 900.
    * 
    * 给定一个整数，将其转为罗马数字。输入确保在 1 到 3999 的范围内。
    * >>> Given an integer, convert it to a roman numeral.
    * 
    * Example 1:
    * Input: num = 3
    * Output: "III"
    * 
    * Example 2:
    * Input: num = 4
    * Output: "IV"
    * 
    * Example 3:
    * Input: num = 9
    * Output: "IX"
    * 
    * Example 4:
    * Input: num = 58
    * Output: "LVIII"
    * Explanation: L = 50, V = 5, III = 3.
    * 
    * Example 5:
    * Input: num = 1994
    * Output: "MCMXCIV"
    * Explanation: M = 1000, CM = 900, XC = 90 and IV = 4.
    * 
    * 提示：Constraints: 
    * 1 <= num <= 3999
    */
    public class Solution12 : SolutionBase
    {
        /// <summary>
        /// 难度
        /// </summary>
        public override Difficulity GetDifficulity() { return Difficulity.Medium; }
        /// <summary>
        /// 关键字:
        /// </summary>
        public override string[] GetKeyWords() { return new string[] { "HashTable" }; }
        /// <summary>
        /// 标签： 
        /// </summary>
        public override Tag[] GetTags() { return new Tag[] { Tag.HashTable }; }

        public override bool Test(System.Diagnostics.Stopwatch sw)
        {
            int num = 0;
            string checkResult = "";
            bool isSuccess = true;
            string result;

            num = 3;
            checkResult = "III";
            result = IntToRoman(num);
            isSuccess &= result == checkResult;

            num = 4;
            checkResult = "IV";
            result = IntToRoman(num);
            isSuccess &= result == checkResult;

            num = 9;
            checkResult = "IX";
            result = IntToRoman(num);
            isSuccess &= result == checkResult;

            num = 58;
            checkResult = "LVIII";
            result = IntToRoman(num);
            isSuccess &= result == checkResult;

            num = 1994;
            checkResult = "MCMXCIV";
            result = IntToRoman(num);
            isSuccess &= result == checkResult;
            System.Diagnostics.Debug.Print("isSuccess = {3} | Convert {0} to {1} | anticipated : {2} | ", num, result, checkResult, isSuccess);
            return isSuccess;
        }

        static List<int> nums = new List<int>(new int[] { 1, 5, 10, 50, 100, 500, 1000 });
        static string numRomStr = "IVXLCDM";

        //20 XX
        //30 XXX
        //40 XL
        //50 L
        //60 LX
        //70 LXX
        //80 LXXX
        //90 XC
        //100 C
        //110 CX
        //24 XX IV
        //27 XX + VII

        public string IntToRoman(int num)
        {
            string result = GetNumberRoma(nums.Count - 1, num);
            return result;
        }

        //Output: "MCMXCIV"
        /// Explanation: M = 1000, CM = 900, XC = 90 and IV = 4.
        string GetNumberRoma(int level, int num)
        {
            string str = "";
            int levelValue = nums[level];
            int quotient = num / levelValue;
            int mod = num % levelValue;

            if (quotient > 0)
            {
                if (quotient >= 5) ///5~9
                {
                    //9 IX
                    //5,6,7,8 V,VI,VII,VIII
                    quotient -= 5;
                    if (quotient == 4)
                    {
                        str += numRomStr[level];
                        str += numRomStr[level + 2];
                    }
                    else
                    {
                        str += numRomStr[level + 1];
                        for (int j = 0; j < quotient; j++)
                        {
                            str += numRomStr[level];
                        }
                    }
                }
                else //1~4
                {
                    //4 IV
                    //1,2,3, I,II,III,
                    if (quotient == 4)
                    {
                        str += numRomStr[level];
                        str += numRomStr[level + 1];
                    }
                    else
                    {
                        for (int j = 0; j < quotient; j++)
                        {
                            str += numRomStr[level];
                        }
                    }
                }
            }
            if (mod > 0)
            {
                str += GetNumberRoma(level - 2, mod);
            }
            return str;
        }
    }
}
