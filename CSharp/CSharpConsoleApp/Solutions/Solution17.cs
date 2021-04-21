using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpConsoleApp.Solutions
{
    /// <summary>
    /// 电话号码的字母组合
    /// </summary>
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
            Print("isSuccess = {0} \n result ={1} \n anticipated = {2}", isSuccess , string.Join(",", result) , string.Join(",", checkResult));
            return isSuccess;
        }

        public IList<string> LetterCombinations(string digits)
        {
            if (string.IsNullOrEmpty(digits))
                return new List<string>();

            Dictionary<string, List<string>> resultDict = new Dictionary<string, List<string>>();
            Dictionary<char, string> numCharsDict = new Dictionary<char, string>();
            string[] codeCharsArr = new string[] { "abc", "def", "ghi", "jkl", "mno", "pqrs", "tuv", "wxyz"};
            for(int i=2; i<=9; i++)
            {
                numCharsDict.Add(i.ToString()[0], codeCharsArr[i-2]);
            }

            for(int i=0;i<digits.Length;i++)
            {
                char nubmer = digits[i].ToString()[0];

                string preKey = i== 0 ? "" : digits.Substring(0, i);
                string key = digits.Substring(0, i+1);

                
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
