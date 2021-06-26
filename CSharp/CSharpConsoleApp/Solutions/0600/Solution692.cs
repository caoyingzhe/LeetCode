using System;
using System.Collections.Generic;
namespace CSharpConsoleApp.Solutions
{
    /*
 * @lc app=leetcode.cn id=692 lang=csharp
 *
 * [692] 前K个高频单词
 *
 * https://leetcode-cn.com/problems/top-k-frequent-words/description/
 *
 * Category	Difficulty	Likes	Dislikes
 * algorithms	Medium (58.45%)	351	-
 * Tags
 * hash-table | heap | trie
 * 
 * Companies
 * amazon | bloomberg | uber | yelp
 * 
 * Total Accepted:    60.9K
 * Total Submissions: 104.2K
 * Testcase Example:  '["i", "love", "leetcode", "i", "love", "coding"]\n2'
 *
 * 给一非空的单词列表，返回前 k 个出现次数最多的单词。
 * 返回的答案应该按单词出现频率由高到低排序。如果不同的单词有相同出现频率，按字母顺序排序。
 * 
 * 示例 1：
 * 输入: ["i", "love", "leetcode", "i", "love", "coding"], k = 2
 * 输出: ["i", "love"]
 * 解析: "i" 和 "love" 为出现次数最多的两个单词，均为2次。
 * ⁠   注意，按字母顺序 "i" 在 "love" 之前。
 * 
 * 示例 2：
 * 输入: ["the", "day", "is", "sunny", "the", "the", "the", "sunny", "is", "is"],
 * k = 4
 * 输出: ["the", "is", "sunny", "day"]
 * 解析: "the", "is", "sunny" 和 "day" 是出现次数最多的四个单词，
 * ⁠   出现次数依次为 4, 3, 2 和 1 次。
 * 
 * 注意：
 * 假定 k 总为有效值， 1 ≤ k ≤ 集合元素数。
 * 输入的单词均由小写字母组成。
 * 
 * 扩展练习：
 * 尝试以 O(n log k) 时间复杂度和 O(n) 空间复杂度解决。
 */

    // @lc code=start
    public class Solution692 : SolutionBase
    {
        /// <summary>
        /// 难易度:
        /// </summary>
        public override Difficulity GetDifficulity() { return Difficulity.Medium; }
        /// <summary>
        /// 关键字:
        /// </summary>
        public override string[] GetKeyWords() { return new string[] { "类似347" }; }
        /// <summary>
        /// 标签： 
        /// </summary>
        public override Tag[] GetTags() { return new Tag[] { Tag.HashTable, Tag.Heap, Tag.Trie }; }

        public override bool Test(System.Diagnostics.Stopwatch sw)
        {
            bool isSuccess = true;
            IList<string> result, checkResult;
            string[] words; int k;

            words = new string[] { "i", "love", "leetcode", "i", "love", "coding" };
            k = 2 ;
            checkResult = new string[] { "i", "love" };
            result = TopKFrequent(words, k);
            isSuccess &= IsListSame(result, checkResult);
            PrintResult(isSuccess, GetArrayStr(result), GetArrayStr(checkResult));

            words = new string[] { "the", "day", "is", "sunny", "the", "the", "the", "sunny", "is", "is" };
            k = 4;
            checkResult = new string[] { "the", "is", "sunny", "day" };
            result = TopKFrequent(words, k);
            isSuccess &= IsListSame(result, checkResult);
            PrintResult(isSuccess, GetArrayStr(result), GetArrayStr(checkResult));

            //"i", "love", "leetcode", "i", "love", "coding"
            words = new string[] { "i", "love", "leetcode", "i", "love", "coding" };
            k = 3;
            checkResult = new string[] { "i", "love", "coding" };
            result = TopKFrequent(words, k);
            isSuccess &= IsListSame(result, checkResult);
            PrintResult(isSuccess, GetArrayStr(result), GetArrayStr(checkResult));
            return isSuccess;
        }
        public class Word
        {
            public string word;
            public int count;
        }
        /// <summary>
        /// 110/110 cases passed (320 ms)
        /// Your runtime beats 63.06 % of csharp submissions
        /// Your memory usage beats 67.54 % of csharp submissions(33.3 MB)
        /// </summary>
        /// <param name="words"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public IList<string> TopKFrequent(string[] words, int k)
        {
            Dictionary<string, Word> occurrences = new Dictionary<string, Word>();
            
            foreach (string word in words)
            {
                if (!occurrences.ContainsKey(word))
                    occurrences.Add(word, new Word());
                occurrences[word].word = word;
                occurrences[word].count += 1;
            }

            // int[] 的第一个元素代表数组的值，第二个元素代表了该值出现的次数
            PriorityQueue<Word> queue = new PriorityQueue<Word>(new ComparerSolution692());

            foreach (string key in occurrences.Keys)
            {
                Word word = occurrences[key];
                //if (queue.Count == k)
                //{
                //    if (queue.Peek().count < word.count)
                //    {
                //        queue.Poll();
                //        queue.Offer(word);
                //    }
                //}
                //else
                //{
                //    queue.Offer(word);
                //}
                queue.Offer(word);
            }
            string[] ret = new string[k];
            for (int i = 0; i < k; ++i)
            {
                ret[i] = queue.Poll().word;
            }
            return ret;
        }

        public class ComparerSolution692 : IComparer<Word>
        {
            public int Compare(Word pair1, Word pair2)
            {
                if (pair1.count == pair2.count) return string.Compare(pair2.word, pair1.word); //字母表顺序小的排在顶部
                return pair1.count - pair2.count; //count大的排在顶部
            }
        }
    }
    // @lc code=end


}
