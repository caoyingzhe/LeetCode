 
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpConsoleApp.Solutions
{
    /*
     * @lc app=leetcode.cn id=239 lang=csharp
     *
     * [239] 滑动窗口最大值
     *
     * https://leetcode-cn.com/problems/sliding-window-maximum/description/
     *
     * algorithms
     * Hard (49.49%)
     * Likes:    948
     * Dislikes: 0
     * Total Accepted:    141.8K
     * Total Submissions: 286.4K
     * Testcase Example:  '[1,3,-1,-3,5,3,6,7]\n3'
     *
     * 给你一个整数数组 nums，有一个大小为 k 的滑动窗口从数组的最左侧移动到数组的最右侧。你只可以看到在滑动窗口内的 k
     * 个数字。滑动窗口每次只向右移动一位。
     * 返回滑动窗口中的最大值。
     * 
     * 示例 1：
     * 输入：nums = [1,3,-1,-3,5,3,6,7], k = 3
     * 输出：[3,3,5,5,6,7]
     * 解释：
     * 滑动窗口的位置                最大值
     * ---------------               -----
     * [1  3  -1] -3  5  3  6  7       3
     * ⁠1 [3  -1  -3] 5  3  6  7       3
     * ⁠1  3 [-1  -3  5] 3  6  7       5
     * ⁠1  3  -1 [-3  5  3] 6  7       5
     * ⁠1  3  -1  -3 [5  3  6] 7       6
     * ⁠1  3  -1  -3  5 [3  6  7]      7
     * 
     * 示例 2：
     * 输入：nums = [1], k = 1
     * 输出：[1]
     * 
     * 示例 3：
     * 输入：nums = [1,-1], k = 1
     * 输出：[1,-1]
     * 
     * 示例 4：
     * 输入：nums = [9,11], k = 2
     * 输出：[11]
     * 
     * 示例 5：
     * 输入：nums = [4,-2], k = 2
     * 输出：[4]
     * 
     * 提示：
     * 1 <= nums.length <= 10^5
     * -10^4 <= nums[i] <= 10^4
     * 1 <= k <= nums.length
     */
    class Solution239 : SolutionBase
    {
        /// <summary>
        /// 难度
        /// </summary>
        public override Difficulity GetDifficulity() { return Difficulity.Hard; }
        /// <summary>
        /// 关键字:
        /// </summary>
        public override string[] GetKeyWords() { return new string[] { "优先队列（堆）", }; }
        /// <summary>
        /// 标签：
        /// </summary>
        public override Tag[] GetTags() { return new Tag[] { Tag.Heap, Tag.SlidingWindow }; }
        public override bool Test(System.Diagnostics.Stopwatch sw)
        {
            bool isSuccess = true;

            int[] nums; int k; int[] result;
            int[] checkResult;

            nums = new int[] { 1, 3, -1, -3, 5, 3, 6, 7, 8, 9 };
            k = 3;
            checkResult = new int[] { 3, 3, 5, 5, 6, 7, 8, 9 };
            result = MaxSlidingWindow(nums, k);
            isSuccess &= IsArraySame(result, checkResult);
            Print("isSuccess = {0} | result = {1} | anticipated = {2}", isSuccess, GetArrayStr<int>(result), GetArrayStr<int>(checkResult));

            //nums = new int[] { 1 };
            //k = 1;
            //checkResult = new int[] { 1 };
            //result = MaxSlidingWindow(nums, k);

            //isSuccess &= IsArraySame(result, checkResult);
            //Print("isSuccess = {0} | result = {1} | anticipated = {2}", isSuccess, result, checkResult);
            //
            //nums = new int[] { 1, -1 };
            //k = 1;
            //checkResult = new int[] { 1, -1 };
            //result = MaxSlidingWindow(nums, k);
            //isSuccess &= IsArraySame(result, checkResult);
            //Print("isSuccess = {0} | result = {1} | anticipated = {2}", isSuccess, result, checkResult);
            //
            //nums = new int[] { 4, -2 };
            //k = 2;
            //checkResult = new int[] { 4 };
            //result = MaxSlidingWindow(nums, k);
            //isSuccess &= IsArraySame(result, checkResult);
            //Print("isSuccess = {0} | result = {1} | anticipated = {2}", isSuccess, result, checkResult);
            
            return isSuccess;
        }

        public int[] MaxSlidingWindow(int[] nums, int k)
        {
            int n = nums.Length;

            //Queue<int[]> pq = new Queue<int[]>( );
            PriorityQueue<int[]> pq = new PriorityQueue<int[]>(new ComparerSolution239());
            for (int i = 0; i<k; ++i) {
                pq.Push(new int[] { nums[i], i });//pq.offer(new int[]{nums[i], i});
            }
            
            int[] ans = new int[n - k + 1];
            ans[0] = pq.Top()[0];

            for (int i = k; i<n; ++i) {
                //优先队列，Enqueue方法会自动排序，算法的重要处理。
                pq.Push(new int[] { nums[i], i });  // pq.offer(new int[]{nums[i], i});
                
                while (pq.Top()[1] <= i - k) {
                    // pq.poll(); // poll 方法每次从 PriorityQueue 的头部删除一个节点
                    pq.Pop();    //C#中没有 poll方法。
                }
                ans[i - k + 1] = pq.Top()[0];
            }
            return ans;
        }
    }

    /// <summary>
    /// 若希望对自建类进行比较或排序，那么可以使用IComparable<T>和IComparer<T>接口。
    /// 一、IComparable<T> 接口
    /// 继承IComparable<T> 接口，可以给自建类实现一个通用的比较方法，使自建类的数组可以使用Array.Sort方法进行排序。
    /// 实现IComparable<T> 接口，要求在类中实现CompareTo方法，该方法参数是一个T类型的对象，返回值必须是-1,0,1中之一。
    /// </summary>
    public class ComparerSolution239 : IComparer<int[]>
    {
        public int Compare(int[] pair1, int[] pair2)
        {
            //在[239] 滑动窗口最大值中，[0]代表值，[1]代表数组中的索引
            //重大疑惑：官方提供的Java代码的比较方法是相反的。
            return pair1[0] != pair2[0] ? pair1[0] - pair2[0] : pair1[1] - pair2[1];
        }
    }
}
