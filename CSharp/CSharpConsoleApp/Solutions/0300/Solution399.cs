using System;
using System.Collections.Generic;
namespace CSharpConsoleApp.Solutions
{
    /*
     * @lc app=leetcode.cn id=399 lang=csharp
     *
     * [399] 除法求值
     *
     * https://leetcode-cn.com/problems/evaluate-division/description/
     *
     * Category	Difficulty	Likes	Dislikes
     * algorithms	Medium (59.24%)	531	-
     * Tags
     * union-find | graph
     * 
     * Companies
     * google
     * 
     * Total Accepted:    36.1K
     * Total Submissions: 60.9K
     * Testcase Example:  '[["a","b"],["b","c"]]\n' +
      '[2.0,3.0]\n' +
      '[["a","c"],["b","a"],["a","e"],["a","a"],["x","x"]]'
     *
     * 给你一个变量对数组 equations 和一个实数值数组 values 作为已知条件，其中 equations[i] = [Ai, Bi] 和
     * values[i] 共同表示等式 Ai / Bi = values[i] 。每个 Ai 或 Bi 是一个表示单个变量的字符串。
     * 
     * 另有一些以数组 queries 表示的问题，其中 queries[j] = [Cj, Dj] 表示第 j 个问题，请你根据已知条件找出 Cj / Dj
     * = ? 的结果作为答案。
     * 
     * 返回 所有问题的答案 。如果存在某个无法确定的答案，则用 -1.0 替代这个答案。如果问题中出现了给定的已知条件中没有出现的字符串，也需要用 -1.0
     * 替代这个答案。
     * 
     * 注意：输入总是有效的。你可以假设除法运算中不会出现除数为 0 的情况，且不存在任何矛盾的结果。
     *
     * 
     * 示例 1：
     * 输入：equations = [["a","b"],["b","c"]], values = [2.0,3.0], queries =
     * [["a","c"],["b","a"],["a","e"],["a","a"],["x","x"]]
     * 输出：[6.00000,0.50000,-1.00000,1.00000,-1.00000]
     * 解释：
     * 条件：a / b = 2.0, b / c = 3.0
     * 问题：a / c = ?, b / a = ?, a / e = ?, a / a = ?, x / x = ?
     * 结果：[6.0, 0.5, -1.0, 1.0, -1.0 ]
     * 
     * 
     * 示例 2：
     * 输入：equations = [["a","b"],["b","c"],["bc","cd"]], values = [1.5,2.5,5.0],
     * queries = [["a","c"],["c","b"],["bc","cd"],["cd","bc"]]
     * 输出：[3.75000,0.40000,5.00000,0.20000]
     * 
     * 
     * 示例 3：
     * 输入：equations = [["a","b"]], values = [0.5], queries =
     * [["a","b"],["b","a"],["a","c"],["x","y"]]
     * 输出：[0.50000,2.00000,-1.00000,-1.00000]
     * 
     * 
     * 提示：
     * 1 <= equations.length <= 20
     * equations[i].length == 2
     * 1 <= Ai.length, Bi.length <= 5
     * values.length == equations.length
     * 0.0 < values[i] 
     * 1 <= queries.length <= 20
     * queries[i].length == 2
     * 1 <= Cj.length, Dj.length <= 5
     * Ai, Bi, Cj, Dj 由小写英文字母与数字组成
     */
    public class Solution399 : SolutionBase
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
        public override Tag[] GetTags() { return new Tag[] { Tag.UnionFind, Tag.Graph, }; }

        public override bool Test(System.Diagnostics.Stopwatch sw)
        {
            bool isSuccess = true;
            List<IList<string>> equations; double[] values; List<IList<string>> queries;
            double[] result, checkResult;

            equations = new List<IList<string>>();
            queries = new List<IList<string>>();

            equations.Clear(); queries.Clear();
            equations.Add(new List<string>(new string[] { "a", "b" }));
            equations.Add(new List<string>(new string[] { "b", "c" }));
            //equations.Add(new List<string>(new string[] { "bc", "cd" }));
            values = new double[] { 2.0, 3.0 };
            queries.Add(new List<string>(new string[] { "a", "c" }));
            queries.Add(new List<string>(new string[] { "b", "a" }));
            queries.Add(new List<string>(new string[] { "a", "e" }));
            queries.Add(new List<string>(new string[] { "a", "a" }));
            queries.Add(new List<string>(new string[] { "x", "x" }));
            checkResult = new double[] { 6.0, 0.5, -1.0, 1.0, -1.0 };
            result = CalcEquation(equations, values, queries);

            isSuccess &= IsArraySame(checkResult, result);
            Print("isSuccess = {0} | result = {1} | anticipated = {2}", isSuccess, GetArrayStr<double>(result), GetArrayStr<double>(checkResult));

            return isSuccess;
        }
        public class Data
        {
            public double a;
            public string x;
            public Data(double a, string x)
            {
                this.a = a;
                this.x = x;
            }
        }

        /// <summary>
        /// 23/23 cases passed (268 ms)
        /// Your runtime beats 100 % of csharp submissions
        /// Your memory usage beats 72.73 % of csharp submissions(30.4 MB)
        /// </summary>
        /// <param name="equations"></param>
        /// <param name="values"></param>
        /// <param name="queries"></param>
        /// <returns></returns>
        public double[] CalcEquation(IList<IList<string>> equations, double[] values, IList<IList<string>> queries)
        {
            Dictionary<string, Data> Dictionary = new Dictionary<string, Data>();
            //1，将每个字符表示未a*x的形式
            int nEqu = equations.Count;
            int[] used = new int[nEqu];
            int cnt = 0;//已经建好的结点数
            int cur = 0;//当前该建的结点
            while (cnt < nEqu)
            {
                //加入cur结点
                string s1 = equations[cur][0];
                string s2 = equations[cur][1];
                double val = values[cur];
                if (Dictionary.ContainsKey(s1))
                {
                    Data data = Dictionary[s1];
                    Dictionary[s2] = new Data(data.a / val, data.x);
                }
                else if (Dictionary.ContainsKey(s2))
                {
                    Data data = Dictionary[s2];
                    Dictionary[s1] = new Data(data.a * val, data.x);
                }
                else
                {
                    Dictionary.Add(s1, new Data(val, s2));
                    Dictionary.Add(s2, new Data(1.0, s2));
                }

                cnt++;
                used[cur] = 1;
                if (cnt == nEqu) break;

                //下一个该建的结点
                int next = (cur + 1) % nEqu;
                bool isRalax = false;
                int n1 = 0;//统计跳动次数
                while (true)
                {
                    //判断next是否满足条件
                    if (used[next] == 0)
                    {//没有遍历过
                        string t1 = equations[next][0];
                        string t2 = equations[next][1];
                        if (isRalax || Dictionary.ContainsKey(t1) || Dictionary.ContainsKey(t2))
                        {//包含字符串，一圈后去掉要求
                            cur = next;
                            break;
                        }
                    }
                    next = (next + 1) % nEqu;
                    n1++;
                    if (n1 == nEqu) isRalax = true;
                }
            }

            //2，计算结点比值
            double[] res = new double[queries.Count];
            for (int i = 0; i < queries.Count; i++)
            {
                string s1 = queries[i][0];
                string s2 = queries[i][1];
                Data data1 = Dictionary.ContainsKey(s1) ? Dictionary[s1] : null;
                Data data2 = Dictionary.ContainsKey(s2) ? Dictionary[s2] : null;
                if (data1 == null || data2 == null || !data1.x.Equals(data2.x))
                {
                    res[i] = -1.0;
                }
                else
                {
                    res[i] = data1.a / data2.a;
                }
            }

            return res;
        }

        //作者：xiao-xiong-1
        //链接：https://leetcode-cn.com/problems/evaluate-division/solution/biao-shi-wei-dataa-xge-shi-shi-jian-100n-eqwl/

    }


}
