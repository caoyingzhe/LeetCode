using System;
using System.Collections.Generic; //泛型集合的接口和类，强类型安全
//using System.Collections集合的接口和类
using System.Collections.Specialized; //：专用的和强类型的集合　
using System.Collections.Concurrent; //：线程安全的集合
using System.Linq;
namespace CSharpConsoleApp.Solutions
{
    /*
     * @lc app=leetcode.cn id=220 lang=csharp
     *
     * [220] 存在重复元素 III
     *
     * https://leetcode-cn.com/problems/contains-duplicate-iii/description/
     *
     * Category	Difficulty	Likes	Dislikes
     * algorithms	Medium (28.69%)	467	-
     * Tags
     * sort | ordered-map
     * 
     * Companies
     * airbnb | palantir
     * 
     * Total Accepted:    59.4K
     * Total Submissions: 206.9K
     * Testcase Example:  '[1,2,3,1]\n3\n0'
     *
     * 给你一个整数数组 nums 和两个整数 k 和 t 。请你判断是否存在 两个不同下标 i 和 j，使得 abs(nums[i] - nums[j])
     * ，同时又满足 abs(i - j)  。
     * 如果存在则返回 true，不存在返回 false。
     * 
     * 
     * 示例 1：
     * 输入：nums = [1,2,3,1], k = 3, t = 0
     * 输出：true
     * 
     * 示例 2：
     * 输入：nums = [1,0,1,1], k = 1, t = 2
     * 输出：true
     * 
     * 示例 3：
     * 输入：nums = [1,5,9,1,5,9], k = 2, t = 3
     * 输出：false
     * 
     * 
     * 提示：
     * 0 <= nums.length <= 2 * 104
     * -231 <= nums[i] <= 231 - 1
     * 0 <= k <= 104
     * 0 <= t <= 231 - 1
     */

    // @lc code=start
    public class Solution220 : SolutionBase
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
        public override Tag[] GetTags() { return new Tag[] { Tag.Array, Tag.OrderedMap, }; }

        public override bool Test(System.Diagnostics.Stopwatch sw)
        {
            bool isSuccess = true;
            bool result, checkResult;
            int[] nums; int k, t;

            //nums = new int[] { 1, 2, 3, 1 }; k = 3; t = 0;
            //checkResult = true;
            //result = ContainsNearbyAlmostDuplicate(nums, k, t);
            //isSuccess &= IsSame(result, checkResult);
            //PrintResult(isSuccess, (result), (checkResult));

            //nums = new int[] { 1, 0, 1, 1 }; k = 1; t = 2;
            //checkResult = true;
            //result = ContainsNearbyAlmostDuplicate(nums, k, t);
            //isSuccess &= IsSame(result, checkResult);
            //PrintResult(isSuccess, (result), (checkResult));

            //nums = new int[] { 1, 5, 9, 1, 5, 9 }; k = 2; t = 3;
            //checkResult = false;
            //result = ContainsNearbyAlmostDuplicate(nums, k, t);
            //isSuccess &= IsSame(result, checkResult);
            //PrintResult(isSuccess, (result), (checkResult));

            //nums = new int[] { -2147483648, 2147483647 }; k = 1; t = 1;
            //checkResult = false;
            //result = ContainsNearbyAlmostDuplicate(nums, k, t);
            //isSuccess &= IsSame(result, checkResult);
            //PrintResult(isSuccess, (result), (checkResult));

            //nums = new int[] { 1, 3, 6, 2 }; k = 1; t = 2;
            //checkResult = true;
            //result = ContainsNearbyAlmostDuplicate(nums, k, t);
            //isSuccess &= IsSame(result, checkResult);
            //PrintResult(isSuccess, (result), (checkResult));

            nums = new int[] { 1, 2, 2, 3, 4, 5 }; k = 3; t = 0;
            checkResult = true;
            result = ContainsNearbyAlmostDuplicate(nums, k, t);
            isSuccess &= IsSame(result, checkResult);
            PrintResult(isSuccess, (result), (checkResult));

            return isSuccess;
        }

        /// <summary>
        /// 作者：AC_OIer
        /// 链接：https://leetcode-cn.com/problems/contains-duplicate-iii/solution/gong-shui-san-xie-yi-ti-shuang-jie-hua-d-dlnv/
        /// Exceptions : 
        /// System.InvalidOperationException: Sequence contains no elements
        ///
        /// 未解决问题：没有找到对应 Java中TreeSet的 C#的集合类
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="k"></param>
        /// <param name="t"></param>
        /// <returns></returns>
        public bool ContainsNearbyAlmostDuplicate_NG(int[] nums, int k, int t)
        {
            int n = nums.Length;
            SortedSet<long> ts = new SortedSet<long>(); //TreeSet<long> ts = new TreeSet<long>();
            for (int i = 0; i < n; i++)
            {
                long u = nums[i] * 1L;
                // 从 ts 中找到小于等于 u 的最大值（小于等于 u 的最接近 u 的数）
                //long l = ts.floor(u);
                var l = ts.Where<long>(a => a <= u);
                // 从 ts 中找到大于等于 u 的最小值（大于等于 u 的最接近 u 的数）
                //long r = ts.ceiling(u);
                var r = ts.Where<long>(a => a >= u);
                if (l != null && u - l.Last() <= t) return true;
                if (r != null && r.First() - u <= t) return true;
                // 将当前数加到 ts 中，并移除下标范围不在 [max(0, i - k), i) 的数（维持滑动窗口大小为 k）
                ts.Add(u);
                if (i >= k) ts.Remove(nums[i - k] * 1L);
            }
            return false;


        }

        //作者：LeetCode - Solution
        //链接：https://leetcode-cn.com/problems/contains-duplicate-iii/solution/cun-zai-zhong-fu-yuan-su-iii-by-leetcode-bbkt/
        /// <summary>
        /// 
        /// 方法二：桶 (桶的大小为 t+1。)
        /// 
        /// 如果两个元素同属一个桶，那么这两个元素必然符合条件。
        /// 如果两个元素属于相邻桶，那么我们需要校验这两个元素是否差值不超过 t。
        /// 如果两个元素既不属于同一个桶，也不属于相邻桶，那么这两个元素必然不符合条件。
        ///
        /// 每一个整数 xx 表示为 x=(t+1)×a + b (0 ≤ b ≤ t) 的形式
        /// 这样 xx 即归属于编号为 a 的桶。
        /// 因为一个桶内至多只会有一个元素，所以我们使用哈希表实现即可。
        /// 
        /// 54/54 cases passed (128 ms)
        /// Your runtime beats 90.85 % of csharp submissions
        /// Your memory usage beats 32.92 % of csharp submissions(30.2 MB)
        /// 
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="k"></param>
        /// <param name="t"></param>
        /// <returns></returns>
        public bool ContainsNearbyAlmostDuplicate(int[] nums, int k, int t)
        {
            int n = nums.Length;
            Dictionary<long, long> map = new Dictionary<long, long>();

            //桶的大小为 t+1。
            long w = (long)t + 1;

            for (int i = 0; i < n; i++)
            {
                long id = getID(nums[i], w);
                //首先检查 xx 所属于的桶是否已经存在元素
                if (map.ContainsKey(id))
                {
                    return true;
                }
                //继续检查两个相邻的桶内是否存在符合条件的元素
                //如果两个元素属于相邻桶，那么我们需要校验这两个元素是否差值不超过 t。
                if (map.ContainsKey(id - 1) && Math.Abs(nums[i] - map[id - 1]) < w)
                {
                    return true;
                }
                if (map.ContainsKey(id + 1) && Math.Abs(nums[i] - map[id + 1]) < w)
                {
                    return true;
                }

                map[id] = (long)nums[i];
                if (i >= k)
                {
                    map.Remove(getID(nums[i - k], w));
                }
            }
            return false;
        }
        public long getID(long x, long w)
        {
            if (x >= 0)
            {
                return x / w;
            }
            return (x + 1) / w - 1;
        }
    }
    // @lc code=end


}
