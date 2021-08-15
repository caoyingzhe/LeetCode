using System;
using System.Collections.Generic;

namespace CSharpConsoleApp.Solutions
{
    /// <summary>
    /// Time Limit Exceeded
    /// 43/44 cases passed (N/A)
    /// 作者：chi-gua-chuan
    /// 链接：https://leetcode-cn.com/problems/concatenated-words/solution/java-zi-dian-shu-ji-bai-97-by-chi-gua-ch-7tv8/
    /// </summary>
    public class Solution472
    {
        public class trie
        {
            public bool isEnd;
            public trie[] next;
            public trie()
            {
                isEnd = false;
                next = new trie[26];
            }
        }

        trie root;
        //向字典树加入单词
        public void add(String word)
        {
            trie temp = root;

            for (int i = 0; i < word.Length; i++)
            {
                char c = word[i];

                if (temp.next[c - 'a'] != null)
                {
                    temp = temp.next[c - 'a'];
                }
                else
                {
                    trie next = new trie();

                    temp.next[c - 'a'] = next;
                    temp = temp.next[c - 'a'];
                }
            }
            temp.isEnd = true;
        }
        //向字典树搜索单词: search(要搜索的单词， 当前搜索到了哪一位字母， 目前已经由num个单词组成， 字典树引用)
        public bool search(String word, int idx, int num, trie now)
        {
            for (int i = idx; i < word.Length; i++)
            {
                char c = word[i];
                if (now.next[c - 'a'] != null)
                    now = now.next[c - 'a'];
                else
                {
                    return false;
                }

                if (now.isEnd)
                {
                    if (search(word, i + 1, num + 1, root))
                        return true;
                    num++;
                }

                if (i == word.Length - 1)
                {
                    if (now.isEnd && num > 1) return true;
                    else return false;
                }
            }
            if (num > 1) return true;
            else return false;
        }
        public IList<string> FindAllConcatenatedWordsInADict(string[] words)
        {
            //因为一个单词只能由更短的单词组成，所以将短单词放前面
            Array.Sort(words, (a, b) =>(a.Length - b.Length));

            root = new trie();

            List<String> res = new List<String>();

            for (int i = 0; i < words.Length; i++)
            {
                //对于每个单词，搜索字典树（字典树由 所有比当前单词 短 的单词组成）
                String word = words[i];
                //搜索, 也就是dfs
                if (search(word, 0, 0, root))
                {
                    res.Add(word);
                }
                //将这个单词加入字典树
                add(word);
            }
            return res;
        }
    }
}
