using System;
namespace CSharpConsoleApp.Solutions
{
    class Solution211 : SolutionBase
    {
        /// <summary>
        /// 难度
        /// </summary>
        public override Difficulity GetDifficulity() { return Difficulity.Medium; }
        /// <summary>
        /// 关键字:
        /// </summary>
        public override string[] GetKeyWords() { return new string[] { "二叉搜索树迭代器类", "BSTIterator", "设计", "按中序遍历", "BST" }; }
        /// <summary>
        /// 标签： 
        /// </summary>
        public override Tag[] GetTags() { return new Tag[] { Tag.Trie, Tag.Design, Tag.Backtracking }; }

        public override bool Test(System.Diagnostics.Stopwatch sw)
        {
            bool isSuccess = true;
            WordDictionary wordDictionary = new WordDictionary();
            wordDictionary.AddWord("bad");
            wordDictionary.AddWord("dad");
            wordDictionary.AddWord("mad");
            wordDictionary.Search("pad"); // return False
            wordDictionary.Search("bad"); // return True
            wordDictionary.Search(".ad"); // return True
            wordDictionary.Search("b.."); // return True
            return isSuccess;
        }
    }
    /*
    * @lc app=leetcode.cn id=211 lang=csharp
    *
    * [211] 添加与搜索单词 - 数据结构设计
    *
    * https://leetcode-cn.com/problems/design-add-and-search-words-data-structure/description/
    *
    * Category	Difficulty	Likes	Dislikes
    * algorithms	Medium (48.16%)	250	-
    * Tags
    * backtracking | design | trie
    * 
    * Companies
    * facebook
    * 
    * Total Accepted:    25K
    * Total Submissions: 51.9K
    * Testcase Example:  '["WordDictionary","addWord","addWord","addWord","search","search","search","search"]\n' +
    '[[],["bad"],["dad"],["mad"],["pad"],["bad"],[".ad"],["b.."]]'
    *
    * 请你设计一个数据结构，支持 添加新单词 和 查找字符串是否与任何先前添加的字符串匹配 。
    * 
    * 实现词典类 WordDictionary ：
    * 
    * 
    * WordDictionary() 初始化词典对象
    * void addWord(word) 将 word 添加到数据结构中，之后可以对它进行匹配
    * bool search(word) 如果数据结构中存在字符串与 word 匹配，则返回 true ；否则，返回  false 。word 中可能包含一些
    * '.' ，每个 . 都可以表示任何一个字母。
    * 
    * 
    * 
    * 
    * 示例：
    * 
    * 
    * 输入：
    * 
    * ["WordDictionary","addWord","addWord","addWord","search","search","search","search"]
    * [[],["bad"],["dad"],["mad"],["pad"],["bad"],[".ad"],["b.."]]
    * 输出：
    * [null,null,null,null,false,true,true,true]
    * 
    * 解释：
    * WordDictionary wordDictionary = new WordDictionary();
    * wordDictionary.addWord("bad");
    * wordDictionary.addWord("dad");
    * wordDictionary.addWord("mad");
    * wordDictionary.search("pad"); // return False
    * wordDictionary.search("bad"); // return True
    * wordDictionary.search(".ad"); // return True
    * wordDictionary.search("b.."); // return True
    * 
    * 提示：
    * 1 <= word.length <= 500
    * addWord 中的 word 由小写英文字母组成
    * search 中的 word 由 '.' 或小写英文字母组成
    * 最多调用 50000 次 addWord 和 search
    */

    // @lc code=start

    /// <summary>
    /// 作者：ydding
    /// 链接：https://leetcode-cn.com/problems/design-add-and-search-words-data-structure/solution/zi-dian-shu-by-ydding-eof4/
    /// 13/13 cases passed (256 ms)
    /// Your runtime beats 88.46 % of csharp submissions
    /// Your memory usage beats 61.54 % of csharp submissions(44.8 MB)
    /// </summary>
    public class WordDictionary
    {
        private WordTrie trie;
        /** Initialize your data structure here. */
        public WordDictionary()
        {
            trie = new WordTrie();
        }

        public void AddWord(string word)
        {
            WordTrie t = trie;
            foreach (char c in word)
            {
                int idx = c - 'a';
                if (t.children[idx] == null)
                    t.children[idx] = new WordTrie();
                t = t.children[idx];
            }
            t.isWord = true;
        }

        public bool Search(string word)
        {
            return DFS(word, 0, trie);
        }

        /// <summary>
        /// 添加的搜索方法
        /// </summary>
        /// <param name="word"></param>
        /// <param name="idx"></param>
        /// <param name="root"></param>
        /// <returns></returns>
        private bool DFS(string word, int idx, WordTrie root)
        {
            if (idx == word.Length)
            {
                return root.isWord;
            }
            if (word[idx] == '.')
            {
                for (int i = 0; i < 26; i++)
                {
                    if (root.children[i] != null && DFS(word, idx + 1, root.children[i]))
                        return true;
                }
                return false;
            }
            else
            {
                if (root.children[word[idx] - 'a'] != null && DFS(word, idx + 1, root.children[word[idx] - 'a']))
                {
                    return true;
                }
                return false;
            }
        }
    }

    public class WordTrie : SolutionBase.Trie
    {
        public WordTrie[] children;
        public bool isWord;

        public WordTrie()
        {
            children = new WordTrie[26];
            for (int i = 0; i < 26; i++)
            {
                children[i] = null;
            }
            isWord = false;
        }
    }




    /**
     * Your WordDictionary object will be instantiated and called as such:
     * WordDictionary obj = new WordDictionary();
     * obj.AddWord(word);
     * bool param_2 = obj.Search(word);
     */
    // @lc code=end


}
