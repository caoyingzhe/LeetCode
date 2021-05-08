using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrieNode = CSharpConsoleApp.Solutions.SolutionBase.TrieNode<char>;
namespace CSharpConsoleApp.Solutions
{
    /// <summary>
    /// [212] 单词搜索 II
    /// 
    /// 给定一个 m x n 二维字符网格 board 和一个单词（字符串）列表 words，
    /// 找出所有同时在二维网格和字典中出现的单词。
    /// 
    /// 单词必须按照字母顺序，通过 相邻的单元格 内的字母构成，
    /// 其中“相邻”单元格是那些水平相邻或垂直相邻的单元格。
    /// 同一个单元格内的字母在一个单词中不允许被重复使用。
    /// 
    /// 输入：board = [["o","a","a","n"],["e","t","a","e"],["i","h","k","r"],["i","f","l","v"]], words = ["oath","pea","eat","rain"]
    /// 输出：["eat","oath"]
    /// 
    /// 输入：board = [["a","b"],["c","d"]], words = ["abcb"]
    /// 输出：[]
    /// </summary>
    class Solution212 : SolutionBase
    {
        /// <summary>
        /// 难度
        /// </summary>
        public override Difficulity GetDifficulity() { return Difficulity.Hard; }
        /// <summary>
        /// 关键字:
        /// </summary>
        public override string[] GetKeyWords() { return new string[] { "二叉搜索树迭代器类", "BSTIterator", "设计", "按中序遍历", "BST" }; }
        /// <summary>
        /// 标签： 
        /// </summary>
        public override Tag[] GetTags() { return new Tag[] { Tag.Trie, Tag.Backtracking,}; }

        public override bool Test(System.Diagnostics.Stopwatch sw)
        {
            bool isSuccess = true;
            char[][] board = null;
            string[] words = null;
            IList<string> result = null;
            string[] checkResult = null;

            board = new char[][] {
                new char[] {'o','a','a','n'},
                new char[] {'e','t','a','e'},
                new char[] {'i','h','k','r'},
                new char[] {'i','f','l','v'} };

            words = new string[]{ "oath", "pea", "eat", "rain" };
            checkResult = new string[] { "eat","oath"};
            result = FindWords(board, words);

            isSuccess &= (IsListSame(result, checkResult));
            return isSuccess;
        }

        char[][] _board = null;
        List<String> _result = new List<String>();

        public IList<string> FindWords(char[][] board, string[] words)
        {
            //1. 对words构建前缀表数据结构
            TrieNode root = new TrieNode();
            foreach (string word in words)
            {
                TrieNode node = root; //根节点

                foreach (char letter in word.ToCharArray())
                {
                    if (node.children.ContainsKey(letter))
                    {
                        node = node.children[letter];
                    }
                    else
                    {
                        TrieNode newNode = new TrieNode();
                        node.children.Add(letter, newNode);
                        node = newNode;
                    }
                }
                node.word = word;  // store words in Trie
            }

            this._board = board;
            // Step 2). Backtracking starting for each cell in the board
            for (int row = 0; row < board.Length; ++row)
            {
                for (int col = 0; col < board[row].Length; ++col)
                {
                    if (root.children.ContainsKey(board[row][col]))
                    {
                        //发现前缀表中有对应字符，直接进行回溯匹配其他字符。参数为 行索引 + 列索引 + 前缀表
                        //返回结果为全局变量。
                        Backtracking(row, col, root);
                    }
                }
            }
            return this._result;
        }

        private void Backtracking(int row, int col, TrieNode parent)
        {
            char letter = this._board[row][col];
            TrieNode currNode = parent.children[letter];

            // check if there is any match
            if (currNode.word != null)
            {
                this._result.Add(currNode.word);
                currNode.word = null;
            }

            // mark the current letter before the EXPLORATION
            this._board[row][col] = '#';

            // explore neighbor cells in around-clock directions: up, right, down, left
            int[] rowOffset = { -1, 0, 1, 0 };
            int[] colOffset = { 0, 1, 0, -1 };
            for (int i = 0; i < 4; ++i)
            {
                int newRow = row + rowOffset[i];
                int newCol = col + colOffset[i];
                if (newRow < 0 || newRow >= this._board.Length || newCol < 0
                    || newCol >= this._board[0].Length)
                {
                    continue;
                }
                if (currNode.children.ContainsKey(this._board[newRow][newCol]))
                {
                    Backtracking(newRow, newCol, currNode);
                }
            }

            // End of EXPLORATION, restore the original letter in the board.
            this._board[row][col] = letter;

            // Optimization: incrementally remove the leaf nodes
            if (currNode.children.Count == 0)
            {
                parent.children.Remove(letter);
            }
        }
    }
}
