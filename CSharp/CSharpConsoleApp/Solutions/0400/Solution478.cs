﻿using System;
namespace CSharpConsoleApp.Solutions
{
    /*
     * @lc app=leetcode.cn id=478 lang=csharp
     *
     * [478] 在圆内随机生成点
     *
     * https://leetcode-cn.com/problems/generate-random-point-in-a-circle/description/
     *
     * Category	Difficulty	Likes	Dislikes
     * algorithms	Medium (43.26%)	60	-
     * Tags
     * Unknown
     * 
     * Companies
     * Unknown
     * 
     * Total Accepted:    5.8K
     * Total Submissions: 13.5K
     * Testcase Example:  '["Solution","randPoint","randPoint","randPoint"]\n[[1.0,0.0,0.0],[],[],[]]'
     *
     * 给定圆的半径和圆心的 x、y 坐标，写一个在圆中产生均匀随机点的函数 randPoint 。
     * 
     * 说明:
     * 输入值和输出值都将是浮点数。
     * 圆的半径和圆心的 x、y 坐标将作为参数传递给类的构造函数。
     * 圆周上的点也认为是在圆中。
     * randPoint 返回一个包含随机点的x坐标和y坐标的大小为2的数组。
     * 
     * 
     * 示例 1：
     * 输入: 
     * ["Solution","randPoint","randPoint","randPoint"]
     * [[1,0,0],[],[],[]]
     * 输出: [null,[-0.72939,-0.65505],[-0.78502,-0.28626],[-0.83119,-0.19803]]
     * 
     * 
     * 示例 2：
     * 输入: 
     * ["Solution","randPoint","randPoint","randPoint"]
     * [[10,5,-7.5],[],[],[]]
     * 输出: [null,[11.52438,-8.33273],[2.46992,-16.21705],[11.13430,-12.42337]]
     * 
     * 输入语法说明：
     * 
     * 输入是两个列表：调用成员函数名和调用的参数。Solution 的构造函数有三个参数，圆的半径、圆心的 x 坐标、圆心的 y 坐标。randPoint
     * 没有参数。输入参数是一个列表，即使参数为空，也会输入一个 [] 空列表。
     * 
     */

    // @lc code=start
    public class Solution478 : SolutionBase
    {
        /// <summary>
        /// 难度
        /// </summary>
        public override Difficulity GetDifficulity() { return Difficulity.Medium; }
        /// <summary>
        /// 关键字:
        /// </summary>
        public override string[] GetKeyWords() { return new string[] { "随机函数算法", "期望的生成次数E", "本质为Easy"  }; }
        /// <summary>
        /// 标签：
        /// </summary>
        public override Tag[] GetTags() { return new Tag[] { Tag.DynamicProgramming, Tag.Minimax }; }

        public override bool Test(System.Diagnostics.Stopwatch sw)
        {
            bool isSuccess = true;
            //TODO
            return isSuccess;
        }

        /// <summary>
        /// 8/8 cases passed (376 ms)
        /// Your runtime beats 100 % of csharp submissions
        /// Your memory usage beats 50 % of csharp submissions(48.7 MB)
        /// </summary>
        public class Solution
        {
            double rad, xc, yc;
            Random rand;
            public Solution(double radius, double x_center, double y_center)
            {
                this.rad = radius;
                this.xc = x_center;
                this.yc = y_center;
                this.rand = new Random();
            }

            public double[] RandPoint()
            {
                double d = rad * Math.Sqrt(rand.NextDouble());
                double theta = rand.NextDouble() * 2 * Math.PI;
                return new double[] { d * Math.Cos(theta) + xc, d * Math.Sin(theta) + yc };
            }
        }
    }

    /**
     * Your Solution object will be instantiated and called as such:
     * Solution obj = new Solution(radius, x_center, y_center);
     * double[] param_1 = obj.RandPoint();
     */
    // @lc code=end


}
