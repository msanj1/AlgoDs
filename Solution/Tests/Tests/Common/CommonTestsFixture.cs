using AutoFixture;
using AutoFixture.AutoMoq;

namespace Tests.Common;

public class CommonTestsFixture
{
    public CommonTestsFixture()
    {
        FixtureData = new Fixture()
            .Customize(new AutoMoqCustomization());
    }

    public IFixture FixtureData { get; private set; }
}