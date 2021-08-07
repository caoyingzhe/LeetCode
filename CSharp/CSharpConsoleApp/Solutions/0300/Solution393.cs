using System;
namespace CSharpConsoleApp.Solutions
{
    /*
     * @lc app=leetcode.cn id=393 lang=csharp
     *
     * [393] UTF-8 编码验证
     *
     * https://leetcode-cn.com/problems/utf-8-validation/description/
     *
     * algorithms
     * Medium (39.26%)
     * Likes:    64
     * Dislikes: 0
     * Total Accepted:    9.5K
     * Total Submissions: 24.3K
     * Testcase Example:  '[197,130,1]'
     *
     * UTF-8 中的一个字符可能的长度为 1 到 4 字节，遵循以下的规则：
     * 
     * 对于 1 字节的字符，字节的第一位设为 0 ，后面 7 位为这个符号的 unicode 码。
     * 对于 n 字节的字符 (n > 1)，第一个字节的前 n 位都设为1，第 n+1 位设为 0 ，后面字节的前两位一律设为 10
     * 。剩下的没有提及的二进制位，全部为这个符号的 unicode 码。
     * 
     * 
     * 这是 UTF-8 编码的工作方式：
     * ⁠  Char. number range  |        UTF-8 octet sequence
     * ⁠     (hexadecimal)    |              (binary)
     * ⁠  --------------------+---------------------------------------------
     * ⁠  0000 0000-0000 007F | 0xxxxxxx
     * ⁠  0000 0080-0000 07FF | 110xxxxx 10xxxxxx
     * ⁠  0000 0800-0000 FFFF | 1110xxxx 10xxxxxx 10xxxxxx
     * ⁠  0001 0000-0010 FFFF | 11110xxx 10xxxxxx 10xxxxxx 10xxxxxx
     * 
     * 
     * 给定一个表示数据的整数数组，返回它是否为有效的 utf-8 编码。
     * 
     * 注意：
     * 输入是整数数组。只有每个整数的 最低 8 个有效位 用来存储数据。这意味着每个整数只表示 1 字节的数据。
     * 
     * 示例 1：
     * data = [197, 130, 1], 表示 8 位的序列: 11000101 10000010 00000001.
     * 
     * 返回 true 。
     * 这是有效的 utf-8 编码，为一个2字节字符，跟着一个1字节字符。
     * 
     * 
     * 示例 2：
     * data = [235, 140, 4], 表示 8 位的序列: 11101011 10001100 00000100.
     * 
     * 返回 false 。
     * 前 3 位都是 1 ，第 4 位为 0 表示它是一个3字节字符。
     * 下一个字节是开头为 10 的延续字节，这是正确的。
     * 但第二个延续字节不以 10 开头，所以是不符合规则的。
     */
    public class Solution393 : SolutionBase
    {
        /// <summary>
        /// 难度
        /// </summary>
        public override Difficulity GetDifficulity() { return Difficulity.Hard; }
        /// <summary>
        /// 关键字:
        /// </summary>
        public override string[] GetKeyWords() { return new string[] { "SortHashMap" }; }
        /// <summary>
        /// 标签： 
        /// </summary>
        public override Tag[] GetTags() { return new Tag[] { Tag.BinarySearch, Tag.DynamicProgramming, Tag.Queue }; }

        public override bool Test(System.Diagnostics.Stopwatch sw)
        {
            bool isSuccess = true;

            int[] data;
            bool result, checkResult;

            //data = new int[] { 197, 130, 1 };
            //result = ValidUtf8(data);
            //checkResult = true;
            //isSuccess = (result == checkResult);
            //Print("isSuccess = {0} | result = {1} | anticipated = {2}", isSuccess, result, checkResult);

            //data = new int[] { 235, 140, 4 };
            //result = ValidUtf8(data);
            //checkResult = false;
            //isSuccess = (result == checkResult);
            //Print("isSuccess = {0} | result = {1} | anticipated = {2}", isSuccess, result, checkResult);

            //data = new int[] { 245, 140, 120 };
            //result = ValidUtf8(data);
            //checkResult = false;
            //isSuccess = (result == checkResult);
            //Print("isSuccess = {0} | result = {1} | anticipated = {2}", isSuccess, result, checkResult);

            //data = new int[] { 245, 140, 508, 128 };
            //result = ValidUtf8(data);
            //checkResult = false;
            //isSuccess = (result == checkResult);
            //Print("isSuccess = {0} | result = {1} | anticipated = {2}", isSuccess, result, checkResult);

            //data = new int[] { 255 };
            //result = ValidUtf8(data);
            //checkResult = false;
            //isSuccess = (result == checkResult);
            //Print("isSuccess = {0} | result = {1} | anticipated = {2}", isSuccess, result, checkResult);

            //data = new int[] { 127 };
            //result = ValidUtf8(data);
            //checkResult = true;
            //isSuccess = (result == checkResult);
            //Print("isSuccess = {0} | result = {1} | anticipated = {2}", isSuccess, result, checkResult);

            data = new int[] { 240, 162, 138, 147, 145 };
            //11110000,10100010,10001010,10010011,10010001  false 原因：最后一位开头为10,必须不能是10才对
            result = ValidUtf8(data);
            checkResult = false;
            isSuccess = (result == checkResult);
            Print("isSuccess = {0} | result = {1} | anticipated = {2}", isSuccess, result, checkResult);

            //data = new int[] { 230, 136, 145 };
            //result = ValidUtf8(data);
            //checkResult = true;
            //isSuccess = (result == checkResult);
            //Print("isSuccess = {0} | result = {1} | anticipated = {2}", isSuccess, result, checkResult);

            //data = new int[] { 240, 162, 138, 147, 17 };
            ////11110000,10100010,10001010,10010011,00010001  true
            //result = ValidUtf8(data);
            //checkResult = true;
            //isSuccess = (result == checkResult);
            //Print("isSuccess = {0} | result = {1} | anticipated = {2}", isSuccess, result, checkResult);

            data = new int[] { 250, 145, 145, 145, 145 };
            //11111010,10010001,10010001,10010001,10010001  false
            result = ValidUtf8(data);
            checkResult = false;
            isSuccess = (result == checkResult);
            Print("isSuccess = {0} | result = {1} | anticipated = {2}", isSuccess, result, checkResult);

            //该UTF8 字段长度大于5，也是符合要求的
            data = new int[] { 228, 189, 160, 229, 165, 189, 13, 10 };
            result = ValidUtf8(data);
            checkResult = true;
            isSuccess = (result == checkResult);
            Print("isSuccess = {0} | result = {1} | anticipated = {2}", isSuccess, result, checkResult);

            return isSuccess;
        }

        public bool ValidUtf8(int[] data)
        {
            //return ValidUtf8_My(data);
            return ValidUtf8_CPP(data);
        }

        public bool ValidUtf8_My(int[] data)
        {

            //Print(GetArrayBiinaryStr(data));

            if (data == null || data.Length == 0)
                return false;

            int n = data.Length;
            if (n > 5) return false;

            int mask0 = 1 << 7;         // 10000000    128
            int mask1 = 1 << 6 | mask0; // 11000000    192
            int mask2 = 1 << 5 | mask1; // 11100000    224
            int mask3 = 1 << 4 | mask2; // 11110000    240
            int maskOut = 1 << 3 | mask3; // 11111000  248 不存在该模式的 UTF8 数据

            int[] firstMasks = new int[] { mask1, mask2, mask3 };

            int firstNum = data[0] % 256;
            if ((firstNum >= maskOut) || (firstNum >= mask0 && firstNum < mask1))
                return false;

            if ((firstNum & mask0) == 0) //多字节判断
            {
                return n == 1;
            }
            else
            {
                if (n == 1)
                    return false;

                int matchNumber = 0;
                for (int i = firstMasks.Length; i >= 1; i--)
                {
                    //此处逻辑是错误的
                    if ((firstNum >= firstMasks[i - 1])) //多字节判断
                    {
                        matchNumber = i;
                        break;
                    }
                }

                //matchNumber 不可以大于4，即个值不可以大于248(11111xxx),范围为110000 
                if (matchNumber < 4 && matchNumber > 0 && matchNumber <= n - 1)
                {
                    for (int i = 1; i <= matchNumber; i++)
                    {
                        if (data[i] < mask0 || data[i] >= mask1) //多字节判断  10xxxxxx ~ 11000000 OK
                        {
                            return false;
                        }
                    }
                    return true;
                }
                return false;
            }
        }



        /// <summary>
        /// 效率似乎有待改进
        /// 49/49 cases passed (128 ms)
        /// Your runtime beats 20 % of csharp submissions
        /// Your memory usage beats 80 % of csharp submissions(27.2 MB)
        /// 
        ///作者：froson
        ///链接：https://leetcode-cn.com/problems/utf-8-validation/solution/248bao-cuo-yuan-yin-by-froson-eqv7/
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public bool ValidUtf8_CPP(int[] data)
        {
            int L = data.Length;
            int i = 0;
            while (i < L)
            {
                int a = Judgelen(data[i]); i++;
                if ((a > L - i) || a == -1)
                    return false;
                for (; a > 0; a--)
                {
                    if (data[i] < 128 || data[i] >= 192) // <10000000 && > 11000000
                        return false;
                    i++;
                }
            }
            return true;
        }

        int Judgelen(int a)
        {
            if ((a >= 248)                //11111xxx
                || (a >= 128 && a < 192)) //10xxxxxx
                return -1;
            else if (a >= 240) //11110000
            {
                return 3;
            }
            else if (a >= 224) //11100000
            {
                return 2;
            }
            else if (a >= 192) //11000000
            {
                return 1;
            }
            else
            {
                return 0;      //0xxxxxxx
            }
        }
    }
}
