using System;
using System.Collections.Generic;
namespace CSharpConsoleApp.Solutions
{
    /*
 * @lc app=leetcode.cn id=207 lang=csharp
 *
 * [207] 课程表
 *
 * https://leetcode-cn.com/problems/course-schedule/description/
 *
 * Category	Difficulty	Likes	Dislikes
 * algorithms	Medium (54.60%)	845	-
 * Tags
 * depth-first-search | breadth-first-search | graph | topological-sort
 * 
 * Companies
 * apple | uber | yelp | zenefits
 * 
 * Total Accepted:    117.8K
 * Total Submissions: 215.8K
 * Testcase Example:  '2\n[[1,0]]'
 *
 * 你这个学期必须选修 numCourses 门课程，记为 0 到 numCourses - 1 。
 * 在选修某些课程之前需要一些先修课程。 先修课程按数组 prerequisites 给出，其中 prerequisites[i] = [ai, bi]
 * ，表示如果要学习课程 ai 则 必须 先学习课程  bi 。
 * 例如，先修课程对 [0, 1] 表示：想要学习课程 0 ，你需要先完成课程 1 。
 * 请你判断是否可能完成所有课程的学习？如果可以，返回 true ；否则，返回 false 。
 * 
 * 
 * 示例 1：
 * 输入：numCourses = 2, prerequisites = [[1,0]]
 * 输出：true
 * 解释：总共有 2 门课程。学习课程 1 之前，你需要完成课程 0 。这是可能的。
 * 
 * 示例 2：
 * 输入：numCourses = 2, prerequisites = [[1,0],[0,1]]
 * 输出：false
 * 解释：总共有 2 门课程。学习课程 1 之前，你需要先完成​课程 0 ；并且学习课程 0 之前，你还应先完成课程 1 。这是不可能的。
 * 
 * 
 * 提示：
 * 1 <= numCourses <= 105
 * 0 <= prerequisites.length <= 5000
 * prerequisites[i].length == 2
 * 0 i, bi < numCourses
 * prerequisites[i] 中的所有课程对 互不相同
 */

    // @lc code=start
    public class Solution207 : SolutionBase
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

            bool result, checkResult;

            numCourses = 2;
            prerequisites = new int[][] {
                new int[] { 1, 0 }
            };
            checkResult = true;
            result = CanFinish(numCourses, prerequisites);
            isSuccess &= IsSame(result, checkResult);
            Print("isSuccess = {0} | result= {1} | checkResult= {2} | ", isSuccess, (result), (checkResult));

            numCourses = 2;
            prerequisites = new int[][] {
                new int[] { 1, 0 },
                new int[] { 0, 1 }
            };
            checkResult = false;
            result = CanFinish(numCourses, prerequisites);
            isSuccess &= IsSame(result, checkResult);
            Print("isSuccess = {0} | result= {1} | checkResult= {2} | ", isSuccess, (result), (checkResult));
            return isSuccess;
        }

        //作者：Terry2020
        //链接：https://leetcode-cn.com/problems/course-schedule/solution/rang-ni-miao-dong-de-bao-mu-ji-tuo-bu-pa-o4b1/ 
        /// <summary>
        /// 49/49 cases passed (132 ms)
        /// Your runtime beats 79.1 % of csharp submissions
        /// Your memory usage beats 95.52 % of csharp submissions(29.2 MB)
        /// </summary>
        /// <param name="numCourses"></param>
        /// <param name="prerequisites"></param>
        /// <returns></returns>
        public bool CanFinish(int numCourses, int[][] prerequisites)
        {
            int n = prerequisites.Length;
            // 没有依赖关系，必然能完成所有课程的学习
            if (n == 0) return true;
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
            return count == numCourses;
        }
    }
    // @lc code=end


}
