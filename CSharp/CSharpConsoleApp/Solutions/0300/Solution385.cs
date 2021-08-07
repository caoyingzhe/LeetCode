using System;
using System.Collections.Generic;
namespace CSharpConsoleApp.Solutions
{
    /*
     * @lc app=leetcode.cn id=385 lang=csharp
     *
     * [385] 迷你语法分析器
     *
     * https://leetcode-cn.com/problems/mini-parser/description/
     *
     * algorithms
     * Medium (41.29%)
     * Likes:    64
     * Dislikes: 0
     * Total Accepted:    6.7K
     * Total Submissions: 16.1K
     * Testcase Example:  '"324"'
     *
     * 给定一个用字符串表示的整数的嵌套列表，实现一个解析它的语法分析器。
     * 
     * 列表中的每个元素只可能是整数或整数嵌套列表
     * 
     * 提示：你可以假定这些字符串都是格式良好的：
     * 
     * 
     * 字符串非空
     * 字符串不包含空格
     * 字符串只包含数字0-9、[、-、,、]
     * 
     * 
     * 
     * 
     * 示例 1：
     * 
     * 给定 s = "324",
     * 
     * 你应该返回一个 NestedInteger 对象，其中只包含整数值 324。
     * 
     * 
     * 示例 2：
     * 
     * 给定 s = "[123,[456,[789]]]",
     * 
     * 返回一个 NestedInteger 对象包含一个有两个元素的嵌套列表：
     * 
     * 1. 一个 integer 包含值 123
     * 2. 一个包含两个元素的嵌套列表：
     * ⁠   i.  一个 integer 包含值 456
     * ⁠   ii. 一个包含一个元素的嵌套列表
     * ⁠        a. 一个 integer 包含值 789
     * 
     * 
     */

    // @lc code=start
    /**
     * // This is the interface that allows for creating nested lists.
     * // You should not implement it, or speculate about its implementation
     * interface NestedInteger {
     *
     *     // Constructor initializes an empty nested list.
     *     public NestedInteger();
     *
     *     // Constructor initializes a single integer.
     *     public NestedInteger(int value);
     *
     *     // @return true if this NestedInteger holds a single integer, rather than a nested list.
     *     bool IsInteger();
     *
     *     // @return the single integer that this NestedInteger holds, if it holds a single integer
     *     // Return null if this NestedInteger holds a nested list
     *     int GetInteger();
     *
     *     // Set this NestedInteger to hold a single integer.
     *     public void SetInteger(int value);
     *
     *     // Set this NestedInteger to hold a nested list and adds a nested integer to it.
     *     public void Add(NestedInteger ni);
     *
     *     // @return the nested list that this NestedInteger holds, if it holds a nested list
     *     // Return null if this NestedInteger holds a single integer
     *     IList<NestedInteger> GetList();
     * }
     */
    public class Solution385 : SolutionBase
    {
        /// <summary>
        /// 难度
        /// </summary>
        public override Difficulity GetDifficulity() { return Difficulity.Medium; }
        /// <summary>
        /// 关键字:
        /// </summary>
        public override string[] GetKeyWords() { return new string[] { "", }; }
        /// <summary>
        /// 标签：
        /// </summary>
        public override Tag[] GetTags() { return new Tag[] { Tag.String, Tag.Stack }; }

        public override bool Test(System.Diagnostics.Stopwatch sw)
        {
            bool isSuccess = true;

            string s;

            s = "[123,[456,[789]]]";
            NestedInteger result1 = Deserialize(s);
            NestedInteger result2 = result1.GetList()[0];
            NestedInteger result3 = result1.GetList()[1];
            //NestedInteger result4 = result3.GetList()[0];
            Print("result1 = {0}", result1.GetInteger());
            Print("result2 = {0}", result2.GetInteger());
            Print("result3 = {0}", result3.GetInteger());
            //Print("result4 = {0}", result4.GetInteger());

            isSuccess &= result1.GetInteger() == 123;
            return isSuccess;
        }

        /// <summary>
        /// DFS法
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public NestedInteger Deserialize_DFS(string s)
        {

            if (s.Length == 0) return new NestedInteger();

            Print("Deserialize : {0}", s);
            if (s[0] != '[') return new NestedInteger(int.Parse(s.TrimEnd(new char[] { ',', ']' })));
            if (s.Length == 2) return new NestedInteger();

            NestedInteger ni = new NestedInteger();
            for (int start = 1, i = 1, count = 0; i < s.Length; i++)
            { // 分段DFS
                if (count == 0 && (s[i] == ',' || s.Length - 1 == i))
                {
                    // s[length - 1]肯定是]。 注意这个if要排第一，
                    //如果s.chartAt(i) == ']'排在这前面，会少执行一次add操作
                    ni.Add(Deserialize_DFS(s.Substring(start, i - start + 1))); // 加入兄弟节点
                    start = i + 1;
                }
                else if (s[i] == '[')
                {
                    count++;
                }
                else if (s[i] == ']')
                {
                    count--;
                }
            }
            return ni;
        }

        /// <summary>
        /// https://leetcode-cn.com/problems/mini-parser/solution/385-mi-ni-yu-fa-fen-xi-qi-dfs-by-nortondark/
        /// 58/58 cases passed (244 ms)
        /// Your runtime beats 100 % of csharp submissions
        /// Your memory usage beats 16.67 % of csharp submissions(34.5 MB)
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public NestedInteger Deserialize(String s)
        {
            if (s == null || s.Length == 0) return new NestedInteger();
            if (s[0] != '[') return new NestedInteger(int.Parse(s.TrimEnd(new char[] { ',', ']' })));

            LinkedList<NestedInteger> stack = new LinkedList<NestedInteger>();
            NestedInteger ans = new NestedInteger();
            stack.AddLast(ans); // 执行到这，肯定是[开头的，为了减少对stack为空的判断，先加入1个空对象。

            for (int i = 0; i < s.Length; i++)
            {
                if (s[i] == ',') continue;

                if (s[i] == '[')
                {
                    NestedInteger node = new NestedInteger();
                    stack.Last.Value.Add(node);
                    stack.AddLast(node);
                }
                else if (s[i] == ']')
                {
                    ans = stack.Last.Value; stack.RemoveLast();
                }
                else
                {  // number, 这里把负号合并了，因为Integer可以整合负号。即start位置上的字符可能是“-”
                    int start = i;
                    while (i + 1 < s.Length && char.IsDigit(s[i + 1]))
                    { // 双指针
                        i++;
                    }
                    NestedInteger ni = new NestedInteger(int.Parse(s.Substring(start, i + 2 - start).TrimEnd(new char[] { ',', ']' })));
                    stack.Last.Value.Add(ni);
                }
            }
            return ans;
        }

        public int SimpleParse(string s)
        {
            for (int i = 0; i < s.Length; i++)
            {
                if (char.IsNumber(s[i]))
                {
                    if (i == 0)
                        return int.MaxValue;
                    return int.Parse(s.Substring(0, i));
                }
            }
            return int.Parse(s);
        }

    }

    public class NestedInteger : INestedInteger
    {
        private int val = int.MaxValue;
        private bool isInt = false;
        private List<NestedInteger> list;
        // Constructor initializes an empty nested list.
        public NestedInteger() { }

        // Constructor initializes a single integer.
        public NestedInteger(int value) { val = value; isInt = true; list = null; }

        // @return true if this NestedInteger holds a single integer, rather than a nested list.
        public bool IsInteger() { return isInt; }

        // @return the single integer that this NestedInteger holds, if it holds a single integer
        // Return null if this NestedInteger holds a nested list
        public int GetInteger() { return val; }

        // Set this NestedInteger to hold a single integer.
        public void SetInteger(int value) { val = value; isInt = true; }

        // Set this NestedInteger to hold a nested list and adds a nested integer to it.
        public void Add(NestedInteger ni)
        {
            if (ni == null) return;
            if (list == null) list = new List<NestedInteger>();
            list.Add(ni);
        }

        // @return the nested list that this NestedInteger holds, if it holds a nested list
        // Return null if this NestedInteger holds a single integer
        public IList<NestedInteger> GetList() { return list; }
    }

    public interface INestedInteger
    {
        // @return true if this NestedInteger holds a single integer, rather than a nested list.
        bool IsInteger();

        // @return the single integer that this NestedInteger holds, if it holds a single integer
        // Return null if this NestedInteger holds a nested list
        int GetInteger();

        // Set this NestedInteger to hold a single integer.
        void SetInteger(int value);

        // Set this NestedInteger to hold a nested list and adds a nested integer to it.
        void Add(NestedInteger ni);

        // @return the nested list that this NestedInteger holds, if it holds a nested list
        // Return null if this NestedInteger holds a single integer
        IList<NestedInteger> GetList();
    }
    // @lc code=end


}
