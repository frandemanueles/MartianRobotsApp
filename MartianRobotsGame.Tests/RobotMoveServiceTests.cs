using MartianRobotsGame.Models;
using MartianRobotsGame.Services;
using System.Collections.Generic;
using Xunit;

namespace MartianRobotsGame.Tests
{
    public class RobotMoveServiceTests
    {
        private readonly MarsGrid _marsGrid;
        public RobotMoveServiceTests()
        {
            _marsGrid = new MarsGrid(5, 3);
        }

        [Fact]
        public void GivenACoordinate_WhenMoving_ShowNewOrientation()
        {
            IEnumerable<Position> scents = null;
            var expectedPosition = new Position { Orientation = Orientation.N, PositionX = 3, PositionY = 3};
            var position = new Position { Orientation = Orientation.N, PositionX = 3, PositionY = 2 };
            
            List<IMoveCommand> movements = MoveCommand_Extensions.ExampleCommandsRobotTwo();

            var _sut = new RobotMoveService(movements, scents, _marsGrid);

            var finalPosition = _sut.GetFinalPosition(position);

            Assert.Equal(expectedPosition.Orientation, finalPosition.Position.Orientation);
            Assert.Equal(expectedPosition.PositionX, finalPosition.Position.PositionX);
            Assert.Equal(expectedPosition.PositionY, finalPosition.Position.PositionY);
        }

        [Fact]
        public void GivenARobotMove_IfIsInScentPositionPreventItToFall()
        {
            var scents = new List<Position> { new Position { PositionX = 2, PositionY = 3 } };
            var currentPostion = new Position { PositionX = 2, PositionY = 2, Orientation = Orientation.N };
            List<IMoveCommand> movements = MoveCommand_Extensions.ForwardCommands();

            var _sut = new RobotMoveService(movements, scents, _marsGrid);

            var result = _sut.GetFinalPosition(currentPostion);

            Assert.True(!result.IsLost &&
                result.Position.PositionX == 2 &&
                result.Position.PositionY == 3 &&
                result.Position.Orientation == Orientation.S);
        }

        [Fact]
        public void GivenARobotMove_IfThereIsNOScent_RobotIsLost()
        {
            IEnumerable<Position> scents = null;
            var currentPostion = new Position { PositionX = 2, PositionY = 3, Orientation = Orientation.N };
            List<IMoveCommand> movements = MoveCommand_Extensions.ForwardCommands();

            var _sut = new RobotMoveService(movements, scents, _marsGrid);

            var result = _sut.GetFinalPosition(currentPostion);

            Assert.True(result.IsLost &&
                result.Position.PositionX == 2 &&
                result.Position.PositionY == 3 &&
                result.Position.Orientation == Orientation.N);
        }
    }
}
