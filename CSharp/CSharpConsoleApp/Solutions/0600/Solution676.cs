using System;
using System.Collections.Generic;
namespace CSharpConsoleApp.Solutions
{
    public class Solution676 : SolutionBase
    {
        /// <summary>
        /// 难度
        /// </summary>
        public override Difficulity GetDifficulity() { return Difficulity.Medium; }
        /// <summary>
        /// 关键字:
        /// </summary>
        public override string[] GetKeyWords() { return new string[] { "前缀树", "汉明距离", "非典型多叉数", "设计" }; }
        /// <summary>
        /// 标签：
        /// </summary>
        public override Tag[] GetTags() { return new Tag[] { Tag.Trie, Tag.Design, Tag.HashTable }; }

        public override bool Test(System.Diagnostics.Stopwatch sw)
        {
            bool isSuccess = true;
            return isSuccess;
        }

        public Solution676()
        {
        }
    }

    /// <summary>
    /// 83/83 cases passed (144 ms)
    /// Your runtime beats 75 % of csharp submissions
    /// Your memory usage beats 75 % of csharp submissions(30.5 MB)
    /// </summary>
    public class MagicDictionary
    {
        Dictionary<int, List<string>> buckets;
        /** Initialize your data structure here. */
        public MagicDictionary()
        {
            buckets = new Dictionary<int, List<string>>();
        }

        public void BuildDict(string[] dictionary)
        {
            for(int i=0; i<dictionary.Length; i++)
            {
                string word = dictionary[i];
                if(!buckets.ContainsKey(word.Length))
                    buckets.Add(word.Length, new List<string>());
                buckets[word.Length].Add(word);
            }
        }

        public bool Search(string searchWord)
        {
            if (!buckets.ContainsKey(searchWord.Length))
                return false;
            foreach(string word in buckets[searchWord.Length])
            {
                int mismatch = 0;
                for(int i=0; i<word.Length; i++)
                {
                    if(searchWord[i] != word[i])
                    {
                        if (++mismatch > 1)
                            break;
                    }
                }
                if (mismatch <= 1)
                    return true;
            }
            return false;
        }
    }
}
