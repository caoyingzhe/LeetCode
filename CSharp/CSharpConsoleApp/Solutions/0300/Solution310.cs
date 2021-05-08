using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpConsoleApp.Solutions._0300
{
    /*
     * @lc app=leetcode.cn id=310 lang=csharp
     *
     * [310] 最小高度树
     *
     * https://leetcode-cn.com/problems/minimum-height-trees/description/
     *
     * Category	Difficulty	Likes	Dislikes
     * algorithms	Medium (37.00%)	323	-
     * Tags
     * breadth-first-search | graph
     * 
     * Companies
     * google
     * 
     * Total Accepted:    16.7K
     * Total Submissions: 45.1K
     * Testcase Example:  '4\n[[1,0],[1,2],[1,3]]'
     *
     * 树是一个无向图，其中任何两个顶点只通过一条路径连接。 换句话说，一个任何没有简单环路的连通图都是一棵树。
     * 
     * 给你一棵包含 n 个节点的树，标记为 0 到 n - 1 。给定数字 n 和一个有 n - 1 条无向边的 edges
     * 列表（每一个边都是一对标签），其中 edges[i] = [ai, bi] 表示树中节点 ai 和 bi 之间存在一条无向边。
     * 
     * 可选择树中任何一个节点作为根。当选择节点 x 作为根节点时，设结果树的高度为 h 。在所有可能的树中，具有最小高度的树（即，min(h)）被称为
     * 最小高度树 。
     * 
     * 请你找到所有的 最小高度树 并按 任意顺序 返回它们的根节点标签列表。
     * 树的 高度 是指根节点和叶子节点之间最长向下路径上边的数量。
     * 
     * 
     * 示例 1：
     * 输入：n = 4, edges = [[1,0],[1,2],[1,3]]
     * 输出：[1]
     * 解释：如图所示，当根是标签为 1 的节点时，树的高度是 1 ，这是唯一的最小高度树。
     * 
     * 示例 2：
     * 输入：n = 6, edges = [[3,0],[3,1],[3,2],[3,4],[5,4]]
     * 输出：[3,4]
     * 
     * 示例 3：
     * 输入：n = 1, edges = []
     * 输出：[0]
     * 
     * 示例 4：
     * 输入：n = 2, edges = [[0,1]]
     * 输出：[0,1]
     * 
     * 提示：
     * 1 
     * edges.length == n - 1
     * 0 i, bi < n
     * ai != bi
     * 所有 (ai, bi) 互不相同
     * 给定的输入 保证 是一棵树，并且 不会有重复的边
     * 
     */
    class Solution310 : SolutionBase
    {
        /// <summary>
        /// 难度
        /// </summary>
        public override Difficulity GetDifficulity() { return Difficulity.Medium; }
        /// <summary>
        /// 关键字:
        /// </summary>
        public override string[] GetKeyWords() { return new string[] { "多叉树", }; }
        /// <summary>
        /// 标签：
        /// </summary>
        public override Tag[] GetTags() { return new Tag[] { Tag.Graph, Tag.BreadthFirstSearch }; }

        public override bool Test(System.Diagnostics.Stopwatch sw)
        {
            int[][] edges;
            int n;
            bool isSuccess = true;
            IList<int> result;
            int[] checkResult;

            edges = new int[][] {
                new int[] { 1,0 },
                new int[] { 1,2 },
                new int[] { 1,3 }
            };
            n = 4;
            checkResult = new int[] { 1 };
            result = FindMinHeightTrees_My(n, edges);
            isSuccess &= IsArraySame(result.ToArray(), checkResult);
            Print("isSuccess = {0} | reuslt = {1} | anticipated : {2} | ", isSuccess, GetArrayStr(result), GetArrayStr(checkResult));
            
            
            edges = new int[][] {
                new int[] { 3, 4 },
                new int[] { 3, 1 },
                new int[] { 3, 2 },
                new int[] { 3, 4 },
                new int[] { 5, 4 },
            };
            n = 6;
            checkResult = new int[] { 3, 4 };
            result = FindMinHeightTrees_My(n, edges);
            isSuccess &= IsArraySame(result.ToArray(), checkResult);
            Print("isSuccess = {0} | reuslt = {1} | anticipated : {2} | ", isSuccess, GetArrayStr(result), GetArrayStr(checkResult));

            edges = new int[][] {
                new int[] { 3, 0 },
                new int[] { 3, 1 },
                new int[] { 3, 2 },
                new int[] { 3, 4 },
                new int[] { 5, 4 },
            };
            n = 6;
            checkResult = new int[] { 3, 4 };
            result = FindMinHeightTrees_My(n, edges);
            isSuccess &= IsArraySame(result.ToArray(), checkResult);
            Print("isSuccess = {0} | reuslt = {1} | anticipated : {2} | ", isSuccess, GetArrayStr(result), GetArrayStr(checkResult));


            return isSuccess;
        }

        /// <summary>
        /// 1. 这个树并不是二叉树，是多叉树
        /// 2. 节点遍历bfs，统计下每个节点的高度，然后用map存储起来,会超时的。
        /// 3. 越是靠里面的节点越有可能是最小高度树。
        /// 4. 我们从边缘开始，先找到所有出度为1的节点，然后把所有出度为1的节点进队列，然后不断地bfs
        /// </summary>
        /// <param name="n"></param>
        /// <param name="edges"></param>
        /// <returns></returns>
        public IList<int> FindMinHeightTrees_My(int n, int[][] edges)
        {
            if (edges == null || n != edges.Length + 1)
                return new List<int>();

            Dictionary<int, List<int>> dict = new Dictionary<int, List<int>>();
            for (int i=0; i<n-1; i++)
            {
                int a = edges[i][0];
                int b = edges[i][1];

                if(!dict.ContainsKey(a))
                {
                    dict.Add(a, new List<int>());
                }
                if (!dict.ContainsKey(b))
                {
                    dict.Add(b, new List<int>());
                }
                dict[a].Add(i);
                dict[b].Add(i);
            }

            List<int> oneDepthList = new List<int>();
            while(true)
            {
                oneDepthList.Clear();
                int removeCount = 0;
                int leftCount = 0;
                foreach (int key in dict.Keys)
                {
                    if(dict[key].Count == 1)
                    {
                        oneDepthList.Add(key);
                        removeCount++;
                    }
                    else
                    {
                        leftCount++;
                    }
                }

                // 代买还有待整理。
                // 关键逻辑： 程序推出循环的两种情况， 
                // 情况1. removeCount == 0, 没有字典中可删除的深度为1的节点了。
                // 情况2. removeCount != 0, 但是字典已经没有可删除的节点了。（oneDepthList中的值和dict的[key]完全一致）
                if (removeCount == 0)
                {
                    //情况1
                    for (int i = 0; i < oneDepthList.Count; i++)
                    {
                        dict.Remove(oneDepthList[i]);   //  remove depth1 key from dict;
                    }
                    oneDepthList.Clear();
                    //Print("removeNode = {0}", GetArrayStr(oneDepthList));
                    foreach (int key in dict.Keys)
                    {
                        oneDepthList.Add(key);
                    }
                    break;
                }
                else if (leftCount > 0)
                {
                    for (int i = 0; i < oneDepthList.Count; i++)
                    {
                        int key = oneDepthList[i];
                        int pairIndex = dict[key][0];
                        int removeVal = edges[pairIndex][0] == key ? edges[pairIndex][1] : edges[pairIndex][0];
                        dict[removeVal].Remove(pairIndex);
                    }
                    for (int i = 0; i < oneDepthList.Count; i++)
                    {
                        dict.Remove(oneDepthList[i]);   //  remove depth1 key from dict;
                    }
                    //Print("removeNode = {0}", GetArrayStr(oneDepthList));
                }
                else
                {
                    //情况2
                    break;
                }
                //Print("removeNode = {0}", GetArrayStr(oneDepthList));
            }
            //Print("result = {0}", GetArrayStr(oneDepthList));
            return oneDepthList;
        }
    }
}
