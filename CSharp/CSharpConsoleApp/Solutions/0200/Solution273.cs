using System;
namespace CSharpConsoleApp.Solutions
{
    /*
     * @lc app=leetcode.cn id=273 lang=csharp
     *
     * [273] 整数转换英文表示
     *
     * https://leetcode-cn.com/problems/integer-to-english-words/description/
     *
     * Category	Difficulty	Likes	Dislikes
     * algorithms	Hard (30.56%)	157	-
     * Tags
     * math | string
     * 
     * Companies
     * facebook | microsoft
     * Total Accepted:    11K
     * Total Submissions: 35.9K
     * Testcase Example:  '123'
     *
     * 将非负整数 num 转换为其对应的英文表示。
     * 
     * 
     * 示例 1：
     * 输入：num = 123
     * 输出："One Hundred Twenty Three"
     * 
     * 
     * 示例 2：
     * 输入：num = 12345
     * 输出："Twelve Thousand Three Hundred Forty Five"
     * 
     * 
     * 示例 3：
     * 输入：num = 1234567
     * 输出："One Million Two Hundred Thirty Four Thousand Five Hundred Sixty Seven"
     * 
     * 
     * 示例 4：
     * 输入：num = 1234567891
     * 输出："One Billion Two Hundred Thirty Four Million Five Hundred Sixty Seven
     * Thousand Eight Hundred Ninety One"
     * 
     * 
     * 提示：
     * 0 <= num <= 2^31 - 1
     */

    // @lc code=start
    public class Solution273 : SolutionBase
    {
        /// <summary>
        /// 难度
        /// </summary>
        public override Difficulity GetDifficulity() { return Difficulity.Hard; }
        /// <summary>
        /// 关键字:
        /// </summary>
        public override string[] GetKeyWords() { return new string[] { "" }; }
        /// <summary>
        /// 标签：
        /// </summary>
        public override Tag[] GetTags() { return new Tag[] { Tag.Math, Tag.String, }; }

        public override bool Test(System.Diagnostics.Stopwatch sw)
        {
            bool isSuccess = true;
            int nums;
            string result, checkResult;

            nums = 123;
            checkResult = "One Hundred Twenty Three";
            result = NumberToWords(nums);
            isSuccess &= IsSame(result, checkResult);
            PrintResult(isSuccess, (result), (checkResult));

            nums = 12345;
            checkResult = "Twelve Thousand Three Hundred Forty Five";
            result = NumberToWords(nums);
            isSuccess &= IsSame(result, checkResult);
            PrintResult(isSuccess, (result), (checkResult));

            nums = 1234567;
            checkResult = "One Million Two Hundred Thirty Four Thousand Five Hundred Sixty Seven";
            result = NumberToWords(nums);
            isSuccess &= IsSame(result, checkResult);
            PrintResult(isSuccess, (result), (checkResult));

            nums = 1234567891;
            checkResult = "One Billion Two Hundred Thirty Four Million Five Hundred Sixty Seven Thousand Eight Hundred Ninety One";
            result = NumberToWords(nums);
            isSuccess &= IsSame(result, checkResult);
            PrintResult(isSuccess, (result), (checkResult));

            return isSuccess;
        }

        /// <summary>
        /// 作者：LeetCode
        /// 链接：https://leetcode-cn.com/problems/integer-to-english-words/solution/zheng-shu-zhuan-huan-ying-wen-biao-shi-by-leetcode/
        /// 601/601 cases passed (92 ms)
        /// Your runtime beats 66.67 % of csharp submissions
        /// Your memory usage beats 100 % of csharp submissions(23.2 MB)
        /// </summary>
        /// <param name="num"></param>
        /// <returns></returns>
        public string NumberToWords(int num)
        {
            if (num == 0)
                return "Zero";
            //10^9
            int billion = num / 1000000000;
            //10^6
            int million = (num - billion * 1000000000) / 1000000;
            //10^3
            int thousand = (num - billion * 1000000000 - million * 1000000) / 1000;
            //<10^3
            int rest = num - billion * 1000000000 - million * 1000000 - thousand * 1000;

            String result = "";
            if (billion != 0)
                result = three(billion) + " Billion";
            if (million != 0)
            {
                if (!string.IsNullOrEmpty(result))
                    result += " ";
                result += three(million) + " Million";
            }
            if (thousand != 0)
            {
                if (!string.IsNullOrEmpty(result))
                    result += " ";
                result += three(thousand) + " Thousand";
            }
            if (rest != 0)
            {
                if (!string.IsNullOrEmpty(result))
                    result += " ";
                result += three(rest);
            }
            return result;
        }

        public String twoLessThan20(int num)
        {
            switch (num)
            {
                case 10: return "Ten";
                case 11: return "Eleven";
                case 12: return "Twelve";
                case 13: return "Thirteen";
                case 14: return "Fourteen";
                case 15: return "Fifteen";
                case 16: return "Sixteen";
                case 17: return "Seventeen";
                case 18: return "Eighteen";
                case 19: return "Nineteen";
            }
            return "";
        }

        public String ten(int num)
        {
            switch (num)
            {
                case 2: return "Twenty";
                case 3: return "Thirty";
                case 4: return "Forty";
                case 5: return "Fifty";
                case 6: return "Sixty";
                case 7: return "Seventy";
                case 8: return "Eighty";
                case 9: return "Ninety";
            }
            return "";
        }

        public String three(int num)
        {
            int hundred = num / 100;
            int rest = num - hundred * 100;
            String res = "";
            if (hundred * rest != 0)
                res = one(hundred) + " Hundred " + two(rest);
            else if ((hundred == 0) && (rest != 0))
                res = two(rest);
            else if ((hundred != 0) && (rest == 0))
                res = one(hundred) + " Hundred";
            return res;
        }

        public String two(int num)
        {
            if (num == 0)
                return "";
            else if (num < 10)
                return one(num);
            else if (num < 20)
                return twoLessThan20(num);
            else
            {
                int tenner = num / 10;
                int rest = num - tenner * 10;
                if (rest != 0)
                    return ten(tenner) + " " + one(rest);
                else
                    return ten(tenner);
            }
        }

        public String one(int num)
        {
            switch (num)
            {
                case 1: return "One";
                case 2: return "Two";
                case 3: return "Three";
                case 4: return "Four";
                case 5: return "Five";
                case 6: return "Six";
                case 7: return "Seven";
                case 8: return "Eight";
                case 9: return "Nine";
            }
            return "";
        }

        public String TenPower3X(int powerLevel = 1)
        {
            switch(powerLevel)
            {
                case 1: return "Thousand";
                case 2: return "Million";
                case 3: return "Billion";
            }
            return "unknow";
        }

        //作者：LeetCode
        //链接：https://leetcode-cn.com/problems/integer-to-english-words/solution/zheng-shu-zhuan-huan-ying-wen-biao-shi-by-leetcode/
    }
    // @lc code=end
}
