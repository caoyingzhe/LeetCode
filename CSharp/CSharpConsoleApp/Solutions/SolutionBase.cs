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
                                if(nodes[parentIndex] != null)
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
                for (int i = 0; i < nodes.Count; i++)
                {
                    str += nodes[i] == null ? "null" : "" + nodes[i].val;
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
            public T Tail()
            {
                if (Count > 0) return heap[Count - 1];
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


        /// <summary>
        /// Solution 208也使用了类名 Trie，为了区分，后面添加Solution号码加以区分。
        /// Solution 336
        ///作者：LeetCode-Solution
        ///链接：https://leetcode-cn.com/problems/palindrome-pairs/solution/hui-wen-dui-by-leetcode-solution/
        /// </summary>
        public class Trie336
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
            return string.Join(",", a.ToArray());
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
        public bool IsArraySame(int[] a, int[] b, bool ignoreTail = true)
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
                    if (a[i] != b[i])
                        return false;
                }
            }

            return true;
        }
        public bool IsArray2DSame(IList<IList<int>> a, IList<IList<int>> b, bool useSort = false)
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
                        int[] arrA = a[row].ToArray(); Array.Sort(arrA);
                        int[] arrB = b[row].ToArray(); Array.Sort(arrB);
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
                                if (a[row][i] != b[row][i])
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
