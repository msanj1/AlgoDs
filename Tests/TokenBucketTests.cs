using Application;
using AutoFixture;
using FluentAssertions;
using Tests.Common;
using Xunit;

namespace Tests;

public class TokenBucketTests : CommonTestsFixture
{
    public TokenBucketTests()
    {
        
    }
    [Fact]
    public void ShouldThrottle_ShouldSucceedWhenNotThrottled()
    {
        var request = FixtureData.Build<string>().Create();

        using var sut = new TokenBucket(10, 1000, false);

        sut.Throttle(request);
    }

    [Fact]
    public void ShouldThrottle_ShouldRequestThrottledExceptionWhenThrottled()
    {
        var request = FixtureData.Build<string>().Create();

        using var sut = new TokenBucket(0, 1000, false);

        var del = () => sut.Throttle(request);

        del.Should().Throw<RequestThrottledException>();
    }

    [Fact]
    public void ShouldThrottle_ShouldRequestThrottledExceptionAfter10Requests()
    {
        var requests = FixtureData.CreateMany<string>(10);

        using var sut = new TokenBucket(10, 1000, false);

        foreach (var request in requests) sut.Throttle(request);
    }

    [Fact]
    public void ShouldThrottle_ShouldRequestThrottledExceptionAfter10RequestsInParallel()
    {
        var requests = FixtureData.CreateMany<string>(10);

        using var sut = new TokenBucket(10, 500, true);

        Parallel.ForEach(requests, request => { sut.Throttle(request); });

        Thread.Sleep(800);

        Parallel.ForEach(requests, request => { sut.Throttle(request); });
    }
}