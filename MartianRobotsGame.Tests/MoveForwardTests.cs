using MartianRobotsGame.Models;
using MartianRobotsGame.Services;
using Xunit;

namespace MartianRobotsGame.Tests
{
    public class MoveForwardCommandTests
    {
        private readonly MoveForwardCommand _sut;
        public MoveForwardCommandTests()
        {
            _sut = new MoveForwardCommand();
        }

        [Fact]
        public void WhenInWestOrientation_SubstractOneTo_X_Position()
        {
            var position = new Position { Orientation = Orientation.W, PositionX = 2, PositionY = 1 };
            var result = _sut.Move(position);
            Assert.Equal(position.PositionX - 1, result.PositionX);
        }

        [Fact]
        public void WhenInSouthOrientation_SubstractOneTo_Y_Position()
        {
            var position = new Position { Orientation = Orientation.S, PositionX = 2, PositionY = 1 };
            var result = _sut.Move(position);
            Assert.Equal(position.PositionY - 1, result.PositionY);
        }

        [Fact]
        public void WhenInEastOrientation_AddOneTo_X_Position()
        {
            var position = new Position { Orientation = Orientation.E, PositionX = 2, PositionY = 1 };
            var result = _sut.Move(position);
            Assert.Equal(position.PositionX + 1, result.PositionX);
        }
    }
}
