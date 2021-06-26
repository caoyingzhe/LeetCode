using System;
namespace CSharpConsoleApp.Solutions
{
    /*
 * @lc app=leetcode.cn id=468 lang=csharp
 *
 * [468] 验证IP地址
 *
 * https://leetcode-cn.com/problems/validate-ip-address/description/
 *
 * Category	Difficulty	Likes	Dislikes
 * algorithms	Medium (24.31%)	93	-
 * Tags
 * string
 * 
 * Companies
 * twitter
 * 
 * Total Accepted:    20.2K
 * Total Submissions: 83.2K
 * Testcase Example:  '"172.16.254.1"'
 *
 * 编写一个函数来验证输入的字符串是否是有效的 IPv4 或 IPv6 地址。
 * 
 * 如果是有效的 IPv4 地址，返回 "IPv4" ；
 * 如果是有效的 IPv6 地址，返回 "IPv6" ；
 * 如果不是上述类型的 IP 地址，返回 "Neither" 。
 * 
 * IPv4 地址由十进制数和点来表示，每个地址包含 4 个十进制数，其范围为 0 - 255， 用(".")分割。比如，172.16.254.1；
 * 同时，IPv4 地址内的数不会以 0 开头。比如，地址 172.16.254.01 是不合法的。
 * 
 * IPv6 地址由 8 组 16 进制的数字来表示，每组表示 16 比特。这些组数字通过 (":")分割。比如,
 * 2001:0db8:85a3:0000:0000:8a2e:0370:7334 是一个有效的地址。而且，我们可以加入一些以 0
 * 开头的数字，字母可以使用大写，也可以是小写。所以， 2001:db8:85a3:0:0:8A2E:0370:7334 也是一个有效的 IPv6
 * address地址 (即，忽略 0 开头，忽略大小写)。
 * 
 * 然而，我们不能因为某个组的值为 0，而使用一个空的组，以至于出现 (::) 的情况。 比如，
 * 2001:0db8:85a3::8A2E:0370:7334 是无效的 IPv6 地址。
 * 
 * 同时，在 IPv6 地址中，多余的 0 也是不被允许的。比如， 02001:0db8:85a3:0000:0000:8a2e:0370:7334
 * 是无效的。
 * 
 * 
 * 示例 1：
 * 输入：IP = "172.16.254.1"
 * 输出："IPv4"
 * 解释：有效的 IPv4 地址，返回 "IPv4"
 * 
 * 
 * 示例 2：
 * 输入：IP = "2001:0db8:85a3:0:0:8A2E:0370:7334"
 * 输出："IPv6"
 * 解释：有效的 IPv6 地址，返回 "IPv6"
 * 
 * 
 * 示例 3：
 * 输入：IP = "256.256.256.256"
 * 输出："Neither"
 * 解释：既不是 IPv4 地址，又不是 IPv6 地址
 * 
 * 
 * 示例 4：
 * 输入：IP = "2001:0db8:85a3:0:0:8A2E:0370:7334:"
 * 输出："Neither"
 * 
 * 
 * 示例 5：
 * 输入：IP = "1e1.4.5.6"
 * 输出："Neither"
 * 
 * 
 * 提示：
 * IP 仅由英文字母，数字，字符 '.' 和 ':' 组成。
 * 
 * 
 */

    // @lc code=start
    public class Solution468 : SolutionBase
    {
        /// <summary>
        /// 难度
        /// </summary>
        public override Difficulity GetDifficulity() { return Difficulity.Medium; }
        /// <summary>
        /// 关键字:
        /// </summary>
        public override string[] GetKeyWords() { return new string[] { "" }; }
        /// <summary>
        /// 标签：
        /// </summary>
        public override Tag[] GetTags() { return new Tag[] { Tag.TwoPointers, Tag.SlidingWindow }; }

        public override bool Test(System.Diagnostics.Stopwatch sw)
        {
            bool isSuccess = true;
            string s;

            string result, checkResult;

            //s = "001.16.254.1";
            //checkResult = "Neither";
            //result = ValidIPAddress(s);
            //isSuccess &= IsSame(result, checkResult);
            //Print(s); PrintResult(isSuccess, (result), (checkResult));

            //s = "172.16.254.1";
            //checkResult = "IPv4";
            //result = ValidIPAddress(s);
            //isSuccess &= IsSame(result, checkResult);
            //Print(s); PrintResult(isSuccess, (result), (checkResult));

            s = "192.0.0.1";
            checkResult = "IPv4";
            result = ValidIPAddress(s);
            isSuccess &= IsSame(result, checkResult);
            Print(s); PrintResult(isSuccess, (result), (checkResult));

            //s = "20EE:FGb8:85a3:0:0:8A2E:0370:7334";
            //checkResult = "Neither";
            //result = ValidIPAddress(s);
            //isSuccess &= IsSame(result, checkResult);
            //Print(s); PrintResult(isSuccess, (result), (checkResult));

            ////NG: 00000
            //s = "2001:0db8:85a3:00000:0:8A2E:0370:7334";
            //checkResult = "Neither";
            //result = ValidIPAddress(s);
            //isSuccess &= IsSame(result, checkResult);
            //Print(s); PrintResult(isSuccess, (result), (checkResult));

            //s = "2001:0000:85a3:0:0:8A2E:0370:7334";
            //checkResult = "IPv6";
            //result = ValidIPAddress(s);
            //isSuccess &= IsSame(result, checkResult);
            //Print(s); PrintResult(isSuccess, (result), (checkResult));

            //s = "2001:0db8:85a3:0:0:8A2E:0370:7334";
            //checkResult = "IPv6";
            //result = ValidIPAddress(s);
            //isSuccess &= IsSame(result, checkResult);
            //Print(s); PrintResult(isSuccess, (result), (checkResult));

            //s = "256.256.256.256";
            //checkResult = "Neither";
            //result = ValidIPAddress(s);
            //isSuccess &= IsSame(result, checkResult);
            //Print(s); PrintResult(isSuccess, (result), (checkResult));

            //s = "2001:0db8:85a3:0:0:8A2E:0370:7334:";
            //checkResult = "Neither";
            //result = ValidIPAddress(s);
            //isSuccess &= IsSame(result, checkResult);
            //Print(s); PrintResult(isSuccess, (result), (checkResult));

            //s = "1e1.4.5.6";
            //checkResult = "Neither";
            //result = ValidIPAddress(s);
            //isSuccess &= IsSame(result, checkResult);
            //Print(s);PrintResult(isSuccess, (result), (checkResult));

            return isSuccess;


        }

        /// <summary>
        /// Accepted
        /// 73/73 cases passed(100 ms)
        /// Your runtime beats 88.89 % of csharp submissions
        /// Your memory usage beats 22.22 % of csharp submissions(23.8 MB)
        /// </summary>
        /// <param name="IP"></param>
        /// <returns></returns>
        public string ValidIPAddress(string IP)
        {
            bool isOK1 = IsBit16X4("FGb8");
            Print("isOK : {0} | {1}", isOK1, "FGb8");

            bool isContainsDot = IP.Contains(".");
            bool isContainsComma = IP.Contains(":");
            if(isContainsDot && isContainsComma)
                return "Neither";

            if(isContainsDot)
            {
                string[] arr = IP.Split('.');
                if(arr.Length == 4)
                {
                    for(int i=0; i<4; i++)
                    {
                        //bool isOK = IsBit10X3(arr[i]);
                        //Print("isOK : {0} | {1}", isOK, arr[i]);

                        if (IsBit10X3(arr[i]))
                        {
                            if(i==3)
                                return "IPv4";
                        }
                        else
                            break;
                    }
                }
            }
            else if(isContainsComma)
            {
                string[] arr = IP.Split(':');
                if (arr.Length == 8)
                {
                    for (int i = 0; i < 8; i++)
                    {
                        bool isOK = IsBit16X4(arr[i]);
                        Print("isOK : {0} | {1}", isOK, arr[i]);
                        if (IsBit16X4(arr[i]))
                        {
                            if (i == 7)
                                return "IPv6";
                        }
                        else
                            break;
                    }
                }
            }
            return "Neither";
        }

        //是否为IP6的有效数字
        public bool IsBit16X4(string s)
        {
            if (s == null) return false;
            int n = s.Length;
            if (n > 4 || n == 0) return false;
            //if (s.StartsWith("0") && n > 1) return false;
            //if (s == "00" || s == "000" || s == "0000") return false;

            for (int i = 0; i < n; i++)
            {
                if ((s[i] - '0' >= 0 && s[i] - '0' <= 9) ||
                    (s[i] - 'a' >= 0 && s[i] - 'a' <= 5) ||
                    (s[i] - 'A' >= 0 && s[i] - 'A' <= 5))
                {
                    if (i == n - 1)
                        return true;
                }
                else
                    break;
            }
            return false;
        }

        //是否为IP4的有效数字
        public bool IsBit10X3(string s, int maxVal = 255)
        {
            if (s == null) return false;
            int n = s.Length;
            if (n > 3 || n == 0) return false;
            if (s.StartsWith("0") && n > 1) return false;

            int val = 0;
            for (int i = 0; i < n; i++)
            {
                if ((s[i] - '0' >= 0 && s[i] - '0' <= 9))
                {
                    val = val * 10 + s[i] - '0';
                    if (i == n - 1 && val <= maxVal)
                        return true;
                }
                else
                    break;
            }
            return false;
        }
    }
    // @lc code=end


}
