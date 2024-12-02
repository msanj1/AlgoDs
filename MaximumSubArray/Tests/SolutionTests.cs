using AutoFixture;
using FluentAssertions;
using MaximumSubArray;
using Tests.Common;
using Xunit;

namespace Tests;

public class SolutionTests : CommonTestsFixture
{
    [Theory]
    [ClassData(typeof(InputWithOutputs))]
    public void MaxSubArray_ShouldReturnExpectedValue(int[] input, int expectedValue)
    {
        var sut = FixtureData.Create<Solution>();

        //do something
        var result = sut.MaxSubArray(input);

        //assert
        result.Should().Be(expectedValue);
    }
}
