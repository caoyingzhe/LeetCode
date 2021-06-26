using System;
using System.Collections.Generic;
namespace CSharpConsoleApp.Solutions
{
    /*
     * @lc app=leetcode.cn id=227 lang=csharp
     *
     * [227] 基本计算器 II
     *
     * https://leetcode-cn.com/problems/basic-calculator-ii/description/
     *
     * Category	Difficulty	Likes	Dislikes
     * algorithms	Medium (43.47%)	409	-
     * Tags
     * string
     * 
     * Companies
     * airbnb
     * 
     * Total Accepted:    73.8K
     * Total Submissions: 169.8K
     * Testcase Example:  '"3+2*2"'
     *
     * 给你一个字符串表达式 s ，请你实现一个基本计算器来计算并返回它的值。
     * 
     * 整数除法仅保留整数部分。
     *
     * 
     * 示例 1：
     * 输入：s = "3+2*2"
     * 输出：7
     * 
     * 
     * 示例 2：
     * 输入：s = " 3/2 "
     * 输出：1
     * 
     * 
     * 示例 3：
     * 输入：s = " 3+5 / 2 "
     * 输出：5
     * 
     * 
     * 提示：
     * 1 <= s.length <= 3 * 105
     * s 由整数和算符 ('+', '-', '*', '/') 组成，中间由一些空格隔开
     * s 表示一个 有效表达式
     * 表达式中的所有整数都是非负整数，且在范围 [0, 2^31 - 1] 内
     * 题目数据保证答案是一个 32-bit 整数
     */

    // @lc code=start
    public class Solution227 : SolutionBase
    {
        /// <summary>
        /// 难度
        /// </summary>
        public override Difficulity GetDifficulity() { return Difficulity.Medium; }
        /// <summary>
        /// 关键字:
        /// </summary>
        public override string[] GetKeyWords() { return new string[] { "" }; }
        /// <summary>
        /// 标签：
        /// </summary>
        public override Tag[] GetTags() { return new Tag[] { Tag.String }; }

        public override bool Test(System.Diagnostics.Stopwatch sw)
        {
            bool isSuccess = true;
            int result, checkResult;
            string nums;

            nums = "3+2*2";
            checkResult = 7;
            result = Calculate(nums);
            isSuccess &= IsSame(result, checkResult);
            PrintResult(isSuccess, (result), (checkResult));

            nums = " 3/2 ";
            checkResult = 1;
            result = Calculate(nums);
            isSuccess &= IsSame(result, checkResult);
            PrintResult(isSuccess, (result), (checkResult));

            nums = " 3+5 / 2 ";
            checkResult = 5;
            result = Calculate(nums);
            isSuccess &= IsSame(result, checkResult);
            PrintResult(isSuccess, (result), (checkResult));

            nums = " (3%5-(16-4)/2)+21/3 ";
            checkResult = 4;
            result = Calculate(nums);
            isSuccess &= IsSame(result, checkResult);
            PrintResult(isSuccess, (result), (checkResult));

            return isSuccess;
        }

        /// <summary>
        /// 【宫水三叶】使用「双栈」解决「究极表达式计算」问题
        /// 109/109 cases passed (104 ms)
        /// Your runtime beats 48.73 % of csharp submissions
        /// Your memory usage beats 32.21 % of csharp submissions(28.1 MB)
        /// https://leetcode-cn.com/problems/basic-calculator-ii/solution/shi-yong-shuang-zhan-jie-jue-jiu-ji-biao-c65k/
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public int Calculate(string s)
        {
            // 使用 map 维护一个运算符优先级
            // 这里的优先级划分按照「数学」进行划分即可
            Dictionary<char, int> map = new Dictionary<char, int>();
            map.Add('-', 1);
            map.Add('+', 1);
            map.Add('*', 2);
            map.Add('/', 2);
            map.Add('%', 2);
            map.Add('^', 3);

            s = s.Replace(" ", "");
            char[] cs = s.ToCharArray();
            int n = s.Length;
            // 存放所有的数字
            LinkedList<int> nums = new LinkedList<int>(); // Deque<Integer> nums = new ArrayDeque<>();
            // 为了防止第一个数为负数，先往 nums 加个 0
            nums.AddLast(0);
            // 存放所有「非数字以外」的操作
            LinkedList<char> ops = new LinkedList<char>();
            for (int i = 0; i < n; i++)
            {
                char c = cs[i];
                if (c == '(')
                {
                    ops.AddLast(c);
                }
                else if (c == ')')
                {
                    // 计算到最近一个左括号为止
                    while (ops.Count != 0)
                    {
                        if (ops.Last.Value != '(') //if (ops.peekLast() != '(')  取得栈顶
                        {
                            Calc(nums, ops);
                        }
                        else
                        {
                            ops.RemoveLast();  //ops.pollLast();
                            break;
                        }
                    }
                }
                else
                {
                    if (char.IsNumber(c))
                    {
                        int u = 0;
                        int j = i;
                        // 将从 i 位置开始后面的连续数字整体取出，加入 nums
                        while (j < n && char.IsNumber(cs[j])) u = u * 10 + (cs[j++] - '0');
                        nums.AddLast(u);
                        i = j - 1;
                    }
                    else
                    {
                        if (i > 0 && (cs[i - 1] == '(' || cs[i - 1] == '+' || cs[i - 1] == '-'))
                        {
                            nums.AddLast(0);
                        }
                        // 有一个新操作要入栈时，先把栈内可以算的都算了 
                        // 只有满足「栈内运算符」比「当前运算符」优先级高/同等，才进行运算
                        //while (ops.Count != 0 && ops.peekLast() != '(')
                        while (ops.Count != 0 && ops.Last.Value != '(')
                        {
                            char prev = ops.Last.Value; //char prev = ops.peekLast();
                            if (map[prev] >= map[c])
                            {
                                Calc(nums, ops);
                            }
                            else
                            {
                                break;
                            }
                        }
                        ops.AddLast(c);
                    }
                }
            }
            // 将剩余的计算完
            while (ops.Count != 0) Calc(nums, ops);
            return nums.Last.Value; //nums.peekLast();
        }

        void Calc(LinkedList<int> nums, LinkedList<char> ops)
        {
            if (nums.Count < 2) return;
            if (ops.Count == 0) return;
            //int b = nums.pollLast(), a = nums.pollLast();
            int b = nums.Last.Value; nums.RemoveLast();
            int a = nums.Last.Value; nums.RemoveLast();

            //char op = ops.pollLast();
            char op = ops.Last.Value; ops.RemoveLast();
            int ans = 0;
            if (op == '+') ans = a + b;
            else if (op == '-') ans = a - b;
            else if (op == '*') ans = a * b;
            else if (op == '/') ans = a / b;
            else if (op == '^') ans = (int)Math.Pow(a, b);
            else if (op == '%') ans = a % b;
            nums.AddLast(ans);
        }
    }
    // @lc code=end


}
