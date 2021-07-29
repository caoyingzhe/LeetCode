using System;
namespace CSharpConsoleApp.Solutions
{
    public class Solution307 : SolutionBase
    {
        /// <summary>
        /// 难度
        /// </summary>
        public override Difficulity GetDifficulity() { return Difficulity.Medium; }
        /// <summary>
        /// 关键字:
        /// </summary>
        public override string[] GetKeyWords() { return new string[] { "线段树", }; }
        /// <summary>
        /// 标签：
        /// </summary>
        public override Tag[] GetTags() { return new Tag[] {Tag.BinaryIndexedTree, Tag.SegmentTree,  Tag.Design, Tag.NeedStudy }; }

        
        public override bool Test(System.Diagnostics.Stopwatch sw)
        {
            bool isSuccess = true;
            int result, checkResult;

            NumArray numArray = new NumArray(new int[] { 1, 3, 5 });
            result = numArray.SumRange(0, 2);         // 返回 9 ，sum([1,3,5]) = 9

            checkResult = 9;
            isSuccess &= IsSame(result, checkResult);
            PrintResult(isSuccess, result, checkResult);

            numArray.Update(1, 2);   // nums = [1,2,5]
            result = numArray.SumRange(0, 2); // 返回 8 ，sum([1,2,5]) = 8

            checkResult = 8;
            isSuccess &= IsSame(result, checkResult);
            PrintResult(isSuccess, result, checkResult);

            return isSuccess;
        }

        /*
         * @lc app=leetcode.cn id=307 lang=csharp
         *
         * [307] 区域和检索 - 数组可修改
         *
         * https://leetcode-cn.com/problems/range-sum-query-mutable/description/
         *
         * Category	Difficulty	Likes	Dislikes
         * algorithms	Medium (54.86%)	278	-
         * Tags
         * binary-indexed-tree | segment-tree
         * 
         * Companies
         * Unknown
         * 
         * Total Accepted:    21.8K
         * Total Submissions: 39.8K
         * Testcase Example:  '["NumArray","sumRange","update","sumRange"]\n[[[1,3,5]],[0,2],[1,2],[0,2]]'
         *
         * 给你一个数组 nums ，请你完成两类查询，其中一类查询要求更新数组下标对应的值，另一类查询要求返回数组中某个范围内元素的总和。
         * 
         * 实现 NumArray 类：
         * NumArray(int[] nums) 用整数数组 nums 初始化对象
         * void update(int index, int val) 将 nums[index] 的值更新为 val
         * int sumRange(int left, int right) 返回子数组 nums[left, right] 的总和（即，nums[left] +
         * nums[left + 1], ..., nums[right]）
         *
         * 
         * 示例：
         * 输入：
         * ["NumArray", "sumRange", "update", "sumRange"]
         * [[[1, 3, 5]], [0, 2], [1, 2], [0, 2]]
         * 输出：
         * [null, 9, null, 8]
         * 
         * 解释：
         * NumArray numArray = new NumArray([1, 3, 5]);
         * numArray.sumRange(0, 2); // 返回 9 ，sum([1,3,5]) = 9
         * numArray.update(1, 2);   // nums = [1,2,5]
         * numArray.sumRange(0, 2); // 返回 8 ，sum([1,2,5]) = 8
         * 
         * 
         * 提示：
         * 1 <= nums.length <= 3 * 10^4
         * -100 <= nums[i] <= 100
         * 0 <= index < nums.length
         * -100 <= val <= 100
         * 0 <= left <= right < nums.length
         * 最多调用 3 * 10^4 次 update 和 sumRange 方法
         */

        //作者：LeetCode
        //链接：https://leetcode-cn.com/problems/range-sum-query-mutable/solution/qu-yu-he-jian-suo-shu-zu-ke-xiu-gai-by-leetcode/

        /// <summary>
        /// 15/15 cases passed (968 ms)
        /// Your runtime beats 100 % of csharp submissions
        /// Your memory usage beats 38.1 % of csharp submissions(82.3 MB)
        /// </summary>
        // @lc code=start
        public class NumArray
        {
            int[] tree;
            int n;

            /// <summary>
            /// 时间复杂度：O(n)：for 循环的每次迭代中计算一个节点的和。而一个线段树中大约有 2n 个节点。
            /// 空间复杂度：O(n)，我们用了 2n2n 的额外空间来存储整个线段树
            /// </summary>
            /// <param name="nums"></param>
            public NumArray(int[] nums)
            {
                if (nums.Length > 0)
                {
                    n = nums.Length;
                    tree = new int[n * 2];

                    //初始化线段树
                    //BuildTree(nums);

                    //先设置 n~2n 索引区间的的原始数据（即最后一层子节点）
                    for (int i = n, j = 0; i < 2 * n; i++, j++)
                        tree[i] = nums[j];

                    //再设置 n~2n 索引区间的的原始数据（即最后一层子节点）
                    for (int i = n - 1; i > 0; --i)
                        tree[i] = tree[i * 2] + tree[i * 2 + 1];
                }
            }

            /// <summary>
            /// 更新线段树
            /// 时间复杂度：O(log n)。算法的时间复杂度为 O(logn)，因为有几个树节点的范围包括第 i 个数组元素，每个层上都有一个。共有 log(n) 层。
            /// 空间复杂度：O(1)。
            /// </summary>
            /// <param name="index"></param>
            /// <param name="val"></param>
            public void Update(int index, int val)
            {
                index += n;
                tree[index] = val;
                while (index > 0)
                {
                    int L = index;
                    int R = index;
                    if (index % 2 == 0)
                    {
                        R = index + 1;
                    }
                    else
                    {
                        L = index - 1;
                    }
                    // parent is updated after child is updated
                    tree[index / 2] = tree[L] + tree[R];
                    index /= 2;
                }
            }

            /// <summary>
            /// 区域和检索：
            /// 时间复杂度：O(logn)。
            ///     因为在算法的每次迭代中，我们会向上移动一层，
            ///     要么移动到当前节点的父节点，要么移动到父节点的左侧或者右侧的兄弟节点，直到两个边界相交为止。
            ///     在最坏的情况下，这种情况会在算法进行 nlogn 次迭代后发生在根节点。
            /// 空间复杂度：O(1)。
            /// </summary>
            /// <param name="left"></param>
            /// <param name="right"></param>
            /// <returns></returns>
            public int SumRange(int l, int r)
            {
                // get leaf with value 'l'
                l += n;
                // get leaf with value 'r'
                r += n;
                int sum = 0;
                while (l <= r)
                {
                    if ((l % 2) == 1)
                    {
                        sum += tree[l];
                        l++;
                    }
                    if ((r % 2) == 0)
                    {
                        sum += tree[r];
                        r--;
                    }
                    l /= 2;
                    r /= 2;
                }
                return sum;
            }
        }

    /**
     * Your NumArray object will be instantiated and called as such:
     * NumArray obj = new NumArray(nums);
     * obj.Update(index,val);
     * int param_2 = obj.SumRange(left,right);
     */
    // @lc code=end
    }
}
