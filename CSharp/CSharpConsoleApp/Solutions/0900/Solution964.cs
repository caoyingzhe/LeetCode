using System;
using System.Collections.Generic;

namespace CSharpConsoleApp.Solutions
{
    public class Solution964
    {

        #region
        /// <summary>
        /// 该方法效率不佳，原因可能是字典的Key过长（long+double+double字符串过长）
        /// 109/109 cases passed (332 ms)
        /// Your runtime beats 16.67 % of csharp submissions
        /// Your memory usage beats 16.67 % of csharp submissions(40.9 MB)
        /// </summary>
        /// <param name="p1"></param>
        /// <param name="p2"></param>
        /// <returns></returns>

        //https://leetcode-cn.com/problems/minimum-area-rectangle-ii/solution/zhong-gui-zhong-ju-qiu-zui-xiao-ju-xing-600y6/
        //一定可以组成矩形的条件：
        //    只要找到了两组对顶点，它们的中心重合；
        //    并且表示的对角线长度相等；
        //
        //解题思路 ：
        //    可以遍历任意两个顶点，求出它们之间的距离，和中心点的坐标
        //    这样能组成矩形的点就被归类到一起，存入HashMap
        //    遍历 HashMap 求出最大解

        long GetDistance(int[] p1, int[] p2) {
            return (p1[0] - p2[0]) * (p1[0] - p2[0]) + (p1[1] - p2[1]) * (p1[1] - p2[1]);
        }

        double GetEuclidianDist(int[] p1, int[] p2)
        {
            return Math.Sqrt(GetDistance(p1, p2));
        }

        double[] GetCenter(int[] p1, int[] p2)
        {
            double x = (p1[0] + p2[0]) / 2.0;
            double y = (p1[1] + p2[1]) / 2.0;
            return new double[] { x, y};
        }

        //double calcMinArea(
        //    const unordered_map<string, vector<vector<int>>>& mp,
        //    const vector<vector<int>>& points)
        double CalcMinArea(Dictionary<string, List<int[]>> mp, int[][] points)
        {
            double minArea = double.MaxValue; // c++: DBL_MAX;
            foreach (List<int[]> vec in mp.Values) {
                if (vec.Count < 2)
                {
                    continue;
                }
                for (int i = 0; i < vec.Count; i++)
                {
                    for (int j = i + 1; j < vec.Count; j++)
                    {
                        // The vector from points 1 to points2 are orthogonal to
                        // the vector from points 1 to 3
                        int p1 = vec[i][0]; // point 1 of the rectangle
                        int p2 = vec[j][0]; // point 2 of the rectangle
                        int p3 = vec[j][1]; // point 3 of the rectangle
                        double curArea = GetEuclidianDist(points[p1], points[p2]) * GetEuclidianDist(points[p1], points[p3]);
                        minArea = Math.Min(minArea, curArea);
                    }
                }
            }

            return minArea == double.MaxValue ? 0.0 : minArea;
        }

        //double minAreaFreeRect(vector<vector<int>>& points)
        public double MinAreaFreeRect(int[][] points)
        {
            int N = points.Length;
            if (N < 4)
            {
                return 0.0;
            }

            // Diagnoal of rectangle and center to points
            Dictionary<string, List<int[]>> mp = new Dictionary<string, List<int[]>>();
            for (int i = 0; i < N; i++)
            {
                for (int j = i + 1; j < N; j++)
                {
                    long dist = GetDistance(points[i], points[j]);
                    // cx : x value of center
                    // cy : y value of center
                    double[] center = GetCenter(points[i], points[j]);
                    string key = dist.ToString() + ":" + center[0].ToString() + ":" + center[1].ToString();

                    if (!mp.ContainsKey(key))
                        mp.Add(key, new List<int[]>());
                    mp[key].Add(new int[]{ i, j});
                }
            }

            double minArea = CalcMinArea(mp, points);
            return minArea;
       }

        #endregion
    }
}
