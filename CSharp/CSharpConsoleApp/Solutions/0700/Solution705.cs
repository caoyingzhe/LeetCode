using System;
using System.Collections.Generic;
namespace CSharpConsoleApp.Solutions
{
    public class Solution705
    {
        /*
         * @lc app=leetcode.cn id=705 lang=csharp
         *
         * [705] 设计哈希集合
         *
         * https://leetcode-cn.com/problems/design-hashset/description/
         *
         * Category	Difficulty	Likes	Dislikes
         * algorithms	Easy (64.72%)	172	-
         * Tags
         * Unknown
         * 
         * Companies
         * Unknown
         * 
         * Testcase Example:  '["MyHashSet","add","add","contains","contains","add","contains","remove","contains"]\n' +
          '[[],[1],[2],[1],[3],[2],[2],[2],[2]]'
         *
         * 不使用任何内建的哈希表库设计一个哈希集合（HashSet）。
         * 
         * 实现 MyHashSet 类：
         * 
         * void add(key) 向哈希集合中插入值 key 。
         * bool contains(key) 返回哈希集合中是否存在这个值 key 。
         * void remove(key) 将给定值 key 从哈希集合中删除。如果哈希集合中没有这个值，什么也不做。
         * 
         * 
         * 
         * 示例：
         * 
         * 
         * 输入：
         * ["MyHashSet", "add", "add", "contains", "contains", "add", "contains",
         * "remove", "contains"]
         * [[], [1], [2], [1], [3], [2], [2], [2], [2]]
         * 输出：
         * [null, null, null, true, false, null, true, null, false]
         * 
         * 解释：
         * MyHashSet myHashSet = new MyHashSet();
         * myHashSet.add(1);      // set = [1]
         * myHashSet.add(2);      // set = [1, 2]
         * myHashSet.contains(1); // 返回 True
         * myHashSet.contains(3); // 返回 False ，（未找到）
         * myHashSet.add(2);      // set = [1, 2]
         * myHashSet.contains(2); // 返回 True
         * myHashSet.remove(2);   // set = [1]
         * myHashSet.contains(2); // 返回 False ，（已移除）
         * 
         * 
         * 
         * 提示：
         * 
         * 
         * 0 
         * 最多调用 10^4 次 add、remove 和 contains 。
         * 
         * 
         * 
         * 
         * 进阶：你可以不使用内建的哈希集合库解决此问题吗？
         * 
         */

        // @lc code=start

        /// <summary>
        /// 32/32 cases passed (228 ms)
        /// Your runtime beats 84.21 % of csharp submissions
        /// Your memory usage beats 24.21 % of csharp submissions(47.2 MB)
        /// </summary>
        public class MyHashSet
        {
            private const int bucket = 769;
            private LinkedList<int>[] data;

            /** Initialize your data structure here. */
            public MyHashSet()
            {
                data = new LinkedList<int>[bucket];
                for (int i = 0; i < bucket; i++)
                {
                    data[i] = new LinkedList<int>();
                }
            }

            public void Add(int key)
            {
                int h = Hash(key);
                foreach(int element in data[h])
                {
                    if (element == key)
                    {
                        return;
                    }
                }
                data[h].AddLast(key);
            }

            public void Remove(int key)
            {
                int h = Hash(key);
                foreach (int element in data[h])
                {
                    if (element == key)
                    {
                        data[h].Remove(element);
                        return;
                    }
                }
            }

            /** Returns true if this set contains the specified element */
            public bool Contains(int key)
            {
                int h = Hash(key);
                foreach (int element in data[h])
                {
                    if (element == key)
                    {
                        return true;
                    }
                }
                return false;
            }

            private static int Hash(int key)
            {
                return key % bucket;
            }
        }

        /**
         * Your MyHashSet object will be instantiated and called as such:
         * MyHashSet obj = new MyHashSet();
         * obj.Add(key);
         * obj.Remove(key);
         * bool param_3 = obj.Contains(key);
         */
        // @lc code=end


    }
}
