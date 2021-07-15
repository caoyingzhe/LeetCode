using System;
using System.Collections.Generic;
using System.Text;
namespace CSharpConsoleApp.Solutions
{
    /*
 * @lc app=leetcode.cn id=301 lang=csharp
 *
 * [301] 删除无效的括号
 *
 * https://leetcode-cn.com/problems/remove-invalid-parentheses/description/
 *
 * Category	Difficulty	Likes	Dislikes
 * algorithms	Hard (51.53%)	457	-
 * Tags
 * depth-first-search | breadth-first-search
 * 
 * Companies
 * facebook
 * 
 * Total Accepted:    27.1K
 * Total Submissions: 52.6K
 * Testcase Example:  '"()())()"'
 *
 * 给你一个由若干括号和字母组成的字符串 s ，删除最小数量的无效括号，使得输入的字符串有效。
 * 返回所有可能的结果。答案可以按 任意顺序 返回。
 * 
 * 
 * 示例 1：
 * 输入：s = "()())()"
 * 输出：["(())()","()()()"]
 * 
 * 
 * 示例 2：
 * 输入：s = "(a)())()"
 * 输出：["(a())()","(a)()()"]
 * 
 * 
 * 示例 3：
 * 输入：s = ")("
 * 输出：[""]
 * 
 * 
 * 提示：
 * 1 <= s.length <= 25
 * s 由小写英文字母以及括号 '(' 和 ')' 组成
 * s 中至多含 20 个括号
 */

    // @lc code=start
    public class Solution301 : SolutionBase
    {
        /// <summary>
        /// 难度
        /// </summary>
        public override Difficulity GetDifficulity() { return Difficulity.Hard; }
        /// <summary>
        /// 关键字:
        /// </summary>
        public override string[] GetKeyWords() { return new string[] { }; }
        /// <summary>
        /// 标签：hash-table | two-pointers | binary-search | sort
        /// </summary>
        public override Tag[] GetTags() { return new Tag[] { Tag.DepthFirstSearch, Tag.BreadthFirstSearch }; }

        public override bool Test(System.Diagnostics.Stopwatch sw)
        {
            bool isSuccess = true;
            string s;
            IList<string> result, checkResult;

            s = "()())()";
            checkResult = new string[] { "(())()", "()()()" } ;
            result = RemoveInvalidParentheses(s);
            isSuccess &= IsListSame(result, checkResult, true);
            Print("isSuccess = {0} result = {1} | checkResult = {2}", isSuccess, GetArrayStr(result), GetArrayStr(checkResult));

            s = "(a)())()";
            checkResult = new string[] { "(a())()", "(a)()()" };
            result = RemoveInvalidParentheses(s);
            isSuccess &= IsListSame(result, checkResult, true);
            Print("isSuccess = {0} result = {1} | checkResult = {2}", isSuccess, GetArrayStr(result), GetArrayStr(checkResult));

            s = ")(";
            checkResult = new string[] { "" };
            result = RemoveInvalidParentheses(s);
            isSuccess &= IsListSame(result, checkResult, true);
            Print("isSuccess = {0} result = {1} | checkResult = {2}", isSuccess, GetArrayStr(result), GetArrayStr(checkResult));

            return isSuccess;
        }


        private int n;
        private char[] charArr;
        private HashSet<string> validExpressions = new HashSet<string>();

        /// <summary>
        /// 作者：LeetCode
        /// 链接：https://leetcode-cn.com/problems/remove-invalid-parentheses/solution/shan-chu-wu-xiao-de-gua-hao-by-leetcode/
        ///
        /// 1. 如果当前遍历到的左括号的数目严格小于右括号的数目则表达式无效（这一点非常重要）。
        ///    因此，我们可以遍历一次输入字符串，统计「左括号」和「右括号」出现的次数
        /// 2. 删除不同位置的左括号可能得到相同的结果,。所以须要使用哈希表去重。
        /// 3. 回溯算法里面采用了「剪枝」操作，复杂度分析已经非常复杂，
        ///
        /// 125/125 cases passed (280 ms)
        /// Your runtime beats 78.95 % of csharp submissions
        /// Your memory usage beats 89.47 % of csharp submissions(31.3 MB)
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public IList<string> RemoveInvalidParentheses(string s)
        {
            this.n = s.Length;
            this.charArr = s.ToCharArray();
            this.validExpressions.Clear();

            // 第 1 步：遍历一次，计算多余的左右括号
            int lRemove = 0;
            int rRemove = 0;
            for (int i = 0; i < n; i++)
            {
                if (charArr[i] == '(')
                {
                    lRemove++;
                }
                else if (charArr[i] == ')')
                {
                    // 遇到右括号的时候，须要根据已经存在的左括号数量决定
                    if (lRemove == 0)
                    {
                        rRemove++;
                    }
                    if (lRemove > 0)
                    {
                        // 关键：一个右括号出现可以抵销之前遇到的左括号
                        lRemove--;
                    }
                }
            }

            // 第 2 步：回溯算法，尝试每一种可能的删除操作
            StringBuilder path = new StringBuilder();
            DFS(0, 0, 0, lRemove, rRemove, path);
            return new List<string>(this.validExpressions);
        }

        /// <summary>
        /// DFS
        /// </summary>
        /// <param name="i">当前遍历到的下标</param>
        /// <param name="lCount">已经遍历到的左括号的个数</param>
        /// <param name="rCount">已经遍历到的右括号的个数</param>
        /// <param name="lRemove">最少应该删除的左括号的个数 （值不变）</param>
        /// <param name="rRemove">最少应该删除的右括号的个数 （值不变）</param>
        /// <param name="path">一个可能的结果（临时，可变）</param>
        private void DFS(int i, int lCount, int rCount, int lRemove, int rRemove, StringBuilder path)
        {
            if (i == n)
            {
                if (lRemove == 0 && rRemove == 0)
                {
                    validExpressions.Add(path.ToString());
                }
                return;
            }

            char ch = charArr[i];
            // 可能的操作 1：删除当前遍历到的字符
            if (ch == '(' && lRemove > 0)
            {
                // 由于 leftRemove > 0，并且当前遇到的是左括号，因此可以尝试删除当前遇到的左括号
                DFS(i + 1, lCount, rCount, lRemove - 1, rRemove, path);
            }
            if (ch == ')' && rRemove > 0)
            {
                // 由于 rightRemove > 0，并且当前遇到的是右括号，因此可以尝试删除当前遇到的右括号
                DFS(i + 1, lCount, rCount, lRemove, rRemove - 1, path);
            }

            // 可能的操作 2：保留当前遍历到的字符
            path.Append(ch);
            if (ch != '(' && ch != ')')
            {
                // 如果不是括号，继续深度优先遍历
                DFS(i + 1, lCount, rCount, lRemove, rRemove, path);
            }
            else if (ch == '(')
            {
                // 考虑左括号
                DFS(i + 1, lCount + 1, rCount, lRemove, rRemove, path);
            }
            else if (rCount < lCount)
            {
                // 考虑右括号
                DFS(i + 1, lCount, rCount + 1, lRemove, rRemove, path);
            }
            path.Remove(path.Length - 1, 1);
        }
    }
    // @lc code=end


}
