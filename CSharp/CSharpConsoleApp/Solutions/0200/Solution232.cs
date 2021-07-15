using System;
using System.Collections.Generic;
namespace CSharpConsoleApp.Solutions
{
    public class Solution232 : SolutionBase
    {
        /// <summary>
        /// 难度
        /// </summary>
        public override Difficulity GetDifficulity() { return Difficulity.Easy; }
        /// <summary>
        /// 关键字:
        /// </summary>
        public override string[] GetKeyWords() { return new string[] { "" }; }
        /// <summary>
        /// 标签：
        /// </summary>
        public override Tag[] GetTags() { return new Tag[] { Tag.Stack, }; }

        public override bool Test(System.Diagnostics.Stopwatch sw)
        {
            bool isSuccess = true;
            MyQueue myQueue = new MyQueue();
            myQueue.Push(1); // queue is: [1]
            myQueue.Push(2); // queue is: [1, 2] (leftmost is front of the queue)
            myQueue.Peek(); // return 1
            myQueue.Pop(); // return 1, queue is [2]
            myQueue.Empty(); // return false

            return isSuccess;
        }

        /*
         * @lc app=leetcode.cn id=232 lang=csharp
         *
         * [232] 用栈实现队列
         *
         * https://leetcode-cn.com/problems/implement-queue-using-stacks/description/
         *
         * Category	Difficulty	Likes	Dislikes
         * algorithms	Easy (68.85%)	429	-
         * Tags
         * stack | design
         * 
         * Companies
         * bloomberg | microsoft
         * 
         * Total Accepted:    133.8K
         * Total Submissions: 194.4K
         * Testcase Example:  '["MyQueue","push","push","peek","pop","empty"]\n[[],[1],[2],[],[],[]]'
         *
         * 请你仅使用两个栈实现先入先出队列。队列应当支持一般队列支持的所有操作（push、pop、peek、empty）：
         * 
         * 实现 MyQueue 类：
         * void push(int x) 将元素 x 推到队列的末尾
         * int pop() 从队列的开头移除并返回元素
         * int peek() 返回队列开头的元素
         * boolean empty() 如果队列为空，返回 true ；否则，返回 false
         * 
         * 说明：
         * 你只能使用标准的栈操作 —— 也就是只有 push to top, peek/pop from top, size, 和 is empty
         * 操作是合法的。
         * 你所使用的语言也许不支持栈。你可以使用 list 或者 deque（双端队列）来模拟一个栈，只要是标准的栈操作即可。
         * 
         * 进阶：
         * 你能否实现每个操作均摊时间复杂度为 O(1) 的队列？换句话说，执行 n 个操作的总时间复杂度为 O(n)
         * ，即使其中一个操作可能花费较长时间。
         * 
         * 示例：
         * 输入：
         * ["MyQueue", "push", "push", "peek", "pop", "empty"]
         * [[], [1], [2], [], [], []]
         * 输出：
         * [null, null, null, 1, 1, false]
         * 
         * 解释：
         * MyQueue myQueue = new MyQueue();
         * myQueue.push(1); // queue is: [1]
         * myQueue.push(2); // queue is: [1, 2] (leftmost is front of the queue)
         * myQueue.peek(); // return 1
         * myQueue.pop(); // return 1, queue is [2]
         * myQueue.empty(); // return false
         * 
         * 
         * 提示：
         * 1 
         * 最多调用 100 次 push、pop、peek 和 empty
         * 假设所有操作都是有效的 （例如，一个空的队列不会调用 pop 或者 peek 操作）
         */

        //20/20 cases passed (124 ms)
        //Your runtime beats 48.42 % of csharp submissions
        //Your memory usage beats 30.53 % of csharp submissions(24.1 MB)
        // @lc code=start
        public class MyQueue
        {
            LinkedList<int> st;
            /** Initialize your data structure here. */
            public MyQueue()
            {
                st = new LinkedList<int>();
            }

            /** Push element x to the back of queue. */
            public void Push(int x)
            {
                st.AddLast(x);
            }

            /** Removes the element from in front of queue and returns that element. */
            public int Pop()
            {
                int res = st.First.Value;
                st.RemoveFirst();
                return res;
            }

            /** Get the front element. */
            public int Peek()
            {
                return st.First.Value;
            }

            /** Returns whether the queue is empty. */
            public bool Empty()
            {
                return st.Count == 0;
            }
        }

        /**
         * Your MyQueue object will be instantiated and called as such:
         * MyQueue obj = new MyQueue();
         * obj.Push(x);
         * int param_2 = obj.Pop();
         * int param_3 = obj.Peek();
         * bool param_4 = obj.Empty();
         */
        // @lc code=end
    }
}
