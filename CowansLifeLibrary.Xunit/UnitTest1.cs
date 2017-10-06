using System;
using Xunit;

namespace CowansGameLibrary.Xunit
{
    public class UnitTest1
    {
        [Theory]
        [InlineData (2)]
        [InlineData (3)]
        public void live_cell_with_two_or_three_alive_neighs_will_stay_alive(int i)
        {
            var result = new CowansGame();
            var willLive = CowansGame.LiveOrDie(1,i);
            Assert.True(willLive == true);
        }

        [Theory]
        [InlineData (0)]
        [InlineData (1)]
        [InlineData (4)]
        [InlineData (5)]
        [InlineData (6)]
        [InlineData (7)]
        [InlineData (8)]
        public void live_cell_without_two_or_three_alive_neighs_will_die(int i)
        {
            var result = new CowansGame();
            var willLive = CowansGame.LiveOrDie(1,i);
            Assert.True(willLive == false);
        }

        [Fact]
        public void dead_cell_with_three_alive_neighs_will_come_alive()
        {
            var result = new CowansGame();
            var willLive = CowansGame.LiveOrDie(0,3);
            Assert.True(willLive == true);
        }

        [Theory()]
        [InlineData(0)]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(4)]
        [InlineData(5)]
        [InlineData(6)]
        [InlineData(7)]
        [InlineData(8)]
        public void dead_cell_with_not_three_alive_neighs_will_die(int i)
        {
            var result = new CowansGame();
            var willLive = CowansGame.LiveOrDie(0,i);
            Assert.True(willLive == false);
        }
    }
}
