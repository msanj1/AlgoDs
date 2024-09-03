using AutoFixture;
using FluentAssertions;
using NumberOfIslands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tests.Common;
using Xunit;

namespace Tests
{
    public class SolutionTests : CommonTestsFixture
    {
        [Theory]
        [ClassData(typeof(TestCases))]
        public void NumIslands_ShouldReturnExpectedResult(char[][] grid, int expectedOutput)
        {
            var sut = FixtureData.Build<Solution>().Create();

            var result = sut.NumIslands(grid);

            result.Should().Be(expectedOutput);
        }
    }
}
