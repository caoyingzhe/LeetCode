using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpConsoleApp.Solutions
{
    /*
    * @lc app=leetcode.cn id=17 lang=csharp
    * 
    * [17] 电话号码的字母组合
    * 
    * Category	Difficulty	Likes	Dislikes
    * algorithms	Medium (56.27%)	1212	-
    * Tags
    * string | backtracking
    * 
    * Companies
    * amazon | dropbox | facebook | google | uber
    * 
    * 给定一个仅包含数字 2-9 的字符串，返回所有它能表示的字母组合。答案可以按 任意顺序 返回。
    * 
    * 给出数字到字母的映射如下（与电话按键相同）。注意 1 不对应任何字母。
    * 
    * 示例 1：
    * 输入：digits = "23"
    * 输出：["ad","ae","af","bd","be","bf","cd","ce","cf"]
    * 
    * 示例 2：
    * 输入：digits = ""
    * 输出：[]
    * 
    * 示例 3：
    * 输入：digits = "2"
    * 输出：["a","b","c"]
    * 
    * 提示：
    * 0 <= digits.length <= 4
    * digits[i] 是范围 ['2', '9'] 的一个数字。
    * 
    */
    class Solution17 : SolutionBase
    {

        /// <summary>
        /// 难度
        /// </summary>
        public override Difficulity GetDifficulity() { return Difficulity.Medium; }
        /// <summary>
        /// 关键字:
        /// </summary>
        public override string[] GetKeyWords() { return new string[] { "Not Medium, 暴力写法很无聊" }; }
        /// <summary>
        /// 标签： 
        /// </summary>
        public override Tag[] GetTags() { return new Tag[] { Tag.Backtracking }; }
        public override bool Test(System.Diagnostics.Stopwatch sw)
        {
            bool isSuccess = true;
            string digits = "";
            List<string> checkResult, result;

            digits = "23";
            checkResult = new List<string>(new string[] { "ad", "ae", "af", "bd", "be", "bf", "cd", "ce", "cf" });
            result = LetterCombinations(digits) as List<string>;

            //排序后比较，避免排序不同内容相同误判。
            checkResult.Sort();
            result.Sort();

            isSuccess &= string.Join(",", result) == string.Join(",", checkResult);
            Print("isSuccess = {0} \n result ={1} \n anticipated = {2}", isSuccess, string.Join(",", result), string.Join(",", checkResult));
            return isSuccess;
        }

        public IList<string> LetterCombinations(string digits)
        {
            if (string.IsNullOrEmpty(digits))
                return new List<string>();

            Dictionary<string, List<string>> resultDict = new Dictionary<string, List<string>>();
            Dictionary<char, string> numCharsDict = new Dictionary<char, string>();
            string[] codeCharsArr = new string[] { "abc", "def", "ghi", "jkl", "mno", "pqrs", "tuv", "wxyz" };
            for (int i = 2; i <= 9; i++)
            {
                numCharsDict.Add(i.ToString()[0], codeCharsArr[i - 2]);
            }

            for (int i = 0; i < digits.Length; i++)
            {
                char nubmer = digits[i].ToString()[0];

                string preKey = i == 0 ? "" : digits.Substring(0, i);
                string key = digits.Substring(0, i + 1);


                if (resultDict.ContainsKey(preKey))
                {
                    List<string> preKeyList = resultDict[preKey];
                    for (int j = 0; j < numCharsDict[nubmer].Length; j++)
                    {
                        List<string> addList = null;
                        if (j == 0)
                        {
                            addList = new List<string>();

                            resultDict.Add(key, addList);
                        }
                        else
                        {
                            addList = resultDict[key];
                        }

                        foreach (string preValue in preKeyList)
                        {
                            addList.Add(preValue + numCharsDict[nubmer][j]);
                        }
                    }
                    resultDict.Remove(preKey);
                }
                else
                {
                    List<string> addList = new List<string>();
                    for (int j = 0; j < numCharsDict[nubmer].Length; j++)
                    {
                        addList.Add("" + numCharsDict[nubmer][j]);
                    }
                    resultDict.Add(key, addList);
                }
            }

            List<string> result = new List<string>();
            foreach (List<string> value in resultDict.Values)
                result.AddRange(value);
            return result;
        }
    }
}
