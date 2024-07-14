using System.Collections;

namespace Tests;

internal class BoardWithWordThatExists : IEnumerable<object[]>
{
    public IEnumerator<object[]> GetEnumerator()
    {
        yield return new object[]
        {
            new char[][]
            {
                new char[] { 'A', 'B', 'C', 'D' },
                new char[] { 'S', 'A', 'A', 'T' },
                new char[] { 'A', 'C', 'A', 'E' }
            },
            "CAT"
        };

        yield return new object[]
        {
            new char[][]
            {
                new char[] { 'A', 'B', 'C', 'E' },
                new char[] { 'S', 'F', 'E', 'S' },
                new char[] { 'A', 'D', 'E', 'E' }
            },
            "ABCESEEEFS"
        };

        yield return new object[]
        {
            new char[][]
            {
                new char[] { 'A', 'B', 'C', 'D' }
            },
            "ABCD"
        };

        yield return new object[]
        {
            new char[][]
            {
                new char[] { 'A' },
                new char[] { 'S' },
                new char[] { 'A' }
            },
            "ASA"
        };
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}

internal class BoardWithWordThatDoesNotExist : IEnumerable<object[]>
{
    public IEnumerator<object[]> GetEnumerator()
    {
        yield return new object[]
        {
            new char[][]
            {
                new char[] { 'A', 'B', 'C', 'D' },
                new char[] { 'S', 'A', 'A', 'T' },
                new char[] { 'A', 'C', 'A', 'E' }
            },
            "BAT"
        };

        yield return new object[]
        {
            new char[][]
            {
                new char[] { 'A' },
                new char[] { 'S' },
                new char[] { 'A' }
            },
            "BAT"
        };
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}