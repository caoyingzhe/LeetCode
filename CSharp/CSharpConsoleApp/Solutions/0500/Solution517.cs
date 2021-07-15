using System;
namespace CSharpConsoleApp.Solutions
{
    /*
     * @lc app=leetcode.cn id=517 lang=csharp
     *
     * [517] 超级洗衣机
     *
     * https://leetcode-cn.com/problems/super-washing-machines/description/
     *
     * Category	Difficulty	Likes	Dislikes
     * algorithms	Hard (43.31%)	66	-
     * Tags
     * math | dynamic-programming
     * 
     * Companies
     * amazon
     * 
     * Total Accepted:    3.3K
     * Total Submissions: 7.6K
     * Testcase Example:  '[1,0,5]'
     *
     * 假设有 n 台超级洗衣机放在同一排上。开始的时候，每台洗衣机内可能有一定量的衣服，也可能是空的。
     * 
     * 在每一步操作中，你可以选择任意 m （1 ≤ m ≤ n） 台洗衣机，与此同时将每台洗衣机的一件衣服送到相邻的一台洗衣机。
     * 给定一个非负整数数组代表从左至右每台洗衣机中的衣物数量，请给出能让所有洗衣机中剩下的衣物的数量相等的最少的操作步数。
     * 如果不能使每台洗衣机中衣物的数量相等，则返回-1。
     * 
     * 示例 1：
     * 输入: [1,0,5]
     * 输出: 3
     * 解释: 
     * 第一步:    1     0 <-- 5    =>    1     1     4
     * 第二步:    1 <-- 1 <-- 4    =>    2     1     3    
     * 第三步:    2     1 <-- 3    =>    2     2     2   
     * 
     *
     * 示例 2：
     * 输入: [0,3,0]
     * 输出: 2
     * 解释: 
     * 第一步:    0 <-- 3     0    =>    1     2     0    
     * 第二步:    1     2 --> 0    =>    1     1     1     
     * 
     * 
     * 示例 3:
     * 输入: [0,2,0]
     * 输出: -1
     * 解释: 
     * 不可能让所有三个洗衣机同时剩下相同数量的衣物。
     * 
     * 提示：
     * n 的范围是 [1, 10000]。
     * 在每台超级洗衣机中，衣物数量的范围是 [0, 1e5]。
     */

    // @lc code=start
    public class Solution517 : SolutionBase
    {
        /// <summary>
        /// 难度
        /// </summary>
        public override Difficulity GetDifficulity() { return Difficulity.Hard; }
        /// <summary>
        /// 关键字:
        /// </summary>
        public override string[] GetKeyWords() { return new string[] { }; }
        /// <summary>
        /// 标签：
        /// </summary>
        public override Tag[] GetTags() { return new Tag[] { Tag.Math, Tag.DynamicProgramming }; }

        /// <summary>
        /// </summary>
        /// <param name="sw"></param>
        /// <returns></returns>
        public override bool Test(System.Diagnostics.Stopwatch sw)
        {
            bool isSuccess = true;
            //TODO
            return isSuccess;
        }

        /// <summary>
        /// TODO 没理解题解的后面的部分
        /// </summary>
        /// <param name="machines"></param>
        /// <returns></returns>
        public int FindMinMoves_Home(int[] machines)
        {
            int n = machines.Length, dressTotal = 0;
            foreach (int m in machines)
                dressTotal += m;
            if (dressTotal % n != 0) return -1;

            //目标平均值
            int dressPerMachine = dressTotal / n;
            // Change the number of dresses in the machines to
            // the number of dresses to be removed from this machine
            // (could be negative)
            //每个洗衣机的增减值列表
            for (int i = 0; i < n; i++)
                machines[i] -= dressPerMachine;

            //TODO 没理解题解的后面的部分
            // currSum is a number of dresses to move at this point, 
            // maxSum is a max number of dresses to move at this point or before,
            // m is number of dresses to move out from the current machine.
            int currSum = 0, maxSum = 0, tmpRes = 0, res = 0;
            foreach (int m in machines)
            {
                currSum += m;
                maxSum = Math.Max(maxSum, Math.Abs(currSum));
                tmpRes = Math.Max(maxSum, m);
                res = Math.Max(res, tmpRes);
            }
            return res;
        }

        /// <summary>
        /// TODO 没理解题解的后面的部分
        /// 超级洗衣机两边分配法
        /// 作者：wen-rou-yi-dao-123
        /// 链接：https://leetcode-cn.com/problems/super-washing-machines/solution/duo-tu-xiang-xi-jie-shi-yi-xia-yi-fu-de-rq3g4/
        /// 
        /// 120/120 cases passed (120 ms)
        /// Your runtime beats 80 % of csharp submissions
        /// Your memory usage beats 60 % of csharp submissions(26.3 MB)
        /// </summary>
        /// <param name="machines"></param>
        /// <returns></returns>
        public int FindMinMoves(int[] machines)
        {
            int sum = 0;
            foreach (int num in machines) sum += num;

            int i, n = machines.Length;
            int average = sum / n;
            if (average * n != sum)
            {
                return -1;
            }

            int left = machines[0];
            int wantedLeft = average;
            int right, wantedRight = average * (n - 2);

            //最小移动量
            int minMoves = Math.Max(Math.Abs(machines[0] - average), Math.Abs(machines[n - 1] - average));

            //TODO 没理解题解的后面的部分
            //从左二到右二遍历
            for (i = 1; i < n - 1; ++i)
            {
                int num = machines[i];
                right = sum - num - left;

                //把最多衣服的洗衣机想象成一个真正的超级洗衣机，左右两边的洗衣机都等着它分发衣服就可以了。
                if (num >= average)
                {
                    int moves = num - average;
                    if (left > wantedLeft)
                    {
                        moves += (left - wantedLeft);
                    }
                    if (right > wantedRight)
                    {
                        moves += (right - wantedRight);
                    }
                    minMoves = Math.Max(minMoves, moves);
                }
                left += num;
                wantedLeft += average;
                wantedRight -= average;
            }
            return minMoves;
        }
    }
    // @lc code=end


}
