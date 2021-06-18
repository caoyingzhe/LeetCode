using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpConsoleApp.Solutions._0300
{
    /*
     * @lc app=leetcode.cn id=341 lang=csharp
     *
     * [341] 扁平化嵌套列表迭代器
     *
     * https://leetcode-cn.com/problems/flatten-nested-list-iterator/description/
     *
     * Category	Difficulty	Likes	Dislikes
     * algorithms	Medium (72.80%)	331	-
     * Tags
     * stack | design
     * 
     * Companies
     * facebook | google | twitter
     * 
     * Total Accepted:    45K
     * Total Submissions: 61.8K
     * Testcase Example:  '[[1,1],2,[1,1]]'
     *
     * 给你一个嵌套的整型列表。请你设计一个迭代器，使其能够遍历这个整型列表中的所有整数。
     * 
     * 列表中的每一项或者为一个整数，或者是另一个列表。其中列表的元素也可能是整数或是其他列表。
     * 
     * 示例 1:
     * 输入: [[1,1],2,[1,1]]
     * 输出: [1,1,2,1,1]
     * 解释: 通过重复调用 next 直到 hasNext 返回 false，next 返回的元素的顺序应该是: [1,1,2,1,1]。
     * 
     * 示例 2:
     * 输入: [1,[4,[6]]]
     * 输出: [1,4,6]
     * 解释: 通过重复调用 next 直到 hasNext 返回 false，next 返回的元素的顺序应该是: [1,4,6]。
     * 
     */

    // @lc code=start
    /**
     * // This is the interface that allows for creating nested lists.
     * // You should not implement it, or speculate about its implementation
     * interface NestedInteger {
     *
     *     // @return true if this NestedInteger holds a single integer, rather than a nested list.
     *     bool IsInteger();
     *
     *     // @return the single integer that this NestedInteger holds, if it holds a single integer
     *     // Return null if this NestedInteger holds a nested list
     *     int GetInteger();
     *
     *     // @return the nested list that this NestedInteger holds, if it holds a nested list
     *     // Return null if this NestedInteger holds a single integer
     *     IList<NestedInteger> GetList();
     * }
     */
    class Solution341 : SolutionBase
    {
        /// <summary>
        /// 难易度:
        /// </summary>
        public override Difficulity GetDifficulity() { return Difficulity.Medium; }
        /// <summary>
        /// 关键字:
        /// </summary>
        public override string[] GetKeyWords() { return new string[] { "" }; }
        /// <summary>
        /// 标签： binary-search | divide-and-conquer | sort | binary-indexed-tree | segment-tree
        /// </summary>
        public override Tag[] GetTags() { return new Tag[] { Tag.Stack, Tag.Design}; }

        public override bool Test(System.Diagnostics.Stopwatch sw)
        {
            bool isSuccess = false;

            //TODO
            IList<NestedInteger> nestedList = null;
            NestedIterator i = new NestedIterator(nestedList);
            while (i.HasNext())
                Print(i.Next().ToString());

            return isSuccess;
        }
    }

    public interface NestedInteger
    {
     
         // @return true if this NestedInteger holds a single integer, rather than a nested list.
         bool IsInteger();
     
         // @return the single integer that this NestedInteger holds, if it holds a single integer
         // Return null if this NestedInteger holds a nested list
         int GetInteger();
     
         // @return the nested list that this NestedInteger holds, if it holds a nested list
         // Return null if this NestedInteger holds a single integer
         IList<NestedInteger> GetList();
     }
    /**
     * Your NestedIterator will be called like this:
     * NestedIterator i = new NestedIterator(nestedList);
     * while (i.HasNext()) v[f()] = i.Next();
     */

    //作者：LeetCode - Solution
    //链接：https://leetcode-cn.com/problems/flatten-nested-list-iterator/solution/bian-ping-hua-qian-tao-lie-biao-die-dai-ipjzq/

    ///43/43 cases passed (252 ms)
    ///Your runtime beats 99.56 % of csharp submissions
    ///Your memory usage beats 79.04 % of csharp submissions(32.2 MB)
    public class NestedIterator
    {
        private List<int> vals;
        private int index;

        public NestedIterator(IList<NestedInteger> nestedList)
        {
            vals = new List<int>();
            dfs(nestedList);
            index = -1;
        }

        public bool HasNext()
        {
            return index < vals.Count-1;
        }

        public int Next()
        {
            if (HasNext())
            {
                index++;
                return vals[index];
            }
            else
            { 
                return -1;
            }
        }

        private void dfs(IList<NestedInteger> nestedList)
        {
            foreach (NestedInteger nest in nestedList)
            {
                if (nest.IsInteger())
                {
                    vals.Add(nest.GetInteger());
                }
                else
                {
                    dfs(nest.GetList());
                }
            }
        }
    }
}
