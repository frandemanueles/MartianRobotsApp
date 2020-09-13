using MartianRobotsGame.Models;
using MartianRobotsGame.Services;
using System.Collections.Generic;
using Xunit;

namespace MartianRobotsGame.Tests
{
    public class RobotMoveServiceTests
    {
        private readonly RobotMoveService _sut;
        public RobotMoveServiceTests()
        {
            //FRRFLLFFRRFLL
            _sut = new RobotMoveService(new List<IMoveCommand> { 
            new MoveForwardCommand(),
            new MoveRightCommand(),
            new MoveRightCommand(),
            new MoveForwardCommand(),
            new MoveLeftCommand(),
            new MoveLeftCommand(),
            new MoveForwardCommand(),
            new MoveForwardCommand(),
            new MoveRightCommand(),
            new MoveRightCommand(),
            new MoveForwardCommand(),
            new MoveLeftCommand(),
            new MoveLeftCommand(),
            });
        }

        [Fact]
        public void GivenACoordinate_WhenMovingRight_ShowNewOrientation()
        {
            var expectedPosition = new Position { Orientation = Orientation.North, PositionX = 3, PositionY = 3};
            var position = new Position { Orientation = Orientation.North, PositionX = 3, PositionY = 2 };

            var finalPosition = _sut.GetFinalPosition(position);

            Assert.Equal(expectedPosition.Orientation, finalPosition.Orientation);
        }
    }
}
