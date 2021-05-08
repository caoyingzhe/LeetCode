using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpConsoleApp.Solutions
{
    /*
    * @lc app=leetcode.cn id=12 lang=csharp
    *
    * [12] 整数转罗马数字
    * 
    * Tags
    * math | string
    * Companies
    * twitter
    * 
    * 罗马数字包含以下七种字符： I， V， X， L，C，D 和 M。
    * 字符          数值
    * I             1
    * V             5
    * X             10
    * L             50
    * C             100
    * D             500
    * M             1000
    * 例如， 罗马数字 2 写做 II ，即为两个并列的 1。12 写做 XII ，即为 X + II 。 27 写做  XXVII, 即为 XX + V + II 。
    * 
    * 通常情况下，罗马数字中小的数字在大的数字的右边。但也存在特例，例如 4 不写做 IIII，而是 IV。数字 1 在数字 5 的左边，所表示的数等于大数 5 减小数 1 得到的数值 4 。同样地，数字 9 表示为 IX。这个特殊的规则只适用于以下六种情况：
    * 
    * I 可以放在 V (5) 和 X (10) 的左边，来表示 4 和 9。
    * X 可以放在 L (50) 和 C (100) 的左边，来表示 40 和 90。 
    * C 可以放在 D (500) 和 M (1000) 的左边，来表示 400 和 900。
    * 给定一个整数，将其转为罗马数字。输入确保在 1 到 3999 的范围内。
    * 
    * 示例 1:
    * 输入: 3
    * 输出: "III"
    * 
    * 示例 2:
    * 输入: 4
    * 输出: "IV"
    * 
    * 示例 3:
    * 输入: 9
    * 输出: "IX"
    * 
    * 示例 4:
    * 输入: 58
    * 输出: "LVIII"
    * 解释: L = 50, V = 5, III = 3.
    * 
    * 示例 5:
    * 输入: 1994
    * 输出: "MCMXCIV"
    * 解释: M = 1000, CM = 900, XC = 90, IV = 4.
    * 
    * 提示：
    * 1 <= num <= 3999
    */

    public class Solution118 : SolutionBase
    {
        #region Test118 : 杨辉三角
        public override bool Test(System.Diagnostics.Stopwatch sw)
        {
            int lv = 6;
            IList<IList<int>> llist = Generate(lv);
            System.Diagnostics.Debug.Print(GetArrayStr(llist));
            return true;
        }

        /// <summary>
        /// 杨辉三角
        /// 
        /// 知识点1: C#中IList与List区别
        ///             首先IList 泛型接口是 ICollection 泛型接口的子代，并且是所有泛型列表的基接口。
        ///             
        /// 关键字：
        ///     --------------------------------------------------
        ///     <System.Collection>
        ///     --------------------------------------------------
        ///         IEnumerable
        ///         --> ICollection
        ///                 .Count
        ///                 .Add
        ///                 .Remove
        ///                 .IsSynchronized
        ///                 .SyncRoot
        ///                 
        ///             --> Queue
        ///             --> Stack
        ///             --> BitArray
        ///             --> IList
        ///                 .IndexOf
        ///                 .Insert
        ///                 .RemoveAt
        ///                 
        ///                 --> ArrayList
        ///                 --> Array
        ///                 
        ///             --> IDictionary
        ///                 .Keys
        ///                 .Values
        ///                 .TryGetValues
        ///                 
        ///                 --> Hashtable 
        ///                 --> SortedList
        ///                 --> ListDictionary 
        ///     --------------------------------------------------            
        ///     <System.Collection.Generic>        
        ///     --------------------------------------------------
        ///         IEnumerable<T>
        ///         --> ICollection<T>
        ///             --> LinkedList
        ///             
        ///             --> IDictionary<Tkey,TValue>
        ///                 --> Dictionary<Tkey,TValue>
        ///             --> IList<T>
        ///                 --> List<T>
        ///             --> ISet<T>
        ///                 --> HashSet<T>
        ///                 
        ///     IEnumerable.GetEnumerator()
        ///         --> IEnumerator
        ///                 .MoveNext
        ///                 .Reset
        ///             --> IDictionaryEnumerator
        ///     IComparable
        ///         Compare
        ///         
        ///     LinkedList??
        ///         
        ///     System.Linq.ILookup<TKey, TElement>
        ///     --------------------------------------------------   
        ///     System.Collections.Concurrent
        ///     --------------------------------------------------   
        ///         --> ConcurrentQueue<T> (thread safe collection)
        ///     --------------------------------------------------   
        ///     System.Collections.ObjectModel   
        ///     --------------------------------------------------   
        ///         IReadOnlyList<T>
        ///             --> ReadOnlyCollection<T> 
        ///         ObservableCollection<T>
        ///         
        ///         IObservable<T>
        ///         IObserver<T>
        ///         ObservableCollection<T>
        ///         
        ///     System.Collections.Specialized.INotifyCollectionChanged
        /// 
        /// </summary>
        /// <param name="numRows"></param>
        /// <returns></returns>
        public IList<IList<int>> Generate(int numRows)
        {
            List<IList<int>> llist = new List<IList<int>>();

            IList<int> listPre = null;
            for (int i = 0; i < numRows; i++)
            {
                IList<int> list = new List<int>();

                int currentRowCount = i + 1;
                for (int j = 0; j <= currentRowCount - 1; j++)
                {
                    if (j == 0 || j == currentRowCount - 1)
                        list.Add(1);
                    else if (currentRowCount > 1)
                        list.Add(listPre[j - 1] + listPre[j]);
                }
                llist.Add(list);
                listPre = list;
            }
            return llist;
        }
        #endregion
    }
}
