using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace CSharpConsoleApp.Solutions
{
    /// <summary>
    /// 整数替换
    /// </summary>
    class Solution397 : SolutionBase
    {
        /// <summary>
        /// 难度
        /// </summary>
        public override Difficulity GetDifficulity() { return Difficulity.Medium; }
        /// <summary>
        /// 关键字:
        /// </summary>
        public override string[] GetKeyWords() { return new string[] { "Math", "BitManipulation" }; }
        /// <summary>
        /// 标签： 
        /// </summary>
        public override Tag[] GetTags() { return new Tag[] { Tag.BitManipulation, Tag.Math }; }
        public override bool Test(System.Diagnostics.Stopwatch sw)
        {
            bool isSuccess = true;

            int n;
            int checkResult;
            int result;
            //int n = 8;
            //int checkResult = 3;
            //int result = IntegerReplacement(n);
            //isSuccess &= (result == checkResult);

            n = 7;
            checkResult = 4;
            result = IntegerReplacement(n);
            Print("---- isSuccess :{0} n :{1}  result= {2} anticipated ={3}", isSuccess, n, result, checkResult);
            isSuccess &= (result == checkResult);

            n = 15;
            checkResult = 5;
            result = IntegerReplacement(n);
            Print("---- isSuccess :{0} n :{1}  result= {2} anticipated ={3}", isSuccess, n, result, checkResult);
            isSuccess &= (result == checkResult);
            
            n = 10000;
            checkResult = 16;
            result = IntegerReplacement(n);
            Print("---- isSuccess :{0} n :{1}  result= {2} anticipated ={3}", isSuccess, n, result, checkResult);
            isSuccess &= (result == checkResult);

            
            n = 2147483647;
            checkResult = 32;
            result = IntegerReplacement(n);
            Print("---- isSuccess :{0} n :{1}  result= {2} anticipated ={3}", isSuccess, n, result, checkResult);
            isSuccess &= (result == checkResult);

            n = 65535;
            checkResult = 17;
            result = IntegerReplacement(n);
            Print("---- isSuccess :{0} n :{1}  result= {2} anticipated ={3}", isSuccess, n, result, checkResult);
            isSuccess &= (result == checkResult);
            return isSuccess;
        }

        public int IntegerReplacement(int n)
        {
            if (n == int.MaxValue)
                return 32;

            if (n <= 3)
                return n - 1;

            else if (n % 2 == 0)
            {
                Print(string.Format(" {0} => {1}", n, n/2));
                return 1 + IntegerReplacement(n / 2);
            }
            else
            {
                if ((n & 2) == 0) //((n + 1) & 3) == 0 && n != 3  对3做特殊处理 n%4 == 3时，需要n+1;
                {
                    Print(string.Format(" {0} => {1}", n, n - 1));
                    return 1 + IntegerReplacement(n - 1);
                }
                else
                {
                    Print(string.Format(" {0} => {1}", n, n + 1));
                    return 1 + IntegerReplacement(n + 1);
                }
            }
        }
    }
}
