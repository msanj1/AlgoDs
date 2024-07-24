using System.Collections;

namespace Tests;

internal class InputWithOutputs : IEnumerable<object[]>
{
    public IEnumerator<object[]> GetEnumerator()
    {
        yield return new object[]
        {
            new[] { 1, 1, 1, 2, 2, 3 },
            2,
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