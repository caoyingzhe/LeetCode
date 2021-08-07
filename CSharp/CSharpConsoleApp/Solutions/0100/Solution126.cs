using System;
using System.Collections.Generic;
namespace CSharpConsoleApp.Solutions
{
    /*
     * @lc app=leetcode.cn id=126 lang=csharp
     *
     * [126] 单词接龙 II
     *
     * https://leetcode-cn.com/problems/word-ladder-ii/description/
     *
     * Category	Difficulty	Likes	Dislikes
     * algorithms	Hard (38.63%)	430	-
     * Tags
     * array | string | backtracking | breadth-first-search
     * 
     * Companies
     * amazon | yelp
     * 
     * Total Accepted:    32.2K
     * Total Submissions: 83.4K
     * Testcase Example:  '"hit"\n"cog"\n["hot","dot","dog","lot","log","cog"]'
     *
     * 按字典 wordList 完成从单词 beginWord 到单词 endWord 转化，一个表示此过程的 转换序列 是形式上像 beginWord ->
     * s1 -> s2 -> ... -> sk 这样的单词序列，并满足：
     * 
     * 每对相邻的单词之间仅有单个字母不同。
     * 转换过程中的每个单词 si（1 ）必须是字典 wordList 中的单词。注意，beginWord 不必是字典 wordList 中的单词。
     * sk == endWord
     * 
     * 给你两个单词 beginWord 和 endWord ，以及一个字典 wordList 。请你找出并返回所有从 beginWord 到 endWord
     * 的 最短转换序列 ，如果不存在这样的转换序列，返回一个空列表。每个序列都应该以单词列表 [beginWord, s1, s2, ..., sk]
     * 的形式返回。
     * 
     * 
     * 示例 1：
     * 输入：beginWord = "hit", endWord = "cog", wordList =
     * ["hot","dot","dog","lot","log","cog"]
     * 输出：[["hit","hot","dot","dog","cog"],["hit","hot","lot","log","cog"]]
     * 解释：存在 2 种最短的转换序列：
     * "hit" -> "hot" -> "dot" -> "dog" -> "cog"
     * "hit" -> "hot" -> "lot" -> "log" -> "cog"
     * 
     * 
     * 示例 2：
     * 输入：beginWord = "hit", endWord = "cog", wordList =
     * ["hot","dot","dog","lot","log"]
     * 输出：[]
     * 解释：endWord "cog" 不在字典 wordList 中，所以不存在符合要求的转换序列。
     *
     * 
     * 提示：
     * 1 
     * endWord.length == beginWord.length
     * 1 
     * wordList[i].length == beginWord.length
     * beginWord、endWord 和 wordList[i] 由小写英文字母组成
     * beginWord != endWord
     * wordList 中的所有单词 互不相同
     */


    public class Solution126 : SolutionBase
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

            beginWord = "hit"; endWord = "cog";
            wordList = new string[] { "hot", "dot", "dog", "lot", "log", "cog" };
            checkResult = new string[][] {
                new string[] {"hit","hot","dot","dog","cog" },
                new string[] {"hit","hot","lot","log","cog"},
            };
            result = FindLadders(beginWord, endWord, wordList);
            isSuccess &= IsArray2DSame<string>(result, checkResult);
            Print("isSuccess = {0} | result= {1} | checkResult= {2} | ", isSuccess, GetArray2DStr(result), GetArray2DStr(checkResult));
            return isSuccess;
        }

        //作者：LeetCode-Solution
        //链接：https://leetcode-cn.com/problems/word-ladder-ii/solution/dan-ci-jie-long-ii-by-leetcode-solution/

        /// <summary>
        /// 32/32 cases passed (316 ms)
        /// Your runtime beats 85.71 % of csharp submissions
        /// Your memory usage beats 92.86 % of csharp submissions(33.3 MB)
        /// </summary>
        /// <param name="beginWord"></param>
        /// <param name="endWord"></param>
        /// <param name="wordList"></param>
        /// <returns></returns>
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
