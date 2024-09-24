using AutoFixture;
using FluentAssertions;
using Tests.Common;
using Xunit;

namespace Tests;

public class SolutionTests : CommonTestsFixture
{
    [Theory]
    [ClassData(typeof(InputWithOutputs))]
    public void Method_ShouldDoSomething(string[] input, string output)
    {
        var sut = FixtureData.Create<Solution>();

        //do something
        var result = sut.foreignDictionary(input);

        //assert
        result.Should().Be(output);
    }
}
