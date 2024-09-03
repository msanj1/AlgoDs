using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests
{
    public class TestCases : IEnumerable<object[]>
    {
        private readonly List<object[]> _data = new List<object[]>
        {
            new object[] {
                new char[][]{
                    new char[] {  '0', '1', '1', '1', '0' },
                    new char[] {  '0', '1', '0', '1', '0' },
                    new char[] {  '1', '1', '0', '0', '0' },
                    new char[] {  '0', '0', '0', '0', '0' }
                },
                1
            },
            new object[] {
                new char[][]{ 
                    new char[] {  '1', '1', '0', '0', '1' },
                    new char[] {  '1', '1', '0', '0', '1' },
                    new char[] {  '0', '0', '1', '0', '0' },
                    new char[] {  '0', '0', '0', '1', '1' } 
                },
                4
            }
        };

        public IEnumerator<object[]> GetEnumerator() => _data.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
