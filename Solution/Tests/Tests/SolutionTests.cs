using Application;
using AutoFixture;
using Tests.Common;
using Xunit;

namespace Tests;

public class SolutionTests : CommonTestsFixture
{
    [Fact]
    public void Method_ShouldDoSomething()
    {
        var sut = FixtureData.Create<Solution>();

        //do something

        //assert
    }
}
