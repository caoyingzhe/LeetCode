using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace CSharpConsoleApp.Solutions
{
    /// <summary>
    /// 12. Integer to Roman  [Medium]
    /// 
    /// Roman numerals are represented by seven different symbols: I, V, X, L, C, D and M.
    /// 
    /// Symbol Value
    /// I             1
    /// V             5
    /// X             10
    /// L             50
    /// C             100
    /// D             500
    /// M             1000
    /// For example, 
    ///     2 is written as II in Roman numeral, just two one's added together. 
    ///     12 is written as XII, which is simply X + II. 
    ///     The number 27 is written as XXVII, which is XX + V + II.
    /// 
    /// Roman numerals are usually written largest to smallest from left to right.
    /// However, the numeral for four is not IIII. Instead, the number four is written as IV.
    /// Because the one is before the five we subtract it making four. 
    /// The same principle applies to the number nine, which is written as IX.
    /// There are six instances where subtraction is used:
    /// 
    /// I can be placed before V (5) and X(10) to make 4 and 9. 
    /// X can be placed before L(50) and C(100) to make 40 and 90. 
    /// C can be placed before D(500) and M(1000) to make 400 and 900.
    /// Given an integer, convert it to a roman numeral.
    /// 
    /// Example 1:
    /// Input: num = 3
    /// Output: "III"
    /// 
    /// Example 2:
    /// Input: num = 4
    /// Output: "IV"
    /// 
    /// Example 3:
    /// Input: num = 9
    /// Output: "IX"
    /// 
    /// Example 4:
    /// Input: num = 58
    /// Output: "LVIII"
    /// Explanation: L = 50, V = 5, III = 3.
    /// 
    /// Example 5:
    /// Input: num = 1994
    /// Output: "MCMXCIV"
    /// Explanation: M = 1000, CM = 900, XC = 90 and IV = 4.
    /// 
    /// Constraints: 1 <= num <= 3999
    /// </summary>
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

        public override bool Test(Stopwatch sw)
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
