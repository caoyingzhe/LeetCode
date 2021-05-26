using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpConsoleApp.Solutions
{
    /*
     * @lc app=leetcode.cn id=208 lang=csharp
     *
     * [208] 实现 Trie (前缀树)
     *
     * https://leetcode-cn.com/problems/implement-trie-prefix-tree/description/
     *
     * Category	Difficulty	Likes	Dislikes
     * algorithms	Medium (71.61%)	783	-
     * Tags
     * design | trie
     * 
     * Companies
     * bloomberg | facebook | google | microsoft | twitter | uber
     * 
     * Total Accepted:    121.5K
     * Total Submissions: 169.6K
     * Testcase Example:  '["Trie","insert","search","search","startsWith","insert","search"]\n' +
      '[[],["apple"],["apple"],["app"],["app"],["app"],["app"]]'
     *
     * Trie（发音类似 "try"）或者说 前缀树
     * 是一种树形数据结构，用于高效地存储和检索字符串数据集中的键。这一数据结构有相当多的应用情景，例如自动补完和拼写检查。
     * 
     * 请你实现 Trie 类：
     * Trie() 初始化前缀树对象。
     * void insert(String word) 向前缀树中插入字符串 word 。
     * boolean search(String word) 如果字符串 word 在前缀树中，返回 true（即，在检索之前已经插入）；否则，返回
     * false 。
     * boolean startsWith(String prefix) 如果之前已经插入的字符串 word 的前缀之一为 prefix ，返回 true
     * ；否则，返回 false 。
     * 
     * 
     * 示例：
     * 输入
     * ["Trie", "insert", "search", "search", "startsWith", "insert", "search"]
     * [[], ["apple"], ["apple"], ["app"], ["app"], ["app"], ["app"]]
     * 输出
     * [null, null, true, false, true, null, true]
     * 
     * 解释
     * Trie trie = new Trie();
     * trie.insert("apple");
     * trie.search("apple");   // 返回 True
     * trie.search("app");     // 返回 False
     * trie.startsWith("app"); // 返回 True
     * trie.insert("app");
     * trie.search("app");     // 返回 True
     * 
     * 
     * 提示：
     * 1 <= word.length, prefix.length <= 2000
     * word 和 prefix 仅由小写英文字母组成
     * insert、search 和 startsWith 调用次数 总计 不超过 3 * 10^4 次
     */
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
