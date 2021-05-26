﻿using System;
namespace CSharpConsoleApp.Solutions
{
    /*
     * @lc app=leetcode.cn id=684 lang=csharp
     *
     * [684] 冗余连接
     *
     * https://leetcode-cn.com/problems/redundant-connection/description/
     *
     * Category	Difficulty	Likes	Dislikes
     * algorithms	Medium (66.37%)	346	-
     * Tags
     * tree | union-find | graph
     * 
     * Companies
     * google
     * 
     * Total Accepted:    50.9K
     * Total Submissions: 76.6K
     * Testcase Example:  '[[1,2],[1,3],[2,3]]'
     *
     * 在本问题中, 树指的是一个连通且无环的无向图。
     * 
     * 输入一个图，该图由一个有着N个节点 (节点值不重复1, 2, ..., N)
     * 的树及一条附加的边构成。附加的边的两个顶点包含在1到N中间，这条附加的边不属于树中已存在的边。
     * 
     * 结果图是一个以边组成的二维数组。每一个边的元素是一对[u, v] ，满足 u < v，表示连接顶点u 和v的无向图的边。
     * 
     * 返回一条可以删去的边，使得结果图是一个有着N个节点的树。如果有多个答案，则返回二维数组中最后出现的边。答案边 [u, v] 应满足相同的格式 u <
     * v。
     * 
     * 示例 1：
     * 输入: [[1,2], [1,3], [2,3]]
     * 输出: [2,3]
     * 解释: 给定的无向图为:
     * ⁠ 1
     * ⁠/ \
     * 2 - 3
     * 
     * 示例 2：
     * 输入: [[1,2], [2,3], [3,4], [1,4], [1,5]]
     * 输出: [1,4]
     * 解释: 给定的无向图为:
     * 5 - 1 - 2
     * ⁠   |   |
     * ⁠   4 - 3
     * 
     * 注意:
     * 输入的二维数组大小在 3 到 1000。
     * 二维数组中的整数在1到N之间，其中N是输入数组的大小。
     * 
     * 更新(2017-09-26):
     * 我们已经重新检查了问题描述及测试用例，明确图是无向 图。对于有向图详见冗余连接II。对于造成任何不便，我们深感歉意。
     * 
     */

    public class Solution684 : SolutionBase
    {
        /// <summary>
        /// 难易度:
        /// </summary>
        public override Difficulity GetDifficulity() { return Difficulity.Medium; }
        /// <summary>
        /// 关键字:
        /// </summary>
        public override string[] GetKeyWords() { return new string[] { "并查集", "图", "树" }; }
        /// <summary>
        /// 标签： 
        /// </summary>
        public override Tag[] GetTags() { return new Tag[] { Tag.Tree, Tag.UnionFind, Tag.Graph}; }

        public override bool Test(System.Diagnostics.Stopwatch sw)
        {
            bool isSuccess = true;
            int[][] edges;
            int[] result, checkResult;
            edges = new int[][]
            {
                new int[] { 1,2 },
                new int[] { 2, 3 },
                new int[] { 3,4 },
                new int[] { 1,4 },
                new int[] { 1,5 }
            };
            checkResult = new int[] { 1, 4 };
            result = FindRedundantConnection(edges);
            isSuccess &= IsArraySame(checkResult, result);
            Print("isSuccess = {0} | result = {1} | anticipated = {2}", isSuccess, GetArrayStr<int>(result), GetArrayStr<int>(checkResult));
            return isSuccess;
        }
        /// <summary>
        /// 如果两个顶点属于相同的连通分量，则说明在遍历到当前的边之前，这两个顶点之间已经连通，
        /// 因此当前的边导致环出现，为附加的边，将当前的边作为答案返回。
        /// 作者：LeetCode-Solution
        /// 链接：https://leetcode-cn.com/problems/redundant-connection/solution/rong-yu-lian-jie-by-leetcode-solution-pks2/
        /// </summary>
        /// <param name="edges"></param>
        /// <returns></returns>
        public int[] FindRedundantConnection(int[][] edges)
        {
            int n = edges.Length;
            int[] parent = new int[n + 1];
            for (int i = 1; i <= n; i++)
            {
                parent[i] = i;
            }
            Print(GetArrayStr(parent));
            for (int i = 0; i < n; i++)
            {
                int[] edge = edges[i];
                int node1 = edge[0], node2 = edge[1];

                int parent1 = Find(parent, node1);
                int parent2 = Find(parent, node2);
                
                if (parent1 != parent2)
                {
                    Print("Union {0} | {1} | parent = {2} | {3}", node1, node2, parent1, parent2);
                    Union(parent, node1, node2);
                }
                else
                {
                    return edge;
                }
            }
            return new int[0];
        }

        /// <summary>
        /// 合并不同父对象的节点
        /// </summary>
        /// <param name="parent"></param>
        /// <param name="index1"></param>
        /// <param name="index2"></param>
        public void Union(int[] parent, int index1, int index2)
        {
            parent[Find(parent, index1)] = Find(parent, index2);
            Print("After Union {0} | {1} + {2}", GetArrayStr(parent), index1, index2);
        }


        //递归寻找
        public int Find(int[] parent, int index)
        {
            if (parent[index] != index)
            {
                parent[index] = Find(parent, parent[index]);
                Print("After Find {0} | {1}", GetArrayStr(parent), index);
            }
            return parent[index];
        }
    }
}
