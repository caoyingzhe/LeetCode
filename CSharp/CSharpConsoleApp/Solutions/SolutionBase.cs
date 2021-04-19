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

        public class ListNode
        {
            public int val;
            public ListNode next;
            public ListNode(int x) { val = x; }
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

        #region ------------------------- Util Functions -------------------------
        public string GetArrayStr(IList<IList<int>> llist, string seperator = ",", string lineSeperator = "\n")
        {
            string result = "";
            foreach (IList<int> iList in llist)
            {
                result += "[" + string.Join(seperator, iList) + "]" + lineSeperator;
            }
            return result;
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
