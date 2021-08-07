using System;
using System.Collections.Generic;
using System.Linq;

namespace CSharpConsoleApp.Solutions
{
    /*
     * @lc app=leetcode.cn id=388 lang=csharp
     *
     * [388] 文件的最长绝对路径
     *
     * https://leetcode-cn.com/problems/longest-absolute-file-path/description/
     *
     * Category	Difficulty	Likes	Dislikes
     * algorithms	Medium (51.51%)	76	-
     * Tags
     * Unknown
     * 
     * Companies
     * google
     * 
     * Total Accepted:    4.7K
     * Total Submissions: 9.2K
     * Testcase Example:  '"dir\\n\\tsubdir1\\n\\tsubdir2\\n\\t\\tfile.ext"'
     *
     * 假设文件系统如下图所示：
     * 
     * 这里将 dir 作为根目录中的唯一目录。dir 包含两个子目录 subdir1 和 subdir2 。subdir1 包含文件 file1.ext
     * 和子目录 subsubdir1；subdir2 包含子目录 subsubdir2，该子目录下包含文件 file2.ext 。
     * 
     * 在文本格式中，如下所示(⟶表示制表符)：
     * 
     * dir
     * ⟶ subdir1
     * ⟶ ⟶ file1.ext
     * ⟶ ⟶ subsubdir1
     * ⟶ subdir2
     * ⟶ ⟶ subsubdir2
     * ⟶ ⟶ ⟶ file2.ext
     * 
     * 如果是代码表示，上面的文件系统可以写为
     * "dir\n\tsubdir1\n\t\tfile1.ext\n\t\tsubsubdir1\n\tsubdir2\n\t\tsubsubdir2\n\t\t\tfile2.ext"
     * 。'\n' 和 '\t' 分别是换行符和制表符。
     * 
     * 文件系统中的每个文件和文件夹都有一个唯一的 绝对路径 ，即必须打开才能到达文件/目录所在位置的目录顺序，所有路径用 '/' 连接。上面例子中，指向
     * file2.ext 的绝对路径是 "dir/subdir2/subsubdir2/file2.ext"
     * 。每个目录名由字母、数字和/或空格组成，每个文件名遵循 name.extension 的格式，其中名称和扩展名由字母、数字和/或空格组成。
     * 
     * 给定一个以上述格式表示文件系统的字符串 input ，返回文件系统中 指向文件的最长绝对路径 的长度。 如果系统中没有文件，返回 0。
     * 
     * 
     * 示例 1：
     * 输入：input = "dir\n\tsubdir1\n\tsubdir2\n\t\tfile.ext"
     * 输出：20
     * 解释：只有一个文件，绝对路径为 "dir/subdir2/file.ext" ，路径长度 20
     * 路径 "dir/subdir1" 不含任何文件
     * 
     * 示例 2：
     * 输入：input =
     * "dir\n\tsubdir1\n\t\tfile1.ext\n\t\tsubsubdir1\n\tsubdir2\n\t\tsubsubdir2\n\t\t\tfile2.ext"
     * 输出：32
     * 解释：存在两个文件：
     * "dir/subdir1/file1.ext" ，路径长度 21
     * "dir/subdir2/subsubdir2/file2.ext" ，路径长度 32
     * 返回 32 ，因为这是最长的路径
     * 
     * 示例 3：
     * 输入：input = "a"
     * 输出：0
     * 解释：不存在任何文件
     * 
     * 示例 4：
     * 输入：input = "file1.txt\nfile2.txt\nlongfile.txt"
     * 输出：12
     * 解释：根目录下有 3 个文件。
     * 因为根目录中任何东西的绝对路径只是名称本身，所以答案是 "longfile.txt" ，路径长度为 12
     * 
     * 
     * 提示：
     * 1 <= input.length <= 10^4
     * input 可能包含小写或大写的英文字母，一个换行符 '\n'，一个指表符 '\t'，一个点 '.'，一个空格 ' '，和数字。
     * 
     */

    // @lc code=start
    public class Solution388 : SolutionBase
    {
        /// <summary>
        /// 难度
        /// </summary>
        public override Difficulity GetDifficulity() { return Difficulity.Easy; }
        /// <summary>
        /// 关键字:
        /// </summary>
        public override string[] GetKeyWords() { return new string[] { "SortHashMap" }; }
        /// <summary>
        /// 标签： 
        /// </summary>
        public override Tag[] GetTags() { return new Tag[] { Tag.Stack, Tag.Design }; }

        public override bool Test(System.Diagnostics.Stopwatch sw)
        {
            bool isSuccess = true;
            string input;
            // "dir/subdir1/file1.ext" ，路径长度 21
            // "dir/subdir2/subsubdir2/file2.ext" ，路径长度 32
            int result, checkResult;

            input = "dir\n\tsubdir1\n\t\tfile1.ext\n\t\tsubsubdir1\n\tsubdir2\n\t\tsubsubdir2\n\t\t\tfile2.ext";
            checkResult = 32;
            result = LengthLongestPath(input);
            isSuccess &= result == checkResult;
            Print("=== {0} | {1} | {2}", result == checkResult, result, checkResult);

            input = "file1.txt\nfile2.txt\nlongfile.txt";
            checkResult = 12;
            result = LengthLongestPath(input);
            isSuccess &= result == checkResult;
            Print("=== {0} | {1} | {2}", result == checkResult, result, checkResult);

            input = "dir\n\tsubdir1\n\tsubdir2\n\t\tfile.ext";
            checkResult = 20;
            result = LengthLongestPath(input);
            isSuccess &= result == checkResult;
            Print("==== {0} | {1} | {2}", result == checkResult, result, checkResult);

            input = "dir\n        file.txt";
            checkResult = 16;
            result = LengthLongestPath(input);
            isSuccess &= result == checkResult;
            Print("==== {0} | {1} | {2}", result == checkResult, result, checkResult);

            input = "a\n\tb\n\t\tc.txt\n\taaaa.txt";
            checkResult = 10;
            result = LengthLongestPath(input);
            isSuccess &= result == checkResult;
            Print("==== {0} | {1} | {2}", result == checkResult, result, checkResult);

            /*
            "skd\
            \\talskjv\
            \\t\\tlskjf\
            \\t\\t\\tklsj.slkj\
            \\t\\tsdlfkj.sdlkjf\
            \\t\\tslkdjf.sdfkj\
            \\tsldkjf\
            \\t\\tlskdjf\
            \\t\\t\\tslkdjf.sldkjf\
            \\t\\t\\tslkjf\
            \\t\\t\\tsfdklj\
            \\t\\t\\tlskjdflk.sdkflj\
            \\t\\t\\tsdlkjfl\
            \\t\\t\\t\\tlskdjf\
            \\t\\t\\t\\t\\tlskdjf.sdlkfj\
            \\t\\t\\t\\t\\tlsdkjf\
            \\t\\t\\t\\t\\t\\tsldkfjl.sdlfkj\
            \\t\\t\\t\\tsldfjlkjd\
            \\t\\t\\tsdlfjlk\
            \\t\\t\\tlsdkjf\
            \\t\\tlsdkjfl\
            \\tskdjfl\
            \\t\\tsladkfjlj\
            \\t\\tlskjdflkjsdlfjsldjfljslkjlkjslkjslfjlskjgldfjlkfdjbljdbkjdlkjkasljfklasjdfkljaklwejrkljewkljfslkjflksjfvsafjlgjfljgklsdf.a"

            my anser = 129
            ecpected answer = 133
             *
             */
            return isSuccess;
        }

        /// <summary>
        /// 作者：jerry_nju
        /// 链接：https://leetcode-cn.com/problems/longest-absolute-file-path/solution/javajian-ji-de-zi-fu-chuan-chu-li-by-jerry_nju/
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public int LengthLongestPath(String input)
        {
            if (input.Length == 0)
            {
                return 0;
            }
            int res = 0;
            int[] sum = new int[input.Length + 1];    //从1开始，第0层就是0

            foreach (String s in input.Split('\n'))
            {
                int level = s.LastIndexOf('\t') + 2;    // 计算当前在第几层（从第一层开始，没有\t就是第一层）
                int len = s.Length - (level - 1);     // 计算当前这一行的长度
                if (s.Contains("."))
                {
                    res = Math.Max(res, sum[level - 1] + len);
                }
                else
                {
                    sum[level] = sum[level - 1] + len + 1;  //是目录，要+1，目录有个/的
                }
            }
            return res;
        }

        public int LengthLongestPath_My_Wrong(string input)
        {
            if (string.IsNullOrEmpty(input))
                return 0;

            string[] lines = input.Split('\n');
            int n = lines.Length;

            Stack<int> tabCountStack = new Stack<int>();
            Stack<string> folderStack = new Stack<string>();
            Stack<int> folderDepthStack = new Stack<int>();
            int maxLen = 0;

            string prefolder = "";
            int preFolderDepth = 0;
            string currenPath = "";
            for (int i = 0; i < n; i++)
            {
                string line = lines[i];
                if (string.IsNullOrEmpty(line))
                    continue;

                Print("{0}", line);

                bool isFolder = line.IndexOf('.') < 0;
                int tmpFolderDepth = line.LastIndexOf('\t') + 1;

                string linePath = line.Substring(tmpFolderDepth);
                if (isFolder)
                {

                    if (tmpFolderDepth == preFolderDepth + 1) //子目录
                    {
                        prefolder = string.IsNullOrEmpty(prefolder) ? linePath : prefolder + '|' + linePath;
                        folderStack.Push(prefolder);
                        folderDepthStack.Push(tmpFolderDepth);
                    }
                    else if (tmpFolderDepth <= preFolderDepth) //同级目录
                    {
                        if (folderStack.Count > 0)
                        {
                            while (true)
                            {
                                folderStack.Pop();
                                folderDepthStack.Pop();

                                if (folderDepthStack.Count == 0)
                                    break;
                                if (tmpFolderDepth > folderDepthStack.Peek())
                                    break;
                            }
                        }

                        string stackFolder = folderStack.Count == 0 ? "" : folderStack.Peek();
                        prefolder = string.IsNullOrEmpty(stackFolder) ? linePath : stackFolder + '|' + linePath;
                        folderStack.Push(prefolder);
                        folderDepthStack.Push(tmpFolderDepth);
                    }
                    preFolderDepth = tmpFolderDepth;

                    Print("prefolder = {0}", prefolder);
                }
                else
                {

                    if (tmpFolderDepth < preFolderDepth + 1)
                    {
                        if (folderStack.Count > 0)
                        {
                            while (true)
                            {
                                folderStack.Pop();
                                folderDepthStack.Pop();

                                if (folderDepthStack.Count == 0)
                                    break;
                                if (tmpFolderDepth == folderDepthStack.Peek() + 1)
                                    break;
                            }
                        }
                        currenPath = string.IsNullOrEmpty(prefolder) ? linePath : prefolder + '|' + linePath;
                        string stackFolder = folderStack.Count == 0 ? "" : folderStack.Peek();
                        prefolder = stackFolder;
                        preFolderDepth = tmpFolderDepth;
                    }
                    currenPath = string.IsNullOrEmpty(prefolder) ? linePath : prefolder + '|' + linePath;

                    maxLen = Math.Max(maxLen, currenPath.Length);

                    Print("maxLen = {0} | {1} | len ={2}", maxLen, currenPath, currenPath.Length);
                }
            }
            return maxLen;
        }
    }
    // @lc code=end
}
