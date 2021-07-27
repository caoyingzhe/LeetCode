using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpConsoleApp.Solutions._0600
{
    /*
     * @lc app=leetcode.cn id=621 lang=csharp
     *
     * [621] 任务调度器
     *
     * https://leetcode-cn.com/problems/task-scheduler/description/
     *
     * Category	Difficulty	Likes	Dislikes
     * algorithms	Medium (56.64%)	686	-
     * Tags
     * array | greedy | queue
     * 
     * Companies
     * facebook
     * 
     * Total Accepted:    71.8K
     * Total Submissions: 126.7K
     * Testcase Example:  '["A","A","A","B","B","B"]\n2'
     *
     * 给你一个用字符数组 tasks 表示的 CPU 需要执行的任务列表。其中每个字母表示一种不同种类的任务。任务可以以任意顺序执行，并且每个任务都可以在 1
     * 个单位时间内执行完。在任何一个单位时间，CPU 可以完成一个任务，或者处于待命状态。
     * 然而，两个 相同种类 的任务之间必须有长度为整数 n 的冷却时间，因此至少有连续 n 个单位时间内 CPU 在执行不同的任务，或者在待命状态。
     * 你需要计算完成所有任务所需要的 最短时间 。
     * 
     * 
     * 示例 1：
     * 输入：tasks = ["A","A","A","B","B","B"], n = 2
     * 输出：8
     * 解释：A -> B -> (待命) -> A -> B -> (待命) -> A -> B
     * ⁠    在本示例中，两个相同类型任务之间必须间隔长度为 n = 2 的冷却时间，而执行一个任务只需要一个单位时间，所以中间出现了（待命）状态。 
     * 
     * 示例 2：
     * 输入：tasks = ["A","A","A","B","B","B"], n = 0
     * 输出：6
     * 解释：在这种情况下，任何大小为 6 的排列都可以满足要求，因为 n = 0
     * ["A","A","A","B","B","B"]
     * ["A","B","A","B","A","B"]
     * ["B","B","B","A","A","A"]
     * ...
     * 诸如此类
     * 
     * 
     * 示例 3：
     * 输入：tasks = ["A","A","A","A","A","A","B","C","D","E","F","G"], n = 2
     * 输出：16
     * 解释：一种可能的解决方案是：
     * ⁠    A -> B -> C -> A -> D -> E -> A -> F -> G -> A -> (待命) -> (待命) -> A ->
     * (待命) -> (待命) -> A
     * 
     * 
     * 提示：
     * 1 <= task.length <= 104
     * tasks[i] 是大写英文字母
     * n 的取值范围为 [0, 100]
     */

    // @lc code=start
    public class Solution621 : SolutionBase
    {
        /// <summary>
        /// 难易度:
        /// </summary>
        public override Difficulity GetDifficulity() { return Difficulity.Medium; }
        /// <summary>
        /// 关键字:
        /// </summary>
        public override string[] GetKeyWords() { return new string[] { "" }; }
        /// <summary>
        /// 标签： 
        /// </summary>
        public override Tag[] GetTags() { return new Tag[] { Tag.Array, Tag.Greedy, Tag.Queue }; }

        public override bool Test(System.Diagnostics.Stopwatch sw)
        {
            bool isSuccess = true;
            isSuccess &= Test(new char[] { 'A', 'A', 'A', 'B', 'B', 'B' }, 2, 8);
            isSuccess &= Test(new char[] { 'A', 'A', 'A', 'B', 'B', 'B' }, 0, 6);
            isSuccess &= Test(new char[] { 'A', 'A', 'A', 'A', 'A', 'A', 'B', 'C', 'D', 'E', 'F', 'G' }, 2, 16);
            return isSuccess;
        }

        bool Test(char[] tasks, int n, int checkResult)
        {
            int result = LeastInterval(tasks, n);
            bool isSuccess = IsSame(result, checkResult);
            PrintResult(isSuccess, result, checkResult);
            return isSuccess;
        }

        //作者：LeetCode - Solution
        //链接：https://leetcode-cn.com/problems/task-scheduler/solution/ren-wu-diao-du-qi-by-leetcode-solution-ur9w/
        /// <summary>
        /// 71/71 cases passed (164 ms)
        /// Your runtime beats 87.5 % of csharp submissions
        /// Your memory usage beats 37.5 % of csharp submissions(34.6 MB)
        /// </summary>
        /// <param name="tasks"></param>
        /// <param name="n"></param>
        /// <returns></returns>
        public int LeastInterval(char[] tasks, int n)
        {
            if (n == 0) return tasks.Length;

            Dictionary<char, int> freq = new Dictionary<char, int>();
            // 最多的执行次数
            int maxExec = 0;
            foreach (char ch in tasks)
            {
                if (!freq.ContainsKey(ch))
                    freq.Add(ch, 0);
                freq[ch]++ ;
                maxExec = Math.Max(maxExec, freq[ch]);
            }

            // 具有最多执行次数的任务数量
            int maxCount = 0;
            foreach (char key in freq.Keys)
            {
                if (freq[key] == maxExec)
                {
                    ++maxCount;
                }
            }
            return Math.Max((maxExec - 1) * (n + 1) + maxCount, tasks.Length);
        }

        //TODO
        public int LeastInterval_MyNG(char[] tasks, int n)
        {
            if (n == 0) return tasks.Length;
            // NG :  (n == 1) return tasks.Length * 2 - 1;

            int len = tasks.Length;

            int[] tCounts = new int['Z'];

            int maxCount = 0;
            for (int i = 0; i < len; i++)
            {
                tCounts[tasks[i]]++;
                maxCount = Math.Max(maxCount, tCounts[tasks[i]]);
            }

            //如果 n >= 26,该算法成立
            //如果 n < 26,该算法有问题，没有考虑并行n之间也需要添加等待时间的计算。
            //int nTaskCount = 0;
            //for (int i = 'A'; i <= 'Z'; i++)
            //{
            //    nTaskCount += (tCounts[tasks[i]]) / n;
            //    tCounts[tasks[i]] %= n;
            //}
            return (maxCount - 1) * n + len;
        }
    }
    // @lc code=end


}
