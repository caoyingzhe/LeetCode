
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CSharpConsoleApp.Solutions;
using PriorityQueue = CSharpConsoleApp.Solutions.SolutionBase.PriorityQueue<int>;
namespace CSharpConsoleApp.Solutions._0200
{
    /*
     * @lc app=leetcode.cn id=295 lang=csharp
     *
     * [295] 数据流的中位数
     *
     * https://leetcode-cn.com/problems/find-median-from-data-stream/description/
     *
     * Category	Difficulty	Likes	Dislikes
     * algorithms	Hard (51.36%)	400	-
     * Tags
     * heap | design
     * 
     * Companies
     * google
     * 
     * Total Accepted:    34.5K
     * Total Submissions: 66.9K
     * Testcase Example:  '["MedianFinder","addNum","addNum","findMedian","addNum","findMedian"]\n' +
      '[[],[1],[2],[],[3],[]]'
     *
     * 中位数是有序列表中间的数。如果列表长度是偶数，中位数则是中间两个数的平均值。
     * 
     * 例如，
     * 
     * [2,3,4] 的中位数是 3
     * 
     * [2,3] 的中位数是 (2 + 3) / 2 = 2.5
     * 
     * 设计一个支持以下两种操作的数据结构：
     * 
     * 
     * void addNum(int num) - 从数据流中添加一个整数到数据结构中。
     * double findMedian() - 返回目前所有元素的中位数。
     * 
     * 
     * 示例：
     * 
     * addNum(1)
     * addNum(2)
     * findMedian() -> 1.5
     * addNum(3) 
     * findMedian() -> 2
     * 
     * 进阶:
     * 
     * 
     * 如果数据流中所有整数都在 0 到 100 范围内，你将如何优化你的算法？
     * 如果数据流中 99% 的整数都在 0 到 100 范围内，你将如何优化你的算法？
     * 
     * 
     */

    class Solution295 : SolutionBase
    {
        /// <summary>
        /// 难度
        /// </summary>
        public override Difficulity GetDifficulity() { return Difficulity.Hard; }
        /// <summary>
        /// 关键字:
        /// </summary>
        public override string[] GetKeyWords() { return new string[] { "动态编程", }; }
        /// <summary>
        /// 标签：
        /// </summary>
        public override Tag[] GetTags() { return new Tag[] { Tag.DivideAndConquer, Tag.DynamicProgramming }; }

        public override bool Test(System.Diagnostics.Stopwatch sw)
        {
            bool isSuccess = true;
            int num = 0;

            MedianFinder obj = new MedianFinder();
            obj.AddNum(num);
            double param_2 = obj.FindMedian();

            return isSuccess;
        }

    }

    public class MedianFinder
    {
        private PriorityQueue small;  //private final PriorityQueue<Integer> small;
        private PriorityQueue large;  //private final PriorityQueue<Integer> large;
        /** initialize your data structure here. */
        public MedianFinder()
        {
            small = new PriorityQueue(new SolutionBase.ComparerIntAsc());//small = new PriorityQueue<>(Comparator.reverseOrder());
            large = new PriorityQueue();//large = new PriorityQueue<>();
        }

        public void AddNum(int num)
        {
            if (small.Count >= large.Count)
            {
                small.Push(num);  //small.offer(num);

                large.Push(small.Pop()); //large.offer(small.poll());
            }
            else
            {
                large.Push(num); //large.offer(num);
                small.Push(large.Pop()); //small.offer(large.poll());
            }
        }

        public double FindMedian()
        {
            if (small.Count == 0 && large.Count == 0) //if (small.isEmpty() && large.isEmpty())
            {
                return 0;
            }

            if (small.Count > large.Count)
            {
                return small.Top(); //return small.peek();
            }
            else if (large.Count > small.Count)
            {
                return large.Top(); //return large.peek();
            }
            else
            {
                return (small.Top() + large.Top()) / 2.0;  //return (small.peek() + large.peek()) / 2.0;
            }
        }
    }

    /**
     * Your MedianFinder object will be instantiated and called as such:
     * MedianFinder obj = new MedianFinder();
     * obj.AddNum(num);
     * double param_2 = obj.FindMedian();
     */
}
