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
    [ClassData(typeof(BoardWithWordThatExists))]
    public void Exist_ShouldReturnTrue(char[][] board, string word)
    {
      
        var sut = FixtureData.Build<Solution>().Create();

        var result = sut.Exist(board, word);

        result.Should().BeTrue();
    }

    [Theory]
    [ClassData(typeof(BoardWithWordThatDoesNotExist))]
    public void Exist_ShouldReturnFalse(char[][] board, string word)
    {

        var sut = FixtureData.Build<Solution>().Create();

        var result = sut.Exist(board, word);

        result.Should().BeFalse();
    }
}