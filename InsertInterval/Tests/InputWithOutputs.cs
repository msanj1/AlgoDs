using System.Collections;

namespace Tests
{
    public class InputWithOutputs : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[]
            {
                new int[][] { new int[] { 1, 3 }, new int[] { 4, 6 } },
                new int[] { 2, 5 },
                new int[][] { new int[] { 1, 6 } }
            };

            yield return new object[]
            {
                new int[][] { new int[] { 1, 2 }, new int[] { 3, 5 }, new int[] { 9, 10 } },
                new int[] { 6, 7 },
                new int[][] { new int[] { 1, 2 }, new int[] { 3, 5 }, new int[] { 6, 7 }, new int[] { 9, 10 } }
            };
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
