
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpConsoleApp.Solutions._0300
{
    /*
     * @lc app=leetcode.cn id=315 lang=csharp
     *
     * [315] 计算右侧小于当前元素的个数
     *
     * https://leetcode-cn.com/problems/count-of-smaller-numbers-after-self/description/
     *
     * Category	Difficulty	Likes	Dislikes
     * algorithms	Hard (42.08%)	570	-
     * Tags
     * binary-search | divide-and-conquer | sort | binary-indexed-tree | segment-tree
     * 
     * Companies
     * google
     * 
     * Total Accepted:    43.8K
     * Total Submissions: 104.2K
     * Testcase Example:  '[5,2,6,1]'
     *
     * 给定一个整数数组 nums，按要求返回一个新数组 counts。数组 counts 有该性质： counts[i] 的值是  nums[i] 右侧小于
     * nums[i] 的元素的数量。
     * 
     * 示例：
     * 输入：nums = [5,2,6,1]
     * 输出：[2,1,1,0] 
     * 解释：
     * 5 的右侧有 2 个更小的元素 (2 和 1)
     * 2 的右侧仅有 1 个更小的元素 (1)
     * 6 的右侧有 1 个更小的元素 (1)
     * 1 的右侧有 0 个更小的元素
     * 
     * 
     * 提示：
     * 0 <= nums.Length <= 10^5
     * -10^4 <= nums[i] <= 10^4
     * 
     */

    class Solution315 : SolutionBase
    {
        /// <summary>
        /// 难度
        /// </summary>
        public override Difficulity GetDifficulity() { return Difficulity.Hard; }
        /// <summary>
        /// 关键字:
        /// </summary>
        public override string[] GetKeyWords() { return new string[] { "binary-search | divide-and-conquer | sort | binary-indexed-tree | segment-tree", }; }
        /// <summary>
        /// 标签：
        /// </summary>
        public override Tag[] GetTags() { return new Tag[] { Tag.BinarySearch, Tag.DivideAndConquer, Tag.Sort, Tag.BinaryIndexedTree, Tag.SegmentTree }; }
        public override bool Test(System.Diagnostics.Stopwatch sw)
        {
            bool isSuccess = true;
            int[] nums;
            IList<int> result;
            int[] checkResult;

            nums = new int[] { 5, 2, 6, 1 };
            checkResult = new int[] { 2, 1, 1, 0 };
            result = CountSmaller(nums);
            isSuccess &= IsArraySame(result.ToArray(), checkResult);
            Print("isSuccess = {0} | result = {1} | anticipated = {2}", isSuccess, GetArrayStr<int>(result), GetArrayStr<int>(checkResult));

            nums = new int[] { 2, 0, 1 };
            checkResult = new int[] { 2, 0, 0 };
            result = CountSmaller(nums);
            isSuccess &= IsArraySame(result.ToArray(), checkResult);
            Print("isSuccess = {0} | result = {1} | anticipated = {2}", isSuccess, GetArrayStr<int>(result), GetArrayStr<int>(checkResult));

            nums = new int[] { -1, -2 };
            checkResult = new int[] { 1, 0 };
            result = CountSmaller(nums);
            isSuccess &= IsArraySame(result.ToArray(), checkResult);
            Print("isSuccess = {0} | result = {1} | anticipated = {2}", isSuccess, GetArrayStr<int>(result), GetArrayStr<int>(checkResult));

            return isSuccess;
        }

        /// <summary>
        /// 常规方法：一定超时；
        /// Time Limit Exceeded 
        /// 55/65 cases passed (N/A)
        /// 
        /// 方法一：离散化树状数组
        /// 方法二：归并排序
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public IList<int> CountSmaller_TLE(int[] nums)
        {
            List<int> result = new List<int>();
            Dictionary<int, int> dict = new Dictionary<int, int>();

            int n = nums.Length;
            for (int i = n - 1; i >= 0; i--)
            {
                int count = 0;
                for (int j = i + 1; j < n; j++)
                {
                    if (nums[j] < nums[i])
                        count++;
                }
                result.Add(count);
            }
            result.Reverse();
            return result;
        }

        /// <summary>
        /// 小改进一下
        /// 
        /// Time Limit Exceeded
        /// 57/65 cases passed(N/A)
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public IList<int> CountSmaller_TLE2(int[] nums)
        {
            int[] numCounts = new int[20001];
            List<int> result = new List<int>(10000);
            Dictionary<int, int> dict = new Dictionary<int, int>();

            int n = nums.Length;

            int count = 0;
            int preCount = 0;
            for (int i = n - 1; i >= 0; i--)
            {
                int num = nums[i];
                numCounts[num + 10000]++; //更新对应数字出现次数。

                preCount = count;
                count = 0;
                for (int j = 0; j < 10000 + num; j++)
                {
                    count += numCounts[j];
                }
                result.Add(count);
            }
            result.Reverse();
            return result;
        }

        /// <summary>
        /// 50/65 cases passed (N/A)
        /// 思路没问题，就是LTE，细节没抓住要点。 前缀和的计算能不能优化？？
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public IList<int> CountSmaller_TLE3(int[] nums)
        {
            int[] numCounts = new int[20001];
            List<int> result = new List<int>(10000);

            Dictionary<int, int> dict = new Dictionary<int, int>();

            int n = nums.Length;

            int count = 0;

            int numIndexPre = 0;
            for (int i = n - 1; i >= 0; i--)
            {
                int num = nums[i];

                int numIndex = num + 10000;

                if (!dict.ContainsKey(numIndex))
                    dict.Add(numIndex, num);

                numCounts[numIndex]++; //更新对应数字出现次数。
                                       //Print("i={0} num = {2} numCounts[numIndex] =  numCounts[{1}] =  numIndexPre = {3} numIndex {2}", i, numIndex, num, numIndexPre);

                if (numIndexPre < numIndex)
                {
                    foreach (int pIndex in dict.Keys)
                    {
                        if (pIndex >= numIndexPre && pIndex < numIndex)
                        {
                            count += numCounts[pIndex];
                        }
                    }
                }
                else if (numIndexPre > numIndex)
                {
                    count = 0;
                    foreach (int pIndex in dict.Keys)
                    {
                        if (pIndex < numIndex)
                        {
                            count += numCounts[pIndex];
                        }
                    }

                }
                else if (numIndexPre == numIndex)
                {

                }

                numIndexPre = numIndex;
                //Print("i={0} Add count = {1}", i, count);
                result.Add(count);
            }
            result.Reverse();
            return result;
        }

        #region ---------------------------- 官方解答 ----------------------------------------
        //作者：LeetCode-Solution
        //链接：https://leetcode-cn.com/problems/count-of-smaller-numbers-after-self/solution/ji-suan-you-ce-xiao-yu-dang-qian-yuan-su-de-ge-s-7/

        // 官方答案，这么慢，一定是哪里不对。
        // 65/65 cases passed(772 ms)
        // Your runtime beats 8.33 % of csharp submissions
        // Your memory usage beats 45.83 % of csharp submissions(49.2 MB)

        private int[] c;
        private int[] a;

        public List<int> CountSmaller(int[] nums)
        {
            List<int> resultList = new List<int>();
            discretization(nums);
            init(nums.Length + 5);
            for (int i = nums.Length - 1; i >= 0; --i)
            {
                int id = getId(nums[i]);

                resultList.Add(query(id - 1));
                update(id);
            }
            resultList.Reverse(); // Collections.reverse(resultList);
            return resultList;
        }

        private void init(int length)
        {
            c = new int[length];
            //Arrays.fill(c, 0);
        }

        private int lowBit(int x)
        {
            return x & (-x);
        }

        private void update(int pos)
        {
            while (pos < c.Length)
            {
                c[pos] += 1;
                pos += lowBit(pos);
            }
        }

        private int query(int pos)
        {
            int ret = 0;
            while (pos > 0)
            {
                ret += c[pos];
                pos -= lowBit(pos);
            }

            return ret;
        }

        private void discretization(int[] nums)
        {
            //添加出现的数字到哈希表（最大20001)
            HashSet<int> set = new HashSet<int>();
            foreach (int num in nums)
            {
                set.Add(num);
            }
            //建立对应数量的数组（最大20001)
            int size = set.Count;
            a = new int[size];
            int index = 0;
            foreach (int num in set)
            {
                a[index++] = num;
            }
            Array.Sort(a); //Arrays.sort(a); 这应该是最慢的处理。
        }

        private int getId(int x)
        {
            //return Arrays.binarySearch(a, x) + 1;
            return Array.BinarySearch(a, x) + 1;
        }
        #endregion
    }
}
