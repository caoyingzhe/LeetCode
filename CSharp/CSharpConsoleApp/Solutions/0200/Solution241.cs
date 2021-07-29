using System;
using System.Collections.Generic;
namespace CSharpConsoleApp.Solutions
{
    /*
     * @lc app=leetcode.cn id=241 lang=csharp
     *
     * [241] 为运算表达式设计优先级
     *
     * https://leetcode-cn.com/problems/different-ways-to-add-parentheses/description/
     *
     * Tags
     * divide-and-conquer
     * 
     * Companies
     * Unknown
     * 
     * Total Accepted:    27.7K
     * Total Submissions: 37.6K
     * Testcase Example:  '"2-1-1"'
     *
     * 给定一个含有数字和运算符的字符串，为表达式添加括号，改变其运算优先级以求出不同的结果。你需要给出所有可能的组合的结果。有效的运算符号包含 +, - 以及
     * * 。
     * 
     * 示例 1:
     * 
     * 输入: "2-1-1"
     * 输出: [0, 2]
     * 解释: 
     * ((2-1)-1) = 0 
     * (2-(1-1)) = 2
     * 
     * 示例 2:
     * 
     * 输入: "2*3-4*5"
     * 输出: [-34, -14, -10, -10, 10]
     * 解释: 
     * (2*(3-(4*5))) = -34 
     * ((2*3)-(4*5)) = -14 
     * ((2*(3-4))*5) = -10 
     * (2*((3-4)*5)) = -10 
     * (((2*3)-4)*5) = 10
     * 
     */

    // @lc code=start
    public class Solution241 : SolutionBase
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
        public override Tag[] GetTags() { return new Tag[] { Tag.DivideAndConquer }; }

        
        public override bool Test(System.Diagnostics.Stopwatch sw)
        {
            bool isSuccess = true;
            string root;
            IList<int> result, checkResult;

            root = "2-1-1";
            checkResult = new int[] { 0, 2};
            result = DiffWaysToCompute(root);
            isSuccess &= IsListSame(result, checkResult, true);
            PrintResult(isSuccess, GetArrayStr(result), GetArrayStr(checkResult));

            return isSuccess;
        }

        /// 作者：suns - u
        /// 链接：https://leetcode-cn.com/problems/different-ways-to-add-parentheses/solution/fen-zhi-by-suns-u-029f/
        char[] cArr;
        int len;
        List<int> res = new List<int>();

        /// <summary>
        /// 25/25 cases passed (260 ms)
        /// Your runtime beats 92.86 % of csharp submissions
        /// Your memory usage beats 71.43 % of csharp submissions(31.1 MB)
        /// </summary>
        /// <param name="expression"></param>
        /// <returns></returns>
        public IList<int> DiffWaysToCompute(string expression)
        {
            this.cArr = expression.ToCharArray();
            this.len = expression.Length;
            return dfsHelper(0, len - 1);
        }

        private List<int> dfsHelper(int l, int r)
        {
            int idx = l, num = cArr[idx] - '0';
            List<int> nArr = new List<int>();
            while ((idx + 1 <= r) && char.IsDigit(cArr[idx + 1]))
            {
                idx++;
                num = num * 10 + (cArr[idx] - '0');
            }
            if (idx == r) { nArr.Add(num); return nArr; }
            for (int i = idx + 1; i <= r; i++)
            {
                if (char.IsDigit(cArr[i])) continue;
                List<int> left = this.dfsHelper(l, i - 1);
                List<int> right = this.dfsHelper(i + 1, r);
                foreach (int val_l in left)
                {
                    foreach (int val_r in right)
                    {
                        char opt = cArr[i]; int output = 0;
                        if (opt == '+') output = val_l + val_r;
                        else if (opt == '-') output = val_l - val_r;
                        else if (opt == '*') output = val_l * val_r;
                        nArr.Add(output);
                    }
                }
            }
            return nArr;
        }
    }
    // @lc code=end


}
