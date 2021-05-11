using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpConsoleApp.Solutions._0300
{
    /*
     * @lc app=leetcode.cn id=332 lang=csharp
     *
     * [332] 重新安排行程
     *
     * https://leetcode-cn.com/problems/reconstruct-itinerary/description/
     *
     * algorithms
     * Medium (44.55%)
     * Likes:    402
     * Dislikes: 0
     * Total Accepted:    32.3K
     * Total Submissions: 72.5K
     * Testcase Example:  '[["MUC","LHR"],["JFK","MUC"],["SFO","SJC"],["LHR","SFO"]]'
     *
     * 给定一个机票的字符串二维数组 [from,
     * to]，子数组中的两个成员分别表示飞机出发和降落的机场地点，对该行程进行重新规划排序。所有这些机票都属于一个从
     * JFK（肯尼迪国际机场）出发的先生，所以该行程必须从 JFK 开始。
     * 
     * 
     * 
     * 提示：
     * 
     * 
     * 如果存在多种有效的行程，请你按字符自然排序返回最小的行程组合。例如，行程 ["JFK", "LGA"] 与 ["JFK", "LGB"]
     * 相比就更小，排序更靠前
     * 所有的机场都用三个大写字母表示（机场代码）。
     * 假定所有机票至少存在一种合理的行程。
     * 所有的机票必须都用一次 且 只能用一次。
     * 
     * 
     * 
     * 
     * 示例 1：
     * 输入：[["MUC", "LHR"], ["JFK", "MUC"], ["SFO", "SJC"], ["LHR", "SFO"]]
     * 输出：["JFK", "MUC", "LHR", "SFO", "SJC"]
     * 
     * 
     * 示例 2：
     * 输入：[["JFK","SFO"],["JFK","ATL"],["SFO","ATL"],["ATL","JFK"],["ATL","SFO"]]
     * 输出：["JFK","ATL","JFK","SFO","ATL","SFO"]
     * 解释：另一种有效的行程是 ["JFK","SFO","ATL","JFK","ATL","SFO"]。但是它自然排序更大更靠后。
     * 
     */
    class Solution332 : SolutionBase
    {
        /// <summary>
        /// 难易度:
        /// </summary>
        public override Difficulity GetDifficulity() { return Difficulity.Medium; }
        /// <summary>
        /// 关键字:
        /// </summary>
        public override string[] GetKeyWords() { return new string[] { "前序序列化", "入度出度" }; }
        /// <summary>
        /// 标签：
        /// </summary>
        public override Tag[] GetTags() { return new Tag[] { Tag.Stack, Tag.DivideAndConquer }; }

        //TODO
        public override bool Test(System.Diagnostics.Stopwatch sw)
        {
            bool isSuccess = true;

            //[["JFK","SFO"],["JFK","ATL"],["SFO","ATL"],["ATL","JFK"],["ATL","SFO"]]
            IList<IList<string>> tickets = new List<IList<string>>();
            tickets.Add(new string[] { "JFK", "SFO" });
            tickets.Add(new string[] { "JFK", "ATL" });
            tickets.Add(new string[] { "SFO", "ATL" });
            tickets.Add(new string[] { "ATL", "JFK" });
            tickets.Add(new string[] { "ATL", "SFO" });
            IList<string> result = FindItinerary(tickets);
            string[] checkResult = new string[] { "JFK", "ATL", "JFK", "SFO", "ATL", "SFO" };

            //IList<IList<string>> tickets = new List<IList<string>>();
            //tickets.Add(new string[] { "MUC", "LHR" });
            //tickets.Add(new string[] { "JFK", "MUC" });
            //tickets.Add(new string[] { "SFO", "SJC" });
            //tickets.Add(new string[] { "LHR", "SFO" });
            //
            //IList<string> result = FindItinerary(tickets);
            //string[] checkResult = new string[] { "JFK", "MUC", "LHR", "SFO", "SJC" };
            isSuccess &= (GetArrayStr(result) == GetArrayStr(checkResult));
            Print("isSuccess = {0} | result= {1} | checkResult= {2} | ", isSuccess, GetArrayStr(result), GetArrayStr(checkResult));
            return isSuccess;
        }

        //TODO 以为简单，却花了一天没做出来。
        public IList<string> FindItinerary_My_Uncomplete(IList<IList<string>> tickets)
        {
            return null;
        }
        public int GetIntValue(string char3)
        {
            return ((char3[0] - 'A') << 10) + ((char3[1] - 'A') << 5) + (char3[2] - 'A');
        }
        /*
        public string GetChar3Value_Wrong(int intVal)
        {                 
            return "" + (char)((intVal & (31 << 10)) + 'A') + (char)((intVal & (31 << 5)) + 'A') + (char)((intVal & 31) + 'A');
        }
        */

        Dictionary<string, PriorityQueue<string>> map = new Dictionary<string, PriorityQueue<string>>();
        LinkedList<string> itinerary = new LinkedList<string>();

        /// <summary>
        /// 作者：LeetCode-Solution
        /// 链接：https://leetcode-cn.com/problems/reconstruct-itinerary/solution/zhong-xin-an-pai-xing-cheng-by-leetcode-solution/
        /// </summary>
        /// <param name="tickets"></param>
        /// <returns></returns>
        public IList<string> FindItinerary(IList<IList<string>> tickets)
        {
            foreach (IList<string> ticket in tickets)
            {
                string src = ticket[0], dst = ticket[1];
                if (!map.ContainsKey(src))
                {
                    map.Add(src, new PriorityQueue<string>(new ComparerStringAsc()));
                }
                map[src].Push(dst);// map[src].offer(dst);
            }
            dfs("JFK");
            IList<string> result = itinerary.Reverse().ToList();
            return result;
        }

        public void dfs(string curr)
        {
            while (map.ContainsKey(curr) && map[curr].Count > 0)
            {
                string tmp = map[curr].Pop();//string tmp = map[curr].poll();s
                dfs(tmp);
            }
            itinerary.AddLast(curr);
        }

        // define globalVar;
        // DFS()
        // {
        //      while( 循环条件）
        //      {
        //         处理 : Update(globalVar)
        //         dfs
        //      }
        //      Update(globalVar)
        // }
        //

    }
}
