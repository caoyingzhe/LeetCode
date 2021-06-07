using System;
using System.Collections.Generic;
namespace CSharpConsoleApp.Solutions
{
    /*
     * @lc app=leetcode.cn id=127 lang=csharp
     *
     * [127] 单词接龙
     *
     * https://leetcode-cn.com/problems/word-ladder/description/
     *
     * Category	Difficulty	Likes	Dislikes
     * algorithms	Hard (46.39%)	776	-
     * Tags
     * breadth-first-search
     * 
     * Companies
     * amazon | facebook | linkedin | snapchat | yelp
     * 
     * Total Accepted:    110K
     * Total Submissions: 237.1K
     * Testcase Example:  '"hit"\n"cog"\n["hot","dot","dog","lot","log","cog"]'
     *
     * 字典 wordList 中从单词 beginWord 和 endWord 的 转换序列 是一个按下述规格形成的序列：
     * 
     * 
     * 序列中第一个单词是 beginWord 。
     * 序列中最后一个单词是 endWord 。
     * 每次转换只能改变一个字母。
     * 转换过程中的中间单词必须是字典 wordList 中的单词。
     * 
     * 
     * 给你两个单词 beginWord 和 endWord 和一个字典 wordList ，找到从 beginWord 到 endWord 的 最短转换序列
     * 中的 单词数目 。如果不存在这样的转换序列，返回 0。
     * 
     * 
     * 示例 1：
     * 输入：beginWord = "hit", endWord = "cog", wordList =
     * ["hot","dot","dog","lot","log","cog"]
     * 输出：5
     * 解释：一个最短转换序列是 "hit" -> "hot" -> "dot" -> "dog" -> "cog", 返回它的长度 5。
     * 
     * 
     * 示例 2：
     * 输入：beginWord = "hit", endWord = "cog", wordList =
     * ["hot","dot","dog","lot","log"]
     * 输出：0
     * 解释：endWord "cog" 不在字典中，所以无法进行转换。
     * 
     * 
     * 提示：
     * 1 <= beginWord.length <= 10
     * endWord.length == beginWord.length
     * 1 <= wordList.length <= 5000
     * wordList[i].length == beginWord.length
     * beginWord、endWord 和 wordList[i] 由小写英文字母组成
     * beginWord != endWord
     * wordList 中的所有字符串 互不相同
     */

    // @lc code=start
    public class Solution127 : SolutionBase
    {
        /// <summary>
        /// 难度
        /// </summary>
        public override Difficulity GetDifficulity() { return Difficulity.Hard; }
        /// <summary>
        /// 关键字:
        /// </summary>
        public override string[] GetKeyWords() { return new string[] { }; }
        /// <summary>
        /// 标签：
        /// </summary>
        public override Tag[] GetTags() { return new Tag[] { Tag.Array, Tag.String, Tag.Backtracking, Tag.BreadthFirstSearch }; }

        public override bool Test(System.Diagnostics.Stopwatch sw)
        {
            bool isSuccess = true;
            string beginWord; string endWord; IList<string> wordList;
            IList<IList<string>> result, checkResult;
            int resultLen, checkResultLen;

            beginWord = "hit"; endWord = "cog";
            wordList = new string[] { "hot", "dot", "dog", "lot", "log", "cog" };
            checkResult = new string[][] {
                new string[] {"hit","hot","dot","dog","cog" },
                new string[] {"hit","hot","lot","log","cog"},
            };
            checkResultLen = 5;
            resultLen = LadderLength(beginWord, endWord, wordList);
            isSuccess &= resultLen == checkResultLen;
            Print("isSuccess = {0} | result= {1} | checkResult= {2} | ", isSuccess, resultLen, checkResultLen);
            return isSuccess;
        }
        /// <summary>
        /// 本解答直接基于126的列表结果，返回第一个元素的长度。没有任何优化。
        /// 
        /// 49/49 cases passed (584 ms)
        /// Your runtime beats 29.63 % of csharp submissions
        /// Your memory usage beats 37.04 % of csharp submissions(33.5 MB)
        /// </summary>
        /// <param name="beginWord"></param>
        /// <param name="endWord"></param>
        /// <param name="wordList"></param>
        /// <returns></returns>
        public int LadderLength(string beginWord, string endWord, IList<string> wordList)
        {
            var rtn = FindLadders(beginWord, endWord, wordList);
            return rtn.Count > 0 ? rtn[0].Count : 0;
        }

        //作者：LeetCode-Solution
        //链接：https://leetcode-cn.com/problems/word-ladder-ii/solution/dan-ci-jie-long-ii-by-leetcode-solution/
        public IList<IList<string>> FindLadders(string beginWord, string endWord, IList<string> wordList)
        {
            List<IList<string>> res = new List<IList<string>>();
            // 因为需要快速判断扩展出的单词是否在 wordList 里，因此需要将 wordList 存入哈希表，这里命名为「字典」
            HashSet<string> dict = new HashSet<string>(wordList);
            // 特殊用例判断
            if (!dict.Contains(endWord))
            {
                return res;
            }
            dict.Remove(beginWord);

            // 第 1 步：广度优先遍历建图
            // 记录扩展出的单词是在第几次扩展的时候得到的，key：单词，value：在广度优先遍历的第几层
            Dictionary<string, int> steps = new Dictionary<string, int>();
            steps.Add(beginWord, 0);
            // 记录了单词是从哪些单词扩展而来，key：单词，value：单词列表，这些单词可以变换到 key ，它们是一对多关系
            Dictionary<string, List<string>> from = new Dictionary<string, List<string>>();
            int step = 1;
            bool found = false;
            int wordLen = beginWord.Length;
            Queue<string> queue = new Queue<string>();
            queue.Enqueue(beginWord);
            while (queue.Count != 0)
            {
                int size = queue.Count;
                for (int i = 0; i < size; i++)
                {
                    string currWord = queue.Dequeue();
                    char[] charArray = currWord.ToCharArray();
                    // 将每一位替换成 26 个小写英文字母
                    for (int j = 0; j < wordLen; j++)
                    {
                        char origin = charArray[j];
                        for (char c = 'a'; c <= 'z'; c++)
                        {
                            charArray[j] = c;
                            string nextWord = new string(charArray);
                            if (steps.ContainsKey(nextWord) && step == steps[nextWord])
                            {
                                from[nextWord].Add(currWord);
                            }
                            if (!dict.Contains(nextWord))
                            {
                                continue;
                            }
                            // 如果从一个单词扩展出来的单词以前遍历过，距离一定更远，为了避免搜索到已经遍历到，且距离更远的单词，需要将它从 dict 中删除
                            dict.Remove(nextWord);
                            // 这一层扩展出的单词进入队列
                            queue.Enqueue(nextWord);

                            // 记录 nextWord 从 currWord 而来
                            if (!from.ContainsKey(nextWord))
                                from.Add(nextWord, new List<string>());
                            from[nextWord].Add(currWord);
                            // 记录 nextWord 的 step
                            steps.Add(nextWord, step);
                            if (nextWord.Equals(endWord))
                            {
                                found = true;
                            }
                        }
                        charArray[j] = origin;
                    }
                }
                step++;
                if (found)
                {
                    break;
                }
            }

            // 第 2 步：深度优先遍历找到所有解，从 endWord 恢复到 beginWord ，所以每次尝试操作 path 列表的头部
            if (found)
            {
                LinkedList<string> path = new LinkedList<string>();
                path.AddLast(endWord);
                DFS(from, path, beginWord, endWord, res);
            }
            return res;
        }

        public void DFS(Dictionary<string, List<string>> from, LinkedList<string> path, string beginWord, string cur, List<IList<string>> res)
        {
            if (cur.Equals(beginWord))
            {
                res.Add(new List<string>(path));
                return;
            }
            foreach (string precursor in from[cur])
            {
                path.AddFirst(precursor);
                DFS(from, path, beginWord, precursor, res);
                path.RemoveFirst();
            }
        }
    }
}
