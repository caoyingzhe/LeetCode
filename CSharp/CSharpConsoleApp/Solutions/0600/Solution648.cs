using System;
using System.Collections.Generic;
using System.Text;
namespace CSharpConsoleApp.Solutions
{
    /*
     * @lc app=leetcode.cn id=648 lang=csharp
     *
     * [648] 单词替换
     *
     * https://leetcode-cn.com/problems/replace-words/description/
     *
     * Category	Difficulty	Likes	Dislikes
     * algorithms	Medium (57.90%)	129	-
     * Tags
     * hash-table | trie
     * 
     * Companies
     * uber
     * 
     * Total Accepted:    19.1K
     * Total Submissions: 32.9K
     * Testcase Example:  '["cat","bat","rat"]\n"the cattle was rattled by the battery"'
     *
     * 在英语中，我们有一个叫做 词根(root)的概念，它可以跟着其他一些词组成另一个较长的单词——我们称这个词为
     * 继承词(successor)。例如，词根an，跟随着单词 other(其他)，可以形成新的单词 another(另一个)。
     * 现在，给定一个由许多词根组成的词典和一个句子。你需要将句子中的所有继承词用词根替换掉。如果继承词有许多可以形成它的词根，则用最短的词根替换它。
     * 你需要输出替换之后的句子。
     * 
     * 
     * 示例 1：
     * 输入：dictionary = ["cat","bat","rat"], sentence = "the cattle was rattled by
     * the battery"
     * 输出："the cat was rat by the bat"
     * 
     * 
     * 示例 2：
     * 输入：dictionary = ["a","b","c"], sentence = "aadsfasf absbs bbab cadsfafs"
     * 输出："a a b c"
     * 
     * 
     * 示例 3：
     * 输入：dictionary = ["a", "aa", "aaa", "aaaa"], sentence = "a aa a aaaa aaa aaa
     * aaa aaaaaa bbb baba ababa"
     * 输出："a a a a a a a a bbb baba a"
     * 
     * 
     * 示例 4：
     * 输入：dictionary = ["catt","cat","bat","rat"], sentence = "the cattle was
     * rattled by the battery"
     * 输出："the cat was rat by the bat"
     * 
     * 
     * 示例 5：
     * 输入：dictionary = ["ac","ab"], sentence = "it is abnormal that this solution
     * is accepted"
     * 输出："it is ab that this solution is ac"
     * 
     * 
     * 提示：
     * 1 <= dictionary.Length <= 1000
     * 1 <= dictionary[i].Length <= 100
     * dictionary[i] 仅由小写字母组成。
     * 1 <= sentence.Length <= 10^6
     * sentence 仅由小写字母和空格组成。
     * sentence 中单词的总量在范围 [1, 1000] 内。
     * sentence 中每个单词的长度在范围 [1, 1000] 内。
     * sentence 中单词之间由一个空格隔开。
     * sentence 没有前导或尾随空格。
     */

    // @lc code=start
    public class Solution648 : SolutionBase
    {
        /// <summary>
        /// 难度
        /// </summary>
        public override Difficulity GetDifficulity() { return Difficulity.Medium; }
        /// <summary>
        /// 关键字:
        /// </summary>
        public override string[] GetKeyWords() { return new string[] { }; }
        /// <summary>
        /// 标签：
        /// </summary>
        public override Tag[] GetTags() { return new Tag[] { Tag.Trie, Tag.HashTable }; }

        /// <summary>
        /// </summary>
        /// <param name="sw"></param>
        /// <returns></returns>
        public override bool Test(System.Diagnostics.Stopwatch sw)
        {
            bool isSuccess = true;
            IList<string> dictionary; string sentence;
            string result, checkResult;

            dictionary = new string[] { "cat", "bat", "rat" };
            sentence = "the cattle was rattled by the battery";
            checkResult = "the cat was rat by the bat";
            result = ReplaceWords(dictionary, sentence);
            isSuccess &= IsSame(result, checkResult);
            PrintResult(isSuccess, result, checkResult);


            dictionary = new string[] { "a", "b", "c" };
            sentence = "aadsfasf absbs bbab cadsfafs";
            checkResult = "a a b c";
            result = ReplaceWords(dictionary, sentence);
            isSuccess &= IsSame(result, checkResult);
            PrintResult(isSuccess, result, checkResult);

            dictionary = new string[] { "a", "aa", "aaa", "aaaa" };
            sentence = "a aa a aaaa aaa aaa aaa aaaaaa bbb baba ababa";
            checkResult = "a a a a a a a a bbb baba a";
            result = ReplaceWords(dictionary, sentence);
            isSuccess &= IsSame(result, checkResult);
            PrintResult(isSuccess, result, checkResult);

            dictionary = new string[] { "catt", "cat", "bat", "rat" };
            sentence = "the cattle was rattled by the battery";
            checkResult = "the cat was rat by the bat";
            result = ReplaceWords(dictionary, sentence);
            isSuccess &= IsSame(result, checkResult);
            PrintResult(isSuccess, result, checkResult);

            dictionary = new string[] { "ac", "ab" };
            sentence = "it is abnormal that this solution is accepted";
            checkResult = "it is ab that this solution is ac";
            result = ReplaceWords(dictionary, sentence);
            isSuccess &= IsSame(result, checkResult);
            PrintResult(isSuccess, result, checkResult);

            return isSuccess;
        }

        /// <summary>
        /// 作者：LeetCode
        /// 链接：https://leetcode-cn.com/problems/replace-words/solution/dan-ci-ti-huan-by-leetcode/
        /// 126/126 cases passed (132 ms)
        /// Your runtime beats 100 % of csharp submissions
        /// Your memory usage beats 38.46 % of csharp submissions(50 MB)
        /// </summary>
        /// <param name="dictionary"></param>
        /// <param name="sentence"></param>
        /// <returns></returns>
        public string ReplaceWords(IList<string> dictionary, string sentence)
        {
            //存储字典前缀树的第一层数据；
            TrieNode trie = new TrieNode();
            foreach (String root in dictionary)
            {
                TrieNode cur = trie;
                foreach (char letter in root.ToCharArray())
                {
                    if (cur.children[letter - 'a'] == null)
                        cur.children[letter - 'a'] = new TrieNode();
                    cur = cur.children[letter - 'a'];
                }
                cur.word = root;
            }

            StringBuilder ans = new StringBuilder();

            foreach (String word in sentence.Split(' ')) //.Split(' ')) //Java  data.split("\\s+") \\s+ --->以空格进行分割, 至少出现一个空格，
            {
                if (ans.Length > 0)
                    ans.Append(" ");

                //cur代表找单词的前缀树的节点
                TrieNode cur = trie;
                foreach (char letter in word.ToCharArray())
                {
                    //不存在于前缀树中第一层（即 找不到单词的第一个字母），直接跳出循环
                    if (cur.children[letter - 'a'] == null || cur.word != null)
                        break;
                    //此处代表找到对应单词的前缀树节点，逐字母更新最接近的节点
                    cur = cur.children[letter - 'a'];
                }
                ans.Append(cur.word != null ? cur.word : word);
            }
            return ans.ToString();
        }

        public class TrieNode
        {
            public TrieNode[] children;
            public String word;
            public TrieNode()
            {
                children = new TrieNode[26];
            }
        }
    }
    // @lc code=end
}
