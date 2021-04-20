using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace CSharpConsoleApp.Solutions
{
    /// <summary>
    /// LRU 缓存机制
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
        public override string[] GetKeyWords() { return new string[] { "SortHashMap" }; }
        /// <summary>
        /// 标签： 
        /// </summary>
        public override Tag[] GetTags() { return new Tag[] { Tag.Design}; }
        public override bool Test(Stopwatch sw)
        {
            return false;
        }
    }
    public class LRUCache
    {
        #region LeetCode
        public LRUCache(int capacity)
        {

        }

        public int Get(int key)
        {
            return -1;
        }

        public void Put(int key, int value)
        {

        }
        #endregion}
    }
}
