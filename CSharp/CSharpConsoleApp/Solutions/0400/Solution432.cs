using System;
using System.Collections.Generic;
namespace CSharpConsoleApp.Solutions
{
    public class Solution432 : SolutionBase
    {
        /// <summary>
        /// 难度
        /// </summary>
        public override Difficulity GetDifficulity() { return Difficulity.Hard; }
        /// <summary>
        /// 关键字:
        /// </summary>
        public override string[] GetKeyWords() { return new string[] { }; }
        /// <summary>
        /// 标签：hash-table | two-pointers | binary-search | sort
        /// </summary>
        public override Tag[] GetTags() { return new Tag[] { Tag.DepthFirstSearch, Tag.BreadthFirstSearch }; }

        public override bool Test(System.Diagnostics.Stopwatch sw)
        {
            bool isSuccess = true;

            AllOne t = new AllOne();

            string[] functions = new string[] { "inc", "dec", "getMaxKey", "getMinKey", "inc", "getMaxKey", "getMinKey" };
            string[] datas = new string[] { "hello", "hello", null, null, "leet", null, null };

            for (int i = 0; i < functions.Length; i++)
            {
                string rtn = t.Call(functions[i], datas[i]);
                Print("{0} | {1} : {2} ", functions[i], datas[i] == null ? "null" : datas[i], rtn);
            }

            return isSuccess;
        }

        /*
         * @lc app=leetcode.cn id=432 lang=csharp
         *
         * [432] 全 O(1) 的数据结构
         *
         * https://leetcode-cn.com/problems/all-oone-data-structure/description/
         *
         * Category	Difficulty	Likes	Dislikes
         * algorithms	Hard (37.79%)	91	-
         * Tags
         * design
         * 
         * Companies
         * uber
         * 
         * Total Accepted:    6.1K
         * Total Submissions: 16.1K
         * Testcase Example:  '["AllOne","inc","inc","getMaxKey","getMinKey","inc","getMaxKey","getMinKey"]\n' +
          '[[],["hello"],["hello"],[],[],["leet"],[],[]]'
         *
         * 请你实现一个数据结构支持以下操作：
         * 
         * Inc(key) - 插入一个新的值为 1 的 key。或者使一个存在的 key 增加一，保证 key 不为空字符串。
         * Dec(key) - 如果这个 key 的值是 1，那么把他从数据结构中移除掉。否则使一个存在的 key 值减一。如果这个 key
         * 不存在，这个函数不做任何事情。key 保证不为空字符串。
         * GetMaxKey() - 返回 key 中值最大的任意一个。如果没有元素存在，返回一个空字符串"" 。
         * GetMinKey() - 返回 key 中值最小的任意一个。如果没有元素存在，返回一个空字符串""。
         * 
         * 
         * 挑战：x
         * 你能够以 O(1) 的时间复杂度实现所有操作吗？
         */

        // @lc code=start

        /// <summary>
        /// 16/16 cases passed (360 ms)
        /// Your runtime beats 50 % of csharp submissions
        /// Your memory usage beats 50 % of csharp submissions(58.8 MB)
        /// </summary>
        public class AllOne
        {
            /// <summary>
            /// 带参数的通用函数调用
            /// 作者：LittleFogCat
            /// 链接：https://leetcode-cn.com/problems/all-oone-data-structure/solution/hashmaplian-biao-shi-xian-o1jie-fa-432-q-j6b9/
            /// </summary>
            /// <param name="func"></param>
            /// <param name="param"></param>
            /// <returns></returns>
            public string Call(string func, string param = "")
            {
                if (func == "inc") Inc(param);
                else if (func == "dec") Dec(param);
                else if (func == "getMaxKey") return GetMaxKey();
                else if (func == "getMinKey") return GetMinKey();
                return null;
            }

            //k-v查找节点
            private Dictionary<string, DLinkedNode> map = new Dictionary<string, DLinkedNode>();
            //key - 节点的值； value - 链表中第一个值为key的节点。
            private Dictionary<int, DLinkedNode> first = new Dictionary<int, DLinkedNode>();
            //key - 节点的值；value - 链表中最后一个值为key的节点。
            private Dictionary<int, DLinkedNode> last = new Dictionary<int, DLinkedNode>();

            //链表伪头节点
            private DLinkedNode head = new DLinkedNode();
            //链表伪尾节点
            private DLinkedNode tail = new DLinkedNode();

            //private DLinkedNode head, tail;
            //private LinkedList<int> list = new LinkedList<int>();

            //将节点 [insert] 插入到 n1 与 n2 之间
            private void insert(DLinkedNode n1, DLinkedNode n2, DLinkedNode insert)
            {
                n1.next = insert;
                n2.prev = insert;
                insert.prev = n1;
                insert.next = n2;
            }

            //删除链表节点[n]
            private void remove(DLinkedNode n)
            {
                DLinkedNode prev = n.prev;
                DLinkedNode next = n.next;
                prev.next = next;
                next.prev = prev;
                n.prev = null;
                n.next = null;
            }

            //将节点node移动到prev与next之间
            private void move(DLinkedNode node, DLinkedNode prev, DLinkedNode next)
            {
                remove(node);
                insert(prev, next, node);
            }

            //将[node]设置为新的val值起始点
            private void newFirst(int val, DLinkedNode node)
            {
                if (!first.ContainsKey(val))
                    first.Add(val, node);
                else
                    first[val] = node;
                if (!last.ContainsKey(val)) last.Add(val, node);
            }

            //将[node]设置为新的val值终止点
            private void newLast(int val, DLinkedNode node)
            {
                if (!last.ContainsKey(val))
                    last.Add(val, node);
                else
                    last[val] = node;
                if (!first.ContainsKey(val)) first.Add(val, node);
            }

            /** Initialize your data structure here. */
            public AllOne()
            {
                head.next = tail;
                tail.prev = head;
            }

            /** Inserts a new key <Key> with value 1. Or increments an existing key by 1. */
            public void Inc(string key)
            {
                if (!map.ContainsKey(key))
                { // 当前key不存在，插入到链表末尾
                    DLinkedNode node = new DLinkedNode(key, 1);
                    map.Add(key, node);
                    insert(tail.prev, tail, node); // 插入
                    if (!first.ContainsKey(1)) newFirst(1, node); // 更新first
                    newLast(1, node); // 更新last
                }
                else
                {
                    DLinkedNode node = map[key]; // 当前节点
                    int val = node.value; // 旧值
                    int newVal = val + 1; // 新值
                    DLinkedNode firstNode = first[val]; // 链表中第一个值为val的节点
                    DLinkedNode lastNode = last[val]; // 链表中最后一个值为val的节点

                    // 1. 找位置
                    node.value = newVal;
                    if (firstNode == lastNode)
                    { // 当前节点是唯一一个值为val的节点
                        first.Remove(val); // 没有值为val的节点了
                        last.Remove(val); // 没有值为val的节点了
                        newLast(newVal, node); // 更新last
                    }
                    else if (node == firstNode)
                    { // 该节点是链表中第一个值为val的节点
                      // 不动
                        newLast(newVal, node);
                        newFirst(val, node.next);
                    }
                    else
                    {
                        if (node == lastNode) newLast(val, node.prev); // 是最后一个值val的节点
                                                                       // 这个时候，节点应该移动到链表中第一个值为val的节点之前
                        move(node, firstNode.prev, firstNode);
                        newLast(newVal, node);
                    }
                }
            }

            /** Decrements an existing key by 1. If Key's value is 1, remove it from the data structure. */
            //值减一之后，节点在链表中的位置会往右移动
            public void Dec(string key)
            {
                // 与inc类似，不过多了一个值为1删除的判断
                DLinkedNode node = map[key];
                if (node == null) return;

                int val = node.value;
                int newVal = val - 1;
                DLinkedNode firstNode = first[val];
                DLinkedNode lastNode = last[val];

                if (val == 1)
                { // 值为1，删除这个节点
                    if (firstNode == lastNode)
                    { // 没有值为1的节点了
                        first.Remove(1);
                        last.Remove(1);
                    }
                    else if (node == firstNode)
                    { // 起始值右移
                        if (!first.ContainsKey(1))
                            first.Add(1, node.next);
                        else
                            first[1] = node.next;
                    }
                    else if (node == lastNode)
                    { // 终结值左移
                        if (!last.ContainsKey(1))
                            last.Add(1, node.prev);
                        else
                            last[1] = node.prev;
                    }
                    remove(node);
                    map.Remove(key);
                }
                else
                {
                    node.value = newVal;
                    if (firstNode == lastNode)
                    { // 唯一值为val的节点
                      // 位置不变，成为newVal的首位
                        first.Remove(val);
                        last.Remove(val);
                        newFirst(newVal, node);
                    }
                    else if (node == lastNode)
                    { // 是最后一项val值的节点
                      // 位置不变，成为newVal的首位，并且prev成为val的最后一位
                        newFirst(newVal, node);
                        newLast(val, node.prev);
                    }
                    else
                    {
                        if (node == firstNode) newFirst(val, node.next); // 是第一项val值的节点
                        move(node, lastNode, lastNode.next); // 移动到lastNode之后
                        newFirst(newVal, node);
                    }
                }
            }

            /** Returns one of the keys with maximal value. */
            public string GetMaxKey()
            {
                return head.next == tail ? "" : head.next.key;
            }

            /** Returns one of the keys with Minimal value. */
            public string GetMinKey()
            {
                return tail.prev == head ? "" : tail.prev.key;
            }
        }

        /**
         * Your AllOne object will be instantiated and called as such:
         * AllOne obj = new AllOne();
         * obj.Inc(key);
         * obj.Dec(key);
         * string param_3 = obj.GetMaxKey();
         * string param_4 = obj.GetMinKey();
         */
        // @lc code=end

    }
}
