using System;
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

        //超级棒的题解分类总结 ： https://zhuanlan.zhihu.com/p/349940945?utm_medium=social&utm_oi=51534712799232
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
            DepthFirstSearch,   //深度优先搜索
            Design,             //设计
            DivideAndConquer,   //分治法
            DynamicProgramming, //动态编程
            Geometry,           //图形
            Graph,              //图表
            Greedy,             //贪婪算法
            HashTable,          //散列表(哈希表)
            Heap,               //堆
            LineSweep,          //扫描线算法  [253, 218, 391, 759]
            LinkedList,         //链表   头部尾部插入删除操作都是O(1)，查找任意元素位置O(N) [206,876]
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
            Sort,               //排序  快速排序（Quick Sort）NLogN | 1 ;  归并排序（Merge Sort） NLogN | N [56,148] [4,75,179,215]
                                //     [4,215] 是与快速排序非常相似的快速选择（Quick Select）算法，面试中很常考
            Stack,              //栈
            String,             //字符串
            TopologicalSort,    //拓扑逻辑排序
            Tree,               //树
            Trie,               //前缀树，字典树  【208,211,1268,79]
            TwoPointers,        //双指针
            UnionFind,          //并查集
            Unknown,            //未定
            RedBlackTree,       //红黑树
            PrefixSum,          //前缀和
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
        public virtual Tag[] GetTags() { return null; }

        public abstract bool Test(System.Diagnostics.Stopwatch sw);

        // Template
        //public override bool Test(System.Diagnostics.Stopwatch sw)
        //{
        //    bool isSuccess = true;
        //    int[] nums;
        //    IList<int> result;
        //    int[] checkResult;
        //
        //    nums = new int[] { };
        //    checkResult = new int[] { };
        //    result = CountSmaller(nums);
        //    isSuccess &= IsArraySame(result.ToArray(), checkResult);
        //    Print("isSuccess = {0} | result = {1} | anticipated = {2}", isSuccess, GetArrayStr<int>(result), GetArrayStr<int>(checkResult));
        //    Print("isSuccess = {0} | result = {1} | anticipated = {2}", isSuccess, (result), (checkResult));
        //
        //    return isSuccess;
        //}
        #region ---------------- Data Struct ---------------------------
        //Solution 146
        public class DLinkedNode 
        {
            public string key;
            public int value;
            public DLinkedNode prev;
            public DLinkedNode next;

            public DLinkedNode() { }
            public DLinkedNode(int _key, int _value) { key = _key.ToString(); value = _value; }
            public DLinkedNode(string _key, int _value) { key = _key; value = _value; }
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
                for (int i = 1; i < valueList.Length; i++)
                {
                    curNode.next = new ListNode(valueList[i]);
                    curNode = curNode.next;
                }
            }
            public override string ToString()
            {
                return "[" + ToString(",") + "]";
            }

            public List<int> GetValueList()
            {
                List<int> list = new List<int>();

                ListNode node = this;
                while (node != null)
                {
                    list.Add(node.val);
                    if (node == node.next)
                    {
                        //Warning
                        break;
                    }
                    node = node.next;
                }
                return list;
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

            public static void GetNodeList(ListNode node, List<ListNode> list)
            {
                if (list == null || node == null)
                    return;

                while (node != null)
                {
                    list.Add(node);
                    node = node.next;
                }
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

            public string LeftValStr()
            {
                return left == null ? "null" : left.val.ToString();
            }
            public string RightValStr()
            {
                return right == null ? "null" : right.val.ToString();
            }
            /// <summary>
            /// 创建从顶至底，从左到右顺序的完全二叉数Tree。
            /// 该方法创建的不是有序的Tree。除非nums正好符合BTS的顺序。
            /// nums例子：  ["3","1","4",null,"2"],
            ///        3
            ///     1     4
            /// null  2
            /// </summary>
            public static TreeNode Create(string[] nums)
            {
                List<TreeNode> nodes = new List<TreeNode>();
                for (int i = 0; i < nums.Length; i++)
                {
                    if (string.IsNullOrEmpty(nums[i]) || nums[i].ToLower() == "null")
                    {
                        nodes.Add(null);
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
                                if (nodes[parentIndex] != null)
                                    nodes[parentIndex].right = newNode;
                            }
                        }
                    }
                }
                return nodes[0];
            }

            public static TreeNode Create(int[] nums, int nullValue)
            {
                List<TreeNode> nodes = new List<TreeNode>();
                for (int i = 0; i < nums.Length; i++)
                {
                    if (nums[i] == nullValue)
                    {
                        nodes.Add(null);
                    }
                    else
                    {
                        var newNode = new TreeNode(nums[i]);
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
                                if (nodes[parentIndex] != null)
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

            /// <summary>
            /// 节点排序（from Solution75)
            /// </summary>
            /// <param name="nums"></param>
            /// <param name="left"></param>
            /// <param name="right"></param>
            /// <returns></returns>
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
            /// 节点排序（from Solution75)
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
            /// 节点排序（from Solution75)
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

            public string GetNodeString(bool noAddNullNode = false)
            {
                var nodes = GetNodeList(noAddNullNode);

                string str = "";
                for (int i = 0; i < nodes.Count; i++)
                {
                    str += nodes[i] == null ? "null" : "" + nodes[i].val;
                    if (i < nodes.Count - 1)
                        str += ",";
                }
                return str;
            }
            public List<TreeNode> GetNodeList(bool noAddNullNode = false)
            {
                List<TreeNode> list = new List<TreeNode>();
                GetNodeList(this, list, noAddNullNode);
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
                GetNodeList(node.left, nodeList, noAddNullNode);
                nodeList.Add(node);
                GetNodeList(node.right, nodeList, noAddNullNode);
            }

            /// <summary>
            /// 获取值列表（中序遍历）
            /// </summary>
            /// <param name="node"></param>
            /// <param name="nodeList"></param>
            /// <param name="noAddNullNode"></param>
            /// <param name="nullVale"></param>
            public static void GetValueList(TreeNode node, List<int> nodeList, bool noAddNullNode = false, int nullVale = int.MinValue)
            {
                if (node == null)
                {
                    if (!noAddNullNode)
                        nodeList.Add(nullVale);
                    return;
                }
                GetValueList(node.left, nodeList, noAddNullNode, nullVale);
                nodeList.Add(node.val);
                GetValueList(node.right, nodeList, noAddNullNode, nullVale);
            }

            /// <summary>
            /// 获取值列表（后序遍历） Solution145
            /// </summary>
            /// <param name="node"></param>
            /// <param name="nodeList"></param>
            /// <param name="noAddNullNode"></param>
            /// <param name="nullVale"></param>
            public void GetValueList_Postorder(TreeNode node, List<int> nodeList)
            {
                if (node == null)
                {
                    return;
                }
                GetValueList_Postorder(node.left, nodeList);
                GetValueList_Postorder(node.right, nodeList);
                nodeList.Add(node.val);
            }

            /// <summary>
            /// 获取值列表（前序遍历） Solution144
            /// </summary>
            /// <param name="node"></param>
            /// <param name="nodeList"></param>
            /// <param name="noAddNullNode"></param>
            /// <param name="nullVale"></param>
            public void GetValueList_Preorder(TreeNode node, List<int> nodeList)
            {
                if (node == null)
                {
                    return;
                }
                nodeList.Add(node.val);
                GetValueList_Preorder(node.left, nodeList);
                GetValueList_Preorder(node.right, nodeList);
            }

            /// <summary>
            /// 获取当前节点路径(from Solution235)
            /// 特别注意：
            ///     该方法只可用于2查搜索树（左边小，右边大），
            ///     不可用于非规则树。
            /// </summary>
            /// <param name="root"></param>
            /// <param name="target"></param>
            /// <returns></returns>
            public List<TreeNode> GetPath(TreeNode root, TreeNode target)
            {
                List<TreeNode> path = new List<TreeNode>();
                TreeNode node = root;
                while (node != target)
                {
                    path.Add(node);
                    if (target.val < node.val)
                    {
                        node = node.left;
                    }
                    else
                    {
                        node = node.right;
                    }
                }
                path.Add(node);
                return path;
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
        ///
        /// 特别注意：
        /// C#代码实现的 【PriorityQueue】不完全等同于 Java中的【PriorityQueue】。
        /// Java中如果不指定比较器，对于数组，默认是从第一个元素到最后一个元素升序。
        /// 本【PriorityQueue】如果不指定，则不做任何排序。
        /// 
        /// 该问题发现于第401题【接雨水中】
        /// Java代码为：
        ///     PriorityQueue<int[]> pq = new PriorityQueue<>((
        ///         o1, o2)->o1[2] - o2[2]    //优先对元素3升序，然后是默认对元素1，2升序。
        ///     );
        /// C#直接拷贝代码为，但得到确实错误的结果
        ///     PriorityQueue<int[]> pq = new PriorityQueue<int[]>(new ComparerSolution407());
        /// public class ComparerSolution407 : IComparer<int[]>
        /// {
        ///     public int Compare(int[] pair1, int[] pair2)
        ///     {
        ///         return pair2[2] - pair1[2];  //只对元素3升序
        ///     }
        /// }
        /// 
        /// 正确的比较器如下：
        /// public class ComparerSolution407 : IComparer<int[]>
        /// {
        ///     public int Compare(int[] pair1, int[] pair2)
        ///     {
        ///         if (pair2[2] != pair1[2])
        ///             return pair2[2] - pair1[2];  //元素3升序
        ///         else if (pair2[0] != pair1[0])
        ///         {
        ///             return pair2[0] - pair1[0];  //元素1升序
        ///         }
        ///         else// (pair2[0] != pair1[0])
        ///         {
        ///             return pair2[1] - pair1[1];  //元素2升序
        ///         }
        ///     }
        /// }
        /// </summary>
        /// <typeparam name="T"></typeparam>
        public class PriorityQueue<T>
        {
            IComparer<T> comparer;
            T[] heap;

            public int Count { get; private set; }
            public bool IsEmpty() { return Count == 0; }
            public PriorityQueue() : this(null) { }
            public PriorityQueue(int capacity) : this(capacity, null) { }
            public PriorityQueue(IComparer<T> comparer) : this(16, comparer) { }

            public PriorityQueue(int capacity, IComparer<T> comparer)
            {
                this.comparer = (comparer == null) ? Comparer<T>.Default : comparer;
                this.heap = new T[capacity];
            }
            public void Offer(T v) { Push(v); } //Java Like Function
            public void Push(T v)
            {
                if (Count >= heap.Length) Array.Resize(ref heap, Count * 2);
                heap[Count] = v;
                SiftUp(Count++);
            }

            public T Poll() { return Pop(); } //Java Like Function
            public T Pop()
            {
                var v = Top();
                heap[0] = heap[--Count];
                if (Count > 0) SiftDown(0);
                return v;
            }

            
            public T Peek()  { return Top(); } //Java Like Function
            public T Top()
            {
                if (Count > 0) return heap[0];
                throw new InvalidOperationException("优先队列为空");
            }
            //public T Tail()
            //{
            //    if (Count > 0) return heap[Count - 1];
            //    throw new InvalidOperationException("优先队列为空");
            //}

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

            public T[] ToArray()
            {
                return heap;
            }
        }

        //PriorityQueue 字典排序测试: 使用ComparerStringAsc
        //PriorityQueue<String> test = new PriorityQueue<String>(new ComparerStringAsc());
        //test.Push("ATL");
        //test.Push("XXL");
        //test.Push("CXL");
        //test.Push("ABL");
        //test.Push("CXL");
        //Print("Result : {0} A.CompareTo(C) =  {1}", GetArrayStr(test.ToArray()), "A".CompareTo("C"));
        //排序测试结果：Result : ABL,ATL,CXL,CXL,XXL,,,,,,,,,,, A.CompareTo(C) =  -1

        public class ComparerStringAsc : IComparer<string>
        {
            public int Compare(string a, string b)
            {
                return b.CompareTo(a);  //B.CompareTo(A) = 1, 排序结果是 按照字母表顺序，也就是字典顺序。
            }
        }
        public class ComparerStringDesc : IComparer<string>
        {
            public int Compare(string a, string b)
            {
                return a.CompareTo(b);  //A.CompareTo(B) =  -1, 排序结果是 按照字母表顺序，也就是反字典顺序。
            }
        }

        public class ComparerIntAsc : IComparer<int>
        {
            public int Compare(int a, int b)
            {
                return b - a;
            }
        }
        public class ComparerIntDesc : IComparer<int>
        {
            public int Compare(int a, int b)
            {
                return a - b;
            }
        }
        public class ComparerLongAsc : IComparer<long>
        {
            public int Compare(long a, long b)
            {
                return b == a ? 0 : (b > a ? 1 : -1);
            }
        }
        public class ComparerLongDesc : IComparer<long>
        {
            public int Compare(long a, long b)
            {
                return b == a ? 0 : (b > a ? -1 : 1);
            }
        }


        public class TrieNode<T>
        {
            public Dictionary<T, TrieNode<T>> children = new Dictionary<T, TrieNode<T>>();
            public String word = null;
            public TrieNode() { }
        }

        public class Trie { }

        public class Trie208 : Trie
        {
            public static int count = 0;
            private Trie208[] children; //[字母映射表]
            private bool isEnd;

            /** Initialize your data structure here. */
            public Trie208()
            {
                count++;
                //System.Diagnostics.Debug.Print("new Trie() : " + count);
                this.children = new Trie208[26];
                isEnd = false;
            }

            /** Inserts a word into the trie. */
            public void Insert(string word)
            {
                Trie208 node = this;
                for (int i = 0; i < word.Length; i++)
                {
                    char ch = word[i];
                    int index = ch - 'a';
                    if (node.children[index] == null)
                    {
                        node.children[index] = new Trie208();
                    }
                    node = node.children[index];
                }
                node.isEnd = true; // 这里的node不是自己，而是单词最后一个字幕对应的children中的node
            }

            /** Returns if the word is in the trie. */
            public bool Search(string word)
            {
                Trie208 node = SearchPrefix(word);
                return node != null && node.isEnd;
            }

            /** Returns if there is any word in the trie that starts with the given prefix. */
            public bool StartsWith(string prefix)
            {
                return SearchPrefix(prefix) != null;
            }

            private Trie208 SearchPrefix(string prefix)
            {
                Trie208 node = this;
                for (int i = 0; i < prefix.Length; i++)
                {
                    char ch = prefix[i];
                    int index = ch - 'a';
                    if (node.children[index] == null)
                    {
                        return null;
                    }
                    node = node.children[index];
                }
                return node;
            }
        }

        /// <summary>
        /// Solution 208也使用了类名 Trie，为了区分，后面添加Solution号码加以区分。
        /// Solution 336
        ///作者：LeetCode-Solution
        ///链接：https://leetcode-cn.com/problems/palindrome-pairs/solution/hui-wen-dui-by-leetcode-solution/
        /// </summary>
        public class Trie336 : Trie
        {
            public class Node
            {
                public int[] ch = new int[26];
                public int flag;

                public Node()
                {
                    flag = -1;
                }
            }

            List<Node> tree = new List<Node>();

            public Trie336()
            {
                tree.Add(new Node());
            }

            public void insert(String s, int id)
            {
                int len = s.Length, add = 0;
                for (int i = 0; i < len; i++)
                {
                    int x = s[i] - 'a';
                    if (tree[add].ch[x] == 0)
                    {
                        tree.Add(new Node());
                        tree[add].ch[x] = tree.Count - 1;
                    }
                    add = tree[add].ch[x];
                }
                tree[add].flag = id;
            }

            public int[] query(String s)
            {
                int len = s.Length, add = 0;
                int[] ret = new int[len + 1];
                for (int i = 0; i < len + 1; i++)
                    ret[i] = -1;

                for (int i = 0; i < len; i++)
                {
                    ret[i] = tree[add].flag;
                    int x = s[i] - 'a';
                    if (tree[add].ch[x] == 0)
                    {
                        return ret;
                    }
                    add = tree[add].ch[x];
                }
                ret[len] = tree[add].flag;
                return ret;
            }
        }
        #endregion

        #region ------------------ Math Functions
        /// <summary>
        /// 判断x是否是质数 （From Solution204）
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        public bool IsPrime(int x)
        {
            for (int i = 2; i * i <= x; ++i)
            {
                if (x % i == 0)
                {
                    return false;
                }
            }
            return true;
        }

        /// <summary>
        /// 判断是否是质数，不是更新质因数列表（不含1）
        /// </summary>
        /// <param name="x"></param>
        /// <param name="factors"></param>
        /// <returns></returns>
        public bool IsPrime(int x, List<int> factors)
        {
            if (factors == null) factors = new List<int>();

            for (int i = 2; i * i <= x; ++i)
            {
                if (x % i == 0)
                {
                    factors.Add(i);
                    IsPrime(x / i, factors);
                    break;
                }
            }
            return factors.Count == 0;
        }

        /// <summary>
        /// 判断是否是质数，不是更新所有因数列表（不含1）
        /// </summary>
        /// <param name="x"></param>
        /// <param name="factors"></param>
        /// <returns></returns>
        public bool IsPrime2(int x, List<int> factors)
        {
            if (factors == null) factors = new List<int>();

            for (int i = 2; i <= x / 2; ++i)
            {
                if (x % i == 0)
                {
                    factors.Add(i);
                }
            }
            return factors.Count == 0;
        }

        /// <summary>
        /// 无符号右移, 相当于java里的 value>>>pos
        /// </summary>
        /// <param name="value"></param>
        /// <param name="pos"></param>
        /// <returns></returns>
        public int RightMove(int value, int pos)
        {
            //移动 0 位时直接返回原值
            if (pos != 0)
            {
                // int.MaxValue = 0x7FFFFFFF 整数最大值
                int mask = int.MaxValue;
                //无符号整数最高位不表示正负但操作数还是有符号的，有符号数右移1位，正数时高位补0，负数时高位补1
                value = value >> 1;
                //和整数最大值进行逻辑与运算，运算后的结果为忽略表示正负值的最高位
                value = value & mask;
                //逻辑运算后的值无符号，对无符号的值直接做右移运算，计算剩下的位
                value = value >> pos - 1;
            }

            return value;
        }

        /// <summary>
        /// 无符号右移, 相当于java里的 value>>>pos
        /// </summary>
        /// <param name="value"></param>
        /// <param name="pos"></param>
        /// <returns></returns>
        public long RightMove(long value, int pos)
        {
            //移动 0 位时直接返回原值
            if (pos != 0)
            {
                // long.MaxValue = 0x7FFFFFFFFFFFFFFF 整数最大值
                long mask = long.MaxValue;
                //无符号整数最高位不表示正负但操作数还是有符号的，有符号数右移1位，正数时高位补0，负数时高位补1
                value = value >> 1;
                //和整数最大值进行逻辑与运算，运算后的结果为忽略表示正负值的最高位
                value = value & mask;
                //逻辑运算后的值无符号，对无符号的值直接做右移运算，计算剩下的位
                value = value >> pos - 1;
            }
            return value;
        }

        #endregion
        #region ------------------------- Util Functions -------------------------
        public int GetOrDefault<T>(Dictionary<T, int> dict, T x, int defaultVal = 0)
        {
            if (dict.ContainsKey(x))
                return dict[x];
            else
            {
                dict.Add(x, defaultVal);
                return defaultVal;
            }
        }

        public string GetBitString(int value)
        {
            return Convert.ToString(value, 2).PadLeft(8, '0');
        }

        public bool IsSameDictionary(Dictionary<string, int> dict1, Dictionary<string, int> dict2)
        {
            if (dict1 == null && dict2 != null)
                return false;
            if (dict2 == null && dict1 != null)
                return false;
            if (dict1.Keys.Count != dict2.Keys.Count)
                return false;

            foreach (string key in dict1.Keys)
            {
                if (!dict2.ContainsKey(key))
                    return false;

                if (dict1[key] != dict2[key])
                    return false;
            }
            return true;
        }

        public void ListFill<T>(List<T> list, T defaultValue)
        {
            if (list == null)
                return;
            for (int i = 0; i < list.Count; i++)
            {
                list[i] = defaultValue;
            }
        }
        public void ArrayFill<T>(T[] arr, T defaultValue)
        {
            SolutionBase.ArraysFill<T>(arr, defaultValue);
        }
        public static void ArraysFill<T>(T[] arr, T defaultValue)
        {
            if (arr == null)
                return;
            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = defaultValue;
            }
        }

        public string GetArray2DStr<T>(T[,] matrix, int m, int n, string seperator = ",", string lineSeperator = "\n")
        {
            StringBuilder result = new StringBuilder();
            for (int i = 0; i < m; i++)
            {
                result.Append("[");
                for (int j = 0; j < n; j++)
                {
                    result.Append(matrix[i, j].ToString());
                    if (j != n - 1)
                        result.Append(seperator);
                }
                result.Append("]");
                if (i != m - 1)
                    result.Append(lineSeperator);
            }
            return result.ToString();
        }
        //public string GetArray2DStr<T>(IList<T[]> llist, string seperator = ",", string lineSeperator = "\n")
        //{
        //    string result = "";
        //    foreach (T[] iList in llist)
        //    {
        //        result += "[" + string.Join(seperator, iList.ToArray()) + "]" + lineSeperator;
        //    }
        //    return result;
        //}
        public string GetArray2DStr<T>(IList<IList<T>> llist, string seperator = ",", string lineSeperator = "\n")
        {
            string result = "";
            foreach (IList<T> iList in llist)
            {
                result += "[" + string.Join(seperator, iList.ToArray()) + "]" + lineSeperator;
            }
            return result;
        }
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

        public string GetArrayStr<T>(HashSet<T> a, string seperator = "")
        {
            if (a == null) return "null";
            return string.Join(",", a.ToArray());
        }

        public string GetArrayStr<T>(IList<T> a, string seperator = "")
        {
            if (a == null) return "null";
            return string.Join(",", a);
        }
        public string GetArrayStr(IList<string> a, string seperator = "")
        {
            if (a == null) return "null";
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
        public string GetArrayBiinaryStr(int[] nums, string seperator = ",")
        {
            string result = "";
            for (int i = 0; i < nums.Length; i++)
            {
                if(i == nums.Length -1)
                    result += GetBitString(nums[i]);
                else
                    result += GetBitString(nums[i]) + seperator;
            }
            return result;
        }
        public bool IsListSame<T>(IList<T> a, IList<T> b, bool useSort = true)
        {
            List<T> aList = new List<T>(a);
            List<T> bList = new List<T>(b);

            if (useSort)
            {
                aList.Sort();
                bList.Sort();
            }
            return string.Join(",", aList).Equals(string.Join(",", bList));
        }

        public bool IsSame<T>(T a, T b)
        {
            if (a == null && b != null)
                return false;
            if (a != null && b == null)
                return false;

            if(typeof(T) == typeof(TreeNode))
            {
                TreeNode nodeA = a as TreeNode;
                TreeNode nodeB = a as TreeNode;
                string strA = nodeA.GetNodeString(true);
                string strB = nodeB.GetNodeString(true);
                Print("A:{0} | B:{1} ", strA, strB);
                return strA == strB;
            }
            return a.ToString().Equals(b.ToString());
        }
        public bool IsSame<T>(T[] a, T[] b, bool ignoreTail = true)
        {
            return IsArraySame<T>(a, b, ignoreTail);
        }
        public bool IsSame<T>(IList<IList<T>> a, IList<IList<T>> b, bool useSort = false)
        {
            return IsArray2DSame<T>(a, b, useSort);
        }
        public bool IsSame<T>(IList<T> a, IList<T> b, bool useSort = true)
        {
            return IsListSame<T>(a, b, useSort);
        }

        public bool IsArraySame<T>(T[] a, T[] b, bool ignoreTail = true)
        {
            int alen = a == null ? 0 : a.Length;
            int blen = b == null ? 0 : b.Length;

            if (!ignoreTail)
            {
                if (alen != blen)
                    return false;
            }

            int compareLen = Math.Min(alen, blen);
            {
                for (int i = 0; i < compareLen; i++)
                {
                    if (!a[i].Equals(b[i]))
                        return false;
                }
            }
            return true;
        }
        public bool IsArray2DSame<T>(IList<IList<T>> a, IList<IList<T>> b, bool useSort = false)
        {
            if ((a == null || a.Count == 0) && (b == null || b.Count == 0))
                return true;
            if ((a.Count != 0 && b.Count == 0) || (a.Count == 0 && b.Count != 0))
                return false;

            //int alen = a == null ? 0 : a.Count * (a[0] == null ? 0 : a[0].Count);
            //int blen = b == null ? 0 : b.Count * (b[0] == null ? 0 : b[0].Count);
            if (a.Count == b.Count)
            {
                if (useSort)
                {
                    List<string> strA = new List<string>();
                    List<string> strB = new List<string>();

                    for (int row = 0; row < a.Count; row++)
                    {
                        T[] arrA = a[row].ToArray(); Array.Sort(arrA);
                        T[] arrB = b[row].ToArray(); Array.Sort(arrB);
                        strA.Add(string.Join(",", arrA));
                        strB.Add(string.Join(",", arrB));
                    }
                    strA.Sort(); strB.Sort();
                    string resultA = string.Join("|", strA);
                    string resultB = string.Join("|", strB);
                    return resultA == resultB;
                }
                else
                {
                    for (int row = 0; row < a.Count; row++)
                    {
                        int aCols = a == null ? 0 : a[row].Count;
                        int bCols = b == null ? 0 : b[row].Count;
                        if (aCols == bCols)
                        {
                            for (int i = 0; i < a[row].Count; i++)
                            {
                                if (!a[row][i].Equals( b[row][i]))
                                    return false;
                            }
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
        public void PrintResult(bool isSuccess, object result, object checkResult)
        {
            Print("isSuccess = {0} result: = {1} anticipated: = {2}", isSuccess,
                result == null ? "null" : (result),
                checkResult == null ? "null" : (checkResult));
        }
        public void PrintResult2(bool isSuccess, object result, object checkResult)
        {
            Print("isSuccess = {0} \nresult:\n = {1} \nanticipated:\n = {2}", isSuccess,
                result == null ? "null" : (result),
                checkResult == null ? "null" : (checkResult));
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

        public int GetCodeLineNum(int skipFrames = 0)
        {
            System.Diagnostics.StackTrace st = new System.Diagnostics.StackTrace(skipFrames, true);
            System.Diagnostics.StackFrame fram = st.GetFrame(0);
            int lineNum = fram.GetFileLineNumber();
            return lineNum;
        }
        #endregion
    }
}
