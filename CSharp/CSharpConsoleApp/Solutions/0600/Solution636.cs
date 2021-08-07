using System;
using System.Collections.Generic;
namespace CSharpConsoleApp.Solutions
{
    /*
 * @lc app=leetcode.cn id=636 lang=csharp
 *
 * [636] 函数的独占时间
 *
 * https://leetcode-cn.com/problems/exclusive-time-of-functions/description/
 *
 * Category	Difficulty	Likes	Dislikes
 * algorithms	Medium (54.18%)	128	-
 * Tags
 * stack
 * 
 * Companies
 * facebook | uber
 * 
 * Total Accepted:    9K
 * Total Submissions: 16.5K
 * Testcase Example:  '2\n["0:start:0","1:start:2","1:end:5","0:end:6"]'
 *
 * 有一个 单线程 CPU 正在运行一个含有 n 道函数的程序。每道函数都有一个位于  0 和 n-1 之间的唯一标识符。
 * 
 * 函数调用 存储在一个 调用栈 上
 * ：当一个函数调用开始时，它的标识符将会推入栈中。而当一个函数调用结束时，它的标识符将会从栈中弹出。标识符位于栈顶的函数是 当前正在执行的函数
 * 。每当一个函数开始或者结束时，将会记录一条日志，包括函数标识符、是开始还是结束、以及相应的时间戳。
 * 
 * 给你一个由日志组成的列表 logs ，其中 logs[i] 表示第 i 条日志消息，该消息是一个按 "{function_id}:{"start" |
 * "end"}:{timestamp}" 进行格式化的字符串。例如，"0:start:3" 意味着标识符为 0 的函数调用在时间戳 3 的 起始开始执行
 * ；而 "1:end:2" 意味着标识符为 1 的函数调用在时间戳 2 的 末尾结束执行。注意，函数可以 调用多次，可能存在递归调用 。
 * 
 * 函数的 独占时间
 * 定义是在这个函数在程序所有函数调用中执行时间的总和，调用其他函数花费的时间不算该函数的独占时间。例如，如果一个函数被调用两次，一次调用执行 2
 * 单位时间，另一次调用执行 1 单位时间，那么该函数的 独占时间 为 2 + 1 = 3 。
 * 
 * 以数组形式返回每个函数的 独占时间 ，其中第 i 个下标对应的值表示标识符 i 的函数的独占时间。
 * 
 * 
 * 示例 1：
 * 输入：n = 2, logs = ["0:start:0","1:start:2","1:end:5","0:end:6"]
 * 输出：[3,4]
 * 解释：
 * 函数 0 在时间戳 0 的起始开始执行，执行 2 个单位时间，于时间戳 1 的末尾结束执行。 
 * 函数 1 在时间戳 2 的起始开始执行，执行 4 个单位时间，于时间戳 5 的末尾结束执行。 
 * 函数 0 在时间戳 6 的开始恢复执行，执行 1 个单位时间。 
 * 所以函数 0 总共执行 2 + 1 = 3 个单位时间，函数 1 总共执行 4 个单位时间。 
 * 
 * 
 * 示例 2：
 * 输入：n = 1, logs =
 * ["0:start:0","0:start:2","0:end:5","0:start:6","0:end:6","0:end:7"]
 * 输出：[8]
 * 解释：
 * 函数 0 在时间戳 0 的起始开始执行，执行 2 个单位时间，并递归调用它自身。
 * 函数 0（递归调用）在时间戳 2 的起始开始执行，执行 4 个单位时间。
 * 函数 0（初始调用）恢复执行，并立刻再次调用它自身。
 * 函数 0（第二次递归调用）在时间戳 6 的起始开始执行，执行 1 个单位时间。
 * 函数 0（初始调用）在时间戳 7 的起始恢复执行，执行 1 个单位时间。
 * 所以函数 0 总共执行 2 + 4 + 1 + 1 = 8 个单位时间。
 * 
 * 
 * 示例 3：
 * 输入：n = 2, logs =
 * ["0:start:0","0:start:2","0:end:5","1:start:6","1:end:6","0:end:7"]
 * 输出：[7,1]
 * 解释：
 * 函数 0 在时间戳 0 的起始开始执行，执行 2 个单位时间，并递归调用它自身。
 * 函数 0（递归调用）在时间戳 2 的起始开始执行，执行 4 个单位时间。
 * 函数 0（初始调用）恢复执行，并立刻调用函数 1 。
 * 函数 1在时间戳 6 的起始开始执行，执行 1 个单位时间，于时间戳 6 的末尾结束执行。
 * 函数 0（初始调用）在时间戳 7 的起始恢复执行，执行 1 个单位时间，于时间戳 7 的末尾结束执行。
 * 所以函数 0 总共执行 2 + 4 + 1 = 7 个单位时间，函数 1 总共执行 1 个单位时间。 
 * 
 * 示例 4：
 * 输入：n = 2, logs =
 * ["0:start:0","0:start:2","0:end:5","1:start:7","1:end:7","0:end:8"]
 * 输出：[8,1]
 * 
 * 
 * 示例 5：
 * 输入：n = 1, logs = ["0:start:0","0:end:0"]
 * 输出：[1]
 * 
 * 
 * 提示：
 * 1 <= n <= 100
 * 1 <= logs.length <= 500
 * 0 <= function_id < n
 * 0 <= timestamp <= 10^9
 * 两个开始事件不会在同一时间戳发生
 * 两个结束事件不会在同一时间戳发生
 * 每道函数都有一个对应 "start" 日志的 "end" 日志
 */

    // @lc code=start
    public class Solution636 : SolutionBase
    {
        /// <summary>
        /// 难度
        /// </summary>
        public override Difficulity GetDifficulity() { return Difficulity.Medium; }
        /// <summary>
        /// 关键字:
        /// </summary>
        public override string[] GetKeyWords() { return new string[] { }; }
        /// <summary>
        /// 标签：
        /// </summary>
        public override Tag[] GetTags() { return new Tag[] { Tag.Stack }; }

        /// <summary>
        /// </summary>
        /// <param name="sw"></param>
        /// <returns></returns>
        public override bool Test(System.Diagnostics.Stopwatch sw)
        {
            bool isSuccess = true;
            return isSuccess;
        }

        /// <summary>
        /// 作者：LeetCode
        /// 链接：https://leetcode-cn.com/problems/exclusive-time-of-functions/solution/han-shu-de-du-zhan-shi-jian-by-leetcode/
        /// 120/120 cases passed (248 ms)
        /// Your runtime beats 87.5 % of csharp submissions
        /// Your memory usage beats 25 % of csharp submissions(32.9 MB)
        /// </summary>
        /// <param name="n"></param>
        /// <param name="logs"></param>
        /// <returns></returns>
        public int[] ExclusiveTime(int n, IList<string> logs)
        {
            //保存处理中的函数id（id可重复，id重复代表函数递归调用）
            Stack<int> stack = new Stack<int>();

            //res保存者第1～第n个函数对应的独占时长
            int[] res = new int[n];
            String[] s = logs[0].Split(':');
            stack.Push(int.Parse(s[0])); //入栈：第一个函数的id
            int i = 1, prev = int.Parse(s[2]); //prev ：第一个函数的开始调用时间
            while (i < logs.Count)
            {
                s = logs[i].Split(':');
                if (s[1].Equals("start"))
                {
                    //当前函数=栈顶的函数id对应的函数，当前函数时长 += (当前函数开始时间 - 前一函数结束时间 prev)
                    if (stack.Count != 0)
                        res[stack.Peek()] += int.Parse(s[2]) - prev;

                    //入栈：添加当前函数的id
                    stack.Push(int.Parse(s[0]));
                    //更新prev（前一函数结束时间） = 当前函数时间戳
                    prev = int.Parse(s[2]);
                }
                else
                {
                    //更新函数对应的独占时长 += (当前函数结束时间 - 前一函数结束时间 prev) + 1
                    res[stack.Peek()] += int.Parse(s[2]) - prev + 1;
                    //出栈
                    stack.Pop();
                    //更新prev（前一函数结束时间） = 当前函数时间戳 + 1
                    prev = int.Parse(s[2]) + 1;
                }
                i++;
            }
            return res;
        }

        //TODO
        public int[] ExclusiveTime_MY(int n, IList<string> logs)
        {
            Dictionary<int, int[]> dict = new Dictionary<int, int[]>();
            Stack<int> stack = new Stack<int>();

            //int start = 0;
            int timeAll = 0;
            int count = logs.Count;
            for (int i = 0; i < count; i++)
            {
                string data = logs[i];
                string[] arr = data.Split(':');
                int id = int.Parse(arr[0]);
                bool isStart = arr[1] != "end";
                int time = int.Parse(arr[2]);

                //if (i == 0) start = time;
                //if (i == count - 1) timeAll = time - start + 1;

                if (isStart && !dict.ContainsKey(id))
                {
                    int startTime = time;
                    int[] info = new int[] { 1, time, time }; //[0]=count, [1]=startTime [2]=endTime
                    dict.Add(id, info);
                    stack.Push(id);
                }
                else
                {
                    if (!isStart)
                    {
                        //函数调用一次结束，次数减1
                        dict[id][0]--;
                        if (dict[id][0] == 0) //函数调用次数变为0
                        {
                            //
                        }
                        //无递归时,时间为end
                        dict[id][2] = time;

                    }
                    else
                    {
                        //递归调用函数，更新递归次数

                    }

                }

            }

            return null;
        }


    }
    // @lc code=end


}
