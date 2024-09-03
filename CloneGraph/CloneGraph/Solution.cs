using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloneGraph
{
    public class Solution
    {
        private readonly Dictionary<int, Node> _clonedNodes = new Dictionary<int, Node>();
        private Node _head = null;
        public Node CloneGraph(Node node)
        {
            Dfs(null, node, new HashSet<string>());

            return _head;
        }

        private void Dfs(Node parent, Node node, HashSet<string> visited)
        {
            visited.Add((parent?.val ?? -1) + "-" + node.val);

            if (!_clonedNodes.ContainsKey(node.val))
            {
                var newClonedNode = new Node(node.val);
                _clonedNodes.Add(node.val, newClonedNode);
                if (_head == null)
                {
                    _head = newClonedNode;
                }
            }

            var childClonedNode = _clonedNodes[node.val];

            if (parent != null)
            {
                var parentClonedNode = _clonedNodes[parent.val];
                parentClonedNode.neighbors.Add(childClonedNode);
            }

            foreach (var neighbour in node.neighbors)
            {
                var edge = (node?.val ?? -1) + "-" + neighbour.val;
                if (!visited.Contains(edge))
                {
                    Dfs(node, neighbour, visited);
                }
            }
        }
    }
}
