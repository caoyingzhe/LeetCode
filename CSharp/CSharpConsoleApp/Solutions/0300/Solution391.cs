using System;
using System.Collections.Generic;
namespace CSharpConsoleApp.Solutions
{
    /*
     * @lc app=leetcode.cn id=391 lang=csharp
     *
     * [391] 完美矩形
     *
     * https://leetcode-cn.com/problems/perfect-rectangle/description/
     *
     * Category	Difficulty	Likes	Dislikes
     * algorithms	Hard (33.54%)	76	-
     * Tags
     * line-sweep
     * 
     * Companies
     * google
     * 
     * Total Accepted:    3.6K
     * Total Submissions: 10.6K
     * Testcase Example:  '[[1,1,3,3],[3,1,4,2],[3,2,4,4],[1,3,2,4],[2,3,3,4]]'
     *
     * 我们有 N 个与坐标轴对齐的矩形, 其中 N > 0, 判断它们是否能精确地覆盖一个矩形区域。
     * 
     * 每个矩形用左下角的点和右上角的点的坐标来表示。例如， 一个单位正方形可以表示为 [1,1,2,2]。 ( 左下角的点的坐标为 (1, 1)
     * 以及右上角的点的坐标为 (2, 2) )。
     * 
     * 示例 1:
     * rectangles = [
     * ⁠  [1,1,3,3],
     * ⁠  [3,1,4,2],
     * ⁠ [ 3,2,4,4],
     * ⁠ [1,3,2,4],
     * ⁠ [2,3,3,4]
     * ]
     * 返回 true。5个矩形一起可以精确地覆盖一个矩形区域。
     * 
     * 示例 2:
     * rectangles = [
     * ⁠ [1,1,2,3],
     * ⁠ [1,3,2,4],
     * ⁠ [3,1,4,2],
     * ⁠ [3,2,4,4]
     * ]
     * 返回 false。两个矩形之间有间隔，无法覆盖成一个矩形。
     * 
     * 示例 3:
     * rectangles = [
     * ⁠ [1,1,3,3],
     * ⁠ [3,1,4,2],
     * ⁠ [1,3,2,4],
     * ⁠ [3,2,4,4]
     * ]
     * 返回 false。图形顶端留有间隔，无法覆盖成一个矩形。
     * 
     * 示例 4:
     * rectangles = [
     * ⁠ [1,1,3,3],
     * ⁠ [3,1,4,2],
     * ⁠ [1,3,2,4],
     * ⁠ [2,2,4,4]
     * ]
     * 
     * 返回 false。因为中间有相交区域，虽然形成了矩形，但不是精确覆盖。
     * 
     */

    public class Solution391 : SolutionBase
    {
        /// <summary>
        /// 难度
        /// </summary>
        public override Difficulity GetDifficulity() { return Difficulity.Hard; }
        /// <summary>
        /// 关键字:
        /// </summary>
        public override string[] GetKeyWords() { return new string[] { "扫描线算法", }; }
        /// <summary>
        /// 标签：
        /// </summary>
        public override Tag[] GetTags() { return new Tag[] { Tag.LineSweep }; }


        /// <summary>
        /// Runtime Error
        /// 42/46 cases passed(N/A)
        /// OutOfMemoryException 内存空间不够用
        /// </summary>
        /// <param name="sw"></param>
        /// <returns></returns>
        public override bool Test(System.Diagnostics.Stopwatch sw)
        {
            bool isSuccess = true;
            int[][] rectrangles;
            bool result; bool checkResult;

            rectrangles = new int[][] {
                new int[] {1,1,3,3},
                new int[] {3,1,4,2},
                new int[] {3,2,4,4},
                new int[] {1,3,2,4},
                new int[] {2,3,3,4}
            };
            
            result = IsRectangleCover(rectrangles);
            checkResult = true;
            isSuccess &= checkResult == result;
            Print("isSuccess = {0} | result ={1} | checkResult = {2}", isSuccess, result, checkResult);

            rectrangles = new int[][] {
                new int[]{0,0,4,1},
                new int[]{7,0,8,2},
                new int[]{6,2,8,3},
                new int[]{5,1,6,3},
                new int[]{4,0,5,1},
                new int[]{6,0,7,2},
                new int[]{4,2,5,3},
                new int[]{2,1,4,3},
                new int[]{0,1,2,2},
                new int[]{0,2,2,3},
                new int[]{4,1,5,2},
                new int[]{5,0,6,1}
            };
            result = IsRectangleCover(rectrangles);

            checkResult = false;
            isSuccess &= checkResult == result;
            Print("isSuccess = {0} | result ={1} | checkResult = {2}", isSuccess, result, checkResult);

            //非常好的例子，只出现1次顶点=4，但是不符合要求。出现重叠区域
            rectrangles = new int[][] {
                new int[]{ 0,0,3,3 },
                new int[]{ 1,1,2,2 },
                new int[]{ 1,1,2,2 }
            };
            result = IsRectangleCover(rectrangles);

            checkResult = false;
            isSuccess &= checkResult == result;
            Print("isSuccess = {0} | result ={1} | checkResult = {2}", isSuccess, result, checkResult);
            
            
            rectrangles = new int[][] {
                 new int[] {1,1,2,3},
                 new int[] {1,3,2,4},
                 new int[] {3,1,4,2},
                 new int[] {3,2,4,4}
            };
            result = IsRectangleCover(rectrangles);
            checkResult = false;
            isSuccess &= checkResult == result;
            Print("isSuccess = {0} | result ={1} | checkResult = {2}", isSuccess, result, checkResult);

            rectrangles = new int[][] {
                new int[] {1,1,3,3},
                new int[] {3,1,4,2},
                new int[] {1,3,2,4},
                new int[] {3,2,4,4}
            };
            result = IsRectangleCover(rectrangles);
            checkResult = false;
            isSuccess &= checkResult == result;
            Print("isSuccess = {0} | result ={1} | checkResult = {2}", isSuccess, result, checkResult);

            rectrangles = new int[][] {
                new int[] {1,1,3,3},
                new int[] {3,1,4,2},
                new int[] {1,3,2,4},
                new int[] {2,2,4,4}
            };
            result = IsRectangleCover(rectrangles);
            checkResult = false;
            isSuccess &= checkResult == result;
            Print("isSuccess = {0} | result ={1} | checkResult = {2}", isSuccess, result, checkResult);
            
            return isSuccess;
        }

        public bool IsRectangleCover(int[][] rectangles)
        {
            //return IsRectangleCover_OutOfMemory(rectangles);
            //return IsRectangleCover_Point4(rectangles);
            return IsRectangleCover_LineSweep(rectangles);
        }
        /// <summary>
        /// Runtime Error
        /// 42/46 cases passed(N/A)
        /// OutOfMemoryException 内存空间不够用
        /// </summary>
        /// <param name="rectangles"></param>
        /// <returns></returns>
        public bool IsRectangleCover_OutOfMemory(int[][] rectangles)
        {
            //SortedList<int[], int> sortList = new SortedList<int[], int>();

            int minX = int.MaxValue, minY = int.MaxValue;
            int maxX = int.MinValue, maxY = int.MinValue;

            //小砖块总数量
            int blockCount = 0;
            for(int i=0; i<rectangles.Length; i++)
            {
                int[] rect = rectangles[i];

                //sortList.Add(rect, 1);

                minX = Math.Min(minX, rect[0]);
                minY = Math.Min(minY, rect[1]);
                maxX = Math.Max(maxX, rect[2]);
                maxY = Math.Max(maxY, rect[3]);

                blockCount += (rect[2] - rect[0]) * (rect[3] - rect[1]);
            }
            int m = maxY - minY;
            int n = maxX - minX;

            //Print("block = {0} | minXY= [{1},{2}] | maxXY= [{3},{4}] m * n = {5} * {6} = {7} ", blockCount, minX, minY, maxX, maxY, m, n, m*n);
            //小砖块总数量不同于矩形的小砖块总数量，一定不对。（不是重叠，就是有空洞，或者两者兼有）
            if ( blockCount != (maxX - minX) * (maxY - minY))
            {
                return false;
            }

           
            //是否完全匹配。所有区域不可重叠。
            int[,] matrix = new int[m,n];

            for(int i=0; i< rectangles.Length; i++)
            {
                if (FillMatrix(rectangles[i], matrix, minX, minY, m, n) == false)
                    return false;
            }
            return true;
        }

        private bool FillMatrix(int[] rect, int[,] matrix, int minX, int minY, int m, int n)
        {
            int iFrom = rect[1] - minY;
            int iTo = rect[3] - minY -1 ;

            int jFrom = rect[0] - minX;
            int jTo = rect[2] - minX - 1;

            for (int i = iFrom ; i <= iTo; i++)
            {
                for (int j = jFrom; j <= jTo; j++)
                {
                    if (matrix[i, j] == 1)
                    {
                        //Print(" >>>>  duplicated | i= {0} j= {1}", i, j);
                        //Print(" >>>>  rect= {1}, | minXY= [{2},{3}] | matrix = \n{0}\n", GetArray2DStr(matrix, m, n), GetArrayStr(rect), minX, minY);
                        return false;
                    }
                    matrix[i,j] = 1;
                }
            }
            //Print(" >>>>  rect= {1}, | minXY= [{2},{3}] | matrix = \n{0}\n", GetArray2DStr(matrix, m, n), GetArrayStr(rect), minX, minY);
            return true;
        }

        /// <summary>
        /// 判定准则：只出现1次的顶点只有四个，并且矩形面积和最大最小位置组成的大矩形的面积相等。
        /// https://leetcode-cn.com/problems/perfect-rectangle/solution/java-cong-dian-dao-mian-li-jie-wan-mei-ju-xing-wen/
        /// </summary>
        /// <param name="rectangles"></param>
        /// <returns></returns>
        public bool IsRectangleCover_Point4(int[][] rectangles)
        {
            int minX = int.MaxValue, minY = int.MaxValue;
            int maxX = int.MinValue, maxY = int.MinValue;
            //小砖块总数量（即面积）
            int blockCount = 0;

            //用于判断是否存在重复区域矩形的字典
            HashSet<string> rectSet = new HashSet<string>();
            //用来计数各个顶点的出现次数矩形（该数据可简化为HashSet，只记录出现一次的顶点）
            Dictionary<string,int> pointSet = new Dictionary<string, int>();
            for (int i = 0; i < rectangles.Length; i++)
            {
                int[] rect = rectangles[i];

                //更新大矩形的最大最小边界
                minX = Math.Min(minX, rect[0]);
                minY = Math.Min(minY, rect[1]);
                maxX = Math.Max(maxX, rect[2]);
                maxY = Math.Max(maxY, rect[3]);

                //更新矩形总面积
                blockCount += (rect[2] - rect[0]) * (rect[3] - rect[1]);

                //判断是否存在重复矩形区域
                string rectName = string.Format("{0}|{1}|{2}|{3}", rect[0], rect[1], rect[2], rect[3]);
                if (rectSet.Contains(rectName))
                    return false;
                else
                    rectSet.Add(rectName);

                //添加矩形4顶点数据
                string[] points = new string[] {
                    string.Format("{0}|{1}", rect[0], rect[1]),
                    string.Format("{0}|{1}", rect[0], rect[3]),
                    string.Format("{0}|{1}", rect[2], rect[1]),
                    string.Format("{0}|{1}", rect[2], rect[3])
                };

                for(int p=0; p<4; p++)
                {
                    if(pointSet.ContainsKey(points[p]))
                    {
                        pointSet[points[p]] += 1; //计数， 可以改进连计数都不用了，直接删除。如果超过2次，最终出现1次的顶点不止4个，非常容易判读是否为完美矩形。
                    }
                    else
                    {
                        pointSet.Add(points[p], 1);
                    }
                }
            }
            //小砖块总数量不同于矩形的小砖块总数量，一定不对。（不是重叠，就是有空洞，或者两者兼有）
            if (blockCount != (maxX - minX) * (maxY - minY))
            {
                return false;
            }

            //判断是否为大矩形区域的四顶点。
            int onlyOncePointCount = 0;
            int ld = 0, lu = 0, rd = 0, ru = 0;
            foreach (string point in pointSet.Keys)
            {
                if(pointSet[point] == 1)
                {
                    onlyOncePointCount += 1;
                    if (point == string.Format("{0}|{1}", minX, minY))
                    {
                        ld = 1;
                    }
                    else if (point == string.Format("{0}|{1}", minX, maxY))
                    {
                        lu = 1;
                    }
                    else if (point == string.Format("{0}|{1}", maxX, minY))
                    {
                        rd = 1;
                    }
                    else if (point == string.Format("{0}|{1}", maxX, maxY))
                    {
                        ru = 1;
                    }
                    else
                    {
                        return false;
                    }
                }
            }

            //是大矩形区域的四顶点，返回True
            if (onlyOncePointCount == 4 &&  ld * lu * rd * ru == 1)
            {
                return true;
            }
            return false;
        }

        private class Triplet
        {
            public int x;
            public int y;
            public int h;

            public Triplet(int x, int y, int h)
            {
                this.x = x;
                this.y = y;
                this.h = h;
            }
        }

        /// <summary>
        /// 扫描线法
        /// 作者：wotxdx
        /// 链接：https://leetcode-cn.com/problems/perfect-rectangle/solution/sao-miao-xian-suan-fa-han-dong-hua-tu-jie-by-wotxd/
        /// </summary>
        /// <param name="rectangles"></param>
        /// <returns></returns>
        public bool IsRectangleCover_LineSweep(int[][] rectangles)
        {
            // 左上角 右下角坐标
            // 将 rectangles 转换 三元组 [x y h]
            List<Triplet> triplets = new List<Triplet>();
            //TreeSet<Triplet> triplets = new TreeSet<>((o1, o2)-> {
            //    if (o1.x != o2.x) return o1.x - o2.x;
            //    if (o1.h * o2.h < 0) return o1.h < 0 ? -1 : 1; // 正数 和 负数要分类，负数在左，正数在右
            //    if (o1.y != o2.y) return o1.y - o2.y;
            //    return 1; // 保证重复且有序 ，例如这个用例：[[0,0,4,1],[0,0,4,1]]
            //});
            foreach (int[] rectangle in rectangles) {
                triplets.Add(new Triplet(rectangle[0], rectangle[1], rectangle[3] - rectangle[1])); // 左端点的高度为正
                triplets.Add(new Triplet(rectangle[2], rectangle[1], rectangle[1] - rectangle[3])); // 右端点的高度为负
            }
            triplets.Sort((o1, o2) => {
                if (o1.x != o2.x) return o1.x - o2.x;
                if (o1.h * o2.h < 0) return o1.h < 0 ? -1 : 1; // 正数 和 负数要分类，负数在左，正数在右
                if (o1.y != o2.y) return o1.y - o2.y;
                return 1; // 保证重复且有序 ，例如这个用例：[[0,0,4,1],[0,0,4,1]]
            });
            // 创建优先队列
            //PriorityQueue<int> queue = new PriorityQueue<int>();
            SortedList<int,int> queue = new SortedList<int, int>();
            // 边界上下 宽度
            int high = 0, low = 0, width = 0;
            // 记录横坐标的变化
            int axis = triplets[0].x;

            // 以第一个左边界作为标准

            low = triplets[0].y;
            foreach (Triplet triplet in triplets) {
                if (axis == triplet.x) {
                    high = triplet.y + triplet.h;
                } else break;
            }
            width = high - low;

            // 临时宽度; 临时上界
            int cur_w = 0, cur_h = int.MinValue;

            // 正数入堆 负数出堆
            foreach (Triplet triplet in triplets) {
                // 判断 是否出界
                if (triplet.x<low) return false;
                if (triplet.y + triplet.h > high) return false;

                if (axis != triplet.x) {
                    if (cur_w != width) return false;
                    cur_h = triplet.y;
                    axis = triplet.x;
                } else if (triplet.y<cur_h) {
                    return false;
                }

                if (triplet.h > 0) cur_h = triplet.y + triplet.h;

                if (triplet.h > 0)
                {
                    if (queue.ContainsKey(triplet.h))
                        queue[triplet.h] += 1;
                    else
                        queue.Add(triplet.h, triplet.h);
                }
                else if (triplet.h < 0)
                {
                    if (queue[-triplet.h] == 1) //queue.ContainsKey(triplet.h))
                        queue.Remove(-triplet.h);
                    else
                        queue[-triplet.h] -= 1;
                }
                cur_w += triplet.h;
            }
            return true;
         }


        /// <summary>
        /// 扫描线法？？？
        /// https://leetcode-cn.com/problems/perfect-rectangle/solution/java-cong-dian-dao-mian-li-jie-wan-mei-ju-xing-wen/
        /// </summary>
        /// <param name="rectangles"></param>
        /// <returns></returns>
        public bool IsRectangleCover_LineSweep2(int[][] rectangles)
        {
            //List<int[]> sortList = new List<int[]>();

            int minX = int.MaxValue, minY = int.MaxValue;
            int maxX = int.MinValue, maxY = int.MinValue;

            //小砖块总数量
            int blockCount = 0;

            HashSet<int[]> pointSet = new HashSet<int[]>();
            for (int i = 0; i < rectangles.Length; i++)
            {
                int[] rect = rectangles[i];

                //sortList.Add(rect);

                int[][] points = new int[][] {
                    new int[] { rect[0], rect[1] },
                    new int[] { rect[0], rect[3] },
                    new int[] { rect[2], rect[1] },
                    new int[] { rect[2], rect[3] }
                };

                for (int p = 0; p < 4; p++)
                {
                    if (pointSet.Contains(points[p]))
                    {
                        pointSet.Remove(points[p]); //连计数都不用了，直接删除。如果超过2次，最终出现1次的顶点不止4个，非常容易判读是否为完美矩形。
                    }
                    else
                    {
                        pointSet.Add(points[p]);
                    }
                }

                minX = Math.Min(minX, rect[0]);
                minY = Math.Min(minY, rect[1]);
                maxX = Math.Max(maxX, rect[2]);
                maxY = Math.Max(maxY, rect[3]);

                blockCount += (rect[2] - rect[0]) * (rect[3] - rect[1]);
            }

            //sortList.Sort((a, b) => {
            //    if(a[0] != b[0])
            //    {
            //        return b[0] - a[0];
            //    }
            //    else if (a[2] != b[2])
            //    {
            //        return b[2] - a[2];
            //    }
            //    else if (a[1] != b[1])
            //    {
            //        return b[1] - a[1];
            //    }
            //    else if (a[3] != b[3])
            //    {
            //        return b[3] - a[3];
            //    }
            //    return 0;
            //}); //按照 元素数组  x降序，y升序排序

            int m = maxY - minY;
            int n = maxX - minX;

            //Print("block = {0} | minXY= [{1},{2}] | maxXY= [{3},{4}] m * n = {5} * {6} = {7} ", blockCount, minX, minY, maxX, maxY, m, n, m*n);
            //小砖块总数量不同于矩形的小砖块总数量，一定不对。（不是重叠，就是有空洞，或者两者兼有）
            if (blockCount != (maxX - minX) * (maxY - minY))
            {
                return false;
            }

            return true;
        }
    }
}
