using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpConsoleApp.Solutions
{
    /// <summary>
    /// 克隆图
    /// 
    /// 给你无向 连通 图中一个节点的引用，请你返回该图的 深拷贝（克隆）。
    /// 图中的每个节点都包含它的值 val（int） 和其邻居的列表（list[Node]）。
    /// 
    /// Companies:
    /// facebook | google | pocketgems | uber
    /// 
    /// 时间复杂度：O(N)
    /// 空间复杂度：O(N)O(N)。哈希表使用 O(N)O(N) 的空间。
    /// 
    /// 
    /// </summary>
    class Solution133 : SolutionBase
    {
        public class Node
        {
            public int val;
            public IList<Node> neighbors;

            public Node()
            {
                val = 0;
                neighbors = new List<Node>();
            }

            public Node(int _val)
            {
                val = _val;
                neighbors = new List<Node>();
            }

            public Node(int _val, List<Node> _neighbors)
            {
                val = _val;
                neighbors = _neighbors;
            }
        }

        /// <summary>
        /// 难度 
        /// </summary>
        public override Difficulity GetDifficulity() { return Difficulity.Medium; }
        /// <summary>
        /// 关键字:
        /// </summary>
        public override string[] GetKeyWords() { return new string[] { "DFS", "BFS", "Graph", "深拷贝"}; }
        /// <summary>
        /// 标签： 
        /// </summary>
        public override Tag[] GetTags() { return new Tag[] { Tag.Graph, Tag.DepthFirstSearch, Tag.BreadthFirstSearch }; }
        public override bool Test(System.Diagnostics.Stopwatch sw)
        {
            bool isSuccess = true;
            return isSuccess;
        }

        Dictionary<Node, Node> visited = new Dictionary<Node, Node>();

        public Node CloneGraph(Node node)
        {
            //结论： 
            //    DFS快，但稍耗内存，
            //    BFS慢，但内存使用率更低。 
            //Your runtime beats 38.33 % of csharp submissions
            //Your memory usage beats 81.67 % of csharp submissions (31 MB)
            //Your runtime beats 53.33 % of csharp submissions
            //Your memory usage beats 33.33 % of csharp submissions (31.2 MB)
            return CloneGraph_BFS(node);
            //return CloneGraph_DFS(node);
            //Your runtime beats 91.67 % of csharp submissions
            //Your memory usage beats 58.33 % of csharp submissions (31.1 MB)
        }

        // 深度优先搜索  
        //Your runtime beats 91.67 % of csharp submissions
        //Your memory usage beats 58.33 % of csharp submissions(31.1 MB)
        public Node CloneGraph_DFS(Node node)
        {
            if (node == null)
            {
                return node;
            }

            // 如果该节点已经被访问过了，则直接从哈希表中取出对应的克隆节点返回
            if (visited.ContainsKey(node))
            {
                return visited[node];
            }

            // 克隆节点，注意到为了深拷贝我们不会克隆它的邻居的列表
            Node cloneNode = new Node(node.val, new List<Node>());
            // 哈希表存储
            visited.Add(node, cloneNode);

            // 遍历该节点的邻居并更新克隆节点的邻居列表
            foreach (Node neighbor in node.neighbors)
            {
                cloneNode.neighbors.Add(CloneGraph_DFS(neighbor));
            }
            return cloneNode;
        }

        // 广度优先搜索 
        public Node CloneGraph_BFS(Node node)
        {
            if (node == null)
            {
                return node;
            }

            // 将题目给定的节点添加到队列
            Queue<Node> queue = new Queue<Node>();   //LinkedList<Node> queue = new LinkedList<Node>();
            queue.Enqueue(node);
            // 克隆第一个节点并存储到哈希表中
            visited.Add(node, new Node(node.val, new List<Node>()));

            // 广度优先搜索 
            //该处理会添加很多重复节点的判断
            while (queue.Count != 0)
            {
                // 取出队列的头节点
                Node n = queue.Dequeue();  //Node n = queue.remove();
                // 遍历该节点的邻居
                foreach (Node neighbor in n.neighbors)
                {
                    if (!visited.ContainsKey(neighbor))
                    {
                        // 如果没有被访问过，就克隆并存储在哈希表中
                        visited.Add(neighbor, new Node(neighbor.val, new List<Node>()));
                        // 将邻居节点加入队列中
                        queue.Enqueue(neighbor); //queue.add(neighbor);
                    }
                    // 更新当前节点的邻居列表
                    //visited.get(n).neighbors.add(visited.get(neighbor));
                    visited[n].neighbors.Add(visited[neighbor]);
                }
            }

            return visited[node];
        }
    }
}
