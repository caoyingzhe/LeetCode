using System;
namespace CSharpConsoleApp.Solutions
{
    /*
     * @lc app=leetcode.cn id=672 lang=csharp
     *
     * [672] 灯泡开关 Ⅱ
     *
     * https://leetcode-cn.com/problems/bulb-switcher-ii/description/
     *
     * Category	Difficulty	Likes	Dislikes
     * algorithms	Medium (55.77%)	72	-
     * Tags
     * math
     * 
     * Companies
     * microsoft
     * 
     * Total Accepted:    3.2K
     * Total Submissions: 5.8K
     * Testcase Example:  '1\n1'
     *
     * 现有一个房间，墙上挂有 n 只已经打开的灯泡和 4 个按钮。在进行了 m 次未知操作后，
     * 你需要返回这 n 只灯泡可能有多少种不同的状态。
     * 
     * 假设这 n 只灯泡被编号为 [1, 2, 3 ..., n]，这 4 个按钮的功能如下：
     * 
     * 
     * 将所有灯泡的状态反转（即开变为关，关变为开）
     * 将编号为偶数的灯泡的状态反转
     * 将编号为奇数的灯泡的状态反转
     * 将编号为 3k+1 的灯泡的状态反转（k = 0, 1, 2, ...)
     * 
     * 
     * 示例 1:
     * 
     * 输入: n = 1, m = 1.
     * 输出: 2
     * 说明: 状态为: [开], [关]
     * 
     * 
     * 示例 2:
     * 
     * 输入: n = 2, m = 1.
     * 输出: 3
     * 说明: 状态为: [开, 关], [关, 开], [关, 关]
     * 
     * 
     * 示例 3:
     * 
     * 输入: n = 3, m = 1.
     * 输出: 4
     * 说明: 状态为: [关, 开, 关], [开, 关, 开], [关, 关, 关], [关, 开, 开].
     * 
     * 
     * 注意： n 和 m 都属于 [0, 1000].
     */

    // @lc code=start
    public class Solution672 : SolutionBase
    {
        /// <summary>
        /// 难度
        /// </summary>
        public override Difficulity GetDifficulity() { return Difficulity.Medium; }
        /// <summary>
        /// 关键字:
        /// </summary>
        public override string[] GetKeyWords() { return new string[] { "" }; }
        /// <summary>
        /// 标签：
        /// </summary>
        public override Tag[] GetTags() { return new Tag[] { Tag.Math }; }

        public override bool Test(System.Diagnostics.Stopwatch sw)
        {
            bool isSuccess = true;
            int n, presses;
            int result, checkResult;

            n = 1; presses = 1;
            checkResult = 2;
            result = FlipLights(n, presses);
            isSuccess &= IsSame(result, checkResult);
            PrintResult(isSuccess, result, checkResult);

            n = 2; presses = 1;
            checkResult = 4;
            result = FlipLights(n, presses);
            isSuccess &= IsSame(result, checkResult);
            PrintResult(isSuccess, result, checkResult);

            n = 3; presses = 1;
            checkResult = 2;
            result = FlipLights(n, presses);
            isSuccess &= IsSame(result, checkResult);
            PrintResult(isSuccess, result, checkResult);

            return isSuccess;
        }

        /// <summary>
        /// 作者：LeetCode
        /// 链接：https://leetcode-cn.com/problems/bulb-switcher-ii/solution/deng-pao-kai-guan-ii-by-leetcode/
        /// 80/80 cases passed (36 ms)
        /// Your runtime beats 100 % of csharp submissions
        /// Your memory usage beats 75 % of csharp submissions (14.9 MB)
        /// 时空复杂性：O(1)。整个程序使用常量。
        /// </summary>
        /// <param name="n"></param>
        /// <param name="presses"></param>
        /// <returns></returns>
        public int FlipLights(int n, int presses)
        {
            n = Math.Min(n, 3);
            //当 m=0 时，所有灯都亮起，只有一个状态 (1, 1, 1)(1,1,1)。在这种情况下，答案总是 1。
            if (presses == 0) return 1;
            //当 m=1 时，我们可以得到状态 (0,0,0),(1,0,1),(0,1,0),(0,1,1)。在这种情况下，对于n=1,2,3 的答案是 2,3,4。
            if (presses == 1) return n == 1 ? 2 : n == 2 ? 3 : 4;
            //当 m=2 时，我们可以检查是否可以获得 7 个状态：除(0,1,1)之外的所有状态。在这种情况下，n=1,2,3 的答案是 2,4,7。
            if (presses == 2) return n == 1 ? 2 : n == 2 ? 4 : 7;
            //当 m=3 时，我们可以得到所有 8 个状态。在这种情况下，n=1,2,3 的答案是 2,4,8
            return n == 1 ? 2 : n == 2 ? 4 : 8;
        }

        
    }
    // @lc code=end


}
