using System;
using System.Collections.Generic;
using System.Linq;
namespace CSharpConsoleApp.Solutions
{
    public class Solution381 : SolutionBase
    {
        /// <summary>
        /// 难易度:
        /// </summary>
        public override Difficulity GetDifficulity() { return Difficulity.Hard; }
        /// <summary>
        /// 关键字:
        /// </summary>
        public override string[] GetKeyWords() { return new string[] { "前序序列化", "入度出度" }; }
        /// <summary>
        /// 标签：
        /// </summary>
        public override Tag[] GetTags() { return new Tag[] { Tag.Stack, Tag.Design }; }

        //TODO
        public override bool Test(System.Diagnostics.Stopwatch sw)
        {
            bool isSuccess = false;

            // 初始化一个空的集合。
            RandomizedCollection randomSet = new RandomizedCollection();

            //// 向集合中插入 1 。返回 true 表示 1 被成功地插入。
            //Print("{0}", randomSet.Insert(1));

            //// 返回 false ，集合现在包含 [1，1] 。
            //Print("{0}", randomSet.Insert(1));

            //// 向集合中插入 2 。返回 true 。集合现在包含 [1，1,2] 。
            //Print("{0}", randomSet.Insert(2));

            //// getRandom 应随机返回 1 或 2 。
            //Print("{0}", randomSet.GetRandom());

            //// 从集合中移除 1 ，返回 true 。集合现在包含 [2] 。
            //Print("{0}", randomSet.Remove(1));

            //// 由于 1 是集合中唯一的数字，getRandom 总是返回 1 。
            //Print("{0}", randomSet.GetRandom());

            // 向集合中插入 1 。返回 true 表示 1 被成功地插入。
            Excute(randomSet, "insert", 1);   //true
            Excute(randomSet, "insert", 1);   //false
            Excute(randomSet, "insert", 2);   //true
            Excute(randomSet, "insert", 2);   //false
            Excute(randomSet, "insert", 2);   //true  [1,1,2,2,2]
            Excute(randomSet, "remove", 1);   //false [1,2,2,2]
            Excute(randomSet, "remove", 1);   //true  [2,2,2]
            Excute(randomSet, "remove", 2);   //true  [2,2]
            Excute(randomSet, "insert", 1);   //true  [2,2,1] true
            Excute(randomSet, "remove", 2);   //true  [2,1]
            Excute(randomSet, "getRandom");   //
            Excute(randomSet, "getRandom");   //
            Excute(randomSet, "getRandom");   //
            Excute(randomSet, "getRandom");   //
            Excute(randomSet, "getRandom");   //
            Excute(randomSet, "getRandom");   //
            Excute(randomSet, "getRandom");   //
            Excute(randomSet, "getRandom");   //
            Excute(randomSet, "getRandom");   //
            Excute(randomSet, "getRandom");   //

            //["RandomizedCollection",
            //"insert","insert","insert","insert","insert","remove","remove","remove","insert","remove","getRandom","getRandom","getRandom","getRandom","getRandom","getRandom","getRandom","getRandom","getRandom","getRandom"]
            //[[],[1],[1],[2],[2],[2],[1],[1],[2],[1],[2],[],[],[],[],[],[],[],[],[],[]]
            //[null,true,false,true,false,false,true,true,true,false,true,1,1,1,1,1,1,1,1,1,1] myAnser
            //[null,true,false,true,false,false,true,true,true,true,true,2,2,2,1,2,1,1,1,1,1]  excepted
            return isSuccess;
        }

        public string Excute(RandomizedCollection randomSet, string cmd, int val = -1)
        {
            string rtn = "";
            if (cmd == "insert")
            { 
                rtn = randomSet.Insert(val).ToString();
            }
            if (cmd == "remove")
            {
                rtn = randomSet.Remove(val).ToString();
            }
            if (cmd == "getRandom")
                rtn = randomSet.GetRandom().ToString();

            Print("{0} | {1} | {2} | {3}", cmd, val, rtn, GetArrayStr(randomSet.list));
            return rtn;
        }
    }

    /*
     * @lc app=leetcode.cn id=381 lang=csharp
     *
     * [381] O(1) 时间插入、删除和获取随机元素 - 允许重复
     *
     * https://leetcode-cn.com/problems/insert-delete-getrandom-o1-duplicates-allowed/description/
     *
     * algorithms
     * Hard (44.52%)
     * Likes:    216
     * Dislikes: 0
     * Total Accepted:    20.2K
     * Total Submissions: 45.4K
     * Testcase Example:  '["RandomizedCollection","insert","insert","insert","getRandom","remove","getRandom"]\n' +
      '[[],[1],[1],[2],[],[1],[]]'
     *
     * 设计一个支持在平均 时间复杂度 O(1) 下， 执行以下操作的数据结构。
     * 
     * 注意: 允许出现重复元素。
     * 
     * 
     * insert(val)：向集合中插入元素 val。
     * remove(val)：当 val 存在时，从集合中移除一个 val。
     * getRandom：从现有集合中随机获取一个元素。每个元素被返回的概率应该与其在集合中的数量呈线性相关。
     * 
     * 
     * 示例:
     * 
     * // 初始化一个空的集合。
     * RandomizedCollection collection = new RandomizedCollection();
     * 
     * // 向集合中插入 1 。返回 true 表示集合不包含 1 。
     * collection.insert(1);
     * 
     * // 向集合中插入另一个 1 。返回 false 表示集合包含 1 。集合现在包含 [1,1] 。
     * collection.insert(1);
     * 
     * // 向集合中插入 2 ，返回 true 。集合现在包含 [1,1,2] 。
     * collection.insert(2);
     * 
     * // getRandom 应当有 2/3 的概率返回 1 ，1/3 的概率返回 2 。
     * collection.getRandom();
     * 
     * // 从集合中删除 1 ，返回 true 。集合现在包含 [1,2] 。
     * collection.remove(1);
     * 
     * // getRandom 应有相同概率返回 1 和 2 。
     * collection.getRandom();
     * 
     * 
     */

    /// <summary>
    /// 31/31 cases passed (460 ms)
    /// Your runtime beats 50 % of csharp submissions
    /// Your memory usage beats 50 % of csharp submissions(90.6 MB)
    /// </summary>
    public class RandomizedCollection
    {

        // key = val, value :int[2]  [0] : list中的索引  [1] 个数
        Dictionary<int, HashSet<int>> dict;
        public List<int> list;
        Random rand = new Random();
        /** Initialize your data structure here. */
        public RandomizedCollection()
        {
            dict = new Dictionary<int, HashSet<int>>();
            list = new List<int>();
        }

        /** Inserts a value to the collection. Returns true if the collection did not already contain the specified element. */
        public bool Insert(int val)
        {
            list.Add(val);

            if (!dict.ContainsKey(val))
            {
                dict.Add(val, new HashSet<int>());
            }
            dict[val].Add(list.Count -1);
            return dict[val].Count == 1;
        }

        /** Removes a value from the collection. Returns true if the collection contained the specified element. */
        public bool Remove(int val)
        {
            if (!dict.ContainsKey(val)) return false;

            // move the last element to the place idx of the element to delete

            //Iterator<Integer> it = idx.get(val).iterator();
            //int i = it.next();
            //var it = dict[val].Last<int>(); //it.MoveNext();
            //此处需要取出最后一个被添加的val的索引
            int idx = dict[val].Last<int>();

            //Step1-1 取得list最后一个元素的值
            int lastElement = list[list.Count - 1];
            //Step1-2 设置val对应索引为最后一个值
            list[idx] = lastElement;
            //Step1-3 删除字典中val对应的list索引idx
            dict[val].Remove(idx);


            //Step2-1 删除字典中最后一个元素的值对应的list索引list.Count - 1，同时添加idx，本质上是转移到idx位置
            dict[lastElement].Remove(list.Count - 1);
            if (idx < list.Count - 1)
                dict[lastElement].Add(idx);

            //Step1-4 如果对应val的索引已经没有了，从字典中删除val
            if (dict[val].Count == 0)
                dict.Remove(val);

            //Step3-1 删除最后一个元素（本质上是数据转移，先设置idx索引位置为最后一个元素的值，然后删除最后一个元素）
            list.RemoveAt(list.Count - 1);
            return true;
        }

        /** Get a random element from the collection. */
        public int GetRandom()
        {
            return list[rand.Next(list.Count)];
            //return nums.get((int)(Math.random() * nums.size())); Java
        }
    }

    // @lc code=start
    public class RandomizedCollection_My_NG
    {
        // key = val, value :int[2]  [0] : list中的索引  [1] 个数
        Dictionary<int, int[]> dict;
        List<int> list;
        Random rand = new Random();
        int count = 0;
        /** Initialize your data structure here. */
        public RandomizedCollection_My_NG()
        {
            dict = new Dictionary<int, int[]>();
            list = new List<int>();
        }

        /** Inserts a value to the collection. Returns true if the collection did not already contain the specified element. */
        public bool Insert(int val)
        {
            count++;
            if (dict.ContainsKey(val))
            {
                dict[val][1]++;
                return false;
            }

            dict.Add(val, new int[] { list.Count, 1 });
            list.Add(val);
            return true;
        }

        /** Removes a value from the collection. Returns true if the collection contained the specified element. */
        public bool Remove(int val)
        {
            if (!dict.ContainsKey(val)) return false;

            count--;
            // move the last element to the place idx of the element to delete
            int idx = dict[val][0];
            dict[val][1]--;

            if(dict[val][1] >0)
            {
                return true;
            }

            int lastElement = list[list.Count - 1];

            list[idx] = lastElement;
            if (!dict.ContainsKey(lastElement))
                dict.Add(lastElement, new int[] { idx, 1 });
            else
            {
                dict[lastElement][0] = idx;
                //dict[lastElement][1] = dict[lastElement][1];
            }
            // delete the last element
            list.RemoveAt(list.Count - 1);
            dict.Remove(val);
            return true;
        }

        //TODO NG GetRandom方法不对
        /** Get a random element from the collection. */
        public int GetRandom()
        {
            //return list[rand.Next(list.Count)];
            return list[rand.Next(count % list.Count)];
        }
    }

    /**
     * Your RandomizedCollection object will be instantiated and called as such:
     * RandomizedCollection obj = new RandomizedCollection();
     * bool param_1 = obj.Insert(val);
     * bool param_2 = obj.Remove(val);
     * int param_3 = obj.GetRandom();
     */
    // @lc code=end


}
