using AutoFixture;
using FluentAssertions;
using InsertInterval;
using Tests.Common;
using Xunit;

namespace Tests
{
    public class SolutionTests : CommonTestsFixture
    {
        [Theory]
        [ClassData(typeof(InputWithOutputs))]
        public void Insert_ShouldReturnCorrectOutput(int[][] input, int[] newInterval, int[][] expectedOutput)
        {
            var sut = FixtureData.Create<Solution>();

            //do something
            var result = sut.Insert(input, newInterval);

            //assert
            result.Should().BeEquivalentTo(expectedOutput, o => o.WithStrictOrdering());
        }
    }
}
