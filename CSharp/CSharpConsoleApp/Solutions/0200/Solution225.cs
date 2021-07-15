using System;
using System.Collections.Generic;
namespace CSharpConsoleApp.Solutions
{
    public class Solution225 : SolutionBase
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
        public override Tag[] GetTags() { return new Tag[] { Tag.Stack, Tag.Design, }; }

        public override bool Test(System.Diagnostics.Stopwatch sw)
        {
            bool isSuccess = true;
            return isSuccess;
        }


        /*
         * @lc app=leetcode.cn id=225 lang=csharp
         *
         * [225] 用队列实现栈
         *
         * https://leetcode-cn.com/problems/implement-stack-using-queues/description/
         *
         * Category	Difficulty	Likes	Dislikes
         * algorithms	Easy (67.35%)	341	-
         * Tags
         * stack | design
         * 
         * Companies
         * bloomberg
         * 
         * Total Accepted:    117.2K
         * Total Submissions: 173.9K
         * Testcase Example:  '["MyStack","push","push","top","pop","empty"]\n[[],[1],[2],[],[],[]]'
         *
         * 请你仅使用两个队列实现一个后入先出（LIFO）的栈，并支持普通队列的全部四种操作（push、top、pop 和 empty）。
         * 
         * 实现 MyStack 类：
         * void push(int x) 将元素 x 压入栈顶。
         * int pop() 移除并返回栈顶元素。
         * int top() 返回栈顶元素。
         * boolean empty() 如果栈是空的，返回 true ；否则，返回 false 。
         * 
         * 
         * 注意：
         * 你只能使用队列的基本操作 —— 也就是 push to back、peek/pop from front、size 和 is empty
         * 这些操作。
         * 你所使用的语言也许不支持队列。 你可以使用 list （列表）或者 deque（双端队列）来模拟一个队列 , 只要是标准的队列操作即可。
         * 
         * 
         * 示例：
         * 输入：
         * ["MyStack", "push", "push", "top", "pop", "empty"]
         * [[], [1], [2], [], [], []]
         * 输出：
         * [null, null, null, 2, 2, false]
         * 
         * 解释：
         * MyStack myStack = new MyStack();
         * myStack.push(1);
         * myStack.push(2);
         * myStack.top(); // 返回 2
         * myStack.pop(); // 返回 2
         * myStack.empty(); // 返回 False
         *
         * 
         * 提示：
         * 1 <= x <= 9
         * 最多调用100 次 push、pop、top 和 empty
         * 每次调用 pop 和 top 都保证栈不为空
         * 
         * 进阶：你能否实现每种操作的均摊时间复杂度为 O(1) 的栈？换句话说，执行 n 个操作的总时间复杂度 O(n)
         * ，尽管其中某个操作可能需要比其他操作更长的时间。你可以使用两个以上的队列。
         * 
         */

        /// <summary>
        /// 双队列交换法，实现栈
        /// 16/16 cases passed (116 ms)
        /// Your runtime beats 90.32 % of csharp submissions
        /// Your memory usage beats 16.13 % of csharp submissions(24.2 MB)
        /// </summary>
        // @lc code=start
        public class MyStack
        {
            Queue<int> queue1; //存储栈内的元素
            Queue<int> queue2; //作为入栈操作的辅助队列。
            /** Initialize your data structure here. */
            public MyStack()
            {
                queue1 = new Queue<int>();
                queue2 = new Queue<int>();
            }

            /** Push element x onto stack. */
            public void Push(int x)
            {
                queue2.Enqueue(x);
                while (queue1.Count != 0)
                {
                    queue2.Enqueue(queue1.Dequeue());
                }

                //交换Queue
                Queue<int> temp = queue1;
                queue1 = queue2;
                queue2 = temp;
            }

            /** Removes the element on top of the stack and returns that element. */
            public int Pop()
            {
                return queue1.Dequeue();
            }

            /** Get the top element. */
            public int Top()
            {
                return queue1.Peek();
            }

            /** Returns whether the stack is empty. */
            public bool Empty()
            {
                return queue1.Count == 0;
            }
        }

        /**
         * Your MyStack object will be instantiated and called as such:
         * MyStack obj = new MyStack();
         * obj.Push(x);
         * int param_2 = obj.Pop();
         * int param_3 = obj.Top();
         * bool param_4 = obj.Empty();
         */
        // @lc code=end
    }
}
