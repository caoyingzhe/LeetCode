using System;
namespace CSharpConsoleApp.Solutions
{
    /*
     * @lc app=leetcode.cn id=384 lang=csharp
     *
     * [384] 打乱数组
     *
     * https://leetcode-cn.com/problems/shuffle-an-array/description/
     *
     * algorithms
     * Medium (56.34%)
     * Likes:    134
     * Dislikes: 0
     * Total Accepted:    40.4K
     * Total Submissions: 71.6K
     * Testcase Example:  '["Solution","shuffle","reset","shuffle"]\n[[[1,2,3]],[],[],[]]'
     *
     * 给你一个整数数组 nums ，设计算法来打乱一个没有重复元素的数组。
     * 
     * 实现 Solution class:
     * 
     * Solution(int[] nums) 使用整数数组 nums 初始化对象
     * int[] reset() 重设数组到它的初始状态并返回
     * int[] shuffle() 返回数组随机打乱后的结果
     * 
     * 示例：
     * 输入
     * ["Solution", "shuffle", "reset", "shuffle"]
     * [[[1, 2, 3]], [], [], []]
     * 输出
     * [null, [3, 1, 2], [1, 2, 3], [1, 3, 2]]
     * 
     * 解释
     * Solution solution = new Solution([1, 2, 3]);
     * solution.shuffle();    // 打乱数组 [1,2,3] 并返回结果。任何 [1,2,3]的排列返回的概率应该相同。例如，返回
     * [3, 1, 2]
     * solution.reset();      // 重设数组到它的初始状态 [1, 2, 3] 。返回 [1, 2, 3]
     * solution.shuffle();    // 随机返回数组 [1, 2, 3] 打乱后的结果。例如，返回 [1, 3, 2]
     * 
     * 
     * 提示：
     * 1 <= nums.length <= 200
     * -10^6 <= nums[i] <= -10^6 
     * nums 中的所有元素都是 唯一的
     * 最多可以调用 5 * 10^4 次 reset 和 shuffle
     * 
     */

    ///经典的洗牌算法，思路是在前n-1张牌洗好的情况下，
    ///第n张牌随机与前n-1张牌的其中一张牌交换，或者不换，即是随机洗牌
    ///感觉这题考查的不是算法，而是如何设计一个合理的测试用例。
    ///
    /// 方法一： 暴力 【通过】
    /// 假设我们把每个数都放在一个 ”帽子“ 里面，
    /// 然后我们从帽子里面把它们一个个摸出来，
    /// 摸出来的数按顺序放入数组，这个数组正好就是我们要的洗牌后的数组。
    ///
    /// 方法二： Fisher-Yates 洗牌算法 【通过】
    /// 对于洗牌问题，Fisher-Yates 洗牌算法即是通俗解法，同时也是渐进最优的解法。
    /// 在每次迭代中，生成一个范围在当前下标到数组末尾元素下标之间的随机整数。
    /// 接下来，将当前元素和随机选出的下标所指的元素互相交换
    ///     这一步模拟了每次从 “帽子” 里面摸一个元素的过程
    ///     其中选取下标范围的依据在于每个被摸出的元素都不可能再被摸出来了
    /// 当前元素是可以和它本身互相交换的 - 否则生成最后的排列组合的概率就不对了
    /// @lc code=start
    public class Solution384
    {

        /// <summary>
        /// Fisher-Yates 洗牌算法
        /// 
        /// 10/10 cases passed (416 ms)
        /// Your runtime beats 69.23 % of csharp submissions
        /// Your memory usage beats 40 % of csharp submissions(50.4 MB)
        ///
        /// https://leetcode-cn.com/problems/shuffle-an-array/solution/da-luan-shu-zu-by-leetcode/
        /// </summary>
        public class Solution
        {
            private int[] array;
            private int[] original;

            Random rand = new Random();

            public Solution(int[] nums)
            {
                array = nums;
                original = nums.Clone() as int[];
            }

            public int[] Reset()
            {
                array = original;
                original = original.Clone() as int[];
                return original;
            }

            public int[] Shuffle()
            {
                for (int i = 0; i < array.Length; i++)
                {
                    SwapAt(i, RandRange(i, array.Length));
                }
                return array;
            }

            private int RandRange(int min, int max)
            {
                return rand.Next(max - min) + min;
            }

            /// Fisher-Yates 洗牌算法中的交换处理
            private void SwapAt(int i, int j)
            {
                int temp = array[i];
                array[i] = array[j];
                array[j] = temp;
            }
        }
    }
}
