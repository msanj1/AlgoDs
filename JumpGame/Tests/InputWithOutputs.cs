using System.Collections;

namespace Tests
{
    public class InputWithOutputs : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[]
            {
                new int[] { 1,2,0,1,0 },
                true
            };

            yield return new object[]
            {
                new int[] { 1,2,1,0,1 },
                false
            };

            yield return new object[]
            {
                new int[] { 1,3,0,1,0 },
                true
            };
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
