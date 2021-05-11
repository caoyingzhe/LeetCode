using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpConsoleApp.Solutions._0300
{
    /*
     * @lc app=leetcode.cn id=330 lang=csharp
     *
     * [330] 按要求补齐数组
     *
     * https://leetcode-cn.com/problems/patching-array/description/
     *
     * Category	Difficulty	Likes	Dislikes
     * algorithms	Hard (53.52%)	275	-
     * Tags
     * greedy
     * 
     * Companies
     * google
     * 
     * Total Accepted:    17.8K
     * Total Submissions: 33.2K
     * Testcase Example:  '[1,3]\n6'
     *
     * 给定一个已排序的正整数数组 nums，和一个正整数 n 。从 [1, n] 区间内选取任意个数字补充到 nums 中，使得 [1, n]
     * 区间内的任何数字都可以用 nums 中某几个数字的和来表示。请输出满足上述要求的最少需要补充的数字个数。
     * 
     * 示例 1:
     * 
     * 输入: nums = [1,3], n = 6
     * 输出: 1 
     * 解释:
     * 根据 nums 里现有的组合 [1], [3], [1,3]，可以得出 1, 3, 4。
     * 现在如果我们将 2 添加到 nums 中， 组合变为: [1], [2], [3], [1,3], [2,3], [1,2,3]。
     * 其和可以表示数字 1, 2, 3, 4, 5, 6，能够覆盖 [1, 6] 区间里所有的数。
     * 所以我们最少需要添加一个数字。
     * 
     * 示例 2:
     * 
     * 输入: nums = [1,5,10], n = 20
     * 输出: 2
     * 解释: 我们需要添加 [2, 4]。
     * 
     * 示例 3:
     * 输入: nums = [1,2,2], n = 5
     * 输出: 0
     * 
     * 
     */
    class Solution330 : SolutionBase
    {
        /// <summary>
        /// 难易度:
        /// </summary>
        public override Difficulity GetDifficulity() { return Difficulity.Hard; }
        /// <summary>
        /// 关键字:
        /// </summary>
        public override string[] GetKeyWords() { return new string[] { "" }; }
        /// <summary>
        /// 标签：
        /// </summary>
        public override Tag[] GetTags() { return new Tag[] { Tag.Greedy}; }

        //TODO
        public override bool Test(System.Diagnostics.Stopwatch sw)
        {
            bool isSuccess = true;
            return isSuccess;
        }
        /// <summary>
        /// 作者：LeetCode-Solution
        /// 链接：https://leetcode-cn.com/problems/patching-array/solution/an-yao-qiu-bu-qi-shu-zu-by-leetcode-solu-klp1/
        /// 
        /// 定理： 
        /// 对于正整数 x，如果区间 [1,x-1] 内的所有数字都已经被覆盖，且 x 在数组中，
        /// 则区间 [1,2x−1] 内的所有数字也都被覆盖。
        /// 
        /// 贪心的方案： 
        /// 每次找到未被数组 nums 覆盖的最小的整数 x，在数组中补充 x，
        /// 然后寻找下一个未被覆盖的最小的整数，重复上述步骤直到区间 [1,n] 中的所有数字都被覆盖。
        /// 
        /// 作者：LeetCode-Solution
        /// 链接：https://leetcode-cn.com/problems/patching-array/solution/an-yao-qiu-bu-qi-shu-zu-by-leetcode-solu-klp1/
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="n"></param>
        /// <returns></returns>
        public int MinPatches(int[] nums, int n)
        {
            int patches = 0;
            long x = 1;
            int length = nums.Length, index = 0;
            while (x <= n)  
            {
                if (index < length && nums[index] <= x)
                {
                    x += nums[index];
                    index++;
                }
                else //否则，x 没有被覆盖，因此需要在数组中补充 x，然后将 x 的值乘以 22。
                {
                    x *= 2;
                    patches++;
                }
            }//重复上述操作，直到 x 的值大于 n。

            return patches;
        }
    }
}
