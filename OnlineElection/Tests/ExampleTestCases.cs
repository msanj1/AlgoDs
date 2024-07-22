using System.Collections;

namespace Tests;

internal class InputWithOutputs : IEnumerable<object[]>
{
    public IEnumerator<object[]> GetEnumerator()
    {
        yield return new object[]
        {
            new int[] { 0, 1, 1, 0, 0, 1, 0 },
            new int [] {0, 5, 10, 15, 20, 25, 30},
            new[] { 1, 2 }
        };

        yield return new object[]
        {
            new[] { 1 },
            1,
            new[] { 1 }
        };
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}