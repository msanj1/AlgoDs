using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoFixture;
using FluentAssertions;
using Tests.Common;
using Xunit;

namespace Tests
{
    public class SnakeGameTests : CommonTestsFixture
    {
        [Fact]
        public void Move_ShouldReturnCorrectScores()
        {
            var sut = new SnakeGame.SnakeGame(3, 2, new int[][]{new int[]{1,2}, new int[] { 0, 1 } });

            var result1 = sut.Move("R");
            var result2 = sut.Move("D");
            var result3 = sut.Move("R");
            var result4 = sut.Move("U");
            var result5 = sut.Move("L");
            var result6 = sut.Move("U");

            result1.Should().Be(0);
            result2.Should().Be(0);
            result3.Should().Be(1);
            result4.Should().Be(1);
            result5.Should().Be(2);
            result6.Should().Be(-1);
        }
    }
}
