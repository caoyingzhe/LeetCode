using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpConsoleApp.Solutions
{
    /*
     * @lc app=leetcode.cn id=218 lang=csharp
     *
     * [218] 天际线问题
     *
     * https://leetcode-cn.com/problems/the-skyline-problem/description/
     *
     * algorithms
     * Hard (46.78%)
     * Likes:    399
     * Dislikes: 0
     * Total Accepted:    15.2K
     * Total Submissions: 32.4K
     * Testcase Example:  '[[2,9,10],[3,7,15],[5,12,12],[15,20,10],[19,24,8]]'
     *
     * 城市的天际线是从远处观看该城市中所有建筑物形成的轮廓的外部轮廓。给你所有建筑物的位置和高度，请返回由这些建筑物形成的 天际线 。
     * 
     * 每个建筑物的几何信息由数组 buildings 表示，其中三元组 buildings[i] = [lefti, righti, heighti]
     * 表示：
     * 
     * 
     * lefti 是第 i 座建筑物左边缘的 x 坐标。
     * righti 是第 i 座建筑物右边缘的 x 坐标。
     * heighti 是第 i 座建筑物的高度。
     * 
     * 
     * 天际线 应该表示为由 “关键点” 组成的列表，格式 [[x1,y1],[x2,y2],...] ，并按 x 坐标 进行 排序
     * 。关键点是水平线段的左端点。列表中最后一个点是最右侧建筑物的终点，y 坐标始终为 0
     * ，仅用于标记天际线的终点。此外，任何两个相邻建筑物之间的地面都应被视为天际线轮廓的一部分。
     * 
     * 注意：输出天际线中不得有连续的相同高度的水平线。例如 [...[2 3], [4 5], [7 5], [11 5], [12 7]...]
     * 是不正确的答案；三条高度为 5 的线应该在最终输出中合并为一个：[...[2 3], [4 5], [12 7], ...]
     *
     * 
     * 示例 1：
     * 输入：buildings = [[2,9,10],[3,7,15],[5,12,12],[15,20,10],[19,24,8]]
     * 输出：[[2,10],[3,15],[7,12],[12,0],[15,10],[20,8],[24,0]]
     * 解释：
     * 图 A 显示输入的所有建筑物的位置和高度，
     * 图 B 显示由这些建筑物形成的天际线。图 B 中的红点表示输出列表中的关键点。
     * 
     * 示例 2：
     * 输入：buildings = [[0,2,3],[2,5,3]]
     * 输出：[[0,3],[5,0]]
     * 
     * 
     * 提示：
     * 1 <= buildings.length <= 10^4
     * 0 <= lefti < righti <= 231 - 1
     * 1 <= heighti <= 231 - 1
     * buildings 按 lefti 非递减排序
     */


    /*
    Leetcode 仅支持有限的 linq功能。具体原因不详；
    根据如下错误信息克制，SortedSet类的 LastIndexof和RemoveAt不支持。这在VisualStudio(Mac)中没有问题。

    Line 39: Char 34: error CS1929: 'SortedSet<int>' does not contain a definition for 'LastIndexOf' and the best extension method overload 'MemoryExtensions.LastIndexOf<int>(Span<int>, int)' requires a receiver of type 'Span<int>' (in Solution.cs)
    Line 39: Char 34: error CS1929: 'SortedSet<int>' does not contain a definition for 'LastIndexOf' and the best extension method overload 'MemoryExtensions.LastIndexOf<int>(Span<int>, int)' requires a receiver of type 'Span<int>' (in Solution.cs)
    Line 39: Char 25: error CS1061: 'SortedSet<int>' does not contain a definition for 'RemoveAt' and no accessible extension method 'RemoveAt' accepting a first argument of type 'SortedSet<int>' could be found (are you missing a using directive or an assembly reference?) (in Solution.cs)
    */


    /// <summary>
    /// 天际线问题
    /// 参考：https://briangordon.github.io/2014/08/the-skyline-problem.html
    /// 
    /// 自己算法的问题， 最后一个case过不去，问题不光是超时效率太差，本质上还是错误，忽略了某种特殊情况。具体需要调试才行。
    /// 对于自己的代码，不用浪费时间，看别人代码即可。
    /// 
    /// 自己的提交使用了下面作者的Java代码。
    /// 作者：windliang
    /// https://leetcode-cn.com/problems/the-skyline-problem/solution/xiang-xi-tong-su-de-si-lu-fen-xi-duo-jie-fa-by--45/
    ///
    /// </summary>
    class Solution218 : SolutionBase
    {
        /// <summary>
        /// 难度
        /// </summary>
        public override Difficulity GetDifficulity() { return Difficulity.Hard; }
        /// <summary>
        /// 关键字:
        ///     DFS => 广度优先搜索（算法导论 第六部分 图算法 22.1章节）
        ///     五大常用算法之四：回溯法（试错思想法）
        /// </summary>
        public override string[] GetKeyWords() { return new string[] { "DFS", "Back_Tracing" }; }
        /// <summary>
        /// 标签： 
        /// </summary>
        public override Tag[] GetTags() { return new Tag[] { Tag.DivideAndConquer, Tag.Heap, Tag.BinaryIndexedTree, Tag.SegmentTree, Tag.LineSweep }; }
        public override bool Test(System.Diagnostics.Stopwatch sw)
        {
            bool isSuccess = true;
            int[][] buildings = null;
            IList<IList<int>> checkResult = null;
            IList<IList<int>> result = null;

            buildings = new int[][] {
                 new int[] {2, 9, 10},
                 new int[] {3, 7, 15},
                 new int[] {5, 12, 12},
                 new int[] {15, 20, 10},
                 new int[] {19, 24, 8}
            };

            checkResult = new int[][] {
                 new int[] {2,10},
                 new int[] {3,15},
                 new int[] {7,12},
                 new int[] {12,0},
                 new int[] {15,10},
                 new int[] {20,8},
                 new int[] {24,0}};

            result = GetSkyline(buildings);
            isSuccess &= IsArray2DSame(result, checkResult);
            System.Diagnostics.Debug.Print("test = {0} \n result =\n{1}\n checkResult =\n{2}\n", isSuccess, GetArray2DStr(result), GetArray2DStr(checkResult));

            //
            //
            //buildings = new int[][] {
            //    new int[] { 2, 9, 10 }, 
            //     new int[] { 3, 7, 15 }, 
            //     new int[] { 5, 12, 12 }, 
            //     new int[] { 15, 20, 10 }, 
            //     new int[] { 19, 24, 8 }};
            //
            //checkResult = new int[][] {
            //    new int[] { 2, 10 }, 
            //     new int[] { 3, 15 }, 
            //     new int[] { 7, 12 }, 
            //     new int[] { 12, 0 }, 
            //     new int[] { 15, 10 }, 
            //     new int[] { 20, 8 }, 
            //     new int[] { 24, 0 }};
            //result = GetSkyline(buildings);
            //isSuccess &= IsArraySame(result, checkResult);
            //System.Diagnostics.Debug.Print("test = {0} \n result =\n{1}\n checkResult =\n{2}\n", isSuccess, GetArrayStr(result), GetArrayStr(checkResult));

            //可以合并矩形轮廓的情况
            //buildings = new int[][] {
            //    new int[] { 0,2,3 },
            //     new int[] { 2,5,3 }};
            //
            //checkResult = new int[][] {
            //    new int[] { 0,3 },
            //     new int[] { 5,0 }};
            //result = GetSkyline(buildings);
            //isSuccess &= IsArraySame(result, checkResult);
            //System.Diagnostics.Debug.Print("test = {0} \n result =\n{1}\n checkResult =\n{2}\n", isSuccess, GetArrayStr(result), GetArrayStr(checkResult));

            //存在左右相邻X坐标相同的矩形的情况
            //buildings = new int[][] {
            //    new int[] { 2,9,10 },
            //     new int[] { 9,12,15 }};
            //
            //checkResult = new int[][] {
            //    new int[] { 2,10 },
            //     new int[] { 9,15 },
            //    new int[] { 12,0 }};
            //result = GetSkyline(buildings);
            //isSuccess &= IsArraySame(result, checkResult);
            //System.Diagnostics.Debug.Print("test = {0} \n result =\n{1}\n checkResult =\n{2}\n", isSuccess, GetArrayStr(result), GetArrayStr(checkResult));

            //存在x左右相等，高度不同被大矩形全包围的情况
            //buildings = new int[][] {
            //    new int[] { 1,2,1 },
            //    new int[] { 1,2,2 },
            //    new int[] { 1,2,3 }};
            //
            //checkResult = new int[][] {
            //    new int[] { 1,3 },
            //    new int[] { 2,0 }};
            //result = GetSkyline(buildings);
            //isSuccess &= IsArraySame(result, checkResult);
            //System.Diagnostics.Debug.Print("test = {0} \n result =\n{1}\n checkResult =\n{2}\n", isSuccess, GetArrayStr(result), GetArrayStr(checkResult));

            //buildings = new int[][] {
            //    new int[] { 4,9,10},
            //    new int[] { 4,9,12 },
            //    new int[] { 5,8,9 },
            //    new int[] { 4,9,15 },
            //    new int[] { 10,12,10 },
            //    new int[] { 10,12,8 }};
            //
            //checkResult = new int[][] {
            //    new int[] { 4,15 },
            //    new int[] { 9,0 },
            //    new int[] { 10,10 },
            //    new int[] { 12,0 }};
            //result = GetSkyline(buildings);
            //isSuccess &= IsArraySame(result, checkResult);
            //System.Diagnostics.Debug.Print("test = {0} \n result =\n{1}\n checkResult =\n{2}\n", isSuccess, GetArrayStr(result), GetArrayStr(checkResult));

            /*
            buildings = new int[][] {
                 new int[]{ 1,38,219}, 
                 new int[] { 2, 19, 228 },
                 new int[] { 2, 64, 106 },
                 new int[] { 3, 80, 65 },
                 new int[] { 3, 84, 8 },
                 new int[] { 4, 12, 8 },
                 new int[] { 4, 25, 14 },
                 new int[] { 4, 46, 225 },
                 new int[] { 4, 67, 187 },
                 new int[] { 5, 36, 118 },
                 new int[] { 5, 48, 211 },
                 new int[] { 5, 55, 97 },
                 new int[] { 6, 42, 92 },
                 new int[] { 6, 56, 188 },
                 new int[] { 7, 37, 42 },
                 new int[] { 7, 49, 78 },
                 new int[] { 7, 84, 163 },
                 new int[] { 8, 44, 212 },
                 new int[] { 9, 42, 125 },
                 new int[] { 9, 85, 200 },
                 new int[] { 9, 100, 74 },
                 new int[] { 10, 13, 58 },
                 new int[] { 11, 30, 179 },
                 new int[] { 12, 32, 215 },
                 new int[] { 12, 33, 161 },
                 new int[] { 12, 61, 198 },
                 new int[] { 13, 38, 48 },
                 new int[] { 13, 65, 222 },
                 new int[] { 14, 22, 1 },
                 new int[] { 15, 70, 222 },
                 new int[] { 16, 19, 196 },
                 new int[] { 16, 24, 142 },
                 new int[] { 16, 25, 176 },
                 new int[] { 16, 57, 114 },
                 new int[] { 18, 45, 1 },
                 new int[] { 19, 79, 149 },
                 new int[] { 20, 33, 53 },
                 new int[] { 21, 29, 41 },
                 new int[] { 23, 77, 43 },
                 new int[] { 24, 41, 75 },
                 new int[] { 24, 94, 20 },
                 new int[] { 27, 63, 2 },
                 new int[] { 31, 69, 58 },
                 new int[] { 31, 88, 123 },
                 new int[] { 31, 88, 146 },
                 new int[] { 33, 61, 27 },
                 new int[] { 35, 62, 190 },
                 new int[] { 35, 81, 116 },
                 new int[] { 37, 97, 81 },
                 new int[] { 38, 78, 99 },
                 new int[] { 39, 51, 125 },
                 new int[] { 39, 98, 144 },
                 new int[] { 40, 95, 4 },
                 new int[] { 45, 89, 229 },
                 new int[] { 47, 49, 10 },
                 new int[] { 47, 99, 152 },
                 new int[] { 48, 67, 69 },
                 new int[] { 48, 72, 1 },
                 new int[] { 49, 73, 204 },
                 new int[] { 49, 77, 117 },
                 new int[] { 50, 61, 174 },
                 new int[] { 50, 76, 147 },
                 new int[] { 52, 64, 4 },
                 new int[] { 52, 89, 84 },
                 new int[] { 54, 70, 201 },
                 new int[] { 57, 76, 47 },
                 new int[] { 58, 61, 215 },
                 new int[] { 58, 98, 57 },
                 new int[] { 61, 95, 190 },
                 new int[] { 66, 71, 34 },
                 new int[] { 66, 99, 53 },
                 new int[] { 67, 74, 9 },
                 new int[] { 68, 97, 175 },
                 new int[] { 70, 88, 131 },
                 new int[] { 74, 77, 155 },
                 new int[] { 74, 99, 145 },
                 new int[] { 76, 88, 26 },
                 new int[] { 82, 87, 40 },
                 new int[] { 83, 84, 132 },
                 new int[] { 88, 99, 99 }};

            checkResult = new int[][] {
                 new int[] {1,219},
                 new int[] {2,228},
                 new int[] {19,225},
                 new int[] {45,229},
                 new int[] {89,190},
                 new int[] {95,175},
                 new int[] {97,152},
                 new int[] {99,74},
                 new int[] {100,0}};
            result = GetSkyline(buildings);
            isSuccess &= IsArraySame(result, checkResult);
            System.Diagnostics.Debug.Print("test = {0} \n result =\n{1}\n checkResult =\n{2}\n", isSuccess, GetArrayStr(result), GetArrayStr(checkResult));
            */
            return isSuccess;
        }

        public IList<IList<int>> GetSkylineMySelf(int[][] buildings)
        {
            #region Java Code
            //PriorityQueue<int[]> pq = new PriorityQueue<>((a, b)->a[0] != b[0] ? a[0] - b[0] : a[1] - b[1]);
            //for (int[] building : buildings)
            //{
            //    pq.offer(new int[] { building[0], -building[2] });
            //    pq.offer(new int[] { building[1], building[2] });
            //}
            //
            //List<List<int>> res = new List<int>();
            //
            //TreeMap<int, int> heights = new TreeMap<>((a, b)->b - a);
            //heights.put(0, 1);
            //int left = 0, height = 0;
            //while (!pq.isEmpty())
            //{
            //    int[] arr = pq.poll();
            //    if (arr[1] < 0)
            //    {
            //        heights.put(-arr[1], heights.getOrDefault(-arr[1], 0) + 1);
            //    }
            //    else
            //    {
            //        heights.put(arr[1], heights.get(arr[1]) - 1);
            //        if (heights.get(arr[1]) == 0) heights.remove(arr[1]);
            //    }
            //    int maxHeight = heights.keySet().iterator().next();
            //    if (maxHeight != height)
            //    {
            //        left = arr[0];
            //        height = maxHeight;
            //        res.Add(Arrays.asList(left, height));
            //    }
            //}
            //
            //return res;
            #endregion

            #region C++ Code
            //vector<pair<int, int>> h;
            ////使用multiset 是平衡树
            //multiset<int> m;
            //vector<vector<int>> res;
            //
            ////1、将每一个建筑分成“两个部分”，例如:[2,9,10]可以转换成[2，-10][9,10]，我们用负值来表示左边界
            //for (const auto&b:buildings)
            //    {
            //            h.push_back({ b[0], -b[2]});
            //            h.push_back({ b[1], b[2]});
            //        }
            //
            //        //2、根据x值对分段进行排序
            //        sort(h.begin(), h.end());
            //        int prev = 0, cur = 0;
            //        m.insert(0);
            //
            //        //3、遍历
            //        for (auto i:h)
            //        {
            //            if (i.second < 0) m.insert(-i.second);  //左端点，高度入堆
            //            else m.erase(m.find(i.second));         //右端点，高度出堆
            //            cur = *m.rbegin();                      //当前最大高度高度
            //            if (cur != prev)
            //            {                      //当前最大高度不等于最大高度perv表示这是一个转折点
            //                res.push_back({ i.first, cur});      //添加坐标
            //        prev = cur;                         //更新最大高度
            //    }
            //}
            //return res;
            #endregion

            List<IList<int>> llist = new List<IList<int>>();

            int processCount = 0;
            for (int i = 0; i < buildings.Length; i++)
            {
                int[] building = buildings[i];

                double w = building[1] - building[0];
                double h = building[2];
                double posX = (building[0] + building[1]);
                double posY = h / 2;

                bool needCreate = true;
                for (int j = 0; j < buildings.Length; j++)
                {
                    if (i == j)
                        continue;
                    var infoCheck = buildings[j];

                    double wCheck = infoCheck[1] - infoCheck[0];
                    double hCheck = infoCheck[2];
                    double posXCheck = (infoCheck[0] + infoCheck[1]);
                    double posYCheck = h / 2;

                    if (posX - w * 0.5f >= posXCheck - wCheck * 0.5f
                        && posX + w * 0.5f <= posXCheck + wCheck * 0.5f
                         && posY - h * 0.5f >= posYCheck - hCheck * 0.5f
                        && posY + h * 0.5f <= posYCheck + hCheck * 0.5f
                    )
                    {
                        needCreate = false;
                        break;
                    }
                }
                if (!needCreate)
                    continue;

                //特殊情况处理，存在右侧点和左侧点相同位置的情况下，需要合并为一个。
                int index = llist.FindIndex(pos => pos[0] == building[0] && pos[1] == building[2]);
                if (index >= 0)
                {
                    //只修改X即可。
                    llist[index][0] = building[1];
                    //llist[index][1] = building[2];
                    //llist[index][2] = building[2];
                }
                else
                {
                    llist.Add(new int[] { building[0], building[2], processCount * 2 });  // x, y, isLeft
                    llist.Add(new int[] { building[1], building[2], processCount * 2 + 1 });  // x, y, isLeft

                    processCount++;
                }
            }



            //自动排序， a,b的x坐标值不等时，返回x值大的，否则返回y值大的。
            llist.Sort((a, b) => { return a[0] != b[0] ? a[0] - b[0] : a[1] - b[1]; });

            List<IList<int>> result = new List<IList<int>>();
            //key = LR pair Index, value = llist index.
            Dictionary<int, int> unCompleteIndexDict = new Dictionary<int, int>();
            List<IList<int>> unCompleteList = new List<IList<int>>();

            int height = 0;
            int[] ptPre = llist[0].ToArray();
            result.Add(new int[] { ptPre[0], ptPre[1] });
            unCompleteIndexDict.Add(ptPre[2] / 2, 0);
            unCompleteList.Add(llist[0]);

            height = ptPre[1];

            for (int i = 1; i < llist.Count; i++)
            {
                int[] pt = llist[i].ToArray();

                int pointIndex = pt[2] / 2;

                //寻找为处理的最高高度
                int preMaxHeight = 0;
                if (pt[0] == 97 || pt[0] == 98)
                {
                    System.Diagnostics.Debug.Print("lastResult =");
                }
                foreach (int index in unCompleteIndexDict.Values)
                {
                    //是自己的左侧点的情况不处理。
                    if (llist[index][2] / 2 == pt[2] / 2)
                        continue;
                    if (llist[index][1] > preMaxHeight)
                        preMaxHeight = llist[index][1];
                }

                if (pt[2] % 2 == 0) //左侧
                {
                    //X重叠的情况，修改最后一个顶点的Y值
                    if (pt[0] == result[result.Count - 1][0])
                    {
                        result[result.Count - 1][1] = pt[1];
                    }
                    else if (pt[1] > preMaxHeight)
                    {
                        {
                            result.Add(new int[] { pt[0], pt[1] }); //添加左侧点
                            height = pt[1];
                        }
                    }

                    //notCompleteDict.Add(pointIndex, pointIndex); //pt[2]/2 代表第几个点。 pt[2]%2==0 代表左侧，pt[2]%2 == 1代表右侧
                    unCompleteIndexDict.Add(pointIndex, i); //pointIndex 作为key方便右侧点处理时的删除。 i作为value方便寻找，获取高度值
                    unCompleteList.Add(llist[i]);
                }
                else //右侧  无视
                {
                    //不高于前高无视
                    //右侧不可能高于前高，无视
                    bool isAdd = false;
                    if (i == llist.Count - 1)
                    {
                        //最后的点
                        result.Add(new int[] { pt[0], 0 });
                        isAdd = true;
                    }
                    else if (pt[0] > ptPre[0] || pt[1] != ptPre[1]) //只需判断X的不同, 相同X不同Y也处理
                    {
                        if (pt[0] == 97 || pt[0] == 98)
                        {
                            System.Diagnostics.Debug.Print("lastResult =" + result[result.Count - 1][1] + "," + result[result.Count - 1][1] + " | pt = " + pt[0] + "," + pt[1] + " | preMaxHeight =" + preMaxHeight);
                        }
                        if (preMaxHeight != result[result.Count - 1][1])
                        {

                            result.Add(new int[] { pt[0], preMaxHeight });
                            isAdd = true;
                        }
                        //if (pt[1] == result[result.Count - 1][1])
                        //{
                        //    result[result.Count - 1][0] = pt[0];
                        //    result[result.Count - 1][1] = preMaxHeight;
                        //}
                    }
                    //删除为处理前高的左侧点。
                    if (unCompleteIndexDict.ContainsKey(pointIndex))
                    {
                        int[] removeInfo = llist[unCompleteIndexDict[pointIndex]].ToArray();
                        int index = unCompleteList.FindIndex(obj => obj[0] == removeInfo[0] && obj[1] == removeInfo[1] && obj[2] == removeInfo[2]);
                        unCompleteList.RemoveAt(index);
                    }
                    bool isRemove = unCompleteIndexDict.Remove(pointIndex);


                    if (isRemove && unCompleteIndexDict.Count == 0)
                    {
                        if (!isAdd)
                            result.Add(new int[] { pt[0], 0 });
                    }
                    height = preMaxHeight;
                }
                ptPre = pt;
            }
            return result;
        }

        public IList<IList<int>> GetSkyline(int[][] buildings)
        {
            //return GetSkylineDivideAndConquer(buildings);
            return GetSkyline_LineSweep(buildings);
        }

        #region ------------  DivideAndConquer --------------
        //https://leetcode-cn.com/problems/the-skyline-problem/solution/xiang-xi-tong-su-de-si-lu-fen-xi-duo-jie-fa-by--45/ 解法1
        //有些类似归并排序的思想，divide and conquer 。

        /// <summary>
        /// 40/40 cases passed (328 ms)
        /// Your runtime beats 75 % of csharp submissions
        /// Your memory usage beats 62.5 % of csharp submissions(34.7 MB)
        /// </summary>
        /// <param name="buildings"></param>
        /// <returns></returns>
        public IList<IList<int>> GetSkylineDivideAndConquer(int[][] buildings)
        {
            if (buildings.Length == 0)
            {
                return new List<IList<int>>();
            }
            return merge(buildings, 0, buildings.Length - 1);
        }

        private IList<IList<int>> merge(int[][] buildings, int start, int end)
        {
            List<IList<int>> res = new List<IList<int>>();
            //只有一个建筑, 将 [x, h], [y, 0] 加入结果
            if (start == end)
            {
                List<int> temp = new List<int>();
                temp.Add(buildings[start][0]);
                temp.Add(buildings[start][2]);
                res.Add(temp);

                temp = new List<int>();
                temp.Add(buildings[start][1]);
                temp.Add(00);
                res.Add(temp);
                return res;
            }
            int mid = (start + end) / 2; // (start + end) >>> 1;
            //第一组解
            IList<IList<int>> Skyline1 = merge(buildings, start, mid);
            //第二组解
            IList<IList<int>> Skyline2 = merge(buildings, mid + 1, end);
            //下边将两组解合并
            int h1 = 0;
            int h2 = 0;
            int i = 0;
            int j = 0;
            while (i < Skyline1.Count || j < Skyline2.Count)
            {
                long x1 = i < Skyline1.Count ? Skyline1[i][0] : long.MaxValue;
                long x2 = j < Skyline2.Count ? Skyline2[j][0] : long.MaxValue;
                long x = 0;
                //比较两个坐标
                if (x1 < x2)
                {
                    h1 = Skyline1[i][1];
                    x = x1;
                    i++;
                }
                else if (x1 > x2)
                {
                    h2 = Skyline2[j][1];
                    x = x2;
                    j++;
                }
                else
                {
                    h1 = Skyline1[i][1];
                    h2 = Skyline2[j][1];
                    x = x1;
                    i++;
                    j++;
                }
                //更新 height
                int height = Math.Max(h1, h2);
                //重复的解不要加入
                if (res.Count == 0 || height != res[res.Count - 1][1])
                {
                    List<int> temp = new List<int>();
                    temp.Add((int)x);
                    temp.Add(height);
                    res.Add(temp);
                }
            }
            return res;
        }
        #endregion

        #region --------------- LineSweep Only For Visual Studio ---------------
        /// <summary>
        /// Only for Visual Studio.
        /// </summary>
        /// <param name="buildings"></param>
        /// <returns></returns>
        public IList<IList<int>> GetSkyline_LineSweep_VSOnly(int[][] buildings)
        {
            List<int[]> all = new List<int[]>();//multiset<pair<int, int>> all;
            List<IList<int>> res = new List<IList<int>>();//vector<vector<int>> res;
            SortedSet<int> heights = new SortedSet<int>(); // 保存所有关键高度的列表
            //1、将每一个建筑分成“两个部分”，例如:[2,9,10]可以转换成[2，-10][9,10]，我们用负值来表示左边界
            foreach (int[] e in buildings) //(int i=0; i<buildings.Length; i++) //for (auto & e : buildings)
            {
                all.Add(new int[] { e[0], -e[2] });//all.insert(make_pair(e[0], -e[2])); // critical point, left corner
                all.Add(new int[] { e[1], e[2] }); //all.insert(make_pair(e[1], e[2])); // critical point, right corner
            }


            //2、根据x值对分段进行排序
            all.Sort((a, b) =>
            {
                if (a[0] == b[0])
                    return a[1] - b[1];
                else
                    return a[0] - b[0];
            }); //按照 元素数组  e[1] 升序排序
            int prev = 0; int maxHeight = 0;
            heights.Add(0); //multiset<int> heights({ 0}); 

            //3、遍历
            int i = 0;
            foreach (int[] p in all) //for (auto & e : all)
            {
                if (p[1] < 0)
                {
                    heights.Add(-p[1]);  //if (p.second < 0) heights.insert(-p.second); // 左端点，高度入堆
                    //Print("i={0}    Insert " + (-p[1]), i);
                }
                else
                {
                    int max = p[1];
                    heights.Remove(max);//else heights.erase(heights.find(p.second)); // 右端点，移除高度
                    //Print("i={0}    Remove " + (max), i);
                }
                // 当前关键点，最大高度
                maxHeight = heights.Max(); //auto maxHeight = *heights.rbegin(); //reverse_iterator rbegin():返回尾元素的逆向迭代器指针
                                           //经过调试，rbegin()的意思是取得迭代器反序的第一个元素，但是列表顺序不变。列表是升序的，所以就是取得升序最后一个值，即最大值最后一个（可能最大值重复）。
                                           //Print("i={0}    curr = " + maxHeight,i);
                                           // 当前最大高度如果不同于上一个高度，说明这是一个转折点
                if (maxHeight != prev)
                {
                    // 更新 last，并加入结果集
                    //Print("i={0}    Add = {1}|{2}  prev={3}", i, p[0], maxHeight, prev);
                    res.Add(new int[] { p[0], maxHeight }); //res.push_back(last); //vector::void push_back  该函数将一个新的元素加到vector的最后面，
                    prev = maxHeight;
                }
                i++;
            }
            return res;
        }

        #endregion

        #region --------------- LineSweep (Leetcode TLE) ---------------
        /// <summary>
        /// 作者：ivan_allen
        /// 链接：https://leetcode-cn.com/problems/the-skyline-problem/solution/218tian-ji-xian-wen-ti-sao-miao-xian-fa-by-ivan_al/
        /// </summary>
        /// <param name="buildings"></param>
        /// <returns></returns>
        public IList<IList<int>> GetSkyline_LineSweep_TLE(int[][] buildings)
        {
            List<int[]> all = new List<int[]>();//multiset<pair<int, int>> all;
            List<IList<int>> res = new List<IList<int>>();//vector<vector<int>> res;
            List<int> heights = new List<int>(); // 保存所有关键高度的列表

            //1、将每一个建筑分成“两个部分”，例如:[2,9,10]可以转换成[2，-10][9,10]，我们用负值来表示左边界
            foreach (int[] e in buildings) //(int i=0; i<buildings.Length; i++) //for (auto & e : buildings)
            {
                all.Add(new int[] { e[0], -e[2] });//all.insert(make_pair(e[0], -e[2])); // critical point, left corner
                all.Add(new int[] { e[1], e[2] }); //all.insert(make_pair(e[1], e[2])); // critical point, right corner
            }

            //2、根据x值对分段进行排序
            all.Sort((a, b) =>
            {
                if (a[0] == b[0])
                    return a[1] - b[1];
                else
                    return a[0] - b[0];
            }); //按照 元素数组  e[1] 升序排序
            int prev = 0; int maxHeight = 0;
            heights.Add(0); //multiset<int> heights({ 0}); 

            //3、遍历
            int i = 0;
            foreach (int[] p in all) //for (auto & e : all)
            {
                if (p[1] < 0)
                {
                    heights.Add(-p[1]);  //if (p.second < 0) heights.insert(-p.second); // 左端点，高度入堆
                    heights.Sort();      //此处为超时原因。 c++中使用multiset自动排序，c#没有找到对应的类。
                    //Print("i={0}    Insert " + (-p[1]), i);
                }
                else
                {
                    int max = p[1];
                    heights.RemoveAt(heights.LastIndexOf(max));//else heights.erase(heights.find(p.second)); // 右端点，移除高度
                                                               //Print("i={0}    Remove " + (max), i);
                }
                // 当前关键点，最大高度
                maxHeight = heights.Max(); //auto maxHeight = *heights.rbegin(); //reverse_iterator rbegin():返回尾元素的逆向迭代器指针
                                           //经过调试，rbegin()的意思是取得迭代器反序的第一个元素，但是列表顺序不变。列表是升序的，所以就是取得升序最后一个值，即最大值最后一个（可能最大值重复）。
                                           //Print("i={0}    curr = " + maxHeight,i);
                                           // 当前最大高度如果不同于上一个高度，说明这是一个转折点
                if (maxHeight != prev)
                {
                    // 更新 last，并加入结果集
                    //Print("i={0}    Add = {1}|{2}  prev={3}", i, p[0], maxHeight, prev);
                    res.Add(new int[] { p[0], maxHeight }); //res.push_back(last); //vector::void push_back  该函数将一个新的元素加到vector的最后面，
                    prev = maxHeight;
                }
                i++;
            }
            return res;
        }
        #endregion

        #region --------------- LineSweep (Leetcode OK) ---------------
        /// <summary>
        /// 扫描线法
        /// 参考代码 c++
        /// 链接：https://leetcode-cn.com/problems/the-skyline-problem/solution/218tian-ji-xian-wen-ti-sao-miao-xian-fa-by-ivan_al/
        ///
        /// 解决问题： C#中 multiset的替代方案。
        ///
        /// multiset两大特性
        /// 1. 自动排序，升序；如果元素是数组，优先对比索引小的。  所以对于{3,2} {3,1} {2,5}, 自动变为 {2,5},{3,1},{3,2}
        /// 2. 允许重复数据，
        ///
        /// 针对该特性，使用 c#中的 SorttedList<key,value>。
        /// 其中key用来记录 multiset中不重复的元素，value用来记录重复次数。
        ///
        /// 40/40 cases passed (1228 ms)
        /// Your runtime beats 12.5 % of csharp submissions
        /// Your memory usage beats 87.5 % of csharp submissions(34.6 MB)
        /// 
        /// 40/40 cases passed (1228 ms)
        /// Your runtime beats 12.5 % of csharp submissions
        /// Your memory usage beats 87.5 % of csharp submissions(34.6 MB)
        /// </summary>
        /// <param name="buildings"></param>
        /// <returns></returns>
        public IList<IList<int>> GetSkyline_LineSweep(int[][] buildings)
        {
            List<int[]> all = new List<int[]>();//multiset<pair<int, int>> all;
            List<IList<int>> res = new List<IList<int>>();//vector<vector<int>> res;
            SortedList<int, int> heights = new SortedList<int, int>(); // 保存所有关键高度的列表

            //1、将每一个建筑分成“两个部分”，例如:[2,9,10]可以转换成[2，-10][9,10]，我们用负值来表示左边界
            foreach (int[] e in buildings) //(int i=0; i<buildings.Length; i++) //for (auto & e : buildings)
            {
                all.Add(new int[] { e[0], -e[2] });//all.insert(make_pair(e[0], -e[2])); // critical point, left corner
                all.Add(new int[] { e[1], e[2] }); //all.insert(make_pair(e[1], e[2])); // critical point, right corner
            }


            //2、根据x值对分段进行排序
            all.Sort((a, b) =>
            {
                if (a[0] == b[0])
                    return a[1] - b[1];
                else
                    return a[0] - b[0];
            }); //按照 元素数组  e[1] 升序排序
            int prev = 0; int maxHeight = 0;
            heights.Add(0, 1); //multiset<int> heights({ 0}); 

            //3、遍历
            int i = 0;
            foreach (int[] p in all) //for (auto & e : all)
            {
                if (p[1] < 0)
                {
                    if (heights.ContainsKey(-p[1]))
                        heights[-p[1]]++;
                    else
                        heights.Add(-p[1], 1);  //if (p.second < 0) heights.insert(-p.second); // 左端点，高度入堆
                    Print("i={0}    Insert " + (-p[1]), i);
                }
                else
                {
                    int max = p[1];
                    if (heights[p[1]] == 1)
                        heights.Remove(p[1]);
                    else
                        heights[p[1]]--;      // (max);//else heights.erase(heights.find(p.second)); // 右端点，移除高度
                    Print("i={0}    Remove {1}", i, p[1]);
                }
                // 当前关键点，最大高度
                maxHeight = heights.Keys.Max(); //auto maxHeight = *heights.rbegin(); //reverse_iterator rbegin():返回尾元素的逆向迭代器指针
                                                //经过调试，rbegin()的意思是取得迭代器反序的第一个元素，但是列表顺序不变。列表是升序的，所以就是取得升序最后一个值，即最大值最后一个（可能最大值重复）。
                                                //Print("i={0}    curr = " + maxHeight,i);
                                                // 当前最大高度如果不同于上一个高度，说明这是一个转折点
                if (maxHeight != prev)
                {
                    // 更新 last，并加入结果集
                    Print("i={0}    Add = {1}|{2}  prev={3}", i, p[0], maxHeight, prev);
                    res.Add(new int[] { p[0], maxHeight }); //res.push_back(last); //vector::void push_back  该函数将一个新的元素加到vector的最后面，
                    prev = maxHeight;
                }
                i++;
            }
            return res;
        }
        #endregion
    }
}
