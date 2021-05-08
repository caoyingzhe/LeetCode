using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpConsoleApp.Solutions
{
    /// <summary>
    /// 分数到小数
    /// </summary>
    class Solution166 : SolutionBase
    {
        /// <summary>
        /// 难度
        /// </summary>
        public override Difficulity GetDifficulity() { return Difficulity.Medium; }
        /// <summary>
        /// 关键字:
        /// </summary>
        public override string[] GetKeyWords() { return new string[] { "二分法搜索" }; }
        /// <summary>
        /// 标签： 
        /// </summary>
        public override Tag[] GetTags() { return new Tag[] { Tag.Array, Tag.BinarySearch }; }

        public override bool Test(System.Diagnostics.Stopwatch sw)
        {
            List<int> result = new List<int>();
            int[] checkResult;
            bool isSuccess = true;

            //Print("isSuccess = {0} | result= {1} | resultChecked = {2}", isSuccess, string.Join(",", result), string.Join(",", checkResult));


            isSuccess &= FractionToDecimal(1, 2) == "0.5";

            return isSuccess;
        }

        public string FractionToDecimal(int numerator, int denominator)
        {
            if (numerator == 0)
            {
                return "0";
            }
            StringBuilder fraction = new StringBuilder();
            //不同号加上负号
            if (numerator < 0 ^ denominator < 0)
            {
                fraction.Append("-");
            }

            // Convert to Long or else abs(-2147483648) overflows
            long dividend = Math.Abs((long)numerator);
            long divisor = Math.Abs((long)denominator);
            //添加整数部分
            fraction.Append(dividend / divisor);
            //计算小数部分
            long remainder = dividend % divisor;
            if (remainder == 0)
            {
                return fraction.ToString();  //整除的情况，直接返回
            }
            //非整除，先添加小数点。
            fraction.Append(".");
            //除法余数对应的小数的除法，用于保存除法计算结果中循环的小数的位置
            Dictionary<long, int> modDict = new Dictionary<long, int>();

            while(remainder != 0)
            {
                if(modDict.ContainsKey(remainder))
                {
                    int insertPos = modDict[remainder];
                    fraction.Insert(insertPos, "(");
                    fraction.Append(")");
                    break;
                }
                else
                {
                    modDict.Add(remainder, fraction.Length); //记住当前余数+对应的小数位置。
                    remainder *= 10;
                    fraction.Append(remainder / divisor);    //添加当前的小数。
                    remainder %= divisor;                    //继续求余数
                }
            }

            return fraction.ToString();
        }

    }
}
