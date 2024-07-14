namespace Application;

public class Node
{
    public Node(char value)
    {
        Value = value;
    }

    public Dictionary<char, Node> Children { get; } = new();

    public char Value { get; private set; }
    public bool IsEndOfWord { get; set; }

    public Node AddChild(char value)
    {
        var newNode = new Node(value);
        Children.Add(value, newNode);

        return newNode;
    }
}