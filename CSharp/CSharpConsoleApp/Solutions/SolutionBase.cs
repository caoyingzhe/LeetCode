﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpConsoleApp.Solutions
{
    public abstract class SolutionBase
    {
        //难易度
        public enum Difficulity
        {
            Easy,
            Medium,
            Hard
        }
        public enum Tag
        {
            Array,              //数组
            Backtracking,       //回溯
            BinaryIndexedTree,  //二进制索引树
            BinarySearch,       //二进制检索
            BinarySearchTree,   //二进制检索树
            BitManipulation,    //位操作
            Brainteaser,        //脑经急转弯
            BreadthFirstSearch, //广度优先搜索
            DepthFirstSearch,   //广度优先搜索
            Design,             //设计
            DivideAndConquer,   //分治法
            DynamicProgramming, //动态编程
            Geometry,           //图形
            Graph,              //图表
            Greedy,             //贪婪算法
            HashTable,          //散列表(哈希表)
            Heap,               //堆
            LineSweep,          //扫描线算法
            LinkedList,         //链表
            Math,               //数学
            Memoization,        //记忆
            Minimax,            //最大最小
            OrderedMap,         //顺序图
            Queue,              //队列
            Random,             //随机
            Recursion,          //递归
            RejectionSampling,  //拒绝采样            DI 序列的有效排列 / 分割数组
            ReservoirSampling,  //蓄水池抽样算法      链表随机节点/随机数索引
            SegmentTree,        //线段树/区间树
            SlidingWindow,      //滑动窗口
            Sort,               //排序
            Stack,              //栈
            String,             //字符串
            TopologicalSort,    //拓扑逻辑排序
            Tree,               //树
            Trie,               //前缀树 
            TwoPointers,        //双指针
            UnionFind,          //并查集
            Unknown,            //未定
            RedBlackTree        //红黑树
        }
        /// <summary>
        /// Get problem No on leetcode site.
        /// </summary>
        /// <returns></returns>
        public static int GetProblemNo<T>() where T : SolutionBase
        {
            return GetProblemNo(typeof(T));
        }
        public static int GetProblemNo(Type type)
        {
            string problemNoStr = type.Name.Replace("Solution", "");
            int problemNo;
            if (int.TryParse(problemNoStr, out problemNo))
            {
                return problemNo;
            }
            return -1;
        }

        /// <summary>
        /// 难易度:
        /// </summary>
        public virtual Difficulity GetDifficulity() { return Difficulity.Easy; }
        /// <summary>
        /// 关键字:
        /// </summary>
        public virtual string[] GetKeyWords() { return null; }
        /// <summary>
        /// 标签： 
        /// </summary>
        public virtual Tag[] GetTags(){ return null; }

        public abstract bool Test(System.Diagnostics.Stopwatch sw);

        #region ---------------- Data Struct ---------------------------
        public class DLinkedNode
        {
            public int key;
            public int value;
            public DLinkedNode prev;
            public DLinkedNode next;

            public DLinkedNode() { }
            public DLinkedNode(int _key, int _value) { key = _key; value = _value; }
        }

        public class ListNode
        {
            public int val;
            public ListNode next;
            public ListNode(int x) { val = x; }

            public ListNode(int val = 0, ListNode next = null)
            {
                this.val = val;
                this.next = next;
            }

            public ListNode(int[] valueList)
            {
                if (valueList.Length == 0)
                    return;

                this.val = valueList[0];

                ListNode curNode = this;
                for (int i=1; i<valueList.Length; i++)
                {
                    curNode.next = new ListNode(valueList[i]);
                    curNode = curNode.next;
                }
            }
            public override string ToString()
            {
                return "[" + ToString(",") + "]";
            }
            public string ToString(string seperator = "")
            {
                string result = "";

                ListNode node = this;
                while (true)
                {
                    result += node.val;
                    if (node.next == null)
                        break;
                    else
                    {
                        node = node.next;
                        if (!string.IsNullOrEmpty(seperator))
                            result += seperator;
                    }
                        
                }
                return result;
            }
            public static bool IsSame(ListNode a, ListNode b)
            {
                return (a.ToString().Equals(b.ToString()));
            }
        }

        public class ListNodeList
        {
            public List<ListNode> list { get; private set; }

            public ListNode first
            {
                get
                {
                    if (list != null && list.Count > 0)
                        return list[0];
                    return null;
                }
            }

            public ListNodeList(int[] array)
            {
                list = new List<ListNode>();

                ListNode preNode = null;
                for (int i = 0; i < array.Length; i++)
                {
                    ListNode node = new ListNode(array[i]);
                    if (preNode != null)
                        preNode.next = node;

                    list.Add(node);
                    preNode = node;
                }
            }
        }

        public class TreeNode
        {
            public int val;
            public TreeNode left;
            public TreeNode right;
            public TreeNode(int val = 0, TreeNode left = null, TreeNode right = null)
            {
            this.val = val;
            this.left = left;
            this.right = right;
            }

            /// <summary>
            /// 创建从顶至底，从左到右顺序的Tree。
            /// 该方法创建的不是有序的Tree。除非nums正好符合BTS的顺序。
            /// nums例子：  ["3","1","4",null,"2"],
            ///        3
            ///     1     4
            /// null  2
            /// </summary>
            public static TreeNode Create(string[] nums)
            {
                List<TreeNode> nodes = new List<TreeNode>();
                for (int i=0; i<nums.Length; i++)
                {
                    if(string.IsNullOrEmpty(nums[i]))
                    {
                        nodes.Add(null);
                        i++;
                    }
                    else
                    {
                        var newNode = new TreeNode(int.Parse(nums[i]));
                        nodes.Add(newNode);

                        if (i > 0)
                        {
                            //根据完全二叉搜索表的特性，i节点的父对象的索引为 [(i-1)/2]
                            int parentIndex = (i - 1) / 2;
                            if (i % 2 == 1 && i > 0)
                            {
                                nodes[parentIndex].left = newNode;
                            }
                            else if (i % 2 == 0 && i > 0)
                            {
                                nodes[parentIndex].right = newNode;
                            }
                        }
                    }
                }
                return nodes[0];
            }

            /// <summary>
            /// 获取一个从大到小排序的值列表（对于无序Tree）
            /// 源自 leetcode [230]
            /// </summary>
            /// <param name="root"></param>
            /// <param name="arr"></param>
            /// <returns></returns>
            public List<int> InOrder(TreeNode root, List<int> arr)
            {
                if (root == null) return arr;

                InOrder(root.left, arr);
                arr.Add(root.val);
                InOrder(root.right, arr);
                return arr;
            }

            /// <summary>
            /// 创建中序遍历的BST
            /// </summary>
            /// <param name="nums"></param>
            /// <returns></returns>
            public static TreeNode CreateBST(int[] nums) //From Solution 108
            {
                //return Helper1(nums, 0, nums.Length - 1);             // 该方法不合Leetcode测试结果
                //return Helper2(nums, 0, nums.Length - 1);             // 该方法OK
                return Helper3(nums, 0, nums.Length - 1, new Random()); // 该方法OK
            }

            private static TreeNode Helper1(int[] nums, int left, int right)
            {
                if (left > right)
                {
                    return null;
                }

                // 总是选择中间位置左边的数字作为根节点
                int mid = (left + right) / 2;

                TreeNode root = new TreeNode(nums[mid]);
                root.left = Helper1(nums, left, mid - 1);
                root.right = Helper1(nums, mid + 1, right);
                return root;
            }

            /// <summary>
            /// 方法二：中序遍历，总是选择中间位置右边的数字作为根节点
            /// </summary>
            /// <param name="nums"></param>
            /// <param name="left"></param>
            /// <param name="right"></param>
            /// <returns></returns>
            private static TreeNode Helper2(int[] nums, int left, int right)
            {
                if (left > right)
                {
                    return null;
                }

                // 总是选择中间位置右边的数字作为根节点
                int mid = (left + right + 1) / 2;

                TreeNode root = new TreeNode(nums[mid]);
                root.left = Helper2(nums, left, mid - 1);
                root.right = Helper2(nums, mid + 1, right);
                return root;
            }


            /// <summary>
            /// 方法三：中序遍历，选择任意一个中间位置数字作为根节点
            /// </summary>
            private static TreeNode Helper3(int[] nums, int left, int right, Random rand)
            {
                if (left > right)
                {
                    return null;
                }

                // 选择任意一个中间位置数字作为根节点
                int mid = (left + right + rand.Next(2)) / 2;

                TreeNode root = new TreeNode(nums[mid]);
                root.left = Helper3(nums, left, mid - 1, rand);
                root.right = Helper3(nums, mid + 1, right, rand);
                return root;
            }

            public string GetNodeString()
            {
                var nodes = GetNodeList();

                string str = "";
                for(int i=0; i<nodes.Count; i++)
                {
                    str += nodes[i] == null ? "null" : ""+ nodes[i].val;
                    if (i < nodes.Count - 1)
                        str += ",";
                }
                return str;
            }
            public List<TreeNode> GetNodeList()
            {
                List<TreeNode> list = new List<TreeNode>();
                GetNodeList(this, list);
                return list;
            }

            /// <summary>
            /// 取得所有的Node列表 (返回结果已经是按照中序排列）
            /// </summary>
            /// <param name="node"></param>
            /// <param name="nodeList"></param>
            /// <param name="nodeList"></param>
            public static void GetNodeList(TreeNode node, List<TreeNode> nodeList, bool noAddNullNode = false)
            {
                if (node == null)
                {
                    if (!noAddNullNode)
                        nodeList.Add(node);
                    return;
                }
                GetNodeList(node.left, nodeList);
                nodeList.Add(node);
                GetNodeList(node.right, nodeList);
            }
        }

        /// <summary>
        /// 拷贝于 https://www.cnblogs.com/skyivben/archive/2009/04/18/1438731.html
        /// 
        /// 这个 PriorityQueue<T> 泛型类提供四个公共构造函数，
        /// 第一个是无参的构造函数，
        /// 其余的构造函数允许指定优先队列中包括的初始元素数(capacity)、如何对键进行比较(comparer)。
        /// 
        /// 这个程序使用堆(heap)来实现优先队列。所以，所需的空间是最小的。
        /// Count 属性和 Top 方法的时间复杂度是 O(1)，
        /// Push 和 Pop 方法的时间复杂度都是 O(logN)。
        /// </summary>
        /// <typeparam name="T"></typeparam>
        public class PriorityQueue<T>
        {
            IComparer<T> comparer;
            T[] heap;

            public int Count { get; private set; }

            public PriorityQueue() : this(null) { }
            public PriorityQueue(int capacity) : this(capacity, null) { }
            public PriorityQueue(IComparer<T> comparer) : this(16, comparer) { }

            public PriorityQueue(int capacity, IComparer<T> comparer)
            {
                this.comparer = (comparer == null) ? Comparer<T>.Default : comparer;
                this.heap = new T[capacity];
            }

            public void Push(T v)
            {
                if (Count >= heap.Length) Array.Resize(ref heap, Count * 2);
                heap[Count] = v;
                SiftUp(Count++);
            }

            public T Pop()
            {
                var v = Top();
                heap[0] = heap[--Count];
                if (Count > 0) SiftDown(0);
                return v;
            }

            public T Top()
            {
                if (Count > 0) return heap[0];
                throw new InvalidOperationException("优先队列为空");
            }

            void SiftUp(int n)
            {
                var v = heap[n];
                for (var n2 = n / 2; n > 0 && comparer.Compare(v, heap[n2]) > 0; n = n2, n2 /= 2) heap[n] = heap[n2];
                heap[n] = v;
            }

            void SiftDown(int n)
            {
                var v = heap[n];
                for (var n2 = n * 2; n2 < Count; n = n2, n2 *= 2)
                {
                    if (n2 + 1 < Count && comparer.Compare(heap[n2 + 1], heap[n2]) > 0) n2++;
                    if (comparer.Compare(v, heap[n2]) >= 0) break;
                    heap[n] = heap[n2];
                }
                heap[n] = v;
            }
        }
    
        public class TrieNode<T> 
        {
            public Dictionary<T, TrieNode<T>> children = new Dictionary<T, TrieNode<T>>();
            public String word = null;
            public TrieNode() { }
        }

        #endregion

        #region ------------------------- Util Functions -------------------------
        public string GetArray2DStr(IList<List<string>> llist, string seperator = ",", string lineSeperator = "\n")
        {
            string result = "";
            foreach (IList<string> iList in llist)
            {
                result += "[" + string.Join(seperator, iList.ToArray()) + "]" + lineSeperator;
            }
            return result;
        }
        public string GetArray2DStr(IList<IList<int>> llist, string seperator = ",", string lineSeperator = "\n")
        {
            string result = "";
            foreach (IList<int> iList in llist)
            {
                result += "[" + string.Join(seperator, iList.ToArray()) + "]" + lineSeperator;
            }
            return result;
        }

        public string GetArrayStr<T>(IList<T> a, string seperator = "")
        {
            return string.Join(",", a);
        }
        public string GetArrayStr(IList<string> a, string seperator = "")
        {
            return string.Join(",", a);
        }
        public string GetArrayStr(char[][] a, string seperator = "")
        {
            string result = "";
            for (int i = 0; i < a.Length; i++)
            {
                result += string.Join(seperator, a[i]) + "\n";
            }
            return result;
        }

        public bool IsListSame(IList<string> a, IList<string> b, bool useSort = true)
        {
            List<string> aList = new List<string>(a);
            List<string> bList = new List<string>(b);

            if(useSort)
            {
                aList.Sort();
                bList.Sort();
            }
            return string.Join(",", aList).Equals(string.Join(",", bList));
        }
        public bool IsArraySame(int[] a, int[] b, bool ignoreTail = true)
        {
            int alen = a == null ? 0 : a.Length;
            int blen = b == null ? 0 : b.Length;

            if(!ignoreTail)
            {
                if (alen != blen)
                    return false;
            }

            int compareLen = Math.Min(alen, blen);
            {
                for(int i=0; i<compareLen; i++)
                {
                    if (a[i] != b[i])
                        return false;
                }
            }

            return true;
        }
        public bool IsArraySame(IList<IList<int>> a, IList<IList<int>> b)
        {
            int alen = a == null ? 0 : a.Count * (a[0] == null ? 0 : a[0].Count);
            int blen = b == null ? 0 : b.Count * (b[0] == null ? 0 : b[0].Count);
            if (alen == blen)
            {
                for (int row = 0; row < a.Count; row++)
                {
                    int aCols = a == null ? 0 : a[row].Count;
                    int bCols = b == null ? 0 : b[row].Count;
                    if (aCols == bCols)
                    {
                        for (int i = 0; i < a[row].Count; i++)
                        {
                            if (a[row][i] != b[row][i])
                                return false;
                        }
                    }
                }
            }
            else
            {
                return false;
            }
            return true;
        }

        public bool IsArraySame(char[][] a, char[][] b)
        {
            int alen = a == null ? 0 : a.Length;
            int blen = b == null ? 0 : b.Length;
            if (alen == blen)
            {
                for (int row = 0; row < a.Length; row++)
                {
                    int aCols = a == null ? 0 : a[row].Length;
                    int bCols = b == null ? 0 : b[row].Length;
                    if (aCols == bCols)
                    {
                        for (int i = 0; i < a.Length; i++)
                        {
                            if (a[row][i] != b[row][i])
                                return false;
                        }
                    }
                }
            }
            else
            {
                return false;
            }
            return true;
        }

        public void Print(string log, params object[] args)
        {
            string formatLog = string.Format(log, args);
            Print(formatLog);
        }
        public void Print(string log)
        {
            System.Diagnostics.Debug.Print(log);
        }
        #endregion
    }
}
