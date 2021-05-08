using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpConsoleApp.Solutions
{
    /// <summary>
    /// 加一
    /// </summary>
    class Solution66 : SolutionBase
    {
        /// <summary>
        /// 难易度:
        /// </summary>
        public override Difficulity GetDifficulity() { return Difficulity.Easy; }
        /// <summary>
        /// 关键字:
        /// </summary>
        public override string[] GetKeyWords() { return new string[] { "非常无聊" }; }
        /// <summary>
        /// 标签： 图
        /// </summary>
        public override Tag[] GetTags() { return new Tag[] { Tag.Array}; }

        public override bool Test(System.Diagnostics.Stopwatch sw)
        {
            bool isSuccess = true;

            int[] digits = new int[] { 9, 9, 9 };
            int[] checkresult = new int[] { 1, 0, 0 ,0 };
            int[] result = PlusOne(digits);
            isSuccess &= string.Join(",", checkresult) == string.Join(",", result.ToArray());
            Print("isSuccess = " + isSuccess + " | Anticipated = " + string.Join(",", checkresult) + " | Result = " + string.Join(",", result.ToArray()));
            return isSuccess;
        }
        public int[] PlusOne(int[] digits)
        {
            List<int> result = new List<int>();

            bool isOver10 = false;
            int add = 1;
            for(int i= digits.Length-1; i >=0; i--)
            {
                if (isOver10)
                {
                    add = 1;
                }
                if (digits[i] + add == 10)
                {
                    result.Add(0);
                    isOver10 = true;
                }
                else
                {
                    result.Add(digits[i] + add);
                    isOver10 = false;
                }
                add = 0;
            }
            if (isOver10)
                result.Add(1);
            result.Reverse();
            return result.ToArray();
        }
    }
}
