namespace Application;

public class TrieNode
{
    public Dictionary<char, TrieNode> Children { get; set; } = new();
    public bool IsEndOfWorld { get; set; }
}

public class WordDictionary
{
    private readonly TrieNode _root;

    public WordDictionary()
    {
        _root = new TrieNode();
    }

    public void AddWord(string word)
    {
        var currentNode = _root;
        for (var i = 0; i < word.Length; i++)
        {
            var currentCharacter = word[i];
            if (currentNode.Children.ContainsKey(currentCharacter))
            {
                currentNode = currentNode.Children[currentCharacter];
            }
            else
            {
                var newNode = new TrieNode();
                currentNode.Children.Add(currentCharacter, newNode);
                currentNode = newNode;
            }
        }

        currentNode.IsEndOfWorld = true;
    }

    public bool Search(string word)
    {
        return Dfs(word, _root, 0);
    }

    private bool Dfs(string word, TrieNode node, int index)
    {
        var currentNode = node;
        for (var i = index; i < word.Length; i++)
        {
            var currentCharacter = word[i];
            if (currentCharacter == '.')
            {
                foreach (var key in currentNode.Children.Keys)
                {
                    var value = currentNode.Children[key];

                    var result = Dfs(word, value, i + 1);
                    if (result) return true;
                }

                return false;
            }
            else
            {
                if (!currentNode.Children.ContainsKey(currentCharacter)) return false;

                currentNode = currentNode.Children[currentCharacter];
            }
        }

        return currentNode.IsEndOfWorld;
    }


}