using System.Collections;

namespace Tests
{
    public class InputWithOutputs : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[]
            {
                new int[] { 2,-3,4,-2,2,1,-1,4 },
                8
            };

            yield return new object[]
            {
                new int[] { -1 },
                -1
            };
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
