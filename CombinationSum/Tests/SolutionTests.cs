using Application;
using AutoFixture;
using FluentAssertions;
using Moq;
using Tests.Common;
using Xunit;

namespace Tests;

public class SolutionTests : CommonTestsFixture
{
    [Theory]
    [ClassData(typeof(CombinationSumTestCases))]
    public void CombinationSum_ShouldReturnCorrectOutput(int[] input, int target, List<List<int>> expectedOutcome)
    {
      
        var sut = FixtureData.Build<Solution>().Create();

        var result = sut.CombinationSum(input, target);

        result.Should().BeEquivalentTo(expectedOutcome, options => options.WithStrictOrdering());
    }
}