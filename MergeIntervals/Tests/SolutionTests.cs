using AutoFixture;
using FluentAssertions;
using MergeIntervals;
using Tests.Common;
using Xunit;

namespace Tests;

public class SolutionTests : CommonTestsFixture
{
    [Theory]
    [ClassData(typeof(InputWithOutputs))]
    public void Merge_ShouldReturnOutput(int[][] input, int[][] expectedOutput)
    {
        var sut = FixtureData.Create<Solution>();

        //do something
        var result = sut.Merge(input);

        //assert
        result.Should().BeEquivalentTo(expectedOutput, config => config.WithStrictOrdering());
    }
}
