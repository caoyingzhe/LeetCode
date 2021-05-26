using System;
using System.Collections.Generic;
namespace CSharpConsoleApp.Solutions
{
    /*
     * @lc app=leetcode.cn id=679 lang=csharp
     *
     * [679] 24 点游戏
     *
     * https://leetcode-cn.com/problems/24-game/description/
     *
     * Category	Difficulty	Likes	Dislikes
     * algorithms	Hard (54.15%)	297	-
     * Tags
     * depth-first-search
     * 
     * Companies
     * google
     * 
     * Total Accepted:    23.5K
     * Total Submissions: 43.4K
     * Testcase Example:  '[4,1,8,7]'
     *
     * 你有 4 张写有 1 到 9 数字的牌。你需要判断是否能通过 *，/，+，-，(，) 的运算得到 24。
     * 
     * 示例 1:
     * 输入: [4, 1, 8, 7]
     * 输出: True
     * 解释: (8-4) * (7-1) = 24
     * 
     * 
     * 示例 2:
     * 输入: [1, 2, 1, 2]
     * 输出: False
     * 
     * 
     * 注意:
     * 除法运算符 / 表示实数除法，而不是整数除法。例如 4 / (1 - 2/3) = 12 。
     * 每个运算符对两个数进行运算。特别是我们不能用 - 作为一元运算符。例如，[1, 1, 1, 1] 作为输入时，表达式 -1 - 1 - 1 - 1
     * 是不允许的。
     * 你不能将数字连接在一起。例如，输入为 [1, 2, 1, 2] 时，不能写成 12 + 12 。
     */
    public class Solution679
    {
        const double EPSILON = 1e-6;
        const int ADD = 0, MULTIPLY = 1, SUBTRACT = 2, DIVIDE = 3;

        /// <summary>
        /// 70/70 cases passed (116 ms)
        /// Your runtime beats 61.54 % of csharp submissions
        /// Your memory usage beats 53.85 % of csharp submissions(26.8 MB)
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public bool JudgePoint24(int[] nums)
        {
            List<Double> list = new List<Double>();
            foreach (int num in nums)
            {
                list.Add((double)num);
            }
            return Solve(list, 24);
        }

        /// <summary>
        /// 测试任意数组list是否能通过四则运算组合，达成指定目标值Target
        /// 该处理中包含递归调用。
        ///
        /// 该方法为通用方法，重要点有二点：
        ///   1. target可以为任何值
        ///   2. 列表中数值可以是任意值，包括0.
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        public bool Solve(List<Double> list, int target)
        {
            if (list.Count == 0)
            {
                return false;
            }
            //该处理的意义为，当List中只有1个元素时，也就是递归处理的最后一步，
            //判定list[0] == target； 因为是double类型，误差之内视为相等。
            if (list.Count == 1)
            {
                return Math.Abs(list[0] - target) < EPSILON;
            }
            int size = list.Count;
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    if (i != j)
                    {
                        //任意抽取不同于i,j的第三个数k
                        List<Double> list2 = new List<Double>();
                        for (int k = 0; k < size; k++)
                        {
                            if (k != i && k != j)
                            {
                                list2.Add(list[k]);
                            }
                        }

                        //四则混合运算，k代表运算符号
                        for (int k = 0; k < 4; k++)
                        {
                            //k<2代表加法或者乘法，它们符合交换律，
                            //对于(i < j）的情况无需重复计算，所以continue；
                            if (k < 2 && i > j)
                            {
                                continue;
                            }

                            if (k == ADD)
                            {
                                list2.Add(list[i] + list[j]);
                            }
                            else if (k == MULTIPLY)
                            {
                                list2.Add(list[i] * list[j]);
                            }
                            else if (k == SUBTRACT)
                            {
                                list2.Add(list[i] - list[j]);
                            }
                            else if (k == DIVIDE)
                            {
                                //该处理用于list[j]为0的情况（实际上按照题目，只有1～9，没有0)
                                if (Math.Abs(list[j]) < EPSILON)
                                {
                                    continue;
                                }
                                else
                                {
                                    list2.Add(list[i] / list[j]);
                                }
                            }
                            if (Solve(list2, target))
                            {
                                return true;
                            }
                            list2.RemoveAt(list2.Count - 1);
                        }
                    }
                }
            }
            return false;
        }

        //作者：LeetCode-Solution
        //链接：https://leetcode-cn.com/problems/24-game/solution/24-dian-you-xi-by-leetcode-solution/

    }
}
