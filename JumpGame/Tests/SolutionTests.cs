using AutoFixture;
using FluentAssertions;
using JumpGame;
using Tests.Common;
using Xunit;

namespace Tests;

public class SolutionTests : CommonTestsFixture
{
    [Theory]
    [ClassData(typeof(InputWithOutputs))]
    public void CanJump_ShouldReturnCorrectOutput(int[] input, bool expectedOutput)
    {
        var sut = FixtureData.Create<Solution>();

        //do something
        var resultDp = sut.CanJumpWithDP(input);
        var resultRecursive = sut.CanJumpWithRecursion(input);
        var resultGreedy = sut.CanJumpGreedy(input);

        //assert
        resultDp.Should().Be(expectedOutput);
        resultRecursive.Should().Be(expectedOutput);
        resultGreedy.Should().Be(expectedOutput);
    }
}
