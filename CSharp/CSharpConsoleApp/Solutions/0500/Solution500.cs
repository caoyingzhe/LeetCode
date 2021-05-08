using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace CSharpConsoleApp.Solutions
{
    class Solution500 : SolutionBase
    {
        /// <summary>
        /// 难易度:
        /// </summary>
        public override Difficulity GetDifficulity() { return Difficulity.Medium; }
        /// <summary>
        /// 关键字:
        /// </summary>
        public override string[] GetKeyWords() { return new string[] { "HashTable" }; }
        /// <summary>
        /// 标签：
        /// </summary>
        public override Tag[] GetTags() { return new Tag[] { Tag.HashTable }; }

        public override bool Test(Stopwatch sw)
        {
            bool isSuccess = true;

            string[] words = new string[] { "Hello", "Alaska", "Dad", "Peace" };
            string[] resultCheck = new string[] {"Alaska","Dad" };

            string[] result = FindWords(words);
            string resultStr = string.Join(",",result);
            isSuccess &= string.Join(",", result) == string.Join(",",resultCheck);

            System.Diagnostics.Debug.Print("Result : " + string.Join(",", result));
            System.Diagnostics.Debug.Print("ResultCheck : " + string.Join(",", resultCheck));
            return isSuccess;
        }

        public string[] FindWords(string[] words)
        {
            Dictionary<char, int> dict = new Dictionary<char, int>();
            string line1 = "qwertyuiop";
            string line2 = "asdfghjkl";
            string line3 = "zxcvbnm";
            for (int i = 0; i < line1.Length; i++)
            {
                dict.Add(line1[i], 1);
                dict.Add(line1[i].ToString().ToUpper()[0], 1);
            }
            for (int i = 0; i < line2.Length; i++)
            {
                dict.Add(line2[i], 2);
                dict.Add(line2[i].ToString().ToUpper()[0], 2);
            }
            for (int i = 0; i < line3.Length; i++)
            {
                dict.Add(line3[i], 3);
                dict.Add(line3[i].ToString().ToUpper()[0], 3);
            }

            List<string> resultList = new List<string>();
            for (int i = 0; i < words.Length; i++)
            {
                string word = words[i];
                if (string.IsNullOrEmpty(word))
                {
                    continue;
                }
                if (dict.ContainsKey(word[0]))
                {
                    int lineNo = dict[word[0]];
                    bool isAdd = true;
                    for (int j = 1; j < word.Length; j++)
                    {
                        if (!dict.ContainsKey(word[j]) || dict[word[j]] != lineNo)
                        {
                            isAdd = false;
                            break;
                        }
                    }
                    if(isAdd)
                        resultList.Add(word);
                }
                else
                {
                    continue;
                }

            }
            return resultList.ToArray();
        }
    }
}
