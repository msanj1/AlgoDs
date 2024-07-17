using Application;
using AutoFixture;
using FluentAssertions;
using Tests.Common;
using Xunit;

namespace Tests;

public class TokenBucketWithIdentifierTests : CommonTestsFixture
{
    [Fact]
    public void Throttle_ShouldNotThrottleWhenRateLimitNotReached()
    {
        var identififer = Guid.NewGuid();

        var sut = new TokenBucketWithIdentifier(10, 1000, false);


        for (var i = 0; i < 10; i++) sut.Throttle(identififer);
    }

    [Fact]
    public void Throttle_ShouldThrottleWhenRateLimitReached()
    {
        var identifier = Guid.NewGuid();

        var sut = new TokenBucketWithIdentifier(9, 1000, false);
        var requests = FixtureData.Build<Guid>().FromSeed(x => identifier).CreateMany(10);

        var func = () =>
        {
            foreach (var request in requests) sut.Throttle(identifier);
        };

        func.Should().Throw<RequestThrottledException>();
    }

    [Fact]
    public void Throttle_ShouldNotThrottleAfterRefillSynchronous()
    {
        var identifier = Guid.NewGuid();

        var sut = new TokenBucketWithIdentifier(10, 1000, true);
        var requests = FixtureData.Build<Guid>().FromSeed(x => identifier).CreateMany(10);

        foreach (var request in requests) sut.Throttle(identifier);

        Thread.Sleep(1050);

        foreach (var request in requests) sut.Throttle(identifier);
    }

    [Fact]
    public void Throttle_ShouldNotThrottleAfterRefillMultiThreaded()
    {
        var identifier = Guid.NewGuid();

        var sut = new TokenBucketWithIdentifier(10, 1000, true);
        var requests = FixtureData.Build<Guid>().CreateMany(10);

        Parallel.ForEach(requests, request => { sut.Throttle(identifier); });

        Thread.Sleep(1050);

        Parallel.ForEach(requests, request => { sut.Throttle(identifier); });
    }
}