using System.Collections;


namespace Tests
{
    internal class InputWithOutputs : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[]
            {
                new string[]{ "hrn","hrf","er","enn","rfnn" },
                "hernf"
            };

            yield return new object[]
            {
                new string[]{ "z", "o" },
                "zo"
            };

            yield return new object[]
            {
                new string[]{ "z", "o", "z" },
                ""
            };

            yield return new object[]
            {
                new string[]{ "abcdefgh","bdefghij","cghij","dfghij","efghij","fghij","ghij","hij","ij","j","abcdefghi","bdefghijk","cghijk","dfghijk","efghijk","fghijk","ghijk","hijk","ijk","jk","k" },
                ""
            };
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
