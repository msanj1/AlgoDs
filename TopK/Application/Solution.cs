namespace Application;

public class Solution
{
    private readonly Dictionary<int, int> inputNumbers = new();
    private PriorityQueue<int, int> priorityQueue; //min heap

    public int[] TopKFrequent(int[] nums, int k)
    {
        var output = new int[k];
        for (var i = 0; i < nums.Length; i++)
        {
            //1,1,1,2,2,3
            var currentInput = nums[i]; //1

            if (!inputNumbers.ContainsKey(currentInput)) inputNumbers.Add(currentInput, 0);

            inputNumbers[currentInput]++;
        }

        //{1:3, 2:2, 3:1}
        var inputOrdered = new List<(int, int)>();
        foreach (var key in inputNumbers.Keys)
        {
            var value = inputNumbers[key];
            inputOrdered.Add(new ValueTuple<int, int>(key, value));
        }

        priorityQueue = new PriorityQueue<int, int>(inputOrdered, new InputComparer());

        for (var i = 0; i < k; i++) output[i] = priorityQueue.Dequeue();

        return output;
    }
}

public class InputComparer : IComparer<int>
{
    public int Compare(int x, int y)
    {
        return y.CompareTo(x);
    }
}