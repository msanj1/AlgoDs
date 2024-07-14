namespace Application;

public class Trie
{
    public Trie()
    {
        Root = new Node('0');
    }

    public Node Root { get; }

    public void Insert(string word)
    {
        var currentNode = Root;

        for (var i = 0; i < word.Length; i++)
        {
            var currentCharacter = word[i];

            if (currentNode.Children.ContainsKey(currentCharacter))
                currentNode = currentNode.Children[currentCharacter];
            else
                currentNode = currentNode.AddChild(currentCharacter);
        }

        currentNode.IsEndOfWord = true;
    }

    private bool Search(string word, bool isFullWordSearch = true)
    {
        var currentNode = Root;

        for (var i = 0; i < word.Length; i++)
        {
            var currentCharacter = word[i];

            if (currentNode.Children.ContainsKey(currentCharacter))
                currentNode = currentNode.Children[currentCharacter];
            else
                return false;
        }

        return isFullWordSearch ? currentNode.IsEndOfWord : true;
    }

    public bool Search(string word)
    {
        return Search(word, true);
    }

    public bool StartsWith(string prefix)
    {
        return Search(prefix, false);
    }
}