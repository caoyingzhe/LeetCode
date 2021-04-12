using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpConsoleApp.Solutions
{
    /// <summary>
    /// 天际线问题
    /// 参考：https://briangordon.github.io/2014/08/the-skyline-problem.html
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
        public override bool Test(Stopwatch sw)
        {
            bool isSuccess = true;
            int[][] buildings = null;
            IList<IList<int>> checkResult = null;
            IList<IList<int>> result = null;

            //buildings = new int[][] {
            //     new int[] {2, 9, 10},
            //     new int[] {3, 7, 15},
            //     new int[] {5, 12, 12},
            //     new int[] {15, 20, 10},
            //     new int[] {19, 24, 8}
            //};
            //
            //checkResult = new int[][] {
            //     new int[] {2,10},
            //     new int[] {3,15},
            //     new int[] {7,12},
            //     new int[] {12,0},
            //     new int[] {15,10},
            //     new int[] {20,8},
            //     new int[] {24,0}};
            //
            //result = GetSkyline(buildings);
            //isSuccess &= IsArraySame(result, checkResult);
            //System.Diagnostics.Debug.Print("test = {0} \n result =\n{1}\n checkResult =\n{2}\n", isSuccess, GetArrayStr(result), GetArrayStr(checkResult));
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

            return isSuccess;
        }

        public IList<IList<int>> GetSkyline(int[][] buildings)
        {
            #region Java Code
            //PriorityQueue<int[]> pq = new PriorityQueue<>((a, b)->a[0] != b[0] ? a[0] - b[0] : a[1] - b[1]);
            //for (int[] building : buildings)
            //{
            //    pq.offer(new int[] { building[0], -building[2] });
            //    pq.offer(new int[] { building[1], building[2] });
            //}
            //
            //List<List<Integer>> res = new ArrayList<>();
            //
            //TreeMap<Integer, Integer> heights = new TreeMap<>((a, b)->b - a);
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
            //        res.add(Arrays.asList(left, height));
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
                if(index >= 0)
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
            llist.Sort((a,b) => { return a[0] != b[0] ? a[0] - b[0] : a[1] - b[1]; } );
            
            List<IList<int>> result = new List<IList<int>>();
            //key = LR pair Index, value = llist index.
            Dictionary<int,int> unCompleteIndexDict= new Dictionary<int,int>();
            List<IList<int>> unCompleteList = new List<IList<int>>();

            int height = 0;
            int[] ptPre = llist[0].ToArray();
            result.Add(new int[] { ptPre[0], ptPre[1] });
            unCompleteIndexDict.Add(ptPre[2]/2, 0);
            unCompleteList.Add(llist[0]);

            height = ptPre[1];

            for (int i=1; i<llist.Count; i++)
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

                if (pt[2]%2 == 0) //左侧
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
    }
}
