using System;
namespace CSharpConsoleApp.Solutions
{
    public class Solution1453
    {



        /// <summary>
        /// 作者：smilyt_
        /// 链接：https://leetcode-cn.com/problems/maximum-number-of-darts-inside-of-a-circular-dartboard/solution/c-xiang-liang-suan-yuan-xin-jian-dan-yi-dong-by-sm/
        /// 65/65 cases passed (156 ms)
        /// Your runtime beats 100 % of csharp submissions
        /// Your memory usage beats 100 % of csharp submissions(24.5 MB)
        /// </summary>
        struct Point
        {
            public double x, y;
            public Point(double x, double y)
            {
                this.x = x;
                this.y = y;
            }
        };

        //算两点距离
        double Dist(double x1, double y1, double x2, double y2)
        {
            return Math.Sqrt((x1 - x2) * (x1 - x2) + (y1 - y2) * (y1 - y2));
        }

        //计算圆心
        Point CircleCenter(Point a, Point b, int r)
        {
            //算中点
            Point mid = new Point((a.x+b.x)/ 2.0,(a.y + b.y) / 2.0);
            //AB距离的一半
            double d = Dist(a.x, a.y, mid.x, mid.y);
            //计算h
            double h = Math.Sqrt(r * r - d * d);
            //计算垂线
            Point ba = new Point(b.x-a.x,b.y - a.y);
            Point hd = new Point(-ba.y,ba.x);
            double len = Math.Sqrt(hd.x * hd.x + hd.y * hd.y);
            hd.x /= len; hd.y /= len;
            hd.x *= h; hd.y *= h;
            return new Point(hd.x + mid.x, hd.y + mid.y);
        }

        public int NumPoints(int[][] points, int r)
        {
            int n = points.Length;
            int ans = 0;
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (i == j)
                    {   //一个点
                        int cnt = 0;
                        for (int k = 0; k < n; k++)
                        {
                            double tmp = Dist(points[i][0], points[i][1], points[k][0], points[k][1]);
                            if (tmp <= r) cnt++;
                        }
                        ans = Math.Max(cnt, ans);
                    }
                    else
                    {   //两个点
                        //通过长度判断有没有圆心
                        double d = Dist(points[i][0], points[i][1], points[j][0], points[j][1]);
                        if (d / 2 > r) continue;

                        //求圆心
                        Point a = new Point(points[i][0], points[i][1]);
                        Point b = new Point(points[j][0], points[j][1]);
                        Point res = CircleCenter(a, b, r);
                        int cnt = 0;

                        //求该圆下包含点的个数（全遍历）
                        for (int k = 0; k < n; k++)
                        {
                            double tmp = Dist(res.x, res.y, points[k][0], points[k][1]);
                            if (tmp <= r) cnt++;
                        }
                        ans = Math.Max(cnt, ans);
                    }
                }
            }
            return ans;
        }
    }
}
