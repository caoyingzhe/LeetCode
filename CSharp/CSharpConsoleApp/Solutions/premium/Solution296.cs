using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpConsoleApp.Solutions.premium
{
    /// <summary>
    /// A group of two or more people wants to meet and minimize the total travel distance. 
    /// You are given a 2D grid of values 0 or 1, where each 1 marks the home of someone in the group. 
    /// The distance is calculated using Manhattan Distance, where distance(p1, p2) = |p2.x - p1.x| + |p2.y - p1.y|.
    /// 
    /// Example:
    /// given three people living at (0,0), (0,4), and (2,2):
    /// 
    /// 1 - 0 - 0 - 0 - 1
    /// |   |   |   |   |
    /// 0 - 0 - 0 - 0 - 0
    /// |   |   |   |   |
    /// 0 - 0 - 1 - 0 - 0
    /// 
    /// The point(0,2) is an ideal meeting point, as the total travel distance of 2+2+2=6 is minimal.So return 6.
    /// 
    /// One pass with Count
    //     We can modify the distance function to use frequency to find the reach the median
    //     Time complexity O(mn)
    //     Space complexity O(mn)
    /// </summary>
    class Solution296 : SolutionBase
    {
        public override bool Test(Stopwatch sw)
        {
            return false;
        }

        /// <summary>
        /// 最简单粗暴的解决方案，
        /// Brute force
        ///   Try every point and calculate the 1's distance to this point
        ///   The best distance can be found by using min function
        ///   Time complexity O(m^2n^2)
        ///   Space complexity O(mn)
        /// </summary>
        /// <param name="grid"></param>
        /// <returns></returns>
        public int minTotalDistance(int[][] grid)
        {
            if (grid.Length == 0 || grid[0].Length == 0) return 0;
            int min = int.MaxValue;
            for (int i = 0; i < grid.Length; i++)
            {
                for (int j = 0; j < grid[i].Length; j++)
                {
                    int dist = calculate(i, j, grid);
                    min = Math.Min(min, dist);
                }
            }
            return min;
        }
        private int calculate(int m, int n, int[][] grid)
        {
            int dist = 0;
            for (int i = 0; i < grid.Length; i++)
            {
                for (int j = 0; j < grid[i].Length; j++)
                {
                    if (grid[i][j] == 1) dist += Math.Abs(i - m) + Math.Abs(n - j);
                }
            }
            return dist;
        }

        /// <summary>
        /// One pass with Count
        //     We can modify the distance function to use frequency to find the reach the median
        //     Time complexity O(mn)
        //     Space complexity O(mn)
        /// </summary>
        /// <param name="grid"></param>
        /// <returns></returns>
        public int minTotalDistance_OnePassWithCount(int[][] grid)
        {
            if (grid.Length == 0 || grid[0].Length == 0) return 0;
            int[] rowCount = new int[grid.Length];
            int[] colCount = new int[grid[0].Length];

            for (int i = 0; i < grid.Length; i++)
            {
                for (int j = 0; j < grid[i].Length; j++)
                {
                    if (grid[i][j] == 1)
                    {
                        rowCount[i]++;
                        colCount[j]++;
                    }
                }
            }
            return calDist(rowCount) + calDist(colCount);
        }

        private int calDist(int[] count)
        {
            int i = 0, j = count.Length - 1;
            int dist = 0;
            while (i < j)
            {
                int k = Math.Min(count[i], count[j]);
                dist += k * (j - i);
                count[i] -= k;
                count[j] -= k;
                if (count[i] == 0) i++;
                if (count[j] == 0) j--;
            }
            return dist;
        }
    }
}
