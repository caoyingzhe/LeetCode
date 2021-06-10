using System;
using System.Collections.Generic;
namespace CSharpConsoleApp.Solutions
{
    /*
     * @lc app=leetcode.cn id=149 lang=csharp
     *
     * [149] 直线上最多的点数
     *
     * https://leetcode-cn.com/problems/max-points-on-a-line/description/
     *
     * Category	Difficulty	Likes	Dislikes
     * algorithms	Hard (25.51%)	244	-
     * Tags
     * hash-table | math
     * 
     * Companies
     * apple | linkedin | twitter
     * 
     * Total Accepted:    23.9K
     * Total Submissions: 93.1K
     * Testcase Example:  '[[1,1],[2,2],[3,3]]'
     *
     * 给定一个二维平面，平面上有 n 个点，求最多有多少个点在同一条直线上。
     * 
     * 示例 1:
     * 
     * 输入: [[1,1],[2,2],[3,3]]
     * 输出: 3
     * 解释:
     * ^
     * |
     * |        o
     * |     o
     * |  o  
     * +------------->
     * 0  1  2  3  4
     * 
     * 
     * 示例 2:
     * 
     * 输入: [[1,1],[3,2],[5,3],[4,1],[2,3],[1,4]]
     * 输出: 4
     * 解释:
     * ^
     * |
     * |  o
     * |     o        o
     * |        o
     * |  o        o
     * +------------------->
     * 0  1  2  3  4  5  6
     * 
     */
    public class Solution149 : SolutionBase
    {
        /// <summary>
        /// 难度
        /// </summary>
        public override Difficulity GetDifficulity() { return Difficulity.Hard; }
        /// <summary>
        /// 关键字:
        /// </summary>
        public override string[] GetKeyWords() { return new string[] { "点在直线上", "斜率精度"}; }
        /// <summary>
        /// 标签：
        /// </summary>
        public override Tag[] GetTags() { return new Tag[] { Tag.HashTable, Tag.Math, }; }

        public override bool Test(System.Diagnostics.Stopwatch sw)
        {
            bool isSuccess = true;
            int[][] points; int result, checkResult;

            points = new int[][]
            {
                new int[] { 1,1},
                new int[] { 3,2},
                new int[] { 5,3},
                new int[] { 4,1},
                new int[] { 2,3},
                new int[] { 1,4},
            };
            checkResult = 4;

            result = MaxPoints(points);

            isSuccess &= result == checkResult;
            Print("isSuccess = {0} | result = {1} | anticipated = {2}", isSuccess, (result), (checkResult));
            
            return isSuccess;
        }

        /// <summary>
        /// 关键处理：使用了字符串存储斜率，避免了精度误差。
        /// 关键函数：GCD（递归求最大公约数）
        /// https://leetcode-cn.com/problems/max-points-on-a-line/solution/javamei-ju-fa-si-lu-jian-dan-by-vigilant-5iu4/
        /// 33/33 cases passed (120 ms)
        /// Your runtime beats 72.41 % of csharp submissions
        /// Your memory usage beats 48.28 % of csharp submissions(26.4 MB)
        /// </summary>
        /// <param name="points"></param>
        /// <returns></returns>
        public int MaxPoints(int[][] points)
        {
            //Print("" + gcd(42, 70)); //14
            if (points == null || points.Length < 1) return 0;
            int N = points.Length;
            Point[] pointsAry = new Point[N];
            for (int i = 0; i < N; i++)
            {
                pointsAry[i] = new Point(points[i][0], points[i][1]);
            }
            return process(pointsAry);
        }

        private int process(Point[] points)
        {
            int res = 0;
            Dictionary<string, int> lineThrough = new Dictionary<string, int>();//注意：这里存的都是线上不同点，没有重合的
            int N = points.Length;
            for (int point = 0; point < N; point++)
            {
                lineThrough.Clear();//上一个点搞定了，现在看下一个点了
                int samePoint = 1;//不用重合，就看自己就有一个点了
                int maxLineThrough = 0;
                for (int next = point + 1; next < N; next++)
                {
                    int y = points[next].y - points[point].y;
                    int x = points[next].x - points[point].x;
                    if (y == 0 && x == 0)
                    {
                        samePoint++;
                    }
                    else
                    {
                        string theLine = formatFraction(y, x);

                        if (!lineThrough.ContainsKey(theLine))
                            lineThrough.Add(theLine, 0);
                        lineThrough[theLine] += 1;
                        maxLineThrough = Math.Max(maxLineThrough, lineThrough[theLine]);
                    }
                }
                res = Math.Max(res, samePoint + maxLineThrough);
            }
            return res;
        }

        //进来的时候son和mum不能同时为0，那时重合的答案，自己外面处理去
        private string formatFraction(int son, int mum)
        {
            if (son == 0)
            {
                return "0";
            }
            if (mum == 0)
            {
                return "~";
            }
            int theyGcd = gcd(son, mum);
            son /= theyGcd;
            mum /= theyGcd;
            if (son < 0 && mum < 0)
            {
                son = -son;
                mum = -mum;
            }
            if (mum < 0)
            {   //能进这里说明son肯定大于0
                son = -son;
                mum = -mum;
            }
            return son + "_" + mum;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="a">分子</param>
        /// <param name="b">分母</param>
        /// <returns></returns>
        public int gcd(int a, int b)
        {
            if (b == 0) return a;
            return gcd(b, a % b);
        }
    }

    public class Point
    {
        public int x;
        public int y;

        public Point(int x, int y)
        {
            this.x = x;
            this.y = y;
        }
    }
}
