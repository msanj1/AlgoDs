using FluentAssertions.Equivalency;
using Tests.Common;
using Xunit;
using AutoFixture;
using CloneGraph;
using FluentAssertions;

namespace Tests
{
    public class SolutionTests : CommonTestsFixture
    {
        [Fact]
        public void CloneGraph_ShouldReturnExpectedResult()
        {
            var node1 = new CloneGraph.Node(1);
            var node2 = new CloneGraph.Node(2);
            var node3 = new CloneGraph.Node(3);

            node1.neighbors.Add(node2);
            node2.neighbors.Add(node1);

            node2.neighbors.Add(node3);
            node3.neighbors.Add(node2);

            var sut = FixtureData.Create<Solution>();

            var result = sut.CloneGraph(node1);

            result.Should().BeEquivalentTo(node1);
        }
    }
}
