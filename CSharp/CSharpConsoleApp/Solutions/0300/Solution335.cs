using System;
namespace CSharpConsoleApp.Solutions
{
    /*
     * @lc app=leetcode.cn id=335 lang=csharp
     *
     * [335] 路径交叉
     *
     * https://leetcode-cn.com/problems/self-crossing/description/
     *
     * Category	Difficulty	Likes	Dislikes
     * algorithms	Hard (36.89%)	48	-
     * Tags
     * math
     * 
     * Companies
     * Unknown
     * 
     * Total Accepted:    2.6K
     * Total Submissions: 7.1K
     * Testcase Example:  '[2,1,1,2]'
     *
     * 给定一个含有 n 个正数的数组 x。从点 (0,0) 开始，先向北移动 x[0] 米，然后向西移动 x[1] 米，向南移动 x[2] 米，向东移动
     * x[3] 米，持续移动。也就是说，每次移动后你的方位会发生逆时针变化。
     * 
     * 编写一个 O(1) 空间复杂度的一趟扫描算法，判断你所经过的路径是否相交。
     * 
     * 
     * 
     * 示例 1:
     * ┌───┐
     * │   │
     * └───┼──>
     * │
     * 
     * 输入: [2,1,1,2]
     * 输出: true 
     * 
     * 
     * 示例 2:
     * ┌──────┐
     * │      │
     * │
     * │
     * └────────────>
     * 
     * 输入: [1,2,3,4]
     * 输出: false 
     * 
     * 
     * 示例 3:
     * ┌───┐
     * │   │
     * └───┼>
     * 
     * 输入: [1,1,1,1]
     * 输出: true 
     */

    // @lc code=start
    public class Solution335 : SolutionBase
    {
        /// <summary>
        /// 难度
        /// </summary>
        public override Difficulity GetDifficulity() { return Difficulity.Hard; }
        /// <summary>
        /// 关键字:
        /// </summary>
        public override string[] GetKeyWords() { return new string[] { "向内扩展螺旋状", "向外扩展螺旋状" }; }
        /// <summary>
        /// 标签：
        /// </summary>
        public override Tag[] GetTags() { return new Tag[] { Tag.Math }; }

        
        public override bool Test(System.Diagnostics.Stopwatch sw)
        {
            bool isSuccess = true;
            int[] board;
            bool result, checkResult;

            board = new int[] { 2, 1, 1, 2 };
            checkResult = true;
            result = IsSelfCrossing(board);
            isSuccess &= IsSame(result, checkResult);
            PrintResult(isSuccess, (result).ToString(), (checkResult).ToString());

            board = new int[] { 1,2,3,4 };
            checkResult = false;
            result = IsSelfCrossing(board);
            isSuccess &= IsSame(result, checkResult);
            PrintResult(isSuccess, (result).ToString(), (checkResult).ToString());

            board = new int[] { 1, 1, 1, 1};
            checkResult = true;
            result = IsSelfCrossing(board);
            isSuccess &= IsSame(result, checkResult);
            PrintResult(isSuccess, (result).ToString(), (checkResult).ToString());


            return isSuccess;
        }

        /// <summary>
        /// 重点：最多只能有一个外圈和一个内圈！
        /// 29/29 cases passed (104 ms)
        /// Your runtime beats 100 % of csharp submissions
        /// Your memory usage beats 100 % of csharp submissions(29.5 MB)
        /// 
        /// 作者：LZH_Yves
        /// 链接：https://leetcode-cn.com/problems/self-crossing/solution/yi-bu-yi-bu-fen-xi-by-lzh_yves/
        /// 代码很简单，想的过程。。一言难尽
        /// </summary>
        /// <param name="distance"></param>
        /// <returns></returns>
        public bool IsSelfCrossing(int[] x)
        {
            int x_size = x.Length;
            for (int i = 3; i < x_size; ++i)
            {
                if (i >= 3 && x[i - 1] <= x[i - 3] && x[i] >= x[i - 2])
                    return true;
                if (i >= 4 && x[i - 3] == x[i - 1] && x[i] + x[i - 4] >= x[i - 2])
                    return true;
                if (i >= 5 && x[i] + x[i - 4] >= x[i - 2] && x[i - 1] + x[i - 5] >= x[i - 3] && x[i - 2] > x[i - 4] && x[i - 3] > x[i - 1])
                    return true;
            }
            return false;
        }
    }
    // @lc code=end


}
