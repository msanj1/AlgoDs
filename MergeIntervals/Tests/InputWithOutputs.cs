using System.Collections;

namespace Tests
{
    public class InputWithOutputs : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            //yield return new object[]
            //{
            //    new int[][] { [1,3], [1, 5], [6, 7] },
            //    new int[][] { [1,5], [6, 7] }
            //};

            //yield return new object[]
            //{
            //    new int[][] { [1,2], [2, 3] },
            //    new int[][] { [1,3] }
            //};

            yield return new object[]
            {
                new int[][] { [2,3],[4,5],[6,7],[8,9],[1,10] },
                new int[][] { [1, 10] }
            };
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
