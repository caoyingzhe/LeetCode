using System;
using System.Text;
using System.Linq;
namespace CSharpConsoleApp.Solutions
{
    /*
 * @lc app=leetcode.cn id=564 lang=csharp
 *
 * [564] 寻找最近的回文数
 *
 * https://leetcode-cn.com/problems/find-the-closest-palindrome/description/
 *
 * Category	Difficulty	Likes	Dislikes
 * algorithms	Hard (17.71%)	92	-
 * Tags
 * string
 * 
 * Companies
 * yelp
 * 
 * Total Accepted:    4.1K
 * Total Submissions: 22.9K
 * Testcase Example:  '"123"'
 *
 * 给定一个整数 n ，你需要找到与它最近的回文数（不包括自身）。
 * 
 * “最近的”定义为两个整数差的绝对值最小。
 * 
 * 示例 1:
 * 输入: "123"
 * 输出: "121"
 * 
 * 注意:
 * n 是由字符串表示的正整数，其长度不超过18。
 * 如果有多个结果，返回最小的那个。
 */

    // @lc code=start
    public class Solution564 : SolutionBase
    {
        /// <summary>
        /// 难易度:
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
            string result, checkResult;
            string n;

            n = "123";
            checkResult = "121";
            result = NearestPalindromic(n);
            isSuccess &= IsSame(result, checkResult);
            PrintResult(isSuccess, (result), (checkResult));

            //1543->15->1551, 13542->135->13531。
            n = "1543";
            checkResult = "1551";
            result = NearestPalindromic(n);
            isSuccess &= IsSame(result, checkResult);
            PrintResult(isSuccess, (result), (checkResult));

            n = "51015";
            checkResult = "51115";
            result = NearestPalindromic(n);
            isSuccess &= IsSame(result, checkResult);
            PrintResult(isSuccess, (result), (checkResult));

            n = "51915";
            checkResult = "51815";
            result = NearestPalindromic(n);
            isSuccess &= IsSame(result, checkResult);
            PrintResult(isSuccess, (result), (checkResult));

            n = "519915";
            checkResult = "520025";
            result = NearestPalindromic(n);
            isSuccess &= IsSame(result, checkResult);
            PrintResult(isSuccess, (result), (checkResult));

            ///999->1001, 1001->999, 1000->999
            n = "999";
            checkResult = "1001";
            result = NearestPalindromic(n);
            isSuccess &= IsSame(result, checkResult);
            PrintResult(isSuccess, (result), (checkResult));

            n = "1001";
            checkResult = "999";
            result = NearestPalindromic(n);
            isSuccess &= IsSame(result, checkResult);
            PrintResult(isSuccess, (result), (checkResult));

            n = "1000";
            checkResult = "999";
            result = NearestPalindromic(n);
            isSuccess &= IsSame(result, checkResult);
            PrintResult(isSuccess, (result), (checkResult));
            return isSuccess;
        }

        //作者：LeetCode
        //链接：https://leetcode-cn.com/problems/find-the-closest-palindrome/solution/xun-zhao-zui-jin-de-hui-wen-shu-by-leetcode/
        public int NearestPalindromic_Violence(int[] nums)
        {
            int res = 0;
            for (int i = 0; i < nums.Length; i++)
            {
                int start = nums[i], count = 0;
                do
                {
                    start = nums[start];
                    count++;
                }
                while (start != nums[i]);

                res = Math.Max(res, count);

            }
            return res;
        }

        //作者：luo - bi - da - quan
        //链接：https://leetcode-cn.com/problems/find-the-closest-palindrome/solution/7xing-shuang-bai-by-luo-bi-da-quan-j37e/
        public string NearestPalindromic_Python(string s)
        {
            char[] nums = s.ToCharArray();
            for (int i = 0; i < nums.Length; i++)
            {
                int num = nums[i] - '0';
            }

            int length = s.Length; long n = long.Parse(s);
            if (n < 10 || n == Math.Pow(10,length - 1))
            {
                return (n - 1).ToString();
            }

            if (n - 1 == Math.Pow(10, length - 1))
            {
                return (n - 2).ToString();
            }
            if (n + 1 == Math.Pow(10, length))
            {
                return (n + 2).ToString();
            }

            //pre = int(n[:(length + 1)//2])
            //tmp = [s[:length//2] + s[::-1] for s in [str(pre + dx) for dx in (-1, 0, 1)]]
            //return min(tmp, key = lambda x: (x == n, abs(int(x) - int_n)))''

            long pre = long.Parse(s.Substring(0, (length + 1) / 2)); // pre = int(s[:(length + 1)/2])



            var rArr = s.Substring(0, length / 2).ToCharArray();
            Array.Reverse(rArr);
            long tmp = long.Parse(new string(rArr));

            //tmp = [s[:length//2] + s[::-1]
            //for s in [str(pre + dx) for dx in (-1, 0, 1)]]
            //return min(tmp, key = lambda x: (x == n, abs(int(x) - int_n)))''
            //g = lambda x:x+1
            //g(1) >>> 2
            //g(2) >>> 3
            foreach (int dx in new int[] { -1, 0, 1 })
            {
                string tmpS = (pre + dx).ToString();
                
                // tmp = [s[:length/2] + s[::-1]
                //return Math.Min(tmp, key = lambda x: (x == s, Math.Abs(int(x) - n)));
                
            }
            return "";
        }

        //作者：don-vito-corleone
        //链接：https://leetcode-cn.com/problems/find-the-closest-palindrome/solution/java-qiu-san-ge-shu-ran-hou-he-yuan-shu-zuo-bi-jia/
        /// <summary>
        /// 215/215 cases passed (104 ms)
        /// Your runtime beats 25 % of csharp submissions
        /// Your memory usage beats 50 % of csharp submissions(23.8 MB)
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public String NearestPalindromic(String n)
        {
            char[] arr = n.ToCharArray();
            for (int i = 0, j = arr.Length - 1; i < j; i++, j--)
            {
                arr[j] = arr[i];
            }
            String cur = new string(arr);
            String pre = nearest(cur, false);
            String next = nearest(cur, true);
            long numl = long.Parse(n);
            long curl = long.Parse(cur);
            long prel = long.Parse(pre);
            long nextl = long.Parse(next);

            long d1 = Math.Abs(numl - prel);
            long d2 = Math.Abs(numl - curl);
            long d3 = Math.Abs(numl - nextl);
            if (numl == curl)
            {
                return d1 <= d3 ? pre : next;
            }
            else if (numl < curl)
            {
                return d2 < d1 ? cur : pre;
            }
            else
            {
                return d2 <= d3 ? cur : next;
            }
        }

        string nearest(String cur, bool isRight)
        {
            long right = cur.Length >> 1;
            long left = cur.Length - right;
            long l = int.Parse(cur.Substring(0, (int)left));
            if (!isRight) l--;
            else l++;
            if (l == 0) return right == 0 ? "0" : "9";
            StringBuilder ll = new StringBuilder(l.ToString());

            var lArr = l.ToString().ToCharArray(); Array.Reverse(lArr);
            string rr = new string(lArr);

            if (right > ll.Length)
                rr += "9";

            int startIndex = rr.Length - (int)right;
            return ll.Append(rr.Substring(startIndex, rr.Length - startIndex)).ToString();
        }

        
    }
    // @lc code=end
}