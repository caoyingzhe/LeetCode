using System;
namespace CSharpConsoleApp.Solutions
{
    /*
 * @lc app=leetcode.cn id=223 lang=csharp
 *
 * [223] 矩形面积
 *
 * https://leetcode-cn.com/problems/rectangle-area/description/
 *
 * algorithms
 * Medium (45.23%)
 * Likes:    113
 * Dislikes: 0
 * Total Accepted:    18.5K
 * Total Submissions: 40.9K
 * Testcase Example:  '-3\n0\n3\n4\n0\n-1\n9\n2'
 *
 * 给你 二维 平面上两个 由直线构成的 矩形，请你计算并返回两个矩形覆盖的总面积。
 * 
 * 每个矩形由其 左下 顶点和 右上 顶点坐标表示：
 * 
 * 
 * 
 * 第一个矩形由其左下顶点 (ax1, ay1) 和右上顶点 (ax2, ay2) 定义。
 * 第二个矩形由其左下顶点 (bx1, by1) 和右上顶点 (bx2, by2) 定义。
 * 
 * 
 * 
 * 
 * 
 * 示例 1：
 * 
 * 
 * 输入：ax1 = -3, ay1 = 0, ax2 = 3, ay2 = 4, bx1 = 0, by1 = -1, bx2 = 9, by2 = 2
 * 输出：45
 * 
 * 
 * 示例 2：
 * 
 * 
 * 输入：ax1 = -2, ay1 = -2, ax2 = 2, ay2 = 2, bx1 = -2, by1 = -2, bx2 = 2, by2 = 2
 * 输出：16
 * 
 * 
 * 
 * 
 * 提示：
 * 
 * 
 * -10^4 
 * 
 * 
 */

    // @lc code=start
    public class Solution223 : SolutionBase
    {
        /// <summary>
        /// 难度
        /// </summary>
        public override Difficulity GetDifficulity() { return Difficulity.Medium; }
        /// <summary>
        /// 关键字:
        /// </summary>
        public override string[] GetKeyWords() { return new string[] { "", }; }
        /// <summary>
        /// 标签：
        /// </summary>
        public override Tag[] GetTags() { return new Tag[] { Tag.HashTable, Tag.BitManipulation }; }

        public int NULL = -1;
        public override bool Test(System.Diagnostics.Stopwatch sw)
        {
            bool isSuccess = true;
            int ax1,  ay1,  ax2,  ay2,  bx1,  by1,  bx2,  by2;
            int result, checkResult;

            ax1 = -3; ay1 = 0; ax2 = 3; ay2 = 4; bx1 = 0; by1 = -1; bx2 = 9; by2 = 2;
            checkResult = 45;
            result = ComputeArea(ax1, ay1, ax2, ay2, bx1, by1, bx2, by2);
            isSuccess &= IsSame(result, checkResult);
            PrintResult(isSuccess, (result), (checkResult));

            ax1 = -2; ay1 = -2; ax2 = 2; ay2 = 2; bx1 = -2; by1 = -2; bx2 = 2; by2 = 2;
            checkResult = 16;
            result = ComputeArea(ax1, ay1, ax2, ay2, bx1, by1, bx2, by2);
            isSuccess &= IsSame(result, checkResult);
            PrintResult(isSuccess, (result), (checkResult));

            return isSuccess;
        }

        //作者：luoweian
        //链接：https://leetcode-cn.com/problems/rectangle-area/solution/223-ju-xing-mian-ji-3xing-dai-ma-by-acw_weian/
        /// <summary>
        /// 3080/3080 cases passed (40 ms)
        /// Your runtime beats 100 % of csharp submissions
        /// Your memory usage beats 66.67 % of csharp submissions(15.8 MB)
        /// </summary>
        /// <param name="A">矩形1四顶点1</param>
        /// <param name="B">矩形1四顶点2</param>
        /// <param name="C">矩形1四顶点3</param>
        /// <param name="D">矩形1四顶点4</param>
        /// <param name="E">矩形2四顶点1</param>
        /// <param name="F">矩形2四顶点2</param>
        /// <param name="G">矩形2四顶点3</param>
        /// <param name="H">矩形2四顶点4</param>
        /// <returns></returns>
        public int ComputeArea(int A, int B, int C, int D, int E, int F, int G, int H)
        {
            long X = Math.Max(0, (long)Math.Min(G, C) - Math.Max(A, E));
            long Y = Math.Max(0, (long)Math.Min(D, H) - Math.Max(B, F));
            return (int)((long)(C - A) * (D - B) - X * Y + (G - E) * (H - F));
        }
    }
    // @lc code=end


}
