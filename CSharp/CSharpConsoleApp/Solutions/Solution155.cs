using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpConsoleApp.Solutions
{
    /// <summary>
    /// 设计一个支持 push ，pop ，top 操作，并能在常数时间内检索到最小元素的栈。
    /// 
    /// push(x) —— 将元素 x 推入栈中。
    /// pop() —— 删除栈顶的元素。
    /// top() —— 获取栈顶元素。
    /// getMin() —— 检索栈中的最小元素。
    /// 
    /// 使用最小辅助栈实现要求
    /// https://leetcode-cn.com/problems/min-stack/solution/zui-xiao-zhan-by-leetcode-solution/
    /// </summary>
    class Solution155 : SolutionBase
    {
        /// <summary>
        /// 难度
        /// </summary>
        public override Difficulity GetDifficulity() { return Difficulity.Easy; }
        /// <summary>
        /// 关键字:
        /// </summary>
        public override string[] GetKeyWords() { return new string[] { "SortHashMap" }; }
        /// <summary>
        /// 标签： 
        /// </summary>
        public override Tag[] GetTags() { return new Tag[] { Tag.Stack, Tag.Design }; }

        public override bool Test(System.Diagnostics.Stopwatch sw)
        {
            List<int> result = new List<int>();
            int[] checkResult;
            bool isSuccess = true;

            //["MinStack","push","push","push","getMin","pop","top","getMin"]
            //[[],[-2],[0],[-3],[],[],[],[]]
            //输出：[null,null,null,null,-3,null,0,-2]
            MinStack c = new MinStack();
            c.Push(-2);
            c.Push(0);
            c.Push(-3);
            result.Add(c.GetMin());
            c.Pop();
            result.Add(c.Top());
            result.Add(c.GetMin());
            
            checkResult = new int[] { -3, 0, 2 };

            Print("isSuccess = {0} | result= {1} | resultChecked = {2}", isSuccess, string.Join(",", result), string.Join(",", checkResult));

            isSuccess &= IsArraySame(checkResult, result.ToArray());

            return isSuccess;
        }
    }

    public class MinStack
    {
        Stack<int> stack;
        Stack<int> minStack;

        /** initialize your data structure here. */
        public MinStack()
        {
            stack = new Stack<int>();
            minStack = new Stack<int>();
            minStack.Push(int.MaxValue);
        }

        public void Push(int val)
        {
            stack.Push(val);
            minStack.Push(Math.Min(minStack.FirstOrDefault<int>(), val));
        }

        public void Pop()
        {
            stack.Pop();
            minStack.Pop();
        }

        public int Top()
        {
            return stack.FirstOrDefault<int>();
        }

        public int GetMin()
        {
            return minStack.FirstOrDefault<int>();
        }
    }
}
