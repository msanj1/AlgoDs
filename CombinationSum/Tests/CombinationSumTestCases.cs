using System.Collections;

namespace Tests;

internal class CombinationSumTestCases : IEnumerable<object[]>
{
    public IEnumerator<object[]> GetEnumerator()
    {
        yield return new object[]
        {
            new[] { 2, 5, 6, 9 }, 9, new List<List<int>>
            {
                new() { 2, 2, 5 },
                new() { 9 }
            }
        };
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}