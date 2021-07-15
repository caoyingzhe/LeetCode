using System;
namespace CSharpConsoleApp.Solutions
{
    /*
     * @lc app=leetcode.cn id=1108 lang=csharp
     *
     * [1108] IP 地址无效化
     *
     * https://leetcode-cn.com/problems/defanging-an-ip-address/description/
     *
     * algorithms
     * Easy (83.90%)
     * Likes:    67
     * Dislikes: 0
     * Total Accepted:    64.7K
     * Total Submissions: 77.1K
     * Testcase Example:  '"1.1.1.1"'
     *
     * 给你一个有效的 IPv4 地址 address，返回这个 IP 地址的无效化版本。
     * 
     * 所谓无效化 IP 地址，其实就是用 "[.]" 代替了每个 "."。
     * 
     * 
     * 示例 1：
     * 输入：address = "1.1.1.1"
     * 输出："1[.]1[.]1[.]1"
     * 
     * 
     * 示例 2：
     * 输入：address = "255.100.50.0"
     * 输出："255[.]100[.]50[.]0"
     * 
     * 
     * 提示：
     * 给出的 address 是一个有效的 IPv4 地址
     */

    // @lc code=start
    public class Solution1108
    {
        /// 无聊的题目

        /// <summary>
        /// 62/62 cases passed (96 ms)
        /// Your runtime beats 73.26 % of csharp submissions
        /// Your memory usage beats 18.6 % of csharp submissions(23 MB)
        /// </summary>
        /// <param name="address"></param>
        /// <returns></returns>
        public string DefangIPaddr(string address)
        {
            return address.Replace(".", "[.]");
        }
    }
    // @lc code=end


}
