using System;
using System.Collections.Generic;
namespace CSharpConsoleApp.Solutions
{
    /*
 * @lc app=leetcode.cn id=690 lang=csharp
 *
 * [690] 员工的重要性
 *
 * https://leetcode-cn.com/problems/employee-importance/description/
 * 
 * Category	Difficulty	Likes	Dislikes
 * algorithms	Easy (64.54%)	231	-
 * Tags
 * hash-table | depth-first-search | breadth-first-search
 * 
 * Companies
 * uber
 * 
 * Total Accepted:    53.8K
 * Total Submissions: 83.3K
 * Testcase Example:  '[[1,5,[2,3]],[2,3,[]],[3,3,[]]]\n1'
 *
 * 给定一个保存员工信息的数据结构，它包含了员工 唯一的 id ，重要度 和 直系下属的 id 。
 * 
 * 比如，员工 1 是员工 2 的领导，员工 2 是员工 3 的领导。他们相应的重要度为 15 , 10 , 5 。那么员工 1 的数据结构是 [1,
 * 15, [2]] ，员工 2的 数据结构是 [2, 10, [3]] ，员工 3 的数据结构是 [3, 5, []] 。注意虽然员工 3 也是员工 1
 * 的一个下属，但是由于 并不是直系 下属，因此没有体现在员工 1 的数据结构中。
 * 
 * 现在输入一个公司的所有员工信息，以及单个员工 id ，返回这个员工和他所有下属的重要度之和。
 *
 * 
 * 示例：
 * 输入：[[1, 5, [2, 3]], [2, 3, []], [3, 3, []]], 1
 * 输出：11
 * 解释：
 * 员工 1 自身的重要度是 5 ，他有两个直系下属 2 和 3 ，而且 2 和 3 的重要度均为 3 。
 * 因此员工 1 的总重要度是 5 + 3 + 3 = 11 。
 * 
 * 
 * 提示：
 * 一个员工最多有一个 直系 领导，但是可以有多个 直系 下属
 * 员工数量不超过 2000 。
 */

    // @lc code=start
    /*
    // Definition for Employee.
    class Employee {
        public int id;
        public int importance;
        public IList<int> subordinates;
    }
    */

    class Solution690 : SolutionBase
    {
        /// <summary>
        /// 难度
        /// </summary>
        public override Difficulity GetDifficulity() { return Difficulity.Easy; }
        /// <summary>
        /// 关键字:
        /// </summary>
        public override string[] GetKeyWords() { return new string[] { "通过" }; }
        /// <summary>
        /// 标签：
        /// </summary>
        public override Tag[] GetTags() { return new Tag[] { Tag.HashTable, Tag.DepthFirstSearch, Tag.BreadthFirstSearch }; }


        /// <summary>
        /// </summary>
        /// <param name="sw"></param>
        /// <returns></returns>
        public override bool Test(System.Diagnostics.Stopwatch sw)
        {
            bool isSuccess = true;
            return isSuccess;
        }

        private Dictionary<int, Employee> dict = new Dictionary<int, Employee>();

        public int GetImportance(IList<Employee> employees, int id)
        {
            dict = new Dictionary<int, Employee>();
            foreach (var employee in employees)
            {
                dict.Add(employee.id, employee);
            }

            return BFS(employees, id);
            //return DFS(id);
        }

        /// <summary>
        /// 102/102 cases passed (64 ms)
        /// Your runtime beats 98.37 % of csharp submissions
        /// Your memory usage beats 29.27 % of csharp submissions(20.6 MB)
        /// </summary>
        private int DFS(int id)
        {
            if (!dict.ContainsKey(id)) return 0;

            Employee employee = dict[id];
            int sum = employee.importance;
            if (employee.subordinates != null)
            {
                for (int i = 0; i < employee.subordinates.Count; i++)
                {
                    sum += DFS(employee.subordinates[i]);
                }
            }
            return sum;
        }

        /// <summary>
        /// 102/102 cases passed (60 ms)
        /// Your runtime beats 100 % of csharp submissions
        /// Your memory usage beats 61.38 % of csharp submissions(20.4 MB)
        /// </summary>
        /// <param name="employees"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        private int BFS(IList<Employee> employees, int id)
        {
            int total = 0;
            Queue<int> queue = new Queue<int>();
            queue.Enqueue(id);//添加id到队列
            while (queue.Count > 0)
            {
                //把当前id，移出队列 
                int curId = queue.Dequeue();
                Employee employee = dict[curId];
                //累加计算重要度
                total += employee.importance;

                //添加子对象的id到队列
                IList<int> subordinates = employee.subordinates;
                foreach (int subId in subordinates)
                {
                    queue.Enqueue(subId);
                }
            }
            return total;
        }
        public class Employee
        {
            public int id;
            public int importance;
            public IList<int> subordinates;
        }
    }
    // @lc code=end


}
