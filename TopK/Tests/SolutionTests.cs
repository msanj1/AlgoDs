using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application;
using AutoFixture;
using FluentAssertions;
using Tests.Common;
using Xunit;

namespace Tests
{
    public class SolutionTests : CommonTestsFixture
    {
        [Theory]
        [ClassData(typeof(InputWithOutputs))]
        public void TopKFrequent_ShouldReturnExpectedResults(int[] input, int topK, int[] output)
        {
            var sut = FixtureData.Create<Solution>();

            var result = sut.TopKFrequent(input, topK);

            result.Should().BeEquivalentTo(output, config => config.WithStrictOrdering());
        }
    }
}
