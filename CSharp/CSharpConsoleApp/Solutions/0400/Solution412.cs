using System;
using System.Collections.Generic;
namespace CSharpConsoleApp.Solutions
{
    /*
     * @lc app=leetcode.cn id=412 lang=csharp
     *
     * [412] Fizz Buzz
     *
     * https://leetcode-cn.com/problems/fizz-buzz/description/
     *
     * algorithms
     * Easy (66.72%)
     * Likes:    99
     * Dislikes: 0
     * Total Accepted:    66.7K
     * Total Submissions: 99.8K
     * Testcase Example:  '3'
     *
     * 写一个程序，输出从 1 到 n 数字的字符串表示。
     * 1. 如果 n 是3的倍数，输出“Fizz”；
     * 2. 如果 n 是5的倍数，输出“Buzz”；
     * 3.如果 n 同时是3和5的倍数，输出 “FizzBuzz”。
     * 
     * 示例：
     * n = 15,
     * 返回:
     * [
     * ⁠   "1",
     * ⁠   "2",
     * ⁠   "Fizz",
     * ⁠   "4",
     * ⁠   "Buzz",
     * ⁠   "Fizz",
     * ⁠   "7",
     * ⁠   "8",
     * ⁠   "Fizz",
     * ⁠   "Buzz",
     * ⁠   "11",
     * ⁠   "Fizz",
     * ⁠   "13",
     * ⁠   "14",
     * ⁠   "FizzBuzz"
     * ]
     */

    // @lc code=start
    public class Solution412
    {
        //无聊的题目
        public IList<string> FizzBuzz(int n)
        {
            string[] result = new string[n];
            for (int i = 1; i <= n; i++)
                result[i - 1] = (i % 3 == 0 && i % 5 == 0) ? "FizzBuzz" : (i % 5 == 0) ? "Buzz" : (i % 3 == 0) ? "Fizz" : i.ToString();
            return result;
        }
    }
    // @lc code=end


}
