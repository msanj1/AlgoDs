using Application;
using FluentAssertions;
using Tests.Common;
using Xunit;

namespace Tests;

public class SolutionTests : CommonTestsFixture
{
    [Fact]
    public void Q_ShouldReturnCorrectOutput()
    {
        var persons = new[] { 0, 1, 1, 0, 0, 1, 0 };
        var times = new[] { 0, 5, 10, 15, 20, 25, 30 };

        var sut = new Solution(persons, times);

        var result1 = sut.Q(3);
        var result2 = sut.Q(12);
        var result3 = sut.Q(25);
        var result4 = sut.Q(15);
        var result5 = sut.Q(24);
        var result6 = sut.Q(8);

        result1.Should().Be(0);
        result2.Should().Be(1);
        result3.Should().Be(1);
        result4.Should().Be(0);
        result5.Should().Be(0);
        result6.Should().Be(1);
    }
}