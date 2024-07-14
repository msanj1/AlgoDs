using Application;
using AutoFixture;
using FluentAssertions;
using Moq;
using Tests.Common;
using Xunit;

namespace Tests;

public class SolutionTests : CommonTestsFixture
{

    [Fact]
    public void Insert_ShouldRunWithoutAnyExceptions()
    {
        var wordToEnter = "dog";
        var expectedRoot = new Node('0');
        var dNode = new Node('d');
        var oNode = new Node('o');
        var gNode = new Node('g');
        expectedRoot.Children.Add(dNode.Value, dNode);
        dNode.Children.Add(oNode.Value, oNode);
        oNode.Children.Add(gNode.Value, gNode);
        gNode.IsEndOfWord = true;

        var sut = FixtureData.Build<Trie>().Create();

        sut.Insert(wordToEnter);

        sut.Root.Should().BeEquivalentTo(expectedRoot);

    }

    [Theory]
    [InlineData("dog")]
    [InlineData("og")]
    [InlineData("mobile")]
    [InlineData("bile")]
    public void Search_ShouldReturnTrueWhenEntireWordExists(string input)
    {
        var sut = FixtureData.Build<Trie>().Create();

        sut.Insert(input);

        var result = sut.Search(input);

        result.Should().BeTrue();
    }

    [Theory]
    [InlineData("dog","do")]
    [InlineData("og", "o")]
    [InlineData("mobile","mob")]
    [InlineData("bile", "bil")]
    public void Search_ShouldReturnFalseWhenWordPartiallyExists(string input, string searchInput)
    {
        var sut = FixtureData.Build<Trie>().Create();

        sut.Insert(input);

        var result = sut.Search(searchInput);

        result.Should().BeFalse();
    }

    [Theory]
    [InlineData("dog", "do")]
    [InlineData("og", "o")]
    [InlineData("mobile", "mob")]
    [InlineData("bile", "bil")]
    public void Search_ShouldReturnTrueWhenWordPartiallyExists(string input, string searchInput)
    {
        var sut = FixtureData.Build<Trie>().Create();

        sut.Insert(input);

        var result = sut.StartsWith(searchInput);

        result.Should().BeTrue();
    }
}