using System;
using System.Collections.Generic;
namespace CSharpConsoleApp.Solutions
{
    public class Solution284 : SolutionBase
    {
        /// <summary>
        /// 难度
        /// </summary>
        public override Difficulity GetDifficulity() { return Difficulity.Medium; }
        /// <summary>
        /// 关键字:
        /// </summary>
        public override string[] GetKeyWords() { return new string[] { "循环数组", "单调栈" }; }
        /// <summary>
        /// 标签：
        /// </summary>
        public override Tag[] GetTags() { return new Tag[] { Tag.Design, }; }

        public override bool Test(System.Diagnostics.Stopwatch sw)
        {
            bool isSuccess = true;

            List<int> nums = new List<int>(new int[] { 1, 2, 3 });
            PeekingIterator pi = new PeekingIterator(nums.GetEnumerator());

            Print("Next {0}", pi.Next());
            Print("Peek {0}", pi.Peek());
            Print("Next {0}", pi.Next());
            Print("Next {0}", pi.Next());
            Print("HasNext {0}", pi.HasNext());

            return isSuccess;
        }

        
    }

    /*
     * @lc app=leetcode.cn id=284 lang=csharp
     *
     * [284] 顶端迭代器
     *
     * https://leetcode-cn.com/problems/peeking-iterator/description/
     *
     * Category	Difficulty	Likes	Dislikes
     * algorithms	Medium (73.27%)	83	-
     * Tags
     * design
     * 
     * Companies
     * apple | google | yahoo
     * 
     * Total Accepted:    8.9K
     * Total Submissions: 12.2K
     * Testcase Example:  '["PeekingIterator","next","peek","next","next","hasNext"]\n' +
      '[[[1,2,3]],[],[],[],[],[]]'
     *
     * 给定一个迭代器类的接口，接口包含两个方法： next() 和 hasNext()。设计并实现一个支持 peek() 操作的顶端迭代器 --
     * 其本质就是把原本应由 next() 方法返回的元素 peek() 出来。
     * 
     * 示例:
     * 
     * 假设迭代器被初始化为列表 [1,2,3]。
     * 
     * 调用 next() 返回 1，得到列表中的第一个元素。
     * 现在调用 peek() 返回 2，下一个元素。在此之后调用 next() 仍然返回 2。
     * 最后一次调用 next() 返回 3，末尾元素。在此之后调用 hasNext() 应该返回 false。
     * 
     * 
     * 进阶：你将如何拓展你的设计？使之变得通用化，从而适应所有的类型，而不只是整数型？
     * 
     */

    // @lc code=start
    // C# IEnumerator interface reference:
    // https://docs.microsoft.com/en-us/dotnet/api/system.collections.ienumerator?view=netframework-4.8

    /// <summary>
    /// 14/14 cases passed (128 ms)
    /// Your runtime beats 90.48 % of csharp submissions
    /// Your memory usage beats 33.33 % of csharp submissions(24.9 MB)
    /// </summary>
    class PeekingIterator
    {
        private LinkedList<int> queue;
        // iterators refers to the first element of the array.
        public PeekingIterator(IEnumerator<int> iterator)
        {
            // initialize any member here.

            //下面的代码在Leetcode中通过，在VS中不行。
            //TODO 奇怪的结果，推测：LeetCode迭代器和实现方法和Mac上的VS中的不同。
            //LeetCode Result: 1,2,2,3,False
            //VSCode Result:   0,1,1,2,True
            //queue.AddLast(iterator.Current);
            //while (iterator.MoveNext())
            //{
            //    queue.AddLast(iterator.Current);
            //}

            //TODO VS 中正确代码，LeetCode中通不过。
            queue = new LinkedList<int>();
            while (iterator.MoveNext())
            {
                queue.AddLast(iterator.Current);
            }
        }

        // Returns the next element in the iteration without advancing the iterator.
        public int Peek()
        {
            if (queue.Count == 0)
                return -1;
            //取得栈顶
            return queue.First.Value;
        }

        // Returns the next element in the iteration and advances the iterator.
        public int Next()
        {
            if (queue.Count == 0)
                return -1;
            int t = queue.First.Value;                     //C#写法 先取值
            queue.RemoveFirst();                           //C#写法 再删除
            return t;
        }

        // Returns false if the iterator is refering to the end of the array of true otherwise.
        public bool HasNext()
        {
            return queue.Count > 0;
        }
    }
    // @lc code=end


}
