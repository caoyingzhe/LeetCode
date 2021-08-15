using System;
namespace CSharpConsoleApp.Solutions
{
    /*
     * @lc app=leetcode.cn id=502 lang=csharp
     *
     * [502] IPO
     *
     * https://leetcode-cn.com/problems/ipo/description/
     *
     * Category	Difficulty	Likes	Dislikes
     * algorithms	Hard (41.73%)	86	-
     * Tags
     * heap | greedy
     * 
     * Companies
     * Unknown
     * 
     * Total Accepted:    6.5K
     * Total Submissions: 15.5K
     * Testcase Example:  '2\n0\n[1,2,3]\n[0,1,1]'
     *
     * 假设 力扣（LeetCode）即将开始其 IPO。为了以更高的价格将股票卖给风险投资公司，力扣 希望在 IPO 之前开展一些项目以增加其资本。
     * 由于资源有限，它只能在 IPO 之前完成最多 k 个不同的项目。帮助 力扣 设计完成最多 k 个不同项目后得到最大总资本的方式。
     * 
     * 给定若干个项目。对于每个项目 i，它都有一个纯利润 Pi，并且需要最小的资本 Ci 来启动相应的项目。最初，你有 W
     * 资本。当你完成一个项目时，你将获得纯利润，且利润将被添加到你的总资本中。
     * 
     * 总而言之，从给定项目中选择最多 k 个不同项目的列表，以最大化最终资本，并输出最终可获得的最多资本。
     * 
     * 
     * 示例：
     * 输入：k=2, W=0, Profits=[1,2,3], Capital=[0,1,1].
     * 输出：4
     * 解释：
     * 由于你的初始资本为 0，你仅可以从 0 号项目开始。
     * 在完成后，你将获得 1 的利润，你的总资本将变为 1。
     * 此时你可以选择开始 1 号或 2 号项目。
     * 由于你最多可以选择两个项目，所以你需要完成 2 号项目以获得最大的资本。
     * 因此，输出最后最大化的资本，为 0 + 1 + 3 = 4。
     * 
     * 
     * 提示：
     * 假设所有输入数字都是非负整数。
     * 表示利润和资本的数组的长度不超过 50000。
     * 答案保证在 32 位有符号整数范围内。x
     */

    // @lc code=start
    public class Solution502 : SolutionBase
    {
        /// <summary>
        /// 难度
        /// </summary>
        public override Difficulity GetDifficulity() { return Difficulity.Hard; }
        /// <summary>
        /// 关键字:
        /// </summary>
        public override string[] GetKeyWords() { return new string[] { "抄作业" }; }
        /// <summary>
        /// 标签：
        /// </summary>
        public override Tag[] GetTags() { return new Tag[] { Tag.Heap, Tag.Greedy }; }

        /// <summary>
        /// </summary>
        /// <param name="sw"></param>
        /// <returns></returns>
        public override bool Test(System.Diagnostics.Stopwatch sw)
        {
            bool isSuccess = true;
            int result, checkResult;
            //TODO
            //p1 = [0,0], p2 = [1,1], p3 = [1,0], p4 = [0,1]
            //isSuccess &= FindMaximizedCapital(2, 0, new int[] { 1, 2, 3 }, new int[] { 0, 1, 1 }) == 4; PrintDatas(isSuccess);
            checkResult = 4;
            result = FindMaximizedCapital(2, 0, new int[] { 1, 2, 3 }, new int[] { 0, 1, 1 });
            isSuccess &= IsSame(result, checkResult);
            PrintResult(isSuccess, result, checkResult);

            checkResult = 5;
            result = FindMaximizedCapital(1, 2, new int[] { 1, 2, 3 }, new int[] { 1, 1, 2 });
            isSuccess &= IsSame(result, checkResult);
            PrintResult(isSuccess, result, checkResult);
            return isSuccess;
        }

        /// <summary>
        /// 作者：LeetCode
        /// 链接：https://leetcode-cn.com/problems/ipo/solution/ipo-by-leetcode-3/
        /// 35/35 cases passed (216 ms)
        /// Your runtime beats 100 % of csharp submissions
        /// Your memory usage beats 100 % of csharp submissions(44.1 MB)
        /// </summary>
        /// <param name="k">最多完成 k 个不同的项目</param>
        /// <param name="w">最初你有 W 资本</param>
        /// <param name="profits">每个项目的获得利润</param>
        /// <param name="capital">每个项目需要的资本</param>
        /// <returns></returns>
        public int FindMaximizedCapital(int k, int w, int[] profits, int[] capital)
        {
            // to speed up: if all projects are available
            bool speedUp = true;
            foreach(int c in capital)
                if (w < c) speedUp = false;
            if (speedUp)
            {
                // [Java] : PriorityQueue<Integer> heap = new PriorityQueue<>(); //默认是升序
                PriorityQueue<int> heap = new PriorityQueue<int>(new ComparerIntAsc());
                foreach (int p in profits)
                {
                    heap.Push(p);
                    if (heap.Count > k)
                        heap.Pop();
                }
                var heapArr = heap.ToArray();
                foreach (int h in heapArr)
                    w += h;

                return w;
            }

            int idx;
            int n = profits.Length;
            for (int i = 0; i < Math.Min(k, n); ++i)
            {
                idx = -1;
                // if there are available projects,
                // pick the most profitable one
                for (int j = 0; j < n; ++j)
                {
                    if (w >= capital[j])
                    {
                        if (idx == -1) idx = j;
                        else if (profits[idx] < profits[j]) idx = j;
                    }
                }
                // not enough capital to start any project
                if (idx == -1) break;

                // add the profit from chosen project
                // and remove the project from further consideration
                w += profits[idx];
                capital[idx] = int.MaxValue;
            }
            return w;
        }
    }
    // @lc code=end


}
