using System;
using System.Collections.Generic;
namespace CSharpConsoleApp.Solutions
{
    /*
     * @lc app=leetcode.cn id=587 lang=csharp
     *
     * [587] 安装栅栏
     *
     * https://leetcode-cn.com/problems/erect-the-fence/description/
     *
     * Category	Difficulty	Likes	Dislikes
     * algorithms	Hard (36.51%)	69	-
     * Tags
     * geometry
     * 
     * Companies
     * google
     * 
     * Total Accepted:    1.7K
     * Total Submissions: 4.8K
     * Testcase Example:  '[[1,1],[2,2],[2,0],[2,4],[3,3],[4,2]]'
     *
     * 在一个二维的花园中，有一些用 (x, y)
     * 坐标表示的树。由于安装费用十分昂贵，你的任务是先用最短的绳子围起所有的树。只有当所有的树都被绳子包围时，花园才能围好栅栏。你需要找到正好位于栅栏边界上的树的坐标。
     * 
     * 
     * 示例 1:
     * 输入: [[1,1],[2,2],[2,0],[2,4],[3,3],[4,2]]
     * 输出: [[1,1],[2,0],[4,2],[3,3],[2,4]]
     * 解释:
     * 
     * 
     * 示例 2:
     * 输入: [[1,2],[2,2],[4,2]]
     * 输出: [[1,2],[2,2],[4,2]]
     * 解释:
     * 
     * 即使树都在一条直线上，你也需要先用绳子包围它们。
     *
     * 
     * 注意:
     * 所有的树应当被围在一起。你不能剪断绳子来包围树或者把树分成一组以上。
     * 输入的整数在 0 到 100 之间。
     * 花园至少有一棵树。
     * 所有树的坐标都是不同的。
     * 输入的点没有顺序。输出顺序也没有要求。
     * 
     */
    public class Solution587 : SolutionBase
    {
        /// <summary>
        /// 难度
        /// </summary>
        public override Difficulity GetDifficulity() { return Difficulity.Hard; }
        /// <summary>
        /// 关键字:
        /// </summary>
        public override string[] GetKeyWords() { return new string[] { "游戏开发", "图形学", }; }
        /// <summary>
        /// 标签： 
        /// </summary>
        public override Tag[] GetTags() { return new Tag[] { Tag.Geometry }; }

        public override bool Test(System.Diagnostics.Stopwatch sw)
        {
            bool isSuccess = true;
            int[][] trees;
            int[][] result;
            int[][] checkResult;

            //nums = new int[] { 2, 6, 4, 8, 10, 9, 15  };
            //checkResult = 5;
            //result = FindUnsortedSubarray(nums);
            //isSuccess &= result == checkResult;
            //Print("isSuccess = {0} | result = {1} | anticipated = {2}", isSuccess, result, checkResult);
            //
            //nums = new int[] { 1, 2, 3, 4 };
            //checkResult = 0;
            //result = FindUnsortedSubarray(nums);
            //isSuccess &= result == checkResult;
            //Print("isSuccess = {0} | result = {1} | anticipated = {2}", isSuccess, result, checkResult);

            trees = new int[][] {
                new int[] {1, 1 },
                new int[] {1, 1 },
                new int[] {1, 1 },
                new int[] {1, 1 },
                new int[] {1, 1 },
            };
            checkResult = new int[][] {
                new int[] {1, 1 },
                new int[] {1, 1 },
                new int[] {1, 1 },
                new int[] {1, 1 },
                new int[] {1, 1 },
            };
            result = OuterTrees(trees);
            isSuccess &= result == checkResult;
            Print("isSuccess = {0} | result = {1} | anticipated = {2}", isSuccess, result, checkResult);

            return isSuccess;
        }
        /// <summary>
        /// 方法 1： Jarvis 算法 [Accepted]
        /// 时间复杂度： O(m*n)  m 是凸包上的点数, n 是输入的点数
        /// 空间复杂度： O(m)
        /// 84/84 cases passed (360 ms)
        /// Your runtime beats 100 % of csharp submissions
        /// Your memory usage beats 100 % of csharp submissions(34.7 MB)
        /// 作者：LeetCode
        /// 链接：https://leetcode-cn.com/problems/erect-the-fence/solution/an-zhuang-zha-lan-by-leetcode/
        /// </summary>
        /// <param name="trees"></param>
        /// <returns></returns>
        public int[][] OuterTrees(int[][] points)
        {
            HashSet<int[]> hull = new HashSet<int[]>();
            if (points.Length < 4)
            {
                for (int i = 0; i < points.Length; i++)
                {
                    hull.Add(points[i]);
                }
                return GetHashSetDatas(hull);
            }

            int left_most = 0;
            for (int i = 0; i < points.Length; i++)
                if (points[i][0] < points[left_most][0])
                    left_most = i;
            int p = left_most;
            do
            {
                int q = (p + 1) % points.Length;
                for (int i = 0; i < points.Length; i++)
                {
                    if (Orientation(points[p], points[i], points[q]) < 0)
                    {
                        q = i;
                    }
                }
                for (int i = 0; i < points.Length; i++)
                {
                    if (i != p && i != q && Orientation(points[p], points[i], points[q]) == 0 && InBetween(points[p], points[i], points[q]))
                    {
                        hull.Add(points[i]);
                    }
                }
                hull.Add(points[q]);
                p = q;
            }
            while (p != left_most);

            return GetHashSetDatas(hull);
        }

        public int[][] GetHashSetDatas(HashSet<int[]> hull)
        {
            List<int[]> list = new List<int[]>();
            foreach (int[] point in hull)
                list.Add(point);
            return list.ToArray();
        }

        public int Orientation(int[] p, int[] q, int[] r)
        {
            return (q[1] - p[1]) * (r[0] - q[0]) - (q[0] - p[0]) * (r[1] - q[1]);
        }
        public bool InBetween(int[] p, int[] i, int[] q)
        {
            bool a = i[0] >= p[0] && i[0] <= q[0] || i[0] <= p[0] && i[0] >= q[0];
            bool b = i[1] >= p[1] && i[1] <= q[1] || i[1] <= p[1] && i[1] >= q[1];
            return a && b;
        }
    }
}
