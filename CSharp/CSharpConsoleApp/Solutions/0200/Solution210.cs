using System;
using System.Collections.Generic;
namespace CSharpConsoleApp.Solutions
{
    /*
     * @lc app=leetcode.cn id=210 lang=csharp
     *
     * [210] 课程表 II
     *
     * https://leetcode-cn.com/problems/course-schedule-ii/description/
     *
     * algorithms
     * Medium (53.58%)
     * Likes:    420
     * Dislikes: 0
     * Total Accepted:    74.4K
     * Total Submissions: 138.7K
     * Testcase Example:  '2\n[[1,0]]'
     *
     * 现在你总共有 n 门课需要选，记为 0 到 n-1。
     * 
     * 在选修某些课程之前需要一些先修课程。 例如，想要学习课程 0 ，你需要先完成课程 1 ，我们用一个匹配来表示他们: [0,1]
     * 
     * 给定课程总量以及它们的先决条件，返回你为了学完所有课程所安排的学习顺序。
     * 
     * 可能会有多个正确的顺序，你只要返回一种就可以了。如果不可能完成所有课程，返回一个空数组。
     * 
     * 示例 1:
     * 
     * 输入: 2, [[1,0]] 
     * 输出: [0,1]
     * 解释: 总共有 2 门课程。要学习课程 1，你需要先完成课程 0。因此，正确的课程顺序为 [0,1] 。
     * 
     * 示例 2:
     * 
     * 输入: 4, [[1,0],[2,0],[3,1],[3,2]]
     * 输出: [0,1,2,3] or [0,2,1,3]
     * 解释: 总共有 4 门课程。要学习课程 3，你应该先完成课程 1 和课程 2。并且课程 1 和课程 2 都应该排在课程 0 之后。
     * 因此，一个正确的课程顺序是 [0,1,2,3] 。另一个正确的排序是 [0,2,1,3] 。
     * 
     * 
     * 说明:
     * 
     * 
     * 输入的先决条件是由边缘列表表示的图形，而不是邻接矩阵。详情请参见图的表示法。
     * 你可以假定输入的先决条件中没有重复的边。
     * 
     * 
     * 提示:
     * 
     * 
     * 这个问题相当于查找一个循环是否存在于有向图中。如果存在循环，则不存在拓扑排序，因此不可能选取所有课程进行学习。
     * 通过 DFS 进行拓扑排序 - 一个关于Coursera的精彩视频教程（21分钟），介绍拓扑排序的基本概念。
     * 
     * 拓扑排序也可以通过 BFS 完成。
     * 
     * 
     * 
     */

    // @lc code=start
    public class Solution210 : SolutionBase
    {
        /// <summary>
        /// 难度
        /// </summary>
        public override Difficulity GetDifficulity() { return Difficulity.Medium; }
        /// <summary>
        /// 关键字:
        /// </summary>
        public override string[] GetKeyWords() { return new string[] { "拓扑排序" }; }
        /// <summary>
        /// 标签：
        /// </summary>
        public override Tag[] GetTags() { return new Tag[] { Tag.DepthFirstSearch, Tag.BreadthFirstSearch, Tag.Graph, Tag.TopologicalSort }; }

        /// <summary>
        /// 入度：每个课程节点的入度数量等于其先修课程的数量；
        /// 出度：每个课程节点的出度数量等于其指向的后续课程数量；
        /// 所以只有当一个课程节点的入度为零时，其才是一个可以学习的自由课程。
        ///
        /// 拓扑排序即是将一个无环有向图转换为线性排序的过程。
        /// </summary>
        /// <param name="sw"></param>
        /// <returns></returns>
        public override bool Test(System.Diagnostics.Stopwatch sw)
        {
            bool isSuccess = true;
            int numCourses; int[][] prerequisites;

            int[] result, checkResult;

            numCourses = 2;
            prerequisites = new int[][] {
                new int[] { 1, 0 }
            };
            checkResult = new int[] { 0, 1 };
            result = FindOrder(numCourses, prerequisites);
            isSuccess &= IsSame(result, checkResult);
            Print("isSuccess = {0} | result= {1} | checkResult= {2} | ", isSuccess, (result), (checkResult));

            numCourses = 2;
            prerequisites = new int[][] {
                new int[] { 1, 0 },
                new int[] { 0, 1 }
            };
            checkResult = null;
            result = FindOrder(numCourses, prerequisites);
            isSuccess &= IsArraySame(result, checkResult);
            Print("isSuccess = {0} | result= {1} | checkResult= {2} | ", isSuccess, (result), (checkResult));

            numCourses = 4;
            prerequisites = new int[][] {
                new int[] { 1, 0 },
                new int[] { 2, 0 },
                new int[] { 3, 1 },
                new int[] { 3, 2 },
            };
            checkResult = new int[] { 0, 1, 2 ,3 };
            result = FindOrder(numCourses, prerequisites);
            isSuccess &= IsArraySame(result, checkResult);
            Print("isSuccess = {0} | result= {1} | checkResult= {2} | ", isSuccess, (result), (checkResult));

            numCourses = 1;
            prerequisites = new int[][] {};
            checkResult = new int[] { 0 };
            result = FindOrder(numCourses, prerequisites);
            isSuccess &= IsArraySame(result, checkResult);
            Print("isSuccess = {0} | result= {1} | checkResult= {2} | ", isSuccess, (result), (checkResult));

            return isSuccess;
        }

        /// <summary>
        /// 作者：Terry2020
        /// 链接：https://leetcode-cn.com/problems/course-schedule/solution/rang-ni-miao-dong-de-bao-mu-ji-tuo-bu-pa-o4b1/ 
        /// 44/44 cases passed (344 ms)
        /// Your runtime beats 25 % of csharp submissions
        /// Your memory usage beats 68.18 % of csharp submissions(33.8 MB)
        /// </summary>
        /// <param name="numCourses"></param>
        /// <param name="prerequisites"></param>
        /// <returns></returns>
        public int[] FindOrder(int numCourses, int[][] prerequisites)
        {
            List<int> rtn = new List<int>();
            int n = prerequisites.Length;
            // 没有依赖关系，必然能完成所有课程的学习
            if (n == 0)
            {
                for (int i = 0; i < numCourses; i++) rtn.Add(i);
                return rtn.ToArray();
            }
            int[] indegree = new int[numCourses];              // 每个节点的入度
            List<int>[] adjacency = new List<int>[numCourses]; // 邻接矩阵：先修课程-->(后续课程集合)
            for (int i = 0; i < numCourses; i++) adjacency[i] = new List<int>();

            LinkedList<int> help = new LinkedList<int>();      // 辅助队列，存放入度为0的节点
                                                               // 统计所有节点的入度，构建邻接矩阵
            for (int i = 0; i < n; i++)
            {
                //prerequisites[i][0] : requireCourse
                int course = prerequisites[i][0];  //后修课程
                int required = prerequisites[i][1];  //先修课程
                indegree[course]++;                  //每个节点的入度++
                adjacency[required].Add(course);     //邻接矩阵[先修课程].Add(后修课程)
            }
            // 将所有入度为0的节点加入队列，入度为0的节点意味着没有先修课程的自由课程
            for (int i = 0; i < numCourses; i++)
            {
                if (indegree[i] == 0)
                    help.AddLast(i);
            }

            int count = 0;                              // 已学的课程数
            while (help.Count != 0)
            {
                // 当前学习的课程  C++: int visited = help.front()
                int visited = help.First.Value;
                count++;
                rtn.Add(visited);

                // 学完，出队
                help.RemoveFirst();
                // 将刚学完的课程的所有后续课程的入度减一
                for (int i = 0; i < adjacency[visited].Count; i++)
                {
                    indegree[adjacency[visited][i]]--;
                    // 如果有后续课程的入度减为零了，则其变为了自由课程，加入队列
                    if (indegree[adjacency[visited][i]] == 0)
                        help.AddLast(adjacency[visited][i]);
                }
            }
            // 如果学完的课程数=课程总数则返回true，否则返回false
            if (count != numCourses)
                rtn.Clear();
            return rtn.ToArray();
        }
    }
    // @lc code=end


}
