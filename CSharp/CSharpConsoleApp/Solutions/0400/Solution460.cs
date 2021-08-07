using System;
using System.Collections.Generic;
namespace CSharpConsoleApp.Solutions
{
    /*
     * @lc app=leetcode.cn id=460 lang=csharp
     *
     * [460] LFU 缓存
     *
     * https://leetcode-cn.com/problems/lfu-cache/description/
     *
     * Category	Difficulty	Likes	Dislikes
     * algorithms	Hard (44.30%)	397	-
     * Tags
     * design
     * 
     * Companies
     * amazon | google
     * 
     * Total Accepted:    27.5K
     * Total Submissions: 62.1K
     * Testcase Example:  '["LFUCache","put","put","get","put","get","get","put","get","get","get"]\n' +
      '[[2],[1,1],[2,2],[1],[3,3],[2],[3],[4,4],[1],[3],[4]]'
     *
     * 请你为 最不经常使用（LFU）缓存算法设计并实现数据结构。
     * 实现 LFUCache 类：
     * 
     * LFUCache(int capacity) - 用数据结构的容量 capacity 初始化对象
     * int get(int key) - 如果键存在于缓存中，则获取键的值，否则返回 -1。
     * void put(int key, int value) -
     * 如果键已存在，则变更其值；如果键不存在，请插入键值对。当缓存达到其容量时，则应该在插入新项之前，使最不经常使用的项无效。在此问题中，当存在平局（即两个或更多个键具有相同使用频率）时，应该去除
     * 最近最久未使用 的键。
     * 
     * 注意「项的使用次数」就是自插入该项以来对其调用 get 和 put 函数的次数之和。使用次数会在对应项被移除后置为 0 。
     *
     * 为了确定最不常使用的键，可以为缓存中的每个键维护一个 使用计数器 。使用计数最小的键是最久未使用的键。
     * 当一个键首次插入到缓存中时，它的使用计数器被设置为 1 (由于 put 操作)。对缓存中的键执行 get 或 put
     * 操作，使用计数器的值将会递增。
     * 
     * 
     * 示例：
     * 输入：
     * ["LFUCache", "put", "put", "get", "put", "get", "get", "put", "get", "get",
     * "get"]
     * [[2], [1, 1], [2, 2], [1], [3, 3], [2], [3], [4, 4], [1], [3], [4]]
     * 输出：
     * [null, null, null, 1, null, -1, 3, null, -1, 3, 4]
     * 
     * 解释：
     * // cnt(x) = 键 x 的使用计数
     * // cache=[] 将显示最后一次使用的顺序（最左边的元素是最近的）
     * LFUCache lFUCache = new LFUCache(2);
     * lFUCache.put(1, 1);   // cache=[1,_], cnt(1)=1
     * lFUCache.put(2, 2);   // cache=[2,1], cnt(2)=1, cnt(1)=1
     * lFUCache.get(1);      // 返回 1
     * ⁠                     // cache=[1,2], cnt(2)=1, cnt(1)=2
     * lFUCache.put(3, 3);   // 去除键 2 ，因为 cnt(2)=1 ，使用计数最小
     * ⁠                     // cache=[3,1], cnt(3)=1, cnt(1)=2
     * lFUCache.get(2);      // 返回 -1（未找到）
     * lFUCache.get(3);      // 返回 3
     * ⁠                     // cache=[3,1], cnt(3)=2, cnt(1)=2
     * lFUCache.put(4, 4);   // 去除键 1 ，1 和 3 的 cnt 相同，但 1 最久未使用
     * ⁠                     // cache=[4,3], cnt(4)=1, cnt(3)=2
     * lFUCache.get(1);      // 返回 -1（未找到）
     * lFUCache.get(3);      // 返回 3
     * ⁠                     // cache=[3,4], cnt(4)=1, cnt(3)=3
     * lFUCache.get(4);      // 返回 4
     * ⁠                     // cache=[3,4], cnt(4)=2, cnt(3)=3
     * 
     * 提示：
     * 0 <= capacity, key, value <= 10^4
     * 最多调用 10^5 次 get 和 put 方法
     * 
     * 
     * 进阶：你可以为这两种操作设计时间复杂度为 O(1) 的实现吗？
     * 
     */
    public class Solution460 : SolutionBase
    {
        /// <summary>
        /// 难易度:
        /// </summary>
        public override Difficulity GetDifficulity() { return Difficulity.Hard; }
        /// <summary>
        /// 关键字:
        /// </summary>
        public override string[] GetKeyWords() { return new string[] { "" }; }
        /// <summary>
        /// 标签： 
        /// </summary>
        public override Tag[] GetTags() { return new Tag[] { Tag.Design }; }

        public override bool Test(System.Diagnostics.Stopwatch sw)
        {
            bool isSuccess = false;

            LFUCache lFUCache = new LFUCache(2);
            lFUCache.Put(1, 1);                 // cache=[1,_], cnt(1)=1
            lFUCache.Put(2, 2);                 // cache=[2,1], cnt(2)=1, cnt(1)=1
            Print("{0}", lFUCache.Get(1));      // 返回 1
                                                // cache=[1,2], cnt(2)=1, cnt(1)=2
            lFUCache.Put(3, 3);                 // 去除键 2 ，因为 cnt(2)=1 ，使用计数最小
                                                // cache=[3,1], cnt(3)=1, cnt(1)=2
            Print("{0}", lFUCache.Get(2));      // 返回 -1（未找到）
            Print("{0}", lFUCache.Get(3));      // 返回 3
                                                // cache=[3,1], cnt(3)=2, cnt(1)=2
            lFUCache.Put(4, 4);                 // 去除键 1 ，1 和 3 的 cnt 相同，但 1 最久未使用
                                                // cache=[4,3], cnt(4)=1, cnt(3)=2
            Print("{0}", lFUCache.Get(1));      // 返回 -1（未找到）
            Print("{0}", lFUCache.Get(3));      // 返回 3
                                                // cache=[3,4], cnt(4)=1, cnt(3)=3
            Print("{0}", lFUCache.Get(4));      // 返回 4
                                                // cache=[3,4], cnt(4)=2, cnt(3)=3

            return isSuccess;
        }
    }

    #region  ---------- 单Map+双重环形链表 -----------
    /// <summary>
    /// 单Map+双重环形链表
    /// https://leetcode-cn.com/problems/lfu-cache/solution/lfugao-xiao-shi-xian-dan-mapshuang-zhong-nrwd/
    /// 24/24 cases passed (972 ms)
    /// Your runtime beats 5.26 % of csharp submissions
    /// Your memory usage beats 5.26 % of csharp submissions(133.8 MB)
    /// </summary>
    // @lc code=start
    public class LFUCache
    {
        private Dictionary<int, Node> map;
        private int capacity;//容量
        private int size;//当前元素个数
        private Bucket head;//桶链表的头

        public LFUCache(int capacity)
        {
            this.capacity = capacity;
            map = new Dictionary<int, Node>(capacity);
            head = new Bucket(0);
            head.next = head;
            head.prev = head;
        }

        public int Get(int key)
        {
            if (map.ContainsKey(key))
            {
                Node node = map[key];
                // node访问次数增加，需要放到下一个count值大1的桶里面
                upCount(node);
                return node.value;
            }
            return -1;
        }

        public void Put(int key, int value)
        {
            if (capacity == 0) return;

            if (map.ContainsKey(key))
            {
                Node node = map[key];
                node.value = value;
                upCount(node);
            }
            else
            {
                if (size >= capacity)
                {
                    //淘汰第一个桶中首个元素
                    Bucket b = head.next;
                    Node removed = b.list.removeFirst();
                    map.Remove(removed.key);
                    //若桶变空，删桶
                    if (b.list.isEmpty())
                    {
                        remove(b);
                    }
                }
                else
                {
                    size++;
                }
                Bucket next = head.next;
                if (next.count != 1)
                {
                    next = new Bucket(1);
                    insertAfter(head, next);
                }
                Node newNode = new Node(key, value, next);
                next.list.addLast(newNode);
                map.Add(key, newNode);
            }
        }

        #region  ---------- Addition functions -----------
        // 将node节点从旧桶，移到count值+1的下一个桶
        private void upCount(Node node)
        {
            Bucket bucket = node.bucket;
            Bucket next = bucket.next;
            if (next.count != bucket.count + 1)
            {
                next = new Bucket(bucket.count + 1);
                insertAfter(bucket, next);
            }
            bucket.list.remove(node);
            // 删除空桶
            if (bucket.list.isEmpty())
            {
                remove(bucket);
            }
            // node重新归属到新的桶里面
            node.bucket = next;
            next.list.addLast(node);
        }
        //删除链表上的桶
        public void remove(Bucket bucket)
        {
            bucket.prev.next = bucket.next;
            bucket.next.prev = bucket.prev;
        }
        //在桶链表的exist节点后添加新桶
        private void insertAfter(Bucket exist, Bucket newBucket)
        {
            Bucket next = exist.next;
            exist.next = newBucket;
            newBucket.prev = exist;
            newBucket.next = next;
            next.prev = newBucket;
        }
        #endregion
    }

    /**
     * Your LFUCache object will be instantiated and called as such:
     * LFUCache obj = new LFUCache(capacity);
     * int param_1 = obj.Get(key);
     * obj.Put(key,value);
     */


    #region  ---------- Addition Classes -----------
    // 环形双向链表实现
    public class LinkedNode
    {
        Node head;
        public LinkedNode()
        {
            head = new Node();
            head.next = head;
            head.prev = head;
        }
        // 在head左侧添加元素（新元素成为新的尾巴）
        public void addLast(Node node)
        {
            head.prev.next = node;
            node.prev = head.prev;
            node.next = head;
            head.prev = node;
        }
        // 删除head链上已存在的某个node
        public void remove(Node node)
        {
            node.prev.next = node.next;
            node.next.prev = node.prev;
        }
        // 删除head右侧的元素
        public Node removeFirst()
        {
            Node removed = head.next;
            remove(removed);
            return removed;
        }
        public bool isEmpty()
        {
            return head.next == head;
        }
    }
    public class Node
    {
        public int key;
        public int value;
        public Node prev;
        public Node next;
        public Bucket bucket;//所属的桶

        public Node() { }
        public Node(int key, int value, Bucket bucket)
        {
            this.key = key;
            this.value = value;
            this.bucket = bucket;
        }

        public int val
        {
            get { return this.value; }
            set { this.value = value; }
        }
    }

    public partial class Solution427
    {
        public class Node
        {
            public bool val;
            public bool isLeaf;
            public Node topLeft;
            public Node topRight;
            public Node bottomLeft;
            public Node bottomRight;

            public Node()
            {
                val = false;
                isLeaf = false;
                topLeft = null;
                topRight = null;
                bottomLeft = null;
                bottomRight = null;
            }

            public Node(bool _val, bool _isLeaf)
            {
                val = _val;
                isLeaf = _isLeaf;
                topLeft = null;
                topRight = null;
                bottomLeft = null;
                bottomRight = null;
            }

            public Node(bool _val, bool _isLeaf, Node _topLeft, Node _topRight, Node _bottomLeft, Node _bottomRight)
            {
                val = _val;
                isLeaf = _isLeaf;
                topLeft = _topLeft;
                topRight = _topRight;
                bottomLeft = _bottomLeft;
                bottomRight = _bottomRight;
            }

            //TODO NG
            public int depth
            {
                get { return Depth(this); }
            }
            public static int Depth(Node root)
            {
                if (root == null) return 0;
                return DFS(0, root) + 1;
            }
            public static int DFS(int depth, Node root)
            {
                if (root == null)
                {
                    return depth;
                }
                int tl = 0, tr = 0, bl = 0, br = 0;
                DFS(tl + depth, root.topLeft);
                DFS(tr + depth, root.topRight);
                DFS(bl + depth, root.bottomLeft);
                DFS(br + depth, root.bottomRight);

                Math.Max(Math.Max(tl, tr), Math.Max(bl, br));

                return depth;
            }
        }
    }

    public class Bucket
    {
        public int count;//访问次数相同的元素放到同一个桶里面
        public LinkedNode list = new LinkedNode();//桶内串一起的Node
        public Bucket prev;//前一个桶
        public Bucket next;//后一个桶
        public Bucket(int count)
        {
            this.count = count;
        }
    }
    #endregion
    // @lc code=end
    #endregion
}
