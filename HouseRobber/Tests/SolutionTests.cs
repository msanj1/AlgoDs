﻿using AutoFixture;
using ClimbingStairs;
using FluentAssertions;
using Tests.Common;
using Xunit;

namespace Tests;

public class SolutionTests : CommonTestsFixture
{
    [Theory]
    [ClassData(typeof(InputWithOutputs))]
    public void ClimbStairs_ShouldReturnCorrectSteps(int[] input, int expectedOutput)
    {
        var sut = FixtureData.Create<Solution>();

        //do something
        var result = sut.Rob(input);

        //assert
        result.Should().Be(expectedOutput);
    }
}
