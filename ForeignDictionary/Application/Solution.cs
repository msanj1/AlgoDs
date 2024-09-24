public class Solution
{
    private Dictionary<char, Node> _nodes = new Dictionary<char, Node>();

    public string foreignDictionary(string[] words)
    {

        //put every character in _nodes
        foreach (var word in words)
        {
            foreach (var character in word)
            {
                if (!_nodes.ContainsKey(character))
                {
                    var newNode = new Node();
                    newNode.Value = character;
                    _nodes.Add(character, newNode);
                }
            }
        }

        for (int i = 0; i < words.Length && (i + 1) < words.Length; i++)
        {
            var currentWord = words[i];
            var nextWord = words[i + 1];

            //compare the words
            //either there's only a length difference. If that's the case ignore and move on
            //find the first difference

            var minLength = Math.Min(currentWord.Length, nextWord.Length);
            if (currentWord.Length > nextWord.Length && currentWord.Substring(0, minLength) == nextWord.Substring(0, minLength))
            {
                return "";
            }

            for (int b = 0; b < currentWord.Length && b < nextWord.Length; b++)
            {
                var left = currentWord[b];
                var right = nextWord[b];



                if (left != right)
                {
                    var leftNode = _nodes[left];
                    var rightNode = _nodes[right];

                    leftNode.Children.Add(rightNode);
                    break;
                }
            }
        }

        return Process();
    }

    private string Process()
    {
        var visited = new Dictionary<Node, bool>();
        var output = new List<char>();

        foreach (var keypair in _nodes)
        {            
            var key = keypair.Key;
            var value = keypair.Value;

            if (Dfs(value, output, visited))
            {
                return string.Empty;
            }
        }

        output.Reverse();
        return string.Join("", output);
    }

    private bool Dfs(Node node, List<char> output, Dictionary<Node, bool> visited)
    {
        if (visited.ContainsKey(node))
        {
            return visited[node];
        }

        visited[node] = true;

        foreach (var neighbour in node.Children)
        {
            if(Dfs(neighbour, output, visited))
            {
                return true;
            }
        }

        output.Add(node.Value);
        visited[node] = false;

        return false;
    }
}

public class Node
{
    public HashSet<Node> Children { get; private set; } = new HashSet<Node> ();

    public char Value { get; set; }
}
