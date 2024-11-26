using AutoFixture;
using FluentAssertions;
using LongestCommonSubsequence;
using Tests.Common;
using Xunit;

namespace Tests;

public class SolutionTests : CommonTestsFixture
{
    [Theory]
    [InlineData("cat", "crabt", 3)]
    [InlineData("abcd", "abcd", 4)]
    public void LongestCommonSubsequence_ShouldReturnExpectedValue(string text1, string text2, int expectedValue)
    {
        var sut = FixtureData.Create<Solution>();

        //do something
        var result = sut.LongestCommonSubsequence(text1, text2);

        //assert
        result.Should().Be(expectedValue);
    }
}
