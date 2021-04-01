using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpConsoleApp.Solutions
{
    public class Solution118 : SolutionBase
    {
        #region Test118 : 杨辉三角
        public override bool Test(System.Diagnostics.Stopwatch sw)
        {
            int lv = 6;
            IList<IList<int>> llist = Generate(lv);

            string result = "";
            foreach (IList<int> iList in llist)
            {
                result += "[" + string.Join(",", iList) + "]\n";
            }
            System.Diagnostics.Debug.Print(result);
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
