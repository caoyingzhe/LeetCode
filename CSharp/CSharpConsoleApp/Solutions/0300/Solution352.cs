using System;
using System.Collections.Generic;
using System.Linq;
namespace CSharpConsoleApp.Solutions
{
    public class Solution352
    {
        /*
        * @lc app=leetcode.cn id=352 lang=csharp
        *
        * [352] 将数据流变为多个不相交区间
        *
        * https://leetcode-cn.com/problems/data-stream-as-disjoint-intervals/description/
        *
        * Category	Difficulty	Likes	Dislikes
        * algorithms	Hard (59.32%)	62	-
        * Tags
        * binary-search | ordered-map
        * 
        * Companies
        * Unknown
        * 
        * Total Accepted:    4.1K
        * Total Submissions: 6.9K
        * Testcase Example:  '["SummaryRanges","addNum","getIntervals","addNum","getIntervals","addNum","getIntervals","addNum","getIntervals","addNum","getIntervals"]\n' +
        '[[],[1],[],[3],[],[7],[],[2],[],[6],[]]'
        *
        * 给定一个非负整数的数据流输入 a1，a2，…，an，…，将到目前为止看到的数字总结为不相交的区间列表。
        * 
        * 例如，假设数据流中的整数为 1，3，7，2，6，…，每次的总结为：
        * [1, 1]
        * [1, 1], [3, 3]
        * [1, 1], [3, 3], [7, 7]
        * [1, 3], [7, 7]
        * [1, 3], [6, 7]
        * 
        * 
        * 进阶：
        * 如果有很多合并，并且与数据流的大小相比，不相交区间的数量很小，该怎么办?
        * 
        * 提示：
        * 特别感谢 @yunhong 提供了本问题和其测试用例。
        * 
        */

        /// <summary>
        /// 作者：hxz1998
        /// 链接：https://leetcode-cn.com/problems/data-stream-as-disjoint-intervals/solution/java-ji-he-fang-fa-zhu-xing-zhu-shi-by-h-3pyn/
        ///
        /// 9/9 cases passed (480 ms)
        /// Your runtime beats 100 % of csharp submissions
        /// Your memory usage beats 100 % of csharp submissions(42.6 MB)
        /// 使用有序的哈希集合方法
        /// </summary>
        // @lc code=start
        public class SummaryRanges
        {
            private SortedSet<int> set;
            /** Initialize your data structure here. */
            public SummaryRanges()
            {
                set = new SortedSet<int>();
            }

            public void AddNum(int val)
            {
                set.Add(val);
            }

            public int[][] GetIntervals()
            {
                List<int[]> ret = new List<int[]>();

                // 逐个检查集合中相邻的两个元素
                // [Java]: Iterator<Integer> iterator = set.iterator();
                var iterator = set.GetEnumerator(); iterator.MoveNext(); //此处需要MoveNext，否则一开始指向空，即默认值为0.
                // [Java]: int begin = iterator.next(), end = begin;
                int begin = iterator.Current, end = begin;

                // [Java]: while (iterator.hasNext())
                while (iterator.MoveNext())
                {
                    int t = iterator.Current;
                    // 通过比较下一个元素和当前 end 之差是不是1，看看是否需要开始新的区间
                    if (t != end + 1)
                    {
                        // 如果需要更新的话，就先把当前区间放到返回值中，然后再重新开始新的区间
                        ret.Add(new int[] { begin, end });
                        begin = t;
                        end = begin;
                    }
                    else
                    {
                        // 否则的话，就更新当前区间的 end
                        end = t;
                    }
                }
                // 最后需要把剩余的区间放到返回值中
                ret.Add(new int[] { begin, end });
                return ret.ToArray();
            }
        }

        /**
         * Your SummaryRanges object will be instantiated and called as such:
         * SummaryRanges obj = new SummaryRanges();
         * obj.AddNum(val);
         * int[][] param_2 = obj.GetIntervals();
         */
        // @lc code=end
    }
}
