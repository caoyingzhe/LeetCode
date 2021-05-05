using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpConsoleApp.Solutions
{
    /// <summary>
    /// 实现前缀树
    /// </summary>
    class Solution208 : SolutionBase
    {
        /// <summary>
        /// 难度
        /// </summary>
        public override Difficulity GetDifficulity() { return Difficulity.Medium; }
        /// <summary>
        /// 关键字:
        /// </summary>
        public override string[] GetKeyWords() { return new string[] { "前缀树", "非典型多叉数", "设计" }; }
        /// <summary>
        /// 标签： 
        /// </summary>
        public override Tag[] GetTags() { return new Tag[] { Tag.Trie, Tag.Design }; }

        public override bool Test(System.Diagnostics.Stopwatch sw)
        {
            bool isSuccess = true;

            Trie trie = new Trie();
            //trie.Insert("apple");
            //System.Diagnostics.Debug.Assert(trie.Search("apple")== true);    // 返回 True
            //System.Diagnostics.Debug.Assert(trie.Search("app") == false);    // 返回 False
            //System.Diagnostics.Debug.Assert(trie.StartsWith("app") == true); // 返回 True
            //trie.Insert("app");
            //System.Diagnostics.Debug.Assert(trie.Search("app") == true); ;   // 返回 True

            trie.Insert("abcdefjhijklmnopqrstuvwxyz");
            trie.Insert("abcdefjhijklmnopqrstuvwxyzz");
            System.Diagnostics.Debug.Assert(trie.StartsWith("abcdefjhijklmnopqrstuvwxyz") == true); ;   // 返回 True
            System.Diagnostics.Debug.Assert(trie.Search("abcdefjhijklmnopqrstuvwxyzz") == true); ;   // 返回 True
            //trie.Insert("diagnostics");
            //trie.Insert("dialog");
            //System.Diagnostics.Debug.Assert(trie.Search("diagnostics") == true);    // 返回 False
            //System.Diagnostics.Debug.Assert(trie.Search("dia") == false); // 返回 True
            //System.Diagnostics.Debug.Assert(trie.StartsWith("diagno") == true); // 返回 True
            //System.Diagnostics.Debug.Assert(trie.Search("diagno") == false); // 返回 True

            return isSuccess;
        }

    }

    public class Trie
    {
        public static int count = 0;
        private Trie[] children; //[字母映射表]
        private bool isEnd;

        /** Initialize your data structure here. */
        public Trie()
        {
            count++;
            //System.Diagnostics.Debug.Print("new Trie() : " + count);
            this.children = new Trie[26];
            isEnd = false;
        }

        /** Inserts a word into the trie. */
        public void Insert(string word)
        {
            Trie node = this;
            for(int i=0; i<word.Length; i++)
            {
                char ch = word[i];
                int index = ch - 'a';
                if (node.children[index] == null)
                {
                    node.children[index] = new Trie();
                }
                node = node.children[index];
            }
            node.isEnd = true; // 这里的node不是自己，而是单词最后一个字幕对应的children中的node
        }

        /** Returns if the word is in the trie. */
        public bool Search(string word)
        {
            Trie node = SearchPrefix(word);
            return node != null && node.isEnd;
        }

        /** Returns if there is any word in the trie that starts with the given prefix. */
        public bool StartsWith(string prefix)
        {
            return SearchPrefix(prefix) != null;
        }

        private Trie SearchPrefix(string prefix)
        {
            Trie node = this;
            for(int i= 0; i<prefix.Length; i++)
            {
                char ch = prefix[i];
                int index = ch - 'a';
                if(node.children[index] == null)
                {
                    return null;
                }
                node = node.children[index];
            }
            return node;
        }
    }
}
