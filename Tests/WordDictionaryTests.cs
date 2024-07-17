//using Application;
//using AutoFixture;
//using FluentAssertions;
//using Moq;
//using Tests.Common;
//using Xunit;

//namespace Tests;

//public class WordDictionaryTests : CommonTestsFixture
//{
//    private readonly WordDictionary _sut;
//    public WordDictionaryTests()
//    {
//        _sut = FixtureData.Build<WordDictionary>().Create();
//        _sut.AddWord("day");
//        _sut.AddWord("bay");
//        _sut.AddWord("may");
//        _sut.AddWord("say");
//    }

//    [Theory]
//    [InlineData("say")]
//    [InlineData("day")]
//    [InlineData(".ay")]
//    [InlineData("b..")]
//    [InlineData("...")]
//    public void Search_ShouldReturnTrue(string input)
//    {
//        var result = _sut.Search(input);

//        result.Should().BeTrue();
//    }
//}