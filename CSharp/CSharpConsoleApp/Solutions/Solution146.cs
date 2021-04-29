using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

using DLinkedNode = CSharpConsoleApp.Solutions.SolutionBase.DLinkedNode;

namespace CSharpConsoleApp.Solutions
{
    /// <summary>
    /// LRU 缓存机制
    /// 
    /// 
    /// 输入
    /// ["LRUCache", "put", "put", "get", "put", "get", "put", "get", "get", "get"]
    /// [[2], [1, 1], [2, 2], [1], [3, 3], [2], [4, 4], [1], [3], [4]]
    /// 输出
    /// [null, null, null, 1, null, -1, null, -1, 3, 4]
    /// 
    /// 解释
    /// LRUCache lRUCache = new LRUCache(2);
    /// lRUCache.put(1, 1); // 缓存是 {1=1}
    /// lRUCache.put(2, 2); // 缓存是 {1=1, 2=2}
    /// lRUCache.get(1);    // 返回 1
    /// lRUCache.put(3, 3); // 该操作会使得关键字 2 作废，缓存是 {1=1, 3=3}
    /// lRUCache.get(2);    // 返回 -1 (未找到)
    /// lRUCache.put(4, 4); // 该操作会使得关键字 1 作废，缓存是 {4=4, 3=3}
    /// lRUCache.get(1);    // 返回 -1 (未找到)
    /// lRUCache.get(3);    // 返回 3
    /// lRUCache.get(4);    // 返回 4
    /// https://leetcode-cn.com/problems/lru-cache/solution/lruhuan-cun-ji-zhi-by-leetcode-solution/
    /// </summary>
    class Solution146 : SolutionBase
    {
        /// <summary>
        /// 难度
        /// </summary>
        public override Difficulity GetDifficulity() { return Difficulity.Medium; }
        /// <summary>
        /// 关键字:
        /// </summary>
        public override string[] GetKeyWords() { return new string[] { "哈希表+双向链表" }; }
        /// <summary>
        /// 标签： 
        /// </summary>
        public override Tag[] GetTags() { return new Tag[] { Tag.Design}; }
        public override bool Test(Stopwatch sw)
        {
            List<int> result = new List<int>();
            int[] checkResult;
            bool isSuccess = true;


            //["LRUCache","put","put","get","put","get","put","get","get","get"] +
            //'[[2],[1,1],[2,2],[1],[3,3],[2],[4,4],[1],[3],[4]]
            //[null,null,null,1,null,-1,null,-1,3,4]
            LRUCache c = new LRUCache(2);
            c.Put(1, 1);
            c.Put(1, 1);
            result.Add(c.Get(1));
            c.Put(3, 3);
            result.Add(c.Get(2));
            c.Put(4, 4);
            result.Add(c.Get(1));
            result.Add(c.Get(3));
            result.Add(c.Get(4));

            checkResult = new int[] { 1, -1, -1, 3, 4 };
            isSuccess &= IsArraySame(checkResult, result.ToArray());

            
            return isSuccess;
        }

    }

    public class LRUCache
    {
        #region LeetCode

        Dictionary<int, DLinkedNode> cacheDict = new Dictionary<int, DLinkedNode>();
        private int size;
        private int capacity;
        private DLinkedNode head, tail;

        public void Debug()
        {
            foreach(int key in cacheDict.Keys)
            {

            }
        }
        public LRUCache(int capacity)
        {
            this.capacity = capacity;
            this.size = 0;
            this.head = new DLinkedNode();
            this.tail = new DLinkedNode();
            head.next = tail;
            tail.prev = head;
        }

        public int Get(int key)
        {
            if (cacheDict.ContainsKey(key))
            {
                MoveToHead(cacheDict[key]);
                return cacheDict[key].value;
            }
            return -1;
        }

        public void Put(int key, int value)
        {
            if (cacheDict.ContainsKey(key))
            {
                DLinkedNode node = cacheDict[key];
                node.value = value;
                MoveToHead(node);
            }
            else
            {
                DLinkedNode node = new DLinkedNode(key, value);
                //真正添加节点
                cacheDict.Add(key, node);
                VirtualAddToHead(node);
                ++size;
                if (size > capacity)
                {
                    // 如果超出容量，虚拟删除， 其实是删除双向链表的尾部节点
                    DLinkedNode tail = VirtualRemoveTail();
                    //真正删除节点
                    cacheDict.Remove(tail.key);
                    --size;
                }
            }
        }

        private void MoveToHead(DLinkedNode node)
        {
            VirtualRemoveNode(node);
            VirtualAddToHead(node);
        }

        
        private void VirtualAddToHead(DLinkedNode node)
        {
            //修正自身节点的前后为头节点和次头节点。
            node.prev = head;
            node.next = head.next;
            //修改原有头部节点和次头部节点的连接关系，修改为自己的参照。
            head.next.prev = node;
            head.next = node;

            //if (!cacheDict.ContainsKey(node.key))
            //    cacheDict.Add(node.key, node);
        }

        //虚拟删除后返回
        private DLinkedNode VirtualRemoveTail()
        {
            DLinkedNode res = tail.prev;
            VirtualRemoveNode(res);
            return res;
        }
        //虚拟删除（不返回）
        private void VirtualRemoveNode(DLinkedNode node)
        {
            //修改前后波节点的连接关系，删除自己的参照。
            node.prev.next = node.next;
            node.next.prev = node.prev;
        }
        #endregion
    }
}
