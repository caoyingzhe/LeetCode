using System;
using System.Collections.Generic;
namespace CSharpConsoleApp.Solutions
{
    /*
     * @lc app=leetcode.cn id=675 lang=csharp
     *
     * [675] 为高尔夫比赛砍树
     *
     * https://leetcode-cn.com/problems/cut-off-trees-for-golf-event/description/
     *
     * Category	Difficulty	Likes	Dislikes
     * algorithms	Hard (39.73%)	76	-
     * Tags
     * breadth-first-search
     * 
     * Companies
     * amazon
     * 
     * Total Accepted:    2.6K
     * Total Submissions: 6.5K
     * Testcase Example:  '[[1,2,3],[0,0,4],[7,6,5]]'
     *
     * 你被请来给一个要举办高尔夫比赛的树林砍树。树林由一个 m x n 的矩阵表示， 在这个矩阵中：
     * 
     * 
     * 0 表示障碍，无法触碰
     * 1 表示地面，可以行走
     * 比 1 大的数 表示有树的单元格，可以行走，数值表示树的高度
     * 
     * 
     * 每一步，你都可以向上、下、左、右四个方向之一移动一个单位，如果你站的地方有一棵树，那么你可以决定是否要砍倒它。
     * 
     * 你需要按照树的高度从低向高砍掉所有的树，每砍过一颗树，该单元格的值变为 1（即变为地面）。
     * 
     * 你将从 (0, 0) 点开始工作，返回你砍完所有树需要走的最小步数。 如果你无法砍完所有的树，返回 -1 。
     * 
     * 可以保证的是，没有两棵树的高度是相同的，并且你至少需要砍倒一棵树。
     * 
     * 
     * 
     * 示例 1：
     * 输入：forest = [[1,2,3],[0,0,4],[7,6,5]]
     * 输出：6
     * 解释：沿着上面的路径，你可以用 6 步，按从最矮到最高的顺序砍掉这些树。
     * 
     * 示例 2：
     * 输入：forest = [[1,2,3],[0,0,0],[7,6,5]]
     * 输出：-1
     * 解释：由于中间一行被障碍阻塞，无法访问最下面一行中的树。
     * 
     * 
     * 示例 3：
     * 输入：forest = [[2,3,4],[0,0,5],[8,7,6]]
     * 输出：6
     * 解释：可以按与示例 1 相同的路径来砍掉所有的树。
     * (0,0) 位置的树，可以直接砍去，不用算步数。
     * 
     * 
     * 提示：
     * m == forest.length
     * n == forest[i].length
     * 1 
     * 0 
     */

    // @lc code=start
    public class Solution675 : SolutionBase
    {
        /// <summary>
        /// 难度
        /// </summary>
        public override Difficulity GetDifficulity() { return Difficulity.Medium; }
        /// <summary>
        /// 关键字:
        /// </summary>
        public override string[] GetKeyWords() { return new string[] { "A*搜索", "Hadlock 算法", "宽度优先搜索(BFS)" }; }
        /// <summary>
        /// 标签：
        /// </summary>
        public override Tag[] GetTags() { return new Tag[] { Tag.Tree }; }

        public const int N = int.MinValue;
        /// <summary>
        /// </summary>
        /// <param name="sw"></param>
        /// <returns></returns>
        public override bool Test(System.Diagnostics.Stopwatch sw)
        {
            bool isSuccess = true;
            return isSuccess;
        }

        int[] dr = { -1, 1, 0, 0 };
        int[] dc = { 0, 0, -1, 1 };
        public int CutOffTree(IList<IList<int>> forest)
        {
            List<int[]> trees = new List<int[]>();
            for (int r = 0; r < forest.Count; ++r)
            {
                for (int c = 0; c < forest[0].Count; ++c)
                {
                    int v = forest[r][c];
                    if (v > 1) trees.Add(new int[] { v, r, c });
                }
            }

            trees.Sort((a, b) => a[0] - b[0]); //Collections.sort(trees, (a, b) -> int.compare(a[0], b[0]));

            int ans = 0, sr = 0, sc = 0;
            foreach (int[] tree in trees)
            {
                int d = dist(forest, sr, sc, tree[1], tree[2]);
                if (d < 0) return -1;
                ans += d;
                sr = tree[1]; sc = tree[2];
            }
            return ans;
        }

        //作者：LeetCode
        //链接：https://leetcode-cn.com/problems/cut-off-trees-for-golf-event/solution/wei-gao-er-fu-bi-sai-kan-shu-by-leetcode/
        //我们定义距离函数 dist(forest, sr, sc, tr, tc)，
        //该函数计算从源 (sr, sc) 到目标 (tr, tc) 通过障碍物 dist[i][j]==0 的路径距离。
        //（如果路径不可能，此距离函数将返回 -1）。
        public int dist(IList<IList<int>> forest, int sr, int sc, int tr, int tc)
        {
            //方法一：宽度优先搜索(BFS)
            //return bfs(forest, sr, sc, tr, tc);
            //方法二：A*搜索
            //return astar(forest, sr, sc, tr, tc);
            //方法三：Hadlock 算法
            return hadlocks(forest, sr, sc, tr, tc);
        }

        ///方法一：宽度优先搜索(BFS)
        public int bfs(IList<IList<int>> forest, int sr, int sc, int tr, int tc)
        {
            int R = forest.Count, C = forest[0].Count;
            LinkedList<int[]> queue = new LinkedList<int[]>();
            queue.AddLast(new int[] { sr, sc, 0 });
            bool[][] seen = new bool[R][];
            for (int i = 0; i < R; i++) seen[i] = new bool[C];

            seen[sr][sc] = true;
            while (queue.Count != 0)
            {
                int[] cur = queue.First.Value; //queue.poll();
                queue.RemoveFirst();
                if (cur[0] == tr && cur[1] == tc) return cur[2];
                for (int di = 0; di < 4; ++di)
                {
                    int r = cur[0] + dr[di];
                    int c = cur[1] + dc[di];
                    if (0 <= r && r < R && 0 <= c && c < C &&
                            !seen[r][c] && forest[r][c] > 0)
                    {
                        seen[r][c] = true;
                        queue.AddLast(new int[] { r, c, cur[2] + 1 });
                    }
                }
            }
            return -1;
        }
        ///方法二：A*搜索
        public int astar(IList<IList<int>> forest, int sr, int sc, int tr, int tc)
        {
            int R = forest.Count, C = forest[0].Count;
            PriorityQueue<int[]> heap = new PriorityQueue<int[]>(new ComparerSolution675()); //(a, b)->int.compare(a[0], b[0])
            //Java的compare方法 return value1-value2
            heap.Offer(new int[] { 0, 0, sr, sc });

            Dictionary<int, int> cost = new Dictionary<int, int>();
            cost.Add(sr * C + sc, 0);

            while (heap.Count != 0)
            {
                int[] cur = heap.Poll();
                int g = cur[1], r = cur[2], c = cur[3];
                if (r == tr && c == tc) return g;
                for (int di = 0; di < 4; ++di)
                {
                    int nr = r + dr[di], nc = c + dc[di];
                    if (0 <= nr && nr < R && 0 <= nc && nc < C && forest[nr][nc] > 0)
                    {
                        int ncost = g + 1 + Math.Abs(nr - tr) + Math.Abs(nc - tr);

                        if (!cost.ContainsKey(nr * C + nc))
                            cost.Add(nr * C + nc, 9999);
                        if (ncost < cost[nr * C + nc])
                        {
                            cost[nr * C + nc] = ncost;
                            heap.Offer(new int[] { ncost, g + 1, nr, nc });
                        }
                    }
                }
            }
            return -1;
        }

        public class ComparerSolution675 : IComparer<int[]>
        {
            public int Compare(int[] pair1, int[] pair2)
            {
                if (pair2[2] != pair1[2])
                    return pair2[2] - pair1[2]; //升序
                else if (pair2[0] != pair1[0])
                {
                    return pair2[0] - pair1[0]; //升序
                }
                else// (pair2[0] != pair1[0])
                {
                    return pair2[1] - pair1[1]; //升序
                }
            }
        }

        /// <summary>
        /// 方法三：Hadlock 算法
        /// 54/54 cases passed (248 ms)
        /// Your runtime beats 100 % of csharp submissions
        /// Your memory usage beats 100 % of csharp submissions(28.8 MB)
        /// </summary>
        /// <returns></returns>
        public int hadlocks(IList<IList<int>> forest, int sr, int sc, int tr, int tc)
        {
            int R = forest.Count, C = forest[0].Count;
            HashSet<int> processed = new HashSet<int>();
            LinkedList<int[]> deque = new LinkedList<int[]>();
            deque.AddFirst(new int[] { 0, sr, sc }); //deque.offerFirst(new int[] { 0, sr, sc });
            while (deque.Count != 0)
            {
                int[] cur = deque.First.Value; //linkedList.RemoveFirst()  deque.pollFirst();
                deque.RemoveFirst();
                int detours = cur[0], r = cur[1], c = cur[2];
                if (!processed.Contains(r * C + c))
                {
                    processed.Add(r * C + c);
                    if (r == tr && c == tc)
                    {
                        return Math.Abs(sr - tr) + Math.Abs(sc - tc) + 2 * detours;
                    }
                    for (int di = 0; di < 4; ++di)
                    {
                        int nr = r + dr[di];
                        int nc = c + dc[di];
                        bool closer;
                        if (di <= 1) closer = di == 0 ? r > tr : r < tr;
                        else closer = di == 2 ? c > tc : c < tc;
                        if (0 <= nr && nr < R && 0 <= nc && nc < C && forest[nr][nc] > 0)
                        {
                            if (closer)
                                deque.AddFirst(new int[] { detours, nr, nc }); //deque.offerFirst(new int[] { detours, nr, nc });
                            else
                                deque.AddLast(new int[] { detours + 1, nr, nc });//deque.offerLast(new int[] { detours + 1, nr, nc });
                        }
                    }
                }
            }
            return -1;
        }
        // @lc code=end
    }
}