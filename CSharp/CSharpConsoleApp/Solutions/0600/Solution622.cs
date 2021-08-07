using System;
namespace CSharpConsoleApp.Solutions
{
    public class Solution622 : SolutionBase
    {
        /// <summary>
        /// 难度
        /// </summary>
        public override Difficulity GetDifficulity() { return Difficulity.Medium; }
        /// <summary>
        /// 关键字:
        /// </summary>
        public override string[] GetKeyWords() { return new string[] { "抄作业" }; }
        /// <summary>
        /// 标签：
        /// </summary>
        public override Tag[] GetTags() { return new Tag[] { Tag.Tree }; }

        /// <summary>
        /// </summary>
        /// <param name="sw"></param>
        /// <returns></returns>
        public override bool Test(System.Diagnostics.Stopwatch sw)
        {
            bool isSuccess = true;

            MyCircularQueue circularQueue = new MyCircularQueue(3); // 设置长度为 3
            PrintDatas(circularQueue.EnQueue(1));  // 返回 true
            PrintDatas(circularQueue.EnQueue(2));  // 返回 true
            PrintDatas(circularQueue.EnQueue(3));  // 返回 true
            PrintDatas(circularQueue.EnQueue(4));  // 返回 false，队列已满
            PrintDatas(circularQueue.Rear());  // 返回 3
            PrintDatas(circularQueue.IsFull());  // 返回 true
            PrintDatas(circularQueue.DeQueue());  // 返回 true
            PrintDatas(circularQueue.EnQueue(4));  // 返回 true
            PrintDatas(circularQueue.Rear());  // 返回 4
            return isSuccess;
        }

        /*
         * @lc app=leetcode.cn id=622 lang=csharp
         *
         * [622] 设计循环队列
         *
         * https://leetcode-cn.com/problems/design-circular-queue/description/
         *
         * Category	Difficulty	Likes	Dislikes
         * algorithms	Medium (43.42%)	200	-
         * Tags
         * Unknown
         * 
         * Companies
         * Unknown
         * Total Accepted:    60.2K
         * Total Submissions: 138.3K
         * Testcase Example:  '["MyCircularQueue","enQueue","enQueue","enQueue","enQueue","Rear","isFull","deQueue","enQueue","Rear"]\n' +
          '[[3],[1],[2],[3],[4],[],[],[],[4],[]]'
         *
         * 设计你的循环队列实现。 循环队列是一种线性数据结构，其操作表现基于
         * FIFO（先进先出）原则并且队尾被连接在队首之后以形成一个循环。它也被称为“环形缓冲器”。
         * 
         * 循环队列的一个好处是我们可以利用这个队列之前用过的空间。在一个普通队列里，一旦一个队列满了，我们就不能插入下一个元素，即使在队列前面仍有空间。但是使用循环队列，我们能使用这些空间去存储新的值。
         * 
         * 你的实现应该支持如下操作：
         * MyCircularQueue(k): 构造器，设置队列长度为 k 。
         * Front: 从队首获取元素。如果队列为空，返回 -1 。
         * Rear: 获取队尾元素。如果队列为空，返回 -1 。
         * enQueue(value): 向循环队列插入一个元素。如果成功插入则返回真。
         * deQueue(): 从循环队列中删除一个元素。如果成功删除则返回真。
         * isEmpty(): 检查循环队列是否为空。
         * isFull(): 检查循环队列是否已满。
         * 
         * 
         * 示例：
         * MyCircularQueue circularQueue = new MyCircularQueue(3); // 设置长度为 3
         * circularQueue.EnQueue(1);  // 返回 true
         * circularQueue.EnQueue(2);  // 返回 true
         * circularQueue.EnQueue(3);  // 返回 true
         * circularQueue.EnQueue(4);  // 返回 false，队列已满
         * circularQueue.Rear();  // 返回 3
         * circularQueue.isFull();  // 返回 true
         * circularQueue.deQueue();  // 返回 true
         * circularQueue.EnQueue(4);  // 返回 true
         * circularQueue.Rear();  // 返回 4
         * 
         * 
         * 提示：
         * 所有的值都在 0 至 1000 的范围内；
         * 操作数将在 1 至 1000 的范围内；
         * 请不要使用内置的队列库。
         */

        // @lc code=start

        /// <summary>
        /// 作者：LeetCode
        /// 链接：https://leetcode-cn.com/problems/design-circular-queue/solution/she-ji-xun-huan-dui-lie-by-leetcode/
        /// 57/57 cases passed (136 ms)
        /// Your runtime beats 93.4 % of csharp submissions
        /// Your memory usage beats 14.15 % of csharp submissions(35 MB)
        /// </summary>
        public class MyCircularQueue
        {
            private int[] queue;
            private int headIndex;
            private int count;
            private int capacity;

            /** Initialize your data structure here. Set the size of the queue to be k. */
            public MyCircularQueue(int k)
            {
                this.capacity = k;
                this.queue = new int[k];
                this.headIndex = 0;
                this.count = 0;
            }

            /** Insert an element into the circular queue. Return true if the operation is successful. */
            public bool EnQueue(int value)
            {
                if (this.count == this.capacity)
                    return false;
                this.queue[(this.headIndex + this.count) % this.capacity] = value;
                this.count += 1;
                return true;
            }

            /** Delete an element from the circular queue. Return true if the operation is successful. */
            public bool DeQueue()
            {
                if (this.count == 0)
                    return false;
                this.headIndex = (this.headIndex + 1) % this.capacity;
                this.count -= 1;
                return true;
            }

            /** Get the front item from the queue. */
            public int Front()
            {
                if (this.count == 0)
                    return -1;
                return this.queue[this.headIndex];
            }

            /** Get the last item from the queue. */
            public int Rear()
            {
                if (this.count == 0)
                    return -1;
                int tailIndex = (this.headIndex + this.count - 1) % this.capacity;
                return this.queue[tailIndex];
            }

            /** Checks whether the circular queue is empty or not. */
            public bool IsEmpty()
            {
                return (this.count == 0);
            }

            /** Checks whether the circular queue is full or not. */
            public bool IsFull()
            {
                return (this.count == this.capacity);
            }

        }

        /**
         * Your MyCircularQueue object will be instantiated and called as such:
         * MyCircularQueue obj = new MyCircularQueue(k);
         * bool param_1 = obj.EnQueue(value);
         * bool param_2 = obj.DeQueue();
         * int param_3 = obj.Front();
         * int param_4 = obj.Rear();
         * bool param_5 = obj.IsEmpty();
         * bool param_6 = obj.IsFull();
         */
        // @lc code=end


    }
}
