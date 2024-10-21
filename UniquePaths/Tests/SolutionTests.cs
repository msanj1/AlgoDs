using AutoFixture;
using FluentAssertions;
using Tests.Common;
using UniquePaths;
using Xunit;

namespace Tests;

public class SolutionTests : CommonTestsFixture
{
    [Theory]
    [InlineData(3, 6, 21)]
    public void Method_ShouldDoSomething(int m, int n, int expectedValue)
    {
        var sut = FixtureData.Create<Solution>();

        //do something
        var result = sut.UniquePaths(m, n);

        //assert
        result.Should().Be(expectedValue);
    }
}
