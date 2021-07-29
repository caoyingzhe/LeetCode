using System;
using System.Collections.Generic;
namespace CSharpConsoleApp.Solutions
{
    /*
 * @lc app=leetcode.cn id=473 lang=csharp
 *
 * [473] 火柴拼正方形
 *
 * https://leetcode-cn.com/problems/matchsticks-to-square/description/
 *
 * Category	Difficulty	Likes	Dislikes
 * algorithms	Medium (41.72%)	192	-
 * Tags
 * depth-first-search
 * 
 * Companies
 * Unknown
 * 
 * Total Accepted:    18.6K
 * Total Submissions: 44.4K
 * Testcase Example:  '[1,1,2,2,2]'
 *
 * 
 * 还记得童话《卖火柴的小女孩》吗？现在，你知道小女孩有多少根火柴，请找出一种能使用所有火柴拼成一个正方形的方法。不能折断火柴，可以把火柴连接起来，并且每根火柴都要用到。
 * 
 * 输入为小女孩拥有火柴的数目，每根火柴用其长度表示。输出即为是否能用所有的火柴拼成正方形。
 * 
 * 示例 1:
 * 
 * 
 * 输入: [1,1,2,2,2]
 * 输出: true
 * 
 * 解释: 能拼成一个边长为2的正方形，每边两根火柴。
 * 
 * 
 * 示例 2:
 * 
 * 
 * 输入: [3,3,3,3,4]
 * 输出: false
 * 
 * 解释: 不能用所有火柴拼成一个正方形。
 * 
 * 
 * 注意:
 * 
 * 
 * 给定的火柴长度和在 0 到 10^9之间。
 * 火柴数组的长度不超过15。
 * 
 * 
 */

    // @lc code=start
    public class Solution473 : SolutionBase
    {
        /// <summary>
        /// 难度
        /// </summary>
        public override Difficulity GetDifficulity() { return Difficulity.Medium; }
        /// <summary>
        /// 关键字:
        /// </summary>
        public override string[] GetKeyWords() { return new string[] { "复杂度超N^2", "本质是困难题" }; }
        /// <summary>
        /// 标签：
        /// </summary>
        public override Tag[] GetTags() { return new Tag[] { Tag.DepthFirstSearch }; }

        public override bool Test(System.Diagnostics.Stopwatch sw)
        {
            bool isSuccess = true;
            //TODO
            int[] matchsticks;
            bool result, checkResult;

            //matchsticks = new int[] { 1, 1, 2, 2, 2 };
            //checkResult = true;
            //result = Makesquare(matchsticks);
            //isSuccess &= IsSame(result, checkResult);
            //PrintResult(isSuccess, result, checkResult);

            //matchsticks = new int[] { 3, 3, 3, 3, 4 };
            //checkResult = false;
            //result = Makesquare(matchsticks);
            //isSuccess &= IsSame(result, checkResult);
            //PrintResult(isSuccess, result, checkResult);

            //matchsticks = new int[] { 3, 3, 3, 3, 4 };
            //checkResult = false;
            //result = Makesquare(matchsticks);
            //isSuccess &= IsSame(result, checkResult);
            //PrintResult(isSuccess, result, checkResult);

            //matchsticks = new int[] { 5, 5, 5, 5, 4, 4, 4, 4, 3, 3, 3, 3 };
            //checkResult = true;
            //result = Makesquare(matchsticks);
            //isSuccess &= IsSame(result, checkResult);
            //PrintResult(isSuccess, result, checkResult);

            ////1,2,3,4,5,6,7,8,9,10,5,4,3,2,1
            //matchsticks = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 5, 4, 3, 2, 1 };
            //checkResult = false;
            //result = Makesquare(matchsticks);
            //isSuccess &= IsSame(result, checkResult);
            //PrintResult(isSuccess, result, checkResult);

            matchsticks = new int[] { 1, 2, 3, 4, 1, 2, 3, 4, 5, 5, 6, 7, 8, 9, 10};
            checkResult = false;
            result = Makesquare(matchsticks);
            isSuccess &= IsSame(result, checkResult);
            PrintResult(isSuccess, result, checkResult);

            //sum = 492, avg = 123
            matchsticks = new int[] { 12, 12, 12, 16, 20, 24, 28, 32, 36, 40, 44, 48, 52, 56, 60 };
            checkResult = false;
            result = Makesquare(matchsticks);
            isSuccess &= IsSame(result, checkResult);
            PrintResult(isSuccess, result, checkResult);
            return isSuccess;
        }

        /// <summary>
        /// 作者：sdwwld
        /// 链接：https://leetcode-cn.com/problems/matchsticks-to-square/solution/hui-su-suan-fa-jie-jue-ji-you-hua-chao-g-9iyl/
        /// 175/175 cases passed (76 ms)
        /// Your runtime beats 100 % of csharp submissions
        /// Your memory usage beats 100 % of csharp submissions(23.9 MB)
        /// </summary>
        /// <param name="matchsticks"></param>
        /// <returns></returns>
        public bool Makesquare(int[] matchsticks)
        {
            int total = 0;
            //统计所有火柴的长度
            foreach (int num in matchsticks)
            {
                total += num;
            }
            //如果所有火柴的长度不是4的倍数，直接返回false
            if (total == 0 || (total & 3) != 0)
                return false;

            //先排序
            Array.Sort(matchsticks);
            //回溯，从最长的火柴开始
            return DFS(matchsticks, matchsticks.Length - 1, total >> 2, new int[4]);
        }

        //index表示访问到当前火柴的位置，target表示正方形的边长，size是长度为4的数组，
        //分别保存正方形4个边的长度
        private bool DFS(int[] nums, int index, int target, int[] size)
        {
            if (index == -1)
            {
                //如果火柴都访问完了，并且size的4个边的长度都相等，说明是正方形，直接返回true，
                //否则返回false
                if (size[0] == size[1] && size[1] == size[2] && size[2] == size[3])
                    return true;
                return false;
            }
            //到这一步说明火柴还没访问完
            for (int i = 0; i < size.Length; i++)
            {
                //如果把当前火柴放到size[i]这个边上，他的长度大于target，我们直接跳过。或者
                // size[i] == size[i - 1]即上一个分支的值和当前分支的一样，上一个分支没有成功，
                //说明这个分支也不会成功，直接跳过即可。
                if (size[i] + nums[index] > target ||
                    (i > 0 && size[i] == size[i - 1]) ||
                    (index == nums.Length - 1 && i != 0))
                    continue;
                //如果当前火柴放到size[i]这个边上，长度不大于target，我们就放上面
                size[i] += nums[index];
                //然后在放下一个火柴，如果最终能变成正方形，直接返回true
                if (DFS(nums, index - 1, target, size))
                    return true;
                //如果当前火柴放到size[i]这个边上，最终不能构成正方形，我们就把他从
                //size[i]这个边上给移除，然后在试其他的边
                size[i] -= nums[index];
            }
            //如果不能构成正方形，直接返回false
            return false;
        }

        public bool Makesquare_LTE(int[] matchsticks)
        {
            if (matchsticks.Length < 4) return false;

            sums = new int[4];
            nums = new List<int>();
            nums.AddRange(matchsticks);
            nums.Sort();

            int n = matchsticks.Length;
            int length = 0;
            for(int i=0; i< n; i++) length += matchsticks[i];

            if (length == 0 || length % 4 != 0) return false;
            int sideLen = length / 4;
            if (nums[nums.Count - 1] > sideLen) return false;

            return DFS(0, sideLen);
        }

        public List<int> nums = new List<int>();
        public int[] sums = new int[4];
        /// 作者：LeetCode
        /// 链接：https://leetcode-cn.com/problems/matchsticks-to-square/solution/huo-chai-pin-zheng-fang-xing-by-leetcode/
        public bool DFS(int index, int sideLen)
        {
            // If we have exhausted all our matchsticks, check if all sides of the square are of equal length
            if (index == this.nums.Count)
            {
                return sums[0] == sums[1] && sums[1] == sums[2] && sums[2] == sums[3];
            }

            // Get current matchstick.
            int element = this.nums[index];

            // Try adding it to each of the 4 sides (if possible)
            for (int i = 0; i < 4; i++)
            {
                if (this.sums[i] + element <= sideLen)
                {
                    this.sums[i] += element;
                    if (this.DFS(index + 1, sideLen))
                    {
                        return true;
                    }
                    this.sums[i] -= element;
                }
            }
            return false;
        }

            }
    // @lc code=end


}
