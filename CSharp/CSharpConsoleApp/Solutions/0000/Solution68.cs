using System;
using System.Collections.Generic;
namespace CSharpConsoleApp.Solutions
{
    /*
     * @lc app=leetcode.cn id=68 lang=csharp
     *
     * [68] 文本左右对齐
     *
     * https://leetcode-cn.com/problems/text-justification/description/
     *
     * Category	Difficulty	Likes	Dislikes
     * algorithms	Hard (46.41%)	136	-
     * Tags
     * string
     * 
     * Companies
     * airbnb | facebook | linkedin
     * 
     * Total Accepted:    17.2K
     * Total Submissions: 37K
     * Testcase Example:  '["This", "is", "an", "example", "of", "text", "justification."]\n16'
     *
     * 给定一个单词数组和一个长度 maxWidth，重新排版单词，使其成为每行恰好有 maxWidth 个字符，且左右两端对齐的文本。
     * 
     * 你应该使用“贪心算法”来放置给定的单词；也就是说，尽可能多地往每行中放置单词。必要时可用空格 ' ' 填充，使得每行恰好有 maxWidth 个字符。
     * 
     * 要求尽可能均匀分配单词间的空格数量。如果某一行单词间的空格不能均匀分配，则左侧放置的空格数要多于右侧的空格数。
     * 
     * 文本的最后一行应为左对齐，且单词之间不插入额外的空格。
     * 
     * 说明:
     * 
     * 
     * 单词是指由非空格字符组成的字符序列。
     * 每个单词的长度大于 0，小于等于 maxWidth。
     * 输入单词数组 words 至少包含一个单词。
     * 
     * 
     * 示例:
     * 
     * 输入:
     * words = ["This", "is", "an", "example", "of", "text", "justification."]
     * maxWidth = 16
     * 输出:
     * [
     * "This    is    an",
     * "example  of text",
     * "justification.  "
     * ]
     * 
     * 
     * 示例 2:
     * 输入:
     * words = ["What","must","be","acknowledgment","shall","be"]
     * maxWidth = 16
     * 输出:
     * [
     * "What   must   be",
     * "acknowledgment  ",
     * "shall be        "
     * ]
     * 解释: 注意最后一行的格式应为 "shall be    " 而不是 "shall     be",
     * 因为最后一行应为左对齐，而不是左右两端对齐。       
     * ⁠    第二行同样为左对齐，这是因为这行只包含一个单词。
     * 
     * 
     * 示例 3:
     * 输入:
     * words =
     * ["Science","is","what","we","understand","well","enough","to","explain",
     * "to","a","computer.","Art","is","everything","else","we","do"]
     * maxWidth = 20
     * 输出:
     * [
     * "Science  is  what we",
     * ⁠ "understand      well",
     * "enough to explain to",
     * "a  computer.  Art is",
     * "everything  else  we",
     * "do                  "
     * ]
     * 
     */
    public class Solution68 : SolutionBase
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
        public override Tag[] GetTags() { return new Tag[] { Tag.String }; }

        public override bool Test(System.Diagnostics.Stopwatch sw)
        {
            bool isSuccess = true;

            string[] words; int maxWidth;
            IList<string> result, checkResult;

            //words = new string[] { "Science","is","what","we","understand","well","enough","to","explain", "to","a","computer.","Art","is","everything","else","we","do"};
            //maxWidth = 20;
            //checkResult = new string[] {
            //    "Science  is  what we",
            //     "understand      well",
            //    "enough to explain to",
            //    "a  computer.  Art is",
            //    "everything  else  we",
            //    "do                  "};
            //result = FullJustify(words, maxWidth);
            //isSuccess &= IsListSame(checkResult, result);
            //Print("isSuccess = {0} | result = {1} | anticipated = {2}", isSuccess, (result), (checkResult));

            words = new string[] { "What", "must", "be", "acknowledgment", "shall", "be" };
            maxWidth = 16;
            checkResult = new string[] {
                "What   must   be",
                "acknowledgment  ",
                "shall be        "};
            result = FullJustify(words, maxWidth);
            isSuccess &= IsListSame(checkResult, result);
            Print("isSuccess = {0} | result = {1} | anticipated = {2}", isSuccess, (result), (checkResult));

            return isSuccess;
        }

        /// <summary>
        /// 27/27 cases passed (264 ms)
        /// Your runtime beats 100 % of csharp submissions
        /// Your memory usage beats 100 % of csharp submissions(30.1 MB)
        /// 作者：moranliuli
        /// 链接：https://leetcode-cn.com/problems/text-justification/solution/java-ke-du-xing-zui-hao-de-dai-ma-by-mor-7hoz/
        /// 该问题需要求出最少行树。
        /// 该问题不能使用逐行逐个单词添加的方法。
        /// 所以有可能造成第一行很紧凑，第二行很宽松，最终结果比最优解多出一行以上的可能；
        /// </summary>
        /// <param name="words"></param>
        /// <param name="maxWidth"></param>
        /// <returns></returns>
        public IList<string> FullJustify(string[] words, int maxWidth)
        {
            // 先缓存好0 - maxWidth 个空格的空格字符串
            System.Text.StringBuilder s = new System.Text.StringBuilder();
            string[] spaces = new string[maxWidth];
            for (int i = 0; i < maxWidth; i++)
            {
                spaces[i] = s.ToString();
                s.Append(" ");
            }
            List<string> ans = new List<string>();
            int currentLen = 0; // 当前长度
            List<string> currentLineWords = new List<string>(); // 当前行的单词
            for (int i = 0; i < words.Length; i++)
            {
                string word = words[i];
                // 当前单词和一个空格的长度，因为至少一个空格
                int currenWordWithSingleSpaceLength = word.Length + 1;
                // 这里 -1 因为最后一个单词不需要空格
                if (currenWordWithSingleSpaceLength + currentLen - 1 > maxWidth)
                {
                    // 处理当前行的单词
                    processCurrentLine(ans, currentLineWords, spaces, maxWidth);
                    currentLineWords.Clear();   // 清空，即转到下一行
                    currentLen = 0; // 清空当前长度
                }
                currentLen += currenWordWithSingleSpaceLength;  // 累计单词长度
                currentLineWords.Add(word); // 添加单词
            }
            // 当前 List 里面可能还有剩余的单词
            processCurrentLine(ans, currentLineWords, spaces, maxWidth);
            // 处理最后一行
            string ss = ans[ans.Count - 1];
            ans.RemoveAt(ans.Count - 1); // 先删除
            //ss = ss.Replace("\\s+", " ");    // 将空格改成单空格，
            ss = UpdateLastLine(ss);
            ans.Add(ss + spaces[maxWidth - ss.Length]);   // 添加，但不要忘记补齐
            return ans;
        }

        public string UpdateLastLine(string s)
        {
            int n = s.Length;
            while (s.Contains("  "))
            {
                s = s.Replace("  ", " ");
            }
            int m = s.Length;
            for (int i = 0; i < m - n; i++)
            {
                s += " ";
            }
            return s;
        }

        public void processCurrentLine(
            List<string> ans,
            List<string> currentLineWords,
            string[] spaces,
            int maxWidth)
        {
            if (currentLineWords.Count == 1)
            {
                string word = currentLineWords[0];
                ans.Add(word + spaces[maxWidth - word.Length]);
            }
            else
            {
                int wordsLength = 0;    // 单词长度
                                        // 累计当前行长度
                foreach (string word in currentLineWords)
                {
                    wordsLength += word.Length;
                }
                int spaceNumber = maxWidth - wordsLength;   // 空格数
                int gap = (spaceNumber) / (currentLineWords.Count - 1);    // 间隙
                string[] spaceWords = new string[currentLineWords.Count - 1];
                // 多余的空格数
                int left = spaceNumber - (gap * (currentLineWords.Count - 1));
                System.Text.StringBuilder sb = new System.Text.StringBuilder();
                for (int j = 0; j < currentLineWords.Count; j++)
                {
                    string word = currentLineWords[j];
                    if (j == currentLineWords.Count - 1)
                    {
                        sb.Append(word); // 最后一行不需要空格
                    }
                    else
                    {
                        // 如果在多余的空格下标前就 + 1
                        sb.Append(word).Append((j < left ? spaces[gap + 1] : spaces[gap]));
                    }
                }
                ans.Add(sb.ToString());
            }
        }
    }
}
