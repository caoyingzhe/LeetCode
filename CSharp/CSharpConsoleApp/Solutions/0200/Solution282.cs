#define DebugSolution282

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpConsoleApp.Solutions
{
    /*
     * @lc app=leetcode.cn id=282 lang=csharp
     *
     * [282] 给表达式添加运算符
     *
     * https://leetcode-cn.com/problems/expression-add-operators/description/
     *
     * algorithms
     * Hard (37.75%)
     * Likes:    211
     * Dislikes: 0
     * Total Accepted:    5.8K
     * Total Submissions: 15.4K
     * Testcase Example:  '"123"\n6'
     *
     * 给定一个仅包含数字 0-9 的字符串和一个目标值，在数字之间添加 二元 运算符（不是一元）+、- 或 * ，返回所有能够得到目标值的表达式。
     * 
     * 示例 1:
     * 输入: num = "123", target = 6
     * 输出: ["1+2+3", "1*2*3"] 
     * 
     * 示例 2:
     * 输入: num = "232", target = 8
     * 输出: ["2*3+2", "2+3*2"]
     * 
     * 示例 3:
     * 输入: num = "105", target = 5
     * 输出: ["1*0+5","10-5"]
     * 
     * 示例 4:
     * 输入: num = "00", target = 0
     * 输出: ["0+0", "0-0", "0*0"]
     * 
     * 
     * 示例 5:
     * 输入: num = "3456237490", target = 9191
     * 输出: []
     * 
     * 
     * 提示：
     * 0 <= num.length <= 10
     * num 仅含数字
     * 
     */
    class Solution282 : SolutionBase
    {
        /// <summary>
        /// 难度
        /// </summary>
        public override Difficulity GetDifficulity() { return Difficulity.Hard; }
        /// <summary>
        /// 关键字:
        /// </summary>
        public override string[] GetKeyWords() { return new string[] { "本质是回溯" }; }
        /// <summary>
        /// 标签： 
        /// </summary>
        public override Tag[] GetTags() { return new Tag[] { Tag.DivideAndConquer, Tag.Backtracking }; }

        public override bool Test(System.Diagnostics.Stopwatch sw)
        {
            bool isSuccess = true;
            AddOperators("2013", 5);
            return isSuccess;
        }

        /// <summary>
        /// Your runtime beats 85.71 % of csharp submissions
        /// Your memory usage beats 71.43 % of csharp submissions(34 MB)
        /// </summary>
        /// <param name="num"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        public IList<string> AddOperators(string num, int target)
        {
            List<string> rst = new List<string>();
            if (num == null || num.Length == 0) return rst;
            Helper(rst, "", num, target, 0, 0, 0);
            return rst;
        }

        /// <summary>
        /// 回溯法
        /// </summary>
        /// <param name="rst">处理结果的表达式列表</param>
        /// <param name="path">当前处理过的路径，不一定是完整路径。对于123，可能是1*2, 1+2,1-2，也可能是完整路径，比如1+2-3</param>
        /// <param name="num">int数组</param>
        /// <param name="target"></param>
        /// <param name="pos">当前处理数字字符串的索引位置</param>
        /// <param name="eval">当前计算结果</param>
        /// <param name="multed">先前处理加减法的数字(可能是一位以上)，对于A-B*C的情况，指的是B</param>  
        public void Helper(List<string> rst, string path, string num, int target, int pos, long eval, long multed, string info = "")
        {
            //Print("List rst.Count ={0}, path ={1} , pos = {4}, eval = {5}, multed = {6}, {7}", rst.Count, path.PadRight(8), num, target, pos, eval.ToString().PadRight(4), multed.ToString().PadRight(4), info);
            if (pos == num.Length)
            {
                if (target == eval)
                {
#if DebugSolution282
                    Print("======= Add Path =" + path);
#endif
                    rst.Add(path);
                }
                return;
            }
            for (int i = pos; i < num.Length; i++)
            {
                //if (n==0) return;
                //这个玩意是真的关键啊，我卡这个00这个案例卡了两天
                ///原来如此， 就是不处理 02，05这种 0后面添加后续数字的情况。直接跳过。
                ///参考说明 https://leetcode-cn.com/problems/expression-add-operators/solution/gei-biao-da-shi-tian-jia-yun-suan-fu-xian-shu-hou-/s
                ///追加后面一个数字形成更大的操作数。直接将后一个数字追加到当前操作数。
                ///这种情况下要避免形成带前导0的操作数，所以当前数字不能既是0又是一个操作数的首位置。
                if (i != pos && num[pos] == '0')
                {
#if DebugSolution282
                    Print("i= {0} num[{1}] = 0", i, pos);
#endif
                    break;
                }

                long cur = long.Parse(num.Substring(pos, i + 1 - pos));
                if (pos == 0)
                {
                    Helper(rst, path + cur, num, target, i + 1, cur, cur);
                }
                else
                {
                    //回溯加号的结果
                    Helper(rst, path + "+" + cur, num, target, i + 1, eval + cur, cur
#if DebugSolution282
                        , "i = " + i + " eval + cur = " + eval + " + " + cur
#endif
                        );

                    //回溯减号的结果
                    Helper(rst, path + "-" + cur, num, target, i + 1, eval - cur, -cur
#if DebugSolution282
                        , "i = " + i + " eval - cur = " + eval + " - " + cur
#endif
                        );

                    //回溯乘号的结果，需要当前结果[eval] 减去先前的值 - [multed]，然后加上与后面的值的乘积 [multed * cur]
                    Helper(rst, path + "*" + cur, num, target, i + 1, eval - multed + multed * cur, multed * cur
#if DebugSolution282
                        , "i = " + i + " eval - multed + multed * cur = " + string.Format("{0} - {1} + {1} * {2}", eval, multed, cur)
#endif
                        );
                }
            }
        }
    }
}
