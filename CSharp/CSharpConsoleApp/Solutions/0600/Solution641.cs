using System;
namespace CSharpConsoleApp.Solutions
{
    public class Solution641 : SolutionBase
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
        public override Tag[] GetTags() { return new Tag[] { Tag.Queue }; }

        /// <summary>
        /// </summary>
        /// <param name="sw"></param>
        /// <returns></returns>
        public override bool Test(System.Diagnostics.Stopwatch sw)
        {
            bool isSuccess = true;

            MyCircularDeque circularDeque = new MyCircularDeque(3); // 设置容量大小为3
            PrintDatas(circularDeque.InsertLast(1));                // 返回 true
            PrintDatas(circularDeque.InsertLast(2));                // 返回 true
            PrintDatas(circularDeque.InsertFront(3));               // 返回 true
            PrintDatas(circularDeque.InsertFront(4));               // 已经满了，返回 false
            PrintDatas(circularDeque.GetRear());                    // 返回 2
            PrintDatas(circularDeque.IsFull());                     // 返回 true
            PrintDatas(circularDeque.DeleteLast());                 // 返回 true
            PrintDatas(circularDeque.InsertFront(4));               // 返回 true
            PrintDatas(circularDeque.GetFront());                   // 返回 4
            return isSuccess;
        }
        /*
         * @lc app=leetcode.cn id=641 lang=csharp
         *
         * [641] 设计循环双端队列
         *
         * https://leetcode-cn.com/problems/design-circular-deque/description/
         *
         * Category	Difficulty	Likes	Dislikes
         * algorithms	Medium (53.41%)	82	-
         * Tags
         * Unknown
         * 
         * Companies
         * Unknown
 
         * Total Accepted:    20K
         * Total Submissions: 37.5K
         * Testcase Example:  '["MyCircularDeque","insertLast","insertLast","insertFront","insertFront","getRear","isFull","deleteLast","insertFront","getFront"]\n' +
          '[[3],[1],[2],[3],[4],[],[],[],[4],[]]'
         *
         * 设计实现双端队列。
         * 你的实现需要支持以下操作：
         * 
         * 
         * MyCircularDeque(k)：构造函数,双端队列的大小为k。
         * insertFront()：将一个元素添加到双端队列头部。 如果操作成功返回 true。
         * insertLast()：将一个元素添加到双端队列尾部。如果操作成功返回 true。
         * deleteFront()：从双端队列头部删除一个元素。 如果操作成功返回 true。
         * deleteLast()：从双端队列尾部删除一个元素。如果操作成功返回 true。
         * getFront()：从双端队列头部获得一个元素。如果双端队列为空，返回 -1。
         * getRear()：获得双端队列的最后一个元素。 如果双端队列为空，返回 -1。
         * isEmpty()：检查双端队列是否为空。
         * isFull()：检查双端队列是否满了。
         * 
         * 
         * 示例：
         * MyCircularDeque circularDeque = new MycircularDeque(3); // 设置容量大小为3
         * circularDeque.insertLast(1);                    // 返回 true
         * circularDeque.insertLast(2);                    // 返回 true
         * circularDeque.insertFront(3);                    // 返回 true
         * circularDeque.insertFront(4);                    // 已经满了，返回 false
         * circularDeque.getRear();                  // 返回 2
         * circularDeque.isFull();                        // 返回 true
         * circularDeque.deleteLast();                    // 返回 true
         * circularDeque.insertFront(4);                    // 返回 true
         * circularDeque.getFront();                // 返回 4
         * 
         * 
         * 提示：
         * 所有值的范围为 [1, 1000]
         * 操作次数的范围为 [1, 1000]
         * 请不要使用内置的双端队列库。
         * 
         * 
         */

        /// <summary>
        /// 51/51 cases passed (132 ms)
        /// Your runtime beats 81.82 % of csharp submissions
        /// Your memory usage beats 81.82 % of csharp submissions(34.9 MB)
        /// </summary>
        // @lc code=start
        public class MyCircularDeque
        {
            // 1、不用设计成动态数组，使用静态数组即可
            // 2、设计 head 和 tail 指针变量
            // 3、head == tail 成立的时候表示队列为空
            // 4、tail + 1 == head

            private int capacity;
            private int[] arr;
            private int front;
            private int rear;

            /**
             * Initialize your data structure here. Set the size of the deque to be k.
             */
            public MyCircularDeque(int k)
            {
                capacity = k + 1;
                arr = new int[capacity];

                // 头部指向第 1 个存放元素的位置
                // 插入时，先减，再赋值
                // 删除时，索引 +1（注意取模）
                front = 0;
                // 尾部指向下一个插入元素的位置
                // 插入时，先赋值，再加
                // 删除时，索引 -1（注意取模）
                rear = 0;
            }

            /**
             * Adds an item at the front of Deque. Return true if the operation is successful.
             */
            public bool InsertFront(int value)
            {
                if (IsFull())
                {
                    return false;
                }
                front = (front - 1 + capacity) % capacity;
                arr[front] = value;
                return true;
            }

            /**
             * Adds an item at the rear of Deque. Return true if the operation is successful.
             */
            public bool InsertLast(int value)
            {
                if (IsFull())
                {
                    return false;
                }
                arr[rear] = value;
                rear = (rear + 1) % capacity;
                return true;
            }

            /**
             * Deletes an item from the front of Deque. Return true if the operation is successful.
             */
            public bool deleteFront()
            {
                if (IsEmpty())
                {
                    return false;
                }
                // front 被设计在数组的开头，所以是 +1
                front = (front + 1) % capacity;
                return true;
            }

            /**
             * Deletes an item from the rear of Deque. Return true if the operation is successful.
             */
            public bool DeleteLast()
            {
                if (IsEmpty())
                {
                    return false;
                }
                // rear 被设计在数组的末尾，所以是 -1
                rear = (rear - 1 + capacity) % capacity;
                return true;
            }

            /**
             * Get the front item from the deque.
             */
            public int GetFront()
            {
                if (IsEmpty())
                {
                    return -1;
                }
                return arr[front];
            }

            /**
             * Get the last item from the deque.
             */
            public int GetRear()
            {
                if (IsEmpty())
                {
                    return -1;
                }
                // 当 rear 为 0 时防止数组越界
                return arr[(rear - 1 + capacity) % capacity];
            }

            /**
             * Checks whether the circular deque is empty or not.
             */
            public bool IsEmpty()
            {
                return front == rear;
            }

            /**
             * Checks whether the circular deque is full or not.
             */
            public bool IsFull()
            {
                // 注意：这个设计是非常经典的做法
                return (rear + 1) % capacity == front;
            }

            //作者：liweiwei1419
            //链接：https://leetcode-cn.com/problems/design-circular-deque/solution/shu-zu-shi-xian-de-xun-huan-shuang-duan-dui-lie-by/

        }

        /**
         * Your MyCircularDeque object will be instantiated and called as such:
         * MyCircularDeque obj = new MyCircularDeque(k);
         * bool param_1 = obj.InsertFront(value);
         * bool param_2 = obj.InsertLast(value);
         * bool param_3 = obj.DeleteFront();
         * bool param_4 = obj.DeleteLast();
         * int param_5 = obj.GetFront();
         * int param_6 = obj.GetRear();
         * bool param_7 = obj.IsEmpty();
         * bool param_8 = obj.IsFull();
         */
        // @lc code=end


    }
}
