using System;
using System.Collections.Generic;
namespace CSharpConsoleApp.Solutions
{
    /*
 * @lc app=leetcode.cn id=593 lang=csharp
 *
 * [593] 有效的正方形
 *
 * https://leetcode-cn.com/problems/valid-square/description/
 *
 * Category	Difficulty	Likes	Dislikes
 * algorithms	Medium (44.16%)	68	-
 * Tags
 * math
 * 
 * Companies
 * Unknown
 * Total Accepted:    7.7K
 * Total Submissions: 17.4K
 * Testcase Example:  '[0,0]\n[1,1]\n[1,0]\n[0,1]'
 *
 * 给定二维空间中四点的坐标，返回四点是否可以构造一个正方形。
 * 
 * 一个点的坐标（x，y）由一个有两个整数的整数数组表示。
 * 
 * 示例:
 * 输入: p1 = [0,0], p2 = [1,1], p3 = [1,0], p4 = [0,1]
 * 输出: True
 * 
 * 
 * 注意:
 * 所有输入整数都在 [-10000，10000] 范围内。
 * 一个有效的正方形有四个等长的正长和四个等角（90度角）。
 * 输入点没有顺序。
 */

    // @lc code=start
    public class Solution593 : SolutionBase
    {
        /// <summary>
        /// 难度
        /// </summary>
        public override Difficulity GetDifficulity() { return Difficulity.Medium; }
        /// <summary>
        /// 关键字:
        /// </summary>
        public override string[] GetKeyWords() { return new string[] { "抄作业" }; }
        /// <summary>
        /// 标签：
        /// </summary>
        public override Tag[] GetTags() { return new Tag[] { Tag.Math }; }

        /// <summary>
        /// </summary>
        /// <param name="sw"></param>
        /// <returns></returns>
        public override bool Test(System.Diagnostics.Stopwatch sw)
        {
            bool isSuccess = true;
            //TODO
            //p1 = [0,0], p2 = [1,1], p3 = [1,0], p4 = [0,1]
            PrintDatas(ValidSquare(new int[] { 0, 0 } , new int[] { 1, 1 }, new int[] { 1, 0 }, new int[] { 0, 1 } ));
            return isSuccess;
        }

        /// <summary>
        /// 253/253 cases passed (88 ms)
        /// Your runtime beats 100 % of csharp submissions
        /// Your memory usage beats 66.67 % of csharp submissions(26.7 MB)
        /// </summary>
        /// <param name="p1"></param>
        /// <param name="p2"></param>
        /// <param name="p3"></param>
        /// <param name="p4"></param>
        /// <returns></returns>
        public bool ValidSquare(int[] p1, int[] p2, int[] p3, int[] p4)
        {
            List<int> list = new List<int>
            {
                GetLenSquare(p1, p2),
                GetLenSquare(p1, p3),
                GetLenSquare(p1, p4),
                GetLenSquare(p2, p3),
                GetLenSquare(p2, p4),
                GetLenSquare(p3, p4)
            };
            list.Sort();
            if (list[0] == 0) return false;
            for (int i=1; i<4; i++) if (list[i] != list[0]) return false;
            for (int i = 4; i < 6; i++) if (list[i] != list[0] * 2) return false;
            return true;
        }

        private int GetLenSquare(int[] p1, int[] p2) {
            return (p2[0] - p1[0]) * (p2[0] - p1[0]) + (p2[1] - p1[1]) * (p2[1] - p1[1]);
        }
    
    }
    // @lc code=end


}
