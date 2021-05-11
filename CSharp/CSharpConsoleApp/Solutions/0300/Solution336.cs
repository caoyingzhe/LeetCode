using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpConsoleApp.Solutions
{
    /*
     * @lc app=leetcode.cn id=336 lang=csharp
     *
     * [336] 回文对
     *
     * https://leetcode-cn.com/problems/palindrome-pairs/description/
     *
     * Category	Difficulty	Likes	Dislikes
     * algorithms	Hard (40.04%)	228	-
     * Tags
     * hash-table | string | trie
     * 
     * Companies
     * airbnb | google
     * 
     * Total Accepted:    20.7K
     * Total Submissions: 51.6K
     * Testcase Example:  '["abcd","dcba","lls","s","sssll"]'
     *
     * 给定一组 互不相同 的单词， 找出所有 不同 的索引对 (i, j)，使得列表中的两个单词， words[i] + words[j]
     * ，可拼接成回文串。
     * 
     * 示例 1：
     * 输入：words = ["abcd","dcba","lls","s","sssll"]
     * 输出：[[0,1],[1,0],[3,2],[2,4]] 
     * 解释：可拼接成的回文串为 ["dcbaabcd","abcddcba","slls","llssssll"]
     * 
     * 示例 2：
     * 输入：words = ["bat","tab","cat"]
     * 输出：[[0,1],[1,0]] 
     * 解释：可拼接成的回文串为 ["battab","tabbat"]
     * 
     * 示例 3：
     * 输入：words = ["a",""]
     * 输出：[[0,1],[1,0]]
     * 
     * 提示：
     * 1 <= words.Length <= 5000
     * 0 <= words[i].Length <= 300
     * words[i] 由小写英文字母组成
     * 
     */
    class Solution336 : SolutionBase
    {
        /// <summary>
        /// 难易度:
        /// </summary>
        public override Difficulity GetDifficulity() { return Difficulity.Medium; }
        /// <summary>
        /// 关键字:
        /// </summary>
        public override string[] GetKeyWords() { return new string[] { "前序序列化", "入度出度" }; }
        /// <summary>
        /// 标签：
        /// </summary>
        public override Tag[] GetTags() { return new Tag[] { Tag.HashTable, Tag.String, Tag.Trie }; }

        //TODO
        public override bool Test(System.Diagnostics.Stopwatch sw)
        {
            bool isSuccess = true;
            string[] words;
            IList<IList<int>> result;
            int[][] checkResult;

            words = new string[] { "abcd", "dcba", "lls", "s", "sssll" };
            checkResult = new int[][] {
                new int[] { 0, 1 },
                new int[] { 1, 0 },
                new int[] { 3, 2 },
                new int[] { 2, 4}
            };
            result = PalindromePairs(words);
            return isSuccess;
        }


        class Node
        {
            public int[] ch = new int[26];
            public int flag;

            public Node()
            {
                flag = -1;
            }
        }

        #region ----------------------------- 方法一：枚举前缀和后缀 -----------------------------------
        List<Node> tree = new List<Node>();

        /// <summary>
        /// 速度确实慢，但是比想象中好
        /// Your runtime beats 33.33 % of csharp submissions
        /// Your memory usage beats 16.67 % of csharp submissions(53.4 MB)
        /// 
        /// 方法一：枚举前缀和后缀
        /// 时间复杂度：O(n * m^2)
        ///     n 是字符串的数量，最大5000，
        ///     m 是字符串的平均长度。最大300
        ///     最坏情况：5000 × 300 ×300 = 4.5亿 还处于可以接受范围。
        ///     对于每一个字符串，我们需要 O(m^2)地判断其所有前缀与后缀是否是回文串，
        ///     并 O(m^2)地寻找其所有前缀与后缀是否在给定的字符串序列中出现。
        /// 空间复杂度：O(n * m)
        ///     n 是字符串的数量，
        ///     m 是字符串的平均长度。为字典树的空间开销。
        /// https://leetcode-cn.com/problems/palindrome-pairs/solution/hui-wen-dui-by-leetcode-solution/
        /// </summary>
        /// <param name="words"></param>
        /// <returns></returns>
        public IList<IList<int>> PalindromePairs_Common(string[] words)
        {
            tree.Add(new Node());
            int n = words.Length;
            for (int i = 0; i < n; i++)
            {
                insert(words[i], i);
            }
            List<IList<int>> ret = new List<IList<int>>();
            for (int i = 0; i < n; i++)
            {
                int m = words[i].Length;
                for (int j = 0; j <= m; j++)
                {
                    if (isPalindrome(words[i], j, m - 1))
                    {
                        int leftId = findWord(words[i], 0, j - 1);
                        if (leftId != -1 && leftId != i)
                        {
                            ret.Add(new List<int>(new int[] { i, leftId })); //Java Array.asList数组转化成List集合的方法。
                        }
                    }
                    if (j != 0 && isPalindrome(words[i], 0, j - 1))
                    {
                        int rightId = findWord(words[i], j, m - 1);
                        if (rightId != -1 && rightId != i)
                        {
                            ret.Add(new List<int>(new int[] { rightId, i }));
                        }
                    }
                }
            }
            return ret;
        }

        public void insert(String s, int id)
        {
            int len = s.Length, add = 0;
            for (int i = 0; i < len; i++)
            {
                int x = s[i] - 'a';
                if (tree[add].ch[x] == 0)
                {
                    tree.Add(new Node());
                    tree[add].ch[x] = tree.Count - 1;
                }
                add = tree[add].ch[x];
            }
            tree[add].flag = id;
        }

        public bool isPalindrome(String s, int left, int right)
        {
            int len = right - left + 1;
            for (int i = 0; i < len / 2; i++)
            {
                if (s[left + i] != s[right - i])
                {
                    return false;
                }
            }
            return true;
        }

        public int findWord(String s, int left, int right)
        {
            int add = 0;
            for (int i = right; i >= left; i--)
            {
                int x = s[i] - 'a';
                if (tree[add].ch[x] == 0)
                {
                    return -1;
                }
                add = tree[add].ch[x];
            }
            return tree[add].flag;
        }
        #endregion

        #region ----------------------------- 方法二：字典树 + Manacher -----------------------------------
        ///对于判断其所有前缀与后缀是否是回文串：
        ///    利用 Manacher 算法，可以线性地处理出每一个前后缀是否是回文串
        ///对于判断其所有前缀与后缀是否在给定的字符串序列中出现：
        ///    对于给定的字符串序列，分别正向与反向建立字典树，
        ///    利用正向建立的字典树验证 kk 的后缀的翻转，
        ///    利用反向建立的字典树验证 kk 的前缀的翻转。
        ///
        /// 因为该解法常数较大，因此在随机数据下的表现并没有方法一优秀。
        /// 实际测试结果也如此，不是很优秀。
        /// Your runtime beats 16.67 % of csharp submissions
        /// Your memory usage beats 16.67 % of csharp submissions(55.5 MB)

        public IList<IList<int>> PalindromePairs(string[] words)
        {
            Trie336 trie1 = new Trie336();
            Trie336 trie2 = new Trie336();

            int n = words.Length;
            for (int i = 0; i < n; i++)
            {
                trie1.insert(words[i], i);
                StringBuilder tmp = new StringBuilder(words[i]);
                //tmp.Reverse();
                //trie2.insert(tmp.ToString(), i);
                trie2.insert(new string(tmp.ToString().Reverse().ToArray()), i);
            }

            List<IList<int>> ret = new List<IList<int>>();
            for (int i = 0; i < n; i++)
            {
                int[][] rec = manacher(words[i]);

                int[] id1 = trie2.query(words[i]);
                words[i] = new string(words[i].Reverse().ToArray()); //  words[i] = new StringBuffer(words[i]).reverse().toString();
                int[] id2 = trie1.query(words[i]);

                int m = words[i].Length;

                int allId = id1[m];
                if (allId != -1 && allId != i)
                {
                    ret.Add(new List<int>(new int[] { i, allId }));
                }
                for (int j = 0; j < m; j++)
                {
                    if (rec[j][0] != 0)
                    {
                        int leftId = id2[m - j - 1];
                        if (leftId != -1 && leftId != i)
                        {
                            ret.Add(new List<int>(new int[] { leftId, i }));
                        }
                    }
                    if (rec[j][1] != 0)
                    {
                        int rightId = id1[j];
                        if (rightId != -1 && rightId != i)
                        {
                            ret.Add(new List<int>(new int[] { i, rightId }));
                        }
                    }
                }
            }
            return ret;
        }

        public int[][] manacher(String s)
        {
            int n = s.Length;
            StringBuilder tmp = new StringBuilder("#");
            for (int i = 0; i < n; i++)
            {
                if (i > 0)
                {
                    tmp.Append('*');
                }
                tmp.Append(s[i]);
            }
            tmp.Append('!');
            int m = n * 2;
            int[] len = new int[m];
            int[][] ret = new int[n][];
            for (int i = 0; i < n; i++)
                ret[i] = new int[2];

            int p = 0, maxn = -1;
            for (int i = 1; i < m; i++)
            {
                len[i] = maxn >= i ? Math.Min(len[2 * p - i], maxn - i) : 0;
                while (tmp[i - len[i] - 1] == tmp[i + len[i] + 1])
                {
                    len[i]++;
                }
                if (i + len[i] > maxn)
                {
                    p = i;
                    maxn = i + len[i];
                }
                if (i - len[i] == 1)
                {
                    ret[(i + len[i]) / 2][0] = 1;
                }
                if (i + len[i] == m - 1)
                {
                    ret[(i - len[i]) / 2][1] = 1;
                }
            }
            return ret;
        }
        #endregion
    }
}
