using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
namespace CSharpConsoleApp.Solutions.Others
{

    //SS:
    //Github OK :
    //ss://YWVzLTI1Ni1nY206ZW5jdGRLeUpmU3U3NlZxem5Ld1R0NkFwQDE4NS4yNDIuNS4yMTU6Mzc0NzM=#Pool_Pool_USUS_3087_3151

    /*
    //https://shadowsocks.org/en/config/quick-guide.html
    Config File
    Shadowsocks accepts JSON format configs like this:

    {
        "server":"my_server_ip",
        "server_port":8388,
        "local_port":1080,
        "password":"barfoo!",
        "method":"chacha20-ietf-poly1305"
    }

    Explanation of each field:
        server: your hostname or server IP (IPv4/IPv6).
        server_port: server port number.
        local_port: local port number.
        password: a password used to encrypt transfer.
        method: encryption method.

    Encryption Method
        The strongest option is an AEAD cipher.
        The recommended choice is "chacha20-ietf-poly1305" or "aes-256-gcm".
        Other stream ciphers are implemented but do not provide integrity and authenticity.
        Unless otherwise specified the encryption method defaults to "table",
        which is not secure.

    URI and QR code
        Shadowsocks for Android / iOS also accepts BASE64 encoded URI format configs:
        ss://BASE64-ENCODED-STRING-WITHOUT-PADDING#TAG

        Note that the above URI doesn't follow RFC3986.
        It means the password here should be plain text, not percent-encoded.

    For example, we have a server at
        192.168.100.1:8888
    using bf-cfb encryption method and password
        test/!@#:.
    Then, with the plain URI
        ss://bf-cfb:test/!@#:@192.168.100.1:8888,

    we can generate the BASE64 encoded URI:
        > console.log( "ss://" + btoa("bf-cfb:test/!@#:@192.168.100.1:8888") )
        ss://YmYtY2ZiOnRlc3QvIUAjOkAxOTIuMTY4LjEwMC4xOjg4ODg

    To help organize and identify these URIs,
    you can append a tag after the BASE64 encoded string:
        ss://YmYtY2ZiOnRlc3QvIUAjOkAxOTIuMTY4LjEwMC4xOjg4ODg#example-server
    This URI can also be encoded to QR code. Then,
    just scan it with your Android / iOS devices:
    */
    public class SolutionShadowshocks : Solution9001
    { }

    public class Solution9001 : SolutionBase
    {
        /// <summary>
        /// 难度
        /// </summary>
        public override Difficulity GetDifficulity() { return Difficulity.Medium; }
        /// <summary>
        /// 关键字:
        /// </summary>
        public override string[] GetKeyWords() { return new string[] { "", }; }
        /// <summary>
        /// 标签：
        /// </summary>
        public override Tag[] GetTags() { return new Tag[] { Tag.Shadowsocks }; }

        public void CreateSolutionAnswerFolder(string dirPath)
        {
            ///Users/wxh/Documents/workspace-study/Leetcode/LeetcodeSolutionAnswers/1800 
            if (Directory.Exists(dirPath))
            {
                for (int i = 0; i < 1800; i++)
                {
                    string dir1 = string.Format("{0:D4}", (i / 100) * 100);
                    string dir2 = string.Format("{0:D4}", i);

                    DirectoryInfo dirInfo = Directory.CreateDirectory(dirPath + "/" + dir1 + "/" + dir2);
                    Print("Dir is Created : " + dirInfo.FullName);
                }
            }
            {
                Print("Dir is not exist : " + dirPath);
            }
        }

        public override bool Test(System.Diagnostics.Stopwatch sw)
        {
            //CreateSolutionAnswerFolder("/Users/wxh/Documents/workspace-study/Leetcode/LeetcodeSolutionAnswers");
            //return false;

            bool isSuccess = true;
            string urlStr;
            string result, checkResult;

            urlStr = "bf-cfb:test/!@#:@192.168.100.1:8888";
            checkResult = "ss://YmYtY2ZiOnRlc3QvIUAjOkAxOTIuMTY4LjEwMC4xOjg4ODg=";

            result = "ss://" + bota(urlStr);
            isSuccess &= IsSame(result, checkResult);
            PrintResult(isSuccess, (result).ToString(), (checkResult).ToString());


            //方式一： 不用 @ 时转义 System.Console.WriteLine("\"hello\"");
            //方式二： 用 @ 时, 两个引号表示一个引号 System.Console.WriteLine(@"""hello""");

            int count = 0;
            foreach (string line in File.ReadLines(@"/Users/wxh/Documents/VPN/ShadowSocks-sub.txt"))
            {
                //string line = @"{""remarks"":""Pool_Pool__49_51"",""server"":""180.149.228.147"",""server_port"":""33992"",""method"":""aes-256-gcm"",""password"":""8n6pwAcrrv2pj6tFY2p3TbQ6"",""plugin"":"""",""plugin_opts"":null},";
                if (line.StartsWith(@"{""remarks""") && line.Contains("US_"))
                {
                    count++;

                    //if (count > 10) //break;
                    //Console.WriteLine(line);
                        GenerateURLS(line);

                    //if (count > 100) break;
                }
            }

            //string line = @"{""remarks"":""Pool_Pool__49_51"",""server"":""180.149.228.147"",""server_port"":""33992"",""method"":""aes-256-gcm"",""password"":""8n6pwAcrrv2pj6tFY2p3TbQ6"",""plugin"":"""",""plugin_opts"":null},";
            //GenerateURLS(line);
            return isSuccess;
        }
        public void GenerateURLS(string filePath, string outputPath = "")
        {
            if (File.Exists(filePath))
            {
                string[] lines = File.ReadAllLines(filePath);

                List<string> result = new List<string>();

                foreach (string line in lines)
                {
                    SSData ss = SSData.ParseJson(line);
                    if (ss != null)
                    {
                        Print("ss://" + bota(ss.GetURL()) + "#" + ss.remarks);
                    }
                }
            }
        }

        public void GenerateURLS(string line)
        {
            SSData ss = SSData.ParseJson(line);
            if (ss != null)
            {
                Print("ss://" + bota(ss.GetURL()) + "#" + ss.remarks);
            }
        }

        /// <summary>
        /// A C# version method of javascript bota function.
        ///     This method can generate same results.
        /// Reference :
        ///     https://stackoverflow.com/questions/46093210/c-sharp-version-of-the-javascript-function-btoa?noredirect=1&lq=1
        /// </summary>
        /// <param name="toEncode"></param>
        /// <returns></returns>
        public string bota(string toEncode)
        {
            //In javascript, 
            byte[] bytes = System.Text.Encoding.GetEncoding(28591).GetBytes(toEncode);
            string toReturn = System.Convert.ToBase64String(bytes);
            return toReturn;
        }

        /// <summary>
        /// Base64加密
        /// 原文链接：https://blog.csdn.net/weixin_39885282/article/details/80501092
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public string EncodeURL(string urlStr)
        {
            //string urlStr = System.Web.HttpUtility.UrlEncode(str);
            string base64Str = Base64Encode(urlStr);
            return base64Str;
        }

        /// <summary>
        /// Base64加密
        /// 原文链接：https://blog.csdn.net/weixin_39885282/article/details/80501092
        /// </summary>
        /// <param name="encodeType">加密采用的编码方式</param>
        /// <param name="source">待加密的明文</param>
        /// <returns></returns>
        public string Base64Encode(string source)//Encoding encodeType, 
        {
            //The encoding used in javascript is iso encoding in javascript. 
            //It can be replicated by using the following c# method:
            string encode = string.Empty;
            byte[] bytes = (System.Text.Encoding.UTF8.GetBytes(source));//encodeType.GetBytes(source);
            try
            {
                encode = Convert.ToBase64String(bytes);
            }
            catch
            {
                encode = source;
            }
            return encode;
        }

        public class SSData
        {
            public string remarks;
            public string server;     //"my_server_ip",
            public string server_port;//"8388",
            public string method;     //"chacha20-ietf-poly1305"
            public string password;   //"barfoo!",
            public string local_port; //"1080",

            //{
            //"remarks":"Pool_Pool__31_30",
            //"server":"37.120.221.5",
            //"server_port":"37473",
            //"method":"aes-256-gcm",
            //"password":"enctdKyJfSu76VqznKwTt6Ap",
            //"plugin":"",
            //"plugin_opts":null},
            public string GetURL()
            {
                //[encryption method] + [:] + [password] + [@] + [server] + [:] + [server_port]
                return string.Format("{0}:{1}@{2}:{3}",
                    method,
                    password,
                    server,
                    server_port
                );
            }

            public static SSData ParseJson(string lineData)
            {
                SSData ssdata = null;
                if (lineData.StartsWith("{") && lineData.EndsWith("},"))
                {
                    int n = lineData.Length;
                    //删除首字母的 "{" 和 结尾的 "},"
                    string line = lineData.Trim().Remove(n - 2, 2).Remove(0, 1);
                    string[] datas = line.Split(',');

                    foreach (string data in datas)
                    {
                        if (!data.Contains(":"))
                            continue;

                        string[] dataArr = data.Split(':');
                        if (dataArr == null || dataArr.Length != 2)
                            continue;

                        if (ssdata == null)
                            ssdata = new SSData();
                        string data_1 = dataArr[0];
                        string data_2 = dataArr[1];
                        if (data_1.StartsWith("\""))
                            data_1 = data_1.Remove(data_1.Length - 1, 1).Remove(0, 1);
                        if (data_2.StartsWith("\""))
                            data_2 = data_2.Remove(data_2.Length - 1, 1).Remove(0, 1);

                        switch (data_1)
                        {
                            case "remarks":
                                ssdata.remarks = data_2;
                                break;
                            case "server":
                                ssdata.server = data_2;
                                break;
                            case "server_port":
                                ssdata.server_port = data_2;
                                break;
                            case "method":
                                ssdata.method = data_2;
                                break;
                            case "password":
                                ssdata.password = data_2;
                                break;
                        }
                    }
                }
                return ssdata;
            }
        }
    }
}
