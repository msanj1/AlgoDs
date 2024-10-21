using System.Collections;

namespace Tests
{
    public class InputWithOutputs : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[]
            {
                new int[] { 1, 1, 3, 3 },
                4
            };

            yield return new object[]
            {
                new int[] { 2,9,8,3,6 },
                16
            };
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
