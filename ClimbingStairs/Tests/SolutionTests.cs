using AutoFixture;
using ClimbingStairs;
using FluentAssertions;
using Tests.Common;
using Xunit;

namespace Tests;

public class SolutionTests : CommonTestsFixture
{
    [Fact]
    public void ClimbStairs_ShouldReturnCorrectSteps()
    {
        var sut = FixtureData.Create<Solution>();

        //do something
        var result = sut.ClimbStairs(2);

        //assert
        result.Should().Be(2);
    }
}
